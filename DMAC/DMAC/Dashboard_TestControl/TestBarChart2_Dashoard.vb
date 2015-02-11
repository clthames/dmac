Public Class TestBarChart2_Dashoard


    Private Sub FillChartSingleArea()

        ' Clear the Chart Area
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add("Area1")
        Chart1.BackColor = Color.Silver

        ' // this set the datasource
        Chart1.DataSource = GetItems()



        '// clear all the (possible) existing series
        Chart1.Series.Clear()

        '' Title of Chart
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Working Hour-1")


        '// add the hours series
        Dim hoursSeries = Chart1.Series.Add("Hours")

        hoursSeries.XValueMember = "Name"
        hoursSeries.YValueMembers = "Hours"
        hoursSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column

        '  // add the percentages series
        Dim percSeries = Chart1.Series.Add("Percentages")

        percSeries.XValueMember = "Name"
        percSeries.YValueMembers = "Percent"
        percSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column

        'Enable 3D style
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
    End Sub

    Private Sub FillChartDoubleArea()
        ' // this set the datasource
        Chart1.DataSource = GetItems()

        '// clear all the (possible) existing series
        Chart1.Series.Clear()

        '// clear all the existing areas and add 2 new areas
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add("Area1")
        Chart1.ChartAreas.Add("Area2")

        Chart1.BackColor = Color.Silver

        '' Title of Chart
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Working Hour-2")

        '// add the hours series
        Dim hoursSeries = Chart1.Series.Add("Hours")
        hoursSeries.ChartArea = "Area1"
        hoursSeries.XValueMember = "Name"
        hoursSeries.YValueMembers = "Hours"
        hoursSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column

        '// add the percentages series
        Dim percSeries = Chart1.Series.Add("Percentages")
        hoursSeries.ChartArea = "Area2"
        percSeries.XValueMember = "Name"
        percSeries.YValueMembers = "Percent"
        percSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column

        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        Chart1.ChartAreas(1).Area3DStyle.Enable3D = True
    End Sub


    Private Function GetItems() As List(Of DOHoursChartItem)

        Dim items As New List(Of DOHoursChartItem) From
             {
                New DOHoursChartItem("John", 120, 50),
                New DOHoursChartItem("Amanda", 40, 20),
                New DOHoursChartItem("David", 70, 20),
                New DOHoursChartItem("Rachel", 10, 10)
            }

        '// compute the percentages
        'var totalHours = items.Sum(x => x.Hours);

        'foreach (var item in items)
        '    item.Percent = (item.Hours * 100.0) / totalHours;

        Return items

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Left Alignment of Chart
        Chart1.Anchor = AnchorStyles.Left
        'Display in whole area of user control
        Chart1.Dock = DockStyle.Fill
        FillChartSingleArea()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Chart1.Anchor = AnchorStyles.Left
        Chart1.Dock = DockStyle.Fill
        FillChartDoubleArea()
    End Sub

    Private Sub Chart2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Anchor = AnchorStyles.Left
        Chart1.Dock = DockStyle.Fill
        FillChartSingleArea()
    End Sub
End Class

Public Class DOHoursChartItem

    Public Property Name As String
    Public Property Hours As Double
    Public Property Percent As Double

    Public Sub New()

    End Sub

    Public Sub New(ByVal _Name As String,
                   ByVal _Hours As Double,
                   ByVal _Percent As Double
                   )
        Name = _Name
        Hours = _Hours
        Percent = _Percent

    End Sub

End Class
