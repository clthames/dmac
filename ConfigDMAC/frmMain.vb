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
                    tsEdit.Enabled = True
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
                    oExcelSS.fillComboBox(cboRepCategories, "uspConfiguration_FillRepCategoriesCbo", "categoryname", "categoryidkey")
                    oExcelSS.fillComboBox(cboRepGroupCat, "uspConfiguration_FillRepGroupsCbo", "groupname", "groupidkey")
                    cboRepCategories.SelectedIndex = -1
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
                    tsNew.Enabled = True
                    tbcReportDefinition.Visible = True
                    cboReportDefinitions.Enabled = True
                    tbcReportDefinition.Location = tc
                    cboReportDefinitions.SelectedIndex = -1
                    oExcelSS.fillComboBox(cboReportDefinitions, "uspConfiguration_FillRepDefinitionsCbo", "ReportID", "ReportIDKey")
                    cboReportDefinitions.SelectedIndex = -1
                    isLoading = False

                Case "nReports"
                    isLoading = True
                    Env = clsConfigDmac.ActiveEnv.Reports
                    hideTabs()
                    dgvParameters.Rows.Clear()
                    trvwReports.Nodes.Clear()
                    LoadReports()
                    tsNew.Enabled = False
                    tbcntrlReports.Visible = True
                    If dgvParameters.Rows.Count > 0 Then
                        tsCancel.Enabled = True
                        tsSave.Enabled = True
                    Else
                        tsCancel.Enabled = False
                        tsSave.Enabled = False
                    End If

                    tsEdit.Enabled = False


                    ''''End
            End Select
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        btnAssign.Visible = False
        pnlReportDefinitions.Visible = False
        tbcntrlReports.Visible = False
    End Sub
    ''' <summary>
    ''' Added by Harinath for Reports
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub LoadReports()
        Try

            Dim lobjDataTable As DataTable = Nothing
            lobjDataTable = oExcelSS.getDataTable("select rep.ReportIDKey,rep.GroupIDKey,rep.CategoryIDKey,rep.ReportID,rep.ReportFileName,grp.GroupName,cat.CategoryName from ReportDefs rep,ReportGroups grp,ReportCategories cat where  rep.isActive=1  and (rep.GroupIDKey=grp.GroupIDKey and rep.CategoryIDKey=cat.CategoryIDKey)", False)
            If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                For Each lobjRow As DataRow In lobjDataTable.Rows
                    Dim lobjParentTreeNode As TreeNode = Nothing
                    Dim lobjChildnode As TreeNode = Nothing
                    Dim lobjChildNode2 As New TreeNode()
                    lobjParentTreeNode = New TreeNode()
                    lobjParentTreeNode.Text = lobjRow(5).ToString()
                    lobjParentTreeNode.Name = lobjRow(5).ToString()
                    If trvwReports.Nodes.Find(lobjRow(5).ToString(), False).Length >= 1 Then
                        lobjParentTreeNode = trvwReports.Nodes.Item(lobjRow(5).ToString())
                        If trvwReports.Nodes.Find(lobjRow(6).ToString(), False).Length >= 1 Then
                            lobjChildnode = trvwReports.Nodes.Item(lobjRow(6).ToString())
                        Else
                            lobjChildnode = New TreeNode()
                            lobjChildnode.Text = lobjRow(6).ToString
                            lobjChildnode.Name = lobjRow(6).ToString
                            lobjChildnode.Tag = lobjRow
                        End If
                        lobjChildNode2 = New TreeNode
                        lobjChildNode2.Text = lobjRow(3).ToString
                        lobjChildNode2.Name = lobjRow(3).ToString
                        lobjChildNode2.Tag = lobjRow
                        lobjChildnode.Nodes.Add(lobjChildNode2)
                        lobjParentTreeNode.Nodes.Add(lobjChildnode)

                    Else
                        If trvwReports.Nodes.Find(lobjRow(6).ToString(), False).Length >= 1 Then
                            lobjChildnode = trvwReports.Nodes.Item(lobjRow(6).ToString())
                        Else
                            lobjChildnode = New TreeNode()
                            lobjChildnode.Text = lobjRow(6).ToString
                            lobjChildnode.Name = lobjRow(6).ToString
                            lobjChildnode.Tag = lobjRow
                        End If
                        lobjChildNode2 = New TreeNode
                        lobjChildNode2.Text = lobjRow(3).ToString
                        lobjChildNode2.Name = lobjRow(3).ToString
                        lobjChildNode2.Tag = lobjRow
                        lobjChildnode.Nodes.Add(lobjChildNode2)
                        lobjParentTreeNode.Nodes.Add(lobjChildnode)
                        trvwReports.Nodes.Add(lobjParentTreeNode)
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

    ''''Commented by Harinath 25-JAN-2015

    '    Private Sub cboProfiles_SelectedIndexChanged(sender As Object, e As EventArgs)
    '        If Not cboProfiles.SelectedIndex = -1 And Not isLoading Then
    '            pnlProfiles.Visible = True
    '            pnlProfiles.Enabled = False
    '            txtPrDesc.Clear()
    '            txtPrName.Clear()
    '            chklbPermissions.Controls.Clear()
    '            Dim dt As New DataTable
    '            Dim p As SqlParameter() = New SqlParameter(0) {}
    '            p(0) = New SqlParameter("@ProfileID", cboProfiles.SelectedValue)
    '            dt = oExcelSS.getDataTable("uspConfiguration_GetProfileInfo", True, p)
    '            If Not dt Is Nothing Then
    '                txtPrName.Text = dt.Rows(0)(0)
    '                txtPrDesc.Text = dt.Rows(0)(1)
    '                Dim group As String
    '                group = dt.Rows(0)(5)
    '                Dim chG As New CheckBox
    '                chG.Text = "--" & group.ToUpper & "--"
    '                chG.Name = group.Trim
    '                chG.ThreeState = True
    '                chG.CheckState = CheckState.Indeterminate
    '                chG.TextAlign = ContentAlignment.MiddleCenter
    '                chG.AutoSize = True
    '                AddHandler chG.Click, AddressOf onCHClick
    '                chklbPermissions.Controls.Add(chG)
    '                Dim r As DataRow
    '                For Each r In dt.Rows
    'begin:
    '                    If r(5).trim = group.Trim Then
    '                        Dim ch As New CheckBox
    '                        ch.Text = r(2)
    '                        ch.Tag = r(3)
    '                        ch.CheckState = IIf(r(4) = "1", CheckState.Checked, CheckState.Unchecked)
    '                        ch.TextAlign = ContentAlignment.MiddleCenter
    '                        ch.AutoSize = True
    '                        chklbPermissions.Controls.Add(ch)
    '                    Else
    '                        group = r(5)
    '                        Dim chL As New CheckBox
    '                        chL.Text = "--" & group.ToUpper & "--"
    '                        chL.Name = group.Trim
    '                        chL.ThreeState = True
    '                        chL.CheckState = CheckState.Indeterminate
    '                        chL.TextAlign = ContentAlignment.MiddleCenter
    '                        chL.AutoSize = True
    '                        AddHandler chL.Click, AddressOf onCHClick
    '                        chklbPermissions.Controls.Add(chL)
    '                        GoTo begin
    '                    End If
    '                Next
    '            End If
    '            tsEdit.Enabled = True
    '        Else
    '            pnlProfiles.Visible = False
    '            pnlProfiles.Enabled = False
    '        End If
    '    End Sub

    '''' END
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
                    If Not cboRepCategories.SelectedIndex = -1 Then
                        cboRepCategories.Enabled = False
                        pnlRepCategories.Enabled = True
                        pnlRepCategories.Visible = True
                    Else
                        niu = False
                    End If
                Case clsConfigDmac.ActiveEnv.ReportDefinitions
                    If Not cboReportDefinitions.SelectedIndex = -1 Then
                        cboReportDefinitions.Enabled = False
                        pnlReportDefinitions.Enabled = True
                        pbPreview.Enabled = True
                        btnAssign.Enabled = True
                    Else
                        niu = False
                    End If
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
                    tsEdit.Enabled = True
                    tsSave.Enabled = False
                    tsCancel.Enabled = False
                    pnlRepCategories.Visible = False
                    cboRepCategories.Enabled = True
                    isLoading = True
                    cboRepCategories.SelectedIndex = -1
                    cboRepCategories_SelectedIndexChanged(Me, e)
                    isLoading = True = False
                Case clsConfigDmac.ActiveEnv.ReportDefinitions
                    isLoading = True
                    tsNew.Enabled = True
                    tsEdit.Enabled = True
                    tsSave.Enabled = False
                    tsCancel.Enabled = False
                    cboReportDefinitions.Enabled = True
                    pnlReportDefinitions.Visible = False
                    btnAssign.Visible = False
                    pbPreview.Enabled = False
                    cboReportDefinitions.SelectedIndex = -1

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
                        SaveReportCategory()
                        ''''Added by Harinath Reddy
                        cboRepCategories.SelectedIndex = -1
                        pnlRepCategories.Visible = False
                        pnlRepCategories.Enabled = False
                        cboRepCategories.Enabled = True
                        isLoading = True
                        oExcelSS.fillComboBox(cboRepCategories, "uspConfiguration_FillRepCategoriesCbo", "categoryname", "categoryidkey")
                        isLoading = False

                    End If
                Case clsConfigDmac.ActiveEnv.ReportDefinitions
                    If ValidateReportDefinition() Then
                        If saveReportDefinition() Then
                            pbPreview.Enabled = False
                            btnAssign.Enabled = False
                            pnlReportDefinitions.Enabled = False
                            cboReportDefinitions.Enabled = True
                        Else
                            niu = False
                        End If
                    Else
                        niu = False
                    End If
                Case clsConfigDmac.ActiveEnv.Reports
                    SaveReportParameters()
                    niu = False
            End Select
            If niu Then
                tsNew.Enabled = niu
                tsEdit.Enabled = True
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
        Using ms As System.IO.MemoryStream = New System.IO.MemoryStream
            nImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)

            bImage = ms.ToArray
        End Using
        Try
            Dim param As SqlParameter() = New SqlParameter(10) {}
            param(0) = New SqlParameter("@GroupIDKey", cboReportGroup.SelectedValue)
            param(1) = New SqlParameter("@CategoryIDKey", cboRportCategory.SelectedValue)
            param(2) = New SqlParameter("@ReportID ", txt_ReportID.Text.Trim())
            param(3) = New SqlParameter("@Description", txt_ReportDescription.Text.Trim())
            param(4) = New SqlParameter("@ReportFileName", txt_RemoteFileName.Text.Trim())
            param(5) = New SqlParameter("@Note", txt_Notes.Text.Trim())
            param(6) = New SqlParameter("@isActive", IIf(chkrptdefinitaionActive.Checked, 1, 0))
            param(7) = New SqlParameter("@isDeleted", IIf(chkrptdefinitiondeleted.Checked, 1, 0))
            param(8) = New SqlParameter("@PreviewImg", bImage)
            param(9) = New SqlParameter("@user", mstrUserId)
            param(10) = New SqlParameter("@ReportIDKey", IIf(action = clsConfigDmac.Actions.Edit, cboReportDefinitions.SelectedValue, 0))
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
            If pbPreview.Image Is Nothing Then
                MsgBox("upload a preview image", MsgBoxStyle.Information, "Configuration")
                btnAssign.Focus()
                Return False
            End If


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
    Public Sub SaveReportCategory()
        Try
            Dim param As SqlParameter() = New SqlParameter(5) {}
            param(0) = New SqlParameter("@CategoryName", txtRepCategoryName.Text.Trim)
            param(1) = New SqlParameter("@GroupIDKey", cboRepGroupCat.SelectedValue)
            param(2) = New SqlParameter("@isActive", IIf(chkRepCatIA.Checked, 1, 0))
            param(3) = New SqlParameter("@isDeleted", IIf(chkRepCatID.Checked, 1, 0))
            param(4) = New SqlParameter("@user", mstrUserId)
            param(5) = New SqlParameter("@CategoryIDKey", IIf(action = clsConfigDmac.Actions.Edit, cboRepCategories.SelectedValue, 0))
            Dim dt As New DataTable
            dt = oExcelSS.getDataTable("uspConfiguration_IURepCategories", True, param)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        MsgBox("Information Inserted/Updated successfully", MsgBoxStyle.Information)
    End Sub
    Private Sub tsNew_Click(sender As Object, e As EventArgs) Handles tsNew.Click
        tsEdit.Enabled = False
        tsSave.Enabled = True
        tsCancel.Enabled = True
        tsNew.Enabled = False
        action = clsConfigDmac.Actions.Niu
        Select Case Env
            Case clsConfigDmac.ActiveEnv.ReportCategories
                pnlRepCategories.Enabled = True
                cboRepCategories.SelectedIndex = -1
                cboRepCategories.Enabled = False
                cboRepGroupCat.SelectedIndex = -1
                pnlRepCategories.Visible = True
                txtRepCategoryName.Clear()
                chkRepCatIA.Checked = False
                chkRepCatID.Checked = False

                ''''Added by Harinath Reddy
            Case clsConfigDmac.ActiveEnv.ReportDefinitions
                pnlReportDefinitions.Enabled = True
                pnlReportDefinitions.Visible = True
                cboReportDefinitions.Enabled = False
                cboReportDefinitions.Enabled = False
                txt_Notes.Clear()
                txt_RemoteFileName.Clear()
                txt_ReportDescription.Clear()
                txt_ReportID.Clear()
                chkrptdefinitaionActive.Checked = True
                cboRportCategory.SelectedIndex = -1
                cboReportGroup.SelectedIndex = -1


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
    Private Sub cboRepCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRepCategories.SelectedIndexChanged
        ''''Edited By Harinath


        If Not cboRepCategories.SelectedIndex = -1 And Not isLoading Then
            pnlRepCategories.Visible = True
            pnlRepCategories.Enabled = False

            ''''Set value in the Report Category 
            txtRepCategoryName.Text = DirectCast(cboRepCategories.SelectedItem, System.Data.DataRowView).Item(1)

            Dim dt As New DataTable
            Dim p As SqlParameter() = New SqlParameter(0) {}
            p(0) = New SqlParameter("@catIdKey", cboRepCategories.SelectedValue)
            dt = oExcelSS.getDataTable("select GroupIDKey,isDeleted,isActive from ReportCategories where CategoryIDKey= " & cboRepCategories.SelectedValue, False)
            Dim lintSelectedIndex As Integer = 0
            For Each items In cboRepGroupCat.Items
                Dim lintGroupIDKey As Integer = dt.Rows(0)(0)
                If lintGroupIDKey = DirectCast(items, System.Data.DataRowView).Item(0) Then
                    cboRepGroupCat.SelectedIndex = lintSelectedIndex
                End If
                lintSelectedIndex = lintSelectedIndex + 1
            Next

            chkRepCatIA.Checked = dt.Rows(0)(2)
            chkRepCatID.Checked = dt.Rows(0)(1)


            'If Not dt Is Nothing Then
            '    txtRepCategoryName.Text = dt.Rows(0)(2)
            '    cboRepGroupCat.SelectedValue = dt.Rows(0)(1)
            '    chkRepCatIA.Checked = IIf(dt.Rows(0)(3) = 0, False, True)
            '    chkRepCatID.Checked = IIf(dt.Rows(0)(4) = 0, False, True)
            'End If
        End If
    End Sub

    ''''Commented By Harianth on 25-JAN-2015
    'Private Sub cboUsers_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If Not cboUsers.SelectedIndex = -1 And Not isLoading Then
    '        pnlPermissions.Visible = True
    '        pnlPermissions.Enabled = True
    '        lbOwnedProfiles.Items.Clear()
    '        lbAvailableProfiles.Items.Clear()
    '        Dim dt As New DataTable
    '        Dim dp As New DataTable
    '        Dim p As SqlParameter() = New SqlParameter(0) {}
    '        p(0) = New SqlParameter("@UserID", cboUsers.SelectedValue)
    '        dt = oExcelSS.getDataTable("uspConfiguration_GetProfilesFromUser", True, p)
    '        dp = oExcelSS.getDataTable("select * from AccessProfiles", False)
    '        If Not dt Is Nothing Then
    '            Dim r As DataRow
    '            For Each r In dt.Rows
    '                lbOwnedProfiles.Items.Add(r(1))
    '            Next
    '        End If
    '        If Not dp Is Nothing Then
    '            Dim dr As DataRow
    '            Dim x As Integer = 0
    '            Dim exists As Boolean = False
    '            For Each dr In dp.Rows
    '                exists = False
    '                For x = 0 To dt.Rows.Count - 1
    '                    If dr(1).trim = dt.Rows(x)(1).trim Then
    '                        exists = True
    '                    End If
    '                Next
    '                If Not exists Then
    '                    lbAvailableProfiles.Items.Add(dr(1))
    '                End If
    '            Next
    '        End If
    '        btnAddPr.Enabled = False
    '        btnRemovePr.Enabled = False
    '        action = clsConfigDmac.Actions.None
    '        tsNew.Enabled = False
    '        tsEdit.Enabled = False
    '    Else
    '        pnlPermissions.Visible = False
    '        pnlPermissions.Enabled = False
    '    End If
    'End Sub
    'Private Sub lbOwnedProfiles_GotFocus(sender As Object, e As EventArgs)
    '    If lbOwnedProfiles.Items.Count > 0 Then
    '        lbAvailableProfiles.ClearSelected()
    '        btnRemovePr.Enabled = True
    '        btnAddPr.Enabled = False
    '    Else
    '        btnRemovePr.Enabled = False
    '        btnAddPr.Enabled = False
    '    End If
    'End Sub
    'Private Sub lbAvailableProfiles_GotFocus(sender As Object, e As EventArgs)
    '    If lbAvailableProfiles.Items.Count > 0 Then
    '        lbOwnedProfiles.ClearSelected()
    '        btnAddPr.Enabled = True
    '        btnRemovePr.Enabled = False
    '    Else
    '        btnRemovePr.Enabled = False
    '        btnAddPr.Enabled = False
    '    End If
    'End Sub
    'Private Sub btnAddPr_Click(sender As Object, e As EventArgs)
    '    If lbAvailableProfiles.SelectedIndex = -1 Then
    '        MsgBox("Must select a Profile in the box.")
    '        Exit Sub
    '    End If
    '    lbOwnedProfiles.Items.Add(lbAvailableProfiles.SelectedItem)
    '    lbAvailableProfiles.Items.Remove(lbAvailableProfiles.SelectedItem)
    '    action = clsConfigDmac.Actions.Niu
    'End Sub
    'Private Sub btnRemovePr_Click(sender As Object, e As EventArgs)
    '    If lbOwnedProfiles.SelectedIndex = -1 Then
    '        MsgBox("Must select a Profile in the box.")
    '        Exit Sub
    '    End If
    '    action = clsConfigDmac.Actions.Niu
    '    lbAvailableProfiles.Items.Add(lbOwnedProfiles.SelectedItem)
    '    lbOwnedProfiles.Items.Remove(lbOwnedProfiles.SelectedItem)
    'End Sub

    ''''END
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


    Private Sub chkRepCatID_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepCatID.CheckedChanged
        If Not chkRepCatID.Checked Then
            chkRepCatIA.Enabled = True
        Else
            chkRepCatIA.Enabled = False
        End If
    End Sub

    Private Sub chkRepCatIA_CheckedChanged(sender As Object, e As EventArgs)
        If Not chkRepCatIA.Checked Then
            chkRepCatID.Enabled = True
        Else
            chkRepCatID.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Added by Harinath to make changes to Report Definition
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboReportDefinitions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportDefinitions.SelectedIndexChanged

        If cboReportDefinitions.SelectedIndex <> -1 AndAlso (Not isLoading) Then
            Try
                isLoading = True
                pnlReportDefinitions.Visible = True
                pnlReportDefinitions.Enabled = False
                pbPreview.Visible = True
                btnAssign.Visible = True
                txt_ReportID.Clear()
                txt_ReportDescription.Clear()
                pbPreview.Image = Nothing
                txt_Notes.Clear()
                chkrptdefinitaionActive.Checked = False
                chkrptdefinitiondeleted.Checked = False
                pbPreview.Enabled = False
                btnAssign.Enabled = False
                oExcelSS.fillComboBox(cboRportCategory, "uspConfiguration_FillRepCategoriesCbo", "categoryname", "categoryidkey")
                oExcelSS.fillComboBox(cboReportGroup, "uspConfiguration_FillRepGroupsCbo", "GroupName", "GroupIDKey")
                cboRportCategory.SelectedIndex = -1
                cboReportGroup.SelectedIndex = -1
                Dim lobjDataTable As DataTable = Nothing
                lobjDataTable = oExcelSS.getDataTable("select CategoryIDKey,GroupIDKey,Description,ReportFileName,Note,isActive,isDeleted,PreviewImg from ReportDefs where ReportIDKey=" & cboReportDefinitions.SelectedValue, False)
                If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                    For Each item In cboRportCategory.Items
                        If DirectCast(item, System.Data.DataRowView).Item(0) = lobjDataTable.Rows(0)(0) Then
                            cboRportCategory.SelectedValue = lobjDataTable.Rows(0)(0)
                            Exit For
                        End If
                    Next
                    For Each item In cboReportGroup.Items
                        If DirectCast(item, System.Data.DataRowView).Item(0) = lobjDataTable.Rows(0)(1) Then
                            cboReportGroup.SelectedValue = lobjDataTable.Rows(0)(1)
                            Exit For
                        End If
                    Next
                    txt_ReportDescription.Text = lobjDataTable.Rows(0)(2)
                    txt_ReportID.Text = DirectCast(cboReportDefinitions.SelectedItem, System.Data.DataRowView).Item(1)
                    txt_Notes.Text = lobjDataTable.Rows(0)(4)
                    txt_RemoteFileName.Text = lobjDataTable.Rows(0)(3)
                    chkrptdefinitaionActive.Checked = lobjDataTable.Rows(0)(5)
                    chkrptdefinitiondeleted.Checked = lobjDataTable.Rows(0)(6)
                    Using ms As New IO.MemoryStream(CType(lobjDataTable.Rows(0)(7), Byte()))
                        Dim img As Image = Image.FromStream(ms)
                        pbPreview.Image = img
                    End Using
                End If
            Catch lobjException As Exception
                MessageBox.Show(lobjException.Message)
            Finally
                isLoading = False
            End Try


            ' oExcelSS.fillComboBox(cboReportGroup, "uspConfiguration_FillRepGroupsCbo", "groupname", "groupidkey")

        End If
       

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

    End Sub

    Private Sub chkrptdefinitaionActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkrptdefinitaionActive.CheckedChanged
        If Not chkrptdefinitaionActive.Checked Then
            chkrptdefinitiondeleted.Enabled = True
        Else
            chkrptdefinitiondeleted.Enabled = False
        End If
    End Sub

    Private Sub chkrptdefinitiondeleted_CheckedChanged(sender As Object, e As EventArgs) Handles chkrptdefinitiondeleted.CheckedChanged
        If Not chkrptdefinitiondeleted.Checked Then
            chkrptdefinitaionActive.Enabled = True
        Else
            chkrptdefinitaionActive.Enabled = False
        End If
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If opdImageDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            If IO.File.Exists(opdImageDialog.FileName) Then
                Dim fs As New IO.FileStream(opdImageDialog.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                Dim bt() As Byte = New Byte(fs.Length - 1) {}
                fs.Read(bt, 0, bt.Length)
                AutosizeImage(fs, pbPreview)
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
    Public Sub AutosizeImage(ByVal ImagePath As System.IO.FileStream, ByVal picBox As PictureBox, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            picBox.SizeMode = pSizeMode

            Dim imgOrg As Bitmap
            Dim imgShow As Bitmap
            Dim g As Graphics
            Dim divideBy, divideByH, divideByW As Double
            imgOrg = DirectCast(Image.FromStream(ImagePath), Image)

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

    Private Sub trvwReports_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvwReports.AfterSelect
        Try

            cmbDataType.Visible = False
            cmbOperator.Visible = False
            If dgvParameters.Rows.Count > 0 Then
                dgvParameters.Rows.Clear()
            End If
            If e.Node.Nodes.Count = 0 Then
                GetReportParameters(e.Node.Name, DirectCast(e.Node.Tag, System.Data.DataRow)(0))
                If dgvParameters.Rows.Count > 0 Then
                    tsSave.Enabled = True
                    tsCancel.Enabled = True
                    tsNew.Enabled = False
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("frmParameters frmParameters_Load ##" + ex.Message.ToString())
            MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
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
        'ExcelSSGen.ReportServer.UserName = "sa"
        'ExcelSSGen.ReportServer.ReportServerPath = "http://haridell/ReportServer"
        'ExcelSSGen.ReportServer.ReportPath = "Report Project1"
        'ExcelSSGen.ReportServer.ReportServerDatabase = "ReportServer"
        'ExcelSSGen.ReportServer.Password = ExcelSSGen.ReportServer.UserName
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
                                If Not IsDBNull(dt.Rows(r)("PromptText").ToString) Then
                                    prompt = dt.Rows(r)("PromptText").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("Sequence").ToString) Then
                                    sequence = dt.Rows(r)("Sequence").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("DataType").ToString) Then
                                    varType = dt.Rows(r)("DataType").ToString
                                End If
                                If Not IsDBNull(dt.Rows(r)("isRequired")) Then
                                    isRequired = dt.Rows(r)("isRequired").ToString
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
                                If Not IsDBNull(dt.Rows(r)("DefaultValue2").ToString) Then
                                    value2 = dt.Rows(r)("DefaultValue2").ToString
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
                                .Rows.Add(paramReportName, prompt, sequence, varType, doperator, value1, value2, isRequired)
                            End With
                        Next
                    Else
                        Dim paramReportName As String = String.Empty
                        If dtParam.Rows.Count > 0 Then
                            For i As Int16 = 0 To dtParam.Rows.Count - 1
                                paramReportName = Convert.ToString(dtParam(i)(0))
                                With dgvParameters
                                    .Rows.Add(paramReportName, False, sequence, varType, "", "", "", isRequired)
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
                                dgvParameters.Rows.Add(paramReportName1, False, sequence, varType, "", "", "", isRequired)
                            End If
                        Next
                    End If
                Else
                    MessageBox.Show("No default Parameters Found :", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else
            MessageBox.Show("No default Parameters Found :", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return dgvParameters
    End Function
    'Private Sub setNoDefaultParameter(ByVal dtParam As DataTable, ByVal displayMesage As String)
    '    Try
    '        If dgvParameters.Rows.Count > 0 Then
    '            dgvParameters.Columns.Clear()
    '            dgvParameters.Rows.Clear()
    '        End If
    '        dtParam.Columns.Clear()
    '        dtParam.Rows.Clear()
    '        dtParam.Columns.Add("Parameter", GetType(String))
    '        Dim dr As DataRow = dtParam.Rows.Add()
    '        dr.Item(0) = displayMesage
    '        dgvParameters.DataSource = dtParam
    '        dgvParameters.Columns(0).Width = (dgvParameters.Width)
    '    Catch ex As Exception
    '        oExcelSS.ErrorLog("setNoDefaultParameter frmParameters_Load ##" + ex.Message.ToString())
    '        MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

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
    Private Sub ShowCombobox(ByVal iRowIndex As Integer, ByVal iColumnIndex As Integer, ByVal obj As ComboBox)

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
            .Focus()
        End With
    End Sub
#End Region

    Private Sub dgvParameters_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParameters.CellClick
        Try
            cmbDataType.Visible = False
            cmbOperator.Visible = False
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
    Private Sub cmbDataType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDataType.Leave
        Try
            With dgvParameters
                If .Columns(.CurrentCell.ColumnIndex).HeaderText = "Type" Then
                    .Item(.CurrentCell.ColumnIndex, activeRow).Value = Trim(cmbDataType.Text)
                End If
                activeRow = 0
            End With
            cmbDataType.SelectedIndex = -1
            cmbOperator.SelectedIndex = -1
        Catch ex As Exception
            oExcelSS.ErrorLog("frmParameters cmbDataType_Leave ##" + ex.Message.ToString())
            MessageBox.Show(ex.Message, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbOperator_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperator.Leave
        Try
            With dgvParameters
                If .Columns(.CurrentCell.ColumnIndex).HeaderText = "Default Operator" Then
                    .Item(.CurrentCell.ColumnIndex, activeRow).Value = Trim(cmbOperator.Text)
                End If
            End With
            cmbDataType.SelectedIndex = -1
            cmbOperator.SelectedIndex = -1
        Catch ex As Exception
            oExcelSS.ErrorLog("frmParameters cmbOperator_Leave ##" + ex.Message.ToString())
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
            If oExcelSS.bulkSave(dgvParameters, 1, DirectCast(trvwReports.SelectedNode.Tag, System.Data.DataRow)(0).ToString, mstrUserId, mblnExisting) Then
                MsgBox("Parameter(s) Saved successfully")
                ''Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report Parameters", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
