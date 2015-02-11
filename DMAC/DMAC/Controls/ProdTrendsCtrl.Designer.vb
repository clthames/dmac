<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProdTrendsCtrl
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvProdTrends = New System.Windows.Forms.DataGridView()
        Me.TrendName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekTrend = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MonthTrend = New System.Windows.Forms.DataGridViewImageColumn()
        Me.QuaterTrend = New System.Windows.Forms.DataGridViewImageColumn()
        Me.YearTrend = New System.Windows.Forms.DataGridViewImageColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.UpdatedLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnUpdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvProdTrends, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProdTrends
        '
        Me.dgvProdTrends.AllowUserToAddRows = False
        Me.dgvProdTrends.AllowUserToDeleteRows = False
        Me.dgvProdTrends.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvProdTrends.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvProdTrends.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.AppWorkspace
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProdTrends.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProdTrends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdTrends.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TrendName, Me.WeekTrend, Me.MonthTrend, Me.QuaterTrend, Me.YearTrend})
        Me.dgvProdTrends.Location = New System.Drawing.Point(27, 0)
        Me.dgvProdTrends.Name = "dgvProdTrends"
        Me.dgvProdTrends.ReadOnly = True
        Me.dgvProdTrends.RowHeadersVisible = False
        Me.dgvProdTrends.Size = New System.Drawing.Size(395, 165)
        Me.dgvProdTrends.TabIndex = 0
        '
        'TrendName
        '
        Me.TrendName.HeaderText = "Trend Name"
        Me.TrendName.Name = "TrendName"
        Me.TrendName.ReadOnly = True
        '
        'WeekTrend
        '
        Me.WeekTrend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.WeekTrend.HeaderText = "Last Week"
        Me.WeekTrend.Name = "WeekTrend"
        Me.WeekTrend.ReadOnly = True
        Me.WeekTrend.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.WeekTrend.Width = 65
        '
        'MonthTrend
        '
        Me.MonthTrend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.MonthTrend.HeaderText = "Last Month"
        Me.MonthTrend.Name = "MonthTrend"
        Me.MonthTrend.ReadOnly = True
        Me.MonthTrend.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MonthTrend.Width = 66
        '
        'QuaterTrend
        '
        Me.QuaterTrend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.QuaterTrend.HeaderText = "Last 91 Days (Qtr)"
        Me.QuaterTrend.Name = "QuaterTrend"
        Me.QuaterTrend.ReadOnly = True
        Me.QuaterTrend.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'YearTrend
        '
        Me.YearTrend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.YearTrend.HeaderText = "Last Year"
        Me.YearTrend.Name = "YearTrend"
        Me.YearTrend.ReadOnly = True
        Me.YearTrend.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.YearTrend.Width = 58
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdatedLabel, Me.btnUpdate})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 163)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(446, 26)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'UpdatedLabel
        '
        Me.UpdatedLabel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.UpdatedLabel.Name = "UpdatedLabel"
        Me.UpdatedLabel.Size = New System.Drawing.Size(55, 21)
        Me.UpdatedLabel.Text = "Updated:"
        Me.UpdatedLabel.ToolTipText = "Last Updated Date & Hour"
        '
        'btnUpdate
        '
        Me.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUpdate.Image = Global.DMAC.My.Resources.Resources.update
        Me.btnUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(36, 21)
        '
        'Timer1
        '
        '
        'ProdTrendsCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvProdTrends)
        Me.Name = "ProdTrendsCtrl"
        Me.Size = New System.Drawing.Size(446, 189)
        CType(Me.dgvProdTrends, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProdTrends As System.Windows.Forms.DataGridView
    Friend WithEvents TrendName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeekTrend As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents MonthTrend As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents QuaterTrend As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents YearTrend As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents UpdatedLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
