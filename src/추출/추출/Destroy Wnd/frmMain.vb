Imports System.Runtime.InteropServices
Imports System.Text
Imports 추출.RollRat_Vb_Api
Imports 추출.RollRat_Vb_Api.WinApi

Public Class frmMain

    Private WithEvents mHook As New MouseHook

    Dim TyS As IntPtr
    Dim TY As Boolean = False
    Dim TYf As Boolean = False
    Dim Yk As Boolean = False
    Dim YkT As Boolean = False
    Dim SetWP As Boolean = False
    Dim SetWPf As Boolean = False
    Dim ShownSpy As Boolean = False

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function GetParent(ByVal hWnd As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function GetClientRect(ByVal hWnd As System.IntPtr, ByRef lpRECT As Rectangle) As Integer
    End Function
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function
    Private Declare Function GetNextWindow Lib "user32" Alias "GetWindow" (ByVal hwnd As IntPtr, ByVal wFlag As Integer) As IntPtr
    Private Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Integer
    <DllImport("user32.dll")> _
    Private Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    Private Structure WINDOWPLACEMENT
        Public Length As Integer
        Public flags As Integer
        Public showCmd As Integer
        Public ptMinPosition As Point
        Public ptMaxPosition As Point
        Public rcNormalPosition As Rectangle
    End Structure

    Public Enum WNDSTATE
        SW_HIDE = 0
        SW_SHOWNORMAL = 1
        SW_NORMAL = 1
        SW_SHOWMINIMIZED = 2
        SW_MAXIMIZE = 3
        SW_SHOWNOACTIVATE = 4
        SW_SHOW = 5
        SW_MINIMIZE = 6
        SW_SHOWMINNOACTIVE = 7
        SW_SHOWNA = 8
        SW_RESTORE = 9
        SW_SHOWDEFAULT = 10
        SW_MAX = 10
    End Enum

    Private Const GW_HWNDNEXT = 2
    Private Const GW_HWNDPREV = 3

    Public Sub GetWindowPos(ByVal hwnd As Integer, ByRef ptrPhwnd As Integer, ByRef ptrNhwnd As Integer, ByRef ptPoint As Point, ByRef szSize As Size, ByRef intShowCmd As WNDSTATE)
        Dim wInf As WINDOWPLACEMENT
        wInf.Length = System.Runtime.InteropServices.Marshal.SizeOf(wInf)
        GetWindowPlacement(hwnd, wInf)
        szSize = New Size(wInf.rcNormalPosition.Right - (wInf.rcNormalPosition.Left * 2), wInf.rcNormalPosition.Bottom - (wInf.rcNormalPosition.Top * 2))
        ptPoint = New Point(wInf.rcNormalPosition.Left, wInf.rcNormalPosition.Top)
        ptrPhwnd = GetNextWindow(hwnd, GW_HWNDPREV)
        ptrNhwnd = GetNextWindow(hwnd, GW_HWNDNEXT)
        intShowCmd = wInf.showCmd
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'For more information : http://cafe.naver.com/gogoomas/229681
        WinApi.RegisterHotKey(Me.Handle, 1020, 0, Convert.ToUInt32(Keys.F10))
        WinApi.RegisterHotKey(Me.Handle, 1040, 0, Convert.ToUInt32(Keys.F11))
        WinApi.RegisterHotKey(Me.Handle, 1060, 0, Convert.ToUInt32(Keys.F9))
        WinApi.RegisterHotKey(Me.Handle, 1080, 0, Convert.ToUInt32(Keys.F8))
        WinApi.RegisterHotKey(Me.Handle, 1100, 0, Convert.ToUInt32(Keys.F7))
        WinApi.RegisterHotKey(Me.Handle, 1110, 0, Convert.ToUInt32(Keys.F6))
        WinApi.RegisterHotKey(Me.Handle, 1140, 0, Convert.ToUInt32(Keys.F5))

    End Sub

    Protected Overloads Overrides Sub WndProc(ByRef e As Message)

        MyBase.WndProc(e)
        Dim Id As Integer = e.WParam.ToInt32()
        Select Case Id
            Case 1020
                Timer1.Enabled = True
                Exit Select
            Case 1040
                Timer2.Enabled = True
                Exit Select
            Case 1060
                Timer3.Enabled = True
                Exit Select
            Case 1080
                TY = True
                Exit Select
            Case 1080
                TY = True
                Exit Select
            Case 1100
                Yk = True
                Exit Select
            Case 1110
                YkT = True
                Exit Select
            Case 1140
                SetWP = True
                Exit Select
        End Select

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        WinApi.UnregisterHotKey(Me.Handle, 1020)
        WinApi.UnregisterHotKey(Me.Handle, 1040)
        WinApi.UnregisterHotKey(Me.Handle, 1060)
        WinApi.UnregisterHotKey(Me.Handle, 1080)
        WinApi.UnregisterHotKey(Me.Handle, 1100)
        WinApi.UnregisterHotKey(Me.Handle, 1110)
        WinApi.UnregisterHotKey(Me.Handle, 1140)

    End Sub

    Private Sub mHook_Mouse_Left_Down(ptLocat As Point) Handles mHook.Mouse_Left_Down
        If ShownSpy = True Then Exit Sub
        If Yk = True Then
            Yk = False
            WinApi.Sleep(2000)
            Yk = True
            TyS_1()
            Exit Sub
        End If
        If YkT = True Then
            YkT = False
            TyS_1()
            Exit Sub
        End If
        If SetWP = True Then
            SetWP = False
            Swp_1()
            Exit Sub
        End If

    End Sub

    Private Sub MouseHook_Mouse_Right_Up(ptLocat As Point) Handles mHook.Mouse_Left_Up
        If ShownSpy = True Then Exit Sub
        If Timer1.Enabled = True Then
            Timer1.Enabled = False
            CurDestroyWnd()
            Exit Sub
        End If
        If Timer2.Enabled = True Then
            Timer2.Enabled = False
            Inheritance()
            Exit Sub
        End If
        If Timer3.Enabled = True Then
            Timer3.Enabled = False
            Dis_Inheritance()
            Exit Sub
        End If
        If Yk = True Then
            Yk = False
            TyS_2()
            Exit Sub
        End If
        If TY = True Then
            TY = False
            TyS_1()
            Exit Sub
        Else
            If TYf = True Then
                TYf = False
                TyS_2()
                Exit Sub
            End If
        End If
        If SetWPf = True Then
            SetWPf = False
            Exit Sub
        End If
        If Nfs = True Then
            Nfs = False
            Exit Sub
        End If

    End Sub

    Dim Nf As Rectangle
    Dim Nfs As Boolean = False
    Dim FS As IntPtr

    Private Sub mHook_Mouse_Move(ptLocat As Point) Handles mHook.Mouse_Move
        If ShownSpy = True Then Exit Sub
        Dim Point As Point
        Dim R As Rectangle
        WinApi.GetCursorPos(Point)
        GetWindowRect(WinApi.WindowFromPoint(Point), R)
        If SetWPf = True Then
            If Nfs = False Then
                Nfs = True
                FS = WinApi.WindowFromPoint(Point)
            End If
            GetWindowRect(FS, Nf)
            Dim hwnd As Integer = WinApi.WindowFromPoint(Point)
            Dim ptrPhwnd, ptrNhwnd As Integer
            Dim ptPoint As Point
            Dim szSize As Size
            Dim intShowCmd As WNDSTATE
            GetWindowPos(hwnd, ptrPhwnd, ptrNhwnd, ptPoint, szSize, intShowCmd)
            'SetWindowPos(TyS, vbNullString, Point.X - ptPoint.X, Point.Y - ptPoint.Y, 0, 0, WinApiUsr.SWP_NOSIZE Or WinApiUsr.SWP_NOZORDER)
            'SetWindowPos(TyS, vbNullString, Point.X - Nf.Left, Point.Y - Nf.Width, 0, 0, WinApiUsr.SWP_NOSIZE Or WinApiUsr.SWP_NOZORDER)
            SetWindowPos(TyS, vbNullString, Point.X - Nf.X, Point.Y - Nf.Y, 0, 0, WinApiUsr.SWP_NOSIZE Or WinApiUsr.SWP_NOZORDER)
        End If
        Label12.Text = GetWndText(WinApi.WindowFromPoint(Point))
        Label13.Text = GetClsName(WinApi.WindowFromPoint(Point))
        Label2.Text = WinApi.WindowFromPoint(Point)
        Label6.Text = " Left : " & R.Left & " Right : " & R.Right & vbCrLf & "Width : " & R.Width & " Height : " & R.Height
        GetClientRect(WinApi.WindowFromPoint(Point), R)
        Label7.Text = " Left : " & R.Left & " Right : " & R.Right & vbCrLf & "Width : " & R.Width & " Height : " & R.Height
        Label9.Text = GetParent(WinApi.WindowFromPoint(Point))
    End Sub
    
    Private Function GetWndText(ByVal hWnd As IntPtr)
        Debug.Assert(hWnd <> IntPtr.Zero)
        Dim Str As StringBuilder = New StringBuilder(GetWindowTextLength(hWnd) + 1)
        GetWindowText(hWnd, Str, Str.Capacity)
        Return Str.ToString
    End Function

    Private Function GetClsName(ByVal hWnd As IntPtr)
        Debug.Assert(hWnd <> IntPtr.Zero)
        Dim Str As StringBuilder = New StringBuilder(256)
        GetClassName(hWnd, Str, Str.Capacity)
        Return Str.ToString
    End Function

    Private Sub Swp_1()

        Dim Point As Point
        WinApi.GetCursorPos(Point)
        TyS = WinApi.WindowFromPoint(Point)
        SetWPf = True

    End Sub

    Private Sub TyS_1()

        Dim Point As Point
        WinApi.GetCursorPos(Point)
        TyS = WinApi.WindowFromPoint(Point)
        TYf = True

    End Sub

    Private Sub TyS_2()

        Dim Point As Point
        WinApi.GetCursorPos(Point)
        SetParent(TyS, WinApi.WindowFromPoint(Point))

    End Sub

    Private Sub Inheritance()

        Dim Point As Point
        WinApi.GetCursorPos(Point)
        SetParent(Me.Handle, WinApi.WindowFromPoint(Point))

    End Sub

    Private Sub Dis_Inheritance()

        Dim Point As Point
        WinApi.GetCursorPos(Point)
        'SetParent(GetParent(WinApi.WindowFromPoint(Point)), Me.Handle)
        SetParent(WinApi.WindowFromPoint(Point), Me.Handle)

    End Sub

    Private Sub CurDestroyWnd()

        Dim Point As Point
        WinApi.GetCursorPos(Point)

        _PE.MessageSend(WinApi.WindowFromPoint(Point), WinApiUsr.WM_DESTROY)

    End Sub

    Private WithEvents Spy As New frmSpy

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Spy = New frmSpy
        Spy.Show()
    End Sub

    Private Sub Spy_MeChoose(pt As Point) Handles Spy.MeChoose
        Dim Point As Point = pt
        Dim R As Rectangle
        GetWindowRect(WinApi.WindowFromPoint(Point), R)
        If SetWPf = True Then
            If Nfs = False Then
                Nfs = True
                FS = WinApi.WindowFromPoint(Point)
            End If
            GetWindowRect(FS, Nf)
            Dim hwnd As Integer = WinApi.WindowFromPoint(Point)
            Dim ptrPhwnd, ptrNhwnd As Integer
            Dim ptPoint As Point
            Dim szSize As Size
            Dim intShowCmd As WNDSTATE
            GetWindowPos(hwnd, ptrPhwnd, ptrNhwnd, ptPoint, szSize, intShowCmd)
            'SetWindowPos(TyS, vbNullString, Point.X - ptPoint.X, Point.Y - ptPoint.Y, 0, 0, WinApiUsr.SWP_NOSIZE Or WinApiUsr.SWP_NOZORDER)
            'SetWindowPos(TyS, vbNullString, Point.X - Nf.Left, Point.Y - Nf.Width, 0, 0, WinApiUsr.SWP_NOSIZE Or WinApiUsr.SWP_NOZORDER)
            SetWindowPos(TyS, vbNullString, Point.X - Nf.X, Point.Y - Nf.Y, 0, 0, WinApiUsr.SWP_NOSIZE Or WinApiUsr.SWP_NOZORDER)
        End If
        Label12.Text = GetWndText(WinApi.WindowFromPoint(Point))
        Label13.Text = GetClsName(WinApi.WindowFromPoint(Point))
        Label2.Text = WinApi.WindowFromPoint(Point)
        Label6.Text = " Left : " & R.Left & " Right : " & R.Right & vbCrLf & "Width : " & R.Width & " Height : " & R.Height
        GetClientRect(WinApi.WindowFromPoint(Point), R)
        Label7.Text = " Left : " & R.Left & " Right : " & R.Right & vbCrLf & "Width : " & R.Width & " Height : " & R.Height
        Label9.Text = GetParent(WinApi.WindowFromPoint(Point))
    End Sub

    Private Sub Spy_MeDown() Handles Spy.MeDown
        ShownSpy = False
    End Sub

    Private Sub Spy_MeUp() Handles Spy.MeUp
        ShownSpy = True
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Clipboard.SetText(Label12.Text)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Clipboard.SetText(Label2.Text)
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Clipboard.SetText(Label9.Text)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Clipboard.SetText(Label6.Text)
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Clipboard.SetText(Label7.Text)
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Clipboard.SetText(Label13.Text)
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        frmHookEx.Show()
    End Sub

    Public Class _PE

        '일부

        Public Shared Sub MessageSend(ByVal WndHandle As IntPtr, ByVal uEvent As Integer)

            WinApi.PostMessage(WndHandle, uEvent, 0, 0)

        End Sub

        Public Shared Sub DestroyWnd(ByVal Point As Point)

            _PE.MessageSend(WinApi.WindowFromPoint(Point), WinApiUsr.WM_CLOSE)

        End Sub
        Public Shared Sub CurDestroyWnd()

            Dim Point As Point
            WinApi.GetCursorPos(Point)

            _PE.MessageSend(WinApi.WindowFromPoint(Point), WinApiUsr.WM_CLOSE)

        End Sub

        '******************************************************************************
        ' Copyright (c) 2010-2012 Jung Hyun Jun. All rights reserved.
        '                         RollRat Software Programs & Lab(R LAB)
        '******************************************************************************
    End Class

End Class

Public Class MouseHook

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
