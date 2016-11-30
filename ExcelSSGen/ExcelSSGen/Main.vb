Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.SqlTypes
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class Main

#Region "Declarations"
    'chg102015ly don't get these path variables . . we will only use appath
    'Public x86PFilePath As String = Application.StartupPath
    'Public PFilePath As String = IIf(File.Exists("C:\Program Files\ExcelSS DMAC\dmac.ini"), "C:\Program Files", "C:\Program Files (x86)")
    'Public xArchitecture As Boolean = IIf(InStr(LCase(Application.StartupPath), "bin") > 0, False, True)
    'dmacbuild - folder where build is located.  If this is startupPath we know this is run in environment so set path to \Dmac (all developers should make a path to \Dmac to run
    Public DevPath As String = IIf(GetSetting(AppName:="DMAC", Section:="Session", Key:="DeveloperPath") <> "", GetSetting(AppName:="DMAC", Section:="Session", Key:="DeveloperPath"), "\Dmac")
    Public AppPath As String = IIf(InStr(LCase(Application.StartupPath), "dmacbuild") > 0, DevPath, Application.StartupPath)
    Public Shared connectionString As String
    Public companyarray As New ArrayList
    Public menuArray As New ArrayList
    Public Conn As New Data.SqlClient.SqlConnection
    Public appTitle As String = "Configuration Tool"
    Public ActiveUserID As String = String.Empty
    Public ActiveUserName As String = String.Empty
    Public ActiveCompanyName As String = String.Empty
    Public ActiveCompanyID As String = String.Empty
    Public logintime As String = String.Empty
    Public loginHr As String = String.Empty
    Public userid As String = String.Empty
    Public selectedItem As String = String.Empty
    Public dtPermission As New DataTable
    Public dtShortcut As New DataTable
    Public isMenuBinded As Boolean = False
    Public isOutlookButtonBinded As Boolean = False
    Public arrayOutlookButtons As New ArrayList
    Public selectedShortcutFromList As String = String.Empty
    Public selectedShortcutFromListTag As String = String.Empty
    Public shortcutFor As String = String.Empty
    Public ConnStr As String = ""
    Public licenseKey As String = String.Empty
    Public logoURL As String = "http://www.excelss.com/validate/dynamic.php"
    Public dynamicImage As String = String.Empty
    Public visitUrl As String = String.Empty
    Public IniAppFile As String = String.Empty
    Public AppFolderName As String = String.Empty
    Public ReportToolName As String = String.Empty
    Public cmsearchArray As New ArrayList
    Public servername As String = String.Empty, database As String = String.Empty, dbuserid As String = String.Empty, password As String = String.Empty
    Public reportAlreadyExists As Boolean = False
    Public srOut As String = ""

#End Region

#Region "Enums"

    Public Enum EndMonthDates As Integer
        enJan = 31
        enFeb = 28
        enMar = 31
        enApr = 30
        enMay = 31
        enJun = 30
        enJul = 31
        enAug = 31
        enSep = 30
        enOct = 31
        enNov = 30
        enDec = 31
    End Enum

    Public Enum UserStatus As Integer
        Valid = 0
        Invalid = 1
        LoggedValid = 2
    End Enum

#End Region

