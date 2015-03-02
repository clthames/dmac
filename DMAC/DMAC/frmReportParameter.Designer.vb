<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportParameter
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
        Me.tbcntrlReports = New System.Windows.Forms.TabControl()
        Me.tpgReports = New System.Windows.Forms.TabPage()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbOperator = New System.Windows.Forms.ComboBox()
        Me.cmbDataType = New System.Windows.Forms.ComboBox()
        Me.dgvParameters = New System.Windows.Forms.DataGridView()
        Me.trvwReports = New System.Windows.Forms.TreeView()
        Me.colParameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOperator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnDefaultValue1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmValue2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcntrlReports.SuspendLayout()
        Me.tpgReports.SuspendLayout()
        CType(Me.dgvParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbcntrlReports
        '
        Me.tbcntrlReports.Controls.Add(Me.tpgReports)
        Me.tbcntrlReports.Location = New System.Drawing.Point(3, 1)
        Me.tbcntrlReports.Name = "tbcntrlReports"
        Me.tbcntrlReports.SelectedIndex = 0
        Me.tbcntrlReports.Size = New System.Drawing.Size(948, 286)
        Me.tbcntrlReports.TabIndex = 18
        '
        'tpgReports
        '
        Me.tpgReports.Controls.Add(Me.btnSave)
        Me.tpgReports.Controls.Add(Me.cmbOperator)
        Me.tpgReports.Controls.Add(Me.cmbDataType)
        Me.tpgReports.Controls.Add(Me.dgvParameters)
        Me.tpgReports.Controls.Add(Me.trvwReports)
        Me.tpgReports.Location = New System.Drawing.Point(4, 22)
        Me.tpgReports.Name = "tpgReports"
        Me.tpgReports.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgReports.Size = New System.Drawing.Size(940, 260)
        Me.tpgReports.TabIndex = 0
        Me.tpgReports.Text = "Reports"
        Me.tpgReports.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(858, 232)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbOperator
        '
        Me.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperator.FormattingEnabled = True
        Me.cmbOperator.Location = New System.Drawing.Point(712, 83)
        Me.cmbOperator.Name = "cmbOperator"
        Me.cmbOperator.Size = New System.Drawing.Size(114, 21)
        Me.cmbOperator.TabIndex = 13
        Me.cmbOperator.Visible = False
        '
        'cmbDataType
        '
        Me.cmbDataType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataType.FormattingEnabled = True
        Me.cmbDataType.Items.AddRange(New Object() {"Text", "Date", "Boolean", "Integer", "Float"})
        Me.cmbDataType.Location = New System.Drawing.Point(712, 56)
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
        Me.dgvParameters.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colParameter, Me.colDataType, Me.colOperator, Me.clmnDefaultValue1, Me.clmValue2})
        Me.dgvParameters.Location = New System.Drawing.Point(194, 9)
        Me.dgvParameters.Name = "dgvParameters"
        Me.dgvParameters.RowHeadersWidth = 25
        Me.dgvParameters.Size = New System.Drawing.Size(739, 217)
        Me.dgvParameters.StandardTab = True
        Me.dgvParameters.TabIndex = 11
        '
        'trvwReports
        '
        Me.trvwReports.Location = New System.Drawing.Point(12, 9)
        Me.trvwReports.Name = "trvwReports"
        Me.trvwReports.Size = New System.Drawing.Size(176, 236)
        Me.trvwReports.TabIndex = 0
        '
        'colParameter
        '
        Me.colParameter.HeaderText = "Parameter"
        Me.colParameter.Name = "colParameter"
        Me.colParameter.ReadOnly = True
        Me.colParameter.Width = 145
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
        Me.colOperator.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'clmnDefaultValue1
        '
        Me.clmnDefaultValue1.HeaderText = "Value"
        Me.clmnDefaultValue1.Name = "clmnDefaultValue1"
        Me.clmnDefaultValue1.Width = 200
        '
        'clmValue2
        '
        Me.clmValue2.HeaderText = "Value2"
        Me.clmValue2.Name = "clmValue2"
        Me.clmValue2.ReadOnly = True
        Me.clmValue2.Width = 165
        '
        'frmReportParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(960, 296)
        Me.Controls.Add(Me.tbcntrlReports)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "frmReportParameter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Parameters"
        Me.tbcntrlReports.ResumeLayout(False)
        Me.tpgReports.ResumeLayout(False)
        CType(Me.dgvParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcntrlReports As System.Windows.Forms.TabControl
    Friend WithEvents tpgReports As System.Windows.Forms.TabPage
    Friend WithEvents cmbOperator As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataType As System.Windows.Forms.ComboBox
    Friend WithEvents dgvParameters As System.Windows.Forms.DataGridView
    Friend WithEvents trvwReports As System.Windows.Forms.TreeView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents colParameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOperator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnDefaultValue1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmValue2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
