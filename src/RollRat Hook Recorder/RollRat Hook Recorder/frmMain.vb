'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.IO

Public Class frmMain

    Private WithEvents mouse_hook As New MouseHook
    Private WithEvents keyboard_hook As New KeyboardHook

    Dim timer_ticksum As Integer
    Dim global_downcount As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Timer2.Enabled = False Then
            timer_ticksum = 0
            ListBox1.Items.Clear()
            Button1.Enabled = False
            Button3.Enabled = False
            Timer1.Start()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Enabled = True
        Button3.Enabled = True
        Timer1.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Timer1.Enabled = False AndAlso ListBox1.Items.Count <> 0 Then
            count = 0
            global_downcount = NumericUpDown1.Value
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            CheckBox1.Enabled = False
            NumericUpDown1.Enabled = False
            Timer2.Start()
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WinApi.UnregisterHotKey(Me.Handle, 1000)
        WinApi.UnregisterHotKey(Me.Handle, 1010)
        WinApi.UnregisterHotKey(Me.Handle, 1020)
        WinApi.UnregisterHotKey(Me.Handle, 1030)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WinApi.RegisterHotKey(Me.Handle, 1010, 0, WinApiUsr.VK_F2)
        WinApi.RegisterHotKey(Me.Handle, 1030, 0, WinApiUsr.VK_F3)
        WinApi.RegisterHotKey(Me.Handle, 1020, 0, WinApiUsr.VK_F5)
        WinApi.RegisterHotKey(Me.Handle, 1040, 0, WinApiUsr.VK_F4)
    End Sub

    Protected Overrides Sub WndProc(ByRef e As Message)
        MyBase.WndProc(e)
        Dim num As Integer = e.WParam.ToInt32()
        If num = 1040 Then
            Button3.PerformClick()
        ElseIf num = 1010 Then
            Button1.PerformClick()
        ElseIf num = 1020 Then
            video_stop()
        ElseIf num = 1030 Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub video_stop()
        ListBox1.SelectedIndex = 0
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        CheckBox1.Enabled = True
        NumericUpDown1.Enabled = True
        Timer2.Stop()
    End Sub


    '///////////////////////////////////////////////////////////////////////////
    '
    '
    '   Event Reporter
    '
    '
    '///////////////////////////////////////////////////////////////////////////

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timer_ticksum += 1
        Dim mouse_pt As Point = DirectCast(MouseEvent.GetMousePoint(), Point)
        ListBox1.Items.Add(timer_ticksum & ":{" & mouse_pt.X & "," & mouse_pt.Y & "}")
    End Sub

    Private Sub keyboard_hook_KeyDown(Key As Keys) Handles keyboard_hook.KeyDown
        If Timer1.Enabled Then
            ListBox1.Items.Add(timer_ticksum & ":kkd{" & Key & "}")
        End If
    End Sub

    Private Sub keyboard_hook_KeyUp(Key As Keys) Handles keyboard_hook.KeyUp
        If Timer1.Enabled Then
            ListBox1.Items.Add(timer_ticksum & ":kku{" & Key & "}")
        End If
    End Sub

    Private Sub mouse_hook_Mouse_Left_Down(ptLocat As Point) Handles mouse_hook.Mouse_Left_Down
        If Timer1.Enabled Then
            ListBox1.Items.Add(timer_ticksum & ":ldc{" & ptLocat.X & "," & ptLocat.Y & "}")
        End If
    End Sub

    Private Sub mouse_hook_Mouse_Left_Up(ptLocat As Point) Handles mouse_hook.Mouse_Left_Up
        If Timer1.Enabled Then
            ListBox1.Items.Add(timer_ticksum & ":luc{" & ptLocat.X & "," & ptLocat.Y & "}")
        End If
    End Sub

    Private Sub mouse_hook_Mouse_Middle_Down(ptLocat As Point) Handles mouse_hook.Mouse_Middle_Down
        If Timer1.Enabled Then
            ListBox1.Items.Add(timer_ticksum & ":mdc{" & ptLocat.X & "," & ptLocat.Y & "}")
        End If
    End Sub

    Private Sub mouse_hook_Mouse_Middle_Up(ptLocat As Point) Handles mouse_hook.Mouse_Middle_Up
        If Timer1.Enabled Then
            ListBox1.Items.Add(timer_ticksum & ":muc{" & ptLocat.X & "," & ptLocat.Y & "}")
        End If
    End Sub

    Private Sub mouse_hook_Mouse_Right_Down(ptLocat As Point) Handles mouse_hook.Mouse_Right_Down
        If Timer1.Enabled Then
            ListBox1.Items.Add(timer_ticksum & ":rdc{" & ptLocat.X & "," & ptLocat.Y & "}")
        End If
    End Sub

    Private Sub mouse_hook_Mouse_Right_Up(ptLocat As Point) Handles mouse_hook.Mouse_Right_Up
        If Timer1.Enabled Then
            ListBox1.Items.Add(timer_ticksum & ":ruc{" & ptLocat.X & "," & ptLocat.Y & "}")
        End If
    End Sub

    Private Sub mouse_hook_Mouse_Wheel(ptLocat As Point, Direction As MouseHook.Wheel_Direction) Handles mouse_hook.Mouse_Wheel
        If Timer1.Enabled Then
            If Direction = MouseHook.Wheel_Direction.WheelUp Then
                ListBox1.Items.Add(timer_ticksum & ":wu{" & ptLocat.X & "," & ptLocat.Y & "}")
            ElseIf Direction = MouseHook.Wheel_Direction.WheelDown Then
                ListBox1.Items.Add(timer_ticksum & ":wd{" & ptLocat.X & "," & ptLocat.Y & "}")
            End If
        End If
    End Sub



    '///////////////////////////////////////////////////////////////////////////
    '
    '
    '   Raise Event
    '
    '
    '///////////////////////////////////////////////////////////////////////////

    Dim count

    Function inside(ByVal chl As Char, ByVal chr As Char)
        Return DirectCast(ListBox1.SelectedItem, String).Split(chl)(1).Split(chr)(0)
    End Function

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If count <> timer_ticksum - 2 Then
            count += 1
            ListBox1.SelectedIndex = count
            Dim sign As String = inside(":"c, "{"c)
            If sign = "" Then
                MouseEvent.SetMousePoint(inside("{"c, ","c), inside(","c, "}"c))
            ElseIf sign = "ldc" Then
                MouseEvent.Leftdown(inside("{"c, ","c), inside(","c, "}"c))
            ElseIf sign = "luc" Then
                MouseEvent.Leftup(inside("{"c, ","c), inside(","c, "}"c))
            ElseIf sign = "rdc" Then
                MouseEvent.Rightdown(inside("{"c, ","c), inside(","c, "}"c))
            ElseIf sign = "ruc" Then
                MouseEvent.Rightup(inside("{"c, ","c), inside(","c, "}"c))
            ElseIf sign = "mdc" Then
                MouseEvent.Middledown(inside("{"c, ","c), inside(","c, "}"c))
            ElseIf sign = "muc" Then
                MouseEvent.Middleup(inside("{"c, ","c), inside(","c, "}"c))
            ElseIf sign = "wu" Then
                MouseEvent.WheelUp()
            ElseIf sign = "wd" Then
                MouseEvent.WheelDown()
            ElseIf sign = "kkd" Then
                KeyboardEvent.KeyDown(inside("{"c, "}"c))
            ElseIf sign = "kku" Then
                KeyboardEvent.KeyUp(inside("{"c, "}"c))
            End If
        Else
            If CheckBox1.Checked AndAlso global_downcount <> 1 Then
                count = 0
                ListBox1.SelectedIndex = 0
                If global_downcount <> 0 Then
                    global_downcount -= 1
                End If
            Else
                video_stop()
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        NumericUpDown1.Enabled = CheckBox1.Checked
    End Sub



    '///////////////////////////////////////////////////////////////////////////
    '
    '
    '   Storage Service
    '
    '
    '///////////////////////////////////////////////////////////////////////////

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim str_stream As New StringBuilder
            For i As Integer = 0 To ListBox1.Items.Count - 1
                str_stream.Append(ListBox1.Items.Item(i).ToString & "*")
            Next
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, str_stream.ToString(), True)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim list_of_item As String() = File.ReadAllText(OpenFileDialog1.FileName).Split({"*"c})
            ListBox1.Items.Clear()
            For i As Integer = 0 To list_of_item.Length - 2
                ListBox1.Items.Add(list_of_item(i))
            Next
            timer_ticksum = list_of_item.Length - 2
        End If

    End Sub

End Class