#Region "DataLayer"

    Public Function ExecuteShortcut(Optional ByVal p_ID As Int64 = 0,
                                  Optional ByRef p_UserIDKey As Int32 = 0,
                                  Optional ByRef p_UserID As String = Nothing,
                                  Optional ByVal p_ShortcutType As String = Nothing,
                                  Optional ByVal p_ShortcutName As String = Nothing,
                                  Optional ByVal p_ShortcutFor As String = Nothing,
                                  Optional ByVal p_Linkto As String = Nothing,
                                  Optional ByVal p_Parameters As String = Nothing,
                                  Optional ByVal p_Type As String = "D",
                                  Optional ByVal outputParam As String = Nothing) As Boolean

        Dim status As Boolean = False
        Dim procedureName As String = "uspDmac_ShortcutDML"
        Dim sqlconnection As SqlConnection = New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand(procedureName, sqlconnection)
        Dim output As String = ""

        Try
            If sqlconnection.State = ConnectionState.Closed Then sqlconnection.Open()
            cmd.CommandType = CommandType.StoredProcedure
            ' add parameter
            cmd.Parameters.AddWithValue("@ID", p_ID)
            cmd.Parameters.AddWithValue("@UserIDKey", p_UserIDKey)
            cmd.Parameters.AddWithValue("@UserID", p_UserID)
            cmd.Parameters.AddWithValue("@ShortcutType", p_ShortcutType)
            cmd.Parameters.AddWithValue("@ShortcutName", p_ShortcutName)
            cmd.Parameters.AddWithValue("@ShortcutFor", p_ShortcutFor)
            cmd.Parameters.AddWithValue("@Linkto", p_Linkto)
            cmd.Parameters.AddWithValue("@Parameters", p_Parameters)
            cmd.Parameters.AddWithValue("@Type", p_Type)
            If Not outputParam Is Nothing Then
                cmd.Parameters.Add(outputParam, SqlDbType.VarChar, 500).Direction = ParameterDirection.Output
            End If
            cmd.ExecuteNonQuery()
            output = cmd.Parameters("@strStatus").Value
            If output = "Success" Then
                status = True
            Else
                status = False
                If output <> "" Then
                    ErrorLog("Error From Procedure " & procedureName & "##" + output)
                End If
            End If
        Catch
            ErrorLog("Error From Procedure " & procedureName & "##" + output)
        Finally
            If cmd IsNot Nothing Then cmd.Dispose()
            If sqlconnection IsNot Nothing AndAlso sqlconnection.State <> ConnectionState.Closed Then sqlconnection.Close()
        End Try
        Return status
    End Function
    Public Sub fillTrvCategory(ByRef obj As Object, ByVal Qry As String)
        Dim dt As New DataTable
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                Using sqlcommand As New SqlCommand
                    Dim key As String
                    Dim node As String
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = Qry
                    sqlcommand.CommandType = CommandType.Text
                    Dim sr As New SqlDataAdapter(sqlcommand)
                    sr.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For Each row As DataRow In dt.Rows
                            Dim trNode As New TreeNode
                            key = row(0).ToString
                            node = row(1).ToString
                            trNode.Tag = key
                            trNode.Text = node
                            trNode.Name = node
                            loadChildTree(trNode, key)
                            DirectCast(obj, TreeView).Nodes.Add(trNode)
                        Next
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("Data Layer fillTrvCategory() ##" + ex.Message.ToString())
        Finally
        End Try
    End Sub
    Public Sub loadChildTree(ByRef obj As TreeNode, ByVal categoryID As Integer)
        Dim dt As New DataTable
        Dim key As String
        Dim node As String
        Try
            dt = getDataTable("SELECT CategoryIDKey, ReportFileName FROM ReportDefs WHERE isActive=1 AND isDeleted=0 AND CategoryIDKey = " & categoryID)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim trNode As New TreeNode
                    key = row(0).ToString
                    node = row(1).ToString
                    trNode.Tag = key
                    trNode.Text = node
                    obj.Nodes.Add(trNode)
                Next
            End If
        Catch ex As Exception
            ErrorLog("Data Layer fillTrvCategory() ##" + ex.Message.ToString())
        End Try
    End Sub
    Public Function userLoginStatusUpdation(ByVal procedureName As String,
                                            Optional ByVal param As String(,) = Nothing, Optional ByVal outputParam As String = Nothing) As Boolean
        Dim status As Boolean = False
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then
                    sqlconnection.Open()
                End If
                Using sqlcommand As New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = procedureName
                    sqlcommand.CommandType = CommandType.StoredProcedure
                    If Not param Is Nothing Then
                        For iRow As Integer = 0 To param.GetUpperBound(0)
                            For iCol As Integer = 0 To (param.GetUpperBound(1) - 1)
                                sqlcommand.Parameters.AddWithValue(param(iRow, iCol), param(iRow, iCol + 1))
                            Next
                        Next
                    End If
                    If Not outputParam Is Nothing Then
                        sqlcommand.Parameters.Add(outputParam, SqlDbType.VarChar, 500).Direction = ParameterDirection.Output
                    End If
                    sqlcommand.ExecuteNonQuery()
                    Dim output As String = sqlcommand.Parameters("@strStatus").Value
                    If output = "Success" Then
                        status = True
                    Else
                        status = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            status = False
            ErrorLog("userLoginStatusUpdation Error ##" + ex.Message.ToString())
        End Try
        userLoginStatusUpdation = status
    End Function
    Public Function isValidUser(ByVal procedureName As String, Optional ByVal param As String(,) = Nothing, Optional ByVal outputParam As String = Nothing) As Integer
        Try
            isValidUser = UserStatus.Invalid
            Using sqlconnection As New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then
                    sqlconnection.Open()
                End If
                Using sqlcommand As New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = procedureName
                    sqlcommand.CommandType = CommandType.StoredProcedure
                    If Not param Is Nothing Then
                        For iRow As Integer = 0 To param.GetUpperBound(0)
                            For iCol As Integer = 0 To (param.GetUpperBound(1) - 1)
                                sqlcommand.Parameters.AddWithValue(param(iRow, iCol), param(iRow, iCol + 1))
                            Next
                        Next
                    End If
                    Dim sr As New SqlDataAdapter(sqlcommand)
                    Dim dt As New DataTable
                    sr.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim user As String = Convert.ToString(dt.Rows(0)("Username"))
                        Dim uid As String = Convert.ToString(dt.Rows(0)("ID"))
                        If uid <> "" Then
                            userid = uid
                        End If
                        If user <> "" Then
                            ActiveUserName = user
                            isValidUser = UserStatus.Valid
                        Else
                            isValidUser = UserStatus.Invalid
                        End If
                        If Convert.ToBoolean(dt.Rows(0)("Status")) = True Then
                            isValidUser = UserStatus.LoggedValid
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            isValidUser = UserStatus.Invalid
            ErrorLog("isValidUser Error ##" + ex.Message.ToString())
        End Try
    End Function
    Public Function getDataTable(ByVal Qry As String, Optional ByVal isFromProcedure As Boolean = False, Optional ByVal parameters_values As SqlParameter() = Nothing) As DataTable
        Dim dt As New DataTable
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                Using sqlcommand As New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = Qry
                    sqlcommand.CommandType = CommandType.Text
                    sqlcommand.CommandTimeout = 20000
                    If isFromProcedure Then
                        sqlcommand.CommandType = CommandType.StoredProcedure
                    End If
                    If Not parameters_values Is Nothing Then
                        sqlcommand.Parameters.Clear()
                        For Each param As SqlParameter In parameters_values
                            sqlcommand.Parameters.Add(param)
                        Next
                    End If
                    Dim sr As New SqlDataAdapter(sqlcommand)
                    sr.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("Data Layer getDataTable() ##" + ex.Message.ToString())
            Throw (ex)
        End Try
        getDataTable = dt
    End Function
    Public Function getDataSet(ByVal Qry As String, Optional ByVal isFromProcedure As Boolean = False, Optional ByVal parameters_values As SqlParameter() = Nothing) As DataSet
        Dim ds As New DataSet
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                Using sqlcommand As New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = Qry
                    sqlcommand.CommandType = CommandType.Text
                    sqlcommand.CommandTimeout = 20000
                    If isFromProcedure Then
                        sqlcommand.CommandType = CommandType.StoredProcedure
                    End If
                    If Not parameters_values Is Nothing Then
                        For Each param As SqlParameter In parameters_values
                            sqlcommand.Parameters.Add(param)
                        Next
                    End If
                    Dim sr As New SqlDataAdapter(sqlcommand)
                    sr.Fill(ds)
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("Data Layer getDataTable() ##" + ex.Message.ToString())
        End Try
        getDataSet = ds
    End Function
    Public Function isSavedData(ByVal procedureName As String,
                                Optional ByVal dtParamName As String = Nothing,
                                Optional ByVal dtValue As DataTable = Nothing,
                                Optional ByVal param As String(,) = Nothing,
                                Optional ByVal outputParam As String = Nothing,
                                Optional ByVal parameters_values As SqlParameter() = Nothing) As Boolean
        Dim status As Boolean = False
        Try
            Using sqlconnection As SqlConnection = New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then sqlconnection.Open()
                Using sqlcommand As SqlCommand = New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = procedureName
                    sqlcommand.CommandTimeout = 0
                    sqlcommand.CommandType = CommandType.StoredProcedure

                    If Not dtParamName Is Nothing AndAlso Not dtValue Is Nothing Then
                        sqlcommand.Parameters.AddWithValue(dtParamName, dtValue)
                    End If
                    If Not param Is Nothing Then
                        For iRow As Integer = 0 To param.GetUpperBound(0)
                            For iCol As Integer = 0 To (param.GetUpperBound(1) - 1)
                                sqlcommand.Parameters.AddWithValue(param(iRow, iCol), param(iRow, iCol + 1))
                            Next
                        Next
                    End If
                    If Not outputParam Is Nothing Then
                        sqlcommand.Parameters.Add(outputParam, SqlDbType.VarChar, 500).Direction = ParameterDirection.Output
                    End If
                    If Not parameters_values Is Nothing Then
                        For Each parameter As SqlParameter In parameters_values
                            sqlcommand.Parameters.Add(parameter)
                        Next
                    End If
                    sqlcommand.ExecuteNonQuery()
                    Dim output As String = sqlcommand.Parameters("@strStatus").Value
                    If output = "Success" Then
                        status = True
                    Else
                        status = False
                        If output <> "" Then
                            ErrorLog("Error From Procedure " & procedureName & "##" + output)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("isSaveUser Error ##" + ex.Message.ToString())
            status = False
        End Try
        isSavedData = status
    End Function
    Public Sub fillTrvSelectReports(ByRef trv As TreeView)
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dt3 As New DataTable
        Try
            dt = getDataTable("uspReporting_GetReportGroups", True, )
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim Node0 As New TreeNode
                    Node0.Tag = row(0)
                    Node0.Text = row(1)
                    trv.Nodes.Add(Node0)
                    Dim p As SqlParameter() = New SqlParameter(0) {}
                    p(0) = New SqlParameter("@key", CInt(Node0.Tag))
                    dt2 = getDataTable("uspReporting_GetReportCategories", True, p)
                    If dt2.Rows.Count > 0 Then
                        For Each row2 As DataRow In dt2.Rows
                            Dim Node1 As New TreeNode
                            Node1.Tag = row2(0)
                            Node1.Text = row2(1)
                            Node0.Nodes.Add(Node1)
                            Dim p2 As SqlParameter() = New SqlParameter(0) {}
                            p2(0) = New SqlParameter("@key", CInt(Node1.Tag))
                            dt3 = getDataTable("uspReporting_GetReportDefs", True, p2)
                            If dt3.Rows.Count > 0 Then
                                For Each row3 As DataRow In dt3.Rows
                                    Dim Node2 As New TreeNode
                                    Node2.Tag = row3(0)
                                    Node2.Text = row3(1)
                                    If Not System.DBNull.Value.Equals(row3(3)) Then
                                        Node2.Name = row3(3)
                                    End If
                                    If row3(2).ToString.Trim.Length = 0 Then
                                        Node2.ToolTipText = "No description available."
                                    Else
                                        Node2.ToolTipText = row3(2)

                                    End If
                                    Node1.Nodes.Add(Node2)
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            ErrorLog("Data Layer fillTrvGroup() ##" + ex.Message.ToString())
        Finally
        End Try
    End Sub
    Public Sub getReportPreview(ByVal id As Integer, ByRef pb As PictureBox)
        Dim dt As New DataTable
        Try
            Dim p As SqlParameter() = New SqlParameter(0) {}
            p(0) = New SqlParameter("@ReportIDKey", id)
            dt = getDataTable("uspDmac_GetReportPreviewImage", True, p)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Using ms As New IO.MemoryStream(CType(r(0), Byte()))
                    Dim img As Image = Image.FromStream(ms)
                    pb.Image = img
                End Using
            Else
                pb.Image = Nothing
            End If
        Catch ex As Exception
            ErrorLog("Data Layer getReportPreview() ##" + ex.Message.ToString())
        End Try
    End Sub
    Public Function isDashboardatLogin() As Boolean
        Dim dt As New DataTable
        Dim p As System.Data.SqlClient.SqlParameter() = New System.Data.SqlClient.SqlParameter(0) {}
        p(0) = New System.Data.SqlClient.SqlParameter("@UserID", ActiveUserID)
        dt = getDataTable("uspDashboard_isDashboardatLogin", True, p)
        If dt.Rows.Count > 0 Then
            isDashboardatLogin = True
        Else
            isDashboardatLogin = False
        End If
    End Function
    Private Function connectDb(ByVal server As String, ByVal database As String, ByVal userid As String, ByVal password As String) As Boolean
        Try
            Dim pass As String = DecodedPassword(password)
            ConnStr = "Initial Catalog=" & database & ";User ID=" & userid & ";pwd=" & pass & ";Data Source=" & server & ";"
            If ConnStr.Trim().Length > 0 Then
                Conn.ConnectionString = ConnStr
                connectionString = ConnStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                    If Conn.State = ConnectionState.Open Then
                        Conn.Close()
                    End If
                Else
                    MsgBox("Test connection failed for Server : ", MsgBoxStyle.Critical)
                    Return False
                End If
            End If
        Catch ex As Exception
            ErrorLog("btnLogin_Click Error## " + ex.Message.ToString())
            Return False
        End Try
        Return True
    End Function
    Public Function ConnectDataBaseAsperRegistry() As Boolean
        Dim isConnected As Boolean = False
        Try
            Dim port As String = String.Empty
            Dim TextLine As String
            'Dim Path As String = IIf(xArchitecture, x86PFilePath, PFilePath & "\" & AppFolderName) & "\"
            'chg102015ly change all path statements to use only AppFolderName
            Dim Path As String = AppPath & "\"
            If Directory.Exists(Path) Then
                Dim objReader As New System.IO.StreamReader(Path & IniAppFile)
                Dim companyid As String = GetSetting(AppName:="DMAC", Section:="Session", Key:="CompanyID")
                Dim reportServerPath As String = String.Empty, reportPath As String = String.Empty, reportDatabase As String = String.Empty
                Dim networkUser As String = String.Empty, networkPassword As String = String.Empty
                Dim isDBCcredentialfromini As Boolean = False
                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine() & vbNewLine
                    If TextLine.Trim <> "" Then
                        Dim tmpKeyword As String = Left(TextLine, InStr(TextLine, "=") - 1).Trim()
                        Select Case LCase(tmpKeyword)
                            Case "company"
                                Dim _comma() = Mid(TextLine, InStr(TextLine, "=") + 1).Trim().Split(",")
                                Dim selecteditem As String = String.Empty
                                If Not isDBCcredentialfromini Then
                                    If LCase(companyid) = LCase(_comma(0)) Then
                                        servername = _comma(2).ToString().Trim()
                                        port = _comma(3).ToString().Trim()
                                        database = _comma(4).ToString().Trim()
                                        dbuserid = _comma(5).ToString().Trim()
                                        password = _comma(6).ToString().Trim()
                                        isDBCcredentialfromini = True
                                    End If
                                End If
                            Case "reports"
                                Dim _report() = Mid(TextLine, InStr(TextLine, "=") + 1).Trim().Split(",")
                                Dim selecteditem As String = String.Empty
                                If LCase(companyid) = LCase(_report(0).ToString().Trim()) Then
                                    reportServerPath = _report(1).ToString().Trim()
                                    reportPath = _report(2).ToString().Trim()
                                    reportDatabase = _report(5).ToString().Trim()
                                    networkUser = _report(3).ToString().Trim()
                                    networkPassword = _report(4).ToString().Trim()
                                    If reportServerPath.Trim <> "" AndAlso reportPath.Trim <> "" AndAlso reportDatabase.Trim <> "" AndAlso networkUser.Trim <> "" AndAlso networkPassword.Trim <> "" Then
                                        ReportServer.ReportServerPath = reportServerPath
                                        ReportServer.ReportPath = reportPath
                                        ReportServer.UserName = networkUser
                                        ReportServer.Password = networkPassword
                                        ReportServer.ReportServerDatabase = reportDatabase
                                    End If
                                    Exit Do
                                End If
                            Case "cmsearch"
                                Dim _cmsearch() = Mid(TextLine, InStr(TextLine, "=") + 1).Trim().Split(",")
                                For x As Int16 = 0 To UBound(_cmsearch)
                                    cmsearchArray.Add(_cmsearch(x))
                                Next
                                Exit Do
                        End Select
                    Else
                        Exit Do
                    End If
                Loop
                If servername = "" OrElse database = "" Then
                    MsgBox("Missing data in company file at " & Path & "  Please contact Excel Software Services for assistance", vbCritical)
                    EndApplication()
                End If
                isConnected = connectDb(servername, database, dbuserid, password)
            Else
                MsgBox("Missing company file at " & Path & " Please contact Excel Software Services for assistance", vbCritical)
                EndApplication()
            End If
        Catch ex As Exception
            ErrorLog("Main --> BindCompanyFromINI Error## " & ex.Message.ToString)
            Throw (ex)
            isConnected = False
        End Try
        ConnectDataBaseAsperRegistry = isConnected
    End Function
    Public Sub fillTrvGroup(ByRef obj As Object, ByVal masterQry As String, Optional ByVal isFromProcedure As Boolean = False)
        Dim dt As New DataTable
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                Using sqlcommand As New SqlCommand
                    Dim key As String
                    Dim node As String
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = masterQry
                    sqlcommand.CommandType = CommandType.Text
                    If isFromProcedure Then
                        sqlcommand.CommandType = CommandType.StoredProcedure
                    End If
                    Dim sr As New SqlDataAdapter(sqlcommand)
                    sr.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        For Each row As DataRow In dt.Rows
                            Dim trNode As New TreeNode
                            key = row(0).ToString
                            node = row(1).ToString
                            trNode.Tag = key
                            trNode.Text = node
                            trNode.ImageIndex = 4
                            trNode.SelectedImageIndex = 5
                            DirectCast(obj, TreeView).Nodes.Add(trNode)
                        Next
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("Data Layer fillTrvGroup() ##" + ex.Message.ToString())
        Finally
        End Try
    End Sub
    Public Function saveData(ByVal sql As String,
                             Optional ByVal parameters_values As SqlParameter() = Nothing,
                             Optional ByVal outputParam As String = Nothing,
                             Optional ByVal isReport As Boolean = False) As Boolean
        Dim ans As Boolean = False
        Dim ret As Integer = 0
        Dim transaction As SqlTransaction = Nothing
        Dim strOut As String = String.Empty
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then
                    sqlconnection.Open()
                End If
                Using sqlcommand As New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    'transaction = sqlcommand.Connection.BeginTransaction

                    'sqlcommand.Transaction = transaction
                    sqlcommand.CommandText = sql
                    sqlcommand.CommandType = CommandType.StoredProcedure
                    If Not parameters_values Is Nothing Then
                        For Each param As SqlParameter In parameters_values
                            sqlcommand.Parameters.Add(param)
                        Next
                    End If
                    If Not outputParam Is Nothing Then
                        sqlcommand.Parameters.Add(outputParam, SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output
                    End If
                    ret = sqlcommand.ExecuteNonQuery
                    strOut = sqlcommand.Parameters("@outStatus").Value
                    If strOut <> "Exist" Then
                        'transaction.Commit()
                        reportAlreadyExists = False
                        If strOut.Trim.ToLower = "success" Then
                            ans = True
                        Else
                            'transaction.Rollback()
                            ans = False
                        End If
                    Else
                        reportAlreadyExists = True
                        ans = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            ans = False
            transaction.Rollback()
            ErrorLog("Data Layer saveData() ##" + ex.Message.ToString())
        End Try
        saveData = ans
    End Function
    Public Sub fillComboBox(ByRef obj As Object, ByVal qry As String, ByVal displayMember As String, ByVal valueMember As String, Optional ByVal pblnIsStoredProcedure As Boolean = True)
        Dim dt As New DataTable
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                Using sqlcommand As New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = qry
                    If pblnIsStoredProcedure Then
                        sqlcommand.CommandType = CommandType.StoredProcedure
                    Else
                        sqlcommand.CommandType = CommandType.Text
                    End If
                    Dim sr As New SqlDataAdapter(sqlcommand)
                    sr.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        DirectCast(obj, ComboBox).DataSource = dt
                        DirectCast(obj, ComboBox).DisplayMember = displayMember
                        DirectCast(obj, ComboBox).ValueMember = valueMember
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("Data Layer fillComboBox() ##" + ex.Message.ToString())
        Finally
        End Try
    End Sub
    Public Function FillTreeView(ByVal obj As TreeView, ByVal rootNode As TreeNode,
                              ByVal procedureName As String, Optional ByVal isProcedure As Boolean = False,
                              Optional ByVal param As String(,) = Nothing,
                              Optional ByVal isFillChildNode As Boolean = False) As Boolean
        Dim status As Boolean = False
        Dim ds As New DataSet("users")
        Try
            obj.Nodes.Clear()
            Using sqlconnection As SqlConnection = New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then sqlconnection.Open()
                Using sqlcommand As SqlCommand = New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = procedureName
                    If isProcedure Then
                        sqlcommand.CommandType = CommandType.StoredProcedure
                    Else
                        sqlcommand.CommandType = CommandType.Text
                    End If
                    sqlcommand.CommandTimeout = 0
                    If Not param Is Nothing Then
                        For iRow As Integer = 0 To param.GetUpperBound(0)
                            For iCol As Integer = 0 To (param.GetUpperBound(1) - 1)
                                sqlcommand.Parameters.AddWithValue(param(iRow, iCol), param(iRow, iCol + 1))
                            Next
                        Next
                    End If
                    Dim da As New SqlDataAdapter(sqlcommand)
                    da.Fill(ds)
                End Using
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    Dim tn As New TreeNode()
                    tn.Text = Convert.ToString(row(1))
                    tn.Tag = Convert.ToString(row(0))
                    rootNode.Nodes.Add(tn)
                    If isFillChildNode Then
                        Dim para As String(,) = New String(,) {{"@strSubMenu", Convert.ToString(row(1))}}
                        bindChildNode(tn, Convert.ToString(row(1)), para)
                    End If
                Next
            End If
            status = True
            obj.Nodes.Add(rootNode)
        Catch ex As Exception
            ErrorLog("FillTreeView Error ##" + ex.Message.ToString())
            status = False
        End Try
        Return status
    End Function
    Private Sub bindChildNode(ByVal node As TreeNode, ByVal menuName As String, Optional ByVal param As String(,) = Nothing)
        Try
            Dim ds As New DataSet("users")
            Using sqlconnection As SqlConnection = New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then sqlconnection.Open()
                Using sqlcommand As SqlCommand = New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = "uspConfiguration_GetMenus"
                    sqlcommand.CommandTimeout = 0
                    sqlcommand.CommandType = CommandType.StoredProcedure
                    If Not param Is Nothing Then
                        For iRow As Integer = 0 To param.GetUpperBound(0)
                            For iCol As Integer = 0 To (param.GetUpperBound(1) - 1)
                                sqlcommand.Parameters.AddWithValue(param(iRow, iCol), param(iRow, iCol + 1))
                            Next
                        Next
                    End If
                    Dim da As New SqlDataAdapter(sqlcommand)
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In ds.Tables(0).Rows
                            Dim tn As New TreeNode()
                            tn.Text = Convert.ToString(row(1))
                            tn.Tag = Convert.ToString(row(0))
                            node.Nodes.Add(tn)
                            Dim para As String(,) = New String(,) {{"@strSubMenu", Convert.ToString(row(1))}}
                            bindNextChildNode(tn, Convert.ToString(row(1)), para)
                        Next
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("bindChildNode Error ##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub bindNextChildNode(ByVal node As TreeNode, ByVal menuName As String, Optional ByVal param As String(,) = Nothing)
        Try
            Dim ds As New DataSet("users")
            Using sqlconnection As SqlConnection = New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then sqlconnection.Open()
                Using sqlcommand As SqlCommand = New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = "uspConfiguration_GetMenus"
                    sqlcommand.CommandTimeout = 0
                    sqlcommand.CommandType = CommandType.StoredProcedure
                    If Not param Is Nothing Then
                        For iRow As Integer = 0 To param.GetUpperBound(0)
                            For iCol As Integer = 0 To (param.GetUpperBound(1) - 1)
                                sqlcommand.Parameters.AddWithValue(param(iRow, iCol), param(iRow, iCol + 1))
                            Next
                        Next
                    End If
                    Dim da As New SqlDataAdapter(sqlcommand)
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In ds.Tables(0).Rows
                            Dim tn As New TreeNode()
                            tn.Text = Convert.ToString(row(1))
                            tn.Tag = Convert.ToString(row(0))
                            node.Nodes.Add(tn)
                            Dim para As String(,) = New String(,) {{"@strSubMenu", Convert.ToString(row(1))}}
                            bindNextLevelChildNode(tn, Convert.ToString(row(1)), para)
                        Next
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("bindChildNode Error ##" + ex.Message.ToString())
        End Try
    End Sub
    Private Sub bindNextLevelChildNode(ByVal node As TreeNode, ByVal menuName As String, Optional ByVal param As String(,) = Nothing)
        Try
            Dim ds As New DataSet("users")
            Using sqlconnection As SqlConnection = New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then sqlconnection.Open()
                Using sqlcommand As SqlCommand = New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = "uspConfiguration_GetMenus"
                    sqlcommand.CommandTimeout = 0
                    sqlcommand.CommandType = CommandType.StoredProcedure
                    If Not param Is Nothing Then
                        For iRow As Integer = 0 To param.GetUpperBound(0)
                            For iCol As Integer = 0 To (param.GetUpperBound(1) - 1)
                                sqlcommand.Parameters.AddWithValue(param(iRow, iCol), param(iRow, iCol + 1))
                            Next
                        Next
                    End If
                    Dim da As New SqlDataAdapter(sqlcommand)
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In ds.Tables(0).Rows
                            Dim tn As New TreeNode()
                            tn.Text = Convert.ToString(row(1))
                            tn.Tag = Convert.ToString(row(0))
                            node.Nodes.Add(tn)
                        Next
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("bindChildNode Error ##" + ex.Message.ToString())
        End Try
    End Sub
    Public Function getSQLTable(ByVal tblName As String) As DataTable
        Dim dt As New DataTable
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                Using sqlcommand As New SqlCommand
                    sqlcommand.Connection = sqlconnection
                    sqlcommand.CommandText = tblName
                    sqlcommand.CommandType = CommandType.TableDirect
                    sqlcommand.CommandTimeout = 20000
                    Dim sr As New SqlDataAdapter(sqlcommand)
                    sr.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("Data Layer getSQLTable() ##" + ex.Message.ToString())
        End Try
        Return dt
    End Function
    Public Function bulkSave(ByVal obj As DataGridView, _
                             ByVal currentstatus As Integer, ByVal reportIDKey As String, ByVal pstruser As String, Optional ByVal pblnUpdate As Boolean = False) As Boolean
        Dim ans As Boolean = False
        Dim sb As New System.Text.StringBuilder
        Dim transaction As SqlTransaction = Nothing
        Dim strOut As String = String.Empty
        Dim prompt As Boolean = False
        Dim sequence As Integer = 0
        Dim paramName As String = String.Empty
        Dim dataType As String = String.Empty
        Dim dbField As String = String.Empty
        Dim value As String = String.Empty
        Dim defaultOperator As String = String.Empty
        Dim defaultValue1 As String = String.Empty
        Dim defaultValue2 As String = String.Empty
        Dim intActive As Integer = 1
        Dim intDeleted As Integer = 0
        Dim intRequired As Boolean = False
        Dim OutStatus As String = String.Empty
        Dim hasNext As Boolean = False
        Dim dt As New DataTable
        Try
            Using sqlconnection As New SqlConnection(connectionString)
                If sqlconnection.State = ConnectionState.Closed Then
                    sqlconnection.Open()
                End If
                Using sqlcommand As New SqlCommand()
                    sqlcommand.Connection = sqlconnection
                    transaction = sqlcommand.Connection.BeginTransaction
                    sqlcommand.Transaction = transaction
                    sqlcommand.CommandTimeout = 0
                    sqlcommand.CommandType = CommandType.StoredProcedure
                    dt.Columns.Add("Name")
                    dt.Columns.Add("ReportIDKey")
                    dt.Columns.Add("PromptText")
                    dt.Columns.Add("Sequence")
                    dt.Columns.Add("DataType")
                    dt.Columns.Add("DbField")
                    dt.Columns.Add("isRequired")
                    dt.Columns.Add("DefaultOperator")
                    dt.Columns.Add("DefaultValue1")
                    dt.Columns.Add("DefaultValue2")
                    dt.Columns.Add("isActive")
                    dt.Columns.Add("isDeleted")
                    dt.Columns.Add("CreatedBy")
                    dt.Columns.Add("CreatedDate")
                    dt.Columns.Add("ModifiedBy")
                    dt.Columns.Add("ModifiedDate")
                    For r As Integer = 0 To obj.Rows.Count - 1
                        For c As Integer = 0 To obj.Columns.Count - 1
                            If Not obj.Rows(r).Cells(c).Value Is Nothing Then
                                If Not String.IsNullOrEmpty(obj.Rows(r).Cells(c).Value.ToString()) Then
                                    hasNext = True
                                    paramName = obj.Rows(r).Cells(0).Value.ToString()
                                    If Not String.IsNullOrEmpty(obj.Rows(r).Cells(1).Value) Then
                                        prompt = CType(obj.Rows(r).Cells(1).EditedFormattedValue, Boolean)
                                    End If
                                    If Not String.IsNullOrEmpty(obj.Rows(r).Cells(2).Value) Then
                                        sequence = obj.Rows(r).Cells(2).Value.ToString()
                                    End If
                                    If Not String.IsNullOrEmpty(obj.Rows(r).Cells(3).Value) Then
                                        dataType = obj.Rows(r).Cells(3).Value.ToString()
                                    End If
                                    If Not String.IsNullOrEmpty(obj.Rows(r).Cells(5).Value) Then
                                        defaultOperator = obj.Rows(r).Cells(5).Value.ToString()
                                    End If
                                    If Not String.IsNullOrEmpty(obj.Rows(r).Cells(5).Value) Then
                                        defaultValue1 = obj.Rows(r).Cells(5).Value.ToString()
                                    End If
                                    If Not String.IsNullOrEmpty(obj.Rows(r).Cells(7).Value) Then
                                        defaultValue1 = obj.Rows(r).Cells(7).Value.ToString()
                                    End If
                                    If Not String.IsNullOrEmpty(obj.Rows(r).Cells(7).Value) Then
                                        intRequired = CType(obj.Rows(r).Cells(7).EditedFormattedValue, Boolean)
                                    End If
                                End If
                            End If
                            Exit For
                        Next
                        If hasNext And paramName.Trim().Length <> 0 Then
                            If pblnUpdate Then
                                dt.Rows.Add(paramName, reportIDKey, prompt, sequence, dataType, dbField, intRequired, defaultOperator, defaultValue1, defaultValue2, 1, 0, pstruser, Date.Now.ToString("MM/dd/yyyy"), pstruser, Nothing)

                            Else
                                dt.Rows.Add(paramName, reportIDKey, prompt, sequence, dataType, dbField, intRequired, defaultOperator, defaultValue1, defaultValue2, 1, 0, pstruser, Date.Now.ToString("MM/dd/yyyy"), "", Nothing)
                            End If
                             paramName = String.Empty
                            sequence = 0
                            dataType = String.Empty
                            intRequired = 0
                            dbField = String.Empty
                            defaultOperator = String.Empty
                            defaultValue1 = String.Empty
                            defaultValue2 = String.Empty
                            hasNext = False
                        End If
                    Next
                    sqlcommand.Parameters.Add(New SqlParameter("@ReportIDKey", Convert.ToInt32(reportIDKey)))
                    If pblnUpdate Then
                        sqlcommand.Parameters.Add(New SqlParameter("@update", 2))
                    Else
                        sqlcommand.Parameters.Add(New SqlParameter("@update", 1))
                    End If
                    sqlcommand.Parameters.Add(New SqlParameter("@OutStatus", ""))
                    sqlcommand.Parameters.Add(New SqlParameter("@ReportParameter1", dt))
                    sqlcommand.Parameters("@OutStatus").Direction = ParameterDirection.Output
                    sqlcommand.Parameters("@OutStatus").Size = 10
                    sqlcommand.CommandText = "uspReports_IUParamterNew"
                    Dim success As Integer = sqlcommand.ExecuteNonQuery()
                    strOut = sqlcommand.Parameters("@outStatus").Value
                    sqlcommand.Parameters.Clear()
                    transaction.Commit()
                End Using
            End Using
        Catch ex As Exception
            ErrorLog("Data Layer bulkSave() ##" + ex.Message.ToString())
        End Try
        Return True
    End Function

#End Region

#Region "Encryption"

    Public Shared Function EncodedPassword(ByVal TextPassword As String) As String
        Dim encode As String, tmpval As Integer, tmpEncoded As String = String.Empty, i As Integer
        Try
            encode = "135279054658794563158796412654898743148789156489845435488741232524265"
            For i = 1 To Len(TextPassword)
                tmpval = Asc(Mid(TextPassword, i, 1))
                tmpval = tmpval + Val(Mid(encode, i, 1))
                tmpEncoded = tmpEncoded & Trim(Str(tmpval)) & "|"
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        EncodedPassword = tmpEncoded
    End Function
    Public Shared Function DecodedPassword(ByVal EncodedPassword As String) As String
        Dim encode As String, tmpval As Integer, i As Integer
        Dim tmpPassword As String, tmpDecoded As String = String.Empty
        Dim tmpString As String
        Try
            encode = "135279054658794563158796412654898743148789156489845435488741232524265"

            tmpPassword = EncodedPassword
            If Trim(tmpPassword) <> "" Then
                Do
                    If tmpPassword = "" Then Exit Do
                    tmpString = ParseStr(tmpPassword, "|")
                    i = i + 1
                    tmpval = Val(tmpString)
                    tmpval = tmpval - Val(Mid(encode, i, 1))
                    tmpDecoded = tmpDecoded & Chr(tmpval)
                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DecodedPassword = tmpDecoded
    End Function
    Public Shared Function ParseStr$(ByRef X$, ByVal sep As String)
        Dim Y%
        Dim ret%
        Try
            If sep = "" Then sep = " "
            X$ = Trim(X$)
            Y% = InStr(X$ & sep, sep)
            If Y% Then
                ret% = Left$(X$, Y% - 1)
                X$ = Mid$(X$, Y% + Len(sep))
            Else
                ret% = ""
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ParseStr$ = ret%
    End Function
    Public Shared Function Encrypt(ByVal toEncrypt As String, ByVal key As String, ByVal useHashing As Boolean) As String
        Dim keyArray As Byte()
        Dim toEncryptArray As Byte() = UTF8Encoding.UTF8.GetBytes(toEncrypt)

        If useHashing = True Then
            Dim hashmd5 As New MD5CryptoServiceProvider()
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))
        Else
            keyArray = UTF8Encoding.UTF8.GetBytes(key)
        End If

        Dim tdes As New TripleDESCryptoServiceProvider()
        tdes.Key = keyArray
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.PKCS7

        Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)

        Return (Convert.ToBase64String(resultArray, 0, resultArray.Length))
    End Function
    Public Shared Function Decrypt(ByVal toDecrypt As String, ByVal key As String, ByVal useHashing As Boolean) As String
        Dim keyArray As Byte()
        Dim toEncryptArray As Byte() = Convert.FromBase64String(toDecrypt)

        If useHashing = True Then
            Dim hashmd5 As New MD5CryptoServiceProvider()
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key))
        Else
            keyArray = UTF8Encoding.UTF8.GetBytes(key)
        End If

        Dim tdes As New TripleDESCryptoServiceProvider()
        tdes.Key = keyArray
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.PKCS7

        Dim cTransform As ICryptoTransform = tdes.CreateDecryptor()
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)

        Return UTF8Encoding.UTF8.GetString(resultArray)
    End Function

