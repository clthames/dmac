Module modGeneral

    Public x86PFilePath As String = Environment.GetEnvironmentVariable("ProgramFiles(x86)")
    Public PFilePath As String = Environment.GetEnvironmentVariable("ProgramFiles")
    Public xArchitecture As Boolean = IIf(Not String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432")), True, False)

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

End Module
