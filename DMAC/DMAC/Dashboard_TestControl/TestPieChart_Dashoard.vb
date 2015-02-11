Imports System.Windows.Forms.DataVisualization.Charting

Public Class TestPieChart_Dashoard

    Private Sub myChart_load()
        Try
            Dim dtTest As New DataTable
            Dim dsTest As New DataSet
            dtTest = dsTest.Tables.Add("dtTest")
            dtTest.Columns.Add("Count", GetType(Integer))
            dtTest.Columns.Add("Title", GetType(String))

            dtTest.Rows.Add(50, "On Time")
            dtTest.Rows.Add(30, "Behind Schedul")
            dtTest.Rows.Add(20, "Late")

            Chart1.Dock = DockStyle.Fill
            Chart1.BackColor = Color.Silver

            Chart1.Anchor = AnchorStyles.Left

            Chart1.Series(0).IsVisibleInLegend = True
            Chart1.Titles.Add("Order Delivery Status")
            With Chart1.Series(0)
                .ChartType = SeriesChartType.Pie
                .Name = "Title"
                .IsVisibleInLegend = True
                .IsValueShownAsLabel = True
                .Points.DataBindXY(dtTest.DefaultView, "Title", dtTest.DefaultView, "Count")
            End With
            'Chart1.Series(0)("DrawingStyle") = "Cylinder"
            Chart1.ChartAreas(0).BackColor = Color.LightGray
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
            For Each series As Series In Chart1.Series
                series.Color = Color.FromArgb(0, series.Color)
            Next
            Chart1.Series(0).Palette = ChartColorPalette.SemiTransparent
            Chart1.ChartAreas(0).Area3DStyle.LightStyle = LightStyle.Simplistic
            Chart1.ChartAreas(0).Area3DStyle.Inclination = 50
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Chart1_Pie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Chart1.Dock = DockStyle.Fill
        Me.BackColor = Color.Silver
        myChart_load()
    End Sub
End Class
