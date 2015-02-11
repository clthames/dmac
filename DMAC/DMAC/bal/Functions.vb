Imports System.IO


Public Class Functions
    Public Sub ErrorLog(ByVal strLogMessage As String)
        Dim strFilepath As String
        strFilepath = Environment.CurrentDirectory & "\Log\"
        If Not System.IO.Directory.Exists(strFilepath) Then
            System.IO.Directory.CreateDirectory(strFilepath)
        End If
        strFilepath = strFilepath & "log.txt"
        Dim SWObj As StreamWriter
        strLogMessage = String.Format("{0}:{1}", DateTime.Now, strLogMessage)
        If Not File.Exists(strFilepath) Then
            SWObj = New StreamWriter(strFilepath)
        Else
            SWObj = File.AppendText(strFilepath)
        End If
        SWObj.WriteLine(strLogMessage)
        SWObj.WriteLine()
        SWObj.Close()
    End Sub
End Class

