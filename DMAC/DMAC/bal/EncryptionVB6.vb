Module EncryptionVB6
    Public Function EncodedPassword(ByVal TextPassword As String) As String
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

    Public Function DecodedPassword(ByVal EncodedPassword As String) As String
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
    Public Function ParseStr$(ByRef X$, ByVal sep As String)
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
End Module
