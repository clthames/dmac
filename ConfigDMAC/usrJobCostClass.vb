Imports System.Data.SqlClient

Public Class usrJobCostClass
    Public oExcelSS As New ExcelSSGen.Main

#Region "Form Events"

    ''' <summary>
    ''' Event Load form and retrive Department Data
    ''' here 0 in BindDepartmentData(0) shows all data
    ''' </summary>
    Private Sub usrJobCostClass_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            BindClassData("0")
        Catch ex As Exception
            oExcelSS.ErrorLog("usrJobCostClass_Load Error#" & ex.ToString())
            MessageBox.Show("Failed to retrieve Class Data.", "Class", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reset the form control and show the grid screen
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            pnlAddEditClass.Visible = False
            pnlViewClass.Visible = True
        Catch ex As Exception
            oExcelSS.ErrorLog("btnCancel_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to cancel the operation.", "Class", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save or update data
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(lblID.Text) Then
                InsertUpdateClass("0")
            Else
                InsertUpdateClass(lblID.Text)
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("btnSave_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to save Operation Class.", "Class", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '''<summary>
    '''Event captures the delete and edit button when clicked
    '''</summary>
    Private Sub dgvClass_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClass.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim ID As String = dgvClass.Rows(e.RowIndex).Cells(1).Value.ToString()

                '7 is  form delete button column
                If e.ColumnIndex = 3 Then
                    Dim Result As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If Result = DialogResult.OK Then
                        Dim param As SqlParameter() = New SqlParameter(0) {}
                        param(0) = New SqlParameter("@ID", ID)
                        oExcelSS.ExecuteProc("uspConfiguration_DeleteClass", param)
                        BindClassData("0")
                        MessageBox.Show("Operation Class deleted successfully.", "Class", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ' 6 is for edit button column or any other column then show edit screen
                ElseIf sender Is Nothing OrElse e.ColumnIndex = 0 Then

                    Dim dt As DataTable = GetClassInfo(ID)
                    If Not dt Is Nothing And dt.Rows.Count > 0 Then

                        lblID.Text = Convert.ToString(dt.Rows(0)("ID"))
                        txtClassNo.Text = Convert.ToString(dt.Rows(0)("ID")).Trim
                        txtClassDesc.Text = Convert.ToString(dt.Rows(0)("Description")).Trim

                        btnSave.Text = "Update"
                    End If
                    pnlAddEditClass.Visible = True
                    pnlViewClass.Visible = False
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvClass_CellContentClick Error#" & ex.ToString())
            MessageBox.Show("Failed to perform the operation", "Class", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Event shows the screen to add record
    ''' </summary>
    Private Sub btnAddDept_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click
        Try
            ClearControls()
            pnlAddEditClass.Visible = True
            btnSave.Text = "Save"
            pnlViewClass.Visible = False
        Catch ex As Exception
            oExcelSS.ErrorLog("btnAddClass_Click Error#" & ex.Message.ToString())
            MessageBox.Show("Failed to show Add Operation Class screen.", "Class", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvClass_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClass.CellDoubleClick
        Try
            dgvClass_CellContentClick(Nothing, e)
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvClass_CellDoubleClick Error#" & ex.ToString())
            MessageBox.Show("Failed to show Add Operation Class screen.", "Class", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '''<summary>
    '''The txtDeptNo_KeyPress event make sure the input as numeric only
    '''</summary>
    Private Sub txtClassNo_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClassNo.KeyPress

      

    End Sub
#End Region

#Region "Private Methods"

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
    '''The BindClassData Sub binds data to datagridview 
    '''</summary>
    Private Sub BindClassData(Id As String)
        Dim dtClass As DataTable = GetClassInfo(Id)

        If dtClass.Columns.Contains("NumDesc") Then
            dtClass.Columns.Remove("NumDesc")
        End If

        dgvClass.DataSource = dtClass
    End Sub

    '''<summary>
    '''ClearControls resets the input controls
    '''</summary>
    Private Sub ClearControls()
        lblID.Text = String.Empty
        txtClassNo.Text = String.Empty
        txtClassDesc.Text = String.Empty

    End Sub

    '''<summary>
    '''The InsertUpdateClass inserts or updates the Class 
    ''' IF Id is 0 it inserts else it updates the Class record based on Id value
    '''</summary>
    Private Sub InsertUpdateClass(Id As String)
        If (ValidateInputs()) Then
            Dim param As SqlParameter() = New SqlParameter(3) {}
            Dim OutStatus As String = String.Empty

            param(0) = New SqlParameter("@Id", Id)
            param(1) = New SqlParameter("@ClassID", txtClassNo.Text)
            param(2) = New SqlParameter("@Description", txtClassDesc.Text)
            param(3) = New SqlParameter("@OutStatus", "")
            param(3).Direction = ParameterDirection.Output
            param(3).Size = 1000



            Dim success As Integer = oExcelSS.ExecuteProc("uspConfiguration_ClassInsertUpdate", param)
            OutStatus = param(3).Value
            If (OutStatus = "45000") Then
                MessageBox.Show("Operation Class already exist", "Class", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                pnlAddEditClass.Visible = False
                pnlViewClass.Visible = True
                BindClassData("0")
                MessageBox.Show("Operation Class saved successfully.", "Class", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If



        End If
    End Sub

    '''<summary>
    '''ValidateInputs validates required fields for Class
    '''</summary>
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(txtClassNo.Text) Then
            MessageBox.Show("Please enter Operation Class ID", "Class", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If
    End Function

#End Region


End Class
