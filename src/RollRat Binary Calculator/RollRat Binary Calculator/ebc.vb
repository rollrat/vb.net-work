Imports RollRat_Vb_Api.RollRat_Vb_Api

Public Class ebc

    Private OnlyEJinSu As Boolean = True

    Private Max_Round_Floating As Integer = &H100

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Me.Size = New Size(New Point(551, 465))
        Else
            Me.Size = New Size(New Point(551, 188))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Max As Integer = Convert.ToUInt32(TextBox3.Text)

        TextBox2.Text = SolveAll(Max, SolveParenthesis(TextBox1.Text))

    End Sub

    Private Function NotLogicWithScale(ByVal Binary As String) As String
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

    Private Function SplitN(ByVal Text, ByVal Op, ByVal Len) As String
        ' 예외, 오류를 처리하기위해 SplitN을 만듬
        On Error Resume Next
        If _NS.GetAllOfThings(Text, Op) = 0 Then
            Return ""
        End If
        Return Split(Text, Op)(Len)
    End Function

    Private Function SplitNs(ByVal Text, ByVal Op, ByVal Len) As String
        ' 예외, 오류를 처리하기위해 SplitN을 만듬
        On Error Resume Next
        If _NS.GetAllOfThings(Text, Len) = 0 Then
            Return ""
        End If
        Return Split(Text, Len)(Op)
    End Function

    Private Function Changer(ByVal A As String, ByVal B As String, ByVal C As String, ByVal Length As Integer)
        ' Replace를 그냥 쓰면 않된다는걸 명심하자.
        Dim objX As New System.Text.StringBuilder(A)
        Dim objY As System.Text.StringBuilder
        objY = objX
        objX.Replace(B, C, 0, Length)
        Return objY.ToString
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            OnlyEJinSu = True
        Else
            OnlyEJinSu = False
        End If
    End Sub

    Private Function CFloat(ByVal floatingpointnumber As Double) As String
        Dim round As Integer = 0
        Dim Value(Max_Round_Floating - 1) As Char
        For round = 0 To Max_Round_Floating - 1
            floatingpointnumber *= 2
            If floatingpointnumber > 1 Then
                Value(round) = "1"
                floatingpointnumber -= 1
            ElseIf floatingpointnumber < 1 Then
                Value(round) = "0"
            ElseIf floatingpointnumber = 1 Then
                Value(round) = "1"
                Return Value
            End If
        Next
        Return Value
    End Function

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Clipboard.SetText(Label8.Text)
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Clipboard.SetText(Label9.Text)
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Clipboard.SetText(Label14.Text)
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Clipboard.SetText(Label12.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label8.Text = Convert.ToString(Convert.ToInt32(TextBox4.Text, 2) And _
                      Convert.ToUInt32(TextBox5.Text, 2), 2)
        Label9.Text = Convert.ToString(Convert.ToInt32(TextBox4.Text, 2) And _
                      Convert.ToUInt32(TextBox5.Text, 2), 2)
        Label14.Text = Convert.ToString(Convert.ToUInt32(TextBox4.Text, 2) + Convert.ToUInt32(TextBox5.Text, 2), 2)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Max_Round_Floating = TextBox7.Text
        If Convert.ToDouble(TextBox6.Text) > 1 Then
            MsgBox("입력값은 0이하의 수입니다. ", MsgBoxStyle.Critical)
        Else
            Label12.Text = "0." & CFloat(Convert.ToDouble(TextBox6.Text))
        End If
    End Sub

    Private Function SolveAll(ByVal Max As Integer, ByVal Texts As String) As String

        Dim Value As Integer = 0
        Dim Text As String = Texts

        Try

            Do
                '*******************************************************
                '
                '&rollrat <regularly binary expression>
                '    알고리즘난이도 : ☆☆★★★
                '
                '%% 오류 보고(OnlyEJunSu True(T) or False(F))
                '  F 부정논리오류 : 미리 정해져있지 않은 크기로 Not을 실행하면 산술오류가 뜬다.(T는 오류없음)
                '       해결방안 : 
                '                   1. \d\ 를 이용하여 크기를 지정한다. 이때 크기는 32bit의 크기가된다.
                '                   2. 지정크기 부정논리연산 함수를 이용한다. 예제 NotLogicWithScale(dwNothing)
                '
                '       팁 : NAnd를 사용하기전에 And ~ Not을 이용하거나, 직접 Not을 주는 \n\을 이용한다.
                '
                '*******************************************************
                If OnlyEJinSu = False Then
                    '<!--
                    '   And 값
                    '--!>
                    If _Str.Tsplit(Text, 1, " ") = "And" Then
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\b\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\b\")(1), 2) And _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, "\b\" & Split(_Str.Tsplit(Text, 0, " "), "\b\")(1) & " And " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\b\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Value And _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, " And " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        End If
                        '
                        '@#$십진수 <! ! !--
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\d\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\d\")(1), 10) And _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, "\d\" & Split(_Str.Tsplit(Text, 0, " "), "\d\")(1) & " And " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\d\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Value And _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, " And " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        End If
                    End If
                    '<!--
                    '   Or 값
                    '--!>
                    If _Str.Tsplit(Text, 1, " ") = "Or" Then
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\b\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\b\")(1), 2) Or _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, "\b\" & Split(_Str.Tsplit(Text, 0, " "), "\b\")(1) & " Or " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\b\")(1).Length + 4 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Value Or _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, " Or " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                         4 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        End If
                        '
                        '@#$십진수 <! ! !--
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\d\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\d\")(1), 10) Or _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, "\d\" & Split(_Str.Tsplit(Text, 0, " "), "\d\")(1) & " Or " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\d\")(1).Length + 4 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Value Or _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, " Or " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        4 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        End If
                    End If
                    '<!--
                    '   Xor 값
                    '--!>
                    If _Str.Tsplit(Text, 1, " ") = "Xor" Then
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\b\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\b\")(1), 2) Xor _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, "\b\" & Split(_Str.Tsplit(Text, 0, " "), "\b\")(1) & " Xor " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\b\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Value Xor _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, " Xor " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        End If
                        '
                        '@#$십진수 <! ! !--
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\d\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\d\")(1), 10) Xor _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, "\d\" & Split(_Str.Tsplit(Text, 0, " "), "\d\")(1) & " Xor " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\d\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Value Xor _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, " Xor " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        End If
                    End If
                    '<!--
                    '   NAnd 값
                    '--!>
                    If _Str.Tsplit(Text, 1, " ") = "NAnd" Then
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\b\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Not (Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\b\")(1), 2) And _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2))
                                Text = Changer(Text, "\b\" & Split(_Str.Tsplit(Text, 0, " "), "\b\")(1) & " NAnd " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\b\")(1).Length + 6 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Not (Value And _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2))
                                Text = Changer(Text, " NAnd " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        6 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        End If
                        '
                        '@#$십진수 <! ! !--
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\d\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Not (Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\d\")(1), 10) And _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10))
                                Text = Changer(Text, "\d\" & Split(_Str.Tsplit(Text, 0, " "), "\d\")(1) & " NAnd " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\d\")(1).Length + 6 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Not (Value And _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10))
                                Text = Changer(Text, " NAnd " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        6 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        End If
                    End If
                    '<!--
                    '   NOr 값
                    '--!>
                    If _Str.Tsplit(Text, 1, " ") = "NOr" Then
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\b\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Not (Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\b\")(1), 2) Or _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2))
                                Text = Changer(Text, "\b\" & Split(_Str.Tsplit(Text, 0, " "), "\b\")(1) & " NOr " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\b\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Not (Value Or _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2))
                                Text = Changer(Text, " NOr " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                         5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        End If
                        '
                        '@#$십진수 <! ! !--
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\d\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Not (Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\d\")(1), 10) Or _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10))
                                Text = Changer(Text, "\d\" & Split(_Str.Tsplit(Text, 0, " "), "\d\")(1) & " NOr " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\d\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Not (Value Or _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10))
                                Text = Changer(Text, " NOr " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        End If
                    End If
                    '<!--
                    '   XNor 값
                    '--!>
                    If _Str.Tsplit(Text, 1, " ") = "XNor" Then
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\b\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Not (Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\b\")(1), 2) Xor _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2))
                                Text = Changer(Text, "\b\" & Split(_Str.Tsplit(Text, 0, " "), "\b\")(1) & " XNor " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\b\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Not (Value Xor _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2))
                                Text = Changer(Text, " XNor " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        End If
                        '
                        '@#$십진수 <! ! !--
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\d\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Not (Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\d\")(1), 10) Xor _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10))
                                Text = Changer(Text, "\d\" & Split(_Str.Tsplit(Text, 0, " "), "\d\")(1) & " XNor " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\d\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Not (Value Xor _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10))
                                Text = Changer(Text, " XNor " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        End If
                    End If
                    '<!--
                    '   Add 값
                    '--!>
                    If _Str.Tsplit(Text, 1, " ") = "Add" Then
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\b\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\b\")(1), 2) + _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, "\b\" & Split(_Str.Tsplit(Text, 0, " "), "\b\")(1) & " Add " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\b\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Value + _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, " Add " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        End If
                        '
                        '@#$십진수 <! ! !--
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\d\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\d\")(1), 10) + _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, "\d\" & Split(_Str.Tsplit(Text, 0, " "), "\d\")(1) & " Add " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\d\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Value + _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, " Add " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        End If
                    End If
                    '<!--
                    '   Sub 값
                    '--!>
                    If _Str.Tsplit(Text, 1, " ") = "Sub" Then
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\b\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\b\")(1), 2) - _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, "\b\" & Split(_Str.Tsplit(Text, 0, " "), "\b\")(1) & " Sub " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\b\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\b\", 1) = "" Then
                                Value = Value - _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), 2)
                                Text = Changer(Text, " Sub " & "\b\" & Split(_Str.Tsplit(Text, 2, " "), "\b\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\b\")(1).Length)
                            End If
                        End If
                        '
                        '@#$십진수 <! ! !--
                        '초기값
                        If Not SplitN(_Str.Tsplit(Text, 0, " "), "\d\", 1) = "" Then
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Convert.ToUInt32(Split(_Str.Tsplit(Text, 0, " "), "\d\")(1), 10) - _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, "\d\" & Split(_Str.Tsplit(Text, 0, " "), "\d\")(1) & " Sub " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        3 + Split(_Str.Tsplit(Text, 0, " "), "\d\")(1).Length + 5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        Else '예외처리
                            If Not SplitN(_Str.Tsplit(Text, 2, " "), "\d\", 1) = "" Then
                                Value = Value - _
                                        Convert.ToUInt32(Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), 10)
                                Text = Changer(Text, " Sub " & "\d\" & Split(_Str.Tsplit(Text, 2, " "), "\d\")(1), "",
                                        5 + 3 + Split(_Str.Tsplit(Text, 2, " "), "\d\")(1).Length)
                            End If
                        End If
                    End If
                Else
                    Select Case (_Str.Tsplit(Text, 1, " ")) '그냥 식이 살아있는지 죽어있는지 확인하는단계
                        Case "And"
                            '<!--
                            '   And 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    Value = ibuf And _
                                            fbuf
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " And " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 5 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Value And _
                                        fbuf
                                Text = Changer(Text, " And " & _Str.Tsplit(Text, 2, " "), "",
                                        5 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                        Case "Or"
                            '<!--
                            '   Or 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    Value = ibuf Or _
                                            fbuf
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " Or " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 4 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Value Or _
                                        fbuf
                                Text = Changer(Text, " Or " & _Str.Tsplit(Text, 2, " "), "",
                                        4 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                        Case "Xor"
                            '<!--
                            '   And 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    Value = ibuf Xor _
                                            fbuf
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " Xor " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 5 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Value Xor _
                                        fbuf
                                Text = Changer(Text, " Xor " & _Str.Tsplit(Text, 2, " "), "",
                                        5 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@낫 연산
                        Case "NAnd"
                            '<!--
                            '   And 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    Value = Convert.ToUInt32(NotLogicWithScale(Convert.ToString(ibuf And _
                                            fbuf, 2)), 2)
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " NAnd " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 6 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Convert.ToUInt32(NotLogicWithScale(Convert.ToString(Value And _
                                        fbuf, 2)), 2)
                                Text = Changer(Text, " NAnd " & _Str.Tsplit(Text, 2, " "), "",
                                        6 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                        Case "NOr"
                            '<!--
                            '   Or 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    Value = Convert.ToUInt32(NotLogicWithScale(Convert.ToString(ibuf Or _
                                            fbuf, 2)), 2)
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " NOr " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 5 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Convert.ToUInt32(NotLogicWithScale(Convert.ToString(Value Xor _
                                        fbuf, 2)), 2)
                                Text = Changer(Text, " NOr " & _Str.Tsplit(Text, 2, " "), "",
                                        5 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                        Case "XNor"
                            '<!--
                            '   And 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    Value = Convert.ToUInt32(NotLogicWithScale(Convert.ToString(ibuf Xor _
                                            fbuf, 2)), 2)
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " XNor " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 6 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Convert.ToUInt32(NotLogicWithScale(Convert.ToString(Value Xor _
                                        fbuf, 2)), 2)
                                Text = Changer(Text, " XNor " & _Str.Tsplit(Text, 2, " "), "",
                                        6 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@연산부분
                        Case "Add"
                            '<!--
                            '   Add 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    Value = ibuf + _
                                            fbuf
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " Add " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 5 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Value + _
                                        fbuf
                                Text = Changer(Text, " Add " & _Str.Tsplit(Text, 2, " "), "",
                                        5 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                        Case "Sub"
                            '<!--
                            '   Sub 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    If ibuf < fbuf Then
                                        MsgBox("빼기 연산중 오류가 발생하였습니다. 값은 -가 될 수 없었습니다.", MsgBoxStyle.Critical)
                                        Return 0
                                    End If
                                    Value = ibuf - _
                                            fbuf
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " Sub " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 5 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Value - _
                                        fbuf
                                Text = Changer(Text, " Sub " & _Str.Tsplit(Text, 2, " "), "",
                                        5 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                        Case "Mul"
                            '<!--
                            '   Mul 값 $ Only 2
                            '--!>
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    Value = ibuf * _
                                            fbuf
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " Mul " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 5 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Value * _
                                        fbuf
                                Text = Changer(Text, " Mul " & _Str.Tsplit(Text, 2, " "), "",
                                        5 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                        Case "Div"
                            '<!--
                            '   Div 값 $ Only 2
                            '--!>
                            Dim VBuf As Double = 0
                            If Not _Str.Tsplit(Text, 0, " ") = "" Then
                                If Not _Str.Tsplit(Text, 2, " ") = "" Then
                                    Dim ibuf As UInt32 = 0
                                    Dim fbuf As UInt32 = 0
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 0, " "), 0, "''") = "" Then
                                        ibuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 0, " "), 0, "''"), 2)
                                        Text = Changer(SplitNs(Text, 0, " "), "''", "", SplitNs(SplitNs(Text, 0, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 0, " "), 0, "'") = "" Then
                                        ibuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 0, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 0, " "), 0, "'").Length + 1)
                                    Else
                                        ibuf = Convert.ToUInt32(_Str.Tsplit(Text, 0, " "), 2)
                                    End If
                                    '''''''
                                    If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                        fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                        Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                    ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                        fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                        Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                    Else
                                        fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                    End If
                                    '''''''
                                    VBuf = ibuf / _
                                           fbuf
                                    If VBuf > 1 Then
                                        Return Convert.ToString(Convert.ToUInt32(_Str.Tsplit(Convert.ToString(VBuf), 0, "."), 2)) & _
                                                          "." & CFloat(Convert.ToDouble("0." & _Str.Tsplit(Convert.ToString(VBuf), 1, ".")))
                                        '연산은 한번만 할 수 있게 바꿈
                                    Else
                                        Return CFloat(VBuf)
                                        '연산은 한번만 할 수 있게 바꿈
                                    End If
                                    Text = Changer(Text, _Str.Tsplit(Text, 0, " ") & " Div " & _Str.Tsplit(Text, 2, " "), "",
                                            _Str.Tsplit(Text, 0, " ").Length + 5 + _Str.Tsplit(Text, 2, " ").Length)
                                End If
                            Else '예외처리
                                Dim fbuf As UInt32 = 0
                                If Not SplitNs(SplitNs(Text, 2, " "), 0, "''") = "" Then
                                    fbuf = Not Convert.ToUInt32(SplitNs(SplitNs(Text, 2, " "), 0, "''"), 2)
                                    Text = Changer(Text, "''", "", SplitNs(SplitNs(Text, 2, " "), 0, "''").Length + 1)
                                ElseIf Not SplitNs(SplitNs(Text, 2, " "), 0, "'") = "" Then
                                    fbuf = Convert.ToUInt32(NotLogicWithScale(SplitNs(SplitNs(Text, 2, " "), 0, "'")), 2)
                                    Text = Changer(Text, "'", "", SplitNs(SplitNs(Text, 2, " "), 0, "'").Length + 1)
                                Else
                                    fbuf = Convert.ToUInt32(_Str.Tsplit(Text, 2, " "), 2)
                                End If
                                '''''''
                                Value = Value / _
                                        fbuf
                                Text = Changer(Text, " Div " & _Str.Tsplit(Text, 2, " "), "",
                                        5 + _Str.Tsplit(Text, 2, " ").Length)
                            End If
                            '셀렉트문 종료( 중복처리 금지 )
                            Exit Select
                        Case "Not"
                            '<!--
                            '   Not 값 $ Only 2
                            '--!>
                            Value = Convert.ToUInt32(NotLogicWithScale(Convert.ToString(Value, 2)), 2)
                            Text = Changer(Text, " Not", "", 1 + 3)
                            Exit Select
                        Case """"
                            '<!--
                            '   Not 값 $ Only 2
                            '--!>
                            Value = Convert.ToUInt32(NotLogicWithScale(Convert.ToString(Value, 2)), 2)
                            Text = Changer(Text, " """, "", 1 + 1)
                            Exit Select
                        Case """"""
                            '<!--
                            '   Not 값 $ Only 2
                            '--!>
                            Value = Not Value
                            Text = Changer(Text, " """"", "", 2 + 1)
                            Exit Select
                    End Select
                End If

                Max -= 1

            Loop Until Max = 0

            Return Convert.ToString(Value, 2)

        Catch ex As Exception

            MsgBox("연산중 오류가 발생하였습니다. 오류 : " & ex.Message, MsgBoxStyle.Critical)

        End Try

    End Function

    Private Function SolveParenthesis(ByVal Texts As String) As String

        Dim Value As Integer = 0
        Dim ReturnText As String = ""
        Dim Text As String = Texts

        Dim fText As String = Text
        Dim fGetPthLen As Integer = _NS.GetAllOfThings(fText, "(")
        Dim fBuf(fGetPthLen) As String

        For l_Fo = 0 To fGetPthLen - 1

            Dim mText As String = fText
            Dim mGetPthLen As Integer = _NS.GetAllOfThings(mText, "[")
            Dim mBuf(mGetPthLen) As String

            If mGetPthLen = 0 Then GoTo Db

            For fl_Fo = 0 To mGetPthLen - 1

                Dim dText As String = mText
                Dim dGetPthLen As Integer = _NS.GetAllOfThings(dText, "{")
                Dim dBuf(dGetPthLen) As String

                If dGetPthLen = 0 Then GoTo Da

                For lfl_Fo = 0 To dGetPthLen - 1
                    dBuf(lfl_Fo) = _Str.Tsplit(_Str.Tsplit(dText, 1, "{"), 0, "}")
                    dText = _Str.Changer(dText, "{" & dBuf(lfl_Fo) & "}", "")
                    Text = _Str.Changer(Text, "{" & dBuf(lfl_Fo) & "}", SolveAll(10, dBuf(lfl_Fo)))
                    mText = Text
                Next

Da:

                mBuf(fl_Fo) = _Str.Tsplit(_Str.Tsplit(mText, 1, "["), 0, "]")
                mText = _Str.Changer(mText, "[" & mBuf(fl_Fo) & "]", "")
                Text = _Str.Changer(Text, "[" & mBuf(fl_Fo) & "]", SolveAll(10, mBuf(fl_Fo)))

                fText = Text

            Next

Db:

            fBuf(l_Fo) = _Str.Tsplit(_Str.Tsplit(fText, 1, "("), 0, ")")
            fText = _Str.Changer(fText, "(" & fBuf(l_Fo) & ")", "")
            Text = _Str.Changer(Text, "(" & fBuf(l_Fo) & ")", SolveAll(10, fBuf(l_Fo)))

        Next

        Return Text

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
        Return Convert.ToUInt32(Binary, 2)
    End Function

    Private Function CShiftLeft(ByVal Binary As String, ByVal ShiftTime As Integer) As String
        If ShiftTime = 0 Then
            Return Binary
        Else
            Dim dwfBuffer(Binary.Length - 1 + ShiftTime) As Char
            For l_Lof = 0 To Binary.Length - 1
                If Binary(l_Lof) = "0" Then
                    dwfBuffer(l_Lof) = "0"
                ElseIf Binary(l_Lof) = "1" Then
                    dwfBuffer(l_Lof) = "1"
                End If
            Next
            For l_Lof = ShiftTime - 1 To Binary.Length + ShiftTime - 1
                dwfBuffer(l_Lof) = "0"
            Next
            Return dwfBuffer
        End If
    End Function

    Private Function CShiftRight(ByVal Binary As String, ByVal ShiftTime As Integer) As String
        Return Convert.ToString(Convert.ToUInt32(Binary, 2) >> ShiftTime, 2)
    End Function

    Private Sub ebc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
