<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.components = New System.ComponentModel.Container()
        Me.cntxtmenustrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NEWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.trvwSettings = New System.Windows.Forms.TreeView()
        Me.lstvwSettingValues = New System.Windows.Forms.ListView()
        Me.clmnName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmnValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.lblKeyword = New System.Windows.Forms.Label()
        Me.grpbx_Settings = New System.Windows.Forms.GroupBox()
        Me.cntxtmenustrip.SuspendLayout()
        Me.grpbx_Settings.SuspendLayout()
        Me.SuspendLayout()
        '
        'cntxtmenustrip
        '
        Me.cntxtmenustrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NEWToolStripMenuItem})
        Me.cntxtmenustrip.Name = "cntxtmenustrip"
        Me.cntxtmenustrip.Size = New System.Drawing.Size(101, 26)
        '
        'NEWToolStripMenuItem
        '
        Me.NEWToolStripMenuItem.Name = "NEWToolStripMenuItem"
        Me.NEWToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.NEWToolStripMenuItem.Text = "NEW"
        '
        'trvwSettings
        '
        Me.trvwSettings.Location = New System.Drawing.Point(9, 54)
        Me.trvwSettings.Name = "trvwSettings"
        Me.trvwSettings.Size = New System.Drawing.Size(216, 415)
        Me.trvwSettings.TabIndex = 0
        '
        'lstvwSettingValues
        '
        Me.lstvwSettingValues.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmnName, Me.clmnValue})
        Me.lstvwSettingValues.FullRowSelect = True
        Me.lstvwSettingValues.Location = New System.Drawing.Point(228, 54)
        Me.lstvwSettingValues.MultiSelect = False
        Me.lstvwSettingValues.Name = "lstvwSettingValues"
        Me.lstvwSettingValues.Size = New System.Drawing.Size(298, 415)
        Me.lstvwSettingValues.TabIndex = 1
        Me.lstvwSettingValues.UseCompatibleStateImageBehavior = False
        Me.lstvwSettingValues.View = System.Windows.Forms.View.Details
        '
        'clmnName
        '
        Me.clmnName.Text = "Name"
        Me.clmnName.Width = 159
        '
        'clmnValue
        '
        Me.clmnValue.Text = "Value"
        Me.clmnValue.Width = 134
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFind.Enabled = False
        Me.btnFind.Location = New System.Drawing.Point(451, 17)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 3
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(110, 19)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(335, 20)
        Me.txtFind.TabIndex = 4
        '
        'lblKeyword
        '
        Me.lblKeyword.AutoSize = True
        Me.lblKeyword.Location = New System.Drawing.Point(47, 22)
        Me.lblKeyword.Name = "lblKeyword"
        Me.lblKeyword.Size = New System.Drawing.Size(57, 13)
        Me.lblKeyword.TabIndex = 2
        Me.lblKeyword.Text = "Keyword : "
        '
        'grpbx_Settings
        '
        Me.grpbx_Settings.Controls.Add(Me.lblKeyword)
        Me.grpbx_Settings.Controls.Add(Me.txtFind)
        Me.grpbx_Settings.Controls.Add(Me.btnFind)
        Me.grpbx_Settings.Controls.Add(Me.lstvwSettingValues)
        Me.grpbx_Settings.Controls.Add(Me.trvwSettings)
        Me.grpbx_Settings.Location = New System.Drawing.Point(3, 2)
        Me.grpbx_Settings.Name = "grpbx_Settings"
        Me.grpbx_Settings.Size = New System.Drawing.Size(532, 476)
        Me.grpbx_Settings.TabIndex = 0
        Me.grpbx_Settings.TabStop = False
        Me.grpbx_Settings.Text = "  Settings  "
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(541, 480)
        Me.Controls.Add(Me.grpbx_Settings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.cntxtmenustrip.ResumeLayout(False)
        Me.grpbx_Settings.ResumeLayout(False)
        Me.grpbx_Settings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cntxtmenustrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NEWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents trvwSettings As System.Windows.Forms.TreeView
    Friend WithEvents lstvwSettingValues As System.Windows.Forms.ListView
    Friend WithEvents clmnName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmnValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents lblKeyword As System.Windows.Forms.Label
    Friend WithEvents grpbx_Settings As System.Windows.Forms.GroupBox
End Class
