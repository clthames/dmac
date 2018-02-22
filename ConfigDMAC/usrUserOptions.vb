Imports System.Data.SqlClient

Public Class usrUserOptions
    Public oExcelSS As New ExcelSSGen.Main

#Region "Form Events"
    ''' <summary>
    '''BindUsersData
    ''' </summary>
    Private Sub usrUserOptions_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            BindUsersData()
        Catch ex As Exception
            oExcelSS.ErrorLog("usrUserOptions_Load Error#" & ex.ToString())
            MessageBox.Show("Failed to retrieve Users Data.", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    '''Bind/Get the data based on User selection
    ''' </summary>
    Private Sub cboUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUsers.SelectedIndexChanged
        If Not String.IsNullOrEmpty(cboUsers.SelectedValue) Then
            BindUserOptionsData(cboUsers.SelectedValue)
        End If
    End Sub

    Private Sub btnAddOption_Click(sender As Object, e As EventArgs) Handles btnAddOption.Click
        Dim frm As New frmUserOptions_Popup()
        'frm.Parent = Me
        Dim dialogresult As DialogResult
        dialogresult = frm.ShowDialog(Me)
        If dialogresult = Windows.Forms.DialogResult.OK Then
            Try
                InsertUpdateUserOption(0, frm.Keyword, frm.Value)
            Catch ex As Exception
                oExcelSS.ErrorLog("btnSave_Click Error#" & ex.ToString())
                MessageBox.Show("Failed to save User Option.", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    '''<summary>
    '''Delete and Update selected User Option 
    '''</summary>
    Private Sub dgvUserOptions_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUserOptions.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim ID As Integer = dgvUserOptions.Rows(e.RowIndex).Cells(1).Value.ToString()

                If e.ColumnIndex = 4 Then
                    Dim Result As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If Result = DialogResult.OK Then
                        Dim param As SqlParameter() = New SqlParameter(0) {}
                        param(0) = New SqlParameter("@ID", ID)
                        oExcelSS.ExecuteProc("uspConfiguration_DeleteUserOption", param)
                        If Not String.IsNullOrEmpty(cboUsers.SelectedValue) Then
                            BindUserOptionsData(cboUsers.SelectedValue)
                        End If
                        MessageBox.Show("User Option deleted successfully.", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ' 6 is for edit button column or any other column then show edit screen
                ElseIf sender Is Nothing OrElse e.ColumnIndex = 0 Then

                    Dim dt As DataTable = GetUserOption(ID)
                    If Not dt Is Nothing And dt.Rows.Count > 0 Then

                        lblID.Text = Convert.ToString(dt.Rows(0)("ID"))
                        Dim frm As New frmUserOptions_Popup()
                        frm.Keyword = Convert.ToString(dt.Rows(0)("Keyword")).Trim

                        Dim value As String = Convert.ToString(dt.Rows(0)("Value")).Trim

                        If frm.Keyword.ToLower().Contains("password") Then
                            frm.IsPasswordField = True
                        End If

                        If frm.IsPasswordField AndAlso Not String.IsNullOrEmpty(value) Then
                            frm.Value = ExcelSSGen.Main.Decrypt(value, "dmac", True)
                        Else
                            frm.Value = value
                            frm.IsPasswordField = False
                        End If

                        Dim userId As Integer = Convert.ToInt32(lblID.Text)

                        If (userId = 0) Then
                            frm.IsEditMode = False
                        Else
                            frm.IsEditMode = True
                        End If

                        Dim dialogresult As DialogResult
                        dialogresult = frm.ShowDialog()

                        If dialogresult = Windows.Forms.DialogResult.OK Then
                            InsertUpdateUserOption(userId, frm.Keyword, frm.Value)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvUserOptions_CellContentClick Error#" & ex.ToString())
            MessageBox.Show("Failed to perform the operation", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvUserOptions_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUserOptions.CellContentDoubleClick
        Try
            dgvUserOptions_CellContentClick(Nothing, e)
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvUserOptions_CellDoubleClick Error#" & ex.ToString())
            MessageBox.Show("Failed to show Add Keyword screen.", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Private Methods"


    '''<summary>
    '''The BindUserOptionsData Sub binds data to datagridview 
    '''</summary>
    Private Sub BindUserOptionsData(User As String)
        Dim dtUserOptions As DataTable = GetUserOptionsByUser(User)
        dgvUserOptions.DataSource = dtUserOptions
    End Sub

    '''<summary>
    '''The GetUserOptionsByUser method returns all the user options data for user
    '''</summary>
    Private Function GetUserOptionsByUser(User As String) As DataTable
        Dim dtUserOptions As New DataTable("UserOptionsTable")

        Dim param As SqlParameter() = New SqlParameter(1) {}
        param(0) = New SqlParameter("@UserID", User)
        param(1) = New SqlParameter("@ID", 0)
        dtUserOptions = oExcelSS.getDataTable("uspConfiguration_GetUserOptions", True, param)

        Return dtUserOptions

    End Function

    Private Sub BindUsersData()
        oExcelSS.fillComboBox(cboUsers, "uspConfiguration_GetUsers", "UserName", "UserID")
    End Sub

    

    '''<summary>
    '''The InsertUpdateUserOption inserts or updates the User Option 
    ''' IF Id is 0 it inserts else it updates the User Option record based on Id value
    '''</summary>
    Private Sub InsertUpdateUserOption(ByVal id As Integer, ByVal keyword As String, ByVal value As String)

        Dim param As SqlParameter() = New SqlParameter(4) {}
        Dim OutStatus As String = String.Empty

        param(0) = New SqlParameter("@Id", Id)
        param(1) = New SqlParameter("@UserId", cboUsers.SelectedValue)
        param(2) = New SqlParameter("@Keyword", keyword)
        If keyword.ToLower().Contains("password") Then
            param(3) = New SqlParameter("@Value", ExcelSSGen.Main.Encrypt(value, "dmac", True))
        Else
            param(3) = New SqlParameter("@Value", value)
        End If
        param(4) = New SqlParameter("@OutStatus", "")
        param(4).Direction = ParameterDirection.Output
        param(4).Size = 1000

        Dim success As Integer = oExcelSS.ExecuteProc("uspConfiguration_UserOptionInsertUpdate", param)
        OutStatus = param(4).Value
        If (OutStatus = "45000") Then
            MessageBox.Show("Keyword already exist", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Not String.IsNullOrEmpty(cboUsers.SelectedValue) Then
                BindUserOptionsData(cboUsers.SelectedValue)
            End If
            ClearControls()
            MessageBox.Show("Keyword and Value saved successfully.", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub


    '''<summary>
    '''The GetUserOption method returns all the User Option(s)
    '''</summary>
    Private Function GetUserOption(ID As Integer) As DataTable
        Dim dtUsrOpt As New DataTable("UserOptionTable")

        Dim param As SqlParameter() = New SqlParameter(1) {}
        param(0) = New SqlParameter("@UserID", cboUsers.SelectedValue)
        param(1) = New SqlParameter("@ID", ID)
        dtUsrOpt = oExcelSS.getDataTable("uspConfiguration_GetUserOptions", True, param)

        Return dtUsrOpt

    End Function

    '''<summary>
    '''ClearControls resets the input controls
    '''</summary>
    Private Sub ClearControls()
        lblID.Text = String.Empty
    End Sub


#End Region

End Class
