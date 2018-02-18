<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrUserOptions
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tcUserOptions = New System.Windows.Forms.TabControl()
        Me.tbpgUserOptions = New System.Windows.Forms.TabPage()
        Me.pnlViewUserOptions = New System.Windows.Forms.Panel()
        Me.pnlTopDeptList = New System.Windows.Forms.Panel()
        Me.btnAddOption = New System.Windows.Forms.Button()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.cboUsers = New System.Windows.Forms.ComboBox()
        Me.pnlAddEditDept = New System.Windows.Forms.Panel()
        Me.lblDeptNo = New System.Windows.Forms.Label()
        Me.txtDeptNo = New System.Windows.Forms.TextBox()
        Me.lblDeptDesc = New System.Windows.Forms.Label()
        Me.txtDeptDesc = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.dgvUserOptions = New System.Windows.Forms.DataGridView()
        Me.clmnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tcUserOptions.SuspendLayout()
        Me.tbpgUserOptions.SuspendLayout()
        Me.pnlViewUserOptions.SuspendLayout()
        Me.pnlTopDeptList.SuspendLayout()
        Me.pnlAddEditDept.SuspendLayout()
        CType(Me.dgvUserOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcUserOptions
        '
        Me.tcUserOptions.Controls.Add(Me.tbpgUserOptions)
        Me.tcUserOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcUserOptions.Location = New System.Drawing.Point(0, 0)
        Me.tcUserOptions.Name = "tcUserOptions"
        Me.tcUserOptions.SelectedIndex = 0
        Me.tcUserOptions.Size = New System.Drawing.Size(785, 343)
        Me.tcUserOptions.TabIndex = 3
        '
        'tbpgUserOptions
        '
        Me.tbpgUserOptions.Controls.Add(Me.pnlViewUserOptions)
        Me.tbpgUserOptions.Controls.Add(Me.pnlAddEditDept)
        Me.tbpgUserOptions.Location = New System.Drawing.Point(4, 22)
        Me.tbpgUserOptions.Name = "tbpgUserOptions"
        Me.tbpgUserOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgUserOptions.Size = New System.Drawing.Size(777, 317)
        Me.tbpgUserOptions.TabIndex = 0
        Me.tbpgUserOptions.Text = "User Options"
        Me.tbpgUserOptions.UseVisualStyleBackColor = True
        '
        'pnlViewUserOptions
        '
        Me.pnlViewUserOptions.Controls.Add(Me.dgvUserOptions)
        Me.pnlViewUserOptions.Controls.Add(Me.pnlTopDeptList)
        Me.pnlViewUserOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewUserOptions.Location = New System.Drawing.Point(3, 3)
        Me.pnlViewUserOptions.Name = "pnlViewUserOptions"
        Me.pnlViewUserOptions.Size = New System.Drawing.Size(771, 311)
        Me.pnlViewUserOptions.TabIndex = 2
        '
        'pnlTopDeptList
        '
        Me.pnlTopDeptList.Controls.Add(Me.btnAddOption)
        Me.pnlTopDeptList.Controls.Add(Me.lblUser)
        Me.pnlTopDeptList.Controls.Add(Me.cboUsers)
        Me.pnlTopDeptList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopDeptList.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopDeptList.Name = "pnlTopDeptList"
        Me.pnlTopDeptList.Size = New System.Drawing.Size(771, 40)
        Me.pnlTopDeptList.TabIndex = 0
        '
        'btnAddOption
        '
        Me.btnAddOption.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAddOption.Location = New System.Drawing.Point(476, 11)
        Me.btnAddOption.Name = "btnAddOption"
        Me.btnAddOption.Size = New System.Drawing.Size(117, 23)
        Me.btnAddOption.TabIndex = 2
        Me.btnAddOption.Text = "Add User Option"
        Me.btnAddOption.UseVisualStyleBackColor = True
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(40, 13)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 1
        Me.lblUser.Text = "User"
        '
        'cboUsers
        '
        Me.cboUsers.DisplayMember = "UserName"
        Me.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsers.FormattingEnabled = True
        Me.cboUsers.Location = New System.Drawing.Point(75, 10)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(215, 21)
        Me.cboUsers.TabIndex = 0
        Me.cboUsers.ValueMember = "UserId"
        '
        'pnlAddEditDept
        '
        Me.pnlAddEditDept.Controls.Add(Me.lblDeptNo)
        Me.pnlAddEditDept.Controls.Add(Me.txtDeptNo)
        Me.pnlAddEditDept.Controls.Add(Me.lblDeptDesc)
        Me.pnlAddEditDept.Controls.Add(Me.txtDeptDesc)
        Me.pnlAddEditDept.Controls.Add(Me.btnCancel)
        Me.pnlAddEditDept.Controls.Add(Me.btnSave)
        Me.pnlAddEditDept.Controls.Add(Me.lblHeader)
        Me.pnlAddEditDept.Controls.Add(Me.lblID)
        Me.pnlAddEditDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddEditDept.Location = New System.Drawing.Point(3, 3)
        Me.pnlAddEditDept.Name = "pnlAddEditDept"
        Me.pnlAddEditDept.Size = New System.Drawing.Size(771, 311)
        Me.pnlAddEditDept.TabIndex = 0
        Me.pnlAddEditDept.Visible = False
        '
        'lblDeptNo
        '
        Me.lblDeptNo.AutoSize = True
        Me.lblDeptNo.Location = New System.Drawing.Point(110, 62)
        Me.lblDeptNo.Name = "lblDeptNo"
        Me.lblDeptNo.Size = New System.Drawing.Size(85, 13)
        Me.lblDeptNo.TabIndex = 1
        Me.lblDeptNo.Text = "UserOptions No:"
        '
        'txtDeptNo
        '
        Me.txtDeptNo.Location = New System.Drawing.Point(232, 62)
        Me.txtDeptNo.MaxLength = 5
        Me.txtDeptNo.Name = "txtDeptNo"
        Me.txtDeptNo.Size = New System.Drawing.Size(217, 20)
        Me.txtDeptNo.TabIndex = 2
        '
        'lblDeptDesc
        '
        Me.lblDeptDesc.AutoSize = True
        Me.lblDeptDesc.Location = New System.Drawing.Point(110, 91)
        Me.lblDeptDesc.Name = "lblDeptDesc"
        Me.lblDeptDesc.Size = New System.Drawing.Size(63, 13)
        Me.lblDeptDesc.TabIndex = 3
        Me.lblDeptDesc.Text = "Description:"
        '
        'txtDeptDesc
        '
        Me.txtDeptDesc.Location = New System.Drawing.Point(232, 88)
        Me.txtDeptDesc.MaxLength = 20
        Me.txtDeptDesc.Multiline = True
        Me.txtDeptDesc.Name = "txtDeptDesc"
        Me.txtDeptDesc.Size = New System.Drawing.Size(217, 63)
        Me.txtDeptDesc.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(374, 272)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(293, 272)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(105, 19)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(226, 15)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Jobcost UserOptions Maintenance"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(600, 370)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(0, 13)
        Me.lblID.TabIndex = 1
        Me.lblID.Visible = False
        '
        'dgvUserOptions
        '
        Me.dgvUserOptions.AllowUserToAddRows = False
        Me.dgvUserOptions.AllowUserToDeleteRows = False
        Me.dgvUserOptions.BackgroundColor = System.Drawing.Color.White
        Me.dgvUserOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUserOptions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnID, Me.clmnKey, Me.clmnValue, Me.clmnEdit, Me.clmnDelete})
        Me.dgvUserOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUserOptions.Location = New System.Drawing.Point(0, 40)
        Me.dgvUserOptions.Name = "dgvUserOptions"
        Me.dgvUserOptions.ReadOnly = True
        Me.dgvUserOptions.Size = New System.Drawing.Size(771, 271)
        Me.dgvUserOptions.TabIndex = 2
        '
        'clmnID
        '
        Me.clmnID.DataPropertyName = "ID"
        Me.clmnID.HeaderText = "ID"
        Me.clmnID.Name = "clmnID"
        Me.clmnID.ReadOnly = True
        Me.clmnID.Visible = False
        Me.clmnID.Width = 5
        '
        'clmnKey
        '
        Me.clmnKey.DataPropertyName = "Keyword"
        Me.clmnKey.FillWeight = 99.49238!
        Me.clmnKey.HeaderText = "Keyword"
        Me.clmnKey.Name = "clmnKey"
        Me.clmnKey.ReadOnly = True
        Me.clmnKey.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmnKey.Width = 150
        '
        'clmnValue
        '
        Me.clmnValue.DataPropertyName = "Value"
        Me.clmnValue.FillWeight = 99.49238!
        Me.clmnValue.HeaderText = "Value"
        Me.clmnValue.Name = "clmnValue"
        Me.clmnValue.ReadOnly = True
        Me.clmnValue.Width = 400
        '
        'clmnEdit
        '
        Me.clmnEdit.FillWeight = 101.5228!
        Me.clmnEdit.HeaderText = ""
        Me.clmnEdit.Name = "clmnEdit"
        Me.clmnEdit.ReadOnly = True
        Me.clmnEdit.Text = "Edit"
        Me.clmnEdit.ToolTipText = "Edit User Option"
        Me.clmnEdit.UseColumnTextForButtonValue = True
        Me.clmnEdit.Width = 80
        '
        'clmnDelete
        '
        Me.clmnDelete.DataPropertyName = "ID"
        Me.clmnDelete.FillWeight = 99.49238!
        Me.clmnDelete.HeaderText = ""
        Me.clmnDelete.Name = "clmnDelete"
        Me.clmnDelete.ReadOnly = True
        Me.clmnDelete.Text = "Delete"
        Me.clmnDelete.ToolTipText = "Delete User Option"
        Me.clmnDelete.UseColumnTextForButtonValue = True
        '
        'usrUserOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcUserOptions)
        Me.Name = "usrUserOptions"
        Me.Size = New System.Drawing.Size(785, 343)
        Me.tcUserOptions.ResumeLayout(False)
        Me.tbpgUserOptions.ResumeLayout(False)
        Me.pnlViewUserOptions.ResumeLayout(False)
        Me.pnlTopDeptList.ResumeLayout(False)
        Me.pnlTopDeptList.PerformLayout()
        Me.pnlAddEditDept.ResumeLayout(False)
        Me.pnlAddEditDept.PerformLayout()
        CType(Me.dgvUserOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcUserOptions As System.Windows.Forms.TabControl
    Friend WithEvents tbpgUserOptions As System.Windows.Forms.TabPage
    Friend WithEvents pnlViewUserOptions As System.Windows.Forms.Panel
    Friend WithEvents pnlTopDeptList As System.Windows.Forms.Panel
    Friend WithEvents pnlAddEditDept As System.Windows.Forms.Panel
    Friend WithEvents lblDeptNo As System.Windows.Forms.Label
    Friend WithEvents txtDeptNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDeptDesc As System.Windows.Forms.Label
    Friend WithEvents txtDeptDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents cboUsers As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddOption As System.Windows.Forms.Button
    Friend WithEvents dgvUserOptions As System.Windows.Forms.DataGridView
    Friend WithEvents clmnID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents clmnDelete As System.Windows.Forms.DataGridViewButtonColumn

End Class
