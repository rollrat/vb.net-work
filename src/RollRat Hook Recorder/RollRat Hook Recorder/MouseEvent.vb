Imports System.Runtime.InteropServices

Public Class MouseEvent
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

End Class