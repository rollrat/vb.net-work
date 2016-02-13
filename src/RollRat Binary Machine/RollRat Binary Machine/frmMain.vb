Imports RollRat_Binary_Machine.SyntaxHighlighter
Imports RollRat_Vb_Api.RollRat_Vb_Api

Public Class frmMain

#Region " Text Box "

    Private Sub NumberPut(ByRef g As Graphics)
        Dim FH As Single = SyntaxRichTextBox1.GetPositionFromCharIndex(SyntaxRichTextBox1.GetFirstCharIndexFromLine(2)).Y - _
            SyntaxRichTextBox1.GetPositionFromCharIndex(SyntaxRichTextBox1.GetFirstCharIndexFromLine(1)).Y
        If FH = 0 Then Exit Sub
        Dim FI As Integer = SyntaxRichTextBox1.GetCharIndexFromPosition(New Point(0, g.VisibleClipBounds.Y + FH / 3))
        Dim FL As Integer = SyntaxRichTextBox1.GetLineFromCharIndex(FI)
        Dim FLY As Integer = SyntaxRichTextBox1.GetPositionFromCharIndex(FI).Y
        g.Clear(Control.DefaultBackColor)
        Dim i As Integer = FL
        Dim y As Single
        Do While y < g.VisibleClipBounds.Y + g.VisibleClipBounds.Height
            y = FLY + 2 + FH * (i - FL - 1)

            '이 줄에서 색을 재설정 할 수 있음
            g.DrawString((i).ToString, SyntaxRichTextBox1.Font, Brushes.DarkGray, _
                         MyPictureBox.Width - g.MeasureString((i).ToString, SyntaxRichTextBox1.Font).Width, y)
            i += 1
        Loop
    End Sub
    Private Sub r_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SyntaxRichTextBox1.Resize
        MyPictureBox.Invalidate()
    End Sub
    Private Sub r_VScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles SyntaxRichTextBox1.VScroll
        MyPictureBox.Invalidate()
    End Sub
    Private Sub p_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyPictureBox.Paint
        NumberPut(e.Graphics)
    End Sub