#End Region

#Region "General Functions"

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
    Public Sub EndApplication()
        Application.Exit()
        Application.ExitThread()
    End Sub
    Public Sub ProcessDirectory(ByVal targetDirectory As String, ByVal parentNode As TreeNode, Optional ByVal isCategory As Boolean = False)
        Dim folder As String = String.Empty
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        Dim subdirectory As String
        Dim folderNode As TreeNode = Nothing
        For Each subdirectory In subdirectoryEntries
            folder = IO.Path.GetFileName(subdirectory)
            folderNode = parentNode.Nodes.Add(folder)
            folderNode.Tag = subdirectory
            If isCategory Then
                Dim fileEntries As String() = Directory.GetFiles(subdirectory)
                Dim fileName As String
                For Each fileName In fileEntries
                    ProcessFile(fileName, folderNode)
                Next fileName
                ProcessDirectory(subdirectory, folderNode)
            End If
        Next subdirectory
    End Sub
    Public Shared Sub ProcessFile(ByVal path As String, ByVal parentNode As TreeNode)
        parentNode.Nodes.Add(IO.Path.GetFileName(path))
    End Sub
    Public Sub ProcessCategoryDirectory(ByVal targetDirectory As String, ByVal parentNode As TreeNode)
        Dim folder As String = String.Empty

        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        Dim subdirectory As String
        Dim folderNode As TreeNode = Nothing
        For Each subdirectory In subdirectoryEntries
            folder = IO.Path.GetFileName(subdirectory)
            folderNode = parentNode.Nodes.Add(folder)
            folderNode.Name = subdirectory
            folderNode.Tag = subdirectory
            Dim fileEntries As String() = Directory.GetFiles(subdirectory)
            Dim fileName As String
            For Each fileName In fileEntries
                ProcessFile(fileName, folderNode)
            Next fileName
            ProcessCategoryDirectory(subdirectory, folderNode)
        Next subdirectory
    End Sub
    Public Function AppInit() As String
        'Dim isConnected As Boolean = False
        Dim msg As String = ""
        Try
            'Dim Path As String = IIf(xArchitecture, x86PFilePath, PFilePath & "\" & AppFolderName) & "\"
            'chg102015ly change all path statements to use only AppFolderName
            Dim Path As String = AppPath & "\"
            Dim directoryPath As String, filePath As String
            directoryPath = Dir(Path)
            filePath = Dir(Path & IniAppFile)
            If directoryPath = "" Then
                msg = "Invalid installation path. " & Path & "  Please contact Excel Software Services for assistance."
            End If
            If filePath = "" Then
                msg = "Missing excelss configuration file. " & filePath & " Please contact Excel Software Services for assistance."
            End If
            If Not IO.Directory.Exists(Path) Then
                msg = "Missing company file at " & Path & " Please contact Excel Software Services for assistance."
            End If
            'isConnected = ConnectDataBaseAsperRegistry()
            'If Not isConnected Then
            '    msg = "Database Connection Error. Please contact Excel Software Services for assistance."
            'End If
        Catch ex As Exception
            Return False
        End Try
        Return msg
    End Function

#End Region

End Class

Public Class ReportingServerData : Inherits Main
    Public Shared reportconnection As String = String.Empty
    Public Sub New()
        Try
            reportconnection = "Initial Catalog=" & ReportServer.ReportServerDatabase & ";User ID=" & dbuserid
            reportconnection += ";pwd=" & DecodedPassword(password)
            reportconnection += ";Data Source="
            reportconnection += servername & ";"
            If reportconnection <> "" Then
                Using sqlconnection As New SqlConnection(reportconnection)
                    If sqlconnection.State = ConnectionState.Closed Then
                        sqlconnection.Open()
                    End If
                    Debug.Print("Success")
                    sqlconnection.Close()
                End Using
            End If
        Catch ex As Exception
            ErrorLog("ReportingServerData New() ##" + ex.Message.ToString())
        End Try
    End Sub

End Class
