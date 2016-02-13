Module modWinAPI

    <System.Runtime.InteropServices.DllImport("User32")> _
    Public Function ReleaseCapture() As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("User32")> _
    Public Function SendMessage(hWnd As IntPtr, hMsg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

End Module