#End Region


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SyntaxRichTextBox.F = Label2.Font

        SyntaxRichTextBox.Upper = New String(4, 1) { _
                                                    {"Mov", "mov"}, _
                                                    {"Add", "add"}, _
                                                    {"Sub", "sub"}, _
                                                    {"Mul", "mul"}, _
                                                    {"Div", "div"}
                                                   }

        SyntaxRichTextBox1.Settings.Comment = ";"

        SyntaxRichTextBox1.Settings.Keywords.Add("add")
        SyntaxRichTextBox1.Settings.Keywords.Add("sub")
        SyntaxRichTextBox1.Settings.Keywords.Add("mul")
        SyntaxRichTextBox1.Settings.Keywords.Add("div")
        SyntaxRichTextBox1.Settings.Keywords.Add("xor")
        SyntaxRichTextBox1.Settings.Keywords.Add("or")
        SyntaxRichTextBox1.Settings.Keywords.Add("and")
        SyntaxRichTextBox1.Settings.Keywords.Add("not")
        SyntaxRichTextBox1.Settings.Keywords.Add("shl")
        SyntaxRichTextBox1.Settings.Keywords.Add("shr")
        SyntaxRichTextBox1.Settings.fKeywords.Add("mov")

        SyntaxRichTextBox1.Settings.fKeywords.Add("def")
        SyntaxRichTextBox1.Settings.fKeywords.Add("imp")

        SyntaxRichTextBox1.Settings.fKeywords.Add("jmp") '무조건분기
        SyntaxRichTextBox1.Settings.fKeywords.Add("jz") '조건분기

        '16bit 어셈블리 구성요소지만 그냥씀 
        SyntaxRichTextBox1.Settings.dKeywords.Add("eax")
        SyntaxRichTextBox1.Settings.dKeywords.Add("ebx")
        SyntaxRichTextBox1.Settings.dKeywords.Add("ecx")
        SyntaxRichTextBox1.Settings.dKeywords.Add("edx")
        SyntaxRichTextBox1.Settings.dKeywords.Add("zax")
        SyntaxRichTextBox1.Settings.dKeywords.Add("zbx")
        SyntaxRichTextBox1.Settings.dKeywords.Add("zcx")
        SyntaxRichTextBox1.Settings.dKeywords.Add("zdx")

        SyntaxRichTextBox1.Settings.EnableStrings = False
        SyntaxRichTextBox1.Settings.EnableIntegers = False

        SyntaxRichTextBox1.Settings.KeywordColor = Color.LightBlue
        SyntaxRichTextBox1.Settings.fKeywordColor = Color.Red
        SyntaxRichTextBox1.Settings.CommentColor = Color.Green
        SyntaxRichTextBox1.Settings.dKeywordColor = Color.Aqua

        SyntaxRichTextBox1.CompileKeywords()
        SyntaxRichTextBox1.CompileKeyGreen()
        SyntaxRichTextBox1.CompileKeyS()

        SyntaxRichTextBox1.ProcessAllLines()

        SyntaxRichTextBox1.AcceptsTab = True

    End Sub

    Dim SAVINGVal(7) As Integer
    Dim include_local As Boolean = False
    Dim jmpbuf As Integer
    Dim jmpT As Boolean = False
    Dim binary As Boolean = False

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For f = 0 To 7
            SAVINGVal(f) = Nothing
        Next
        include_local = False
        jmpbuf = Nothing
        jmpT = False
        Dim Max_Jul As Integer = _CA.JulByStr(SyntaxRichTextBox1.Text)
        'Demical ( 십진수 전용 )
        For Now_Jul = 0 To Max_Jul - 1
            Dim NJ As String = _Str.ReadLineByLine(SyntaxRichTextBox1.Text, Now_Jul)
            If jmpT = False Then
                If _Str.Tsplit(NJ, 0, ":") = "BIN" Then
                    binary = True
                End If
                If Not _Str.Tsplit(NJ, 1, ";") = "" Then
                    TextBox1.AppendText("Annotation j : " & Now_Jul + 1 & vbCrLf)
                    GoTo escape
                Else
                    If _Str.Tsplit(NJ, 0, " ") = "def" Then
                        Dim buf As Integer = _Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ":")
                        TextBox1.AppendText("Define : " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                        If _NS.GetAllOfThings(NJ, "eax") = 1 Then
                            TextBox1.AppendText("Define : eax " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                            SAVINGVal(0) = buf
                        End If
                        If _NS.GetAllOfThings(NJ, "ebx") = 1 Then
                            TextBox1.AppendText("Define : ebx " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                            SAVINGVal(1) = buf
                        End If
                        If _NS.GetAllOfThings(NJ, "ecx") = 1 Then
                            TextBox1.AppendText("Define : ecx " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                            SAVINGVal(2) = buf
                        End If
                        If _NS.GetAllOfThings(NJ, "edx") = 1 Then
                            TextBox1.AppendText("Define : edx " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                            SAVINGVal(3) = buf
                        End If
                        If _NS.GetAllOfThings(NJ, "zax") = 1 Then
                            TextBox1.AppendText("Define : eax " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                            SAVINGVal(4) = buf
                        End If
                        If _NS.GetAllOfThings(NJ, "zbx") = 1 Then
                            TextBox1.AppendText("Define : zbx " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                            SAVINGVal(5) = buf
                        End If
                        If _NS.GetAllOfThings(NJ, "zcx") = 1 Then
                            TextBox1.AppendText("Define : zcx " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                            SAVINGVal(6) = buf
                        End If
                        If _NS.GetAllOfThings(NJ, "zdx") = 1 Then
                            TextBox1.AppendText("Define : zdx " & buf & " j : " & Now_Jul + 1 & vbCrLf)
                            SAVINGVal(7) = buf
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "imp" Then
                        If _Str.Tsplit(_Str.Tsplit(NJ, 1, "<"), 0, ">") = "local" Then
                            TextBox1.AppendText("Include : local j : " & Now_Jul + 1 & vbCrLf)
                            include_local = True
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "jmp" Then
                        jmpT = True
                        jmpbuf = _Str.Tsplit(NJ, 1, " ")
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "jz" Then
                        'jz 10 : eax < 0
                        If Not _Str.Tsplit(NJ, 0, "=") = "" Then
                            If IsNumeric(_Str.Tsplit(NJ, 5, " ")) = True Then
                                If Geta(_Str.Tsplit(NJ, 3, " ")) = _Str.Tsplit(NJ, 5, " ") Then
                                    jmpT = True
                                    jmpbuf = _Str.Tsplit(NJ, 1, " ")
                                End If
                            Else
                                If Geta(_Str.Tsplit(NJ, 3, " ")) = Geta(_Str.Tsplit(NJ, 5, " ")) Then
                                    jmpT = True
                                    jmpbuf = _Str.Tsplit(NJ, 1, " ")
                                End If
                            End If
                        ElseIf Not _Str.Tsplit(NJ, 0, "<") = "" Then
                            If IsNumeric(_Str.Tsplit(NJ, 5, " ")) = True Then
                                If Geta(_Str.Tsplit(NJ, 3, " ")) < _Str.Tsplit(NJ, 5, " ") Then
                                    jmpT = True
                                    jmpbuf = _Str.Tsplit(NJ, 1, " ")
                                End If
                            Else
                                If Geta(_Str.Tsplit(NJ, 3, " ")) < Geta(_Str.Tsplit(NJ, 5, " ")) Then
                                    jmpT = True
                                    jmpbuf = _Str.Tsplit(NJ, 1, " ")
                                End If
                            End If
                        ElseIf Not _Str.Tsplit(NJ, 0, ">") = "" Then
                            If IsNumeric(_Str.Tsplit(NJ, 5, " ")) = True Then
                                If Geta(_Str.Tsplit(NJ, 3, " ")) > _Str.Tsplit(NJ, 5, " ") Then
                                    jmpT = True
                                    jmpbuf = _Str.Tsplit(NJ, 1, " ")
                                End If
                            Else
                                If Geta(_Str.Tsplit(NJ, 3, " ")) > Geta(_Str.Tsplit(NJ, 5, " ")) Then
                                    jmpT = True
                                    jmpbuf = _Str.Tsplit(NJ, 1, " ")
                                End If
                            End If
                        ElseIf Not _Str.Tsplit(NJ, 0, "?") = "" Then
                            If IsNumeric(_Str.Tsplit(NJ, 5, " ")) = True Then
                                If Not Geta(_Str.Tsplit(NJ, 3, " ")) = _Str.Tsplit(NJ, 5, " ") Then
                                    jmpT = True
                                    jmpbuf = _Str.Tsplit(NJ, 1, " ")
                                End If
                            Else
                                If Not Geta(_Str.Tsplit(NJ, 3, " ")) = Geta(_Str.Tsplit(NJ, 5, " ")) Then
                                    jmpT = True
                                    jmpbuf = _Str.Tsplit(NJ, 1, " ")
                                End If
                            End If
                        End If
                        GoTo escape
                    ElseIf binary = True Then

                        If _Str.Tsplit(NJ, 0, " ") = "add" Then
                            If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                                Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) + CDecimal(_Str.Tsplit(NJ, 2, " ")))
                                TextBox1.AppendText("Add : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                            End If
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "sub" Then
                            If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                                Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) - CDecimal(_Str.Tsplit(NJ, 2, " ")))
                                TextBox1.AppendText("Sub : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                            End If
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "mul" And include_local = True Then
                            If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                                Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) * CDecimal(_Str.Tsplit(NJ, 2, " ")))
                                TextBox1.AppendText("Mul : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                            End If
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "div" And include_local = True Then
                            If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                                Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) / CDecimal(_Str.Tsplit(NJ, 2, " ")))
                                TextBox1.AppendText("Div : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                            End If
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "and" Then
                            If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                                Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) And CDecimal(_Str.Tsplit(NJ, 2, " ")))
                                TextBox1.AppendText("And : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                            End If
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "or" Then
                            If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                                Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) Or CDecimal(_Str.Tsplit(NJ, 2, " ")))
                                TextBox1.AppendText("Or : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                            End If
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "not" Then
                            Put(_Str.Tsplit(NJ, 1, " "), CDecimal(CNot(CBinary(Geta(_Str.Tsplit(NJ, 1, " "))))))
                            TextBox1.AppendText("Not : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "xor" Then
                            If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                                Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) Xor CDecimal(_Str.Tsplit(NJ, 2, " ")))
                                TextBox1.AppendText("Xor : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                            End If
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "shl" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    CDecimal(CShiftLeft(Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")), _Str.Tsplit(NJ, 2, " "))))
                            TextBox1.AppendText("SHL : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "shr" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                    CDecimal(CShiftRight(Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")), _Str.Tsplit(NJ, 2, " "))))
                            TextBox1.AppendText("SHR : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        ElseIf _Str.Tsplit(NJ, 0, " ") = "msg" Then
                            MsgBox(CBinary(Geta(_Str.Tsplit(NJ, 1, " "))), MsgBoxStyle.Information)
                        End If

                    ElseIf _Str.Tsplit(NJ, 0, " ") = "add" Then
                        If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) + _Str.Tsplit(NJ, 2, " "))
                            TextBox1.AppendText("Add : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "sub" Then
                        If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) - _Str.Tsplit(NJ, 2, " "))
                            TextBox1.AppendText("Sub : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "mul" And include_local = True Then
                        If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) * _Str.Tsplit(NJ, 2, " "))
                            TextBox1.AppendText("Mul : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "div" And include_local = True Then
                        If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) / _Str.Tsplit(NJ, 2, " "))
                            TextBox1.AppendText("Div : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "and" Then
                        If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) And _Str.Tsplit(NJ, 2, " "))
                            TextBox1.AppendText("And : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "or" Then
                        If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) Or _Str.Tsplit(NJ, 2, " "))
                            TextBox1.AppendText("Or : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "not" Then
                        Put(_Str.Tsplit(NJ, 1, " "), Not Geta(_Str.Tsplit(NJ, 1, " ")))
                        TextBox1.AppendText("Not : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "xor" Then
                        If Geta(_Str.Tsplit(NJ, 2, " ")) = "eee" Then
                            Put(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ","), _
                                Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) Xor _Str.Tsplit(NJ, 2, " "))
                            TextBox1.AppendText("Xor : " & Geta(_Str.Tsplit(_Str.Tsplit(NJ, 1, " "), 0, ",")) & vbCrLf)
                        End If
                    ElseIf _Str.Tsplit(NJ, 0, " ") = "msg" Then
                        MsgBox(Geta(_Str.Tsplit(NJ, 1, " ")), MsgBoxStyle.Information)
                    End If
                End If
            Else
                If jmpbuf - 1 = Now_Jul Then
                    jmpT = False
                End If
            End If
