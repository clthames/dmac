Public Class frmLaunch

    Private Sub frmLaunch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btn_Launch_Click(sender As Object, e As EventArgs) Handles btn_Launch.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class