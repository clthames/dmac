Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Collections.Specialized
Imports System.Security.Principal
Imports System.Management

Public Class frmPrincipal
    Implements IDisposable
    Public claPrin As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
    Public Shared oConfig As New clsConfig
    Private mobjPagesetings As PageSettings
    Private mintcurrentPageIndex As Integer
    Private mobjStreams As New List(Of Stream)()
    Public rvPrin As ReportViewerExtended
    Public mblnLandscape As Boolean = False
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadSettings()

            Dim msg As String = oExcelSS.AppInit()
            If msg = "" Then
                oConfig.InitializeProperties(claPrin)
                Dim srURL As New System.Uri(oConfig.rReportServerURL)
                rvPrin.ServerReport.ReportPath = oConfig.rReportPath & oConfig.ReportName
                rvPrin.ServerReport.ReportServerUrl = srURL
                oConfig.CheckForParameters(claPrin, rvPrin)
                'Dim nCred As New System.Net.NetworkCredential(oConfig.rNetworkUser, ExcelSSGen.Main.DecodedPassword(oConfig.rNetworkPass))
                'rvPrin.ServerReport.ReportServerCredentials.NetworkCredentials = nCred
                rvPrin.RefreshReport()

            Else
                MsgBox(msg, MsgBoxStyle.Critical)
                oExcelSS.EndApplication()
            End If

        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub

    Public Sub LoadSettings()
        Try
            oExcelSS.logoURL = ConfigurationSettings.AppSettings("logoURL")
            oExcelSS.AppFolderName = ConfigurationSettings.AppSettings("AppFolderName")
            oExcelSS.IniAppFile = ConfigurationSettings.AppSettings("IniAppFile")
            oExcelSS.ReportToolName = ConfigurationSettings.AppSettings("ReportToolName")
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub


    Private Function CreateEMFDeviceInfo() As String
        Try
            Dim paperSize As PaperSize = mobjPagesetings.PaperSize
            Dim margins As Margins = mobjPagesetings.Margins

            ' The device info string defines the page range to print as well as the size of the page.
            ' A start and end page of 0 means generate all pages.
            Return String.Format(CultureInfo.InvariantCulture, "<DeviceInfo><OutputFormat>emf</OutputFormat><StartPage>0</StartPage><EndPage>0</EndPage><MarginTop>{0}</MarginTop><MarginLeft>{1}</MarginLeft><MarginRight>{2}</MarginRight><MarginBottom>{3}</MarginBottom><PageHeight>{4}</PageHeight><PageWidth>{5}</PageWidth></DeviceInfo>", ToInches(margins.Top), ToInches(margins.Left), ToInches(margins.Right), ToInches(margins.Bottom), _
                ToInches(paperSize.Height), ToInches(paperSize.Width))
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Function



    Public Sub RenderAllServerReportPages(serverReport As ServerReport)
        Try
            mobjStreams = New List(Of Stream)()
            Dim reportPageSettings As ReportPageSettings = serverReport.GetDefaultPageSettings()
            ' The page settings object will use the default printer unless
            ' PageSettings.PrinterSettings is changed.  This assumes there
            ' is a default printer.
            mobjPagesetings = New PageSettings()
            'mobjPagesetings.PaperSize = reportPageSettings.PaperSize
            mobjPagesetings.PaperSize = New PaperSize("Letter", 1400, 850)
            mobjPagesetings.Margins = reportPageSettings.Margins
            'mobjPagesetings.Margins.Left = 0
            'mobjPagesetings.Margins.Right = 0
            mobjPagesetings.Landscape = True

            Dim deviceInfo As String = CreateEMFDeviceInfo()

            ' Generating Image renderer pages one at a time can be expensive.  In order
            ' to generate page 2, the server would need to recalculate page 1 and throw it
            ' away.  Using PersistStreams causes the server to generate all the pages in
            ' the background but return as soon as page 1 is complete.
            Dim firstPageParameters As New NameValueCollection()
            firstPageParameters.Add("rs:PersistStreams", "True")

            ' GetNextStream returns the next page in the sequence from the background process
            ' started by PersistStreams.
            Dim nonFirstPageParameters As New NameValueCollection()
            nonFirstPageParameters.Add("rs:GetNextStream", "True")

            Dim mimeType As String
            Dim fileExtension As String
            Dim pageStream As Stream = serverReport.Render("IMAGE", deviceInfo, firstPageParameters, mimeType, fileExtension)

            ' The server returns an empty stream when moving beyond the last page.
            While pageStream.Length > 0
                mobjStreams.Add(pageStream)

                pageStream = serverReport.Render("IMAGE", deviceInfo, nonFirstPageParameters, mimeType, fileExtension)
            End While
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub

    Private Shared Function ToInches(hundrethsOfInch As Integer) As String
        Try
            Dim inches As Double = hundrethsOfInch / 100.0
            Return inches.ToString(CultureInfo.InvariantCulture) + "in"
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
        Return "0in"
    End Function


    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Try
            Dim pageImage As New Metafile(mobjStreams(mintcurrentPageIndex))

            ' MsgBox("Width = " & ev.PageBounds.Width.ToString() & ", Height = " & ev.PageBounds.Height.ToString())

            ' Adjust rectangular area with printer margins.
            Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), _
                                              ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), _
                                              ev.PageBounds.Width, _
                                              ev.PageBounds.Height)

            ' Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

            ' Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect)

            ' Prepare for the next page. Make sure we haven't hit the end.
            mintcurrentPageIndex += 1
            ev.HasMorePages = (mintcurrentPageIndex < mobjStreams.Count)
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try

    End Sub
    Public Sub Print()
        Try
            If mobjStreams Is Nothing OrElse mobjStreams.Count = 0 Then
                Throw New Exception("Error: no stream to print.")
            End If
            Using wic As WindowsImpersonationContext = WindowsIdentity.Impersonate(IntPtr.Zero)

                Dim printDoc As New PrintDocument()
                If Not String.IsNullOrEmpty(oConfig.PrinterName) Then

                    Dim lobjquery As System.Management.ObjectQuery = New System.Management.ObjectQuery("SELECT * from Win32_Printer where name like '%" & oConfig.PrinterName & "'")
                    Dim lobjSearcher As ManagementObjectSearcher = New ManagementObjectSearcher(lobjquery)
                    Dim lobjCollection As ManagementObjectCollection = lobjSearcher.Get()
                    oExcelSS.ErrorLog("Count: " & lobjCollection.Count)
                    For Each lobjprinter As ManagementObject In lobjCollection
                        printDoc.PrinterSettings.PrinterName = lobjprinter.GetPropertyValue("Name")
                        oExcelSS.ErrorLog("Printer Name:" & lobjprinter.GetPropertyValue("Name"))
                    Next
                    oExcelSS.ErrorLog("Printer Name:" & oConfig.PrinterName)
                End If

                Dim lobjPrintPermission As PrintingPermission = New PrintingPermission(System.Security.Permissions.PermissionState.Unrestricted)
                lobjPrintPermission.Level = PrintingPermissionLevel.AllPrinting
                printDoc.DefaultPageSettings.Landscape = mblnLandscape
                'If Not printDoc.PrinterSettings.IsValid Then
                '    Throw New Exception("Error: cannot find the  printer.")
                'Else
                mintcurrentPageIndex = 0
                AddHandler printDoc.PrintPage, AddressOf PrintPage

                printDoc.Print()
            End Using
            ' End If+
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub

    Public Sub PrintDocument()

        Try
            If mobjStreams Is Nothing OrElse mobjStreams.Count = 0 Then
                Throw New Exception("Error: no stream to print.")
            End If

            Dim printDoc As New PrintDocument()
            If Not String.IsNullOrEmpty(oConfig.PrinterName) Then

                Dim lobjquery As System.Management.ObjectQuery = New System.Management.ObjectQuery("SELECT * from Win32_Printer where name like '%" & oConfig.PrinterName & "'")
                Dim lobjSearcher As ManagementObjectSearcher = New ManagementObjectSearcher(lobjquery)
                Dim lobjCollection As ManagementObjectCollection = lobjSearcher.Get()
                oExcelSS.ErrorLog("Count: " & lobjCollection.Count)
                For Each lobjprinter As ManagementObject In lobjCollection
                    printDoc.PrinterSettings.PrinterName = lobjprinter.GetPropertyValue("Name")
                    oExcelSS.ErrorLog("Printer Name:" & lobjprinter.GetPropertyValue("Name"))
                Next
                oExcelSS.ErrorLog("Printer Name:" & oConfig.PrinterName)
            End If

            Dim lobjPrintPermission As PrintingPermission = New PrintingPermission(System.Security.Permissions.PermissionState.Unrestricted)
            lobjPrintPermission.Level = PrintingPermissionLevel.AllPrinting
            printDoc.DefaultPageSettings.Landscape = mblnLandscape
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Letter", 850, 1400)
            mintcurrentPageIndex = 0
            AddHandler printDoc.PrintPage, AddressOf PrintPage

            'Dim dlgPrintPreview As New PrintPreviewDialog
            'dlgPrintPreview.Document = printDoc
            'dlgPrintPreview.ClientSize = New System.Drawing.Size(900, 800)
            'dlgPrintPreview.Location = New System.Drawing.Point(50, 50)
            'dlgPrintPreview.Name = "RptPrintPreviewDialog"
            'dlgPrintPreview.MinimumSize = New System.Drawing.Size(375, 250)
            'dlgPrintPreview.UseAntiAlias = True

            'dlgPrintPreview.ShowDialog()

            Dim dlgPrint As New PrintDialog
            dlgPrint.Document = printDoc
            
            If dlgPrint.ShowDialog() = Windows.Forms.DialogResult.OK Then
                printDoc.Print()
            End If


        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try

    End Sub

End Class
