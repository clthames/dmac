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
        Me.dgvSalesCodes = New System.Windows.Forms.DataGridView()
        Me.clmnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnTaxCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnQBRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnTaxable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnActive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmnDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblAdd = New System.Windows.Forms.Label()
        Me.pnlAddEditSalesCode = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkTaxable = New System.Windows.Forms.CheckBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.txtQB = New System.Windows.Forms.TextBox()
        Me.lblQBRef = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.txtTaxCode = New System.Windows.Forms.TextBox()
        Me.lblTaxCode = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.tcSalesCodes.SuspendLayout()
        Me.SalesCodes.SuspendLayout()
        Me.pnlViewSalesCode.SuspendLayout()
        CType(Me.dgvSalesCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlAddEditSalesCode.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.pnlViewSalesCode.Controls.Add(Me.Panel2)
        Me.pnlViewSalesCode.Controls.Add(Me.lblAdd)
        Me.pnlViewSalesCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlViewSalesCode.Location = New System.Drawing.Point(3, 3)
        Me.pnlViewSalesCode.Name = "pnlViewSalesCode"
        Me.pnlViewSalesCode.Size = New System.Drawing.Size(676, 399)
        Me.pnlViewSalesCode.TabIndex = 2
        '
        'dgvSalesCodes
        '
        Me.dgvSalesCodes.AllowUserToAddRows = False
        Me.dgvSalesCodes.AllowUserToDeleteRows = False
        Me.dgvSalesCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSalesCodes.BackgroundColor = System.Drawing.Color.White
        Me.dgvSalesCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesCodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnID, Me.clmnTaxCode, Me.clmnDescription, Me.clmnQBRef, Me.clmnTaxable, Me.clmnActive, Me.clmnEdit, Me.clmnDelete})
        Me.dgvSalesCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSalesCodes.Location = New System.Drawing.Point(0, 40)
        Me.dgvSalesCodes.Name = "dgvSalesCodes"
        Me.dgvSalesCodes.Size = New System.Drawing.Size(676, 359)
        Me.dgvSalesCodes.TabIndex = 2
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
        'clmnTaxCode
        '
        Me.clmnTaxCode.DataPropertyName = "TaxCode"
        Me.clmnTaxCode.HeaderText = "Tax Code"
        Me.clmnTaxCode.Name = "clmnTaxCode"
        Me.clmnTaxCode.ReadOnly = True
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
        Me.clmnQBRef.DataPropertyName = "QBReference"
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
        Me.clmnActive.DataPropertyName = "Active"
        Me.clmnActive.HeaderText = "Active"
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
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(676, 40)
        Me.Panel2.TabIndex = 5
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAdd.Location = New System.Drawing.Point(572, 9)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add Sales Code"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblAdd
        '
        Me.lblAdd.AutoSize = True
        Me.lblAdd.Location = New System.Drawing.Point(509, 8)
        Me.lblAdd.Name = "lblAdd"
        Me.lblAdd.Size = New System.Drawing.Size(0, 13)
        Me.lblAdd.TabIndex = 3
        '
        'pnlAddEditSalesCode
        '
        Me.pnlAddEditSalesCode.Controls.Add(Me.Panel1)
        Me.pnlAddEditSalesCode.Controls.Add(Me.lblID)
        Me.pnlAddEditSalesCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddEditSalesCode.Location = New System.Drawing.Point(3, 3)
        Me.pnlAddEditSalesCode.Name = "pnlAddEditSalesCode"
        Me.pnlAddEditSalesCode.Size = New System.Drawing.Size(676, 399)
        Me.pnlAddEditSalesCode.TabIndex = 3
        Me.pnlAddEditSalesCode.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblHeader)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.chkTaxable)
        Me.Panel1.Controls.Add(Me.chkActive)
        Me.Panel1.Controls.Add(Me.txtQB)
        Me.Panel1.Controls.Add(Me.lblQBRef)
        Me.Panel1.Controls.Add(Me.txtDesc)
        Me.Panel1.Controls.Add(Me.lblDesc)
        Me.Panel1.Controls.Add(Me.txtTaxCode)
        Me.Panel1.Controls.Add(Me.lblTaxCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(676, 399)
        Me.Panel1.TabIndex = 23
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(105, 19)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(80, 15)
        Me.lblHeader.TabIndex = 32
        Me.lblHeader.Text = "Sales Codes"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(263, 253)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(374, 253)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkTaxable
        '
        Me.chkTaxable.AutoSize = True
        Me.chkTaxable.Location = New System.Drawing.Point(498, 111)
        Me.chkTaxable.Name = "chkTaxable"
        Me.chkTaxable.Size = New System.Drawing.Size(64, 17)
        Me.chkTaxable.TabIndex = 29
        Me.chkTaxable.Text = "Taxable"
        Me.chkTaxable.UseVisualStyleBackColor = True
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(498, 62)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 28
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'txtQB
        '
        Me.txtQB.Location = New System.Drawing.Point(232, 204)
        Me.txtQB.MaxLength = 50
        Me.txtQB.Name = "txtQB"
        Me.txtQB.Size = New System.Drawing.Size(217, 20)
        Me.txtQB.TabIndex = 27
        '
        'lblQBRef
        '
        Me.lblQBRef.AutoSize = True
        Me.lblQBRef.Location = New System.Drawing.Point(110, 211)
        Me.lblQBRef.Name = "lblQBRef"
        Me.lblQBRef.Size = New System.Drawing.Size(116, 13)
        Me.lblQBRef.TabIndex = 26
        Me.lblQBRef.Text = "Quick Book Reference"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(232, 109)
        Me.txtDesc.MaxLength = 31
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(217, 63)
        Me.txtDesc.TabIndex = 25
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(110, 109)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(60, 13)
        Me.lblDesc.TabIndex = 24
        Me.lblDesc.Text = "Description"
        '
        'txtTaxCode
        '
        Me.txtTaxCode.Location = New System.Drawing.Point(232, 62)
        Me.txtTaxCode.MaxLength = 3
        Me.txtTaxCode.Name = "txtTaxCode"
        Me.txtTaxCode.Size = New System.Drawing.Size(217, 20)
        Me.txtTaxCode.TabIndex = 23
        '
        'lblTaxCode
        '
        Me.lblTaxCode.AutoSize = True
        Me.lblTaxCode.Location = New System.Drawing.Point(110, 66)
        Me.lblTaxCode.Name = "lblTaxCode"
        Me.lblTaxCode.Size = New System.Drawing.Size(53, 13)
        Me.lblTaxCode.TabIndex = 22
        Me.lblTaxCode.Text = "Tax Code"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(600, 370)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(0, 13)
        Me.lblID.TabIndex = 22
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
        Me.pnlViewSalesCode.PerformLayout()
        CType(Me.dgvSalesCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlAddEditSalesCode.ResumeLayout(False)
        Me.pnlAddEditSalesCode.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcSalesCodes As System.Windows.Forms.TabControl
    Friend WithEvents SalesCodes As System.Windows.Forms.TabPage
    Friend WithEvents pnlViewSalesCode As System.Windows.Forms.Panel
    Friend WithEvents pnlAddEditSalesCode As System.Windows.Forms.Panel
    Friend WithEvents dgvSalesCodes As System.Windows.Forms.DataGridView
    Friend WithEvents clmnID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnTaxCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnQBRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnTaxable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEdit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents clmnDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkTaxable As System.Windows.Forms.CheckBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents txtQB As System.Windows.Forms.TextBox
    Friend WithEvents lblQBRef As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents txtTaxCode As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxCode As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblAdd As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
