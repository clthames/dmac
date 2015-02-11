Public Class frmNewValue
    Public mobjNewValue As String = Nothing
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        mobjNewValue = txtbxNewValue.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


   
    Private Sub txtbxNewValue_TextChanged(sender As Object, e As EventArgs) Handles txtbxNewValue.TextChanged
        If Not String.IsNullOrEmpty(txtbxNewValue.Text) Then
            btnOK.Enabled = True
        Else
            btnOK.Enabled = False
        End If
    End Sub
End Class