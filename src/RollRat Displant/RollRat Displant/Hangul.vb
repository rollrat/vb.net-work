'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Module Hangul

    '   UTF-16

    '
    '   Stupid Processing
    '       나ㄹ -> skf -> 날
    '       "나ㄹ"는 영어로 skf가 되며, 이걸 다시 한글로 고치면 "날"이 됩니다.
    '       이 과정은 키보드의 글자밖의 영향을 받으므로 정상적인 번역이 불가능합니다.
    '

    '   두벌식, 세벌식 지원

    Public IndexHangulLetter As Char() = {"ㄱ"c, "ㄲ"c, "ㄳ"c, "ㄴ"c, "ㄵ"c, "ㄶ"c, "ㄷ"c, "ㄸ"c, _
                                          "ㄹ"c, "ㄺ"c, "ㄻ"c, "ㄼ"c, "ㄽ"c, "ㄾ"c, "ㄿ"c, "ㅀ"c, _
                                          "ㅁ"c, "ㅂ"c, "ㅃ"c, "ㅄ"c, "ㅅ"c, "ㅆ"c, "ㅇ"c, "ㅈ"c, _
                                          "ㅉ"c, "ㅊ"c, "ㅋ"c, "ㅌ"c, "ㅍ"c, "ㅎ"c, "ㅏ"c, "ㅐ"c, _
                                          "ㅑ"c, "ㅒ"c, "ㅓ"c, "ㅔ"c, "ㅕ"c, "ㅖ"c, "ㅗ"c, "ㅘ"c, _
                                          "ㅙ"c, "ㅚ"c, "ㅛ"c, "ㅜ"c, "ㅝ"c, "ㅞ"c, "ㅟ"c, "ㅠ"c, _
                                          "ㅡ"c, "ㅢ"c, "ㅣ"c, "ㅤ"c, "ㅥ"c, "ㅦ"c, "ㅧ"c, "ㅨ"c, _
                                          "ㅩ"c, "ㅪ"c, "ㅫ"c, "ㅬ"c, "ㅭ"c, "ㅮ"c, "ㅯ"c, "ㅰ"c, _
                                          "ㅱ"c, "ㅲ"c, "ㅳ"c, "ㅴ"c, "ㅵ"c, "ㅶ"c, "ㅷ"c, "ㅸ"c, _
                                          "ㅹ"c, "ㅺ"c, "ㅻ"c, "ㅼ"c, "ㅽ"c, "ㅾ"c, "ㅿ"c, "ㆀ"c, _
                                          "ㆁ"c, "ㆂ"c, "ㆃ"c, "ㆄ"c, "ㆅ"c, "ㆆ"c, "ㆇ"c, "ㆈ"c, _
                                          "ㆉ"c, "ㆊ"c, "ㆋ"c, "ㆌ"c, "ㆍ"c, "ㆎ"c}
    Public IndexHangulLetterCh2 As String() = {"r", "R", "rt", "s", "sw", "sg", "e", "E", _
                                              "f", "fr", "fa", "fq", "ft", "fe", "fv", "fg", _
                                              "a", "q", "Q", "qt", "t", "T", "d", "w", _
                                              "W", "c", "z", "e", "v", "g", "k", "o", _
                                              "i", "O", "j", "p", "u", "P", "h", "hk", _
                                              "ho", "hl", "y", "n", "nj", "np", "nl", "b", _
                                              "m", "ml", "l", " ", "ss", "se", "st", " ", _
                                              "frt", "fe", "fqt", " ", "fg", "aq", "at", " ", _
                                              " ", "qr", "qe", "qtr", "qte", "qw", "qe", " ", _
                                              " ", "tr", "ts", "te", "tq", "tw", " ", "dd", _
                                              "d", "dt", " ", " ", "gg", " ", "yi", "yO", _
                                              "yl", "bu", "bP", "bl"}
    Public IndexHangulLetterCh3 As String() = {"k", "kk", "kn", "h", "hl", "hm", "u", "uu", _
                                               "y", "yk", "yi", "y;", "yn", "y'", "yp", "ym", _
                                               "i", ";", ";;", ";n", "n", "nn", "j", "l", _
                                               "ll", "o", "0", "'", "p", "m", "f", "r", _
                                               "6", "G", "t", "c", "e", "&", "v", "vf", _
                                               "vr", "vd", "4", "b", "bt", "bc", "bd", "5", _
                                               "g", "8", "d"}



    Public IndexHangulInitial As Char() = {"ㄱ"c, "ㄲ"c, "ㄴ"c, "ㄷ"c, "ㄸ"c, "ㄹ"c, "ㅁ"c, "ㅂ"c, _
                                           "ㅃ"c, "ㅅ"c, "ㅆ"c, "ㅇ"c, "ㅈ"c, "ㅉ"c, "ㅊ"c, "ㅋ"c, _
                                           "ㅌ"c, "ㅍ"c, "ㅎ"c}
    Public IndexHangulInitialCh2 As Char() = {"r"c, "R"c, "s"c, "e"c, "E"c, "f"c, "a"c, "q"c, _
                                              "Q"c, "t"c, "T"c, "d"c, "w"c, "W"c, "c"c, "z"c, _
                                              "x"c, "v"c, "g"c}
    Public IndexHangulInitialCh3 As String() = {"k", "K", "h", "u", "uu", "y", "i", ";", _
                                                ";;", "n", "nn", "j", "l", "ll", "o", "0", _
                                                "'", "p", "m"}
    Public IndexHangulInitialDu3 As Char() = {"u"c, ";"c, "n"c, "l"c}



    Public IndexHangulMedial As Char() = {"ㅏ"c, "ㅐ"c, "ㅑ"c, "ㅒ"c, "ㅓ"c, "ㅔ"c, "ㅕ"c, "ㅖ"c, _
                                          "ㅗ"c, "ㅘ"c, "ㅙ"c, "ㅚ"c, "ㅛ"c, "ㅜ"c, "ㅝ"c, "ㅞ"c, _
                                          "ㅟ"c, "ㅠ"c, "ㅡ"c, "ㅢ"c, "ㅣ"c, "ㅢ"c}
    Public IndexHangulMedialCh2 As String() = {"k", "o", "i", "O", "j", "p", "u", "P", _
                                               "h", "hk", "ho", "hl", "y", "n", "nj", "np", _
                                               "nl", "b", "m", "ml", "l"}
    Public IndexHangulMedialDu2 As Char() = {"k"c, "o"c, "l"c, "j"c, "p"c}
    Public IndexHangulMedialCh3 As String() = {"f", "r", "6", "G", "t", "c", "e", "7", _
                                               "v", "vf", "vr", "vd", "4", "b", "bt", "bc", _
                                               "bd", "5", "g", "gd", "d"}
    Public IndexHangulMedialDu3 As Char() = {"f"c, "r"c, "d"c, "t"c, "c"c}



    Public IndexHangulFinal As Char() = {"", "ㄱ"c, "ㄲ"c, "ㄳ"c, "ㄴ"c, "ㄵ"c, "ㄶ"c, "ㄷ"c, _
                                         "ㄹ"c, "ㄺ"c, "ㄻ"c, "ㄼ"c, "ㄽ"c, "ㄾ"c, "ㄿ"c, "ㅀ"c, _
                                         "ㅁ"c, "ㅂ"c, "ㅄ"c, "ㅅ"c, "ㅆ"c, "ㅇ"c, "ㅈ"c, "ㅊ"c, _
                                         "ㅋ"c, "ㅌ"c, "ㅍ"c, "ㅎ"c}
    Public IndexHangulFinalCh2 As String() = {"", "r", "R", "rt", "s", "sw", "sg", "e", _
                                              "f", "fr", "fa", "fq", "ft", "fx", "fv", "fg", _
                                              "a", "q", "qt", "t", "T", "d", "w", "c", _
                                              "z", "x", "v", "g"}
    Public IndexHangulFinalDu2 As Char() = {"t"c, "w"c, "g"c, "r"c, "a"c, "q"c, "x"c, "v"c}
    Public IndexHangulFinalCh3 As String() = {"", "x", "xx", "xq", "s", "E", "S", "A", _
                                              "w", "wx", "wz", "w3", "wq", "wW", "wQ", "w1", _
                                              "z", "3", "3q", "q", "2", "a", "#", "Z", _
                                              "C", "W", "Q", "1"}
    Public IndexHangulFinalCh3Do As String() = {"", "x", "!", "V", "s", "E", "S", "A", _
                                              "w", "@", "F", "D", "T", "%", "$", "R", _
                                              "z", "3", "X", "q", "qq", "a", "#", "Z", _
                                              "C", "W", "Q", "1"}
    Public IndexHangulFinalDu3 As Char() = {"x"c, "q"c}



    Public IndexNumberic3 As Char() = {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c}
    Public IndexNumbericCh3 As Char() = {"H"c, "J"c, "K"c, "L"c, ":"c, "Y"c, "U"c, "I"c, "O"c, "P"c}
    Public IndexSymbol3 As Char() = {"*", "=", """", """", "'", "~", ")", ">", _
                                     ":", "(", "<", ",", ".", "!", "?", "※", _
                                     ";", "+", "\", "%", "/", ",", "."}
    Public IndexSymbolCh3 As Char() = {"`", "^", "&", "*", "(", ")", "-", "=", _
                                       "\", "[", "]", ",", ".", "?", "B", "~", _
                                       "_", "+", "|", "{", "}", "<", ">"}

    Public _SafeLetterExecuative As Boolean = True

    Public Structure Hangul_Initial
        Dim initial As Integer
        Dim medial As Integer
        Dim final As Integer
    End Structure

    Public Const Hangul_unicode_magic As Integer = &HAC00

    Public Function hangul_combination(hi As Hangul_Initial) As Char
        Return ChrW(Hangul_unicode_magic + hi.initial * 21 * 28 + hi.medial * 28 + hi.final)
    End Function

    Public Function hangul_comination(initial As Integer, medial As Integer, final As Integer) As Char
        Return ChrW(Hangul_unicode_magic + initial * 21 * 28 + medial * 28 + final)
    End Function

    Public Function hangul_distortion(hi As Char) As Hangul_Initial
        Dim rethi As Hangul_Initial
        Dim unis As Integer = AscW(hi) - Hangul_unicode_magic
        ' / : 반올림하는 연산
        ' \ : 내림하는 연산(라운딩 강제 삭제), (C언어의 /와 같음)
        rethi.initial = unis \ (21 * 28)
        rethi.medial = (unis Mod (21 * 28)) \ 28
        rethi.final = (unis Mod (21 * 28)) Mod 28
        Return rethi
    End Function

    ' eng ch to hangul
    Public Function hangul_assembly(hhh As String) As String
        Dim retstr As String = ""

        For i As Integer = 0 To hhh.Length - 1
            Dim initial As Integer = -1
            Dim medial As Integer = -1
            Dim final As Integer = -1


            ' 초성검사
            initial = findifexist(IndexHangulInitialCh2, hhh(i))
            If initial < 0 Then

                '초성이 없는 경우 불안정 문자로 인식함
                If _SafeLetterExecuative Then _
                    retstr += hhh(i) : Continue For

                '중성검사(중성만 있는 모음을 식별하기 위함)
                medial = findifexist(IndexHangulMedialCh2, hhh(i))

                If medial < 0 Then retstr += hhh(i) _
                    Else retstr += IndexHangulMedial(medial)
                Continue For
            End If
            If hhh.Length - 1 = i Then
                retstr += IndexHangulInitial(initial)
                Exit For
            End If
            i += 1


            '중성검사
            medial = findifexist(IndexHangulMedialCh2, hhh(i))
            If medial < 0 Then
                retstr += IndexHangulInitial(initial)
                i -= 1
                Continue For
            End If
            If hhh.Length - 1 = i Then
                retstr += hangul_comination(initial, medial, 0)
                Continue For
            ElseIf hhh.Length - 1 <> i Then
                If IndexHangulMedialDu2.Contains(hhh(i + 1)) Then _
                    jksaveput(hhh(i) & hhh(i + 1), IndexHangulMedialCh2, medial, i)
            End If
            If hhh.Length - 1 = i Then
                retstr += hangul_comination(initial, medial, 0)
                Exit For
            End If
            i += 1


            '다다음글자, 다다다음글자가 중성인가?
            '
            '   2개의 중성이 연달아 나올 경우 겹문자가 될 수 있거나
            '   다음 문자의 초성이 될 수 있으므로 반드시 검사해야 한다.
            '   그 예로 '닭이다'와 '달기다'에서 전자는 중성으로만 이루어진
            '   '이'문자를 다음 문자로 둠으로 ㄺ에서 ㄹ+ㄱ으로 분리되면 
            '   안되지만, 후자에선 ㄺ에서 ㄱ이 분리되지 않으면 모음만
            '   존재하게 되므로 '닭ㅣ다'라는 글자가 나오게 된다.
            '
            Dim stop_force As Boolean = False
            If hhh.Length - 1 >= i + 1 Then
                If IndexHangulMedialCh2.Contains(hhh(i + 1)) Then
                    i -= 1
                    retstr += hangul_comination(initial, medial, 0)
                    Continue For
                ElseIf hhh.Length - 1 >= i + 2 Then
                    ' 다다다음글자가 중성이므로 종성이 2글자인 경우가 없어야한다.
                    If IndexHangulMedialCh2.Contains(hhh(i + 2)) Then _
                        stop_force = True
                End If
            End If


            '종성검사
            final = findifexist(IndexHangulFinalCh2, hhh(i))
            If final < 0 Then
                retstr += hangul_comination(initial, medial, 0)
                i -= 1
                Continue For
            End If
            If hhh.Length - 1 >= i + 1 AndAlso Not stop_force Then _
                If IndexHangulFinalDu2.Contains(hhh(i + 1)) Then _
                    jksaveput(hhh(i) & hhh(i + 1), IndexHangulFinalCh2, final, i)
            retstr += hangul_comination(initial, medial, final)
        Next

        Return retstr
    End Function

    ' eng ch to hangul
    Public Function hangul_assembly3(hhh As String) As String
        Dim retstr As String = ""

        For i As Integer = 0 To hhh.Length - 1
            Dim initial As Integer = -1
            Dim medial As Integer = -1
            Dim final As Integer = -1

            ' 초성검사
            initial = findifexist(IndexHangulInitialCh3, hhh(i))
            If initial < 0 Then

                '중성검사(중성만 있는 모음을 식별하기 위함)
                medial = findifexist(IndexHangulMedialCh3, hhh(i))
                If medial < 0 Then

                    ' 세 벌식 기호, 숫자 식별
                    Dim num_sym As Integer = -1
                    num_sym = findifexist(IndexNumbericCh3, hhh(i))

                    If num_sym >= 0 Then
                        retstr += IndexNumberic3(num_sym)
                    Else
                        num_sym = findifexist(IndexSymbolCh3, hhh(i))
                        If num_sym >= 0 Then retstr += IndexSymbol3(num_sym) _
                            Else retstr += hhh(i)
                    End If

                Else

                    '초성이 없는 경우 불안정 문자로 인식함
                    If _SafeLetterExecuative Then _
                        retstr += hhh(i) : Continue For

                    retstr += IndexHangulMedial(medial)
                End If
                Continue For
            End If
            If hhh.Length - 1 = i Then
                retstr += IndexHangulInitial(initial)
                Exit For
            ElseIf hhh.Length - 1 <> i Then
                If IndexHangulInitialDu3.Contains(hhh(i + 1)) Then _
                    jksaveput(hhh(i) & hhh(i + 1), IndexHangulInitialCh3, initial, i)
            End If
            i += 1


            '중성검사
            Dim ntx = hhh(i)
            medial = findifexist(IndexHangulMedialCh3, ntx)
            If medial < 0 Then

                ' 예외처리
                If hhh(i) = "8" Then
                    medial = findifexist(IndexHangulMedialCh3, "gd")
                ElseIf hhh(i) = "9" Then
                    medial = findifexist(IndexHangulMedialCh3, "b")
                    ntx = "b"
                ElseIf hhh(i) = "/" Then
                    medial = findifexist(IndexHangulMedialCh3, "v")
                    ntx = "v"c
                Else
                    retstr += IndexHangulInitial(initial)
                    i -= 1
                    Continue For
                End If
            End If
            If hhh.Length - 1 = i Then
                retstr += hangul_comination(initial, medial, 0)
                Continue For
            ElseIf hhh.Length - 1 <> i Then
                If IndexHangulMedialDu3.Contains(hhh(i + 1)) Then _
                    jksaveput(ntx & hhh(i + 1), IndexHangulMedialCh3, medial, i)
            End If
            If hhh.Length - 1 = i Then
                retstr += hangul_comination(initial, medial, 0)
                Exit For
            End If
            i += 1


            '다다음글자, 다다다음글자가 중성인가?
            Dim stop_force As Boolean = False
            If hhh.Length - 1 >= i + 1 Then
                If IndexHangulMedialCh3.Contains(hhh(i + 1)) Then
                    i -= 1
                    retstr += hangul_comination(initial, medial, 0)
                    Continue For
                ElseIf hhh.Length - 1 >= i + 2 Then
                    ' 다다다음글자가 중성이므로 종성이 2글자인 경우가 없어야한다.
                    If IndexHangulMedialCh3.Contains(hhh(i + 2)) Then _
                        stop_force = True
                End If
            End If


            '종성검사
            final = findifexist(IndexHangulFinalCh3, hhh(i))
            If final < 0 Then

                '겹받침 검사
                final = findifexist(IndexHangulFinalCh3Do, hhh(i))
                If final < 0 Then
                    retstr += hangul_comination(initial, medial, 0)
                    i -= 1
                    Continue For
                End If
            End If
            If hhh.Length - 1 >= i + 1 AndAlso Not stop_force Then _
                If IndexHangulFinalDu3.Contains(hhh(i + 1)) Then _
                    jksaveput(hhh(i) & hhh(i + 1), IndexHangulFinalCh3, final, i)
            retstr += hangul_comination(initial, medial, final)
        Next

        Return retstr
    End Function

    '
    '   _array에 _item이 포함되어있으면 해당 인덱스의 오프셋을, 아니면 -1를 리턴함
    '
    Private Function findifexist(_array As Object, _item As Object) As Integer
        For i As Integer = 0 To _array.Length - 1
            If _array(i) = _item Then
                Return i
            End If
        Next
        Return -1
    End Function

    '
    '   _condition이 true이면 _what을 _true에 대입하고 false이면 _false에다 대입함
    '
    Private Sub selectiveput(_condition As Boolean, _what As Object, ByRef _true As Object, ByRef _false As Object)
        If _condition Then _true = _what Else _false = _what
    End Sub

    '
    '   jk_str이 _array에 포함된 경우 해당 정보를 _byput에 넣고 _i를 1만큼 증가시킴
    '
    Private Sub jksaveput(jk_str As String, _array As Object, ByRef _byput As Object, ByRef _i As Integer)
        Dim save As Integer
        save = findifexist(_array, jk_str)
        If save >= 0 Then _byput = save : _i += 1
    End Sub

    Public Function hangul_disassembly(ByVal letter As Char) As String
        If hangul_is_letter(letter) Then
            Dim hi As Hangul_Initial = hangul_distortion(letter)
            Return IndexHangulInitialCh2(hi.initial) & IndexHangulMedialCh2(hi.medial) & IndexHangulFinalCh2(hi.final)
        ElseIf hangul_is_jamo31(letter) Then
            Dim unis As Integer = AscW(letter)
            Return IndexHangulLetterCh2(unis - &H3131)
        Else
            Dim unis As Integer = AscW(letter)
            Return IndexHangulLetterCh2(unis - &H1100)
        End If
        Return ""
    End Function

    Public Function hangul_disassembly3(ByVal letter As Char) As String
        If hangul_is_letter(letter) Then
            Dim hi As Hangul_Initial = hangul_distortion(letter)
            Return IndexHangulInitialCh3(hi.initial) & IndexHangulMedialCh3(hi.medial) & IndexHangulFinalCh3(hi.final)
        ElseIf hangul_is_jamo31(letter) Then
            Dim unis As Integer = AscW(letter)
            Return IndexHangulLetterCh3(unis - &H3131)
        ElseIf hangul_is_jamo11(letter) Then
            Dim unis As Integer = AscW(letter)
            Return IndexHangulLetterCh3(unis - &H1100)
        Else
            Dim num_sym As Integer = -1
            For i As Integer = 0 To IndexNumberic3.Length - 1
                If IndexNumberic3(i) = letter Then
                    num_sym = i
                    Exit For
                End If
            Next
            If num_sym >= 0 Then Return IndexNumbericCh3(num_sym)
            For i As Integer = 0 To IndexSymbol3.Length - 1
                If IndexSymbol3(i) = letter Then
                    num_sym = i
                    Exit For
                End If
            Next
            If num_sym >= 0 Then Return IndexSymbolCh3(num_sym)
        End If
        Return ""
    End Function

    Public Function hangul_is(ByVal letter As Char) As Boolean
        Dim unis As Integer = AscW(letter)
        If Not _SafeLetterExecuative Then
            If &HAC00 <= unis AndAlso unis <= &HD7FB Then
                Return True
            ElseIf &H3131 <= unis AndAlso unis <= &H3163 Then
                Return True
            ElseIf &H1100 <= unis AndAlso unis <= &H11FF Then   ' ?? what tf??
                Return True
            End If
        Else
            If &HAC00 <= unis AndAlso unis <= &HD7FB Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function hangul_is3(ByVal letter As Char) As Boolean
        Dim unis As Integer = AscW(letter)
        If Not _SafeLetterExecuative Then
            If &HAC00 <= unis AndAlso unis <= &HD7FB Then
                Return True
            ElseIf &H3131 <= unis AndAlso unis <= &H3163 Then
                Return True
            ElseIf &H1100 <= unis AndAlso unis <= &H11FF Then   ' ?? what tf??
                Return True
            ElseIf IndexNumberic3.Contains(letter) Or IndexSymbol3.Contains(letter) Then
                Return True
            End If
        Else
            If &HAC00 <= unis AndAlso unis <= &HD7FB Then
                Return True
            ElseIf IndexNumberic3.Contains(letter) Or IndexSymbol3.Contains(letter) Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function hangul_is_letter(ByVal letter As Char) As Boolean
        Dim unis As Integer = AscW(letter)
        If &HAC00 <= unis AndAlso unis <= &HD7FB Then
            Return True
        End If
        Return False
    End Function

    Public Function hangul_is_jamo31(ByVal letter As Char) As Boolean
        Dim unis As Integer = AscW(letter)
        If &H3131 <= unis AndAlso unis <= &H3163 Then
            Return True
        End If
        Return False
    End Function

    Public Function hangul_is_jamo11(ByVal letter As Char) As Boolean
        Dim unis As Integer = AscW(letter)
        If &H1100 <= unis AndAlso unis <= &H11FF Then   ' ?? what tf??
            Return True
        End If
        Return False
    End Function

End Module
