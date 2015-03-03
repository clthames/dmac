Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class frmMain

    Public oExcelSS As New ExcelSSGen.Main
    Public mstrUserId As String
    Public isLoading As Boolean = False
    Public mblnExisting = False
    Public Env As Integer = 0
    Public action As Integer = clsConfigDmac.Actions.None
    Dim mblnNew As Boolean = False
    Dim activeRow As Integer


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim message As String = ""
        If mstrUserId.ToUpper() = "EXCELSS" Then
            Me.tsSettings.Visible = True
            Me.tsSettings.Enabled = True
        End If

        LoadSettings()
        message = oExcelSS.AppInit
        If message = "" Then
            EnDisAllButtons(False)
            ToolStrip1.Focus()
        Else
            MsgBox(message, MsgBoxStyle.Critical)
            oExcelSS.EndApplication()
        End If
    End Sub
    Public Sub EnDisAllButtons(value As Boolean)
        tsNew.Enabled = value
        tsEdit.Enabled = value
        tsSave.Enabled = value
        tsCancel.Enabled = value
    End Sub
    Private Sub trvOptions_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvOptions.AfterSelect
        Try
            Dim tc As System.Drawing.Point
            tc.X = 3
            tc.Y = 3
            hideTabs()
            EnDisAllButtons(False)
            Select Case e.Node.Name
                Case "nUsers"
                    isLoading = True
                    Env = clsConfigDmac.ActiveEnv.UserInformation
                    hideTabs()
                    tsNew.Enabled = True
                    tcProfiles.Visible = True
                    tcProfiles.Location = tc
                    tcProfiles.SelectTab(0)
                    txtLogon.Clear()
                    txtEmail.Clear()
                    txtName.Clear()
                    txtPassword.Clear()
                    chkActive.Checked = False
                    oExcelSS.fillComboBox(cboUsers, "uspConfiguration_FillUsersCbo", "UserID", "ID")
                    '  oExcelSS.fillComboBox(cboProfiles, "uspConfiguration_FillProfilesCbo", "ProfileName", "ProfileID")
                    txtPrDesc.Clear()
                    txtPrName.Clear()
                    chklbPermissions.Controls.Clear()
                    lbOwnedProfiles.Items.Clear()
                    cboProfiles.SelectedIndex = -1
                    cboUsers.SelectedIndex = -1
                    cboUsers.Enabled = True
                    isLoading = False
                Case "nCompany"
                    Env = clsConfigDmac.ActiveEnv.CompanyInformation
                    isLoading = True
                    tsNew.Enabled = False
                    tsEdit.Enabled = False
                    tsCancel.Enabled = False
                    tsSave.Enabled = False
                    hideTabs()
                    tcCompany.Visible = True
                    tcCompany.Location = tc
                    tcCompany.SelectTab(0)
                    txtCoAddress.Clear()
                    txtCoFax.Clear()
                    txtCoName.Clear()
                    txtCoPhone.Clear()
                    txtCoWebS.Clear()
                    GetCompanyInfo()

                    ''''Added by Harinath Reddy
                    ''''Report Categories
                Case "nReportCategories"
                    Env = clsConfigDmac.ActiveEnv.ReportCategories
                    isLoading = True
                    tsNew.Enabled = True
                    tsEdit.Enabled = False
                    tsCancel.Enabled = False
                    tsSave.Enabled = False
                    hideTabs()
                    tcReports.Visible = True
                    tcReports.Location = tc
                    tcReports.SelectTab(0)
                    LoadReportCategories()
                    ' oExcelSS.fillComboBox(cboRepCategories, "uspConfiguration_FillRepCategoriesCbo", "categoryname", "categoryidkey")
                    oExcelSS.fillComboBox(cboRepGroupCat, "uspConfiguration_FillRepGroupsCbo", "groupname", "groupidkey")
                    ' cboRepCategories.SelectedIndex = -1
                    cboRepGroupCat.SelectedIndex = -1
                    pnlRepCategories.Visible = False
                    isLoading = False

                    ''''added by Harinath on 25-JAN-2014

                Case "nAccess"
                    hideTabs()

                Case "NRoles"
                    isLoading = True
                    Env = clsConfigDmac.ActiveEnv.UserProfiles
                    hideTabs()
                    tsNew.Enabled = True
                    tbcntrl_ProfileAccess.Visible = True
                    tbcntrl_ProfileAccess.Location = tc
                    tbcntrl_ProfileAccess.SelectTab(0)
                    oExcelSS.fillComboBox(cboProfiles, "uspConfiguration_FillProfilesCbo", "ProfileName", "ProfileID")
                    txtPrDesc.Clear()
                    txtPrName.Clear()
                    chklbPermissions.Controls.Clear()
                    lbOwnedProfiles.Items.Clear()
                    cboProfiles.SelectedIndex = -1
                    isLoading = False

                Case "nReportDefinitions"
                    isLoading = True
                    Env = clsConfigDmac.ActiveEnv.ReportDefinitions
                    hideTabs()
                    tsNew.Enabled = False
                    tbcReportDefinition.Visible = True
                    tbcReportDefinition.Location = tc
                    trvwReportDefinition.Nodes.Clear()
                    LoadReports(trvwReportDefinition)
                    'oExcelSS.fillComboBox(cboReportDefinitions, "uspConfiguration_FillRepDefinitionsCbo", "ReportID", "ReportIDKey")
                    isLoading = False

                Case "nCostOperations"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Job Costing for Cost Operations"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    End If

                Case "nOperationCodes"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Job Costing for Operation Codes"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    End If

                Case "nOperationClasses"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Paper Scheduling for Operations Classes"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    End If

                Case "nOptions"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Paper Scheduling for Options"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    End If

                Case "nPressTrimRequirements"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Paper Scheduling for Press Trim Requirements"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    End If


                Case "nPress"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Labor Standards for Press"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_pres", "Press", "btnPressLaunch_Click")
                    End If

                Case "nCollator"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Labor Standards for Collator"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_coll", "Collator", "btnCollatorLaunch_Click")
                    End If

                Case "nComposition"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Labor Standards for Composition"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_comp", "Composition", "btnCompositionLauncher_Click")
                    End If


                Case "nEncoder"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Labor Standards for Encoder"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_enco", "Encoder", "btnEncoderLauncher_Click")
                    End If

                Case "nOfflineFolderStandards"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Labor Standards for Offline Folder Standards"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_fold", "Offline Folder", "btnOfflineFolderLauncher_Click")
                    End If

                Case "NShrinkwrapStandards"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Labor Standards for Shrinkwrap Standards"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_shri", "Shrinkwrap Standards", "btnShrinkwrapLauncher_Click")
                    End If

                Case "NBinderyCosts"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Labor Standards for Bindery Costs"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_bind", "Bindery Costs", "btnBinderyCostsLauncher_Click")
                    End If

                Case "nPaperMaterial"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Material Standards for Paper Material"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_pap", "Paper Material", "btnMaterialStandardsLauncher_Click")
                    End If

                Case "nBaseandStandardsInks"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Material Standards for Base and Standards Inks"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_inks", "Base and Standard Ink", "btnBSILauncher_Click")
                    End If



                Case "nUpdateCarbonFile"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Material Standards for Update Carbon File"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_cbn", "Update Carbon File", "btnUCFLauncher_Click")
                    End If

                Case "nUpdatePackSizes"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Material Standards for Update Pack Sizes"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_pack", "Update Pack Sizes", "btnUPSLauncher_Click")
                    End If

                Case "nOverhead-Ink-Carton-Helper"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Material Standards for Overhead-Ink-Carton-Helper"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_misc", "Overhead-Ink-Carton-Helper-Exch-Rates", "btnOverheadLauncher_Click")
                    End If


                Case "nProductMarkupFactors"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Other Standards for Overhead-Ink-Carton-Helper"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_prod", "Product Markup Factors", "btnPMFLauncher_Click")
                    End If

                Case "nProductMarkupFactors"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Other Standards for Product Markup Factors"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_frtM", "Freight Rates (MINIMUM)", "btnFreightRates_Click")
                    End If

                Case "nFreightRates(MIN)"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Other Standards for Freight Rates (MIN)"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_frtC", "Freight Rates (CWT COST)", "btnFRC_Click")
                    End If

                Case "nFreightRates(CWTCOST)"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Other Standards for Freight Rates (CWT COST)"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    End If

                Case "nUserDefinedKeywords"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Configuration for User Defined Keywords"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_kwrd", "User-defined Keywords", "btnUserDK_Click")
                    End If


                Case "nOddWidthCrossReference"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Configuration for Odd Width Cross Reference"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_oddw", "Odd Width Cross Reference", "btnOddWidthLauncher_Click")
                    End If

                Case "nPressandCollatorDesignation"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Configuration for Press and Collator Designation"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "est_desg", "Press and Collator Designation", "btnPressandCollatorLauncher_Click")
                    End If


                Case "nPaperColorCrossReference"
                    Dim lobjfrmLaunch As New frmLaunch()

                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Configuration for Paper Color Cross Reference"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("maintain_dmac.exe", "Pap-XREF", "Paper Color Cross Reference", "btnPaperColorLauncher_Click")
                    End If

                Case "nKeypadConfiguration"
                    Dim lobjfrmLaunch As New frmLaunch()
                    lobjfrmLaunch.txtlaunchtext.Text = "Click on the 'Launch' button below to maintain Estimating Configuration for Keypad Configuration"
                    lobjfrmLaunch.btn_Launch.Focus()
                    If lobjfrmLaunch.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        executeApplication("bldkp_dmac.exe", "", "Keypad Configuration", "btnKeypadLauncher_Click")
                    End If


                    ''''End

            End Select
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub executeApplication(ByVal executableFileName As String, ByVal param As String, ByVal title As String, ByVal currentevent As String)
        Try
            Dim parameter As String = String.Empty
            Dim executeFilePath As String = String.Empty
            Dim iniFilePath As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath) & "\" & oExcelSS.AppFolderName & "\"
            parameter = param
            executeFilePath = iniFilePath & executableFileName
            If IO.File.Exists(executeFilePath) Then
                If parameter.Trim.Length > 0 Then
                    Process.Start(executeFilePath, parameter)
                Else
                    Process.Start(executeFilePath)
                End If
            Else
                MsgBox("Executables missing...Contact Admin")
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("frmConfigurationManager -> " & currentevent & " ==> Error##" + ex.Message.ToString())
        End Try
    End Sub
    Public Sub hideTabs()
        tcProfiles.Visible = False
        pnlPermissions.Visible = False
        tcCompany.Visible = False
        tcReports.Visible = False
        tbcntrl_ProfileAccess.Visible = False
        tbcReportDefinition.Visible = False
        pbPreview.Visible = False
        pnlReportDefinitions.Visible = False
    End Sub
    ''' <summary>
    ''' Added by Harinath for Reports
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
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
                            lobjChildNode2.Text = lobjRow(3).ToString
                            lobjChildNode2.Name = lobjRow(3).ToString
                            lobjChildNode2.Tag = lobjRow
                            lobjChildnode.Nodes.Add(lobjChildNode2)
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
            lobjDataTable = oExcelSS.getDataTable("select rep.CategoryIDKey,rep.GroupIDKey,rep.CategoryName,grp.GroupName from ReportCategories rep,ReportGroups grp where  rep.isActive=1  and (rep.GroupIDKey=grp.GroupIDKey )", False)
            If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                For Each lobjRow As DataRow In lobjDataTable.Rows
                    Dim lobjParentTreeNode As TreeNode = Nothing
                    Dim lobjChildnode As TreeNode = Nothing
                    Dim lobjChildNode2 As New TreeNode()
                    lobjParentTreeNode = New TreeNode()
                    lobjParentTreeNode.Text = lobjRow(3).ToString()
                    lobjParentTreeNode.Name = lobjRow(3).ToString()
                    lobjParentTreeNode.Tag = lobjRow
                    If pobjtreeview.Nodes.Find(lobjRow(3).ToString(), False).Length >= 1 Then
                        lobjParentTreeNode = pobjtreeview.Nodes.Item(lobjRow(3).ToString())
                        If lobjParentTreeNode.Nodes.Find(lobjRow(2).ToString(), False).Length >= 1 Then
                            lobjChildnode = pobjtreeview.Nodes.Item(lobjRow(2).ToString())
                        Else
                            lobjChildnode = New TreeNode()
                            lobjChildnode.Text = lobjRow(2).ToString
                            lobjChildnode.Name = lobjRow(2).ToString
                            lobjChildnode.Tag = lobjRow
                            lobjParentTreeNode.Nodes.Add(lobjChildnode)
                        End If
                    Else
                        lobjChildnode = New TreeNode()
                        lobjChildnode.Text = lobjRow(2).ToString
                        lobjChildnode.Name = lobjRow(2).ToString
                        lobjChildnode.Tag = lobjRow
                        lobjParentTreeNode.Nodes.Add(lobjChildnode)
                        pobjtreeview.Nodes.Add(lobjParentTreeNode)
                    End If
                Next
            End If

        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub LoadSettings()
        oExcelSS.logoURL = ConfigurationSettings.AppSettings("logoURL")
        oExcelSS.AppFolderName = ConfigurationSettings.AppSettings("AppFolderName")
        oExcelSS.IniAppFile = ConfigurationSettings.AppSettings("IniAppFile")
        oExcelSS.ReportToolName = ConfigurationSettings.AppSettings("ReportToolName")
    End Sub
    Private Sub tsExit_Click(sender As Object, e As EventArgs) Handles tsExit.Click
        oExcelSS.EndApplication()
    End Sub
    Private Sub cboUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUsers.SelectedIndexChanged
        Try
            If Not cboUsers.SelectedIndex = -1 And Not isLoading Then
                pnlInfoUsers.Visible = True
                pnlInfoUsers.Enabled = False
                txtLogon.Clear()
                txtName.Clear()
                txtPassword.Clear()
                txtEmail.Clear()
                chkActive.Checked = False
                Dim dt As New DataTable
                Dim p As SqlParameter() = New SqlParameter(0) {}
                p(0) = New SqlParameter("@UserID", cboUsers.SelectedValue)
                dt = oExcelSS.getDataTable("uspConfiguration_GetUserInfo", True, p)
                If Not dt Is Nothing Then
                    txtLogon.Text = dt.Rows(0)(0)
                    txtName.Text = dt.Rows(0)(1)
                    txtPassword.Text = ExcelSSGen.Main.Decrypt(dt.Rows(0)(2), "dmac", True)
                    txtEmail.Text = dt.Rows(0)(3)
                    chkActive.Checked = Convert.ToInt16(dt.Rows(0)(4))
                End If
                tsEdit.Enabled = True

                ''''Added By Harinath 24-JAN-2015

                pnlPermissions.Visible = True
                pnlPermissions.Enabled = False
                lbOwnedProfiles.Items.Clear()
                lbAvailableProfiles.Items.Clear()
                dt = New DataTable
                Dim dp As New DataTable
                p = New SqlParameter(0) {}
                p(0) = New SqlParameter("@UserID", cboUsers.SelectedValue)
                dt = oExcelSS.getDataTable("uspConfiguration_GetProfilesFromUser", True, p)
                dp = oExcelSS.getDataTable("select * from AccessProfiles", False)
                If Not dt Is Nothing Then
                    Dim r As DataRow
                    For Each r In dt.Rows
                        lbOwnedProfiles.Items.Add(r(1))
                    Next
                End If
                If Not dp Is Nothing Then
                    Dim dr As DataRow
                    Dim x As Integer = 0
                    Dim exists As Boolean = False
                    For Each dr In dp.Rows
                        exists = False
                        For x = 0 To dt.Rows.Count - 1
                            If dr(1).trim = dt.Rows(x)(1).trim Then
                                exists = True
                            End If
                        Next
                        If Not exists Then
                            lbAvailableProfiles.Items.Add(dr(1))
                        End If
                    Next
                End If
                btnAddPr.Enabled = False
                btnRemovePr.Enabled = False
                action = clsConfigDmac.Actions.None
                tsNew.Enabled = True
                tsEdit.Enabled = True



                ''END
            Else
                pnlInfoUsers.Visible = False
                pnlInfoUsers.Enabled = False
            End If
        Catch lobjExeption As Exception
            Throw lobjExeption

        End Try

    End Sub

    
    Private Sub tsEdit_Click(sender As Object, e As EventArgs) Handles tsEdit.Click
        Try

            Dim niu As Boolean = True
            action = clsConfigDmac.Actions.Edit
            Select Case Env
                Case clsConfigDmac.ActiveEnv.UserInformation
                    If Not cboUsers.SelectedIndex = -1 Then
                        pnlInfoUsers.Enabled = True
                        txtLogon.Enabled = False
                        cboUsers.Enabled = False
                        pnlPermissions.Enabled = True
                        btnAddPr.Enabled = False
                        btnRemovePr.Enabled = False
                    Else
                        niu = False
                    End If
                Case clsConfigDmac.ActiveEnv.UserProfiles
                    If Not cboProfiles.SelectedIndex = -1 Then
                        pnlProfiles.Enabled = True
                        cboProfiles.Enabled = True
                        txtPrName.Enabled = False
                    Else
                        niu = False
                    End If
                Case clsConfigDmac.ActiveEnv.CompanyInformation
                    pnlCompanyInfo.Enabled = True
                    niu = False
                Case clsConfigDmac.ActiveEnv.ReportCategories
                    pnlRepCategories.Enabled = True
                        pnlRepCategories.Visible = True
                Case clsConfigDmac.ActiveEnv.ReportDefinitions

                    pnlReportDefinitions.Enabled = True
                    pbPreview.Enabled = True

            End Select
            If niu Then
                tsEdit.Enabled = False
                tsSave.Enabled = True
                tsCancel.Enabled = True
                tsNew.Enabled = False
            End If
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub
    Private Sub tsCancel_Click(sender As Object, e As EventArgs) Handles tsCancel.Click
        Try
            action = clsConfigDmac.Actions.None
            Select Case Env
                Case clsConfigDmac.ActiveEnv.UserInformation
                    tsNew.Enabled = True
                    tsEdit.Enabled = True
                    tsSave.Enabled = False
                    tsCancel.Enabled = False
                    cboUsers.Enabled = True
                    pnlPermissions.Visible = False
                    cboUsers_SelectedIndexChanged(Me, e)
                Case clsConfigDmac.ActiveEnv.UserProfiles
                    tsNew.Enabled = True
                    tsEdit.Enabled = True
                    tsSave.Enabled = False
                    tsCancel.Enabled = False
                    cboProfiles.Enabled = True
                    cboProfiles_SelectedIndexChanged_1(Me, e)
                Case clsConfigDmac.ActiveEnv.CompanyInformation
                    tsNew.Enabled = False
                    tsEdit.Enabled = True
                    tsSave.Enabled = False
                    tsCancel.Enabled = False
                    pnlCompanyInfo.Enabled = False
                Case clsConfigDmac.ActiveEnv.ReportCategories
                    tsNew.Enabled = True
                    tsEdit.Enabled = False
                    tsSave.Enabled = False
                    tsCancel.Enabled = False
                    pnlRepCategories.Visible = False
                    isLoading = True
                    isLoading = False
                Case clsConfigDmac.ActiveEnv.ReportDefinitions
                    isLoading = True
                    If trvwReportDefinition.SelectedNode.Level = 2 Then
                        tsNew.Enabled = False
                        tsEdit.Enabled = True
                        tsSave.Enabled = False
                        tsCancel.Enabled = False
                        pnlReportDefinitions.Enabled = False

                        pbPreview.Enabled = False

                    Else
                        tsNew.Enabled = True
                        tsEdit.Enabled = False
                        tsSave.Enabled = False
                        tsCancel.Enabled = False
                        pnlReportDefinitions.Visible = False

                        pbPreview.Visible = False
                    End If


                    isLoading = False
            End Select
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub
    Private Sub tsSave_Click(sender As Object, e As EventArgs) Handles tsSave.Click
        Try
            Dim niu As Boolean = True
            Select Case Env
                Case clsConfigDmac.ActiveEnv.UserInformation
                    If ValidateUserInfo() Then
                        If txtLogon.Enabled Then
                            If ValidateLogonAvailable() Then
                                SaveUserInfo(1)
                                'cboUsers.SelectedIndex = -1
                                pnlInfoUsers.Visible = False
                                pnlPermissions.Visible = False
                                isLoading = True
                                oExcelSS.fillComboBox(cboUsers, "uspConfiguration_FillUsersCbo", "UserID", "ID")
                                cboUsers.SelectedIndex = -1
                                isLoading = False
                                cboUsers.Enabled = True
                            Else
                                niu = False
                            End If
                        Else
                            SaveUserInfo(2)
                            cboUsers_SelectedIndexChanged(Me, e)
                            cboUsers.Enabled = True
                        End If
                    End If


                Case clsConfigDmac.ActiveEnv.UserProfiles
                    If ValidateProfileInfo() Then
                        Select Case action
                            Case clsConfigDmac.Actions.Edit
                                SaveProfileInfo(1)
                                cboProfiles_SelectedIndexChanged_1(Me, e)
                            Case clsConfigDmac.Actions.Niu
                                SaveProfileInfo(2)
                                cboProfiles.SelectedIndex = -1
                                pnlProfiles.Visible = False
                                isLoading = True
                                oExcelSS.fillComboBox(cboProfiles, "uspConfiguration_FillProfilesCbo", "ProfileName", "ProfileID")
                                cboProfiles.SelectedIndex = -1
                                isLoading = False
                                cboProfiles.Enabled = True
                        End Select
                    End If
                Case clsConfigDmac.ActiveEnv.UserPermissions
                    If action <> clsConfigDmac.Actions.None And cboUsers.SelectedIndex <> -1 Then
                        SaveUserPermissions(cboUsers.SelectedValue)
                        cboUsers_SelectedIndexChanged(Me, e)
                    Else
                        MsgBox("No changes to save yet.")
                    End If
                Case clsConfigDmac.ActiveEnv.CompanyInformation
                    If ValidateCompanyInfo() Then
                        SaveCompanyInfo()
                        pnlCompanyInfo.Enabled = False
                        GetCompanyInfo()
                        niu = False
                    End If
                Case clsConfigDmac.ActiveEnv.ReportCategories
                    If ValidateReportCategory() Then
                        If SaveReportCategory() Then
                            If mblnNew Then
                                LoadReportCategories()
                                pnlRepCategories.Visible = False
                                tsNew.Enabled = True
                                tsSave.Enabled = False
                                tsCancel.Enabled = False
                                tsEdit.Enabled = False
                            Else
                                LoadReportCategories()
                                pnlRepCategories.Enabled = False
                                tsEdit.Enabled = True
                                tsSave.Enabled = False
                                tsCancel.Enabled = False
                            End If
                        End If
                    End If
                    niu = False
                Case clsConfigDmac.ActiveEnv.ReportDefinitions
                    If ValidateReportDefinition() Then
                        If saveReportDefinition() Then
                            trvwReportDefinition.Nodes.Clear()
                            LoadReports(trvwReportDefinition)
                            pbPreview.Enabled = False

                            pnlReportDefinitions.Enabled = False

                            If trvwReportDefinition.SelectedNode IsNot Nothing AndAlso trvwReportDefinition.SelectedNode.Level = 2 Then
                                tsNew.Enabled = False
                                tsEdit.Enabled = True
                                tsSave.Enabled = False
                                tsCancel.Enabled = False
                            Else

                                tsNew.Enabled = False
                                tsEdit.Enabled = False
                                tsSave.Enabled = False
                                tsCancel.Enabled = False
                                pbPreview.Visible = False

                                pnlReportDefinitions.Visible = False
                            End If
                            niu = False
                        End If
                    Else
                        niu = False
                    End If
              
            End Select
            If niu Then
                tsNew.Enabled = niu
                tsEdit.Enabled = False
                tsSave.Enabled = False
                tsCancel.Enabled = False

            End If
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Save Report Definition to DB ----- Harinath Reddy
    ''' </summary>
    ''' <remarks></remarks>
    Public Function saveReportDefinition() As Boolean

        Dim lobjDataTable As New DataTable
        Dim nImage As Image = pbPreview.Image

        Dim bImage() As Byte
        If nImage IsNot Nothing Then
            Using ms As System.IO.MemoryStream = New System.IO.MemoryStream
                nImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)

                bImage = ms.ToArray
            End Using
        Else
            bImage = New Byte() {0}
        End If
        Try
            Dim param As SqlParameter() = New SqlParameter(9) {}
            param(0) = New SqlParameter("@GroupIDKey", cboReportGroup.SelectedValue)
            param(1) = New SqlParameter("@CategoryIDKey", cboRportCategory.SelectedValue)
            param(2) = New SqlParameter("@ReportID ", txt_ReportID.Text.Trim())
            param(3) = New SqlParameter("@Description", txt_ReportDescription.Text.Trim())
            param(4) = New SqlParameter("@ReportFileName", txt_RemoteFileName.Text.Trim())
            param(5) = New SqlParameter("@Note", txt_Notes.Text.Trim())
            param(6) = New SqlParameter("@isActive", IIf(chkrptdefinitaionActive.Checked, 1, 0))
            param(7) = New SqlParameter("@PreviewImg", bImage)
            param(8) = New SqlParameter("@user", mstrUserId)
            param(9) = New SqlParameter("@ReportIDKey", IIf(action = clsConfigDmac.Actions.Edit, DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(0), 0))
            lobjDataTable = oExcelSS.getDataTable("uspConfiguration_IURepDefinitions", True, param)
            MsgBox("Information Inserted/Updated successfully", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Validata Report Definition ---- Harinath Reddy
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function ValidateReportDefinition() As Boolean
        Try
            If String.IsNullOrEmpty(txt_ReportID.Text) Then
                MsgBox("ReportID cannot be Empty! ", MsgBoxStyle.Information, "Configuration")
                txt_ReportID.Focus()
                Return False
            Else
                If txt_ReportID.Text.Contains(" ") Then
                    MsgBox("ReportID cannot contain Spaces! ", MsgBoxStyle.Information, "Configuration")
                    txt_ReportID.Focus()
                    Return False
                End If
            End If
            If String.IsNullOrEmpty(txt_ReportDescription.Text) Then
                MsgBox("Report Description cannot be Empty! ", MsgBoxStyle.Information, "Configuration")
                txt_ReportDescription.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txt_Notes.Text) Then
                MsgBox("Notes cannot be Empty! ", MsgBoxStyle.Information, "Configuration")
                txt_Notes.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txt_RemoteFileName.Text) Then
                MsgBox("Remote File Name cannot be Empty! ", MsgBoxStyle.Information, "Configuration")
                txt_RemoteFileName.Focus()
                Return False
            End If

            If cboRportCategory.SelectedIndex = -1 Then
                MsgBox("Report Category cannot be Empty! ", MsgBoxStyle.Information, "Configuration")
                cboRportCategory.Focus()
                Return False
            End If
            'If pbPreview.Image Is Nothing Then
            '    MsgBox("upload a preview image", MsgBoxStyle.Information, "Configuration")

            '    Return False
            'End If


        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
            Return False
        End Try

        Return True

    End Function
    Public Function ValidateUserInfo() As Boolean
        ValidateUserInfo = False
        If txtLogon.Text.Trim() = "" Then
            MsgBox("Userid should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtLogon.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        If txtPassword.Text.Trim() = "" Then
            MsgBox("Password should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtPassword.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        If txtName.Text.Trim() = "" Then
            MsgBox("Full Name should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtName.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        If txtEmail.Text.Trim() = "" Then
            MsgBox("EmailID should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtEmail.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        Return True
    End Function
    Public Function ValidateProfileInfo() As Boolean
        ValidateProfileInfo = False
        If txtPrName.Text.Trim = "" Then
            MsgBox("Profile Name should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtPrName.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        If txtPrDesc.Text.Trim = "" Then
            MsgBox("Description should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtPrDesc.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        Return True
    End Function
    Public Function ValidateCompanyInfo() As Boolean
        ValidateCompanyInfo = False
        If txtCoName.Text.Trim() = "" Then
            MsgBox("Company Name should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtCoName.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        If txtCoAddress.Text.Trim() = "" Then
            MsgBox("Company Address should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtCoAddress.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        If txtCoPhone.Text.Trim() = "" Then
            MsgBox("Company Phone should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtCoPhone.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        If txtCoFax.Text.Trim() = "" Then
            MsgBox("Company Fax should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtCoFax.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        If txtCoWebS.Text.Trim() = "" Then
            MsgBox("Company Web Site should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtCoWebS.Focus()
            '''''commented by Harinath reddy
            ''''''Exit Function

            ''''Added by Harinath
            Return False
        End If
        Return True
    End Function
    Public Function ValidateLogonAvailable() As Boolean
        ValidateLogonAvailable = True
        Dim dt As New DataTable("existUser")
        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@strUser", txtLogon.Text.Trim)
        dt = oExcelSS.getDataTable("uspConfiguration_UserAvailability", True, param)
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0)(0)) Then
                If Convert.ToInt16(dt.Rows(0)(0)) > 0 Then
                    MsgBox("The User [ " & txtLogon.Text.Trim & " ] Already exists, please choose different Login ID!", MsgBoxStyle.Information, "Configuration")
                    txtLogon.Focus()
                    Return False
                End If
            End If
        End If
        Return ValidateLogonAvailable
    End Function
    Public Function ValidateReportCategory() As Boolean
        ValidateReportCategory = False
        If txtRepCategoryName.Text.Trim() = "" Then
            MsgBox("Category Name should not be empty!", MsgBoxStyle.Information, "Configuration")
            txtRepCategoryName.Focus()
            Return False
        End If
        If cboRepGroupCat.SelectedIndex = -1 Then
            MsgBox("Report Category Group should not be empty!", MsgBoxStyle.Information, "Configuration")
            cboRepGroupCat.Focus()
            Return False
        End If
        Return True
    End Function
    Public Sub GetCompanyInfo()
        Dim dt As New DataTable
        Try

            Dim p As SqlParameter() = New SqlParameter(2) {}
            p(0) = New SqlParameter("@Keyword", "CompanyName")
            p(1) = New SqlParameter("@ModuleID", "all")
            p(2) = New SqlParameter("@Option", "G")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
            If dt.Rows.Count > 0 Then
                txtCoName.Text = dt.Rows(0)(0)
            Else
                txtCoName.Clear()
            End If
            p(0) = New SqlParameter("@Keyword", "CompanyAddress")
            p(1) = New SqlParameter("@ModuleID", "all")
            p(2) = New SqlParameter("@Option", "G")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
            If dt.Rows.Count > 0 Then
                txtCoAddress.Text = dt.Rows(0)(0)
            Else
                txtCoAddress.Clear()
            End If
            p(0) = New SqlParameter("@Keyword", "CompanyPhone")
            p(1) = New SqlParameter("@ModuleID", "all")
            p(2) = New SqlParameter("@Option", "G")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
            If dt.Rows.Count > 0 Then
                txtCoPhone.Text = dt.Rows(0)(0)
            Else
                txtCoPhone.Clear()
            End If
            p(0) = New SqlParameter("@Keyword", "CompanyFax")
            p(1) = New SqlParameter("@ModuleID", "all")
            p(2) = New SqlParameter("@Option", "G")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
            If dt.Rows.Count > 0 Then
                txtCoFax.Text = dt.Rows(0)(0)
            Else
                txtCoFax.Clear()
            End If
            p(0) = New SqlParameter("@Keyword", "CompanyWebsite")
            p(1) = New SqlParameter("@ModuleID", "all")
            p(2) = New SqlParameter("@Option", "G")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
            If dt.Rows.Count > 0 Then
                txtCoWebS.Text = dt.Rows(0)(0)
            Else
                txtCoWebS.Clear()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub SaveCompanyInfo()
        Dim dt As New DataTable
        Dim p As SqlParameter() = New SqlParameter(2) {}
        p(0) = New SqlParameter("@Keyword", "CompanyName")
        p(1) = New SqlParameter("@ModuleID", "all")
        p(2) = New SqlParameter("@Option", "G")
        Dim up As SqlParameter() = New SqlParameter(3) {}
        Dim sp As SqlParameter() = New SqlParameter(4) {}
        dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
        If dt.Rows.Count > 0 Then
            up(0) = New SqlParameter("@Keyword", "CompanyName")
            up(1) = New SqlParameter("@ModuleID", "all")
            up(2) = New SqlParameter("@Option", "U")
            up(3) = New SqlParameter("@OptionValue", txtCoName.Text.Trim)
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, up)
        Else
            sp(0) = New SqlParameter("@Keyword", "CompanyName")
            sp(1) = New SqlParameter("@ModuleID", "all")
            sp(2) = New SqlParameter("@Option", "I")
            sp(3) = New SqlParameter("@OptionValue", txtCoName.Text.Trim)
            sp(4) = New SqlParameter("@Program", "DMAC")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, sp)
        End If
        p(0) = New SqlParameter("@Keyword", "CompanyAddress")
        dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
        If dt.Rows.Count > 0 Then
            up(0) = New SqlParameter("@Keyword", "CompanyAddress")
            up(1) = New SqlParameter("@ModuleID", "all")
            up(2) = New SqlParameter("@Option", "U")
            up(3) = New SqlParameter("@OptionValue", txtCoAddress.Text.Trim)
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, up)
        Else
            sp(0) = New SqlParameter("@Keyword", "CompanyAddress")
            sp(1) = New SqlParameter("@ModuleID", "all")
            sp(2) = New SqlParameter("@Option", "I")
            sp(3) = New SqlParameter("@OptionValue", txtCoAddress.Text.Trim)
            sp(4) = New SqlParameter("@Program", "DMAC")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, sp)
        End If
        p(0) = New SqlParameter("@Keyword", "CompanyPhone")
        dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
        If dt.Rows.Count > 0 Then
            up(0) = New SqlParameter("@Keyword", "CompanyPhone")
            up(1) = New SqlParameter("@ModuleID", "all")
            up(2) = New SqlParameter("@Option", "U")
            up(3) = New SqlParameter("@OptionValue", txtCoPhone.Text.Trim)
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, up)
        Else
            sp(0) = New SqlParameter("@Keyword", "CompanyPhone")
            sp(1) = New SqlParameter("@ModuleID", "all")
            sp(2) = New SqlParameter("@Option", "I")
            sp(3) = New SqlParameter("@OptionValue", txtCoPhone.Text.Trim)
            sp(4) = New SqlParameter("@Program", "DMAC")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, sp)
        End If
        p(0) = New SqlParameter("@Keyword", "CompanyFax")
        dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
        If dt.Rows.Count > 0 Then
            up(0) = New SqlParameter("@Keyword", "CompanyFax")
            up(1) = New SqlParameter("@ModuleID", "all")
            up(2) = New SqlParameter("@Option", "U")
            up(3) = New SqlParameter("@OptionValue", txtCoFax.Text.Trim)
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, up)
        Else
            sp(0) = New SqlParameter("@Keyword", "CompanyFax")
            sp(1) = New SqlParameter("@ModuleID", "all")
            sp(2) = New SqlParameter("@Option", "I")
            sp(3) = New SqlParameter("@OptionValue", txtCoFax.Text.Trim)
            sp(4) = New SqlParameter("@Program", "DMAC")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, sp)
        End If
        p(0) = New SqlParameter("@Keyword", "CompanyWebsite")
        dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, p)
        If dt.Rows.Count > 0 Then
            up(0) = New SqlParameter("@Keyword", "CompanyWebsite")
            up(1) = New SqlParameter("@ModuleID", "all")
            up(2) = New SqlParameter("@Option", "U")
            up(3) = New SqlParameter("@OptionValue", txtCoWebS.Text.Trim)
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, up)
        Else
            sp(0) = New SqlParameter("@Keyword", "CompanyWebsite")
            sp(1) = New SqlParameter("@ModuleID", "all")
            sp(2) = New SqlParameter("@Option", "I")
            sp(3) = New SqlParameter("@OptionValue", txtCoWebS.Text.Trim)
            sp(4) = New SqlParameter("@Program", "DMAC")
            dt = oExcelSS.getDataTable("uspConfiguration_IUGOptions", True, sp)
        End If
    End Sub
    Public Sub SaveUserPermissions(pstrUser As String)
        Dim x As Integer
        oExcelSS.getDataTable("DELETE FROM AccessUserProfiles where ID = " & pstrUser, False)
        For x = 0 To lbOwnedProfiles.Items.Count - 1
            Dim p As SqlParameter() = New SqlParameter(1) {}
            p(0) = New SqlParameter("@ID", pstrUser)
            p(1) = New SqlParameter("@ProfileName", lbOwnedProfiles.Items(x))
            oExcelSS.getDataTable("uspConfiguration_AddProfile2User", True, p)
        Next
    End Sub
    Public Sub SaveProfileInfo(upddel As Integer)
        Dim param As SqlParameter() = New SqlParameter(2) {}
        Dim dt As New DataTable
        Dim pId As Integer = 0
        param(0) = New SqlParameter("@ProfileName", txtPrName.Text.Trim)
        param(1) = New SqlParameter("@Description", txtPrDesc.Text.Trim)
        If upddel = 2 Then
            param(2) = New SqlParameter("@ProfileID", 0)
        Else
            param(2) = New SqlParameter("@ProfileID", cboProfiles.SelectedValue)
        End If
        dt = oExcelSS.getDataTable("uspConfiguration_IUProfiles", True, param)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                pId = dt.Rows(0)(0)
            End If
        End If
        If pId = 0 Then pId = cboProfiles.SelectedValue
        Dim p As SqlParameter() = New SqlParameter(2) {}
        Dim ctr As New Control
        For Each ctr In chklbPermissions.Controls
            If IsNumeric(ctr.Tag) Then
                If Not DirectCast(ctr, CheckBox).CheckState = CheckState.Indeterminate Then
                    p(0) = New SqlParameter("@ProfileID", pId)
                    p(1) = New SqlParameter("@AccessID", ctr.Tag)
                    p(2) = New SqlParameter("@Setting", IIf(DirectCast(ctr, CheckBox).Checked, 1, 0))
                    dt = oExcelSS.getDataTable("uspConfiguration_IUProfilePermissions", True, p)
                End If
            End If
        Next
    End Sub
    Public Sub SaveUserInfo(upddel As Integer)
        Try
            Dim param As SqlParameter() = New SqlParameter(5) {}
            param(0) = New SqlParameter("@intMode", upddel)
            param(1) = New SqlParameter("@strUserID", txtLogon.Text)
            param(2) = New SqlParameter("@strUserName", txtName.Text)
            Dim password As String = ExcelSSGen.Main.Encrypt(txtPassword.Text.Trim, "dmac", True)
            param(3) = New SqlParameter("@strPassword", password)
            param(4) = New SqlParameter("@strEmail", txtEmail.Text)
            param(5) = New SqlParameter("@intActive", chkActive.Checked)
            Dim succ As Boolean = oExcelSS.saveData("uspConfiguration_InsertUser", param, "@outStatus")
            If succ Then
                If upddel = 2 Then
                    If action <> clsConfigDmac.Actions.None And cboUsers.SelectedIndex <> -1 Then
                        SaveUserPermissions(cboUsers.SelectedValue)
                    Else
                        MsgBox("No changes to save yet.")
                    End If

                Else
                    Dim lobjDataTable As System.Data.DataTable = oExcelSS.getDataTable("select ID FROM Access where UserID = '" & txtLogon.Text & "'", False)
                    Dim lintIndex As String = lobjDataTable.Rows(0).Item(0)
                    SaveUserPermissions(lintIndex)
                End If
                MsgBox("User Information Inserted/Updated Successfully", MsgBoxStyle.Information, "Configuration")
            Else
                MsgBox("User Information not Inserted/Updated", MsgBoxStyle.Information, "Configuration")
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("SaveUserInformation -> " + ex.Message.ToString())
        End Try
    End Sub
    Public Function SaveReportCategory() As Boolean
        Dim lblnUpdated As Boolean = False
        Try
            Dim param As SqlParameter() = New SqlParameter(4) {}
            param(0) = New SqlParameter("@CategoryName", txtRepCategoryName.Text.Trim)
            param(1) = New SqlParameter("@GroupIDKey", cboRepGroupCat.SelectedValue)
            param(2) = New SqlParameter("@isActive", IIf(chkRepCatIA.Checked, 1, 0))
            param(3) = New SqlParameter("@user", mstrUserId)
            param(4) = New SqlParameter("@CategoryIDKey", IIf(action = clsConfigDmac.Actions.Edit, DirectCast(trvwReportCategories.SelectedNode.Tag, System.Data.DataRow).Item(0), 0))
            Dim dt As New DataTable
            dt = oExcelSS.getDataTable("uspConfiguration_IURepCategories", True, param)
            MsgBox("Information Inserted/Updated successfully", MsgBoxStyle.Information)
            lblnUpdated = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            lblnUpdated = False
        End Try
        Return lblnUpdated
    End Function
    Private Sub tsNew_Click(sender As Object, e As EventArgs) Handles tsNew.Click
        mblnNew = True
        Try
            tsEdit.Enabled = False
            tsSave.Enabled = True
            tsCancel.Enabled = True
            tsNew.Enabled = False
            action = clsConfigDmac.Actions.Niu
            Select Case Env
                Case clsConfigDmac.ActiveEnv.ReportCategories
                    pnlRepCategories.Enabled = True
                    Dim lintindex As Integer = 0
                    For Each item In cboRepGroupCat.Items
                        If DirectCast(item, System.Data.DataRowView).Item(0) = DirectCast(trvwReportCategories.SelectedNode.Tag, System.Data.DataRow).Item(1) Then
                            cboRepGroupCat.SelectedIndex = lintindex
                            Exit For
                        End If
                        lintindex = lintindex + 1
                    Next
                    cboRepGroupCat.Enabled = True
                    pnlRepCategories.Visible = True
                    txtRepCategoryName.Clear()
                    chkRepCatIA.Checked = False


                    ''''Added by Harinath Reddy
                Case clsConfigDmac.ActiveEnv.ReportDefinitions
                    pnlReportDefinitions.Enabled = True
                    pnlReportDefinitions.Visible = True
                    pbPreview.Visible = True
                    pbPreview.Enabled = True
                    isLoading = True

                    Dim lintindex As Integer = 0
                    txt_Notes.Clear()
                    txt_RemoteFileName.Clear()
                    txt_ReportDescription.Clear()
                    txt_ReportID.Clear()
                    pbPreview.Image = Nothing
                    chkrptdefinitaionActive.Checked = True

                    Dim lstrCategory As String = ""
                    Dim lstrGroup As String = ""
                    If trvwReportDefinition.SelectedNode.Nodes.Count = 0 Then

                        lstrCategory = DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(0)
                        lstrGroup = DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(1)
                    Else
                        lstrCategory = DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(2)
                        lstrGroup = DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(1)
                    End If
                    oExcelSS.fillComboBox(cboReportGroup, "uspConfiguration_FillRepGroupsCbo", "GroupName", "GroupIDKey")
                    For Each item In cboReportGroup.Items
                        If DirectCast(item, System.Data.DataRowView).Item(0) = lstrGroup Then
                            cboReportGroup.SelectedIndex = lintindex
                            Exit For
                        End If
                        lintindex = lintindex + 1
                    Next
                    oExcelSS.fillComboBox(cboRportCategory, "select CategoryIDKey , CategoryName,GroupIDKey from ReportCategories where GroupIDKey=" + lstrGroup + "and isActive=1", "CategoryName", "CategoryIDKey", False)
                    lintindex = 0
                    For Each item In cboRportCategory.Items
                        If DirectCast(item, System.Data.DataRowView).Item(0) = lstrCategory Then
                            cboRportCategory.SelectedIndex = lintindex
                            Exit For
                        End If
                        lintindex = lintindex + 1
                    Next
                    cboRportCategory.Enabled = True
                    cboReportGroup.Enabled = True
                    isLoading = False
                Case clsConfigDmac.ActiveEnv.UserInformation
                    cboUsers.SelectedIndex = -1
                    pnlInfoUsers.Visible = True
                    pnlInfoUsers.Enabled = True
                    txtLogon.Enabled = True
                    cboUsers.Enabled = False
                    txtEmail.Clear()
                    txtLogon.Clear()
                    txtName.Clear()
                    txtPassword.Clear()
                    chkActive.Checked = False

                    ''''Added by Harinath Reddy

                    pnlPermissions.Visible = True
                    pnlPermissions.Enabled = True
                    lbOwnedProfiles.Items.Clear()
                    lbAvailableProfiles.Items.Clear()
                    Dim dt As New DataTable
                    Dim dp As New DataTable
                    Dim p As SqlParameter() = New SqlParameter(0) {}
                    p(0) = New SqlParameter("@UserID", cboUsers.SelectedValue)
                    If cboUsers.SelectedValue IsNot Nothing Then
                        dt = oExcelSS.getDataTable("uspConfiguration_GetProfilesFromUser", True, p)
                    End If
                    dp = oExcelSS.getDataTable("select * from AccessProfiles", False)
                    If Not dt Is Nothing Then
                        Dim r As DataRow
                        For Each r In dt.Rows
                            lbOwnedProfiles.Items.Add(r(1))
                        Next
                    End If
                    If Not dp Is Nothing Then
                        Dim dr As DataRow
                        Dim x As Integer = 0
                        Dim exists As Boolean = False
                        For Each dr In dp.Rows
                            exists = False
                            For x = 0 To dt.Rows.Count - 1
                                If dr(1).trim = dt.Rows(x)(1).trim Then
                                    exists = True
                                End If
                            Next
                            If Not exists Then
                                lbAvailableProfiles.Items.Add(dr(1))
                            End If
                        Next
                    End If
                    btnAddPr.Enabled = False
                    btnRemovePr.Enabled = False
                    action = clsConfigDmac.Actions.None
                    tsNew.Enabled = False
                    tsEdit.Enabled = False

                    ''''End

                Case clsConfigDmac.ActiveEnv.UserProfiles
                    cboProfiles.SelectedIndex = -1
                    pnlProfiles.Visible = True
                    pnlProfiles.Enabled = True
                    cboProfiles.Enabled = False
                    txtPrName.Enabled = True
                    chklbPermissions.Controls.Clear()
                    txtPrDesc.Clear()
                    txtPrName.Clear()
                    Dim dt As New DataTable
                    Dim p As SqlParameter() = New SqlParameter(0) {}
                    p(0) = New SqlParameter("@ProfileID", 0)
                    dt = oExcelSS.getDataTable("uspConfiguration_GetProfileInfo", True, p)
                    If Not dt Is Nothing Then
                        Dim group As String
                        group = dt.Rows(0)(2)
                        Dim chG As New CheckBox
                        chG.Text = "--" & group.ToUpper & "--"
                        chG.Name = group.Trim
                        chG.ThreeState = True
                        chG.CheckState = CheckState.Indeterminate
                        chG.TextAlign = ContentAlignment.MiddleCenter
                        chG.AutoSize = True
                        AddHandler chG.Click, AddressOf onCHClick
                        chklbPermissions.Controls.Add(chG)
                        Dim r As DataRow
                        For Each r In dt.Rows
