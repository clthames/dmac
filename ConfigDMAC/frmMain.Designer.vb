<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Company")
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Roles")
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Users")
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Access", New System.Windows.Forms.TreeNode() {TreeNode45, TreeNode46})
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Options")
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sales Codes")
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Invoice Options")
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Customers", New System.Windows.Forms.TreeNode() {TreeNode48, TreeNode49, TreeNode50})
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cost Operations")
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Operation Codes")
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Operation Classes")
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Job Costing", New System.Windows.Forms.TreeNode() {TreeNode52, TreeNode53, TreeNode54})
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Options")
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Press Trim Requirements")
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Paper Scheduling", New System.Windows.Forms.TreeNode() {TreeNode56, TreeNode57})
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Press")
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Collator")
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Composition")
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Encoder")
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Offline Folder Standards")
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shrinkwrap Standards")
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bindery Costs")
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estimating Labor Standards", New System.Windows.Forms.TreeNode() {TreeNode59, TreeNode60, TreeNode61, TreeNode62, TreeNode63, TreeNode64, TreeNode65})
        Dim TreeNode67 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Paper Material")
        Dim TreeNode68 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Base and Standards Inks")
        Dim TreeNode69 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Carbon File")
        Dim TreeNode70 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Pack Sizes")
        Dim TreeNode71 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Overhead-Ink-Carton-Helper")
        Dim TreeNode72 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estimating Material Standards", New System.Windows.Forms.TreeNode() {TreeNode67, TreeNode68, TreeNode69, TreeNode70, TreeNode71})
        Dim TreeNode73 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Product Markup Factors")
        Dim TreeNode74 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Freight Rates (MIN)")
        Dim TreeNode75 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Freight Rates (CWT COST)")
        Dim TreeNode76 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estimating Other Standards", New System.Windows.Forms.TreeNode() {TreeNode73, TreeNode74, TreeNode75})
        Dim TreeNode77 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("User Defined Keywords")
        Dim TreeNode78 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Odd Width Cross Reference")
        Dim TreeNode79 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Press and Collator Designation")
        Dim TreeNode80 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Paper Color Cross Reference")
        Dim TreeNode81 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Keypad Configuration")
        Dim TreeNode82 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estimating Configuration", New System.Windows.Forms.TreeNode() {TreeNode77, TreeNode78, TreeNode79, TreeNode80, TreeNode81})
        Dim TreeNode83 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Main Categories")
        Dim TreeNode84 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Report Definitions")
        Dim TreeNode85 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports")
        Dim TreeNode86 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Report Manager", New System.Windows.Forms.TreeNode() {TreeNode83, TreeNode84, TreeNode85})
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsNew = New System.Windows.Forms.ToolStripButton()
        Me.tsEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsSettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsExit = New System.Windows.Forms.ToolStripButton()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.tbcntrlReports = New System.Windows.Forms.TabControl()
        Me.tpgReports = New System.Windows.Forms.TabPage()
        Me.cmbOperator = New System.Windows.Forms.ComboBox()
        Me.cmbDataType = New System.Windows.Forms.ComboBox()
        Me.dgvParameters = New System.Windows.Forms.DataGridView()
        Me.colParameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrompt = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSequence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOperator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDefaultValue1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDefaultValue2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRequired = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.trvwReports = New System.Windows.Forms.TreeView()
        Me.trvOptions = New System.Windows.Forms.TreeView()
        Me.tbcReportDefinition = New System.Windows.Forms.TabControl()
        Me.tbpg_ReportDefinition = New System.Windows.Forms.TabPage()
        Me.trvwReportDefinition = New System.Windows.Forms.TreeView()
        Me.pbPreview = New System.Windows.Forms.PictureBox()
        Me.btnAssign = New System.Windows.Forms.Button()
        Me.pnlReportDefinitions = New System.Windows.Forms.Panel()
        Me.txt_RemoteFileName = New System.Windows.Forms.TextBox()
        Me.lblRemoteFileName = New System.Windows.Forms.Label()
        Me.chkrptdefinitiondeleted = New System.Windows.Forms.CheckBox()
        Me.txt_Notes = New System.Windows.Forms.RichTextBox()
        Me.chkrptdefinitaionActive = New System.Windows.Forms.CheckBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.cboReportGroup = New System.Windows.Forms.ComboBox()
        Me.lblReportGroup = New System.Windows.Forms.Label()
        Me.cboRportCategory = New System.Windows.Forms.ComboBox()
        Me.lbl_ReportCategory = New System.Windows.Forms.Label()
        Me.txt_ReportDescription = New System.Windows.Forms.TextBox()
        Me.lbl_ReportDescription = New System.Windows.Forms.Label()
        Me.txt_ReportID = New System.Windows.Forms.TextBox()
        Me.lblReportID = New System.Windows.Forms.Label()
        Me.tcReports = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.trvwReportCategories = New System.Windows.Forms.TreeView()
        Me.pnlRepCategories = New System.Windows.Forms.Panel()
        Me.chkRepCatID = New System.Windows.Forms.CheckBox()
        Me.chkRepCatIA = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboRepGroupCat = New System.Windows.Forms.ComboBox()
        Me.txtRepCategoryName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tcCompany = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnlCompanyInfo = New System.Windows.Forms.Panel()
        Me.txtCoFax = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCoWebS = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCoPhone = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCoAddress = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCoName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbcntrl_ProfileAccess = New System.Windows.Forms.TabControl()
        Me.tbpg_Roles = New System.Windows.Forms.TabPage()
        Me.pnlProfiles = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chklbPermissions = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtPrDesc = New System.Windows.Forms.TextBox()
        Me.txtPrName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboProfiles = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tcProfiles = New System.Windows.Forms.TabControl()
        Me.Information = New System.Windows.Forms.TabPage()
        Me.pnlPermissions = New System.Windows.Forms.Panel()
        Me.btnAddPr = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbAvailableProfiles = New System.Windows.Forms.ListBox()
        Me.btnRemovePr = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbOwnedProfiles = New System.Windows.Forms.ListBox()
        Me.pnlInfoUsers = New System.Windows.Forms.Panel()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLogon = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboUsers = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.opdImageDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.tbcntrlReports.SuspendLayout()
        Me.tpgReports.SuspendLayout()
        CType(Me.dgvParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcReportDefinition.SuspendLayout()
        Me.tbpg_ReportDefinition.SuspendLayout()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReportDefinitions.SuspendLayout()
        Me.tcReports.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnlRepCategories.SuspendLayout()
        Me.tcCompany.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlCompanyInfo.SuspendLayout()
        Me.tbcntrl_ProfileAccess.SuspendLayout()
        Me.tbpg_Roles.SuspendLayout()
        Me.pnlProfiles.SuspendLayout()
        Me.tcProfiles.SuspendLayout()
        Me.Information.SuspendLayout()
        Me.pnlPermissions.SuspendLayout()
        Me.pnlInfoUsers.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNew, Me.tsEdit, Me.tsSave, Me.tsCancel, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.tsSettings, Me.ToolStripSeparator2, Me.tsExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1182, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsNew
        '
        Me.tsNew.Image = CType(resources.GetObject("tsNew.Image"), System.Drawing.Image)
        Me.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNew.Name = "tsNew"
        Me.tsNew.Size = New System.Drawing.Size(51, 22)
        Me.tsNew.Text = "New"
        '
        'tsEdit
        '
        Me.tsEdit.Image = CType(resources.GetObject("tsEdit.Image"), System.Drawing.Image)
        Me.tsEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEdit.Name = "tsEdit"
        Me.tsEdit.Size = New System.Drawing.Size(47, 22)
        Me.tsEdit.Text = "Edit"
        '
        'tsSave
        '
        Me.tsSave.Image = CType(resources.GetObject("tsSave.Image"), System.Drawing.Image)
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(51, 22)
        Me.tsSave.Text = "Save"
        '
        'tsCancel
        '
        Me.tsCancel.Image = CType(resources.GetObject("tsCancel.Image"), System.Drawing.Image)
        Me.tsCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCancel.Name = "tsCancel"
        Me.tsCancel.Size = New System.Drawing.Size(63, 22)
        Me.tsCancel.Text = "Cancel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'tsSettings
        '
        Me.tsSettings.Image = CType(resources.GetObject("tsSettings.Image"), System.Drawing.Image)
        Me.tsSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSettings.Name = "tsSettings"
        Me.tsSettings.Size = New System.Drawing.Size(69, 22)
        Me.tsSettings.Text = "Settings"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsExit
        '
        Me.tsExit.Image = CType(resources.GetObject("tsExit.Image"), System.Drawing.Image)
        Me.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsExit.Name = "tsExit"
        Me.tsExit.Size = New System.Drawing.Size(45, 22)
        Me.tsExit.Text = "Exit"
        '
        'scMain
        '
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.Location = New System.Drawing.Point(0, 25)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.trvOptions)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.Controls.Add(Me.tbcntrlReports)
        Me.scMain.Panel2.Controls.Add(Me.tbcReportDefinition)
        Me.scMain.Panel2.Controls.Add(Me.tcReports)
        Me.scMain.Panel2.Controls.Add(Me.tcCompany)
        Me.scMain.Panel2.Controls.Add(Me.tbcntrl_ProfileAccess)
        Me.scMain.Panel2.Controls.Add(Me.tcProfiles)
        Me.scMain.Size = New System.Drawing.Size(1182, 696)
        Me.scMain.SplitterDistance = 215
        Me.scMain.TabIndex = 1
        '
        'tbcntrlReports
        '
        Me.tbcntrlReports.Controls.Add(Me.tpgReports)
        Me.tbcntrlReports.Location = New System.Drawing.Point(7, 0)
        Me.tbcntrlReports.Name = "tbcntrlReports"
        Me.tbcntrlReports.SelectedIndex = 0
        Me.tbcntrlReports.Size = New System.Drawing.Size(948, 697)
        Me.tbcntrlReports.TabIndex = 16
        '
        'tpgReports
        '
        Me.tpgReports.Controls.Add(Me.cmbOperator)
        Me.tpgReports.Controls.Add(Me.cmbDataType)
        Me.tpgReports.Controls.Add(Me.dgvParameters)
        Me.tpgReports.Controls.Add(Me.trvwReports)
        Me.tpgReports.Location = New System.Drawing.Point(4, 22)
        Me.tpgReports.Name = "tpgReports"
        Me.tpgReports.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgReports.Size = New System.Drawing.Size(940, 671)
        Me.tpgReports.TabIndex = 0
        Me.tpgReports.Text = "Reports"
        Me.tpgReports.UseVisualStyleBackColor = True
        '
        'cmbOperator
        '
        Me.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperator.FormattingEnabled = True
        Me.cmbOperator.Items.AddRange(New Object() {"All", "=", ">", "<", ">=", "<=", "Like", "Not Like", "In", "Not In", "Between"})
        Me.cmbOperator.Location = New System.Drawing.Point(809, 83)
        Me.cmbOperator.Name = "cmbOperator"
        Me.cmbOperator.Size = New System.Drawing.Size(114, 21)
        Me.cmbOperator.TabIndex = 13
        Me.cmbOperator.Visible = False
        '
        'cmbDataType
        '
        Me.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataType.FormattingEnabled = True
        Me.cmbDataType.Items.AddRange(New Object() {"Text", "Date", "Boolean", "Integer", "Float"})
        Me.cmbDataType.Location = New System.Drawing.Point(809, 56)
        Me.cmbDataType.Name = "cmbDataType"
        Me.cmbDataType.Size = New System.Drawing.Size(114, 21)
        Me.cmbDataType.TabIndex = 12
        Me.cmbDataType.Visible = False
        '
        'dgvParameters
        '
        Me.dgvParameters.AllowUserToAddRows = False
        Me.dgvParameters.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParameters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colParameter, Me.colPrompt, Me.colSequence, Me.colDataType, Me.colOperator, Me.clmnDefaultValue1, Me.clmnDefaultValue2, Me.colRequired})
        Me.dgvParameters.Location = New System.Drawing.Point(242, 8)
        Me.dgvParameters.Name = "dgvParameters"
        Me.dgvParameters.RowHeadersWidth = 25
        Me.dgvParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvParameters.Size = New System.Drawing.Size(695, 650)
        Me.dgvParameters.StandardTab = True
        Me.dgvParameters.TabIndex = 11
        '
        'colParameter
        '
        Me.colParameter.HeaderText = "Parameter"
        Me.colParameter.Name = "colParameter"
        Me.colParameter.ReadOnly = True
        Me.colParameter.Width = 90
        '
        'colPrompt
        '
        Me.colPrompt.HeaderText = "Prompt"
        Me.colPrompt.Name = "colPrompt"
        Me.colPrompt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPrompt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPrompt.ThreeState = True
        Me.colPrompt.Width = 50
        '
        'colSequence
        '
        Me.colSequence.HeaderText = "Sequence"
        Me.colSequence.Name = "colSequence"
        Me.colSequence.Width = 65
        '
        'colDataType
        '
        Me.colDataType.HeaderText = "Type"
        Me.colDataType.Name = "colDataType"
        Me.colDataType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colOperator
        '
        Me.colOperator.HeaderText = "Operator"
        Me.colOperator.Name = "colOperator"
        '
        'clmnDefaultValue1
        '
        Me.clmnDefaultValue1.HeaderText = "Default Value1"
        Me.clmnDefaultValue1.Name = "clmnDefaultValue1"
        '
        'clmnDefaultValue2
        '
        Me.clmnDefaultValue2.HeaderText = "Default Value2"
        Me.clmnDefaultValue2.Name = "clmnDefaultValue2"
        '
        'colRequired
        '
        Me.colRequired.HeaderText = "Required"
        Me.colRequired.Name = "colRequired"
        Me.colRequired.Width = 65
        '
        'trvwReports
        '
        Me.trvwReports.Location = New System.Drawing.Point(12, 9)
        Me.trvwReports.Name = "trvwReports"
        Me.trvwReports.Size = New System.Drawing.Size(224, 649)
        Me.trvwReports.TabIndex = 0
        '
        'trvOptions
        '
        Me.trvOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvOptions.Location = New System.Drawing.Point(0, 0)
        Me.trvOptions.Name = "trvOptions"
        TreeNode44.Name = "nCompany"
        TreeNode44.Text = "Company"
        TreeNode45.Name = "NRoles"
        TreeNode45.Text = "Roles"
        TreeNode46.Name = "nUsers"
        TreeNode46.Text = "Users"
        TreeNode47.Name = "NAcess"
        TreeNode47.Text = "Access"
        TreeNode48.Name = "Node19"
        TreeNode48.Text = "Options"
        TreeNode49.Name = "Node20"
        TreeNode49.Text = "Sales Codes"
        TreeNode50.Name = "nOptions"
        TreeNode50.Text = "Invoice Options"
        TreeNode51.Name = "Node2"
        TreeNode51.Text = "Customers"
        TreeNode52.Name = "nCostOperations"
        TreeNode52.Text = "Cost Operations"
        TreeNode53.Name = "nOperationCodes"
        TreeNode53.Text = "Operation Codes"
        TreeNode54.Name = "nOperationClasses"
        TreeNode54.Text = "Operation Classes"
        TreeNode55.Name = "Node3"
        TreeNode55.Text = "Job Costing"
        TreeNode56.Name = "nOptions"
        TreeNode56.Text = "Options"
        TreeNode57.Name = "nPressTrimRequirements"
        TreeNode57.Text = "Press Trim Requirements"
        TreeNode58.Name = "Node4"
        TreeNode58.Text = "Paper Scheduling"
        TreeNode59.Name = "Node26"
        TreeNode59.Text = "Press"
        TreeNode60.Name = "Node27"
        TreeNode60.Text = "Collator"
        TreeNode61.Name = "Node28"
        TreeNode61.Text = "Composition"
        TreeNode62.Name = "Node29"
        TreeNode62.Text = "Encoder"
        TreeNode63.Name = "Node30"
        TreeNode63.Text = "Offline Folder Standards"
        TreeNode64.Name = "Node31"
        TreeNode64.Text = "Shrinkwrap Standards"
        TreeNode65.Name = "Node32"
        TreeNode65.Text = "Bindery Costs"
        TreeNode66.Name = "Node5"
        TreeNode66.Text = "Estimating Labor Standards"
        TreeNode67.Name = "Node33"
        TreeNode67.Text = "Paper Material"
        TreeNode68.Name = "Node34"
        TreeNode68.Text = "Base and Standards Inks"
        TreeNode69.Name = "Node35"
        TreeNode69.Text = "Update Carbon File"
        TreeNode70.Name = "Node36"
        TreeNode70.Text = "Update Pack Sizes"
        TreeNode71.Name = "Node37"
        TreeNode71.Text = "Overhead-Ink-Carton-Helper"
        TreeNode72.Name = "Node6"
        TreeNode72.Text = "Estimating Material Standards"
        TreeNode73.Name = "Node38"
        TreeNode73.Text = "Product Markup Factors"
        TreeNode74.Name = "Node39"
        TreeNode74.Text = "Freight Rates (MIN)"
        TreeNode75.Name = "Node40"
        TreeNode75.Text = "Freight Rates (CWT COST)"
        TreeNode76.Name = "Node7"
        TreeNode76.Text = "Estimating Other Standards"
        TreeNode77.Name = "Node41"
        TreeNode77.Text = "User Defined Keywords"
        TreeNode78.Name = "Node42"
        TreeNode78.Text = "Odd Width Cross Reference"
        TreeNode79.Name = "Node43"
        TreeNode79.Text = "Press and Collator Designation"
        TreeNode80.Name = "Node44"
        TreeNode80.Text = "Paper Color Cross Reference"
        TreeNode81.Name = "Node45"
        TreeNode81.Text = "Keypad Configuration"
        TreeNode82.Name = "Node8"
        TreeNode82.Text = "Estimating Configuration"
        TreeNode83.Name = "nReportCategories"
        TreeNode83.Text = "Main Categories"
        TreeNode84.Name = "nReportDefinitions"
        TreeNode84.Text = "Report Definitions"
        TreeNode85.Name = "nReports"
        TreeNode85.Text = "Reports"
        TreeNode86.Name = "nReports"
        TreeNode86.Text = "Report Manager"
        Me.trvOptions.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode44, TreeNode47, TreeNode51, TreeNode55, TreeNode58, TreeNode66, TreeNode72, TreeNode76, TreeNode82, TreeNode86})
        Me.trvOptions.Size = New System.Drawing.Size(215, 696)
        Me.trvOptions.TabIndex = 0
        '
        'tbcReportDefinition
        '
        Me.tbcReportDefinition.Controls.Add(Me.tbpg_ReportDefinition)
        Me.tbcReportDefinition.Location = New System.Drawing.Point(8, 0)
        Me.tbcReportDefinition.Name = "tbcReportDefinition"
        Me.tbcReportDefinition.SelectedIndex = 0
        Me.tbcReportDefinition.Size = New System.Drawing.Size(947, 694)
        Me.tbcReportDefinition.TabIndex = 3
        '
        'tbpg_ReportDefinition
        '
        Me.tbpg_ReportDefinition.Controls.Add(Me.trvwReportDefinition)
        Me.tbpg_ReportDefinition.Controls.Add(Me.pbPreview)
        Me.tbpg_ReportDefinition.Controls.Add(Me.btnAssign)
        Me.tbpg_ReportDefinition.Controls.Add(Me.pnlReportDefinitions)
        Me.tbpg_ReportDefinition.Location = New System.Drawing.Point(4, 22)
        Me.tbpg_ReportDefinition.Name = "tbpg_ReportDefinition"
        Me.tbpg_ReportDefinition.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpg_ReportDefinition.Size = New System.Drawing.Size(939, 668)
        Me.tbpg_ReportDefinition.TabIndex = 0
        Me.tbpg_ReportDefinition.Text = "Report Definition"
        Me.tbpg_ReportDefinition.UseVisualStyleBackColor = True
        '
        'trvwReportDefinition
        '
        Me.trvwReportDefinition.Location = New System.Drawing.Point(8, 9)
        Me.trvwReportDefinition.Name = "trvwReportDefinition"
        Me.trvwReportDefinition.Size = New System.Drawing.Size(408, 650)
        Me.trvwReportDefinition.TabIndex = 16
        '
        'pbPreview
        '
        Me.pbPreview.BackColor = System.Drawing.Color.White
        Me.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbPreview.Location = New System.Drawing.Point(424, 324)
        Me.pbPreview.Name = "pbPreview"
        Me.pbPreview.Size = New System.Drawing.Size(510, 306)
        Me.pbPreview.TabIndex = 15
        Me.pbPreview.TabStop = False
        '
        'btnAssign
        '
        Me.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssign.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssign.Location = New System.Drawing.Point(804, 636)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(130, 23)
        Me.btnAssign.TabIndex = 14
        Me.btnAssign.Text = "Assign Preview Image"
        Me.btnAssign.UseVisualStyleBackColor = True
        '
        'pnlReportDefinitions
        '
        Me.pnlReportDefinitions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlReportDefinitions.Controls.Add(Me.txt_RemoteFileName)
        Me.pnlReportDefinitions.Controls.Add(Me.lblRemoteFileName)
        Me.pnlReportDefinitions.Controls.Add(Me.chkrptdefinitiondeleted)
        Me.pnlReportDefinitions.Controls.Add(Me.txt_Notes)
        Me.pnlReportDefinitions.Controls.Add(Me.chkrptdefinitaionActive)
        Me.pnlReportDefinitions.Controls.Add(Me.lblNotes)
        Me.pnlReportDefinitions.Controls.Add(Me.cboReportGroup)
        Me.pnlReportDefinitions.Controls.Add(Me.lblReportGroup)
        Me.pnlReportDefinitions.Controls.Add(Me.cboRportCategory)
        Me.pnlReportDefinitions.Controls.Add(Me.lbl_ReportCategory)
        Me.pnlReportDefinitions.Controls.Add(Me.txt_ReportDescription)
        Me.pnlReportDefinitions.Controls.Add(Me.lbl_ReportDescription)
        Me.pnlReportDefinitions.Controls.Add(Me.txt_ReportID)
        Me.pnlReportDefinitions.Controls.Add(Me.lblReportID)
        Me.pnlReportDefinitions.Location = New System.Drawing.Point(424, 9)
        Me.pnlReportDefinitions.Name = "pnlReportDefinitions"
        Me.pnlReportDefinitions.Size = New System.Drawing.Size(510, 306)
        Me.pnlReportDefinitions.TabIndex = 2
        Me.pnlReportDefinitions.Visible = False
        '
        'txt_RemoteFileName
        '
        Me.txt_RemoteFileName.Location = New System.Drawing.Point(140, 181)
        Me.txt_RemoteFileName.Name = "txt_RemoteFileName"
        Me.txt_RemoteFileName.Size = New System.Drawing.Size(350, 20)
        Me.txt_RemoteFileName.TabIndex = 12
        '
        'lblRemoteFileName
        '
        Me.lblRemoteFileName.AutoSize = True
        Me.lblRemoteFileName.Location = New System.Drawing.Point(25, 184)
        Me.lblRemoteFileName.Name = "lblRemoteFileName"
        Me.lblRemoteFileName.Size = New System.Drawing.Size(97, 13)
        Me.lblRemoteFileName.TabIndex = 11
        Me.lblRemoteFileName.Text = "Remote File Name:"
        '
        'chkrptdefinitiondeleted
        '
        Me.chkrptdefinitiondeleted.AutoSize = True
        Me.chkrptdefinitiondeleted.Location = New System.Drawing.Point(207, 285)
        Me.chkrptdefinitiondeleted.Name = "chkrptdefinitiondeleted"
        Me.chkrptdefinitiondeleted.Size = New System.Drawing.Size(74, 17)
        Me.chkrptdefinitiondeleted.TabIndex = 10
        Me.chkrptdefinitiondeleted.Text = "Is Deleted"
        Me.chkrptdefinitiondeleted.UseVisualStyleBackColor = True
        '
        'txt_Notes
        '
        Me.txt_Notes.Location = New System.Drawing.Point(140, 223)
        Me.txt_Notes.Name = "txt_Notes"
        Me.txt_Notes.Size = New System.Drawing.Size(350, 52)
        Me.txt_Notes.TabIndex = 9
        Me.txt_Notes.Text = ""
        '
        'chkrptdefinitaionActive
        '
        Me.chkrptdefinitaionActive.AutoSize = True
        Me.chkrptdefinitaionActive.Location = New System.Drawing.Point(139, 285)
        Me.chkrptdefinitaionActive.Name = "chkrptdefinitaionActive"
        Me.chkrptdefinitaionActive.Size = New System.Drawing.Size(67, 17)
        Me.chkrptdefinitaionActive.TabIndex = 9
        Me.chkrptdefinitaionActive.Text = "Is Active"
        Me.chkrptdefinitaionActive.UseVisualStyleBackColor = True
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(25, 237)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(33, 13)
        Me.lblNotes.TabIndex = 8
        Me.lblNotes.Text = "Note:"
        '
        'cboReportGroup
        '
        Me.cboReportGroup.Enabled = False
        Me.cboReportGroup.FormattingEnabled = True
        Me.cboReportGroup.Location = New System.Drawing.Point(140, 134)
        Me.cboReportGroup.Name = "cboReportGroup"
        Me.cboReportGroup.Size = New System.Drawing.Size(350, 21)
        Me.cboReportGroup.TabIndex = 7
        '
        'lblReportGroup
        '
        Me.lblReportGroup.AutoSize = True
        Me.lblReportGroup.Location = New System.Drawing.Point(27, 143)
        Me.lblReportGroup.Name = "lblReportGroup"
        Me.lblReportGroup.Size = New System.Drawing.Size(39, 13)
        Me.lblReportGroup.TabIndex = 6
        Me.lblReportGroup.Text = "Group:"
        '
        'cboRportCategory
        '
        Me.cboRportCategory.FormattingEnabled = True
        Me.cboRportCategory.Location = New System.Drawing.Point(140, 91)
        Me.cboRportCategory.Name = "cboRportCategory"
        Me.cboRportCategory.Size = New System.Drawing.Size(350, 21)
        Me.cboRportCategory.TabIndex = 5
        '
        'lbl_ReportCategory
        '
        Me.lbl_ReportCategory.AutoSize = True
        Me.lbl_ReportCategory.Location = New System.Drawing.Point(22, 94)
        Me.lbl_ReportCategory.Name = "lbl_ReportCategory"
        Me.lbl_ReportCategory.Size = New System.Drawing.Size(52, 13)
        Me.lbl_ReportCategory.TabIndex = 4
        Me.lbl_ReportCategory.Text = "Category:"
        '
        'txt_ReportDescription
        '
        Me.txt_ReportDescription.Location = New System.Drawing.Point(140, 46)
        Me.txt_ReportDescription.Name = "txt_ReportDescription"
        Me.txt_ReportDescription.Size = New System.Drawing.Size(350, 20)
        Me.txt_ReportDescription.TabIndex = 3
        '
        'lbl_ReportDescription
        '
        Me.lbl_ReportDescription.AutoSize = True
        Me.lbl_ReportDescription.Location = New System.Drawing.Point(21, 53)
        Me.lbl_ReportDescription.Name = "lbl_ReportDescription"
        Me.lbl_ReportDescription.Size = New System.Drawing.Size(63, 13)
        Me.lbl_ReportDescription.TabIndex = 2
        Me.lbl_ReportDescription.Text = "Description:"
        '
        'txt_ReportID
        '
        Me.txt_ReportID.Location = New System.Drawing.Point(140, 12)
        Me.txt_ReportID.Name = "txt_ReportID"
        Me.txt_ReportID.Size = New System.Drawing.Size(350, 20)
        Me.txt_ReportID.TabIndex = 1
        '
        'lblReportID
        '
        Me.lblReportID.AutoSize = True
        Me.lblReportID.Location = New System.Drawing.Point(22, 19)
        Me.lblReportID.Name = "lblReportID"
        Me.lblReportID.Size = New System.Drawing.Size(56, 13)
        Me.lblReportID.TabIndex = 0
        Me.lblReportID.Text = "Report ID:"
        '
        'tcReports
        '
        Me.tcReports.Controls.Add(Me.TabPage2)
        Me.tcReports.Location = New System.Drawing.Point(11, 2)
        Me.tcReports.Name = "tcReports"
        Me.tcReports.SelectedIndex = 0
        Me.tcReports.Size = New System.Drawing.Size(948, 691)
        Me.tcReports.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.trvwReportCategories)
        Me.TabPage2.Controls.Add(Me.pnlRepCategories)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(940, 665)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Report Categories"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'trvwReportCategories
        '
        Me.trvwReportCategories.Location = New System.Drawing.Point(9, 7)
        Me.trvwReportCategories.Name = "trvwReportCategories"
        Me.trvwReportCategories.Size = New System.Drawing.Size(406, 621)
        Me.trvwReportCategories.TabIndex = 3
        '
        'pnlRepCategories
        '
        Me.pnlRepCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRepCategories.Controls.Add(Me.chkRepCatID)
        Me.pnlRepCategories.Controls.Add(Me.chkRepCatIA)
        Me.pnlRepCategories.Controls.Add(Me.Label20)
        Me.pnlRepCategories.Controls.Add(Me.cboRepGroupCat)
        Me.pnlRepCategories.Controls.Add(Me.txtRepCategoryName)
        Me.pnlRepCategories.Controls.Add(Me.Label19)
        Me.pnlRepCategories.Location = New System.Drawing.Point(421, 7)
        Me.pnlRepCategories.Name = "pnlRepCategories"
        Me.pnlRepCategories.Size = New System.Drawing.Size(489, 621)
        Me.pnlRepCategories.TabIndex = 2
        '
        'chkRepCatID
        '
        Me.chkRepCatID.AutoSize = True
        Me.chkRepCatID.Location = New System.Drawing.Point(174, 87)
        Me.chkRepCatID.Name = "chkRepCatID"
        Me.chkRepCatID.Size = New System.Drawing.Size(74, 17)
        Me.chkRepCatID.TabIndex = 8
        Me.chkRepCatID.Text = "Is Deleted"
        Me.chkRepCatID.UseVisualStyleBackColor = True
        '
        'chkRepCatIA
        '
        Me.chkRepCatIA.AutoSize = True
        Me.chkRepCatIA.Location = New System.Drawing.Point(101, 87)
        Me.chkRepCatIA.Name = "chkRepCatIA"
        Me.chkRepCatIA.Size = New System.Drawing.Size(67, 17)
        Me.chkRepCatIA.TabIndex = 7
        Me.chkRepCatIA.Text = "Is Active"
        Me.chkRepCatIA.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Group:"
        '
        'cboRepGroupCat
        '
        Me.cboRepGroupCat.FormattingEnabled = True
        Me.cboRepGroupCat.Location = New System.Drawing.Point(101, 54)
        Me.cboRepGroupCat.Name = "cboRepGroupCat"
        Me.cboRepGroupCat.Size = New System.Drawing.Size(375, 21)
        Me.cboRepGroupCat.TabIndex = 3
        '
        'txtRepCategoryName
        '
        Me.txtRepCategoryName.Location = New System.Drawing.Point(101, 28)
        Me.txtRepCategoryName.Name = "txtRepCategoryName"
        Me.txtRepCategoryName.Size = New System.Drawing.Size(375, 20)
        Me.txtRepCategoryName.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 31)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Category Name:"
        '
        'tcCompany
        '
        Me.tcCompany.Controls.Add(Me.TabPage1)
        Me.tcCompany.Location = New System.Drawing.Point(11, 6)
        Me.tcCompany.Name = "tcCompany"
        Me.tcCompany.SelectedIndex = 0
        Me.tcCompany.Size = New System.Drawing.Size(951, 688)
        Me.tcCompany.TabIndex = 2
        Me.tcCompany.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pnlCompanyInfo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(943, 662)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pnlCompanyInfo
        '
        Me.pnlCompanyInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCompanyInfo.Controls.Add(Me.txtCoFax)
        Me.pnlCompanyInfo.Controls.Add(Me.Label17)
        Me.pnlCompanyInfo.Controls.Add(Me.txtCoWebS)
        Me.pnlCompanyInfo.Controls.Add(Me.Label16)
        Me.pnlCompanyInfo.Controls.Add(Me.txtCoPhone)
        Me.pnlCompanyInfo.Controls.Add(Me.Label15)
        Me.pnlCompanyInfo.Controls.Add(Me.txtCoAddress)
        Me.pnlCompanyInfo.Controls.Add(Me.Label12)
        Me.pnlCompanyInfo.Controls.Add(Me.txtCoName)
        Me.pnlCompanyInfo.Controls.Add(Me.Label10)
        Me.pnlCompanyInfo.Enabled = False
        Me.pnlCompanyInfo.Location = New System.Drawing.Point(9, 9)
        Me.pnlCompanyInfo.Name = "pnlCompanyInfo"
        Me.pnlCompanyInfo.Size = New System.Drawing.Size(379, 265)
        Me.pnlCompanyInfo.TabIndex = 0
        '
        'txtCoFax
        '
        Me.txtCoFax.Location = New System.Drawing.Point(62, 168)
        Me.txtCoFax.Name = "txtCoFax"
        Me.txtCoFax.Size = New System.Drawing.Size(228, 20)
        Me.txtCoFax.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 198)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Web Site:"
        '
        'txtCoWebS
        '
        Me.txtCoWebS.Location = New System.Drawing.Point(62, 195)
        Me.txtCoWebS.Name = "txtCoWebS"
        Me.txtCoWebS.Size = New System.Drawing.Size(228, 20)
        Me.txtCoWebS.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 172)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Fax:"
        '
        'txtCoPhone
        '
        Me.txtCoPhone.Location = New System.Drawing.Point(62, 140)
        Me.txtCoPhone.Name = "txtCoPhone"
        Me.txtCoPhone.Size = New System.Drawing.Size(228, 20)
        Me.txtCoPhone.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 140)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Phone:"
        '
        'txtCoAddress
        '
        Me.txtCoAddress.Location = New System.Drawing.Point(62, 30)
        Me.txtCoAddress.Multiline = True
        Me.txtCoAddress.Name = "txtCoAddress"
        Me.txtCoAddress.Size = New System.Drawing.Size(228, 100)
        Me.txtCoAddress.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Address:"
        '
        'txtCoName
        '
        Me.txtCoName.Location = New System.Drawing.Point(62, 3)
        Me.txtCoName.Name = "txtCoName"
        Me.txtCoName.Size = New System.Drawing.Size(228, 20)
        Me.txtCoName.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Name:"
        '
        'tbcntrl_ProfileAccess
        '
        Me.tbcntrl_ProfileAccess.Controls.Add(Me.tbpg_Roles)
        Me.tbcntrl_ProfileAccess.Location = New System.Drawing.Point(13, 6)
        Me.tbcntrl_ProfileAccess.Name = "tbcntrl_ProfileAccess"
        Me.tbcntrl_ProfileAccess.SelectedIndex = 0
        Me.tbcntrl_ProfileAccess.Size = New System.Drawing.Size(947, 691)
        Me.tbcntrl_ProfileAccess.TabIndex = 3
        '
        'tbpg_Roles
        '
        Me.tbpg_Roles.Controls.Add(Me.pnlProfiles)
        Me.tbpg_Roles.Controls.Add(Me.cboProfiles)
        Me.tbpg_Roles.Controls.Add(Me.Label6)
        Me.tbpg_Roles.Location = New System.Drawing.Point(4, 22)
        Me.tbpg_Roles.Name = "tbpg_Roles"
        Me.tbpg_Roles.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpg_Roles.Size = New System.Drawing.Size(939, 665)
        Me.tbpg_Roles.TabIndex = 0
        Me.tbpg_Roles.Text = "Roles"
        Me.tbpg_Roles.UseVisualStyleBackColor = True
        '
        'pnlProfiles
        '
        Me.pnlProfiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProfiles.Controls.Add(Me.Label13)
        Me.pnlProfiles.Controls.Add(Me.chklbPermissions)
        Me.pnlProfiles.Controls.Add(Me.txtPrDesc)
        Me.pnlProfiles.Controls.Add(Me.txtPrName)
        Me.pnlProfiles.Controls.Add(Me.Label8)
        Me.pnlProfiles.Controls.Add(Me.Label7)
        Me.pnlProfiles.Location = New System.Drawing.Point(10, 34)
        Me.pnlProfiles.Name = "pnlProfiles"
        Me.pnlProfiles.Size = New System.Drawing.Size(921, 623)
        Me.pnlProfiles.TabIndex = 5
        Me.pnlProfiles.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label13.Location = New System.Drawing.Point(3, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(286, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "This Profile has permission to access the following features:"
        '
        'chklbPermissions
        '
        Me.chklbPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.chklbPermissions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.chklbPermissions.Location = New System.Drawing.Point(6, 51)
        Me.chklbPermissions.Name = "chklbPermissions"
        Me.chklbPermissions.Size = New System.Drawing.Size(910, 567)
        Me.chklbPermissions.TabIndex = 7
        '
        'txtPrDesc
        '
        Me.txtPrDesc.Location = New System.Drawing.Point(435, 14)
        Me.txtPrDesc.MaxLength = 255
        Me.txtPrDesc.Name = "txtPrDesc"
        Me.txtPrDesc.Size = New System.Drawing.Size(356, 20)
        Me.txtPrDesc.TabIndex = 6
        '
        'txtPrName
        '
        Me.txtPrName.Location = New System.Drawing.Point(47, 11)
        Me.txtPrName.MaxLength = 50
        Me.txtPrName.Name = "txtPrName"
        Me.txtPrName.Size = New System.Drawing.Size(276, 20)
        Me.txtPrName.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(366, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Description:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Name:"
        '
        'cboProfiles
        '
        Me.cboProfiles.FormattingEnabled = True
        Me.cboProfiles.Location = New System.Drawing.Point(57, 7)
        Me.cboProfiles.Name = "cboProfiles"
        Me.cboProfiles.Size = New System.Drawing.Size(277, 21)
        Me.cboProfiles.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Profiles:"
        '
        'tcProfiles
        '
        Me.tcProfiles.Controls.Add(Me.Information)
        Me.tcProfiles.Location = New System.Drawing.Point(16, 6)
        Me.tcProfiles.Name = "tcProfiles"
        Me.tcProfiles.SelectedIndex = 0
        Me.tcProfiles.Size = New System.Drawing.Size(944, 688)
        Me.tcProfiles.TabIndex = 1
        Me.tcProfiles.Visible = False
        '
        'Information
        '
        Me.Information.Controls.Add(Me.pnlPermissions)
        Me.Information.Controls.Add(Me.pnlInfoUsers)
        Me.Information.Controls.Add(Me.Label1)
        Me.Information.Controls.Add(Me.cboUsers)
        Me.Information.Location = New System.Drawing.Point(4, 22)
        Me.Information.Name = "Information"
        Me.Information.Padding = New System.Windows.Forms.Padding(3)
        Me.Information.Size = New System.Drawing.Size(936, 662)
        Me.Information.TabIndex = 0
        Me.Information.Text = "Information"
        Me.Information.UseVisualStyleBackColor = True
        '
        'pnlPermissions
        '
        Me.pnlPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPermissions.Controls.Add(Me.btnAddPr)
        Me.pnlPermissions.Controls.Add(Me.Label14)
        Me.pnlPermissions.Controls.Add(Me.lbAvailableProfiles)
        Me.pnlPermissions.Controls.Add(Me.btnRemovePr)
        Me.pnlPermissions.Controls.Add(Me.Label11)
        Me.pnlPermissions.Controls.Add(Me.lbOwnedProfiles)
        Me.pnlPermissions.Location = New System.Drawing.Point(49, 167)
        Me.pnlPermissions.Name = "pnlPermissions"
        Me.pnlPermissions.Size = New System.Drawing.Size(596, 489)
        Me.pnlPermissions.TabIndex = 10
        Me.pnlPermissions.Visible = False
        '
        'btnAddPr
        '
        Me.btnAddPr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAddPr.Image = CType(resources.GetObject("btnAddPr.Image"), System.Drawing.Image)
        Me.btnAddPr.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAddPr.Location = New System.Drawing.Point(239, 155)
        Me.btnAddPr.Name = "btnAddPr"
        Me.btnAddPr.Size = New System.Drawing.Size(75, 26)
        Me.btnAddPr.TabIndex = 16
        Me.btnAddPr.Text = "Add"
        Me.btnAddPr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddPr.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Available Profiles:"
        '
        'lbAvailableProfiles
        '
        Me.lbAvailableProfiles.FormattingEnabled = True
        Me.lbAvailableProfiles.Location = New System.Drawing.Point(12, 27)
        Me.lbAvailableProfiles.Name = "lbAvailableProfiles"
        Me.lbAvailableProfiles.Size = New System.Drawing.Size(201, 446)
        Me.lbAvailableProfiles.TabIndex = 14
        '
        'btnRemovePr
        '
        Me.btnRemovePr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnRemovePr.Image = CType(resources.GetObject("btnRemovePr.Image"), System.Drawing.Image)
        Me.btnRemovePr.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnRemovePr.Location = New System.Drawing.Point(239, 187)
        Me.btnRemovePr.Name = "btnRemovePr"
        Me.btnRemovePr.Size = New System.Drawing.Size(75, 26)
        Me.btnRemovePr.TabIndex = 13
        Me.btnRemovePr.Text = "Remove"
        Me.btnRemovePr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemovePr.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(348, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Owned Profiles:"
        '
        'lbOwnedProfiles
        '
        Me.lbOwnedProfiles.FormattingEnabled = True
        Me.lbOwnedProfiles.Location = New System.Drawing.Point(351, 27)
        Me.lbOwnedProfiles.Name = "lbOwnedProfiles"
        Me.lbOwnedProfiles.Size = New System.Drawing.Size(193, 446)
        Me.lbOwnedProfiles.TabIndex = 11
        '
        'pnlInfoUsers
        '
        Me.pnlInfoUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfoUsers.Controls.Add(Me.chkActive)
        Me.pnlInfoUsers.Controls.Add(Me.Label5)
        Me.pnlInfoUsers.Controls.Add(Me.txtEmail)
        Me.pnlInfoUsers.Controls.Add(Me.Label4)
        Me.pnlInfoUsers.Controls.Add(Me.txtName)
        Me.pnlInfoUsers.Controls.Add(Me.Label3)
        Me.pnlInfoUsers.Controls.Add(Me.txtPassword)
        Me.pnlInfoUsers.Controls.Add(Me.Label2)
        Me.pnlInfoUsers.Controls.Add(Me.txtLogon)
        Me.pnlInfoUsers.Location = New System.Drawing.Point(49, 33)
        Me.pnlInfoUsers.Name = "pnlInfoUsers"
        Me.pnlInfoUsers.Size = New System.Drawing.Size(596, 128)
        Me.pnlInfoUsers.TabIndex = 2
        Me.pnlInfoUsers.Visible = False
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(66, 106)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 8
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Email:"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(67, 80)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(511, 20)
        Me.txtEmail.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Full Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(67, 54)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(511, 20)
        Me.txtName.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(317, 14)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(261, 20)
        Me.txtPassword.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Logon ID:"
        '
        'txtLogon
        '
        Me.txtLogon.Location = New System.Drawing.Point(67, 14)
        Me.txtLogon.Name = "txtLogon"
        Me.txtLogon.Size = New System.Drawing.Size(182, 20)
        Me.txtLogon.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Users:"
        '
        'cboUsers
        '
        Me.cboUsers.FormattingEnabled = True
        Me.cboUsers.Location = New System.Drawing.Point(49, 6)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(271, 21)
        Me.cboUsers.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'opdImageDialog
        '
        Me.opdImageDialog.FileName = "opdImageDialog"
        Me.opdImageDialog.Filter = "JPEG files|*.jpeg|JPG Files|*.jpg|PNG Files|*.png|GIF Files|*.gif"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 721)
        Me.Controls.Add(Me.scMain)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuration Manager"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.tbcntrlReports.ResumeLayout(False)
        Me.tpgReports.ResumeLayout(False)
        CType(Me.dgvParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcReportDefinition.ResumeLayout(False)
        Me.tbpg_ReportDefinition.ResumeLayout(False)
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReportDefinitions.ResumeLayout(False)
        Me.pnlReportDefinitions.PerformLayout()
        Me.tcReports.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.pnlRepCategories.ResumeLayout(False)
        Me.pnlRepCategories.PerformLayout()
        Me.tcCompany.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.pnlCompanyInfo.ResumeLayout(False)
        Me.pnlCompanyInfo.PerformLayout()
        Me.tbcntrl_ProfileAccess.ResumeLayout(False)
        Me.tbpg_Roles.ResumeLayout(False)
        Me.tbpg_Roles.PerformLayout()
        Me.pnlProfiles.ResumeLayout(False)
        Me.pnlProfiles.PerformLayout()
        Me.tcProfiles.ResumeLayout(False)
        Me.Information.ResumeLayout(False)
        Me.Information.PerformLayout()
        Me.pnlPermissions.ResumeLayout(False)
        Me.pnlPermissions.PerformLayout()
        Me.pnlInfoUsers.ResumeLayout(False)
        Me.pnlInfoUsers.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents scMain As System.Windows.Forms.SplitContainer
    Friend WithEvents trvOptions As System.Windows.Forms.TreeView
    Friend WithEvents tcProfiles As System.Windows.Forms.TabControl
    Friend WithEvents Information As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboUsers As System.Windows.Forms.ComboBox
    Friend WithEvents pnlInfoUsers As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLogon As System.Windows.Forms.TextBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents tcCompany As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents pnlCompanyInfo As System.Windows.Forms.Panel
    Friend WithEvents txtCoFax As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCoWebS As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCoPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCoAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCoName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tcReports As System.Windows.Forms.TabControl
    Friend WithEvents pnlPermissions As System.Windows.Forms.Panel
    Friend WithEvents btnAddPr As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbAvailableProfiles As System.Windows.Forms.ListBox
    Friend WithEvents btnRemovePr As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbOwnedProfiles As System.Windows.Forms.ListBox
    Friend WithEvents tbcntrl_ProfileAccess As System.Windows.Forms.TabControl
    Friend WithEvents tbpg_Roles As System.Windows.Forms.TabPage
    Friend WithEvents pnlProfiles As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chklbPermissions As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtPrDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtPrName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboProfiles As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents pnlRepCategories As System.Windows.Forms.Panel
    Friend WithEvents chkRepCatID As System.Windows.Forms.CheckBox
    Friend WithEvents chkRepCatIA As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboRepGroupCat As System.Windows.Forms.ComboBox
    Friend WithEvents txtRepCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbcReportDefinition As System.Windows.Forms.TabControl
    Friend WithEvents tbpg_ReportDefinition As System.Windows.Forms.TabPage
    Friend WithEvents pnlReportDefinitions As System.Windows.Forms.Panel
    Friend WithEvents chkrptdefinitiondeleted As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Notes As System.Windows.Forms.RichTextBox
    Friend WithEvents chkrptdefinitaionActive As System.Windows.Forms.CheckBox
    Public WithEvents lblNotes As System.Windows.Forms.Label
    Public WithEvents lblReportGroup As System.Windows.Forms.Label
    Public WithEvents lbl_ReportCategory As System.Windows.Forms.Label
    Friend WithEvents txt_ReportDescription As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ReportDescription As System.Windows.Forms.Label
    Friend WithEvents txt_ReportID As System.Windows.Forms.TextBox
    Friend WithEvents lblReportID As System.Windows.Forms.Label
    Public WithEvents cboReportGroup As System.Windows.Forms.ComboBox
    Public WithEvents cboRportCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txt_RemoteFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblRemoteFileName As System.Windows.Forms.Label
    Friend WithEvents btnAssign As System.Windows.Forms.Button
    Friend WithEvents opdImageDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pbPreview As System.Windows.Forms.PictureBox
    Friend WithEvents tsSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbcntrlReports As System.Windows.Forms.TabControl
    Friend WithEvents tpgReports As System.Windows.Forms.TabPage
    Friend WithEvents trvwReports As System.Windows.Forms.TreeView
    Friend WithEvents cmbOperator As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType As System.Windows.Forms.ComboBox
    Friend WithEvents dgvParameters As System.Windows.Forms.DataGridView
    Friend WithEvents colParameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrompt As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSequence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOperator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDefaultValue1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDefaultValue2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRequired As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents trvwReportCategories As System.Windows.Forms.TreeView
    Friend WithEvents trvwReportDefinition As System.Windows.Forms.TreeView

End Class
