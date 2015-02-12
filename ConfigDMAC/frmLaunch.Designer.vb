<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaunch
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
        Me.btn_Launch = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.txtlaunchtext = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_Launch
        '
        Me.btn_Launch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Launch.Location = New System.Drawing.Point(133, 35)
        Me.btn_Launch.Name = "btn_Launch"
        Me.btn_Launch.Size = New System.Drawing.Size(75, 23)
        Me.btn_Launch.TabIndex = 2
        Me.btn_Launch.Text = "Launch"
        Me.btn_Launch.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cancel.Location = New System.Drawing.Point(215, 34)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 3
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'txtlaunchtext
        '
        Me.txtlaunchtext.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtlaunchtext.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtlaunchtext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtlaunchtext.Location = New System.Drawing.Point(12, 12)
        Me.txtlaunchtext.Name = "txtlaunchtext"
        Me.txtlaunchtext.ReadOnly = True
        Me.txtlaunchtext.Size = New System.Drawing.Size(401, 13)
        Me.txtlaunchtext.TabIndex = 4
        Me.txtlaunchtext.Text = "41"
        Me.txtlaunchtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmLaunch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(425, 63)
        Me.Controls.Add(Me.txtlaunchtext)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Launch)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmLaunch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Launch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Launch As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents txtlaunchtext As System.Windows.Forms.TextBox
End Class
