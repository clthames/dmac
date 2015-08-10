
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
        If TypeOf lobjToolStripControl Is ToolStrip Then
            Dim tsic As ToolStripItemCollection = DirectCast(lobjToolStripControl, ToolStrip).Items
            Dim index As Integer = 0
            Dim lobj As New ToolStripButton(CType(My.Resources.email1, Image))
            lobj.ToolTipText = "Email"
            AddHandler lobj.Click, AddressOf EmailClicked
            tsic.Insert(12, lobj)
            lobj = New ToolStripButton(CType(My.Resources.Print, Image))
            lobj.ToolTipText = "Print"
            AddHandler lobj.Click, AddressOf EmailClicked
            tsic.Insert(13, lobj)

        End If
        For i As Integer = 0 To lobjToolStripControl.Controls.Count - 1
            SetToolStripItems(lobjToolStripControl.Controls(i))
        Next
    End Sub

    Private Sub EmailClicked(sender As Object, e As EventArgs)
        DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripButton).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).RenderAllServerReportPages(DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripButton).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).rvPrin.ServerReport)
        DirectCast(DirectCast(sender, System.Windows.Forms.ToolStripButton).GetCurrentParent.Parent.FindForm(), dmacReports.frmPrincipal).Print()
    End Sub


End Class
