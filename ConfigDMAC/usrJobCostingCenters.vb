Imports System.Data.SqlClient

Public Class usrJobCostingCenters
    Public oExcelSS As New ExcelSSGen.Main

#Region "Form Events"

    ''' <summary>
    ''' Event Load form and retrive JobCosting Data
    ''' here 0 in BindJobCostingData(0) shows all data
    ''' </summary>
    Private Sub usrJobCostingCenter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            BindJobCostCenterData(0)
            BindDepartmentData(0)
        Catch ex As Exception
            oExcelSS.ErrorLog("usrJobCostDept_Load Error#" & ex.ToString())
            MessageBox.Show("Failed to retrieve Department Data.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reset the form control and show the grid screen
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            pnlAddEditCosting.Visible = False
            pnlViewCosting.Visible = True
        Catch ex As Exception
            oExcelSS.ErrorLog("btnCancel_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to cancel the operation.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save or update data
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(lblID.Text) Then
                InsertUpdateJobcostCenter(0)
            Else
                InsertUpdateJobcostCenter(Convert.ToInt32(lblID.Text))
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("btnSave_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to save Jobcost Center.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '''<summary>
    '''Event captures the delete and edit button when clicked
    '''</summary>
    Private Sub dgvCosting_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCosting.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim ID As Integer = dgvCosting.Rows(e.RowIndex).Cells(2).Value.ToString()

                '7 is  form delete button column
                If e.ColumnIndex = 1 Then
                    Dim Result As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If Result = DialogResult.OK Then
                        Dim param As SqlParameter() = New SqlParameter(0) {}
                        param(0) = New SqlParameter("@Num", ID)
                        oExcelSS.ExecuteProc("uspConfiguration_DeleteJobcostCenter", param)
                        BindJobCostCenterData(0)
                        MessageBox.Show("Jobcost Center deleted successfully.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ' 6 is for edit button column or any other column then show edit screen
                ElseIf sender Is Nothing OrElse e.ColumnIndex = 0 Then

                    Dim dt As DataTable = GetJobcostCenterInfo(ID)
                    If Not dt Is Nothing And dt.Rows.Count > 0 Then

                        lblID.Text = Convert.ToString(dt.Rows(0)("Num"))
                        txtCenterNo.Text = Convert.ToString(dt.Rows(0)("Num")).Trim
                        ddlDepartment.SelectedValue = Convert.ToString(dt.Rows(0)("Dept")).Trim
                        txtDescription.Text = Convert.ToString(dt.Rows(0)("Desc")).Trim
                        txtRate.Text = Convert.ToString(Math.Round(Convert.ToDecimal(dt.Rows(0)("Rate")), 2)).Trim
                        txtBurden.Text = Convert.ToString(dt.Rows(0)("Burden")).Trim

                        If Convert.ToString(dt.Rows(0)("Counter")) = "True" Then
                            chkCounter.Checked = True
                        Else
                            chkCounter.Checked = False
                        End If
                        txtCycleSize.Text = Convert.ToString(dt.Rows(0)("Cyl_Size")).Trim
                        txtRatio.Text = Convert.ToString(dt.Rows(0)("Ratio")).Trim

                        btnSave.Text = "Update"
                    End If
                    pnlAddEditCosting.Visible = True
                    pnlViewCosting.Visible = False
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("ddgvCosting_CellContentClick Error#" & ex.ToString())
            MessageBox.Show("Failed to perform the operation", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Event shows the screen to add record
    ''' </summary>
    Private Sub btnAddCostingCenter_Click(sender As Object, e As EventArgs) Handles btnAddCostingCenter.Click
        Try
            ClearControls()
            pnlAddEditCosting.Visible = True
            btnSave.Text = "Save"
            pnlViewCosting.Visible = False
        Catch ex As Exception
            oExcelSS.ErrorLog("btnAddCostingCenter_Click Error#" & ex.Message.ToString())
            MessageBox.Show("Failed to show Add Jobcost Center screen.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCosting_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCosting.CellDoubleClick
        Try
            dgvCosting_CellContentClick(Nothing, e)
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvCosting_CellDoubleClick Error#" & ex.ToString())
            MessageBox.Show("Failed to show Add Jobcost Center screen.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '''<summary>
    '''The txtCenterNo_KeyPress event make sure the input as numeric only
    '''</summary>
    Private Sub txtCenterNo_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCenterNo.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
    '''<summary>
    '''The txtBurden_KeyPress event make sure the input as numeric only
    '''</summary>
    Private Sub txtBurden_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBurden.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub

    '''<summary>
    '''The txtCycleSize_KeyPress event make sure the input as numeric only
    '''</summary>
    Private Sub txtCycleSize_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCycleSize.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And e.KeyChar <> "." Then
                e.Handled = True
            End If
        End If

    End Sub

    '''<summary>
    '''The txtRatio_KeyPress event make sure the input as numeric only
    '''</summary>
    Private Sub txtRatio_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRatio.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And e.KeyChar <> "." Then
                e.Handled = True
            End If
        End If

    End Sub

    '''<summary>
    '''The txtRate_KeyPress event make sure the input as numeric and decimal only
    '''</summary>
    Private Sub txtRate_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And e.KeyChar <> "." Then
                e.Handled = True
            End If
        End If


    End Sub

#End Region

#Region "Private Methods"

    '''<summary>
    '''The GetJobcostCenterInfo method returns all the Department data
    '''</summary>
    Private Function GetJobcostCenterInfo(ID As Integer) As DataTable
        Dim dtJobcostCenter As New DataTable("JobcostCenterTable")

        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@Num", ID)
        dtJobcostCenter = oExcelSS.getDataTable("uspConfiguration_GetJobcostCenter", True, param)

        Return dtJobcostCenter

    End Function

    '''<summary>
    '''The GetDepartmnetInfo method returns all the Department data
    '''</summary>
    Private Function GetDepartmnetInfo(ID As Integer) As DataTable
        Dim dtDepartment As New DataTable("DepartmentTable")

        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@Num", ID)
        dtDepartment = oExcelSS.getDataTable("uspConfiguration_GetDepartment", True, param)

        Return dtDepartment

    End Function


        '''<summary>
        '''The BindDepartmentData Sub binds data to datagridview 
        '''</summary>
    Private Sub BindJobCostCenterData(Id As Integer)
        Dim dtJobcost As DataTable = GetJobcostCenterInfo(Id)
        dgvCosting.DataSource = dtJobcost
    End Sub

    '''<summary>
    '''The BindDepartmentData Sub binds data to combo 
    '''</summary>
    Private Sub BindDepartmentData(Id As Integer)
        Dim dtDept As DataTable = GetDepartmnetInfo(Id)
        ddlDepartment.DataSource = dtDept
        ddlDepartment.ValueMember = "Num"
        ddlDepartment.DisplayMember = "NumDesc"
        ddlDepartment.SelectedIndex = -1

    End Sub

    '''<summary>
    '''ClearControls resets the input controls
    '''</summary>
    Private Sub ClearControls()
        lblID.Text = String.Empty
        txtCenterNo.Text = String.Empty
        ddlDepartment.SelectedIndex = -1
        txtDescription.Text = String.Empty
        txtRate.Text = String.Empty
        txtBurden.Text = String.Empty
        chkCounter.Checked = False
        txtCycleSize.Text = String.Empty
        txtRatio.Text = String.Empty

    End Sub

    '''<summary>
    '''The InsertUpdateJobcostCenter inserts or updates the Jobcost center 
    ''' IF Id is 0 it inserts else it updates the Jobcost record based on Id value
    '''</summary>
    Private Sub InsertUpdateJobcostCenter(Id As Integer)
        If (ValidateInputs()) Then
            Dim param As SqlParameter() = New SqlParameter(9) {}
            Dim OutStatus As String = String.Empty

            param(0) = New SqlParameter("@Id", Id)
            param(1) = New SqlParameter("@Num", Convert.ToInt32(txtCenterNo.Text))
            param(2) = New SqlParameter("@Dept", Convert.ToInt32(ddlDepartment.SelectedValue))
            param(3) = New SqlParameter("@Desc", txtDescription.Text)
            param(4) = New SqlParameter("@Rate", Convert.ToDecimal(txtRate.Text))
            param(5) = New SqlParameter("@Burden", Convert.ToInt32(txtBurden.Text))
            param(6) = New SqlParameter("@Counter", IIf(chkCounter.Checked, 1, 0))
            param(7) = New SqlParameter("@Cyl_Size", Convert.ToDouble(txtCycleSize.Text))
            param(8) = New SqlParameter("@Ratio", Convert.ToDouble(txtRatio.Text))
            param(9) = New SqlParameter("@OutStatus", "")
            param(9).Direction = ParameterDirection.Output
            param(9).Size = 1000
           



            Dim success As Integer = oExcelSS.ExecuteProc("uspConfiguration_JobcostCenterInsertUpdate", param)
            OutStatus = param(9).Value
            If (OutStatus = "45000") Then
                MessageBox.Show("Jobcost Center Number already exist", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                pnlAddEditCosting.Visible = False
                pnlViewCosting.Visible = True
                BindJobCostCenterData(0)
                MessageBox.Show("Jobcost Center saved successfully.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            

        End If
    End Sub

    '''<summary>
    '''ValidateInputs validates required fields for Jobcost Center
    '''</summary>
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(txtCenterNo.Text) Then
            MessageBox.Show("Please enter Center No.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf Convert.ToInt32(txtCenterNo.Text) <= 0 OrElse Convert.ToInt32(txtCenterNo.Text) >= 255 Then
            MessageBox.Show("Jobcost Center No. should be between 1 and 255.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf ddlDepartment.SelectedIndex = -1 Then
            MessageBox.Show("Please select Department.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter Description.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtRate.Text) Then
            MessageBox.Show("Please enter Rate.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtBurden.Text) Then
            MessageBox.Show("Please enter Burden.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtCycleSize.Text) Then
            MessageBox.Show("Please enter Cylinder Size.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtRatio.Text) Then
            MessageBox.Show("Please enter Ratio.", "Jobcost Center", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End If
        Return True
    End Function

#End Region


End Class

