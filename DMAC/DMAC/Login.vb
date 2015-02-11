Imports System.Data.SqlClient
Imports System.IO
Public Class Login
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Application.ExitThread()
    End Sub
    Private Sub frmLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            selectedItem = String.Empty
        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("btnLogin_Click Error## " + ex.Message.ToString())
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
            If txtUsername.Text.Trim() = "" Then
                MsgBox("User Name should not be Empty", MsgBoxStyle.Information, My.Resources.applicationTitle)
                txtUsername.Focus()
                Exit Sub
            End If
            If txtPassword.Text.Trim() = "" Then
                MsgBox("Password should not be Empty", MsgBoxStyle.Information, My.Resources.applicationTitle)
                txtPassword.Focus()
                Exit Sub
            End If
            ' Dim tst As String = Encryption.Encrypt("password@123", "dmac", True)
            '============================= save the current selected company in registry
            ActiveCompanyName = cmbCompany.Text
            ActiveCompanyID = cmbCompany.SelectedValue.ToString
            SaveSetting("DMAC", ActiveCompanyName, "CompanyID", ActiveCompanyID)
            '============================================================================
            Dim license As String = String.Empty
            Dim sqlparam As SqlParameter() = New SqlParameter(0) {}
            If ConnectDataBaseAsperRegistry() Then
                Dim password As String = Encryption.Encrypt(txtPassword.Text.Trim, "dmac", True)
                Dim param As String(,) = New String(,) {{"@strUserName", txtUsername.Text.Trim()}, {"@strPassword", password}}
                If New DataLayer().isValidUser("uspLoginUser", param) Then
                    ActiveUserID = txtUsername.Text
                    logintime = Now
                    loginHr = Convert.ToString(Now.Hour)
                    '========================== Get the user permission
                    sqlparam(0) = New SqlParameter("@intUserIDKey", userid)
                    dtPermission = New DataLayer().getDataTable("uspGetPermission", True, sqlparam)
                    '===============================================================================
                    Me.Close()
                    '========================== Update the user status
                    param = New String(,) {
                                                {"@userID", userid}, {"@strLogStatus", "Login"},
                                                {"@LogInTime", Now}, {"@LogOutTime", Nothing}
                                          }
                    Dim logregisterstatus As Boolean = New DataLayer().userLoginStatusUpdation("uspUserLogRegister", param, "@strStatus")
                    '==================================================================================
                    license = getLicenseFromUrl("http://www.excelss.com/validate/validate.php?companyid=" & ActiveCompanyID)
                    If license.Trim().Length > 0 Then
                        If license.Split(",").Length > 0 Then
                            licenseKey = Convert.ToString(license.Split(",")(0)).Trim
                            isMenuBinded = True
                        End If
                    Else
                        MsgBox("Unable to read License key for specified Company!")
                    End If
                Else
                    MsgBox("Invalid User/Password", MsgBoxStyle.Critical, My.Resources.applicationTitle)
                End If
            Else
                MsgBox("Missing excelss configuration file.  Please contact Excel Software Services for assistance", vbCritical, My.Resources.applicationTitle)
            End If

        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("btnLogin_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            webControl.Document.Write("")
            webControl.ScrollBarsEnabled = False
            webControl.Refresh()
            webControl.DocumentText = "<html><body style='padding: 0;margin: 0'><img src='" & dynamicImage & "' border='0'/></body></html>"
            If companyarray.Count > 0 Then
                cmbCompany.DataSource = companyarray
                cmbCompany.DisplayMember = "getCompanyName"
                cmbCompany.ValueMember = "getCompanyID"
            End If
            cmbCompany.SelectedIndex = 0
            txtUsername.Text = String.Empty
            txtPassword.Text = String.Empty
            txtUsername.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("frmLogin_Load Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub webControl_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles webControl.DocumentCompleted
        Try
            Dim document As HtmlDocument = webControl.Document
            AddHandler document.Body.MouseDown, New HtmlElementEventHandler(AddressOf webControl_MouseDown)
        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("webControl_DocumentCompleted Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub webControl_MouseDown(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        Try
            If e.MouseButtonsPressed = Windows.Forms.MouseButtons.Left Then
                Process.Start(visitUrl)
            End If
        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("webControl_MouseDown Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        Try
            lblLicensed.Text = "Licensed to : " & cmbCompany.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class