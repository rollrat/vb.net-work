'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class WinApiUsr

    '
    '   프로그램으로 대충 추출한 것이라 몇개가 없을 수도 있음
    '


    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Scroll Bar Constants
    '
    '           #define SB_HORZ             0
    '           #define SB_VERT             1
    '           #define SB_CTL              2
    '           #define SB_BOTH             3
    '
    '******************************************************************************
    Public Const SB_HORZ As Integer = 0
    Public Const SB_VERT As Integer = 1
    Public Const SB_CTL As Integer = 2
    Public Const SB_BOTH As Integer = 3

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Scroll Bar Constants
    '
    '           #define SB_LINEUP           0
    '           #define SB_LINELEFT         0
    '           #define SB_LINEDOWN         1
    '           #define SB_LINERIGHT        1
    '           #define SB_PAGEUP           2
    '           #define SB_PAGELEFT         2
    '           #define SB_PAGEDOWN         3
    '           #define SB_PAGERIGHT        3
    '           #define SB_THUMBPOSITION    4
    '           #define SB_THUMBTRACK       5
    '           #define SB_TOP              6
    '           #define SB_LEFT             6
    '           #define SB_BOTTOM           7
    '           #define SB_RIGHT            7
    '           #define SB_ENDSCROLL        8
    '
    '******************************************************************************
    Public Const SB_LINEUP As Integer = 0
    Public Const SB_LINELEFT As Integer = 0
    Public Const SB_LINEDOWN As Integer = 1
    Public Const SB_LINERIGHT As Integer = 1
    Public Const SB_PAGEUP As Integer = 2
    Public Const SB_PAGELEFT As Integer = 2
    Public Const SB_PAGEDOWN As Integer = 3
    Public Const SB_PAGERIGHT As Integer = 3
    Public Const SB_THUMBPOSITION As Integer = 4
    Public Const SB_THUMBTRACK As Integer = 5
    Public Const SB_TOP As Integer = 6
    Public Const SB_LEFT As Integer = 6
    Public Const SB_BOTTOM As Integer = 7
    Public Const SB_RIGHT As Integer = 7
    Public Const SB_ENDSCROLL As Integer = 8

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           ShowWindow
    '
    '           #define SW_HIDE             0
    '           #define SW_SHOWNORMAL       1
    '           #define SW_NORMAL           1
    '           #define SW_SHOWMINIMIZED    2
    '           #define SW_SHOWMAXIMIZED    3
    '           #define SW_MAXIMIZE         3
    '           #define SW_SHOWNOACTIVATE   4
    '           #define SW_SHOW             5
    '           #define SW_MINIMIZE         6
    '           #define SW_SHOWMINNOACTIVE  7
    '           #define SW_SHOWNA           8
    '           #define SW_RESTORE          9
    '           #define SW_SHOWDEFAULT      10
    '           #define SW_FORCEMINIMIZE    11
    '           #define SW_MAX              11
    '
    '******************************************************************************
    Public Const SW_HIDE As Integer = 0
    Public Const SW_SHOWNORMAL As Integer = 1
    Public Const SW_NORMAL As Integer = 1
    Public Const SW_SHOWMINIMIZED As Integer = 2
    Public Const SW_SHOWMAXIMIZED As Integer = 3
    Public Const SW_MAXIMIZE As Integer = 3
    Public Const SW_SHOWNOACTIVATE As Integer = 4
    Public Const SW_SHOW As Integer = 5
    Public Const SW_MINIMIZE As Integer = 6
    Public Const SW_SHOWMINNOACTIVE As Integer = 7
    Public Const SW_SHOWNA As Integer = 8
    Public Const SW_RESTORE As Integer = 9
    Public Const SW_SHOWDEFAULT As Integer = 10
    Public Const SW_FORCEMINIMIZE As Integer = 11
    Public Const SW_MAX As Integer = 11

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Old ShowWindow
    '
    '           #define HIDE_WINDOW         0
    '           #define SHOW_OPENWINDOW     1
    '           #define SHOW_ICONWINDOW     2
    '           #define SHOW_FULLSCREEN     3
    '           #define SHOW_OPENNOACTIVATE 4
    '
    '******************************************************************************
    Public Const HIDE_WINDOW As Integer = 0
    Public Const SHOW_OPENWINDOW As Integer = 1
    Public Const SHOW_ICONWINDOW As Integer = 2
    Public Const SHOW_FULLSCREEN As Integer = 3
    Public Const SHOW_OPENNOACTIVATE As Integer = 4

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Identifiers for the WM_SHOWWINDOW message
    '
    '           #define SW_PARENTCLOSING    1
    '           #define SW_OTHERZOOM        2
    '           #define SW_PARENTOPENING    3
    '           #define SW_OTHERUNZOOM      4
    '
    '******************************************************************************
    Public Const SW_PARENTCLOSING As Integer = 1
    Public Const SW_OTHERZOOM As Integer = 2
    Public Const SW_PARENTOPENING As Integer = 3
    Public Const SW_OTHERUNZOOM As Integer = 4

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           AnimateWindow
    '
    '           #define AW_HOR_POSITIVE             0x00000001
    '           #define AW_HOR_NEGATIVE             0x00000002
    '           #define AW_VER_POSITIVE             0x00000004
    '           #define AW_VER_NEGATIVE             0x00000008
    '           #define AW_CENTER                   0x00000010
    '           #define AW_HIDE                     0x00010000
    '           #define AW_ACTIVATE                 0x00020000
    '           #define AW_SLIDE                    0x00040000
    '           #define AW_BLEND                    0x00080000
    '
    '******************************************************************************
    Public Const AW_HOR_POSITIVE As Integer = &H1
    Public Const AW_HOR_NEGATIVE As Integer = &H2
    Public Const AW_VER_POSITIVE As Integer = &H4
    Public Const AW_VER_NEGATIVE As Integer = &H8
    Public Const AW_CENTER As Integer = &H10
    Public Const AW_HIDE As Integer = &H10000
    Public Const AW_ACTIVATE As Integer = &H20000
    Public Const AW_SLIDE As Integer = &H40000
    Public Const AW_BLEND As Integer = &H80000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WM_KEYUP/DOWN/CHAR HIWORD(lParam) flags
    '
    '           #define KF_EXTENDED       0x0100
    '           #define KF_DLGMODE        0x0800
    '           #define KF_MENUMODE       0x1000
    '           #define KF_ALTDOWN        0x2000
    '           #define KF_REPEAT         0x4000
    '           #define KF_UP             0x8000
    '
    '******************************************************************************
    Public Const KF_EXTENDED As Integer = &H100
    Public Const KF_DLGMODE As Integer = &H800
    Public Const KF_MENUMODE As Integer = &H1000
    Public Const KF_ALTDOWN As Integer = &H2000
    Public Const KF_REPEAT As Integer = &H4000
    Public Const KF_UP As Integer = &H8000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Virtual Keys, Standard Set
    '
    '           #define VK_LBUTTON        0x01
    '           #define VK_RBUTTON        0x02
    '           #define VK_CANCEL         0x03
    '           #define VK_MBUTTON        0x04
    '
    '******************************************************************************
    Public Const VK_LBUTTON As Integer = &H1
    Public Const VK_RBUTTON As Integer = &H2
    Public Const VK_CANCEL As Integer = &H3
    Public Const VK_MBUTTON As Integer = &H4
    Public Const VK_XBUTTON1 As Integer = &H5
    Public Const VK_XBUTTON2 As Integer = &H6
    Public Const VK_BACK As Integer = &H8
    Public Const VK_TAB As Integer = &H9
    Public Const VK_CLEAR As Integer = &HC
    Public Const VK_RETURN As Integer = &HD
    Public Const VK_SHIFT As Integer = &H10
    Public Const VK_CONTROL As Integer = &H11
    Public Const VK_MENU As Integer = &H12
    Public Const VK_PAUSE As Integer = &H13
    Public Const VK_CAPITAL As Integer = &H14
    Public Const VK_KANA As Integer = &H15
    Public Const VK_HANGEUL As Integer = &H15
    Public Const VK_HANGUL As Integer = &H15
    Public Const VK_JUNJA As Integer = &H17
    Public Const VK_FINAL As Integer = &H18
    Public Const VK_HANJA As Integer = &H19
    Public Const VK_KANJI As Integer = &H19
    Public Const VK_ESCAPE As Integer = &H1B
    Public Const VK_CONVERT As Integer = &H1C
    Public Const VK_NONCONVERT As Integer = &H1D
    Public Const VK_ACCEPT As Integer = &H1E
    Public Const VK_MODECHANGE As Integer = &H1F
    Public Const VK_SPACE As Integer = &H20
    Public Const VK_PRIOR As Integer = &H21
    Public Const VK_NEXT As Integer = &H22
    Public Const VK_END As Integer = &H23
    Public Const VK_HOME As Integer = &H24
    Public Const VK_LEFT As Integer = &H25
    Public Const VK_UP As Integer = &H26
    Public Const VK_RIGHT As Integer = &H27
    Public Const VK_DOWN As Integer = &H28
    Public Const VK_SELECT As Integer = &H29
    Public Const VK_PRINT As Integer = &H2A
    Public Const VK_EXECUTE As Integer = &H2B
    Public Const VK_SNAPSHOT As Integer = &H2C
    Public Const VK_INSERT As Integer = &H2D
    Public Const VK_DELETE As Integer = &H2E
    Public Const VK_HELP As Integer = &H2F
    Public Const VK_LWIN As Integer = &H5B
    Public Const VK_RWIN As Integer = &H5C
    Public Const VK_APPS As Integer = &H5D
    Public Const VK_SLEEP As Integer = &H5F
    Public Const VK_NUMPAD0 As Integer = &H60
    Public Const VK_NUMPAD1 As Integer = &H61
    Public Const VK_NUMPAD2 As Integer = &H62
    Public Const VK_NUMPAD3 As Integer = &H63
    Public Const VK_NUMPAD4 As Integer = &H64
    Public Const VK_NUMPAD5 As Integer = &H65
    Public Const VK_NUMPAD6 As Integer = &H66
    Public Const VK_NUMPAD7 As Integer = &H67
    Public Const VK_NUMPAD8 As Integer = &H68
    Public Const VK_NUMPAD9 As Integer = &H69
    Public Const VK_MULTIPLY As Integer = &H6A
    Public Const VK_ADD As Integer = &H6B
    Public Const VK_SEPARATOR As Integer = &H6C
    Public Const VK_SUBTRACT As Integer = &H6D
    Public Const VK_DECIMAL As Integer = &H6E
    Public Const VK_DIVIDE As Integer = &H6F
    Public Const VK_F1 As Integer = &H70
    Public Const VK_F2 As Integer = &H71
    Public Const VK_F3 As Integer = &H72
    Public Const VK_F4 As Integer = &H73
    Public Const VK_F5 As Integer = &H74
    Public Const VK_F6 As Integer = &H75
    Public Const VK_F7 As Integer = &H76
    Public Const VK_F8 As Integer = &H77
    Public Const VK_F9 As Integer = &H78
    Public Const VK_F10 As Integer = &H79
    Public Const VK_F11 As Integer = &H7A
    Public Const VK_F12 As Integer = &H7B
    Public Const VK_F13 As Integer = &H7C
    Public Const VK_F14 As Integer = &H7D
    Public Const VK_F15 As Integer = &H7E
    Public Const VK_F16 As Integer = &H7F
    Public Const VK_F17 As Integer = &H80
    Public Const VK_F18 As Integer = &H81
    Public Const VK_F19 As Integer = &H82
    Public Const VK_F20 As Integer = &H83
    Public Const VK_F21 As Integer = &H84
    Public Const VK_F22 As Integer = &H85
    Public Const VK_F23 As Integer = &H86
    Public Const VK_F24 As Integer = &H87
    Public Const VK_NUMLOCK As Integer = &H90
    Public Const VK_SCROLL As Integer = &H91
    Public Const VK_OEM_NEC_EQUAL As Integer = &H92
    Public Const VK_OEM_FJ_JISHO As Integer = &H92
    Public Const VK_OEM_FJ_MASSHOU As Integer = &H93
    Public Const VK_OEM_FJ_TOUROKU As Integer = &H94
    Public Const VK_OEM_FJ_LOYA As Integer = &H95
    Public Const VK_OEM_FJ_ROYA As Integer = &H96
    Public Const VK_LSHIFT As Integer = &HA0
    Public Const VK_RSHIFT As Integer = &HA1
    Public Const VK_LCONTROL As Integer = &HA2
    Public Const VK_RCONTROL As Integer = &HA3
    Public Const VK_LMENU As Integer = &HA4
    Public Const VK_RMENU As Integer = &HA5
    Public Const VK_BROWSER_BACK As Integer = &HA6
    Public Const VK_BROWSER_FORWARD As Integer = &HA7
    Public Const VK_BROWSER_REFRESH As Integer = &HA8
    Public Const VK_BROWSER_STOP As Integer = &HA9
    Public Const VK_BROWSER_SEARCH As Integer = &HAA
    Public Const VK_BROWSER_FAVORITES As Integer = &HAB
    Public Const VK_BROWSER_HOME As Integer = &HAC
    Public Const VK_VOLUME_MUTE As Integer = &HAD
    Public Const VK_VOLUME_DOWN As Integer = &HAE
    Public Const VK_VOLUME_UP As Integer = &HAF
    Public Const VK_MEDIA_NEXT_TRACK As Integer = &HB0
    Public Const VK_MEDIA_PREV_TRACK As Integer = &HB1
    Public Const VK_MEDIA_STOP As Integer = &HB2
    Public Const VK_MEDIA_PLAY_PAUSE As Integer = &HB3
    Public Const VK_LAUNCH_MAIL As Integer = &HB4
    Public Const VK_LAUNCH_MEDIA_SELECT As Integer = &HB5
    Public Const VK_LAUNCH_APP1 As Integer = &HB6
    Public Const VK_LAUNCH_APP2 As Integer = &HB7
    Public Const VK_OEM_1 As Integer = &HBA
    Public Const VK_OEM_PLUS As Integer = &HBB
    Public Const VK_OEM_COMMA As Integer = &HBC
    Public Const VK_OEM_MINUS As Integer = &HBD
    Public Const VK_OEM_PERIOD As Integer = &HBE
    Public Const VK_OEM_2 As Integer = &HBF
    Public Const VK_OEM_3 As Integer = &HC0
    Public Const VK_OEM_4 As Integer = &HDB
    Public Const VK_OEM_5 As Integer = &HDC
    Public Const VK_OEM_6 As Integer = &HDD
    Public Const VK_OEM_7 As Integer = &HDE
    Public Const VK_OEM_8 As Integer = &HDF
    Public Const VK_OEM_AX As Integer = &HE1
    Public Const VK_OEM_102 As Integer = &HE2
    Public Const VK_ICO_HELP As Integer = &HE3
    Public Const VK_ICO_00 As Integer = &HE4

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           SetWindowsHook
    '
    '           #define WH_MIN              (-1)
    '           #define WH_MSGFILTER        (-1)
    '           #define WH_JOURNALRECORD    0
    '           #define WH_JOURNALPLAYBACK  1
    '           #define WH_KEYBOARD         2
    '           #define WH_GETMESSAGE       3
    '           #define WH_CALLWNDPROC      4
    '           #define WH_CBT              5
    '           #define WH_SYSMSGFILTER     6
    '           #define WH_MOUSE            7
    '           #if defined(_WIN32_WINDOWS)
    '           #define WH_HARDWARE         8
    '           #endif
    '           #define WH_DEBUG            9
    '           #define WH_SHELL           10
    '           #define WH_FOREGROUNDIDLE  11
    '           #if(WINVER >= 0x0400)
    '           #define WH_CALLWNDPROCRET  12
    '           #endif /* WINVER >= 0x0400 */
    '           
    '           #if (_WIN32_WINNT >= 0x0400)
    '           #define WH_KEYBOARD_LL     13
    '           #define WH_MOUSE_LL        14
    '           #endif // (_WIN32_WINNT >= 0x0400)
    '           
    '           #if(WINVER >= 0x0400)
    '           #if (_WIN32_WINNT >= 0x0400)
    '           #define WH_MAX             14
    '           #else
    '           #define WH_MAX             12
    '           #endif // (_WIN32_WINNT >= 0x0400)
    '           #else
    '           #define WH_MAX             11
    '           #endif
    '           
    '           #define WH_MINHOOK         WH_MIN
    '           #define WH_MAXHOOK         WH_MAX
    '
    '******************************************************************************
    Public Const WH_MIN As Integer = -1
    Public Const WH_MSGFILTER As Integer = -1
    Public Const WH_JOURNALRECORD As Integer = 0
    Public Const WH_JOURNALPLAYBACK As Integer = 1
    Public Const WH_KEYBOARD As Integer = 2
    Public Const WH_GETMESSAGE As Integer = 3
    Public Const WH_CALLWNDPROC As Integer = 4
    Public Const WH_CBT As Integer = 5
    Public Const WH_SYSMSGFILTER As Integer = 6
    Public Const WH_MOUSE As Integer = 7
    Public Const WH_HARDWARE As Integer = 8
    Public Const WH_DEBUG As Integer = 9
    Public Const WH_SHELL As Integer = 10
    Public Const WH_FOREGROUNDIDLE As Integer = 11
    Public Const WH_CALLWNDPROCRET As Integer = 12
    Public Const WH_KEYBOARD_LL As Integer = 13
    Public Const WH_MOUSE_LL As Integer = 14
    Public Const WH_MAX As Integer = 14

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Hook Codes
    '
    '           #define HC_ACTION           0
    '           #define HC_GETNEXT          1
    '           #define HC_SKIP             2
    '           #define HC_NOREMOVE         3
    '           #define HC_SYSMODALON       4
    '           #define HC_SYSMODALOFF      5
    '
    '******************************************************************************
    Public Const HC_ACTION As Integer = 0
    Public Const HC_GETNEXT As Integer = 1
    Public Const HC_SKIP As Integer = 2
    Public Const HC_NOREMOVE As Integer = 3
    Public Const HC_SYSMODALON As Integer = 4
    Public Const HC_SYSMODALOFF As Integer = 5

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           CBT Hook Codes
    '
    '           #define HCBT_MOVESIZE       0
    '           #define HCBT_MINMAX         1
    '           #define HCBT_QS             2
    '           #define HCBT_CREATEWND      3
    '           #define HCBT_DESTROYWND     4
    '           #define HCBT_ACTIVATE       5
    '           #define HCBT_CLICKSKIPPED   6
    '           #define HCBT_KEYSKIPPED     7
    '           #define HCBT_SYSCOMMAND     8
    '           #define HCBT_SETFOCUS       9
    '
    '******************************************************************************
    Public Const HCBT_MOVESIZE As Integer = 0
    Public Const HCBT_MINMAX As Integer = 1
    Public Const HCBT_QS As Integer = 2
    Public Const HCBT_CREATEWND As Integer = 3
    Public Const HCBT_DESTROYWND As Integer = 4
    Public Const HCBT_ACTIVATE As Integer = 5
    Public Const HCBT_CLICKSKIPPED As Integer = 6
    Public Const HCBT_KEYSKIPPED As Integer = 7
    Public Const HCBT_SYSCOMMAND As Integer = 8
    Public Const HCBT_SETFOCUS As Integer = 9

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           codes passed in WPARAM for WM_WTSSESSION_CHANGE
    '
    '           #define WTS_CONSOLE_CONNECT                0x1
    '           #define WTS_CONSOLE_DISCONNECT             0x2
    '           #define WTS_REMOTE_CONNECT                 0x3
    '           #define WTS_REMOTE_DISCONNECT              0x4
    '           #define WTS_SESSION_LOGON                  0x5
    '           #define WTS_SESSION_LOGOFF                 0x6
    '           #define WTS_SESSION_LOCK                   0x7
    '           #define WTS_SESSION_UNLOCK                 0x8
    '           #define WTS_SESSION_REMOTE_CONTROL         0x9
    '           #define WTS_SESSION_CREATE                 0xA
    '           #define WTS_SESSION_TERMINATE              0xB
    '
    '******************************************************************************
    Public Const WTS_CONSOLE_CONNECT As Integer = &H1
    Public Const WTS_CONSOLE_DISCONNECT As Integer = &H2
    Public Const WTS_REMOTE_CONNECT As Integer = &H3
    Public Const WTS_REMOTE_DISCONNECT As Integer = &H4
    Public Const WTS_SESSION_LOGON As Integer = &H5
    Public Const WTS_SESSION_LOGOFF As Integer = &H6
    Public Const WTS_SESSION_LOCK As Integer = &H7
    Public Const WTS_SESSION_UNLOCK As Integer = &H8
    Public Const WTS_SESSION_REMOTE_CONTROL As Integer = &H9
    Public Const WTS_SESSION_CREATE As Integer = &HA
    Public Const WTS_SESSION_TERMINATE As Integer = &HB

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WH_MSGFILTER Filter Proc Codes
    '
    '           #define MSGF_DIALOGBOX      0
    '           #define MSGF_MESSAGEBOX     1
    '           #define MSGF_MENU           2
    '           #define MSGF_SCROLLBAR      5
    '           #define MSGF_NEXTWINDOW     6
    '           #define MSGF_MAX            8                       // unused
    '           #define MSGF_USER           4096
    '
    '******************************************************************************
    Public Const MSGF_DIALOGBOX As Integer = 0
    Public Const MSGF_MESSAGEBOX As Integer = 1
    Public Const MSGF_MENU As Integer = 2
    Public Const MSGF_SCROLLBAR As Integer = 5
    Public Const MSGF_NEXTWINDOW As Integer = 6
    Public Const MSGF_MAX As Integer = 8
    Public Const MSGF_USER As Integer = 4096

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Shell support 
    '
    '           #define HSHELL_WINDOWCREATED        1
    '           #define HSHELL_WINDOWDESTROYED      2
    '           #define HSHELL_ACTIVATESHELLWINDOW  3
    '
    '******************************************************************************
    Public Const HSHELL_WINDOWCREATED As Integer = 1
    Public Const HSHELL_WINDOWDESTROYED As Integer = 2
    Public Const HSHELL_ACTIVATESHELLWINDOW As Integer = 3

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Shell support
    '           
    '           #if(WINVER >= 0x0400)
    '           #define HSHELL_WINDOWACTIVATED      4
    '           #define HSHELL_GETMINRECT           5
    '           #define HSHELL_REDRAW               6
    '           #define HSHELL_TASKMAN              7
    '           #define HSHELL_LANGUAGE             8
    '           #define HSHELL_SYSMENU              9
    '           #define HSHELL_ENDTASK              10
    '           #endif /* WINVER >= 0x0400 */
    '           #if(_WIN32_WINNT >= 0x0500)
    '           #define HSHELL_ACCESSIBILITYSTATE   11
    '           #define HSHELL_APPCOMMAND           12
    '           #endif /* _WIN32_WINNT >= 0x0500 */
    '           
    '           #if(_WIN32_WINNT >= 0x0501)
    '           #define HSHELL_WINDOWREPLACED       13
    '           #define HSHELL_WINDOWREPLACING      14
    '           #endif /* _WIN32_WINNT >= 0x0501 */
    '           
    '           
    '           #if(_WIN32_WINNT >= 0x0602)
    '           #define HSHELL_MONITORCHANGED            16
    '           #endif /* _WIN32_WINNT >= 0x0602 */
    '           
    '           #define HSHELL_HIGHBIT            0x8000
    '
    '******************************************************************************
    Public Const HSHELL_WINDOWACTIVATED As Integer = 4
    Public Const HSHELL_GETMINRECT As Integer = 5
    Public Const HSHELL_REDRAW As Integer = 6
    Public Const HSHELL_TASKMAN As Integer = 7
    Public Const HSHELL_LANGUAGE As Integer = 8
    Public Const HSHELL_SYSMENU As Integer = 9
    Public Const HSHELL_ENDTASK As Integer = 10
    Public Const HSHELL_ACCESSIBILITYSTATE As Integer = 11
    Public Const HSHELL_APPCOMMAND As Integer = 12
    Public Const HSHELL_WINDOWREPLACED As Integer = 13
    Public Const HSHELL_WINDOWREPLACING As Integer = 14
    Public Const HSHELL_MONITORCHANGED As Integer = 16
    Public Const HSHELL_HIGHBIT As Integer = &H8000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           cmd for HSHELL_APPCOMMAND and WM_APPCOMMAND
    '
    '           #define APPCOMMAND_BROWSER_BACKWARD       1
    '           #define APPCOMMAND_BROWSER_FORWARD        2
    '           #define APPCOMMAND_BROWSER_REFRESH        3
    '           #define APPCOMMAND_BROWSER_STOP           4
    '           #define APPCOMMAND_BROWSER_SEARCH         5
    '           #define APPCOMMAND_BROWSER_FAVORITES      6
    '           #define APPCOMMAND_BROWSER_HOME           7
    '           #define APPCOMMAND_VOLUME_MUTE            8
    '           #define APPCOMMAND_VOLUME_DOWN            9
    '           #define APPCOMMAND_VOLUME_UP              10
    '           #define APPCOMMAND_MEDIA_NEXTTRACK        11
    '           #define APPCOMMAND_MEDIA_PREVIOUSTRACK    12
    '           #define APPCOMMAND_MEDIA_STOP             13
    '           #define APPCOMMAND_MEDIA_PLAY_PAUSE       14
    '           #define APPCOMMAND_LAUNCH_MAIL            15
    '           #define APPCOMMAND_LAUNCH_MEDIA_SELECT    16
    '           #define APPCOMMAND_LAUNCH_APP1            17
    '           #define APPCOMMAND_LAUNCH_APP2            18
    '           #define APPCOMMAND_BASS_DOWN              19
    '           #define APPCOMMAND_BASS_BOOST             20
    '           #define APPCOMMAND_BASS_UP                21
    '           #define APPCOMMAND_TREBLE_DOWN            22
    '           #define APPCOMMAND_TREBLE_UP              23
    '           #if(_WIN32_WINNT >= 0x0501)
    '           #define APPCOMMAND_MICROPHONE_VOLUME_MUTE 24
    '           #define APPCOMMAND_MICROPHONE_VOLUME_DOWN 25
    '           #define APPCOMMAND_MICROPHONE_VOLUME_UP   26
    '           #define APPCOMMAND_HELP                   27
    '           #define APPCOMMAND_FIND                   28
    '           #define APPCOMMAND_NEW                    29
    '           #define APPCOMMAND_OPEN                   30
    '           #define APPCOMMAND_CLOSE                  31
    '           #define APPCOMMAND_SAVE                   32
    '           #define APPCOMMAND_PRINT                  33
    '           #define APPCOMMAND_UNDO                   34
    '           #define APPCOMMAND_REDO                   35
    '           #define APPCOMMAND_COPY                   36
    '           #define APPCOMMAND_CUT                    37
    '           #define APPCOMMAND_PASTE                  38
    '           #define APPCOMMAND_REPLY_TO_MAIL          39
    '           #define APPCOMMAND_FORWARD_MAIL           40
    '           #define APPCOMMAND_SEND_MAIL              41
    '           #define APPCOMMAND_SPELL_CHECK            42
    '           #define APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE    43
    '           #define APPCOMMAND_MIC_ON_OFF_TOGGLE      44
    '           #define APPCOMMAND_CORRECTION_LIST        45
    '           #define APPCOMMAND_MEDIA_PLAY             46
    '           #define APPCOMMAND_MEDIA_PAUSE            47
    '           #define APPCOMMAND_MEDIA_RECORD           48
    '           #define APPCOMMAND_MEDIA_FAST_FORWARD     49
    '           #define APPCOMMAND_MEDIA_REWIND           50
    '           #define APPCOMMAND_MEDIA_CHANNEL_UP       51
    '           #define APPCOMMAND_MEDIA_CHANNEL_DOWN     52
    '           #endif /* _WIN32_WINNT >= 0x0501 */
    '           #if(_WIN32_WINNT >= 0x0600)
    '           #define APPCOMMAND_DELETE                 53
    '           #define APPCOMMAND_DWM_FLIP3D             54
    '           #endif /* _WIN32_WINNT >= 0x0600 */
    '
    '******************************************************************************
    Public Const APPCOMMAND_BROWSER_BACKWARD As Integer = 1
    Public Const APPCOMMAND_BROWSER_FORWARD As Integer = 2
    Public Const APPCOMMAND_BROWSER_REFRESH As Integer = 3
    Public Const APPCOMMAND_BROWSER_STOP As Integer = 4
    Public Const APPCOMMAND_BROWSER_SEARCH As Integer = 5
    Public Const APPCOMMAND_BROWSER_FAVORITES As Integer = 6
    Public Const APPCOMMAND_BROWSER_HOME As Integer = 7
    Public Const APPCOMMAND_VOLUME_MUTE As Integer = 8
    Public Const APPCOMMAND_VOLUME_DOWN As Integer = 9
    Public Const APPCOMMAND_VOLUME_UP As Integer = 10
    Public Const APPCOMMAND_MEDIA_NEXTTRACK As Integer = 11
    Public Const APPCOMMAND_MEDIA_PREVIOUSTRACK As Integer = 12
    Public Const APPCOMMAND_MEDIA_STOP As Integer = 13
    Public Const APPCOMMAND_MEDIA_PLAY_PAUSE As Integer = 14
    Public Const APPCOMMAND_LAUNCH_MAIL As Integer = 15
    Public Const APPCOMMAND_LAUNCH_MEDIA_SELECT As Integer = 16
    Public Const APPCOMMAND_LAUNCH_APP1 As Integer = 17
    Public Const APPCOMMAND_LAUNCH_APP2 As Integer = 18
    Public Const APPCOMMAND_BASS_DOWN As Integer = 19
    Public Const APPCOMMAND_BASS_BOOST As Integer = 20
    Public Const APPCOMMAND_BASS_UP As Integer = 21
    Public Const APPCOMMAND_TREBLE_DOWN As Integer = 22
    Public Const APPCOMMAND_TREBLE_UP As Integer = 23
    Public Const APPCOMMAND_MICROPHONE_VOLUME_MUTE As Integer = 24
    Public Const APPCOMMAND_MICROPHONE_VOLUME_DOWN As Integer = 25
    Public Const APPCOMMAND_MICROPHONE_VOLUME_UP As Integer = 26
    Public Const APPCOMMAND_HELP As Integer = 27
    Public Const APPCOMMAND_FIND As Integer = 28
    Public Const APPCOMMAND_NEW As Integer = -1
    Public Const APPCOMMAND_OPEN As Integer = 30
    Public Const APPCOMMAND_CLOSE As Integer = 31
    Public Const APPCOMMAND_SAVE As Integer = 32
    Public Const APPCOMMAND_PRINT As Integer = 33
    Public Const APPCOMMAND_UNDO As Integer = 34
    Public Const APPCOMMAND_REDO As Integer = 35
    Public Const APPCOMMAND_COPY As Integer = 36
    Public Const APPCOMMAND_CUT As Integer = -1
    Public Const APPCOMMAND_PASTE As Integer = 38
    Public Const APPCOMMAND_REPLY_TO_MAIL As Integer = 39
    Public Const APPCOMMAND_FORWARD_MAIL As Integer = 40
    Public Const APPCOMMAND_SEND_MAIL As Integer = 41
    Public Const APPCOMMAND_SPELL_CHECK As Integer = 42
    Public Const APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE As Integer = 43
    Public Const APPCOMMAND_MIC_ON_OFF_TOGGLE As Integer = 44
    Public Const APPCOMMAND_CORRECTION_LIST As Integer = 45
    Public Const APPCOMMAND_MEDIA_PLAY As Integer = 46
    Public Const APPCOMMAND_MEDIA_PAUSE As Integer = 47
    Public Const APPCOMMAND_MEDIA_RECORD As Integer = 48
    Public Const APPCOMMAND_MEDIA_FAST_FORWARD As Integer = 49
    Public Const APPCOMMAND_MEDIA_REWIND As Integer = 50
    Public Const APPCOMMAND_MEDIA_CHANNEL_UP As Integer = 51
    Public Const APPCOMMAND_MEDIA_CHANNEL_DOWN As Integer = 52
    Public Const APPCOMMAND_DELETE As Integer = 53
    Public Const APPCOMMAND_DWM_FLIP3D As Integer = 54
    Public Const FAPPCOMMAND_MOUSE As Integer = &H8000
    Public Const FAPPCOMMAND_KEY As Integer = &H0
    Public Const FAPPCOMMAND_OEM As Integer = &H1000
    Public Const FAPPCOMMAND_MASK As Integer = &HF000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Keyboard Layout API
    '
    '           #define HKL_PREV            0
    '           #define HKL_NEXT            1
    '           
    '           
    '           #define KLF_ACTIVATE        0x00000001
    '           #define KLF_SUBSTITUTE_OK   0x00000002
    '           #define KLF_REORDER         0x00000008
    '           #if(WINVER >= 0x0400)
    '           #define KLF_REPLACELANG     0x00000010
    '           #define KLF_NOTELLSHELL     0x00000080
    '           #endif /* WINVER >= 0x0400 */
    '           #define KLF_SETFORPROCESS   0x00000100
    '           #if(_WIN32_WINNT >= 0x0500)
    '           #define KLF_SHIFTLOCK       0x00010000
    '           #define KLF_RESET           0x40000000
    '           #endif /* _WIN32_WINNT >= 0x0500 */
    '
    '******************************************************************************
    Public Const HKL_PREV As Integer = 0
    Public Const HKL_NEXT As Integer = 1
    Public Const KLF_ACTIVATE As Integer = &H1
    Public Const KLF_SUBSTITUTE_OK As Integer = &H2
    Public Const KLF_REORDER As Integer = &H8
    Public Const KLF_REPLACELANG As Integer = &H10
    Public Const KLF_NOTELLSHELL As Integer = &H80
    Public Const KLF_SETFORPROCESS As Integer = &H100
    Public Const KLF_SHIFTLOCK As Integer = &H10000
    Public Const KLF_RESET As Integer = &H40000000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Bits in wParam of WM_INPUTLANGCHANGEREQUEST message
    '
    '           #define INPUTLANGCHANGE_SYSCHARSET 0x0001
    '           #define INPUTLANGCHANGE_FORWARD    0x0002
    '           #define INPUTLANGCHANGE_BACKWARD   0x0004
    '
    '******************************************************************************
    Public Const INPUTLANGCHANGE_SYSCHARSET As Integer = &H1
    Public Const INPUTLANGCHANGE_FORWARD As Integer = &H2
    Public Const INPUTLANGCHANGE_BACKWARD As Integer = &H4

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Desktop-specific access flags
    '
    '           #define DESKTOP_READOBJECTS         0x0001
    '           #define DESKTOP_CREATEWINDOW        0x0002
    '           #define DESKTOP_CREATEMENU          0x0004
    '           #define DESKTOP_HOOKCONTROL         0x0008
    '           #define DESKTOP_JOURNALRECORD       0x0010
    '           #define DESKTOP_JOURNALPLAYBACK     0x0020
    '           #define DESKTOP_ENUMERATE           0x0040
    '           #define DESKTOP_WRITEOBJECTS        0x0080
    '           #define DESKTOP_SWITCHDESKTOP       0x0100
    '
    '******************************************************************************
    Public Const DESKTOP_READOBJECTS As Integer = &H1
    Public Const DESKTOP_CREATEWINDOW As Integer = &H2
    Public Const DESKTOP_CREATEMENU As Integer = &H4
    Public Const DESKTOP_HOOKCONTROL As Integer = &H8
    Public Const DESKTOP_JOURNALRECORD As Integer = &H10
    Public Const DESKTOP_JOURNALPLAYBACK As Integer = &H20
    Public Const DESKTOP_ENUMERATE As Integer = &H40
    Public Const DESKTOP_WRITEOBJECTS As Integer = &H80
    Public Const DESKTOP_SWITCHDESKTOP As Integer = &H100

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Desktop-specific control flags
    '
    '           #define DF_ALLOWOTHERACCOUNTHOOK    0x0001
    '           
    '
    '******************************************************************************
    Public Const DF_ALLOWOTHERACCOUNTHOOK As Integer = &H1

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Windowstation-specific access flags
    '
    '           #define WINSTA_ENUMDESKTOPS         0x0001
    '           #define WINSTA_READATTRIBUTES       0x0002
    '           #define WINSTA_ACCESSCLIPBOARD      0x0004
    '           #define WINSTA_CREATEDESKTOP        0x0008
    '           #define WINSTA_WRITEATTRIBUTES      0x0010
    '           #define WINSTA_ACCESSGLOBALATOMS    0x0020
    '           #define WINSTA_EXITWINDOWS          0x0040
    '           #define WINSTA_ENUMERATE            0x0100
    '           #define WINSTA_READSCREEN           0x0200
    '
    '******************************************************************************
    Public Const WINSTA_ENUMDESKTOPS As Integer = &H1
    Public Const WINSTA_READATTRIBUTES As Integer = &H2
    Public Const WINSTA_ACCESSCLIPBOARD As Integer = &H4
    Public Const WINSTA_CREATEDESKTOP As Integer = &H8
    Public Const WINSTA_WRITEATTRIBUTES As Integer = &H10
    Public Const WINSTA_ACCESSGLOBALATOMS As Integer = &H20
    Public Const WINSTA_EXITWINDOWS As Integer = &H40
    Public Const WINSTA_ENUMERATE As Integer = &H100
    Public Const WINSTA_READSCREEN As Integer = &H200

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Window Messages
    '
    '           #define WM_NULL                         0x0000
    '           #define WM_CREATE                       0x0001
    '           #define WM_DESTROY                      0x0002
    '           #define WM_MOVE                         0x0003
    '           #define WM_SIZE                         0x0005
    '           
    '           #define WM_ACTIVATE                     0x0006
    '
    '******************************************************************************
    Public Const WM_NULL As Integer = &H0
    Public Const WM_CREATE As Integer = &H1
    Public Const WM_DESTROY As Integer = &H2
    Public Const WM_MOVE As Integer = &H3
    Public Const WM_SIZE As Integer = &H5
    Public Const WM_ACTIVATE As Integer = &H6

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Windows Message
    '
    '
    '******************************************************************************
    Public Const WM_SETFOCUS As Integer = &H7
    Public Const WM_KILLFOCUS As Integer = &H8
    Public Const WM_ENABLE As Integer = &HA
    Public Const WM_SETREDRAW As Integer = &HB
    Public Const WM_SETTEXT As Integer = &HC
    Public Const WM_GETTEXT As Integer = &HD
    Public Const WM_GETTEXTLENGTH As Integer = &HE
    Public Const WM_PAINT As Integer = &HF
    Public Const WM_CLOSE As Integer = &H10
    Public Const WM_QUERYENDSESSION As Integer = &H11
    Public Const WM_QUERYOPEN As Integer = &H13
    Public Const WM_ENDSESSION As Integer = &H16
    Public Const WM_QUIT As Integer = &H12
    Public Const WM_ERASEBKGND As Integer = &H14
    Public Const WM_SYSCOLORCHANGE As Integer = &H15
    Public Const WM_SHOWWINDOW As Integer = &H18
    Public Const WM_WININICHANGE As Integer = &H1A
    Public Const WA_INACTIVE As Integer = 0
    Public Const WA_ACTIVE As Integer = 1
    Public Const WA_CLICKACTIVE As Integer = 2
    Public Const WM_DEVMODECHANGE As Integer = &H1B
    Public Const WM_ACTIVATEAPP As Integer = &H1C
    Public Const WM_FONTCHANGE As Integer = &H1D
    Public Const WM_TIMECHANGE As Integer = &H1E
    Public Const WM_CANCELMODE As Integer = &H1F
    Public Const WM_SETCURSOR As Integer = &H20
    Public Const WM_MOUSEACTIVATE As Integer = &H21
    Public Const WM_CHILDACTIVATE As Integer = &H22
    Public Const WM_QUEUESYNC As Integer = &H23
    Public Const WM_GETMINMAXINFO As Integer = &H24
    Public Const WM_PAINTICON As Integer = &H26
    Public Const WM_ICONERASEBKGND As Integer = &H27
    Public Const WM_NEXTDLGCTL As Integer = &H28
    Public Const WM_SPOOLERSTATUS As Integer = &H2A
    Public Const WM_DRAWITEM As Integer = &H2B
    Public Const WM_MEASUREITEM As Integer = &H2C
    Public Const WM_DELETEITEM As Integer = &H2D
    Public Const WM_VKEYTOITEM As Integer = &H2E
    Public Const WM_CHARTOITEM As Integer = &H2F
    Public Const WM_SETFONT As Integer = &H30
    Public Const WM_GETFONT As Integer = &H31
    Public Const WM_SETHOTKEY As Integer = &H32
    Public Const WM_GETHOTKEY As Integer = &H33
    Public Const WM_QUERYDRAGICON As Integer = &H37
    Public Const WM_COMPAREITEM As Integer = &H39
    Public Const WM_GETOBJECT As Integer = &H3D
    Public Const WM_COMPACTING As Integer = &H41
    Public Const WM_COMMNOTIFY As Integer = &H44
    Public Const WM_WINDOWPOSCHANGING As Integer = &H46
    Public Const WM_WINDOWPOSCHANGED As Integer = &H47
    Public Const WM_POWER As Integer = &H48
    Public Const WM_CONTEXTMENU As Integer = &H7B
    Public Const WM_STYLECHANGING As Integer = &H7C
    Public Const WM_STYLECHANGED As Integer = &H7D
    Public Const WM_DISPLAYCHANGE As Integer = &H7E
    Public Const WM_GETICON As Integer = &H7F
    Public Const WM_SETICON As Integer = &H80
    Public Const WM_NCCREATE As Integer = &H81
    Public Const WM_NCDESTROY As Integer = &H82
    Public Const WM_NCCALCSIZE As Integer = &H83
    Public Const WM_NCHITTEST As Integer = &H84
    Public Const WM_NCPAINT As Integer = &H85
    Public Const WM_NCACTIVATE As Integer = &H86
    Public Const WM_GETDLGCODE As Integer = &H87
    Public Const WM_SYNCPAINT As Integer = &H88
    Public Const WM_NCMOUSEMOVE As Integer = &HA0
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const WM_NCLBUTTONUP As Integer = &HA2
    Public Const WM_NCLBUTTONDBLCLK As Integer = &HA3
    Public Const WM_NCRBUTTONDOWN As Integer = &HA4
    Public Const WM_NCRBUTTONUP As Integer = &HA5
    Public Const WM_NCRBUTTONDBLCLK As Integer = &HA6
    Public Const WM_NCMBUTTONDOWN As Integer = &HA7
    Public Const WM_NCMBUTTONUP As Integer = &HA8
    Public Const WM_NCMBUTTONDBLCLK As Integer = &HA9
    Public Const WM_NCXBUTTONDOWN As Integer = &HAB
    Public Const WM_NCXBUTTONUP As Integer = &HAC
    Public Const WM_NCXBUTTONDBLCLK As Integer = &HAD
    Public Const WM_INPUT_DEVICE_CHANGE As Integer = &HFE
    Public Const WM_INPUT As Integer = &HFF
    Public Const WM_KEYFIRST As Integer = &H100
    Public Const WM_KEYDOWN As Integer = &H100
    Public Const WM_KEYUP As Integer = &H101
    Public Const WM_CHAR As Integer = &H102
    Public Const WM_DEADCHAR As Integer = &H103
    Public Const WM_SYSKEYDOWN As Integer = &H104
    Public Const WM_SYSKEYUP As Integer = &H105
    Public Const WM_SYSCHAR As Integer = &H106
    Public Const WM_SYSDEADCHAR As Integer = &H107
    Public Const WM_UNICHAR As Integer = &H109
    Public Const WM_KEYLAST As Integer = &H109
    Public Const UNICODE_NOCHAR As Integer = &HFFFF
    Public Const WM_IME_STARTCOMPOSITION As Integer = &H10D
    Public Const WM_IME_ENDCOMPOSITION As Integer = &H10E
    Public Const WM_IME_COMPOSITION As Integer = &H10F
    Public Const WM_IME_KEYLAST As Integer = &H10F
    Public Const WM_INITDIALOG As Integer = &H110
    Public Const WM_COMMAND As Integer = &H111
    Public Const WM_SYSCOMMAND As Integer = &H112
    Public Const WM_TIMER As Integer = &H113
    Public Const WM_HSCROLL As Integer = &H114
    Public Const WM_VSCROLL As Integer = &H115
    Public Const WM_INITMENU As Integer = &H116
    Public Const WM_INITMENUPOPUP As Integer = &H117
    Public Const WM_GESTURE As Integer = &H119
    Public Const WM_GESTURENOTIFY As Integer = &H11A
    Public Const WM_MENUSELECT As Integer = &H11F
    Public Const WM_MENUCHAR As Integer = &H120
    Public Const WM_ENTERIDLE As Integer = &H121
    Public Const WM_MENURBUTTONUP As Integer = &H122
    Public Const WM_MENUDRAG As Integer = &H123
    Public Const WM_MENUGETOBJECT As Integer = &H124
    Public Const WM_UNINITMENUPOPUP As Integer = &H125
    Public Const WM_MENUCOMMAND As Integer = &H126
    Public Const WM_CHANGEUISTATE As Integer = &H127
    Public Const WM_UPDATEUISTATE As Integer = &H128
    Public Const WM_QUERYUISTATE As Integer = &H129
    Public Const WM_NOTIFY As Integer = &H4E
    Public Const WM_INPUTLANGCHANGEREQUEST As Integer = &H50
    Public Const WM_INPUTLANGCHANGE As Integer = &H51
    Public Const WM_TCARD As Integer = &H52
    Public Const WM_HELP As Integer = &H53
    Public Const WM_USERCHANGED As Integer = &H54
    Public Const WM_NOTIFYFORMAT As Integer = &H55
    Public Const WM_COPYDATA As Integer = &H4A
    Public Const WM_CANCELJOURNAL As Integer = &H4B
    Public Const NFR_ANSI As Integer = 1
    Public Const NFR_UNICODE As Integer = 2
    Public Const NF_QUERY As Integer = 3
    Public Const NF_REQUERY As Integer = 4
    Public Const WM_CTLCOLORMSGBOX As Integer = &H132
    Public Const WM_CTLCOLOREDIT As Integer = &H133
    Public Const WM_CTLCOLORLISTBOX As Integer = &H134
    Public Const WM_CTLCOLORBTN As Integer = &H135
    Public Const WM_CTLCOLORDLG As Integer = &H136
    Public Const WM_CTLCOLORSCROLLBAR As Integer = &H137
    Public Const WM_CTLCOLORSTATIC As Integer = &H138
    Public Const MN_GETHMENU As Integer = &H1E1
    Public Const WM_MOUSEFIRST As Integer = &H200
    Public Const WM_MOUSEMOVE As Integer = &H200
    Public Const WM_LBUTTONDOWN As Integer = &H201
    Public Const WM_LBUTTONUP As Integer = &H202
    Public Const WM_LBUTTONDBLCLK As Integer = &H203
    Public Const WM_RBUTTONDOWN As Integer = &H204
    Public Const WM_RBUTTONUP As Integer = &H205
    Public Const WM_RBUTTONDBLCLK As Integer = &H206
    Public Const WM_MBUTTONDOWN As Integer = &H207
    Public Const WM_MBUTTONUP As Integer = &H208
    Public Const WM_MBUTTONDBLCLK As Integer = &H209
    Public Const WM_MOUSEWHEEL As Integer = &H20A
    Public Const WM_XBUTTONDOWN As Integer = &H20B
    Public Const WM_XBUTTONUP As Integer = &H20C
    Public Const WM_XBUTTONDBLCLK As Integer = &H20D
    Public Const WM_MOUSEHWHEEL As Integer = &H20E
    Public Const WM_MOUSELAST As Integer = &H20E
    Public Const WHEEL_DELTA As Integer = 120
    Public Const XBUTTON1 As Integer = &H1
    Public Const XBUTTON2 As Integer = &H2
    Public Const WM_PARENTNOTIFY As Integer = &H210
    Public Const WM_ENTERMENULOOP As Integer = &H211
    Public Const WM_EXITMENULOOP As Integer = &H212
    Public Const WM_NEXTMENU As Integer = &H213
    Public Const WM_SIZING As Integer = &H214
    Public Const WM_CAPTURECHANGED As Integer = &H215
    Public Const WM_MOVING As Integer = &H216
    Public Const WM_POWERBROADCAST As Integer = &H218
    Public Const PBT_APMQUERYSUSPEND As Integer = &H0
    Public Const PBT_APMQUERYSTANDBY As Integer = &H1
    Public Const PBT_APMQUERYSUSPENDFAILED As Integer = &H2
    Public Const PBT_APMQUERYSTANDBYFAILED As Integer = &H3
    Public Const PBT_APMSUSPEND As Integer = &H4
    Public Const PBT_APMSTANDBY As Integer = &H5
    Public Const PBT_APMRESUMECRITICAL As Integer = &H6
    Public Const PBT_APMRESUMESUSPEND As Integer = &H7
    Public Const PBT_APMRESUMESTANDBY As Integer = &H8
    Public Const PBTF_APMRESUMEFROMFAILURE As Integer = &H1
    Public Const PBT_APMBATTERYLOW As Integer = &H9
    Public Const PBT_APMPOWERSTATUSCHANGE As Integer = &HA
    Public Const PBT_APMOEMEVENT As Integer = &HB
    Public Const PBT_APMRESUMEAUTOMATIC As Integer = &H12
    Public Const PBT_POWERSETTINGCHANGE As Integer = &H8013
    Public Const WM_DEVICECHANGE As Integer = &H219
    Public Const WM_MDICREATE As Integer = &H220
    Public Const WM_MDIDESTROY As Integer = &H221
    Public Const WM_MDIACTIVATE As Integer = &H222
    Public Const WM_MDIRESTORE As Integer = &H223
    Public Const WM_MDINEXT As Integer = &H224
    Public Const WM_MDIMAXIMIZE As Integer = &H225
    Public Const WM_MDITILE As Integer = &H226
    Public Const WM_MDICASCADE As Integer = &H227
    Public Const WM_MDIICONARRANGE As Integer = &H228
    Public Const WM_MDIGETACTIVE As Integer = &H229
    Public Const WM_MDISETMENU As Integer = &H230
    Public Const WM_ENTERSIZEMOVE As Integer = &H231
    Public Const WM_EXITSIZEMOVE As Integer = &H232
    Public Const WM_DROPFILES As Integer = &H233
    Public Const WM_MDIREFRESHMENU As Integer = &H234
    Public Const WM_POINTERDEVICECHANGE As Integer = &H238
    Public Const WM_POINTERDEVICEINRANGE As Integer = &H239
    Public Const WM_POINTERDEVICEOUTOFRANGE As Integer = &H23A
    Public Const WM_TOUCH As Integer = &H240
    Public Const WM_NCPOINTERUPDATE As Integer = &H241
    Public Const WM_NCPOINTERDOWN As Integer = &H242
    Public Const WM_NCPOINTERUP As Integer = &H243
    Public Const WM_POINTERUPDATE As Integer = &H245
    Public Const WM_POINTERDOWN As Integer = &H246
    Public Const WM_POINTERUP As Integer = &H247
    Public Const WM_POINTERENTER As Integer = &H249
    Public Const WM_POINTERLEAVE As Integer = &H24A
    Public Const WM_POINTERACTIVATE As Integer = &H24B
    Public Const WM_POINTERCAPTURECHANGED As Integer = &H24C
    Public Const WM_TOUCHHITTESTING As Integer = &H24D
    Public Const WM_POINTERWHEEL As Integer = &H24E
    Public Const WM_POINTERHWHEEL As Integer = &H24F
    Public Const WM_IME_SETCONTEXT As Integer = &H281
    Public Const WM_IME_NOTIFY As Integer = &H282
    Public Const WM_IME_CONTROL As Integer = &H283
    Public Const WM_IME_COMPOSITIONFULL As Integer = &H284
    Public Const WM_IME_SELECT As Integer = &H285
    Public Const WM_IME_CHAR As Integer = &H286
    Public Const WM_IME_REQUEST As Integer = &H288
    Public Const WM_IME_KEYDOWN As Integer = &H290
    Public Const WM_IME_KEYUP As Integer = &H291
    Public Const WM_MOUSEHOVER As Integer = &H2A1
    Public Const WM_MOUSELEAVE As Integer = &H2A3
    Public Const WM_NCMOUSEHOVER As Integer = &H2A0
    Public Const WM_NCMOUSELEAVE As Integer = &H2A2
    Public Const WM_WTSSESSION_CHANGE As Integer = &H2B1
    Public Const WM_TABLET_FIRST As Integer = &H2C0
    Public Const WM_TABLET_LAST As Integer = &H2DF
    Public Const WM_CUT As Integer = &H300
    Public Const WM_COPY As Integer = &H301
    Public Const WM_PASTE As Integer = &H302
    Public Const WM_CLEAR As Integer = &H303
    Public Const WM_UNDO As Integer = &H304
    Public Const WM_RENDERFORMAT As Integer = &H305
    Public Const WM_RENDERALLFORMATS As Integer = &H306
    Public Const WM_DESTROYCLIPBOARD As Integer = &H307
    Public Const WM_DRAWCLIPBOARD As Integer = &H308
    Public Const WM_PAINTCLIPBOARD As Integer = &H309
    Public Const WM_VSCROLLCLIPBOARD As Integer = &H30A
    Public Const WM_SIZECLIPBOARD As Integer = &H30B
    Public Const WM_ASKCBFORMATNAME As Integer = &H30C
    Public Const WM_CHANGECBCHAIN As Integer = &H30D
    Public Const WM_HSCROLLCLIPBOARD As Integer = &H30E
    Public Const WM_QUERYNEWPALETTE As Integer = &H30F
    Public Const WM_PALETTEISCHANGING As Integer = &H310
    Public Const WM_PALETTECHANGED As Integer = &H311
    Public Const WM_HOTKEY As Integer = &H312
    Public Const WM_PRINT As Integer = &H317
    Public Const WM_PRINTCLIENT As Integer = &H318
    Public Const WM_APPCOMMAND As Integer = &H319
    Public Const WM_THEMECHANGED As Integer = &H31A
    Public Const WM_CLIPBOARDUPDATE As Integer = &H31D
    Public Const WM_DWMCOMPOSITIONCHANGED As Integer = &H31E
    Public Const WM_DWMNCRENDERINGCHANGED As Integer = &H31F
    Public Const WM_DWMCOLORIZATIONCOLORCHANGED As Integer = &H320
    Public Const WM_DWMWINDOWMAXIMIZEDCHANGE As Integer = &H321
    Public Const WM_DWMSENDICONICTHUMBNAIL As Integer = &H323
    Public Const WM_DWMSENDICONICLIVEPREVIEWBITMAP As Integer = &H326
    Public Const WM_GETTITLEBARINFOEX As Integer = &H33F
    Public Const WM_HANDHELDFIRST As Integer = &H358
    Public Const WM_HANDHELDLAST As Integer = &H35F
    Public Const WM_AFXFIRST As Integer = &H360
    Public Const WM_AFXLAST As Integer = &H37F
    Public Const WM_PENWINFIRST As Integer = &H380
    Public Const WM_PENWINLAST As Integer = &H38F
    Public Const WM_APP As Integer = &H8000
    Public Const WS_OVERLAPPED As Integer = &H0
    Public Const WS_POPUP As Integer = &H80000000
    Public Const WS_CHILD As Integer = &H40000000
    Public Const WS_MINIMIZE As Integer = &H20000000
    Public Const WS_VISIBLE As Integer = &H10000000
    Public Const WS_DISABLED As Integer = &H8000000
    Public Const WS_CLIPSIBLINGS As Integer = &H4000000
    Public Const WS_CLIPCHILDREN As Integer = &H2000000
    Public Const WS_MAXIMIZE As Integer = &H1000000
    Public Const WS_CAPTION As Integer = &HC00000
    Public Const WS_BORDER As Integer = &H800000
    Public Const WS_DLGFRAME As Integer = &H400000
    Public Const WS_VSCROLL As Integer = &H200000
    Public Const WS_HSCROLL As Integer = &H100000
    Public Const WS_SYSMENU As Integer = &H80000
    Public Const WS_THICKFRAME As Integer = &H40000
    Public Const WS_GROUP As Integer = &H20000
    Public Const WS_TABSTOP As Integer = &H10000
    Public Const WS_MINIMIZEBOX As Integer = &H20000
    Public Const WS_MAXIMIZEBOX As Integer = &H10000
    Public Const WS_EX_DLGMODALFRAME As Integer = &H1
    Public Const WS_EX_NOPARENTNOTIFY As Integer = &H4
    Public Const WS_EX_TOPMOST As Integer = &H8
    Public Const WS_EX_ACCEPTFILES As Integer = &H10
    Public Const WS_EX_TRANSPARENT As Integer = &H20
    Public Const WS_EX_MDICHILD As Integer = &H40
    Public Const WS_EX_TOOLWINDOW As Integer = &H80
    Public Const WS_EX_WINDOWEDGE As Integer = &H100
    Public Const WS_EX_CLIENTEDGE As Integer = &H200
    Public Const WS_EX_CONTEXTHELP As Integer = &H400
    Public Const WS_EX_RIGHT As Integer = &H1000
    Public Const WS_EX_LEFT As Integer = &H0
    Public Const WS_EX_RTLREADING As Integer = &H2000
    Public Const WS_EX_LTRREADING As Integer = &H0
    Public Const WS_EX_LEFTSCROLLBAR As Integer = &H4000
    Public Const WS_EX_RIGHTSCROLLBAR As Integer = &H0
    Public Const WS_EX_CONTROLPARENT As Integer = &H10000
    Public Const WS_EX_STATICEDGE As Integer = &H20000
    Public Const WS_EX_APPWINDOW As Integer = &H40000
    Public Const WS_EX_LAYERED As Integer = &H80000
    Public Const WS_EX_NOINHERITLAYOUT As Integer = &H100000
    Public Const WS_EX_NOREDIRECTIONBITMAP As Integer = &H200000
    Public Const WS_EX_LAYOUTRTL As Integer = &H400000
    Public Const WS_EX_COMPOSITED As Integer = &H2000000
    Public Const WS_EX_NOACTIVATE As Integer = &H8000000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           wParam for WM_POWER window message and DRV_POWER driver notification
    '
    '           #define PWR_OK              1
    '           #define PWR_SUSPENDREQUEST  1
    '           #define PWR_SUSPENDRESUME   2
    '           #define PWR_CRITICALRESUME  3
    '
    '******************************************************************************
    Public Const PWR_SUSPENDREQUEST As Integer = 1
    Public Const PWR_OK As Integer = 1
    Public Const PWR_FAIL As Integer = -1
    Public Const PWR_SUSPENDRESUME As Integer = 2
    Public Const PWR_CRITICALRESUME As Integer = 3


    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           LOWORD(wParam) values in WM_*UISTATE*
    '
    '           #define UIS_SET          1
    '           #define UIS_CLEAR            2
    '           #define UIS_INITIALIZE         3
    '           
    '
    '******************************************************************************
    Public Const UIS_SET As Integer = 1
    Public Const UIS_CLEAR As Integer = 2
    Public Const UIS_INITIALIZE As Integer = 3

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           HIWORD(wParam) values in WM_*UISTATE*
    '
    '           #define UISF_HIDEFOCUS                  0x1
    '           #define UISF_HIDEACCEL                  0x2
    '           #if(_WIN32_WINNT >= 0x0501)
    '           #define UISF_ACTIVE                     0x4
    '
    '******************************************************************************
    Public Const UISF_HIDEFOCUS As Integer = &H1
    Public Const UISF_HIDEACCEL As Integer = &H2
    Public Const UISF_ACTIVE As Integer = &H4

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           wParam for WM_SIZING message
    '
    '           #define WMSZ_LEFT           1
    '           #define WMSZ_RIGHT          2
    '           #define WMSZ_TOP            3
    '           #define WMSZ_TOPLEFT        4
    '           #define WMSZ_TOPRIGHT       5
    '           #define WMSZ_BOTTOM         6
    '           #define WMSZ_BOTTOMLEFT     7
    '           #define WMSZ_BOTTOMRIGHT    8
    '
    '******************************************************************************
    Public Const WMSZ_LEFT As Integer = 1
    Public Const WMSZ_RIGHT As Integer = 2
    Public Const WMSZ_TOP As Integer = 3
    Public Const WMSZ_TOPLEFT As Integer = 4
    Public Const WMSZ_TOPRIGHT As Integer = 5
    Public Const WMSZ_BOTTOM As Integer = 6
    Public Const WMSZ_BOTTOMLEFT As Integer = 7
    Public Const WMSZ_BOTTOMRIGHT As Integer = 8

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WM_NCHITTEST and MOUSEHOOKSTRUCT Mouse Position Codes
    '
    '           #define HTOBJECT            19
    '           #define HTCLOSE             20
    '           #define HTHELP              21
    '           #define HTMENU              5
    '           #define HTHSCROLL           6
    '           #define HTVSCROLL           7
    '           #define HTMINBUTTON         8
    '           #define HTMAXBUTTON         9
    '           #define HTLEFT              10
    '           #define HTRIGHT             11
    '           #define HTTOP               12
    '           #define HTTOPLEFT           13
    '           #define HTTOPRIGHT          14
    '           #define HTBOTTOM            15
    '           #define HTBOTTOMLEFT        16
    '           #define HTBOTTOMRIGHT       17
    '           #define HTBORDER            18
    '           #define HTNOWHERE           0
    '           #define HTCLIENT            1
    '           #define HTCAPTION           2
    '           #define HTSYSMENU           3
    '           #define HTGROWBOX           4
    '           #define HTERROR             -2
    '           #define HTTRANSPARENT       -1
    '
    '******************************************************************************
    Public Const HTOBJECT As Integer = 19
    Public Const HTCLOSE As Integer = 20
    Public Const HTHELP As Integer = 21
    Public Const HTMENU As Integer = 5
    Public Const HTHSCROLL As Integer = 6
    Public Const HTVSCROLL As Integer = 7
    Public Const HTMINBUTTON As Integer = 8
    Public Const HTMAXBUTTON As Integer = 9
    Public Const HTLEFT As Integer = 10
    Public Const HTRIGHT As Integer = 11
    Public Const HTTOP As Integer = 12
    Public Const HTTOPLEFT As Integer = 13
    Public Const HTTOPRIGHT As Integer = 14
    Public Const HTBOTTOM As Integer = 15
    Public Const HTBOTTOMLEFT As Integer = 16
    Public Const HTBOTTOMRIGHT As Integer = 17
    Public Const HTBORDER As Integer = 18
    Public Const HTNOWHERE As Integer = 0
    Public Const HTCLIENT As Integer = 1
    Public Const HTCAPTION As Integer = 2
    Public Const HTSYSMENU As Integer = 3
    Public Const HTGROWBOX As Integer = 4
    Public Const HTERROR As Integer = -2
    Public Const HTTRANSPARENT As Integer = -1

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           SendMessageTimeout values
    '
    '******************************************************************************
    Public Const SMTO_NORMAL As Integer = &H0
    Public Const SMTO_BLOCK As Integer = &H1
    Public Const SMTO_ABORTIFHUNG As Integer = &H2
    Public Const SMTO_NOTIMEOUTIFNOTHUNG As Integer = &H8
    Public Const SMTO_ERRORONEXIT As Integer = &H20

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WM_MOUSEACTIVATE Return Codes
    '
    '           #define MA_ACTIVATE         1
    '           #define MA_ACTIVATEANDEAT   2
    '           #define MA_NOACTIVATE       3
    '           #define MA_NOACTIVATEANDEAT 4
    '
    '******************************************************************************
    Public Const MA_ACTIVATE As Integer = 1
    Public Const MA_ACTIVATEANDEAT As Integer = 2
    Public Const MA_NOACTIVATE As Integer = 3
    Public Const MA_NOACTIVATEANDEAT As Integer = 4

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WM_SETICON / WM_GETICON Type Codes
    '
    '           #define ICON_SMALL          0
    '           #define ICON_BIG            1
    '           #define ICON_SMALL2         2
    '
    '******************************************************************************
    Public Const ICON_SMALL As Integer = 0
    Public Const ICON_BIG As Integer = 1
    Public Const ICON_SMALL2 As Integer = 2

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WM_SIZE message wParam values
    '
    '           #define SIZE_RESTORED       0
    '           #define SIZE_MINIMIZED      1
    '           #define SIZE_MAXIMIZED      2
    '           #define SIZE_MAXSHOW        3
    '           #define SIZE_MAXHIDE        4
    '
    '******************************************************************************
    Public Const SIZE_RESTORED As Integer = 0
    Public Const SIZE_MINIMIZED As Integer = 1
    Public Const SIZE_MAXIMIZED As Integer = 2
    Public Const SIZE_MAXSHOW As Integer = 3
    Public Const SIZE_MAXHIDE As Integer = 4

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WM_NCCALCSIZE "window valid rect" return values
    '
    '           #define WVR_ALIGNTOP        0x0010
    '           #define WVR_ALIGNLEFT       0x0020
    '           #define WVR_ALIGNBOTTOM     0x0040
    '           #define WVR_ALIGNRIGHT      0x0080
    '           #define WVR_HREDRAW         0x0100
    '           #define WVR_VREDRAW         0x0200
    '
    '******************************************************************************
    Public Const WVR_ALIGNTOP As Integer = &H10
    Public Const WVR_ALIGNLEFT As Integer = &H20
    Public Const WVR_ALIGNBOTTOM As Integer = &H40
    Public Const WVR_ALIGNRIGHT As Integer = &H80
    Public Const WVR_HREDRAW As Integer = &H100
    Public Const WVR_VREDRAW As Integer = &H200
    Public Const WVR_REDRAW As Integer = &H300
    Public Const WVR_VALIDRECTS As Integer = &H400

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Key State Masks for Mouse Messages
    '
    '           #define MK_LBUTTON          0x0001
    '           #define MK_RBUTTON          0x0002
    '           #define MK_SHIFT            0x0004
    '           #define MK_CONTROL          0x0008
    '           #define MK_MBUTTON          0x0010
    '           #if(_WIN32_WINNT >= 0x0500)
    '           #define MK_XBUTTON1         0x0020
    '           #define MK_XBUTTON2         0x0040
    '
    '******************************************************************************
    Public Const MK_LBUTTON As Integer = &H1
    Public Const MK_RBUTTON As Integer = &H2
    Public Const MK_SHIFT As Integer = &H4
    Public Const MK_CONTROL As Integer = &H8
    Public Const MK_MBUTTON As Integer = &H10
    Public Const MK_XBUTTON1 As Integer = &H20
    Public Const MK_XBUTTON2 As Integer = &H40
    Public Const TME_HOVER As Integer = &H1
    Public Const TME_LEAVE As Integer = &H2
    Public Const TME_NONCLIENT As Integer = &H10
    Public Const TME_QUERY As Integer = &H40000000
    Public Const TME_CANCEL As Integer = &H80000000
    Public Const HOVER_DEFAULT As Integer = &HFFFFFFFF

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Class styles
    '
    '           #define CS_VREDRAW          0x0001
    '           #define CS_HREDRAW          0x0002
    '           #define CS_DBLCLKS          0x0008
    '           #define CS_OWNDC            0x0020
    '           #define CS_CLASSDC          0x0040
    '           #define CS_PARENTDC         0x0080
    '           #define CS_NOCLOSE          0x0200
    '           #define CS_SAVEBITS         0x0800
    '           #define CS_BYTEALIGNCLIENT  0x1000
    '           #define CS_BYTEALIGNWINDOW  0x2000
    '           #define CS_GLOBALCLASS      0x4000
    '           
    '           #define CS_IME              0x00010000
    '           #if(_WIN32_WINNT >= 0x0501)
    '           #define CS_DROPSHADOW       0x00020000
    '
    '******************************************************************************
    Public Const CS_VREDRAW As Integer = &H1
    Public Const CS_HREDRAW As Integer = &H2
    Public Const CS_DBLCLKS As Integer = &H8
    Public Const CS_OWNDC As Integer = &H20
    Public Const CS_CLASSDC As Integer = &H40
    Public Const CS_PARENTDC As Integer = &H80
    Public Const CS_NOCLOSE As Integer = &H200
    Public Const CS_SAVEBITS As Integer = &H800
    Public Const CS_BYTEALIGNCLIENT As Integer = &H1000
    Public Const CS_BYTEALIGNWINDOW As Integer = &H2000
    Public Const CS_GLOBALCLASS As Integer = &H4000
    Public Const CS_IME As Integer = &H10000
    Public Const CS_DROPSHADOW As Integer = &H20000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WM_PRINT flags
    '
    '           #define PRF_CHECKVISIBLE    0x00000001
    '           #define PRF_NONCLIENT       0x00000002
    '           #define PRF_CLIENT          0x00000004
    '           #define PRF_ERASEBKGND      0x00000008
    '           #define PRF_CHILDREN        0x00000010
    '           #define PRF_OWNED           0x00000020
    '
    '******************************************************************************
    Public Const PRF_CHECKVISIBLE As Integer = &H1
    Public Const PRF_NONCLIENT As Integer = &H2
    Public Const PRF_CLIENT As Integer = &H4
    Public Const PRF_ERASEBKGND As Integer = &H8
    Public Const PRF_CHILDREN As Integer = &H10
    Public Const PRF_OWNED As Integer = &H20

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           3D border styles
    '
    '           #define BDR_RAISEDOUTER 0x0001
    '           #define BDR_SUNKENOUTER 0x0002
    '           #define BDR_RAISEDINNER 0x0004
    '           #define BDR_SUNKENINNER 0x0008
    '           
    '           #define BDR_OUTER       (BDR_RAISEDOUTER | BDR_SUNKENOUTER)
    '           #define BDR_INNER       (BDR_RAISEDINNER | BDR_SUNKENINNER)
    '           #define BDR_RAISED      (BDR_RAISEDOUTER | BDR_RAISEDINNER)
    '           #define BDR_SUNKEN      (BDR_SUNKENOUTER | BDR_SUNKENINNER)
    '           
    '           
    '           #define EDGE_RAISED     (BDR_RAISEDOUTER | BDR_RAISEDINNER)
    '           #define EDGE_SUNKEN     (BDR_SUNKENOUTER | BDR_SUNKENINNER)
    '           #define EDGE_ETCHED     (BDR_SUNKENOUTER | BDR_RAISEDINNER)
    '           #define EDGE_BUMP       (BDR_RAISEDOUTER | BDR_SUNKENINNER)
    '
    '******************************************************************************
    Public Const BDR_RAISEDOUTER As Integer = &H1
    Public Const BDR_SUNKENOUTER As Integer = &H2
    Public Const BDR_RAISEDINNER As Integer = &H4
    Public Const BDR_SUNKENINNER As Integer = &H8

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Border flags
    '
    '           #define BF_LEFT         0x0001
    '           #define BF_TOP          0x0002
    '           #define BF_RIGHT        0x0004
    '           #define BF_BOTTOM       0x0008
    '           
    '           #define BF_TOPLEFT      (BF_TOP | BF_LEFT)
    '           #define BF_TOPRIGHT     (BF_TOP | BF_RIGHT)
    '           #define BF_BOTTOMLEFT   (BF_BOTTOM | BF_LEFT)
    '           #define BF_BOTTOMRIGHT  (BF_BOTTOM | BF_RIGHT)
    '           #define BF_RECT         (BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM)
    '           
    '           #define BF_DIAGONAL     0x0010
    '
    '******************************************************************************
    Public Const BF_LEFT As Integer = &H1
    Public Const BF_TOP As Integer = &H2
    Public Const BF_RIGHT As Integer = &H4
    Public Const BF_BOTTOM As Integer = &H8
    Public Const BF_DIAGONAL As Integer = &H10
    Public Const BF_MIDDLE As Integer = &H800
    Public Const BF_SOFT As Integer = &H1000
    Public Const BF_ADJUST As Integer = &H2000
    Public Const BF_FLAT As Integer = &H4000
    Public Const BF_MONO As Integer = &H8000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           flags for DrawFrameControl
    '
    '           #define DFC_CAPTION             1
    '           #define DFC_MENU                2
    '           #define DFC_SCROLL              3
    '           #define DFC_BUTTON              4
    '           #if(WINVER >= 0x0500)
    '           #define DFC_POPUPMENU           5
    '           #endif /* WINVER >= 0x0500 */
    '           
    '           #define DFCS_CAPTIONCLOSE       0x0000
    '           #define DFCS_CAPTIONMIN         0x0001
    '           #define DFCS_CAPTIONMAX         0x0002
    '           #define DFCS_CAPTIONRESTORE     0x0003
    '           #define DFCS_CAPTIONHELP        0x0004
    '           
    '           #define DFCS_MENUARROW          0x0000
    '           #define DFCS_MENUCHECK          0x0001
    '           #define DFCS_MENUBULLET         0x0002
    '           #define DFCS_MENUARROWRIGHT     0x0004
    '           #define DFCS_SCROLLUP           0x0000
    '           #define DFCS_SCROLLDOWN         0x0001
    '           #define DFCS_SCROLLLEFT         0x0002
    '           #define DFCS_SCROLLRIGHT        0x0003
    '           #define DFCS_SCROLLCOMBOBOX     0x0005
    '           #define DFCS_SCROLLSIZEGRIP     0x0008
    '           #define DFCS_SCROLLSIZEGRIPRIGHT 0x0010
    '           
    '           #define DFCS_BUTTONCHECK        0x0000
    '           #define DFCS_BUTTONRADIOIMAGE   0x0001
    '           #define DFCS_BUTTONRADIOMASK    0x0002
    '           #define DFCS_BUTTONRADIO        0x0004
    '           #define DFCS_BUTTON3STATE       0x0008
    '           #define DFCS_BUTTONPUSH         0x0010
    '           
    '           #define DFCS_INACTIVE           0x0100
    '           #define DFCS_PUSHED             0x0200
    '           #define DFCS_CHECKED            0x0400
    '           
    '           #if(WINVER >= 0x0500)
    '           #define DFCS_TRANSPARENT        0x0800
    '           #define DFCS_HOT                0x1000
    '           #endif /* WINVER >= 0x0500 */
    '           
    '           #define DFCS_ADJUSTRECT         0x2000
    '           #define DFCS_FLAT               0x4000
    '           #define DFCS_MONO               0x8000
    '
    '******************************************************************************
    Public Const DFC_CAPTION As Integer = &H1
    Public Const DFC_MENU As Integer = &H2
    Public Const DFC_SCROLL As Integer = &H3
    Public Const DFC_BUTTON As Integer = &H4
    Public Const DFC_POPUPMENU As Integer = &H5
    Public Const DFCS_CAPTIONCLOSE As Integer = &H0
    Public Const DFCS_CAPTIONMIN As Integer = &H1
    Public Const DFCS_CAPTIONMAX As Integer = &H2
    Public Const DFCS_CAPTIONRESTORE As Integer = &H3
    Public Const DFCS_CAPTIONHELP As Integer = &H4
    Public Const DFCS_MENUARROW As Integer = &H0
    Public Const DFCS_MENUCHECK As Integer = &H1
    Public Const DFCS_MENUBULLET As Integer = &H2
    Public Const DFCS_MENUARROWRIGHT As Integer = &H4
    Public Const DFCS_SCROLLUP As Integer = &H0
    Public Const DFCS_SCROLLDOWN As Integer = &H1
    Public Const DFCS_SCROLLLEFT As Integer = &H2
    Public Const DFCS_SCROLLRIGHT As Integer = &H3
    Public Const DFCS_SCROLLCOMBOBOX As Integer = &H5
    Public Const DFCS_SCROLLSIZEGRIP As Integer = &H8
    Public Const DFCS_SCROLLSIZEGRIPRIGHT As Integer = &H10
    Public Const DFCS_BUTTONCHECK As Integer = &H0
    Public Const DFCS_BUTTONRADIOIMAGE As Integer = &H1
    Public Const DFCS_BUTTONRADIOMASK As Integer = &H2
    Public Const DFCS_BUTTONRADIO As Integer = &H4
    Public Const DFCS_BUTTON3STATE As Integer = &H8
    Public Const DFCS_BUTTONPUSH As Integer = &H10
    Public Const DFCS_INACTIVE As Integer = &H100
    Public Const DFCS_PUSHED As Integer = &H200
    Public Const DFCS_CHECKED As Integer = &H400
    Public Const DFCS_TRANSPARENT As Integer = &H800
    Public Const DFCS_HOT As Integer = &H1000
    Public Const DFCS_ADJUSTRECT As Integer = &H2000
    Public Const DFCS_FLAT As Integer = &H4000
    Public Const DFCS_MONO As Integer = &H8000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           flags for DrawCaption
    '
    '           #define DC_ACTIVE           0x0001
    '           #define DC_SMALLCAP         0x0002
    '           #define DC_ICON             0x0004
    '           #define DC_TEXT             0x0008
    '           #define DC_INBUTTON         0x0010
    '           #if(WINVER >= 0x0500)
    '           #define DC_GRADIENT         0x0020
    '           #endif /* WINVER >= 0x0500 */
    '           #if(_WIN32_WINNT >= 0x0501)
    '           #define DC_BUTTONS          0x1000
    '
    '******************************************************************************
    Public Const DC_ACTIVE As Integer = &H1
    Public Const DC_SMALLCAP As Integer = &H2
    Public Const DC_ICON As Integer = &H4
    Public Const DC_TEXT As Integer = &H8
    Public Const DC_INBUTTON As Integer = &H10
    Public Const DC_GRADIENT As Integer = &H20
    Public Const DC_BUTTONS As Integer = &H1000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Predefined Clipboard Formats
    '
    '           #define CF_TEXT             1
    '           #define CF_BITMAP           2
    '           #define CF_METAFILEPICT     3
    '           #define CF_SYLK             4
    '           #define CF_DIF              5
    '           #define CF_TIFF             6
    '           #define CF_OEMTEXT          7
    '           #define CF_DIB              8
    '           #define CF_PALETTE          9
    '           #define CF_PENDATA          10
    '           #define CF_RIFF             11
    '           #define CF_WAVE             12
    '           #define CF_UNICODETEXT      13
    '           #define CF_ENHMETAFILE      14
    '           #if(WINVER >= 0x0400)
    '           #define CF_HDROP            15
    '           #define CF_LOCALE           16
    '           #endif /* WINVER >= 0x0400 */
    '           #if(WINVER >= 0x0500)
    '           #define CF_DIBV5            17
    '           #endif /* WINVER >= 0x0500 */
    '           
    '           #if(WINVER >= 0x0500)
    '           #define CF_MAX              18
    '           #elif(WINVER >= 0x0400)
    '           #define CF_MAX              17
    '           #else
    '           #define CF_MAX              15
    '           #endif
    '           
    '           #define CF_OWNERDISPLAY     0x0080
    '           #define CF_DSPTEXT          0x0081
    '           #define CF_DSPBITMAP        0x0082
    '           #define CF_DSPMETAFILEPICT  0x0083
    '           #define CF_DSPENHMETAFILE   0x008E
    '
    '******************************************************************************
    Public Const CF_TEXT As Integer = 1
    Public Const CF_BITMAP As Integer = 2
    Public Const CF_METAFILEPICT As Integer = 3
    Public Const CF_SYLK As Integer = 4
    Public Const CF_DIF As Integer = 5
    Public Const CF_TIFF As Integer = 6
    Public Const CF_OEMTEXT As Integer = 7
    Public Const CF_DIB As Integer = 8
    Public Const CF_PALETTE As Integer = 9
    Public Const CF_PENDATA As Integer = 10
    Public Const CF_RIFF As Integer = 11
    Public Const CF_WAVE As Integer = 12
    Public Const CF_UNICODETEXT As Integer = 13
    Public Const CF_ENHMETAFILE As Integer = 14
    Public Const CF_HDROP As Integer = 15
    Public Const CF_LOCALE As Integer = 16
    Public Const CF_DIBV5 As Integer = 17
    Public Const CF_MAX As Integer = 18
    Public Const CF_OWNERDISPLAY As Integer = &H80
    Public Const CF_DSPTEXT As Integer = &H81
    Public Const CF_DSPBITMAP As Integer = &H82
    Public Const CF_DSPMETAFILEPICT As Integer = &H83
    Public Const CF_DSPENHMETAFILE As Integer = &H8E

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Defines for the fVirt field of the Accelerator table structure.
    '
    '           #define FVIRTKEY  1
    '           #define FNOINVERT 0x02
    '           #define FSHIFT    0x04
    '           #define FCONTROL  0x08
    '           #define FALT      0x10
    '
    '******************************************************************************
    Public Const FVIRTKEY As Integer = 1
    Public Const FNOINVERT As Integer = &H2
    Public Const FSHIFT As Integer = &H4
    Public Const FCONTROL As Integer = &H8
    Public Const FALT As Integer = &H10

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Edit Control Messages
    '
    '           #define ES_LEFT             0x0000
    '           #define ES_CENTER           0x0001
    '           #define ES_RIGHT            0x0002
    '           #define ES_MULTILINE        0x0004
    '           #define ES_UPPERCASE        0x0008
    '           #define ES_LOWERCASE        0x0010
    '           #define ES_PASSWORD         0x0020
    '           #define ES_AUTOVSCROLL      0x0040
    '           #define ES_AUTOHSCROLL      0x0080
    '           #define ES_NOHIDESEL        0x0100
    '           #define ES_OEMCONVERT       0x0400
    '           #define ES_READONLY         0x0800
    '           #define ES_WANTRETURN       0x1000
    '           #if(WINVER >= 0x0400)
    '           #define ES_NUMBER           0x2000
    '           #endif /* WINVER >= 0x0400 */
    '           
    '           
    '           #endif /* !NOWINSTYLES */
    '           
    '           /*
    '            * Edit Control Notification Codes
    '            */
    '           #define EN_SETFOCUS         0x0100
    '           #define EN_KILLFOCUS        0x0200
    '           #define EN_CHANGE           0x0300
    '           #define EN_UPDATE           0x0400
    '           #define EN_ERRSPACE         0x0500
    '           #define EN_MAXTEXT          0x0501
    '           #define EN_HSCROLL          0x0601
    '           #define EN_VSCROLL          0x0602
    '           
    '           #if(_WIN32_WINNT >= 0x0500)
    '           #define EN_ALIGN_LTR_EC     0x0700
    '           #define EN_ALIGN_RTL_EC     0x0701
    '           #endif /* _WIN32_WINNT >= 0x0500 */
    '           
    '           #if(WINVER >= 0x0400)
    '           /* Edit control EM_SETMARGIN parameters */
    '           #define EC_LEFTMARGIN       0x0001
    '           #define EC_RIGHTMARGIN      0x0002
    '           #define EC_USEFONTINFO      0xffff
    '           #endif /* WINVER >= 0x0400 */
    '           
    '           #if(WINVER >= 0x0500)
    '           /* wParam of EM_GET/SETIMESTATUS  */
    '           #define EMSIS_COMPOSITIONSTRING        0x0001
    '           
    '           /* lParam for EMSIS_COMPOSITIONSTRING  */
    '           #define EIMES_GETCOMPSTRATONCE         0x0001
    '           #define EIMES_CANCELCOMPSTRINFOCUS     0x0002
    '           #define EIMES_COMPLETECOMPSTRKILLFOCUS 0x0004
    '           #endif /* WINVER >= 0x0500 */
    '           
    '           #ifndef NOWINMESSAGES
    '           
    '           
    '           /*
    '            * Edit Control Messages
    '            */
    '           #define EM_GETSEL               0x00B0
    '           #define EM_SETSEL               0x00B1
    '           #define EM_GETRECT              0x00B2
    '           #define EM_SETRECT              0x00B3
    '           #define EM_SETRECTNP            0x00B4
    '           #define EM_SCROLL               0x00B5
    '           #define EM_LINESCROLL           0x00B6
    '           #define EM_SCROLLCARET          0x00B7
    '           #define EM_GETMODIFY            0x00B8
    '           #define EM_SETMODIFY            0x00B9
    '           #define EM_GETLINECOUNT         0x00BA
    '           #define EM_LINEINDEX            0x00BB
    '           #define EM_SETHANDLE            0x00BC
    '           #define EM_GETHANDLE            0x00BD
    '           #define EM_GETTHUMB             0x00BE
    '           #define EM_LINELENGTH           0x00C1
    '           #define EM_REPLACESEL           0x00C2
    '           #define EM_GETLINE              0x00C4
    '           #define EM_LIMITTEXT            0x00C5
    '           #define EM_CANUNDO              0x00C6
    '           #define EM_UNDO                 0x00C7
    '           #define EM_FMTLINES             0x00C8
    '           #define EM_LINEFROMCHAR         0x00C9
    '           #define EM_SETTABSTOPS          0x00CB
    '           #define EM_SETPASSWORDCHAR      0x00CC
    '           #define EM_EMPTYUNDOBUFFER      0x00CD
    '           #define EM_GETFIRSTVISIBLELINE  0x00CE
    '           #define EM_SETREADONLY          0x00CF
    '           #define EM_SETWORDBREAKPROC     0x00D0
    '           #define EM_GETWORDBREAKPROC     0x00D1
    '           #define EM_GETPASSWORDCHAR      0x00D2
    '           #if(WINVER >= 0x0400)
    '           #define EM_SETMARGINS           0x00D3
    '           #define EM_GETMARGINS           0x00D4
    '           #define EM_SETLIMITTEXT         EM_LIMITTEXT   /* ;win40 Name change */
    '           #define EM_GETLIMITTEXT         0x00D5
    '           #define EM_POSFROMCHAR          0x00D6
    '           #define EM_CHARFROMPOS          0x00D7
    '           #endif /* WINVER >= 0x0400 */
    '           
    '           #if(WINVER >= 0x0500)
    '           #define EM_SETIMESTATUS         0x00D8
    '           #define EM_GETIMESTATUS         0x00D9
    '
    '******************************************************************************
    Public Const ES_LEFT As Integer = &H0
    Public Const ES_CENTER As Integer = &H1
    Public Const ES_RIGHT As Integer = &H2
    Public Const ES_MULTILINE As Integer = &H4
    Public Const ES_UPPERCASE As Integer = &H8
    Public Const ES_LOWERCASE As Integer = &H10
    Public Const ES_PASSWORD As Integer = &H20
    Public Const ES_AUTOVSCROLL As Integer = &H40
    Public Const ES_AUTOHSCROLL As Integer = &H80
    Public Const ES_NOHIDESEL As Integer = &H100
    Public Const ES_OEMCONVERT As Integer = &H400
    Public Const ES_READONLY As Integer = &H800
    Public Const ES_WANTRETURN As Integer = &H1000
    Public Const ES_NUMBER As Integer = &H2000
    Public Const EN_SETFOCUS As Integer = &H100
    Public Const EN_KILLFOCUS As Integer = &H200
    Public Const EN_CHANGE As Integer = &H300
    Public Const EN_UPDATE As Integer = &H400
    Public Const EN_ERRSPACE As Integer = &H500
    Public Const EN_MAXTEXT As Integer = &H501
    Public Const EN_HSCROLL As Integer = &H601
    Public Const EN_VSCROLL As Integer = &H602
    Public Const EN_ALIGN_LTR_EC As Integer = &H700
    Public Const EN_ALIGN_RTL_EC As Integer = &H701
    Public Const EC_LEFTMARGIN As Integer = &H1
    Public Const EC_RIGHTMARGIN As Integer = &H2
    Public Const EC_USEFONTINFO As Integer = &HFFFF
    Public Const EMSIS_COMPOSITIONSTRING As Integer = &H1
    Public Const EIMES_GETCOMPSTRATONCE As Integer = &H1
    Public Const EIMES_CANCELCOMPSTRINFOCUS As Integer = &H2
    Public Const EIMES_COMPLETECOMPSTRKILLFOCUS As Integer = &H4
    Public Const EM_GETSEL As Integer = &HB0
    Public Const EM_SETSEL As Integer = &HB1
    Public Const EM_GETRECT As Integer = &HB2
    Public Const EM_SETRECT As Integer = &HB3
    Public Const EM_SETRECTNP As Integer = &HB4
    Public Const EM_SCROLL As Integer = &HB5
    Public Const EM_LINESCROLL As Integer = &HB6
    Public Const EM_SCROLLCARET As Integer = &HB7
    Public Const EM_GETMODIFY As Integer = &HB8
    Public Const EM_SETMODIFY As Integer = &HB9
    Public Const EM_GETLINECOUNT As Integer = &HBA
    Public Const EM_LINEINDEX As Integer = &HBB
    Public Const EM_SETHANDLE As Integer = &HBC
    Public Const EM_GETHANDLE As Integer = &HBD
    Public Const EM_GETTHUMB As Integer = &HBE
    Public Const EM_LINELENGTH As Integer = &HC1
    Public Const EM_REPLACESEL As Integer = &HC2
    Public Const EM_GETLINE As Integer = &HC4
    Public Const EM_LIMITTEXT As Integer = &HC5
    Public Const EM_CANUNDO As Integer = &HC6
    Public Const EM_UNDO As Integer = &HC7
    Public Const EM_FMTLINES As Integer = &HC8
    Public Const EM_LINEFROMCHAR As Integer = &HC9
    Public Const EM_SETTABSTOPS As Integer = &HCB
    Public Const EM_SETPASSWORDCHAR As Integer = &HCC
    Public Const EM_EMPTYUNDOBUFFER As Integer = &HCD
    Public Const EM_GETFIRSTVISIBLELINE As Integer = &HCE
    Public Const EM_SETREADONLY As Integer = &HCF
    Public Const EM_SETWORDBREAKPROC As Integer = &HD0
    Public Const EM_GETWORDBREAKPROC As Integer = &HD1
    Public Const EM_GETPASSWORDCHAR As Integer = &HD2
    Public Const EM_SETMARGINS As Integer = &HD3
    Public Const EM_GETMARGINS As Integer = &HD4
    Public Const EM_GETLIMITTEXT As Integer = &HD5
    Public Const EM_POSFROMCHAR As Integer = &HD6
    Public Const EM_CHARFROMPOS As Integer = &HD7
    Public Const EM_SETIMESTATUS As Integer = &HD8
    Public Const EM_GETIMESTATUS As Integer = &HD9

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Button Control Styles
    '
    '           #define BS_PUSHBUTTON       0x00000000
    '           #define BS_DEFPUSHBUTTON    0x00000001
    '           #define BS_CHECKBOX         0x00000002
    '           #define BS_AUTOCHECKBOX     0x00000003
    '           #define BS_RADIOBUTTON      0x00000004
    '           #define BS_3STATE           0x00000005
    '           #define BS_AUTO3STATE       0x00000006
    '           #define BS_GROUPBOX         0x00000007
    '           #define BS_USERBUTTON       0x00000008
    '           #define BS_AUTORADIOBUTTON  0x00000009
    '           #define BS_PUSHBOX          0x0000000A
    '           #define BS_OWNERDRAW        0x0000000B
    '           #define BS_TYPEMASK         0x0000000F
    '           #define BS_LEFTTEXT         0x00000020
    '           #if(WINVER >= 0x0400)
    '           #define BS_TEXT             0x00000000
    '           #define BS_ICON             0x00000040
    '           #define BS_BITMAP           0x00000080
    '           #define BS_LEFT             0x00000100
    '           #define BS_RIGHT            0x00000200
    '           #define BS_CENTER           0x00000300
    '           #define BS_TOP              0x00000400
    '           #define BS_BOTTOM           0x00000800
    '           #define BS_VCENTER          0x00000C00
    '           #define BS_PUSHLIKE         0x00001000
    '           #define BS_MULTILINE        0x00002000
    '           #define BS_NOTIFY           0x00004000
    '           #define BS_FLAT             0x00008000
    '
    '******************************************************************************
    Public Const BS_PUSHBUTTON As Integer = &H0
    Public Const BS_DEFPUSHBUTTON As Integer = &H1
    Public Const BS_CHECKBOX As Integer = &H2
    Public Const BS_AUTOCHECKBOX As Integer = &H3
    Public Const BS_RADIOBUTTON As Integer = &H4
    Public Const BS_3STATE As Integer = &H5
    Public Const BS_AUTO3STATE As Integer = &H6
    Public Const BS_GROUPBOX As Integer = &H7
    Public Const BS_USERBUTTON As Integer = &H8
    Public Const BS_AUTORADIOBUTTON As Integer = &H9
    Public Const BS_PUSHBOX As Integer = &HA
    Public Const BS_OWNERDRAW As Integer = &HB
    Public Const BS_TYPEMASK As Integer = &HF
    Public Const BS_LEFTTEXT As Integer = &H20
    Public Const BS_TEXT As Integer = &H0
    Public Const BS_ICON As Integer = &H40
    Public Const BS_BITMAP As Integer = &H80
    Public Const BS_LEFT As Integer = &H100
    Public Const BS_RIGHT As Integer = &H200
    Public Const BS_CENTER As Integer = &H300
    Public Const BS_TOP As Integer = &H400
    Public Const BS_BOTTOM As Integer = &H800
    Public Const BS_VCENTER As Integer = &HC00
    Public Const BS_PUSHLIKE As Integer = &H1000
    Public Const BS_MULTILINE As Integer = &H2000
    Public Const BS_NOTIFY As Integer = &H4000
    Public Const BS_FLAT As Integer = &H8000

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           WINAPI_FAMILY_PARTITION(WINAPI_PARTITION_DESKTOP)
    '
    '           #define LWA_COLORKEY            0x00000001
    '           #define LWA_ALPHA               0x00000002
    '           
    '           #define ULW_COLORKEY            0x00000001
    '           #define ULW_ALPHA               0x00000002
    '           #define ULW_OPAQUE              0x00000004
    '           
    '           #define ULW_EX_NORESIZE         0x00000008
    '
    '******************************************************************************
    Public Const LWA_COLORKEY As Integer = &H1
    Public Const LWA_ALPHA As Integer = &H2
    Public Const ULW_COLORKEY As Integer = &H1
    Public Const ULW_ALPHA As Integer = &H2
    Public Const ULW_OPAQUE As Integer = &H4
    Public Const ULW_EX_NORESIZE As Integer = &H8

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           Window field offsets for GetWindowLong
    '
    '           #define GWL_WNDPROC         (-4)
    '           #define GWL_HINSTANCE       (-6)
    '           #define GWL_HWNDPARENT      (-8)
    '           #define GWL_STYLE           (-16)
    '           #define GWL_EXSTYLE         (-20)
    '           #define GWL_USERDATA        (-21)
    '           #define GWL_ID              (-12)
    '
    '******************************************************************************
    Public Const GWL_WNDPROC As Integer = -4
    Public Const GWL_HINSTANCE As Integer = -6
    Public Const GWL_HWNDPARENT As Integer = -8
    Public Const GWL_STYLE As Integer = -16
    Public Const GWL_EXSTYLE As Integer = -20
    Public Const GWL_USERDATA As Integer = -21
    Public Const GWL_ID As Integer = -12

    '******************************************************************************
    'MicroSoft & <WinUser.h>
    '
    '           SetWindowPos Flags
    '
    '
    '******************************************************************************
    Public Const SWP_NOSIZE As Integer = &H1
    Public Const SWP_NOMOVE As Integer = &H2
    Public Const SWP_NOZORDER As Integer = &H4
    Public Const SWP_NOREDRAW As Integer = &H8
    Public Const SWP_NOACTIVATE As Integer = &H10
    Public Const SWP_FRAMECHANGED As Integer = &H20
    Public Const SWP_SHOWWINDOW As Integer = &H40
    Public Const SWP_HIDEWINDOW As Integer = &H80
    Public Const SWP_NOCOPYBITS As Integer = &H100
    Public Const SWP_NOOWNERZORDER As Integer = &H200
    Public Const SWP_NOSENDCHANGING As Integer = &H400
    Public Const SWP_DEFERERASE As Integer = &H2000
    Public Const SWP_ASYNCWINDOWPOS As Integer = &H4000

End Class