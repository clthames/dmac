Imports System.Data.SqlClient
Public Class frmProgramList
    Dim currentMode As String
    Public Sub New(ByVal currentMode As String)
        InitializeComponent()
        Me.currentMode = currentMode
    End Sub
    Private Sub frmProgramList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Select Case currentMode.ToLower
                Case "program"
                    Me.Text = "Program List"
                    Dim dt As New DataTable("ProgramTable")
                    dt = oExcelSS.getDataTable("uspAccess_GetProgramMenu", True)
                    If dt.Rows.Count > 0 Then
                        'Update datatable with divisions
                        Dim moduleid As String = ""
                        Dim r1 As DataRow
                        Dim dtN As New DataTable
                        dtN.Columns.Add("Menu")
                        dtN.Columns.Add("MenuName")
                        dtN.Columns.Add("RunProgram")
                        dtN.Columns.Add("ModuleID")
                        r1 = dtN.NewRow
                        r1(1) = ""
                        For x As Integer = 0 To dt.Rows.Count - 1
                            moduleid = dt.Rows(x)(3)
                            If moduleid = "inv" Then moduleid = "bcinv"
                            If Not r1(1) = moduleid Then
                                If Not x = 0 Then
                                    Dim rEmpty As DataRow
                                    rEmpty = dtN.NewRow
                                    rEmpty(0) = " "
                                    rEmpty(1) = " "
                                    rEmpty(2) = " "
                                    rEmpty(3) = " "
                                    dtN.Rows.Add(rEmpty)
                                End If
                                Select Case moduleid.Trim
                                    Case "all"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--GENERAL--"
                                        r4(1) = "all"
                                        r1(1) = "all"
                                        dtN.Rows.Add(r4)
                                    Case "e4"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--ESTIMATIONS--"
                                        r4(1) = "e4"
                                        r1(1) = "e4"
                                        dtN.Rows.Add(r4)
                                    Case "fax"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--FAX--"
                                        r4(1) = "fax"
                                        r1(1) = "fax"
                                        dtN.Rows.Add(r4)
                                    Case Is = "fgi"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--FGI--"
                                        r4(1) = "fgi"
                                        r1(1) = "fgi"
                                        dtN.Rows.Add(r4)
                                    Case Is = "bcinv"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--INVENTORY--"
                                        r4(1) = "inv"
                                        r1(1) = "bcinv"
                                        dtN.Rows.Add(r4)
                                    Case Is = "jc"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--JOB COSTING--"
                                        r4(1) = "jc"
                                        r1(1) = "jc"
                                        dtN.Rows.Add(r4)
                                    Case Is = "oe"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--ORDERS--"
                                        r4(1) = "oe"
                                        r1(1) = "oe"
                                        dtN.Rows.Add(r4)
                                    Case Is = "pp"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--PRODUCTION PLANNER--"
                                        r4(1) = "pp"
                                        r1(1) = "pp"
                                        dtN.Rows.Add(r4)
                                    Case Is = "qb"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--QUICKBOOKS--"
                                        r4(1) = "qb"
                                        r1(1) = "qb"
                                        dtN.Rows.Add(r4)
                                    Case Is = "ship"
                                        Dim r4 As DataRow
                                        r4 = dtN.NewRow
                                        r4(0) = "--SHIPPING--"
                                        r4(1) = "ship"
                                        r1(1) = "ship"
                                        dtN.Rows.Add(r4)
                                End Select
                                Dim r2 As DataRow
                                r2 = dtN.NewRow
                                r2(0) = dt.Rows(x)(0)
                                r2(1) = dt.Rows(x)(1)
                                r2(2) = dt.Rows(x)(2)
                                r2(3) = dt.Rows(x)(3)
                                dtN.Rows.Add(r2)
                            Else
                                Dim r3 As DataRow
                                r3 = dtN.NewRow
                                r3(0) = dt.Rows(x)(0)
                                r3(1) = dt.Rows(x)(1)
                                r3(2) = dt.Rows(x)(2)
                                r3(3) = dt.Rows(x)(3)
                                dtN.Rows.Add(r3)
                            End If
                        Next
                        lstPrograms.DataSource = dtN
                        lstPrograms.DisplayMember = "Menu"
                        lstPrograms.ValueMember = "MenuName"

                    End If
                Case "report"
                    Me.Text = "Report List"
                    Dim dt As New DataTable("ReportTable")
                    dt = oExcelSS.getDataTable("uspReporting_GetActiveReports", True)
                    If dt.Rows.Count > 0 Then
                        lstPrograms.DataSource = dt
                        lstPrograms.DisplayMember = "ReportFileName"
                        lstPrograms.ValueMember = "ReportIDKey"
                    End If
                Case "custom"
            End Select
        Catch ex As Exception
            oExcelSS.ErrorLog("frmProgramList --> frmProgramList_Load Error## " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub frmProgramList_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' e.Cancel = True
    End Sub
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            If lstPrograms.Items.Count > 0 Then
                If lstPrograms.SelectedValue.ToString <> "" Then
                    Debug.Print(currentMode.ToLower)
                    If currentMode.ToLower <> "report" Then
                        oExcelSS.selectedShortcutFromList = lstPrograms.Text
                        oExcelSS.selectedShortcutFromListTag = lstPrograms.SelectedValue.ToString
                    Else
                        oExcelSS.selectedShortcutFromList = lstPrograms.Text
                        oExcelSS.selectedShortcutFromListTag = lstPrograms.SelectedValue 'lstPrograms.Text
                    End If
                End If
            End If
            Me.Close()
        Catch ex As Exception
            oExcelSS.ErrorLog("frmProgramList --> btnOk_Click Error## " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub lstPrograms_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPrograms.DoubleClick
        Try
            If DirectCast(sender, ListBox).SelectedValue.ToString <> "" Then
                If Not lstPrograms.GetItemText(lstPrograms.SelectedItem).StartsWith("-") Or lstPrograms.GetItemText(lstPrograms.SelectedItem).StartsWith(" ") Then
                    btnOk_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("lstPrograms_DoubleClick Error## " & ex.Message.ToString)
        End Try
    End Sub
    Private Sub lstPrograms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPrograms.SelectedIndexChanged
        If lstPrograms.GetItemText(lstPrograms.SelectedItem).StartsWith("-") Or lstPrograms.GetItemText(lstPrograms.SelectedItem).StartsWith(" ") Then
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If
    End Sub
End Class