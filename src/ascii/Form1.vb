Public Class Form1

    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    For a = 0 To 255
    '        RichTextBox1.AppendText("   0x" & a.ToString("x") & ", /* '" & Chr(a) & "' */" & vbCrLf)
    '    Next
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox2.Text = ""
        Dim a As Integer = TextBox1.Text
        For Each t As String In RichTextBox1.Lines
            RichTextBox2.AppendText(RSet(a, 4) & ": " & t & vbCrLf)
            a += 1
        Next
        TextBox1.Text = a
    End Sub
End Class
