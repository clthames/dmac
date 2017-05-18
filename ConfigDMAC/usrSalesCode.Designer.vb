<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrSalesCode
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
        Me.tcSalesCodes = New System.Windows.Forms.TabControl()
        Me.SalesCodes = New System.Windows.Forms.TabPage()
        Me.pnlViewSalesCode = New System.Windows.Forms.Panel()
        Me.pnlTopSalesCodeList = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvSalesCodes = New System.Windows.Forms.DataGridView()
        Me.clmnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnQBRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnTaxable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnActive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlAddEditSalesCode = New System.Windows.Forms.Panel()
        Me.lblSalesCode = New System.Windows.Forms.Label()
        Me.txtSalesCode = New System.Windows.Forms.TextBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.lblQBRef = New System.Windows.Forms.Label()
        Me.txtQB = New System.Windows.Forms.TextBox()
        Me.chkDiscount = New System.Windows.Forms.CheckBox()
        Me.chkTaxable = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.tcSalesCodes.SuspendLayout()
        Me.SalesCodes.SuspendLayout()
        Me.pnlViewSalesCode.SuspendLayout()
        Me.pnlTopSalesCodeList.SuspendLayout()
        CType(Me.dgvSalesCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAddEditSalesCode.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcSalesCodes
        '
        Me.tcSalesCodes.Controls.Add(Me.SalesCodes)
        Me.tcSalesCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSalesCodes.Location = New System.Drawing.Point(0, 0)
        Me.tcSalesCodes.Name = "tcSalesCodes"
        Me.tcSalesCodes.SelectedIndex = 0
        Me.tcSalesCodes.Size = New System.Drawing.Size(690, 431)
        Me.tcSalesCodes.TabIndex = 2
        '
        'SalesCodes
        '
        Me.SalesCodes.Controls.Add(Me.pnlViewSalesCode)
        Me.SalesCodes.Controls.Add(Me.pnlAddEditSalesCode)
        Me.SalesCodes.Location = New System.Drawing.Point(4, 22)
        Me.SalesCodes.Name = "SalesCodes"
        Me.SalesCodes.Padding = New System.Windows.Forms.Padding(3)
        Me.SalesCodes.Size = New System.Drawing.Size(682, 405)
        Me.SalesCodes.TabIndex = 0
        Me.SalesCodes.Text = "Sales Codes"
        Me.SalesCodes.UseVisualStyleBackColor = True
        '
        'pnlViewSalesCode
        '
        Me.pnlViewSalesCode.Controls.Add(Me.dgvSalesCodes)
        Me.pnlViewSalesCode.Controls.Add(Me.pnlTopSalesCodeList)
        Me.pnlViewSalesCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewSalesCode.Location = New System.Drawing.Point(3, 3)
        Me.pnlViewSalesCode.Name = "pnlViewSalesCode"
        Me.pnlViewSalesCode.Size = New System.Drawing.Size(676, 399)
        Me.pnlViewSalesCode.TabIndex = 2
        '
        'pnlTopSalesCodeList
        '
        Me.pnlTopSalesCodeList.Controls.Add(Me.btnAdd)
        Me.pnlTopSalesCodeList.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopSalesCodeList.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopSalesCodeList.Name = "pnlTopSalesCodeList"
        Me.pnlTopSalesCodeList.Size = New System.Drawing.Size(676, 40)
        Me.pnlTopSalesCodeList.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAdd.Location = New System.Drawing.Point(572, 9)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add Sales Code"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvSalesCodes
        '
        Me.dgvSalesCodes.AllowUserToAddRows = False
        Me.dgvSalesCodes.AllowUserToDeleteRows = False
        Me.dgvSalesCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSalesCodes.BackgroundColor = System.Drawing.Color.White
        Me.dgvSalesCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesCodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnID, Me.clmnCode, Me.clmnDescription, Me.clmnQBRef, Me.clmnTaxable, Me.clmnActive, Me.clmnEdit, Me.clmnDelete})
        Me.dgvSalesCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSalesCodes.Location = New System.Drawing.Point(0, 40)
        Me.dgvSalesCodes.Name = "dgvSalesCodes"
        Me.dgvSalesCodes.Size = New System.Drawing.Size(676, 359)
        Me.dgvSalesCodes.TabIndex = 1
        '
        'clmnID
        '
        Me.clmnID.DataPropertyName = "ID"
        Me.clmnID.HeaderText = "ID"
        Me.clmnID.Name = "clmnID"
        Me.clmnID.ReadOnly = True
        Me.clmnID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmnID.Visible = False
        '
        'clmnCode
        '
        Me.clmnCode.DataPropertyName = "SCODE"
        Me.clmnCode.HeaderText = "Code"
        Me.clmnCode.Name = "clmnCode"
        Me.clmnCode.ReadOnly = True
        '
        'clmnDescription
        '
        Me.clmnDescription.DataPropertyName = "Description"
        Me.clmnDescription.HeaderText = "Description"
        Me.clmnDescription.Name = "clmnDescription"
        Me.clmnDescription.ReadOnly = True
        '
        'clmnQBRef
        '
        Me.clmnQBRef.DataPropertyName = "QBItem"
        Me.clmnQBRef.HeaderText = "Quick Book Reference"
        Me.clmnQBRef.Name = "clmnQBRef"
        Me.clmnQBRef.ReadOnly = True
        '
        'clmnTaxable
        '
        Me.clmnTaxable.DataPropertyName = "Taxable"
        Me.clmnTaxable.HeaderText = "Taxable"
        Me.clmnTaxable.Name = "clmnTaxable"
        Me.clmnTaxable.ReadOnly = True
        '
        'clmnActive
        '
        Me.clmnActive.DataPropertyName = "Discount"
        Me.clmnActive.HeaderText = "Discount"
        Me.clmnActive.Name = "clmnActive"
        Me.clmnActive.ReadOnly = True
        '
        'clmnEdit
        '
        Me.clmnEdit.DataPropertyName = "ID"
        Me.clmnEdit.HeaderText = ""
        Me.clmnEdit.Name = "clmnEdit"
        Me.clmnEdit.Text = "Edit"
        Me.clmnEdit.ToolTipText = "Edit Sales Code"
        Me.clmnEdit.UseColumnTextForButtonValue = True
        '
        'clmnDelete
        '
        Me.clmnDelete.DataPropertyName = "ID"
        Me.clmnDelete.HeaderText = ""
        Me.clmnDelete.Name = "clmnDelete"
        Me.clmnDelete.Text = "Delete"
        Me.clmnDelete.ToolTipText = "Delete Sales Code"
        Me.clmnDelete.UseColumnTextForButtonValue = True
        '
        'pnlAddEditSalesCode
        '
        Me.pnlAddEditSalesCode.Controls.Add(Me.lblSalesCode)
        Me.pnlAddEditSalesCode.Controls.Add(Me.txtSalesCode)
        Me.pnlAddEditSalesCode.Controls.Add(Me.lblDesc)
        Me.pnlAddEditSalesCode.Controls.Add(Me.txtDesc)
        Me.pnlAddEditSalesCode.Controls.Add(Me.lblQBRef)
        Me.pnlAddEditSalesCode.Controls.Add(Me.txtQB)
        Me.pnlAddEditSalesCode.Controls.Add(Me.chkDiscount)
        Me.pnlAddEditSalesCode.Controls.Add(Me.chkTaxable)
        Me.pnlAddEditSalesCode.Controls.Add(Me.btnCancel)
        Me.pnlAddEditSalesCode.Controls.Add(Me.btnSave)
        Me.pnlAddEditSalesCode.Controls.Add(Me.lblHeader)
        Me.pnlAddEditSalesCode.Controls.Add(Me.lblID)
        Me.pnlAddEditSalesCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddEditSalesCode.Location = New System.Drawing.Point(3, 3)
        Me.pnlAddEditSalesCode.Name = "pnlAddEditSalesCode"
        Me.pnlAddEditSalesCode.Size = New System.Drawing.Size(676, 399)
        Me.pnlAddEditSalesCode.TabIndex = 0
        Me.pnlAddEditSalesCode.Visible = False
        '
        'lblSalesCode
        '
        Me.lblSalesCode.AutoSize = True
        Me.lblSalesCode.Location = New System.Drawing.Point(110, 62)
        Me.lblSalesCode.Name = "lblSalesCode"
        Me.lblSalesCode.Size = New System.Drawing.Size(35, 13)
        Me.lblSalesCode.TabIndex = 1
        Me.lblSalesCode.Text = "Code:"
        '
        'txtSalesCode
        '
        Me.txtSalesCode.Location = New System.Drawing.Point(232, 62)
        Me.txtSalesCode.MaxLength = 5
        Me.txtSalesCode.Name = "txtSalesCode"
        Me.txtSalesCode.Size = New System.Drawing.Size(217, 20)
        Me.txtSalesCode.TabIndex = 2
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(110, 91)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(63, 13)
        Me.lblDesc.TabIndex = 3
        Me.lblDesc.Text = "Description:"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(232, 88)
        Me.txtDesc.MaxLength = 30
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(217, 63)
        Me.txtDesc.TabIndex = 4
        '
        'lblQBRef
        '
        Me.lblQBRef.AutoSize = True
        Me.lblQBRef.Location = New System.Drawing.Point(110, 160)
        Me.lblQBRef.Name = "lblQBRef"
        Me.lblQBRef.Size = New System.Drawing.Size(119, 13)
        Me.lblQBRef.TabIndex = 5
        Me.lblQBRef.Text = "Quick Book Reference:"
        '
        'txtQB
        '
        Me.txtQB.Location = New System.Drawing.Point(232, 157)
        Me.txtQB.MaxLength = 255
        Me.txtQB.Multiline = True
        Me.txtQB.Name = "txtQB"
        Me.txtQB.Size = New System.Drawing.Size(217, 76)
        Me.txtQB.TabIndex = 6
        '
        'chkDiscount
        '
        Me.chkDiscount.AutoSize = True
        Me.chkDiscount.Location = New System.Drawing.Point(232, 239)
        Me.chkDiscount.Name = "chkDiscount"
        Me.chkDiscount.Size = New System.Drawing.Size(68, 17)
        Me.chkDiscount.TabIndex = 7
        Me.chkDiscount.Text = "Discount"
        Me.chkDiscount.UseVisualStyleBackColor = True
        '
        'chkTaxable
        '
        Me.chkTaxable.AutoSize = True
        Me.chkTaxable.Location = New System.Drawing.Point(304, 239)
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.Size = New System.Drawing.Size(64, 17)
        Me.chkTaxable.TabIndex = 8
        Me.chkTaxable.Text = "Taxable"
        Me.chkTaxable.UseVisualStyleBackColor = True
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
        Me.lblHeader.Size = New System.Drawing.Size(87, 15)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Sales Codes"
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
        'usrSalesCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tcSalesCodes)
        Me.Name = "usrSalesCode"
        Me.Size = New System.Drawing.Size(690, 431)
        Me.tcSalesCodes.ResumeLayout(False)
        Me.SalesCodes.ResumeLayout(False)
        Me.pnlViewSalesCode.ResumeLayout(False)
        Me.pnlTopSalesCodeList.ResumeLayout(False)
        CType(Me.dgvSalesCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAddEditSalesCode.ResumeLayout(False)
        Me.pnlAddEditSalesCode.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcSalesCodes As System.Windows.Forms.TabControl
    Friend WithEvents SalesCodes As System.Windows.Forms.TabPage
    Friend WithEvents pnlViewSalesCode As System.Windows.Forms.Panel
    Friend WithEvents pnlAddEditSalesCode As System.Windows.Forms.Panel
    Friend WithEvents dgvSalesCodes As System.Windows.Forms.DataGridView
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents chkDiscount As System.Windows.Forms.CheckBox
    Friend WithEvents txtQB As System.Windows.Forms.TextBox
    Friend WithEvents lblQBRef As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtSalesCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSalesCode As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlTopSalesCodeList As System.Windows.Forms.Panel
    Friend WithEvents clmnID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnQBRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnTaxable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents clmnDelete As System.Windows.Forms.DataGridViewButtonColumn

End Class
