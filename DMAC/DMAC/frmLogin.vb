Imports System.Data.SqlClient
Imports System.IO
Public Class frmLogin
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Application.ExitThread()
    End Sub
    Private Sub frmLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oExcelSS.selectedItem = String.Empty
        Catch ex As Exception
            oExcelSS.ErrorLog("btnLogin_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub frmLogin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Application.ExitThread()
        End If
    End Sub
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            If ValidateLoginFields() Then
                '============================================================================
                Dim license As String = String.Empty
                Dim sqlparam As SqlParameter() = New SqlParameter(0) {}
                If oExcelSS.ConnectDataBaseAsperRegistry() Then
                    Dim password As String = ExcelSSGen.Main.Encrypt(txtPassword.Text.Trim, "dmac", True)
                    Dim param As String(,) = New String(,) {{"@strUserName", txtUsername.Text.Trim()}, {"@strPassword", password}}
                    Select Case oExcelSS.isValidUser("uspAccess_LoginUser", param)
                        Case ExcelSSGen.Main.UserStatus.Valid
                            '====== Entry in registry of Userid 
                            SaveSetting("DMAC", "Session", "UserID", txtUsername.Text.Trim())
                            '================================================================
                            oExcelSS.ActiveUserID = txtUsername.Text
                            oExcelSS.logintime = Now
                            oExcelSS.loginHr = Convert.ToString(Now.Hour)
                            '========================== Get the user permission
                            sqlparam(0) = New SqlParameter("@UserIDKey", txtUsername.Text.Trim())
                            oExcelSS.dtPermission = oExcelSS.getDataTable("uspAccess_GetPermission", True, sqlparam)
                            '===============================================================================
                            Me.Close()
                            '========================== Update the user status
                            param = New String(,) {
                                                        {"@userID", oExcelSS.userid}, {"@WorkstationID", My.Computer.Name}, {"@strLogStatus", "Login"},
                                                        {"@LogInTime", Now}, {"@LogOutTime", Nothing}
                                                  }
                            Dim logregisterstatus As Boolean = oExcelSS.userLoginStatusUpdation("uspAccess_UserLogRegister", param, "@strStatus")
                            '==================================================================================
                            oExcelSS.isMenuBinded = True
                            oExcelSS.dtShortcut = New DataTable("tblShortcut")
                            Dim paramsql As SqlParameter() = New SqlParameter(0) {}
                            paramsql(0) = New SqlParameter("@intUserIDKey", oExcelSS.userid)
                            oExcelSS.dtShortcut = oExcelSS.getDataTable("uspDmac_GetShortcut", True, paramsql)
                        Case ExcelSSGen.Main.UserStatus.Invalid
                            MsgBox("Invalid User/Password", MsgBoxStyle.Critical, My.Resources.applicationTitle)
                        Case ExcelSSGen.Main.UserStatus.LoggedValid
                            MsgBox("This User is already logged in", MsgBoxStyle.Critical, My.Resources.applicationTitle)
                    End Select
                Else
                    MsgBox("Missing excelss configuration file.  Please contact Excel Software Services for assistance", vbCritical, My.Resources.applicationTitle)
                End If
            End If

        Catch ex As Exception
            oExcelSS.ErrorLog("btnLogin_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strLastLoginCompany As String
            strLastLoginCompany = GetSetting("DMAC", "Session", "CompanyID")

            webControl.Document.Write("")
            webControl.ScrollBarsEnabled = False
            webControl.Refresh()
            webControl.DocumentText = "<html><body style='padding: 0;margin: 0'><img src='" & oExcelSS.dynamicImage & "' border='0'/></body></html>"

            If companyarray.Count > 0 Then
                cmbCompany.DataSource = companyarray
                cmbCompany.DisplayMember = "getCompanyName"
                cmbCompany.ValueMember = "getCompanyID"
                If strLastLoginCompany <> "" Then
                    cmbCompany.SelectedValue = strLastLoginCompany
                Else
                    cmbCompany.SelectedIndex = 0
                End If
            End If
            ' cmbCompany.SelectedIndex = 0
            txtUsername.Text = String.Empty
            txtPassword.Text = String.Empty
            txtUsername.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
            oExcelSS.ErrorLog("frmLogin_Load Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub webControl_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles webControl.DocumentCompleted
        Try
            Dim document As HtmlDocument = webControl.Document
            AddHandler document.Body.MouseDown, New HtmlElementEventHandler(AddressOf webControl_MouseDown)
        Catch ex As Exception
            oExcelSS.ErrorLog("webControl_DocumentCompleted Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub webControl_MouseDown(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        Try
            If e.MouseButtonsPressed = Windows.Forms.MouseButtons.Left Then
                Process.Start(oExcelSS.visitUrl)
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("webControl_MouseDown Error## " + ex.Message.ToString())
        End Try
    End Sub
    ' when user enter key press then automatically call login button
    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            Call btnLogin_Click(sender, e)
        End If
    End Sub
    Private Sub btnClearUser_Click(sender As Object, e As EventArgs) Handles btnClearUser.Click
        If MsgBox("Are you sure clearing your User?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If ValidateLoginFields() Then
                If oExcelSS.ConnectDataBaseAsperRegistry() Then
                    Dim password As String = ExcelSSGen.Main.Encrypt(txtPassword.Text.Trim, "dmac", True)
                    Dim param As String(,) = New String(,) {{"@strUserName", txtUsername.Text.Trim()}, {"@strPassword", password}}
                    If oExcelSS.isValidUser("uspAccess_LoginUser", param) = ExcelSSGen.Main.UserStatus.LoggedValid Then
                        Dim paramsql As SqlClient.SqlParameter() = New SqlClient.SqlParameter(0) {}
                        paramsql(0) = New SqlClient.SqlParameter("@userID", oExcelSS.userid)
                        oExcelSS.getDataTable("uspAccess_ClearUser", True, paramsql)
                        MsgBox("User Cleared!", MsgBoxStyle.Exclamation)
                    Else
                        MsgBox("Invalid User/Password", MsgBoxStyle.Critical, My.Resources.applicationTitle)
                    End If
                Else
                    MsgBox("Missing excelss configuration file.  Please contact Excel Software Services for assistance", vbCritical, My.Resources.applicationTitle)
                End If
            End If
        Else
            MsgBox("User NOT Cleared!", MsgBoxStyle.Information)
        End If
    End Sub
    Public Function ValidateLoginFields() As Boolean
        ValidateLoginFields = False
        If txtUsername.Text.Trim() = "" Then
            MsgBox("User Name should not be Empty", MsgBoxStyle.Information, My.Resources.applicationTitle)
            txtUsername.Focus()
            '''' Below line commented by Harinath Reddy
            ''Exit Function

            '''' Line added by Harinath Reddy
            Return False

        End If
        If txtPassword.Text.Trim() = "" Then
            MsgBox("Password should not be Empty", MsgBoxStyle.Information, My.Resources.applicationTitle)
            txtPassword.Focus()
            '''' Below line commented by Harinath Reddy
            ''Exit Function

            '''' Line added by Harinath Reddy
            Return False
        End If
        oExcelSS.ActiveCompanyName = cmbCompany.Text
        oExcelSS.ActiveCompanyID = cmbCompany.SelectedValue.ToString
        SaveSetting("DMAC", "Session", "CompanyID", oExcelSS.ActiveCompanyID)
        ValidateLoginFields = True
        '''' Line added by Harinath Reddy
        Return True
    End Function

End Class