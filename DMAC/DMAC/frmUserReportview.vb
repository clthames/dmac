Imports System.Data.SqlClient
Public Class frmUserReportview
    Dim _reportID As String = String.Empty
    Dim reportName As String = String.Empty
    Dim rsd As New ReportingServerData
    Dim emptyparam As Boolean = False
    Dim _externalParam As String
    Public Sub New(ByVal reportID As String)
        InitializeComponent()
        _reportID = reportID
    End Sub
    Private Sub frmUserReportview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dt As DataTable = rsd.getReportDetails(_reportID)
            Dim pdt As DataTable = rsd.getReportExternalParameter(_reportID)
            If pdt.Rows.Count > 0 Then
                If Not IsDBNull(pdt.Rows(0)(0)) Then
                    _externalParam = Convert.ToString(pdt.Rows(0)(0))
                Else
                    _externalParam = String.Empty
                End If
            End If
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    reportName = row("ReportName")
                    lblReport.Text = "Report Name : " & row("ReportName")
                    If IsDBNull(row(0)) Then
                        emptyparam = True
                    ElseIf row(0) = "" Then
                        emptyparam = True
                    End If
                Next
                If Not emptyparam Then
                    dgvParameter.DataSource = dt
                    dgvParameter.Columns(0).Width = 250
                    dgvParameter.Columns(1).Width = 220
                    dgvParameter.Columns(2).Visible = False
                    dgvParameter.Columns(3).Visible = False
                    dgvParameter.Columns(4).Visible = False
                    dgvParameter.Columns(5).Visible = False
                    dgvParameter.Columns(6).Visible = False
                Else
                    '    setNoParameter()
                    Me.Close()
                    Me.Dispose()
                    btnSelect_Click(sender, e)
                End If
            Else
                'setNoParameter()
                Me.Close()
                Me.Dispose()
                btnSelect_Click(sender, e)
            End If
            'btnSelect.Enabled = True
        Catch ex As Exception
            Dim functions As New Functions
            functions.ErrorLog("frmUserReportview_Load ##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub dgvParameter_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvParameter.CellEnter
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv(e.ColumnIndex, e.RowIndex).EditType IsNot Nothing Then
            If dgv(e.ColumnIndex, e.RowIndex).EditType.ToString() = "System.Windows.Forms.DataGridViewComboBoxEditingControl" Then
                SendKeys.Send("{F4}")
            End If
        End If
    End Sub
    Private Sub setNoParameter()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("Prompt Text", GetType(String))
            Dim dr As DataRow = dt.Rows.Add
            dr.Item(0) = "No Parameters"
            dgvParameter.DataSource = dt
            dgvParameter.Columns(0).Width = dgvParameter.Width - 45
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim namevalue As String = String.Empty
        Dim operand As String = String.Empty
        Dim varOperator As String = String.Empty
        Dim varColumName As String = String.Empty
        Dim isRequired As Boolean = False
        Try
            For Each row As DataGridViewRow In dgvParameter.Rows
                If row.Cells().Count > 1 Then
                    If row.Cells("Required").Value.ToString() = True AndAlso row.Cells("value").Value.ToString() = "" Then
                        row.DefaultCellStyle.BackColor = Color.FromArgb(236, 236, 255)
                        isRequired = True
                    End If
                End If
            Next
            If isRequired Then
                MsgBox("Please enter valid values to view report")
                Exit Sub
            End If
            Dim reportviewer As New frmReportView(reportName, dgvParameter, _externalParam)
            reportviewer.Show()
        Catch ex As Exception
            Dim functions As New Functions
            functions.ErrorLog("frmReportViewUser_Load Error# " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub dgvParameter_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvParameter.CellBeginEdit
        Try
            If e.ColumnIndex = 0 Then
                e.Cancel = True
            Else
                If IsDBNull(dgvParameter.CurrentRow.Cells(0)) Then
                    e.Cancel = True
                End If
                If dgvParameter.CurrentRow.Cells(0).Value = "No Parameters" Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub dgvParameter_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvParameter.UserDeletingRow
        e.Cancel = True
    End Sub
    Private Sub trvRptViewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgvParameter.DataSource = Nothing
    End Sub


    Private Sub bindReportParameters()
        Try
            Dim dt As New DataTable("param")
            Dim sparam As SqlParameter() = New SqlParameter(2) {}
            sparam(0) = New SqlParameter("@strReport", _reportID)
            sparam(1) = New SqlParameter("@strReportServerDB", ReportServer.ReportServerDatabase)
            sparam(2) = New SqlParameter("@status", "")
            sparam(2).DbType = DbType.String
            sparam(2).Size = 1000
            sparam(2).Direction = ParameterDirection.Output
            dt = New DataLayer().getDataTable("uspReporting_GetReportParameter", True, sparam)
            If dt.Rows.Count > 0 Then
                Dim dtTmp As New DataTable()
                dtTmp.Columns.Add("Prompt", GetType(String))
                dtTmp.Columns.Add("Value", GetType(String))
                dtTmp.Columns.Add("Parameter", GetType(String))
                For Each row As DataRow In dt.Rows
                    Dim dr As DataRow = dtTmp.NewRow()
                    dr(0) = row("Prompt")
                    dr(1) = ""
                    dr(2) = row("ReportParameterName")
                    dtTmp.Rows.Add(dr)
                Next
                dgvParameter.DataSource = dtTmp
                dgvParameter.Columns(0).Width = 250
                dgvParameter.Columns(1).Width = 150
                dgvParameter.Columns(2).Visible = False
            Else
                setNoParameter()
            End If
            btnSelect.Enabled = True
        Catch ex As Exception
            Dim functions As New Functions
            functions.ErrorLog("frmUserReportview --> bindReportParameters ##" + ex.Message.ToString())
        End Try
    End Sub




    Private Sub pnlBottom_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlBottom.Paint

    End Sub
End Class