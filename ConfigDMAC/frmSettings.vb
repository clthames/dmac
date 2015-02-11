Public Class frmSettings

    Public oExcelSS As ExcelSSGen.Main
    Private Sub trvwSettings_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvwSettings.AfterSelect
        Try

            If e.Node.Tag IsNot Nothing Then
                lstvwSettingValues.Items.Clear()
                Dim lobjRow As DataRow = e.Node.Tag
                Dim lobjListViewItem As ListViewItem = New ListViewItem()
                lobjListViewItem.Tag = lobjRow
                lobjListViewItem.Text = "Program Name"
                lobjListViewItem.Name = "ProgramName"
                lobjListViewItem.SubItems.Add(lobjRow(2).ToString)
                lstvwSettingValues.Items.Add(lobjListViewItem)
                lobjListViewItem = New ListViewItem()
                lobjListViewItem.Tag = lobjRow
                lobjListViewItem.Text = "Option Value"
                lobjListViewItem.Name = "OptionValue"
                lobjListViewItem.SubItems.Add(lobjRow(3).ToString)
                lstvwSettingValues.Items.Add(lobjListViewItem)

            Else
                lstvwSettingValues.Items.Clear()
            End If

        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message, "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub lstvwSettingValues_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstvwSettingValues.MouseDoubleClick
        Try

            Dim lobjlistview As ListView = CType(sender, ListView)
            Dim lobjRow As DataRow = lobjlistview.SelectedItems.Item(0).Tag
            Dim lobjfrmNewValue As frmNewValue = New frmNewValue
            If lobjfrmNewValue.ShowDialog() = Windows.Forms.DialogResult.OK Then
                oExcelSS.getDataTable("update Options set " & lobjlistview.SelectedItems.Item(0).Name & "='" & lobjfrmNewValue.txtbxNewValue.Text & "' where OptionID=" & lobjRow(4).ToString)
                Dim lobjDataTable As DataTable
                lobjDataTable = oExcelSS.getDataTable("select  ModuleID,Keyword,ProgramName,OptionValue,OptionID from vwOptions where IsActive=1 and OptionID=" & lobjRow(4).ToString, False)
                If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                    For Each lobjRow In lobjDataTable.Rows
                        lobjlistview.SelectedItems.Item(0).Tag = lobjRow
                        If lobjlistview.SelectedItems.Item(0).Name = "ProgramName" Then
                            lobjlistview.SelectedItems.Item(0).SubItems(0).Text = lobjRow(2).ToString()
                        Else
                            lobjlistview.SelectedItems.Item(0).SubItems(0).Text = lobjRow(3).ToString()
                        End If

                    Next
                End If
            End If
        Catch lobjException As Exception
            MessageBox.Show(lobjException.Message, "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        If String.IsNullOrEmpty(txtFind.Text) Then
            btnFind.Enabled = False
        Else
            btnFind.Enabled = True
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If trvwSettings.Nodes.Count > 0 Then
            If trvwSettings.Nodes.Find(txtFind.Text, True).Length >= 1 Then
                Dim lobjNode As TreeNode = trvwSettings.Nodes.Find(txtFind.Text, True)(0)
                trvwSettings.SelectedNode = lobjNode
                trvwSettings.Focus()
            End If
        End If
    End Sub

    Private Sub trvwSettings_MouseClick(sender As Object, e As MouseEventArgs) Handles trvwSettings.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'cntxtmenustrip.Show(e.X, e.Y)

        End If
    End Sub

  
    Private Sub trvwSettings_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles trvwSettings.MouseDoubleClick
        If DirectCast(sender, System.Windows.Forms.TreeView).SelectedNode.Parent Is Nothing Then
            Dim lobjfrmkeyword As frmKeyword = New frmKeyword
            If lobjfrmkeyword.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim lobjDataTable As DataTable
                lobjDataTable = oExcelSS.getDataTable("insert into OptionsMaster (ModuleID,Keyword,IsActive) values ( '" & DirectCast(sender, System.Windows.Forms.TreeView).SelectedNode.Text & "' , '" & lobjfrmkeyword.txtKeyword.Text & "' , 1)")
                lobjDataTable = oExcelSS.getDataTable("select OptionID from OptionsMaster where ModuleID='" & DirectCast(sender, System.Windows.Forms.TreeView).SelectedNode.Text & "' and Keyword='" & lobjfrmkeyword.txtKeyword.Text & "'")
                If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                    oExcelSS.getDataTable("insert into Options (OptionID,OptionValue,ProgramName) values ( '" & lobjDataTable.Rows(0).Item(0).ToString & "' , '" & lobjfrmkeyword.txtOptionValue.Text & "' , '" & lobjfrmkeyword.txtProgramName.Text & "')")
                    lobjDataTable = oExcelSS.getDataTable("select  ModuleID,Keyword,ProgramName,OptionValue,OptionID from vwOptions where IsActive=1 and OptionID=" & lobjDataTable.Rows(0).Item(0).ToString, False)
                    If lobjDataTable IsNot Nothing AndAlso lobjDataTable.Rows.Count > 0 Then
                        Dim lobjChildnode As TreeNode = Nothing
                        lobjChildnode = New TreeNode()
                        lobjChildnode.Text = lobjDataTable.Rows(0).Item(1).ToString
                        lobjChildnode.Name = lobjDataTable.Rows(0).Item(1).ToString
                        lobjChildnode.Tag = lobjDataTable.Rows(0)
                        DirectCast(sender, System.Windows.Forms.TreeView).SelectedNode.Nodes.Add(lobjChildnode)
                    End If
                End If
            End If
        End If
    End Sub
End Class