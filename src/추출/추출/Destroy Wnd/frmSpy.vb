Imports 추출.RollRat_Vb_Api
Imports System.Text
Imports System.Runtime.InteropServices

Public Class frmSpy

    Public Enum GetSystem_Metrics As Integer
        SM_CXBORDER = 5
        SM_CXFULLSCREEN = 16
        SM_CYFULLSCREEN = 17
    End Enum

    Private LastWindow As IntPtr = IntPtr.Zero

    Public Shared Function GetWindowRects(ByVal hWnd As IntPtr) As Rectangle
        Debug.Assert((hWnd <> IntPtr.Zero))
        Dim rect As WinApi.RECT = New WinApi.RECT
        If (WinApi.GetWindowRect(hWnd, rect) = False) Then Throw New Exception("GetWindowRect failed")
        Return rect
    End Function

    Private Shared Sub ShowInvertRectTracker(ByVal window As IntPtr)
        If (window <> IntPtr.Zero) Then
            Dim WindowRect As Rectangle = GetWindowRects(window)
            Dim dc As IntPtr = WinApi.GetWindowDC(window)
            WinApi.SetROP2(dc, 6)
            Dim Pen As IntPtr = WinApi.CreatePen(6, 5 * WinApi.GetSystemMetrics(5), 0)
            Dim OldPen As IntPtr = WinApi.SelectObject(dc, Pen)
            Dim OldBrush As IntPtr = WinApi.SelectObject(dc, WinApi.GetStockObject(5))
            WinApi.Rectangle(dc, 0, 0, WindowRect.Width, WindowRect.Height)
            WinApi.SelectObject(dc, OldBrush)
            WinApi.SelectObject(dc, OldPen)
            WinApi.ReleaseDC(window, dc)
            WinApi.DeleteObject(Pen)
        End If
    End Sub

    Private Shared Function ChildWindowFromPoint(ByVal point As Point) As IntPtr
        Dim WindowPoint As IntPtr = WinApi.WindowFromPoint(point)
        If (WindowPoint = IntPtr.Zero) Then Return IntPtr.Zero
        If (WinApi.ScreenToClient(WindowPoint, point) = False) Then Throw New Exception("ScreenToClient failed")
        Dim Window As IntPtr = WinApi.ChildWindowFromPointEx(WindowPoint, point, 0)
        If (Window = IntPtr.Zero) Then  Return WindowPoint
        If (WinApi.ClientToScreen(WindowPoint, point) = False) Then Throw New Exception("ClientToScreen failed")
        If (WinApi.IsChild(WinApi.GetParent(Window), Window) = False) Then Return Window
        Dim WindowList As ArrayList = New ArrayList
        While (Window <> IntPtr.Zero)
            Dim rect As Rectangle = GetWindowRects(Window)
            If rect.Contains(point) Then
                WindowList.Add(Window)
            End If
            Window = WinApi.GetWindow(Window, 2)
        End While
        Dim MinPixel As Integer = (WinApi.GetSystemMetrics(16) * WinApi.GetSystemMetrics(17))
        Dim i As Integer = 0
        Do While (i < WindowList.Count)
            Dim rect As Rectangle = GetWindowRects(WindowList(i))
            Dim ChildPixel As Integer = (rect.Width * rect.Height)
            If (ChildPixel < MinPixel) Then
                MinPixel = ChildPixel
                Window = CType(WindowList(i), IntPtr)
            End If
            i = (i + 1)
        Loop
        Return Window
    End Function

    Private Sub pictureBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pictureBox.MouseDown
        If (e.Button = MouseButtons.Left) Then
            Cursor = New Cursor("windowfi.cur")
            pictureBox.Image = imageList.Images(0)
        End If
    End Sub

    Private Sub pictureBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pictureBox.MouseMove
        If (Cursor <> Cursors.Default) Then
            Dim FoundWindow As IntPtr = ChildWindowFromPoint(Cursor.Position)
            If (Control.FromHandle(FoundWindow) Is Nothing) Then
                If (FoundWindow <> LastWindow) Then
                    ShowInvertRectTracker(LastWindow)
                    LastWindow = FoundWindow
                    ShowInvertRectTracker(LastWindow)
                End If
            End If
        End If
    End Sub

    Public Shared Event MeUp()
    Public Shared Event MeDown()
    Public Shared Event MeChoose(ByVal pt As Point)

    Private Sub frmSpy_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        RaiseEvent MeDown()
    End Sub

    Private Sub frmSpy_Load(sender As Object, e As EventArgs) Handles Me.Load
        RaiseEvent MeUp()
    End Sub

    Public ReadOnly Property Ha()
        Get
            Return LastWindow
        End Get
    End Property

    Private Sub pictureBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pictureBox.MouseUp

        If (Cursor <> Cursors.Default) Then
            ShowInvertRectTracker(LastWindow)
            Dim pt As Point
            WinApi.GetCursorPos(pt)
            RaiseEvent MeChoose(pt)
            LastWindow = IntPtr.Zero
            Cursor = Cursors.Default
            pictureBox.Image = imageList.Images(1)
        End If
    End Sub

End Class