Imports System.Windows.Forms
Imports System.IO
Imports vbAccelerator.Components.Controls

Public Class Master
    Private Sub closeOpenForms()
        For Each ChildForm As Form In Me.MdiChildren
            If ChildForm.Name <> "ChartContainer" Then
                ChildForm.Close()
            End If
        Next
    End Sub
    Private Sub closeOpenFormsAfterLogin()
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private Sub GetEnabledMenues(ByVal Current As ToolStripItem, ByRef enabledMenues As List(Of ToolStripItem))
        If Current.Enabled Then
            enabledMenues.Add(Current)
        End If
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetEnabledMenues(menu, enabledMenues)
            Next
        End If
    End Sub
    Private Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
        menues.Add(Current)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetMenues(menu, menues)
            Next
        End If
    End Sub
    Private Sub EnableMenuesAsLicense(ByVal Current As ToolStripItem)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                Dim menuname As String = String.Empty
                menuname = menu.Name
                Dim enable As Boolean = False
                For Each obj As Object In menuArray
                    If obj.getMenuName().ToString().ToLower = menu.Name.ToLower Then
                        menu.Enabled = True
                    End If
                    Select Case menu.Name.ToLower
                        Case "tsmfile", "tsmexit", "tsmTopCustomer", "tsmestimate",
                                "tsmsales", "tsmproduction", "tsmbilling", "tsmpurchasing",
                                "tsminventory", "tsmpackagingshipping", "tsmfinishedgoodsinventory",
                                "tsmjobcosting", "tsmreports", "tsmmisc", "tsmproductionpcc",
                                "tsmfilechangecompany", "tsmfilebackupcompany", "tsmfileprintersetup",
                                "tsmfilecm"
                            menu.Enabled = True
                    End Select
                Next
                EnableMenuesAsLicense(menu)
            Next
        End If
    End Sub
    Private Sub DisableMenus(Optional ByVal disable As Boolean = False)
        Dim menues As New List(Of ToolStripItem)
        Dim tools As New List(Of ToolStripItem)
        For Each t As ToolStripItem In MenuStrip.Items
            GetMenues(t, menues)
        Next
        For Each l As ToolStripItem In ToolStrip.Items
            GetMenues(l, tools)
        Next
        For Each tool As ToolStripItem In menues
            If tool.Name.Trim.EndsWith("Top") Then

            Else
                If tool.Name.Trim.ToLower().Contains("help") Then
                ElseIf tool.Name.Trim.ToLower().Contains("file") Then
                    ' tool.Enabled = True
                Else
                    tool.Enabled = disable
                End If

            End If
        Next
        For Each tool As ToolStripItem In tools
            If tool.Name.Trim.EndsWith("Top") Then

            Else
                If tool.Name.Trim.ToLower().Contains("help") Then
                ElseIf tool.Name.Trim.ToLower().Contains("file") Then
                    ' tool.Enabled = True
                Else
                    tool.Enabled = disable
                End If

            End If
        Next
    End Sub
    Private Sub Master_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            tsLogintime.Text = "   " & oExcelSS.logintime
            '---------------- Binding the Customize Outlook button
            If oExcelSS.isOutlookButtonBinded = True Then
                OutlookBar1.Buttons.Clear()
                For Each item As Object In oExcelSS.arrayOutlookButtons
                    Dim obj As Object = item.getButton
                    OutlookBar1.Buttons.Add(Convert.ToString(item.getButtonShortcut), item.shortcutType, item.getShortcutFor, item.getLinkTo, obj.Image)
                    OutlookBar1.Height = OutlookBar1.Height + 35
                Next
                oExcelSS.isOutlookButtonBinded = False
                oExcelSS.arrayOutlookButtons = Nothing
            End If
            '-------------------- 
            If oExcelSS.isMenuBinded = False Then
                Exit Sub
            End If
            tsCurrentUser.Text = "Welcome, You are logged " & vbCr & "in as " & oExcelSS.ActiveUserID & "-" & oExcelSS.ActiveUserName
            tsActiveCompany.Text = oExcelSS.ActiveCompanyName
            lblSelectedItem.Text = oExcelSS.selectedItem
            Timer1.Start()
            If OutlookBar1.Buttons.Count <> oExcelSS.dtShortcut.Rows.Count Then
                If oExcelSS.dtShortcut.Rows.Count > 0 Then
                    OutlookBar1.Buttons.Clear()
                End If
                If oExcelSS.dtShortcut.Rows.Count > 0 Then
                    For Each drow As DataRow In oExcelSS.dtShortcut.Rows
                        Dim btnName As String = Convert.ToString(drow("ShortcutName"))
                        Dim shortcutType As String = Convert.ToString(drow("ShortcutType"))
                        Dim btnLinkFor As String = Convert.ToString(drow("ShortcutFor"))
                        Dim btnLinkto As String = Convert.ToString(drow("Linkto"))
                        Dim btIcon As Byte() = Nothing
                        If Not drow("Linkto") Is Nothing Then
                            If Not IsDBNull(drow("Icon")) Then
                                btIcon = DirectCast(drow("Icon"), Byte())
                            End If
                        End If
                        Dim obutton As New OutlookStyleControls.OutlookBarButton
                        obutton.Text = btnName
                        obutton.Tag = btnLinkFor
                        Dim ms As New MemoryStream
                        If Not btIcon Is Nothing Then
                            ms = New MemoryStream(btIcon)
                            obutton.Image = Image.FromStream(ms)
                        End If
                        If ms.Length > 0 Then
                            OutlookBar1.Buttons.Add(btnName, shortcutType, btnLinkFor, btnLinkto, Image.FromStream(ms))
                        Else
                            OutlookBar1.Buttons.Add(btnName, shortcutType, btnLinkFor, btnLinkto)
                        End If

                        OutlookBar1.Height = OutlookBar1.Height + 35
                    Next
                Else
                    OutlookBar1.Buttons.Clear()
                End If
            End If
            If oExcelSS.isMenuBinded Then
                tsmExit.Enabled = True
                Dim Menues As New List(Of ToolStripItem)
                For Each item As ToolStripItem In MenuStrip.Items
                    GetMenues(item, Menues)
                Next

                For Each row As DataRow In oExcelSS.dtPermission.Rows
                    menuArray.Add(New MenuList(Convert.ToString(row("MenuName")), Convert.ToString(row("ModuleID")), Convert.ToString(row("RunProgram"))))
                    'Toolstrip Buttons always Enabled
                    tsScreenshot.Enabled = True
                    Dim testing As String
                    testing = Convert.ToString(row("RunProgram"))
                    ToolStripButton1.Enabled = True
                    tsActiveCompany.Enabled = True
                    tsLogintime.Enabled = True
                    tsAlerts.Enabled = True
                    tsDashboard.Enabled = True
                    '============================================================
                    For Each tool As ToolStripItem In Menues
                        If (Convert.ToString(row("ModuleID")).ToLower() = "all" And tool.Name.ToLower = Convert.ToString(row("MenuName")).ToLower) Then
                            tool.Enabled = True
                        ElseIf (Convert.ToString(row("Setting")).ToLower() = "1") Then
                            tool.Enabled = True
                        ElseIf tool.Name.Trim = Convert.ToString(row("MenuName")).Trim Then
                            tool.Enabled = True
                        End If
                        Select Case Convert.ToString(row("MenuName")).ToLower
                            Case "tsmtoolsfaxstatus"
                                tsmToolsFaxStatus.Enabled = True
                                tsFaxStatus.Enabled = True
                            Case ("tsminvmm_physicalcountinput")
                                tsmInvMM.Enabled = True
                                tsmInvMM_PhysicalCountInput.Enabled = True
                            Case "tsminvmm_auditreportupdateinventory"
                                tsmInvMM.Enabled = True
                                tsmInvMM_AuditReportUpdateInventory.Enabled = True
                            Case "tsminvbru_editpaperrollfile"
                                tsmInvBRU.Enabled = True
                                tsmInvBRU_EditPaperRollFile.Enabled = True
                            Case "tsminvbru_rollweightbalance"
                                tsmInvBRU.Enabled = True
                                tsmInvBRU_RollWeightBalance.Enabled = True
                            Case "tsmjobcost_editimpressionquantity"
                                tsmJobCostingDM.Enabled = True
                                tsmJobCost_EditImpressionQuantity.Enabled = True
                            Case "tsmjob_updateoutsidepurchasematerialusage"
                                tsmJobCostingDM.Enabled = True
                                tsmJob_UpdateOutsidePurchaseMaterialUsage.Enabled = True
                            Case "tsmjob_updatemiscpaperusage"
                                tsmJobCostingDM.Enabled = True
                            Case "tsmjob_updatemiscmaterialusage"
                                tsmJobCostingDM.Enabled = True
                            Case "tsmjob_updatecartonmaterialusage"
                                tsmJobCostingDM.Enabled = True
                            Case "tsmjob_vieworeditemployeeshift"
                                tsmJobCostingDM.Enabled = True
                                tsmJob_ViewOrEditEmployeeShift.Enabled = True
                            Case "tsmjob_updatecarbonmaterialusage"
                                tsmJobCostingDM.Enabled = True
                            Case "tsmtoolq_synctodaysinvoices", "tsmtoolq_synccustomers"
                                tsmToolQuickbooks.Enabled = True
                                tsmToolQ_SyncTodaysInvoices.Enabled = True
                                tsmToolQ_SyncCustomers.Enabled = True
                            Case "tsmtoolmr_purgeorders"
                                tsmToolMonthlyRoutines.Enabled = True
                                tsmToolMR_PurgeOrders.Enabled = True
                            Case "tsmestimateform"
                                tsmEstimateForm.Enabled = True
                                tsEstimating.Enabled = True
                            Case "tsmtoolsq_synctodaysinvoices"
                                tsmToolQuickbooks.Enabled = True
                                tsmToolQ_SyncTodaysInvoices.Enabled = True
                            Case "tsmorderproduction"
                                tsOrderEntry.Enabled = True
                            Case "tsmordercreateinvoices"
                                tsInvoicing.Enabled = True
                                tsFaxStatus.Enabled = True
                                'Case "tsmshippingbl"
                                '    tsBillofLading.Enabled = True
                                'Case "tsmshippingcl"
                                '    tsmToolCartonLabels.Enabled = True
                            Case "tsminvrmiu"
                                tsInventory.Enabled = True
                            Case "tsmproductionplanner"
                                tsPPCC.Enabled = True
                            Case "tsmcustomerreports"
                                tsReports.Enabled = True
                            Case "tsmdashboardsetup"
                                tsmDashboardSetup.Enabled = True
                        End Select
                    Next
                Next
                oExcelSS.isMenuBinded = False
            End If
            If oExcelSS.isDashboardatLogin Then
                tsDashboard_Click(Me, e)
            End If
            Me.Text = ""
            Me.Text = "DMAC - " & oExcelSS.ActiveCompanyName
        Catch ex As Exception
            oExcelSS.ErrorLog("Master_Activated Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub Master_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            tsmExit_Click(sender, e)
        End If
    End Sub
    Private Sub tsDashboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDashboard.Click
        If AcclExplorerBar1.Visible = True Then
            Exit Sub
        End If
        Dim dtGadgets As New DataTable
        Dim isBar As Boolean = False
        Dim p As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(0) {}
        p(0) = New System.Data.SqlClient.SqlParameter("@UserID", oExcelSS.ActiveUserID)
        dtGadgets = oExcelSS.getDataTable("uspDashboard_GetGadgets", True, p)
        Dim arrBar(10) As ExplorerBar
        Dim x As Integer = 0
        For Each b As ExplorerBar In AcclExplorerBar1.Bars
            arrBar(x) = b
            x += 1
            isBar = True
        Next
        If isBar Then
            For y = 0 To x - 1
                If arrBar(y).Items.Count > 0 Then
                    Dim hold As ExplorerBarControlHolderItem
                    hold = arrBar(y).Items(0)
                    hold.Control.Visible = False
                End If
                AcclExplorerBar1.Bars.Remove(arrBar(y))
            Next
        End If
        x = 0
        isBar = False
        For Each b As ExplorerBar In AcclExplorerBar2.Bars
            arrBar(x) = b
            x += 1
            isBar = True
        Next
        If isBar Then
            For y = 0 To x - 1
                If arrBar(y).Items.Count > 0 Then
                    Dim hold As ExplorerBarControlHolderItem
                    hold = arrBar(y).Items(0)
                    hold.Control.Visible = False
                End If
                AcclExplorerBar2.Bars.Remove(arrBar(y))
            Next
        End If
        If dtGadgets.Rows.Count > 0 Then
            If dtGadgets.Rows.Count > 1 Then
                AcclExplorerBar1.Visible = True
                AcclExplorerBar2.Visible = True
            Else
                AcclExplorerBar1.Visible = True
                AcclExplorerBar2.Visible = False
            End If
        End If
        For i As Integer = 0 To dtGadgets.Rows.Count - 1
            Dim gdg As Object
            Dim repBar As New ExplorerBar
            Dim repBarItem As New ExplorerBarControlHolderItem
            With dtGadgets
                If Not .Rows(i)(2) = 0 Then
                    Select Case .Rows(i)(3).ToString.Trim.ToLower
                        Case Is = "dbinventoryind"
                            gdg = New InventoryInd
                            If .Rows(i)(1) > 0 Then
                                DirectCast(gdg, InventoryInd).Timer1.Interval = (.Rows(i)(1) * 60) * 1000
                                DirectCast(gdg, InventoryInd).Timer1.Enabled = True
                                DirectCast(gdg, InventoryInd).Timer1.Start()
                            End If
                            repBar.Text = "Inventory Indicator"
                            repBar.ToolTipText = "Inventory Indicator"
                        Case Is = "dbordersinfo"
                            gdg = New OrdersInfo
                            If .Rows(i)(1) > 0 Then
                                DirectCast(gdg, OrdersInfo).Timer1.Interval = (.Rows(i)(1) * 60) * 1000
                                DirectCast(gdg, OrdersInfo).Timer1.Enabled = True
                                DirectCast(gdg, OrdersInfo).Timer1.Start()
                            End If
                            repBar.Text = "Order Overview"
                            repBar.ToolTipText = "Information about Orders, Shipments & Invoices"
                        Case Is = "dbsalesbyrep"
                            gdg = New SalesbyRep
                            If .Rows(i)(1) > 0 Then
                                DirectCast(gdg, SalesbyRep).Timer1.Interval = (.Rows(i)(1) * 60) * 1000
                                DirectCast(gdg, SalesbyRep).Timer1.Enabled = True
                                DirectCast(gdg, SalesbyRep).Timer1.Start()
                            End If
                            repBar.Text = "Sales by Product"
                            repBar.ToolTipText = "Sales by Product Overview"
                        Case Is = "dbprodtrends"
                            gdg = New ProdTrendsCtrl
                            If .Rows(i)(1) > 0 Then
                                DirectCast(gdg, ProdTrendsCtrl).Timer1.Interval = (.Rows(i)(1) * 60) * 1000
                                DirectCast(gdg, ProdTrendsCtrl).Timer1.Enabled = True
                                DirectCast(gdg, ProdTrendsCtrl).Timer1.Start()
                            End If
                            repBar.Text = "Production Trend"
                            repBar.ToolTipText = "Production Trend Report"
                    End Select
                    repBar.BackColor = Color.WhiteSmoke
                    repBar.State = ExplorerBarState.Expanded
                    repBar.CanExpand = True
                    If i Mod 2 = 0 Then
                        AcclExplorerBar2.Bars.Add(repBar)
                    Else
                        AcclExplorerBar1.Bars.Add(repBar)
                    End If
                    repBarItem.Control = gdg
                    Try
                        repBar.Items.Add(repBarItem)
                    Catch ex As Exception
                        oExcelSS.ErrorLog("Master_Activated Error##" + ex.Message.ToString())
                    End Try

                End If
            End With
        Next
        btnCloseDb.Visible = True
    End Sub
    Public Sub btnSU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RunReportLauncher("", "ScheduledUsage", "")
    End Sub
    Private Sub OutlookBar1_Click(ByVal sender As System.Object, ByVal e As DMAC.OutlookStyleControls.OutlookBar.ButtonClickEventArgs) Handles OutlookBar1.Click
        Try
            Dim isValidShortcut As Boolean = False

            Dim idx As Integer = OutlookBar1.Buttons.IndexOf(e.SelectedButton)
            Dim selectedButton = OutlookBar1.Buttons.Item(idx)
            Debug.Print(selectedButton.Text & " " & selectedButton.ShortcutFor & " " & selectedButton.LinkTo)
            lblSelectedItem.Text = e.SelectedButton.Text
            If selectedButton.ShortcutType = "Program" Then
                Dim paramsql As SqlClient.SqlParameter() = New SqlClient.SqlParameter(0) {}
                paramsql(0) = New SqlClient.SqlParameter("@Linkto", selectedButton.LinkTo)
                Dim dt As DataTable = oExcelSS.getDataTable("uspAccess_OutlookDynamicEvent", True, paramsql)
                If dt.Rows.Count > 0 Then
                    Dim strProcess As String = Convert.ToString(dt(0)(0))
                    isValidShortcut = executeApplicationByShortcut(e.SelectedButton.Text, strProcess, "Program")
                Else
                    MsgBox("[ " & e.SelectedButton.Text & " ] Goes Here ...")
                End If
            ElseIf selectedButton.ShortcutType = "Report" Then
                isValidShortcut = RunReportLauncher("DMAC-ShortCut ", selectedButton.ShortcutFor, "") 'Launch Report Viewer - 14sep13
            ElseIf selectedButton.ShortcutType = "Custom" Then
                Dim paramsql As SqlClient.SqlParameter() = New SqlClient.SqlParameter(1) {}
                paramsql(0) = New SqlClient.SqlParameter("@intUserID", oExcelSS.userid)
                paramsql(1) = New SqlClient.SqlParameter("@strShortcutName", selectedButton.Text)
                Dim dt As DataTable = oExcelSS.getDataTable("uspAccess_GetCustomShortcut", True, paramsql)
                If dt.Rows.Count > 0 Then
                    Dim strProcess As String = Convert.ToString(dt(0)(0))
                    Dim shortcutType As String = Convert.ToString(dt(0)(1))
                    isValidShortcut = executeApplicationByShortcut(e.SelectedButton.Text, strProcess, shortcutType)
                Else
                    MsgBox("[ " & e.SelectedButton.Text & " ] Goes Here ...")
                End If
            ElseIf selectedButton.ShortcutType.Contains("Document") Then
                Dim paramsql As SqlClient.SqlParameter() = New SqlClient.SqlParameter(1) {}
                paramsql(0) = New SqlClient.SqlParameter("@intUserID", oExcelSS.userid)
                paramsql(1) = New SqlClient.SqlParameter("@strShortcutName", selectedButton.Text)
                Dim dt As DataTable = oExcelSS.getDataTable("uspAccess_GetCustomShortcut", True, paramsql)
                If dt.Rows.Count > 0 Then
                    Dim strProcess As String = Convert.ToString(dt(0)(0))
                    Dim shortcutType As String = Convert.ToString(dt(0)(1))
                    isValidShortcut = executeApplicationByShortcut(e.SelectedButton.Text, strProcess, shortcutType)
                Else
                    MsgBox("[ " & e.SelectedButton.Text & " ] Goes Here ...")
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("OutlookBar1_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    'John 14sep13
    Public Function RunReportLauncher(ByVal currentItem As String, ByVal ReportName As String, ByVal PrinterName As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim executableFileName As String = String.Empty
            Dim executeFilePath As String = String.Empty
            'Dim iniFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath & "\" & oExcelSS.AppFolderName) & "\"
            'chg102015ly change all path statements to use only AppFolderName
            Dim iniFilePath As String = oExcelSS.AppPath & "\"
            executeFilePath = iniFilePath & oExcelSS.ReportToolName
            If IO.File.Exists(executeFilePath) Then
                ' open when the child form is open -------- if external program is opep, it must be closed
                closeOpenForms()
                success = True
                Dim lobjStartInfo As New ProcessStartInfo(executeFilePath)
                lobjStartInfo.Arguments = ReportName & " " & """" & PrinterName & """"
                Process.Start(lobjStartInfo)
            Else
                MsgBox("Report Utility not installed yet." & executeFilePath)
            End If
        Catch ex As Exception
            success = False
            oExcelSS.ErrorLog(" executeApplicationByShortcut ==> Error## " + ex.Message.ToString())
        End Try
        Return success
    End Function
    Private Function executeApplicationByShortcut(ByVal selectedButtonText As String, ByVal currentItem As String, Optional ByVal shortcutType As String = "") As Boolean
        Dim success As Boolean = False
        Try
            Dim parameter As String = String.Empty
            Dim executableFileName As String = String.Empty
            Dim executeFilePath As String = String.Empty
            If shortcutType = "Program" Then
                'Dim iniFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath)
                'chg102015ly change all path statements to use only AppFolderName 
                Dim iniFilePath As String = oExcelSS.AppPath
                executableFileName = currentItem.Split(" ")(0) & IIf(currentItem.Split(" ")(0).EndsWith(".exe"), "", ".exe")
                If currentItem.Split(" ").Length > 1 Then
                    parameter = currentItem.ToString().Split(" ")(1)
                End If
                executeFilePath = oExcelSS.AppPath & "\" & executableFileName
            Else
                executeFilePath = currentItem
            End If
            If IO.File.Exists(executeFilePath) Then
                ' open when the child form is open -------- if external program is opep, it must be closed
                closeOpenForms()
                success = True
                Process.Start(executeFilePath, parameter)
            Else
                MsgBox("[ " & selectedButtonText & " ] Goes Here ...")
            End If
        Catch ex As Exception
            success = False
            oExcelSS.ErrorLog(" executeApplicationByShortcut ==> Error## " + ex.Message.ToString())
        End Try
        Return success
    End Function
    Private Sub Master_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            DisableMenus()
            tsCurrentUser.Text = "Welcome Guest "
            tsLogintime.Text = "   "
            lblSelectedItem.Text = "Login"
            OutlookBar1.Buttons.Clear()
            OutlookBar1.Height = 350
            AcclExplorerBar1.Visible = False
            AcclExplorerBar2.Visible = False
            frmLogin.ShowDialog()
        Catch ex As Exception
            If ex.ToString.Contains("Could not load file or assembly") Then
                MsgBox("Missing company file.  Please contact Excel Software Services for assistance", vbCritical, My.Resources.applicationTitle)
                oExcelSS.EndApplication()
            End If
            oExcelSS.ErrorLog("Master_Load Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsDbfconversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        closeOpenForms()
    End Sub
    Private Sub logOff(Optional ByVal isFromExit As Boolean = False)
        Try
            DisableMenus()
            oExcelSS.licenseKey = String.Empty
            Timer1.Stop()
            tsCurrentUser.Text = "Welcome Guest"
            tsActiveCompany.Text = "Company"
            lblSelectedItem.Text = "Login"
            tsLogintime.Text = "   "
            closeOpenFormsAfterLogin()
            menuArray.Clear()
            oExcelSS.ActiveUserID = String.Empty
            oExcelSS.logintime = String.Empty
            Dim param As String(,) = New String(,) {{"@userID", oExcelSS.userid}, {"@WorkstationID", My.Computer.Name}, {"@strLogStatus", "Logout"},
                                               {"@LogInTime", Nothing}, {"@LogOutTime", Now}}
            Dim logregisterstatus As Boolean = oExcelSS.userLoginStatusUpdation("uspAccess_UserLogRegister", param, "@strStatus")
            oExcelSS.userid = String.Empty
            oExcelSS.loginHr = String.Empty
            oExcelSS.dtShortcut = Nothing
            OutlookBar1.Buttons.Clear()
            If Not isFromExit Then
                frmLogin.ShowDialog()
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("Master ==> logOff()  Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        tsLogintime.Text = "   " & Now
        If Now.Hour - Convert.ToInt16(oExcelSS.loginHr) >= 12 Then
            Timer1.Stop()
            MsgBox("Your login time is exceeding the 12hrs, so it logout automatically", MsgBoxStyle.Information, My.Resources.applicationTitle)
            logOff()
        End If
    End Sub
    Private Sub tsmExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmExit.Click
        If MsgBox("Are you sure to Exit the Application?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Resources.applicationTitle) = MsgBoxResult.Yes Then
            logOff(True)
            Application.ExitThread()
            Me.Close()
        End If
    End Sub
    Private Sub Master_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        If MsgBox("Are you sure to Exit the Application?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, My.Resources.applicationTitle) = MsgBoxResult.Yes Then
            logOff(True)
            Application.ExitThread()
            End
        End If
    End Sub
    Private Sub tsmFileChangeCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmFileChangeCompany.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmFileChangeCompany_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Function executeApplicationAsPerMenu(ByVal currentMenuItem As ToolStripMenuItem) As Boolean
        Dim success As Boolean = False
        Dim szReportName As String
        Try
            Dim currentMenu As String = DirectCast(currentMenuItem, ToolStripMenuItem).Name
            Dim szGroup As String = currentMenuItem.OwnerItem.Text
            For Each obj As Object In menuArray
                If obj.getMenuName().ToString().ToLower = currentMenu.ToLower Then
                    Dim parameter As String = String.Empty
                    Dim param As String = String.Empty
                    'Dim iniFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath & "\" & oExcelSS.AppFolderName) & "\"
                    'chg102015ly change all path statements to use only AppFolderName
                    Dim iniFilePath As String = oExcelSS.AppPath & "\"
                    Dim executableFileName As String = obj.getMenuRunProgram().ToString().Split(" ")(0) '& ".exe"
                    If obj.getMenuRunProgram().ToString().Split(" ").Length > 1 Then
                        parameter = obj.getMenuRunProgram().ToString().Split(" ")(1)
                    End If
                    Dim executeFilePath As String = ""
                    If executableFileName = "reports.exe" Then
                        executeFilePath = iniFilePath & oExcelSS.ReportToolName
                        szReportName = currentMenuItem.Text.Replace(" ", "_")
                        param = "DMAC-Menu " & parameter & " " & szReportName
                        parameter = param
                    Else
                        executeFilePath = iniFilePath & executableFileName
                    End If
                    If IO.File.Exists(executeFilePath) Then
                        success = True

                        ''''commented by Harinath Reddy

                        ' Process.Start(executeFilePath, parameter)

                        ''''end of comment


                        ''''Added by Harinath : 22nd JAN 2015
                        Select Case executableFileName.ToUpper()
                            Case "CONFIGDMAC.EXE"

                                Dim lobjfrm As ConfigDMAC.frmMain = New ConfigDMAC.frmMain()
                                lobjfrm.mstrUserId = oExcelSS.ActiveUserID
                                lobjfrm.ShowDialog(Me)

                            Case Else
                                Process.Start(executeFilePath, parameter)

                        End Select


                        ''''End

                        Exit For
                    Else
                        MsgBox("[ " & DirectCast(currentMenuItem, ToolStripMenuItem).Text & " ] Not Installed in: " & executeFilePath)
                    End If
                End If
            Next
        Catch ex As Exception
            success = False
            oExcelSS.ErrorLog(" executeApplicationAsPerMenu ==> Error## " + ex.Message.ToString())
        End Try
        Return success
    End Function
    Private Sub tsmFileBackupCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmFileBackupCompany.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmFileBackupCompany_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmFilePrinterSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmFilePrinterSetup.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmFilePrinterSetup_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmFileCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmFileCM.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmFileCM_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmCustomerUCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCustomer.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmCustomerUCM_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmCustomerPCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCustomerContacts.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmCustomerPCM_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmCustomerUeA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCustomerReference.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmCustomerUeA_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmCustomerOla247UserInterface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCustomerReports.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmCustomerOla247UserInterface_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnShortcuts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShortcuts.Click
        Try
            Dim arList As ArrayList = OutlookBar1.Buttons.GetButtons()
            Dim outlookshortcut As New frmOutlookShortcuts(arList)
            outlookshortcut.ShowDialog()
        Catch ex As Exception
            oExcelSS.ErrorLog("btnShortcuts_Click Error## " + ex.Message.ToString())
        End Try

    End Sub
    Private Sub tsAlerts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAlerts.Click
        Try
            closeOpenForms()
            MsgBox("Alerts Goes ...")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsAlerts_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsEstimating_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEstimating.Click
        Try
            closeOpenForms()
            ShellLauncher("est3_dmac.exe")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsEstimating_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Public Sub ShellLauncher(ByVal shellName As String)
        Try
            Dim executeFilePath As String = String.Empty
            'Dim iniFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath & "\" & oExcelSS.AppFolderName) & "\"
            'chg102015ly change all path statements to use only AppFolderName
            Dim iniFilePath As String = oExcelSS.AppPath & "\"
            executeFilePath = iniFilePath & shellName
            If IO.File.Exists(executeFilePath) Then
                closeOpenForms()
                Process.Start(executeFilePath)
            Else
                MsgBox("Utility not Installed in " & executeFilePath)
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog(" Shell Launcher ==> Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsOrderEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsOrderEntry.Click
        Try
            closeOpenForms()
            ShellLauncher("orderfrm_dmac.exe")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsOrderEntry_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsInvoicing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsInvoicing.Click
        Try
            closeOpenForms()
            ShellLauncher("invoice_dmac.exe")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsInvoicing_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsBillofLading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            closeOpenForms()
            ShellLauncher("billlad_dmac.exe")
        Catch ex As Exception
            oExcelSS.ErrorLog("BillofLading Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsCartonLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            closeOpenForms()
            ShellLauncher("label_dmac.exe")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsCartonLabels_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsInventory.Click
        Try
            closeOpenForms()
            ShellLauncher("inventory_dmac.exe")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsInventory_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsPPCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPPCC.Click
        Try
            closeOpenForms()
            ShellLauncher("ppcc_dmac.exe")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsPPCC_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReports.Click
        Try
            closeOpenForms()
            Dim frmgrpCat As frmSelectGrpCategory = New frmSelectGrpCategory
            frmgrpCat.ShowDialog()
        Catch ex As Exception
            oExcelSS.ErrorLog("tsReports_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsFaxStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFaxStatus.Click
        Try
            closeOpenForms()
            ShellLauncher("jobref_dmac.exe")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsFaxStatus_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsScreenshot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsScreenshot.Click
        Try
            closeOpenForms()
            MsgBox("Screenshot Goes ...")
        Catch ex As Exception
            oExcelSS.ErrorLog("tsScreenshot_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmEstimateForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEstimateForm.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmEstimateForm_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmReportEstimate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmReportEstimate.Click
        Try
            LoadReportDataSeletor(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderReports_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmOrderProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOrderProduction.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderProduction_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmOrderWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOrderWarehouse.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderWarehouse_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmOrderView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOrderView.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderView_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmOrderStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOrderStatus.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderStatus_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmOrderCreateInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOrderCreateInvoices.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderCreateInvoices_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmOrderReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOrderReports.Click
        Try
            LoadReportDataSeletor(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderReports_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmProductionMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionMonitor.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmProductionMonitor_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmProductionViewJobActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionViewJobActivity.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmProductionViewJobActivity_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmProductionViewCostCenterActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionViewCostCenterActivity.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmProductionViewCostCenterActivity_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmProductionViewEmployeeActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionViewEmployeeActivity.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmProductionViewEmployeeActivity_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmProductionUpdateOrderLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionUpdateOrderLocation.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmProductionUpdateOrderLocation_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmProductionInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionInformation.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmProductionInformation_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmProductionPlanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionPlanner.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmProductionPlanner_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmProductionReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionReports.Click
        Try
            LoadReportDataSeletor(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderReports_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPurchaseOrder.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmPurchaseOrder_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmPurchaseReceiveItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPurchaseReceiveItems.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmPurchaseReceiveItems_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmPurchaseEnterBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPurchaseEnterBill.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmPurchaseEnterBill_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmPurchaseEditOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPurchaseEditOrder.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmPurchaseEditOrder_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvRMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvRMI.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvRMI_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvWPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvWPI.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvWPI_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvSMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvSMP.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvSMP_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvCPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvCPA.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvCPA_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvRMIU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvRMIU.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvRMIU_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvMM_PhysicalCountInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvMM_PhysicalCountInput.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvMM_PhysicalCountInput_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvMM_AuditReportUpdateInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvMM_AuditReportUpdateInventory.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvMM_AuditReportUpdateInventory_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvBRU_EditPaperRollFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvBRU_EditPaperRollFile.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvBRU_EditPaperRollFile_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInvBRU_RollWeightBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInvBRU_RollWeightBalance.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmInvBRU_RollWeightBalance_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmInventoryIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmInventoryIR.Click
        Try
            LoadReportDataSeletor(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderReports_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmShippingBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShippingBL.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmShippingBL_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmShippingCL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShippingCL.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmShippingCL_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmShipping_PrintPickTickets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShipping_PrintPickTickets.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmShipping_PrintPickTickets_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmShipping_FindShipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShipping_FindShipmentToolStripMenuItem.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmShipping_FindShipmentToolStripMenuItem_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmShipping_ShippingReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShipping_ShippingReports.Click
        Try
            LoadReportDataSeletor(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderReports_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmJobCost_EditImpressionQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmJobCost_EditImpressionQuantity.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmJobCost_EditImpressionQuantity_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmJob_ViewOrEditEmployeeShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmJob_ViewOrEditEmployeeShift.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmJob_ViewOrEditEmployeeShift_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmJob_UpdateCarbonMaterialUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmJob_UpdateCarbonMaterialUsage_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmJob_UpdateCartonMaterialUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmJob_UpdateCartonMaterialUsage_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmJob_UpdateMiscMaterialUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmJob_UpdateMiscMaterialUsage_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmJob_UpdateMiscPaperUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmJob_UpdateMiscPaperUsage_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmJob_UpdateOutsidePurchaseMaterialUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmJob_UpdateOutsidePurchaseMaterialUsage.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmJob_UpdateOutsidePurchaseMaterialUsage_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmToolsFaxStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmToolsFaxStatus.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmToolsFaxStatus_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmToolQ_SyncTodaysInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmToolQ_SyncTodaysInvoices.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmToolQ_SyncTodaysInvoices_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmToolQ_SyncCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmToolQ_SyncCustomers.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmToolQ_SyncCustomers_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmToolMR_PurgeOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmToolMR_PurgeOrders.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmToolMR_PurgeOrders_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmHelp.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmHelp_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmHelpDMACSupport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmHelpDMACSupport.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmHelpDMACSupport_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmHelpLicenseInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmHelpLicenseInformation.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmHelpLicenseInformation_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmHelpUpdateDMAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmHelpUpdateDMAC.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmHelpUpdateDMAC_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tsmHelpAboutDMAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmHelpAboutDMAC.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmHelpAboutDMAC_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        logOff()
    End Sub
    Private Sub tsmDashboardSetup_Click(sender As Object, e As EventArgs) Handles tsmDashboardSetup.Click
        Dim frmDS As New frmDashboardSetup
        frmDS.ShowDialog()
    End Sub
    Private Sub btnCloseDb_Click(sender As Object, e As EventArgs) Handles btnCloseDb.Click
        'Close Dashboard
        AcclExplorerBar1.Visible = False
        AcclExplorerBar2.Visible = False
        btnCloseDb.Visible = False
    End Sub
    Private Sub Master_MaximizedBoundsChanged(sender As Object, e As EventArgs) Handles Me.MaximizedBoundsChanged
        AcclExplorerBar1.Height = Me.MaximizedBounds.Height - 140
        AcclExplorerBar2.Height = Me.MaximizedBounds.Height - 140
    End Sub
    Private Sub Master_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        AcclExplorerBar1.Height = Me.Size.Height - 140
        AcclExplorerBar2.Height = Me.Size.Height - 140
    End Sub


    Private Sub tsmPricebookQuote_Click(sender As Object, e As EventArgs) Handles tsmPricebookQuote.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmPricebookQuote_Click Error## " + ex.Message.ToString())
        End Try
    End Sub

    Private Sub tsmJobCostingReports_Click(sender As Object, e As EventArgs) Handles tsmJobCostingReports.Click
        Try
            LoadReportDataSeletor(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmOrderReports_Click Error## " + ex.Message.ToString())
        End Try
    End Sub


    Private Sub tsmInvMM_Click(sender As Object, e As EventArgs) Handles tsmInvMM.Click

    End Sub

    Private Sub tsmInvBRU_Click(sender As Object, e As EventArgs) Handles tsmInvBRU.Click

    End Sub

    Private Sub tsmJobCostingDM_Click(sender As Object, e As EventArgs) Handles tsmJobCostingDM.Click

    End Sub


    Private Sub tsmSplitShipments_Click(sender As Object, e As EventArgs) Handles tsmSplitShipments.Click
        Try
            executeApplicationAsPerMenu(DirectCast(sender, ToolStripMenuItem))
        Catch ex As Exception
            oExcelSS.ErrorLog("Menu tsmPricebookQuote_Click Error## " + ex.Message.ToString())
        End Try
    End Sub

    Private Sub tsActiveCompany_Click(sender As Object, e As EventArgs) Handles tsActiveCompany.Click

    End Sub
End Class
