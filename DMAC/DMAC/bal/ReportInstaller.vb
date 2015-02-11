Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.Security.AccessControl
Imports System.IO
Imports System.Reflection
Public Class ReportInstaller
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    <Security.Permissions.SecurityPermission(Security.Permissions.SecurityAction.Demand)>
    Public Overrides Sub Commit(
  ByVal savedState As System.Collections.IDictionary)
        MyBase.Commit(savedState)
    End Sub
    Protected Overrides Sub OnBeforeUninstall(ByVal savedState As System.Collections.IDictionary)
        MyBase.OnBeforeUninstall(savedState)
        Try
            For Each FileName As String In Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.installstate")
                File.Delete(FileName)
            Next
            For Each FileName As String In Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.tmp")
                File.Delete(FileName)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)
        MyBase.Install(stateSaver)
        stateSaver.Add("TargetDir", Context.Parameters("DP_TargetDir").ToString())
    End Sub
    Protected Overrides Sub OnCommitted(ByVal savedState As System.Collections.IDictionary)
        MyBase.OnCommitted(savedState)

        Try
            Dim FolderPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            Dim UserAccount As String = "Everyone" 'Specify the user here
            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath & "\log\")
            Dim FolderAcl As New DirectorySecurity
            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            FolderInfo.SetAccessControl(FolderAcl)
            Dim prg = Environment.GetEnvironmentVariable("ProgramFiles(x86)")
            If prg = "" Then
                prg = Environment.GetEnvironmentVariable("ProgramFiles")
            End If
            If prg.Trim().Length <> 0 Then
                Dim excelss As IO.DirectoryInfo = New IO.DirectoryInfo(prg & "\excelss dmac\")
                FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
                excelss.SetAccessControl(FolderAcl)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

End Class
