Imports System.Runtime.InteropServices
Imports RollRat_Vb_Api.RollRat_Vb_Api

Public Class frmPannel

    '//////////////////////////////////////////////////////////////
    '
    '   RollRat Software Programs
    '
    '
    '     Name : Windows Api C Style Window Maker
    '
    '  Purpose : Make a window easilly
    '
    '  Project : B 0-1-5-0
    '
    '   Copyright (c) rollrat. 2010-2013. All right reserved.
    '
    '//////////////////////////////////////////////////////////////

    ' Vb_Api.dll 에 대한 업데이트 정보는 블로그를 참고하십시오.

    Private Manager As frmManageMent

    Public Class CStyleWNDAPIS
        <DllImport("user32.dll", SetLastError:=True)> _
        Public Shared Function CreateWindowEx( _
        ByVal dwExStyle As WindowStylesEx, _
        ByVal lpClassName As String, _
        ByVal lpWindowName As String, _
        ByVal dwStyle As WindowStyles, _
        ByVal x As Integer, _
        ByVal y As Integer, _
        ByVal nWidth As Integer, _
        ByVal nHeight As Integer, _
        ByVal hWndParent As IntPtr, _
        ByVal hMenu As IntPtr, _
        ByVal hInstance As IntPtr, _
        ByVal lpParam As IntPtr) As IntPtr
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
        Public Structure XYWH
            Dim x As Integer
            Dim y As Integer
            Dim Width As Integer
            Dim Height As Integer
        End Structure
        Public hWnd As IntPtr = 0
        'If you use the First Parameter of CreateWindowEx Null, the function is equal to CreateWindow
        Public Function C_Button(ByVal Caption As String, ByVal Value As XYWH, ByVal Menu As Integer)
            Return CreateWindowEx(0, "button", Caption, WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE, _
                           Value.x, Value.y, Value.Width, Value.Height, hWnd, Menu, 0, 0)
        End Function
        Public Function C_ListBox(ByVal Caption As String, ByVal Value As XYWH, ByVal Menu As Integer)
            Return CreateWindowEx(0, "listbox", Caption, _
                           WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE Or WindowStyles.WS_BORDER _
                           Or WindowStyles.WS_VSCROLL Or 1, _
                           Value.x, Value.y, Value.Width, Value.Height, hWnd, Menu, 0, 0)
        End Function
        Public Function C_RadioButton(ByVal Caption As String, ByVal Value As XYWH, ByVal Menu As Integer)
            Return CreateWindowEx(0, "button", Caption, WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE Or 9, _
                           Value.x, Value.y, Value.Width, Value.Height, hWnd, Menu, 0, 0)
        End Function
        Public Function C_CheckBox(ByVal Caption As String, ByVal Value As XYWH, ByVal Menu As Integer)
            Return CreateWindowEx(0, "button", Caption, WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE Or 2, _
                           Value.x, Value.y, Value.Width, Value.Height, hWnd, Menu, 0, 0)
        End Function
        Public Function C_GroupBox(ByVal Caption As String, ByVal Value As XYWH, ByVal Menu As Integer)
            Return CreateWindowEx(0, "button", Caption, WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE Or 7, _
                           Value.x, Value.y, Value.Width, Value.Height, hWnd, Menu, 0, 0)
        End Function
        Public Function C_Edit(ByVal Caption As String, ByVal Value As XYWH, ByVal Menu As Integer)
            Return CreateWindowEx(0, "edit", Caption, WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE Or WindowStyles.WS_BORDER Or 4, _
                           Value.x, Value.y, Value.Width, Value.Height, hWnd, Menu, 0, 0)
        End Function
        Public Function C_Edit_Multi(ByVal Caption As String, ByVal Value As XYWH, ByVal Menu As Integer)
            Return CreateWindowEx(0, "edit", Caption, WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE Or WindowStyles.WS_BORDER Or 4 Or &H200000, _
                           Value.x, Value.y, Value.Width, Value.Height, hWnd, Menu, 0, 0)
        End Function
        Public Function C_Combobox(ByVal Caption As String, ByVal Value As XYWH, ByVal Menu As Integer)
            Return CreateWindowEx(0, "combobox", Caption, WindowStyles.WS_CHILD Or WindowStyles.WS_VISIBLE Or 2, _
                           Value.x, Value.y, Value.Width, Value.Height, hWnd, Menu, 0, 0)
        End Function
    End Class

    Public Shared CS As New CStyleWNDAPIS

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hWnd As IntPtr
        Dim STRUCT As CStyleWNDAPIS.XYWH
        Dim R As Rectangle
        Dim RP As Rectangle
        With STRUCT
            .x = 10
            .y = 10
            .Width = 150
            .Height = 50
        End With
        If TreeView1.SelectedNode.Text = "Button" Then
            hWnd = CS.C_Button("Button", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("버튼 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "CheckBox" Then
            hWnd = CS.C_CheckBox("CheckBox", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("체크박스 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "GroupBox" Then
            hWnd = CS.C_GroupBox("GroupBox", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("그룹박스 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "Edit(MultiLine)" Then
            hWnd = CS.C_Edit_Multi("Edit-Multi Line", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("에디트(멀티) : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "Edit" Then
            hWnd = CS.C_Edit("Edit", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("에디트 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "RadioButton" Then
            hWnd = CS.C_RadioButton("RadioButton", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("라디오버튼 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "Combobox" Then
            hWnd = CS.C_Combobox("Combobox", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("콤보박스 : " & CInt(hWnd))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IsNumeric(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")) Then
            Manager = New frmManageMent
            Manager.hHandle = CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " "))
            Manager.Show()
        Else
            _ER.Show_Error("오류", "올바른 핸들식을 선택하십시오.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If IsNumeric(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")) Then
            WinApi.SendMessageW(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), _
                                WinApiUsr.WM_CLOSE, 0, 0)
            TreeView1.Nodes.Remove(TreeView1.SelectedNode)
        Else
            _ER.Show_Error("오류", "올바른 핸들식을 선택하십시오.")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ForI As Integer = TreeView1.Nodes(1).Nodes.Count
        Dim Str As String = ""
        Dim R As Rectangle
        Dim RP As Rectangle
        For vo_F = 0 To ForI - 1
            If _Str.SplitS(TreeView1.Nodes(1).Nodes(vo_F).Text, 0, " :") = "버튼" Then
                GetWindowRect(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), R)
                GetWindowRect(frmMain.Handle, RP)
                Str += "CreateWindow(TEXT(""button""), Caption, WS_CHILD | WS_VISIBLE," & _
                    R.X - RP.X - 8 & " ," & R.Y - RP.Y - 31 & " ," & R.Width - R.X & " ," & R.Height - R.Y & " ," & " hWnd, Menu, 0, 0)"
                Str += vbCrLf
            ElseIf _Str.SplitS(TreeView1.Nodes(1).Nodes(vo_F).Text, 0, " :") = "라디오버튼" Then
                GetWindowRect(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), R)
                GetWindowRect(frmMain.Handle, RP)
                Str += "CreateWindow(TEXT(""button""), Caption, WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON," & _
                    R.X - RP.X - 8 & " ," & R.Y - RP.Y - 31 & " ," & R.Width - R.X & " ," & R.Height - R.Y & " ," & " hWnd, Menu, 0, 0)"
                Str += vbCrLf
            ElseIf _Str.SplitS(TreeView1.Nodes(1).Nodes(vo_F).Text, 0, " :") = "체크박스" Then
                GetWindowRect(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), R)
                GetWindowRect(frmMain.Handle, RP)
                Str += "CreateWindow(TEXT(""button""), Caption, WS_CHILD | WS_VISIBLE | BS_CHECKBOX," & _
                    R.X - RP.X - 8 & " ," & R.Y - RP.Y - 31 & " ," & R.Width - R.X & " ," & R.Height - R.Y & " ," & " hWnd, Menu, 0, 0)"
                Str += vbCrLf
            ElseIf _Str.SplitS(TreeView1.Nodes(1).Nodes(vo_F).Text, 0, " :") = "그룹박스" Then
                GetWindowRect(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), R)
                GetWindowRect(frmMain.Handle, RP)
                Str += "CreateWindow(TEXT(""button""), Caption, WS_CHILD | WS_VISIBLE | BS_GROUPBOX," & _
                    R.X - RP.X - 8 & " ," & R.Y - RP.Y - 31 & " ," & R.Width - R.X & " ," & R.Height - R.Y & " ," & " hWnd, Menu, 0, 0)"
                Str += vbCrLf
            ElseIf _Str.SplitS(TreeView1.Nodes(1).Nodes(vo_F).Text, 0, " :") = "리스트박스" Then
                GetWindowRect(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), R)
                GetWindowRect(frmMain.Handle, RP)
                Str += "CreateWindow(TEXT(""listbox""), Caption, WS_CHILD | WS_VISIBLE | WS_BORDER | WS_VSCROLL | LBS_NOTIFY," & _
                    R.X - RP.X - 8 & " ," & R.Y - RP.Y - 31 & " ," & R.Width - R.X & " ," & R.Height - R.Y & " ," & " hWnd, Menu, 0, 0)"
                Str += vbCrLf
            ElseIf _Str.SplitS(TreeView1.Nodes(1).Nodes(vo_F).Text, 0, " :") = "에디트" Then
                GetWindowRect(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), R)
                GetWindowRect(frmMain.Handle, RP)
                Str += "CreateWindow(TEXT(""edit""), Caption, WS_CHILD | WS_VISIBLE | WS_BORDER | ES_MULTILINE," & _
                    R.X - RP.X - 8 & " ," & R.Y - RP.Y - 31 & " ," & R.Width - R.X & " ," & R.Height - R.Y & " ," & " hWnd, Menu, 0, 0)"
                Str += vbCrLf
            ElseIf _Str.SplitS(TreeView1.Nodes(1).Nodes(vo_F).Text, 0, " :") = "에디트(멀티)" Then
                GetWindowRect(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), R)
                GetWindowRect(frmMain.Handle, RP)
                Str += "CreateWindow(TEXT(""edit""), Caption, WS_CHILD | WS_VISIBLE | WS_VSCROLL | WS_BORDER | ES_MULTILINE," & _
                    R.X - RP.X - 8 & " ," & R.Y - RP.Y - 31 & " ," & R.Width - R.X & " ," & R.Height - R.Y & " ," & " hWnd, Menu, 0, 0)"
                Str += vbCrLf
            ElseIf _Str.SplitS(TreeView1.Nodes(1).Nodes(vo_F).Text, 0, " :") = "콤보박스" Then
                GetWindowRect(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), R)
                GetWindowRect(frmMain.Handle, RP)
                Str += "CreateWindow(TEXT(""combobox""), Caption, WS_CHILD | WS_VISIBLE | CBS_DROPDOWN," & _
                    R.X - RP.X - 8 & " ," & R.Y - RP.Y - 31 & " ," & R.Width - R.X & " ," & R.Height - R.Y & " ," & " hWnd, Menu, 0, 0)"
                Str += vbCrLf
            End If
        Next
        MsgBox(Str)
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        Dim hWnd As IntPtr
        Dim STRUCT As CStyleWNDAPIS.XYWH
        Dim R As Rectangle
        Dim RP As Rectangle
        With STRUCT
            .x = 10
            .y = 10
            .Width = 150
            .Height = 50
        End With
        If TreeView1.SelectedNode.Text = "Button" Then
            hWnd = CS.C_Button("Button", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("버튼 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "CheckBox" Then
            hWnd = CS.C_CheckBox("CheckBox", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("체크박스 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "GroupBox" Then
            hWnd = CS.C_GroupBox("GroupBox", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("그룹박스 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "Edit(MultiLine)" Then
            hWnd = CS.C_Edit_Multi("Edit-Multi Line", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("에디트(멀티) : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "Edit" Then
            hWnd = CS.C_Edit("Edit", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("에디트 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "RadioButton" Then
            hWnd = CS.C_RadioButton("RadioButton", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("라디오버튼 : " & CInt(hWnd))
        ElseIf TreeView1.SelectedNode.Text = "Combobox" Then
            hWnd = CS.C_Combobox("Combobox", STRUCT, 0)
            GetWindowRect(hWnd, R)
            GetWindowRect(frmMain.Handle, RP)
            SetWindowPos(hWnd, 0, _
                         R.X - RP.X - 8, _
                         R.Y - RP.Y - 31, _
                         R.Width - R.X, _
                         R.Height - R.Y, _
                         WinApiUsr.SWP_NOZORDER
                         )
            TreeView1.Nodes(1).Nodes.Add("콤보박스 : " & CInt(hWnd))
        End If
    End Sub

    Private Sub TreeView1_KeyPress(sender As Object, e As KeyEventArgs) Handles TreeView1.KeyDown
        If e.KeyValue = Keys.Delete Then
            If IsNumeric(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")) Then
                WinApi.SendMessageW(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), _
                                    WinApiUsr.WM_CLOSE, 0, 0)
                TreeView1.Nodes.Remove(TreeView1.SelectedNode)
            Else
                _ER.Show_Error("오류", "올바른 핸들식을 선택하십시오.")
            End If
        End If
    End Sub

    Private Sub frmPannel_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Delete Then
            If IsNumeric(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")) Then
                WinApi.SendMessageW(CInt(_Str.Split(_Str.Split(TreeView1.SelectedNode.Text, 1, 1, ":"), 1, 1, " ")), _
                                    WinApiUsr.WM_CLOSE, 0, 0)
                TreeView1.Nodes.Remove(TreeView1.SelectedNode)
            Else
                _ER.Show_Error("오류", "올바른 핸들식을 선택하십시오.")
            End If
        End If
    End Sub

#Region "   Control Move Worker              "
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function GetParent(ByVal hWnd As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")> _
    Private Shared Function GetWindowRect(ByVal hWnd As System.IntPtr, ByRef lpRect As Rectangle) As Boolean
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function GetClientRect(ByVal hWnd As System.IntPtr, ByRef lpRECT As Rectangle) As Integer
    End Function
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function
    Private Declare Function GetNextWindow Lib "user32" Alias "GetWindow" (ByVal hwnd As IntPtr, ByVal wFlag As Integer) As IntPtr
    Private Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As IntPtr, ByRef lpwndpl As WINDOWPLACEMENT) As Integer
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
    Private WithEvents mHook As New MouseHook
    Dim Sets As Boolean = False
    Dim SetWPf As Boolean = False
    Dim TyS As IntPtr
    Protected Overloads Overrides Sub WndProc(ByRef e As Message)
        MyBase.WndProc(e)
        Dim Id As Integer = e.WParam.ToInt32()
        Select Case Id
            Case 1140
                Sets = True
                Exit Select
        End Select
    End Sub
    Private Sub mHook_Mouse_Left_Down(ptLocat As Point) Handles mHook.Mouse_Left_Down
        If Sets = True Then
            Sets = False
            Swp_1()
            Exit Sub
        End If
    End Sub
    Private Sub MouseHook_Mouse_Right_Up(ptLocat As Point) Handles mHook.Mouse_Left_Up
        If SetWPf = True Then
            SetWPf = False
            Exit Sub
        End If
    End Sub
    Private Sub Swp_1()
        Dim Point As Point
        WinApi.GetCursorPos(Point)
        TyS = WinApi.WindowFromPoint(Point)
        SetWPf = True
    End Sub
    Private Structure WINDOWPLACEMENT
        Public Length As Integer
        Public flags As Integer
        Public showCmd As Integer
        Public ptMinPosition As Point
        Public ptMaxPosition As Point
        Public rcNormalPosition As Rectangle
    End Structure
    Public Sub GetWindowPos(ByVal hwnd As Integer, ByRef ptrPhwnd As Integer, ByRef ptrNhwnd As Integer, ByRef ptPoint As Point, ByRef szSize As Size, ByRef intShowCmd As WNDSTATE)
        Dim wInf As WINDOWPLACEMENT
        wInf.Length = System.Runtime.InteropServices.Marshal.SizeOf(wInf)
        GetWindowPlacement(hwnd, wInf)
        szSize = New Size(wInf.rcNormalPosition.Right - (wInf.rcNormalPosition.Left * 2), wInf.rcNormalPosition.Bottom - (wInf.rcNormalPosition.Top * 2))
        ptPoint = New Point(wInf.rcNormalPosition.Left, wInf.rcNormalPosition.Top)
        ptrPhwnd = GetNextWindow(hwnd, 2)
        ptrNhwnd = GetNextWindow(hwnd, 3)
        intShowCmd = wInf.showCmd
    End Sub
    Dim Nf As Rectangle
    Dim Nfs As Boolean = False
    Dim FS As IntPtr
    Private Sub mHook_Mouse_Move(ptLocat As Point) Handles mHook.Mouse_Move
        Dim Point As Point
        Dim R As Rectangle
        WinApi.GetCursorPos(Point)
        GetWindowRect(WinApi.WindowFromPoint(Point), R)
        If SetWPf = True Then
            If Nfs = False Then
                Nfs = True
                FS = GetParent(WinApi.WindowFromPoint(Point))
            End If
            GetWindowRect(FS, Nf)
            SetWindowPos(TyS, _
                         vbNullString, _
                         Point.X - Nf.X, _
                         Point.Y - Nf.Y, _
                         0, 0, _
                         WinApiUsr.SWP_NOSIZE Or WinApiUsr.SWP_NOZORDER _
                         )
        End If
    End Sub
    Private Sub frmPannel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WinApi.RegisterHotKey(Me.Handle, 1140, 0, Convert.ToUInt32(Keys.F5))
        CS.hWnd = frmMain.Handle
    End Sub
    Private Sub frmPannel_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WinApi.UnregisterHotKey(Me.Handle, 1140)
    End Sub
    'made by rollrat
#End Region

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