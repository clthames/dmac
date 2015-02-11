Public Class OrdersInfo

    Private Sub OrdersInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetOrdersInfo()
    End Sub
    Public Sub getWeekDates(ByRef date1 As String, ByRef date2 As String)
        Dim actual As Integer
        Dim d1, d2 As Date
        actual = Date.Today.DayOfWeek + 1
        actual = IIf(actual = 8, 1, actual)
        d1 = DateAdd(DateInterval.Day, (1 - actual), Date.Now)
        d2 = DateAdd(DateInterval.Day, (7 - actual), Date.Now)
        date1 = d1.Month & "/" & d1.Day & "/" & d1.Year
        date2 = d2.Month & "/" & d2.Day & "/" & d2.Year
    End Sub
    Public Sub SetUpdateLabel()
        UpdatedLabel.Text = "Updated: " & Date.Now.ToString
        Dim marg As New System.Windows.Forms.Padding(0, 3, 250 - (UpdatedLabel.Text.Length), 2)
        UpdatedLabel.Margin = marg
    End Sub
    Public Sub GetOrdersInfo()
        Dim dsToday As New DataSet
        Dim dsYesterday As New DataSet
        Dim dsWeek As New DataSet
        Dim date1 As String
        Dim date2 As String
        date1 = Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year
        date2 = Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year
        dsToday = oExcelSS.getDataSet("exec uspGadget_OrderOverview '" & date1 & "','" & date2 & "'")
        date1 = DateAdd(DateInterval.Day, -1, Date.Now).Month & "/" & DateAdd(DateInterval.Day, -1, Date.Now).Day & "/" & DateAdd(DateInterval.Day, -1, Date.Now).Year
        date1 = DateAdd(DateInterval.Day, -1, Date.Now).Month & "/" & DateAdd(DateInterval.Day, -1, Date.Now).Day & "/" & DateAdd(DateInterval.Day, -1, Date.Now).Year
        dsYesterday = oExcelSS.getDataSet("exec uspGadget_OrderOverview '" & date1 & "','" & date2 & "'")
        getWeekDates(date1, date2)
        dsWeek = oExcelSS.getDataSet("exec uspGadget_OrderOverview '" & date1 & "','" & date2 & "'")
        SetUpdateLabel()
        dgvOrders.Rows.Clear()
        If dsToday.Tables.Count > 0 And dsYesterday.Tables.Count > 0 And dsWeek.Tables.Count > 0 Then
            dgvOrders.Rows.Add()
            dgvOrders.Rows(0).Cells(0).Value = "Entered"
            dgvOrders.Rows(0).Cells(1).Value = dsToday.Tables(0).Rows(0)(0)
            dgvOrders.Rows(0).Cells(2).Value = dsYesterday.Tables(0).Rows(0)(0)
            dgvOrders.Rows(0).Cells(3).Value = dsWeek.Tables(0).Rows(0)(0)
            dgvOrders.Rows.Add()
            dgvOrders.Rows(1).Cells(0).Value = "  Value"
            dgvOrders.Rows(1).Cells(1).Value = "$ " & Math.Truncate(Math.Round(dsToday.Tables(0).Rows(0)(2), 2))
            dgvOrders.Rows(1).Cells(2).Value = "$ " & Math.Truncate(Math.Round(dsYesterday.Tables(0).Rows(0)(2), 2))
            dgvOrders.Rows(1).Cells(3).Value = "$ " & Math.Truncate(Math.Round(dsWeek.Tables(0).Rows(0)(2), 2))
            dgvOrders.Rows.Add()
            dgvOrders.Rows(2).Cells(0).Value = "Shipped"
            dgvOrders.Rows(2).Cells(1).Value = dsToday.Tables(1).Rows(0)(0)
            dgvOrders.Rows(2).Cells(2).Value = dsYesterday.Tables(1).Rows(0)(0)
            dgvOrders.Rows(2).Cells(3).Value = dsWeek.Tables(1).Rows(0)(0)
            dgvOrders.Rows.Add()
            dgvOrders.Rows(3).Cells(0).Value = "  Qty"
            dgvOrders.Rows(3).Cells(1).Value = dsToday.Tables(1).Rows(0)(1)
            dgvOrders.Rows(3).Cells(2).Value = dsYesterday.Tables(1).Rows(0)(1)
            dgvOrders.Rows(3).Cells(3).Value = dsWeek.Tables(1).Rows(0)(1)
            dgvOrders.Rows.Add()
            dgvOrders.Rows(4).Cells(0).Value = "  Value"
            dgvOrders.Rows(4).Cells(1).Value = "$ " & Math.Truncate(Math.Round(dsToday.Tables(1).Rows(0)(2), 2))
            dgvOrders.Rows(4).Cells(2).Value = "$ " & Math.Truncate(Math.Round(dsYesterday.Tables(1).Rows(0)(2), 2))
            dgvOrders.Rows(4).Cells(3).Value = "$ " & Math.Truncate(Math.Round(dsWeek.Tables(1).Rows(0)(2), 2))
            dgvOrders.Rows.Add()
            dgvOrders.Rows(5).Cells(0).Value = "Invoiced"
            dgvOrders.Rows(5).Cells(1).Value = dsToday.Tables(2).Rows(0)(0)
            dgvOrders.Rows(5).Cells(2).Value = dsYesterday.Tables(2).Rows(0)(0)
            dgvOrders.Rows(5).Cells(3).Value = dsWeek.Tables(2).Rows(0)(0)
            dgvOrders.Rows.Add()
            dgvOrders.Rows(6).Cells(0).Value = "  Value"
            dgvOrders.Rows(6).Cells(1).Value = "$ " & Math.Truncate(Math.Round(dsToday.Tables(2).Rows(0)(1), 2))
            dgvOrders.Rows(6).Cells(2).Value = "$ " & Math.Truncate(Math.Round(dsYesterday.Tables(2).Rows(0)(1), 2))
            dgvOrders.Rows(6).Cells(3).Value = "$ " & Math.Truncate(Math.Round(dsWeek.Tables(2).Rows(0)(1), 2))
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        GetOrdersInfo()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetOrdersInfo()
    End Sub
End Class
