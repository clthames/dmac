Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Configuration
Module Main
    Public companyarray As New ArrayList
    Public menuArray As New ArrayList
    Public oExcelSS As New ExcelSSGen.Main

    Public Sub main()
        LoadSettings()
        Dim msg As String = oExcelSS.AppInit()
        If msg = "" Then
            Dim Path As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath & "\" & oExcelSS.AppFolderName) & "\"
            loadCompany(Path & oExcelSS.IniAppFile)
            getLogoAndUrl(oExcelSS.logoURL)
            Application.EnableVisualStyles()
            Application.Run(New Master)
        Else
            MsgBox(msg, MsgBoxStyle.Critical, My.Resources.applicationTitle)
            oExcelSS.EndApplication()
        End If
    End Sub
    Public Sub LoadSettings()
        oExcelSS.logoURL = ConfigurationSettings.AppSettings("logoURL")
        oExcelSS.AppFolderName = ConfigurationSettings.AppSettings("AppFolderName")
        oExcelSS.IniAppFile = ConfigurationSettings.AppSettings("IniAppFile")
        oExcelSS.ReportToolName = ConfigurationSettings.AppSettings("ReportToolName")
    End Sub
    Public Structure MenuList
        Public menuName As String
        Public menuModule As String
        Public menuRunProgram As String
        Public Sub New(ByVal menuName As String, ByVal menuModule As String, ByVal runProgram As String)
            Me.menuName = menuName
            Me.menuModule = menuModule
            Me.menuRunProgram = runProgram
        End Sub
        Public ReadOnly Property getMenuName
            Get
                Return Me.menuName
            End Get
        End Property
        Public ReadOnly Property getMenuModule
            Get
                Return Me.menuModule
            End Get
        End Property
        Public ReadOnly Property getMenuRunProgram
            Get
                Return Me.menuRunProgram
            End Get
        End Property
    End Structure
    'structure for load the company list from the dmac.ini file
    Public Structure CompanyList
        Public companyName As String
        Public companyID As String
        Public Sub New(ByVal companyName As String, ByVal companyID As String)
            Me.companyName = companyName
            Me.companyID = companyID
        End Sub
        Public ReadOnly Property getCompanyName
            Get
                Return companyName
            End Get
        End Property
        Public ReadOnly Property getCompanyID
            Get
                Return companyID
            End Get
        End Property
    End Structure
    Public Structure OutlookButtonList
        Public buttonShortcut As String
        Public shortcutFor As String
        Public shortcutType As String
        Public linkTo As String
        Public outlookbutton As OutlookStyleControls.OutlookBarButton
        Public Sub New(ByVal buttonShortcut As String, ByVal shortcutType As String, ByVal shortcutFor As String, ByVal linkTo As String, ByVal button As OutlookStyleControls.OutlookBarButton)
            Me.shortcutType = shortcutType
            Me.buttonShortcut = buttonShortcut
            Me.shortcutFor = shortcutFor
            Me.linkTo = linkTo
            Me.outlookbutton = button
        End Sub
        Public ReadOnly Property getShortcutType
            Get
                Return shortcutType
            End Get
        End Property
        Public ReadOnly Property getButton
            Get
                Return Me.outlookbutton
            End Get
        End Property
        Public ReadOnly Property getLinkTo
            Get
                Return Me.linkTo
            End Get
        End Property
        Public ReadOnly Property getShortcutFor
            Get
                Return Me.shortcutFor
            End Get
        End Property
        Public ReadOnly Property getButtonShortcut
            Get
                Return Me.buttonShortcut
            End Get
        End Property
    End Structure
    Public Sub LoadReportDataSeletor(ByVal currentMenuItem As ToolStripMenuItem)
        Try
            Dim szGroup As String = ""
            Dim currentMenu As String = DirectCast(currentMenuItem, ToolStripMenuItem).Tag
            szGroup = currentMenu
            Dim SelectCategory As New frmSelectCategory(currentMenu, "")
            SelectCategory.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadCompany(ByVal path As String)
        Try
            Dim objReader As New System.IO.StreamReader(path)
            Dim TextLine As String
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine() & vbNewLine
                If TextLine.Trim <> "" Then
                    Dim tmpKeyword As String = Left(TextLine, InStr(TextLine, "=") - 1).Trim()
                    Select Case LCase(tmpKeyword)
                        Case "company"
                            Dim _comma() = Mid(TextLine, InStr(TextLine, "=") + 1).Trim().Split(",")
                            If _comma(0).ToString().Trim().Length <> 0 Then
                                companyarray.Add(New CompanyList(_comma(1).ToString().Trim() & " (" & _comma(0).ToString().Trim() & ")", _comma(0).ToString().Trim()))
                            End If
                    End Select
                Else
                    Exit Do
                End If
            Loop
            objReader.Close()
            objReader.Dispose()
        Catch ex As Exception
            oExcelSS.ErrorLog("Main --> loadCompany Error## " & ex.Message.ToString)
        End Try
    End Sub
    'read the dynamic image and link url from url
    Private Function getLogoAndUrl(ByVal url As String) As Boolean
        Dim status As Boolean = False
        Dim myPageSource As String = String.Empty
        Try
            Dim myWebRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
            myWebRequest.Method = "GET"
            Dim myWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
            Dim myWebSource As New StreamReader(myWebResponse.GetResponseStream())
            myPageSource = myWebSource.ReadToEnd()
            myWebResponse.Close()
            If myPageSource.Split(",").Length >= 2 Then
                oExcelSS.dynamicImage = Convert.ToString(myPageSource.Split(",")(0)).Trim
                oExcelSS.visitUrl = Convert.ToString(myPageSource.Split(",")(1)).Trim
            Else
                MsgBox("Unable to read Logo and link url from specified Url!")
                'End
            End If
        Catch ex As Exception
            status = False
            oExcelSS.ErrorLog("getLogoAndUrl Error## " + ex.Message.ToString())
        End Try
        status = True
        Return status
    End Function
    'return license key for the company id
    Public Function getLicenseFromUrl(ByVal url As String) As String
        Dim status As Boolean = False
        Dim pageSource As String = String.Empty
        Try
            Dim webrequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
            webrequest.Method = "GET"
            Dim webresponse As HttpWebResponse = DirectCast(webrequest.GetResponse(), HttpWebResponse)
            Dim myWebSource As New StreamReader(webresponse.GetResponseStream())
            pageSource = myWebSource.ReadToEnd()
            webresponse.Close()
        Catch ex As Exception
            pageSource = String.Empty
            oExcelSS.ErrorLog("getLicenseFromUrl Error## " + ex.Message.ToString())
        End Try
        Return pageSource
    End Function

    Private Function orepExcelSS() As Object
        Throw New NotImplementedException
    End Function

End Module