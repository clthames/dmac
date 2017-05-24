<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrJobCostingCenters
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tcCosting = New System.Windows.Forms.TabControl()
        Me.tbpgCosting = New System.Windows.Forms.TabPage()
        Me.pnlViewCosting = New System.Windows.Forms.Panel()
        Me.dgvCosting = New System.Windows.Forms.DataGridView()
        Me.clmnCtrNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnBurden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnCounter = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmnCylSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnRatio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlTopCostingList = New System.Windows.Forms.Panel()
        Me.btnAddCostingCenter = New System.Windows.Forms.Button()
        Me.pnlAddEditCosting = New System.Windows.Forms.Panel()
        Me.lblCenterNo = New System.Windows.Forms.Label()
        Me.txtCenterNo = New System.Windows.Forms.TextBox()
        Me.lblDept = New System.Windows.Forms.Label()
        Me.ddlDepartment = New System.Windows.Forms.ComboBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblRate = New System.Windows.Forms.Label()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.lblBurden = New System.Windows.Forms.Label()
        Me.txtBurden = New System.Windows.Forms.TextBox()
        Me.lblCounter = New System.Windows.Forms.Label()
        Me.chkCounter = New System.Windows.Forms.CheckBox()
        Me.lblCycleSize = New System.Windows.Forms.Label()
        Me.txtCycleSize = New System.Windows.Forms.TextBox()
        Me.lblRatio = New System.Windows.Forms.Label()
        Me.txtRatio = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.tcCosting.SuspendLayout()
        Me.tbpgCosting.SuspendLayout()
        Me.pnlViewCosting.SuspendLayout()
        CType(Me.dgvCosting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTopCostingList.SuspendLayout()
        Me.pnlAddEditCosting.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcCosting
        '
        Me.tcCosting.Controls.Add(Me.tbpgCosting)
        Me.tcCosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcCosting.Location = New System.Drawing.Point(0, 0)
        Me.tcCosting.Name = "tcCosting"
        Me.tcCosting.SelectedIndex = 0
        Me.tcCosting.Size = New System.Drawing.Size(926, 372)
        Me.tcCosting.TabIndex = 4
        '
        'tbpgCosting
        '
        Me.tbpgCosting.Controls.Add(Me.pnlViewCosting)
        Me.tbpgCosting.Controls.Add(Me.pnlAddEditCosting)
        Me.tbpgCosting.Location = New System.Drawing.Point(4, 22)
        Me.tbpgCosting.Name = "tbpgCosting"
        Me.tbpgCosting.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgCosting.Size = New System.Drawing.Size(918, 346)
        Me.tbpgCosting.TabIndex = 0
        Me.tbpgCosting.Text = "Jobcost Center Maintenance"
        Me.tbpgCosting.UseVisualStyleBackColor = True
        '
        'pnlViewCosting
        '
        Me.pnlViewCosting.Controls.Add(Me.dgvCosting)
        Me.pnlViewCosting.Controls.Add(Me.pnlTopCostingList)
        Me.pnlViewCosting.Location = New System.Drawing.Point(3, 6)
        Me.pnlViewCosting.Name = "pnlViewCosting"
        Me.pnlViewCosting.Size = New System.Drawing.Size(912, 337)
        Me.pnlViewCosting.TabIndex = 2
        Me.pnlViewCosting.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'dgvCosting
        '
        Me.dgvCosting.AllowUserToAddRows = False
        Me.dgvCosting.AllowUserToDeleteRows = False
        Me.dgvCosting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCosting.BackgroundColor = System.Drawing.Color.White
        Me.dgvCosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCosting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnCtrNo, Me.clmnDepartment, Me.clmnDescription, Me.clmnRate, Me.clmnBurden, Me.clmnCounter, Me.clmnCylSize, Me.clmnRatio, Me.clmnEdit, Me.clmnDelete})
        Me.dgvCosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCosting.Location = New System.Drawing.Point(0, 39)
        Me.dgvCosting.Name = "dgvCosting"
        Me.dgvCosting.Size = New System.Drawing.Size(912, 298)
        Me.dgvCosting.TabIndex = 1
        '
        'clmnCtrNo
        '
        Me.clmnCtrNo.DataPropertyName = "Num"
        Me.clmnCtrNo.FillWeight = 99.49238!
        Me.clmnCtrNo.HeaderText = "Center Number"
        Me.clmnCtrNo.Name = "clmnCtrNo"
        Me.clmnCtrNo.ReadOnly = True
        Me.clmnCtrNo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'clmnDepartment
        '
        Me.clmnDepartment.DataPropertyName = "Dept"
        Me.clmnDepartment.FillWeight = 99.49238!
        Me.clmnDepartment.HeaderText = "Department"
        Me.clmnDepartment.Name = "clmnDepartment"
        Me.clmnDepartment.ReadOnly = True
        Me.clmnDepartment.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'clmnDescription
        '
        Me.clmnDescription.DataPropertyName = "Desc"
        Me.clmnDescription.FillWeight = 99.49238!
        Me.clmnDescription.HeaderText = "Description"
        Me.clmnDescription.Name = "clmnDescription"
        Me.clmnDescription.ReadOnly = True
        '
        'clmnRate
        '
        Me.clmnRate.DataPropertyName = "Rate"
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.clmnRate.DefaultCellStyle = DataGridViewCellStyle4
        Me.clmnRate.FillWeight = 99.49238!
        Me.clmnRate.HeaderText = "Rate"
        Me.clmnRate.Name = "clmnRate"
        Me.clmnRate.ReadOnly = True
        '
        'clmnBurden
        '
        Me.clmnBurden.DataPropertyName = "Burden"
        Me.clmnBurden.FillWeight = 99.49238!
        Me.clmnBurden.HeaderText = "Burden"
        Me.clmnBurden.Name = "clmnBurden"
        Me.clmnBurden.ReadOnly = True
        '
        'clmnCounter
        '
        Me.clmnCounter.DataPropertyName = "Counter"
        Me.clmnCounter.FillWeight = 99.49238!
        Me.clmnCounter.HeaderText = "Counter"
        Me.clmnCounter.Name = "clmnCounter"
        Me.clmnCounter.ReadOnly = True
        '
        'clmnCylSize
        '
        Me.clmnCylSize.DataPropertyName = "Cyl_Size"
        Me.clmnCylSize.FillWeight = 99.49238!
        Me.clmnCylSize.HeaderText = "Cycle Size"
        Me.clmnCylSize.Name = "clmnCylSize"
        Me.clmnCylSize.ReadOnly = True
        '
        'clmnRatio
        '
        Me.clmnRatio.DataPropertyName = "Ratio"
        Me.clmnRatio.FillWeight = 99.49238!
        Me.clmnRatio.HeaderText = "Ratio"
        Me.clmnRatio.Name = "clmnRatio"
        Me.clmnRatio.ReadOnly = True
        '
        'clmnEdit
        '
        Me.clmnEdit.FillWeight = 101.5228!
        Me.clmnEdit.HeaderText = ""
        Me.clmnEdit.Name = "clmnEdit"
        Me.clmnEdit.Text = "Edit"
        Me.clmnEdit.ToolTipText = "Edit Jobcost Center"
        Me.clmnEdit.UseColumnTextForButtonValue = True
        '
        'clmnDelete
        '
        Me.clmnDelete.DataPropertyName = "ID"
        Me.clmnDelete.FillWeight = 99.49238!
        Me.clmnDelete.HeaderText = ""
        Me.clmnDelete.Name = "clmnDelete"
        Me.clmnDelete.Text = "Delete"
        Me.clmnDelete.ToolTipText = "Delete Jobcost Center"
        Me.clmnDelete.UseColumnTextForButtonValue = True
        '
        'pnlTopCostingList
        '
        Me.pnlTopCostingList.Controls.Add(Me.btnAddCostingCenter)
        Me.pnlTopCostingList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopCostingList.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopCostingList.Name = "pnlTopCostingList"
        Me.pnlTopCostingList.Size = New System.Drawing.Size(912, 39)
        Me.pnlTopCostingList.TabIndex = 0
        '
        'btnAddCostingCenter
        '
        Me.btnAddCostingCenter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAddCostingCenter.Location = New System.Drawing.Point(757, 8)
        Me.btnAddCostingCenter.Name = "btnAddCostingCenter"
        Me.btnAddCostingCenter.Size = New System.Drawing.Size(146, 23)
        Me.btnAddCostingCenter.TabIndex = 0
        Me.btnAddCostingCenter.Text = "Add Jobcost Center"
        Me.btnAddCostingCenter.UseVisualStyleBackColor = True
        '
        'pnlAddEditCosting
        '
        Me.pnlAddEditCosting.Controls.Add(Me.lblCenterNo)
        Me.pnlAddEditCosting.Controls.Add(Me.txtCenterNo)
        Me.pnlAddEditCosting.Controls.Add(Me.lblDept)
        Me.pnlAddEditCosting.Controls.Add(Me.ddlDepartment)
        Me.pnlAddEditCosting.Controls.Add(Me.lblDescription)
        Me.pnlAddEditCosting.Controls.Add(Me.txtDescription)
        Me.pnlAddEditCosting.Controls.Add(Me.lblRate)
        Me.pnlAddEditCosting.Controls.Add(Me.txtRate)
        Me.pnlAddEditCosting.Controls.Add(Me.lblBurden)
        Me.pnlAddEditCosting.Controls.Add(Me.txtBurden)
        Me.pnlAddEditCosting.Controls.Add(Me.lblCounter)
        Me.pnlAddEditCosting.Controls.Add(Me.chkCounter)
        Me.pnlAddEditCosting.Controls.Add(Me.lblCycleSize)
        Me.pnlAddEditCosting.Controls.Add(Me.txtCycleSize)
        Me.pnlAddEditCosting.Controls.Add(Me.lblRatio)
        Me.pnlAddEditCosting.Controls.Add(Me.txtRatio)
        Me.pnlAddEditCosting.Controls.Add(Me.btnCancel)
        Me.pnlAddEditCosting.Controls.Add(Me.btnSave)
        Me.pnlAddEditCosting.Controls.Add(Me.lblHeader)
        Me.pnlAddEditCosting.Controls.Add(Me.lblID)
        Me.pnlAddEditCosting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddEditCosting.Location = New System.Drawing.Point(3, 3)
        Me.pnlAddEditCosting.Name = "pnlAddEditCosting"
        Me.pnlAddEditCosting.Size = New System.Drawing.Size(912, 340)
        Me.pnlAddEditCosting.TabIndex = 0
        Me.pnlAddEditCosting.Visible = False
        '
        'lblCenterNo
        '
        Me.lblCenterNo.AutoSize = True
        Me.lblCenterNo.Location = New System.Drawing.Point(110, 62)
        Me.lblCenterNo.Name = "lblCenterNo"
        Me.lblCenterNo.Size = New System.Drawing.Size(58, 13)
        Me.lblCenterNo.TabIndex = 0
        Me.lblCenterNo.Text = "Center No:"
        '
        'txtCenterNo
        '
        Me.txtCenterNo.Location = New System.Drawing.Point(180, 62)
        Me.txtCenterNo.MaxLength = 5
        Me.txtCenterNo.Name = "txtCenterNo"
        Me.txtCenterNo.Size = New System.Drawing.Size(217, 20)
        Me.txtCenterNo.TabIndex = 1
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
        Me.txtDescription.MaxLength = 20
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(217, 63)
        Me.txtDescription.TabIndex = 3
        '
        'lblRate
        '
        Me.lblRate.AutoSize = True
        Me.lblRate.Location = New System.Drawing.Point(501, 110)
        Me.lblRate.Name = "lblRate"
        Me.lblRate.Size = New System.Drawing.Size(33, 13)
        Me.lblRate.TabIndex = 4
        Me.lblRate.Text = "Rate:"
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(584, 110)
        Me.txtRate.MaxLength = 5
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(217, 20)
        Me.txtRate.TabIndex = 4
        '
        'lblBurden
        '
        Me.lblBurden.AutoSize = True
        Me.lblBurden.Location = New System.Drawing.Point(110, 199)
        Me.lblBurden.Name = "lblBurden"
        Me.lblBurden.Size = New System.Drawing.Size(44, 13)
        Me.lblBurden.TabIndex = 5
        Me.lblBurden.Text = "Burden:"
        '
        'txtBurden
        '
        Me.txtBurden.Location = New System.Drawing.Point(180, 196)
        Me.txtBurden.MaxLength = 6
        Me.txtBurden.Name = "txtBurden"
        Me.txtBurden.Size = New System.Drawing.Size(217, 20)
        Me.txtBurden.TabIndex = 5
        '
        'lblCounter
        '
        Me.lblCounter.AutoSize = True
        Me.lblCounter.Location = New System.Drawing.Point(501, 155)
        Me.lblCounter.Name = "lblCounter"
        Me.lblCounter.Size = New System.Drawing.Size(47, 13)
        Me.lblCounter.TabIndex = 6
        Me.lblCounter.Text = "Counter:"
        '
        'chkCounter
        '
        Me.chkCounter.Location = New System.Drawing.Point(584, 155)
        Me.chkCounter.Name = "chkCounter"
        Me.chkCounter.Size = New System.Drawing.Size(16, 13)
        Me.chkCounter.TabIndex = 6
        '
        'lblCycleSize
        '
        Me.lblCycleSize.AutoSize = True
        Me.lblCycleSize.Location = New System.Drawing.Point(501, 206)
        Me.lblCycleSize.Name = "lblCycleSize"
        Me.lblCycleSize.Size = New System.Drawing.Size(59, 13)
        Me.lblCycleSize.TabIndex = 7
        Me.lblCycleSize.Text = "Cycle Size:"
        '
        'txtCycleSize
        '
        Me.txtCycleSize.Location = New System.Drawing.Point(584, 203)
        Me.txtCycleSize.MaxLength = 6
        Me.txtCycleSize.Name = "txtCycleSize"
        Me.txtCycleSize.Size = New System.Drawing.Size(217, 20)
        Me.txtCycleSize.TabIndex = 7
        '
        'lblRatio
        '
        Me.lblRatio.AutoSize = True
        Me.lblRatio.Location = New System.Drawing.Point(110, 246)
        Me.lblRatio.Name = "lblRatio"
        Me.lblRatio.Size = New System.Drawing.Size(35, 13)
        Me.lblRatio.TabIndex = 8
        Me.lblRatio.Text = "Ratio:"
        '
        'txtRatio
        '
        Me.txtRatio.Location = New System.Drawing.Point(180, 239)
        Me.txtRatio.MaxLength = 6
        Me.txtRatio.Name = "txtRatio"
        Me.txtRatio.Size = New System.Drawing.Size(217, 20)
        Me.txtRatio.TabIndex = 8
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
        Me.lblHeader.Size = New System.Drawing.Size(189, 15)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Jobcost Center Maintenance"
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
        'usrJobCostingCenters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcCosting)
        Me.Name = "usrJobCostingCenters"
        Me.Size = New System.Drawing.Size(926, 372)
        Me.tcCosting.ResumeLayout(False)
        Me.tbpgCosting.ResumeLayout(False)
        Me.pnlViewCosting.ResumeLayout(False)
        CType(Me.dgvCosting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTopCostingList.ResumeLayout(False)
        Me.pnlAddEditCosting.ResumeLayout(False)
        Me.pnlAddEditCosting.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcCosting As System.Windows.Forms.TabControl
    Friend WithEvents tbpgCosting As System.Windows.Forms.TabPage
    Friend WithEvents pnlViewCosting As System.Windows.Forms.Panel
    Friend WithEvents dgvCosting As System.Windows.Forms.DataGridView
    Friend WithEvents clmnCtrNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDepartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnBurden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnCounter As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmnCylSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnRatio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents clmnDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents pnlTopCostingList As System.Windows.Forms.Panel
    Friend WithEvents btnAddCostingCenter As System.Windows.Forms.Button
    Friend WithEvents pnlAddEditCosting As System.Windows.Forms.Panel
    Friend WithEvents lblCenterNo As System.Windows.Forms.Label
    Friend WithEvents txtCenterNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDept As System.Windows.Forms.Label
    Friend WithEvents ddlDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblRate As System.Windows.Forms.Label
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents lblBurden As System.Windows.Forms.Label
    Friend WithEvents txtBurden As System.Windows.Forms.TextBox
    Friend WithEvents lblCounter As System.Windows.Forms.Label
    Friend WithEvents chkCounter As System.Windows.Forms.CheckBox
    Friend WithEvents lblCycleSize As System.Windows.Forms.Label
    Friend WithEvents txtCycleSize As System.Windows.Forms.TextBox
    Friend WithEvents lblRatio As System.Windows.Forms.Label
    Friend WithEvents txtRatio As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label

End Class