escape:
        Next
        For G = 0 To 7
            TextBox1.AppendText("End : " & SAVINGVal(G) & vbCrLf)
        Next
    End Sub

    Private Sub Put(ByVal val As String, ByVal Value As Integer)
        If val = "eax" Then
            SAVINGVal(0) = Value
        ElseIf val = "ebx" Then
            SAVINGVal(1) = Value
        ElseIf val = "ecx" Then
            SAVINGVal(2) = Value
        ElseIf val = "edx" Then
            SAVINGVal(3) = Value
        ElseIf val = "zax" Then
            SAVINGVal(4) = Value
        ElseIf val = "zbx" Then
            SAVINGVal(5) = Value
        ElseIf val = "zcx" Then
            SAVINGVal(6) = Value
        ElseIf val = "zdx" Then
            SAVINGVal(7) = Value
        End If
    End Sub

    Private Function Geta(ByVal val As String)
        If val = "eax" Then
            Return SAVINGVal(0)
        ElseIf val = "ebx" Then
            Return SAVINGVal(1)
        ElseIf val = "ecx" Then
            Return SAVINGVal(2)
        ElseIf val = "edx" Then
            Return SAVINGVal(3)
        ElseIf val = "zax" Then
            Return SAVINGVal(4)
        ElseIf val = "zbx" Then
            Return SAVINGVal(5)
        ElseIf val = "zcx" Then
            Return SAVINGVal(6)
        ElseIf val = "zdx" Then
            Return SAVINGVal(7)
        Else
            Return "eee"
        End If

    End Function

    Private Function CAnd(ByVal binarystring1 As String, ByVal binarystring2 As String)
        Dim Value(binarystring1.Length - 1) As Char
        If binarystring1.Length >= binarystring2.Length Then
            For l_Fo = 0 To binarystring1.Length - 1
                If binarystring1(l_Fo) = binarystring2(l_Fo) Then
                    Value(l_Fo) = "1"
                ElseIf Not binarystring1(l_Fo) = binarystring2(l_Fo) Then
                    Value(l_Fo) = "0"
                End If
            Next
        Else
            For l_Fo = 0 To binarystring2.Length - 1
                If binarystring1(l_Fo) = binarystring2(l_Fo) Then
                    Value(l_Fo) = "1"
                ElseIf Not binarystring1(l_Fo) = binarystring2(l_Fo) Then
                    Value(l_Fo) = "0"
                End If
            Next
        End If
        Return Value
    End Function

    Private Function COr(ByVal binarystring1 As String, ByVal binarystring2 As String)
        Dim Value(binarystring1.Length - 1) As Char
        If binarystring1.Length >= binarystring2.Length Then
            For l_Fo = 0 To binarystring1.Length - 1
                If binarystring1(l_Fo) = "1" Or binarystring2(l_Fo) = "1" Then
                    Value(l_Fo) = "1"
                ElseIf Not binarystring1(l_Fo) = binarystring2(l_Fo) Then
                    Value(l_Fo) = "0"
                End If
            Next
        Else
            For l_Fo = 0 To binarystring2.Length - 1
                If binarystring1(l_Fo) = "1" Or binarystring2(l_Fo) = "1" Then
                    Value(l_Fo) = "1"
                ElseIf Not binarystring1(l_Fo) = binarystring2(l_Fo) Then
                    Value(l_Fo) = "0"
                End If
            Next
        End If
        Return Value
    End Function

    Private Function CXor(ByVal binarystring1 As String, ByVal binarystring2 As String)
        Dim Value(binarystring1.Length - 1) As Char
        If binarystring1.Length >= binarystring2.Length Then
            For l_Fo = 0 To binarystring1.Length - 1
                If (binarystring1(l_Fo) = "1" And binarystring2(l_Fo) = "0") Or (binarystring1(l_Fo) = "0" And binarystring2(l_Fo) = "1") Then
                    Value(l_Fo) = "1"
                ElseIf Not binarystring1(l_Fo) = binarystring2(l_Fo) Then
                    Value(l_Fo) = "0"
                End If
            Next
        Else
            For l_Fo = 0 To binarystring2.Length - 1
                If (binarystring1(l_Fo) = "1" And binarystring2(l_Fo) = "0") Or (binarystring1(l_Fo) = "0" And binarystring2(l_Fo) = "1") Then
                    Value(l_Fo) = "1"
                ElseIf Not binarystring1(l_Fo) = binarystring2(l_Fo) Then
                    Value(l_Fo) = "0"
                End If
            Next
        End If
        Return Value
    End Function

    Private Function CNot(ByVal Binary As String) As String
        Dim dwSize As UInteger = Binary.Length - 1
        Dim At As Integer = 0
        Dim bfBuffer(dwSize) As Char
        bfBuffer = Binary
        For At = 0 To dwSize
            If Binary(At) = "0" Then
                bfBuffer(At) = "1"
            ElseIf Binary(At) = "1" Then
                bfBuffer(At) = "0"
            End If
        Next
        Return bfBuffer
    End Function

    Private Function CBinary(ByVal Decimals As UInt32) As String
        Return Convert.ToString(Decimals, 2)
    End Function

    Private Function CDecimal(ByVal Binary As String) As UInt32
        Return Convert.ToUInt32(Trim(Binary), 2)
    End Function

    Private Function CShiftLeft(ByVal Binary As Integer, ByVal ShiftTime As Integer) As String
        Return Trim(Convert.ToString(Binary << ShiftTime, 2))
    End Function

    Private Function CShiftRight(ByVal Binary As Integer, ByVal ShiftTime As Integer) As String
        Return Trim(Convert.ToString(Binary >> ShiftTime, 2))
    End Function



End Class
