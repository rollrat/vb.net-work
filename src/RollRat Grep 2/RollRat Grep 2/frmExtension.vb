'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmExtension

    Dim indexptr As Integer = 0

    Private Sub frmExtension_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmExtension_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reload()
    End Sub

    Private Sub reload()
        Dim strexarr As String() = My.Settings.Extension.Split("|"c)
        Dim index As Integer = 1
        ListView1.Items.Clear()
        For Each x In strexarr
            Dim strArray = New String() {index, x}
            Dim lvt = New ListViewItem(strArray)
            ListView1.Items.Add(lvt)
            index += 1
        Next
        indexptr = index
    End Sub

    Private Sub save()
        Dim strexarr(ListView1.Items.Count) As String
        For i As Integer = 0 To ListView1.Items.Count - 1
            strexarr(i) = ListView1.Items.Item(i).SubItems(1).Text
        Next
        Dim strex As String = ""
        Dim tx As Integer = strexarr.Length
        For i As Integer = 0 To ListView1.Items.Count - 1
            strex += strexarr(i)
            If Not (i = ListView1.Items.Count - 1) Then
                strex += "|"
            End If
        Next
        My.Settings.Extension = strex
        My.Settings.Save()
        frmMain.ParseExtension(My.Settings.Extension)
        reload()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        save()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            For Each i As ListViewItem In ListView1.SelectedItems
                ListView1.Items.Remove(i)
                indexptr -= 1
            Next
        End If
    End Sub

    Public Shared Function parse_argument(ByVal args As String) As List(Of String)
        Dim strr As New List(Of String)
        Dim i As Integer = 0
        While i < args.Length
            If args(i) = """" Then
                Dim tmpstr As String = ""
                i += 1
                While args(i) <> """"
                    tmpstr += args(i)
                    i += 1
                    If i >= args.Length Then
                        MsgBox(tmpstr & "이 ""로 닫히지 않았습니다.", MsgBoxStyle.Critical)
                        Exit While
                    End If
                End While
                strr.Add(tmpstr)
                i += 1
            ElseIf args(i) <> " " Then
                Dim tmpstr As String = ""
                While args(i) <> " "
                    tmpstr += args(i)
                    i += 1
                    If i >= args.Length Then
                        Exit While
                    End If
                End While
                strr.Add(tmpstr)
                i += 1
            ElseIf args(i) = " " Then
                i += 1
            End If
        End While
        Return strr
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '
        '   정식확장자 확인
        '
        If Not TextBox1.Text.StartsWith(".") Then
            MsgBox(".을 포함한 확장자를 입력해주십시오.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        '
        '   금지문자 확인
        '
        Dim notallow As String = "\/:*?""<>|"
        For i As Integer = 0 To notallow.Length - 1
            If TextBox1.Text.Contains(notallow(i)) Then
                MsgBox("\/:*?""<>|와 같은 문자를 사용할 수 없습니다.", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Next

        '
        '   중복확인
        '
        Dim strexarr As String() = My.Settings.Extension.Split("|"c)
        If strexarr.Contains(TextBox1.Text) Then
            MsgBox("해당 확장자는 이미 포함되어있습니다.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim strArray = New String() {indexptr, TextBox1.Text}
        Dim lvt = New ListViewItem(strArray)
        ListView1.Items.Add(lvt)
        indexptr += 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.Extension = ".txt|.c|.cpp|.h|.hpp|.vb|.xml|.log|.html|.java|.php|.cs|.s|.asm|.htm|.pas|.rtf|.python"
        My.Settings.Save()
        MsgBox("설정 저장을 위해 프로그램을 재시작하시기 바랍니다.", MsgBoxStyle.Exclamation)
        reload()
    End Sub

End Class