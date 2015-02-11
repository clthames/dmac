<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyword
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
        Me.lblKeyword = New System.Windows.Forms.Label()
        Me.lblProgramName = New System.Windows.Forms.Label()
        Me.lblOptionValue = New System.Windows.Forms.Label()
        Me.txtKeyword = New System.Windows.Forms.TextBox()
        Me.txtProgramName = New System.Windows.Forms.TextBox()
        Me.txtOptionValue = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblKeyword
        '
        Me.lblKeyword.AutoSize = True
        Me.lblKeyword.Location = New System.Drawing.Point(13, 16)
        Me.lblKeyword.Name = "lblKeyword"
        Me.lblKeyword.Size = New System.Drawing.Size(48, 13)
        Me.lblKeyword.TabIndex = 0
        Me.lblKeyword.Text = "Keyword"
        '
        'lblProgramName
        '
        Me.lblProgramName.AutoSize = True
        Me.lblProgramName.Location = New System.Drawing.Point(13, 44)
        Me.lblProgramName.Name = "lblProgramName"
        Me.lblProgramName.Size = New System.Drawing.Size(77, 13)
        Me.lblProgramName.TabIndex = 1
        Me.lblProgramName.Text = "Program Name"
        '
        'lblOptionValue
        '
        Me.lblOptionValue.AutoSize = True
        Me.lblOptionValue.Location = New System.Drawing.Point(13, 70)
        Me.lblOptionValue.Name = "lblOptionValue"
        Me.lblOptionValue.Size = New System.Drawing.Size(68, 13)
        Me.lblOptionValue.TabIndex = 2
        Me.lblOptionValue.Text = "Option Value"
        '
        'txtKeyword
        '
        Me.txtKeyword.Location = New System.Drawing.Point(123, 13)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.Size = New System.Drawing.Size(313, 20)
        Me.txtKeyword.TabIndex = 3
        '
        'txtProgramName
        '
        Me.txtProgramName.Location = New System.Drawing.Point(123, 41)
        Me.txtProgramName.Name = "txtProgramName"
        Me.txtProgramName.Size = New System.Drawing.Size(313, 20)
        Me.txtProgramName.TabIndex = 4
        '
        'txtOptionValue
        '
        Me.txtOptionValue.Location = New System.Drawing.Point(123, 67)
        Me.txtOptionValue.Name = "txtOptionValue"
        Me.txtOptionValue.Size = New System.Drawing.Size(313, 20)
        Me.txtOptionValue.TabIndex = 5
        '
        'btnOk
        '
        Me.btnOk.Enabled = False
        Me.btnOk.Location = New System.Drawing.Point(280, 93)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(361, 93)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmKeyword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(447, 123)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtOptionValue)
        Me.Controls.Add(Me.txtProgramName)
        Me.Controls.Add(Me.txtKeyword)
        Me.Controls.Add(Me.lblOptionValue)
        Me.Controls.Add(Me.lblProgramName)
        Me.Controls.Add(Me.lblKeyword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmKeyword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmKeyword"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblKeyword As System.Windows.Forms.Label
    Friend WithEvents lblProgramName As System.Windows.Forms.Label
    Friend WithEvents lblOptionValue As System.Windows.Forms.Label
    Friend WithEvents txtKeyword As System.Windows.Forms.TextBox
    Friend WithEvents txtProgramName As System.Windows.Forms.TextBox
    Friend WithEvents txtOptionValue As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
