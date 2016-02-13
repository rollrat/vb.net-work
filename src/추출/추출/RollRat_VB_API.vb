Imports System.Windows.Forms
Imports Microsoft
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Threading
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Net.Sockets.SocketException
Imports System.CodeDom.Compiler
Imports System.Net.Mail
Imports System.Drawing.Drawing2D

Public Class RollRat_Vb_Api

    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@
    '@      RollRat Software Subrutines Dynamic Linked Library
    '@
    '@      This Program is made rollrat at 2012/12/09/2:12 P.M.
    '@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@
    '@      Lastest : 2012/12/30/1:21 A.M.
    '@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    '                   [------ Version 1.6.1 ------]
    '
    'XML Main Annotation is Hangul.

#Region " DLL ROUTINE "

#Region " Code "

    Public Class _Str

        ''' <summary>
        ''' 'split'의 확장된 기능으로서, 
        ''' 한 문자를 기준으로 다른 문장이나 단어를 가져옵니다.
        ''' </summary>
        ''' <param name="e">split할 문장입니다.</param>
        ''' <param name="f">c값과 동일하게 넣어주시면됩니다.</param>
        ''' <param name="c">0부터 시작하며 몇번째 있는 값을 가져올건지 설정합니다.</param>
        ''' <param name="d">어떤 문자를 기준으로 할지 설정합니다.</param>
        ''' <returns></returns>
        ''' <remarks>splitfuntions</remarks>
        Shared Function Split(ByVal e, ByVal f, ByVal c, ByVal d)
            On Error Resume Next
            Dim Result As String
            Dim Splitdata As String() = New String() {f}
            Dim Pdata As Char() = New Char() {d}
            Result = e
            Splitdata = Result.Split(Pdata)
            Return Splitdata(c)
        End Function

        ''' <summary>
        ''' 'SplitFuctnion'의 확장된 기능으로서,
        ''' 한 문장을 기준으로 다른 문장이나 단어를 가져옵니다.
        ''' </summary>
        ''' <param name="e">split할 문장입니다.</param>
        ''' <param name="f">0이면 '\0'이 있는 배열문자가 포함되고 아니면 그렇지 않습니다.</param>
        ''' <param name="c">0부터 시작하며 몇번째 있는 값을 가져올건지 설정합니다.</param>
        ''' <param name="d">어떤 문자를 기준으로 할지 설정합니다.</param>
        ''' <returns></returns>
        ''' <remarks>splitfuntions</remarks>
        Shared Function SplitY(ByVal e, ByVal f, ByVal c, ByVal d)
            On Error Resume Next
            If f = 0 Then
                Return e.Split(New String() {d}, StringSplitOptions.None)(c)
            ElseIf f > 0 Then
                Return e.Split(New String() {d}, StringSplitOptions.RemoveEmptyEntries)(c)
            End If
        End Function

        ''' <summary>
        ''' 'SplitFuctnion'의 확장된 기능으로서,
        ''' 한 문장을 기준으로 다른 문장이나 단어를 가져옵니다.
        ''' SplitY(e,0,c,d)의 축소
        ''' </summary>
        ''' <param name="e">split할 문장입니다.</param>
        ''' <param name="c">0부터 시작하며 몇번째 있는 값을 가져올건지 설정합니다.</param>
        ''' <param name="d">어떤 문자를 기준으로 할지 설정합니다.</param>
        ''' <returns></returns>
        ''' <remarks>splitfuntions</remarks>
        Shared Function SplitS(ByVal e, ByVal c, ByVal d)
            On Error Resume Next
            Return e.Split(New String() {d}, StringSplitOptions.None)(c)
        End Function

        ''' <summary>
        ''' 'SplitFuctnion'의 확장된 기능으로서,
        ''' 한 문장을 기준으로 다른 문장이나 단어를 가져옵니다.
        ''' SplitY(e,0,c,d)의 축소, 가독성 Up
        ''' </summary>
        ''' <param name="e">split할 문장입니다.</param>
        ''' <param name="c">0부터 시작하며 몇번째 있는 값을 가져올건지 설정합니다.</param>
        ''' <param name="d">어떤 문자를 기준으로 할지 설정합니다.</param>
        ''' <returns></returns>
        ''' <remarks>splitfuntions</remarks>
        Shared Function SplitSG(ByVal e, ByVal f, ByVal c, ByVal d)
            On Error Resume Next
            Return e.Split(New String() {d}, StringSplitOptions.None)(c)
        End Function

        ''' <summary>
        ''' 'SplitFuctnion'의 확장된 기능으로서,
        ''' 한 문장을 기준으로 다른 문장이나 단어를 가져옵니다.
        ''' SplitY(e,1,c,d)의 축소
        ''' </summary>
        ''' <param name="e">split할 문장입니다.</param>
        ''' <param name="c">0부터 시작하며 몇번째 있는 값을 가져올건지 설정합니다.</param>
        ''' <param name="d">어떤 문자를 기준으로 할지 설정합니다.</param>
        ''' <returns></returns>
        ''' <remarks>splitfuntions</remarks>
        Shared Function SplitN(ByVal e, ByVal c, ByVal d)
            On Error Resume Next
            Return e.Split(New String() {d}, StringSplitOptions.RemoveEmptyEntries)(c)
        End Function

        ''' <summary>
        ''' 'splitfuntions' 과 동일하나, 
        ''' f의 값이 없어졌습니다.
        ''' </summary>
        ''' <param name="e">split할 문장입니다.</param>
        ''' <param name="c">0부터 시작하며 몇번째 있는 값을 가져올건지 설정합니다.</param>
        ''' <param name="d">어떤 문자를 기준으로 할지 설정합니다.</param>
        ''' <returns></returns>
        ''' <remarks>Tsplitfuntions</remarks>
        Shared Function Tsplit(ByVal e, ByVal c, ByVal d)
            On Error Resume Next
            Dim Result As String
            Dim Splitdata As String() = New String() {c}
            Dim Pdata As Char() = New Char() {d}
            Result = e
            Splitdata = Result.Split(Pdata)
            Return Splitdata(c)
        End Function

        ''' <summary>
        ''' 'replace'를 이용하여 문장안에 있는 
        ''' 모든 문자나 문장이나 단어를 원하는 글자로 바꿉니다.
        ''' </summary>
        ''' <param name="A">원본형태의 문장입니다.</param>
        ''' <param name="B">어떤 문자를 바꾸실것입니까?</param>
        ''' <param name="C">어떻게 바꾸실것입니까?</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function Changer(ByVal A As String, ByVal B As String, ByVal C As String)
            Dim objX As New System.Text.StringBuilder(A)
            Dim objY As System.Text.StringBuilder
            objY = objX
            objX.Replace(B, C)
            Return objY.ToString
        End Function

        ''' <summary>
        ''' RTB or other things to give the function 
        ''' as the extended functionality of 'RTB' gets
        ''' </summary>
        ''' <param name="Text">RTB or related</param>
        ''' <param name="SplitNumber">Will bring a few line?</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function ReadLineByLine(ByVal Text As String, ByVal SplitNumber As Double)
            Dim A As String = Text
            Dim C() As Char = {Chr(10)}
            Dim B() As String = A.Split(C)
            Return B(SplitNumber)
        End Function

        ''' <summary>
        ''' 중앙 Split함수
        ''' </summary>
        ''' <param name="Text">split할 문장입니다.</param>
        ''' <param name="A">Character One</param>
        ''' <param name="B">Character Two</param>
        Shared Function Middle(ByVal Text As String, A As String, B As String)
            Return _Str.Split(_Str.Split(Text, A, 1, 1), B, 1, 0)
        End Function

        ''' <summary>
        ''' 중앙 Split함수, String전용
        ''' </summary>
        ''' <param name="text">split할 문장입니다.</param>
        ''' <param name="A">String</param>
        ''' <param name="B">String</param>
        Shared Function MiddleS(ByVal text As String, A As String, B As String)
            Return _Str.SplitS(_Str.SplitS(text, 1, A), 0, B)
        End Function

        Shared Function MiddleR(ByVal Text As RichTextBox, A As Integer, B As String, C As String, D As Integer)
            Return _Str.Split(_Str.Split(ReadLineByLine(Text.Text, A), B, 1, 1), C, 1, D)
        End Function
        Shared Function Split_A_1(ByVal Text As String, A As String)
            Return _Str.Split(Text, A, 1, 0)
        End Function
        Shared Function Split_A_2(ByVal Text As String, A As String)
            Return _Str.Split(Text, A, 1, 1)
        End Function
        Shared Function Split_A_3(ByVal Text As String, A As String)
            Return _Str.Split(Text, A, 2, 2)
        End Function
        Shared Function Split_B(ByVal Text As String, A As String, B As String)
            Return _Str.Split(_Str.Split(Text, A, 1, 1), B, 1, 0)
        End Function
        Shared Function Split_C_1(ByVal Text As String, A As String, B As String, C As String)
            Return _Str.Split(_Str.Split(_Str.Split(Text, A, 1, 1), B, 1, 0), C, 1, 0)
        End Function
        Shared Function Split_C_2(ByVal Text As String, A As String, B As String, C As String)
            Return _Str.Split(_Str.Split(_Str.Split(Text, A, 1, 1), B, 1, 0), C, 1, 1)
        End Function
        Shared Function Split_D_1(ByVal Text As String, A As String, B As String, C As String, D As String)
            Return _Str.Split(_Str.Split(_Str.Split(_Str.Split(Text, A, 1, 1), B, 1, 0), C, 1, 0), D, 1, 0)
        End Function
        Shared Function Split_D_2(ByVal Text As String, A As String, B As String, C As String, D As String)
            Return _Str.Split(_Str.Split(_Str.Split(_Str.Split(Text, A, 1, 1), B, 1, 0), C, 1, 0), D, 1, 1)
        End Function
        Shared Function Split_D_3(ByVal Text As String, A As String, B As String, C As String, D As String)
            Return _Str.Split(_Str.Split(_Str.Split(_Str.Split(Text, A, 1, 1), B, 1, 0), C, 1, 1), D, 1, 0)
        End Function
        Shared Function Split_D_4(ByVal Text As String, A As String, B As String, C As String, D As String)
            Return _Str.Split(_Str.Split(_Str.Split(_Str.Split(Text, A, 1, 1), B, 1, 0), C, 1, 1), D, 1, 1)
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _CA

        ''' <summary>
        ''' 'Log'를 사용할지의 여부를 가져옵니다.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Log_Able As Boolean = True

        ''' <summary>
        ''' 미리 설정해 놓은 RTB로, 반복 작업시 사용됩니다.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared AppendTextBox As RichTextBox

        ''' <summary>
        ''' RTB의 총 줄의 수를 가져옵니다.
        ''' </summary>
        ''' <param name="Text">RTB Textbox</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function Jul(ByVal Text As RichTextBox)
            Dim Buffer_Jul As Integer
            For A = 0 To 100000
                Try
                    _Str.ReadLineByLine(Text.Text, A)
                    Buffer_Jul += 1
                Catch ex As Exception
                    Exit For
                End Try
            Next
            Return Buffer_Jul
        End Function

        ''' <summary>
        ''' String의 총 줄의 수를 가져옵니다.
        ''' </summary>
        Shared Function JulByStr(ByVal Text As String)
            Dim Buffer_Jul As Integer
            For A = 0 To 100000
                Try
                    _Str.ReadLineByLine(Text, A)
                    Buffer_Jul += 1
                Catch ex As Exception
                    Exit For
                End Try
            Next
            Return Buffer_Jul
        End Function

        ''' <summary>
        ''' 'splitfunctions'와 'ReadLineByLine'의 결합으로 사용자에게 편의를 제공합니다. 
        ''' </summary>
        ''' <param name="RichTextBox_TextBox">RTB Textbox</param>
        ''' <param name="A">Will bring a few line?</param>
        ''' <param name="B">C값과 동일하게 넣어주시면됩니다.</param>
        ''' <param name="C">0부터 시작하며 몇번째 있는 값을 가져올건지 설정합니다</param>
        ''' <param name="D">어떤 문자를 기준으로 할지 설정합니다.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Function Code_Jul_Get(ByVal RichTextBox_TextBox As RichTextBox, ByVal A As Integer, ByVal B As Integer, ByVal C As Integer, ByVal D As String)
            Return _Str.Split(_Str.ReadLineByLine(RichTextBox_TextBox.Text, A), B, C, D)
        End Function

        ''' <summary>
        ''' Convenience function for rollratsoftware developers
        ''' </summary>
        ''' <param name="RichTextBox_TextBox">RTB Textbox</param>
        ''' <param name="A">Long name</param>
        ''' <param name="Counter">Counter integer</param>
        ''' <remarks></remarks>
        Public Shared Sub Log(ByVal RichTextBox_TextBox As RichTextBox, ByVal A As String, ByVal Counter As Integer)
            If Log_Able = True Then
                Dim localTime = My.Computer.Clock.LocalTime
                RichTextBox_TextBox.AppendText("[" & localTime & "] {" & Counter & "} " & A & vbNewLine)
            End If
        End Sub

        ''' <summary>
        ''' 'SetAppendText'로 저장된 RichTextBox를 불러와 AppendText 시킵니다.
        ''' </summary>
        ''' <param name="RichTextBox">RTB Textbox</param>
        ''' <param name="Text">Nomally Text</param>
        ''' <remarks></remarks>
        Public Shared Sub nAppendText(ByVal RichTextBox As RichTextBox, ByVal Text As String)
            RichTextBox.AppendText(Text & vbNewLine)
        End Sub

        ''' <summary>
        ''' 'AppendTextBox'에 입력받은 'RichTextBox'를 넣어 연동시킵니다.
        ''' </summary>
        ''' <param name="RichTextBox">RTB Textbox</param>
        ''' <remarks></remarks>
        Public Shared Sub SetAppendText(ByVal RichTextBox As RichTextBox)
            AppendTextBox = RichTextBox
        End Sub

        ''' <summary>
        ''' Append the text and append enter effect.
        ''' </summary>
        ''' <param name="Text">Nomally Text</param>
        ''' <remarks></remarks>
        Public Shared Sub AppendText(ByVal Text As String)
            AppendTextBox.AppendText(Text & vbNewLine)
        End Sub

        ''' <summary>
        ''' 입력받은 문자열에서 해당하는 모든 문자를 카운트합니다.
        ''' </summary>
        ''' <param name="Text">문자열을 넣어줍니다.</param>
        ''' <param name="Things">찾을 문자또는 단어를 넣어줍니다.</param>
        ''' <returns>카운트</returns>
        ''' <remarks></remarks>
        Public Shared Function FindAndCount(ByVal Text As String, ByVal Things As String)

            Dim RTB As New RichTextBox : RTB.Clear()
            RTB.Text = Text : RTB.AppendText("閒")
            Dim count As Integer = 0
            Dim i As Integer = 0

            i = RTB.Find(Things, 0, RichTextBoxFinds.None)

            If i > -1 Then

                count = 1

                Do

                    i = RTB.Find(Things, i + 1, RichTextBoxFinds.None)
                    If i > -1 Then
                        count += 1
                    End If

                Loop Until i < 0

            End If

            Return count

        End Function

        ''' <summary>
        ''' RictTextBox에서 특정줄을 삭제합니다.
        ''' 같은 Value를 넣으면 그 줄이 삭제됩니다.
        ''' </summary>
        ''' <param name="RichTextBox">RTB를 넣는곳</param>
        ''' <param name="FirstValue">몇번째 줄부터(여기서 첫번째줄은 0입니다.)</param>
        ''' <param name="LastValue">몇번째 줄까지</param>
        ''' <returns>String값이 출력됩니다.</returns>
        Public Shared Function Delete_Jul(ByVal RichTextBox As RichTextBox, ByVal FirstValue As Integer, ByVal LastValue As Integer)
            Dim Max_Jul As Integer = _CA.Jul(RichTextBox)
            Dim RTB As New RichTextBox : RTB.Clear()
            Dim ExistNot As Boolean = False
            Dim FExistNot As Boolean = False
            For A = 0 To Max_Jul - 1
                If ExistNot = False Then
                    If FirstValue = A AndAlso Not LastValue = A Then
                        ExistNot = True
                    ElseIf FirstValue = A AndAlso LastValue = A Then
                        FExistNot = True
                    Else
                        RTB.AppendText(_Str.ReadLineByLine(RichTextBox.Text, A) & vbNewLine)
                    End If
                ElseIf FExistNot = True Then
                    RTB.AppendText(_Str.ReadLineByLine(RichTextBox.Text, A) & vbNewLine)
                    FExistNot = False
                Else
                    If LastValue = A Then
                        ExistNot = False
                    End If
                End If
            Next
            Return RTB.Text
        End Function

        ''' <summary>
        ''' RictTextBox에서 특정줄을 보존합니다.
        ''' 같은 Value를 넣으면 그 줄만 보존됩니다.
        ''' 이 경우, 이함수를 쓰는 의미가 없어집니다.
        ''' </summary>
        ''' <param name="RichTextBox">RTB를 넣는곳</param>
        ''' <param name="FirstValue">몇번째 줄부터(여기서 첫번째줄은 0입니다.)</param>
        ''' <param name="LastValue">몇번째 줄까지</param>
        ''' <returns>String값이 출력됩니다.</returns>
        Public Shared Function Delete_Jul_Not(ByVal RichTextBox As RichTextBox, ByVal FirstValue As Integer, ByVal LastValue As Integer)
            Dim Max_Jul As Integer = _CA.Jul(RichTextBox)
            Dim RTB As New RichTextBox : RTB.Clear()
            Dim ExistNot As Boolean = False
            For A = 0 To Max_Jul - 1
                If ExistNot = False Then
                    If FirstValue = A Then
                        RTB.AppendText(_Str.ReadLineByLine(RichTextBox.Text, A) & vbNewLine)
                        ExistNot = True
                    End If
                Else
                    If LastValue = A Then
                        RTB.AppendText(_Str.ReadLineByLine(RichTextBox.Text, A) & vbNewLine)
                        Exit For
                    Else
                        RTB.AppendText(_Str.ReadLineByLine(RichTextBox.Text, A) & vbNewLine)
                    End If
                End If
            Next
            Return RTB.Text
        End Function

        ''' <summary>
        ''' RichTextBox에서 나온 모든 주석문구를 삭제합니다. 
        ''' 단, 주석이 한번에 2개가 나온경우, 오류가 발생할 수 있습니다.
        ''' 오직 (/*, */)관해서만 삭제합니다.
        ''' </summary>
        ''' <param name="RichTextBox"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Destroy_Annotation(ByVal RichTextBox As RichTextBox)
            Dim Max_Jul As Integer = Jul(RichTextBox)
            Dim RTB As New RichTextBox : RTB.Clear()
            Dim ExistNot As Boolean = False
            For A = 0 To Max_Jul - 1
                If ExistNot = False Then
                    If InStr(_Str.ReadLineByLine(RichTextBox.Text, A), "/*") AndAlso Teps(_Str.ReadLineByLine(RichTextBox.Text, A), "*/") = 1 Then
                        ExistNot = True
                    ElseIf InStr(_Str.ReadLineByLine(RichTextBox.Text, A), "/*") AndAlso Teps(_Str.ReadLineByLine(RichTextBox.Text, A), "*/") = 0 Then

                    Else
                        RTB.AppendText(_Str.ReadLineByLine(RichTextBox.Text, A) & vbNewLine)
                    End If
                Else
                    If InStr(_Str.ReadLineByLine(RichTextBox.Text, A), "*/") Then
                        ExistNot = False
                    End If
                End If
            Next
            Return RTB.Text
        End Function

        ''' <summary>
        ''' Text의 변화를 감지합니다.
        ''' </summary>
        ''' <param name="Text">String값</param>
        ''' <param name="Value">감지할 String</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Teps(ByVal Text As String, ByVal Value As String)
            Dim FirstValue As Integer = Text.Length
            Text.Replace(Value, "")
            If Not FirstValue = Text.Length Then
                Return 1
            Else
                Return 0
            End If
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _F

        ''' <summary>
        ''' Window Api MessageBox를 호출할지 여부를 설정합니다.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared AppendMessage As Boolean = False

        ''' <summary>
        ''' 파일의 존재여부를 가져옵니다.
        ''' </summary>
        ''' <param name="Address_File">여부를 확인한 파일의 주소</param>
        ''' <returns>성공시 0, 실패시1 이 출력됩니다.</returns>
        ''' <remarks></remarks>
        Shared Function [Exist](ByVal Address_File As String)
            Dim fileExists As Boolean
            fileExists = My.Computer.FileSystem.FileExists(Address_File)
            If fileExists = True Then
                Return 0
            Else
                Return 1
            End If
        End Function

        ''' <summary>
        ''' 파일을 새로 만듭니다.
        ''' </summary>
        ''' <param name="Address_File">새로 만들 파일의 주소</param>
        ''' <returns>성공시 0, 실패시1 이 출력됩니다.</returns>
        ''' <remarks></remarks>
        Shared Function [New](ByVal Address_File As String)
            Try
                My.Computer.FileSystem.WriteAllText(Address_File, String.Empty, False)
                Return 0
            Catch ex As Exception
                If AppendMessage = True Then
                    MsgBox("Error : " & ex.Message & " Code : " & ex.HelpLink, _
                           MsgBoxStyle.Critical, _
                           "RollRat Software Subrutines Dynamic Linked Library")
                    Return 1
                End If
                Return 1
            End Try
        End Function

        ''' <summary>
        ''' 파일에서 텍스르르 읽습니다.
        ''' </summary>
        ''' <param name="Address_File">읽을 파일의 주소</param>
        ''' <returns>성공시 0, 실패시1 이 출력됩니다.</returns>
        ''' <remarks></remarks>
        Shared Function [Read](ByVal Address_File As String)
            Try
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(Address_File)
                Return fileContents
            Catch ex As Exception
                If AppendMessage = True Then
                    MsgBox("Error : " & ex.Message & " Code : " & ex.HelpLink, _
                           MsgBoxStyle.Critical, _
                           "RollRat Software Subrutines Dynamic Linked Library")
                    Return 1
                End If
                Return 1
            End Try
        End Function

        ''' <summary>
        ''' 파일에 텍스트를 씁니다.
        ''' </summary>
        ''' <param name="Address_File">텍스트를 쓸 파일의 주소</param>
        ''' <param name="Write_Text">파일에 입력할 텍스트</param>
        ''' <returns>성공시 0, 실패시1 이 출력됩니다.</returns>
        ''' <remarks></remarks>
        Shared Function [Write](ByVal Address_File As String, ByVal Write_Text As String)
            Try
                My.Computer.FileSystem.WriteAllText(Address_File, Write_Text, True)
                Return 0
            Catch ex As Exception
                If AppendMessage = True Then
                    MsgBox("Error : " & ex.Message & " Code : " & ex.HelpLink, _
                           MsgBoxStyle.Critical, _
                           "RollRat Software Subrutines Dynamic Linked Library")
                    Return 1
                End If
                Return 1
            End Try
        End Function

        ''' <summary>
        ''' Window Api MessageBox를 호출할지 여부를 설정합니다.
        ''' </summary>
        ''' <param name="sAppendMessage">여부</param>
        ''' <remarks></remarks>
        Public Shared Sub SetAppendMessage(ByVal sAppendMessage As Boolean)
            AppendMessage = sAppendMessage
        End Sub

        Public Shared Sub WriteBytes(ByVal Address_File As String, ByVal Buffer() As Byte)
            FileIO.FileSystem.WriteAllBytes(Address_File, Buffer, True)
        End Sub

        Public Shared Function ReadBytes(ByVal Address_File As String) As Byte()
            Return FileIO.FileSystem.ReadAllBytes(Address_File)
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _LV

        Public Shared LV As ListView

        ''' <summary>
        ''' 리스트뷰에 아이템을 추가시킵니다.
        ''' </summary>
        Public Shared Sub Put(ByVal ListView As ListView, ByVal A As String, ByVal B As String)
            Dim strArray = New String() {A, B}
            Dim lvt = New ListViewItem(strArray)
            ListView.Items.Add(lvt)
        End Sub

        ''' <summary>
        ''' 리스트뷰에 아이템을 추가시킵니다.(정의형)
        ''' </summary>
        Public Shared Sub Puts(ByVal A As String, ByVal B As String)
            Dim strArray = New String() {A, B}
            Dim lvt = New ListViewItem(strArray)
            LV.Items.Add(lvt)
        End Sub

        ''' <summary>
        ''' 리스뷰를 초기화 시킵니다.
        ''' </summary>
        Public Shared Sub Refresh(ByVal ListView As ListView)
            ListView.Clear()
        End Sub

        ''' <summary>
        ''' 리스뷰를 초기화 시킵니다.(정의형)
        ''' </summary>
        Public Shared Sub Refreshs()
            LV.Clear()
        End Sub

        ''' <summary>
        ''' 아이템을 가져옵니다.
        ''' </summary>
        Shared Function Item(ByVal ListView As ListView, ByVal A As Integer, ByVal B As Integer)
            Try
                Return ListView.SelectedItems(A).SubItems(B).Text
            Catch ex As Exception
                Return 1
            End Try
        End Function

        ''' <summary>
        ''' 아이템을 가져옵니다.(정의형)
        ''' </summary>
        Shared Function Items(ByVal A As Integer, ByVal B As Integer)
            Try
                Return LV.SelectedItems(A).SubItems(B).Text
            Catch ex As Exception
                Return 1
            End Try
        End Function

        ''' <summary>
        ''' 정의형 리스트뷰를 설정합니다.(정의형)
        ''' </summary>
        Public Shared Sub SetLV(ListView As ListView)
            LV = ListView
        End Sub

        ''' <summary>
        ''' ListView를 정리하는 이벤트를 만듭니다.
        ''' </summary>
        Public Class Sorter

            Public Class ListViewSorter
                Private lvw As ListView
                Private intCol As Integer
                Private soOrder As SortOrder
                Dim co As ColumnSorter
                Private il As ImageList

                Public Sub New(ByVal TheListView As ListView)
                    intCol = 0
                    soOrder = SortOrder.None

                    lvw = TheListView

                    AddHandler lvw.ColumnClick, AddressOf lvw_ColumnClick

                    co = New ColumnSorter(Me)
                End Sub

                Public Property ListViewRef() As ListView
                    Get
                        Return lvw
                    End Get
                    Set(ByVal Value As ListView)
                        lvw = Value
                    End Set
                End Property

                Public Property Column() As Integer
                    Get
                        Return intCol
                    End Get
                    Set(ByVal Value As Integer)

                    End Set
                End Property

                Public Property SortOrder() As SortOrder
                    Get
                        Return soOrder
                    End Get
                    Set(ByVal Value As SortOrder)

                    End Set
                End Property

                Public Sub lvw_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
                    Dim so As SortOrder

                    If e.Column = intCol Then
                        If soOrder = SortOrder.None OrElse soOrder = SortOrder.Descending Then
                            so = SortOrder.Ascending
                        Else
                            so = SortOrder.Descending
                        End If
                    Else
                        so = SortOrder.Ascending
                    End If

                    intCol = e.Column
                    soOrder = so

                    If lvw.ListViewItemSorter Is Nothing Then
                        lvw.ListViewItemSorter = co
                    End If

                    co.SetColumnType()
                    lvw.Sort()

                    'ShowHeaderIcon(intCol, soOrder)
                End Sub

                Public Sub ReInitSorter()
                    intCol = 0
                    soOrder = SortOrder.None
                    lvw.ListViewItemSorter = Nothing
                End Sub


            End Class

            Friend Class ColumnSorter
                Implements IComparer

                Private Enum ColumnType
                    Text = 1
                    Numeric
                    DateTime
                End Enum

                Private eColType As ColumnType
                Private olvs As ListViewSorter

                Public Sub New(ByVal lvs As ListViewSorter)
                    olvs = lvs
                End Sub

                Public Sub SetColumnType()
                    eColType = DetectColumnType()
                End Sub

                Private Function DetectColumnType() As ColumnType
                    Dim iNumericCount As Integer
                    Dim iDateCount As Integer
                    Dim li As ListViewItem
                    Dim iCol As Integer
                    Dim sSIText As String
                    Dim dNumValue As Double
                    Dim dteDateValue As Date

                    iCol = olvs.Column

                    For Each li In olvs.ListViewRef.Items
                        sSIText = li.SubItems(iCol).Text

                        If sSIText.Length > 0 Then
                            If iNumericCount > 0 Then
                                Try
                                    dNumValue = Double.Parse(sSIText)
                                Catch
                                    Return ColumnType.Text
                                End Try
                            ElseIf iDateCount > 0 Then
                                Try
                                    dteDateValue = Date.Parse(sSIText)
                                Catch
                                    Return ColumnType.Text
                                End Try
                            Else
                                Try
                                    dNumValue = Double.Parse(sSIText)
                                    iNumericCount += 1
                                Catch
                                    Try
                                        dteDateValue = Date.Parse(sSIText)
                                        iDateCount += 1
                                    Catch
                                        Return ColumnType.Text
                                    End Try
                                End Try
                            End If
                        Else
                            '
                        End If
                    Next

                    If iDateCount > 0 Then Return ColumnType.DateTime
                    If iNumericCount > 0 Then Return ColumnType.Numeric
                    Return ColumnType.Text
                End Function

                Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
                    Dim liX As ListViewItem
                    Dim liY As ListViewItem
                    Dim sTextX As String
                    Dim sTextY As String
                    Dim intRet As Integer

                    liX = CType(x, ListViewItem)
                    liY = CType(y, ListViewItem)

                    sTextX = liX.SubItems(olvs.Column).Text
                    sTextY = liY.SubItems(olvs.Column).Text

                    Select Case eColType
                        Case ColumnType.Text
                            intRet = String.Compare(sTextX, sTextY)

                        Case ColumnType.Numeric
                            intRet = 0
                            If Double.Parse(sTextX) > Double.Parse(sTextY) Then intRet = 1
                            If Double.Parse(sTextX) < Double.Parse(sTextY) Then intRet = -1

                        Case ColumnType.DateTime
                            intRet = Date.Compare(CType(sTextX, Date), CType(sTextY, Date))

                    End Select

                    If olvs.SortOrder = SortOrder.Descending Then
                        intRet *= -1
                    End If

                    Return intRet
                End Function

            End Class

            '//////////////////////////////////////////////////////////////////////////////////////////////////
            '   Copyright : http://www.planet-source-code.com/vb/scripts/ShowCode.asp?txtCodeId=2435&lngWId=10
            '//////////////////////////////////////////////////////////////////////////////////////////////////

            '******************************************************************************
            ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
            '                         RollRat Software Programs & Lab(R LAB)
            '******************************************************************************
        End Class

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _TV

        ''' <summary>
        ''' 3층 계층의 노드에서 해당하는 층의 노드의 개수를 가져옵니다.
        ''' </summary>
        ''' <param name="NodeN">몇층의 노드를 가져올건지 입력합니다.</param>
        ''' <returns>실패시 "/", 입력값이 없는경우 "*.*"이 출력됩니다.</returns>
        Public Shared Function GetNodeMax(ByVal TV As TreeView, ByVal NodeN As Integer)
            Try
                If NodeN = 0 Then
                    Dim Maxs As Integer = 0
                    Try
                        For Maxs = 0 To 1000000000
                            TV.Nodes(Maxs).ToString()
                        Next
                    Catch ex As Exception
                        Return Maxs
                    End Try
                ElseIf NodeN = 1 Then
                    Dim Maxs As Integer = 0
                    Try
                        For A = 0 To 1000000000
                            For Maxs = 0 To TV.Nodes(A).Nodes.Count
                                TV.Nodes(A).Nodes(Maxs).ToString()
                            Next
                        Next
                    Catch ex As Exception
                        Return Maxs
                    End Try
                ElseIf NodeN = 2 Then
                    Dim Maxs As Integer = 0
                    Try
                        For A = 0 To 1000000000
                            For B = 0 To TV.Nodes(A).Nodes.Count
                                For Maxs = 0 To TV.Nodes(A).Nodes(B).Nodes.Count
                                    TV.Nodes(A).Nodes(B).Nodes(Maxs).ToString()
                                Next
                            Next
                        Next
                    Catch ex As Exception
                        Return Maxs
                    End Try
                End If
            Catch
                Return "/"
            End Try
            Return "*.*"
        End Function

        ''' <summary>
        ''' 3층 계층의 노드에서 해당하는 층의 노드의 Value를 가져옵니다.
        ''' </summary>
        ''' <param name="Type">몇층의 노드를 가져올건지 입력합니다.</param>
        ''' <returns>실패시 "/", 입력값이 없는경우 "*.*"이 출력됩니다.</returns>
        Public Shared Function GetNodesItemPos(ByRef TV As TreeView, ByVal NodeItemStr As String, ByVal Type As Integer)
            If Type = 0 Then
                Try
                    For Maxs = 0 To GetNodeMax(TV, 0)
                        If TV.Nodes(Maxs).Text = NodeItemStr Then
                            Return Maxs & "." & 0
                        End If
                    Next
                Catch
                    Return "/"
                End Try
                Return "*.*"
            ElseIf Type = 1 Then
                Try
                    For Maxs = 0 To GetNodeMax(TV, 0)
                        For Maxes = 0 To GetNodeMax(TV, 1)
                            If TV.Nodes(Maxs).Nodes(Maxes).Text = NodeItemStr Then
                                Return Maxs & "." & Maxes
                            End If
                        Next
                    Next
                Catch
                    Return "/"
                End Try
                Return "*.*"
            ElseIf Type = 2 Then
                Try
                    For Maxs = 0 To GetNodeMax(TV, 0)
                        For Maxes = 0 To GetNodeMax(TV, 1)
                            For Maxeses = 0 To GetNodeMax(TV, 2)
                                If TV.Nodes(Maxs).Nodes(Maxes).Nodes(Maxeses).Text = NodeItemStr Then
                                    Return Maxs & "." & Maxes & "." & Maxeses
                                End If
                            Next
                        Next
                    Next
                Catch
                    Return "/"
                End Try
                Return "*.*"
            End If
            Return "*.*"
        End Function

        ''' <summary>
        ''' 1층의 노드에서 해당하는 아이템의 노드의 Value를 가져옵니다.
        ''' </summary>
        Public Shared Function GetNodesItemPos_1(ByRef TV As TreeView, ByVal NodeItemStr As String, ByVal Max As Integer)
            Try
                For Maxs = 0 To Max
                    If TV.Nodes(Maxs).Text = NodeItemStr Then
                        Return Maxs & "." & 0
                    End If
                Next
            Catch
                Return "/"
            End Try
            Return "*.*"
        End Function

        ''' <summary>
        ''' 2층의 노드에서 해당하는 아이템의 노드의 Value를 가져옵니다.
        ''' </summary>
        Public Shared Function GetNodesItemPos_2(ByRef TV As TreeView, ByVal NodeItemStr As String, ByVal Max As Integer, ByVal Max_ As Integer)
            Try
                For Maxs = 0 To Max
                    For Maxes = 0 To Max_
                        If TV.Nodes(Maxs).Nodes(Maxes).Text = NodeItemStr Then
                            Return Maxs & "." & Maxes
                        End If
                    Next
                Next
            Catch
                Return "/"
            End Try
            Return "*.*"
        End Function

        ''' <summary>
        ''' 3층의 노드에서 해당하는 아이템의 노드의 Value를 가져옵니다.
        ''' </summary>
        Public Shared Function GetNodesItemPos_3(ByRef TV As TreeView, ByVal NodeItemStr As String, ByVal Max As Integer, ByVal Max_ As Integer, ByVal Max__ As Integer)
            Try
                For Maxs = 0 To Max
                    For Maxes = 0 To Max_
                        For Maxeses = 0 To Max__
                            If TV.Nodes(Maxs).Nodes(Maxes).Nodes(Maxeses).Text = NodeItemStr Then
                                Return Maxs & "." & Maxes & "." & Maxeses
                            End If
                        Next
                    Next
                Next
            Catch
                Return "/"
            End Try
            Return "*.*"
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _PB
        Enum PBC
            NORMAL = 1
            [ERROR]
            PAUSED
        End Enum
        Public Shared Sub SetProgressBarColor(ByVal PBM As ProgressBar, ByVal Color As PBC)
            WinApi.SendMessage(PBM.Handle, &H410, Color, 0)
        End Sub
    End Class
    Public Class KeyboardHook

        Public Shared NoneCheckError As Boolean = False

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '                       SetWindowsHookEx
        '
        '           WINUSERAPI
        '           HHOOK
        '           WINAPI
        '           SetWindowsHookExW(
        '               _In_ int idHook,
        '               _In_ HOOKPROC lpfn,
        '               _In_opt_ HINSTANCE hmod,
        '               _In_ DWORD dwThreadId);
        '
        '           #define SetWindowsHookEx SetWindowsHookExW
        'by rollrat
        '******************************************************************************
        <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
        Private Overloads Shared Function SetWindowsHookEx( _
                                                            ByVal idHook As Integer, _
                                                            ByVal HookProc As KBDLLHookProc, _
                                                            ByVal hInstance As IntPtr, _
                                                            ByVal wParam As Integer _
                                                            ) As Integer
        End Function

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '                       CallNextHookEx
        '
        '           WINUSERAPI
        '           LRESULT
        '           WINAPI
        '           CallNextHookEx(
        '               _In_opt_ HHOOK hhk,
        '               _In_ int nCode,
        '               _In_ WPARAM wParam,
        '               _In_ LPARAM lParam);
        'by rollrat
        '******************************************************************************
        <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
        Private Overloads Shared Function CallNextHookEx( _
                                                          ByVal idHook As Integer, _
                                                          ByVal nCode As Integer, _
                                                          ByVal wParam As IntPtr, _
                                                          ByVal lParam As IntPtr _
                                                          ) As Integer
        End Function

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '                       UnhookWindowsHookEx
        '
        '           WINUSERAPI
        '           BOOL
        '           WINAPI
        '           UnhookWindowsHookEx(
        '               _In_ HHOOK hhk);
        'by rollrat
        '******************************************************************************
        <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
        Private Overloads Shared Function UnhookWindowsHookEx( _
                                                               ByVal idHook As Integer _
                                                               ) As Boolean
        End Function

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '           /*
        '            * Structure used by WH_KEYBOARD_LL
        '            */
        '           typedef struct tagKBDLLHOOKSTRUCT {
        '               DWORD   vkCode;
        '               DWORD   scanCode;
        '               DWORD   flags;
        '               DWORD   time;
        '               ULONG_PTR dwExtraInfo;
        '           } KBDLLHOOKSTRUCT, FAR *LPKBDLLHOOKSTRUCT, *PKBDLLHOOKSTRUCT;
        'by rollrat            
        '******************************************************************************
        <StructLayout(LayoutKind.Sequential)> _
        Private Structure KBDLLHOOKSTRUCT
            Public vkCode As UInt32
            Public scanCode As UInt32
            Public flags As KBDLLHOOKSTRUCTFlags
            Public time As UInt32
            Public dwExtraInfo As UIntPtr
        End Structure

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '           /*
        '           * Structure used by WH_MOUSE_LL
        '           */
        '           typedef struct tagMSLLHOOKSTRUCT {
        '                  POINT   pt;
        '                  DWORD   mouseData;
        '                  DWORD   flags;
        '                  DWORD   time;
        '                  ULONG_PTR dwExtraInfo;
        '           } MSLLHOOKSTRUCT, FAR *LPMSLLHOOKSTRUCT, *PMSLLHOOKSTRUCT;
        'by rollrat
        '******************************************************************************
        <Flags()> _
        Private Enum KBDLLHOOKSTRUCTFlags As UInt32
            LLKHF_EXTENDED = &H1
            LLKHF_INJECTED = &H10
            LLKHF_ALTDOWN = &H20
            LLKHF_UP = &H80
        End Enum

        '******************************************************************************
        '
        '
        '                       Keyboard Hook Events
        '
        '
        '******************************************************************************
        Public Shared Event KeyDown(ByVal Key As Keys)
        Public Shared Event KeyUp(ByVal Key As Keys)

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '                       Hook Events
        '
        '           #define WH_KEYBOARD_LL     13
        '           #define WH_MOUSE_LL        14
        '
        '           /*
        '           * Hook Codes
        '           */
        '           #define HC_ACTION           0
        '           #define HC_GETNEXT          1
        '           #define HC_SKIP             2
        '           #define HC_NOREMOVE         3
        '           #define HC_NOREM            HC_NOREMOVE
        '           #define HC_SYSMODALON       4
        '           #define HC_SYSMODALOFF      5
        '
        '           #define WM_KEYFIRST                     0x0100
        '           #define WM_KEYDOWN                      0x0100
        '           #define WM_KEYUP                        0x0101
        '           #define WM_CHAR                         0x0102
        '           #define WM_DEADCHAR                     0x0103
        '           #define WM_SYSKEYDOWN                   0x0104
        '           #define WM_SYSKEYUP                     0x0105
        '           #define WM_SYSCHAR                      0x0106
        '           #define WM_SYSDEADCHAR                  0x0107
        'by rollrat
        '******************************************************************************
        Private Const WH_KEYBOARD_LL As Integer = WinApiUsr.WH_KEYBOARD_LL
        Private Const HC_ACTION As Integer = WinApiUsr.HC_ACTION
        Private Const WM_KEYFIRST As Integer = WinApiUsr.WM_KEYFIRST
        Private Const WM_KEYDOWN As Integer = WinApiUsr.WM_KEYDOWN
        Private Const WM_KEYUP As Integer = WinApiUsr.WM_KEYUP
        Private Const WM_CHAR As Integer = WinApiUsr.WM_CHAR
        Private Const WM_DEADCHAR As Integer = WinApiUsr.WM_DEADCHAR
        Private Const WM_SYSKEYDOWN As Integer = WinApiUsr.WM_SYSKEYDOWN
        Private Const WM_SYSKEYUP As Integer = WinApiUsr.WM_SYSKEYUP
        Private Const WM_SYSCHAR As Integer = WinApiUsr.WM_SYSKEYDOWN
        Private Const WM_SYSDEADCHAR As Integer = WinApiUsr.WM_SYSDEADCHAR

        Private Delegate Function KBDLLHookProc( _
                                                 ByVal nCode As Integer, _
                                                 ByVal wParam As IntPtr, _
                                                 ByVal lParam As IntPtr _
                                                 ) As Integer

        Private KBDLLHookProcDelegate As KBDLLHookProc = New KBDLLHookProc( _
                                                                            AddressOf KeyboardProc _
                                                                            )
        Private HHookID As IntPtr = IntPtr.Zero

        Private Function KeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
            If (nCode = HC_ACTION) Then
                Dim struct As KBDLLHOOKSTRUCT
                Select Case wParam
                    Case WM_KEYDOWN, WM_SYSKEYDOWN
                        RaiseEvent KeyDown(CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
                    Case WM_KEYUP, WM_SYSKEYUP
                        RaiseEvent KeyUp(CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
                End Select
            End If
            Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
        End Function

        Public Sub New()
            HHookID = SetWindowsHookEx( _
                                        WH_KEYBOARD_LL, _
                                        KBDLLHookProcDelegate, _
                                        System.Runtime.InteropServices.Marshal.GetHINSTANCE( _
                                            System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, _
                                        0 _
                                        )
            '/////////////////////////////////////////////////////////////////////
            '
            '       If there was an error, debug, and run it using the 'Ctrl + F5' key.
            '
            '/////////////////////////////////////////////////////////////////////
            If NoneCheckError = True Then
                If HHookID = IntPtr.Zero Then
                    Throw New Exception("Could not set keyboard hook")
                End If
            End If
        End Sub

        Public Shared Sub NoneCheck(ByVal NoneE As Boolean)
            NoneCheckError = NoneE
        End Sub

        Protected Overrides Sub Finalize()
            If Not HHookID = IntPtr.Zero Then
                UnhookWindowsHookEx(HHookID)
            End If
            MyBase.Finalize()
        End Sub

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class WinApiUsr
        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Scroll Bar Constants
        '
        '           #define SB_HORZ             0
        '           #define SB_VERT             1
        '           #define SB_CTL              2
        '           #define SB_BOTH             3
        'by rollrat
        '******************************************************************************
        Public Const SB_HORZ As Integer = 0
        Public Const SB_VERT As Integer = 1
        Public Const SB_CTL As Integer = 2
        Public Const SB_BOTH As Integer = 3

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Scroll Bar Constants
        '
        '           #define SB_LINEUP           0
        '           #define SB_LINELEFT         0
        '           #define SB_LINEDOWN         1
        '           #define SB_LINERIGHT        1
        '           #define SB_PAGEUP           2
        '           #define SB_PAGELEFT         2
        '           #define SB_PAGEDOWN         3
        '           #define SB_PAGERIGHT        3
        '           #define SB_THUMBPOSITION    4
        '           #define SB_THUMBTRACK       5
        '           #define SB_TOP              6
        '           #define SB_LEFT             6
        '           #define SB_BOTTOM           7
        '           #define SB_RIGHT            7
        '           #define SB_ENDSCROLL        8
        'by rollrat
        '******************************************************************************
        Public Const SB_LINEUP As Integer = 0
        Public Const SB_LINELEFT As Integer = 0
        Public Const SB_LINEDOWN As Integer = 1
        Public Const SB_LINERIGHT As Integer = 1
        Public Const SB_PAGEUP As Integer = 2
        Public Const SB_PAGELEFT As Integer = 2
        Public Const SB_PAGEDOWN As Integer = 3
        Public Const SB_PAGERIGHT As Integer = 3
        Public Const SB_THUMBPOSITION As Integer = 4
        Public Const SB_THUMBTRACK As Integer = 5
        Public Const SB_TOP As Integer = 6
        Public Const SB_LEFT As Integer = 6
        Public Const SB_BOTTOM As Integer = 7
        Public Const SB_RIGHT As Integer = 7
        Public Const SB_ENDSCROLL As Integer = 8

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           ShowWindow
        '
        '           #define SW_HIDE             0
        '           #define SW_SHOWNORMAL       1
        '           #define SW_NORMAL           1
        '           #define SW_SHOWMINIMIZED    2
        '           #define SW_SHOWMAXIMIZED    3
        '           #define SW_MAXIMIZE         3
        '           #define SW_SHOWNOACTIVATE   4
        '           #define SW_SHOW             5
        '           #define SW_MINIMIZE         6
        '           #define SW_SHOWMINNOACTIVE  7
        '           #define SW_SHOWNA           8
        '           #define SW_RESTORE          9
        '           #define SW_SHOWDEFAULT      10
        '           #define SW_FORCEMINIMIZE    11
        '           #define SW_MAX              11
        'by rollrat
        '******************************************************************************
        Public Const SW_HIDE As Integer = 0
        Public Const SW_SHOWNORMAL As Integer = 1
        Public Const SW_NORMAL As Integer = 1
        Public Const SW_SHOWMINIMIZED As Integer = 2
        Public Const SW_SHOWMAXIMIZED As Integer = 3
        Public Const SW_MAXIMIZE As Integer = 3
        Public Const SW_SHOWNOACTIVATE As Integer = 4
        Public Const SW_SHOW As Integer = 5
        Public Const SW_MINIMIZE As Integer = 6
        Public Const SW_SHOWMINNOACTIVE As Integer = 7
        Public Const SW_SHOWNA As Integer = 8
        Public Const SW_RESTORE As Integer = 9
        Public Const SW_SHOWDEFAULT As Integer = 10
        Public Const SW_FORCEMINIMIZE As Integer = 11
        Public Const SW_MAX As Integer = 11

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Old ShowWindow
        '
        '           #define HIDE_WINDOW         0
        '           #define SHOW_OPENWINDOW     1
        '           #define SHOW_ICONWINDOW     2
        '           #define SHOW_FULLSCREEN     3
        '           #define SHOW_OPENNOACTIVATE 4
        'by rollrat
        '******************************************************************************
        Public Const HIDE_WINDOW As Integer = 0
        Public Const SHOW_OPENWINDOW As Integer = 1
        Public Const SHOW_ICONWINDOW As Integer = 2
        Public Const SHOW_FULLSCREEN As Integer = 3
        Public Const SHOW_OPENNOACTIVATE As Integer = 4

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Identifiers for the WM_SHOWWINDOW message
        '
        '           #define SW_PARENTCLOSING    1
        '           #define SW_OTHERZOOM        2
        '           #define SW_PARENTOPENING    3
        '           #define SW_OTHERUNZOOM      4
        'by rollrat
        '******************************************************************************
        Public Const SW_PARENTCLOSING As Integer = 1
        Public Const SW_OTHERZOOM As Integer = 2
        Public Const SW_PARENTOPENING As Integer = 3
        Public Const SW_OTHERUNZOOM As Integer = 4

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           AnimateWindow
        '
        '           #define AW_HOR_POSITIVE             0x00000001
        '           #define AW_HOR_NEGATIVE             0x00000002
        '           #define AW_VER_POSITIVE             0x00000004
        '           #define AW_VER_NEGATIVE             0x00000008
        '           #define AW_CENTER                   0x00000010
        '           #define AW_HIDE                     0x00010000
        '           #define AW_ACTIVATE                 0x00020000
        '           #define AW_SLIDE                    0x00040000
        '           #define AW_BLEND                    0x00080000
        'by rollrat
        '******************************************************************************
        Public Const AW_HOR_POSITIVE As Integer = &H1
        Public Const AW_HOR_NEGATIVE As Integer = &H2
        Public Const AW_VER_POSITIVE As Integer = &H4
        Public Const AW_VER_NEGATIVE As Integer = &H8
        Public Const AW_CENTER As Integer = &H10
        Public Const AW_HIDE As Integer = &H10000
        Public Const AW_ACTIVATE As Integer = &H20000
        Public Const AW_SLIDE As Integer = &H40000
        Public Const AW_BLEND As Integer = &H80000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WM_KEYUP/DOWN/CHAR HIWORD(lParam) flags
        '
        '           #define KF_EXTENDED       0x0100
        '           #define KF_DLGMODE        0x0800
        '           #define KF_MENUMODE       0x1000
        '           #define KF_ALTDOWN        0x2000
        '           #define KF_REPEAT         0x4000
        '           #define KF_UP             0x8000
        'by rollrat
        '******************************************************************************
        Public Const KF_EXTENDED As Integer = &H100
        Public Const KF_DLGMODE As Integer = &H800
        Public Const KF_MENUMODE As Integer = &H1000
        Public Const KF_ALTDOWN As Integer = &H2000
        Public Const KF_REPEAT As Integer = &H4000
        Public Const KF_UP As Integer = &H8000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Virtual Keys, Standard Set
        '
        '           #define VK_LBUTTON        0x01
        '           #define VK_RBUTTON        0x02
        '           #define VK_CANCEL         0x03
        '           #define VK_MBUTTON        0x04
        'by rollrat
        '******************************************************************************
        Public Const VK_LBUTTON As Integer = &H1
        Public Const VK_RBUTTON As Integer = &H2
        Public Const VK_CANCEL As Integer = &H3
        Public Const VK_MBUTTON As Integer = &H4
        Public Const VK_XBUTTON1 As Integer = &H5
        Public Const VK_XBUTTON2 As Integer = &H6
        Public Const VK_BACK As Integer = &H8
        Public Const VK_TAB As Integer = &H9
        Public Const VK_CLEAR As Integer = &HC
        Public Const VK_RETURN As Integer = &HD
        Public Const VK_SHIFT As Integer = &H10
        Public Const VK_CONTROL As Integer = &H11
        Public Const VK_MENU As Integer = &H12
        Public Const VK_PAUSE As Integer = &H13
        Public Const VK_CAPITAL As Integer = &H14
        Public Const VK_KANA As Integer = &H15
        Public Const VK_HANGEUL As Integer = &H15
        Public Const VK_HANGUL As Integer = &H15
        Public Const VK_JUNJA As Integer = &H17
        Public Const VK_FINAL As Integer = &H18
        Public Const VK_HANJA As Integer = &H19
        Public Const VK_KANJI As Integer = &H19
        Public Const VK_ESCAPE As Integer = &H1B
        Public Const VK_CONVERT As Integer = &H1C
        Public Const VK_NONCONVERT As Integer = &H1D
        Public Const VK_ACCEPT As Integer = &H1E
        Public Const VK_MODECHANGE As Integer = &H1F
        Public Const VK_SPACE As Integer = &H20
        Public Const VK_PRIOR As Integer = &H21
        Public Const VK_NEXT As Integer = &H22
        Public Const VK_END As Integer = &H23
        Public Const VK_HOME As Integer = &H24
        Public Const VK_LEFT As Integer = &H25
        Public Const VK_UP As Integer = &H26
        Public Const VK_RIGHT As Integer = &H27
        Public Const VK_DOWN As Integer = &H28
        Public Const VK_SELECT As Integer = &H29
        Public Const VK_PRINT As Integer = &H2A
        Public Const VK_EXECUTE As Integer = &H2B
        Public Const VK_SNAPSHOT As Integer = &H2C
        Public Const VK_INSERT As Integer = &H2D
        Public Const VK_DELETE As Integer = &H2E
        Public Const VK_HELP As Integer = &H2F
        Public Const VK_LWIN As Integer = &H5B
        Public Const VK_RWIN As Integer = &H5C
        Public Const VK_APPS As Integer = &H5D
        Public Const VK_SLEEP As Integer = &H5F
        Public Const VK_NUMPAD0 As Integer = &H60
        Public Const VK_NUMPAD1 As Integer = &H61
        Public Const VK_NUMPAD2 As Integer = &H62
        Public Const VK_NUMPAD3 As Integer = &H63
        Public Const VK_NUMPAD4 As Integer = &H64
        Public Const VK_NUMPAD5 As Integer = &H65
        Public Const VK_NUMPAD6 As Integer = &H66
        Public Const VK_NUMPAD7 As Integer = &H67
        Public Const VK_NUMPAD8 As Integer = &H68
        Public Const VK_NUMPAD9 As Integer = &H69
        Public Const VK_MULTIPLY As Integer = &H6A
        Public Const VK_ADD As Integer = &H6B
        Public Const VK_SEPARATOR As Integer = &H6C
        Public Const VK_SUBTRACT As Integer = &H6D
        Public Const VK_DECIMAL As Integer = &H6E
        Public Const VK_DIVIDE As Integer = &H6F
        Public Const VK_F1 As Integer = &H70
        Public Const VK_F2 As Integer = &H71
        Public Const VK_F3 As Integer = &H72
        Public Const VK_F4 As Integer = &H73
        Public Const VK_F5 As Integer = &H74
        Public Const VK_F6 As Integer = &H75
        Public Const VK_F7 As Integer = &H76
        Public Const VK_F8 As Integer = &H77
        Public Const VK_F9 As Integer = &H78
        Public Const VK_F10 As Integer = &H79
        Public Const VK_F11 As Integer = &H7A
        Public Const VK_F12 As Integer = &H7B
        Public Const VK_F13 As Integer = &H7C
        Public Const VK_F14 As Integer = &H7D
        Public Const VK_F15 As Integer = &H7E
        Public Const VK_F16 As Integer = &H7F
        Public Const VK_F17 As Integer = &H80
        Public Const VK_F18 As Integer = &H81
        Public Const VK_F19 As Integer = &H82
        Public Const VK_F20 As Integer = &H83
        Public Const VK_F21 As Integer = &H84
        Public Const VK_F22 As Integer = &H85
        Public Const VK_F23 As Integer = &H86
        Public Const VK_F24 As Integer = &H87
        Public Const VK_NUMLOCK As Integer = &H90
        Public Const VK_SCROLL As Integer = &H91
        Public Const VK_OEM_NEC_EQUAL As Integer = &H92
        Public Const VK_OEM_FJ_JISHO As Integer = &H92
        Public Const VK_OEM_FJ_MASSHOU As Integer = &H93
        Public Const VK_OEM_FJ_TOUROKU As Integer = &H94
        Public Const VK_OEM_FJ_LOYA As Integer = &H95
        Public Const VK_OEM_FJ_ROYA As Integer = &H96
        Public Const VK_LSHIFT As Integer = &HA0
        Public Const VK_RSHIFT As Integer = &HA1
        Public Const VK_LCONTROL As Integer = &HA2
        Public Const VK_RCONTROL As Integer = &HA3
        Public Const VK_LMENU As Integer = &HA4
        Public Const VK_RMENU As Integer = &HA5
        Public Const VK_BROWSER_BACK As Integer = &HA6
        Public Const VK_BROWSER_FORWARD As Integer = &HA7
        Public Const VK_BROWSER_REFRESH As Integer = &HA8
        Public Const VK_BROWSER_STOP As Integer = &HA9
        Public Const VK_BROWSER_SEARCH As Integer = &HAA
        Public Const VK_BROWSER_FAVORITES As Integer = &HAB
        Public Const VK_BROWSER_HOME As Integer = &HAC
        Public Const VK_VOLUME_MUTE As Integer = &HAD
        Public Const VK_VOLUME_DOWN As Integer = &HAE
        Public Const VK_VOLUME_UP As Integer = &HAF
        Public Const VK_MEDIA_NEXT_TRACK As Integer = &HB0
        Public Const VK_MEDIA_PREV_TRACK As Integer = &HB1
        Public Const VK_MEDIA_STOP As Integer = &HB2
        Public Const VK_MEDIA_PLAY_PAUSE As Integer = &HB3
        Public Const VK_LAUNCH_MAIL As Integer = &HB4
        Public Const VK_LAUNCH_MEDIA_SELECT As Integer = &HB5
        Public Const VK_LAUNCH_APP1 As Integer = &HB6
        Public Const VK_LAUNCH_APP2 As Integer = &HB7
        Public Const VK_OEM_1 As Integer = &HBA
        Public Const VK_OEM_PLUS As Integer = &HBB
        Public Const VK_OEM_COMMA As Integer = &HBC
        Public Const VK_OEM_MINUS As Integer = &HBD
        Public Const VK_OEM_PERIOD As Integer = &HBE
        Public Const VK_OEM_2 As Integer = &HBF
        Public Const VK_OEM_3 As Integer = &HC0
        Public Const VK_OEM_4 As Integer = &HDB
        Public Const VK_OEM_5 As Integer = &HDC
        Public Const VK_OEM_6 As Integer = &HDD
        Public Const VK_OEM_7 As Integer = &HDE
        Public Const VK_OEM_8 As Integer = &HDF
        Public Const VK_OEM_AX As Integer = &HE1
        Public Const VK_OEM_102 As Integer = &HE2
        Public Const VK_ICO_HELP As Integer = &HE3
        Public Const VK_ICO_00 As Integer = &HE4

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           SetWindowsHook
        '
        '           #define WH_MIN              (-1)
        '           #define WH_MSGFILTER        (-1)
        '           #define WH_JOURNALRECORD    0
        '           #define WH_JOURNALPLAYBACK  1
        '           #define WH_KEYBOARD         2
        '           #define WH_GETMESSAGE       3
        '           #define WH_CALLWNDPROC      4
        '           #define WH_CBT              5
        '           #define WH_SYSMSGFILTER     6
        '           #define WH_MOUSE            7
        '           #if defined(_WIN32_WINDOWS)
        '           #define WH_HARDWARE         8
        '           #endif
        '           #define WH_DEBUG            9
        '           #define WH_SHELL           10
        '           #define WH_FOREGROUNDIDLE  11
        '           #if(WINVER >= 0x0400)
        '           #define WH_CALLWNDPROCRET  12
        '           #endif /* WINVER >= 0x0400 */
        '           
        '           #if (_WIN32_WINNT >= 0x0400)
        '           #define WH_KEYBOARD_LL     13
        '           #define WH_MOUSE_LL        14
        '           #endif // (_WIN32_WINNT >= 0x0400)
        '           
        '           #if(WINVER >= 0x0400)
        '           #if (_WIN32_WINNT >= 0x0400)
        '           #define WH_MAX             14
        '           #else
        '           #define WH_MAX             12
        '           #endif // (_WIN32_WINNT >= 0x0400)
        '           #else
        '           #define WH_MAX             11
        '           #endif
        '           
        '           #define WH_MINHOOK         WH_MIN
        '           #define WH_MAXHOOK         WH_MAX
        'by rollrat
        '******************************************************************************
        Public Const WH_MIN As Integer = -1
        Public Const WH_MSGFILTER As Integer = -1
        Public Const WH_JOURNALRECORD As Integer = 0
        Public Const WH_JOURNALPLAYBACK As Integer = 1
        Public Const WH_KEYBOARD As Integer = 2
        Public Const WH_GETMESSAGE As Integer = 3
        Public Const WH_CALLWNDPROC As Integer = 4
        Public Const WH_CBT As Integer = 5
        Public Const WH_SYSMSGFILTER As Integer = 6
        Public Const WH_MOUSE As Integer = 7
        Public Const WH_HARDWARE As Integer = 8
        Public Const WH_DEBUG As Integer = 9
        Public Const WH_SHELL As Integer = 10
        Public Const WH_FOREGROUNDIDLE As Integer = 11
        Public Const WH_CALLWNDPROCRET As Integer = 12
        Public Const WH_KEYBOARD_LL As Integer = 13
        Public Const WH_MOUSE_LL As Integer = 14
        Public Const WH_MAX As Integer = 14

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Hook Codes
        '
        '           #define HC_ACTION           0
        '           #define HC_GETNEXT          1
        '           #define HC_SKIP             2
        '           #define HC_NOREMOVE         3
        '           #define HC_SYSMODALON       4
        '           #define HC_SYSMODALOFF      5
        'by rollrat
        '******************************************************************************
        Public Const HC_ACTION As Integer = 0
        Public Const HC_GETNEXT As Integer = 1
        Public Const HC_SKIP As Integer = 2
        Public Const HC_NOREMOVE As Integer = 3
        Public Const HC_SYSMODALON As Integer = 4
        Public Const HC_SYSMODALOFF As Integer = 5

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           CBT Hook Codes
        '
        '           #define HCBT_MOVESIZE       0
        '           #define HCBT_MINMAX         1
        '           #define HCBT_QS             2
        '           #define HCBT_CREATEWND      3
        '           #define HCBT_DESTROYWND     4
        '           #define HCBT_ACTIVATE       5
        '           #define HCBT_CLICKSKIPPED   6
        '           #define HCBT_KEYSKIPPED     7
        '           #define HCBT_SYSCOMMAND     8
        '           #define HCBT_SETFOCUS       9
        'by rollrat
        '******************************************************************************
        Public Const HCBT_MOVESIZE As Integer = 0
        Public Const HCBT_MINMAX As Integer = 1
        Public Const HCBT_QS As Integer = 2
        Public Const HCBT_CREATEWND As Integer = 3
        Public Const HCBT_DESTROYWND As Integer = 4
        Public Const HCBT_ACTIVATE As Integer = 5
        Public Const HCBT_CLICKSKIPPED As Integer = 6
        Public Const HCBT_KEYSKIPPED As Integer = 7
        Public Const HCBT_SYSCOMMAND As Integer = 8
        Public Const HCBT_SETFOCUS As Integer = 9

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           codes passed in WPARAM for WM_WTSSESSION_CHANGE
        '
        '           #define WTS_CONSOLE_CONNECT                0x1
        '           #define WTS_CONSOLE_DISCONNECT             0x2
        '           #define WTS_REMOTE_CONNECT                 0x3
        '           #define WTS_REMOTE_DISCONNECT              0x4
        '           #define WTS_SESSION_LOGON                  0x5
        '           #define WTS_SESSION_LOGOFF                 0x6
        '           #define WTS_SESSION_LOCK                   0x7
        '           #define WTS_SESSION_UNLOCK                 0x8
        '           #define WTS_SESSION_REMOTE_CONTROL         0x9
        '           #define WTS_SESSION_CREATE                 0xA
        '           #define WTS_SESSION_TERMINATE              0xB
        'by rollrat
        '******************************************************************************
        Public Const WTS_CONSOLE_CONNECT As Integer = &H1
        Public Const WTS_CONSOLE_DISCONNECT As Integer = &H2
        Public Const WTS_REMOTE_CONNECT As Integer = &H3
        Public Const WTS_REMOTE_DISCONNECT As Integer = &H4
        Public Const WTS_SESSION_LOGON As Integer = &H5
        Public Const WTS_SESSION_LOGOFF As Integer = &H6
        Public Const WTS_SESSION_LOCK As Integer = &H7
        Public Const WTS_SESSION_UNLOCK As Integer = &H8
        Public Const WTS_SESSION_REMOTE_CONTROL As Integer = &H9
        Public Const WTS_SESSION_CREATE As Integer = &HA
        Public Const WTS_SESSION_TERMINATE As Integer = &HB

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WH_MSGFILTER Filter Proc Codes
        '
        '           #define MSGF_DIALOGBOX      0
        '           #define MSGF_MESSAGEBOX     1
        '           #define MSGF_MENU           2
        '           #define MSGF_SCROLLBAR      5
        '           #define MSGF_NEXTWINDOW     6
        '           #define MSGF_MAX            8                       // unused
        '           #define MSGF_USER           4096
        'by rollrat
        '******************************************************************************
        Public Const MSGF_DIALOGBOX As Integer = 0
        Public Const MSGF_MESSAGEBOX As Integer = 1
        Public Const MSGF_MENU As Integer = 2
        Public Const MSGF_SCROLLBAR As Integer = 5
        Public Const MSGF_NEXTWINDOW As Integer = 6
        Public Const MSGF_MAX As Integer = 8
        Public Const MSGF_USER As Integer = 4096

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Shell support 
        '
        '           #define HSHELL_WINDOWCREATED        1
        '           #define HSHELL_WINDOWDESTROYED      2
        '           #define HSHELL_ACTIVATESHELLWINDOW  3
        'by rollrat
        '******************************************************************************
        Public Const HSHELL_WINDOWCREATED As Integer = 1
        Public Const HSHELL_WINDOWDESTROYED As Integer = 2
        Public Const HSHELL_ACTIVATESHELLWINDOW As Integer = 3

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Shell support
        '           
        '           #if(WINVER >= 0x0400)
        '           #define HSHELL_WINDOWACTIVATED      4
        '           #define HSHELL_GETMINRECT           5
        '           #define HSHELL_REDRAW               6
        '           #define HSHELL_TASKMAN              7
        '           #define HSHELL_LANGUAGE             8
        '           #define HSHELL_SYSMENU              9
        '           #define HSHELL_ENDTASK              10
        '           #endif /* WINVER >= 0x0400 */
        '           #if(_WIN32_WINNT >= 0x0500)
        '           #define HSHELL_ACCESSIBILITYSTATE   11
        '           #define HSHELL_APPCOMMAND           12
        '           #endif /* _WIN32_WINNT >= 0x0500 */
        '           
        '           #if(_WIN32_WINNT >= 0x0501)
        '           #define HSHELL_WINDOWREPLACED       13
        '           #define HSHELL_WINDOWREPLACING      14
        '           #endif /* _WIN32_WINNT >= 0x0501 */
        '           
        '           
        '           #if(_WIN32_WINNT >= 0x0602)
        '           #define HSHELL_MONITORCHANGED            16
        '           #endif /* _WIN32_WINNT >= 0x0602 */
        '           
        '           #define HSHELL_HIGHBIT            0x8000
        'by rollrat
        '******************************************************************************
        Public Const HSHELL_WINDOWACTIVATED As Integer = 4
        Public Const HSHELL_GETMINRECT As Integer = 5
        Public Const HSHELL_REDRAW As Integer = 6
        Public Const HSHELL_TASKMAN As Integer = 7
        Public Const HSHELL_LANGUAGE As Integer = 8
        Public Const HSHELL_SYSMENU As Integer = 9
        Public Const HSHELL_ENDTASK As Integer = 10
        Public Const HSHELL_ACCESSIBILITYSTATE As Integer = 11
        Public Const HSHELL_APPCOMMAND As Integer = 12
        Public Const HSHELL_WINDOWREPLACED As Integer = 13
        Public Const HSHELL_WINDOWREPLACING As Integer = 14
        Public Const HSHELL_MONITORCHANGED As Integer = 16
        Public Const HSHELL_HIGHBIT As Integer = &H8000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           cmd for HSHELL_APPCOMMAND and WM_APPCOMMAND
        '
        '           #define APPCOMMAND_BROWSER_BACKWARD       1
        '           #define APPCOMMAND_BROWSER_FORWARD        2
        '           #define APPCOMMAND_BROWSER_REFRESH        3
        '           #define APPCOMMAND_BROWSER_STOP           4
        '           #define APPCOMMAND_BROWSER_SEARCH         5
        '           #define APPCOMMAND_BROWSER_FAVORITES      6
        '           #define APPCOMMAND_BROWSER_HOME           7
        '           #define APPCOMMAND_VOLUME_MUTE            8
        '           #define APPCOMMAND_VOLUME_DOWN            9
        '           #define APPCOMMAND_VOLUME_UP              10
        '           #define APPCOMMAND_MEDIA_NEXTTRACK        11
        '           #define APPCOMMAND_MEDIA_PREVIOUSTRACK    12
        '           #define APPCOMMAND_MEDIA_STOP             13
        '           #define APPCOMMAND_MEDIA_PLAY_PAUSE       14
        '           #define APPCOMMAND_LAUNCH_MAIL            15
        '           #define APPCOMMAND_LAUNCH_MEDIA_SELECT    16
        '           #define APPCOMMAND_LAUNCH_APP1            17
        '           #define APPCOMMAND_LAUNCH_APP2            18
        '           #define APPCOMMAND_BASS_DOWN              19
        '           #define APPCOMMAND_BASS_BOOST             20
        '           #define APPCOMMAND_BASS_UP                21
        '           #define APPCOMMAND_TREBLE_DOWN            22
        '           #define APPCOMMAND_TREBLE_UP              23
        '           #if(_WIN32_WINNT >= 0x0501)
        '           #define APPCOMMAND_MICROPHONE_VOLUME_MUTE 24
        '           #define APPCOMMAND_MICROPHONE_VOLUME_DOWN 25
        '           #define APPCOMMAND_MICROPHONE_VOLUME_UP   26
        '           #define APPCOMMAND_HELP                   27
        '           #define APPCOMMAND_FIND                   28
        '           #define APPCOMMAND_NEW                    29
        '           #define APPCOMMAND_OPEN                   30
        '           #define APPCOMMAND_CLOSE                  31
        '           #define APPCOMMAND_SAVE                   32
        '           #define APPCOMMAND_PRINT                  33
        '           #define APPCOMMAND_UNDO                   34
        '           #define APPCOMMAND_REDO                   35
        '           #define APPCOMMAND_COPY                   36
        '           #define APPCOMMAND_CUT                    37
        '           #define APPCOMMAND_PASTE                  38
        '           #define APPCOMMAND_REPLY_TO_MAIL          39
        '           #define APPCOMMAND_FORWARD_MAIL           40
        '           #define APPCOMMAND_SEND_MAIL              41
        '           #define APPCOMMAND_SPELL_CHECK            42
        '           #define APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE    43
        '           #define APPCOMMAND_MIC_ON_OFF_TOGGLE      44
        '           #define APPCOMMAND_CORRECTION_LIST        45
        '           #define APPCOMMAND_MEDIA_PLAY             46
        '           #define APPCOMMAND_MEDIA_PAUSE            47
        '           #define APPCOMMAND_MEDIA_RECORD           48
        '           #define APPCOMMAND_MEDIA_FAST_FORWARD     49
        '           #define APPCOMMAND_MEDIA_REWIND           50
        '           #define APPCOMMAND_MEDIA_CHANNEL_UP       51
        '           #define APPCOMMAND_MEDIA_CHANNEL_DOWN     52
        '           #endif /* _WIN32_WINNT >= 0x0501 */
        '           #if(_WIN32_WINNT >= 0x0600)
        '           #define APPCOMMAND_DELETE                 53
        '           #define APPCOMMAND_DWM_FLIP3D             54
        '           #endif /* _WIN32_WINNT >= 0x0600 */
        'by rollrat
        '******************************************************************************
        Public Const APPCOMMAND_BROWSER_BACKWARD As Integer = 1
        Public Const APPCOMMAND_BROWSER_FORWARD As Integer = 2
        Public Const APPCOMMAND_BROWSER_REFRESH As Integer = 3
        Public Const APPCOMMAND_BROWSER_STOP As Integer = 4
        Public Const APPCOMMAND_BROWSER_SEARCH As Integer = 5
        Public Const APPCOMMAND_BROWSER_FAVORITES As Integer = 6
        Public Const APPCOMMAND_BROWSER_HOME As Integer = 7
        Public Const APPCOMMAND_VOLUME_MUTE As Integer = 8
        Public Const APPCOMMAND_VOLUME_DOWN As Integer = 9
        Public Const APPCOMMAND_VOLUME_UP As Integer = 10
        Public Const APPCOMMAND_MEDIA_NEXTTRACK As Integer = 11
        Public Const APPCOMMAND_MEDIA_PREVIOUSTRACK As Integer = 12
        Public Const APPCOMMAND_MEDIA_STOP As Integer = 13
        Public Const APPCOMMAND_MEDIA_PLAY_PAUSE As Integer = 14
        Public Const APPCOMMAND_LAUNCH_MAIL As Integer = 15
        Public Const APPCOMMAND_LAUNCH_MEDIA_SELECT As Integer = 16
        Public Const APPCOMMAND_LAUNCH_APP1 As Integer = 17
        Public Const APPCOMMAND_LAUNCH_APP2 As Integer = 18
        Public Const APPCOMMAND_BASS_DOWN As Integer = 19
        Public Const APPCOMMAND_BASS_BOOST As Integer = 20
        Public Const APPCOMMAND_BASS_UP As Integer = 21
        Public Const APPCOMMAND_TREBLE_DOWN As Integer = 22
        Public Const APPCOMMAND_TREBLE_UP As Integer = 23
        Public Const APPCOMMAND_MICROPHONE_VOLUME_MUTE As Integer = 24
        Public Const APPCOMMAND_MICROPHONE_VOLUME_DOWN As Integer = 25
        Public Const APPCOMMAND_MICROPHONE_VOLUME_UP As Integer = 26
        Public Const APPCOMMAND_HELP As Integer = 27
        Public Const APPCOMMAND_FIND As Integer = 28
        Public Const APPCOMMAND_NEW As Integer = -1
        Public Const APPCOMMAND_OPEN As Integer = 30
        Public Const APPCOMMAND_CLOSE As Integer = 31
        Public Const APPCOMMAND_SAVE As Integer = 32
        Public Const APPCOMMAND_PRINT As Integer = 33
        Public Const APPCOMMAND_UNDO As Integer = 34
        Public Const APPCOMMAND_REDO As Integer = 35
        Public Const APPCOMMAND_COPY As Integer = 36
        Public Const APPCOMMAND_CUT As Integer = -1
        Public Const APPCOMMAND_PASTE As Integer = 38
        Public Const APPCOMMAND_REPLY_TO_MAIL As Integer = 39
        Public Const APPCOMMAND_FORWARD_MAIL As Integer = 40
        Public Const APPCOMMAND_SEND_MAIL As Integer = 41
        Public Const APPCOMMAND_SPELL_CHECK As Integer = 42
        Public Const APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE As Integer = 43
        Public Const APPCOMMAND_MIC_ON_OFF_TOGGLE As Integer = 44
        Public Const APPCOMMAND_CORRECTION_LIST As Integer = 45
        Public Const APPCOMMAND_MEDIA_PLAY As Integer = 46
        Public Const APPCOMMAND_MEDIA_PAUSE As Integer = 47
        Public Const APPCOMMAND_MEDIA_RECORD As Integer = 48
        Public Const APPCOMMAND_MEDIA_FAST_FORWARD As Integer = 49
        Public Const APPCOMMAND_MEDIA_REWIND As Integer = 50
        Public Const APPCOMMAND_MEDIA_CHANNEL_UP As Integer = 51
        Public Const APPCOMMAND_MEDIA_CHANNEL_DOWN As Integer = 52
        Public Const APPCOMMAND_DELETE As Integer = 53
        Public Const APPCOMMAND_DWM_FLIP3D As Integer = 54
        Public Const FAPPCOMMAND_MOUSE As Integer = &H8000
        Public Const FAPPCOMMAND_KEY As Integer = &H0
        Public Const FAPPCOMMAND_OEM As Integer = &H1000
        Public Const FAPPCOMMAND_MASK As Integer = &HF000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Keyboard Layout API
        '
        '           #define HKL_PREV            0
        '           #define HKL_NEXT            1
        '           
        '           
        '           #define KLF_ACTIVATE        0x00000001
        '           #define KLF_SUBSTITUTE_OK   0x00000002
        '           #define KLF_REORDER         0x00000008
        '           #if(WINVER >= 0x0400)
        '           #define KLF_REPLACELANG     0x00000010
        '           #define KLF_NOTELLSHELL     0x00000080
        '           #endif /* WINVER >= 0x0400 */
        '           #define KLF_SETFORPROCESS   0x00000100
        '           #if(_WIN32_WINNT >= 0x0500)
        '           #define KLF_SHIFTLOCK       0x00010000
        '           #define KLF_RESET           0x40000000
        '           #endif /* _WIN32_WINNT >= 0x0500 */
        'by rollrat
        '******************************************************************************
        Public Const HKL_PREV As Integer = 0
        Public Const HKL_NEXT As Integer = 1
        Public Const KLF_ACTIVATE As Integer = &H1
        Public Const KLF_SUBSTITUTE_OK As Integer = &H2
        Public Const KLF_REORDER As Integer = &H8
        Public Const KLF_REPLACELANG As Integer = &H10
        Public Const KLF_NOTELLSHELL As Integer = &H80
        Public Const KLF_SETFORPROCESS As Integer = &H100
        Public Const KLF_SHIFTLOCK As Integer = &H10000
        Public Const KLF_RESET As Integer = &H40000000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Bits in wParam of WM_INPUTLANGCHANGEREQUEST message
        '
        '           #define INPUTLANGCHANGE_SYSCHARSET 0x0001
        '           #define INPUTLANGCHANGE_FORWARD    0x0002
        '           #define INPUTLANGCHANGE_BACKWARD   0x0004
        'by rollrat
        '******************************************************************************
        Public Const INPUTLANGCHANGE_SYSCHARSET As Integer = &H1
        Public Const INPUTLANGCHANGE_FORWARD As Integer = &H2
        Public Const INPUTLANGCHANGE_BACKWARD As Integer = &H4

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Desktop-specific access flags
        '
        '           #define DESKTOP_READOBJECTS         0x0001
        '           #define DESKTOP_CREATEWINDOW        0x0002
        '           #define DESKTOP_CREATEMENU          0x0004
        '           #define DESKTOP_HOOKCONTROL         0x0008
        '           #define DESKTOP_JOURNALRECORD       0x0010
        '           #define DESKTOP_JOURNALPLAYBACK     0x0020
        '           #define DESKTOP_ENUMERATE           0x0040
        '           #define DESKTOP_WRITEOBJECTS        0x0080
        '           #define DESKTOP_SWITCHDESKTOP       0x0100
        'by rollrat
        '******************************************************************************
        Public Const DESKTOP_READOBJECTS As Integer = &H1
        Public Const DESKTOP_CREATEWINDOW As Integer = &H2
        Public Const DESKTOP_CREATEMENU As Integer = &H4
        Public Const DESKTOP_HOOKCONTROL As Integer = &H8
        Public Const DESKTOP_JOURNALRECORD As Integer = &H10
        Public Const DESKTOP_JOURNALPLAYBACK As Integer = &H20
        Public Const DESKTOP_ENUMERATE As Integer = &H40
        Public Const DESKTOP_WRITEOBJECTS As Integer = &H80
        Public Const DESKTOP_SWITCHDESKTOP As Integer = &H100

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Desktop-specific control flags
        '
        '           #define DF_ALLOWOTHERACCOUNTHOOK    0x0001
        '           
        'by rollrat
        '******************************************************************************
        Public Const DF_ALLOWOTHERACCOUNTHOOK As Integer = &H1

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Windowstation-specific access flags
        '
        '           #define WINSTA_ENUMDESKTOPS         0x0001
        '           #define WINSTA_READATTRIBUTES       0x0002
        '           #define WINSTA_ACCESSCLIPBOARD      0x0004
        '           #define WINSTA_CREATEDESKTOP        0x0008
        '           #define WINSTA_WRITEATTRIBUTES      0x0010
        '           #define WINSTA_ACCESSGLOBALATOMS    0x0020
        '           #define WINSTA_EXITWINDOWS          0x0040
        '           #define WINSTA_ENUMERATE            0x0100
        '           #define WINSTA_READSCREEN           0x0200
        'by rollrat
        '******************************************************************************
        Public Const WINSTA_ENUMDESKTOPS As Integer = &H1
        Public Const WINSTA_READATTRIBUTES As Integer = &H2
        Public Const WINSTA_ACCESSCLIPBOARD As Integer = &H4
        Public Const WINSTA_CREATEDESKTOP As Integer = &H8
        Public Const WINSTA_WRITEATTRIBUTES As Integer = &H10
        Public Const WINSTA_ACCESSGLOBALATOMS As Integer = &H20
        Public Const WINSTA_EXITWINDOWS As Integer = &H40
        Public Const WINSTA_ENUMERATE As Integer = &H100
        Public Const WINSTA_READSCREEN As Integer = &H200

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Window Messages
        '
        '           #define WM_NULL                         0x0000
        '           #define WM_CREATE                       0x0001
        '           #define WM_DESTROY                      0x0002
        '           #define WM_MOVE                         0x0003
        '           #define WM_SIZE                         0x0005
        '           
        '           #define WM_ACTIVATE                     0x0006
        'by rollrat
        '******************************************************************************
        Public Const WM_NULL As Integer = &H0
        Public Const WM_CREATE As Integer = &H1
        Public Const WM_DESTROY As Integer = &H2
        Public Const WM_MOVE As Integer = &H3
        Public Const WM_SIZE As Integer = &H5
        Public Const WM_ACTIVATE As Integer = &H6

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Windows Message
        '
        'by rollrat
        '******************************************************************************
        Public Const WM_SETFOCUS As Integer = &H7
        Public Const WM_KILLFOCUS As Integer = &H8
        Public Const WM_ENABLE As Integer = &HA
        Public Const WM_SETREDRAW As Integer = &HB
        Public Const WM_SETTEXT As Integer = &HC
        Public Const WM_GETTEXT As Integer = &HD
        Public Const WM_GETTEXTLENGTH As Integer = &HE
        Public Const WM_PAINT As Integer = &HF
        Public Const WM_CLOSE As Integer = &H10
        Public Const WM_QUERYENDSESSION As Integer = &H11
        Public Const WM_QUERYOPEN As Integer = &H13
        Public Const WM_ENDSESSION As Integer = &H16
        Public Const WM_QUIT As Integer = &H12
        Public Const WM_ERASEBKGND As Integer = &H14
        Public Const WM_SYSCOLORCHANGE As Integer = &H15
        Public Const WM_SHOWWINDOW As Integer = &H18
        Public Const WM_WININICHANGE As Integer = &H1A
        Public Const WA_INACTIVE As Integer = 0
        Public Const WA_ACTIVE As Integer = 1
        Public Const WA_CLICKACTIVE As Integer = 2
        Public Const WM_DEVMODECHANGE As Integer = &H1B
        Public Const WM_ACTIVATEAPP As Integer = &H1C
        Public Const WM_FONTCHANGE As Integer = &H1D
        Public Const WM_TIMECHANGE As Integer = &H1E
        Public Const WM_CANCELMODE As Integer = &H1F
        Public Const WM_SETCURSOR As Integer = &H20
        Public Const WM_MOUSEACTIVATE As Integer = &H21
        Public Const WM_CHILDACTIVATE As Integer = &H22
        Public Const WM_QUEUESYNC As Integer = &H23
        Public Const WM_GETMINMAXINFO As Integer = &H24
        Public Const WM_PAINTICON As Integer = &H26
        Public Const WM_ICONERASEBKGND As Integer = &H27
        Public Const WM_NEXTDLGCTL As Integer = &H28
        Public Const WM_SPOOLERSTATUS As Integer = &H2A
        Public Const WM_DRAWITEM As Integer = &H2B
        Public Const WM_MEASUREITEM As Integer = &H2C
        Public Const WM_DELETEITEM As Integer = &H2D
        Public Const WM_VKEYTOITEM As Integer = &H2E
        Public Const WM_CHARTOITEM As Integer = &H2F
        Public Const WM_SETFONT As Integer = &H30
        Public Const WM_GETFONT As Integer = &H31
        Public Const WM_SETHOTKEY As Integer = &H32
        Public Const WM_GETHOTKEY As Integer = &H33
        Public Const WM_QUERYDRAGICON As Integer = &H37
        Public Const WM_COMPAREITEM As Integer = &H39
        Public Const WM_GETOBJECT As Integer = &H3D
        Public Const WM_COMPACTING As Integer = &H41
        Public Const WM_COMMNOTIFY As Integer = &H44
        Public Const WM_WINDOWPOSCHANGING As Integer = &H46
        Public Const WM_WINDOWPOSCHANGED As Integer = &H47
        Public Const WM_POWER As Integer = &H48
        Public Const WM_CONTEXTMENU As Integer = &H7B
        Public Const WM_STYLECHANGING As Integer = &H7C
        Public Const WM_STYLECHANGED As Integer = &H7D
        Public Const WM_DISPLAYCHANGE As Integer = &H7E
        Public Const WM_GETICON As Integer = &H7F
        Public Const WM_SETICON As Integer = &H80
        Public Const WM_NCCREATE As Integer = &H81
        Public Const WM_NCDESTROY As Integer = &H82
        Public Const WM_NCCALCSIZE As Integer = &H83
        Public Const WM_NCHITTEST As Integer = &H84
        Public Const WM_NCPAINT As Integer = &H85
        Public Const WM_NCACTIVATE As Integer = &H86
        Public Const WM_GETDLGCODE As Integer = &H87
        Public Const WM_SYNCPAINT As Integer = &H88
        Public Const WM_NCMOUSEMOVE As Integer = &HA0
        Public Const WM_NCLBUTTONDOWN As Integer = &HA1
        Public Const WM_NCLBUTTONUP As Integer = &HA2
        Public Const WM_NCLBUTTONDBLCLK As Integer = &HA3
        Public Const WM_NCRBUTTONDOWN As Integer = &HA4
        Public Const WM_NCRBUTTONUP As Integer = &HA5
        Public Const WM_NCRBUTTONDBLCLK As Integer = &HA6
        Public Const WM_NCMBUTTONDOWN As Integer = &HA7
        Public Const WM_NCMBUTTONUP As Integer = &HA8
        Public Const WM_NCMBUTTONDBLCLK As Integer = &HA9
        Public Const WM_NCXBUTTONDOWN As Integer = &HAB
        Public Const WM_NCXBUTTONUP As Integer = &HAC
        Public Const WM_NCXBUTTONDBLCLK As Integer = &HAD
        Public Const WM_INPUT_DEVICE_CHANGE As Integer = &HFE
        Public Const WM_INPUT As Integer = &HFF
        Public Const WM_KEYFIRST As Integer = &H100
        Public Const WM_KEYDOWN As Integer = &H100
        Public Const WM_KEYUP As Integer = &H101
        Public Const WM_CHAR As Integer = &H102
        Public Const WM_DEADCHAR As Integer = &H103
        Public Const WM_SYSKEYDOWN As Integer = &H104
        Public Const WM_SYSKEYUP As Integer = &H105
        Public Const WM_SYSCHAR As Integer = &H106
        Public Const WM_SYSDEADCHAR As Integer = &H107
        Public Const WM_UNICHAR As Integer = &H109
        Public Const WM_KEYLAST As Integer = &H109
        Public Const UNICODE_NOCHAR As Integer = &HFFFF
        Public Const WM_IME_STARTCOMPOSITION As Integer = &H10D
        Public Const WM_IME_ENDCOMPOSITION As Integer = &H10E
        Public Const WM_IME_COMPOSITION As Integer = &H10F
        Public Const WM_IME_KEYLAST As Integer = &H10F
        Public Const WM_INITDIALOG As Integer = &H110
        Public Const WM_COMMAND As Integer = &H111
        Public Const WM_SYSCOMMAND As Integer = &H112
        Public Const WM_TIMER As Integer = &H113
        Public Const WM_HSCROLL As Integer = &H114
        Public Const WM_VSCROLL As Integer = &H115
        Public Const WM_INITMENU As Integer = &H116
        Public Const WM_INITMENUPOPUP As Integer = &H117
        Public Const WM_GESTURE As Integer = &H119
        Public Const WM_GESTURENOTIFY As Integer = &H11A
        Public Const WM_MENUSELECT As Integer = &H11F
        Public Const WM_MENUCHAR As Integer = &H120
        Public Const WM_ENTERIDLE As Integer = &H121
        Public Const WM_MENURBUTTONUP As Integer = &H122
        Public Const WM_MENUDRAG As Integer = &H123
        Public Const WM_MENUGETOBJECT As Integer = &H124
        Public Const WM_UNINITMENUPOPUP As Integer = &H125
        Public Const WM_MENUCOMMAND As Integer = &H126
        Public Const WM_CHANGEUISTATE As Integer = &H127
        Public Const WM_UPDATEUISTATE As Integer = &H128
        Public Const WM_QUERYUISTATE As Integer = &H129
        Public Const WM_NOTIFY As Integer = &H4E
        Public Const WM_INPUTLANGCHANGEREQUEST As Integer = &H50
        Public Const WM_INPUTLANGCHANGE As Integer = &H51
        Public Const WM_TCARD As Integer = &H52
        Public Const WM_HELP As Integer = &H53
        Public Const WM_USERCHANGED As Integer = &H54
        Public Const WM_NOTIFYFORMAT As Integer = &H55
        Public Const WM_COPYDATA As Integer = &H4A
        Public Const WM_CANCELJOURNAL As Integer = &H4B
        Public Const NFR_ANSI As Integer = 1
        Public Const NFR_UNICODE As Integer = 2
        Public Const NF_QUERY As Integer = 3
        Public Const NF_REQUERY As Integer = 4
        Public Const WM_CTLCOLORMSGBOX As Integer = &H132
        Public Const WM_CTLCOLOREDIT As Integer = &H133
        Public Const WM_CTLCOLORLISTBOX As Integer = &H134
        Public Const WM_CTLCOLORBTN As Integer = &H135
        Public Const WM_CTLCOLORDLG As Integer = &H136
        Public Const WM_CTLCOLORSCROLLBAR As Integer = &H137
        Public Const WM_CTLCOLORSTATIC As Integer = &H138
        Public Const MN_GETHMENU As Integer = &H1E1
        Public Const WM_MOUSEFIRST As Integer = &H200
        Public Const WM_MOUSEMOVE As Integer = &H200
        Public Const WM_LBUTTONDOWN As Integer = &H201
        Public Const WM_LBUTTONUP As Integer = &H202
        Public Const WM_LBUTTONDBLCLK As Integer = &H203
        Public Const WM_RBUTTONDOWN As Integer = &H204
        Public Const WM_RBUTTONUP As Integer = &H205
        Public Const WM_RBUTTONDBLCLK As Integer = &H206
        Public Const WM_MBUTTONDOWN As Integer = &H207
        Public Const WM_MBUTTONUP As Integer = &H208
        Public Const WM_MBUTTONDBLCLK As Integer = &H209
        Public Const WM_MOUSEWHEEL As Integer = &H20A
        Public Const WM_XBUTTONDOWN As Integer = &H20B
        Public Const WM_XBUTTONUP As Integer = &H20C
        Public Const WM_XBUTTONDBLCLK As Integer = &H20D
        Public Const WM_MOUSEHWHEEL As Integer = &H20E
        Public Const WM_MOUSELAST As Integer = &H20E
        Public Const WHEEL_DELTA As Integer = 120
        Public Const XBUTTON1 As Integer = &H1
        Public Const XBUTTON2 As Integer = &H2
        Public Const WM_PARENTNOTIFY As Integer = &H210
        Public Const WM_ENTERMENULOOP As Integer = &H211
        Public Const WM_EXITMENULOOP As Integer = &H212
        Public Const WM_NEXTMENU As Integer = &H213
        Public Const WM_SIZING As Integer = &H214
        Public Const WM_CAPTURECHANGED As Integer = &H215
        Public Const WM_MOVING As Integer = &H216
        Public Const WM_POWERBROADCAST As Integer = &H218
        Public Const PBT_APMQUERYSUSPEND As Integer = &H0
        Public Const PBT_APMQUERYSTANDBY As Integer = &H1
        Public Const PBT_APMQUERYSUSPENDFAILED As Integer = &H2
        Public Const PBT_APMQUERYSTANDBYFAILED As Integer = &H3
        Public Const PBT_APMSUSPEND As Integer = &H4
        Public Const PBT_APMSTANDBY As Integer = &H5
        Public Const PBT_APMRESUMECRITICAL As Integer = &H6
        Public Const PBT_APMRESUMESUSPEND As Integer = &H7
        Public Const PBT_APMRESUMESTANDBY As Integer = &H8
        Public Const PBTF_APMRESUMEFROMFAILURE As Integer = &H1
        Public Const PBT_APMBATTERYLOW As Integer = &H9
        Public Const PBT_APMPOWERSTATUSCHANGE As Integer = &HA
        Public Const PBT_APMOEMEVENT As Integer = &HB
        Public Const PBT_APMRESUMEAUTOMATIC As Integer = &H12
        Public Const PBT_POWERSETTINGCHANGE As Integer = &H8013
        Public Const WM_DEVICECHANGE As Integer = &H219
        Public Const WM_MDICREATE As Integer = &H220
        Public Const WM_MDIDESTROY As Integer = &H221
        Public Const WM_MDIACTIVATE As Integer = &H222
        Public Const WM_MDIRESTORE As Integer = &H223
        Public Const WM_MDINEXT As Integer = &H224
        Public Const WM_MDIMAXIMIZE As Integer = &H225
        Public Const WM_MDITILE As Integer = &H226
        Public Const WM_MDICASCADE As Integer = &H227
        Public Const WM_MDIICONARRANGE As Integer = &H228
        Public Const WM_MDIGETACTIVE As Integer = &H229
        Public Const WM_MDISETMENU As Integer = &H230
        Public Const WM_ENTERSIZEMOVE As Integer = &H231
        Public Const WM_EXITSIZEMOVE As Integer = &H232
        Public Const WM_DROPFILES As Integer = &H233
        Public Const WM_MDIREFRESHMENU As Integer = &H234
        Public Const WM_POINTERDEVICECHANGE As Integer = &H238
        Public Const WM_POINTERDEVICEINRANGE As Integer = &H239
        Public Const WM_POINTERDEVICEOUTOFRANGE As Integer = &H23A
        Public Const WM_TOUCH As Integer = &H240
        Public Const WM_NCPOINTERUPDATE As Integer = &H241
        Public Const WM_NCPOINTERDOWN As Integer = &H242
        Public Const WM_NCPOINTERUP As Integer = &H243
        Public Const WM_POINTERUPDATE As Integer = &H245
        Public Const WM_POINTERDOWN As Integer = &H246
        Public Const WM_POINTERUP As Integer = &H247
        Public Const WM_POINTERENTER As Integer = &H249
        Public Const WM_POINTERLEAVE As Integer = &H24A
        Public Const WM_POINTERACTIVATE As Integer = &H24B
        Public Const WM_POINTERCAPTURECHANGED As Integer = &H24C
        Public Const WM_TOUCHHITTESTING As Integer = &H24D
        Public Const WM_POINTERWHEEL As Integer = &H24E
        Public Const WM_POINTERHWHEEL As Integer = &H24F
        Public Const WM_IME_SETCONTEXT As Integer = &H281
        Public Const WM_IME_NOTIFY As Integer = &H282
        Public Const WM_IME_CONTROL As Integer = &H283
        Public Const WM_IME_COMPOSITIONFULL As Integer = &H284
        Public Const WM_IME_SELECT As Integer = &H285
        Public Const WM_IME_CHAR As Integer = &H286
        Public Const WM_IME_REQUEST As Integer = &H288
        Public Const WM_IME_KEYDOWN As Integer = &H290
        Public Const WM_IME_KEYUP As Integer = &H291
        Public Const WM_MOUSEHOVER As Integer = &H2A1
        Public Const WM_MOUSELEAVE As Integer = &H2A3
        Public Const WM_NCMOUSEHOVER As Integer = &H2A0
        Public Const WM_NCMOUSELEAVE As Integer = &H2A2
        Public Const WM_WTSSESSION_CHANGE As Integer = &H2B1
        Public Const WM_TABLET_FIRST As Integer = &H2C0
        Public Const WM_TABLET_LAST As Integer = &H2DF
        Public Const WM_CUT As Integer = &H300
        Public Const WM_COPY As Integer = &H301
        Public Const WM_PASTE As Integer = &H302
        Public Const WM_CLEAR As Integer = &H303
        Public Const WM_UNDO As Integer = &H304
        Public Const WM_RENDERFORMAT As Integer = &H305
        Public Const WM_RENDERALLFORMATS As Integer = &H306
        Public Const WM_DESTROYCLIPBOARD As Integer = &H307
        Public Const WM_DRAWCLIPBOARD As Integer = &H308
        Public Const WM_PAINTCLIPBOARD As Integer = &H309
        Public Const WM_VSCROLLCLIPBOARD As Integer = &H30A
        Public Const WM_SIZECLIPBOARD As Integer = &H30B
        Public Const WM_ASKCBFORMATNAME As Integer = &H30C
        Public Const WM_CHANGECBCHAIN As Integer = &H30D
        Public Const WM_HSCROLLCLIPBOARD As Integer = &H30E
        Public Const WM_QUERYNEWPALETTE As Integer = &H30F
        Public Const WM_PALETTEISCHANGING As Integer = &H310
        Public Const WM_PALETTECHANGED As Integer = &H311
        Public Const WM_HOTKEY As Integer = &H312
        Public Const WM_PRINT As Integer = &H317
        Public Const WM_PRINTCLIENT As Integer = &H318
        Public Const WM_APPCOMMAND As Integer = &H319
        Public Const WM_THEMECHANGED As Integer = &H31A
        Public Const WM_CLIPBOARDUPDATE As Integer = &H31D
        Public Const WM_DWMCOMPOSITIONCHANGED As Integer = &H31E
        Public Const WM_DWMNCRENDERINGCHANGED As Integer = &H31F
        Public Const WM_DWMCOLORIZATIONCOLORCHANGED As Integer = &H320
        Public Const WM_DWMWINDOWMAXIMIZEDCHANGE As Integer = &H321
        Public Const WM_DWMSENDICONICTHUMBNAIL As Integer = &H323
        Public Const WM_DWMSENDICONICLIVEPREVIEWBITMAP As Integer = &H326
        Public Const WM_GETTITLEBARINFOEX As Integer = &H33F
        Public Const WM_HANDHELDFIRST As Integer = &H358
        Public Const WM_HANDHELDLAST As Integer = &H35F
        Public Const WM_AFXFIRST As Integer = &H360
        Public Const WM_AFXLAST As Integer = &H37F
        Public Const WM_PENWINFIRST As Integer = &H380
        Public Const WM_PENWINLAST As Integer = &H38F
        Public Const WM_APP As Integer = &H8000
        Public Const WS_OVERLAPPED As Integer = &H0
        Public Const WS_POPUP As Integer = &H80000000
        Public Const WS_CHILD As Integer = &H40000000
        Public Const WS_MINIMIZE As Integer = &H20000000
        Public Const WS_VISIBLE As Integer = &H10000000
        Public Const WS_DISABLED As Integer = &H8000000
        Public Const WS_CLIPSIBLINGS As Integer = &H4000000
        Public Const WS_CLIPCHILDREN As Integer = &H2000000
        Public Const WS_MAXIMIZE As Integer = &H1000000
        Public Const WS_CAPTION As Integer = &HC00000
        Public Const WS_BORDER As Integer = &H800000
        Public Const WS_DLGFRAME As Integer = &H400000
        Public Const WS_VSCROLL As Integer = &H200000
        Public Const WS_HSCROLL As Integer = &H100000
        Public Const WS_SYSMENU As Integer = &H80000
        Public Const WS_THICKFRAME As Integer = &H40000
        Public Const WS_GROUP As Integer = &H20000
        Public Const WS_TABSTOP As Integer = &H10000
        Public Const WS_MINIMIZEBOX As Integer = &H20000
        Public Const WS_MAXIMIZEBOX As Integer = &H10000
        Public Const WS_EX_DLGMODALFRAME As Integer = &H1
        Public Const WS_EX_NOPARENTNOTIFY As Integer = &H4
        Public Const WS_EX_TOPMOST As Integer = &H8
        Public Const WS_EX_ACCEPTFILES As Integer = &H10
        Public Const WS_EX_TRANSPARENT As Integer = &H20
        Public Const WS_EX_MDICHILD As Integer = &H40
        Public Const WS_EX_TOOLWINDOW As Integer = &H80
        Public Const WS_EX_WINDOWEDGE As Integer = &H100
        Public Const WS_EX_CLIENTEDGE As Integer = &H200
        Public Const WS_EX_CONTEXTHELP As Integer = &H400
        Public Const WS_EX_RIGHT As Integer = &H1000
        Public Const WS_EX_LEFT As Integer = &H0
        Public Const WS_EX_RTLREADING As Integer = &H2000
        Public Const WS_EX_LTRREADING As Integer = &H0
        Public Const WS_EX_LEFTSCROLLBAR As Integer = &H4000
        Public Const WS_EX_RIGHTSCROLLBAR As Integer = &H0
        Public Const WS_EX_CONTROLPARENT As Integer = &H10000
        Public Const WS_EX_STATICEDGE As Integer = &H20000
        Public Const WS_EX_APPWINDOW As Integer = &H40000
        Public Const WS_EX_LAYERED As Integer = &H80000
        Public Const WS_EX_NOINHERITLAYOUT As Integer = &H100000
        Public Const WS_EX_NOREDIRECTIONBITMAP As Integer = &H200000
        Public Const WS_EX_LAYOUTRTL As Integer = &H400000
        Public Const WS_EX_COMPOSITED As Integer = &H2000000
        Public Const WS_EX_NOACTIVATE As Integer = &H8000000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           wParam for WM_POWER window message and DRV_POWER driver notification
        '
        '           #define PWR_OK              1
        '           #define PWR_SUSPENDREQUEST  1
        '           #define PWR_SUSPENDRESUME   2
        '           #define PWR_CRITICALRESUME  3
        'by rollrat
        '******************************************************************************
        Public Const PWR_SUSPENDREQUEST As Integer = 1
        Public Const PWR_OK As Integer = 1
        Public Const PWR_FAIL As Integer = -1
        Public Const PWR_SUSPENDRESUME As Integer = 2
        Public Const PWR_CRITICALRESUME As Integer = 3


        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           LOWORD(wParam) values in WM_*UISTATE*
        '
        '           #define UIS_SET          1
        '           #define UIS_CLEAR            2
        '           #define UIS_INITIALIZE         3
        '           
        'by rollrat
        '******************************************************************************
        Public Const UIS_SET As Integer = 1
        Public Const UIS_CLEAR As Integer = 2
        Public Const UIS_INITIALIZE As Integer = 3

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           HIWORD(wParam) values in WM_*UISTATE*
        '
        '           #define UISF_HIDEFOCUS                  0x1
        '           #define UISF_HIDEACCEL                  0x2
        '           #if(_WIN32_WINNT >= 0x0501)
        '           #define UISF_ACTIVE                     0x4
        'by rollrat
        '******************************************************************************
        Public Const UISF_HIDEFOCUS As Integer = &H1
        Public Const UISF_HIDEACCEL As Integer = &H2
        Public Const UISF_ACTIVE As Integer = &H4

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           wParam for WM_SIZING message
        '
        '           #define WMSZ_LEFT           1
        '           #define WMSZ_RIGHT          2
        '           #define WMSZ_TOP            3
        '           #define WMSZ_TOPLEFT        4
        '           #define WMSZ_TOPRIGHT       5
        '           #define WMSZ_BOTTOM         6
        '           #define WMSZ_BOTTOMLEFT     7
        '           #define WMSZ_BOTTOMRIGHT    8
        'by rollrat
        '******************************************************************************
        Public Const WMSZ_LEFT As Integer = 1
        Public Const WMSZ_RIGHT As Integer = 2
        Public Const WMSZ_TOP As Integer = 3
        Public Const WMSZ_TOPLEFT As Integer = 4
        Public Const WMSZ_TOPRIGHT As Integer = 5
        Public Const WMSZ_BOTTOM As Integer = 6
        Public Const WMSZ_BOTTOMLEFT As Integer = 7
        Public Const WMSZ_BOTTOMRIGHT As Integer = 8

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WM_NCHITTEST and MOUSEHOOKSTRUCT Mouse Position Codes
        '
        '           #define HTOBJECT            19
        '           #define HTCLOSE             20
        '           #define HTHELP              21
        '           #define HTMENU              5
        '           #define HTHSCROLL           6
        '           #define HTVSCROLL           7
        '           #define HTMINBUTTON         8
        '           #define HTMAXBUTTON         9
        '           #define HTLEFT              10
        '           #define HTRIGHT             11
        '           #define HTTOP               12
        '           #define HTTOPLEFT           13
        '           #define HTTOPRIGHT          14
        '           #define HTBOTTOM            15
        '           #define HTBOTTOMLEFT        16
        '           #define HTBOTTOMRIGHT       17
        '           #define HTBORDER            18
        '           #define HTNOWHERE           0
        '           #define HTCLIENT            1
        '           #define HTCAPTION           2
        '           #define HTSYSMENU           3
        '           #define HTGROWBOX           4
        '           #define HTERROR             -2
        '           #define HTTRANSPARENT       -1
        'by rollrat
        '******************************************************************************
        Public Const HTOBJECT As Integer = 19
        Public Const HTCLOSE As Integer = 20
        Public Const HTHELP As Integer = 21
        Public Const HTMENU As Integer = 5
        Public Const HTHSCROLL As Integer = 6
        Public Const HTVSCROLL As Integer = 7
        Public Const HTMINBUTTON As Integer = 8
        Public Const HTMAXBUTTON As Integer = 9
        Public Const HTLEFT As Integer = 10
        Public Const HTRIGHT As Integer = 11
        Public Const HTTOP As Integer = 12
        Public Const HTTOPLEFT As Integer = 13
        Public Const HTTOPRIGHT As Integer = 14
        Public Const HTBOTTOM As Integer = 15
        Public Const HTBOTTOMLEFT As Integer = 16
        Public Const HTBOTTOMRIGHT As Integer = 17
        Public Const HTBORDER As Integer = 18
        Public Const HTNOWHERE As Integer = 0
        Public Const HTCLIENT As Integer = 1
        Public Const HTCAPTION As Integer = 2
        Public Const HTSYSMENU As Integer = 3
        Public Const HTGROWBOX As Integer = 4
        Public Const HTERROR As Integer = -2
        Public Const HTTRANSPARENT As Integer = -1

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           SendMessageTimeout values
        'by rollrat
        '******************************************************************************
        Public Const SMTO_NORMAL As Integer = &H0
        Public Const SMTO_BLOCK As Integer = &H1
        Public Const SMTO_ABORTIFHUNG As Integer = &H2
        Public Const SMTO_NOTIMEOUTIFNOTHUNG As Integer = &H8
        Public Const SMTO_ERRORONEXIT As Integer = &H20

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WM_MOUSEACTIVATE Return Codes
        '
        '           #define MA_ACTIVATE         1
        '           #define MA_ACTIVATEANDEAT   2
        '           #define MA_NOACTIVATE       3
        '           #define MA_NOACTIVATEANDEAT 4
        'by rollrat
        '******************************************************************************
        Public Const MA_ACTIVATE As Integer = 1
        Public Const MA_ACTIVATEANDEAT As Integer = 2
        Public Const MA_NOACTIVATE As Integer = 3
        Public Const MA_NOACTIVATEANDEAT As Integer = 4

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WM_SETICON / WM_GETICON Type Codes
        '
        '           #define ICON_SMALL          0
        '           #define ICON_BIG            1
        '           #define ICON_SMALL2         2
        'by rollrat
        '******************************************************************************
        Public Const ICON_SMALL As Integer = 0
        Public Const ICON_BIG As Integer = 1
        Public Const ICON_SMALL2 As Integer = 2

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WM_SIZE message wParam values
        '
        '           #define SIZE_RESTORED       0
        '           #define SIZE_MINIMIZED      1
        '           #define SIZE_MAXIMIZED      2
        '           #define SIZE_MAXSHOW        3
        '           #define SIZE_MAXHIDE        4
        'by rollrat
        '******************************************************************************
        Public Const SIZE_RESTORED As Integer = 0
        Public Const SIZE_MINIMIZED As Integer = 1
        Public Const SIZE_MAXIMIZED As Integer = 2
        Public Const SIZE_MAXSHOW As Integer = 3
        Public Const SIZE_MAXHIDE As Integer = 4

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WM_NCCALCSIZE "window valid rect" return values
        '
        '           #define WVR_ALIGNTOP        0x0010
        '           #define WVR_ALIGNLEFT       0x0020
        '           #define WVR_ALIGNBOTTOM     0x0040
        '           #define WVR_ALIGNRIGHT      0x0080
        '           #define WVR_HREDRAW         0x0100
        '           #define WVR_VREDRAW         0x0200
        'by rollrat
        '******************************************************************************
        Public Const WVR_ALIGNTOP As Integer = &H10
        Public Const WVR_ALIGNLEFT As Integer = &H20
        Public Const WVR_ALIGNBOTTOM As Integer = &H40
        Public Const WVR_ALIGNRIGHT As Integer = &H80
        Public Const WVR_HREDRAW As Integer = &H100
        Public Const WVR_VREDRAW As Integer = &H200
        Public Const WVR_REDRAW As Integer = &H300
        Public Const WVR_VALIDRECTS As Integer = &H400

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Key State Masks for Mouse Messages
        '
        '           #define MK_LBUTTON          0x0001
        '           #define MK_RBUTTON          0x0002
        '           #define MK_SHIFT            0x0004
        '           #define MK_CONTROL          0x0008
        '           #define MK_MBUTTON          0x0010
        '           #if(_WIN32_WINNT >= 0x0500)
        '           #define MK_XBUTTON1         0x0020
        '           #define MK_XBUTTON2         0x0040
        'by rollrat
        '******************************************************************************
        Public Const MK_LBUTTON As Integer = &H1
        Public Const MK_RBUTTON As Integer = &H2
        Public Const MK_SHIFT As Integer = &H4
        Public Const MK_CONTROL As Integer = &H8
        Public Const MK_MBUTTON As Integer = &H10
        Public Const MK_XBUTTON1 As Integer = &H20
        Public Const MK_XBUTTON2 As Integer = &H40
        Public Const TME_HOVER As Integer = &H1
        Public Const TME_LEAVE As Integer = &H2
        Public Const TME_NONCLIENT As Integer = &H10
        Public Const TME_QUERY As Integer = &H40000000
        Public Const TME_CANCEL As Integer = &H80000000
        Public Const HOVER_DEFAULT As Integer = &HFFFFFFFF

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Class styles
        '
        '           #define CS_VREDRAW          0x0001
        '           #define CS_HREDRAW          0x0002
        '           #define CS_DBLCLKS          0x0008
        '           #define CS_OWNDC            0x0020
        '           #define CS_CLASSDC          0x0040
        '           #define CS_PARENTDC         0x0080
        '           #define CS_NOCLOSE          0x0200
        '           #define CS_SAVEBITS         0x0800
        '           #define CS_BYTEALIGNCLIENT  0x1000
        '           #define CS_BYTEALIGNWINDOW  0x2000
        '           #define CS_GLOBALCLASS      0x4000
        '           
        '           #define CS_IME              0x00010000
        '           #if(_WIN32_WINNT >= 0x0501)
        '           #define CS_DROPSHADOW       0x00020000
        'by rollrat
        '******************************************************************************
        Public Const CS_VREDRAW As Integer = &H1
        Public Const CS_HREDRAW As Integer = &H2
        Public Const CS_DBLCLKS As Integer = &H8
        Public Const CS_OWNDC As Integer = &H20
        Public Const CS_CLASSDC As Integer = &H40
        Public Const CS_PARENTDC As Integer = &H80
        Public Const CS_NOCLOSE As Integer = &H200
        Public Const CS_SAVEBITS As Integer = &H800
        Public Const CS_BYTEALIGNCLIENT As Integer = &H1000
        Public Const CS_BYTEALIGNWINDOW As Integer = &H2000
        Public Const CS_GLOBALCLASS As Integer = &H4000
        Public Const CS_IME As Integer = &H10000
        Public Const CS_DROPSHADOW As Integer = &H20000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WM_PRINT flags
        '
        '           #define PRF_CHECKVISIBLE    0x00000001
        '           #define PRF_NONCLIENT       0x00000002
        '           #define PRF_CLIENT          0x00000004
        '           #define PRF_ERASEBKGND      0x00000008
        '           #define PRF_CHILDREN        0x00000010
        '           #define PRF_OWNED           0x00000020
        'by rollrat
        '******************************************************************************
        Public Const PRF_CHECKVISIBLE As Integer = &H1
        Public Const PRF_NONCLIENT As Integer = &H2
        Public Const PRF_CLIENT As Integer = &H4
        Public Const PRF_ERASEBKGND As Integer = &H8
        Public Const PRF_CHILDREN As Integer = &H10
        Public Const PRF_OWNED As Integer = &H20

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           3D border styles
        '
        '           #define BDR_RAISEDOUTER 0x0001
        '           #define BDR_SUNKENOUTER 0x0002
        '           #define BDR_RAISEDINNER 0x0004
        '           #define BDR_SUNKENINNER 0x0008
        '           
        '           #define BDR_OUTER       (BDR_RAISEDOUTER | BDR_SUNKENOUTER)
        '           #define BDR_INNER       (BDR_RAISEDINNER | BDR_SUNKENINNER)
        '           #define BDR_RAISED      (BDR_RAISEDOUTER | BDR_RAISEDINNER)
        '           #define BDR_SUNKEN      (BDR_SUNKENOUTER | BDR_SUNKENINNER)
        '           
        '           
        '           #define EDGE_RAISED     (BDR_RAISEDOUTER | BDR_RAISEDINNER)
        '           #define EDGE_SUNKEN     (BDR_SUNKENOUTER | BDR_SUNKENINNER)
        '           #define EDGE_ETCHED     (BDR_SUNKENOUTER | BDR_RAISEDINNER)
        '           #define EDGE_BUMP       (BDR_RAISEDOUTER | BDR_SUNKENINNER)
        'by rollrat
        '******************************************************************************
        Public Const BDR_RAISEDOUTER As Integer = &H1
        Public Const BDR_SUNKENOUTER As Integer = &H2
        Public Const BDR_RAISEDINNER As Integer = &H4
        Public Const BDR_SUNKENINNER As Integer = &H8

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Border flags
        '
        '           #define BF_LEFT         0x0001
        '           #define BF_TOP          0x0002
        '           #define BF_RIGHT        0x0004
        '           #define BF_BOTTOM       0x0008
        '           
        '           #define BF_TOPLEFT      (BF_TOP | BF_LEFT)
        '           #define BF_TOPRIGHT     (BF_TOP | BF_RIGHT)
        '           #define BF_BOTTOMLEFT   (BF_BOTTOM | BF_LEFT)
        '           #define BF_BOTTOMRIGHT  (BF_BOTTOM | BF_RIGHT)
        '           #define BF_RECT         (BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM)
        '           
        '           #define BF_DIAGONAL     0x0010
        'by rollrat
        '******************************************************************************
        Public Const BF_LEFT As Integer = &H1
        Public Const BF_TOP As Integer = &H2
        Public Const BF_RIGHT As Integer = &H4
        Public Const BF_BOTTOM As Integer = &H8
        Public Const BF_DIAGONAL As Integer = &H10
        Public Const BF_MIDDLE As Integer = &H800
        Public Const BF_SOFT As Integer = &H1000
        Public Const BF_ADJUST As Integer = &H2000
        Public Const BF_FLAT As Integer = &H4000
        Public Const BF_MONO As Integer = &H8000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           flags for DrawFrameControl
        '
        '           #define DFC_CAPTION             1
        '           #define DFC_MENU                2
        '           #define DFC_SCROLL              3
        '           #define DFC_BUTTON              4
        '           #if(WINVER >= 0x0500)
        '           #define DFC_POPUPMENU           5
        '           #endif /* WINVER >= 0x0500 */
        '           
        '           #define DFCS_CAPTIONCLOSE       0x0000
        '           #define DFCS_CAPTIONMIN         0x0001
        '           #define DFCS_CAPTIONMAX         0x0002
        '           #define DFCS_CAPTIONRESTORE     0x0003
        '           #define DFCS_CAPTIONHELP        0x0004
        '           
        '           #define DFCS_MENUARROW          0x0000
        '           #define DFCS_MENUCHECK          0x0001
        '           #define DFCS_MENUBULLET         0x0002
        '           #define DFCS_MENUARROWRIGHT     0x0004
        '           #define DFCS_SCROLLUP           0x0000
        '           #define DFCS_SCROLLDOWN         0x0001
        '           #define DFCS_SCROLLLEFT         0x0002
        '           #define DFCS_SCROLLRIGHT        0x0003
        '           #define DFCS_SCROLLCOMBOBOX     0x0005
        '           #define DFCS_SCROLLSIZEGRIP     0x0008
        '           #define DFCS_SCROLLSIZEGRIPRIGHT 0x0010
        '           
        '           #define DFCS_BUTTONCHECK        0x0000
        '           #define DFCS_BUTTONRADIOIMAGE   0x0001
        '           #define DFCS_BUTTONRADIOMASK    0x0002
        '           #define DFCS_BUTTONRADIO        0x0004
        '           #define DFCS_BUTTON3STATE       0x0008
        '           #define DFCS_BUTTONPUSH         0x0010
        '           
        '           #define DFCS_INACTIVE           0x0100
        '           #define DFCS_PUSHED             0x0200
        '           #define DFCS_CHECKED            0x0400
        '           
        '           #if(WINVER >= 0x0500)
        '           #define DFCS_TRANSPARENT        0x0800
        '           #define DFCS_HOT                0x1000
        '           #endif /* WINVER >= 0x0500 */
        '           
        '           #define DFCS_ADJUSTRECT         0x2000
        '           #define DFCS_FLAT               0x4000
        '           #define DFCS_MONO               0x8000
        'by rollrat
        '******************************************************************************
        Public Const DFC_CAPTION As Integer = &H1
        Public Const DFC_MENU As Integer = &H2
        Public Const DFC_SCROLL As Integer = &H3
        Public Const DFC_BUTTON As Integer = &H4
        Public Const DFC_POPUPMENU As Integer = &H5
        Public Const DFCS_CAPTIONCLOSE As Integer = &H0
        Public Const DFCS_CAPTIONMIN As Integer = &H1
        Public Const DFCS_CAPTIONMAX As Integer = &H2
        Public Const DFCS_CAPTIONRESTORE As Integer = &H3
        Public Const DFCS_CAPTIONHELP As Integer = &H4
        Public Const DFCS_MENUARROW As Integer = &H0
        Public Const DFCS_MENUCHECK As Integer = &H1
        Public Const DFCS_MENUBULLET As Integer = &H2
        Public Const DFCS_MENUARROWRIGHT As Integer = &H4
        Public Const DFCS_SCROLLUP As Integer = &H0
        Public Const DFCS_SCROLLDOWN As Integer = &H1
        Public Const DFCS_SCROLLLEFT As Integer = &H2
        Public Const DFCS_SCROLLRIGHT As Integer = &H3
        Public Const DFCS_SCROLLCOMBOBOX As Integer = &H5
        Public Const DFCS_SCROLLSIZEGRIP As Integer = &H8
        Public Const DFCS_SCROLLSIZEGRIPRIGHT As Integer = &H10
        Public Const DFCS_BUTTONCHECK As Integer = &H0
        Public Const DFCS_BUTTONRADIOIMAGE As Integer = &H1
        Public Const DFCS_BUTTONRADIOMASK As Integer = &H2
        Public Const DFCS_BUTTONRADIO As Integer = &H4
        Public Const DFCS_BUTTON3STATE As Integer = &H8
        Public Const DFCS_BUTTONPUSH As Integer = &H10
        Public Const DFCS_INACTIVE As Integer = &H100
        Public Const DFCS_PUSHED As Integer = &H200
        Public Const DFCS_CHECKED As Integer = &H400
        Public Const DFCS_TRANSPARENT As Integer = &H800
        Public Const DFCS_HOT As Integer = &H1000
        Public Const DFCS_ADJUSTRECT As Integer = &H2000
        Public Const DFCS_FLAT As Integer = &H4000
        Public Const DFCS_MONO As Integer = &H8000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           flags for DrawCaption
        '
        '           #define DC_ACTIVE           0x0001
        '           #define DC_SMALLCAP         0x0002
        '           #define DC_ICON             0x0004
        '           #define DC_TEXT             0x0008
        '           #define DC_INBUTTON         0x0010
        '           #if(WINVER >= 0x0500)
        '           #define DC_GRADIENT         0x0020
        '           #endif /* WINVER >= 0x0500 */
        '           #if(_WIN32_WINNT >= 0x0501)
        '           #define DC_BUTTONS          0x1000
        'by rollrat
        '******************************************************************************
        Public Const DC_ACTIVE As Integer = &H1
        Public Const DC_SMALLCAP As Integer = &H2
        Public Const DC_ICON As Integer = &H4
        Public Const DC_TEXT As Integer = &H8
        Public Const DC_INBUTTON As Integer = &H10
        Public Const DC_GRADIENT As Integer = &H20
        Public Const DC_BUTTONS As Integer = &H1000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Predefined Clipboard Formats
        '
        '           #define CF_TEXT             1
        '           #define CF_BITMAP           2
        '           #define CF_METAFILEPICT     3
        '           #define CF_SYLK             4
        '           #define CF_DIF              5
        '           #define CF_TIFF             6
        '           #define CF_OEMTEXT          7
        '           #define CF_DIB              8
        '           #define CF_PALETTE          9
        '           #define CF_PENDATA          10
        '           #define CF_RIFF             11
        '           #define CF_WAVE             12
        '           #define CF_UNICODETEXT      13
        '           #define CF_ENHMETAFILE      14
        '           #if(WINVER >= 0x0400)
        '           #define CF_HDROP            15
        '           #define CF_LOCALE           16
        '           #endif /* WINVER >= 0x0400 */
        '           #if(WINVER >= 0x0500)
        '           #define CF_DIBV5            17
        '           #endif /* WINVER >= 0x0500 */
        '           
        '           #if(WINVER >= 0x0500)
        '           #define CF_MAX              18
        '           #elif(WINVER >= 0x0400)
        '           #define CF_MAX              17
        '           #else
        '           #define CF_MAX              15
        '           #endif
        '           
        '           #define CF_OWNERDISPLAY     0x0080
        '           #define CF_DSPTEXT          0x0081
        '           #define CF_DSPBITMAP        0x0082
        '           #define CF_DSPMETAFILEPICT  0x0083
        '           #define CF_DSPENHMETAFILE   0x008E
        'by rollrat
        '******************************************************************************
        Public Const CF_TEXT As Integer = 1
        Public Const CF_BITMAP As Integer = 2
        Public Const CF_METAFILEPICT As Integer = 3
        Public Const CF_SYLK As Integer = 4
        Public Const CF_DIF As Integer = 5
        Public Const CF_TIFF As Integer = 6
        Public Const CF_OEMTEXT As Integer = 7
        Public Const CF_DIB As Integer = 8
        Public Const CF_PALETTE As Integer = 9
        Public Const CF_PENDATA As Integer = 10
        Public Const CF_RIFF As Integer = 11
        Public Const CF_WAVE As Integer = 12
        Public Const CF_UNICODETEXT As Integer = 13
        Public Const CF_ENHMETAFILE As Integer = 14
        Public Const CF_HDROP As Integer = 15
        Public Const CF_LOCALE As Integer = 16
        Public Const CF_DIBV5 As Integer = 17
        Public Const CF_MAX As Integer = 18
        Public Const CF_OWNERDISPLAY As Integer = &H80
        Public Const CF_DSPTEXT As Integer = &H81
        Public Const CF_DSPBITMAP As Integer = &H82
        Public Const CF_DSPMETAFILEPICT As Integer = &H83
        Public Const CF_DSPENHMETAFILE As Integer = &H8E

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Defines for the fVirt field of the Accelerator table structure.
        '
        '           #define FVIRTKEY  1
        '           #define FNOINVERT 0x02
        '           #define FSHIFT    0x04
        '           #define FCONTROL  0x08
        '           #define FALT      0x10
        'by rollrat
        '******************************************************************************
        Public Const FVIRTKEY As Integer = 1
        Public Const FNOINVERT As Integer = &H2
        Public Const FSHIFT As Integer = &H4
        Public Const FCONTROL As Integer = &H8
        Public Const FALT As Integer = &H10

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Edit Control Messages
        '
        '           #define ES_LEFT             0x0000
        '           #define ES_CENTER           0x0001
        '           #define ES_RIGHT            0x0002
        '           #define ES_MULTILINE        0x0004
        '           #define ES_UPPERCASE        0x0008
        '           #define ES_LOWERCASE        0x0010
        '           #define ES_PASSWORD         0x0020
        '           #define ES_AUTOVSCROLL      0x0040
        '           #define ES_AUTOHSCROLL      0x0080
        '           #define ES_NOHIDESEL        0x0100
        '           #define ES_OEMCONVERT       0x0400
        '           #define ES_READONLY         0x0800
        '           #define ES_WANTRETURN       0x1000
        '           #if(WINVER >= 0x0400)
        '           #define ES_NUMBER           0x2000
        '           #endif /* WINVER >= 0x0400 */
        '           
        '           
        '           #endif /* !NOWINSTYLES */
        '           
        '           /*
        '            * Edit Control Notification Codes
        '            */
        '           #define EN_SETFOCUS         0x0100
        '           #define EN_KILLFOCUS        0x0200
        '           #define EN_CHANGE           0x0300
        '           #define EN_UPDATE           0x0400
        '           #define EN_ERRSPACE         0x0500
        '           #define EN_MAXTEXT          0x0501
        '           #define EN_HSCROLL          0x0601
        '           #define EN_VSCROLL          0x0602
        '           
        '           #if(_WIN32_WINNT >= 0x0500)
        '           #define EN_ALIGN_LTR_EC     0x0700
        '           #define EN_ALIGN_RTL_EC     0x0701
        '           #endif /* _WIN32_WINNT >= 0x0500 */
        '           
        '           #if(WINVER >= 0x0400)
        '           /* Edit control EM_SETMARGIN parameters */
        '           #define EC_LEFTMARGIN       0x0001
        '           #define EC_RIGHTMARGIN      0x0002
        '           #define EC_USEFONTINFO      0xffff
        '           #endif /* WINVER >= 0x0400 */
        '           
        '           #if(WINVER >= 0x0500)
        '           /* wParam of EM_GET/SETIMESTATUS  */
        '           #define EMSIS_COMPOSITIONSTRING        0x0001
        '           
        '           /* lParam for EMSIS_COMPOSITIONSTRING  */
        '           #define EIMES_GETCOMPSTRATONCE         0x0001
        '           #define EIMES_CANCELCOMPSTRINFOCUS     0x0002
        '           #define EIMES_COMPLETECOMPSTRKILLFOCUS 0x0004
        '           #endif /* WINVER >= 0x0500 */
        '           
        '           #ifndef NOWINMESSAGES
        '           
        '           
        '           /*
        '            * Edit Control Messages
        '            */
        '           #define EM_GETSEL               0x00B0
        '           #define EM_SETSEL               0x00B1
        '           #define EM_GETRECT              0x00B2
        '           #define EM_SETRECT              0x00B3
        '           #define EM_SETRECTNP            0x00B4
        '           #define EM_SCROLL               0x00B5
        '           #define EM_LINESCROLL           0x00B6
        '           #define EM_SCROLLCARET          0x00B7
        '           #define EM_GETMODIFY            0x00B8
        '           #define EM_SETMODIFY            0x00B9
        '           #define EM_GETLINECOUNT         0x00BA
        '           #define EM_LINEINDEX            0x00BB
        '           #define EM_SETHANDLE            0x00BC
        '           #define EM_GETHANDLE            0x00BD
        '           #define EM_GETTHUMB             0x00BE
        '           #define EM_LINELENGTH           0x00C1
        '           #define EM_REPLACESEL           0x00C2
        '           #define EM_GETLINE              0x00C4
        '           #define EM_LIMITTEXT            0x00C5
        '           #define EM_CANUNDO              0x00C6
        '           #define EM_UNDO                 0x00C7
        '           #define EM_FMTLINES             0x00C8
        '           #define EM_LINEFROMCHAR         0x00C9
        '           #define EM_SETTABSTOPS          0x00CB
        '           #define EM_SETPASSWORDCHAR      0x00CC
        '           #define EM_EMPTYUNDOBUFFER      0x00CD
        '           #define EM_GETFIRSTVISIBLELINE  0x00CE
        '           #define EM_SETREADONLY          0x00CF
        '           #define EM_SETWORDBREAKPROC     0x00D0
        '           #define EM_GETWORDBREAKPROC     0x00D1
        '           #define EM_GETPASSWORDCHAR      0x00D2
        '           #if(WINVER >= 0x0400)
        '           #define EM_SETMARGINS           0x00D3
        '           #define EM_GETMARGINS           0x00D4
        '           #define EM_SETLIMITTEXT         EM_LIMITTEXT   /* ;win40 Name change */
        '           #define EM_GETLIMITTEXT         0x00D5
        '           #define EM_POSFROMCHAR          0x00D6
        '           #define EM_CHARFROMPOS          0x00D7
        '           #endif /* WINVER >= 0x0400 */
        '           
        '           #if(WINVER >= 0x0500)
        '           #define EM_SETIMESTATUS         0x00D8
        '           #define EM_GETIMESTATUS         0x00D9
        'by rollrat
        '******************************************************************************
        Public Const ES_LEFT As Integer = &H0
        Public Const ES_CENTER As Integer = &H1
        Public Const ES_RIGHT As Integer = &H2
        Public Const ES_MULTILINE As Integer = &H4
        Public Const ES_UPPERCASE As Integer = &H8
        Public Const ES_LOWERCASE As Integer = &H10
        Public Const ES_PASSWORD As Integer = &H20
        Public Const ES_AUTOVSCROLL As Integer = &H40
        Public Const ES_AUTOHSCROLL As Integer = &H80
        Public Const ES_NOHIDESEL As Integer = &H100
        Public Const ES_OEMCONVERT As Integer = &H400
        Public Const ES_READONLY As Integer = &H800
        Public Const ES_WANTRETURN As Integer = &H1000
        Public Const ES_NUMBER As Integer = &H2000
        Public Const EN_SETFOCUS As Integer = &H100
        Public Const EN_KILLFOCUS As Integer = &H200
        Public Const EN_CHANGE As Integer = &H300
        Public Const EN_UPDATE As Integer = &H400
        Public Const EN_ERRSPACE As Integer = &H500
        Public Const EN_MAXTEXT As Integer = &H501
        Public Const EN_HSCROLL As Integer = &H601
        Public Const EN_VSCROLL As Integer = &H602
        Public Const EN_ALIGN_LTR_EC As Integer = &H700
        Public Const EN_ALIGN_RTL_EC As Integer = &H701
        Public Const EC_LEFTMARGIN As Integer = &H1
        Public Const EC_RIGHTMARGIN As Integer = &H2
        Public Const EC_USEFONTINFO As Integer = &HFFFF
        Public Const EMSIS_COMPOSITIONSTRING As Integer = &H1
        Public Const EIMES_GETCOMPSTRATONCE As Integer = &H1
        Public Const EIMES_CANCELCOMPSTRINFOCUS As Integer = &H2
        Public Const EIMES_COMPLETECOMPSTRKILLFOCUS As Integer = &H4
        Public Const EM_GETSEL As Integer = &HB0
        Public Const EM_SETSEL As Integer = &HB1
        Public Const EM_GETRECT As Integer = &HB2
        Public Const EM_SETRECT As Integer = &HB3
        Public Const EM_SETRECTNP As Integer = &HB4
        Public Const EM_SCROLL As Integer = &HB5
        Public Const EM_LINESCROLL As Integer = &HB6
        Public Const EM_SCROLLCARET As Integer = &HB7
        Public Const EM_GETMODIFY As Integer = &HB8
        Public Const EM_SETMODIFY As Integer = &HB9
        Public Const EM_GETLINECOUNT As Integer = &HBA
        Public Const EM_LINEINDEX As Integer = &HBB
        Public Const EM_SETHANDLE As Integer = &HBC
        Public Const EM_GETHANDLE As Integer = &HBD
        Public Const EM_GETTHUMB As Integer = &HBE
        Public Const EM_LINELENGTH As Integer = &HC1
        Public Const EM_REPLACESEL As Integer = &HC2
        Public Const EM_GETLINE As Integer = &HC4
        Public Const EM_LIMITTEXT As Integer = &HC5
        Public Const EM_CANUNDO As Integer = &HC6
        Public Const EM_UNDO As Integer = &HC7
        Public Const EM_FMTLINES As Integer = &HC8
        Public Const EM_LINEFROMCHAR As Integer = &HC9
        Public Const EM_SETTABSTOPS As Integer = &HCB
        Public Const EM_SETPASSWORDCHAR As Integer = &HCC
        Public Const EM_EMPTYUNDOBUFFER As Integer = &HCD
        Public Const EM_GETFIRSTVISIBLELINE As Integer = &HCE
        Public Const EM_SETREADONLY As Integer = &HCF
        Public Const EM_SETWORDBREAKPROC As Integer = &HD0
        Public Const EM_GETWORDBREAKPROC As Integer = &HD1
        Public Const EM_GETPASSWORDCHAR As Integer = &HD2
        Public Const EM_SETMARGINS As Integer = &HD3
        Public Const EM_GETMARGINS As Integer = &HD4
        Public Const EM_GETLIMITTEXT As Integer = &HD5
        Public Const EM_POSFROMCHAR As Integer = &HD6
        Public Const EM_CHARFROMPOS As Integer = &HD7
        Public Const EM_SETIMESTATUS As Integer = &HD8
        Public Const EM_GETIMESTATUS As Integer = &HD9

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Button Control Styles
        '
        '           #define BS_PUSHBUTTON       0x00000000
        '           #define BS_DEFPUSHBUTTON    0x00000001
        '           #define BS_CHECKBOX         0x00000002
        '           #define BS_AUTOCHECKBOX     0x00000003
        '           #define BS_RADIOBUTTON      0x00000004
        '           #define BS_3STATE           0x00000005
        '           #define BS_AUTO3STATE       0x00000006
        '           #define BS_GROUPBOX         0x00000007
        '           #define BS_USERBUTTON       0x00000008
        '           #define BS_AUTORADIOBUTTON  0x00000009
        '           #define BS_PUSHBOX          0x0000000A
        '           #define BS_OWNERDRAW        0x0000000B
        '           #define BS_TYPEMASK         0x0000000F
        '           #define BS_LEFTTEXT         0x00000020
        '           #if(WINVER >= 0x0400)
        '           #define BS_TEXT             0x00000000
        '           #define BS_ICON             0x00000040
        '           #define BS_BITMAP           0x00000080
        '           #define BS_LEFT             0x00000100
        '           #define BS_RIGHT            0x00000200
        '           #define BS_CENTER           0x00000300
        '           #define BS_TOP              0x00000400
        '           #define BS_BOTTOM           0x00000800
        '           #define BS_VCENTER          0x00000C00
        '           #define BS_PUSHLIKE         0x00001000
        '           #define BS_MULTILINE        0x00002000
        '           #define BS_NOTIFY           0x00004000
        '           #define BS_FLAT             0x00008000
        'by rollrat
        '******************************************************************************
        Public Const BS_PUSHBUTTON As Integer = &H0
        Public Const BS_DEFPUSHBUTTON As Integer = &H1
        Public Const BS_CHECKBOX As Integer = &H2
        Public Const BS_AUTOCHECKBOX As Integer = &H3
        Public Const BS_RADIOBUTTON As Integer = &H4
        Public Const BS_3STATE As Integer = &H5
        Public Const BS_AUTO3STATE As Integer = &H6
        Public Const BS_GROUPBOX As Integer = &H7
        Public Const BS_USERBUTTON As Integer = &H8
        Public Const BS_AUTORADIOBUTTON As Integer = &H9
        Public Const BS_PUSHBOX As Integer = &HA
        Public Const BS_OWNERDRAW As Integer = &HB
        Public Const BS_TYPEMASK As Integer = &HF
        Public Const BS_LEFTTEXT As Integer = &H20
        Public Const BS_TEXT As Integer = &H0
        Public Const BS_ICON As Integer = &H40
        Public Const BS_BITMAP As Integer = &H80
        Public Const BS_LEFT As Integer = &H100
        Public Const BS_RIGHT As Integer = &H200
        Public Const BS_CENTER As Integer = &H300
        Public Const BS_TOP As Integer = &H400
        Public Const BS_BOTTOM As Integer = &H800
        Public Const BS_VCENTER As Integer = &HC00
        Public Const BS_PUSHLIKE As Integer = &H1000
        Public Const BS_MULTILINE As Integer = &H2000
        Public Const BS_NOTIFY As Integer = &H4000
        Public Const BS_FLAT As Integer = &H8000

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           WINAPI_FAMILY_PARTITION(WINAPI_PARTITION_DESKTOP)
        '
        '           #define LWA_COLORKEY            0x00000001
        '           #define LWA_ALPHA               0x00000002
        '           
        '           #define ULW_COLORKEY            0x00000001
        '           #define ULW_ALPHA               0x00000002
        '           #define ULW_OPAQUE              0x00000004
        '           
        '           #define ULW_EX_NORESIZE         0x00000008
        'by rollrat
        '******************************************************************************
        Public Const LWA_COLORKEY As Integer = &H1
        Public Const LWA_ALPHA As Integer = &H2
        Public Const ULW_COLORKEY As Integer = &H1
        Public Const ULW_ALPHA As Integer = &H2
        Public Const ULW_OPAQUE As Integer = &H4
        Public Const ULW_EX_NORESIZE As Integer = &H8

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           Window field offsets for GetWindowLong
        '
        '           #define GWL_WNDPROC         (-4)
        '           #define GWL_HINSTANCE       (-6)
        '           #define GWL_HWNDPARENT      (-8)
        '           #define GWL_STYLE           (-16)
        '           #define GWL_EXSTYLE         (-20)
        '           #define GWL_USERDATA        (-21)
        '           #define GWL_ID              (-12)
        'by rollrat
        '******************************************************************************
        Public Const GWL_WNDPROC As Integer = -4
        Public Const GWL_HINSTANCE As Integer = -6
        Public Const GWL_HWNDPARENT As Integer = -8
        Public Const GWL_STYLE As Integer = -16
        Public Const GWL_EXSTYLE As Integer = -20
        Public Const GWL_USERDATA As Integer = -21
        Public Const GWL_ID As Integer = -12

        '******************************************************************************
        'MicroSoft & <WinUser.h>
        '
        '           SetWindowPos Flags
        '
        'by rollrat
        '******************************************************************************
        Public Const SWP_NOSIZE As Integer = &H1
        Public Const SWP_NOMOVE As Integer = &H2
        Public Const SWP_NOZORDER As Integer = &H4
        Public Const SWP_NOREDRAW As Integer = &H8
        Public Const SWP_NOACTIVATE As Integer = &H10
        Public Const SWP_FRAMECHANGED As Integer = &H20
        Public Const SWP_SHOWWINDOW As Integer = &H40
        Public Const SWP_HIDEWINDOW As Integer = &H80
        Public Const SWP_NOCOPYBITS As Integer = &H100
        Public Const SWP_NOOWNERZORDER As Integer = &H200
        Public Const SWP_NOSENDCHANGING As Integer = &H400
        Public Const SWP_DEFERERASE As Integer = &H2000
        Public Const SWP_ASYNCWINDOWPOS As Integer = &H4000



        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class WinApiImm
        '******************************************************************************
        'MicroSoft & <Imm.h>
        '
        '       IMM Defined
        '           
        'by rollrat
        '******************************************************************************
        Public Const IMC_GETCANDIDATEPOS As Integer = &H7
        Public Const IMC_SETCANDIDATEPOS As Integer = &H8
        Public Const IMC_GETCOMPOSITIONFONT As Integer = &H9
        Public Const IMC_SETCOMPOSITIONFONT As Integer = &HA
        Public Const IMC_GETCOMPOSITIONWINDOW As Integer = &HB
        Public Const IMC_SETCOMPOSITIONWINDOW As Integer = &HC
        Public Const IMC_GETSTATUSWINDOWPOS As Integer = &HF
        Public Const IMC_SETSTATUSWINDOWPOS As Integer = &H10
        Public Const IMC_CLOSESTATUSWINDOW As Integer = &H21
        Public Const IMC_OPENSTATUSWINDOW As Integer = &H22
        Public Const NI_OPENCANDIDATE As Integer = &H10
        Public Const NI_CLOSECANDIDATE As Integer = &H11
        Public Const NI_SELECTCANDIDATESTR As Integer = &H12
        Public Const NI_CHANGECANDIDATELIST As Integer = &H13
        Public Const NI_FINALIZECONVERSIONRESULT As Integer = &H14
        Public Const NI_COMPOSITIONSTR As Integer = &H15
        Public Const NI_SETCANDIDATE_PAGESTART As Integer = &H16
        Public Const NI_SETCANDIDATE_PAGESIZE As Integer = &H17
        Public Const NI_IMEMENUSELECTED As Integer = &H18
        Public Const ISC_SHOWUICANDIDATEWINDOW As Integer = &H1
        Public Const ISC_SHOWUICOMPOSITIONWINDOW As Integer = &H80000000
        Public Const ISC_SHOWUIGUIDELINE As Integer = &H40000000
        Public Const ISC_SHOWUIALLCANDIDATEWINDOW As Integer = &HF
        Public Const ISC_SHOWUIALL As Integer = &HC000000F
        Public Const CPS_COMPLETE As Integer = &H1
        Public Const CPS_CONVERT As Integer = &H2
        Public Const CPS_REVERT As Integer = &H3
        Public Const CPS_CANCEL As Integer = &H4
        Public Const MOD_ALT As Integer = &H1
        Public Const MOD_CONTROL As Integer = &H2
        Public Const MOD_SHIFT As Integer = &H4
        Public Const MOD_LEFT As Integer = &H8000
        Public Const MOD_RIGHT As Integer = &H4000
        Public Const MOD_ON_KEYUP As Integer = &H800
        Public Const MOD_IGNORE_ALL_MODIFIER As Integer = &H400
        Public Const IME_CHOTKEY_IME_NONIME_TOGGLE As Integer = &H10
        Public Const IME_CHOTKEY_SHAPE_TOGGLE As Integer = &H11
        Public Const IME_CHOTKEY_SYMBOL_TOGGLE As Integer = &H12
        Public Const IME_JHOTKEY_CLOSE_OPEN As Integer = &H30
        Public Const IME_KHOTKEY_SHAPE_TOGGLE As Integer = &H50
        Public Const IME_KHOTKEY_HANJACONVERT As Integer = &H51
        Public Const IME_KHOTKEY_ENGLISH As Integer = &H52
        Public Const IME_THOTKEY_IME_NONIME_TOGGLE As Integer = &H70
        Public Const IME_THOTKEY_SHAPE_TOGGLE As Integer = &H71
        Public Const IME_THOTKEY_SYMBOL_TOGGLE As Integer = &H72
        Public Const IME_HOTKEY_DSWITCH_FIRST As Integer = &H100
        Public Const IME_HOTKEY_DSWITCH_LAST As Integer = &H11F
        Public Const IME_HOTKEY_PRIVATE_FIRST As Integer = &H200
        Public Const IME_ITHOTKEY_RESEND_RESULTSTR As Integer = &H200
        Public Const IME_ITHOTKEY_PREVIOUS_COMPOSITION As Integer = &H201
        Public Const IME_ITHOTKEY_UISTYLE_TOGGLE As Integer = &H202
        Public Const IME_ITHOTKEY_RECONVERTSTRING As Integer = &H203
        Public Const IME_HOTKEY_PRIVATE_LAST As Integer = &H21F
        Public Const GCS_COMPREADSTR As Integer = &H1
        Public Const GCS_COMPREADATTR As Integer = &H2
        Public Const GCS_COMPREADCLAUSE As Integer = &H4
        Public Const GCS_COMPSTR As Integer = &H8
        Public Const GCS_COMPATTR As Integer = &H10
        Public Const GCS_COMPCLAUSE As Integer = &H20
        Public Const GCS_CURSORPOS As Integer = &H80
        Public Const GCS_DELTASTART As Integer = &H100
        Public Const GCS_RESULTREADSTR As Integer = &H200
        Public Const GCS_RESULTREADCLAUSE As Integer = &H400
        Public Const GCS_RESULTSTR As Integer = &H800
        Public Const GCS_RESULTCLAUSE As Integer = &H1000
        Public Const CS_INSERTCHAR As Integer = &H2000
        Public Const CS_NOMOVECARET As Integer = &H4000
        Public Const IMEVER_0310 As Integer = &H3000A
        Public Const IMEVER_0400 As Integer = &H40000
        Public Const IME_PROP_AT_CARET As Integer = &H10000
        Public Const IME_PROP_SPECIAL_UI As Integer = &H20000
        Public Const IME_PROP_CANDLIST_START_FROM_1 As Integer = &H40000
        Public Const IME_PROP_UNICODE As Integer = &H80000
        Public Const IME_PROP_COMPLETE_ON_UNSELECT As Integer = &H100000
        Public Const UI_CAP_2700 As Integer = &H1
        Public Const UI_CAP_ROT90 As Integer = &H2
        Public Const UI_CAP_ROTANY As Integer = &H4
        Public Const SCS_CAP_COMPSTR As Integer = &H1
        Public Const SCS_CAP_MAKEREAD As Integer = &H2
        Public Const SCS_CAP_SETRECONVERTSTRING As Integer = &H4
        Public Const SELECT_CAP_CONVERSION As Integer = &H1
        Public Const SELECT_CAP_SENTENCE As Integer = &H2
        Public Const GGL_LEVEL As Integer = &H1
        Public Const GGL_INDEX As Integer = &H2
        Public Const GGL_STRING As Integer = &H3
        Public Const GGL_PRIVATE As Integer = &H4
        Public Const GL_LEVEL_NOGUIDELINE As Integer = &H0
        Public Const GL_LEVEL_FATAL As Integer = &H1
        Public Const GL_LEVEL_ERROR As Integer = &H2
        Public Const GL_LEVEL_WARNING As Integer = &H3
        Public Const GL_LEVEL_INFORMATION As Integer = &H4
        Public Const GL_ID_UNKNOWN As Integer = &H0
        Public Const GL_ID_NOMODULE As Integer = &H1
        Public Const GL_ID_NODICTIONARY As Integer = &H10
        Public Const GL_ID_CANNOTSAVE As Integer = &H11
        Public Const GL_ID_NOCONVERT As Integer = &H20
        Public Const GL_ID_TYPINGERROR As Integer = &H21
        Public Const GL_ID_TOOMANYSTROKE As Integer = &H22
        Public Const GL_ID_READINGCONFLICT As Integer = &H23
        Public Const GL_ID_INPUTREADING As Integer = &H24
        Public Const GL_ID_INPUTRADICAL As Integer = &H25
        Public Const GL_ID_INPUTCODE As Integer = &H26
        Public Const GL_ID_INPUTSYMBOL As Integer = &H27
        Public Const GL_ID_CHOOSECANDIDATE As Integer = &H28
        Public Const GL_ID_REVERSECONVERSION As Integer = &H29
        Public Const GL_ID_PRIVATE_FIRST As Integer = &H8000
        Public Const GL_ID_PRIVATE_LAST As Integer = &HFFFF
        Public Const IGP_PROPERTY As Integer = &H4
        Public Const IGP_CONVERSION As Integer = &H8
        Public Const IGP_SENTENCE As Integer = &HC
        Public Const IGP_UI As Integer = &H10
        Public Const IGP_SETCOMPSTR As Integer = &H14
        Public Const IGP_SELECT As Integer = &H18
        Public Const SCS_SETRECONVERTSTRING As Integer = &H10000
        Public Const SCS_QUERYRECONVERTSTRING As Integer = &H20000
        Public Const ATTR_INPUT As Integer = &H0
        Public Const ATTR_TARGET_CONVERTED As Integer = &H1
        Public Const ATTR_CONVERTED As Integer = &H2
        Public Const ATTR_TARGET_NOTCONVERTED As Integer = &H3
        Public Const ATTR_INPUT_ERROR As Integer = &H4
        Public Const ATTR_FIXEDCONVERTED As Integer = &H5
        Public Const CFS_DEFAULT As Integer = &H0
        Public Const CFS_RECT As Integer = &H1
        Public Const CFS_POINT As Integer = &H2
        Public Const CFS_FORCE_POSITION As Integer = &H20
        Public Const CFS_CANDIDATEPOS As Integer = &H40
        Public Const CFS_EXCLUDE As Integer = &H80
        Public Const GCL_CONVERSION As Integer = &H1
        Public Const GCL_REVERSECONVERSION As Integer = &H2
        Public Const GCL_REVERSE_LENGTH As Integer = &H3
        Public Const IME_CMODE_SOFTKBD As Integer = &H80
        Public Const IME_CMODE_NOCONVERSION As Integer = &H100
        Public Const IME_CMODE_EUDC As Integer = &H200
        Public Const IME_CMODE_SYMBOL As Integer = &H400
        Public Const IME_CMODE_FIXED As Integer = &H800
        Public Const IME_CMODE_RESERVED As Integer = &HF0000000
        Public Const IME_SMODE_NONE As Integer = &H0
        Public Const IME_SMODE_PLAURALCLAUSE As Integer = &H1
        Public Const IME_SMODE_SINGLECONVERT As Integer = &H2
        Public Const IME_SMODE_AUTOMATIC As Integer = &H4
        Public Const IME_SMODE_PHRASEPREDICT As Integer = &H8
        Public Const IME_SMODE_CONVERSATION As Integer = &H10
        Public Const IME_SMODE_RESERVED As Integer = &HF000
        Public Const IME_CAND_UNKNOWN As Integer = &H0
        Public Const IME_CAND_READ As Integer = &H1
        Public Const IME_CAND_CODE As Integer = &H2
        Public Const IME_CAND_MEANING As Integer = &H3
        Public Const IME_CAND_RADICAL As Integer = &H4
        Public Const IME_CAND_STROKE As Integer = &H5
        Public Const IMN_CLOSESTATUSWINDOW As Integer = &H1
        Public Const IMN_OPENSTATUSWINDOW As Integer = &H2
        Public Const IMN_CHANGECANDIDATE As Integer = &H3
        Public Const IMN_CLOSECANDIDATE As Integer = &H4
        Public Const IMN_OPENCANDIDATE As Integer = &H5
        Public Const IMN_SETCONVERSIONMODE As Integer = &H6
        Public Const IMN_SETSENTENCEMODE As Integer = &H7
        Public Const IMN_SETOPENSTATUS As Integer = &H8
        Public Const IMN_SETCANDIDATEPOS As Integer = &H9
        Public Const IMN_SETCOMPOSITIONFONT As Integer = &HA
        Public Const IMN_SETCOMPOSITIONWINDOW As Integer = &HB
        Public Const IMN_SETSTATUSWINDOWPOS As Integer = &HC
        Public Const IMN_GUIDELINE As Integer = &HD
        Public Const IMN_PRIVATE As Integer = &HE
        Public Const IMR_COMPOSITIONWINDOW As Integer = &H1
        Public Const IMR_CANDIDATEWINDOW As Integer = &H2
        Public Const IMR_COMPOSITIONFONT As Integer = &H3
        Public Const IMR_RECONVERTSTRING As Integer = &H4
        Public Const IMR_CONFIRMRECONVERTSTRING As Integer = &H5
        Public Const IMR_QUERYCHARPOSITION As Integer = &H6
        Public Const IMR_DOCUMENTFEED As Integer = &H7
        Public Const IMM_ERROR_NODATA As Integer = -1
        Public Const IMM_ERROR_GENERAL As Integer = -2
        Public Const IME_CONFIG_GENERAL As Integer = &H1
        Public Const IME_CONFIG_REGISTERWORD As Integer = &H2
        Public Const IME_CONFIG_SELECTDICTIONARY As Integer = &H3
        Public Const IME_ESC_QUERY_SUPPORT As Integer = &H3
        Public Const IME_ESC_RESERVED_FIRST As Integer = &H4
        Public Const IME_ESC_RESERVED_LAST As Integer = &H7FF
        Public Const IME_ESC_PRIVATE_FIRST As Integer = &H800
        Public Const IME_ESC_PRIVATE_LAST As Integer = &HFFF
        Public Const IME_ESC_SEQUENCE_TO_INTERNAL As Integer = &H1001
        Public Const IME_ESC_GET_EUDC_DICTIONARY As Integer = &H1003
        Public Const IME_ESC_SET_EUDC_DICTIONARY As Integer = &H1004
        Public Const IME_ESC_MAX_KEY As Integer = &H1005
        Public Const IME_ESC_IME_NAME As Integer = &H1006
        Public Const IME_ESC_SYNC_HOTKEY As Integer = &H1007
        Public Const IME_ESC_HANJA_MODE As Integer = &H1008
        Public Const IME_ESC_AUTOMATA As Integer = &H1009
        Public Const IME_ESC_PRIVATE_HOTKEY As Integer = &H100A
        Public Const IME_ESC_GETHELPFILENAME As Integer = &H100B
        Public Const IME_REGWORD_STYLE_EUDC As Integer = &H1
        Public Const IME_REGWORD_STYLE_USER_FIRST As Integer = &H80000000
        Public Const IME_REGWORD_STYLE_USER_LAST As Integer = &HFFFFFFFF
        Public Const IACE_CHILDREN As Integer = &H1
        Public Const IACE_DEFAULT As Integer = &H10
        Public Const IACE_IGNORENOCONTEXT As Integer = &H20
        Public Const IGIMIF_RIGHTMENU As Integer = &H1
        Public Const IGIMII_CMODE As Integer = &H1
        Public Const IGIMII_SMODE As Integer = &H2
        Public Const IGIMII_CONFIGURE As Integer = &H4
        Public Const IGIMII_TOOLS As Integer = &H8
        Public Const IGIMII_HELP As Integer = &H10
        Public Const IGIMII_OTHER As Integer = &H20
        Public Const IGIMII_INPUTTOOLS As Integer = &H40
        Public Const IMFT_RADIOCHECK As Integer = &H1
        Public Const IMFT_SEPARATOR As Integer = &H2
        Public Const IMFT_SUBMENU As Integer = &H4

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class WinApi
        Public Declare Function GetProcAddress Lib "kernel32" Alias "GetProcAddress" (ByVal hModule As Long, ByVal lpProcName As String) As Long
        Public Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (ByVal lpLibFileName As String) As Long
        Public Declare Function VirtualAllocEx Lib "kernel32" Alias "VirtualAllocEx" (ByVal hProcess As Long, lpAddress As Object, ByVal dwSize As Long, ByVal fAllocType As Long, FlProtect As Long) As Long
        Public Declare Function WriteProcessMemory Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Long, ByVal lpBaseAddress As Object, lpBuffer As Object, ByVal nSize As Long, lpNumberOfBytesWritten As Long) As Long
        Public Declare Function CreateRemoteThread Lib "kernel32" Alias "CreateRemoteThread" (ByVal ProcessHandle As Long, lpThreadAttributes As Long, ByVal dwStackSize As Long, ByVal lpStartAddress As Object, ByVal lpParameter As Object, ByVal dwCreationFlags As Long, lpThreadID As Long) As Long
        Public Declare Ansi Function Beep Lib "kernel32" Alias "Beep" (dwFreq As UInteger, dwDuration As UInteger) As Boolean
        Public Declare Ansi Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
        Public Declare Ansi Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
        Public Declare Ansi Function FlashWindow Lib "user32" Alias "FlashWindow" (hwnd As IntPtr, bInvert As Boolean) As Boolean
        Public Declare Function VkKeyScanEx Lib "user32" Alias "VkKeyScanExA" (ByVal ch As Byte, ByVal dwhkl As Long) As Integer
        Public Declare Ansi Function SetWindowText Lib "user32.lib" Alias "SetWindowText" (hwnd As IntPtr, lpString As String) As Boolean
        Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
        Public Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Integer)
        Public Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean
        Public Declare Function OpenProcess Lib "kernel32" Alias "OpenProcess" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer
        Public Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal Classname As String, ByVal WindowName As String) As Integer
        Public Declare Function GetWindowThreadProcessId Lib "user32" Alias "GetWindowThreadProcessId" (ByVal hWnd As Integer, ByRef lpdwProcessId As Integer) As Integer
        Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)
        Public Declare Function GetMessageExtraInfo Lib "user32" Alias "GetMessageExtraInfo" () As Long
        Public Declare Function CreateToolhelpSnapshot Lib "kernel32" Alias "CreateToolhelp32Snapshot" (ByVal lFlags As Integer, ByVal lProcessID As Integer) As Integer
        Public Declare Function Process32First Lib "kernel32" Alias "Process32First" (ByVal hSnapShot As Integer, ByRef uProcess As PROCESSENTRY32) As Integer
        Public Declare Function Process32Next Lib "kernel32" Alias "Process32Next" (ByVal hSnapShot As Integer, ByRef uProcess As PROCESSENTRY32) As Integer
        Public Declare Sub CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hPass As Integer)
        Public Declare Function CreateRemoteThreads Lib "kernel32" Alias "CreateRemoteThreads" (ByVal hProcess As Long, ByVal lpSecurityAttributes As Long, ByVal dwStackSize As Long, ByVal lpThreadProc As Long, ByVal lpParameters As Long, ByVal dwCreateFlags As Long, F As Long) As Long
        Public Declare Function VirtualAllocEx Lib "kernel32" Alias "VirtualAllocEx" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As IntPtr, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As IntPtr
        Public Declare Ansi Function OpenProcess Lib "kernel32" Alias "OpenProcess" (dwDesiredAccess As UInteger, bInheritHandle As Boolean, dwProcessId As UInteger) As IntPtr
        Public Declare Function CancelShutdown Lib "user32.dll" Alias "CancelShutdown" () As Integer
        Public Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByVal lpBuffer As String, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
        Public Declare Function FindWindowEx Lib "user32" Alias "FindWindowEx" (ByVal hWnd1 As IntPtr, ByVal hWnd2 As IntPtr, ByVal lpsz1 As String, ByVal lpsz2 As String) As IntPtr
        Public Delegate Function WndProcDelegate(hWnd As IntPtr, msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
        Public Declare Function BlockInput Lib "user32" Alias "BlockInput" (ByVal fBlockIt As Boolean) As Boolean
        Public Declare Function GetCursorPos Lib "user32.dll" Alias "GetCursorPos" (ByRef lpPoint As Point) As Boolean
        Public Declare Auto Function SetLayeredWindowAttributes Lib "User32.Dll" Alias "SetLayeredWindowAttributes" (ByVal hWnd As IntPtr, ByVal crKey As Integer, ByVal Alpha As Byte, ByVal dwFlags As Integer) As Boolean
        Public Declare Function GetCurrentProcess Lib "kernel32.dll" () As IntPtr
        Public Declare Function GetCurrentProcessId Lib "kernel32" () As Integer
        Public Declare Function ScreenToClient Lib "user32.dll" (ByVal handle As IntPtr, ByRef point As Point) As Boolean
        Public Declare Function ChildWindowFromPointEx Lib "user32.dll" (ByVal hWndParent As IntPtr, ByVal pt As Point, ByVal uFlags As UInteger) As IntPtr
        Public Declare Function ClientToScreen Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpPoint As Point) As Boolean
        Public Declare Function IsChild Lib "user32.dll" (ByVal hWndParent As IntPtr, ByVal hWnd As IntPtr) As Boolean
        Public Declare Function GetWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal uCmd As UInteger) As IntPtr
        Public Declare Function GetWindowDC Lib "user32.dll" (ByVal hWnd As IntPtr) As IntPtr
        Public Declare Function SetROP2 Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal fnDrawMode As Integer) As Integer
        Public Declare Function CreatePen Lib "gdi32.dll" (ByVal fnPenStyle As Integer, ByVal nWidth As Integer, ByVal crColor As UInteger) As IntPtr
        Public Declare Function SelectObject Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal hgdiobj As IntPtr) As IntPtr
        Public Declare Function GetStockObject Lib "gdi32.dll" (ByVal fnObject As Integer) As IntPtr
        Public Declare Function Rectangle Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer) As UInteger
        Public Declare Function DeleteObject Lib "gdi32.dll" (ByVal hObject As IntPtr) As Boolean
        Public Declare Function ReleaseDC Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal hdc As IntPtr) As Int32
        Public Declare Function GetSystemMetrics Lib "user32.dll" (ByVal smIndex As Integer) As Integer
        Public Declare Function TerminateProcess Lib "coredll.dll" (ByVal processIdOrHandle As IntPtr, ByVal exitCode As IntPtr) As Integer
        Public Declare Function GetNextWindow Lib "user32" Alias "GetWindow" (ByVal hwnd As IntPtr, ByVal wFlag As Integer) As IntPtr
        Public Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Integer
        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Sub GetClassName(ByVal hWnd As System.IntPtr, ByVal lpClassName As System.Text.StringBuilder, ByVal nMaxCount As Integer)
        End Sub
        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function GetWindowTextLength(ByVal hwnd As IntPtr) As Integer
        End Function
        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function GetWindowText(ByVal hwnd As IntPtr, ByVal lpString As StringBuilder, ByVal cch As Integer) As Integer
        End Function
        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
        End Function
        <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function GetParent(ByVal hWnd As IntPtr) As IntPtr
        End Function
        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function GetClientRect(ByVal hWnd As System.IntPtr, ByRef lpRECT As Rectangle) As Integer
        End Function
        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
        End Function
        Public Structure WINDOWPLACEMENT
            Public Length As Integer
            Public flags As Integer
            Public showCmd As Integer
            Public ptMinPosition As Point
            Public ptMaxPosition As Point
            Public rcNormalPosition As Rectangle
        End Structure
        Public Enum GetWindow_Cmd As UInteger
            GW_HWNDFIRST = 0
            GW_HWNDLAST = 1
            GW_HWNDNEXT = 2
            GW_HWNDPREV = 3
            GW_OWNER = 4
            GW_CHILD = 5
            GW_ENABLEDPOPUP = 6
        End Enum
        <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)>
        Public Shared Function ShowCursor(ByVal bShow As Boolean) As Integer
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function SetCursor(ByVal hCursor As IntPtr) As IntPtr
        End Function
        <DllImport("kernel32.dll")> _
        Public Shared Function SetThreadPriority(ByVal hThread As IntPtr, ByVal nPriority As ThreadPriority) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function AnimateWindow(ByVal hwnd As IntPtr, ByVal time As Integer, ByVal flags As AnimateWindowFlags) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function AttachThreadInput(ByVal idAttach As System.UInt32, ByVal idAttachTo As System.UInt32, ByVal fAttach As Boolean) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function BeginPaint(ByVal hwnd As IntPtr, <Out()> ByRef lpPaint As PAINTSTRUCT) As IntPtr
        End Function
        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function GetWindowLong(hWnd As IntPtr, _
                <MarshalAs(UnmanagedType.I4)> nIndex As WindowLongFlags) As Integer
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function LoadCursorFromFile(ByVal lpFileName As String) As IntPtr
        End Function
        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function BringWindowToTop(ByVal hwnd As IntPtr) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function CallMsgFilter(<[In]> ByRef lpMsg As MSG, nCode As Integer) As Boolean
        End Function
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure MSG
            Public hwnd As IntPtr
            Public message As Integer
            Public wParam As IntPtr
            Public lParam As IntPtr
            Public time As Integer
            Public pt As Point
        End Structure
        <DllImport("kernel32.dll")> _
        Public Shared Sub ZeroMemory(ByVal addr As IntPtr, ByVal size As IntPtr)
        End Sub
        <DllImport("kernel32.dll", SetLastError:=True)> _
        Public Shared Function CreateToolhelp32Snapshot(ByVal dwFlags As SnapshotFlags, ByVal th32ProcessID As UInteger) As IntPtr
        End Function
        <Flags()> _
        Public Enum SnapshotFlags As Integer
            HeapList = &H1
            Process = &H2
            Thread = &H4
            [Module] = &H8
            Module32 = &H10
            Inherit = &H80000000
            All = &HF
            NoHeaps = &H40000000
        End Enum
        <DllImport("kernel32.dll")> _
        Public Shared Function Process32First(ByVal hSnapshot As IntPtr, ByRef lppe As PROCESSENTRY32) As Boolean
        End Function
        <DllImport("kernel32.dll")> _
        Public Shared Function Process32Next(ByVal hSnapshot As IntPtr, ByRef lppe As PROCESSENTRY32) As Boolean
        End Function
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure PROCESSENTRY32
            Public dwSize As UInteger
            Public cntUsage As UInteger
            Public th32ProcessID As UInteger
            Public th32DefaultHeapID As IntPtr
            Public th32ModuleID As UInteger
            Public cntThreads As UInteger
            Public th32ParentProcessID As UInteger
            Public pcPriClassBase As Integer
            Public dwFlags As UInteger
            <VBFixedString(260), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szExeFile As String
        End Structure
        <DllImport("user32.dll")> Public Shared Function SendMessageW(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function
        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function LoadCursor(ByVal hInstance As IntPtr, ByVal lpCursorName As String) As IntPtr
        End Function
        <DllImport("kernel32.dll")> _
        Public Shared Function ResumeThread(hThread As IntPtr) As UInt32
        End Function
        <DllImport("kernel32.dll")> _
        Public Shared Function SuspendThread(hThread As IntPtr) As UInteger
        End Function
        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
        Public Structure STARTUPINFO
            Public cb As Integer
            Public lpReserved As String
            Public lpDesktop As String
            Public lpTitle As String
            Public dwX As Integer
            Public dwY As Integer
            Public dwXSize As Integer
            Public dwYSize As Integer
            Public dwXCountChars As Integer
            Public dwYCountChars As Integer
            Public dwFillAttribute As Integer
            Public dwFlags As Integer
            Public wShowWindow As Short
            Public cbReserved2 As Short
            Public lpReserved2 As Integer
            Public hStdInput As Integer
            Public hStdOutput As Integer
            Public hStdError As Integer
        End Structure
        <DllImport("kernel32.dll")> _
        Public Shared Function GetThreadPriority(ByVal hThread As IntPtr) As ThreadPriority
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function SetWindowLong(hWnd As IntPtr, _
                <MarshalAs(UnmanagedType.I4)> nIndex As WindowLongFlags, _
                dwNewLong As IntPtr) As Integer
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function WindowFromPoint(ByVal Point As Point) As IntPtr
        End Function
        <StructLayout(LayoutKind.Sequential, Pack:=4)> _
        Public Structure PAINTSTRUCT
            Public hdc As IntPtr
            Public fErase As Integer
            Public rcPaint As RECT
            Public fRestore As Integer
            Public fIncUpdate As Integer
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
            Public rgbReserved As Byte()
        End Structure
        <DllImport("Advapi32.dll", ExactSpelling:=False, SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function CreateProcessAsUser( _
                                              ByVal hToken As IntPtr, _
                                              ByVal lpApplicationName As String, _
                                              <[In](), Out(), [Optional]()> ByVal lpCommandLine As StringBuilder, _
                                              ByVal lpProcessAttributes As IntPtr, _
                                              ByVal lpThreadAttributes As IntPtr, _
                                              <MarshalAs(UnmanagedType.Bool)> ByVal bInheritHandles As Boolean, _
                                              ByVal dwCreationFlags As Integer, _
                                              ByVal lpEnvironment As IntPtr, _
                                              ByVal lpCurrentDirectory As String, _
                                              <[In]()> ByRef lpStartupInfo As STARTUPINFO, _
                                              <Out()> ByRef lpProcessInformation As SystemInformation) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
        End Function
        <Flags()> _
        Public Enum AnimateWindowFlags
            AW_HOR_POSITIVE = &H1
            AW_HOR_NEGATIVE = &H2
            AW_VER_POSITIVE = &H4
            AW_VER_NEGATIVE = &H8
            AW_CENTER = &H10
            AW_HIDE = &H10000
            AW_ACTIVATE = &H20000
            AW_SLIDE = &H40000
            AW_BLEND = &H80000
        End Enum
        <DllImport("kernel32.dll", SetLastError:=True)> _
        Public Shared Function GetExitCodeProcess(ByVal hProcess As IntPtr, ByRef lpExitCode As System.UInt32) As Boolean
        End Function
        <DllImport("advapi32.dll", SetLastError:=True)> _
        Public Shared Function ControlService(ByVal hService As IntPtr, ByVal dwControl As SERVICE_CONTROL, ByRef lpServiceStatus As SERVICE_STATUS) As Boolean
        End Function
        <Flags> _
        Public Enum SERVICE_CONTROL As UInteger
            [STOP] = &H1
            PAUSE = &H2
            [CONTINUE] = &H3
            INTERROGATE = &H4
            SHUTDOWN = &H5
            PARAMCHANGE = &H6
            NETBINDADD = &H7
            NETBINDREMOVE = &H8
            NETBINDENABLE = &H9
            NETBINDDISABLE = &HA
            DEVICEEVENT = &HB
            HARDWAREPROFILECHANGE = &HC
            POWEREVENT = &HD
            SESSIONCHANGE = &HE
        End Enum
        Public Enum SERVICE_STATE As UInteger
            SERVICE_STOPPED = &H1
            SERVICE_START_PENDING = &H2
            SERVICE_STOP_PENDING = &H3
            SERVICE_RUNNING = &H4
            SERVICE_CONTINUE_PENDING = &H5
            SERVICE_PAUSE_PENDING = &H6
            SERVICE_PAUSED = &H7
        End Enum
        Public Enum WindowLongFlags As Integer
            GWL_EXSTYLE = -20
            GWLP_HINSTANCE = -6
            GWLP_HWNDPARENT = -8
            GWL_ID = -12
            GWL_STYLE = -16
            GWL_USERDATA = -21
            GWL_WNDPROC = -4
            DWLP_USER = &H8
            DWLP_MSGRESULT = &H0
            DWLP_DLGPROC = &H4
        End Enum
        <Flags> _
        Public Enum SERVICE_ACCEPT As UInteger
            [STOP] = &H1
            PAUSE_CONTINUE = &H2
            SHUTDOWN = &H4
            PARAMCHANGE = &H8
            NETBINDCHANGE = &H10
            HARDWAREPROFILECHANGE = &H20
            POWEREVENT = &H40
            SESSIONCHANGE = &H80
        End Enum
        <DllImport("kernel32.dll")> _
        Public Shared Function WriteProcessMemory( _
        ByVal hProcess As IntPtr, _
        ByVal lpBaseAddress As IntPtr, _
        ByVal lpBuffer As Byte(), _
        ByVal nSize As UInt32, _
        ByRef lpNumberOfBytesWritten As UInt32) As Boolean
        End Function
        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
        End Function
        <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True)> _
        Public Shared Function GetProcAddress(ByVal hModule As IntPtr, ByVal procName As String) As UIntPtr
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function CallNextHookEx(ByVal hhk As IntPtr, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function CallWindowProc(lpPrevWndFunc As WndProcDelegate, hWnd As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function ChangeDisplaySettings(ByRef devMode As DEVMODE, ByVal flags As Integer) As DISP_CHANGE
        End Function
        <DllImport("user32.dll", _
                EntryPoint:="CharToOem", _
                SetLastError:=True, _
                CharSet:=CharSet.Unicode, _
                ExactSpelling:=True, _
                PreserveSig:=True, _
                CallingConvention:=CallingConvention.Winapi)> _
        Public Shared Function CharToOem(ByVal lpszSrc As String, ByVal lpszDst As StringBuilder) As Boolean
        End Function
        Public Enum DISP_CHANGE As Integer
            Successful = 0
            Restart = 1
            Failed = -1
            BadMode = -2
            NotUpdated = -3
            BadFlags = -4
            BadParam = -5
            BadDualView = -6
        End Enum
        <Flags()> _
        Public Enum DM As Integer
            Orientation = &H1
            PaperSize = &H2
            PaperLength = &H4
            PaperWidth = &H8
            Scale = &H10
            Position = &H20
            NUP = &H40
            DisplayOrientation = &H80
            Copies = &H100
            DefaultSource = &H200
            PrintQuality = &H400
            Color = &H800
            Duplex = &H1000
            YResolution = &H2000
            TTOption = &H4000
            Collate = &H8000
            FormName = &H10000
            LogPixels = &H20000
            BitsPerPixel = &H40000
            PelsWidth = &H80000
            PelsHeight = &H100000
            DisplayFlags = &H200000
            DisplayFrequency = &H400000
            ICMMethod = &H800000
            ICMIntent = &H1000000
            MediaType = &H2000000
            DitherType = &H4000000
            PanningWidth = &H8000000
            PanningHeight = &H10000000
            DisplayFixedOutput = &H20000000
        End Enum
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure DEVMODE
            Public Const CCHDEVICENAME As Integer = 32
            Public Const CCHFORMNAME As Integer = 32

            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCHDEVICENAME)> _
            Public dmDeviceName As String
            Public dmSpecVersion As Short
            Public dmDriverVersion As Short
            Public dmSize As Short
            Public dmDriverExtra As Short
            Public dmFields As DM

            Public dmOrientation As Short
            Public dmPaperSize As Short
            Public dmPaperLength As Short
            Public dmPaperWidth As Short

            Public dmScale As Short
            Public dmCopies As Short
            Public dmDefaultSource As Short
            Public dmPrintQuality As Short
            Public dmColor As Short
            Public dmDuplex As Short
            Public dmYResolution As Short
            Public dmTTOption As Short
            Public dmCollate As Short
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCHFORMNAME)> _
            Public dmFormName As String
            Public dmLogPixels As Short
            Public dmBitsPerPel As Integer ' Declared wrong in the full framework
            Public dmPelsWidth As Integer
            Public dmPelsHeight As Integer
            Public dmDisplayFlags As Integer
            Public dmDisplayFrequency As Integer

            Public dmICMMethod As Integer
            Public dmICMIntent As Integer
            Public dmMediaType As Integer
            Public dmDitherType As Integer
            Public dmReserved1 As Integer
            Public dmReserved2 As Integer
            Public dmPanningWidth As Integer
            Public dmPanningHeight As Integer

            Public dmPositionX As Integer ' Using a PointL Struct does not work
            Public dmPositionY As Integer
        End Structure
        Public Structure SERVICE_STATUS
            Dim dwServiceType As Int32
            Dim dwCurrentState As Int32
            Dim dwControlsAccepted As Int32
            Dim dwWin32ExitCode As Int32
            Dim dwServiceSpecificExitCode As Int32
            Dim dwCheckPoint As Int32
            Dim dwWaitHint As Int32
        End Structure
        <DllImport("user32.dll")> _
        Public Shared Function UnregisterHotKey( _
                                           ByVal hWnd As IntPtr, _
                                           ByVal id As Integer _
                                           ) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function RegisterHotKey( _
                                         ByVal hWnd As IntPtr, _
                                         ByVal id As Integer, _
                                         ByVal fsModifiers As UInteger, _
                                         ByVal vk As UInteger _
                                         ) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function ActivateKeyboardLayout(ByVal nkl As IntPtr, ByVal Flags As UInt32) As Integer
        End Function
        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function AddClipboardFormatListener(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function AdjustWindowRect(ByRef lpRect As RECT, ByVal dwStyle As UInteger, ByVal bMenu As Boolean) As Boolean
        End Function
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure RECT
            Private _Left As Integer, _Top As Integer, _Right As Integer, _Bottom As Integer

            Public Sub New(ByVal Rectangle As Rectangle)
                Me.New(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
            End Sub
            Public Sub New(ByVal Left As Integer, ByVal Top As Integer, ByVal Right As Integer, ByVal Bottom As Integer)
                _Left = Left
                _Top = Top
                _Right = Right
                _Bottom = Bottom
            End Sub

            Public Property X As Integer
                Get
                    Return _Left
                End Get
                Set(ByVal value As Integer)
                    _Right = _Right - _Left + value
                    _Left = value
                End Set
            End Property
            Public Property Y As Integer
                Get
                    Return _Top
                End Get
                Set(ByVal value As Integer)
                    _Bottom = _Bottom - _Top + value
                    _Top = value
                End Set
            End Property
            Public Property Left As Integer
                Get
                    Return _Left
                End Get
                Set(ByVal value As Integer)
                    _Left = value
                End Set
            End Property
            Public Property Top As Integer
                Get
                    Return _Top
                End Get
                Set(ByVal value As Integer)
                    _Top = value
                End Set
            End Property
            Public Property Right As Integer
                Get
                    Return _Right
                End Get
                Set(ByVal value As Integer)
                    _Right = value
                End Set
            End Property
            Public Property Bottom As Integer
                Get
                    Return _Bottom
                End Get
                Set(ByVal value As Integer)
                    _Bottom = value
                End Set
            End Property
            Public Property Height() As Integer
                Get
                    Return _Bottom - _Top
                End Get
                Set(ByVal value As Integer)
                    _Bottom = value - _Top
                End Set
            End Property
            Public Property Width() As Integer
                Get
                    Return _Right - _Left
                End Get
                Set(ByVal value As Integer)
                    _Right = value + _Left
                End Set
            End Property
            Public Property Location() As Point
                Get
                    Return New Point(Left, Top)
                End Get
                Set(ByVal value As Point)
                    _Right = _Right - _Left + value.X
                    _Bottom = _Bottom - _Top + value.Y
                    _Left = value.X
                    _Top = value.Y
                End Set
            End Property
            Public Property Size() As Size
                Get
                    Return New Size(Width, Height)
                End Get
                Set(ByVal value As Size)
                    _Right = value.Width + _Left
                    _Bottom = value.Height + _Top
                End Set
            End Property

            Public Shared Widening Operator CType(ByVal Rectangle As RECT) As Rectangle
                Return New Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height)
            End Operator
            Public Shared Widening Operator CType(ByVal Rectangle As Rectangle) As RECT
                Return New RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
            End Operator
            Public Shared Operator =(ByVal Rectangle1 As RECT, ByVal Rectangle2 As RECT) As Boolean
                Return Rectangle1.Equals(Rectangle2)
            End Operator
            Public Shared Operator <>(ByVal Rectangle1 As RECT, ByVal Rectangle2 As RECT) As Boolean
                Return Not Rectangle1.Equals(Rectangle2)
            End Operator

            Public Overrides Function ToString() As String
                Return "{Left: " & _Left & "; " & "Top: " & _Top & "; Right: " & _Right & "; Bottom: " & _Bottom & "}"
            End Function

            Public Overloads Function Equals(ByVal Rectangle As RECT) As Boolean
                Return Rectangle.Left = _Left AndAlso Rectangle.Top = _Top AndAlso Rectangle.Right = _Right AndAlso Rectangle.Bottom = _Bottom
            End Function
            Public Overloads Overrides Function Equals(ByVal [Object] As Object) As Boolean
                If TypeOf [Object] Is RECT Then
                    Return Equals(DirectCast([Object], RECT))
                ElseIf TypeOf [Object] Is Rectangle Then
                    Return Equals(New RECT(DirectCast([Object], Rectangle)))
                End If

                Return False
            End Function
        End Structure
        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
        End Function
        <Flags()> Public Enum WindowStyles As UInteger
            ''' <summary>The window has a thin-line border.</summary>
            WS_BORDER = &H800000

            ''' <summary>The window has a title bar (includes the WS_BORDER style).</summary>
            WS_CAPTION = &HC00000

            ''' <summary>The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the WS_POPUP style.</summary>
            WS_CHILD = &H40000000

            ''' <summary>Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.</summary>
            WS_CLIPCHILDREN = &H2000000

            ''' <summary>
            ''' Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated.
            ''' If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
            ''' </summary>
            WS_CLIPSIBLINGS = &H4000000

            ''' <summary>The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.</summary>
            WS_DISABLED = &H8000000

            ''' <summary>The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.</summary>
            WS_DLGFRAME = &H400000

            ''' <summary>
            ''' The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style.
            ''' The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys.
            ''' You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
            ''' </summary>
            WS_GROUP = &H20000

            ''' <summary>The window has a horizontal scroll bar.</summary>
            WS_HSCROLL = &H100000

            ''' <summary>The window is initially maximized.</summary> 
            WS_MAXIMIZE = &H1000000

            ''' <summary>The window has a maximize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.</summary> 
            WS_MAXIMIZEBOX = &H10000

            ''' <summary>The window is initially minimized.</summary>
            WS_MINIMIZE = &H20000000

            ''' <summary>The window has a minimize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.</summary>
            WS_MINIMIZEBOX = &H20000

            ''' <summary>The window is an overlapped window. An overlapped window has a title bar and a border.</summary>
            WS_OVERLAPPED = &H0

            ''' <summary>The window is an overlapped window.</summary>
            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED Or WS_CAPTION Or WS_SYSMENU Or WS_SIZEFRAME Or WS_MINIMIZEBOX Or WS_MAXIMIZEBOX

            ''' <summary>The window is a pop-up window. This style cannot be used with the WS_CHILD style.</summary>
            WS_POPUP = &H80000000UI

            ''' <summary>The window is a pop-up window. The WS_CAPTION and WS_POPUPWINDOW styles must be combined to make the window menu visible.</summary>
            WS_POPUPWINDOW = WS_POPUP Or WS_BORDER Or WS_SYSMENU

            ''' <summary>The window has a sizing border.</summary>
            WS_SIZEFRAME = &H40000

            ''' <summary>The window has a window menu on its title bar. The WS_CAPTION style must also be specified.</summary>
            WS_SYSMENU = &H80000

            ''' <summary>
            ''' The window is a control that can receive the keyboard focus when the user presses the TAB key.
            ''' Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style.  
            ''' You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
            ''' For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.
            ''' </summary>
            WS_TABSTOP = &H10000

            ''' <summary>The window is initially visible. This style can be turned on and off by using the ShowWindow or SetWindowPos function.</summary>
            WS_VISIBLE = &H10000000

            ''' <summary>The window has a vertical scroll bar.</summary>
            WS_VSCROLL = &H200000
        End Enum
        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function
        <Flags()> _
        Public Enum WindowStylesEx As UInteger
            ''' <summary>
            ''' Specifies that a window created with this style accepts drag-drop files.
            ''' </summary>
            WS_EX_ACCEPTFILES = &H10
            ''' <summary>
            ''' Forces a top-level window onto the taskbar when the window is visible.
            ''' </summary>
            WS_EX_APPWINDOW = &H40000
            ''' <summary>
            ''' Specifies that a window has a border with a sunken edge.
            ''' </summary>
            WS_EX_CLIENTEDGE = &H200
            ''' <summary>
            ''' Windows XP: Paints all descendants of a window in bottom-to-top painting order using double-buffering. For more information, see Remarks. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. 
            ''' </summary>
            WS_EX_COMPOSITED = &H2000000
            ''' <summary>
            ''' Includes a question mark in the title bar of the window. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window.
            ''' WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
            ''' </summary>
            WS_EX_CONTEXTHELP = &H400
            ''' <summary>
            ''' The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
            ''' </summary>
            WS_EX_CONTROLPARENT = &H10000
            ''' <summary>
            ''' Creates a window that has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
            ''' </summary>
            WS_EX_DLGMODALFRAME = &H1
            ''' <summary>
            ''' Windows 2000/XP: Creates a layered window. Note that this cannot be used for child windows. Also, this cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. 
            ''' </summary>
            WS_EX_LAYERED = &H80000
            ''' <summary>
            ''' Arabic and Hebrew versions of Windows 98/Me, Windows 2000/XP: Creates a window whose horizontal origin is on the right edge. Increasing horizontal values advance to the left. 
            ''' </summary>
            WS_EX_LAYOUTRTL = &H400000
            ''' <summary>
            ''' Creates a window that has generic left-aligned properties. This is the default.
            ''' </summary>
            WS_EX_LEFT = &H0
            ''' <summary>
            ''' If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
            ''' </summary>
            WS_EX_LEFTSCROLLBAR = &H4000
            ''' <summary>
            ''' The window text is displayed using left-to-right reading-order properties. This is the default.
            ''' </summary>
            WS_EX_LTRREADING = &H0
            ''' <summary>
            ''' Creates a multiple-document interface (MDI) child window.
            ''' </summary>
            WS_EX_MDICHILD = &H40
            ''' <summary>
            ''' Windows 2000/XP: A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window. 
            ''' To activate the window, use the SetActiveWindow or SetForegroundWindow function.
            ''' The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
            ''' </summary>
            WS_EX_NOACTIVATE = &H8000000
            ''' <summary>
            ''' Windows 2000/XP: A window created with this style does not pass its window layout to its child windows.
            ''' </summary>
            WS_EX_NOINHERITLAYOUT = &H100000
            ''' <summary>
            ''' Specifies that a child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
            ''' </summary>
            WS_EX_NOPARENTNOTIFY = &H4
            ''' <summary>
            ''' Combines the WS_EX_CLIENTEDGE and WS_EX_WINDOWEDGE styles.
            ''' </summary>
            WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE Or WS_EX_CLIENTEDGE
            ''' <summary>
            ''' Combines the WS_EX_WINDOWEDGE, WS_EX_TOOLWINDOW, and WS_EX_TOPMOST styles.
            ''' </summary>
            WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE Or WS_EX_TOOLWINDOW Or WS_EX_TOPMOST
            ''' <summary>
            ''' The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored.
            ''' Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
            ''' </summary>
            WS_EX_RIGHT = &H1000
            ''' <summary>
            ''' Vertical scroll bar (if present) is to the right of the client area. This is the default.
            ''' </summary>
            WS_EX_RIGHTSCROLLBAR = &H0
            ''' <summary>
            ''' If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
            ''' </summary>
            WS_EX_RTLREADING = &H2000
            ''' <summary>
            ''' Creates a window with a three-dimensional border style intended to be used for items that do not accept user input.
            ''' </summary>
            WS_EX_STATICEDGE = &H20000
            ''' <summary>
            ''' Creates a tool window; that is, a window intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE. 
            ''' </summary>
            WS_EX_TOOLWINDOW = &H80
            ''' <summary>
            ''' Specifies that a window created with this style should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the SetWindowPos function.
            ''' </summary>
            WS_EX_TOPMOST = &H8
            ''' <summary>
            ''' Specifies that a window created with this style should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted.
            ''' To achieve transparency without these restrictions, use the SetWindowRgn function.
            ''' </summary>
            WS_EX_TRANSPARENT = &H20
            ''' <summary>
            ''' Specifies that a window has a border with a raised edge.
            ''' </summary>
            WS_EX_WINDOWEDGE = &H100
        End Enum
        <DllImport("user32.dll")> _
        Public Shared Function AdjustWindowRectEx(<MarshalAs(UnmanagedType.Struct)> ByRef lpRect As RECT, _
                    <MarshalAs(UnmanagedType.U4)> dwStyle As WindowStyles, _
                    <MarshalAs(UnmanagedType.Bool)> bMenu As Boolean, _
                    <MarshalAs(UnmanagedType.U4)> dwExStyle As WindowStylesEx) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _Hex

        '******************************************************************************
        '   Get File Stream
        '******************************************************************************
        Public Function fsStream(ByVal FilePath As String) As System.IO.FileStream
            Dim FileStream As System.IO.FileStream = System.IO.File.OpenRead(FilePath)
            FileStream.Seek(0, System.IO.SeekOrigin.Begin)
            Return FileStream
        End Function

        '******************************************************************************
        '   Read Byte
        '******************************************************************************
        Public Function rdfByte(ByVal f As System.IO.FileStream)
            Dim j As Integer = 1024 * 500
            Dim binar(j) As Byte, i As Integer = 0
            j = CInt(f.Length - 1)
            For i = 0 To j
                binar(i) = CByte(f.ReadByte())
            Next
            Return binar
        End Function

        '******************************************************************************
        '   Make Hex Editor
        '******************************************************************************
        Public Function rdByte() As String
            Dim ofd1 As New OpenFileDialog, path As String = ""
            If ofd1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim binf As Byte() = rdfByte(fsStream(ofd1.FileName))
                Dim i As Integer = 0, j As Integer = binf.Length - 1, x As Byte = 0
                Dim a As String = "", buffer1 As String = ""
                Dim strplus As String = "", buffer2 As String = ""
                For i = 0 To j
                    x = binf(i)
                    If x < 16 Then
                        buffer1 += "0" + Hex(x)
                    Else
                        buffer1 += Hex(x)
                    End If
                    Select Case x
                        Case 0, 13, 10, 9, 12, 11 : strplus += "."
                        Case Else : strplus += Chr(x)
                    End Select
                    If strplus.Length = 8 Then
                        buffer1 += " "
                    End If
                    If strplus.Length = 16 Then
                        buffer2 += buffer1 + "  " + strplus + Chr(13) + Chr(10)
                        buffer1 = ""
                        strplus = ""
                    Else
                        buffer1 += ChrW(32)
                    End If
                    If buffer2.Length > 4096 Then
                        a += buffer2
                        buffer2 = ""
                    End If
                Next
                While buffer1.Length < 48
                    buffer1 += " "
                End While
                a += buffer2 + buffer1 + "  " + strplus
                Return a
            Else
                Return 0
            End If
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _ED

        '******************************************************************************
        '   Do not encrypted Unicode
        '   Unicode decoding will be ignored.
        '******************************************************************************

        Public Shared Algorithm As String() = New String(9) {}

        Public Shared Function isNumeric(sVal As String) As Boolean
            Try
                Dim x As Integer
                x = Convert.ToInt32(sVal)
                Return True
            Catch generatedExceptionName As Exception

                Return False
            End Try
        End Function

        Public Shared Function Convert_To_Symbols(sSTR_PWD As String) As String
            Dim s As String = Nothing
            Dim sFULL_String As String = Nothing
            Dim ctr As Integer = 0
            Dim rand As New Random()
            Dim x As String() = New String(9) {}
            x(0) = "o"
            x(1) = "u"
            x(2) = "d"
            x(3) = "w"
            x(4) = "l"
            x(5) = "P"
            x(6) = "Q"
            x(7) = "i"
            x(8) = "n"
            x(9) = "M"

            sFULL_String = ""
            s = ""
            For ctr = 1 To Microsoft.VisualBasic.Strings.Len(sSTR_PWD)
                s = ""
                s = Microsoft.VisualBasic.Strings.Right(Microsoft.VisualBasic.Strings.Left(sSTR_PWD, ctr), 1)
                If Not isNumeric(s) Then
                    sFULL_String = sFULL_String & s
                Else
                    Dim serializer As Integer = rand.[Next](9)
                    sFULL_String = sFULL_String & Convert.ToString(Microsoft.VisualBasic.Interaction.Choose( _
                                                                   Convert.ToDouble(s) + 1, _
                                                                   "A", "B", "C", "D", "E", "F", "G", "H", "I", "J")) & x(serializer)
                End If
            Next
            Return sFULL_String

        End Function

        Public Shared Function Encrypt_String(sSTRING As String) As String
            Dim sPWD As String = Nothing
            Dim s1 As String = Nothing
            Dim sFULL_String As String = String.Empty
            Dim i As Integer = 0

            sFULL_String = ""
            s1 = ""
            sPWD = ""

            For i = 1 To sSTRING.Length
                s1 = Microsoft.VisualBasic.Strings.Right(Microsoft.VisualBasic.Strings.Left(sSTRING, i), 1)
                sPWD = sPWD & Microsoft.VisualBasic.Strings.Format(Microsoft.VisualBasic.Strings.Asc(s1), "#000")
            Next

            Return Convert_To_Symbols(Microsoft.VisualBasic.Strings.StrReverse(sPWD))
        End Function

        Public Shared Function Decrypt_From_String(sStr As String) As String
            Dim x As Integer = 0
            Dim i As String = Nothing
            Dim iLEN As Integer = 0
            Dim sDecrypt As String = Nothing
            sDecrypt = ""
            i = ""
            Dim ctr As Integer = 0
            Dim s As String = Nothing
            Dim strTemp_PASSWORD As String = Nothing
            Dim sFINAL_PWD As String = Nothing
            strTemp_PASSWORD = ""
            s = ""
            For ctr = 1 To Microsoft.VisualBasic.Strings.Len(sStr)
                s = Microsoft.VisualBasic.Strings.Right(Microsoft.VisualBasic.Strings.Left(sStr, ctr), 1)
                Select Case s
                    Case "A"
                        s = "0"
                        Exit Select
                    Case "B"
                        s = "1"
                        Exit Select
                    Case "C"
                        s = "2"
                        Exit Select
                    Case "D"
                        s = "3"
                        Exit Select
                    Case "E"
                        s = "4"
                        Exit Select
                    Case "F"
                        s = "5"
                        Exit Select
                    Case "G"
                        s = "6"
                        Exit Select
                    Case "H"
                        s = "7"
                        Exit Select
                    Case "I"
                        s = "8"
                        Exit Select
                    Case "J"
                        s = "9"
                        Exit Select
                    Case Else
                        s = ""
                        Exit Select
                End Select
                strTemp_PASSWORD = strTemp_PASSWORD & s
            Next
            sFINAL_PWD = Microsoft.VisualBasic.Strings.StrReverse(strTemp_PASSWORD)
            iLEN = Microsoft.VisualBasic.Strings.Len(sFINAL_PWD)
            For x = 3 To iLEN Step 3
                i = Convert.ToString(Microsoft.VisualBasic.Strings.Right(Microsoft.VisualBasic.Strings.Left(sFINAL_PWD, x), 3))
                sDecrypt = sDecrypt & Convert.ToString(Microsoft.VisualBasic.Strings.Chr(Convert.ToInt32(i)))
            Next
            Return sDecrypt
        End Function

        Public Shared Sub SaveFileEnc(ByVal FName As String, ByVal Filter As String, ByVal RTB As RichTextBox)
            Dim FileSaver As New SaveFileDialog, ReadText As String = Nothing
            Dim rtbBuffer As New RichTextBox
            FileSaver.FileName = FName
            FileSaver.Filter = Filter
            If FileSaver.ShowDialog = Windows.Forms.DialogResult.OK Then
                rtbBuffer.Text = _ED.Encrypt_String(RTB.Text)
                My.Computer.FileSystem.WriteAllText(FileSaver.FileName, rtbBuffer.Text, True)
            End If
        End Sub

        Public Shared Sub OpenFileDec(ByVal FName As String, ByVal Filter As String, ByVal RTB As RichTextBox)
            Dim FileOpener As New OpenFileDialog, ReadText As String = Nothing
            Dim rtbBuffer As New RichTextBox
            FileOpener.Filter = Filter
            If FileOpener.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(FileOpener.FileName)
                rtbBuffer.Text = _ED.Decrypt_From_String(fileContents)
                RTB.Text = rtbBuffer.Text
            End If
        End Sub

        '/////////////////////////////////////////////////////////////////////////////////////////////
        ' Source : http://www.planet-source-code.com/vb/scripts/ShowCode.asp?txtCodeId=8807&lngWId=10
        '/////////////////////////////////////////////////////////////////////////////////////////////

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class Ini
        Const Max_Path As Integer = 255
        Declare Ansi Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" ( _
                                                                                                        ByVal lpApplicationName As String, _
                                                                                                        ByVal lpKeyName As String, _
                                                                                                        ByVal lpDefault As String, _
                                                                                                        ByVal lpReturnedString As String, _
                                                                                                        ByVal nSize As Integer, _
                                                                                                        ByVal lpFileName As String) As Integer
        Declare Ansi Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" ( _
                                                                                                        ByVal lpApplicationName As String, _
                                                                                                        ByVal lpKeyName As String, _
                                                                                                        ByVal lpString As String, _
                                                                                                        ByVal lpFileName As String) As Integer
        '******************************************************************************
        '   Read ini Data
        '******************************************************************************
        Public Shared Function ReadIni(ByVal fileName As String, ByVal section As String, ByVal item As String, Optional ByVal defaultValue As String = "") As String
            Dim buffer As New String(Chr(0), Max_Path)
            Dim bufLen As Integer
            bufLen = GetPrivateProfileString(section, item, defaultValue, buffer, Max_Path, fileName)
            Return Left(buffer, bufLen)
        End Function

        '******************************************************************************
        '   Write ini Data
        '******************************************************************************
        Public Shared Sub WriteIni(ByVal fileName As String, ByVal section As String, ByVal item As String, ByVal value As String)
            WritePrivateProfileString(section, item, value, fileName)
        End Sub

        Public Shared Function Switch(ByVal ParamArray ObjectExpr() As Object) As Object
            Return Microsoft.VisualBasic.Switch(ObjectExpr)
        End Function
        Public Shared Function Left(ByVal str As String, ByVal Length As Integer) As String
            Return Microsoft.VisualBasic.Left(str, Length)
        End Function
        Public Shared Function Right(ByVal str As String, ByVal Length As Integer) As String
            Return Microsoft.VisualBasic.Right(str, Length)
        End Function
        Public Shared Function Mid(ByVal str As String, ByVal Start As Integer) As String
            Return Microsoft.VisualBasic.Mid(str, Start)
        End Function
        Public Shared Function Mid(ByVal str As String, ByVal Start As Integer, ByVal Length As Integer) As String
            Return Microsoft.VisualBasic.Mid(str, Start)
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _ME
        Private Declare Sub mouse_event Lib "user32" ( _
                                                       ByVal dwFlags As Long, _
                                                       ByVal dx As Long, _
                                                       ByVal dy As Long, _
                                                       ByVal cButtons As Long, _
                                                       ByVal dwExtraInfo As Long _
                                                       )
        Private Declare Function GetMessageExtraInfo Lib "user32" () As Long
        <DllImport("user32.dll", SetLastError:=True)> _
        Private Shared Function SetCursorPos( _
                                              ByVal X As Integer, _
                                              ByVal Y As Integer _
                                              ) As Boolean
        End Function
        Const MOUSEEVENTF_LEFTDOWN = &H2
        Const MOUSEEVENTF_LEFTUP = &H4
        Const MOUSEEVENTF_MOVE = &H1
        Const MOUSEEVENTF_RIGHTDOWN = &H8
        Const MOUSEEVENTF_RIGHTUP = &H10
        Const MOUSEEVENTF_MIDDLEDOWN = &H20
        Const MOUSEEVENTF_MIDDLEUP = &H40
        Const WHEEL_DELTA = 120
        Const MOUSEEVENTF_WHEEL = &H800
        Const MOUSEEVENTF_ABSOLUTE = &H8000
        Public Shared Sub Leftdown(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_LEFTDOWN, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Sub Leftup(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_LEFTUP, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Sub Rightdown(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_RIGHTDOWN, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Sub Rightup(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_RIGHTUP, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Sub Middledown(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_MIDDLEDOWN, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Sub Middleup(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_MIDDLEUP, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Sub LeftClick(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_LEFTDOWN, dx, dy, 0, GetMessageExtraInfo())
            Call mouse_event(MOUSEEVENTF_LEFTUP, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Sub RightClick(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_RIGHTDOWN, dx, dy, 0, GetMessageExtraInfo())
            Call mouse_event(MOUSEEVENTF_RIGHTUP, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Sub MiddleClick(ByVal dx As Integer, ByVal dy As Integer)
            Call mouse_event(MOUSEEVENTF_MIDDLEDOWN, dx, dy, 0, GetMessageExtraInfo())
            Call mouse_event(MOUSEEVENTF_MIDDLEUP, dx, dy, 0, GetMessageExtraInfo())
        End Sub
        Public Shared Function GetMousePoint()
            Dim mp As Point = Cursor.Position
            Return mp
        End Function
        Public Shared Sub SetMousePointEx(ByVal dx As Integer, ByVal dy As Integer)
            Cursor.Position = New Point(dx, dy)
        End Sub
        Public Shared Sub SetMousePoint(ByVal dx As Integer, ByVal dy As Integer)
            Call SetCursorPos(dx, dy)
        End Sub
        Public Shared Sub WheelUp()
            Call mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -WHEEL_DELTA, 0)
        End Sub
        Public Shared Sub WheelDown()
            Call mouse_event(MOUSEEVENTF_WHEEL, 0, 0, WHEEL_DELTA, 0)
        End Sub

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class MouseHook
        Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" ( _
                                                                                           ByVal idHook As Integer, _
                                                                                           ByVal lpfn As MouseProcc, _
                                                                                           ByVal hmod As Integer, _
                                                                                           ByVal dwThreadId As Integer _
                                                                                           ) As Integer
        Private Declare Function CallNextHookEx Lib "user32" ( _
                                                               ByVal hHook As Integer, _
                                                               ByVal nCode As Integer, _
                                                               ByVal wParam As Integer, _
                                                               ByVal lParam As MSLLHOOK _
                                                               ) As Integer
        Private Declare Function UnhookWindowsHookEx Lib "user32" ( _
                                                                    ByVal hHook As Integer _
                                                                    ) As Integer
        Private Delegate Function MouseProcc( _
                                              ByVal nCode As Integer, _
                                              ByVal wParam As Integer, _
                                              ByRef lParam As MSLLHOOK _
                                              ) As Integer

        Private Structure MSLLHOOK
            Public pt As Point
            Public mouseData As Integer
            Public flags As Integer
            Public time As Integer
            Public dwExtraInfo As Integer
        End Structure

        Public Enum Wheel_Direction
            WheelUp
            WheelDown
        End Enum

        Private Const HC_ACTION As Integer = 0
        Private Const WH_MOUSE_LL As Integer = 14
        Private Const WM_MOUSEMOVE As Integer = &H200
        Private Const WM_LBUTTONDOWN As Integer = &H201
        Private Const WM_LBUTTONUP As Integer = &H202
        Private Const WM_LBUTTONDBLCLK As Integer = &H203
        Private Const WM_RBUTTONDOWN As Integer = &H204
        Private Const WM_RBUTTONUP As Integer = &H205
        Private Const WM_RBUTTONDBLCLK As Integer = &H206
        Private Const WM_MBUTTONDOWN As Integer = &H207
        Private Const WM_MBUTTONUP As Integer = &H208
        Private Const WM_MBUTTONDBLCLK As Integer = &H209
        Private Const WM_MOUSEWHEEL As Integer = &H20A

        Private MouseHook As Integer
        Private MouseHookDelegate As MouseProcc

        Public Event Mouse_Move(ByVal ptLocat As Point)
        Public Event Mouse_Left_Down(ByVal ptLocat As Point)
        Public Event Mouse_Left_Up(ByVal ptLocat As Point)
        Public Event Mouse_Left_DoubleClick(ByVal ptLocat As Point)
        Public Event Mouse_Right_Down(ByVal ptLocat As Point)
        Public Event Mouse_Right_Up(ByVal ptLocat As Point)
        Public Event Mouse_Right_DoubleClick(ByVal ptLocat As Point)
        Public Event Mouse_Middle_Down(ByVal ptLocat As Point)
        Public Event Mouse_Middle_Up(ByVal ptLocat As Point)
        Public Event Mouse_Middle_DoubleClick(ByVal ptLocat As Point)
        Public Event Mouse_Wheel(ByVal ptLocat As Point, ByVal Direction As Wheel_Direction)

        Public Sub New()
            MouseHookDelegate = New MouseProcc(AddressOf MouseProc)
            MouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookDelegate, System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
        End Sub

        Private Function MouseProc(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As MSLLHOOK) As Integer
            If (nCode = HC_ACTION) Then
                Select Case wParam
                    Case WM_MOUSEMOVE
                        RaiseEvent Mouse_Move(lParam.pt)
                    Case WM_LBUTTONDOWN
                        RaiseEvent Mouse_Left_Down(lParam.pt)
                    Case WM_LBUTTONUP
                        RaiseEvent Mouse_Left_Up(lParam.pt)
                    Case WM_LBUTTONDBLCLK
                        RaiseEvent Mouse_Left_DoubleClick(lParam.pt)
                    Case WM_RBUTTONDOWN
                        RaiseEvent Mouse_Right_Down(lParam.pt)
                    Case WM_RBUTTONUP
                        RaiseEvent Mouse_Right_Up(lParam.pt)
                    Case WM_RBUTTONDBLCLK
                        RaiseEvent Mouse_Right_DoubleClick(lParam.pt)
                    Case WM_MBUTTONDOWN
                        RaiseEvent Mouse_Middle_Down(lParam.pt)
                    Case WM_MBUTTONUP
                        RaiseEvent Mouse_Middle_Up(lParam.pt)
                    Case WM_MBUTTONDBLCLK
                        RaiseEvent Mouse_Middle_DoubleClick(lParam.pt)
                    Case WM_MOUSEWHEEL
                        Dim wDirection As Wheel_Direction
                        If lParam.mouseData < 0 Then
                            wDirection = Wheel_Direction.WheelDown
                        Else
                            wDirection = Wheel_Direction.WheelUp
                        End If
                        RaiseEvent Mouse_Wheel(lParam.pt, wDirection)
                End Select
            End If
            Return CallNextHookEx(MouseHook, nCode, wParam, lParam)
        End Function

        Protected Overrides Sub Finalize()
            UnhookWindowsHookEx(MouseHook)
            MyBase.Finalize()
        End Sub

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _KE
        Declare Sub keybd_event Lib "user32" ( _
                                               ByVal bVk As Byte, _
                                               ByVal bScan As Byte, _
                                               ByVal dwFlags As Long, _
                                               ByVal dwExtraInfo As Long _
                                               )
        Declare Function VkKeyScanEx Lib "user32" Alias "VkKeyScanExA" ( _
                                                                         ByVal ch As Byte, _
                                                                         ByVal dwhkl As Long _
                                                                         ) As Integer
        Const KEYEVENTF_EXTENDEDKEY = &H1
        Const KEYEVENTF_KEYDOWN = &H0
        Const KEYEVENTF_KEYUP = &H2
        Const VK_Shift = &HA0
        Public Shared Sub KeyDown(ByVal Key As Integer)
            Call keybd_event(Key, 0, KEYEVENTF_KEYDOWN, 0)
        End Sub
        Public Shared Sub KeyUp(ByVal Key As Integer)
            Call keybd_event(Key, 0, KEYEVENTF_KEYUP, 0)
        End Sub
        Public Shared Function Return_Key(ByVal Key As String) As Keys
            If Key = "a" Then Return Keys.A
            If Key = "b" Then Return Keys.B
            If Key = "c" Then Return Keys.C
            If Key = "d" Then Return Keys.D
            If Key = "e" Then Return Keys.E
            If Key = "f" Then Return Keys.F
            If Key = "g" Then Return Keys.G
            If Key = "h" Then Return Keys.H
            If Key = "i" Then Return Keys.I
            If Key = "j" Then Return Keys.J
            If Key = "k" Then Return Keys.K
            If Key = "l" Then Return Keys.L
            If Key = "m" Then Return Keys.M
            If Key = "n" Then Return Keys.N
            If Key = "o" Then Return Keys.O
            If Key = "p" Then Return Keys.P
            If Key = "q" Then Return Keys.Q
            If Key = "r" Then Return Keys.R
            If Key = "s" Then Return Keys.S
            If Key = "t" Then Return Keys.T
            If Key = "u" Then Return Keys.U
            If Key = "v" Then Return Keys.V
            If Key = "w" Then Return Keys.W
            If Key = "x" Then Return Keys.X
            If Key = "y" Then Return Keys.Y
            If Key = "z" Then Return Keys.Z
            If Key = "~" Then Return Keys.Oem3
            If Key = "!" Then Return Keys.D1
            If Key = "@" Then Return Keys.D2
            If Key = "#" Then Return Keys.D3
            If Key = "$" Then Return Keys.D4
            If Key = "%" Then Return Keys.D5
            If Key = "^" Then Return Keys.D6
            If Key = "&" Then Return Keys.D7
            If Key = "*" Then Return Keys.D8
            If Key = "(" Then Return Keys.D9
            If Key = ")" Then Return Keys.D0
            If Key = "1" Then Return Keys.NumPad1
            If Key = "2" Then Return Keys.NumPad2
            If Key = "3" Then Return Keys.NumPad3
            If Key = "4" Then Return Keys.NumPad4
            If Key = "5" Then Return Keys.NumPad5
            If Key = "6" Then Return Keys.NumPad6
            If Key = "7" Then Return Keys.NumPad7
            If Key = "8" Then Return Keys.NumPad8
            If Key = "9" Then Return Keys.NumPad9
            If Key = "0" Then Return Keys.NumPad0
            If Key = "1" Then Return Keys.NumPad1
            If Key = "2" Then Return Keys.NumPad2
            If Key = "3" Then Return Keys.NumPad3
            If Key = "4" Then Return Keys.NumPad4
            If Key = "5" Then Return Keys.NumPad5
            If Key = "6" Then Return Keys.NumPad6
            If Key = "7" Then Return Keys.NumPad7
            If Key = "8" Then Return Keys.NumPad8
            If Key = "9" Then Return Keys.NumPad9
            If Key = "0" Then Return Keys.NumPad0
            If Key = "*" Then Return Keys.Multiply
            If Key = "+" Then Return Keys.Add
            If Key = "-" Then Return Keys.Subtract
            If Key = "." Then Return Keys.OemPeriod
            If Key = "/" Then Return Keys.Divide
            If Key = "[Esc]" Then Return Keys.Escape
            If Key = "=" Then Return Keys.Oemplus
            If Key = "?" Then Return Keys.OemQuestion
            If Key = "." Then Return Keys.OemPeriod
            If Key = "←" Then Return Keys.Left
            If Key = "→" Then Return Keys.Right
            If Key = "↑" Then Return Keys.Up
            If Key = "↓" Then Return Keys.Down
            If Key = "[SPACE]" Then Return Keys.Space
            If Key = "[CTRL]" Then Return Keys.ControlKey
            If Key = "[TAB]" Then Return Keys.Tab
            If Key = "[ENTER]" Then Return Keys.Enter
            If Key = "[SHIFT]" Then Return Keys.ShiftKey
            If Key = "[ALT]" Then Return Keys.Menu
            If Key = "[PAUSEBREAK]" Then Return Keys.Pause
            If Key = "[CAPSLOOK]" Then Return Keys.Capital
            If Key = "[PAGEDN]" Then Return Keys.PageDown
            If Key = "[PAGEUP]" Then Return Keys.PageUp
            If Key = "[END]" Then Return Keys.End
            If Key = "[HOME]" Then Return Keys.Home
            If Key = "[INSERT]" Then Return Keys.Insert
            If Key = "[DELETE]" Then Return Keys.Delete
            If Key = "[NUMLOCK]" Then Return Keys.NumLock
            If Key = "[F1]" Then Return Keys.F1
            If Key = "[F2]" Then Return Keys.F2
            If Key = "[F3]" Then Return Keys.F3
            If Key = "[F4]" Then Return Keys.F4
            If Key = "[F5]" Then Return Keys.F5
            If Key = "[F6]" Then Return Keys.F6
            If Key = "[F7]" Then Return Keys.F7
            If Key = "[F8]" Then Return Keys.F8
            If Key = "[F9]" Then Return Keys.F9
            If Key = "[F10]" Then Return Keys.F10
            If Key = "[F11]" Then Return Keys.F11
            If Key = "[F12]" Then Return Keys.F12
            If Key = "[SCROLLLOCK]" Then Return Keys.Scroll
            If Key = "[BACKSPACE]" Then Return Keys.Back
            Return 0
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _AES

        Public Shared Basically_Code As String = "RollRatSoftwareAseTech"

        Public Shared Function AES_Enc_256(ByVal Text As String, _
                                           Optional ByVal salt As String = "RollratSoftwarePrograms", _
                                           Optional ByVal InitialVector As String = "rollratwqw][;'/.")
            Dim HashAlgorithm As String = "SHA1"
            Dim PasswordIterations As String = 2
            Dim KeySize As Integer = 256

            If (String.IsNullOrEmpty(Text)) Then
                Return 0
            End If
            Dim InitialVectorBytes As Byte() = Encoding.ASCII.GetBytes(InitialVector)
            Dim SaltValueBytes As Byte() = Encoding.ASCII.GetBytes(salt)
            Dim PlainTextBytes As Byte() = Encoding.UTF8.GetBytes(Text)
            Dim DerivedPassword As PasswordDeriveBytes = New PasswordDeriveBytes(Basically_Code, SaltValueBytes, HashAlgorithm, PasswordIterations)
            Dim KeyBytes As Byte() = DerivedPassword.GetBytes(KeySize / 8)
            Dim SymmetricKey As RijndaelManaged = New RijndaelManaged()
            SymmetricKey.Mode = CipherMode.CBC

            Dim CipherTextBytes As Byte() = Nothing
            Using Encryptor As ICryptoTransform = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes)
                Using MemStream As New MemoryStream()
                    Using CryptoStream As New CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write)
                        CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length)
                        CryptoStream.FlushFinalBlock()
                        CipherTextBytes = MemStream.ToArray()
                        MemStream.Close()
                        CryptoStream.Close()
                    End Using
                End Using
            End Using
            SymmetricKey.Clear()
            Return Convert.ToBase64String(CipherTextBytes)
        End Function

        Public Shared Function AES_Dec_256(ByVal text As String, _
                                           Optional ByVal salt As String = "RollratSoftwarePrograms", _
                                           Optional ByVal InitialVector As String = "rollratwqw][;'/.")
            Dim HashAlgorithm As String = "SHA1"
            Dim PasswordIterations As String = 2
            Dim KeySize As Integer = 256

            Dim InitialVectorBytes As Byte() = Encoding.ASCII.GetBytes(InitialVector)
            Dim SaltValueBytes As Byte() = Encoding.ASCII.GetBytes(salt)
            Dim CipherTextBytes As Byte() = Convert.FromBase64String(text)
            Dim DerivedPassword As PasswordDeriveBytes = New PasswordDeriveBytes(Basically_Code, SaltValueBytes, HashAlgorithm, PasswordIterations)
            Dim KeyBytes As Byte() = DerivedPassword.GetBytes(KeySize / 8)
            Dim SymmetricKey As RijndaelManaged = New RijndaelManaged()
            SymmetricKey.Mode = CipherMode.CBC
            Dim PlainTextBytes As Byte() = New Byte(CipherTextBytes.Length - 1) {}

            Dim ByteCount As Integer = 0

            Using Decryptor As ICryptoTransform = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes)
                Using MemStream As MemoryStream = New MemoryStream(CipherTextBytes)
                    Using CryptoStream As CryptoStream = New CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read)
                        ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length)
                        MemStream.Close()
                        CryptoStream.Close()
                    End Using
                End Using
            End Using
            SymmetricKey.Clear()
            Return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount)
        End Function

        Public Shared Function AES_256_GenerateHash(ByVal Str As String) As String
            Dim StringIncode As New System.Text.UnicodeEncoding
            Dim HashByt() As Byte = New System.Security.Cryptography.SHA512Managed().ComputeHash(StringIncode.GetBytes(Str))
            Dim i As Long
            Dim ReturnText As String = ""
            Dim tmp As String
            For i = 0 To UBound(HashByt)
                tmp = Hex$(HashByt(i))
                If Len(tmp) = 1 Then tmp = "0" & tmp
                ReturnText &= tmp
            Next
            Return ReturnText
        End Function

        Public Shared Function AES_Enc_128(ByVal text As String) As String
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim encrypted As String = ""
            Try
                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Basically_Code))
                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)
                AES.Key = hash
                AES.Mode = Security.Cryptography.CipherMode.ECB
                Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
                Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(text)
                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
                Return encrypted
            Catch ex As Exception
                Return 1
            End Try
        End Function

        Public Shared Function AES_Dec_128(ByVal text As String) As String
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim decrypted As String = ""
            Try
                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Basically_Code))
                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)
                AES.Key = hash
                AES.Mode = Security.Cryptography.CipherMode.ECB
                Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
                Dim Buffer As Byte() = Convert.FromBase64String(text)
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
                Return decrypted
            Catch ex As Exception
                Return 1
            End Try
        End Function

        Public Shared Sub Exchange_AES_Bytes(ByVal ASE_Bytes As String)
            If Basically_Code = "" Then
                _ER.Show_Error("Error : Bytes of value is invalid. Its value can not be used.", "RollRatSubroutins.dll")
                Exit Sub
            End If
            Basically_Code = ASE_Bytes
        End Sub

        Public Shared Sub RTBSaveFileEnc(ByVal FName As String, ByVal Filter As String, ByVal RTB As RichTextBox)
            Dim FileSaver As New SaveFileDialog, ReadText As String = Nothing
            Dim rtbBuffer As New RichTextBox
            FileSaver.FileName = FName
            FileSaver.Filter = Filter
            If FileSaver.ShowDialog = Windows.Forms.DialogResult.OK Then
                rtbBuffer.Text = _AES.AES_Enc_128(RTB.Text)
                My.Computer.FileSystem.WriteAllText(FileSaver.FileName, rtbBuffer.Text, True)
            End If
        End Sub

        Public Shared Sub RTBOpenFileDec(ByVal FName As String, ByVal Filter As String, ByVal RTB As RichTextBox)
            Dim FileOpener As New OpenFileDialog, ReadText As String = Nothing
            Dim rtbBuffer As New RichTextBox
            FileOpener.Filter = Filter
            If FileOpener.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(FileOpener.FileName)
                rtbBuffer.Text = _AES.AES_Dec_128(fileContents)
                RTB.Text = rtbBuffer.Text
            End If
        End Sub

        Public Shared Sub TBSaveFileEnc(ByVal FName As String, ByVal Filter As String, ByVal RTB As TextBox)
            Dim FileSaver As New SaveFileDialog, ReadText As String = Nothing
            Dim rtbBuffer As New TextBox
            FileSaver.FileName = FName
            FileSaver.Filter = Filter
            If FileSaver.ShowDialog = Windows.Forms.DialogResult.OK Then
                rtbBuffer.Text = _AES.AES_Enc_128(RTB.Text)
                My.Computer.FileSystem.WriteAllText(FileSaver.FileName, rtbBuffer.Text, True)
            End If
        End Sub

        Public Shared Sub TBOpenFileDec(ByVal FName As String, ByVal Filter As String, ByVal RTB As TextBox)
            Dim FileOpener As New OpenFileDialog, ReadText As String = Nothing
            Dim rtbBuffer As New TextBox
            FileOpener.Filter = Filter
            If FileOpener.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(FileOpener.FileName)
                rtbBuffer.Text = _AES.AES_Dec_128(fileContents)
                RTB.Text = rtbBuffer.Text
            End If
        End Sub

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _BC

        Public Shared Function GetVersion()
            Return "1.6.1"
        End Function
        Public Shared Function CopyRight()
            Return "Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved." & vbNewLine & _
                   "                        RollRat Software Programs & Lab(R LAB)"
        End Function
        Public Shared Function GetPtrAddress(ByVal o As Object) As Integer
            Dim GC As System.Runtime.InteropServices.GCHandle = System.Runtime.InteropServices.GCHandle.Alloc(o, System.Runtime.InteropServices.GCHandleType.Pinned)
            Dim ret As Integer = GC.AddrOfPinnedObject.ToInt32
            GC.Free()
            Return ret
        End Function
        Public Shared Sub SetColorZero(ByVal hWnd As IntPtr, ByVal Color As UInteger)
            WinApi.SetWindowLong(hWnd, WinApiUsr.GWL_EXSTYLE, WinApi.GetWindowLong(hWnd, WinApiUsr.GWL_EXSTYLE) Or WinApiUsr.WS_EX_LAYERED)
            WinApi.SetLayeredWindowAttributes(hWnd, Color, 0, WinApiUsr.LWA_COLORKEY)
        End Sub
        Public Shared Function GetRGB(ByVal Color As Color) As UInteger
            Dim R As Integer = Color.R
            Dim G As Integer = Color.G
            Dim B As Integer = Color.B
            Dim RGB As Integer = R + (G << 8) + (B << 16)
            Return RGB
        End Function
        Public Shared Function GetB(ByVal Color As Color) As UInteger
            Return Color.B << 16
        End Function
        Public Shared Function GetG(ByVal Color As Color) As UInteger
            Return Color.G << 8
        End Function
        Public Shared Sub Locker(ByVal Text As String, ByVal keys As String, ByVal seconds As Integer)
            Dim success As Boolean = False
            Dim now As DateTime = DateTime.Now
            WinApi.BlockInput(True)
            While (success = False And (DateTime.Now.Subtract(now).Seconds < seconds Or seconds = 0))
                Try
                    AppActivate(Text)
                    SendKeys.SendWait(keys)
                    success = True
                Catch
                    System.Threading.Thread.Sleep(100)
                End Try
            End While
            WinApi.BlockInput(False)
        End Sub
        Public Shared Sub VolumeMute(ByVal Handle As IntPtr)
            WinApi.SendMessageW(Handle, WinApiUsr.WM_APPCOMMAND, Handle, New IntPtr(WinApiUsr.APPCOMMAND_VOLUME_MUTE * _R_CO.AppCommandValueMul))
        End Sub
        Public Shared Sub VolumeDown(ByVal Handle As IntPtr)
            WinApi.SendMessageW(Handle, WinApiUsr.WM_APPCOMMAND, Handle, New IntPtr(WinApiUsr.APPCOMMAND_VOLUME_DOWN * _R_CO.AppCommandValueMul))
        End Sub
        Public Shared Sub VolumeUp(ByVal Handle As IntPtr)
            WinApi.SendMessageW(Handle, WinApiUsr.WM_APPCOMMAND, Handle, New IntPtr(WinApiUsr.APPCOMMAND_VOLUME_UP * _R_CO.AppCommandValueMul))
        End Sub
        Public Shared Function GetCpuUsageByTarget(ByVal Target As String)
            Dim A As New PerformanceCounter("Process", "% User Time", Target)
            Return A.NextValue
        End Function
        Public Shared Function GetMemoryUsageByTarget(ByVal Target As String)
            Dim A As New PerformanceCounter("Process", "Working Set - Private", Target)
            Return A.NextValue
        End Function
        Public Shared CPU_C As New PerformanceCounter("Processor", "% Processor Time", "_Total")
        Public Shared Function GetCpuUsage()
            Return CPU_C.NextValue
        End Function
        Public Shared Memory_C As New PerformanceCounter("Memory", "% Committed Bytes In Use", "")
        Public Shared Function GetMemoryUsage()
            Return Memory_C.NextValue
        End Function
        Public Shared Threads_C As New PerformanceCounter("Objects", "Threads", "")
        Public Shared Function GetThread()
            Return Threads_C.NextValue
        End Function
        Public Shared Handle_C As New PerformanceCounter("Process", "Handle Count", "_Total")
        Public Shared Function GetHandle()
            Return Handle_C.NextValue
        End Function
        Public Shared Function GetWebPageSource(ByVal WebPageURL As String)
            Try
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(WebPageURL)
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim sourcecode As String = sr.ReadToEnd()
                Return sourcecode
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function
        Public Shared Function LOWORD(ByVal l As UInteger)
            Return l & &HFFFF
        End Function
        Public Shared Function HIWORD(ByVal l As UInteger)
            Return (l >> 16) & &HFFFF
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _ER

        Public Shared Sub Show_Error(ByVal Title As String, ByVal Body As String)
            MsgBox(Body, MsgBoxStyle.Critical, Title)
        End Sub

        Public Shared Sub Show_Impomation(ByVal Title As String, ByVal Body As String)
            MsgBox(Body, MsgBoxStyle.Information, Title)
        End Sub

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _DM
        Public Shared DPs As New DP
        Public Shared Function Algorithm_Types_Data_Setter(ByVal str As String)
            Dim StrF As String = Algorithm_Types_Data_JunkTo(Algorithm_Types_Data_Set(Algorithm_Types_Data_JunkTo(str)))
            Return StrF
        End Function
        Public Shared Function Algorithm_Types_Data_JunkTo(ByVal str As String)
            Dim StrF As String = _AES.AES_Enc_128(str)
            Return StrF
        End Function
        Public Shared Function Algorithm_Types_Data_Set(ByVal str As String)
            Dim StrF As String = _ED.Encrypt_String(str)
            Return StrF
        End Function
        Public Shared Function Algorithm_Types_Ret_Setter(ByVal str As String)
            Dim StrF As String = Algorithm_Types_Ret_JunkTo(Algorithm_Types_Ret_Set(Algorithm_Types_Ret_JunkTo(str)))
            Return StrF
        End Function
        Public Shared Function Algorithm_Types_Ret_JunkTo(ByVal str As String)
            Dim StrF As String = _AES.AES_Dec_128(str)
            Return StrF
        End Function
        Public Shared Function Algorithm_Types_Ret_Set(ByVal str As String)
            Dim StrF As String = _ED.Decrypt_From_String(str)
            Return StrF
        End Function
        Public Shared Sub Set_AES_String(ByVal str As String)
            _AES.Basically_Code = str
        End Sub
        Public Structure DeAnalysis
            Dim richtextbox As RichTextBox
            Dim listview As ListView
            Dim All_OfColum As Integer
            Dim Array_Data As String()
        End Structure
        Public Structure ProjectMake
            Dim LFirst As String
            Dim LLast As String
            Dim ListView As ListView
            Dim InputData As String
        End Structure
        Public Structure DeProject
            Dim DeAnalysis As DeAnalysis
            Dim ProjectMake As ProjectMake
        End Structure
        Public Structure DP
            Dim A As String
            Dim B As String
        End Structure
        Public Shared Function AnalysisAll(ByVal richtextbox1 As RichTextBox, listview1 As ListView)
            On Error Resume Next
            Dim Datas_P_S As Boolean = False
            Dim Datas_P_D As Boolean = False
            Dim Datas_P_F As Boolean = False
            Dim Alpahss As DeAnalysis
            Dim Max_Value As Integer
            Dim Array_Data As String()
            Dim ColumnHeader As System.Windows.Forms.ColumnHeader()
            Dim LISTVIEWW As ListView
            Dim Max_Jul As Integer = _CA.Jul(richtextbox1)
            LISTVIEWW = listview1
            For A = 0 To Max_Jul - 1
                If Datas_P_S = False Then
                    If Not _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "["), 1, 0, "]") = "" Then
                        Dim F As String = _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "["), 1, 0, "]")
                        If _Str.Split(_Str.Split(F, 1, 0, " "), 1, 0, "_") = "Private" Then
                            If _Str.Split(_Str.Split(F, 1, 0, " "), 1, 1, "_") = "Setter" Then
                                Datas_P_S = True
                                Dim Fs = _Str.Split(_Str.Split(_Str.Split(F, 1, 1, " "), 1, 1, "<"), 1, 0, ">")
                                If Fs = "Datas" Then
                                    Datas_P_D = True
                                End If
                            End If
                        ElseIf _Str.Split(_Str.Split(F, 1, 0, " "), 1, 0, "_") = "Public" Then
                            If _Str.Split(_Str.Split(F, 1, 0, " "), 1, 1, "_") = "Setter" Then
                                Datas_P_S = True
                                Dim Fs = _Str.Split(_Str.Split(_Str.Split(F, 1, 1, " "), 1, 1, "<"), 1, 0, ">")
                                If Fs = "Datas" Then
                                    Datas_P_F = True
                                End If
                            End If
                        End If
                    End If
                ElseIf Datas_P_S = True Then
                    If Datas_P_D = True Then
                        If _CA.Code_Jul_Get(richtextbox1, A, 1, 0, ";") = "r" Then
                            If _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, ";"), 1, 0, "=") = "Set" Then
                                If _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "="), 1, 0, "(") = "DataValue" Then
                                    Array_Data = New String(CInt(_Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "("), 1, 0, ")"))) {}
                                    Max_Value = CInt(_Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "("), 1, 0, ")"))
                                ElseIf _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "="), 1, 0, "{") = "Mash" Then
                                    Dim QuiptlyDatas As String = _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "{"), 1, 0, "}")
                                    For Y = 0 To Max_Value
                                        Array_Data(Y) = _Str.Split(_Str.Split(QuiptlyDatas, Y, Y, ","), 1, 1, "'")
                                    Next
                                    With LISTVIEWW
                                        .Clear()
                                        .View = View.Details
                                        ColumnHeader = New System.Windows.Forms.ColumnHeader(Max_Value) {}
                                        For Y = 0 To Max_Value
                                            ColumnHeader(Y) = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
                                            With ColumnHeader(Y)
                                                .Text = Array_Data(Y)
                                            End With
                                        Next
                                        .Columns.AddRange(ColumnHeader)
                                    End With
                                End If
                            ElseIf _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, ";"), 1, 0, "=") = "Ret" Then
                                Datas_P_S = False
                                Datas_P_D = False
                            End If
                        End If
                    ElseIf Datas_P_F = True Then
                        If _CA.Code_Jul_Get(richtextbox1, A, 1, 0, ";") = "f" Then
                            If _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "="), 1, 0, "{") = "K" Then
                                Dim strArray = New String(Max_Value) {}
                                Dim QuiptlyDatas As String = _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, "{"), 1, 0, "}")
                                For XY = 0 To Max_Value
                                    strArray(XY) = _Str.Split(_Str.Split(QuiptlyDatas, XY, XY, ","), 1, 1, "'")
                                Next
                                Dim lvt = New ListViewItem(strArray)
                                LISTVIEWW.Items.Add(lvt)
                            ElseIf _Str.Split(_CA.Code_Jul_Get(richtextbox1, A, 1, 1, ";"), 1, 0, "=") = "Ret" Then
                                Datas_P_S = False
                                Datas_P_D = False
                            End If
                        End If
                    End If
                End If
            Next
            With Alpahss
                .All_OfColum = Max_Value
                .Array_Data = Array_Data
                .listview = listview1
                .richtextbox = richtextbox1
            End With
            DPs.A = _Str.ReadLineByLine(richtextbox1.Text, 1)
            DPs.B = _Str.ReadLineByLine(richtextbox1.Text, 2)
            Return Alpahss
        End Function
        Public Shared Function DeAnalysisAll(ByVal dalDeAnalysis As DeAnalysis)
            On Error Resume Next
            Dim rtbBuffer As New RichTextBox
            With rtbBuffer
                .AppendText("[Private_Setter <Datas>]" & vbNewLine)
                .AppendText("r;Set=DataValue(" & dalDeAnalysis.All_OfColum & ")" & vbNewLine)
                .AppendText("r;Set=Mash{")
                For A = 0 To dalDeAnalysis.All_OfColum
                    .AppendText("'")
                    .AppendText(dalDeAnalysis.Array_Data(A))
                    .AppendText("'")
                    If Not A = dalDeAnalysis.All_OfColum Then
                        .AppendText(", ")
                    End If
                Next
                .AppendText("}" & vbNewLine)
                .AppendText("r;Ret=" & vbNewLine & vbNewLine)

                .AppendText("[Public_Setter <Datas>]" & vbNewLine)
                For A = 0 To dalDeAnalysis.listview.Items.Count - 1
                    dalDeAnalysis.listview.Items(A).Selected = True
                    .AppendText("f;Data=K{")
                    For B = 0 To dalDeAnalysis.All_OfColum
                        .AppendText("'")
                        .AppendText(_LV.Item(dalDeAnalysis.listview, A, B))
                        .AppendText("'")
                        If Not B = dalDeAnalysis.All_OfColum Then
                            .AppendText(", ")
                        End If
                    Next
                    .AppendText("}" & vbNewLine)
                Next
                .AppendText("f;Ret=")

                Return .Text
            End With
        End Function
        Public Shared Sub SaveFilewithAlgorithmEnc(ByVal richtextbox1 As RichTextBox, ByVal sString As String)
            Dim FileSaver As New SaveFileDialog, ReadText As String = Nothing
            Dim rtbBuffer As New RichTextBox
            FileSaver.Filter = "DB 파일|*.rdb"
            If FileSaver.ShowDialog = Windows.Forms.DialogResult.OK Then
                _DM.Set_AES_String(sString)
                rtbBuffer.Text = _DM.Algorithm_Types_Data_Setter(richtextbox1.Text)
                My.Computer.FileSystem.WriteAllText(FileSaver.FileName, rtbBuffer.Text, True)
            End If
        End Sub
        Public Shared Sub OpenFilewithAlgorithmEnc(ByVal richtextbox1 As RichTextBox, ByVal sString As String)
            Dim FileOpener As New OpenFileDialog, ReadText As String = Nothing
            Dim rtbBuffer As New RichTextBox
            FileOpener.Filter = "DB 파일|*.rdb"
            If FileOpener.ShowDialog = Windows.Forms.DialogResult.OK Then
                _DM.Set_AES_String(sString)
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText(FileOpener.FileName)
                rtbBuffer.Text = _DM.Algorithm_Types_Ret_Setter(fileContents)
                richtextbox1.Text = rtbBuffer.Text
            End If
        End Sub
        Public Shared Sub Save(ByVal richtextbox1 As RichTextBox, ByVal sString As String)
            Dim rtbBuffer As New RichTextBox
            _DM.Set_AES_String(sString)
            rtbBuffer.Text = _DM.Algorithm_Types_Data_Setter(richtextbox1.Text)
            My.Computer.FileSystem.WriteAllText("C:\windows\buffer.t", rtbBuffer.Text, True)
            richtextbox1.Text = rtbBuffer.Text
        End Sub
        Public Shared Sub Open(ByVal richtextbox1 As RichTextBox, ByVal sString As String)
            Dim rtbBuffer1 As New RichTextBox
            Dim fileContents As String
            fileContents = My.Computer.FileSystem.ReadAllText("C:\windows\buffer.t")
            rtbBuffer1.Text = _DM.Algorithm_Types_Ret_Setter(fileContents)
            richtextbox1.Text = rtbBuffer1.Text
            Kill("C:\windows\buffer.t")
        End Sub
        Public Shared Function New_Project(ByVal F As ProjectMake)

            On Error Resume Next
            Dim Max_Value As Integer
            Dim Array_Data As String()
            Dim Alphasss As _DM.DeAnalysis
            Array_Data = New String(CInt(_Str.Split(_Str.Split(F.LFirst, 1, 1, "("), 1, 0, ")"))) {}
            Max_Value = CInt(_Str.Split(_Str.Split(F.LFirst, 1, 1, "("), 1, 0, ")"))
            Dim QuiptlyDatas As String = _Str.Split(_Str.Split(F.LLast, 1, 1, "{"), 1, 0, "}")
            For Y = 0 To Max_Value
                Array_Data(Y) = _Str.Split(_Str.Split(QuiptlyDatas, Y, Y, ","), 1, 1, "'")
            Next

            Dim LISTVIEWW As ListView
            LISTVIEWW = F.ListView

            Dim ColumnHeader As System.Windows.Forms.ColumnHeader()

            With LISTVIEWW
                .Clear()
                .View = View.Details
                ColumnHeader = New System.Windows.Forms.ColumnHeader(Max_Value) {}
                For Y = 0 To Max_Value
                    ColumnHeader(Y) = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
                    With ColumnHeader(Y)
                        .Text = Array_Data(Y)
                    End With
                Next
                .Columns.AddRange(ColumnHeader)
            End With

            With Alphasss
                .All_OfColum = Max_Value
                .Array_Data = Array_Data
                .listview = F.ListView
            End With

            Return Alphasss

        End Function
        Public Shared Function New_Tap_And_Clear(ByVal Ye As ProjectMake, ByVal _Max_Value As Integer)

            On Error Resume Next
            Dim Array_Data As String()
            Dim Alphasss As New _DM.DeAnalysis
            Dim DE As DeProject
            Dim F As _DM.ProjectMake = Ye

            F.LFirst = "r;Set=DataValue(" & _Max_Value + 1 & ")"
            F.LLast = _Str.Split(F.LLast, 1, 0, "}") & ", '" & F.InputData & "'}"

            Dim Max_Value As Integer
            Array_Data = New String(CInt(_Str.Split(_Str.Split(F.LFirst, 1, 1, "("), 1, 0, ")"))) {}
            Max_Value = CInt(_Str.Split(_Str.Split(F.LFirst, 1, 1, "("), 1, 0, ")"))

            Dim QuiptlyDatas As String = _Str.Split(_Str.Split(F.LLast, 1, 1, "{"), 1, 0, "}")

            For Y = 0 To Max_Value
                Array_Data(Y) = _Str.Split(_Str.Split(QuiptlyDatas, Y, Y, ","), 1, 1, "'")
            Next

            Dim LISTVIEWW As ListView
            LISTVIEWW = F.ListView

            Dim ColumnHeader As System.Windows.Forms.ColumnHeader()
            With LISTVIEWW
                .Clear()
                .View = View.Details
                ColumnHeader = New System.Windows.Forms.ColumnHeader(Max_Value) {}
                For Y = 0 To Max_Value
                    ColumnHeader(Y) = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
                    With ColumnHeader(Y)
                        .Text = Array_Data(Y)
                    End With
                Next
                .Columns.AddRange(ColumnHeader)
            End With

            With Alphasss
                .All_OfColum = Max_Value
                .Array_Data = Array_Data
                .listview = F.ListView
            End With

            DE.DeAnalysis = Alphasss
            DE.ProjectMake = F

            Return DE

        End Function
        Public Shared Function New_Tap_And_Keep(ByVal Ye As DeProject, ByVal _Max_Value As Integer)

            On Error Resume Next
            Dim Array_Data As String()
            Dim Alphasss As New _DM.DeAnalysis
            Dim DE As DeProject
            Dim F As _DM.ProjectMake = Ye.ProjectMake
            Dim rtbBuffer As New RichTextBox

            With rtbBuffer

                For A = 0 To Ye.DeAnalysis.listview.Items.Count - 1

                    Ye.DeAnalysis.listview.Items(A).Selected = True
                    .AppendText("f;Data=K{")
                    For B = 0 To Ye.DeAnalysis.All_OfColum
                        .AppendText("'")
                        .AppendText(_LV.Item(Ye.DeAnalysis.listview, A, B))
                        .AppendText("'")
                        If Not B = Ye.DeAnalysis.All_OfColum Then
                            .AppendText(", ")
                        End If
                    Next
                    .AppendText("}" & vbNewLine)

                Next

            End With

            Dim FST As New RichTextBox
            FST.Text = DeAnalysisAll(Ye.DeAnalysis)
            AnalysisAll(FST, Ye.ProjectMake.ListView)

            F.LFirst = "r;Set=DataValue(" & _Max_Value + 1 & ")"
            F.LLast = _Str.Split(F.LLast, 1, 0, "}") & ", '" & F.InputData & "'}"

            Dim Max_Value As Integer
            Array_Data = New String(CInt(_Str.Split(_Str.Split(F.LFirst, 1, 1, "("), 1, 0, ")"))) {}
            Max_Value = CInt(_Str.Split(_Str.Split(F.LFirst, 1, 1, "("), 1, 0, ")"))

            Dim QuiptlyDatas As String = _Str.Split(_Str.Split(F.LLast, 1, 1, "{"), 1, 0, "}")
            For Y = 0 To Max_Value
                Array_Data(Y) = _Str.Split(_Str.Split(QuiptlyDatas, Y, Y, ","), 1, 1, "'")
            Next

            Dim LISTVIEWW As ListView
            LISTVIEWW = F.ListView

            Dim ColumnHeader As System.Windows.Forms.ColumnHeader()
            With LISTVIEWW
                .Clear()
                .View = View.Details
                ColumnHeader = New System.Windows.Forms.ColumnHeader(Max_Value) {}
                For Y = 0 To Max_Value
                    ColumnHeader(Y) = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
                    With ColumnHeader(Y)
                        .Text = Array_Data(Y)
                    End With
                Next
                .Columns.AddRange(ColumnHeader)
            End With


            Dim Max_Jul As Integer = _CA.Jul(rtbBuffer)
            For A = 0 To Max_Jul - 1

                Dim strArray = New String(Max_Value) {}
                Dim tQuiptlyDatas As String = _Str.Split(_CA.Code_Jul_Get(rtbBuffer, A, 1, 1, "{"), 1, 0, "}")
                For XY = 0 To Max_Value
                    strArray(XY) = _Str.Split(_Str.Split(tQuiptlyDatas, XY, XY, ","), 1, 1, "'")
                Next
                If strArray(0) = "" Then
                    GoTo E
                End If
                Dim lvt = New ListViewItem(strArray)
                LISTVIEWW.Items.Add(lvt)
E:
            Next

            With Alphasss
                .All_OfColum = Max_Value
                .Array_Data = Array_Data
                .listview = F.ListView
            End With

            DE.DeAnalysis = Alphasss
            DE.ProjectMake = F

            Return DE

        End Function
        Public Shared Function Destroy_Tap_And_Keep(ByVal Ye As DeProject, ByVal _Max_Value As Integer)

            On Error Resume Next
            Dim Array_Data As String()
            Dim Alphasss As New _DM.DeAnalysis
            Dim DE As DeProject
            Dim F As _DM.ProjectMake = Ye.ProjectMake
            Dim rtbBuffer As New RichTextBox

            With rtbBuffer

                For A = 0 To Ye.DeAnalysis.listview.Items.Count - 1

                    Ye.DeAnalysis.listview.Items(A).Selected = True
                    .AppendText("f;Data=K{")
                    For B = 0 To Ye.DeAnalysis.All_OfColum
                        .AppendText("'")
                        .AppendText(_LV.Item(Ye.DeAnalysis.listview, A, B))
                        .AppendText("'")
                        If Not B = Ye.DeAnalysis.All_OfColum Then
                            .AppendText(", ")
                        End If
                    Next
                    .AppendText("}" & vbNewLine)

                Next

            End With

            Dim FST As New RichTextBox
            FST.Text = DeAnalysisAll(Ye.DeAnalysis)
            AnalysisAll(FST, Ye.ProjectMake.ListView)
            F.LFirst = "r;Set=DataValue(" & _Max_Value - 1 & ")"

            Dim eF As Integer
            Dim sfTring As String() = New String(1000) {}
            For A = 0 To 10000
                eF = A
                If _Str.Split(_Str.Split(_Str.Split(F.LLast, 1, 1, "{"), 1, 0, "}"), A, A, ",") = "" Then
                    Exit For
                End If
                sfTring(A) = _Str.Split(_Str.Split(_Str.Split(F.LLast, 1, 1, "{"), 1, 0, "}"), A, A, ",")
            Next

            Dim FTYB As New TextBox
            FTYB.AppendText("r;Set=Mash{")

            For A = 0 To eF - 1
                FTYB.AppendText(sfTring(A))
                If Not A = eF Then
                    FTYB.AppendText(", ")
                End If
            Next

            FTYB.AppendText("}")
            F.LLast = FTYB.Text

            'F.LLast = _Str.split(F.LLast, 1, 0, "}") & ", '" & F.InputData & "'}"

            Dim Max_Value As Integer
            Array_Data = New String(CInt(_Str.Split(_Str.Split(F.LFirst, 1, 1, "("), 1, 0, ")"))) {}
            Max_Value = CInt(_Str.Split(_Str.Split(F.LFirst, 1, 1, "("), 1, 0, ")"))

            Dim QuiptlyDatas As String = _Str.Split(_Str.Split(F.LLast, 1, 1, "{"), 1, 0, "}")
            For Y = 0 To Max_Value
                Array_Data(Y) = _Str.Split(_Str.Split(QuiptlyDatas, Y, Y, ","), 1, 1, "'")
            Next

            Dim LISTVIEWW As ListView
            LISTVIEWW = F.ListView

            Dim ColumnHeader As System.Windows.Forms.ColumnHeader()
            With LISTVIEWW
                .Clear()
                .View = View.Details
                ColumnHeader = New System.Windows.Forms.ColumnHeader(Max_Value) {}
                For Y = 0 To Max_Value
                    ColumnHeader(Y) = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
                    With ColumnHeader(Y)
                        .Text = Array_Data(Y)
                    End With
                Next
                .Columns.AddRange(ColumnHeader)
            End With


            Dim Max_Jul As Integer = _CA.Jul(rtbBuffer)
            For A = 0 To Max_Jul - 1

                Dim strArray = New String(Max_Value) {}
                Dim tQuiptlyDatas As String = _Str.Split(_CA.Code_Jul_Get(rtbBuffer, A, 1, 1, "{"), 1, 0, "}")
                For XY = 0 To Max_Value
                    strArray(XY) = _Str.Split(_Str.Split(tQuiptlyDatas, XY, XY, ","), 1, 1, "'")
                Next
                If strArray(0) = "" Then
                    GoTo E
                End If
                Dim lvt = New ListViewItem(strArray)
                LISTVIEWW.Items.Add(lvt)
E:
            Next

            With Alphasss
                .All_OfColum = Max_Value
                .Array_Data = Array_Data
                .listview = F.ListView
            End With

            DE.DeAnalysis = Alphasss
            DE.ProjectMake = F

            Return DE

        End Function
        Public Shared Function Destroy_Selected_Item(ByVal ListView As ListView, ByVal Max_Value As Integer)

            Dim ListView1 As New ListView
            ListView1 = ListView

            Dim rtbBuffer As New RichTextBox

            Dim Get_Selected_Item As String

            Get_Selected_Item = _LV.Item(ListView1, 0, 0)

            With rtbBuffer

                .Clear()

                For At = 0 To ListView1.Items.Count - 1

                    ListView1.Items(At).Selected = True

                    If _LV.Item(ListView1, At, 0) = Get_Selected_Item Then

                        GoTo F

                    End If

                    .AppendText("f;Data=K{")
                    For B = 0 To Max_Value
                        .AppendText("'")
                        .AppendText(_LV.Item(ListView1, At, B))
                        .AppendText("'")
                        If Not B = Max_Value Then
                            .AppendText(", ")
                        End If
                    Next
                    .AppendText("}" & vbNewLine)
F:
                Next

            End With

            ListView1.Items.Clear()

            Dim Max_Jul As Integer = _CA.Jul(rtbBuffer)

            For At = 0 To Max_Jul - 1

                Dim strArray = New String(Max_Value) {}
                Dim tQuiptlyDatas As String = _Str.Split(_CA.Code_Jul_Get(rtbBuffer, At, 1, 1, "{"), 1, 0, "}")
                For XY = 0 To Max_Value
                    strArray(XY) = _Str.Split(_Str.Split(tQuiptlyDatas, XY, XY, ","), 1, 1, "'")
                Next
                If strArray(0) = "" Then
                    GoTo E
                End If
                Dim lvt = New ListViewItem(strArray)
                ListView1.Items.Add(lvt)
E:
            Next

            Return ListView1

        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _NS

        Public Shared Sub Highligthing(ByVal RichN As RichTextBox, ByVal StrArray() As String, ByVal color As Color, ByVal Seconder As Boolean)
            Dim str As String
            If RichN.Text.Length > 0 Then
                Dim _select As Integer = RichN.SelectionStart
                If Seconder = False Then
                    RichN.Select(0, RichN.Text.Length)
                    RichN.SelectionColor = color.Black
                    RichN.DeselectAll()
                End If
                For Each str In StrArray
                    Dim Int As Integer = 0
                    Do While RichN.Text.ToUpper.IndexOf(str.ToUpper, Int) >= 0
                        Int = RichN.Text.ToUpper.IndexOf(str.ToUpper, Int)
                        RichN.Select(Int, str.Length)
                        RichN.SelectionColor = color.Blue
                        Int += 1
                    Loop
                Next
                RichN.SelectionStart = _select
            End If
        End Sub
        Public Shared Sub FindAndChange(ByVal RichN As RichTextBox, ByVal TextA As String, ByVal TextB As String)
            Dim str As String
            If RichN.Text.Length > 0 Then
                Dim _select As Integer = RichN.SelectionStart
                For Each str In TextA
                    Dim Int As Integer = 0
                    Do While RichN.Text.ToUpper.IndexOf(str.ToUpper, Int) >= 0
                        Int = RichN.Text.ToUpper.IndexOf(str.ToUpper, Int)
                        RichN.Select(Int, str.Length)
                        RichN.SelectedText = TextB
                        Int += 1
                    Loop
                Next
                RichN.SelectionStart = _select
            End If
        End Sub
        Public Shared Function GetAllOfThings(ByVal Text As String, ByVal Things As String)
            Dim RTB As New RichTextBox : RTB.Clear()
            RTB.Text = Text : RTB.AppendText("閒")
            Dim count As Integer = 0
            Dim i As Integer = 0
            i = RTB.Find(Things, 0, RichTextBoxFinds.None)
            If i > -1 Then
                count = 1
                Do
                    i = RTB.Find(Things, i + 1, RichTextBoxFinds.None)
                    If i > -1 Then
                        count += 1
                    End If
                Loop Until i < 0
            End If
            Return count
        End Function
        Public Shared Function SpGetAOT(ByVal Text As String, ByVal Things As String)
            Dim A As Integer = Text.Length
            Dim B As String = _Str.Changer(Text, Things, "")
            Dim C As Integer = B.Length
            Dim D As Integer = A - C
            Return D / Things.Length
        End Function

        Public Shared Function GetArrayAnalysisAndPutTheArray(ByVal Text As String, ByVal M As String, ByVal F As Char)
            Dim Buf() As String = New String(GetAllOfThings(Text, M)) {}
            For A = 0 To GetAllOfThings(Text, M)
                Buf(A) = _Str.Split(_Str.Split(Text, A, A, M), 1, 1, F)
            Next
            Return Buf
        End Function

        Public Shared Function BasicallyGetArrayAnalysisAndPutTheArray(ByVal Text As String)
            Dim Buf() As String = New String(GetAllOfThings(Text, ",")) {}
            For A = 0 To GetAllOfThings(Text, ",")
                Buf(A) = _Str.Split(_Str.Split(Text, A, A, ","), 1, 1, "'")
            Next
            Return Buf
        End Function

        Public Enum DSpace
            Basically
            Left
            Right
        End Enum

        Public Shared Function DestroySpace(ByVal Text As String, ByVal Type As DSpace)
            If Type = DSpace.Basically Then
                Return Trim(Text)
            ElseIf Type = DSpace.Left Then
                Return LTrim(Text)
            ElseIf Type = DSpace.Right Then
                Return RTrim(Text)
            End If
        End Function

        Public Enum CUT
            Left
            Right
        End Enum

        Public Shared Function Cutter(ByVal Text As String, ByVal Length As Integer, ByVal Type As CUT)
            If Type = CUT.Left Then
                Return LSet(Text, Length)
            ElseIf Type = CUT.Right Then
                Return RSet(Text, Length)
            End If
        End Function

        Public Shared Function GetAllOfCutterSyntaxForRtb(ByVal RTB As RichTextBox, ByVal CutterSyntax As String) As RichTextBox
            Dim RTBA As New RichTextBox
            RTBA = RTB
            RTBA.Text = Nothing
            Try
                For A = 0 To 10000000
                    If _Str.Split(RTB.Text, A, A, CutterSyntax) = "" Then
                        Exit Try
                    End If
                    RTBA.AppendText(_Str.Split(RTB.Text, A, A, CutterSyntax) & vbCrLf)
                Next
            Catch ex As Exception
            End Try
            Return RTBA
        End Function

        Public Shared Function GetAllOfCutterSyntaxForTb(ByVal TB As TextBox, ByVal CutterSyntax As String) As TextBox
            Dim TBA As New TextBox
            TBA = TB
            TBA.Text = Nothing
            Try
                For A = 0 To 10000000
                    If _Str.Split(TB.Text, A, A, CutterSyntax) = "" Then
                        Exit Try
                    End If
                    TBA.AppendText(_Str.Split(TB.Text, A, A, CutterSyntax) & vbCrLf)
                Next
            Catch ex As Exception
            End Try
            Return TBA
        End Function

        Public Shared Sub [ReDim](ByRef Text(,) As String, ByVal m As Integer, ByVal f As Integer)
            ReDim Text(m, f)
        End Sub

        Public Shared Function ASE_EncByKeyS(ByVal Value As Integer, ByVal ByCode As String)
            Dim A As String
            For fy = 0 To Value
                If Not fy = 0 Then
                    A = _AES.AES_Enc_128(A)
                Else
                    A = _AES.AES_Enc_128(ByCode)
                End If
            Next
            Return A
        End Function

        Public Shared Function ASE_DecByKeyS(ByVal Value As Integer, ByVal ByCode As String)
            Dim A As String
            For fy = 0 To Value
                If Not fy = 0 Then
                    A = _AES.AES_Dec_128(A)
                Else
                    A = _AES.AES_Dec_128(ByCode)
                End If
            Next
            Return A
        End Function

        Public Shared Function ASE_ChuChul(ByVal ByCode As String)
            Dim y As String = ByCode
            Dim F As New TextBox
            F.Text = ""
            Dim TL As Integer = CInt(ByCode.Length / 50)
            F.AppendText("rollrat의 의하여 작성된코드" & vbCrLf & vbCrLf)
            F.AppendText("시간 : " & My.Computer.Clock.LocalTime & vbCrLf & vbCrLf)
            For A = 0 To TL - 1
                F.AppendText("/// 암호화된 코드 /// " & LSet(y, 50) & " // 줄 : " & RSet(A, 4) & vbCrLf)
                y = y.Replace(LSet(y, 50), "")
            Next
            Return F.Text
        End Function

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _PE

        Public Shared Function GetWindowHandle(ByVal lpWindowName As String) As IntPtr

            Return WinApi.FindWindow(0, lpWindowName)

        End Function

        Public Shared Sub MessageSend(ByVal WndHandle As IntPtr, ByVal uEvent As Integer)

            WinApi.PostMessage(WndHandle, uEvent, 0, 0)

        End Sub

        Public Shared Sub DestroyWnd(ByVal Point As Point)

            _PE.MessageSend(WinApi.WindowFromPoint(Point), WinApiUsr.WM_DESTROY)

        End Sub

        Public Shared Sub CloseWnd(ByVal Point As Point)

            _PE.MessageSend(WinApi.WindowFromPoint(Point), WinApiUsr.WM_CLOSE)

        End Sub

        Public Shared Sub ShowWnd_WName(ByVal lpWindowName As String)

            _PE.MessageSend(GetWindowHandle(lpWindowName), WinApiUsr.WM_SHOWWINDOW)

        End Sub

        Public Shared Sub ShowWnd_PHandle(ByVal ProcName As String)

            _PE.MessageSend(GetProcHandle(ProcName), WinApiUsr.WM_SHOWWINDOW)

        End Sub

        Public Shared Sub CurDestroyWnd()

            Dim Point As Point
            WinApi.GetCursorPos(Point)

            _PE.MessageSend(WinApi.WindowFromPoint(Point), WinApiUsr.WM_CLOSE)

        End Sub

        Public Shared Function GetProcHandle(ByVal ProcName As String) As IntPtr

            Dim ProcArray() As Process

            ProcArray = Process.GetProcessesByName(ProcName)

            If ProcArray.Length > 0 Then

                Return ProcArray(0).MainWindowHandle

            Else

                Return 0

            End If

        End Function

        Public Shared Function GetProcId(ByVal ProcName As String) As IntPtr

            Dim ProcArray() As Process

            ProcArray = Process.GetProcessesByName(ProcName)

            If ProcArray.Length > 0 Then

                Dim myProcess As Process

                For Each myProcess In ProcArray

                    Return myProcess.Handle

                Next myProcess

            Else

                Return 0

            End If

        End Function

        ''' <summary>
        ''' 사용금지
        ''' </summary>
        Public Shared Function GetProcessIdByName(ByVal ProcName As String)
            Dim pe32 As New WinApi.PROCESSENTRY32
            Dim hSnapshot As IntPtr
            Dim pePtr As IntPtr
            Marshal.StructureToPtr(pe32, pePtr, True)
            WinApi.ZeroMemory(pePtr, Marshal.SizeOf(pe32))
            If hSnapshot = -1 Then Return 0
            pe32.dwSize = Marshal.SizeOf(pe32)
            If WinApi.Process32First(hSnapshot, pe32) = False Then
                WinApi.CloseHandle(hSnapshot)
                Return 0
            End If
            If Not pe32.szExeFile = ProcName Then
                WinApi.CloseHandle(hSnapshot)
                Return 0
            End If
            While WinApi.Process32Next(hSnapshot, pe32) = True
                If Not pe32.szExeFile = ProcName Then
                    WinApi.CloseHandle(hSnapshot)
                    Return pe32.th32ProcessID
                End If
            End While
            WinApi.CloseHandle(hSnapshot)
            Return 0
        End Function



        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class _SH

        Private Sub NumberPut(ByRef g As Graphics, ByRef RTB As RichTextBox, ByRef MyPictureBox As PictureBox)
            Dim FH As Single = RTB.GetPositionFromCharIndex(RTB.GetFirstCharIndexFromLine(2)).Y - RTB.GetPositionFromCharIndex(RTB.GetFirstCharIndexFromLine(1)).Y
            If FH = 0 Then Exit Sub
            Dim FI As Integer = RTB.GetCharIndexFromPosition(New Point(0, g.VisibleClipBounds.Y + FH / 3))
            Dim FL As Integer = RTB.GetLineFromCharIndex(FI)
            Dim FLY As Integer = RTB.GetPositionFromCharIndex(FI).Y
            g.Clear(Control.DefaultBackColor)
            Dim i As Integer = FL
            Dim y As Single
            Do While y < g.VisibleClipBounds.Y + g.VisibleClipBounds.Height
                y = FLY + 2 + FH * (i - FL - 1)

                g.DrawString((i).ToString, RTB.Font, Brushes.DarkGray, MyPictureBox.Width - g.MeasureString((i).ToString, RTB.Font).Width, y)
                i += 1
            Loop
        End Sub
        Public Shared Function Old_Color(ByVal Text As RichTextBox, ByVal SyntaxText As String, ByVal Color As Color)
            Dim A As Integer
            Dim B As Integer
            Dim C As Integer
            Dim D As Integer
            Dim E As Integer
            C = Text.SelectionStart
            D = Text.SelectionLength
            B = Len(SyntaxText)
            A = Text.Find(SyntaxText, 0, RichTextBoxFinds.NoHighlight)
            While A > 0
                E = E + 1
                Text.SelectionStart = A
                Text.SelectionLength = B
                Text.SelectionColor = Color
                A = Text.Find(SyntaxText, A + B, RichTextBoxFinds.NoHighlight)
            End While
            Text.SelectionStart = C
            Text.SelectionLength = D
            Old_Color = E
        End Function
        Public Shared Function Old_Highligth(ByVal Text As RichTextBox, ByVal SyntaxText As String, ByVal Color As Color)
            Dim A As Integer
            Dim B As Integer
            Dim C As Integer
            Dim D As Integer
            Dim E As Integer
            C = Text.SelectionStart
            D = Text.SelectionLength
            B = Len(SyntaxText)
            A = Text.Find(SyntaxText, 0, RichTextBoxFinds.NoHighlight)
            While A > 0
                E = E + 1
                Text.SelectionStart = A
                Text.SelectionLength = B
                Text.SelectionBackColor = Color
                A = Text.Find(SyntaxText, A + B, RichTextBoxFinds.NoHighlight)
            End While
            Text.SelectionStart = C
            Text.SelectionLength = D
            Old_Highligth = E
        End Function
        Public Shared Property RTBHighlightingOne(RTB As RichTextBox, Text As String, Colorf As Color)
            Get
                Dim RTBF As New RichTextBox
                RTBF = RTB
                Dim search As String = Text
                Dim A As Integer = RTBF.SelectionStart
                Dim B As Integer = RTBF.SelectionLength
                Dim index As Integer = RTBF.Text.IndexOf(search)
                If (index <> -1) Then
                    RTBF.Select(index, search.Length)
                    RTBF.SelectionColor = Colorf
                    RTBF.DeselectAll()
                End If
                Return RTBF
            End Get
            Set(value)
                Dim search As String = Text
                Dim A As Integer = RTB.SelectionStart
                Dim B As Integer = RTB.SelectionLength
                Dim index As Integer = RTB.Text.IndexOf(search)
                If (index <> -1) Then
                    RTB.Select(index, search.Length)
                    RTB.SelectionColor = Colorf
                    RTB.DeselectAll()
                End If
            End Set
        End Property
        Public Shared Sub RTBHighligthing(ByVal RichN As RichTextBox, ByVal StrArray() As String, ByVal color As Color, ByVal Seconder As Boolean)
            Dim str As String
            RichN.HideSelection = True
            If RichN.Text.Length > 0 Then
                Dim _select As Integer = RichN.SelectionStart
                If Seconder = False Then
                    RichN.Select(0, RichN.Text.Length)
                    RichN.SelectionColor = color.Black
                    RichN.DeselectAll()
                End If
                For Each str In StrArray
                    Dim Int As Integer = 0
                    Do While RichN.Text.ToUpper.IndexOf(str.ToUpper, Int) >= 0
                        Int = RichN.Text.ToUpper.IndexOf(str.ToUpper, Int)
                        RichN.Select(Int, str.Length)
                        RichN.SelectionColor = color.Blue
                        Int += 1
                    Loop
                Next
                RichN.SelectionStart = _select
            End If
        End Sub

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class
    Public Class E_Mail
        Public Shared Sub SendMail(ByVal SMTPHOST As String, ByVal FromMail As String, ByVal FromPass As String, ByVal ByMail As String, ByVal BySub As String, ByVal ByBody As String)
            Try
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.Credentials = New Net.NetworkCredential(FromMail, FromPass)
                SmtpServer.Port = 587
                SmtpServer.Host = SMTPHOST
                mail = New MailMessage()
                mail.From = New MailAddress(FromMail)
                mail.To.Add(ByMail)
                mail.Subject = BySub
                mail.Body = ByBody
                SmtpServer.Send(mail)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub
    End Class
    Public Class _ART

        Public Sub Gradient2(ByRef sender As Object, ByVal color As Color, ByVal colora As Color, ByVal Propertys As LinearGradientMode)
            Dim g As Graphics = sender.CreateGraphics
            Dim rect As Rectangle = New Rectangle(0, 0, sender.width, sender.Height)
            Dim bruch As New LinearGradientBrush(rect, color, colora, Propertys)
            g.FillRectangle(bruch, rect)
            bruch.SetBlendTriangularShape(0.5F, 1.0F)
            g.FillRectangle(bruch, rect)
        End Sub

        Public Sub ThickPointLineDrawner(ByRef sender As Object, ByVal Thick As Integer, ByVal XYPointG_1 As Point, ByVal XYPointG_2 As Point, ByVal color As Color)
            Dim g As Graphics = sender.CreateGraphics
            g.DrawRectangle(New Pen(color, Thick), _
                                     Thick - 1, Thick - 1, _
                                     sender.Size.Width - Thick, _
                                     sender.Size.Height - Thick)
        End Sub

        Public Sub Gradient3(ByRef sender As Object, ByVal color As Color, ByVal colora As Color, ByVal Propertys As LinearGradientMode)
            Dim g As Graphics = sender.CreateGraphics
            Dim rect As Rectangle = New Rectangle(0, 0, sender.width, sender.Height)
            Dim bruch As LinearGradientBrush = New LinearGradientBrush(rect, color, colora, Propertys)
            g.FillRectangle(bruch, rect)
        End Sub

    End Class
    Public Class _AG

        Public Class _NCharType

            Public Shared Function LShift(ByVal strings As String, ByVal op As Integer, ByVal KeyAdd As Integer)
                Dim aphass(strings.Length - 1) As Int64
                For m_state = 0 To strings.Length - 1
                    'only ascii code
                    If 0 < Convert.ToInt32(strings(m_state)) < 256 Then
                        aphass(m_state) = Convert.ToInt32(strings(m_state))
                    End If
                Next
                For m_aphass = 0 To strings.Length - 1
                    aphass(m_aphass) = aphass(m_aphass) << op
                    aphass(m_aphass) = aphass(m_aphass) Xor KeyAdd
                Next
                Return aphass
            End Function

            Public Shared Function RShift(ByVal strings As String, ByVal op As Integer, ByVal KeyAdd As Integer)
                Dim aphass(strings.Length - 1) As Int64
                For m_state = 0 To strings.Length - 1
                    'only ascii code
                    If 0 < Convert.ToInt32(strings(m_state)) < 256 Then
                        aphass(m_state) = Convert.ToInt32(strings(m_state))
                    End If
                Next
                For m_aphass = 0 To strings.Length - 1
                    aphass(m_aphass) = aphass(m_aphass) Xor KeyAdd
                    aphass(m_aphass) = aphass(m_aphass) >> op
                Next
                Return aphass
            End Function

            Public Shared Function StringEncL(ByVal strings As String, _
                                              Optional ByVal Key As String = "rollrat", _
                                              Optional ByVal op As Integer = 1, _
                                              Optional ByVal TypeKey As Integer = 0)
                Dim Alhass(strings.Length - 1) As Int64
                If TypeKey = 0 Then
                    Alhass = LShift(strings, op, KeyAdder(Key))
                ElseIf TypeKey = 1 Then
                    Alhass = LShift(strings, op, KeyXorer(Key))
                End If
                Dim StringArt(strings.Length - 1) As Char
                For m_soc = 0 To strings.Length - 1
                    StringArt(m_soc) = Convert.ToChar(Alhass(m_soc))
                Next
                Dim F As String = StringArt
                Return F
            End Function

            Public Shared Function StringDecL(ByVal strings As String, _
                                              Optional ByVal Key As String = "rollrat", _
                                              Optional ByVal op As Integer = 1, _
                                              Optional ByVal TypeKey As Integer = 0)
                Dim Alhass(strings.Length - 1) As Int64
                If TypeKey = 0 Then
                    Alhass = RShift(strings, op, KeyAdder(Key))
                ElseIf TypeKey = 1 Then
                    Alhass = RShift(strings, op, KeyXorer(Key))
                End If
                Dim StringArt(strings.Length - 1) As Char
                For m_soc = 0 To strings.Length - 1
                    StringArt(m_soc) = Convert.ToChar(Alhass(m_soc))
                Next
                Dim F As String = StringArt
                Return F
            End Function

            Public Shared Function KeyAdder(ByVal Key As String)
                Dim Keys As Int64
                For m_kadd = 0 To Key.Length - 1
                    Keys += Convert.ToInt32(Key(m_kadd))
                Next
                Return Keys
            End Function

            Public Shared Function KeyXorer(ByVal Key As String)
                Dim Keys As Int64
                For m_kadd = 0 To Key.Length - 1
                    Keys = Keys Xor Convert.ToInt32(Key(m_kadd))
                Next
                Return Keys
            End Function

        End Class

        Public Class _NCharType_A

            ''' <summary>
            ''' 문자열을 2배로 만들고 순서를 섞고 암호화하는 알고리즘입니다.
            ''' </summary>
            Public Shared Function Enc(ByVal str As String, Optional ByVal op As UInteger = 1, Optional ByVal key As String = "rollrat")
                Dim Y As New RichTextBox
                For A = 0 To str.Length / 4
                    Dim f(3) As Char
                    Dim fy(3) As Char
                    For M = 0 To 3
                        f(M) = LSet(str, 4)(M)
                    Next
                    fy(0) = Convert.ToChar(Convert.ToInt32(f(2)) << op)
                    fy(1) = Convert.ToChar(Convert.ToInt32(f(0)) << op)
                    fy(2) = Convert.ToChar(Convert.ToInt32(f(3)) << op)
                    fy(3) = Convert.ToChar(Convert.ToInt32(f(1)) << op)
                    'Y.AppendText(fy)
                    Dim X(3) As Char
                    Dim Alhass(3) As Int64
                    Alhass = _NCharType.LShift(LSet(str, 4), 1, _NCharType.KeyAdder(key))
                    For M = 0 To 3
                        X(M) = Convert.ToChar(Alhass(M))
                    Next
                    Y.AppendText(X)
                    str = Replace(str, LSet(str, 4), "")
                Next
                Return Y.Text
            End Function

            ''' <summary>
            ''' 문자열을 2배로 만들고 순서를 섞고 복호화하는 알고리즘입니다.
            ''' </summary>
            Public Shared Function Dec(ByVal str As String, Optional ByVal op As UInteger = 1, Optional ByVal key As String = "rollrat")
                Dim Y As New RichTextBox
                For A = 0 To str.Length / 8 - 1
                    Dim f(3) As Char
                    Dim fy(3) As Char
                    For M = 0 To 3
                        f(M) = LSet(str, 8)(M)
                    Next
                    fy(0) = Convert.ToChar(Convert.ToInt32(f(1)) >> op)
                    fy(1) = Convert.ToChar(Convert.ToInt32(f(3)) >> op)
                    fy(2) = Convert.ToChar(Convert.ToInt32(f(0)) >> op)
                    fy(3) = Convert.ToChar(Convert.ToInt32(f(2)) >> op)
                    Y.AppendText(fy)
                    str = Replace(str, LSet(str, 8), "")
                Next
                Return Y.Text
            End Function

        End Class

        Public Class CalculateBinary_equation

            Public Shared OnlyEJinSu As Boolean = True

            Public Shared Max_Round_Floating As Integer = &H100

            Public Shared Function NotLogicWithScale(ByVal Binary As String) As String
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

            Public Shared Function CFloat(ByVal floatingpointnumber As Double) As String
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

            Public Shared Function SplitN(ByVal Text, ByVal Op, ByVal Len) As String
                ' 예외, 오류를 처리하기위해 SplitN을 만듬
                On Error Resume Next
                If _NS.GetAllOfThings(Text, Op) = 0 Then
                    Return ""
                End If
                Return Split(Text, Op)(Len)
            End Function

            Public Shared Function SplitNs(ByVal Text, ByVal Op, ByVal Len) As String
                ' 예외, 오류를 처리하기위해 SplitN을 만듬
                On Error Resume Next
                If _NS.GetAllOfThings(Text, Len) = 0 Then
                    Return ""
                End If
                Return Split(Text, Len)(Op)
            End Function

            Public Shared Function Changer(ByVal A As String, ByVal B As String, ByVal C As String, ByVal Length As Integer)
                ' Replace를 그냥 쓰면 않된다는걸 명심하자.
                Dim objX As New System.Text.StringBuilder(A)
                Dim objY As System.Text.StringBuilder
                objY = objX
                objX.Replace(B, C, 0, Length)
                Return objY.ToString
            End Function

            Public Shared Function SolveAll(ByVal Max As Integer, ByVal Texts As String) As String

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

            Public Shared Function SolveParenthesis(ByVal Texts As String) As String

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

            Public Shared Function CAnd(ByVal binarystring1 As String, ByVal binarystring2 As String)
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

            Public Shared Function COr(ByVal binarystring1 As String, ByVal binarystring2 As String)
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

            Public Shared Function CXor(ByVal binarystring1 As String, ByVal binarystring2 As String)
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

            Public Shared Function CNot(ByVal Binary As String) As String
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

            Public Shared Function CBinary(ByVal Decimals As UInt32) As String
                Return Convert.ToString(Decimals, 2)
            End Function

            Public Shared Function CDecimal(ByVal Binary As String) As UInt32
                Return Convert.ToUInt32(Binary, 2)
            End Function

            Public Shared Function CShiftLeft(ByVal Binary As String, ByVal ShiftTime As Integer) As String
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

            Public Shared Function CShiftRight(ByVal Binary As String, ByVal ShiftTime As Integer) As String
                Return Convert.ToString(Convert.ToUInt32(Binary, 2) >> ShiftTime, 2)
            End Function

        End Class

    End Class

#End Region
#Region " Annotations "

    Public Class _R_Message
        Public Const Junk As Integer = &H0
        Public Const None As Integer = &H0
        Public Const Warning As Integer = &H1
        Public Const Kill As Integer = &HFFFF
        Public Const Key As Integer = &HF001
        Public Const Low As Integer = &HF002
        Public Const High As Integer = &HF003
        Public Const Mid As Integer = &HF004
        Public Const Returns As Integer = &HF005
        Public Const Over As Integer = &HF006

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class

    Public Class _R_CO

        Public Const Max As UInteger = &HFFFFFF
        Public Const Min As Integer = &H0
        Public Const AppCommandValueMul As UInteger = &H10000

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class

#End Region

#End Region

#Region " Copyright "

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' '                                                                               ' '
    '   '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''   '
    '   '                                                                           '   '
    '   '    This program was made by rollrat.                                      '   '
    '   '    Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.            '   '
    '   '                                                                           '   '
    '   '    Made for RollRat Software Programs & Lab(R LAB).                       '   '
    '   '                                                                           '   '
    '   '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''   '
    ' '                                                                               ' '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

#End Region

    '******************************************************************************
    ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
    '                         RollRat Software Programs & Lab(R LAB)
    '******************************************************************************
End Class