'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Text

Public Class frmChecker

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f = OpenFileDialog1.ShowDialog()
        If f = DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IO.File.Exists(TextBox1.Text) Then
            TextBox2.Text = MD5File(TextBox1.Text)
            TextBox3.Text = SHA512File(TextBox1.Text)
            TextBox4.Text = SHA1File(TextBox1.Text)
            TextBox5.Text = SHA256File(TextBox1.Text)
            TextBox6.Text = SHA384File(TextBox1.Text)
            TextBox7.Text = Crc32File(TextBox1.Text)
        Else
            TextBox2.Text = MD5Str(TextBox1.Text)
            TextBox3.Text = SHA512Str(TextBox1.Text)
            TextBox4.Text = SHA1Str(TextBox1.Text)
            TextBox5.Text = SHA256Str(TextBox1.Text)
            TextBox6.Text = SHA384Str(TextBox1.Text)
            TextBox7.Text = Crc32Str(TextBox1.Text)
        End If
    End Sub

    Function MD5File(ByVal addr As String) As String
        Dim md5service As New Security.Cryptography.MD5CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In md5service.ComputeHash(IO.File.ReadAllBytes(addr))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA1File(ByVal addr As String) As String
        Dim sha1service As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha1service.ComputeHash(IO.File.ReadAllBytes(addr))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA256File(ByVal addr As String) As String
        Dim sha256service As New Security.Cryptography.SHA256CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha256service.ComputeHash(IO.File.ReadAllBytes(addr))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA384File(ByVal addr As String) As String
        Dim sha348service As New Security.Cryptography.SHA384CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha348service.ComputeHash(IO.File.ReadAllBytes(addr))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

    Function SHA512File(ByVal addr As String) As String
        Dim sha512service As New Security.Cryptography.SHA512CryptoServiceProvider
        Dim sb As New StringBuilder
        For Each bytex In sha512service.ComputeHash(IO.File.ReadAllBytes(addr))
            sb.Append(bytex.ToString("x2"))
        Next
        Return sb.ToString
    End Function

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

    Function Crc32File(ByVal addr As String) As String
        Return Crc32.ComputeChecksum(IO.File.ReadAllBytes(addr))
    End Function

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

    Private Sub _KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

End Class