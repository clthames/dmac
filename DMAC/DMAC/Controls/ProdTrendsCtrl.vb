Public Class ProdTrendsCtrl

    Private Sub ProdTrendsCtrl_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetProdTrendsInfo()
    End Sub
    Public Sub GetProdTrendsInfo()
        Dim dtPT As New DataTable
        'Dim imgFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath & "\" & oExcelSS.AppFolderName)
        'chg102015ly change all path statements to use only AppFolderName
        Dim imgFilePath As String = "\" & oExcelSS.AppFolderName
        dtPT = oExcelSS.getDataTable("uspReports_ProductionTrends", True)
        SetUpdateLabel()
        dgvProdTrends.Rows.Clear()
        If dtPT.Rows.Count > 0 Then
            Dim count As Integer = 0
            For Each r As DataRow In dtPT.Rows
                dgvProdTrends.Rows.Add()
                dgvProdTrends.Rows.Item(count).Cells(0).Value = r("TrendName")
                Dim c01 As New DataGridViewImageCell
                If Not IsDBNull(r("PrvWeekTrend")) And Not IsDBNull(r("WeekTrend")) Then
                    If r("PrvWeekTrend") - r("WeekTrend") > 0 Then
                        c01.Value = Image.FromFile(imgFilePath & "\images\red.png")
                    Else
                        c01.Value = Image.FromFile(imgFilePath & "\images\green.png")
                    End If
                Else
                    c01.Value = Image.FromFile(imgFilePath & "\images\yellow.png")
                End If
                c01.ImageLayout = DataGridViewImageCellLayout.Zoom
                c01.ToolTipText = "Previous Week: " & r("PrvWeekTrend") & " Current Week: " & r("WeekTrend")
                dgvProdTrends.Rows.Item(count).Cells(1) = c01
                Dim c02 As New DataGridViewImageCell
                If Not IsDBNull(r("PrvMonthTrend")) And Not IsDBNull(r("MonthTrend")) Then
                    If r("PrvMonthTrend") - r("MonthTrend") > 0 Then
                        c02.Value = Image.FromFile(imgFilePath & "\images\red.png")
                    Else
                        c02.Value = Image.FromFile(imgFilePath & "\images\green.png")
                    End If
                Else
                    c02.Value = Image.FromFile(imgFilePath & "\images\yellow.png")
                End If
                c02.ImageLayout = DataGridViewImageCellLayout.Zoom
                c02.ToolTipText = "Previous Month: " & r("PrvMonthTrend") & " Current Month: " & r("MonthTrend")
                dgvProdTrends.Rows.Item(count).Cells(2) = c02
                Dim c03 As New DataGridViewImageCell
                If Not IsDBNull(r("PrvQuaterTrend")) And Not IsDBNull(r("QuaterTrend")) Then
                    If r("PrvQuaterTrend") - r("QuaterTrend") > 0 Then
                        c03.Value = Image.FromFile(imgFilePath & "\images\red.png")
                    Else
                        c03.Value = Image.FromFile(imgFilePath & "\images\green.png")
                    End If
                Else
                    c03.Value = Image.FromFile(imgFilePath & "\images\yellow.png")
                End If
                c03.ImageLayout = DataGridViewImageCellLayout.Zoom
                c03.ToolTipText = "Previous Quarter: " & r("PrvQuaterTrend") & " Current Quarter:" & r("QuaterTrend")
                dgvProdTrends.Rows.Item(count).Cells(3) = c03
                Dim c04 As New DataGridViewImageCell
                If Not IsDBNull(r("PrvYearTrend")) And Not IsDBNull(r("YearTrend")) Then
                    If r("PrvYearTrend") - r("YearTrend") > 0 Then
                        c04.Value = Image.FromFile(imgFilePath & "\images\red.png")
                    Else
                        c04.Value = Image.FromFile(imgFilePath & "\images\green.png")
                    End If
                Else
                    c04.Value = Image.FromFile(imgFilePath & "\images\yellow.png")
                End If
                c04.ImageLayout = DataGridViewImageCellLayout.Zoom
                c04.ToolTipText = "Previous Year: " & r("PrvYearTrend") & " Current Year:" & r("YearTrend")
                dgvProdTrends.Rows.Item(count).Cells(4) = c04
                count += 1
            Next
        End If
    End Sub
    Public Sub SetUpdateLabel()
        UpdatedLabel.Text = "Updated: " & Date.Now.ToString
        Dim marg As New System.Windows.Forms.Padding(0, 3, 250 - (UpdatedLabel.Text.Length), 2)
        UpdatedLabel.Margin = marg
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        GetProdTrendsInfo()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetProdTrendsInfo()
    End Sub
End Class
