'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmResult

    Dim filename As String

    Private Sub frmResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        filename = frmMain.filename
        Me.Text += " " & filename
        For Each it As String In frmMain.result(frmMain.seletedindex - 1)
            i += 1
            Dim isx As String = it.Split(":")(0)
            lvResult.Items.Add(New ListViewItem(New String() {i, isx, it.Remove(0, isx.Length + 1)}))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bEnd.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles bRun.Click
        Process.Start(filename)
    End Sub

    Private Sub frmResult_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class