'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmMain

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim text As String = ""
        If RadioButton1.Checked Then
            For Each ch As Char In RichTextBox1.Text
                If hangul_is(ch) Then
                    text += hangul_disassembly(ch)
                Else
                    text += ch
                End If
            Next
        Else
            For Each ch As Char In RichTextBox1.Text
                If hangul_is3(ch) Then
                    text += hangul_disassembly3(ch)
                Else
                    text += ch
                End If
            Next
        End If
        RichTextBox1.Text = text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim text As String = ""
        If RadioButton1.Checked Then
            text = hangul_assembly(RichTextBox1.Text)
        Else
            text = hangul_assembly3(RichTextBox1.Text)
        End If
        RichTextBox1.Text = text
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        _SafeLetterExecuative = CheckBox1.Checked
    End Sub

End Class
