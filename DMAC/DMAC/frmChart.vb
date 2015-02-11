Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmChart
    Private Sub frmChart_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            selectedItem = String.Empty
        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("btnLogin_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub frmChart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dv As DataView = DirectCast((New DataLayer().getChart()), DataTable).DefaultView
            Chart1.Titles.Add("Category")
            Chart1.AllowDrop = True
            Chart1.Enabled = True
            Chart1.Series(0).IsValueShownAsLabel = True
            Chart1.ChartAreas(0).AxisX.Interval = 1
            Chart1.ChartAreas(0).AxisX.LabelStyle.IsStaggered = True
            Chart1.ChartAreas(0).Area3DStyle.PointDepth = 30
            Chart1.ChartAreas(0).AxisX.IsMarginVisible = True
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
            Chart1.Series(0).Points.DataBindXY(dv, "CategoryName", dv, "categorycount")
            Chart1.DataSource = dv
            Chart1.DataBind()

            myChart2()
            myChart3()
        Catch ex As Exception
            Dim objfunction As New Functions
            objfunction.ErrorLog("frmChart pageLoad ##" + ex.Message.ToString())
        End Try

    End Sub
    Private Sub myChart2()
        Try
            Dim dtTest As New DataTable
            Dim dsTest As New DataSet
            dtTest = dsTest.Tables.Add("dtTest")
            dtTest.Columns.Add("Count", GetType(Integer))
            dtTest.Columns.Add("Value", GetType(Integer))
            dtTest.Columns.Add("Name", GetType(String))

            dtTest.Rows.Add(54, 111861.29, "PROGRESSIVE PRINTING CO")
            dtTest.Rows.Add(78, 79097.88, "PRINT & DESIGN SOLUTIONS")
            dtTest.Rows.Add(26, 78737.89, "ABC PRINTING")
            dtTest.Rows.Add(46, 47164.07, "COMPASS PRINTING")
            dtTest.Rows.Add(128, 41247.14, "AMERICAN DIRECT MARKETING")
            dtTest.Rows.Add(11, 35177.06, "BLINK SOLUTIONS")
            dtTest.Rows.Add(20, 26110.14, "SPRINGDALE PRINTING COMPANY")
            dtTest.Rows.Add(1, 25454.89, "UNITED BUSINESS SERVICES")
            dtTest.Rows.Add(8, 24843.52, "YOUNG & YOUNG MARKETING")
            dtTest.Rows.Add(8, 21372.11, "DOCUGRAPHICS, INC")
            Chart2.Dock = DockStyle.Bottom
            Chart2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top
            Chart2.Series(0).IsVisibleInLegend = False
            Chart2.Titles.Add("Orders")
            With Chart2.Series(0)
                .ChartType = SeriesChartType.Bar
                '.Name = "Name"
                '.LegendText = "myValue"
                .IsVisibleInLegend = True
                .IsValueShownAsLabel = True
                .Points.DataBindXY(dtTest.DefaultView, "Name", dtTest.DefaultView, "value")
            End With
            Chart2.Series(0)("DrawingStyle") = "Cylinder"
            Chart2.ChartAreas(0).Area3DStyle.Enable3D = True
            Chart2.Series(0).Palette = ChartColorPalette.SemiTransparent
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub myChart3()
        Try
            Dim dtTest As New DataTable
            Dim dsTest As New DataSet
            dtTest = dsTest.Tables.Add("dtTest")
            dtTest.Columns.Add("Count", GetType(Integer))
            dtTest.Columns.Add("Title", GetType(String))

            dtTest.Rows.Add(23, "On Time")
            dtTest.Rows.Add(27, "Behind Schedul")
            dtTest.Rows.Add(0, "Late")

            Chart3.Dock = DockStyle.Bottom
            Chart3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top
            Chart3.Series(0).IsVisibleInLegend = True
            Chart3.Titles.Add("Order Delivery Status")
            With Chart3.Series(0)
                .ChartType = SeriesChartType.Pie
                .Name = "Title"
                .IsVisibleInLegend = True
                .IsValueShownAsLabel = True
                .Points.DataBindXY(dtTest.DefaultView, "Title", dtTest.DefaultView, "Count")
            End With
            'Chart3.Series(0)("DrawingStyle") = "Cylinder"
            Chart3.ChartAreas(0).BackColor = Color.LightGray
            Chart3.ChartAreas(0).Area3DStyle.Enable3D = True
            For Each series As Series In Chart3.Series
                series.Color = Color.FromArgb(0, series.Color)
            Next
            Chart3.Series(0).Palette = ChartColorPalette.SemiTransparent
            Chart3.ChartAreas(0).Area3DStyle.LightStyle = LightStyle.Simplistic
            Chart3.ChartAreas(0).Area3DStyle.Inclination = 50
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LoadChart4()
        Chart4.Series.Clear()
        Chart4.Palette = ChartColorPalette.Fire
        Chart4.BackColor = Color.LightYellow
        Chart4.Titles.Add("Employee Salary")
        Chart4.ChartAreas(0).BackColor = Color.Transparent
        Dim series1 As New Series() With { _
         .Name = "series1", _
         .IsVisibleInLegend = True, _
         .color = System.Drawing.Color.Green, _
         .ChartType = SeriesChartType.Doughnut _
        }

        Chart4.Series.Add(series1)
        series1.Points.Add(70000)
        series1.Points.Add(30000)
        Chart4.ChartAreas(0).Area3DStyle.Enable3D = True
        Chart4.ChartAreas(0).Area3DStyle.LightStyle = LightStyle.Simplistic
        For Each series As Series In Chart4.Series
            series.Color = Color.FromArgb(0, series.Color)
        Next
        Chart4.Series(0).Palette = ChartColorPalette.SemiTransparent
        Chart4.Series(1).Palette = ChartColorPalette.SemiTransparent
        Dim p1 = series1.Points(0)
        p1.AxisLabel = "70000"
        p1.LegendText = "Hiren Khirsaria"
        Dim p2 = series1.Points(1)
        p2.AxisLabel = "30000"
        p2.LegendText = "ABC XYZ"
        Chart4.Invalidate()
        Panel1.Controls.Add(Chart4)
        Chart4.SaveImage("d:\piechart.png", ChartImageFormat.Png)
    End Sub
    

End Class