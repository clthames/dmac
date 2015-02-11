Public Class frmSelectCategory

    Dim _szGroup As String = String.Empty
    Dim _szReportName As String = String.Empty

    Public Sub New(ByVal szGroupSel As String, ByVal ReportName As String)
        InitializeComponent()
        _szGroup = szGroupSel
        _szReportName = ReportName
    End Sub
    Private Sub frmSelectCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCategory(_szGroup)
    End Sub
    Private Sub LoadCategory(ByVal szGroup As String)
        Try
            trvRptViewCategory.Nodes.Clear()
            oExcelSS.fillTrvCategory(trvRptViewCategory, "SELECT CategoryIDKey, CategoryName FROM ReportCategories WHERE isActive=1 AND isdeleted=0 AND groupidkey=( select top 1 groupidkey from ReportGroups where GroupName='" + szGroup + "')")
            trvRptViewCategory.ExpandAll()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim szCategory As String = trvRptViewCategory.SelectedNode.Text
        Master.RunReportLauncher("DMAC-Menu", szCategory)
        Me.Close()
    End Sub
End Class