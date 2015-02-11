<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rvPrin = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvPrin
        '
        Me.rvPrin.AutoSize = True
        Me.rvPrin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvPrin.Location = New System.Drawing.Point(0, 0)
        Me.rvPrin.Name = "rvPrin"
        Me.rvPrin.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rvPrin.ServerReport.ReportServerUrl = New System.Uri("", System.UriKind.Relative)
        Me.rvPrin.ShowCredentialPrompts = False
        Me.rvPrin.Size = New System.Drawing.Size(966, 665)
        Me.rvPrin.TabIndex = 0
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(966, 665)
        Me.Controls.Add(Me.rvPrin)
        Me.Name = "frmPrincipal"
        Me.Text = "DMAC Report Viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rvPrin As Microsoft.Reporting.WinForms.ReportViewer

End Class
