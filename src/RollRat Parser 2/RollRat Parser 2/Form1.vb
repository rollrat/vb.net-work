Imports System.Text.RegularExpressions

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "기능을 선택하십시오." Then
            MsgBox("기능중 하나를 선택하여야 합니다.", MsgBoxStyle.Information)
            Exit Sub
        End If
        ComboBox1.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With SyntaxRichTextBox1
            With .Settings
                With .Keywords
                    .Add("unsigned")
                    .Add("int")
                    .Add("char")
                    .Add("double")
                    .Add("long")
                    .Add("const")
                    .Add("float")
                    .Add("void")

                    .Add("__cdecl")
                    .Add("__stdcall")
                    .Add("__fastcall")

                    .Add("return")
                    .Add("inline")
                    .Add("sizeof")

                    .Add("while")
                    .Add("for")
                    .Add("do")
                    .Add("break")
                    .Add("switch")
                    .Add("case")
                    .Add("default")
                    .Add("if")
                    .Add("else")
                    .Add("struct")
                    .Add("typedef")
                    .Add("extern")
                    .Add("static")
                End With

                .Comment = "//"

                .KeywordColor = Color.FromArgb(86, 156, 214)
                .CommentColor = Color.FromArgb(96, 139, 78)
                .StringColor = Color.FromArgb(214, 157, 133)
                .IntegerColor = Color.FromArgb(181, 206, 168)
            End With
            .CompileKeywords()
            .ProcessAllLines()

            .BackColor = Color.FromArgb(30, 30, 30)
            .ForeColor = Color.White

            .AcceptsTab = True
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SyntaxRichTextBox1.ProcessAllLines()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Regexing_CLanguage_MakeSyntaxTree(SyntaxRichTextBox1.Text, TreeView1)
    End Sub

    Public Sub Regexing_CLanguage_MakeSyntaxTree(ByVal m_Text As String, ByRef m_Treeview As TreeView)
        '***************************************
        '
        '   RollRat C Syntax Tree Maker
        '
        '***************************************

        'Clear TreeView
        m_Treeview.Nodes.Clear()

        'Regex Pattern
        Dim rg_annote_comment As String = "//.*?\n"
        Dim rg_annote_randfid As String = "/\*(?>\n|[^*]|\*+[^*/])*\**\*/"
        Dim rg_define As String = "#define (\w+|\w+(\([\w\, ]*\)))\s+(?(?=\\)([^\\]|\\\n)*[^\\]|([^\n]*))"
        Dim rg_function As String = "\b[\w\*]+([\w\* ]+)?\s+\w+\s*\([\w\,\* ]*\)\s*{(?(?={)((?(?={)((?(?={)[^}]*|[^}])*})|[^}])*})|[^}])*}"
        Dim rg_function_1 As String = "[\w\*]+\s+\n*\w+\([\w\*\&\=\,\s\n ]*\)[\s\n\w ]*(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n||[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})+" '"(?<=[\w\*]+([\w\* ]+)?\s+\w+\s*\([\w\,\* ]*\)\s*{)(?(?={)((?(?={)((?(?={)[^}]*|[^}])*})|[^}])*})|[^}])*(?=})"
        Dim rg_function_name As String = "\b[\w\*]+([\w\* ]+)?\s+\w+\s*\([\w\,\* ]*\)\s*(?={(?(?={)((?(?={)((?(?={)[^}]*|[^}])*})|[^}])*})|[^}])*})"
        '(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n||[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*
        '[\w\*]+\s+\w+\([\w\*\&\=\,\s\n ]*\)[\s\n\w ]*(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n|(\{(\n||[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})*|[^\}\{])*\})+
        Dim rg_string As String = """[^""\\\r\n]*(?:\\.[^""\\\r\n]*)*"""
        Dim rg_include As String = "#include ((<[/\.\w_\-\#\\\+\-\(\)\{\}\[\]\:\;\']+>)|(""[/\.\w_\-\#\\\+\-\(\)\{\}\[\]\:\;\']+""))"
        Dim rg_number As String = "\b(?:[0-9]*\.)?[0-9]+\b"
        Dim rg_colon As String = "[^;]+;"
        Dim rg_prefunction As String = "\b[\w\*]+([\w\* ]+)?\s+\w+\s*\([\w\,\ ]*\)\s*;"
        Dim rg_return As String = "\breturn\s+([^;])*;"
        Dim rg_functions As String = "\b\w+\s*\([^)]*\)\s*;"
        Dim rg_function_types_1 As String = "[\w\s\* ]+(?=[\s ]+[\w]+\s*\()"
        Dim rg_function_types_2 As String = "(?<=[\w\s\* ]+[\s ]+)[\w]+\s*(?=\()"
        Dim rg_function_types_3 As String = "(?<=\()[\w\,\* ]*(?=\))"
        Dim meaning_sunun As String = "\w+[\,\=\w ]+"
        Dim meaning_brace As String = "(?<=\()[\w\W\s\n ]+(?>=\))"
        '\w+[\s\n ]+\w+[\s\n ]+=[\s\n ]+(\s|\n|[^\;])+;
        '\w+[\s\n ]+[\<\>(\<\=)(\=\>)(\>\=)(\=\<)]+[\s\n ]+\w+;
        '\w+[\s\n ]+[\<\>\=]+[\s\n ]+\w+[\s\n ]+\?[\s\n ]+\w+[\s\n ]+:[\s\n ]+\w+
        '

        'Regex
        Dim EntryRegex As Regex
        Dim RegexMatch As Match
        Dim EntryRegex_1 As Regex
        Dim RegexMatch_1 As Match
        Dim EntryRegex_2 As Regex
        Dim RegexMatch_2 As Match
        Dim EntryRegex_3 As Regex
        Dim RegexMatch_3 As Match

        'Annotations
        EntryRegex = New Regex(rg_annote_comment, RegexOptions.Compiled)
        RegexMatch = EntryRegex.Match(m_Text)
        'If RegexMatch.Success Then
        m_Treeview.Nodes.Add("Annotes") ' 0
        'End If
        While RegexMatch.Success
            m_Treeview.Nodes(0).Nodes.Add(RegexMatch.Value)
            RegexMatch = RegexMatch.NextMatch
        End While
        EntryRegex = New Regex(rg_annote_randfid, RegexOptions.Compiled)
        RegexMatch = EntryRegex.Match(m_Text)
        While RegexMatch.Success
            m_Treeview.Nodes(0).Nodes.Add(RegexMatch.Value)
            RegexMatch = RegexMatch.NextMatch
        End While

        'Defines
        EntryRegex = New Regex(rg_define, RegexOptions.Compiled)
        RegexMatch = EntryRegex.Match(m_Text)
        'If RegexMatch.Success Then
        m_Treeview.Nodes.Add("Define") ' 1
        'End If
        While RegexMatch.Success
            m_Treeview.Nodes(1).Nodes.Add(RegexMatch.Value)
            RegexMatch = RegexMatch.NextMatch
        End While

        'Functions
        EntryRegex = New Regex(rg_function_name, RegexOptions.Compiled)
        RegexMatch = EntryRegex.Match(m_Text)
        EntryRegex_2 = New Regex(rg_function_1, RegexOptions.Compiled)
        RegexMatch_2 = EntryRegex_2.Match(m_Text)
        'If RegexMatch.Success Then
        m_Treeview.Nodes.Add("Functions") ' 2
        'End If
        Dim i_func_1 = 0
        While RegexMatch.Success
            m_Treeview.Nodes(2).Nodes.Add(RegexMatch.Value)
            m_Treeview.Nodes(2).Nodes(i_func_1).Nodes.Add("Colons")
            EntryRegex_1 = New Regex(rg_colon, RegexOptions.Compiled)
            RegexMatch_1 = EntryRegex_1.Match(RegexMatch_2.Value)

            Dim i = 0

            While RegexMatch_1.Success
                m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(0).Nodes.Add(RegexMatch_1.Value)

                EntryRegex_3 = New Regex(meaning_sunun, RegexOptions.Compiled)
                RegexMatch_3 = EntryRegex_3.Match(RegexMatch_1.Value)
                While RegexMatch_3.Success
                    m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(0).Nodes(i).Nodes.Add(RegexMatch_3.Value)
                    RegexMatch_3 = RegexMatch_3.NextMatch()
                End While

                EntryRegex_3 = New Regex(rg_number, RegexOptions.Compiled)
                RegexMatch_3 = EntryRegex_3.Match(RegexMatch_1.Value)
                While RegexMatch_3.Success
                    m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(0).Nodes(i).Nodes.Add(RegexMatch_3.Value)
                    RegexMatch_3 = RegexMatch_3.NextMatch()
                End While

                EntryRegex_3 = New Regex(rg_string, RegexOptions.Compiled)
                RegexMatch_3 = EntryRegex_3.Match(RegexMatch_1.Value)
                While RegexMatch_3.Success
                    m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(0).Nodes(i).Nodes.Add(RegexMatch_3.Value)
                    RegexMatch_3 = RegexMatch_3.NextMatch()
                End While

                EntryRegex_3 = New Regex(meaning_brace, RegexOptions.Compiled)
                RegexMatch_3 = EntryRegex_3.Match(RegexMatch_1.Value)
                While RegexMatch_3.Success
                    m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(0).Nodes(i).Nodes.Add(RegexMatch_3.Value)
                    RegexMatch_3 = RegexMatch_3.NextMatch()
                End While

                i += 1
                RegexMatch_1 = RegexMatch_1.NextMatch
            End While

            m_Treeview.Nodes(2).Nodes(i_func_1).Nodes.Add("String")
            EntryRegex_1 = New Regex(rg_string, RegexOptions.Compiled)
            RegexMatch_1 = EntryRegex_1.Match(RegexMatch_2.Value)
            While RegexMatch_1.Success
                m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(1).Nodes.Add(RegexMatch_1.Value)
                RegexMatch_1 = RegexMatch_1.NextMatch
            End While

            m_Treeview.Nodes(2).Nodes(i_func_1).Nodes.Add("Return")
            EntryRegex_1 = New Regex(rg_return, RegexOptions.Compiled)
            RegexMatch_1 = EntryRegex_1.Match(RegexMatch_2.Value)
            While RegexMatch_1.Success
                m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(2).Nodes.Add(RegexMatch_1.Value)
                RegexMatch_1 = RegexMatch_1.NextMatch
            End While

            m_Treeview.Nodes(2).Nodes(i_func_1).Nodes.Add("Functions")
            EntryRegex_1 = New Regex(rg_functions, RegexOptions.Compiled)
            RegexMatch_1 = EntryRegex_1.Match(RegexMatch_2.Value)
            While RegexMatch_1.Success
                m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(3).Nodes.Add(RegexMatch_1.Value)
                RegexMatch_1 = RegexMatch_1.NextMatch
            End While

            m_Treeview.Nodes(2).Nodes(i_func_1).Nodes.Add("TypesH")
            EntryRegex_1 = New Regex(rg_function_types_1, RegexOptions.Compiled)
            RegexMatch_1 = EntryRegex_1.Match(RegexMatch.Value)
            m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(4).Nodes.Add(RegexMatch_1.Value)
            EntryRegex_1 = New Regex(rg_function_types_2, RegexOptions.Compiled)
            RegexMatch_1 = EntryRegex_1.Match(RegexMatch.Value)
            m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(4).Nodes.Add(RegexMatch_1.Value)
            EntryRegex_1 = New Regex(rg_function_types_3, RegexOptions.Compiled)
            RegexMatch_1 = EntryRegex_1.Match(RegexMatch.Value)
            m_Treeview.Nodes(2).Nodes(i_func_1).Nodes(4).Nodes.Add(RegexMatch_1.Value)

            i_func_1 += 1
            RegexMatch = RegexMatch.NextMatch
            RegexMatch_2 = RegexMatch_2.NextMatch
        End While

        'String
        EntryRegex = New Regex(rg_string, RegexOptions.Compiled)
        RegexMatch = EntryRegex.Match(m_Text)
        'If RegexMatch.Success Then
        m_Treeview.Nodes.Add("String") ' 2
        'End If
        While RegexMatch.Success
            m_Treeview.Nodes(3).Nodes.Add(RegexMatch.Value)
            RegexMatch = RegexMatch.NextMatch
        End While

        'Include
        EntryRegex = New Regex(rg_include, RegexOptions.Compiled)
        RegexMatch = EntryRegex.Match(m_Text)
        'If RegexMatch.Success Then
        m_Treeview.Nodes.Add("Include") ' 2
        'End If
        While RegexMatch.Success
            m_Treeview.Nodes(4).Nodes.Add(RegexMatch.Value)
            RegexMatch = RegexMatch.NextMatch
        End While

        'Number
        EntryRegex = New Regex(rg_number, RegexOptions.Compiled)
        RegexMatch = EntryRegex.Match(m_Text)
        'If RegexMatch.Success Then
        m_Treeview.Nodes.Add("Number") ' 2
        'End If
        While RegexMatch.Success
            m_Treeview.Nodes(5).Nodes.Add(RegexMatch.Value)
            RegexMatch = RegexMatch.NextMatch
        End While

        'rg_prefunction
        EntryRegex = New Regex(rg_prefunction, RegexOptions.Compiled)
        RegexMatch = EntryRegex.Match(m_Text)
        'If RegexMatch.Success Then
        m_Treeview.Nodes.Add("PreFunction") ' 2
        'End If
        While RegexMatch.Success
            m_Treeview.Nodes(6).Nodes.Add(RegexMatch.Value)
            RegexMatch = RegexMatch.NextMatch
        End While

    End Sub

End Class


