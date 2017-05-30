
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.Reporting.WinForms
Imports System.Windows.Forms
Imports System.IO
Imports System.Resources


Public Class ReportViewerExtended
    Inherits ReportViewer

    Protected Overrides Sub OnControlAdded(e As System.Windows.Forms.ControlEventArgs)
        Me.SetToolStripItems(e.Control)
        MyBase.OnControlAdded(e)
    End Sub

    Public Sub New()

    End Sub
    Private Sub SetToolStripItems(lobjToolStripControl As Control)
        Try

            If TypeOf lobjToolStripControl Is ToolStrip Then
                Dim tsic As ToolStripItemCollection = DirectCast(lobjToolStripControl, ToolStrip).Items
                Dim index As Integer = 0
                Dim lobj As New ToolStripButton(CType(My.Resources.email1, Image))
                lobj.ToolTipText = "Email"
                AddHandler lobj.Click, AddressOf EmailClicked
                tsic.Insert(12, lobj)
                lobj = New ToolStripButton(CType(My.Resources.Print, Image))
                lobj.ToolTipText = "Print"
                AddHandler lobj.Click, AddressOf Printclicked
                tsic.Insert(13, lobj)

                Dim lobjToolStripCombo As ToolStripComboBox = New ToolStripComboBox("PrinterLayoutettings")
                lobjToolStripCombo.DropDownStyle = ComboBoxStyle.DropDownList

                lobjToolStripCombo.Name = "PrinterLayoutettings"
                lobjToolStripCombo.ToolTipText = "PrintLayout"
                lobjToolStripCombo.Items.Add("Portrait")
                lobjToolStripCombo.Items.Add("Landscape")
                lobjToolStripCombo.SelectedIndex = 0
                AddHandler lobjToolStripCombo.SelectedIndexChanged, AddressOf LayoutSelectionChanged
                tsic.Insert(14, lobjToolStripCombo)

            End If
            For i As Integer = 0 To lobjToolStripControl.Controls.Count - 1
                SetToolStripItems(lobjToolStripControl.Controls(i))
            Next

        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub

    Private Sub EmailClicked(sender As Object, e As EventArgs)
        ''Dim frmEmail As New frmEmailOptions(Me)
        '' frmEmail.ShowDialog()
        Dim iniFilePath As String = oExcelSS.AppPath & "\"
        Dim executableFileName As String = "SendEmails.exe"
        Dim executeFilePath As String = iniFilePath & executableFileName
        Dim args() As String = {Me.ExportReport(), "Report", "0", "0"}
        Process.Start(executeFilePath, String.Join(" ", args))

    End Sub

    Private Sub Printclicked(sender As Object, e As EventArgs)
        Try
            DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripButton).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).RenderAllServerReportPages(DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripButton).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).rvPrin.ServerReport)
            'DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripButton).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).Print()
            DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripButton).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).PrintDocument()
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub

    Private Sub LayoutSelectionChanged(sender As Object, e As EventArgs)
        If DirectCast(sender, System.Windows.Forms.ToolStripComboBox).SelectedIndex = 1 Then
            DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripComboBox).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).mblnLandscape = True
        Else
            DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripComboBox).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).mblnLandscape = False
        End If

    End Sub

    ''' <summary>
    ''' Exports Report into PDF format and returns generated PDF filename as output
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExportReport() As String
        Dim v_mimetype As String = ""
        Dim v_encoding As String = ""
        Dim v_filename_extension As String = ""
        Dim v_streamids() As String
        Dim o_warnings() As Microsoft.Reporting.WinForms.Warning
        Dim fileName As String = Path.Combine(Path.GetTempPath() & ServerReport.ReportPath.Replace("/", "\") & Today.Year.ToString & Today.Month.ToString & Today.Day.ToString() &
                                              DateTime.Now.Hour.ToString() & DateTime.Now.Minute.ToString() & DateTime.Now.Day.ToString() & ".PDF")
        fileName = fileName.Replace("\\", "\")
        Dim directoryName As String = Path.GetDirectoryName(fileName)

        If Not Directory.Exists(directoryName) Then
            Directory.CreateDirectory(directoryName)
        End If

        Dim content() As Byte = Me.ServerReport.Render("PDF", Nothing, v_mimetype, v_encoding, v_filename_extension, v_streamids, o_warnings)
        Using fs As New IO.FileStream(fileName, IO.FileMode.Create)
            fs.Write(content, 0, content.Length)
        End Using

        Return fileName
    End Function

End Class
