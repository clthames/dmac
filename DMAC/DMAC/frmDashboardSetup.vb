Public Class frmDashboardSetup

    Public dbCheckedGD As New DataTable
    Public selIndex As Integer
    Public someChange As Boolean = False
    Public isLoading As Boolean = False

    Private Sub frmDashboardSetup_Load(sender As Object, e As EventArgs) Handles Me.Load
        isLoading = True
        Dim dbPermittedGD As New DataTable
        dbPermittedGD = oExcelSS.dtPermission.Select("ModuleID='db'").CopyToDataTable()
        GetGadgetsInfo()
        lvGadgets.Items.Clear()
        cbDashboardLogin.Checked = False
        For Each r As DataRow In dbPermittedGD.Rows
            Dim it As New ListViewItem
            it.Text = r(1).ToString
            it.Name = r(6).ToString
            it.Checked = False
            For Each dr As DataRow In dbCheckedGD.Rows
                If dr(3).ToString.Trim.ToLower = r(0).ToString.Trim.ToLower Then
                    it.Checked = True
                End If
                If dr(2) = 0 Then
                    cbDashboardLogin.Checked = True
                End If
            Next
            lvGadgets.Items.Add(it)
        Next
        isLoading = False
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub lvGadgets_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lvGadgets.ItemChecked
        If Not isLoading Then someChange = True
        If e.Item.Checked And e.Item.Selected = True Then
            cbAutoRefresh.Enabled = True
            If cbAutoRefresh.Checked Then
                cboMinutes.Enabled = True
            Else
                cboMinutes.Enabled = False
            End If
            selIndex = e.Item.Index
        Else
            cbAutoRefresh.Enabled = False
        End If
    End Sub
    Private Sub lvGadgets_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvGadgets.ItemSelectionChanged
        If Not isLoading And someChange Then
            If MsgBox("Do you want to update your changes first?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim opd As New System.EventArgs
                btnUpdate_Click(Me, opd)
            End If
            someChange = False
        End If
        If lvGadgets.Items(e.ItemIndex).Checked Then
            isLoading = True
            cbAutoRefresh.Enabled = True
            GetGadgetsInfo()
            cboMinutes.SelectedIndex = -1
            For Each r As DataRow In dbCheckedGD.Rows
                If r(2) = lvGadgets.Items(e.ItemIndex).Name Then
                    If r(1) > 0 Then
                        cbAutoRefresh.Checked = True
                        Select Case r(1)
                            Case Is = 5
                                cboMinutes.SelectedIndex = 0
                            Case Is = 15
                                cboMinutes.SelectedIndex = 1
                            Case Is = 30
                                cboMinutes.SelectedIndex = 2
                            Case Is = 60
                                cboMinutes.SelectedIndex = 3
                        End Select
                    Else
                        cbAutoRefresh.Checked = False
                    End If
                End If
            Next
            If cbAutoRefresh.Checked Then
                cboMinutes.Enabled = True
            Else
                cboMinutes.Enabled = False
            End If
            isLoading = False
        Else
            isLoading = True
            cbAutoRefresh.Enabled = False
            cbAutoRefresh.Checked = False
            cboMinutes.SelectedIndex = -1
            isLoading = False
        End If
        selIndex = e.ItemIndex
    End Sub
    Public Sub GetGadgetsInfo()
        dbCheckedGD.Clear()
        Dim p As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(0) {}
        p(0) = New System.Data.SqlClient.SqlParameter("@UserID", oExcelSS.ActiveUserID)
        dbCheckedGD = oExcelSS.getDataTable("uspDashboard_GetGadgets", True, p)
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        GetGadgetsInfo()
        Dim strQuery As String = "uspDashboard_InsertGadgets"
        For Each r As DataRow In dbCheckedGD.Rows
            If r(2) = lvGadgets.Items(selIndex).Name Then
                strQuery = "uspDashboard_UpdateGadgets"
            End If
        Next
        If lvGadgets.Items(selIndex).Checked Then
            Dim f As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(2) {}
            f(0) = New System.Data.SqlClient.SqlParameter("@UserID", oExcelSS.ActiveUserID)
            f(1) = New System.Data.SqlClient.SqlParameter("@AutoRefresh", IIf(cboMinutes.SelectedItem = Nothing, 0, cboMinutes.SelectedItem))
            f(2) = New System.Data.SqlClient.SqlParameter("@AccessID", lvGadgets.Items(selIndex).Name)
            oExcelSS.getDataTable(strQuery, True, f)
        Else
            Dim f As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(2) {}
            f(0) = New System.Data.SqlClient.SqlParameter("@UserID", oExcelSS.ActiveUserID)
            f(1) = New System.Data.SqlClient.SqlParameter("@AutoRefresh", IIf(cboMinutes.SelectedItem = Nothing, 0, cboMinutes.SelectedItem))
            f(2) = New System.Data.SqlClient.SqlParameter("@AccessID", lvGadgets.Items(selIndex).Name)
            oExcelSS.getDataTable("uspDashboard_DeleteGadgets", True, f)
        End If
        If cbDashboardLogin.Checked Then
            Dim l As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(2) {}
            l(0) = New System.Data.SqlClient.SqlParameter("@UserID", oExcelSS.ActiveUserID)
            l(1) = New System.Data.SqlClient.SqlParameter("@AutoRefresh", IIf(cboMinutes.SelectedItem = Nothing, 0, cboMinutes.SelectedItem))
            l(2) = New System.Data.SqlClient.SqlParameter("@AccessID", lvGadgets.Items(selIndex).Name)
            oExcelSS.getDataTable("uspDashboard_UpdateDashboardatLogin", True, l)
        Else
            Dim l As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(2) {}
            l(0) = New System.Data.SqlClient.SqlParameter("@UserID", oExcelSS.ActiveUserID)
            l(1) = New System.Data.SqlClient.SqlParameter("@AutoRefresh", 100)
            l(2) = New System.Data.SqlClient.SqlParameter("@AccessID", lvGadgets.Items(selIndex).Name)
            oExcelSS.getDataTable("uspDashboard_UpdateDashboardatLogin", True, l)
        End If
        MsgBox("Dashboard Updated")
    End Sub
    Private Sub cbAutoRefresh_CheckedChanged(sender As Object, e As EventArgs) Handles cbAutoRefresh.CheckedChanged
        If Not isLoading Then someChange = True
        If cbAutoRefresh.Checked Then
            cboMinutes.Enabled = True
        Else
            cboMinutes.Enabled = False
        End If
    End Sub
    Private Sub cboMinutes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMinutes.SelectedIndexChanged
        If Not isLoading Then someChange = True
    End Sub

End Class