Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports System.Drawing.Graphics
Imports System.Runtime.InteropServices

Namespace SyntaxHighlighter

    '<ClassInterfaceAttribute(ClassInterfaceType.AutoDispatch)> _
    '<ComVisibleAttribute(True)> _
    '<DockingAttribute(DockingBehavior.Ask)> _
    Public Class SyntaxRichTextBox
        Inherits System.Windows.Forms.RichTextBox
        Private Shared m_settings As New SyntaxSettings()
        Public Shared F As Font
        Private Shared m_bPaint As Boolean = True
        Private m_strLine As String = ""
        Private m_nContentLength As Integer = 0
        Private m_nLineLength As Integer = 0
        Private m_nLineStart As Integer = 0
        Private m_nLineEnd As Integer = 0
        Private m_strKeywords As String = ""
        Private m_fstrKeywords As String = ""
        Private m_dstrKeywords As String = ""
        Private m_ystrKeywords As String = ""
        Private m_nCurSelection As Integer = 0
        Public Shared Upper As String(,)

        Public Shared Sub FindAndChange(ByVal RichN As SyntaxRichTextBox, ByVal TextA() As String, ByVal TextB As String)
            Dim str As String
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
        End Sub

        ''' <summary>
        ''' The settings.
        ''' </summary>
        Public ReadOnly Property Settings() As SyntaxSettings
            Get
                Return m_settings
            End Get
        End Property

        ''' <summary>
        ''' WndProc
        ''' </summary>
        ''' <param name="m"></param>
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            If m.Msg = &HF Then
                If m_bPaint Then
                    MyBase.WndProc(m)
                Else
                    m.Result = IntPtr.Zero
                End If
            Else
                MyBase.WndProc(m)
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim A1 As Point
            A1.X = 2
            A1.Y = 2
            Dim A2 As Point
            A2.X = 100
            A2.Y = 100
            Dim B As Rectangle
            B.X = 2
            B.Y = 200
            e.Graphics.DrawRectangle(Pens.Blue, B)
        End Sub

        ''' <summary>
        ''' OnTextChanged
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overrides Sub OnTextChanged(e As EventArgs)
            'Me.Font = F

            'FindAndChange(Me, New String(1) {"private", "pRivate"}, "Private")
            ' Calculate shit here.
            m_nContentLength = Me.TextLength

            Dim nCurrentSelectionStart As Integer = SelectionStart
            Dim nCurrentSelectionLength As Integer = SelectionLength

            m_bPaint = False

            ' Find the start of the current line.
            m_nLineStart = nCurrentSelectionStart
            While (m_nLineStart > 0) AndAlso (Text(m_nLineStart - 1) <> ControlChars.Lf)
                m_nLineStart -= 1
            End While
            ' Find the end of the current line.
            m_nLineEnd = nCurrentSelectionStart
            While (m_nLineEnd < Text.Length) AndAlso (Text(m_nLineEnd) <> ControlChars.Lf)
                m_nLineEnd += 1
            End While
            ' Calculate the length of the line.
            m_nLineLength = m_nLineEnd - m_nLineStart
            ' Get the current line.
            m_strLine = Text.Substring(m_nLineStart, m_nLineLength)

            ' Process this line.
            ProcessLine()

            m_bPaint = True
        End Sub

        Private Sub ProcessLine()
            Dim NFont As Font = Me.Font
            Dim nPosition As Integer = SelectionStart
            SelectionStart = m_nLineStart
            SelectionLength = m_nLineLength
            SelectionColor = Color.Black
            ProcessRegex(m_strKeywords, Settings.KeywordColor)
            If Settings.EnableIntegers Then
                ProcessRegex("\b(?:[0-9]*\.)?[0-9]+\b", Settings.IntegerColor)
            End If
            If Settings.EnableStrings Then
                ProcessRegex("""[^""\\\r\n]*(?:\\.[^""\\\r\n]*)*""", Settings.StringColor)
            End If
            If Settings.EnableComments AndAlso Not String.IsNullOrEmpty(Settings.Comment) Then
                ProcessRegex(Settings.Comment & ".*$", Settings.CommentColor)
            End If
            ProcessRegex(m_fstrKeywords, Settings.fKeywordColor)
            ProcessRegex(m_dstrKeywords, Settings.dKeywordColor)
            SelectionStart = nPosition
            SelectionLength = 0
            SelectionColor = Color.Black
            SelectionFont = NFont
            m_nCurSelection = nPosition
        End Sub

        ''' <summary>
        ''' Process a regular expression.
        ''' </summary>
        ''' <param name="strRegex">The regular expression.</param>
        ''' <param name="color">The color.</param>
        Private Sub ProcessRegex(strRegex As String, color As Color)
            Dim regKeywords As New Regex(strRegex, RegexOptions.IgnoreCase Or RegexOptions.Compiled)
            Dim regMatch As Match
            regMatch = regKeywords.Match(m_strLine)
            While regMatch.Success
                ' Process the words
                Dim nStart As Integer = m_nLineStart + regMatch.Index
                Dim nLenght As Integer = regMatch.Length
                SelectionStart = nStart
                SelectionLength = nLenght
                SelectionFont = F
                SelectionColor = color
                For A = 0 To Upper.Length / 2 - 1
                    If SelectedText = Upper(A, 0) Then
                        SelectedText = Upper(A, 1)
                    End If
                Next
                regMatch = regMatch.NextMatch()
            End While
        End Sub

        ''' <summary>
        ''' Compiles the keywords as a regular expression.
        ''' </summary>
        Public Sub CompileKeywords()
            For i As Integer = 0 To Settings.Keywords.Count - 1
                Dim strKeyword As String = Settings.Keywords(i)

                If i = Settings.Keywords.Count - 1 Then
                    m_strKeywords += "\b" & strKeyword & "\b"
                Else
                    m_strKeywords += "\b" & strKeyword & "\b|"
                End If
            Next
        End Sub

        Public Sub CompileKeyGreen()
            For i As Integer = 0 To Settings.fKeywords.Count - 1
                Dim strKeyword As String = Settings.fKeywords(i)

                If i = Settings.fKeywords.Count - 1 Then
                    m_fstrKeywords += "\b" & strKeyword & "\b"
                Else
                    m_fstrKeywords += "\b" & strKeyword & "\b|"
                End If
            Next
        End Sub

        Public Sub CompileKeyS()
            For i As Integer = 0 To Settings.dKeywords.Count - 1
                Dim strKeyword As String = Settings.dKeywords(i)

                If i = Settings.dKeywords.Count - 1 Then
                    m_dstrKeywords += "\b" & strKeyword & "\b"
                Else
                    m_dstrKeywords += "\b" & strKeyword & "\b|"
                End If
            Next
        End Sub

        Public Sub ProcessAllLines()
            m_bPaint = False

            Dim nStartPos As Integer = 0
            Dim i As Integer = 0
            Dim nOriginalPos As Integer = SelectionStart
            While i < Lines.Length
                m_strLine = Lines(i)
                m_nLineStart = nStartPos
                m_nLineEnd = m_nLineStart + m_strLine.Length

                ProcessLine()
                i += 1

                nStartPos += m_strLine.Length + 1
            End While

            m_bPaint = True
        End Sub

    End Class

    Public Class SyntaxList
        Public m_rgList As New List(Of String)()
        Public m_color As New Color()
    End Class

    Public Class SyntaxSettings
        Private m_rgKeywords As New SyntaxList()
        Private m_frgKeywords As New SyntaxList()
        Private m_drgKeywords As New SyntaxList()
        Private m_strComment As String = ""
        Private m_colorComment As Color = Color.Green
        Private m_colorString As Color = Color.Gray
        Private m_colorInteger As Color = Color.Red
        Private m_bEnableComments As Boolean = True
        Private m_bEnableIntegers As Boolean = True
        Private m_bEnableStrings As Boolean = True

#Region "Properties"
        Public ReadOnly Property Keywords() As List(Of String)
            Get
                Return m_rgKeywords.m_rgList
            End Get
        End Property
        Public Property KeywordColor() As Color
            Get
                Return m_rgKeywords.m_color
            End Get
            Set(value As Color)
                m_rgKeywords.m_color = value
            End Set
        End Property
        Public ReadOnly Property fKeywords() As List(Of String)
            Get
                Return m_frgKeywords.m_rgList
            End Get
        End Property
        Public Property fKeywordColor() As Color
            Get
                Return m_frgKeywords.m_color
            End Get
            Set(value As Color)
                m_frgKeywords.m_color = value
            End Set
        End Property
        Public ReadOnly Property dKeywords() As List(Of String)
            Get
                Return m_drgKeywords.m_rgList
            End Get
        End Property
        Public Property dKeywordColor() As Color
            Get
                Return m_drgKeywords.m_color
            End Get
            Set(value As Color)
                m_drgKeywords.m_color = value
            End Set
        End Property
        Public Property Comment() As String
            Get
                Return m_strComment
            End Get
            Set(value As String)
                m_strComment = value
            End Set
        End Property
        Public Property CommentColor() As Color
            Get
                Return m_colorComment
            End Get
            Set(value As Color)
                m_colorComment = value
            End Set
        End Property
        Public Property EnableComments() As Boolean
            Get
                Return m_bEnableComments
            End Get
            Set(value As Boolean)
                m_bEnableComments = value
            End Set
        End Property
        Public Property EnableIntegers() As Boolean
            Get
                Return m_bEnableIntegers
            End Get
            Set(value As Boolean)
                m_bEnableIntegers = value
            End Set
        End Property
        Public Property EnableStrings() As Boolean
            Get
                Return m_bEnableStrings
            End Get
            Set(value As Boolean)
                m_bEnableStrings = value
            End Set
        End Property
        Public Property StringColor() As Color
            Get
                Return m_colorString
            End Get
            Set(value As Color)
                m_colorString = value
            End Set
        End Property
        Public Property IntegerColor() As Color
            Get
                Return m_colorInteger
            End Get
            Set(value As Color)
                m_colorInteger = value
            End Set
        End Property
#End Region
    End Class

End Namespace
