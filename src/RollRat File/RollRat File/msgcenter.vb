Imports System.Text
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class aNobugz
    Private Shared mRect As Rectangle     ' Form rectangle
    Private Shared mTid As IntPtr         ' UI thread ID
    Private Shared mHwnd As IntPtr        ' Handle of message box window
    Private Shared mPos As Point          ' Desired postion of message box

    Public Shared Sub CenterMsgBox(ByVal frm As Form)
        '--- Centers the message box about to be displayed inside form <frm>
        mRect = frm.Bounds
        mTid = GetCurrentThreadId()
        mHwnd = IntPtr.Zero
        Dim bw As New BackgroundWorker
        AddHandler bw.DoWork, AddressOf FindMsgBox
        AddHandler bw.RunWorkerCompleted, AddressOf CenterMsgBox
        bw.RunWorkerAsync()
    End Sub
    Private Shared Sub FindMsgBox(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        '--- Try this a few times in case the message box wasn't created yet
        For ix As Integer = 1 To 4
            '--- Enumerate the windows in the GUI thread
            EnumThreadWindows(mTid, AddressOf EnumWindow, IntPtr.Zero)
            If mHwnd <> IntPtr.Zero Then Exit For
            Threading.Thread.Sleep(30)
        Next
    End Sub
    Private Shared Sub CenterMsgBox(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        '--- Center it if we found the message box
        If mHwnd <> IntPtr.Zero Then
            SetWindowPos(mHwnd, IntPtr.Zero, mPos.X, mPos.Y, 0, 0, SWP_NOSIZE)
        End If
    End Sub
    Private Shared Function EnumWindow(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
        '--- Is this the message box?
        Dim sb As New StringBuilder(256)
        GetClassName(hWnd, sb, sb.Capacity)
        If sb.ToString() <> "#32770" Then Return True
        '--- Got it, now move it where it should go
        Dim rc As RECT
        GetWindowRect(hWnd, rc)
        mPos = New Point(mRect.Left + (mRect.Width - (rc.Right - rc.Left)) \ 2, _
                         mRect.Top + (mRect.Height - (rc.Bottom - rc.Top)) \ 2)
        mHwnd = hWnd
        '--- Done, stop iterating
        Return False
    End Function

    '--- P/Invoke declarations
    Private Delegate Function EnumThreadDelegate(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
    Private Declare Auto Function EnumThreadWindows Lib "user32.dll" (ByVal tid As IntPtr, ByVal callback As EnumThreadDelegate, ByVal lp As IntPtr) As Boolean
    Private Declare Auto Function GetClassName Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal name As StringBuilder, ByVal maxlen As Integer) As Integer
    Private Declare Auto Function GetCurrentThreadId Lib "kernel32.dll" () As IntPtr
    Private Declare Auto Function SetWindowPos Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal hAfter As IntPtr, _
      ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    Private Declare Auto Function GetWindowRect Lib "user32.dll" (ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure
    Private Const SWP_NOSIZE As Integer = 1
End Class