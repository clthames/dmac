<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrJobCostingCodes
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
        Me.tcCostingCodes = New System.Windows.Forms.TabControl()
        Me.tbpgCostingCodes = New System.Windows.Forms.TabPage()
        Me.pnlViewCostingCodes = New System.Windows.Forms.Panel()
        Me.dgvCostingCodes = New System.Windows.Forms.DataGridView()
        Me.pnlTopCostingCodesList = New System.Windows.Forms.Panel()
        Me.btnAddCostingCodes = New System.Windows.Forms.Button()
        Me.pnlAddEditCostingCodes = New System.Windows.Forms.Panel()
        Me.lblCodeNo = New System.Windows.Forms.Label()
        Me.txtCodeNo = New System.Windows.Forms.TextBox()
        Me.lblDept = New System.Windows.Forms.Label()
        Me.ddlDepartment = New System.Windows.Forms.ComboBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.lblKey = New System.Windows.Forms.Label()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.ddlCls = New System.Windows.Forms.ComboBox()
        Me.clmnCodeNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tcCostingCodes.SuspendLayout()
        Me.tbpgCostingCodes.SuspendLayout()
        Me.pnlViewCostingCodes.SuspendLayout()
        CType(Me.dgvCostingCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTopCostingCodesList.SuspendLayout()
        Me.pnlAddEditCostingCodes.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcCostingCodes
        '
        Me.tcCostingCodes.Controls.Add(Me.tbpgCostingCodes)
        Me.tcCostingCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcCostingCodes.Location = New System.Drawing.Point(0, 0)
        Me.tcCostingCodes.Name = "tcCostingCodes"
        Me.tcCostingCodes.SelectedIndex = 0
        Me.tcCostingCodes.Size = New System.Drawing.Size(926, 372)
        Me.tcCostingCodes.TabIndex = 4
        '
        'tbpgCostingCodes
        '
        Me.tbpgCostingCodes.Controls.Add(Me.pnlViewCostingCodes)
        Me.tbpgCostingCodes.Controls.Add(Me.pnlAddEditCostingCodes)
        Me.tbpgCostingCodes.Location = New System.Drawing.Point(4, 22)
        Me.tbpgCostingCodes.Name = "tbpgCostingCodes"
        Me.tbpgCostingCodes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgCostingCodes.Size = New System.Drawing.Size(918, 346)
        Me.tbpgCostingCodes.TabIndex = 0
        Me.tbpgCostingCodes.Text = "Jobcost Code Maintenance"
        Me.tbpgCostingCodes.UseVisualStyleBackColor = True
        '
        'pnlViewCostingCodes
        '
        Me.pnlViewCostingCodes.Controls.Add(Me.dgvCostingCodes)
        Me.pnlViewCostingCodes.Controls.Add(Me.pnlTopCostingCodesList)
        Me.pnlViewCostingCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewCostingCodes.Location = New System.Drawing.Point(3, 3)
        Me.pnlViewCostingCodes.Name = "pnlViewCostingCodes"
        Me.pnlViewCostingCodes.Size = New System.Drawing.Size(912, 340)
        Me.pnlViewCostingCodes.TabIndex = 2
        '
        'dgvCostingCodes
        '
        Me.dgvCostingCodes.AllowUserToAddRows = False
        Me.dgvCostingCodes.AllowUserToDeleteRows = False
        Me.dgvCostingCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCostingCodes.BackgroundColor = System.Drawing.Color.White
        Me.dgvCostingCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCostingCodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnCodeNo, Me.clmnDepartment, Me.clmnClass, Me.clmnDescription, Me.clmnKey, Me.clmnEdit, Me.clmnDelete})
        Me.dgvCostingCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCostingCodes.Location = New System.Drawing.Point(0, 34)
        Me.dgvCostingCodes.Name = "dgvCostingCodes"
        Me.dgvCostingCodes.ReadOnly = True
        Me.dgvCostingCodes.Size = New System.Drawing.Size(912, 306)
        Me.dgvCostingCodes.TabIndex = 1
        '
        'pnlTopCostingCodesList
        '
        Me.pnlTopCostingCodesList.Controls.Add(Me.btnAddCostingCodes)
        Me.pnlTopCostingCodesList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopCostingCodesList.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopCostingCodesList.Name = "pnlTopCostingCodesList"
        Me.pnlTopCostingCodesList.Size = New System.Drawing.Size(912, 34)
        Me.pnlTopCostingCodesList.TabIndex = 0
        '
        'btnAddCostingCodes
        '
        Me.btnAddCostingCodes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAddCostingCodes.Location = New System.Drawing.Point(757, 6)
        Me.btnAddCostingCodes.Name = "btnAddCostingCodes"
        Me.btnAddCostingCodes.Size = New System.Drawing.Size(146, 23)
        Me.btnAddCostingCodes.TabIndex = 0
        Me.btnAddCostingCodes.Text = "Add Jobcost Code"
        Me.btnAddCostingCodes.UseVisualStyleBackColor = True
        '
        'pnlAddEditCostingCodes
        '
        Me.pnlAddEditCostingCodes.Controls.Add(Me.lblCodeNo)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.txtCodeNo)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.lblDept)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.ddlDepartment)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.lblDescription)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.txtDescription)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.lblClass)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.lblKey)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.txtKey)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.btnCancel)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.btnSave)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.lblHeader)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.lblID)
        Me.pnlAddEditCostingCodes.Controls.Add(Me.ddlCls)
        Me.pnlAddEditCostingCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddEditCostingCodes.Location = New System.Drawing.Point(3, 3)
        Me.pnlAddEditCostingCodes.Name = "pnlAddEditCostingCodes"
        Me.pnlAddEditCostingCodes.Size = New System.Drawing.Size(912, 340)
        Me.pnlAddEditCostingCodes.TabIndex = 0
        Me.pnlAddEditCostingCodes.Visible = False
        '
        'lblCodeNo
        '
        Me.lblCodeNo.AutoSize = True
        Me.lblCodeNo.Location = New System.Drawing.Point(110, 62)
        Me.lblCodeNo.Name = "lblCodeNo"
        Me.lblCodeNo.Size = New System.Drawing.Size(52, 13)
        Me.lblCodeNo.TabIndex = 0
        Me.lblCodeNo.Text = "Code No:"
        '
        'txtCodeNo
        '
        Me.txtCodeNo.Location = New System.Drawing.Point(180, 62)
        Me.txtCodeNo.MaxLength = 5
        Me.txtCodeNo.Name = "txtCodeNo"
        Me.txtCodeNo.Size = New System.Drawing.Size(217, 20)
        Me.txtCodeNo.TabIndex = 1
        '
        'lblDept
        '
        Me.lblDept.AutoSize = True
        Me.lblDept.Location = New System.Drawing.Point(501, 62)
        Me.lblDept.Name = "lblDept"
        Me.lblDept.Size = New System.Drawing.Size(65, 13)
        Me.lblDept.TabIndex = 2
        Me.lblDept.Text = "Department:"
        '
        'ddlDepartment
        '
        Me.ddlDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlDepartment.Location = New System.Drawing.Point(584, 61)
        Me.ddlDepartment.Name = "ddlDepartment"
        Me.ddlDepartment.Size = New System.Drawing.Size(217, 21)
        Me.ddlDepartment.TabIndex = 2
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(110, 110)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(63, 13)
        Me.lblDescription.TabIndex = 3
        Me.lblDescription.Text = "Description:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(180, 107)
        Me.txtDescription.MaxLength = 50
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(217, 63)
        Me.txtDescription.TabIndex = 3
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Location = New System.Drawing.Point(501, 110)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(35, 13)
        Me.lblClass.TabIndex = 4
        Me.lblClass.Text = "Class:"
        '
        'lblKey
        '
        Me.lblKey.AutoSize = True
        Me.lblKey.Location = New System.Drawing.Point(110, 199)
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Size = New System.Drawing.Size(28, 13)
        Me.lblKey.TabIndex = 5
        Me.lblKey.Text = "Key:"
        '
        'txtKey
        '
        Me.txtKey.Location = New System.Drawing.Point(180, 196)
        Me.txtKey.MaxLength = 10
        Me.txtKey.Name = "txtKey"
        Me.txtKey.Size = New System.Drawing.Size(217, 20)
        Me.txtKey.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(398, 299)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(317, 299)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(105, 19)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(167, 15)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Jobcost Operation Codes"
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
        'ddlCls
        '
        Me.ddlCls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlCls.Location = New System.Drawing.Point(584, 110)
        Me.ddlCls.Name = "ddlCls"
        Me.ddlCls.Size = New System.Drawing.Size(88, 21)
        Me.ddlCls.TabIndex = 11
        '
        'clmnCodeNo
        '
        Me.clmnCodeNo.DataPropertyName = "CodeNo"
        Me.clmnCodeNo.FillWeight = 99.49238!
        Me.clmnCodeNo.HeaderText = "Code Number"
        Me.clmnCodeNo.Name = "clmnCodeNo"
        Me.clmnCodeNo.ReadOnly = True
        Me.clmnCodeNo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'clmnDepartment
        '
        Me.clmnDepartment.DataPropertyName = "Department"
        Me.clmnDepartment.FillWeight = 99.49238!
        Me.clmnDepartment.HeaderText = "Department"
        Me.clmnDepartment.Name = "clmnDepartment"
        Me.clmnDepartment.ReadOnly = True
        Me.clmnDepartment.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'clmnClass
        '
        Me.clmnClass.DataPropertyName = "Class"
        Me.clmnClass.FillWeight = 99.49238!
        Me.clmnClass.HeaderText = "Class"
        Me.clmnClass.Name = "clmnClass"
        Me.clmnClass.ReadOnly = True
        Me.clmnClass.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'clmnDescription
        '
        Me.clmnDescription.DataPropertyName = "Description"
        Me.clmnDescription.FillWeight = 99.49238!
        Me.clmnDescription.HeaderText = "Description"
        Me.clmnDescription.Name = "clmnDescription"
        Me.clmnDescription.ReadOnly = True
        '
        'clmnKey
        '
        Me.clmnKey.DataPropertyName = "Key"
        Me.clmnKey.FillWeight = 99.49238!
        Me.clmnKey.HeaderText = "Key"
        Me.clmnKey.Name = "clmnKey"
        Me.clmnKey.ReadOnly = True
        Me.clmnKey.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'clmnEdit
        '
        Me.clmnEdit.FillWeight = 101.5228!
        Me.clmnEdit.HeaderText = ""
        Me.clmnEdit.Name = "clmnEdit"
        Me.clmnEdit.ReadOnly = True
        Me.clmnEdit.Text = "Edit"
        Me.clmnEdit.ToolTipText = "Edit Jobcost Code"
        Me.clmnEdit.UseColumnTextForButtonValue = True
        '
        'clmnDelete
        '
        Me.clmnDelete.DataPropertyName = "ID"
        Me.clmnDelete.FillWeight = 99.49238!
        Me.clmnDelete.HeaderText = ""
        Me.clmnDelete.Name = "clmnDelete"
        Me.clmnDelete.ReadOnly = True
        Me.clmnDelete.Text = "Delete"
        Me.clmnDelete.ToolTipText = "Delete Jobcost Codes"
        Me.clmnDelete.UseColumnTextForButtonValue = True
        '
        'usrJobCostingCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcCostingCodes)
        Me.Name = "usrJobCostingCodes"
        Me.Size = New System.Drawing.Size(926, 372)
        Me.tcCostingCodes.ResumeLayout(False)
        Me.tbpgCostingCodes.ResumeLayout(False)
        Me.pnlViewCostingCodes.ResumeLayout(False)
        CType(Me.dgvCostingCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTopCostingCodesList.ResumeLayout(False)
        Me.pnlAddEditCostingCodes.ResumeLayout(False)
        Me.pnlAddEditCostingCodes.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcCostingCodes As System.Windows.Forms.TabControl
    Friend WithEvents tbpgCostingCodes As System.Windows.Forms.TabPage
    Friend WithEvents pnlViewCostingCodes As System.Windows.Forms.Panel
    Friend WithEvents pnlTopCostingCodesList As System.Windows.Forms.Panel
    Friend WithEvents btnAddCostingCodes As System.Windows.Forms.Button
    Friend WithEvents pnlAddEditCostingCodes As System.Windows.Forms.Panel
    Friend WithEvents lblCodeNo As System.Windows.Forms.Label
    Friend WithEvents txtCodeNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDept As System.Windows.Forms.Label
    Friend WithEvents ddlDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblClass As System.Windows.Forms.Label
    Friend WithEvents lblKey As System.Windows.Forms.Label
    Friend WithEvents txtKey As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents ddlCls As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCostingCodes As System.Windows.Forms.DataGridView
    Friend WithEvents clmnCodeNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDepartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents clmnDelete As System.Windows.Forms.DataGridViewButtonColumn

End Class
