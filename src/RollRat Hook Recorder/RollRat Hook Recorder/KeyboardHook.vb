Imports System.Runtime.InteropServices

Public Class KeyboardHook

    Public Shared NoneCheckError As Boolean = False

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '                       SetWindowsHookEx
    '
    '           WINUSERAPI
    '           HHOOK
    '           WINAPI
    '           SetWindowsHookExW(
    '               _In_ int idHook,
    '               _In_ HOOKPROC lpfn,
    '               _In_opt_ HINSTANCE hmod,
    '               _In_ DWORD dwThreadId);
    '
    '           #define SetWindowsHookEx SetWindowsHookExW
    '
    '******************************************************************************
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Private Overloads Shared Function SetWindowsHookEx( _
                                                            ByVal idHook As Integer, _
                                                            ByVal HookProc As KBDLLHookProc, _
                                                            ByVal hInstance As IntPtr, _
                                                            ByVal wParam As Integer _
                                                            ) As Integer
    End Function

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '                       CallNextHookEx
    '
    '           WINUSERAPI
    '           LRESULT
    '           WINAPI
    '           CallNextHookEx(
    '               _In_opt_ HHOOK hhk,
    '               _In_ int nCode,
    '               _In_ WPARAM wParam,
    '               _In_ LPARAM lParam);
    '
    '******************************************************************************
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Private Overloads Shared Function CallNextHookEx( _
                                                          ByVal idHook As Integer, _
                                                          ByVal nCode As Integer, _
                                                          ByVal wParam As IntPtr, _
                                                          ByVal lParam As IntPtr _
                                                          ) As Integer
    End Function

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '                       UnhookWindowsHookEx
    '
    '           WINUSERAPI
    '           BOOL
    '           WINAPI
    '           UnhookWindowsHookEx(
    '               _In_ HHOOK hhk);
    '
    '******************************************************************************
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Private Overloads Shared Function UnhookWindowsHookEx( _
                                                               ByVal idHook As Integer _
                                                               ) As Boolean
    End Function

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '           /*
    '            * Structure used by WH_KEYBOARD_LL
    '            */
    '           typedef struct tagKBDLLHOOKSTRUCT {
    '               DWORD   vkCode;
    '               DWORD   scanCode;
    '               DWORD   flags;
    '               DWORD   time;
    '               ULONG_PTR dwExtraInfo;
    '           } KBDLLHOOKSTRUCT, FAR *LPKBDLLHOOKSTRUCT, *PKBDLLHOOKSTRUCT;
    '      
    '******************************************************************************
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure KBDLLHOOKSTRUCT
        Public vkCode As UInt32
        Public scanCode As UInt32
        Public flags As KBDLLHOOKSTRUCTFlags
        Public time As UInt32
        Public dwExtraInfo As UIntPtr
    End Structure

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '           /*
    '           * Structure used by WH_MOUSE_LL
    '           */
    '           typedef struct tagMSLLHOOKSTRUCT {
    '                  POINT   pt;
    '                  DWORD   mouseData;
    '                  DWORD   flags;
    '                  DWORD   time;
    '                  ULONG_PTR dwExtraInfo;
    '           } MSLLHOOKSTRUCT, FAR *LPMSLLHOOKSTRUCT, *PMSLLHOOKSTRUCT;
    '
    '******************************************************************************
    <Flags()> _
    Private Enum KBDLLHOOKSTRUCTFlags As UInt32
        LLKHF_EXTENDED = &H1
        LLKHF_INJECTED = &H10
        LLKHF_ALTDOWN = &H20
        LLKHF_UP = &H80
    End Enum

    '******************************************************************************
    '
    '
    '                       Keyboard Hook Events
    '
    '
    '******************************************************************************
    Public Shared Event KeyDown(ByVal Key As Keys)
    Public Shared Event KeyUp(ByVal Key As Keys)

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '                       Hook Events
    '
    '           #define WH_KEYBOARD_LL     13
    '           #define WH_MOUSE_LL        14
    '
    '           /*
    '           * Hook Codes
    '           */
    '           #define HC_ACTION           0
    '           #define HC_GETNEXT          1
    '           #define HC_SKIP             2
    '           #define HC_NOREMOVE         3
    '           #define HC_NOREM            HC_NOREMOVE
    '           #define HC_SYSMODALON       4
    '           #define HC_SYSMODALOFF      5
    '
    '           #define WM_KEYFIRST                     0x0100
    '           #define WM_KEYDOWN                      0x0100
    '           #define WM_KEYUP                        0x0101
    '           #define WM_CHAR                         0x0102
    '           #define WM_DEADCHAR                     0x0103
    '           #define WM_SYSKEYDOWN                   0x0104
    '           #define WM_SYSKEYUP                     0x0105
    '           #define WM_SYSCHAR                      0x0106
    '           #define WM_SYSDEADCHAR                  0x0107
    '
    '******************************************************************************
    Private Const WH_KEYBOARD_LL As Integer = WinApiUsr.WH_KEYBOARD_LL
    Private Const HC_ACTION As Integer = WinApiUsr.HC_ACTION
    Private Const WM_KEYFIRST As Integer = WinApiUsr.WM_KEYFIRST
    Private Const WM_KEYDOWN As Integer = WinApiUsr.WM_KEYDOWN
    Private Const WM_KEYUP As Integer = WinApiUsr.WM_KEYUP
    Private Const WM_CHAR As Integer = WinApiUsr.WM_CHAR
    Private Const WM_DEADCHAR As Integer = WinApiUsr.WM_DEADCHAR
    Private Const WM_SYSKEYDOWN As Integer = WinApiUsr.WM_SYSKEYDOWN
    Private Const WM_SYSKEYUP As Integer = WinApiUsr.WM_SYSKEYUP
    Private Const WM_SYSCHAR As Integer = WinApiUsr.WM_SYSKEYDOWN
    Private Const WM_SYSDEADCHAR As Integer = WinApiUsr.WM_SYSDEADCHAR

    Private Delegate Function KBDLLHookProc( _
                                             ByVal nCode As Integer, _
                                             ByVal wParam As IntPtr, _
                                             ByVal lParam As IntPtr _
                                             ) As Integer

    Private KBDLLHookProcDelegate As KBDLLHookProc = New KBDLLHookProc( _
                                                                        AddressOf KeyboardProc _
                                                                        )
    Private HHookID As IntPtr = IntPtr.Zero

    Private Function KeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        If (nCode = HC_ACTION) Then
            Dim struct As KBDLLHOOKSTRUCT
            Select Case wParam
                Case WM_KEYDOWN, WM_SYSKEYDOWN
                    RaiseEvent KeyDown(CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
                Case WM_KEYUP, WM_SYSKEYUP
                    RaiseEvent KeyUp(CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
            End Select
        End If
        Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
    End Function

    Public Sub New()
        HHookID = SetWindowsHookEx( _
                                    WH_KEYBOARD_LL, _
                                    KBDLLHookProcDelegate, _
                                    System.Runtime.InteropServices.Marshal.GetHINSTANCE( _
                                        System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, _
                                    0 _
                                    )
        '/////////////////////////////////////////////////////////////////////
        '
        '       If there was an error, debug, and run it using the 'Ctrl + F5' key.
        '
        '/////////////////////////////////////////////////////////////////////
        If NoneCheckError = True Then
            If HHookID = IntPtr.Zero Then
                Throw New Exception("Could not set keyboard hook")
            End If
        End If
    End Sub

    Public Shared Sub NoneCheck(ByVal NoneE As Boolean)
        NoneCheckError = NoneE
    End Sub

    Protected Overrides Sub Finalize()
        If Not HHookID = IntPtr.Zero Then
            UnhookWindowsHookEx(HHookID)
        End If
        MyBase.Finalize()
    End Sub

End Class