Imports System.Data.SqlClient

Public Class usrJobCostingCodes
    Public oExcelSS As New ExcelSSGen.Main

#Region "Form Events"

    ''' <summary>
    ''' Event Load form and retrive JobCostingCodes Data
    ''' here 0 in BindJobCostingCodesData(0) shows all data
    ''' </summary>
    Private Sub usrJobCostingCodes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            BindJobCostCodesData(0)
            BindDepartmentData(0)
            BindClassData("0")
        Catch ex As Exception
            oExcelSS.ErrorLog("usrJobCostCodes_Load Error#" & ex.ToString())
            MessageBox.Show("Failed to retrieve Department Data or Class Data.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reset the form control and show the grid screen
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            pnlAddEditCostingCodes.Visible = False
            pnlViewCostingCodes.Visible = True
        Catch ex As Exception
            oExcelSS.ErrorLog("btnCancel_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to cancel the operation.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save or update data
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(lblID.Text) Then
                InsertUpdateJobcostCodes(0)
            Else
                InsertUpdateJobcostCodes(Convert.ToInt32(lblID.Text))
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("btnSave_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to save Jobcost Codes.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '''<summary>
    '''Event captures the delete and edit button when clicked
    '''</summary>
    Private Sub dgvCostingCodes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostingCodes.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim ID As Integer = dgvCostingCodes.Rows(e.RowIndex).Cells(2).Value.ToString()

                '7 is  form delete button column
                If e.ColumnIndex = 1 Then
                    Dim Result As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If Result = DialogResult.OK Then
                        Dim param As SqlParameter() = New SqlParameter(0) {}
                        param(0) = New SqlParameter("@CodeNo", ID)
                        oExcelSS.ExecuteProc("uspConfiguration_DeleteJobcostCodes", param)
                        BindJobCostCodesData(0)
                        MessageBox.Show("Jobcost Code deleted successfully.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ' 6 is for edit button column or any other column then show edit screen
                ElseIf sender Is Nothing OrElse e.ColumnIndex = 0 Then

                    Dim dt As DataTable = GetJobcostCodesInfo(ID)
                    If Not dt Is Nothing And dt.Rows.Count > 0 Then

                        lblID.Text = Convert.ToString(dt.Rows(0)("CodeNo"))
                        txtCodeNo.Text = Convert.ToString(dt.Rows(0)("CodeNo")).Trim
                        ddlDepartment.SelectedValue = Convert.ToString(dt.Rows(0)("Department")).Trim
                        txtDescription.Text = Convert.ToString(dt.Rows(0)("Description")).Trim
                        ddlCls.SelectedValue = Convert.ToString(dt.Rows(0)("Class")).Trim
                        txtKey.Text = Convert.ToString(dt.Rows(0)("Key")).Trim
                        btnSave.Text = "Update"
                    End If
                    pnlAddEditCostingCodes.Visible = True
                    pnlViewCostingCodes.Visible = False
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("ddgvCostingCodes_CellContentClick Error#" & ex.ToString())
            MessageBox.Show("Failed to perform the operation", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Event shows the screen to add record
    ''' </summary>
    Private Sub btnAddCostingCodes_Click(sender As Object, e As EventArgs) Handles btnAddCostingCodes.Click
        Try
            ClearControls()
            pnlAddEditCostingCodes.Visible = True
            btnSave.Text = "Save"
            pnlViewCostingCodes.Visible = False
        Catch ex As Exception
            oExcelSS.ErrorLog("btnAddCostingCodes_Click Error#" & ex.Message.ToString())
            MessageBox.Show("Failed to show Add Jobcost Codes screen.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCostingCodes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostingCodes.CellDoubleClick
        Try
            dgvCostingCodes_CellContentClick(Nothing, e)
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvCostingCodes_CellDoubleClick Error#" & ex.ToString())
            MessageBox.Show("Failed to show Add Jobcost Codes screen.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '''<summary>
    '''The txtCodeNo_KeyPress event make sure the input as numeric only
    '''</summary>
    Private Sub txtCodeNo_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodeNo.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
   

#End Region

#Region "Private Methods"

    '''<summary>
    '''The GetJobcostCodesInfo method returns all the Codes data
    '''</summary>
    Private Function GetJobcostCodesInfo(ID As Integer) As DataTable
        Dim dtJobcostCodes As New DataTable("JobcostCodesTable")

        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@CodeNo", ID)
        dtJobcostCodes = oExcelSS.getDataTable("uspConfiguration_GetJobcostCodes", True, param)

        Return dtJobcostCodes

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
    '''The GetClassInfo method returns all the Class data
    '''</summary>
    Private Function GetClassInfo(ID As String) As DataTable
        Dim dtClass As New DataTable("ClassTable")

        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@ID", ID)
        dtClass = oExcelSS.getDataTable("uspConfiguration_GetClass", True, param)

        Return dtClass

    End Function

    '''<summary>
    '''The BindDepartmentData Sub binds data to datagridview 
    '''</summary>
    Private Sub BindJobCostCodesData(Id As Integer)
        Dim dtJobcostCodes As DataTable = GetJobcostCodesInfo(Id)
        dgvCostingCodes.DataSource = dtJobcostCodes
    End Sub

    '''<summary>
    '''The BindDepartmentData Sub binds data to combo 
    '''</summary>
    Private Sub BindDepartmentData(Id As Integer)
        Dim dtDept As DataTable = GetDepartmentInfo(Id)
        ddlDepartment.DataSource = dtDept
        ddlDepartment.ValueMember = "Num"
        ddlDepartment.DisplayMember = "Description"
        ddlDepartment.SelectedIndex = -1

    End Sub

    '''<summary>
    '''The BindClassData Sub binds data to combo 
    '''</summary>
    Private Sub BindClassData(Id As String)
        Dim dtClass As DataTable = GetClassInfo(Id)
        ddlCls.DataSource = dtClass
        ddlCls.ValueMember = "ID"
        ddlCls.DisplayMember = "Description"
        ddlCls.SelectedIndex = -1

    End Sub

    '''<summary>
    '''ClearControls resets the input controls
    '''</summary>
    Private Sub ClearControls()
        lblID.Text = String.Empty
        txtCodeNo.Text = String.Empty
        ddlDepartment.SelectedIndex = -1
        txtDescription.Text = String.Empty
        ddlCls.SelectedIndex = -1
        txtKey.Text = String.Empty
    End Sub

    '''<summary>
    '''The InsertUpdateJobcostCodes inserts or updates the Jobcost codes 
    ''' IF Id is 0 it inserts else it updates the Jobcost codes record based on Id value
    '''</summary>
    Private Sub InsertUpdateJobcostCodes(Id As Integer)
        If (ValidateInputs()) Then
            Dim param As SqlParameter() = New SqlParameter(6) {}
            Dim OutStatus As String = String.Empty

            param(0) = New SqlParameter("@Id", Id)
            param(1) = New SqlParameter("@CodeNo", Convert.ToInt32(txtCodeNo.Text))
            param(2) = New SqlParameter("@Department", Convert.ToInt32(ddlDepartment.SelectedValue))
            param(3) = New SqlParameter("@Description", txtDescription.Text)
            param(4) = New SqlParameter("@Class", ddlCls.SelectedValue)
            param(5) = New SqlParameter("@Key", txtKey.Text)
            param(6) = New SqlParameter("@OutStatus", "")
            param(6).Direction = ParameterDirection.Output
            param(6).Size = 1000




            Dim success As Integer = oExcelSS.ExecuteProc("uspConfiguration_JobcostCodesInsertUpdate", param)
            OutStatus = param(6).Value
            If (OutStatus = "45000") Then
                MessageBox.Show("Jobcost Code Number already exist", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                pnlAddEditCostingCodes.Visible = False
                pnlViewCostingCodes.Visible = True
                BindJobCostCodesData(0)
                MessageBox.Show("Jobcost Code saved successfully.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        End If
    End Sub

    '''<summary>
    '''ValidateInputs validates required fields for Jobcost Codes
    '''</summary>
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(txtCodeNo.Text) Then
            MessageBox.Show("Please enter Code No.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf Convert.ToInt32(txtCodeNo.Text) <= 0 OrElse Convert.ToInt32(txtCodeNo.Text) >= 1000 Then
            MessageBox.Show("Jobcost Code No. should be between 1 and 1000.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf ddlDepartment.SelectedIndex = -1 Then
            MessageBox.Show("Please select Department.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter Description.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf ddlCls.SelectedIndex = -1 Then
            MessageBox.Show("Please select Class.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtKey.Text) Then
            MessageBox.Show("Please enter Key.", "Jobcost Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

#End Region


End Class

