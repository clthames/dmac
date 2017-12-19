Imports System.Net.Mail
Imports System.IO
Imports System.Configuration

Module EmailModule
    Private smtpUserName As String = ""
    Private smtpPassword As String = ""
    Private smtpServer As String = ""
    Private smtpPort As String = ""
    Private attachmentName As String = ""
    Private emailCfgDirectoryPath As String = ConfigurationManager.AppSettings.Get("EmailCfgDirectoryPath")
    Private emlDirectoryPath As String = ConfigurationManager.AppSettings.Get("EmlDirectoryPath")

    Sub Main()
        For Each filePath As String In Directory.GetFiles(emlDirectoryPath, "*.eml")
            If SendEmail(filePath) Then
                If Not String.IsNullOrEmpty(attachmentName) AndAlso File.Exists(attachmentName) Then
                    File.Delete(attachmentName)
                End If
                File.Delete(filePath)
            End If
        Next
        For Each filePath As String In Directory.GetFiles(emlDirectoryPath, "*.em")
            If SendEmail(filePath) Then
                If Not String.IsNullOrEmpty(attachmentName) AndAlso File.Exists(attachmentName) Then
                    File.Delete(attachmentName)
                End If
                File.Delete(filePath)
            End If
        Next
    End Sub

    Private Sub ReadSmtpServerSettings(ByVal cfgFileName As String)
        Dim emailCfgFullPath As String = Nothing

        If File.Exists(Path.Combine(emailCfgDirectoryPath, cfgFileName)) Then
            emailCfgFullPath = Path.Combine(emailCfgDirectoryPath, cfgFileName)
        ElseIf File.Exists(Path.Combine(emailCfgDirectoryPath, "email", cfgFileName)) Then
            emailCfgFullPath = Path.Combine(emailCfgDirectoryPath, cfgFileName)
        End If

        If File.Exists(emailCfgFullPath) Then
            Dim arrContent As String() = File.ReadAllLines(emailCfgFullPath)
            For Each content As String In arrContent
                If Not String.IsNullOrEmpty(content) Then
                    Dim key_values As String() = content.Split("=")
                    If Not key_values Is Nothing AndAlso key_values.Length > 1 Then
                        Dim key As String = key_values(0).Trim().ToLowerInvariant()
                        Dim value As String = key_values(1).Trim()
                        Select Case key
                            Case "username"
                                smtpUserName = value
                            Case "password"
                                smtpPassword = value
                            Case "smtpport"
                                smtpPort = value
                            Case "smtphost"
                                smtpServer = value
                        End Select
                    End If
                End If
            Next
        End If
    End Sub

    Private Function SendEmail(ByVal emlFilePath As String) As Boolean
        Dim fromEmailAddress As String = ""
        Dim recipient As String = ""
        Dim emailSubject As String = ""
        Dim result As Boolean = False
        Dim fromDisplayName As String = ""
        Dim emailCfgFileName As String = ""
        attachmentName = ""
        TransactionLog("SendEmail - filename = " & emlFilePath)
        Try
            If File.Exists(emlFilePath) Then
                Dim arrContent As String() = File.ReadAllLines(emlFilePath)

                For Each content As String In arrContent
                    If Not String.IsNullOrEmpty(content) Then
                        Dim key_values As String() = content.Split("=")
                        If Not key_values Is Nothing AndAlso key_values.Length > 1 Then
                            Dim key As String = key_values(0).Trim().ToLowerInvariant()
                            Dim value As String = key_values(1).Trim()

                            Select Case key
                                Case "fromuname"
                                    emailCfgFileName = value
                                Case "filename"
                                    attachmentName = value
                                Case "from"
                                    fromEmailAddress = value
                                Case "recipient"
                                    recipient = value
                                Case "description"
                                    emailSubject = value
                                Case "fromdisplayname"
                                    fromDisplayName = value
                            End Select
                        End If
                    End If
                Next
            End If

            ReadSmtpServerSettings("email.cfg")

            Dim emailCfgFullPath As String = ""
            If File.Exists(Path.Combine(emailCfgDirectoryPath, emailCfgFileName & ".cfg")) Then
                TransactionLog("getting settings from " & emailCfgDirectoryPath & emailCfgFileName & ".cfg")
                emailCfgFullPath = Path.Combine(emailCfgDirectoryPath, emailCfgFileName & ".cfg")
            ElseIf File.Exists(Path.Combine(emailCfgDirectoryPath, "email", emailCfgFileName & ".cfg")) Then
                TransactionLog("getting settings from " & emailCfgDirectoryPath & emailCfgFileName & ".cfg")
                emailCfgFullPath = Path.Combine(emailCfgDirectoryPath, "email", emailCfgFileName & ".cfg")
            End If

            If Not String.IsNullOrEmpty(emailCfgFullPath) Then
                Dim arrContent As String() = File.ReadAllLines(emailCfgFullPath)

                For Each content As String In arrContent
                    If Not String.IsNullOrEmpty(content) Then
                        Dim key_values As String() = content.Split("=")
                        If Not key_values Is Nothing AndAlso key_values.Length > 1 Then
                            Dim key As String = key_values(0).Trim().ToLowerInvariant()
                            Dim value As String = key_values(1).Trim()

                            Select Case key
                                Case "fromuname"
                                    emailCfgFileName = value
                                Case "filename"
                                    attachmentName = value
                                Case "from"
                                    fromEmailAddress = value
                                Case "recipient"
                                    recipient = value
                                Case "description"
                                    emailSubject = value
                                Case "fromdisplayname"
                                    fromDisplayName = value
                                Case "username"
                                    smtpUserName = value
                                Case "password"
                                    smtpPassword = value
                                Case "smtpport"
                                    smtpPort = value
                                Case "smtphost"
                                    smtpServer = value
                            End Select
                        End If
                    End If
                Next
            End If
            TransactionLog("SendEmail - FromUname = " & emailCfgFileName)
            TransactionLog("SendEmail - From = " & fromEmailAddress)
            TransactionLog("SendEmail - Recipient = " & recipient)
            TransactionLog("SendEmail - Description = " & emailSubject)
            TransactionLog("SendEmail - From Display Name" & fromDisplayName)
            TransactionLog("SendEmail - Attachment = " & attachmentName)
            TransactionLog("SendEmail - SMTPhost = " & smtpServer)
            TransactionLog("SendEmail - SMTPort = " & smtpPort)
            TransactionLog("SendEmail - UserName = " & smtpUserName)

            Dim emailMsg As MailMessage = New MailMessage()

            If Not String.IsNullOrEmpty(fromDisplayName) Then
                emailMsg.From = New MailAddress(fromEmailAddress, fromDisplayName)
            Else
                emailMsg.From = New MailAddress(fromEmailAddress)
            End If

            emailMsg.To.Add(recipient)

            emailMsg.Subject = emailSubject
            emailMsg.Body = ""

            emailMsg.IsBodyHtml = False

            Dim client As SmtpClient = New SmtpClient(smtpServer, CInt(smtpPort))

            client.UseDefaultCredentials = False

            If Not String.IsNullOrEmpty(smtpUserName) AndAlso Not String.IsNullOrEmpty(smtpPassword) Then
                client.Credentials = New System.Net.NetworkCredential(smtpUserName, smtpPassword)
            End If

            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.EnableSsl = True

            If Not String.IsNullOrEmpty(attachmentName) AndAlso File.Exists(attachmentName) Then
                Using attachment As New System.Net.Mail.Attachment(attachmentName)
                    emailMsg.Attachments.Add(attachment)
                    client.Send(emailMsg)
                    result = True
                    TransactionLog("Email sent sucessfully.")
                End Using
            Else
                result = False
                TransactionLog("Failed to send email. Attachment is not present: " & attachmentName)
            End If
        Catch ex As Exception
            TransactionLog("Failed to send email.")
            TransactionLog(ex.ToString())
            'Console.ReadLine()
        End Try
        Return result
    End Function

    Public Sub TransactionLog(ByVal strLogMessage As String)
        Dim strFilepath As String
        strFilepath = Environment.CurrentDirectory & "\Log\"
        If Not System.IO.Directory.Exists(strFilepath) Then
            System.IO.Directory.CreateDirectory(strFilepath)
        End If
        strFilepath = strFilepath & "log.txt"
        Dim SWObj As StreamWriter
        strLogMessage = String.Format("{0}:{1}", DateTime.Now, strLogMessage)
        If Not File.Exists(strFilepath) Then
            SWObj = New StreamWriter(strFilepath)
        Else
            SWObj = File.AppendText(strFilepath)
        End If
        SWObj.WriteLine(strLogMessage)
        SWObj.WriteLine()
        SWObj.Close()
    End Sub
End Module
