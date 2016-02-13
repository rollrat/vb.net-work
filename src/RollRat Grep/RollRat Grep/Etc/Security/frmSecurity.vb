'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Text
Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography

Public Class frmSecurity

    Dim s1 As String = ""
    Dim s2 As String = ""

    Function CompactString(ByVal MyString As String, ByVal Width As Integer,
                    ByVal Font As Drawing.Font,
                    ByVal FormatFlags As TextFormatFlags) As String

        Dim Result As String = String.Copy(MyString)

        TextRenderer.MeasureText(Result, Font, New Drawing.Size(Width, 0),
            FormatFlags Or TextFormatFlags.ModifyString)

        Return Result

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f = OpenFileDialog1.ShowDialog()
        If f = DialogResult.OK Then
            TextBox1.Text = CompactString(OpenFileDialog1.FileName, _
                        TextBox1.Width, TextBox1.Font, TextFormatFlags.PathEllipsis)
            s1 = OpenFileDialog1.FileName
        End If

        '
        '   확장자가 .fsm이라면 99%확률로 이 프로그램으로 암호화된 파일이므로 복호화를 준비하게함
        '
        If s1.EndsWith(".fsm") Then
            s2 = OpenFileDialog1.FileName.Remove( _
                        OpenFileDialog1.FileName.Length - ".fsm".Length, ".fsm".Length)
            TextBox2.Text = CompactString(s2, _
                        TextBox2.Width, TextBox2.Font, TextFormatFlags.PathEllipsis)
        Else
            s2 = OpenFileDialog1.FileName & ".fsm"
            TextBox2.Text = CompactString(s2, _
                        TextBox2.Width, TextBox2.Font, TextFormatFlags.PathEllipsis)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.FileName = TextBox2.Text
        Dim f = SaveFileDialog1.ShowDialog()
        If f = DialogResult.OK Then
            TextBox2.Text = CompactString(SaveFileDialog1.FileName, _
                        TextBox2.Width, TextBox2.Font, TextFormatFlags.PathEllipsis)
            s2 = TextBox1.Text
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim key() As Byte

        If TextBox3.Text = "" Then
            MsgBox("암호는 적어도 한 글자 이상이여야합니다.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        key = SHA512Str(TextBox3.Text)
        Try
            AES_EncryptFromToFile(s1, s2, key)
            MsgBox("암호화를 완료하였습니다.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim key() As Byte
        key = SHA512Str(TextBox3.Text)
        Try
            AES_DecryptFromToFile(s1, s2, key)
            MsgBox("복호화를 완료하였습니다.", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Function SHA512Str(ByVal str As String) As Byte()
        Dim sha512service As New Security.Cryptography.SHA512CryptoServiceProvider
        Dim sb As New StringBuilder
        Return sha512service.ComputeHash(Encoding.ASCII.GetBytes(str))
    End Function

    Private Sub AES_EncryptFromToFile(ByVal [from] As String, ByVal [to] As String, _
                                             ByVal pass As Byte())
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim hash(31) As Byte
        Dim iv(15) As Byte
        Array.Copy(pass, hash, 31)

        '
        '   키의 총 길이가 31이라 64bit인 SHA512값을 요리조리 섞어주어야 전부 사용할 수 있음
        '   안해도 상관없음
        '
        For i As Integer = 0 To 30
            hash(i) = hash(i) Xor pass(i + 31)
        Next
        hash(0) = hash(0) Xor pass(62)
        hash(30) = hash(30) Xor pass(63)

        '
        '   벡터초기화 부분
        '   RijndealManaged의 기본 벡터생성함수로 생성하면 복호화값이 다르게나옴
        '
        For i As Integer = 0 To 14
            iv(i) = pass(i + 15)
        Next
        AES.Key = hash
        AES.IV = iv

        '
        '   EBC: 어디 한 군데 손상되도 복호화가능
        '   CBC: 손상되면 복구 불능(뒷 부분이 손상되었으면 거의 복구가능)
        '
        AES.Mode = Security.Cryptography.CipherMode.CBC
        Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
        Dim fbuffer(4096) As Byte
        Dim fpIn As New FileStream([from], FileMode.Open, FileAccess.Read)
        Dim fpOut As New FileStream([to], FileMode.OpenOrCreate, FileAccess.Write)
        Dim fpCs As New CryptoStream(fpOut, DESEncrypter, CryptoStreamMode.Write)
        Dim ptrbuffer As UInteger = 0
        Dim procbuffer As Long = 0
        While procbuffer < fpIn.Length
            ptrbuffer = fpIn.Read(fbuffer, 0, 4096)
            fpCs.Write(fbuffer, 0, ptrbuffer)
            procbuffer += CLng(ptrbuffer)
            ProgressBar1.Value = CInt((procbuffer / fpIn.Length) * 100)
            Application.DoEvents()
        End While
        fpCs.Close()
        fpOut.Close()
        fpIn.Close()
    End Sub

    Public Sub AES_DecryptFromToFile(ByVal [from] As String, ByVal [to] As String, _
                                             ByVal pass As Byte())
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim hash(31) As Byte
        Dim iv(15) As Byte
        Array.Copy(pass, hash, 31)
        For i As Integer = 0 To 30
            hash(i) = hash(i) Xor pass(i + 31)
        Next
        hash(0) = hash(0) Xor pass(62)
        hash(30) = hash(30) Xor pass(63)
        For i As Integer = 0 To 14
            iv(i) = pass(i + 15)
        Next
        AES.Key = hash
        AES.IV = iv
        AES.Mode = Security.Cryptography.CipherMode.CBC
        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
        Dim fbuffer(4096) As Byte
        Dim fpIn As New FileStream([from], FileMode.Open, FileAccess.Read)
        Dim fpOut As New FileStream([to], FileMode.OpenOrCreate, FileAccess.Write)
        Dim fpCs As New CryptoStream(fpOut, DESDecrypter, CryptoStreamMode.Write)
        Dim ptrbuffer As UInteger = 0
        Dim procbuffer As UInteger = 0
        While procbuffer < fpIn.Length
            ptrbuffer = fpIn.Read(fbuffer, 0, 4096)
            fpCs.Write(fbuffer, 0, ptrbuffer)
            procbuffer += ptrbuffer
            ProgressBar1.Value = CInt((procbuffer / fpIn.Length) * 100)
            Application.DoEvents()
        End While
        fpCs.Close()
        fpOut.Close()
        fpIn.Close()
    End Sub

    Private Sub _KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Public Shared Function SHA512StrGlobal(ByVal str As String) As Byte()
        Dim sha512service As New Security.Cryptography.SHA512CryptoServiceProvider
        Dim sb As New StringBuilder
        Return sha512service.ComputeHash(Encoding.ASCII.GetBytes(str))
    End Function

    Public Shared Function AES_DecryptGlobal(ByVal [from] As String, ByVal [to] As String, ByVal password As String) As Boolean
        Dim key() As Byte
        key = SHA512StrGlobal(password)
        Try
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim hash(31) As Byte
            Dim iv(15) As Byte
            Array.Copy(key, hash, 31)
            For i As Integer = 0 To 30
                hash(i) = hash(i) Xor key(i + 31)
            Next
            hash(0) = hash(0) Xor key(62)
            hash(30) = hash(30) Xor key(63)
            For i As Integer = 0 To 14
                iv(i) = key(i + 15)
            Next
            AES.Key = hash
            AES.IV = iv
            AES.Mode = Security.Cryptography.CipherMode.CBC
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim fbuffer(4096) As Byte
            Dim fpIn As New FileStream([from], FileMode.Open, FileAccess.Read)
            Dim fpOut As New FileStream([to], FileMode.OpenOrCreate, FileAccess.Write)
            Dim fpCs As New CryptoStream(fpOut, DESDecrypter, CryptoStreamMode.Write)
            Dim ptrbuffer As UInteger = 0
            Dim procbuffer As UInteger = 0
            While procbuffer < fpIn.Length
                ptrbuffer = fpIn.Read(fbuffer, 0, 4096)
                fpCs.Write(fbuffer, 0, ptrbuffer)
                procbuffer += ptrbuffer
                'Application.DoEvents()
            End While
            fpCs.Close()
            fpOut.Close()
            fpIn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
        Return True
    End Function

End Class