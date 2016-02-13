﻿Imports System.Runtime.InteropServices
Imports BaseBall.WinApi

Public Class Form1

#Region "Window Behavior"

#Region "Fields"
    Private dwmMargins As Dwm.MARGINS
    Private _marginOk As Boolean
    Private _aeroEnabled As Boolean = False
#End Region
#Region "Ctor"
    Public Sub New()
        SetStyle(ControlStyles.ResizeRedraw, True)

        InitializeComponent()

        DoubleBuffered = True

    End Sub
#End Region
#Region "Props"
    Public ReadOnly Property AeroEnabled() As Boolean
        Get
            Return _aeroEnabled
        End Get
    End Property
#End Region
#Region "Methods"
    Public Shared Function LoWord(ByVal dwValue As Integer) As Integer
        Return dwValue And &HFFFF
    End Function
    ''' <summary>
    ''' Equivalent to the HiWord C Macro
    ''' </summary>
    ''' <param name="dwValue"></param>
    ''' <returns></returns>
    Public Shared Function HiWord(ByVal dwValue As Integer) As Integer
        Return (dwValue >> 16) And &HFFFF
    End Function
#End Region

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dwm.DwmExtendFrameIntoClientArea(Me.Handle, dwmMargins)
    End Sub

    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        Dim WM_NCCALCSIZE As Integer = &H83
        Dim WM_NCHITTEST As Integer = &H84
        Dim result As IntPtr

        Dim dwmHandled As Integer = Dwm.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, result)

        If dwmHandled = 1 Then
            m.Result = result
            Exit Sub
        End If

        If m.Msg = WM_NCCALCSIZE AndAlso CInt(m.WParam) = 1 Then
            Dim nccsp As NCCALCSIZE_PARAMS = _
              DirectCast(Marshal.PtrToStructure(m.LParam, _
              GetType(NCCALCSIZE_PARAMS)), NCCALCSIZE_PARAMS)

            ' Adjust (shrink) the client rectangle to accommodate the border:
            nccsp.rect0.Top += 0
            nccsp.rect0.Bottom += 0
            nccsp.rect0.Left += 0
            nccsp.rect0.Right += 0

            If Not _marginOk Then
                'Set what client area would be for passing to DwmExtendIntoClientArea. Also remember that at least one of these values NEEDS TO BE > 1, else it won't work.
                dwmMargins.cyTopHeight = 0
                dwmMargins.cxLeftWidth = 0
                dwmMargins.cyBottomHeight = 0
                dwmMargins.cxRightWidth = 0
                _marginOk = True
            End If

            Marshal.StructureToPtr(nccsp, m.LParam, False)

            m.Result = IntPtr.Zero
        ElseIf m.Msg = WM_NCHITTEST AndAlso CInt(m.Result) = 0 Then
            m.Result = HitTestNCA(m.HWnd, m.WParam, m.LParam)
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Function HitTestNCA(ByVal hwnd As IntPtr, ByVal wparam _
                                      As IntPtr, ByVal lparam As IntPtr) As IntPtr
        Dim HTNOWHERE As Integer = 0
        Dim HTCLIENT As Integer = 1
        Dim HTCAPTION As Integer = 2
        Dim HTGROWBOX As Integer = 4
        Dim HTSIZE As Integer = HTGROWBOX
        Dim HTMINBUTTON As Integer = 8
        Dim HTMAXBUTTON As Integer = 9
        Dim HTLEFT As Integer = 10
        Dim HTRIGHT As Integer = 11
        Dim HTTOP As Integer = 12
        Dim HTTOPLEFT As Integer = 13
        Dim HTTOPRIGHT As Integer = 14
        Dim HTBOTTOM As Integer = 15
        Dim HTBOTTOMLEFT As Integer = 16
        Dim HTBOTTOMRIGHT As Integer = 17
        Dim HTREDUCE As Integer = HTMINBUTTON
        Dim HTZOOM As Integer = HTMAXBUTTON
        Dim HTSIZEFIRST As Integer = HTLEFT
        Dim HTSIZELAST As Integer = HTBOTTOMRIGHT

        Dim p As New Point(LoWord(CInt(lparam)), HiWord(CInt(lparam)))

        Dim topleft As Rectangle = RectangleToScreen(New Rectangle(0, 0, _
                                   dwmMargins.cxLeftWidth, dwmMargins.cxLeftWidth))

        If topleft.Contains(p) Then
            Return New IntPtr(HTTOPLEFT)
        End If

        Dim topright As Rectangle = _
          RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, 0, _
          dwmMargins.cxRightWidth, dwmMargins.cxRightWidth))

        If topright.Contains(p) Then
            Return New IntPtr(HTTOPRIGHT)
        End If

        Dim botleft As Rectangle = _
           RectangleToScreen(New Rectangle(0, Height - dwmMargins.cyBottomHeight, _
           dwmMargins.cxLeftWidth, dwmMargins.cyBottomHeight))

        If botleft.Contains(p) Then
            Return New IntPtr(HTBOTTOMLEFT)
        End If

        Dim botright As Rectangle = _
            RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, _
            Height - dwmMargins.cyBottomHeight, _
            dwmMargins.cxRightWidth, dwmMargins.cyBottomHeight))

        If botright.Contains(p) Then
            Return New IntPtr(HTBOTTOMRIGHT)
        End If

        Dim top As Rectangle = _
            RectangleToScreen(New Rectangle(0, 0, Width, dwmMargins.cxLeftWidth))

        If top.Contains(p) Then
            Return New IntPtr(HTTOP)
        End If

        Dim cap As Rectangle = _
            RectangleToScreen(New Rectangle(0, dwmMargins.cxLeftWidth, _
            Width, dwmMargins.cyTopHeight - dwmMargins.cxLeftWidth))

        If cap.Contains(p) Then
            Return New IntPtr(HTCAPTION)
        End If

        Dim left As Rectangle = _
            RectangleToScreen(New Rectangle(0, 0, dwmMargins.cxLeftWidth, Height))

        If left.Contains(p) Then
            Return New IntPtr(HTLEFT)
        End If

        Dim right As Rectangle = _
            RectangleToScreen(New Rectangle(Width - dwmMargins.cxRightWidth, _
            0, dwmMargins.cxRightWidth, Height))

        If right.Contains(p) Then
            Return New IntPtr(HTRIGHT)
        End If

        Dim bottom As Rectangle = _
            RectangleToScreen(New Rectangle(0, Height - dwmMargins.cyBottomHeight, _
            Width, dwmMargins.cyBottomHeight))

        If bottom.Contains(p) Then
            Return New IntPtr(HTBOTTOM)
        End If

        Return New IntPtr(HTCLIENT)
    End Function

    Private Const BorderWidth As Integer = 6

    Private _resizeDir As ResizeDirection = ResizeDirection.None

    Private Sub Form1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If Me.Width - BorderWidth > e.Location.X AndAlso e.Location.X > BorderWidth AndAlso e.Location.Y > BorderWidth Then
                MoveControl(Me.Handle)
            Else
                If Me.WindowState <> FormWindowState.Maximized Then
                    'ResizeForm(resizeDir)
                End If
            End If
        End If
    End Sub

    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 4
        TopRight = 8
        Right = 16
        BottomRight = 32
        Bottom = 64
        BottomLeft = 128
    End Enum

    'Private Property resizeDir() As ResizeDirection
    '    Get
    '        Return _resizeDir
    '    End Get
    '    Set(ByVal value As ResizeDirection)
    '        _resizeDir = value

    '        'Change cursor
    '        Select Case value
    '            Case ResizeDirection.Left
    '                Me.Cursor = Cursors.SizeWE

    '            Case ResizeDirection.Right
    '                Me.Cursor = Cursors.SizeWE

    '            Case ResizeDirection.Top
    '                Me.Cursor = Cursors.SizeNS

    '            Case ResizeDirection.Bottom
    '                Me.Cursor = Cursors.SizeNS

    '            Case ResizeDirection.BottomLeft
    '                Me.Cursor = Cursors.SizeNESW

    '            Case ResizeDirection.TopRight
    '                Me.Cursor = Cursors.SizeNESW

    '            Case ResizeDirection.BottomRight
    '                Me.Cursor = Cursors.SizeNWSE

    '            Case ResizeDirection.TopLeft
    '                Me.Cursor = Cursors.SizeNWSE

    '            Case Else
    '                Me.Cursor = Cursors.Default
    '        End Select
    '    End Set
    'End Property

    'Private Sub Form1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
    '    'Calculate which direction to resize based on mouse position

    '    If e.Location.X < BorderWidth And e.Location.Y < BorderWidth Then
    '        resizeDir = ResizeDirection.TopLeft

    '    ElseIf e.Location.X < BorderWidth And e.Location.Y > Me.Height - BorderWidth Then
    '        resizeDir = ResizeDirection.BottomLeft

    '    ElseIf e.Location.X > Me.Width - BorderWidth And e.Location.Y > Me.Height - BorderWidth Then
    '        resizeDir = ResizeDirection.BottomRight

    '    ElseIf e.Location.X > Me.Width - BorderWidth And e.Location.Y < BorderWidth Then
    '        resizeDir = ResizeDirection.TopRight

    '    ElseIf e.Location.X < BorderWidth Then
    '        resizeDir = ResizeDirection.Left

    '    ElseIf e.Location.X > Me.Width - BorderWidth Then
    '        resizeDir = ResizeDirection.Right

    '    ElseIf e.Location.Y < BorderWidth Then
    '        resizeDir = ResizeDirection.Top

    '    ElseIf e.Location.Y > Me.Height - BorderWidth Then
    '        resizeDir = ResizeDirection.Bottom

    '    Else
    '        resizeDir = ResizeDirection.None
    '    End If
    'End Sub

    Private Sub MoveControl(ByVal hWnd As IntPtr)
        ReleaseCapture()
        SendMessage(hWnd, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub

    'Private Sub ResizeForm(ByVal direction As ResizeDirection)
    '    Dim dir As Integer = -1
    '    Select Case direction
    '        Case ResizeDirection.Left
    '            dir = HTLEFT
    '        Case ResizeDirection.TopLeft
    '            dir = HTTOPLEFT
    '        Case ResizeDirection.Top
    '            dir = HTTOP
    '        Case ResizeDirection.TopRight
    '            dir = HTTOPRIGHT
    '        Case ResizeDirection.Right
    '            dir = HTRIGHT
    '        Case ResizeDirection.BottomRight
    '            dir = HTBOTTOMRIGHT
    '        Case ResizeDirection.Bottom
    '            dir = HTBOTTOM
    '        Case ResizeDirection.BottomLeft
    '            dir = HTBOTTOMLEFT
    '    End Select

    '    If dir <> -1 Then
    '        ReleaseCapture()
    '        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, dir, 0)
    '    End If

    'End Sub

    <DllImport("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14
#End Region

    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Location = Me.Location
    '    shWidth = Me.Width
    '    shHeight = Me.Height
    '    shColor = Color.Black
    '    CreateShadow()
    'End Sub


    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const DROPSHADOW = &H20000
            Dim cParam As CreateParams = MyBase.CreateParams
            cParam.ClassStyle = cParam.ClassStyle Or DROPSHADOW
            Return cParam
        End Get
    End Property

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Dim x As Single = 110.0F
        'Dim y As Single = 120.0F
        'Dim strText As String = "숫자 야구"
        'Dim drawFont As Font = New Font("맑은 고딕", 24, FontStyle.Bold)
        'Dim drawBrush As SolidBrush = New SolidBrush(Color.DodgerBlue)
        'Dim drawShadow As SolidBrush = New SolidBrush(Color.DimGray)
        'Dim drawFormat As StringFormat = New StringFormat()
        'e.Graphics.DrawString(strText, drawFont, drawShadow, x + 3, y + 3, drawFormat)
        'e.Graphics.DrawString(strText, drawFont, drawBrush, x, y, drawFormat)

        e.Graphics.DrawLine(Pens.Gray, New Point(0, 50), New Point(Me.Width, 50))

    End Sub

    ' ''######################
    ''this is a class form
    ''just create a new empty form named frmShadow and insert the code below

    'Private m_width As Integer = 0
    'Private m_Height As Integer = 0
    'Private m_color As System.Drawing.Color

    'Public Property shWidth() As Integer
    '    Get
    '        Return m_width
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_width = value + 5
    '        Me.Width = m_width
    '    End Set
    'End Property

    'Public Property shHeight() As Integer
    '    Get
    '        Return m_Height
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_Height = value + 5
    '        Me.Height = m_Height
    '    End Set
    'End Property

    'Public Property shColor() As System.Drawing.Color
    '    Get
    '        Return m_color
    '    End Get
    '    Set(ByVal value As System.Drawing.Color)
    '        m_color = value
    '        Me.BackColor = value
    '    End Set
    'End Property

    'Public Sub CreateShadow()
    '    Dim reg As New Region(New Rectangle(0, 0, m_width, m_Height))
    '    Dim oPath As New System.Drawing.Drawing2D.GraphicsPath
    '    Dim olPath As New System.Drawing.Drawing2D.GraphicsPath
    '    Dim obPath As New System.Drawing.Drawing2D.GraphicsPath
    '    Dim otPath As New System.Drawing.Drawing2D.GraphicsPath
    '    Dim shpath() As Point = {New Point(m_width - 5, 5), New Point(m_width, 10), New Point(m_width, m_Height - 5), New Point(m_width - 5, m_Height), New Point(10, m_Height), New Point(5, m_Height - 5), New Point(m_width - 5, m_Height - 5)}

    '    oPath.AddLines(shpath)
    '    reg.Intersect(oPath)

    '    olPath.AddArc(3, Me.Height - 7, 8, 7, 45, 180)
    '    reg.Union(olPath)

    '    obPath.AddArc(m_width - 7, m_Height - 7, 7, 7, 315, 180)
    '    reg.Union(obPath)

    '    otPath.AddArc(m_width - 7, 3, 7, 8, 225, 180)
    '    reg.Union(otPath)

    '    Me.Region = reg
    '    Me.Show()
    'End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserControl11.strike.SetNumber(0)
        UserControl11.ball.SetNumber(0)
    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)

    '    Application.DoEvents()
    '    For appear As Integer = 0 To 929
    '        'Button1.Opacity = (Math.Abs(appear - 80) / 100)
    '        Button1.Location = New Point(1074 - Math.Sqrt(appear * 100), Button1.Location.Y)
    '        Application.DoEvents()
    '        Threading.Thread.Sleep(0)
    '    Next
    'End Sub

    Private Sub ElementHost1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles ElementHost1.ChildChanged

    End Sub
End Class