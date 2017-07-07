<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmailContacts
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
        Me.pnlSearchResult = New System.Windows.Forms.Panel()
        Me.dgvSearchResult = New System.Windows.Forms.DataGridView()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.chkQuickSearch = New System.Windows.Forms.CheckBox()
        Me.lblInclude = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtCustValue = New System.Windows.Forms.TextBox()
        Me.cmbPattern = New System.Windows.Forms.ComboBox()
        Me.cmbCustProp = New System.Windows.Forms.ComboBox()
        Me.lblFindWhere = New System.Windows.Forms.Label()
        Me.pnlAddContact = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbAccount = New System.Windows.Forms.ComboBox()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.btnContactCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblActive = New System.Windows.Forms.Label()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblConactId = New System.Windows.Forms.Label()
        Me.txtContactId = New System.Windows.Forms.TextBox()
        Me.pnlAction = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.clmnCustNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnCustName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnContactId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnAdd1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnAdd2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnAdd3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnZip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlSearchResult.SuspendLayout()
        CType(Me.dgvSearchResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
        Me.pnlAddContact.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlAction.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSearchResult
        '
        Me.pnlSearchResult.Controls.Add(Me.dgvSearchResult)
        Me.pnlSearchResult.Location = New System.Drawing.Point(12, 62)
        Me.pnlSearchResult.Name = "pnlSearchResult"
        Me.pnlSearchResult.Size = New System.Drawing.Size(1109, 411)
        Me.pnlSearchResult.TabIndex = 1
        '
        'dgvSearchResult
        '
        Me.dgvSearchResult.AllowUserToAddRows = False
        Me.dgvSearchResult.AllowUserToDeleteRows = False
        Me.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmnCustNumber, Me.clmnCustName, Me.clmnContactId, Me.clmnName, Me.clmnTitle, Me.clmnPhone, Me.clmnEmail, Me.clmnAdd1, Me.clmnAdd2, Me.clmnAdd3, Me.clmnZip})
        Me.dgvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearchResult.Location = New System.Drawing.Point(0, 0)
        Me.dgvSearchResult.Name = "dgvSearchResult"
        Me.dgvSearchResult.Size = New System.Drawing.Size(1109, 411)
        Me.dgvSearchResult.TabIndex = 0
        '
        'pnlSearch
        '
        Me.pnlSearch.Controls.Add(Me.chkQuickSearch)
        Me.pnlSearch.Controls.Add(Me.lblInclude)
        Me.pnlSearch.Controls.Add(Me.cmbStatus)
        Me.pnlSearch.Controls.Add(Me.txtCustValue)
        Me.pnlSearch.Controls.Add(Me.cmbPattern)
        Me.pnlSearch.Controls.Add(Me.cmbCustProp)
        Me.pnlSearch.Controls.Add(Me.lblFindWhere)
        Me.pnlSearch.Location = New System.Drawing.Point(12, 19)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(1109, 37)
        Me.pnlSearch.TabIndex = 1
        '
        'chkQuickSearch
        '
        Me.chkQuickSearch.AutoSize = True
        Me.chkQuickSearch.Location = New System.Drawing.Point(994, 10)
        Me.chkQuickSearch.Name = "chkQuickSearch"
        Me.chkQuickSearch.Size = New System.Drawing.Size(91, 17)
        Me.chkQuickSearch.TabIndex = 6
        Me.chkQuickSearch.Text = "Quick Search"
        Me.chkQuickSearch.UseVisualStyleBackColor = True
        '
        'lblInclude
        '
        Me.lblInclude.AutoSize = True
        Me.lblInclude.Location = New System.Drawing.Point(751, 12)
        Me.lblInclude.Name = "lblInclude"
        Me.lblInclude.Size = New System.Drawing.Size(42, 13)
        Me.lblInclude.TabIndex = 5
        Me.lblInclude.Text = "Include"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(825, 9)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbStatus.TabIndex = 4
        '
        'txtCustValue
        '
        Me.txtCustValue.Location = New System.Drawing.Point(423, 8)
        Me.txtCustValue.Name = "txtCustValue"
        Me.txtCustValue.Size = New System.Drawing.Size(304, 20)
        Me.txtCustValue.TabIndex = 3
        '
        'cmbPattern
        '
        Me.cmbPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPattern.FormattingEnabled = True
        Me.cmbPattern.Location = New System.Drawing.Point(271, 8)
        Me.cmbPattern.Name = "cmbPattern"
        Me.cmbPattern.Size = New System.Drawing.Size(121, 21)
        Me.cmbPattern.TabIndex = 2
        '
        'cmbCustProp
        '
        Me.cmbCustProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustProp.FormattingEnabled = True
        Me.cmbCustProp.Location = New System.Drawing.Point(104, 9)
        Me.cmbCustProp.Name = "cmbCustProp"
        Me.cmbCustProp.Size = New System.Drawing.Size(121, 21)
        Me.cmbCustProp.TabIndex = 1
        '
        'lblFindWhere
        '
        Me.lblFindWhere.AutoSize = True
        Me.lblFindWhere.Location = New System.Drawing.Point(14, 12)
        Me.lblFindWhere.Name = "lblFindWhere"
        Me.lblFindWhere.Size = New System.Drawing.Size(62, 13)
        Me.lblFindWhere.TabIndex = 0
        Me.lblFindWhere.Text = "Find Where"
        '
        'pnlAddContact
        '
        Me.pnlAddContact.Controls.Add(Me.Panel2)
        Me.pnlAddContact.Controls.Add(Me.Panel1)
        Me.pnlAddContact.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddContact.Location = New System.Drawing.Point(0, 0)
        Me.pnlAddContact.Name = "pnlAddContact"
        Me.pnlAddContact.Size = New System.Drawing.Size(1133, 537)
        Me.pnlAddContact.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblTitle)
        Me.Panel2.Location = New System.Drawing.Point(195, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(665, 37)
        Me.Panel2.TabIndex = 14
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(275, 11)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(140, 17)
        Me.lblTitle.TabIndex = 12
        Me.lblTitle.Text = "Add Email Contact"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbAccount)
        Me.Panel1.Controls.Add(Me.lblAccount)
        Me.Panel1.Controls.Add(Me.btnContactCancel)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.lblActive)
        Me.Panel1.Controls.Add(Me.chkActive)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.lblEmail)
        Me.Panel1.Controls.Add(Me.lblConactId)
        Me.Panel1.Controls.Add(Me.txtContactId)
        Me.Panel1.Location = New System.Drawing.Point(195, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(665, 316)
        Me.Panel1.TabIndex = 13
        '
        'cmbAccount
        '
        Me.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccount.FormattingEnabled = True
        Me.cmbAccount.Location = New System.Drawing.Point(117, 52)
        Me.cmbAccount.Name = "cmbAccount"
        Me.cmbAccount.Size = New System.Drawing.Size(180, 21)
        Me.cmbAccount.TabIndex = 11
        '
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(43, 55)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(47, 13)
        Me.lblAccount.TabIndex = 1
        Me.lblAccount.Text = "Account"
        '
        'btnContactCancel
        '
        Me.btnContactCancel.Location = New System.Drawing.Point(360, 216)
        Me.btnContactCancel.Name = "btnContactCancel"
        Me.btnContactCancel.Size = New System.Drawing.Size(80, 23)
        Me.btnContactCancel.TabIndex = 6
        Me.btnContactCancel.Text = "Cancel"
        Me.btnContactCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(217, 216)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(431, 48)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(180, 20)
        Me.txtName.TabIndex = 1
        '
        'lblActive
        '
        Me.lblActive.AutoSize = True
        Me.lblActive.Location = New System.Drawing.Point(43, 169)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(37, 13)
        Me.lblActive.TabIndex = 10
        Me.lblActive.Text = "Active"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(117, 169)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(15, 14)
        Me.chkActive.TabIndex = 4
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(357, 55)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Name"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(117, 105)
        Me.txtEmail.MaxLength = 99
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(180, 20)
        Me.txtEmail.TabIndex = 2
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(43, 112)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 5
        Me.lblEmail.Text = "Email"
        '
        'lblConactId
        '
        Me.lblConactId.AutoSize = True
        Me.lblConactId.Location = New System.Drawing.Point(357, 119)
        Me.lblConactId.Name = "lblConactId"
        Me.lblConactId.Size = New System.Drawing.Size(58, 13)
        Me.lblConactId.TabIndex = 7
        Me.lblConactId.Text = "Contact ID"
        '
        'txtContactId
        '
        Me.txtContactId.Location = New System.Drawing.Point(431, 112)
        Me.txtContactId.MaxLength = 20
        Me.txtContactId.Name = "txtContactId"
        Me.txtContactId.Size = New System.Drawing.Size(183, 20)
        Me.txtContactId.TabIndex = 3
        '
        'pnlAction
        '
        Me.pnlAction.Controls.Add(Me.btnCancel)
        Me.pnlAction.Controls.Add(Me.btnNew)
        Me.pnlAction.Controls.Add(Me.btnAdd)
        Me.pnlAction.Controls.Add(Me.btnOk)
        Me.pnlAction.Location = New System.Drawing.Point(12, 479)
        Me.pnlAction.Name = "pnlAction"
        Me.pnlAction.Size = New System.Drawing.Size(1109, 46)
        Me.pnlAction.TabIndex = 6
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(343, 17)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(130, 17)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(80, 23)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(26, 17)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(236, 17)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'clmnCustNumber
        '
        Me.clmnCustNumber.DataPropertyName = "CustomerNumber"
        Me.clmnCustNumber.HeaderText = "Customer Number"
        Me.clmnCustNumber.Name = "clmnCustNumber"
        Me.clmnCustNumber.ReadOnly = True
        '
        'clmnCustName
        '
        Me.clmnCustName.DataPropertyName = "CustomerName"
        Me.clmnCustName.HeaderText = "Customer Name"
        Me.clmnCustName.Name = "clmnCustName"
        Me.clmnCustName.ReadOnly = True
        '
        'clmnContactId
        '
        Me.clmnContactId.DataPropertyName = "ContactId"
        Me.clmnContactId.HeaderText = "Contact ID"
        Me.clmnContactId.Name = "clmnContactId"
        Me.clmnContactId.ReadOnly = True
        '
        'clmnName
        '
        Me.clmnName.DataPropertyName = "Name"
        Me.clmnName.HeaderText = "Name"
        Me.clmnName.Name = "clmnName"
        Me.clmnName.ReadOnly = True
        '
        'clmnTitle
        '
        Me.clmnTitle.DataPropertyName = "Title"
        Me.clmnTitle.HeaderText = "Title"
        Me.clmnTitle.Name = "clmnTitle"
        Me.clmnTitle.ReadOnly = True
        Me.clmnTitle.Width = 80
        '
        'clmnPhone
        '
        Me.clmnPhone.DataPropertyName = "ContactPhone"
        Me.clmnPhone.HeaderText = "Contact Phone"
        Me.clmnPhone.Name = "clmnPhone"
        Me.clmnPhone.ReadOnly = True
        '
        'clmnEmail
        '
        Me.clmnEmail.DataPropertyName = "ContactEmail"
        Me.clmnEmail.HeaderText = "Contact Email"
        Me.clmnEmail.Name = "clmnEmail"
        Me.clmnEmail.ReadOnly = True
        '
        'clmnAdd1
        '
        Me.clmnAdd1.DataPropertyName = "LocationAddress1"
        Me.clmnAdd1.HeaderText = "Address 1"
        Me.clmnAdd1.Name = "clmnAdd1"
        Me.clmnAdd1.ReadOnly = True
        '
        'clmnAdd2
        '
        Me.clmnAdd2.DataPropertyName = "LocationAddress2"
        Me.clmnAdd2.HeaderText = "Address 2"
        Me.clmnAdd2.Name = "clmnAdd2"
        Me.clmnAdd2.ReadOnly = True
        '
        'clmnAdd3
        '
        Me.clmnAdd3.DataPropertyName = "LocationAddress3"
        Me.clmnAdd3.HeaderText = "Address 3"
        Me.clmnAdd3.Name = "clmnAdd3"
        Me.clmnAdd3.ReadOnly = True
        '
        'clmnZip
        '
        Me.clmnZip.DataPropertyName = "ZIP"
        Me.clmnZip.HeaderText = "Zip"
        Me.clmnZip.Name = "clmnZip"
        Me.clmnZip.Width = 70
        '
        'frmEmailContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 537)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlAction)
        Me.Controls.Add(Me.pnlAddContact)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.pnlSearchResult)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEmailContacts"
        Me.Text = "Email Contacts"
        Me.pnlSearchResult.ResumeLayout(False)
        CType(Me.dgvSearchResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.pnlAddContact.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAction.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSearchResult As System.Windows.Forms.Panel
    Friend WithEvents pnlAddContact As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnContactCancel As System.Windows.Forms.Button
    Friend WithEvents lblActive As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblConactId As System.Windows.Forms.Label
    Friend WithEvents txtContactId As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents chkQuickSearch As System.Windows.Forms.CheckBox
    Friend WithEvents lblInclude As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustValue As System.Windows.Forms.TextBox
    Friend WithEvents cmbPattern As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCustProp As System.Windows.Forms.ComboBox
    Friend WithEvents lblFindWhere As System.Windows.Forms.Label
    Friend WithEvents dgvSearchResult As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlAction As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents cmbAccount As System.Windows.Forms.ComboBox
    Friend WithEvents clmnCustNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnCustName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnContactId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnTitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnAdd1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnAdd2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnAdd3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnZip As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
