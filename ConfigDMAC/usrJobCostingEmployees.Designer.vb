<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrJobCostingEmployees
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
        Me.tcCostingEmployees = New System.Windows.Forms.TabControl()
        Me.tbpgCostingEmployees = New System.Windows.Forms.TabPage()
        Me.pnlViewCostingEmployees = New System.Windows.Forms.Panel()
        Me.dgvCostingEmployees = New System.Windows.Forms.DataGridView()
        Me.clmnEmpNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClassDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlTopCostingEmployeesList = New System.Windows.Forms.Panel()
        Me.btnAddCostingEmployees = New System.Windows.Forms.Button()
        Me.pnlAddEditCostingEmployees = New System.Windows.Forms.Panel()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblEmpNo = New System.Windows.Forms.Label()
        Me.txtEmpNo = New System.Windows.Forms.TextBox()
        Me.lblDept = New System.Windows.Forms.Label()
        Me.ddlDepartment = New System.Windows.Forms.ComboBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.tcCostingEmployees.SuspendLayout()
        Me.tbpgCostingEmployees.SuspendLayout()
        Me.pnlViewCostingEmployees.SuspendLayout()
        CType(Me.dgvCostingEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTopCostingEmployeesList.SuspendLayout()
        Me.pnlAddEditCostingEmployees.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcCostingEmployees
        '
        Me.tcCostingEmployees.Controls.Add(Me.tbpgCostingEmployees)
        Me.tcCostingEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcCostingEmployees.Location = New System.Drawing.Point(0, 0)
        Me.tcCostingEmployees.Name = "tcCostingEmployees"
        Me.tcCostingEmployees.SelectedIndex = 0
        Me.tcCostingEmployees.Size = New System.Drawing.Size(926, 372)
        Me.tcCostingEmployees.TabIndex = 4
        '
        'tbpgCostingEmployees
        '
        Me.tbpgCostingEmployees.Controls.Add(Me.pnlViewCostingEmployees)
        Me.tbpgCostingEmployees.Controls.Add(Me.pnlAddEditCostingEmployees)
        Me.tbpgCostingEmployees.Location = New System.Drawing.Point(4, 22)
        Me.tbpgCostingEmployees.Name = "tbpgCostingEmployees"
        Me.tbpgCostingEmployees.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgCostingEmployees.Size = New System.Drawing.Size(918, 346)
        Me.tbpgCostingEmployees.TabIndex = 0
        Me.tbpgCostingEmployees.Text = "Jobcost Employee Maintenance"
        Me.tbpgCostingEmployees.UseVisualStyleBackColor = True
        '
        'pnlViewCostingEmployees
        '
        Me.pnlViewCostingEmployees.Controls.Add(Me.dgvCostingEmployees)
        Me.pnlViewCostingEmployees.Controls.Add(Me.pnlTopCostingEmployeesList)
        Me.pnlViewCostingEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewCostingEmployees.Location = New System.Drawing.Point(3, 3)
        Me.pnlViewCostingEmployees.Name = "pnlViewCostingEmployees"
        Me.pnlViewCostingEmployees.Size = New System.Drawing.Size(912, 340)
        Me.pnlViewCostingEmployees.TabIndex = 14
        '
        'dgvCostingEmployees
        '
        Me.dgvCostingEmployees.AllowUserToAddRows = False
        Me.dgvCostingEmployees.AllowUserToDeleteRows = False
        Me.dgvCostingEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCostingEmployees.BackgroundColor = System.Drawing.Color.White
        Me.dgvCostingEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCostingEmployees.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnEmpNo, Me.clmnClass, Me.ClassDescription, Me.clmnDepartment, Me.clmnEdit, Me.clmnDelete})
        Me.dgvCostingEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCostingEmployees.Location = New System.Drawing.Point(0, 34)
        Me.dgvCostingEmployees.Name = "dgvCostingEmployees"
        Me.dgvCostingEmployees.ReadOnly = True
        Me.dgvCostingEmployees.Size = New System.Drawing.Size(912, 306)
        Me.dgvCostingEmployees.TabIndex = 9
        '
        'clmnEmpNo
        '
        Me.clmnEmpNo.DataPropertyName = "EmpNo"
        Me.clmnEmpNo.FillWeight = 99.49238!
        Me.clmnEmpNo.HeaderText = "Employee Number"
        Me.clmnEmpNo.Name = "clmnEmpNo"
        Me.clmnEmpNo.ReadOnly = True
        Me.clmnEmpNo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'clmnClass
        '
        Me.clmnClass.DataPropertyName = "FirstName"
        Me.clmnClass.FillWeight = 99.49238!
        Me.clmnClass.HeaderText = "First Name"
        Me.clmnClass.Name = "clmnClass"
        Me.clmnClass.ReadOnly = True
        '
        'ClassDescription
        '
        Me.ClassDescription.DataPropertyName = "LastName"
        Me.ClassDescription.HeaderText = "Last Name"
        Me.ClassDescription.Name = "ClassDescription"
        Me.ClassDescription.ReadOnly = True
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
        'clmnEdit
        '
        Me.clmnEdit.FillWeight = 101.5228!
        Me.clmnEdit.HeaderText = ""
        Me.clmnEdit.Name = "clmnEdit"
        Me.clmnEdit.ReadOnly = True
        Me.clmnEdit.Text = "Edit"
        Me.clmnEdit.ToolTipText = "Edit Jobcost Employee"
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
        Me.clmnDelete.ToolTipText = "Delete Jobcost Employee"
        Me.clmnDelete.UseColumnTextForButtonValue = True
        '
        'pnlTopCostingEmployeesList
        '
        Me.pnlTopCostingEmployeesList.Controls.Add(Me.btnAddCostingEmployees)
        Me.pnlTopCostingEmployeesList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopCostingEmployeesList.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopCostingEmployeesList.Name = "pnlTopCostingEmployeesList"
        Me.pnlTopCostingEmployeesList.Size = New System.Drawing.Size(912, 34)
        Me.pnlTopCostingEmployeesList.TabIndex = 7
        '
        'btnAddCostingEmployees
        '
        Me.btnAddCostingEmployees.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAddCostingEmployees.Location = New System.Drawing.Point(757, 6)
        Me.btnAddCostingEmployees.Name = "btnAddCostingEmployees"
        Me.btnAddCostingEmployees.Size = New System.Drawing.Size(146, 23)
        Me.btnAddCostingEmployees.TabIndex = 0
        Me.btnAddCostingEmployees.Text = "Add Jobcost Employee"
        Me.btnAddCostingEmployees.UseVisualStyleBackColor = True
        '
        'pnlAddEditCostingEmployees
        '
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.txtLastName)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.lblEmpNo)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.txtEmpNo)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.lblDept)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.ddlDepartment)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.lblFirstName)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.lblLastName)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.txtFirstName)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.btnCancel)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.btnSave)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.lblHeader)
        Me.pnlAddEditCostingEmployees.Controls.Add(Me.lblID)
        Me.pnlAddEditCostingEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddEditCostingEmployees.Location = New System.Drawing.Point(3, 3)
        Me.pnlAddEditCostingEmployees.Name = "pnlAddEditCostingEmployees"
        Me.pnlAddEditCostingEmployees.Size = New System.Drawing.Size(912, 340)
        Me.pnlAddEditCostingEmployees.TabIndex = 1
        Me.pnlAddEditCostingEmployees.Visible = False
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(584, 107)
        Me.txtLastName.MaxLength = 50
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(217, 20)
        Me.txtLastName.TabIndex = 11
        '
        'lblEmpNo
        '
        Me.lblEmpNo.AutoSize = True
        Me.lblEmpNo.Location = New System.Drawing.Point(110, 62)
        Me.lblEmpNo.Name = "lblEmpNo"
        Me.lblEmpNo.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpNo.TabIndex = 0
        Me.lblEmpNo.Text = "Emp No:"
        '
        'txtEmpNo
        '
        Me.txtEmpNo.Location = New System.Drawing.Point(180, 62)
        Me.txtEmpNo.MaxLength = 5
        Me.txtEmpNo.Name = "txtEmpNo"
        Me.txtEmpNo.Size = New System.Drawing.Size(217, 20)
        Me.txtEmpNo.TabIndex = 1
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
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(110, 110)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(60, 13)
        Me.lblFirstName.TabIndex = 3
        Me.lblFirstName.Text = "First Name:"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(501, 110)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(61, 13)
        Me.lblLastName.TabIndex = 4
        Me.lblLastName.Text = "Last Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(180, 110)
        Me.txtFirstName.MaxLength = 50
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(217, 20)
        Me.txtFirstName.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(414, 201)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(322, 201)
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
        Me.lblHeader.Size = New System.Drawing.Size(123, 15)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Jobcost Employee"
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
        'usrJobCostingEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcCostingEmployees)
        Me.Name = "usrJobCostingEmployees"
        Me.Size = New System.Drawing.Size(926, 372)
        Me.tcCostingEmployees.ResumeLayout(False)
        Me.tbpgCostingEmployees.ResumeLayout(False)
        Me.pnlViewCostingEmployees.ResumeLayout(False)
        CType(Me.dgvCostingEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTopCostingEmployeesList.ResumeLayout(False)
        Me.pnlAddEditCostingEmployees.ResumeLayout(False)
        Me.pnlAddEditCostingEmployees.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcCostingEmployees As System.Windows.Forms.TabControl
    Friend WithEvents tbpgCostingEmployees As System.Windows.Forms.TabPage
    Friend WithEvents pnlAddEditCostingEmployees As System.Windows.Forms.Panel
    Friend WithEvents pnlViewCostingEmployees As System.Windows.Forms.Panel
    Friend WithEvents dgvCostingEmployees As System.Windows.Forms.DataGridView
    Friend WithEvents clmnEmpNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnClass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClassDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDepartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents clmnDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents pnlTopCostingEmployeesList As System.Windows.Forms.Panel
    Friend WithEvents btnAddCostingEmployees As System.Windows.Forms.Button
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblEmpNo As System.Windows.Forms.Label
    Friend WithEvents txtEmpNo As System.Windows.Forms.TextBox
    Friend WithEvents lblDept As System.Windows.Forms.Label
    Friend WithEvents ddlDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label

End Class
