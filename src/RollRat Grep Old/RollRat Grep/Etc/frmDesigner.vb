'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO

Public Class frmDesigner

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim itemss() As String = RichTextBox1.Lines
        Array.Sort(Of String)(itemss)
        RichTextBox1.Lines = itemss
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.Lines = (From value In RichTextBox1.Lines Select value Distinct Order By value).ToArray
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Clipboard.SetData(Windows.Forms.DataFormats.StringFormat, RichTextBox1.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f = SaveFileDialog1.ShowDialog()
        If f = Windows.Forms.DialogResult.OK Then
            File.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text)
        End If
    End Sub

    Private Sub _KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

End Class