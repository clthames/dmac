Imports System.Data.SqlClient

Public Class usrSalesCode
    Public oExcelSS As New ExcelSSGen.Main

#Region "Form Events"

    ''' <summary>
    ''' Event Load form and retrive Sales Tax Code Data
    ''' here 0 in BindSalesCodeData(0) shows all data
    ''' </summary>
    Private Sub usrSalesCode_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            BindSalesCodeData(0)
        Catch ex As Exception
            oExcelSS.ErrorLog("usrSalesCode_Load Error#" & ex.ToString())
            MessageBox.Show("Failed to retrieve Sales Tax Code Data.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reset the form control and show the grid screen
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            pnlAddEditSalesCode.Visible = False
            pnlViewSalesCode.Visible = True
        Catch ex As Exception
            oExcelSS.ErrorLog("btnCancel_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to cancel the operation.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save or update data
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(lblID.Text) Then
                InsertUpdateSalesCode(0)
            Else
                InsertUpdateSalesCode(Convert.ToInt32(lblID.Text))
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("btnSave_Click Error#" & ex.ToString())
            MessageBox.Show("Failed to save Sales Code.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '''<summary>
    '''Event captures the delete and edit button when clicked
    '''</summary>
    Private Sub dgvSalesCodes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSalesCodes.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim ID As Integer = dgvSalesCodes.Rows(e.RowIndex).Cells(5).Value.ToString()

                '7 is  form delete button column
                If e.ColumnIndex = 7 Then
                    Dim Result As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If Result = DialogResult.OK Then
                        Dim param As SqlParameter() = New SqlParameter(0) {}
                        param(0) = New SqlParameter("@ID", ID)
                        oExcelSS.ExecuteProc("uspConfiguration_DeleteSalesCode", param)
                        BindSalesCodeData(0)
                        MessageBox.Show("Sales Code deleted successfully.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    ' 6 is for edit button column or any other column then show edit screen
                Else

                    Dim dt As DataTable = GetSalesCodeInfo(ID)
                    If Not dt Is Nothing And dt.Rows.Count > 0 Then

                        lblID.Text = Convert.ToString(dt.Rows(0)("ID"))
                        txtSalesCode.Text = Convert.ToString(dt.Rows(0)("SCODE"))
                        txtDesc.Text = Convert.ToString(dt.Rows(0)("Description"))
                        txtQB.Text = Convert.ToString(dt.Rows(0)("QBitem"))

                        If Convert.ToString(dt.Rows(0)("Discount")).ToLowerInvariant() = "yes" Then
                            chkDiscount.Checked = True
                        Else
                            chkDiscount.Checked = False
                        End If

                        If Convert.ToString(dt.Rows(0)("Taxable")).ToLowerInvariant() = "yes" Then
                            chkTaxable.Checked = True
                        Else
                            chkTaxable.Checked = False
                        End If

                        btnSave.Text = "Update"
                    End If
                    pnlAddEditSalesCode.Visible = True
                    pnlViewSalesCode.Visible = False
                End If
            End If
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvSalesCodes_CellContentClick Error#" & ex.ToString())
            MessageBox.Show("Failed to perform the operation", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Event shows the screen to add record
    ''' </summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            ClearControls()
            pnlAddEditSalesCode.Visible = True
            btnSave.Text = "Save"
            pnlViewSalesCode.Visible = False
        Catch ex As Exception
            oExcelSS.ErrorLog("btnAdd_Click Error#" & ex.Message.ToString())
            MessageBox.Show("Failed to show Add Sales Code screen.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvSalesCodes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSalesCodes.CellDoubleClick
        Try
            dgvSalesCodes_CellContentClick(sender, e)
        Catch ex As Exception
            oExcelSS.ErrorLog("dgvSalesCodes_CellDoubleClick Error#" & ex.ToString())
            MessageBox.Show("Failed to show Add Sales Code screen.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Private Methods"

    '''<summary>
    '''The GetSalesCodeInfo method returns all the sales code data
    '''</summary>
    Private Function GetSalesCodeInfo(ID As Integer) As DataTable
        Dim dtSalesCode As New DataTable("SalesCodeTable")

        Dim param As SqlParameter() = New SqlParameter(0) {}
        param(0) = New SqlParameter("@ID", ID)
        dtSalesCode = oExcelSS.getDataTable("uspConfiguration_GetSalesCode", True, param)

        Return dtSalesCode

    End Function

    '''<summary>
    '''The BindSalesCodeData Sub binds data to datagridview 
    '''</summary>
    Private Sub BindSalesCodeData(Id As Integer)
        Dim dtSalesCode As DataTable = GetSalesCodeInfo(Id)
        dgvSalesCodes.DataSource = dtSalesCode
    End Sub

    '''<summary>
    '''ClearControls resets the input controls
    '''</summary>
    Private Sub ClearControls()
        lblID.Text = String.Empty
        txtSalesCode.Text = String.Empty
        txtDesc.Text = String.Empty
        txtQB.Text = String.Empty
        chkDiscount.Checked = False
        chkTaxable.Checked = False
    End Sub

    '''<summary>
    '''The InsertUpdateSalesCode inserts or updates the sales code 
    ''' IF Id is 0 it inserts else it updates the sales code record based on Id value
    '''</summary>
    Private Sub InsertUpdateSalesCode(Id As Integer)
        If (ValidateInputs()) Then
            Dim param As SqlParameter() = New SqlParameter(5) {}

            param(0) = New SqlParameter("@ID", Id)
            param(1) = New SqlParameter("@SCode", txtSalesCode.Text)
            param(2) = New SqlParameter("@Description", txtDesc.Text)
            param(3) = New SqlParameter("@QBItem", txtQB.Text)
            param(4) = New SqlParameter("@Discount", IIf(chkDiscount.Checked, "Y", "N"))
            param(5) = New SqlParameter("@Taxable", IIf(chkTaxable.Checked, "Y", "N"))

            oExcelSS.ExecuteProc("uspConfiguration_SalesCodeInsertUpdate", param)

            pnlAddEditSalesCode.Visible = False
            pnlViewSalesCode.Visible = True
            BindSalesCodeData(0)
            MessageBox.Show("Sales Code saved successfully.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    '''<summary>
    '''ValidateInputs validates required fields for Sales Code
    '''</summary>
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(txtSalesCode.Text) Then
            MessageBox.Show("Please enter Sales Code.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtDesc.Text) Then
            MessageBox.Show("Please enter Description.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtQB.Text) Then
            MessageBox.Show("Please enter Quick Book Reference.", "Sales Codes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

#End Region

   
End Class
