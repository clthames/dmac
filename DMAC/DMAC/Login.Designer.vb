<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.pnlLogoTop = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlLogo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlBrowser = New System.Windows.Forms.Panel()
        Me.Grouper1 = New Grouper.CodeVendor.Controls.Grouper()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUserid = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.lblUnauthor = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.pnlLicensed = New System.Windows.Forms.Panel()
        Me.lblLicensed = New System.Windows.Forms.Label()
        Me.webControl = New System.Windows.Forms.WebBrowser()
        Me.pnlOuter = New System.Windows.Forms.Panel()
        Me.pnlLogoTop.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLogo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grouper1.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.pnlOuter.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLogoTop
        '
        Me.pnlLogoTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlLogoTop.Controls.Add(Me.Label2)
        Me.pnlLogoTop.Controls.Add(Me.Label1)
        Me.pnlLogoTop.Controls.Add(Me.PictureBox2)
        Me.pnlLogoTop.Controls.Add(Me.pnlLogo)
        Me.pnlLogoTop.Controls.Add(Me.pnlBrowser)
        Me.pnlLogoTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLogoTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlLogoTop.Name = "pnlLogoTop"
        Me.pnlLogoTop.Size = New System.Drawing.Size(658, 128)
        Me.pnlLogoTop.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(383, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "powered by Excel Software Services, Inc."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(514, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "www.excelss.com"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, 104)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(639, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'pnlLogo
        '
        Me.pnlLogo.Controls.Add(Me.PictureBox1)
        Me.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLogo.Location = New System.Drawing.Point(0, 0)
        Me.pnlLogo.Name = "pnlLogo"
        Me.pnlLogo.Size = New System.Drawing.Size(340, 128)
        Me.pnlLogo.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-68, 4)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(20, 3, 3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(407, 113)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'pnlBrowser
        '
        Me.pnlBrowser.Location = New System.Drawing.Point(6, 117)
        Me.pnlBrowser.Name = "pnlBrowser"
        Me.pnlBrowser.Size = New System.Drawing.Size(336, 161)
        Me.pnlBrowser.TabIndex = 2
        '
        'Grouper1
        '
        Me.Grouper1.BackgroundColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientMode = Grouper.CodeVendor.Controls.Grouper.GroupBoxGradientMode.None
        Me.Grouper1.BorderColor = System.Drawing.Color.Black
        Me.Grouper1.BorderThickness = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Grouper1.Controls.Add(Me.cmbCompany)
        Me.Grouper1.Controls.Add(Me.btnCancel)
        Me.Grouper1.Controls.Add(Me.btnLogin)
        Me.Grouper1.Controls.Add(Me.txtPassword)
        Me.Grouper1.Controls.Add(Me.txtUsername)
        Me.Grouper1.Controls.Add(Me.lblPassword)
        Me.Grouper1.Controls.Add(Me.lblUserid)
        Me.Grouper1.Controls.Add(Me.lblCompany)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(365, 134)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 12
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 1
        Me.Grouper1.Size = New System.Drawing.Size(268, 138)
        Me.Grouper1.TabIndex = 0
        Me.Grouper1.TabStop = False
        '
        'cmbCompany
        '
        Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(63, 19)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(194, 21)
        Me.cmbCompany.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(207, 109)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(47, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(154, 109)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(47, 23)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(63, 82)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(194, 20)
        Me.txtPassword.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(63, 51)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(194, 20)
        Me.txtUsername.TabIndex = 2
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(8, 82)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'lblUserid
        '
        Me.lblUserid.AutoSize = True
        Me.lblUserid.Location = New System.Drawing.Point(1, 51)
        Me.lblUserid.Name = "lblUserid"
        Me.lblUserid.Size = New System.Drawing.Size(60, 13)
        Me.lblUserid.TabIndex = 1
        Me.lblUserid.Text = "User Name"
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(6, 19)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(51, 13)
        Me.lblCompany.TabIndex = 0
        Me.lblCompany.Text = "Company"
        '
        'pnlLogin
        '
        Me.pnlLogin.Location = New System.Drawing.Point(348, 138)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(294, 137)
        Me.pnlLogin.TabIndex = 4
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.lblUnauthor)
        Me.pnlBottom.Controls.Add(Me.lblWarning)
        Me.pnlBottom.Controls.Add(Me.lblCopyright)
        Me.pnlBottom.Controls.Add(Me.pnlLicensed)
        Me.pnlBottom.Controls.Add(Me.lblLicensed)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 278)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(658, 70)
        Me.pnlBottom.TabIndex = 1
        '
        'lblUnauthor
        '
        Me.lblUnauthor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblUnauthor.AutoSize = True
        Me.lblUnauthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnauthor.Location = New System.Drawing.Point(89, 54)
        Me.lblUnauthor.Name = "lblUnauthor"
        Me.lblUnauthor.Size = New System.Drawing.Size(453, 13)
        Me.lblUnauthor.TabIndex = 2
        Me.lblUnauthor.Text = "Unauthorized reproduction or distribution of this program, or any portion of it, " & _
            "is strictly prohibited"
        '
        'lblWarning
        '
        Me.lblWarning.AutoSize = True
        Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.Location = New System.Drawing.Point(104, 40)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(422, 13)
        Me.lblWarning.TabIndex = 1
        Me.lblWarning.Text = "Warning : This computer program is protected by copyright law and international t" & _
            "reaties."
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Location = New System.Drawing.Point(166, 21)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(291, 15)
        Me.lblCopyright.TabIndex = 0
        Me.lblCopyright.Text = "Copyright © 1998-2013 Excel Software Services, Inc."
        '
        'pnlLicensed
        '
        Me.pnlLicensed.Location = New System.Drawing.Point(4, 34)
        Me.pnlLicensed.Name = "pnlLicensed"
        Me.pnlLicensed.Size = New System.Drawing.Size(629, 24)
        Me.pnlLicensed.TabIndex = 3
        Me.pnlLicensed.Visible = False
        '
        'lblLicensed
        '
        Me.lblLicensed.AutoSize = True
        Me.lblLicensed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicensed.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLicensed.Location = New System.Drawing.Point(187, 45)
        Me.lblLicensed.Name = "lblLicensed"
        Me.lblLicensed.Size = New System.Drawing.Size(227, 13)
        Me.lblLicensed.TabIndex = 0
        Me.lblLicensed.Text = "Licensed to : DMAC Software Services"
        Me.lblLicensed.Visible = False
        '
        'webControl
        '
        Me.webControl.IsWebBrowserContextMenuEnabled = False
        Me.webControl.Location = New System.Drawing.Point(9, 138)
        Me.webControl.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webControl.Name = "webControl"
        Me.webControl.ScrollBarsEnabled = False
        Me.webControl.Size = New System.Drawing.Size(333, 151)
        Me.webControl.TabIndex = 0
        Me.webControl.Url = New System.Uri("", System.UriKind.Relative)
        Me.webControl.WebBrowserShortcutsEnabled = False
        '
        'pnlOuter
        '
        Me.pnlOuter.BackColor = System.Drawing.Color.White
        Me.pnlOuter.Controls.Add(Me.Grouper1)
        Me.pnlOuter.Controls.Add(Me.pnlBottom)
        Me.pnlOuter.Controls.Add(Me.pnlLogin)
        Me.pnlOuter.Controls.Add(Me.pnlLogoTop)
        Me.pnlOuter.Controls.Add(Me.webControl)
        Me.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOuter.Location = New System.Drawing.Point(0, 0)
        Me.pnlOuter.Name = "pnlOuter"
        Me.pnlOuter.Size = New System.Drawing.Size(658, 348)
        Me.pnlOuter.TabIndex = 0
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 348)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlOuter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlLogoTop.ResumeLayout(False)
        Me.pnlLogoTop.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLogo.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.pnlOuter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLogoTop As System.Windows.Forms.Panel
    Friend WithEvents pnlLogo As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents lblUnauthor As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents pnlLicensed As System.Windows.Forms.Panel
    Friend WithEvents lblLicensed As System.Windows.Forms.Label
    Friend WithEvents pnlLogin As System.Windows.Forms.Panel
    Friend WithEvents pnlBrowser As System.Windows.Forms.Panel
    Friend WithEvents webControl As System.Windows.Forms.WebBrowser
    Friend WithEvents Grouper1 As Grouper.CodeVendor.Controls.Grouper
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserid As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents pnlOuter As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
