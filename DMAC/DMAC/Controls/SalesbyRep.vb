Public Class SalesbyRep

    Public stDate As String = ""
    Public enDate As String = ""

    Public Sub SetUpdateLabel()
        UpdatedLabel.Text = "Updated: " & Date.Now.ToString
        Dim marg As New System.Windows.Forms.Padding(0, 3, 250 - (UpdatedLabel.Text.Length), 2)
        UpdatedLabel.Margin = marg
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        GetSalesbyRepInfo()
    End Sub

    Public Sub GetSalesbyRepInfo()
        Dim dt As New DataTable
        getMonthDates(cboMonth.SelectedIndex)
        Dim paramsql As SqlClient.SqlParameter() = New SqlClient.SqlParameter(1) {}
        paramsql(0) = New SqlClient.SqlParameter("@DateStart", stDate)
        paramsql(1) = New SqlClient.SqlParameter("@DateEnd", enDate)
        dt = oExcelSS.getDataTable("uspGadget_GetSalesByRep", True, paramsql)
        SetUpdateLabel()
        If dt.Rows.Count > 0 Then
            Dim Chart1 As New Chart()
            Dim chartArea1 As New ChartArea()
            chartArea1.Name = "Default"
            Dim series1 As New Series()
            series1.Name = "Default"
            Chart1.ChartAreas.Add(chartArea1)
            Chart1.Series.Add(series1)
            Dim xValues(dt.Rows.Count - 1) As String
            Dim yValues(dt.Rows.Count - 1) As Double
            For i As Integer = 0 To dt.Rows.Count - 1
                xValues(i) = dt.Rows(i)(1)
                yValues(i) = Math.Round(dt.Rows(i)(0), 2)
            Next
            Chart1.Series("Default").Points.DataBindXY(xValues, yValues)
            Chart1.Series("Default").ChartType = SeriesChartType.Pie
            Chart1.Legends.Add("Sales")
            Chart1.Legends("Sales").Title = "Sales values"
            series1.IsValueShownAsLabel = True
            Chart1.Series("Default")("PieLabelStyle") = "Inside"
            Chart1.ChartAreas("Default").Area3DStyle.Enable3D = True
            Chart1.Series("Default")("PieDrawingStyle") = "SoftEdge"
            'Chart1.Series("Default").LegendText = "Product"
            Chart1.BackColor = Color.Transparent
            Chart1.Location = New System.Drawing.Point(0, 0)
            Chart1.Size = New System.Drawing.Size(440, 300)
            Panel1.Controls.Clear()
            Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Chart1})
        End If

    End Sub

    Private Sub SalesbyRep_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim actMonth As Integer = Date.Now.Month
        cboMonth.SelectedIndex = actMonth - 1
    End Sub

    Public Sub getMonthDates(selind As Integer)
        stDate = (selind + 1).ToString & "/01/" & Date.Now.Year
        Select Case selind
            Case Is = 0
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enJan & "/" & Date.Now.Year.ToString
            Case Is = 1
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enFeb & "/" & Date.Now.Year.ToString
            Case Is = 2
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enMar & "/" & Date.Now.Year.ToString
            Case Is = 3
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enApr & "/" & Date.Now.Year.ToString
            Case Is = 4
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enMay & "/" & Date.Now.Year.ToString
            Case Is = 5
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enJun & "/" & Date.Now.Year.ToString
            Case Is = 6
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enJul & "/" & Date.Now.Year.ToString
            Case Is = 7
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enAug & "/" & Date.Now.Year.ToString
            Case Is = 8
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enSep & "/" & Date.Now.Year.ToString
            Case Is = 9
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enOct & "/" & Date.Now.Year.ToString
            Case Is = 10
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enNov & "/" & Date.Now.Year.ToString
            Case Is = 11
                enDate = (selind + 1).ToString & "/" & ExcelSSGen.Main.EndMonthDates.enDec & "/" & Date.Now.Year.ToString
        End Select
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedIndexChanged
        GetSalesbyRepInfo()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetSalesbyRepInfo()
    End Sub
End Class
