Imports System.Runtime.InteropServices
Imports RollRat_Vb_Api.RollRat_Vb_Api

Public Class frmManageMent

    '//////////////////////////////////////////////////////////////
    '
    '   RollRat Software Programs
    '
    '
    '     Name : Windows Api C Style Window Maker
    '
    '  Purpose : Make a window easilly
    '
    '  Project : B 0-1-5-1
    '
    '   Copyright (c) rollrat. 2010-2013. All right reserved.
    '
    '//////////////////////////////////////////////////////////////

    Dim hWnd As IntPtr
    Dim hParent As IntPtr

    Property hHandle() As IntPtr
        Get
            Return hWnd
        End Get
        Set(value As IntPtr)
            hWnd = value
        End Set
    End Property

    <DllImport("user32.dll")> _
    Private Shared Function GetWindowRect(ByVal hWnd As System.IntPtr, ByRef lpRect As Rectangle) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function

    Private Sub frmManageMent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label7.Text = hWnd
        Dim R As Rectangle
        Dim RP As Rectangle
        GetWindowRect(hWnd, R)
        hParent = WinApi.GetParent(hWnd)
        GetWindowRect(hParent, RP)
        NumericUpDown1.Value = R.X - RP.X - 8
        NumericUpDown2.Value = R.Y - RP.Y - 31
        NumericUpDown3.Value = R.Width - R.X
        NumericUpDown4.Value = R.Height - R.Y
    End Sub

    Private Sub frmManageMent_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If CheckBox1.Checked Then
            SetWindowPos(hWnd, 0, _
                         NumericUpDown1.Value, _
                         NumericUpDown2.Value, _
                         NumericUpDown3.Value, _
                         NumericUpDown4.Value, _
                         WinApiUsr.SWP_NOZORDER
                         )
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If CheckBox1.Checked Then
            SetWindowPos(hWnd, 0, _
                         NumericUpDown1.Value, _
                         NumericUpDown2.Value, _
                         NumericUpDown3.Value, _
                         NumericUpDown4.Value, _
                         WinApiUsr.SWP_NOZORDER
                         )
        End If
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        If CheckBox1.Checked Then
            SetWindowPos(hWnd, 0, _
                         NumericUpDown1.Value, _
                         NumericUpDown2.Value, _
                         NumericUpDown3.Value, _
                         NumericUpDown4.Value, _
                         WinApiUsr.SWP_NOZORDER
                         )
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If CheckBox1.Checked Then
            SetWindowPos(hWnd, 0, _
                         NumericUpDown1.Value, _
                         NumericUpDown2.Value, _
                         NumericUpDown3.Value, _
                         NumericUpDown4.Value, _
                         WinApiUsr.SWP_NOZORDER
                         )
        End If
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged
        If CheckBox1.Checked Then
            SetWindowPos(hWnd, 0, _
                         NumericUpDown1.Value, _
                         NumericUpDown2.Value, _
                         NumericUpDown3.Value, _
                         NumericUpDown4.Value, _
                         WinApiUsr.SWP_NOZORDER
                         )
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then
            SetWindowPos(hWnd, 0, _
                         NumericUpDown1.Value, _
                         NumericUpDown2.Value, _
                         NumericUpDown3.Value, _
                         NumericUpDown4.Value, _
                         WinApiUsr.SWP_NOZORDER
                         )
        End If
        Me.Close()
    End Sub

End Class