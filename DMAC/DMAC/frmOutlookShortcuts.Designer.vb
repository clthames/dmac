<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOutlookShortcuts
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
        Me.pnlOuter = New System.Windows.Forms.Panel()
        Me.pnlPropertyGrid = New System.Windows.Forms.Panel()
        Me.btnReportParameters = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.radDocument = New System.Windows.Forms.RadioButton()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnNewShortcut = New System.Windows.Forms.Button()
        Me.radCustom = New System.Windows.Forms.RadioButton()
        Me.radReport = New System.Windows.Forms.RadioButton()
        Me.radProgram = New System.Windows.Forms.RadioButton()
        Me.btnCreateShortcut = New System.Windows.Forms.Button()
        Me.btnChooseShortcuts = New System.Windows.Forms.Button()
        Me.txtLinkto = New System.Windows.Forms.TextBox()
        Me.btnImages = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtShortcutname = New System.Windows.Forms.TextBox()
        Me.lblProgram = New System.Windows.Forms.Label()
        Me.lblImage = New System.Windows.Forms.Label()
        Me.lblShortcutName = New System.Windows.Forms.Label()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.splButtonNameList = New System.Windows.Forms.Splitter()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pnlLeftButtonNames = New System.Windows.Forms.Panel()
        Me.lstButtons = New System.Windows.Forms.ListBox()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnRemoveOutlookbutton = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ofdIcon = New System.Windows.Forms.OpenFileDialog()
        Me.ofdFile = New System.Windows.Forms.OpenFileDialog()
        Me.ofdcustom = New System.Windows.Forms.OpenFileDialog()
        Me.pnlOuter.SuspendLayout()
        Me.pnlPropertyGrid.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeftButtonNames.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlOuter
        '
        Me.pnlOuter.Controls.Add(Me.pnlPropertyGrid)
        Me.pnlOuter.Controls.Add(Me.splButtonNameList)
        Me.pnlOuter.Controls.Add(Me.Splitter1)
        Me.pnlOuter.Controls.Add(Me.pnlLeftButtonNames)
        Me.pnlOuter.Controls.Add(Me.pnlBottom)
        Me.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOuter.Location = New System.Drawing.Point(0, 0)
        Me.pnlOuter.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.pnlOuter.Name = "pnlOuter"
        Me.pnlOuter.Size = New System.Drawing.Size(578, 422)
        Me.pnlOuter.TabIndex = 0
        '
        'pnlPropertyGrid
        '
        Me.pnlPropertyGrid.Controls.Add(Me.btnReportParameters)
        Me.pnlPropertyGrid.Controls.Add(Me.btnCancel)
        Me.pnlPropertyGrid.Controls.Add(Me.radDocument)
        Me.pnlPropertyGrid.Controls.Add(Me.btnClear)
        Me.pnlPropertyGrid.Controls.Add(Me.btnNewShortcut)
        Me.pnlPropertyGrid.Controls.Add(Me.radCustom)
        Me.pnlPropertyGrid.Controls.Add(Me.radReport)
        Me.pnlPropertyGrid.Controls.Add(Me.radProgram)
        Me.pnlPropertyGrid.Controls.Add(Me.btnCreateShortcut)
        Me.pnlPropertyGrid.Controls.Add(Me.btnChooseShortcuts)
        Me.pnlPropertyGrid.Controls.Add(Me.txtLinkto)
        Me.pnlPropertyGrid.Controls.Add(Me.btnImages)
        Me.pnlPropertyGrid.Controls.Add(Me.PictureBox1)
        Me.pnlPropertyGrid.Controls.Add(Me.txtShortcutname)
        Me.pnlPropertyGrid.Controls.Add(Me.lblProgram)
        Me.pnlPropertyGrid.Controls.Add(Me.lblImage)
        Me.pnlPropertyGrid.Controls.Add(Me.lblShortcutName)
        Me.pnlPropertyGrid.Controls.Add(Me.PropertyGrid1)
        Me.pnlPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPropertyGrid.Location = New System.Drawing.Point(242, 0)
        Me.pnlPropertyGrid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.pnlPropertyGrid.Name = "pnlPropertyGrid"
        Me.pnlPropertyGrid.Size = New System.Drawing.Size(336, 382)
        Me.pnlPropertyGrid.TabIndex = 4
        '
        'btnReportParameters
        '
        Me.btnReportParameters.Enabled = False
        Me.btnReportParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReportParameters.Location = New System.Drawing.Point(190, 186)
        Me.btnReportParameters.Name = "btnReportParameters"
        Me.btnReportParameters.Size = New System.Drawing.Size(30, 23)
        Me.btnReportParameters.TabIndex = 16
        Me.btnReportParameters.Text = "..,"
        Me.btnReportParameters.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(263, 352)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(55, 23)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'radDocument
        '
        Me.radDocument.AutoSize = True
        Me.radDocument.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDocument.ForeColor = System.Drawing.Color.Black
        Me.radDocument.Location = New System.Drawing.Point(107, 222)
        Me.radDocument.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.radDocument.Name = "radDocument"
        Me.radDocument.Size = New System.Drawing.Size(78, 17)
        Me.radDocument.TabIndex = 14
        Me.radDocument.Text = "Document"
        Me.radDocument.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(145, 352)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(55, 23)
        Me.btnClear.TabIndex = 13
        Me.btnClear.Text = "Clear "
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.Visible = False
        '
        'btnNewShortcut
        '
        Me.btnNewShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewShortcut.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewShortcut.Location = New System.Drawing.Point(22, 3)
        Me.btnNewShortcut.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnNewShortcut.Name = "btnNewShortcut"
        Me.btnNewShortcut.Size = New System.Drawing.Size(104, 23)
        Me.btnNewShortcut.TabIndex = 12
        Me.btnNewShortcut.Text = "New Shortcut"
        Me.btnNewShortcut.UseVisualStyleBackColor = True
        '
        'radCustom
        '
        Me.radCustom.AutoSize = True
        Me.radCustom.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCustom.ForeColor = System.Drawing.Color.Black
        Me.radCustom.Location = New System.Drawing.Point(107, 254)
        Me.radCustom.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.radCustom.Name = "radCustom"
        Me.radCustom.Size = New System.Drawing.Size(64, 17)
        Me.radCustom.TabIndex = 11
        Me.radCustom.Text = "Custom"
        Me.radCustom.UseVisualStyleBackColor = True
        '
        'radReport
        '
        Me.radReport.AutoSize = True
        Me.radReport.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radReport.ForeColor = System.Drawing.Color.Black
        Me.radReport.Location = New System.Drawing.Point(107, 190)
        Me.radReport.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.radReport.Name = "radReport"
        Me.radReport.Size = New System.Drawing.Size(60, 17)
        Me.radReport.TabIndex = 10
        Me.radReport.Text = "Report"
        Me.radReport.UseVisualStyleBackColor = True
        '
        'radProgram
        '
        Me.radProgram.AutoSize = True
        Me.radProgram.Checked = True
        Me.radProgram.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radProgram.ForeColor = System.Drawing.Color.Black
        Me.radProgram.Location = New System.Drawing.Point(107, 157)
        Me.radProgram.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.radProgram.Name = "radProgram"
        Me.radProgram.Size = New System.Drawing.Size(68, 17)
        Me.radProgram.TabIndex = 9
        Me.radProgram.TabStop = True
        Me.radProgram.Text = "Program"
        Me.radProgram.UseVisualStyleBackColor = True
        '
        'btnCreateShortcut
        '
        Me.btnCreateShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateShortcut.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateShortcut.Location = New System.Drawing.Point(204, 352)
        Me.btnCreateShortcut.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCreateShortcut.Name = "btnCreateShortcut"
        Me.btnCreateShortcut.Size = New System.Drawing.Size(55, 23)
        Me.btnCreateShortcut.TabIndex = 4
        Me.btnCreateShortcut.Text = "Save"
        Me.btnCreateShortcut.UseVisualStyleBackColor = True
        '
        'btnChooseShortcuts
        '
        Me.btnChooseShortcuts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChooseShortcuts.Location = New System.Drawing.Point(290, 285)
        Me.btnChooseShortcuts.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnChooseShortcuts.Name = "btnChooseShortcuts"
        Me.btnChooseShortcuts.Size = New System.Drawing.Size(26, 22)
        Me.btnChooseShortcuts.TabIndex = 8
        Me.btnChooseShortcuts.Text = "..."
        Me.btnChooseShortcuts.UseVisualStyleBackColor = True
        '
        'txtLinkto
        '
        Me.txtLinkto.Enabled = False
        Me.txtLinkto.Location = New System.Drawing.Point(107, 285)
        Me.txtLinkto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtLinkto.Name = "txtLinkto"
        Me.txtLinkto.Size = New System.Drawing.Size(180, 20)
        Me.txtLinkto.TabIndex = 7
        '
        'btnImages
        '
        Me.btnImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImages.Location = New System.Drawing.Point(139, 119)
        Me.btnImages.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnImages.Name = "btnImages"
        Me.btnImages.Size = New System.Drawing.Size(26, 22)
        Me.btnImages.TabIndex = 6
        Me.btnImages.Text = "..."
        Me.btnImages.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(107, 119)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 21)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'txtShortcutname
        '
        Me.txtShortcutname.Location = New System.Drawing.Point(107, 80)
        Me.txtShortcutname.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtShortcutname.MaxLength = 25
        Me.txtShortcutname.Name = "txtShortcutname"
        Me.txtShortcutname.Size = New System.Drawing.Size(209, 20)
        Me.txtShortcutname.TabIndex = 4
        '
        'lblProgram
        '
        Me.lblProgram.AutoSize = True
        Me.lblProgram.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgram.ForeColor = System.Drawing.Color.Black
        Me.lblProgram.Location = New System.Drawing.Point(62, 287)
        Me.lblProgram.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProgram.Name = "lblProgram"
        Me.lblProgram.Size = New System.Drawing.Size(45, 13)
        Me.lblProgram.TabIndex = 3
        Me.lblProgram.Text = "Link to:"
        '
        'lblImage
        '
        Me.lblImage.AutoSize = True
        Me.lblImage.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImage.ForeColor = System.Drawing.Color.Black
        Me.lblImage.Location = New System.Drawing.Point(65, 121)
        Me.lblImage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblImage.Name = "lblImage"
        Me.lblImage.Size = New System.Drawing.Size(41, 13)
        Me.lblImage.TabIndex = 2
        Me.lblImage.Text = "Image:"
        '
        'lblShortcutName
        '
        Me.lblShortcutName.AutoSize = True
        Me.lblShortcutName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShortcutName.ForeColor = System.Drawing.Color.Black
        Me.lblShortcutName.Location = New System.Drawing.Point(19, 84)
        Me.lblShortcutName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblShortcutName.Name = "lblShortcutName"
        Me.lblShortcutName.Size = New System.Drawing.Size(86, 13)
        Me.lblShortcutName.TabIndex = 1
        Me.lblShortcutName.Text = "Shortcut Name:"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Location = New System.Drawing.Point(222, 388)
        Me.PropertyGrid1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(50, 25)
        Me.PropertyGrid1.TabIndex = 0
        '
        'splButtonNameList
        '
        Me.splButtonNameList.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.splButtonNameList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.splButtonNameList.Location = New System.Drawing.Point(239, 0)
        Me.splButtonNameList.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.splButtonNameList.Name = "splButtonNameList"
        Me.splButtonNameList.Size = New System.Drawing.Size(3, 382)
        Me.splButtonNameList.TabIndex = 3
        Me.splButtonNameList.TabStop = False
        Me.splButtonNameList.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(239, 382)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(339, 3)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        Me.Splitter1.Visible = False
        '
        'pnlLeftButtonNames
        '
        Me.pnlLeftButtonNames.Controls.Add(Me.lstButtons)
        Me.pnlLeftButtonNames.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftButtonNames.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftButtonNames.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.pnlLeftButtonNames.Name = "pnlLeftButtonNames"
        Me.pnlLeftButtonNames.Size = New System.Drawing.Size(239, 385)
        Me.pnlLeftButtonNames.TabIndex = 1
        '
        'lstButtons
        '
        Me.lstButtons.BackColor = System.Drawing.SystemColors.Control
        Me.lstButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstButtons.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstButtons.ForeColor = System.Drawing.Color.Black
        Me.lstButtons.FormattingEnabled = True
        Me.lstButtons.Location = New System.Drawing.Point(0, 0)
        Me.lstButtons.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lstButtons.Name = "lstButtons"
        Me.lstButtons.Size = New System.Drawing.Size(239, 385)
        Me.lstButtons.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.btnOk)
        Me.pnlBottom.Controls.Add(Me.btnRemoveOutlookbutton)
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 385)
        Me.pnlBottom.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(578, 37)
        Me.pnlBottom.TabIndex = 0
        '
        'btnOk
        '
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(446, 5)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(55, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "Save"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnRemoveOutlookbutton
        '
        Me.btnRemoveOutlookbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveOutlookbutton.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveOutlookbutton.Location = New System.Drawing.Point(177, 5)
        Me.btnRemoveOutlookbutton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnRemoveOutlookbutton.Name = "btnRemoveOutlookbutton"
        Me.btnRemoveOutlookbutton.Size = New System.Drawing.Size(62, 23)
        Me.btnRemoveOutlookbutton.TabIndex = 5
        Me.btnRemoveOutlookbutton.Text = "Remove "
        Me.btnRemoveOutlookbutton.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(505, 5)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ofdcustom
        '
        Me.ofdcustom.DefaultExt = "*.exe"
        Me.ofdcustom.Filter = "Application Files|*.exe"
        '
        'frmOutlookShortcuts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(578, 422)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlOuter)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.Name = "frmOutlookShortcuts"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shortcuts"
        Me.pnlOuter.ResumeLayout(False)
        Me.pnlPropertyGrid.ResumeLayout(False)
        Me.pnlPropertyGrid.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeftButtonNames.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlOuter As System.Windows.Forms.Panel
    Friend WithEvents splButtonNameList As System.Windows.Forms.Splitter
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pnlLeftButtonNames As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents lstButtons As System.Windows.Forms.ListBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnRemoveOutlookbutton As System.Windows.Forms.Button
    Friend WithEvents btnCreateShortcut As System.Windows.Forms.Button
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents pnlPropertyGrid As System.Windows.Forms.Panel
    Friend WithEvents btnImages As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtShortcutname As System.Windows.Forms.TextBox
    Friend WithEvents lblProgram As System.Windows.Forms.Label
    Friend WithEvents lblImage As System.Windows.Forms.Label
    Friend WithEvents lblShortcutName As System.Windows.Forms.Label
    Friend WithEvents txtLinkto As System.Windows.Forms.TextBox
    Friend WithEvents btnChooseShortcuts As System.Windows.Forms.Button
    Friend WithEvents radReport As System.Windows.Forms.RadioButton
    Friend WithEvents radProgram As System.Windows.Forms.RadioButton
    Friend WithEvents radCustom As System.Windows.Forms.RadioButton
    Friend WithEvents ofdIcon As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ofdFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnNewShortcut As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents ofdcustom As System.Windows.Forms.OpenFileDialog
    Friend WithEvents radDocument As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnReportParameters As System.Windows.Forms.Button
End Class
