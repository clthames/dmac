Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class frmEmailContacts
#Region "Public Members"
    Public oExcelSS As New ExcelSSGen.Main
    Dim dtCustContacts As DataTable = New DataTable()
    Dim filterField As String
    Dim strAccount As String
    Private _emailAdd As String
    Public Property EmailAddress() As String
        Get
            Return _emailAdd
        End Get
        Set(ByVal value As String)
            _emailAdd = value
        End Set
    End Property
#End Region
#Region "Public Methods"
    Public Sub New(ByVal Account As String)
        InitializeComponent()
        strAccount = Account
    End Sub

    Public Function IsValidEmailAddress() As Boolean
        ' Return true if strIn is in valid e-mail format.
        Return Regex.IsMatch(txtEmail.Text,
                   "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                   RegexOptions.IgnoreCase)
    End Function
#End Region
#Region "Private Methods"
    ''' <summary>
    ''' 
    ''' BindSearchData(0) shows all data
    ''' </summary>
    ''' 
    Private Sub frmCustomerContacts_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            pnlSearch.Visible = True
            pnlAddContact.Visible = False
            pnlAction.Visible = True
            FillComboBoxes()
            BindCustomerContact()
            filterField = DirectCast(cmbCustProp.SelectedItem, KeyValuePair(Of String, String)).Key
        Catch ex As Exception
            oExcelSS.ErrorLog("frmCustomerContacts_Load Error#" & ex.ToString())
            MessageBox.Show("Failed to retrieve Email Contacts.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '''<summary>
    '''Closes the form
    '''</summary>
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    '''<summary>
    '''Closes the form
    '''</summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '''<summary>
    '''Filters the data based on text value and selected property of customer in combobox
    '''</summary>
    Private Sub txtCustValue_TextChanged(sender As Object, e As EventArgs) Handles txtCustValue.TextChanged
        Dim strPattern = DirectCast(cmbPattern.SelectedItem, KeyValuePair(Of String, String)).Key
        If strPattern = "B" Then
            dtCustContacts.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}%'", filterField, txtCustValue.Text)
        Else
            dtCustContacts.DefaultView.RowFilter = String.Format("[{0}] LIKE '%{1}%'", filterField, txtCustValue.Text)
        End If
    End Sub
    '''<summary>
    '''Binds the data to datagridview based on filter criteria
    '''</summary>
    Private Sub BindCustomerContact()
        dtCustContacts = GetSearchContactData()
        dgvSearchResult.DataSource = dtCustContacts
    End Sub

    '''<summary>
    '''The GetSearchContactData method returns all the code based on filter criteria
    '''</summary>
    Private Function GetSearchContactData() As DataTable
        Dim dtCustContacts As New DataTable("CustContact")
        Dim status As String = String.Empty
        If Not cmbStatus Is Nothing Then
            status = DirectCast(cmbStatus.SelectedItem, KeyValuePair(Of String, String)).Key
        End If

        Dim param As SqlParameter() = New SqlParameter(2) {}
        If String.IsNullOrEmpty(strAccount) Then
            param(0) = New SqlParameter("@Account", DBNull.Value)
        Else
            param(0) = New SqlParameter("@Account", strAccount)
        End If


        If status = "1" Then
            param(1) = New SqlParameter("@Status", 1)
        Else
            param(1) = New SqlParameter("@Status", DBNull.Value)
        End If
        param(2) = New SqlParameter("@IsQuickSearch", IIf(chkQuickSearch.Checked, 1, 0))

        dtCustContacts = oExcelSS.getDataTable("uspContact_GetContacts", True, param)
        Return dtCustContacts

    End Function
    '''<summary>
    '''Refresh the data when contact property changed
    '''</summary>
    Private Sub cmbCustProp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCustProp.SelectedIndexChanged
        filterField = DirectCast(cmbCustProp.SelectedItem, KeyValuePair(Of String, String)).Key
    End Sub

    '''<summary>
    '''Refresh the data when search pattern changed
    '''</summary>
    Private Sub cmbPattern_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPattern.SelectedIndexChanged
        txtCustValue.Text = String.Empty
        BindCustomerContact()
    End Sub
    '''<summary>
    '''Fills the combo boxes for filter of contacts
    '''</summary>
    Private Sub FillComboBoxes()
        Dim comboCustSource As New Dictionary(Of String, String)()
        comboCustSource.Add("Name", "Contact Name")
        comboCustSource.Add("CustomerName", "Customer Name")
        comboCustSource.Add("CustomerNumber", "Customer Number")
        comboCustSource.Add("ContactId", "Contact ID")
        comboCustSource.Add("ContactPhone", "Phone Number")
        comboCustSource.Add("Zip", "Zip Code")
        cmbCustProp.DataSource = New BindingSource(comboCustSource, Nothing)
        cmbCustProp.DisplayMember = "Value"
        cmbCustProp.ValueMember = "Key"
        cmbCustProp.SelectedIndex = 0

        Dim comboSearchPattern As New Dictionary(Of String, String)()
        comboSearchPattern.Add("B", "Begins With")
        comboSearchPattern.Add("C", "Contains")
        cmbPattern.DataSource = New BindingSource(comboSearchPattern, Nothing)
        cmbPattern.DisplayMember = "Value"
        cmbPattern.ValueMember = "Key"
        cmbPattern.SelectedIndex = 0

        Dim comboStatus As New Dictionary(Of String, String)()
        comboStatus.Add("1", "Active Customer")
        comboStatus.Add("0", "All")
        cmbStatus.DataSource = New BindingSource(comboStatus, Nothing)
        cmbStatus.DisplayMember = "Value"
        cmbStatus.ValueMember = "Key"
        cmbStatus.SelectedIndex = 0

        Dim dtAccount As DataTable = GetAccounts()
        cmbAccount.DataSource = dtAccount
        cmbAccount.ValueMember = "Account"
        cmbAccount.DisplayMember = "Account"
        cmbAccount.SelectedIndex = -1

    End Sub

    '''<summary>
    '''The GetAccountInfo method returns all the Account data
    '''</summary>
    Private Function GetAccounts() As DataTable
        Dim dtAccount As New DataTable("AccountTable")
        dtAccount = oExcelSS.getDataTable("uspContact_GetAccounts", True)
        Return dtAccount
    End Function

    '''<summary>
    '''If gets the active and all contact records based on checkbox value
    '''</summary>
    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        txtCustValue.Text = String.Empty
        BindCustomerContact()
    End Sub

    '''<summary>
    '''If checked TOP 2500 records displayed else all records displayed
    '''</summary>
    Private Sub chkQuickSearch_CheckedChanged(sender As Object, e As EventArgs) Handles chkQuickSearch.CheckedChanged
        txtCustValue.Text = String.Empty
        BindCustomerContact()
    End Sub

    '''<summary>
    '''Closes the fill contact details form
    '''</summary>
    Private Sub btnContactCancel_Click(sender As Object, e As EventArgs) Handles btnContactCancel.Click
        pnlSearch.Visible = True
        pnlAction.Visible = True
        pnlAddContact.Visible = False
    End Sub

    '''<summary>
    '''Saves contact details
    '''</summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        InsertContact()

    End Sub

    '''<summary>
    '''Opens the form to fill the contact details
    '''</summary>
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        pnlSearch.Visible = False
        pnlAction.Visible = False
        pnlAddContact.Visible = True
    End Sub

    '''<summary>
    '''The InsertContact inserts the Contact 
    '''</summary>
    Private Sub InsertContact()
        If (ValidateInputs()) Then
            Dim param As SqlParameter() = New SqlParameter(7) {}
            Dim OutStatus As String = String.Empty

            param(0) = New SqlParameter("@Account", cmbAccount.SelectedValue)
            param(1) = New SqlParameter("@ContactId", txtContactId.Text)
            param(2) = New SqlParameter("@Name", txtName.Text)
            param(3) = New SqlParameter("@Email", txtEmail.Text)
            param(4) = New SqlParameter("@Status", IIf(chkActive.Checked, 1, 0))
            param(5) = New SqlParameter("@CreatedBy", oExcelSS.userid)
            param(6) = New SqlParameter("@CreatedDate", Date.Now)
            param(7) = New SqlParameter("@OutStatus", "")
            param(7).Direction = ParameterDirection.Output
            param(7).Size = 1000

            Dim success As Integer = oExcelSS.ExecuteProc("uspContact_InsertContact", param)
            OutStatus = param(7).Value
            If (OutStatus <> "Success") Then
                MessageBox.Show("Error while saving contact", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                BindCustomerContact()
                MessageBox.Show("Contact saved successfully.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Information)
                pnlSearch.Visible = True
                pnlAction.Visible = True
                pnlAddContact.Visible = False
            End If

        End If
    End Sub

    '''<summary>
    '''ValidateInputs validates required fields for Contact
    '''</summary>
    Private Function ValidateInputs() As Boolean
        If cmbAccount.SelectedIndex = -1 Then
            MessageBox.Show("Please select Account.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Please enter Name.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtEmail.Text) Then
            MessageBox.Show("Please enter Email.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf Not IsValidEmailAddress() Then
            MessageBox.Show("Please enter valid Email Address.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtContactId.Text) Then
            MessageBox.Show("Please enter Contact Id.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    '''<summary>
    '''Adds the selected contacts email to send list but does not closes the form
    '''</summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgvSearchResult.SelectedRows.Count <> 0 Then
            If Not String.IsNullOrEmpty(_emailAdd) Then
                If Not _emailAdd.Contains(GetSelectedRowEmail()) Then
                    _emailAdd = _emailAdd & GetSelectedRowEmail()
                Else
                    MessageBox.Show(GetSelectedRowEmail() & " already added.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

            Else
                _emailAdd = GetSelectedRowEmail()
            End If
            MessageBox.Show(GetSelectedRowEmail() & " added.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select entire row to add Email contact.", "Email Contact", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    '''<summary>
    '''Adds the selected contact email to send list and closes the form
    '''</summary>
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Not String.IsNullOrEmpty(_emailAdd) Then
            If Not _emailAdd.Contains(GetSelectedRowEmail()) Then
                _emailAdd = _emailAdd & GetSelectedRowEmail()
            End If
        Else
            _emailAdd = GetSelectedRowEmail()
        End If
        Me.DialogResult = DialogResult.OK
    End Sub
    '''<summary>
    '''Gets the selected email from contact list displayed
    '''</summary>
    Function GetSelectedRowEmail() As String
        Dim EmailAddress As String = String.Empty
        If dgvSearchResult.SelectedRows.Count <> 0 Then
            Dim RowIndex = dgvSearchResult.CurrentRow.Index
            Dim row As DataGridViewRow = dgvSearchResult.Rows(RowIndex)
            EmailAddress = row.Cells("clmnEmail").Value
            EmailAddress = EmailAddress & ";" & Environment.NewLine
        End If
        Return EmailAddress
    End Function
#End Region
End Class