begin:
                            If r(2).trim = group.Trim Then
                                Dim ch As New CheckBox
                                ch.Text = r(1)
                                ch.Tag = r(0)
                                ch.CheckState = CheckState.Unchecked
                                ch.TextAlign = ContentAlignment.MiddleCenter
                                ch.AutoSize = True
                                chklbPermissions.Controls.Add(ch)
                            Else
                                group = r(2)
                                Dim chL As New CheckBox
                                chL.Text = "--" & group.ToUpper & "--"
                                chL.Name = group.Trim
                                chL.ThreeState = True
                                chL.CheckState = CheckState.Indeterminate
                                chL.TextAlign = ContentAlignment.MiddleCenter
                                chL.AutoSize = True
                                AddHandler chL.Click, AddressOf onCHClick
                                chklbPermissions.Controls.Add(chL)
                                GoTo begin
                            End If
                        Next
                    End If
            End Select
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message, "Configuration Manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
            oExcelSS.ErrorLog("SaveUserInformation -> " + lobjException.Message.ToString())
        Finally
            isLoading = False
        End Try

    End Sub
    Private Sub onCHClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim dt As New DataTable
        Dim chk As Boolean = False
        Dim chto As Boolean
        Dim p As SqlParameter() = New SqlParameter(0) {}
        p(0) = New SqlParameter("@AccessGroup", DirectCast(sender, CheckBox).Name.Trim)
        dt = oExcelSS.getDataTable("uspConfiguration_GetAccessIDbyAccessGroup", True, p)
        If Not dt Is Nothing Then
            Dim r As DataRow
            For Each r In dt.Rows
                Dim ctr As Control
                For Each ctr In chklbPermissions.Controls
                    If ctr.Tag = r(0) Then
                        If DirectCast(ctr, CheckBox).Checked = False Then
                            chto = True
                        End If
                    End If
                Next
            Next
            For Each r In dt.Rows
                For Each ctr In chklbPermissions.Controls
                    If ctr.Tag = r(0) Then
                        DirectCast(ctr, CheckBox).Checked = chto
                    End If
                Next
            Next
        End If
        DirectCast(sender, CheckBox).CheckState = CheckState.Indeterminate
    End Sub
    Private Sub tcProfiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcProfiles.SelectedIndexChanged
        Select Case tcProfiles.SelectedIndex
            Case 0
                Env = clsConfigDmac.ActiveEnv.UserInformation
                tsNew.Enabled = True
                tsSave.Enabled = False
                tsEdit.Enabled = False
                tsCancel.Enabled = False
                Env = clsConfigDmac.ActiveEnv.UserInformation
                tsNew.Enabled = False
                tsEdit.Enabled = False
                tsCancel.Enabled = False
                tsSave.Enabled = True
                isLoading = True
                oExcelSS.fillComboBox(cboUsers, "uspConfiguration_FillUsersCbo", "UserID", "ID")
                cboUsers.SelectedIndex = -1
                btnAddPr.Enabled = False
                btnRemovePr.Enabled = False
                isLoading = False
                action = clsConfigDmac.Actions.None
            Case 1
                Env = clsConfigDmac.ActiveEnv.UserProfiles
                tsNew.Enabled = True
                tsSave.Enabled = False
                tsEdit.Enabled = False
                tsCancel.Enabled = False
            Case 2
                Env = clsConfigDmac.ActiveEnv.UserPermissions
                tsNew.Enabled = False
                tsEdit.Enabled = False
                tsCancel.Enabled = False
                tsSave.Enabled = True
                isLoading = True
                oExcelSS.fillComboBox(cboUsers, "uspConfiguration_FillUsersCbo", "UserID", "ID")
                cboUsers.SelectedIndex = -1
                btnAddPr.Enabled = False
                btnRemovePr.Enabled = False
                isLoading = False
                action = clsConfigDmac.Actions.None
            Case 3
                Env = clsConfigDmac.ActiveEnv.UserPreferences
                tsNew.Enabled = True
                tsSave.Enabled = False
                tsEdit.Enabled = False
                tsCancel.Enabled = False
        End Select
    End Sub



    Private Sub tcReports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcReports.SelectedIndexChanged
        Select Case tcReports.SelectedIndex
            Case 0
                Env = clsConfigDmac.ActiveEnv.ReportCategories
                tsNew.Enabled = True
                tsSave.Enabled = False
                tsEdit.Enabled = True
                tsCancel.Enabled = False
            Case 1
                Env = clsConfigDmac.ActiveEnv.ReportGroups
                tsNew.Enabled = True
                tsSave.Enabled = False
                tsEdit.Enabled = True
                tsCancel.Enabled = False
            Case 2
                Env = clsConfigDmac.ActiveEnv.ReportDefinitions
                tsNew.Enabled = False
                tsEdit.Enabled = True
                tsCancel.Enabled = False
                tsSave.Enabled = False
        End Select
    End Sub

    Private Sub cboProfiles_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboProfiles.SelectedIndexChanged
        If Not cboProfiles.SelectedIndex = -1 And Not isLoading Then
            pnlProfiles.Visible = True
            pnlProfiles.Enabled = False
            txtPrDesc.Clear()
            txtPrName.Clear()
            chklbPermissions.Controls.Clear()
            Dim dt As New DataTable
            Dim p As SqlParameter() = New SqlParameter(0) {}
            p(0) = New SqlParameter("@ProfileID", cboProfiles.SelectedValue)
            dt = oExcelSS.getDataTable("uspConfiguration_GetProfileInfo", True, p)
            If Not dt Is Nothing Then
                txtPrName.Text = dt.Rows(0)(0)
                txtPrDesc.Text = dt.Rows(0)(1)
                Dim group As String
                group = dt.Rows(0)(5)
                Dim chG As New CheckBox
                chG.Text = "--" & group.ToUpper & "--"
                chG.Name = group.Trim
                chG.ThreeState = True
                chG.CheckState = CheckState.Indeterminate
                chG.TextAlign = ContentAlignment.MiddleCenter
                chG.AutoSize = True
                AddHandler chG.Click, AddressOf onCHClick
                chklbPermissions.Controls.Add(chG)
                Dim r As DataRow
                For Each r In dt.Rows
