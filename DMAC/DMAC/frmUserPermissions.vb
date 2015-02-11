Imports System.Data.SqlClient
Public Class frmUserPermissions
    Dim userIDforPermission As String = String.Empty
    Private Sub frmUserPermissions_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            selectedItem = String.Empty
        Catch ex As Exception
            Dim objfunctions As New Functions
            objfunctions.ErrorLog("btnLogin_Click Error## " + ex.Message.ToString())
        End Try
    End Sub
    Private Sub frmUserPermissions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim param As String(,) = New String(,) {{"@strSubMenu", ""}}
            Dim userNode As New TreeNode
            userNode.Text = "Users List"
            userNode.Tag = "Users List"
            'Dim success = New DataLayer().FillTreeView(tvUser, userNode, "uspFillUserTv")
            Dim success = New DataLayer().FillTreeView(tvUser, userNode, "uspAccessFillUserTv")
            Dim permissionNode As New TreeNode
            permissionNode.Text = "Permissions"
            permissionNode.Tag = "Permissions"
            success = New DataLayer().FillTreeView(tvMenus, permissionNode, "uspAccessGetMenus", param, True)
            tvMenus.Enabled = False
            tvUser.ExpandAll()

        Catch ex As Exception
            Dim objFunctions As New Functions
            objFunctions.ErrorLog("frmUserPermissions_Load ==> Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tvUser_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvUser.AfterSelect
        Try
            Dim sqlparam As SqlParameter() = New SqlParameter(0) {}
            userIDforPermission = e.Node.Tag
            If e.Node.Text = "Users List" Then
                tvMenus.CollapseAll()
                tvMenus.Enabled = False
                lblselectedUser.Text = "Please choose an User to set/view the permissions "

                Exit Sub
            Else
                lblselectedUser.Text = "Selected User : " & e.Node.Text
                tvMenus.Enabled = True
            End If

            resetNodeSelection()
            sqlparam(0) = New SqlParameter("@intUserIDKey", e.Node.Tag.Trim)
            Dim dtPermission As DataTable = New DataLayer().getDataTable("uspAccessGetPermission", True, sqlparam)
            If dtPermission.Rows.Count > 0 Then
                'checked the menus in treeview control
                'as per the permission table of the selected user
                For Each row As DataRow In dtPermission.Rows
                    CheckNode(tvMenus.Nodes, row("Menu"))
                Next
            End If
            tvMenus.ExpandAll()
        Catch ex As Exception
            Dim objFunctions As New Functions
            objFunctions.ErrorLog("tvUser_AfterSelect ==> Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub tvMenus_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMenus.AfterCheck
        Try
            If e.Action <> TreeViewAction.Unknown AndAlso e.Node.Checked Then
                If Not e.Node.Parent.Parent Is Nothing Then
                    e.Node.Parent.Parent.Checked = True
                End If
                If e.Node.Level = 4 Then
                    e.Node.Parent.Parent.Parent.Checked = True
                End If
                e.Node.Parent.Checked = True
                If e.Node.Nodes.Count > 0 Then
                    Me.CheckAllChildNodes(e.Node, e.Node.Checked)
                End If
            ElseIf e.Action <> TreeViewAction.Unknown AndAlso Not e.Node.Checked Then
                If e.Node.Nodes.Count > 0 Then
                    Me.CheckAllChildNodes(e.Node, e.Node.Checked)
                End If
            End If
        Catch ex As Exception
            Dim objFunctions As New Functions
            objFunctions.ErrorLog("tvMenus_AfterCheck ==> Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub CheckAllChildNodes(ByVal treeNode As TreeNode, ByVal nodeChecked As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            resetNodeSelection()
        Catch ex As Exception
            Dim objFunctions As New Functions
            objFunctions.ErrorLog("tvMenus_AfterCheck ==> Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Try
            If userIDforPermission = "" Then
                MsgBox("Please choose an user", MsgBoxStyle.Exclamation, My.Resources.applicationTitle)
                Exit Sub
            End If
            Dim tn() As TreeNode
            tn = Me.isCheckedNodes(Me.tvMenus.Nodes)
            If tn.Length = 0 Then
                MsgBox("No item(s) selected", MsgBoxStyle.Exclamation, My.Resources.applicationTitle)
            Else
                Dim dt As New DataTable("menus")
                dt.Columns.Add("menu", GetType(String))
                For Each node In tn
                    dt.Rows.Add(node.Text)
                Next
                Dim param(,) = New String(,) {{"@strUserID", userIDforPermission}}
                Dim status As Boolean = New DataLayer().isSavedData("uspAccessSetUserMenu", "@tblMenu", dt, param, "@strStatus")
                If status Then
                    MsgBox("Permisison applied ", MsgBoxStyle.Information, My.Resources.applicationTitle)
                Else
                    MsgBox("Not applied", MsgBoxStyle.Exclamation, My.Resources.applicationTitle)
                End If
            End If
        Catch ex As Exception
            Dim objFunctions As New Functions
            objFunctions.ErrorLog("btnApply_Click ==> Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Function isCheckedNodes(ByVal nodes As TreeNodeCollection) As TreeNode()
        Dim checkedNodes As New List(Of TreeNode)
        For Each node As TreeNode In nodes
            If node.Checked AndAlso node.Level > 0 Then
                checkedNodes.Add(node)
            End If
            checkedNodes.AddRange(Me.isCheckedNodes(node.Nodes))
        Next
        Return checkedNodes.ToArray()
    End Function
    Private Sub resetNodeSelection()
        Try
            Dim node As TreeNode
            For Each node In tvMenus.Nodes
                node.Checked = False
                If node.Nodes.Count > 0 Then
                    Me.CheckAllChildNodes(node, False)
                End If
            Next node
        Catch ex As Exception
            Dim objFunctions As New Functions
            objFunctions.ErrorLog("tvMenus_AfterCheck ==> Error##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub CheckNode(ByVal treeNode As TreeNodeCollection, ByVal menu As String)
        Dim node As TreeNode
        For Each node In treeNode
            If node.Text.Trim = menu.Trim Then
                node.Checked = True
            End If
            If node.Nodes.Count > 0 Then
                CheckNode(node.Nodes, menu)
            End If
        Next node
    End Sub
End Class