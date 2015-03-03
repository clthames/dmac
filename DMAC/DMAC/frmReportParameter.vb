Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmReportParameter
    Public mblnExisting = False
    Dim activeRow As Integer
    Public lstrParametersandValues As String = Nothing
    Public mstrSelectedReportName As String = Nothing
    Public lstrReportFileName As String
    Public Function GetReportParameters(ByVal pstrReportName As String, ByVal pstrReportID As String) As DataGridView
        Dim paramName As String = String.Empty
        Dim paramValue As String = String.Empty
        Dim prompt As Boolean = False
        Dim sequence As Integer
        mblnExisting = False
        Dim varType As String = String.Empty
        Dim isRequired As Boolean = False
        Dim dbField As String = String.Empty
        Dim doperator As String = String.Empty
        Dim value1 As String = String.Empty
        Dim value2 As String = String.Empty
        Dim reportIDKey As Integer
        Dim paramIDKey As Integer
        Dim lobjStatus As String
        Dim param As SqlParameter() = New SqlParameter(2) {}
        param(0) = New SqlParameter("@strReport", pstrReportName)
        param(1) = New SqlParameter("@strReportServerDB", ExcelSSGen.ReportServer.ReportServerDatabase)
        param(2) = New SqlParameter("@status", lobjStatus)
        param(2).Direction = ParameterDirection.Output
        param(2).Size = 1000
        Dim dtParam As New DataTable("ParamTable")
        'read and bind the report parameter from .rdl file
        dtParam = oExcelSS.getDataTable("uspReporting_GetReportParameter", True, param)
        If dtParam.Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(dtParam.Rows(0)(0)) Then
                If Convert.ToString(dtParam.Rows(0)(0)) <> "Invalid Object" Then
                    param = New SqlParameter(0) {}
                    param(0) = New SqlParameter("@intReportIDkey", pstrReportID)
                    Dim dt As New DataTable
                    Dim paramcount As Int16 = 0
                    dt = oExcelSS.getDataTable("select * from ReportParameters where ReportIDKey = " & pstrReportID, False)
                    If dt.Rows.Count > 0 Then
                        mblnExisting = True
                        For r As Int16 = 0 To dt.Rows.Count - 1
                            With dgvParameters
                                If Not IsDBNull(dt.Rows(r)("Name").ToString) Then
                                    paramName = dt.Rows(r)("Name").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("Sequence").ToString) Then
                                    sequence = dt.Rows(r)("Sequence").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("DataType").ToString) Then
                                    varType = dt.Rows(r)("DataType").ToString
                                End If

                                If Not IsDBNull(dt.Rows(r)("DbField").ToString) Then
                                    dbField = dt.Rows(r)("DbField").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("DefaultOperator").ToString) Then
                                    doperator = dt.Rows(r)("DefaultOperator").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("DefaultValue1").ToString) Then
                                    value1 = dt.Rows(r)("DefaultValue1").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("reportIDKey").ToString) Then
                                    reportIDKey = dt.Rows(r)("reportIDKey").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("ParameterIDKey").ToString) Then
                                    paramIDKey = dt.Rows(r)("ParameterIDKey").ToString
                                End If
                                Dim paramReportName As String = String.Empty
                                If dtParam.Rows.Count > 0 Then
                                    paramReportName = Convert.ToString(dtParam(paramcount)(0))
                                End If
                                paramcount += 1
                                .Rows.Add(paramReportName, varType, doperator, value1)
                            End With
                        Next
                    Else
                        Dim paramReportName As String = String.Empty
                        If dtParam.Rows.Count > 0 Then
                            For i As Int16 = 0 To dtParam.Rows.Count - 1
                                paramReportName = Convert.ToString(dtParam(i)(0))
                                With dgvParameters
                                    .Rows.Add(paramReportName, varType, "", "")
                                End With
                            Next
                        End If
                    End If
                    Dim paramReportName1 As String = String.Empty
                    If dtParam.Rows.Count > 0 Then
                        For i As Int16 = 0 To dtParam.Rows.Count - 1
                            Dim nf As Boolean = False
                            paramReportName1 = Convert.ToString(dtParam(i)(0))
                            For x As Int16 = 0 To dgvParameters.Rows.Count - 1
                                If Not String.IsNullOrEmpty(dgvParameters.Rows(x).Cells(0).Value) Then
                                    If dgvParameters.Rows(x).Cells(0).Value = paramReportName1 Then
                                        nf = True
                                    End If
                                End If
                            Next
                            If Not nf Then
                                dgvParameters.Rows.Add(paramReportName1, varType, "", "")
                            End If
                        Next
                    End If
                Else
                    MessageBox.Show("Check the Report definition/Connection Parameters :", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else
            MessageBox.Show("No default Parameters Found :", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return dgvParameters
    End Function
    Public Sub LoadReports(ByRef pobjtreeview As TreeView)
        Try

            Dim lobjDataTable As DataTable = Nothing
            lobjDataTable = oExcelSS.getDataTable("select rep.ReportIDKey,rep.GroupIDKey,rep.CategoryIDKey,rep.ReportID,rep.ReportFileName,grp.GroupName,cat.CategoryName from ReportDefs rep,ReportGroups grp,ReportCategories cat where   (rep.GroupIDKey=grp.GroupIDKey and rep.CategoryIDKey=cat.CategoryIDKey)", False)
            If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                For Each lobjRow As DataRow In lobjDataTable.Rows
                    Dim lobjParentTreeNode As TreeNode = Nothing
                    Dim lobjChildnode As TreeNode = Nothing
                    Dim lobjChildNode2 As New TreeNode()
                    lobjParentTreeNode = New TreeNode()
                    lobjParentTreeNode.Text = lobjRow(5).ToString()
                    lobjParentTreeNode.Name = lobjRow(5).ToString()
                    If pobjtreeview.Nodes.Find(lobjRow(5).ToString(), False).Length >= 1 Then
                        lobjParentTreeNode = pobjtreeview.Nodes.Item(lobjRow(5).ToString())
                        If lobjParentTreeNode.Nodes.Find(lobjRow(6).ToString(), False).Length >= 1 Then
                            lobjChildnode = lobjParentTreeNode.Nodes.Item(lobjRow(6).ToString())
                            lobjChildNode2 = New TreeNode
                            lobjChildNode2.Text = lobjRow(4).ToString
                            lobjChildNode2.Name = lobjRow(3).ToString
                            lobjChildNode2.Tag = lobjRow
                            lobjChildnode.Nodes.Add(lobjChildNode2)
                        Else
                            lobjChildnode = New TreeNode()
                            lobjChildnode.Text = lobjRow(6).ToString
                            lobjChildnode.Name = lobjRow(6).ToString
                            lobjChildnode.Tag = lobjRow
                            lobjChildNode2 = New TreeNode
                            lobjChildNode2.Text = lobjRow(4).ToString
                            lobjChildNode2.Name = lobjRow(3).ToString
                            lobjChildNode2.Tag = lobjRow
                            lobjChildnode.Nodes.Add(lobjChildNode2)
                            lobjParentTreeNode.Nodes.Add(lobjChildnode)
                        End If

                    Else

                        lobjChildnode = New TreeNode()
                        lobjChildnode.Text = lobjRow(6).ToString
                        lobjChildnode.Name = lobjRow(6).ToString
                        lobjChildnode.Tag = lobjRow

                        lobjChildNode2 = New TreeNode
                        lobjChildNode2.Text = lobjRow(3).ToString
                        lobjChildNode2.Name = lobjRow(3).ToString
                        lobjChildNode2.Tag = lobjRow
                        lobjChildnode.Nodes.Add(lobjChildNode2)
                        lobjParentTreeNode.Nodes.Add(lobjChildnode)
                        pobjtreeview.Nodes.Add(lobjParentTreeNode)
                    End If
                Next
            End If
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub trvwReports_AfterSelect_1(sender As Object, e As TreeViewEventArgs) Handles trvwReports.AfterSelect
        Try

            ' cmbDataType.Visible = False
            ' cmbOperator.Visible = False
            If dgvParameters.Rows.Count > 0 Then
                dgvParameters.Rows.Clear()
            End If
            If e.Node.Nodes.Count = 0 Then
                GetReportParameters(e.Node.Name, DirectCast(e.Node.Tag, System.Data.DataRow)(0))
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("frmParameters frmParameters_Load ##" + ex.Message.ToString())
            MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "New Code"
    Private Sub ShowCombobox(ByVal iRowIndex As Integer, ByVal iColumnIndex As Integer)
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim Width As Integer = 0
        Dim height As Integer = 0
        Dim rect As Rectangle
        rect = dgvParameters.GetCellDisplayRectangle(iColumnIndex, iRowIndex, False)
        x = rect.X + dgvParameters.Left
        y = rect.Y + dgvParameters.Top
        Width = rect.Width
        height = rect.Height
        cmbDataType.SelectedIndex = -1
        If Not String.IsNullOrEmpty(dgvParameters.Rows(iRowIndex).Cells(iColumnIndex).Value) Then
            cmbDataType.SelectedIndex = cmbDataType.FindString(dgvParameters.Rows(iRowIndex).Cells(iColumnIndex).Value.ToString)
        End If
        With cmbDataType
            .SetBounds(x, y, Width, height)
            .Visible = True
            .Focus()
        End With
    End Sub
    Private Sub ShowCombobox(ByVal iRowIndex As Integer, ByVal iColumnIndex As Integer, ByRef obj As ComboBox)

        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim Width As Integer = 0
        Dim height As Integer = 0

        Dim rect As Rectangle
        rect = dgvParameters.GetCellDisplayRectangle(iColumnIndex, iRowIndex, False)
        x = rect.X + dgvParameters.Left
        y = rect.Y + dgvParameters.Top

        Width = rect.Width
        height = rect.Height
        obj.SelectedIndex = -1
        If Not String.IsNullOrEmpty(dgvParameters.Rows(iRowIndex).Cells(iColumnIndex).Value) Then
            obj.SelectedIndex = obj.FindString(dgvParameters.Rows(iRowIndex).Cells(iColumnIndex).Value.ToString)
        End If
        With obj
            .SetBounds(x, y, Width, height)
            .Visible = True
            .Enabled = True
            .Focus()
            .BringToFront()
        End With
    End Sub
#End Region

    Private Sub dgvParameters_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParameters.CellClick
        Try
            'cmbDataType.Visible = False
            'cmbOperator.Visible = False
            If dgvParameters.Columns(e.ColumnIndex).HeaderText = "Type" Then
                activeRow = e.RowIndex
                With dgvParameters
                    ShowCombobox(.CurrentRow.Index, .CurrentCell.ColumnIndex, cmbDataType)
                    'SendKeys.Send("{F4}")
                End With
            ElseIf dgvParameters.Columns(e.ColumnIndex).HeaderText = "Operator" Then
                activeRow = e.RowIndex
                With dgvParameters
                    ShowCombobox(.CurrentRow.Index, .CurrentCell.ColumnIndex, cmbOperator)
                    ' SendKeys.Send("{F4}")
                End With
            Else
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvParameters_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvParameters.UserDeletingRow
        If MsgBox("Are you sure to Remove the parameter [" & e.Row.Cells(0).Value.ToString & "] from the list?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Report Tool") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub dgvParameters_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvParameters.CellBeginEdit
        Try
            If e.ColumnIndex = 0 Then
                e.Cancel = True
            Else
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub SaveReportParameters()
        Try

            Dim bs As New BindingSource
            bs.DataSource = dgvParameters.DataSource
            Dim dt As New DataTable
            dt = DirectCast(bs.DataSource, DataTable)
            If oExcelSS.bulkSave(dgvParameters, 1, DirectCast(trvwReports.SelectedNode.Tag, System.Data.DataRow)(0).ToString, "", mblnExisting) Then
                MsgBox("Parameter(s) Saved successfully")
                ''Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub AddItemstoCombobox(ByVal pobjCombobox As ComboBox)
        pobjCombobox.Items.Clear()
        pobjCombobox.Items.AddRange({"All", "=", ">", "<", ">=", "<=", "Like", "Not Like", "In", "Not In", "Between"})
    End Sub

    Private Sub cmbDataType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType.SelectedIndexChanged
        Try
            dgvParameters.Rows(dgvParameters.SelectedCells.Item(0).RowIndex).Cells(1).Value = Trim(cmbDataType.Text)

            Select Case Trim(cmbDataType.Text)
                Case "Text"
                    cmbOperator.Items.Clear()
                    cmbOperator.Items.AddRange({"All", "=", "Like", "Not Like", "In", "Not In", "Between"})
                Case "Date"
                    cmbOperator.Items.Clear()
                    cmbOperator.Items.AddRange({"=", ">", "<", ">=", "<=", "Like", "Not Like", "In", "Not In", "Between"})
                Case "Boolean"
                    cmbOperator.Items.Clear()
                    cmbOperator.Items.AddRange({"="})
                Case "Integer"
                    cmbOperator.Items.Clear()
                    cmbOperator.Items.AddRange({"=", ">", "<", ">=", "<=", "Like", "Not Like", "In", "Not In", "Between"})
                Case "Float"
                    cmbOperator.Items.Clear()
                    cmbOperator.Items.AddRange({"=", ">", "<", ">=", "<=", "Like", "Not Like", "In", "Not In", "Between"})
            End Select

            activeRow = 0

        Catch ex As Exception
            oExcelSS.ErrorLog("frmParameters cmbDataType_Leave ##" + ex.Message.ToString())
            MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbOperator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperator.SelectedIndexChanged
        Try
            dgvParameters.Rows(dgvParameters.SelectedCells.Item(0).RowIndex).Cells(2).Value = Trim(cmbOperator.Text)
            If Trim(cmbOperator.Text).ToUpper = "BETWEEN" Then
                dgvParameters.Rows(dgvParameters.SelectedCells.Item(0).RowIndex).Cells(4).ReadOnly = False
            Else
                dgvParameters.Rows(dgvParameters.SelectedCells.Item(0).RowIndex).Cells(4).ReadOnly = True
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("frmParameters cmbOperator_Leave ##" + ex.Message.ToString())
            MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmReportParameter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = "Esc" Then


        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            Dim lstrValue As String = Nothing
            For Each lobjRow In dgvParameters.Rows
                If CType(lobjRow, DataGridViewRow).Cells(1).Value.ToString = "Date" Then
                    If CType(lobjRow, DataGridViewRow).Cells(2).Value.ToString = "Between" Then
                        lstrValue = GettheDate(CType(lobjRow, DataGridViewRow).Cells(3).Value.ToString)
                        lstrValue = lstrValue + "and" + GettheDate(CType(lobjRow, DataGridViewRow).Cells(3).Value.ToString)
                    Else

                        lstrValue = GettheDate(CType(lobjRow, DataGridViewRow).Cells(3).Value.ToString)

                    End If
                Else
                    lstrValue = CType(lobjRow, DataGridViewRow).Cells(3).Value.ToString
                End If
                If lstrParametersandValues Is Nothing Then
                    lstrParametersandValues = CType(lobjRow, DataGridViewRow).Cells(0).Value.ToString + CType(lobjRow, DataGridViewRow).Cells(2).Value.ToString + lstrValue
                Else
                    lstrParametersandValues = lstrParametersandValues + "&" + CType(lobjRow, DataGridViewRow).Cells(0).Value.ToString + CType(lobjRow, DataGridViewRow).Cells(2).Value.ToString + lstrValue
                End If
            Next
            mstrSelectedReportName = trvwReports.SelectedNode.Text
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function GettheDate(ByVal pstrValue As String) As String
        Try
            Dim lobDate As System.DateTime = Nothing
            Dim pattern As String = "(day|month|year)"
            Dim lstrCounter As String = Nothing
            Dim pstrComparevalue As String
            Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
            Dim lobjMatch As Match = rgx.Match(pstrValue)
            pstrComparevalue = lobjMatch.Groups(0).Value
            If lobjMatch IsNot Nothing Then
                pattern = "\d*"
                rgx = New Regex(pattern, RegexOptions.IgnoreCase)
                lobjMatch = rgx.Match(pstrValue)
                lstrCounter = lobjMatch.Groups(0).Value
                If pstrValue.ToUpper().EndsWith("AGO") Then

                    Select Case pstrComparevalue.ToUpper

                        Case "DAYS", "DAY"
                            lobDate = DateAndTime.Now.AddDays(CType(lstrCounter, Int32))
                        Case "MONTHS", "MONTH"
                            lobDate = DateAndTime.Now.AddMonths(CType(lstrCounter, Int32))
                        Case "YEARS", "YEAR"
                            lobDate = DateAndTime.Now.AddYears(CType(lstrCounter, Int32))
                    End Select

                ElseIf pstrValue.ToUpper().EndsWith("FROMNOW") Then
                    Select Case pstrComparevalue.ToUpper

                        Case "DAYS", "DAY"
                            lobDate = DateAndTime.Now.AddDays(-CType(lstrCounter, Int32))
                        Case "MONTHS", "MONTH"
                            lobDate = DateAndTime.Now.AddMonths(-CType(lstrCounter, Int32))
                        Case "YEARS", "YEAR"
                            lobDate = DateAndTime.Now.AddYears(-CType(lstrCounter, Int32))

                    End Select
                End If
            End If
            If lobDate = Nothing Then
                Select Case pstrValue.Trim(" ").ToUpper
                    Case "LASTWEEK"
                        lobDate = DateAndTime.Now.AddDays(-7)
                    Case "LASTYEAR"
                        lobDate = DateAndTime.Now.AddYears(-1)
                    Case "YESTERDAY"
                        lobDate = DateAndTime.Now.AddDays(-1)
                    Case "LASTMONTH"
                        lobDate = DateAndTime.Now.AddMonths(-1)
                    Case "NEXTMONTH"
                        lobDate = DateAndTime.Now.AddMonths(1)
                    Case "TODAY"
                        Return (DateAndTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
                    Case "TOMORROW"
                        lobDate = DateAndTime.Now.AddDays(1)
                    Case "NEXTYEAR"
                        lobDate = DateAndTime.Now.AddYears(1)
                End Select

            End If
            Return (lobDate.ToString("dd/MM/yyyy HH:mm:ss"))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report Parameters")
        End Try
        Return Nothing
    End Function

    Private Sub dgvParameters_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParameters.CellContentClick

    End Sub
End Class