Imports System.Data.SqlClient

Public Class usrJobCostDept
    Public oExcelSS As New ExcelSSGen.Main

#Region "Form Events"

    ''' <summary>
    ''' Event Load form and retrive Department Data
    ''' here 0 in BindDepartmentData(0) shows all data
    ''' </summary>
    Private Sub usrJobCostDept_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            BindDepartmentData(0)
        Catch ex As Exception
            oExcelSS.ErrorLog("usrJobCostDept_Load Error#" & ex.ToString())
            MessageBox.Show("Failed to retrieve Department Data.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reset the form control and show the grid screen
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            pnlAddEditDept.Visible = False
            pnlViewDepartment.Visible = True
        Catch ex As Exception
            oExcelSS.ErrorLog("btnCancel_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to cancel the operation.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save or update data
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(lblID.Text) Then
                InsertUpdateDepartment(0)
            Else
                InsertUpdateDepartment(Convert.ToInt32(lblID.Text))
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("btnSave_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to save Department.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '''<summary>
    '''Event captures the delete and edit button when clicked
    '''</summary>
    Private Sub dgvDept_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDept.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim ID As Integer = dgvDept.Rows(e.RowIndex).Cells(2).Value.ToString()

                '7 is  form delete button column
                If e.ColumnIndex = 1 Then
                    Dim Result As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If Result = DialogResult.OK Then
                        Dim param As SqlParameter() = New SqlParameter(0) {}
                        param(0) = New SqlParameter("@Num", ID)
                        oExcelSS.ExecuteProc("uspConfiguration_DeleteDepartment", param)
                        BindDepartmentData(0)
                        MessageBox.Show("Department deleted successfully.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ' 6 is for edit button column or any other column then show edit screen
                ElseIf sender Is Nothing OrElse e.ColumnIndex = 0 Then

                    Dim dt As DataTable = GetDeptInfo(ID)
                    If Not dt Is Nothing And dt.Rows.Count > 0 Then

                        lblID.Text = Convert.ToString(dt.Rows(0)("Num"))
                        txtDeptNo.Text = Convert.ToString(dt.Rows(0)("Num")).Trim
                        txtDeptDesc.Text = Convert.ToString(dt.Rows(0)("Description")).Trim

                        btnSave.Text = "Update"
                    End If
                    pnlAddEditDept.Visible = True
                    pnlViewDepartment.Visible = False
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvDept_CellContentClick Error#" & ex.ToString())
            MessageBox.Show("Failed to perform the operation", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Event shows the screen to add record
    ''' </summary>
    Private Sub btnAddDept_Click(sender As Object, e As EventArgs) Handles btnAddDept.Click
        Try
            ClearControls()
            pnlAddEditDept.Visible = True
            btnSave.Text = "Save"
            pnlViewDepartment.Visible = False
        Catch ex As Exception
            oExcelSS.ErrorLog("btnAddDept_Click Error#" & ex.Message.ToString())
            MessageBox.Show("Failed to show Add Department screen.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvDept_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDept.CellDoubleClick
        Try
            dgvDept_CellContentClick(Nothing, e)
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvDept_CellDoubleClick Error#" & ex.ToString())
            MessageBox.Show("Failed to show Add Department screen.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '''<summary>
    '''The txtDeptNo_KeyPress event make sure the input as numeric only
    '''</summary>
    Private Sub txtDeptNo_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeptNo.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
#End Region

#Region "Private Methods"

    '''<summary>
    '''The GetDeptInfo method returns all the Department data
    '''</summary>
    Private Function GetDeptInfo(ID As Integer) As DataTable
        Dim dtDept As New DataTable("DepartmentTable")

        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@Num", ID)
        dtDept = oExcelSS.getDataTable("uspConfiguration_GetDepartment", True, param)

        Return dtDept

    End Function

    '''<summary>
    '''The BindDepartmentData Sub binds data to datagridview 
    '''</summary>
    Private Sub BindDepartmentData(Id As Integer)
        Dim dtDept As DataTable = GetDeptInfo(Id)
        dgvDept.DataSource = dtDept
    End Sub

    '''<summary>
    '''ClearControls resets the input controls
    '''</summary>
    Private Sub ClearControls()
        lblID.Text = String.Empty
        txtDeptNo.Text = String.Empty
        txtDeptDesc.Text = String.Empty

    End Sub

    '''<summary>
    '''The InsertUpdateDepartment inserts or updates the Department 
    ''' IF Id is 0 it inserts else it updates the Department record based on Id value
    '''</summary>
    Private Sub InsertUpdateDepartment(Id As Integer)
        If (ValidateInputs()) Then
            Dim param As SqlParameter() = New SqlParameter(4) {}
            Dim OutStatus As String = String.Empty

            param(0) = New SqlParameter("@Id", Id)
            param(1) = New SqlParameter("@Num", txtDeptNo.Text)
            param(2) = New SqlParameter("@Description", txtDeptDesc.Text)
            param(3) = New SqlParameter("@Type", 0)
            param(4) = New SqlParameter("@OutStatus", "")
            param(4).Direction = ParameterDirection.Output
            param(4).Size = 1000



            Dim success As Integer = oExcelSS.ExecuteProc("uspConfiguration_DepartmentInsertUpdate", param)
            OutStatus = param(4).Value
            If (OutStatus = "45000") Then
                MessageBox.Show("Department Number already exist", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                pnlAddEditDept.Visible = False
                pnlViewDepartment.Visible = True
                BindDepartmentData(0)
                MessageBox.Show("Department saved successfully.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

           
           
        End If
    End Sub

    '''<summary>
    '''ValidateInputs validates required fields for Department
    '''</summary>
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(txtDeptNo.Text) Then
            MessageBox.Show("Please enter Department No.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf Convert.ToInt32(txtDeptNo.Text) = 0 Then
            MessageBox.Show("Department No. cannot be 0", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

#End Region


End Class
