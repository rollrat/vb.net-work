'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Module dxSecretService

    '
    '   수정금지
    '

    '
    '   VB.NET 헥스 변환
    '
    Public Function File2VbNetHex(ByVal addr As String) As String
        Dim ss As New System.Text.StringBuilder
        Dim bytes() As Byte = IO.File.ReadAllBytes(addr)
        Dim prefix As String = "&H"
        Dim deli As String = ", "
        Dim rate As Integer = 16
        Dim postfix As String = " _"
        Dim ratec As Integer = 0

        Dim variablename As String = "security_" & MD5Str(addr)

        ss.Append("'" & vbCrLf & "'" & vbTab & addr & vbCrLf & "'" & vbCrLf)
        ss.Append("Public " & variablename & "  As Byte() = { _" & vbCrLf & vbTab & vbTab)

        For Each arg As Byte In bytes
            If rate = ratec Then
                ratec = 0
                ss.Append(postfix & vbCrLf & vbTab & vbTab)
            End If
            ss.Append(prefix & arg.ToString("X") & deli)
            ratec += 1
        Next

        If ratec <> 1 Then
            ss.Remove(ss.Length - deli.Length, deli.Length)
        End If

        ss.Append("}")

        Return ss.ToString
    End Function

    Public Function MultiFile2VbNetHexWithModule(ByVal addrs As String()) As String
        Dim ss As New System.Text.StringBuilder

        ss.Append("Module mod_" & MD5Str(addrs(0)) & vbCrLf & vbCrLf)

        For Each addr As String In addrs
            ss.Append(File2VbNetHex(addr))
            ss.Append(vbCrLf & vbCrLf)
        Next

        ss.Append(vbCrLf & "End Module")

        Return ss.ToString
    End Function

    Function MD5Str(ByVal str As String) As String
        Dim md5service As New Security.Cryptography.MD5CryptoServiceProvider
        Dim sb As New System.Text.StringBuilder
        For Each bytex In md5service.ComputeHash(System.Text.Encoding.ASCII.GetBytes(str))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

End Module
