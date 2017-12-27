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
        Dim emailCustName As String = ""
        Dim recipientDisplayName As String = ""
        Dim emailCfgFileName As String = ""
        Dim statusLogFileName As String
        Dim temp1 As String = "001"
        attachmentName = ""
        TransactionLog("SendEmail - filename = " & emlFilePath)

        Do
            statusLogFileName = Format(Now, "MMddhhmm") & "." & temp1
            If Dir(emailCfgDirectoryPath & "\Log\" & statusLogFileName) = "" Then Exit Do
            If Val(temp1) < 999 Then
                temp1 = Right("000" & Trim(Str(Val(temp1) + 1)), 3)
            Else
                temp1 = "001"
            End If
        Loop
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
                                Case "custname"
                                    emailCustName = value
                                Case "recipientdisplayname"
                                    recipientDisplayName = value
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
                    CreateStatusLog(statusLogFileName, "Sent successfully", recipient, recipientDisplayName, emailCustName, fromEmailAddress, emailSubject, fromDisplayName)
                End Using
            Else
                result = False
                TransactionLog("Failed to send email. Attachment is not present: " & attachmentName)
                CreateStatusLog(statusLogFileName, "Failure", recipient, recipientDisplayName, emailCustName, fromEmailAddress, emailSubject, fromDisplayName)
            End If
        Catch ex As Exception
            TransactionLog("Failed to send email.")
            TransactionLog(ex.ToString())
            CreateStatusLog(statusLogFileName, "Failure", recipient, recipientDisplayName, emailCustName, fromEmailAddress, emailSubject, fromDisplayName)
        End Try
        Return result
    End Function

    Public Sub TransactionLog(ByVal strLogMessage As String)
        Dim strFilepath As String
        strFilepath = emailCfgDirectoryPath & "\" '& "\Log\"
        If Not System.IO.Directory.Exists(strFilepath) Then
            System.IO.Directory.CreateDirectory(strFilepath)
        End If
        strFilepath = strFilepath & "emaillog.txt"
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

    Public Sub StatusLog(ByVal logFile As String, ByVal strLogMessage As String)
        Dim strFilepath As String
        strFilepath = emailCfgDirectoryPath & "\Log\"
        If Not System.IO.Directory.Exists(strFilepath) Then
            System.IO.Directory.CreateDirectory(strFilepath)
        End If
        strFilepath = strFilepath & logFile
        Dim SWObj As StreamWriter
        SWObj = New StreamWriter(strFilepath)
        SWObj.WriteLine(strLogMessage)
        SWObj.WriteLine()
        SWObj.Close()
    End Sub

    Public Sub CreateStatusLog(ByVal logFileName As String, ByVal status As String, ByVal recipient As String, ByVal emailRecipientDisplayName As String,
                               ByVal emailCustomerName As String, ByVal fromEmailAddress As String, ByVal emailSubject As String, ByVal fromDisplayName As String)

        Dim LogTrans As String, temp As String
        LogTrans = "*" & logFileName & "* (Filename is saved in SenderDepartment)" & vbCrLf
        LogTrans = LogTrans & "SenderDepartment = " & logFileName & vbCrLf
        temp = emailCustomerName
        If Trim(emailRecipientDisplayName) <> "" Then
            temp = Trim(emailRecipientDisplayName) & " @ " & Trim(emailCustomerName)
        End If
        LogTrans = LogTrans & "Recipient.Name = " & temp & vbCrLf
        LogTrans = LogTrans & "Recipient.FaxNumber = " & recipient & vbCrLf
        LogTrans = LogTrans & "DocumentName = " & emailSubject & vbCrLf
        LogTrans = LogTrans & "Status = " & status & vbCrLf
        LogTrans = LogTrans & "Id = " & "email" & vbCrLf
        LogTrans = LogTrans & "OriginalScheduledTime = " & "Now" & vbCrLf
        LogTrans = LogTrans & "Pages = " & "0" & vbCrLf
        LogTrans = LogTrans & "Retries = " & "0" & vbCrLf
        LogTrans = LogTrans & "Sender.Company = " & "email" & vbCrLf
        temp = fromEmailAddress
        If Trim(fromDisplayName) <> "" Then
            temp = Trim(fromDisplayName) & " (" & Trim(fromEmailAddress) & ")"
        End If
        LogTrans = LogTrans & "Sender.Name = " & temp & vbCrLf
        LogTrans = LogTrans & "Subject = " & emailSubject & vbCrLf
        LogTrans = LogTrans & "SubmissionTime = " & Now & vbCrLf

        StatusLog(logFileName, LogTrans)
    End Sub
End Module
