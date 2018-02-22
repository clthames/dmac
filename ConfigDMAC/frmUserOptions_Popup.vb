Public Class frmUserOptions_Popup

    Private key As String
    Public Property Keyword() As String
        Get
            Return key
        End Get
        Set(ByVal value As String)
            key = value
        End Set
    End Property

    Private val As String
    Public Property Value() As String
        Get
            Return val
        End Get
        Set(ByVal value As String)
            val = value
        End Set
    End Property

    Private ispassword As Boolean
    Public Property IsPasswordField() As Boolean
        Get
            Return ispassword
        End Get
        Set(ByVal value As Boolean)
            ispassword = value
        End Set
    End Property

    Private _isEditMode As Boolean
    Public Property IsEditMode() As Boolean
        Get
            Return _isEditMode
        End Get
        Set(ByVal value As Boolean)
            _isEditMode = value
        End Set
    End Property

    Private Sub usrUserOptions_Popup_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtValue.Text = Value
        If IsPasswordField Then
            txtValue.PasswordChar = "*"
        End If
        txtKey.Text = Keyword
        txtKey.Enabled = Not IsEditMode
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (ValidateInputs()) Then
            Keyword = txtKey.Text
            val = txtValue.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub
    '''<summary>
    '''ValidateInputs validates required fields for User Option
    '''</summary>
    Private Function ValidateInputs() As Boolean
        If String.IsNullOrEmpty(txtKey.Text) Then
            MessageBox.Show("Please enter Keyword.", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf String.IsNullOrEmpty(txtValue.Text) Then
            MessageBox.Show("Please enter Value.", "UserOptions", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

End Class