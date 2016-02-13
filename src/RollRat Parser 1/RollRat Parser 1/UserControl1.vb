Imports System.Text.RegularExpressions

Public Class SyntaxRichTextBox
    Inherits System.Windows.Forms.RichTextBox
    Private m_settings As New SyntaxSettings()
    Private Shared m_bPaint As Boolean = True
    Private m_strLine As String = ""
    Private m_nContentLength As Integer = 0
    Private m_nLineLength As Integer = 0
    Private m_nLineStart As Integer = 0
    Private m_nLineEnd As Integer = 0
    Private m_strKeywords As String = ""
    Private m_nCurSelection As Integer = 0

    Public ReadOnly Property Settings() As SyntaxSettings
        Get
            Return m_settings
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        BackColor = Color.Black
        ForeColor = Color.White
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

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        m_nContentLength = Me.TextLength

        Dim nCurrentSelectionStart As Integer = SelectionStart
        Dim nCurrentSelectionLength As Integer = SelectionLength

        m_bPaint = False

        m_nLineStart = nCurrentSelectionStart
        While (m_nLineStart > 0) AndAlso (Text(m_nLineStart - 1) <> ControlChars.Lf)
            m_nLineStart -= 1
        End While
        m_nLineEnd = nCurrentSelectionStart
        While (m_nLineEnd < Text.Length) AndAlso (Text(m_nLineEnd) <> ControlChars.Lf)
            m_nLineEnd += 1
        End While
        m_nLineLength = m_nLineEnd - m_nLineStart
        m_strLine = Text.Substring(m_nLineStart, m_nLineLength)

        ProcessLine()

        m_bPaint = True
    End Sub

    Private Sub ProcessLine()
        Dim nPosition As Integer = SelectionStart
        SelectionStart = m_nLineStart
        SelectionLength = m_nLineLength
        SelectionColor = Color.Black

        ProcessRegex(m_strKeywords, Settings.KeywordColor)
        ProcessRegex("\b(?:[0-9]*\.)?[0-9]+\b", Settings.IntegerColor)
        ProcessRegex("""[^""\\\r\n]*(?:\\.[^""\\\r\n]*)*""", Settings.StringColor)
        ProcessRegex("<[^""\\\r\n]*(?:\\.[^""\\\r\n]*)*>", Settings.StringColor)
        ProcessRegex(Settings.Comment & ".*$", Settings.CommentColor)
        ProcessRegexs("/\*(\n|[^*]|\*+[^*/])*\**\*/", Settings.CommentColor)
        SelectionStart = nPosition
        SelectionLength = 0
        SelectionColor = Color.Black

        m_nCurSelection = nPosition
    End Sub

    Private Sub ProcessRegex(strRegex As String, color As Color)
        Dim regKeywords As New Regex(strRegex, RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        Dim regMatch As Match
        regMatch = regKeywords.Match(m_strLine)
        While regMatch.Success
            Dim nStart As Integer = m_nLineStart + regMatch.Index
            Dim nLenght As Integer = regMatch.Length
            SelectionStart = nStart
            SelectionLength = nLenght
            SelectionColor = color
            regMatch = regMatch.NextMatch()
        End While
    End Sub

    Private Sub ProcessRegexs(strRegex As String, color As Color)
        Dim regKeywords As New Regex(strRegex, RegexOptions.IgnoreCase Or RegexOptions.Compiled)
        Dim regMatch As Match
        regMatch = regKeywords.Match(Text)
        While regMatch.Success
            'Dim nStart As Integer = m_nLineStart + regMatch.Index
            Dim nLenght As Integer = regMatch.Length
            SelectionStart = 0
            SelectionLength = nLenght
            SelectionColor = color
            regMatch = regMatch.NextMatch()
        End While
    End Sub

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
    Private m_strComment As String = ""
    Private m_colorComment As Color = Color.Green
    Private m_colorString As Color = Color.Gray
    Private m_colorInteger As Color = Color.Red
    Private m_bEnableComments As Boolean = True
    Private m_bEnableIntegers As Boolean = True
    Private m_bEnableStrings As Boolean = True

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
End Class
