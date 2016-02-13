'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

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

End Class