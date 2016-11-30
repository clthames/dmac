Public Class InventoryInd

    Public Sub SetUpdateLabel()
        UpdatedLabel.Text = "Updated: " & Date.Now.ToString
        Dim marg As New System.Windows.Forms.Padding(0, 3, 250 - (UpdatedLabel.Text.Length), 2)
        UpdatedLabel.Margin = marg
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        GetInventoryIndInfo()
    End Sub

    Public Sub GetInventoryIndInfo()
        'Dim imgFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath & "\" & oExcelSS.AppFolderName)
        'chg102015ly change all paths to only use AppFolderName
        Dim imgFilePath As String = oExcelSS.AppPath
        Dim dt As New DataTable
        dt = oExcelSS.getDataTable("uspGadget_GetInventoryIndicator", True)
        SetUpdateLabel()
        If dt.Rows.Count > 0 Then
            Select Case CDbl(dt.Rows(0)(0).ToString)
                Case Is = 0
                    pbInv.Image = Image.FromFile(imgFilePath & "\images\IIGreen.png")
                    lblII.Text = "Stock Level OK."
                Case Is > 0
                    pbInv.Image = Image.FromFile(imgFilePath & "\images\IIRed.png")
                    lblII.Text = "Need to Order. Click on Inventory Items link to get a list."
            End Select
        End If
    End Sub

    Private Sub InventoryInd_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetInventoryIndInfo()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetInventoryIndInfo()
    End Sub

    Private Sub lnklblScheduled_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblScheduled.LinkClicked
        Master.RunReportLauncher("DMAC-Report", "ScheduledUsage", "")
    End Sub
End Class
