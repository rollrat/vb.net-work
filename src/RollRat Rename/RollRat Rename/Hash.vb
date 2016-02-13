'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Text

Module Hash

    Public Class Crc32
        Shared table As UInteger()

        Shared Sub New()
            Dim poly As UInteger = &HEDB88320UI
            table = New UInteger(255) {}
            Dim temp As UInteger = 0
            For i As UInteger = 0 To table.Length - 1
                temp = i
                For j As Integer = 8 To 1 Step -1
                    If (temp And 1) = 1 Then
                        temp = CUInt((temp >> 1) Xor poly)
                    Else
                        temp >>= 1
                    End If
                Next
                table(i) = temp
            Next
        End Sub

        Public Shared Function ComputeChecksum(bytes As Byte()) As UInteger
            Dim crc As UInteger = &HFFFFFFFFUI
            For i As Integer = 0 To bytes.Length - 1
                Dim index As Byte = CByte(((crc) And &HFF) Xor bytes(i))
                crc = CUInt((crc >> 8) Xor table(index))
            Next
            Return Not crc
        End Function
    End Class

    Function MD5Str(ByVal str As String) As String
        Dim md5service As New Security.Cryptography.MD5CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In md5service.ComputeHash(Encoding.ASCII.GetBytes(str))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA1Str(ByVal str As String) As String
        Dim sha1service As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha1service.ComputeHash(Encoding.ASCII.GetBytes(str))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA256Str(ByVal str As String) As String
        Dim sha256service As New Security.Cryptography.SHA256CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha256service.ComputeHash(Encoding.ASCII.GetBytes(str))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA384Str(ByVal str As String) As String
        Dim sha348service As New Security.Cryptography.SHA384CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha348service.ComputeHash(Encoding.ASCII.GetBytes(str))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA512Str(ByVal str As String) As String
        Dim sha512service As New Security.Cryptography.SHA512CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha512service.ComputeHash(Encoding.ASCII.GetBytes(str))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function Crc32Str(ByVal str As String) As String
        Return Crc32.ComputeChecksum(Encoding.ASCII.GetBytes(str))
    End Function

    '
    '   Encryption/Decryption
    '
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
            MsgBox("문자열 암호화 중 오류가 발생하여 프로그램을 종료해야 합니다." & vbCrLf & _
                   "입력: " & input & vbCrLf & _
                   "암호: " & pass & vbCrLf & _
                   "자세한 사항은 제작자에게 문의하십시오.", MsgBoxStyle.Critical, "RollRat Rename")
            End
        End Try
    End Function

    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            MsgBox("문자열 복호화 중 오류가 발생하여 프로그램을 종료해야 합니다." & vbCrLf & _
                   "입력: " & input & vbCrLf & _
                   "암호: " & pass & vbCrLf & _
                   "자세한 사항은 제작자에게 문의하십시오.", MsgBoxStyle.Critical, "RollRat Rename")
            End
        End Try
    End Function

End Module
