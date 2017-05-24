<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrJobCostDept
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
        Me.tcDepartment = New System.Windows.Forms.TabControl()
        Me.tbpgDepartment = New System.Windows.Forms.TabPage()
        Me.pnlViewDepartment = New System.Windows.Forms.Panel()
        Me.dgvDept = New System.Windows.Forms.DataGridView()
        Me.pnlTopDeptList = New System.Windows.Forms.Panel()
        Me.btnAddDept = New System.Windows.Forms.Button()
        Me.pnlAddEditDept = New System.Windows.Forms.Panel()
        Me.lblDeptNo = New System.Windows.Forms.Label()
        Me.txtDeptNo = New System.Windows.Forms.TextBox()
        Me.lblDeptDesc = New System.Windows.Forms.Label()
        Me.txtDeptDesc = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.clmnDeptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tcDepartment.SuspendLayout()
        Me.tbpgDepartment.SuspendLayout()
        Me.pnlViewDepartment.SuspendLayout()
        CType(Me.dgvDept, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTopDeptList.SuspendLayout()
        Me.pnlAddEditDept.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcDepartment
        '
        Me.tcDepartment.Controls.Add(Me.tbpgDepartment)
        Me.tcDepartment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcDepartment.Location = New System.Drawing.Point(0, 0)
        Me.tcDepartment.Name = "tcDepartment"
        Me.tcDepartment.SelectedIndex = 0
        Me.tcDepartment.Size = New System.Drawing.Size(785, 343)
        Me.tcDepartment.TabIndex = 3
        '
        'tbpgDepartment
        '
        Me.tbpgDepartment.Controls.Add(Me.pnlViewDepartment)
        Me.tbpgDepartment.Controls.Add(Me.pnlAddEditDept)
        Me.tbpgDepartment.Location = New System.Drawing.Point(4, 22)
        Me.tbpgDepartment.Name = "tbpgDepartment"
        Me.tbpgDepartment.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgDepartment.Size = New System.Drawing.Size(777, 317)
        Me.tbpgDepartment.TabIndex = 0
        Me.tbpgDepartment.Text = "Job Costing Department"
        Me.tbpgDepartment.UseVisualStyleBackColor = True
        '
        'pnlViewDepartment
        '
        Me.pnlViewDepartment.Controls.Add(Me.dgvDept)
        Me.pnlViewDepartment.Controls.Add(Me.pnlTopDeptList)
        Me.pnlViewDepartment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewDepartment.Location = New System.Drawing.Point(3, 3)
        Me.pnlViewDepartment.Name = "pnlViewDepartment"
        Me.pnlViewDepartment.Size = New System.Drawing.Size(771, 311)
        Me.pnlViewDepartment.TabIndex = 2
        '
        'dgvDept
        '
        Me.dgvDept.AllowUserToAddRows = False
        Me.dgvDept.AllowUserToDeleteRows = False
        Me.dgvDept.BackgroundColor = System.Drawing.Color.White
        Me.dgvDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDept.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnDeptNo, Me.clmnDescription, Me.clmnEdit, Me.clmnDelete})
        Me.dgvDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDept.Location = New System.Drawing.Point(0, 40)
        Me.dgvDept.Name = "dgvDept"
        Me.dgvDept.Size = New System.Drawing.Size(771, 271)
        Me.dgvDept.TabIndex = 1
        '
        'pnlTopDeptList
        '
        Me.pnlTopDeptList.Controls.Add(Me.btnAddDept)
        Me.pnlTopDeptList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopDeptList.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopDeptList.Name = "pnlTopDeptList"
        Me.pnlTopDeptList.Size = New System.Drawing.Size(771, 40)
        Me.pnlTopDeptList.TabIndex = 0
        '
        'btnAddDept
        '
        Me.btnAddDept.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAddDept.Location = New System.Drawing.Point(667, 9)
        Me.btnAddDept.Name = "btnAddDept"
        Me.btnAddDept.Size = New System.Drawing.Size(95, 23)
        Me.btnAddDept.TabIndex = 0
        Me.btnAddDept.Text = "Add Department"
        Me.btnAddDept.UseVisualStyleBackColor = True
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
        Me.lblDeptNo.Size = New System.Drawing.Size(82, 13)
        Me.lblDeptNo.TabIndex = 1
        Me.lblDeptNo.Text = "Department No:"
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
        Me.lblHeader.Size = New System.Drawing.Size(222, 15)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Jobcost Department Maintenance"
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
        'clmnDeptNo
        '
        Me.clmnDeptNo.DataPropertyName = "Num"
        Me.clmnDeptNo.FillWeight = 99.49238!
        Me.clmnDeptNo.HeaderText = "Dept No"
        Me.clmnDeptNo.Name = "clmnDeptNo"
        Me.clmnDeptNo.ReadOnly = True
        Me.clmnDeptNo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmnDeptNo.Width = 181
        '
        'clmnDescription
        '
        Me.clmnDescription.DataPropertyName = "Description"
        Me.clmnDescription.FillWeight = 99.49238!
        Me.clmnDescription.HeaderText = "Description"
        Me.clmnDescription.Name = "clmnDescription"
        Me.clmnDescription.ReadOnly = True
        Me.clmnDescription.Width = 181
        '
        'clmnEdit
        '
        Me.clmnEdit.FillWeight = 101.5228!
        Me.clmnEdit.HeaderText = ""
        Me.clmnEdit.Name = "clmnEdit"
        Me.clmnEdit.Text = "Edit"
        Me.clmnEdit.ToolTipText = "Edit Department"
        Me.clmnEdit.UseColumnTextForButtonValue = True
        Me.clmnEdit.Width = 80
        '
        'clmnDelete
        '
        Me.clmnDelete.DataPropertyName = "ID"
        Me.clmnDelete.FillWeight = 99.49238!
        Me.clmnDelete.HeaderText = ""
        Me.clmnDelete.Name = "clmnDelete"
        Me.clmnDelete.Text = "Delete"
        Me.clmnDelete.ToolTipText = "Delete Department"
        Me.clmnDelete.UseColumnTextForButtonValue = True
        '
        'usrJobCostDept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcDepartment)
        Me.Name = "usrJobCostDept"
        Me.Size = New System.Drawing.Size(785, 343)
        Me.tcDepartment.ResumeLayout(False)
        Me.tbpgDepartment.ResumeLayout(False)
        Me.pnlViewDepartment.ResumeLayout(False)
        CType(Me.dgvDept, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTopDeptList.ResumeLayout(False)
        Me.pnlAddEditDept.ResumeLayout(False)
        Me.pnlAddEditDept.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcDepartment As System.Windows.Forms.TabControl
    Friend WithEvents tbpgDepartment As System.Windows.Forms.TabPage
    Friend WithEvents pnlViewDepartment As System.Windows.Forms.Panel
    Friend WithEvents dgvDept As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTopDeptList As System.Windows.Forms.Panel
    Friend WithEvents btnAddDept As System.Windows.Forms.Button
    Friend WithEvents pnlAddEditDept As System.Windows.Forms.Panel
    Friend WithEvents lblDeptNo As System.Windows.Forms.Label
    Friend WithEvents txtDeptNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDeptDesc As System.Windows.Forms.Label
    Friend WithEvents txtDeptDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents clmnDeptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents clmnDelete As System.Windows.Forms.DataGridViewButtonColumn

End Class
