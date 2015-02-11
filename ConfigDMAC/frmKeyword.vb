Public Class frmKeyword
    Public mstrKeyword As String
    Public mstrProgramName As String
    Public mstrOptionValue As String
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        mstrKeyword = txtKeyword.Text
        mstrOptionValue = txtOptionValue.Text
        mstrProgramName = txtProgramName.Text
    End Sub

    Private Sub txtKeyword_TextChanged(sender As Object, e As EventArgs) Handles txtKeyword.TextChanged
        If String.IsNullOrEmpty(txtKeyword.Text) Or String.IsNullOrEmpty(txtOptionValue.Text) Or String.IsNullOrEmpty(txtProgramName.Text) Then
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub txtProgramName_TextChanged(sender As Object, e As EventArgs) Handles txtProgramName.TextChanged
        If String.IsNullOrEmpty(txtKeyword.Text) Or String.IsNullOrEmpty(txtOptionValue.Text) Or String.IsNullOrEmpty(txtProgramName.Text) Then
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub txtOptionValue_TextChanged(sender As Object, e As EventArgs) Handles txtOptionValue.TextChanged
        If String.IsNullOrEmpty(txtKeyword.Text) Or String.IsNullOrEmpty(txtOptionValue.Text) Or String.IsNullOrEmpty(txtProgramName.Text) Then
            btnOk.Enabled = False
        Else
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class