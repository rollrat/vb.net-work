Public Class KeyboardEvent
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

End Class
