Imports System.Data.SqlClient
Public Class frmUser
    Dim currentStatus As Integer = 0
    Private Sub frmUser_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            selectedItem = String.Empty
        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("btnLogin_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub frmUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If e.KeyCode = Keys.Escape Then
        '    If currentStatus > 0 Then
        '        If MsgBox("Are you sure to Exit from User creation ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "") = MsgBoxResult.No Then
        '            Exit Sub
        '        End If
        '    End If
        '    Me.Close()
        'End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtFirstname.Text.Trim() = "" Then
                MsgBox("First name should not be empty!", MsgBoxStyle.Critical, My.Resources.applicationTitle)
                txtFirstname.Focus()
                Exit Sub
            End If
            If txtLastname.Text.Trim() = "" Then
                MsgBox("Last name should not be empty!", MsgBoxStyle.Critical, My.Resources.applicationTitle)
                txtLastname.Focus()
                Exit Sub
            End If
            If currentStatus = 1 And txtUsername.Text.Trim() = "" Then
                MsgBox("User name should not be empty!", MsgBoxStyle.Critical, My.Resources.applicationTitle)
                txtUsername.Focus()
                Exit Sub
            End If
            If txtPassword.Text.Trim() = "" Then
                MsgBox("Password should not be empty!", MsgBoxStyle.Critical, My.Resources.applicationTitle)
                txtPassword.Focus()
                Exit Sub
            End If
            If MsgBox("Are you sure to save?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Resources.applicationTitle) = MsgBoxResult.No Then
                Exit Sub
            End If
            '------ check the user available / not
            If currentStatus = 1 Then
                Dim dtUserExist As New DataTable
                Dim sqlparam As SqlParameter() = New SqlParameter(0) {}
                sqlparam(0) = New SqlParameter("@strUser", txtUsername.Text.Trim)
                dtUserExist = New DataLayer().getDataTable("uspAccessUserAvailorNot", True, sqlparam)
                If dtUserExist.Rows.Count > 0 Then
                    If Convert.ToInt16(dtUserExist.Rows(0)(0)) > 0 Then
                        MsgBox("User [" & txtUsername.Text.Trim() & "] already exists", MsgBoxStyle.Exclamation, My.Resources.applicationTitle)
                        txtUsername.Focus()
                        Exit Sub
                    End If
                End If
            End If
            '1------- for Insert
            '2------- for Update
            Dim encryptpassword As String = Encryption.Encrypt(txtPassword.Text.Trim, "report", True)
            Dim param As String(,) = New String(,) {
                                                    {"@intMode", currentStatus}, {"@strFirstName", txtFirstname.Text.Trim},
                                                    {"@strLastName", txtLastname.Text.Trim}, {"@strUserName", txtUsername.Text.Trim},
                                                    {"@strPassword", encryptpassword}, {"@strContactNo", txtContact.Text.Trim},
                                                    {"@strEmailId", txtEmail.Text.Trim}, {"@strAddress", txtAddress.Text.Trim},
                                                    {"@Role", 1}, {"@Active", 1},
                                                    {"@Deleted", 0}, {"@Notes", ""}
                                                   }

            Dim status As Boolean = New DataLayer().isSavedData("uspAccessInsertUser", , , param, "@strStatus")
            If status Then
                If currentStatus = 1 Then
                    MsgBox("User created successfully", MsgBoxStyle.Information, My.Resources.applicationTitle)
                ElseIf currentStatus = 2 Then
                    MsgBox("User updated successfully", MsgBoxStyle.Information, My.Resources.applicationTitle)
                End If
                lockTextBox(False)
                lockButton(True, True, True)
                currentStatus = 0
            Else
                MsgBox("Cannot create user", MsgBoxStyle.Critical, My.Resources.applicationTitle)
            End If
        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("fmUser btnSave_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub txtContact_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContact.KeyPress
        If e.KeyChar >= "0" And e.KeyChar <= "9" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub lockTextBox(Optional ByVal enable As Boolean = True)
        txtAddress.Enabled = enable
        txtContact.Enabled = enable
        txtEmail.Enabled = enable
        txtFirstname.Enabled = enable
        txtLastname.Enabled = enable
        txtPassword.Enabled = enable
        txtUsername.Enabled = enable
    End Sub
    Private Sub lockButton(Optional ByVal btNew As Boolean = False, Optional ByVal btEdit As Boolean = False,
                           Optional ByVal btSearch As Boolean = False, Optional ByVal btSave As Boolean = False)
        btnNew.Enabled = btNew
        btnEdit.Enabled = btEdit
        btnSave.Enabled = btSave
        btnSearch.Enabled = btSearch
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            currentStatus = 0
            Dim dtUser As New DataTable
            Dim sqlparam As SqlParameter() = New SqlParameter(0) {}
            Dim username = InputBox("Enter user name to search?", "User search")
            If username <> "" Then
                sqlparam(0) = New SqlParameter("@strUser", username.Trim)
                dtUser = New DataLayer().getDataTable("uspAccessGetUser", True, sqlparam)
                If dtUser.Rows.Count > 0 Then
                    txtFirstname.Text = Convert.ToString(dtUser(0)("FirstName"))
                    txtLastname.Text = Convert.ToString(dtUser(0)("LastName"))
                    txtEmail.Text = Convert.ToString(dtUser(0)("EmailID"))
                    txtContact.Text = Convert.ToString(dtUser(0)("Contactnumber"))
                    txtUsername.Text = Convert.ToString(dtUser(0)("Username"))
                    txtPassword.Text = Convert.ToString(dtUser(0)("Password"))
                    txtAddress.Text = Convert.ToString(dtUser(0)("Address"))
                    txtFirstname.Focus()
                    lockTextBox(False)
                End If
                lockButton(True, True, True)
            End If
        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("fmUser btnSearch_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If currentStatus > 0 Then
            If MsgBox("Are you sure to Exit from User creation ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Resources.applicationTitle) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub
    Private Sub frmUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        clearTextBox()
        lockTextBox(False)
        lockButton(True, , True)
        currentStatus = 0
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        currentStatus = 2
        lockTextBox(True)
        txtFirstname.Focus()
        lockButton(, , , True)
        txtPassword.Enabled = False
        txtUsername.Enabled = False
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If currentStatus > 0 Then
            If MsgBox("Are you sure to cancel ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, My.Resources.applicationTitle) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        currentStatus = 0
        clearTextBox()
        lockTextBox(False)
        lockButton(True, , True)
    End Sub
    Private Sub clearTextBox()
        txtAddress.Text = String.Empty
        txtContact.Text = String.Empty
        txtEmail.Text = String.Empty
        txtFirstname.Text = String.Empty
        txtLastname.Text = String.Empty
        txtPassword.Text = String.Empty
        txtUsername.Text = String.Empty
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        currentStatus = 1
        lockTextBox(True)
        clearTextBox()
        lockButton(, , , True)
    End Sub
End Class