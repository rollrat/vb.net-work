Public Class Form1
    '828, 98
    '828, 491
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "기능을 선택하십시오." Then
            MsgBox("기능중 하나를 선택하여야 합니다.", MsgBoxStyle.Information)
            Exit Sub
        End If
        ComboBox1.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SyntaxRichTextBox1.Settings.Keywords.Add("unsigned")
        SyntaxRichTextBox1.Settings.Keywords.Add("include")
        SyntaxRichTextBox1.Settings.Keywords.Add("else")
        SyntaxRichTextBox1.Settings.Keywords.Add("if")
        SyntaxRichTextBox1.Settings.Keywords.Add("endif")
        SyntaxRichTextBox1.Settings.Keywords.Add("plagma")
        SyntaxRichTextBox1.Settings.Keywords.Add("define")
        SyntaxRichTextBox1.Settings.Keywords.Add("push_macro")
        SyntaxRichTextBox1.Settings.Keywords.Add("undef")

        SyntaxRichTextBox1.Settings.Keywords.Add("int")
        SyntaxRichTextBox1.Settings.Keywords.Add("char")
        SyntaxRichTextBox1.Settings.Keywords.Add("double")
        SyntaxRichTextBox1.Settings.Keywords.Add("long")
        SyntaxRichTextBox1.Settings.Keywords.Add("const")
        SyntaxRichTextBox1.Settings.Keywords.Add("float")
        SyntaxRichTextBox1.Settings.Keywords.Add("void")

        SyntaxRichTextBox1.Settings.Keywords.Add("__cdecl")
        SyntaxRichTextBox1.Settings.Keywords.Add("__stdcall")
        SyntaxRichTextBox1.Settings.Keywords.Add("__fastcall")

        SyntaxRichTextBox1.Settings.Keywords.Add("return")
        SyntaxRichTextBox1.Settings.Keywords.Add("inline")
        SyntaxRichTextBox1.Settings.Keywords.Add("sizeof")

        SyntaxRichTextBox1.Settings.Keywords.Add("while")
        SyntaxRichTextBox1.Settings.Keywords.Add("for")
        SyntaxRichTextBox1.Settings.Keywords.Add("do")
        SyntaxRichTextBox1.Settings.Keywords.Add("break")
        SyntaxRichTextBox1.Settings.Keywords.Add("switch")
        SyntaxRichTextBox1.Settings.Keywords.Add("case")
        SyntaxRichTextBox1.Settings.Keywords.Add("default")

        SyntaxRichTextBox1.Settings.Comment = "//"

        SyntaxRichTextBox1.Settings.KeywordColor = Color.FromArgb(86, 156, 214)
        SyntaxRichTextBox1.Settings.CommentColor = Color.Green
        SyntaxRichTextBox1.Settings.StringColor = Color.FromArgb(214, 157, 133)
        SyntaxRichTextBox1.Settings.IntegerColor = Color.Red
        SyntaxRichTextBox1.Settings.EnableStrings = False
        SyntaxRichTextBox1.Settings.EnableIntegers = False

        SyntaxRichTextBox1.CompileKeywords()
        SyntaxRichTextBox1.ProcessAllLines()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SyntaxRichTextBox1.ProcessAllLines()
    End Sub

End Class
