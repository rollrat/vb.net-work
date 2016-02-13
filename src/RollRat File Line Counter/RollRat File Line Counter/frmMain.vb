'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmMain

    Const mAccess As String = ".txt|.c|.cpp|.h|.hpp|.vb|.xml|.log|.html|.java|.php|.cs|.s|.asm|.htm|.pas|.rtf|.python"
    Private DropedFileList As New List(Of String)
    Private LineCounter As Integer = 0
    Private array_ext() As String

    Private Sub ParseExtension(ByVal strExtension As String)
        Dim strexarr As String() = strExtension.Split("|"c)
        array_ext = strexarr
    End Sub

    Private Sub ListView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            For Each path As String In filePaths
                If array_ext.Contains(IO.Path.GetExtension(path).ToLower()) Then
                    If Not DropedFileList.Contains(path) Then
                        Dim fileLen As Integer = IO.File.ReadAllLines(path).Length
                        Dim lvi As ListViewItem
                        lvi = ListView1.Items.Add(New ListViewItem(New String() {path, fileLen}))
                        lvi.StateImageIndex = 0
                        DropedFileList.Add(path)
                        LineCounter += fileLen
                        Label2.Text = LineCounter.ToString("#,#")
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim identity = Security.Principal.WindowsIdentity.GetCurrent()
        Dim principal = New Security.Principal.WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator)
        If isElevated Then
            MsgBox("이 프로그램은 관리자권한으로 실행할 수 없습니다.", MsgBoxStyle.Critical, "RollRat File Line Counter")
            End
        End If

        ParseExtension(mAccess)
    End Sub

End Class
