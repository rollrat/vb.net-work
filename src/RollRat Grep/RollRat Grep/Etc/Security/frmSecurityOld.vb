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

Public Class frmSecurityOld

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f = OpenFileDialog1.ShowDialog()
        If f = DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f = SaveFileDialog1.ShowDialog()
        If f = DialogResult.OK Then
            TextBox2.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f = OpenFileDialog2.ShowDialog()
        If f = DialogResult.OK Then
            TextBox3.Text = OpenFileDialog2.FileName
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked Then
            TabControl1.SelectedIndex = 1
            Button3.Enabled = True
        Else
            TabControl1.SelectedIndex = 0
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Using rsa As New Security.Cryptography.RSACryptoServiceProvider
            TextBox4.Text = rsa.ToXmlString(False)
            TextBox5.Text = rsa.ToXmlString(True)
        End Using
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim key() As Byte

        If RadioButton6.Checked Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                Exit Sub
            End If
            If TextBox4.Text = "" Then
                MsgBox("RSA 키 쌍을 만드십시오.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Try
                Dim rsa As New System.Security.Cryptography.RSACryptoServiceProvider
                rsa.FromXmlString(TextBox4.Text)
                Using _rsa = New System.Security.Cryptography.RSACryptoServiceProvider
                    _rsa.ImportParameters(rsa.ExportParameters(False))
                    key = _rsa.Encrypt((New System.Text.UnicodeEncoding()).GetBytes(TextBox3.Text), False)
                End Using
                IO.File.WriteAllBytes(TextBox2.Text & ".key", key)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try
            Button4.Enabled = False
        Else
            If RadioButton1.Checked Then
                key = MD5Str(TextBox3.Text)
            ElseIf RadioButton2.Checked Then
                key = SHA1Str(TextBox3.Text)
            ElseIf RadioButton3.Checked Then
                key = SHA256Str(TextBox3.Text)
            ElseIf RadioButton4.Checked Then
                key = SHA384Str(TextBox3.Text)
            ElseIf RadioButton5.Checked Then
                key = SHA512Str(TextBox3.Text)
            Else
                key = SHA512Str(TextBox3.Text)
            End If
        End If

        If RadioButton8.Checked = False Then
            Try
                File.WriteAllBytes(TextBox2.Text, AES_Encrypt128(File.ReadAllBytes(TextBox1.Text), key))
                MsgBox("암호화를 완료하였습니다.", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim key() As Byte

        If RadioButton6.Checked Then
            key = File.ReadAllBytes(TextBox3.Text)
        Else
            If RadioButton1.Checked Then
                key = MD5Str(TextBox3.Text)
            ElseIf RadioButton2.Checked Then
                key = SHA1Str(TextBox3.Text)
            ElseIf RadioButton3.Checked Then
                key = SHA256Str(TextBox3.Text)
            ElseIf RadioButton4.Checked Then
                key = SHA384Str(TextBox3.Text)
            ElseIf RadioButton5.Checked Then
                key = SHA512Str(TextBox3.Text)
            Else
                key = SHA512Str(TextBox3.Text)
            End If
        End If

        If RadioButton8.Checked = False Then
            Try
                File.WriteAllBytes(TextBox2.Text, AES_Decrypt128(File.ReadAllBytes(TextBox1.Text), key))
                MsgBox("복호화를 완료하였습니다.", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Function MD5Str(ByVal str As String) As Byte()
        Dim md5service As New Security.Cryptography.MD5CryptoServiceProvider
        Dim sb As New StringBuilder
        Return md5service.ComputeHash(Encoding.ASCII.GetBytes(str))
    End Function

    Function SHA1Str(ByVal str As String) As Byte()
        Dim sha1service As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim sb As New StringBuilder
        Return sha1service.ComputeHash(Encoding.ASCII.GetBytes(str))
    End Function

    Function SHA256Str(ByVal str As String) As Byte()
        Dim sha256service As New Security.Cryptography.SHA256CryptoServiceProvider
        Dim sb As New StringBuilder
        Return sha256service.ComputeHash(Encoding.ASCII.GetBytes(str))
    End Function

    Function SHA384Str(ByVal str As String) As Byte()
        Dim sha348service As New Security.Cryptography.SHA384CryptoServiceProvider
        Dim sb As New StringBuilder
        Return sha348service.ComputeHash(Encoding.ASCII.GetBytes(str))
    End Function

    Function SHA512Str(ByVal str As String) As Byte()
        Dim sha512service As New Security.Cryptography.SHA512CryptoServiceProvider
        Dim sb As New StringBuilder
        Return sha512service.ComputeHash(Encoding.ASCII.GetBytes(str))
    End Function

    'Public Shared Function AES_Enc_256(ByVal Text As String, _
    '                                   Optional ByVal salt As String = "RollratSoftwarePrograms", _
    '                                   Optional ByVal InitialVector As String = "rollratwqw][;'/.")
    '    Dim HashAlgorithm As String = "SHA1"
    '    Dim PasswordIterations As String = 2
    '    Dim KeySize As Integer = 256

    '    If (String.IsNullOrEmpty(Text)) Then
    '        Return 0
    '    End If
    '    Dim InitialVectorBytes As Byte() = Encoding.ASCII.GetBytes(InitialVector)
    '    Dim SaltValueBytes As Byte() = Encoding.ASCII.GetBytes(salt)
    '    Dim PlainTextBytes As Byte() = Encoding.UTF8.GetBytes(Text)
    '    Dim DerivedPassword As PasswordDeriveBytes = New PasswordDeriveBytes(Basically_Code, SaltValueBytes, HashAlgorithm, PasswordIterations)
    '    Dim KeyBytes As Byte() = DerivedPassword.GetBytes(KeySize / 8)
    '    Dim SymmetricKey As RijndaelManaged = New RijndaelManaged()
    '    SymmetricKey.Mode = CipherMode.CBC

    '    Dim CipherTextBytes As Byte() = Nothing
    '    Using Encryptor As ICryptoTransform = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes)
    '        Using MemStream As New MemoryStream()
    '            Using CryptoStream As New CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write)
    '                CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length)
    '                CryptoStream.FlushFinalBlock()
    '                CipherTextBytes = MemStream.ToArray()
    '                MemStream.Close()
    '                CryptoStream.Close()
    '            End Using
    '        End Using
    '    End Using
    '    SymmetricKey.Clear()
    '    Return Convert.ToBase64String(CipherTextBytes)
    'End Function

    'Public Shared Function AES_Dec_256(ByVal text As String, _
    '                                   Optional ByVal salt As String = "RollratSoftwarePrograms", _
    '                                   Optional ByVal InitialVector As String = "rollratwqw][;'/.")
    '    Dim HashAlgorithm As String = "SHA1"
    '    Dim PasswordIterations As String = 2
    '    Dim KeySize As Integer = 256

    '    Dim InitialVectorBytes As Byte() = Encoding.ASCII.GetBytes(InitialVector)
    '    Dim SaltValueBytes As Byte() = Encoding.ASCII.GetBytes(salt)
    '    Dim CipherTextBytes As Byte() = Convert.FromBase64String(text)
    '    Dim DerivedPassword As PasswordDeriveBytes = New PasswordDeriveBytes(Basically_Code, SaltValueBytes, HashAlgorithm, PasswordIterations)
    '    Dim KeyBytes As Byte() = DerivedPassword.GetBytes(KeySize / 8)
    '    Dim SymmetricKey As RijndaelManaged = New RijndaelManaged()
    '    SymmetricKey.Mode = CipherMode.CBC
    '    Dim PlainTextBytes As Byte() = New Byte(CipherTextBytes.Length - 1) {}

    '    Dim ByteCount As Integer = 0

    '    Using Decryptor As ICryptoTransform = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes)
    '        Using MemStream As MemoryStream = New MemoryStream(CipherTextBytes)
    '            Using CryptoStream As CryptoStream = New CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read)
    '                ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length)
    '                MemStream.Close()
    '                CryptoStream.Close()
    '            End Using
    '        End Using
    '    End Using
    '    SymmetricKey.Clear()
    '    Return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount)
    'End Function

    'Public Shared Function AES_256_GenerateHash(ByVal Str As String) As String
    '    Dim StringIncode As New System.Text.UnicodeEncoding
    '    Dim HashByt() As Byte = New System.Security.Cryptography.SHA512Managed().ComputeHash(StringIncode.GetBytes(Str))
    '    Dim i As Long
    '    Dim ReturnText As String = ""
    '    Dim tmp As String
    '    For i = 0 To UBound(HashByt)
    '        tmp = Hex$(HashByt(i))
    '        If Len(tmp) = 1 Then tmp = "0" & tmp
    '        ReturnText &= tmp
    '    Next
    '    Return ReturnText
    'End Function

    Public Function AES_Encrypt128(ByVal input As Byte(), ByVal pass As Byte()) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        ' Try
        Dim hash(31) As Byte
        Dim temp As Byte() = Hash_AES.ComputeHash(pass)
        'Array.Copy(temp, 0, hash, 0, 16)
        'Array.Copy(temp, 0, hash, 15, 16)
        'AES.Key = hash
        AES.Key = temp
        AES.Mode = Security.Cryptography.CipherMode.ECB
        Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
        Return DESEncrypter.TransformFinalBlock(input, 0, input.Length)
        'Catch ex As Exception
        '    Dim dummyBA(0) As Byte
        '    MsgBox("Error 1", MsgBoxStyle.Critical)
        '    Return dummyBA
        'End Try
    End Function

    Public Function AES_Decrypt128(ByVal input As Byte(), ByVal pass As Byte()) As Byte()
        Dim AES As New System.Security.Cryptography.RijndaelManaged

        ' MD5해쉬 생성
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        'Try
        Dim hash(31) As Byte
        Dim temp As Byte() = Hash_AES.ComputeHash(pass)
        'Array.Copy(temp, 0, hash, 0, 16)
        'Array.Copy(temp, 0, hash, 15, 16)
        'AES.Key = hash
        AES.Key = temp
        AES.Mode = Security.Cryptography.CipherMode.ECB
        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
        Return DESDecrypter.TransformFinalBlock(input, 0, input.Length)
        'Catch ex As Exception
        '   Dim dummyBA(0) As Byte
        '   MsgBox("Error 2", MsgBoxStyle.Critical)
        '   Return dummyBA
        'End Try
    End Function

    Public Sub AES_Encrypt256(ByVal input As Byte(), ByVal pass As Byte())
        Dim roundtrip As String
        Dim textConverter As New ASCIIEncoding()
        Dim myRijndael As New RijndaelManaged()
        Dim fromEncrypt() As Byte
        Dim encrypted() As Byte
        Dim key() As Byte
        Dim IV() As Byte

        'Create a new key and initialization vector.
        'myRijndael.GenerateKey()
        'myRijndael.GenerateIV()

        myRijndael.Mode = CipherMode.CFB
        myRijndael.BlockSize = 128
        myRijndael.KeySize = 256
        myRijndael.Key = StringToByteArray("603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4")
        myRijndael.IV = StringToByteArray("000102030405060708090A0B0C0D0E0F")


        'Get the key and IV.
        key = myRijndael.Key
        IV = myRijndael.IV

        'Get an encryptor.
        Dim encryptor As ICryptoTransform = myRijndael.CreateEncryptor(key, IV)

        'Encrypt the data.
        Dim msEncrypt As New MemoryStream()
        Dim csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)

        'Convert the data to a byte array.=

        'Write all data to the crypto stream and flush it.
        csEncrypt.Write(input, 0, input.Length)
        csEncrypt.FlushFinalBlock()

        'Get encrypted array of bytes.
        encrypted = msEncrypt.ToArray()

        'This is where the message would be transmitted to a recipient
        ' who already knows your secret key. Optionally, you can
        ' also encrypt your secret key using a public key algorithm
        ' and pass it to the mesage recipient along with the RijnDael
        ' encrypted message.            
        'Get a decryptor that uses the same key and IV as the encryptor.
        Dim decryptor As ICryptoTransform = myRijndael.CreateDecryptor(key, IV)

        'Now decrypt the previously encrypted message using the decryptor
        ' obtained in the above step.
        Dim msDecrypt As New MemoryStream(encrypted)
        Dim csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

        fromEncrypt = New Byte(encrypted.Length) {}

        'Read the data out of the crypto stream.
        csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length)

        'Convert the byte array back into a string.
        roundtrip = textConverter.GetString(fromEncrypt)

    End Sub

    Public Function StringToByteArray(ByVal hex As [String]) As Byte()
        Dim NumberChars As Integer = hex.Length
        Dim bytes As Byte() = New Byte(NumberChars \ 2 - 1) {}
        For i As Integer = 0 To NumberChars - 1 Step 2
            bytes(i \ 2) = Convert.ToByte(hex.Substring(i, 2), 16)
        Next
        Return bytes
    End Function

End Class