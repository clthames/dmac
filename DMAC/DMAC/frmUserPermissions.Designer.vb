<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserPermissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserPermissions))
        Me.pnlOuter = New System.Windows.Forms.Panel()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.tvMenus = New System.Windows.Forms.TreeView()
        Me.pnlselecteduser = New System.Windows.Forms.Panel()
        Me.lblselectedUser = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pnlUser = New System.Windows.Forms.Panel()
        Me.tvUser = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlOuter.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.pnlselecteduser.SuspendLayout()
        Me.pnlUser.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlOuter
        '
        Me.pnlOuter.Controls.Add(Me.pnlMenu)
        Me.pnlOuter.Controls.Add(Me.pnlselecteduser)
        Me.pnlOuter.Controls.Add(Me.Splitter1)
        Me.pnlOuter.Controls.Add(Me.pnlUser)
        Me.pnlOuter.Controls.Add(Me.Panel1)
        Me.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOuter.Location = New System.Drawing.Point(0, 0)
        Me.pnlOuter.Name = "pnlOuter"
        Me.pnlOuter.Size = New System.Drawing.Size(624, 469)
        Me.pnlOuter.TabIndex = 0
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.tvMenus)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMenu.Location = New System.Drawing.Point(211, 27)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(413, 396)
        Me.pnlMenu.TabIndex = 5
        '
        'tvMenus
        '
        Me.tvMenus.CheckBoxes = True
        Me.tvMenus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvMenus.Location = New System.Drawing.Point(0, 0)
        Me.tvMenus.Name = "tvMenus"
        Me.tvMenus.Size = New System.Drawing.Size(413, 396)
        Me.tvMenus.TabIndex = 2
        '
        'pnlselecteduser
        '
        Me.pnlselecteduser.Controls.Add(Me.lblselectedUser)
        Me.pnlselecteduser.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlselecteduser.Location = New System.Drawing.Point(211, 0)
        Me.pnlselecteduser.Name = "pnlselecteduser"
        Me.pnlselecteduser.Size = New System.Drawing.Size(413, 27)
        Me.pnlselecteduser.TabIndex = 4
        '
        'lblselectedUser
        '
        Me.lblselectedUser.AutoSize = True
        Me.lblselectedUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblselectedUser.Location = New System.Drawing.Point(44, 6)
        Me.lblselectedUser.Name = "lblselectedUser"
        Me.lblselectedUser.Size = New System.Drawing.Size(51, 15)
        Me.lblselectedUser.TabIndex = 0
        Me.lblselectedUser.Text = "Label1"
        Me.lblselectedUser.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(208, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 423)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'pnlUser
        '
        Me.pnlUser.Controls.Add(Me.tvUser)
        Me.pnlUser.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlUser.Location = New System.Drawing.Point(0, 0)
        Me.pnlUser.Name = "pnlUser"
        Me.pnlUser.Size = New System.Drawing.Size(208, 423)
        Me.pnlUser.TabIndex = 0
        '
        'tvUser
        '
        Me.tvUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvUser.Location = New System.Drawing.Point(0, 0)
        Me.tvUser.Name = "tvUser"
        Me.tvUser.Size = New System.Drawing.Size(208, 423)
        Me.tvUser.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 423)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(624, 46)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnReset)
        Me.GroupBox1.Controls.Add(Me.btnApply)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(422, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 46)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(136, 15)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(52, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(76, 15)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(52, 23)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(16, 15)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(52, 23)
        Me.btnApply.TabIndex = 0
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "users16.ico")
        '
        'frmUserPermissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 469)
        Me.Controls.Add(Me.pnlOuter)
        Me.Name = "frmUserPermissions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Permissions"
        Me.pnlOuter.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlselecteduser.ResumeLayout(False)
        Me.pnlselecteduser.PerformLayout()
        Me.pnlUser.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlOuter As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pnlUser As System.Windows.Forms.Panel
    Friend WithEvents tvUser As System.Windows.Forms.TreeView
    Friend WithEvents tvMenus As System.Windows.Forms.TreeView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents lblselectedUser As System.Windows.Forms.Label
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents pnlselecteduser As System.Windows.Forms.Panel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
