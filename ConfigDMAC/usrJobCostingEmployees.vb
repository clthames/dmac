Imports System.Data.SqlClient

Public Class usrJobCostingEmployees
    Public oExcelSS As New ExcelSSGen.Main

#Region "Form Events"

    ''' <summary>
    ''' Event Load form and retrive JobCostingEmployees Data
    ''' here 0 in BindJobCostingEmployeesData(0) shows all data
    ''' </summary>
    Private Sub usrJobCostingEmployees_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            BindJobCostEmployeesData(0)
            BindDepartmentData(0)
        Catch ex As Exception
            oExcelSS.ErrorLog("usrJobCostEmployees_Load Error#" & ex.ToString())
            MessageBox.Show("Failed to retrieve Department Data.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reset the form control and show the grid screen
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            pnlAddEditCostingEmployees.Visible = False
            pnlViewCostingEmployees.Visible = True
        Catch ex As Exception
            oExcelSS.ErrorLog("btnCancel_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to cancel the operation.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save or update data
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(lblID.Text) Then
                InsertUpdateJobcostEmployees(0)
            Else
                InsertUpdateJobcostEmployees(Convert.ToInt32(lblID.Text))
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("btnSave_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to save Jobcost Employees.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '''<summary>
    '''Event captures the delete and edit button when clicked
    '''</summary>
    Private Sub dgvCostingEmployees_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostingEmployees.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim ID As Integer = dgvCostingEmployees.Rows(e.RowIndex).Cells(2).Value.ToString()

                If e.ColumnIndex = 1 Then
                    Dim Result As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If Result = DialogResult.OK Then
                        Dim param As SqlParameter() = New SqlParameter(0) {}
                        param(0) = New SqlParameter("@EmpNo", ID)
                        oExcelSS.ExecuteProc("uspConfiguration_DeleteJobcostEmployees", param)
                        BindJobCostEmployeesData(0)
                        MessageBox.Show("Jobcost Employee deleted successfully.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                ElseIf sender Is Nothing OrElse e.ColumnIndex = 0 Then

                    Dim dt As DataTable = GetJobcostEmployeesInfo(ID)
                    If Not dt Is Nothing And dt.Rows.Count > 0 Then

                        lblID.Text = Convert.ToString(dt.Rows(0)("EmpNo"))
                        txtEmpNo.Text = Convert.ToString(dt.Rows(0)("EmpNo")).Trim
                        ddlDepartment.SelectedValue = Convert.ToString(dt.Rows(0)("Department")).Trim
                        txtFirstName.Text = Convert.ToString(dt.Rows(0)("FirstName")).Trim
                        txtLastName.Text = Convert.ToString(dt.Rows(0)("LastName")).Trim
                        btnSave.Text = "Update"
                    End If
                    pnlAddEditCostingEmployees.Visible = True
                    pnlViewCostingEmployees.Visible = False
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("ddgvCostingEmployees_CellContentClick Error#" & ex.ToString())
            MessageBox.Show("Failed to perform the operation", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Event shows the screen to add record
    ''' </summary>
    Private Sub btnAddCostingEmployees_Click(sender As Object, e As EventArgs) Handles btnAddCostingEmployees.Click
        Try
            ClearControls()
            pnlAddEditCostingEmployees.Visible = True
            btnSave.Text = "Save"
            pnlViewCostingEmployees.Visible = False
        Catch ex As Exception
            oExcelSS.ErrorLog("btnAddCostingEmployees_Click Error#" & ex.Message.ToString())
            MessageBox.Show("Failed to show Add Jobcost Employee screen.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCostingEmployees_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostingEmployees.CellDoubleClick
        Try
            dgvCostingEmployees_CellContentClick(Nothing, e)
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvCostingEmployees_CellDoubleClick Error#" & ex.ToString())
            MessageBox.Show("Failed to show Add Jobcost Employee screen.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '''<summary>
    '''The txtEmpNo_KeyPress event make sure the input as numeric only
    '''</summary>
    Private Sub txtEmpNo_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpNo.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub


#End Region

#Region "Private Methods"

    '''<summary>
    '''The GetJobcostEmployeesInfo method returns all the Employees data
    '''</summary>
    Private Function GetJobcostEmployeesInfo(ID As Integer) As DataTable
        Dim dtJobcostEmployees As New DataTable("JobcostEmployeesTable")

        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@EmpNo", ID)
        dtJobcostEmployees = oExcelSS.getDataTable("uspConfiguration_GetJobcostEmployees", True, param)

        Return dtJobcostEmployees

    End Function

    '''<summary>
    '''The GetDepartmnetInfo method returns all the Department data
    '''</summary>
    Private Function GetDepartmentInfo(ID As Integer) As DataTable
        Dim dtDepartment As New DataTable("DepartmentTable")

        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@Num", ID)
        dtDepartment = oExcelSS.getDataTable("uspConfiguration_GetDepartment", True, param)

        Return dtDepartment

    End Function

    '''<summary>
    '''The BindDepartmentData Sub binds data to datagridview 
    '''</summary>
    Private Sub BindJobCostEmployeesData(Id As Integer)
        Dim dtJobcostEmployees As DataTable = GetJobcostEmployeesInfo(Id)
        dgvCostingEmployees.DataSource = dtJobcostEmployees
    End Sub

    '''<summary>
    '''The BindDepartmentData Sub binds data to combo 
    '''</summary>
    Private Sub BindDepartmentData(Id As Integer)
        Dim dtDept As DataTable = GetDepartmentInfo(Id)
        ddlDepartment.DataSource = dtDept
        ddlDepartment.ValueMember = "Num"
        ddlDepartment.DisplayMember = "Num"
        ddlDepartment.SelectedIndex = -1

    End Sub

    '''<summary>
    '''ClearControls resets the input controls
    '''</summary>
    Private Sub ClearControls()
        lblID.Text = String.Empty
        txtEmpNo.Text = String.Empty
        ddlDepartment.SelectedIndex = -1
        txtFirstName.Text = String.Empty
        txtLastName.Text = String.Empty
    End Sub

    '''<summary>
    '''The InsertUpdateJobcostEmployees inserts or updates the Jobcost Employees 
    ''' IF Id is 0 it inserts else it updates the Jobcost Employees record based on Id value
    '''</summary>
    Private Sub InsertUpdateJobcostEmployees(Id As Integer)
        If (ValidateInputs()) Then
            Dim param As SqlParameter() = New SqlParameter(5) {}
            Dim OutStatus As String = String.Empty

            param(0) = New SqlParameter("@Id", Id)
            param(1) = New SqlParameter("@EmpNo", Convert.ToInt32(txtEmpNo.Text))
            param(2) = New SqlParameter("@Department", Convert.ToInt32(ddlDepartment.SelectedValue))
            param(3) = New SqlParameter("@FirstName", txtFirstName.Text)
            param(4) = New SqlParameter("@LastName", txtLastName.Text)
            param(5) = New SqlParameter("@OutStatus", "")
            param(5).Direction = ParameterDirection.Output
            param(5).Size = 1000

            Dim success As Integer = oExcelSS.ExecuteProc("uspConfiguration_JobcostEmployeesInsertUpdate", param)
            OutStatus = param(5).Value
            If (OutStatus = "45000") Then
                MessageBox.Show("Jobcost Employee Number already exist", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                pnlAddEditCostingEmployees.Visible = False
                pnlViewCostingEmployees.Visible = True
                BindJobCostEmployeesData(0)
                MessageBox.Show("Jobcost Employee saved successfully.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    '''<summary>
    '''ValidateInputs validates required fields for Jobcost Employees
    '''</summary>
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(txtEmpNo.Text) Then
            MessageBox.Show("Please enter Employee No.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf Convert.ToInt32(txtEmpNo.Text) <= 0 OrElse Convert.ToInt32(txtEmpNo.Text) >= 10000 Then
            MessageBox.Show("Jobcost Employee No. should be between 1 and 10000.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf ddlDepartment.SelectedIndex = -1 Then
            MessageBox.Show("Please select Department.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter First Name.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter Last Name.", "Jobcost Employees", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

#End Region


  

End Class