begin:
                    If r(5).trim = group.Trim Then
                        Dim ch As New CheckBox
                        ch.Text = r(2)
                        ch.Tag = r(3)
                        ch.CheckState = IIf(r(4) = "1", CheckState.Checked, CheckState.Unchecked)
                        ch.TextAlign = ContentAlignment.MiddleCenter
                        ch.AutoSize = True
                        chklbPermissions.Controls.Add(ch)
                    Else
                        group = r(5)
                        Dim chL As New CheckBox
                        chL.Text = "--" & group.ToUpper & "--"
                        chL.Name = group.Trim
                        chL.ThreeState = True
                        chL.CheckState = CheckState.Indeterminate
                        chL.TextAlign = ContentAlignment.MiddleCenter
                        chL.AutoSize = True
                        AddHandler chL.Click, AddressOf onCHClick
                        chklbPermissions.Controls.Add(chL)
                        GoTo begin
                    End If
                Next
            End If
            tsEdit.Enabled = True
        Else
            pnlProfiles.Visible = False
            pnlProfiles.Enabled = False
        End If
    End Sub



    Private Sub lbOwnedProfiles_Enter(sender As Object, e As EventArgs) Handles lbOwnedProfiles.Enter
        If lbOwnedProfiles.Items.Count > 0 Then
            lbAvailableProfiles.ClearSelected()
            btnRemovePr.Enabled = True
            btnAddPr.Enabled = False
        Else
            btnRemovePr.Enabled = False
            btnAddPr.Enabled = False
        End If
    End Sub

    Private Sub lbAvailableProfiles_Enter(sender As Object, e As EventArgs) Handles lbAvailableProfiles.Enter
        If lbAvailableProfiles.Items.Count > 0 Then
            lbOwnedProfiles.ClearSelected()
            btnAddPr.Enabled = True
            btnRemovePr.Enabled = False
        Else
            btnRemovePr.Enabled = False
            btnAddPr.Enabled = False
        End If
    End Sub

    Private Sub btnAddPr_Click_1(sender As Object, e As EventArgs) Handles btnAddPr.Click
        If lbAvailableProfiles.SelectedIndex = -1 Then
            MsgBox("Must select a Profile in the box.")
            Exit Sub
        End If
        lbOwnedProfiles.Items.Add(lbAvailableProfiles.SelectedItem)
        lbAvailableProfiles.Items.Remove(lbAvailableProfiles.SelectedItem)
        action = clsConfigDmac.Actions.Niu
        If lbAvailableProfiles.Items.Count = 0 Then
            btnAddPr.Enabled = False
        End If
    End Sub

    Private Sub btnRemovePr_Click_1(sender As Object, e As EventArgs) Handles btnRemovePr.Click
        If lbOwnedProfiles.SelectedIndex = -1 Then
            MsgBox("Must select a Profile in the box.")
            Exit Sub
        End If
        action = clsConfigDmac.Actions.Niu
        lbAvailableProfiles.Items.Add(lbOwnedProfiles.SelectedItem)
        lbOwnedProfiles.Items.Remove(lbOwnedProfiles.SelectedItem)
        If lbOwnedProfiles.Items.Count = 0 Then
            btnRemovePr.Enabled = False
        End If
    End Sub


    Private Sub chkRepCatID_CheckedChanged(sender As Object, e As EventArgs)
     
    End Sub

    Private Sub chkRepCatIA_CheckedChanged(sender As Object, e As EventArgs)
   
    End Sub



    Private Sub cboRportCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRportCategory.SelectedIndexChanged
        Try


            If cboRportCategory.SelectedIndex <> -1 AndAlso Not isLoading Then
                Dim lobjDataTable As DataTable = Nothing
                lobjDataTable = oExcelSS.getDataTable("select GroupIDKey from ReportCategories where CategoryIDKey=" & cboRportCategory.SelectedValue, False)
                If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                    For Each item In cboReportGroup.Items
                        If DirectCast(item, System.Data.DataRowView).Item(0) = lobjDataTable.Rows(0)(0) Then
                            cboReportGroup.SelectedValue = lobjDataTable.Rows(0)(0)
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message)
        End Try
    End Sub

    Private Sub cboReportGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportGroup.SelectedIndexChanged
        If cboReportGroup.SelectedValue IsNot Nothing AndAlso Not isLoading Then
            oExcelSS.fillComboBox(cboRportCategory, "select CategoryIDKey , CategoryName,GroupIDKey from ReportCategories where isActive=1 and GroupIDKey=" + cboReportGroup.SelectedValue.ToString, "CategoryName", "CategoryIDKey", False)
            cboRportCategory.SelectedIndex = -1
        End If

    End Sub

    Private Sub chkrptdefinitaionActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkrptdefinitaionActive.CheckedChanged
    
    End Sub

    Private Sub chkrptdefinitiondeleted_CheckedChanged(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs)
        If opdImageDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(opdImageDialog.FileName) Then
                Dim fs As New IO.FileStream(opdImageDialog.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                Dim bt() As Byte = New Byte(fs.Length - 1) {}
                fs.Read(bt, 0, bt.Length)
                AutosizeImage(DirectCast(Image.FromStream(fs), Image), pbPreview)
                fs.Close()
                Dim nImage As Image = pbPreview.Image
                If Not nImage Is Nothing Then
                    Using ms As System.IO.MemoryStream = New System.IO.MemoryStream
                        nImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                        Dim bImage() As Byte
                        bImage = ms.ToArray
                        'Dim p As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(1) {}
                        'p(0) = New System.Data.SqlClient.SqlParameter("@ReportIDKey", trvRptViewGroup.SelectedNode.Tag)
                        'p(1) = New System.Data.SqlClient.SqlParameter("@image", bImage)
                        'oExcelSS.isSavedData("uspDmac_SavePreviewReportImage", , , , "strStatus", p)
                    End Using
                End If
            Else
                MsgBox("File Not Found")
            End If
        End If
    End Sub
    Public Sub AutosizeImage(ByVal ImagePath As Image, ByVal picBox As PictureBox, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            picBox.SizeMode = pSizeMode

            Dim imgOrg As Bitmap
            Dim imgShow As Bitmap
            Dim g As Graphics
            Dim divideBy, divideByH, divideByW As Double
            imgOrg = ImagePath

            divideByW = imgOrg.Width / picBox.Width
            divideByH = imgOrg.Height / picBox.Height
            If divideByW > 1 Or divideByH > 1 Then
                If divideByW > divideByH Then
                    divideBy = divideByW
                Else
                    divideBy = divideByH
                End If

                imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                g = Graphics.FromImage(imgShow)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                g.Dispose()
            Else
                imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                g = Graphics.FromImage(imgShow)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                g.Dispose()
            End If
            imgOrg.Dispose()

            picBox.Image = imgShow



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    ''' <summary>
    ''' Added by Harinath to display avaiable settingd
    ''' </summary>
    ''' <param name="sender"></param>
    ''' 
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsSettings_Click(sender As Object, e As EventArgs) Handles tsSettings.Click
        Try
            Dim lobjfrmSettings As New frmSettings()
            Dim lobjsettingsTreeView As New TreeView()
            Dim lobjDataTable As DataTable = Nothing
            lobjDataTable = oExcelSS.getDataTable("select  ModuleID,Keyword,ProgramName,OptionValue,OptionID from vwOptions where IsActive=1", False)
            If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then

                For Each lobjRow As DataRow In lobjDataTable.Rows
                    Dim lobjParentTreeNode As TreeNode = Nothing
                    Dim lobjChildnode As TreeNode = Nothing
                    lobjParentTreeNode = New TreeNode()
                    lobjParentTreeNode.Text = lobjRow(0).ToString()
                    lobjParentTreeNode.Name = lobjRow(0).ToString()
                    If lobjfrmSettings.trvwSettings.Nodes.Find(lobjRow(0).ToString(), False).Length >= 1 Then
                        lobjParentTreeNode = lobjfrmSettings.trvwSettings.Nodes.Item(lobjRow(0).ToString())
                        lobjChildnode = New TreeNode()
                        lobjChildnode.Text = lobjRow(1).ToString
                        lobjChildnode.Name = lobjRow(1).ToString
                        lobjChildnode.Tag = lobjRow
                        lobjParentTreeNode.Nodes.Add(lobjChildnode)

                    Else
                        lobjChildnode = New TreeNode()
                        lobjChildnode.Text = lobjRow(1).ToString
                        lobjChildnode.Name = lobjRow(1).ToString
                        lobjChildnode.Tag = lobjRow
                        lobjParentTreeNode.Nodes.Add(lobjChildnode)
                        lobjfrmSettings.trvwSettings.Nodes.Add(lobjParentTreeNode)
                    End If
                Next

            End If
            lobjDataTable = oExcelSS.getDataTable("select ModuleID from AccessMaster")
            If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then

                For Each lobjRow As DataRow In lobjDataTable.Rows
                    Dim lobjParentTreeNode As TreeNode = Nothing
                    If lobjfrmSettings.trvwSettings.Nodes.Find(lobjRow(0).ToString(), False).Length = 0 Then
                        lobjParentTreeNode = New TreeNode()
                        lobjParentTreeNode.Text = lobjRow(0).ToString()
                        lobjParentTreeNode.Name = lobjRow(0).ToString()
                        lobjfrmSettings.trvwSettings.Nodes.Add(lobjParentTreeNode)
                    End If
                Next
            End If

            'lobjfrmSettings.TreeView1 = lobjsettingsTreeView
            lobjfrmSettings.oExcelSS = oExcelSS
            lobjfrmSettings.ShowDialog(Me)
        Catch lobjException As Exception

        End Try
    End Sub


    Private Sub LoadReportCategories()
        Try
            trvwReportCategories.Nodes.Clear()
            Dim lobjDataTable As DataTable = Nothing
            lobjDataTable = oExcelSS.getDataTable("select rep.CategoryIDKey,rep.GroupIDKey,rep.CategoryName,grp.GroupName,rep.isActive from ReportCategories rep,ReportGroups grp where (rep.GroupIDKey=grp.GroupIDKey )", False)
            If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                For Each lobjRow As DataRow In lobjDataTable.Rows
                    Dim lobjParentTreeNode As TreeNode = Nothing
                    Dim lobjChildnode As TreeNode = Nothing
                    Dim lobjChildNode2 As New TreeNode()
                    lobjParentTreeNode = New TreeNode()
                    lobjParentTreeNode.Text = lobjRow(3).ToString()
                    lobjParentTreeNode.Name = lobjRow(3).ToString()
                    lobjParentTreeNode.Tag = lobjRow
                    If trvwReportCategories.Nodes.Find(lobjRow(3).ToString(), False).Length >= 1 Then
                        lobjParentTreeNode = trvwReportCategories.Nodes.Item(lobjRow(3).ToString())
                        If lobjParentTreeNode.Nodes.Find(lobjRow(2).ToString(), False).Length >= 1 Then
                            lobjChildnode = lobjParentTreeNode.Nodes.Item(lobjRow(2).ToString())
                        Else
                            lobjChildnode = New TreeNode()
                            lobjChildnode.Text = lobjRow(2).ToString
                            lobjChildnode.Name = lobjRow(2).ToString
                            lobjChildnode.Tag = lobjRow
                            lobjParentTreeNode.Nodes.Add(lobjChildnode)
                        End If

                    Else
                        lobjChildnode = New TreeNode()
                        lobjChildnode.Text = lobjRow(2).ToString
                        lobjChildnode.Name = lobjRow(2).ToString
                        lobjChildnode.Tag = lobjRow
                        lobjParentTreeNode.Nodes.Add(lobjChildnode)
                        trvwReportCategories.Nodes.Add(lobjParentTreeNode)
                    End If
                Next
            End If
            lobjDataTable = oExcelSS.getDataTable("select grp.GroupIDKey,grp.GroupName from ReportGroups grp where  grp.isActive=1  ", False)
            If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                For Each lobjRow As DataRow In lobjDataTable.Rows
                    Dim lobjParentTreeNode As TreeNode = Nothing
                    Dim lobjChildnode As TreeNode = Nothing
                    Dim lobjChildNode2 As New TreeNode()
                    lobjParentTreeNode = New TreeNode()
                    lobjParentTreeNode.Text = lobjRow(1).ToString()
                    lobjParentTreeNode.Name = lobjRow(1).ToString()
                    lobjParentTreeNode.Tag = lobjRow
                    If Not (trvwReportCategories.Nodes.Find(lobjRow(1).ToString(), False).Length >= 1) Then
                        trvwReportCategories.Nodes.Add(lobjParentTreeNode)
                    End If
                Next
            End If

        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub trvwReportCategories_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvwReportCategories.AfterSelect
        If e.Node.Parent IsNot Nothing Then
            pnlRepCategories.Visible = True
            pnlRepCategories.Enabled = False

            ''''Set value in the Report Category 
            txtRepCategoryName.Text = trvwReportCategories.SelectedNode.Name

            Dim lintSelectedIndex As Integer = 0
            For Each items In cboRepGroupCat.Items
                Dim lintGroupIDKey As Integer = DirectCast(trvwReportCategories.SelectedNode.Tag, System.Data.DataRow).Item(1)
                If lintGroupIDKey = DirectCast(items, System.Data.DataRowView).Item(0) Then
                    cboRepGroupCat.SelectedIndex = lintSelectedIndex
                End If
                lintSelectedIndex = lintSelectedIndex + 1
            Next
            chkRepCatIA.Checked = DirectCast(e.Node.Tag, System.Data.DataRow).Item(4).ToString

            tsNew.Enabled = False
            tsEdit.Enabled = True
            tsCancel.Enabled = False
            tsSave.Enabled = False
        Else
            tsNew.Enabled = True
            tsEdit.Enabled = False
            tsCancel.Enabled = False
            tsSave.Enabled = False
            pnlRepCategories.Visible = False
            pnlRepCategories.Enabled = True
        End If
    End Sub

    Private Sub trvwReportDefinition_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvwReportDefinition.AfterSelect
        If e.Node.Nodes.Count = 0 AndAlso e.Node.Level = 2 Then
            Try
                isLoading = True
                pnlReportDefinitions.Visible = True
                pnlReportDefinitions.Enabled = False
                pbPreview.Visible = True

                txt_ReportID.Clear()
                txt_ReportDescription.Clear()
                pbPreview.Image = Nothing
                txt_Notes.Clear()
                chkrptdefinitaionActive.Checked = False

                pbPreview.Enabled = False

                oExcelSS.fillComboBox(cboRportCategory, "uspConfiguration_FillRepCategoriesCbo", "categoryname", "categoryidkey")
                oExcelSS.fillComboBox(cboReportGroup, "uspConfiguration_FillRepGroupsCbo", "GroupName", "GroupIDKey")
                cboRportCategory.SelectedIndex = -1
                cboReportGroup.SelectedIndex = -1
                Dim lobjDataTable As DataTable = Nothing
                Dim lintindex As Integer = 0
                lobjDataTable = oExcelSS.getDataTable("select CategoryIDKey,GroupIDKey,Description,ReportFileName,Note,isActive,isDeleted,PreviewImg from ReportDefs where ReportIDKey=" & CType(e.Node.Tag, Data.DataRow).Item(0), False)
                If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                    Dim lstrCategory As String = ""
                    Dim lstrGroup As String = ""
                    If trvwReportDefinition.SelectedNode.Nodes.Count = 0 Then

                        lstrCategory = DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(0)
                        lstrGroup = DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(1)
                    Else
                        lstrCategory = DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(2)
                        lstrGroup = DirectCast(trvwReportDefinition.SelectedNode.Tag, System.Data.DataRow).Item(1)
                    End If

                    For Each item In cboReportGroup.Items
                        If DirectCast(item, System.Data.DataRowView).Item(0) = lstrGroup Then
                            cboReportGroup.SelectedIndex = lintindex
                            Exit For
                        End If
                        lintindex = lintindex + 1
                    Next
                    oExcelSS.fillComboBox(cboRportCategory, "select CategoryIDKey , CategoryName,GroupIDKey from ReportCategories where GroupIDKey=" + lstrGroup + "and isActive=1", "CategoryName", "CategoryIDKey", False)
                    lintindex = 0
                    For Each item In cboRportCategory.Items
                        If DirectCast(item, System.Data.DataRowView).Item(0) = lstrCategory Then
                            cboRportCategory.SelectedIndex = lintindex
                            Exit For
                        End If
                        lintindex = lintindex + 1
                    Next
                    cboRportCategory.Enabled = True
                    cboReportGroup.Enabled = True
                    txt_ReportDescription.Text = lobjDataTable.Rows(0)(2)
                    txt_ReportID.Text = CType(e.Node.Tag, Data.DataRow).Item(3)
                    txt_Notes.Text = lobjDataTable.Rows(0)(4)
                    txt_RemoteFileName.Text = lobjDataTable.Rows(0)(3)
                    chkrptdefinitaionActive.Checked = lobjDataTable.Rows(0)(5)
                    If (Not IsDBNull(lobjDataTable.Rows(0)(7))) AndAlso (Not DirectCast(lobjDataTable.Rows(0)(7), Byte()).Length = 1) AndAlso (Not DirectCast(lobjDataTable.Rows(0)(7), Byte())(0) = 0) Then
                        Using ms As New IO.MemoryStream(CType(lobjDataTable.Rows(0)(7), Byte()))
                            Dim img As Image = Image.FromStream(ms)
                            AutosizeImage(img, pbPreview)
                        End Using
                    End If
                End If
            Catch lobjException As Exception
                MessageBox.Show(lobjException.Message)
            Finally
                isLoading = False
            End Try

            tsEdit.Enabled = True
            tsCancel.Enabled = False
            tsSave.Enabled = False
            tsNew.Enabled = False
        ElseIf e.Node.Level = 1 Then
            pnlReportDefinitions.Visible = False

            pbPreview.Visible = False
            tsNew.Enabled = True
            tsEdit.Enabled = False
            tsCancel.Enabled = False
            tsSave.Enabled = False
        Else
            pnlReportDefinitions.Visible = False

            pbPreview.Visible = False
            tsNew.Enabled = False
            tsEdit.Enabled = False
            tsCancel.Enabled = False
            tsSave.Enabled = False
        End If
    End Sub

    Private Sub btnAssignImage_Click(sender As Object, e As EventArgs) Handles btnAssignImage.Click
        If opdImageDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(opdImageDialog.FileName) Then
                Dim fs As New IO.FileStream(opdImageDialog.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                Dim bt() As Byte = New Byte(fs.Length - 1) {}
                fs.Read(bt, 0, bt.Length)
                AutosizeImage(DirectCast(Image.FromStream(fs), Image), pbPreview)
                fs.Close()
                Dim nImage As Image = pbPreview.Image
                If Not nImage Is Nothing Then
                    Using ms As System.IO.MemoryStream = New System.IO.MemoryStream
                        nImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                        Dim bImage() As Byte
                        bImage = ms.ToArray
                        'Dim p As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(1) {}
                        'p(0) = New System.Data.SqlClient.SqlParameter("@ReportIDKey", trvRptViewGroup.SelectedNode.Tag)
                        'p(1) = New System.Data.SqlClient.SqlParameter("@image", bImage)
                        'oExcelSS.isSavedData("uspDmac_SavePreviewReportImage", , , , "strStatus", p)
                    End Using
                End If
            Else
                MsgBox("File Not Found")
            End If
        End If
    End Sub
End Class
