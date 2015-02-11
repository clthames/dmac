Public Class ChartContainer

    Dim _layingOut As Boolean = False
    '_layingOut = false

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.BackColor = Color.Silver
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None

        Dim dynamicTableLayoutPanel As New TableLayoutPanel()

        Dim Hmaster As New Integer
        Dim Wmaster As New Integer

        Dim Htlc As New Integer
        Dim Wtlc As New Integer


        Htlc = Me.Height
        Wtlc = Me.Width

        Hmaster = Me.Height
        Wmaster = Me.Width

        Dim hh As New Integer
        Dim ww As New Integer

        hh = Int(Hmaster / 2) - Int(Htlc / 2)
        ww = Int(Hmaster / 2) - Int(Wtlc / 2)

        dynamicTableLayoutPanel.Location = New System.Drawing.Point(0, 0)

        dynamicTableLayoutPanel.Name = "TableLayoutPanel1"

        ' dynamicTableLayoutPanel.Size = New System.Drawing.Size(Htlc, Wtlc)

        dynamicTableLayoutPanel.BackColor = Me.BackColor

        ' set number of Column -----column is fixed------don't change column
        dynamicTableLayoutPanel.ColumnCount = 2

        'Set number of Rows-------if number of gadget is increased then you can set row with more number
        dynamicTableLayoutPanel.RowCount = 2

        '' Draw Border of cell
        dynamicTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset

        dynamicTableLayoutPanel.AutoSize = True
        dynamicTableLayoutPanel.AutoScroll = True
        dynamicTableLayoutPanel.Dock = DockStyle.Fill
        dynamicTableLayoutPanel.Anchor = AnchorStyles.Left

        'dynamicTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.0F))

        'dynamicTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.0F))

        'dynamicTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))

        'dynamicTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 52.0F))

        'dynamicTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 44.0F))

        Dim dtGadget As New DataTable
        Dim maxNoGadget As Integer = dynamicTableLayoutPanel.ColumnCount * dynamicTableLayoutPanel.RowCount

        '' get gedget list by the user ID
        dtGadget = New DataLayer().getUserGadget("Demo", maxNoGadget)

        Dim Col As Integer = 0
        Dim Row As Integer = 0
        Dim cnt As Integer = 0

        For Each dr As DataRow In dtGadget.Rows

            cnt += 1

            If cnt Mod 2 = 0 Then
                Col = 1
            Else
                Col = 0
            End If

            'If cnt = 1 Then
            '    Col = 0
            '    Row = 0
            'ElseIf cnt = 2 Then
            '    Col = 1
            '    Row = 0
            'ElseIf cnt = 3 Then
            '    Col = 0
            '    Row = 1
            'ElseIf cnt = 4 Then
            '    Col = 1
            '    Row = 1
            'End If
        

            Dim ctl As New Control

            ctl = getUserControl(dr.Item("ControlName"), dr.Item("ControlType"))

            ctl.Dock = DockStyle.Fill
            ctl.ForeColor = dynamicTableLayoutPanel.ForeColor

            ctl.BackColor = Me.BackColor

            dynamicTableLayoutPanel.Controls.Add(ctl, Col, Row)


            If Col = 1 Then
                Row += 1
            End If

        Next dr


        'For Each RS As RowStyle In dynamicTableLayoutPanel.RowStyles
        '    RS.SizeType = SizeType.Absolute
        '    RS.Height = 400
        'Next

        Controls.Add(dynamicTableLayoutPanel)

        'For Each RS As ColumnStyle In dynamicTableLayoutPanel.RowStyles
        '    RS.SizeType = SizeType.Absolute
        '    RS.Width = 300
        'Next

    
    End Sub

    '' Convert a windows form to user control
    Public Shared Sub ShowFormInControl(ByRef ctl As Control, ByRef frm As Form)
        If ctl IsNot Nothing AndAlso frm IsNot Nothing Then
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            frm.BackColor = Color.Silver
            frm.Visible = True
            ctl.Controls.Add(frm)
            ctl.Size = frm.Size
        End If
    End Sub

    Private Function getUserControl(ByVal ControlName As String, ByVal ControlType As String) As Control

        Dim ctl As New Control
        Dim obj As New Object
        Dim frm As New TestForm_Dashboard

        Select Case ControlName
            Case "TestFormUserControl"
                obj = New TestFormUserControl
            Case "TestPieChart_Dashoard"
                obj = New TestPieChart_Dashoard
            Case "TestBarChart2_Dashoard"
                obj = New TestBarChart2_Dashoard
            Case "TestForm_Dashboard"
                obj = New TestForm_Dashboard
            Case Else
                If ControlType = "Form" Then
                    obj = New FormNotFound_Dashboard
                Else
                    obj = New FormusctlNotFound_Dashboard
                End If

        End Select

        If ControlType = "Form" Then
            ShowFormInControl(ctl, obj)
        Else
            ctl = obj
        End If

        Return ctl

    End Function

End Class
