<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectGrpCategory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectGrpCategory))
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.trvRptViewGroup = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pbPreview = New System.Windows.Forms.PictureBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAssign = New System.Windows.Forms.Button()
        Me.ofdImage = New System.Windows.Forms.OpenFileDialog()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelect.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.Location = New System.Drawing.Point(549, 408)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(86, 23)
        Me.btnSelect.TabIndex = 8
        Me.btnSelect.Text = "Open Report"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'trvRptViewGroup
        '
        Me.trvRptViewGroup.BackColor = System.Drawing.Color.White
        Me.trvRptViewGroup.ImageIndex = 0
        Me.trvRptViewGroup.ImageList = Me.ImageList1
        Me.trvRptViewGroup.Location = New System.Drawing.Point(12, 12)
        Me.trvRptViewGroup.Name = "trvRptViewGroup"
        Me.trvRptViewGroup.SelectedImageIndex = 1
        Me.trvRptViewGroup.Size = New System.Drawing.Size(371, 302)
        Me.trvRptViewGroup.TabIndex = 7
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder.gif")
        Me.ImageList1.Images.SetKeyName(1, "folderopen.png")
        Me.ImageList1.Images.SetKeyName(2, "article.gif")
        '
        'pbPreview
        '
        Me.pbPreview.BackColor = System.Drawing.Color.White
        Me.pbPreview.Location = New System.Drawing.Point(389, 12)
        Me.pbPreview.Name = "pbPreview"
        Me.pbPreview.Size = New System.Drawing.Size(320, 390)
        Me.pbPreview.TabIndex = 10
        Me.pbPreview.TabStop = False
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(12, 320)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(371, 82)
        Me.txtDescription.TabIndex = 11
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(641, 408)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAssign
        '
        Me.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssign.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssign.Location = New System.Drawing.Point(12, 408)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(130, 23)
        Me.btnAssign.TabIndex = 13
        Me.btnAssign.Text = "Assign Preview Image"
        Me.btnAssign.UseVisualStyleBackColor = True
        '
        'ofdImage
        '
        Me.ofdImage.Filter = "JPEG files|*.jpeg|JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif"
        Me.ofdImage.Title = "Select a preview image file for report:"
        '
        'frmSelectGrpCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 441)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.pbPreview)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.trvRptViewGroup)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmSelectGrpCategory"
        Me.Opacity = 0.95R
        Me.Text = "Select Group, Category and Report"
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents trvRptViewGroup As System.Windows.Forms.TreeView
    Friend WithEvents pbPreview As System.Windows.Forms.PictureBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnAssign As System.Windows.Forms.Button
    Friend WithEvents ofdImage As System.Windows.Forms.OpenFileDialog
End Class
