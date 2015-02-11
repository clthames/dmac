<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryInd
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
        Me.pbInv = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.UpdatedLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnUpdate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lnklblScheduled = New System.Windows.Forms.LinkLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblII = New System.Windows.Forms.Label()
        CType(Me.pbInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbInv
        '
        Me.pbInv.Location = New System.Drawing.Point(146, 31)
        Me.pbInv.Name = "pbInv"
        Me.pbInv.Size = New System.Drawing.Size(42, 48)
        Me.pbInv.TabIndex = 0
        Me.pbInv.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdatedLabel, Me.btnUpdate})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 124)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(444, 26)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 4
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
        'lnklblScheduled
        '
        Me.lnklblScheduled.AutoSize = True
        Me.lnklblScheduled.Location = New System.Drawing.Point(175, 82)
        Me.lnklblScheduled.Name = "lnklblScheduled"
        Me.lnklblScheduled.Size = New System.Drawing.Size(79, 13)
        Me.lnklblScheduled.TabIndex = 5
        Me.lnklblScheduled.TabStop = True
        Me.lnklblScheduled.Text = "Inventory Items"
        '
        'Timer1
        '
        '
        'lblII
        '
        Me.lblII.Location = New System.Drawing.Point(194, 31)
        Me.lblII.Name = "lblII"
        Me.lblII.Size = New System.Drawing.Size(201, 48)
        Me.lblII.TabIndex = 6
        '
        'InventoryInd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.lblII)
        Me.Controls.Add(Me.lnklblScheduled)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pbInv)
        Me.Name = "InventoryInd"
        Me.Size = New System.Drawing.Size(444, 150)
        CType(Me.pbInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbInv As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents UpdatedLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lnklblScheduled As System.Windows.Forms.LinkLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblII As System.Windows.Forms.Label

End Class
