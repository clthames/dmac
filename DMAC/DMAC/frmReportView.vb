Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Public Class frmReportView
    Dim _where As String = String.Empty
    Dim _name As String = String.Empty
    Dim _department As String = String.Empty
    Dim _operand As String = String.Empty
    Dim _reportFileName As String = String.Empty
    Dim _externalparameter As String = String.Empty
    Dim _grid As New DataGridView
    Public Sub New(ByVal name As String, ByVal department As String, ByVal operand As String, ByVal reportFileName As String)
        InitializeComponent()
        _name = name
        _department = department
        _operand = operand
        _reportFileName = reportFileName
    End Sub
    Public Sub New(ByVal reportFileName As String, ByVal gridObject As DataGridView, ByVal externalParameter As String)
        InitializeComponent()
        _reportFileName = reportFileName
        _grid = gridObject
        _externalparameter = externalParameter
    End Sub
    Public Sub New(ByVal whereClause As String, ByVal reportFileName As String)
        InitializeComponent()
        _where = whereClause
        _reportFileName = reportFileName
    End Sub
    Private Sub frmReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet("DataSet1")
        Try
            Dim credentialCatch As New System.Net.CredentialCache()
            Dim networkcredential As New System.Net.NetworkCredential
            networkcredential.UserName = ExcelSSGen.ReportServer.UserName
            networkcredential.Password = ExcelSSGen.Main.DecodedPassword(ExcelSSGen.ReportServer.Password)
            rptViewer.ProcessingMode = ProcessingMode.Remote
            rptViewer.ServerReport.ReportServerCredentials.NetworkCredentials = networkcredential
            rptViewer.ServerReport.ReportServerUrl = New Uri(ExcelSSGen.ReportServer.ReportServerPath)
            rptViewer.ServerReport.ReportPath = "/" & ExcelSSGen.ReportServer.ReportPath & "/" & _reportFileName
            rptViewer.ShowCredentialPrompts = False
            rptViewer.PromptAreaCollapsed = True
            Dim paramList As New List(Of ReportParameter)()
            Dim parName As String = String.Empty
            Dim parValue As String = String.Empty
            For r As Integer = 0 To _grid.Rows.Count - 1
                For c As Integer = 0 To _grid.Columns.Count - 1
                    If _grid.Columns.Count <> 1 Then
                        If Not _grid.Rows(r).Cells(c).Value Is Nothing Then
                            If c < 2 Then
                                If Not String.IsNullOrEmpty(_grid.Rows(r).Cells(c).Value.ToString()) Then
                                    parName = _grid.Rows(r).Cells(2).Value.ToString() 'original param name
                                    parValue = _grid.Rows(r).Cells(1).Value.ToString() 'value
                                    If parName <> "No Parameters" Then
                                        paramList.Add(New ReportParameter(parName, parValue, False))
                                    End If
                                End If
                            End If
                            Exit For
                        End If
                    End If
                Next
            Next
            rptViewer.ServerReport.SetParameters(paramList)
            rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
            Me.rptViewer.RefreshReport()
            Me.UpdateZOrder()
            Me.BringToFront()
            Me.TopMost = True
        Catch ex As Exception
            oExcelSS.ErrorLog("frmReportView_Load Error##" + ex.Message.ToString())
        End Try
    End Sub
End Class