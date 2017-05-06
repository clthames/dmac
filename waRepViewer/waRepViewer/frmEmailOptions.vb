Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Drawing.Printing
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class frmEmailOptions

#Region "Private Members"
    Private _viewer As ReportViewerExtended = Nothing
#End Region

#Region "Constructor"
    Public Sub New(ByVal viewer As ReportViewerExtended)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _viewer = viewer
    End Sub
#End Region

#Region "Form Events"

    ''' <summary>
    ''' Form Load Event - By default put focus in Email Address field
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmEmailOptions_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            txtEmailAddress.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
            oExcelSS.ErrorLog("frmLogin_Load Error## " + ex.Message.ToString())
        End Try
    End Sub

#End Region

#Region "Button Events"

    ''' <summary>
    ''' Read SMTP and Report Settings from UserOptions/Options Table and Sends Email with Report as the PDF attachment to the destination email address
    ''' </summary>
    ''' <param name="sender">Send Button</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        Dim smtpUserName As String = ""
        Dim smtpPassword As String = ""
        Dim smtpServer As String = ""
        Dim smtpPort As String = ""
        Dim fromEmailAddress As String = ""
        Dim CcEmail As String = ""
        Dim BccEmail As String = ""
        Dim emailSubject As String = ""
        Dim isEnableSSL As Boolean = False
        Dim isBodyHtmlText As Boolean = False
        Dim attachmentName As String = ""
        lblResult.Text = ""

        Try
            'Validate Email Address. If invalid, then show message and skip sending email.
            If IsValidEmailAddress() Then
                'Connect to the Database (internally uses .INI files to read connection string for CompnayDB and connects to DB)
                If oExcelSS.ConnectDataBaseAsperRegistry() Then
                    btnSend.Enabled = False
                    btnCancel.Enabled = False

                    Dim p As SqlParameter() = New SqlParameter(0) {}
                    p(0) = New SqlParameter("@strUserName", GetSetting("DMAC", "Session", "UserID").Trim)

                    'Gets all SMTP and Report Email Specific Settings from the PROC - if present 
                    'in UserOptions, then fetch it using UserID otherwise get default settings from Options Table
                    Dim dtSMTPInfo As DataTable = oExcelSS.getDataTable("uspReports_GetSMTPInfo", True, p)

                    If Not dtSMTPInfo Is Nothing Then

                        'read all SMTP/Report Emailing Settings into local variables
                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_FromEmailAddress'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            fromEmailAddress = dtSMTPInfo.DefaultView(0)("Value").ToString
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'ReportEmailSubject'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            emailSubject = dtSMTPInfo.DefaultView(0)("Value").ToString
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_CcEmailAddress'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            CcEmail = dtSMTPInfo.DefaultView(0)("Value").ToString
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_BccEmailAddress'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            BccEmail = dtSMTPInfo.DefaultView(0)("Value").ToString
                        End If

                        'Prepare Email Message Object. All properties of Email Message object will be fetched from DB
                        Dim emailMsg As MailMessage = New MailMessage(fromEmailAddress, txtEmailAddress.Text)

                        If Not String.IsNullOrEmpty(CcEmail) Then
                            Dim ccMailAddress As New MailAddress(CcEmail)
                            emailMsg.CC.Add(ccMailAddress)
                        End If

                        If Not String.IsNullOrEmpty(BccEmail) Then
                            Dim BccMailAddress As New MailAddress(BccEmail)
                            emailMsg.Bcc.Add(BccMailAddress)
                        End If

                        emailMsg.Subject = emailSubject

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'ReportEmailContent'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            emailMsg.Body = dtSMTPInfo.DefaultView(0)("Value").ToString
                        Else
                            emailMsg.Body = "Default Body"
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_ServerName'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            smtpServer = dtSMTPInfo.DefaultView(0)("Value").ToString
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_Port'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            smtpPort = dtSMTPInfo.DefaultView(0)("Value").ToString
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_UserName'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            smtpUserName = dtSMTPInfo.DefaultView(0)("Value").ToString
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_Password'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            smtpPassword = dtSMTPInfo.DefaultView(0)("Value").ToString
                            smtpPassword = ExcelSSGen.Main.Decrypt(smtpPassword, "dmac", True)
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_EnableSSL'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            isEnableSSL = Convert.ToBoolean(dtSMTPInfo.DefaultView(0)("Value"))
                        End If

                        dtSMTPInfo.DefaultView.RowFilter = "KeyWord = 'SMTP_IsHTMLBodyText'"

                        If (dtSMTPInfo.DefaultView.Count > 0) Then
                            isBodyHtmlText = Convert.ToBoolean(dtSMTPInfo.DefaultView(0)("Value"))
                        End If

                        emailMsg.IsBodyHtml = isBodyHtmlText

                        'Connect to SMTP server
                        Dim client As SmtpClient = New SmtpClient(smtpServer, CInt(smtpPort))

                        If Not String.IsNullOrEmpty(smtpUserName) AndAlso Not String.IsNullOrEmpty(smtpPassword) Then
                            client.Credentials = New System.Net.NetworkCredential(smtpUserName, smtpPassword)
                        End If

                        client.DeliveryMethod = SmtpDeliveryMethod.Network
                        client.EnableSsl = isEnableSSL

                        'Export report associated with Viewer into PDF file and attach it to Email
                        Using attachment As New System.Net.Mail.Attachment(_viewer.ExportReport())
                            attachmentName = attachment.Name
                            emailMsg.Attachments.Add(attachment)

                            'Send Email with PDF attachment
                            client.Send(emailMsg)
                        End Using

                        lblResult.ForeColor = Color.Green
                        lblResult.Text = "Report sent as an Email Attachment..."

                        'Begin Email Logger
                        Dim params As SqlParameter() = New SqlParameter(4) {}
                        params(0) = New SqlParameter("@RecipientEmailAddress", txtEmailAddress.Text)
                        params(1) = New SqlParameter("@Status", "SENT SUCCESSFULLY")
                        params(2) = New SqlParameter("@Description", attachmentName)
                        params(3) = New SqlParameter("@SenderEmailAddress", fromEmailAddress)
                        params(4) = New SqlParameter("@RecipientName", String.Empty)

                        oExcelSS.ExecuteProc("[uspEmailLogger]", params)
                        ' end email logger

                        'Show MsgBox of Success
                        MessageBox.Show("Report sent as an Email Attachment.", "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Close the Window
                        Me.Close()

                    End If
                Else
                    MessageBox.Show("Please configure SMTP Server Settings to send report as an email attachment.", "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Please enter valid Email Address.", "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            'Begin Email Logger
            Dim params As SqlParameter() = New SqlParameter(4) {}
            params(0) = New SqlParameter("@RecipientEmailAddress", txtEmailAddress.Text)
            params(1) = New SqlParameter("@Status", "FAILED: " & ex.Message)
            params(2) = New SqlParameter("@Description", attachmentName)
            params(3) = New SqlParameter("@SenderEmailAddress", fromEmailAddress)
            params(4) = New SqlParameter("@RecipientName", String.Empty)

            oExcelSS.ExecuteProc("[uspEmailLogger]", params)

            ' end email logger

            lblResult.ForeColor = Color.Red
            lblResult.Text = "Sending Email Failed..."
            oExcelSS.ErrorLog("btnSend_Click Error#" & ex.Message.ToString())
            'Show MsgBox of Failure
            MessageBox.Show("Sending Email Failed.", "Send Email", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnSend.Enabled = True
            btnCancel.Enabled = True
        End Try
    End Sub

#End Region

#Region "Private Functions"

    ''' <summary>
    ''' Validates email address format
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidEmailAddress() As Boolean
        ' Return true if strIn is in valid e-mail format.
        Return Regex.IsMatch(txtEmailAddress.Text,
                   "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                   RegexOptions.IgnoreCase)
    End Function

#End Region
    
End Class