Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Public Class frmPrincipal

    Public claPrin As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
    Public Shared oConfig As New clsConfig

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
        Dim msg As String = oExcelSS.AppInit()
        If msg = "" Then
            oConfig.InitializeProperties(claPrin)
            Dim srURL As New System.Uri(oConfig.rReportServerURL)
            rvPrin.ServerReport.ReportPath = oConfig.rReportPath & oConfig.ReportName
            rvPrin.ServerReport.ReportServerUrl = srURL
            oConfig.CheckForParameters(claPrin, rvPrin)
            'Dim nCred As New System.Net.NetworkCredential(oConfig.rNetworkUser, ExcelSSGen.Main.DecodedPassword(oConfig.rNetworkPass))
            'rvPrin.ServerReport.ReportServerCredentials.NetworkCredentials = nCred
            rvPrin.RefreshReport()
        Else
            MsgBox(msg, MsgBoxStyle.Critical)
            oExcelSS.EndApplication()
        End If

    End Sub

    Public Sub LoadSettings()
        oExcelSS.logoURL = ConfigurationSettings.AppSettings("logoURL")
        oExcelSS.AppFolderName = ConfigurationSettings.AppSettings("AppFolderName")
        oExcelSS.IniAppFile = ConfigurationSettings.AppSettings("IniAppFile")
        oExcelSS.ReportToolName = ConfigurationSettings.AppSettings("ReportToolName")
    End Sub

End Class
