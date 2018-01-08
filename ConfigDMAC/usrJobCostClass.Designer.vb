<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrJobCostClass
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
        Me.tcClass = New System.Windows.Forms.TabControl()
        Me.tbpgClass = New System.Windows.Forms.TabPage()
        Me.pnlViewClass = New System.Windows.Forms.Panel()
        Me.dgvClass = New System.Windows.Forms.DataGridView()
        Me.clmnClassNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlTopClassList = New System.Windows.Forms.Panel()
        Me.btnAddClass = New System.Windows.Forms.Button()
        Me.pnlAddEditClass = New System.Windows.Forms.Panel()
        Me.lblClassNo = New System.Windows.Forms.Label()
        Me.txtClassNo = New System.Windows.Forms.TextBox()
        Me.lblClassDesc = New System.Windows.Forms.Label()
        Me.txtClassDesc = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.tcClass.SuspendLayout()
        Me.tbpgClass.SuspendLayout()
        Me.pnlViewClass.SuspendLayout()
        CType(Me.dgvClass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTopClassList.SuspendLayout()
        Me.pnlAddEditClass.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcClass
        '
        Me.tcClass.Controls.Add(Me.tbpgClass)
        Me.tcClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcClass.Location = New System.Drawing.Point(0, 0)
        Me.tcClass.Name = "tcClass"
        Me.tcClass.SelectedIndex = 0
        Me.tcClass.Size = New System.Drawing.Size(785, 343)
        Me.tcClass.TabIndex = 3
        '
        'tbpgClass
        '
        Me.tbpgClass.Controls.Add(Me.pnlAddEditClass)
        Me.tbpgClass.Controls.Add(Me.pnlViewClass)
        Me.tbpgClass.Location = New System.Drawing.Point(4, 22)
        Me.tbpgClass.Name = "tbpgClass"
        Me.tbpgClass.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgClass.Size = New System.Drawing.Size(777, 317)
        Me.tbpgClass.TabIndex = 0
        Me.tbpgClass.Text = "Job Costing Operation Class"
        Me.tbpgClass.UseVisualStyleBackColor = True
        '
        'pnlViewClass
        '
        Me.pnlViewClass.Controls.Add(Me.dgvClass)
        Me.pnlViewClass.Controls.Add(Me.pnlTopClassList)
        Me.pnlViewClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewClass.Location = New System.Drawing.Point(3, 3)
        Me.pnlViewClass.Name = "pnlViewClass"
        Me.pnlViewClass.Size = New System.Drawing.Size(771, 311)
        Me.pnlViewClass.TabIndex = 2
        '
        'dgvClass
        '
        Me.dgvClass.AllowUserToAddRows = False
        Me.dgvClass.AllowUserToDeleteRows = False
        Me.dgvClass.BackgroundColor = System.Drawing.Color.White
        Me.dgvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClass.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnClassNo, Me.clmnDescription, Me.clmnEdit, Me.clmnDelete})
        Me.dgvClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClass.Location = New System.Drawing.Point(0, 40)
        Me.dgvClass.Name = "dgvClass"
        Me.dgvClass.ReadOnly = True
        Me.dgvClass.Size = New System.Drawing.Size(771, 271)
        Me.dgvClass.TabIndex = 1
        '
        'clmnClassNo
        '
        Me.clmnClassNo.DataPropertyName = "ID"
        Me.clmnClassNo.FillWeight = 99.49238!
        Me.clmnClassNo.HeaderText = "Class"
        Me.clmnClassNo.Name = "clmnClassNo"
        Me.clmnClassNo.ReadOnly = True
        Me.clmnClassNo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmnClassNo.Width = 80
        '
        'clmnDescription
        '
        Me.clmnDescription.DataPropertyName = "Description"
        Me.clmnDescription.FillWeight = 99.49238!
        Me.clmnDescription.HeaderText = "Description"
        Me.clmnDescription.Name = "clmnDescription"
        Me.clmnDescription.ReadOnly = True
        Me.clmnDescription.Width = 400
        '
        'clmnEdit
        '
        Me.clmnEdit.FillWeight = 101.5228!
        Me.clmnEdit.HeaderText = ""
        Me.clmnEdit.Name = "clmnEdit"
        Me.clmnEdit.ReadOnly = True
        Me.clmnEdit.Text = "Edit"
        Me.clmnEdit.ToolTipText = "Edit Operation Class"
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
        Me.clmnDelete.ToolTipText = "Delete Operation Class"
        Me.clmnDelete.UseColumnTextForButtonValue = True
        '
        'pnlTopClassList
        '
        Me.pnlTopClassList.Controls.Add(Me.btnAddClass)
        Me.pnlTopClassList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopClassList.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopClassList.Name = "pnlTopClassList"
        Me.pnlTopClassList.Size = New System.Drawing.Size(771, 40)
        Me.pnlTopClassList.TabIndex = 0
        '
        'btnAddClass
        '
        Me.btnAddClass.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAddClass.Location = New System.Drawing.Point(608, 11)
        Me.btnAddClass.Name = "btnAddClass"
        Me.btnAddClass.Size = New System.Drawing.Size(121, 23)
        Me.btnAddClass.TabIndex = 0
        Me.btnAddClass.Text = "Add Operation Class"
        Me.btnAddClass.UseVisualStyleBackColor = True
        '
        'pnlAddEditClass
        '
        Me.pnlAddEditClass.Controls.Add(Me.lblClassNo)
        Me.pnlAddEditClass.Controls.Add(Me.txtClassNo)
        Me.pnlAddEditClass.Controls.Add(Me.lblClassDesc)
        Me.pnlAddEditClass.Controls.Add(Me.txtClassDesc)
        Me.pnlAddEditClass.Controls.Add(Me.btnCancel)
        Me.pnlAddEditClass.Controls.Add(Me.btnSave)
        Me.pnlAddEditClass.Controls.Add(Me.lblHeader)
        Me.pnlAddEditClass.Controls.Add(Me.lblID)
        Me.pnlAddEditClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddEditClass.Location = New System.Drawing.Point(3, 3)
        Me.pnlAddEditClass.Name = "pnlAddEditClass"
        Me.pnlAddEditClass.Size = New System.Drawing.Size(771, 311)
        Me.pnlAddEditClass.TabIndex = 0
        Me.pnlAddEditClass.Visible = False
        '
        'lblClassNo
        '
        Me.lblClassNo.AutoSize = True
        Me.lblClassNo.Location = New System.Drawing.Point(110, 62)
        Me.lblClassNo.Name = "lblClassNo"
        Me.lblClassNo.Size = New System.Drawing.Size(35, 13)
        Me.lblClassNo.TabIndex = 1
        Me.lblClassNo.Text = "Class:"
        '
        'txtClassNo
        '
        Me.txtClassNo.Location = New System.Drawing.Point(232, 62)
        Me.txtClassNo.MaxLength = 1
        Me.txtClassNo.Name = "txtClassNo"
        Me.txtClassNo.Size = New System.Drawing.Size(217, 20)
        Me.txtClassNo.TabIndex = 2
        '
        'lblClassDesc
        '
        Me.lblClassDesc.AutoSize = True
        Me.lblClassDesc.Location = New System.Drawing.Point(110, 91)
        Me.lblClassDesc.Name = "lblClassDesc"
        Me.lblClassDesc.Size = New System.Drawing.Size(63, 13)
        Me.lblClassDesc.TabIndex = 3
        Me.lblClassDesc.Text = "Description:"
        '
        'txtClassDesc
        '
        Me.txtClassDesc.Location = New System.Drawing.Point(232, 88)
        Me.txtClassDesc.MaxLength = 20
        Me.txtClassDesc.Multiline = True
        Me.txtClassDesc.Name = "txtClassDesc"
        Me.txtClassDesc.Size = New System.Drawing.Size(217, 63)
        Me.txtClassDesc.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(376, 166)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(295, 166)
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
        Me.lblHeader.Size = New System.Drawing.Size(177, 15)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Jobcost Operation Classes"
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
        'usrJobCostClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcClass)
        Me.Name = "usrJobCostClass"
        Me.Size = New System.Drawing.Size(785, 343)
        Me.tcClass.ResumeLayout(False)
        Me.tbpgClass.ResumeLayout(False)
        Me.pnlViewClass.ResumeLayout(False)
        CType(Me.dgvClass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTopClassList.ResumeLayout(False)
        Me.pnlAddEditClass.ResumeLayout(False)
        Me.pnlAddEditClass.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcClass As System.Windows.Forms.TabControl
    Friend WithEvents tbpgClass As System.Windows.Forms.TabPage
    Friend WithEvents pnlViewClass As System.Windows.Forms.Panel
    Friend WithEvents dgvClass As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTopClassList As System.Windows.Forms.Panel
    Friend WithEvents btnAddClass As System.Windows.Forms.Button
    Friend WithEvents pnlAddEditClass As System.Windows.Forms.Panel
    Friend WithEvents lblClassNo As System.Windows.Forms.Label
    Friend WithEvents txtClassNo As System.Windows.Forms.TextBox
    Friend WithEvents lblClassDesc As System.Windows.Forms.Label
    Friend WithEvents txtClassDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents clmnClassNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents clmnDelete As System.Windows.Forms.DataGridViewButtonColumn

End Class
