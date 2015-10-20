Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class clsConfig

#Region "Declarations"

    Public regCompany As String = ""
    Public varcCompanyID As String = ""
    Public varcCompanyName As String = ""
    Public varcSqlServerHost As String = ""
    Public varcPort As String = ""
    Public varcDatabase As String = ""
    Public varcDatabaseUser As String = ""
    Public varcDatabasePass As String = ""
    Public varrCompanyID As String = ""
    Public varrReportServerURL As String = ""
    Public varrReportPath As String = ""
    Public varrNetworkUser As String = ""
    Public varrNetworkPass As String = ""
    Public varReportName As String = ""
    Public srIni As StreamReader
    Public txtIni As String = ""
    Public txtCompanyLine As String = ""
    Public txtReportLine As String = ""
    Public arrCompany() As String
    Public arrReport() As String
    Dim varPrinterName As String


#End Region

#Region "Properties"


    'All Properties works for selected company

    ''' <summary>
    ''' Gets the CompanyID for Company line in dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property cCompanyID As String
        Get
            Return varcCompanyID
        End Get
    End Property

    ''' <summary>
    ''' Gets the Company Name for Company line in dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property cCompanyName As String
        Get
            Return varcCompanyName
        End Get
    End Property

    ''' <summary>
    ''' Gets Sql Server Host from dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property cSqlServerHost As String
        Get
            Return varcSqlServerHost
        End Get
    End Property

    ''' <summary>
    ''' Gets Optional Port from dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property cPort As String
        Get
            Return varcPort
        End Get
    End Property

    ''' <summary>
    ''' Gets Database Name from dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property cDatabase As String
        Get
            Return varcDatabase
        End Get
    End Property

    ''' <summary>
    ''' Gets Database User Name from dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property cDatabaseUser As String
        Get
            Return varcDatabaseUser
        End Get
    End Property

    ''' <summary>
    ''' Gets Database User Password "encoded" from dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property cDatabasePass As String
        Get
            Return varcDatabasePass
        End Get
    End Property

    ''' <summary>
    ''' Gets the CompanyID for Report line in dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property rCompanyID As String
        Get
            Return varrCompanyID
        End Get
    End Property

    ''' <summary>
    ''' Gets Report Server URL from dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property rReportServerURL As String
        Get
            Return varrReportServerURL
        End Get
    End Property

    ''' <summary>
    ''' Gets Report Path from dmac.ini and build readable path
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property rReportPath As String
        Get
            If varrReportPath.Trim.Count > 0 Then
                Return "/" & varrReportPath & "/"
            Else
                Return "/"
            End If
        End Get
    End Property

    ''' <summary>
    ''' Gets Network User from dmac.ini
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property rNetworkUser As String
        Get
            Return varrNetworkUser
        End Get
    End Property

    ''' <summary>
    ''' Gets Network Password from dmac.ini "encoded"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property rNetworkPass As String
        Get
            Return varrNetworkPass
        End Get
    End Property

    ''' <summary>
    ''' Gets the Report Name to Load as indicated in command line.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ReportName As String
        Get
            Return varReportName
        End Get
    End Property
    ''' <summary>
    ''' Gets the Printername Name to print as indicated in command line.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PrinterName As String
        Get
            Return varPrinterName
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub InitializeProperties(claPrin As System.Collections.ObjectModel.ReadOnlyCollection(Of String))
        Try
            regCompany = GetSetting("DMAC", "Session", "CompanyID").Trim
            ExtractLinesfromINI()
            ArrangeArrays()
            varcCompanyID = arrCompany(0).Trim
            varcCompanyName = arrCompany(1).Trim
            varcSqlServerHost = arrCompany(2).Trim
            varcPort = arrCompany(3).Trim
            varcDatabase = arrCompany(4).Trim
            varcDatabaseUser = arrCompany(5).Trim
            varcDatabasePass = arrCompany(6).Trim
            varrCompanyID = arrReport(0).Trim
            varrReportServerURL = arrReport(1).Trim
            varrReportPath = arrReport(2).Trim
            varrNetworkUser = arrReport(3).Trim
            varrNetworkPass = arrReport(4).Trim
            varReportName = claPrin.Item(0)
            If claPrin.Count > 1 Then
                varPrinterName = claPrin.Item(1)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub CheckForParameters(claPrin As System.Collections.ObjectModel.ReadOnlyCollection(Of String), ByRef rv As ReportViewer)
        Try
            If claPrin.Count > 2 Then
                Dim parString As String = ""
                Dim arrParam() As String
                For x As Integer = 1 To claPrin.Count - 1
                    If claPrin(x).Trim.Length > 0 Then
                        parString += " " & claPrin(x)
                    End If
                Next
                parString = parString.Trim
                arrParam = parString.Split("&")
                For y As Integer = 0 To arrParam.Length - 1
                    Dim name As String = arrParam(y).Substring(0, arrParam(y).IndexOf("="))
                    Dim val As String = arrParam(y).Substring(arrParam(y).IndexOf("=") + 1)
                    Dim rp As New ReportParameter(name, val, True)
                    rv.ServerReport.SetParameters(rp)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub ExtractLinesfromINI()
        Try
            'Dim pathF As String = IIf(oExcelSS.xArchitecture, oExcelSS.x86PFilePath, oExcelSS.PFilePath & "\" & oExcelSS.AppFolderName) & "\" & oExcelSS.IniAppFile
            'chg102015ly change all path statements to use only AppFolderName
            Dim pathF As String = "\" & oExcelSS.AppFolderName & "\" & oExcelSS.IniAppFile
            If File.Exists(pathF) Then
                srIni = New StreamReader(pathF)
                While Not srIni.EndOfStream
                    txtIni = srIni.ReadLine()
                    If txtIni.Trim.Length > 0 Then
                        If InStr(txtIni, "Company", CompareMethod.Text) > 0 And InStr(txtIni.Substring(0, 25), regCompany & ",", CompareMethod.Text) > 0 And Not txtIni.StartsWith("'") Then
                            txtCompanyLine = txtIni
                        End If
                        If InStr(txtIni, "Reports", CompareMethod.Text) > 0 And InStr(txtIni, regCompany & ",", CompareMethod.Text) > 0 And Not txtIni.StartsWith("'") Then
                            txtReportLine = txtIni
                        End If
                    End If
                End While
                srIni.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub ArrangeArrays()
        Try
            Dim pos As Integer
            pos = InStr(txtCompanyLine, "=", CompareMethod.Text)
            txtCompanyLine = txtCompanyLine.Trim.Substring(pos + 1)
            pos = InStr(txtReportLine, "=", CompareMethod.Text)
            txtReportLine = txtReportLine.Trim.Substring(pos + 1)
            arrCompany = txtCompanyLine.Split(",")
            arrReport = txtReportLine.Split(",")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region



End Class
