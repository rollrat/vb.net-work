Imports System.Text.RegularExpressions

Public Class Form1

    '////////////////////////////////////////////
    '//         ROLLRAT SOFTWARE               //
    '////////////////////////////////////////////

    Dim mode As Integer
    Dim modes As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox3.Clear()
        Dim rex As New Regex(TextBox1.Text)
        Dim mat As MatchCollection = rex.Matches(TextBox2.Text)
        If TextBox4.Text = "" Then
            For Each mmat As Match In mat
                TextBox3.AppendText(Convert.ToString(mmat) & vbCr & vbLf)
            Next
        Else
            If TextBox5.Text <> "" Then
                Dim rexs As New Regex(TextBox5.Text)
                Dim mats As Match = rexs.Match(TextBox2.Text)
                Dim abgg As String = ""
                For Each mmat As Match In mat
                    abgg = TextBox4.Text
                    abgg = Replace(abgg, "{0}", Convert.ToString(mmat))
                    abgg = Replace(abgg, "{1}", Convert.ToString(mats.Value))
                    TextBox3.AppendText(abgg & vbCr & vbLf)
                    mats = mats.NextMatch
                Next
            Else
                For Each mmat As Match In mat
                    TextBox3.AppendText(Replace(TextBox4.Text, "{0}", Convert.ToString(mmat)) & vbCr & vbLf)
                Next
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mode = 0
        modes = 0
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.Modifiers = Keys.Control Then
            If mode <> 0 Then
                If mode = 1 Then

                    ' STANDARD REGEX PARENTHESIS ASSOCIATED

                    If (e.KeyCode = Keys.S) Then
                        TextBox1.Text = "(?<=\()[^""\\\r\n]*(?=\))"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + S)"
                    ElseIf (e.KeyCode = Keys.M) Then
                        TextBox1.Text = "(?<=\{)[^""\\\r\n]*(?=\})"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + M)"
                    ElseIf (e.KeyCode = Keys.L) Then
                        TextBox1.Text = "(?<=\[)[^""\\\r\n]*(?=\])"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + L)"
                    ElseIf (e.KeyCode = Keys.A) Then
                        TextBox1.Text = "(?<=\<)[^""\\\r\n]*(?=\>)"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + A)"
                    ElseIf (e.KeyCode = Keys.G) Then
                        TextBox1.Text = "(?<=\"")[^""\\\r\n]*(?=\"")"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + G)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                ElseIf mode = 2 Then

                    ' STANDARD REGEX PREPROCESSOR ASSOCIATED

                    If (e.KeyCode = Keys.D) Then
                        TextBox1.Text = "(?<=\#define[\t ]+)\w+"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + P, Ctrl + D)"
                    ElseIf (e.KeyCode = Keys.F) Then
                        TextBox1.Text = "(?<=\#define[\t ]+\w+[\t ]+)\w+"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + P, Ctrl + F)"
                    ElseIf (e.KeyCode = Keys.G) Then
                        TextBox1.Text = "(?<=\#define[\t ]+\w+[\t ]+\w+[\t ]+)\w+"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + P, Ctrl + F)"
                    ElseIf (e.KeyCode = Keys.I) Then
                        TextBox1.Text = "(?<=\#include[\t ]+)((<[/\.\w_\-\#\\\+\-\(\)\{\}\[\]\:\;\']+>)|(""[/\.\w_\-\#\\\+\-\(\)\{\}\[\]\:\;\']+""))"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + P, Ctrl + F)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                ElseIf mode = 3 Then

                    ' STANDARD REGEX ANOTATION ASSOCIATED

                    If (e.KeyCode = Keys.O) Then
                        TextBox1.Text = "//.*?\n"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + A, Ctrl + O)"
                    ElseIf (e.KeyCode = Keys.F) Then
                        TextBox1.Text = "/\*(?>\n|[^*]|\*+[^*/])*\**\*/"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + A, Ctrl + F)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                ElseIf mode = 4 Then

                    ' STANDARD REGEX FUNCITON ASSOCIATED

                    If (e.KeyCode = Keys.O) Then
                        TextBox1.Text = "[\w\*]+\s+\n*\w+\([\w\*\&\=\,\s\n ]*\)[\s\n\w ]*(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n||[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})+"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + F, Ctrl + O)"
                    ElseIf (e.KeyCode = Keys.N) Then
                        TextBox1.Text = "\b[\w\*]+([\w\* ]+)?\s+\w+\s*\([\w\,\* ]*\)\s*(?={(?(?={)((?(?={)((?(?={)[^}]*|[^}])*})|[^}])*})|[^}])*})"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + F, Ctrl + N)"
                    ElseIf (e.KeyCode = Keys.P) Then
                        TextBox1.Text = "\b\w+\s*\([^)]*\)\s*;"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + F, Ctrl + P)"
                    ElseIf (e.KeyCode = Keys.R) Then
                        TextBox1.Text = "\breturn\s+([^;])*;"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + F, Ctrl + R)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                ElseIf mode = 5 Then

                    ' STANDARD REGEX TEMPLATE ASSOCIATED

                ElseIf mode = 6 Then

                    ' STANDARD REGEX CLASS ASSOCIATED

                ElseIf mode = 7 Then

                    ' INFORMATION ASSOCIATED

                    If (e.KeyCode = Keys.I) Then
                        MsgBox("이 프로그램은 윈도우프로그래밍을 위하여 만들어졌습니다. 또한 JHJ의 개발환경에 최대한 맞추어 제작하였습니다.", MsgBoxStyle.Information, "RollRat Programs")
                        ToolStripStatusLabel1.Text = "Success(Ctrl + I, Ctrl + I)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                ElseIf mode = 8 Then

                    ' ROLLRAT WINDOWS TOOL ASSOCIATED

                    If (e.KeyCode = Keys.W) Then
                        frmMain.Show()
                        ToolStripStatusLabel1.Text = "Success(Ctrl + L, Ctrl + W)"
                    ElseIf (e.KeyCode = Keys.H) Then
                        frmUV.Show()
                        ToolStripStatusLabel1.Text = "Success(Ctrl + L, Ctrl + H)"
                    ElseIf (e.KeyCode = Keys.C) Then
                        frmUC.Show()
                        ToolStripStatusLabel1.Text = "Success(Ctrl + L, Ctrl + C)"
                    ElseIf (e.KeyCode = Keys.M) Then
                        MemoryEditor.Show()
                        ToolStripStatusLabel1.Text = "Success(Ctrl + L, Ctrl + M)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                End If
                mode = 0
            Else
                If (e.KeyCode = Keys.G) Then
                    mode = 1 ' parenthesis
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + G)"
                ElseIf (e.KeyCode = Keys.P) Then
                    mode = 2 ' preprocessor
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + P)"
                ElseIf (e.KeyCode = Keys.A) Then
                    mode = 3 ' annotation
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + A)"
                ElseIf (e.KeyCode = Keys.F) Then
                    mode = 4 ' function
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + F)"
                ElseIf (e.KeyCode = Keys.T) Then
                    mode = 5 ' template
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + T)"
                ElseIf (e.KeyCode = Keys.C) Then
                    mode = 6 ' class
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + C)"
                ElseIf (e.KeyCode = Keys.I) Then
                    mode = 7 ' information
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + I)"
                ElseIf (e.KeyCode = Keys.L) Then
                    mode = 8 ' tool
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + L)"
                End If
            End If
        ElseIf e.Modifiers = Keys.Shift Then
            If modes <> 0 Then
                If modes = 1 Then
                    If (e.KeyCode = Keys.S) Then
                        Button1.PerformClick()
                        ToolStripStatusLabel1.Text = "Success(Shift + S, Shift + S)"
                    Else
                        If (e.KeyCode = Keys.ShiftKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If
                End If
                modes = 0
            Else
                If (e.KeyCode = Keys.S) Then
                    modes = 1
                    ToolStripStatusLabel1.Text = "Press Next Keys(Shift + S)"
                End If
            End If
        ElseIf e.Modifiers = (Keys.Control Or Keys.Shift) Then
            If (e.KeyCode = Keys.S) Then
                Button1.PerformClick()
                ToolStripStatusLabel1.Text = "Success(Ctrl + Shift + S)"
            End If
        End If
T:
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If (e.Modifiers = Keys.Control) AndAlso (e.KeyCode = Keys.N) Then
            Process.Start("c:\windows\system32\notepad.exe")
            ToolStripStatusLabel1.Text = "Success(Open Notepad.exe)"
        ElseIf (e.Modifiers = (Keys.Control Or Keys.Shift)) AndAlso (e.KeyCode = Keys.S) Then
            Button1.PerformClick()
            ToolStripStatusLabel1.Text = "Success(Ctrl + Shift + S)"
        End If
        If TextBox3.Text <> "" Then
            If (e.Modifiers = Keys.Control) AndAlso (e.KeyCode = Keys.C) Then
                Clipboard.SetText(TextBox3.Text)
                ToolStripStatusLabel1.Text = "Success(Clipboard Copyed)"
            ElseIf (e.Modifiers = Keys.Control) AndAlso (e.KeyCode = Keys.A) Then
                TextBox3.SelectAll()
                ToolStripStatusLabel1.Text = "Success(Choose All)"
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.Modifiers = (Keys.Control Or Keys.Shift) Then
            If (e.KeyCode = Keys.S) Then
                Button1.PerformClick()
                ToolStripStatusLabel1.Text = "Success(Ctrl + Shift + S)"
            ElseIf (e.KeyCode = Keys.C) Then
                TextBox2.Clear()
                ToolStripStatusLabel1.Text = "Success(Ctrl + Shift + C)"
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.Modifiers = Keys.Control Then
            If mode <> 0 Then
                If mode = 1 Then

                    ' STANDARD REGEX PARENTHESIS ASSOCIATED

                    If (e.KeyCode = Keys.S) Then
                        TextBox5.Text = "(?<=\()[^""\\\r\n]*(?=\))"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + S)"
                    ElseIf (e.KeyCode = Keys.M) Then
                        TextBox5.Text = "(?<=\{)[^""\\\r\n]*(?=\})"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + M)"
                    ElseIf (e.KeyCode = Keys.L) Then
                        TextBox5.Text = "(?<=\[)[^""\\\r\n]*(?=\])"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + L)"
                    ElseIf (e.KeyCode = Keys.A) Then
                        TextBox5.Text = "(?<=\<)[^""\\\r\n]*(?=\>)"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + A)"
                    ElseIf (e.KeyCode = Keys.G) Then
                        TextBox5.Text = "(?<=\"")[^""\\\r\n]*(?=\"")"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + G, Ctrl + G)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                ElseIf mode = 2 Then

                    ' STANDARD REGEX PREPROCESSOR ASSOCIATED

                    If (e.KeyCode = Keys.D) Then
                        TextBox5.Text = "(?<=\#define[\t ]+)\w+"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + P, Ctrl + D)"
                    ElseIf (e.KeyCode = Keys.F) Then
                        TextBox5.Text = "(?<=\#define[\t ]+\w+[\t ]+)\w+"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + P, Ctrl + F)"
                    ElseIf (e.KeyCode = Keys.G) Then
                        TextBox5.Text = "(?<=\#define[\t ]+\w+[\t ]+\w+[\t ]+)\w+"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + P, Ctrl + F)"
                    ElseIf (e.KeyCode = Keys.I) Then
                        TextBox5.Text = "(?<=\#include[\t ]+)((<[/\.\w_\-\#\\\+\-\(\)\{\}\[\]\:\;\']+>)|(""[/\.\w_\-\#\\\+\-\(\)\{\}\[\]\:\;\']+""))"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + P, Ctrl + F)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                ElseIf mode = 3 Then

                    ' STANDARD REGEX ANOTATION ASSOCIATED

                    If (e.KeyCode = Keys.O) Then
                        TextBox5.Text = "//.*?\n"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + A, Ctrl + O)"
                    ElseIf (e.KeyCode = Keys.F) Then
                        TextBox5.Text = "/\*(?>\n|[^*]|\*+[^*/])*\**\*/"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + A, Ctrl + F)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                ElseIf mode = 4 Then

                    ' STANDARD REGEX FUNCITON ASSOCIATED

                    If (e.KeyCode = Keys.O) Then
                        TextBox5.Text = "[\w\*]+\s+\n*\w+\([\w\*\&\=\,\s\n ]*\)[\s\n\w ]*(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n||[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})+"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + F, Ctrl + O)"
                    ElseIf (e.KeyCode = Keys.N) Then
                        TextBox5.Text = "\b[\w\*]+([\w\* ]+)?\s+\w+\s*\([\w\,\* ]*\)\s*(?={(?(?={)((?(?={)((?(?={)[^}]*|[^}])*})|[^}])*})|[^}])*})"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + F, Ctrl + N)"
                    ElseIf (e.KeyCode = Keys.P) Then
                        TextBox5.Text = "\b\w+\s*\([^)]*\)\s*;"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + F, Ctrl + P)"
                    ElseIf (e.KeyCode = Keys.R) Then
                        TextBox5.Text = "\breturn\s+([^;])*;"
                        ToolStripStatusLabel1.Text = "Success(Ctrl + F, Ctrl + R)"
                    Else
                        If (e.KeyCode = Keys.ControlKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If

                End If
                mode = 0
            Else
                If (e.KeyCode = Keys.G) Then
                    mode = 1 ' parenthesis
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + G)"
                ElseIf (e.KeyCode = Keys.P) Then
                    mode = 2 ' preprocessor
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + P)"
                ElseIf (e.KeyCode = Keys.A) Then
                    mode = 3 ' annotation
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + A)"
                ElseIf (e.KeyCode = Keys.F) Then
                    mode = 4 ' function
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + F)"
                ElseIf (e.KeyCode = Keys.T) Then
                    mode = 5 ' template
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + T)"
                ElseIf (e.KeyCode = Keys.C) Then
                    mode = 6 ' class
                    ToolStripStatusLabel1.Text = "Press Next Keys(Ctrl + C)"
                End If
            End If
        ElseIf e.Modifiers = Keys.Shift Then
            If modes <> 0 Then
                If modes = 1 Then
                    If (e.KeyCode = Keys.S) Then
                        Button1.PerformClick()
                        ToolStripStatusLabel1.Text = "Success(Shift + S, Shift + S)"
                    Else
                        If (e.KeyCode = Keys.ShiftKey) Then
                            GoTo T
                        End If
                        ToolStripStatusLabel1.Text = "Keys omitted."
                    End If
                End If
                modes = 0
            Else
                If (e.KeyCode = Keys.S) Then
                    modes = 1
                    ToolStripStatusLabel1.Text = "Press Next Keys(Shift + S)"
                End If
            End If
        ElseIf e.Modifiers = (Keys.Control Or Keys.Shift) Then
            If (e.KeyCode = Keys.S) Then
                Button1.PerformClick()
                ToolStripStatusLabel1.Text = "Success(Ctrl + Shift + S)"
            End If
        End If
T:
    End Sub

End Class
