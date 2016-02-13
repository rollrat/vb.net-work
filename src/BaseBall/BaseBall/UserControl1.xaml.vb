Imports System.Windows

Public Class UserControl1

    Dim i As Integer = 0
    Dim f As Integer = 0

    Dim count As Integer = 0
    Dim max_count As Integer = 0
    Dim now_count As Integer = 0

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        If cmb.Text = "2 자리" Then
            i = 2
        ElseIf cmb.Text = "3 자리" Then
            i = 3
        ElseIf cmb.Text = "4 자리" Then
            i = 4
        ElseIf cmb.Text = "5 자리" Then
            i = 5
        ElseIf cmb.Text = "6 자리" Then
            i = 6
        End If
        jari.Content = "자릿수 : " & i
        If max_count Then
            count_.Content = "카운트 : " & count & "/" & max_count
        Else
            count_.Content = "카운트 : " & count
        End If
        button1.IsEnabled = False
        grid.IsEnabled = True
        cmb.IsEnabled = False
        aend.IsEnabled = True
        count = 0
        '/////////
        Dim arr(0 To i - 1) As Integer

        textboxproccess.AppendText("    Select User Type : " & i & vbCrLf)

        'Dim a As Integer = GetRandom((i - 1) * 10, i * 10)

        textboxproccess.AppendText("    Creating non-repeate number..." & i & vbCrLf)
        For x = 0 To i - 1
START:
            f = GetRandom(0, 10) Mod 10
            For y = 0 To i - 1
                If f = arr(y) Then
                    'textboxproccess.AppendText("    CreateRndErr : Duplicate(" & y & ",... " & arr(y) & ")" & vbCrLf)
                    GoTo START
                End If
            Next y

            arr(x) = f
        Next
        f = 0
        For x = 0 To i - 1
            f *= 10
            f += arr(x)
        Next

        If max_count <> 0 Then
            now_count = 0
            textboxproccess.AppendText("Max count set : " & max_count & vbCrLf)
        End If
        textboxproccess.AppendText("Success! CreateRnd : " & f & vbCrLf)
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        count += 1
        If max_count Then
            count_.Content = "카운트 : " & count & "/" & max_count
        Else
            count_.Content = "카운트 : " & count
        End If
        'strike.setnumber(2)
        If ttx.Text = "administrator setting" Then
            setting.Show()
        ElseIf ttx.Text.Length <> i Then
            'out.Content = "숫자의 길이는 " & i & "이여야 합니다."
            textboxproccess.AppendText("Error! Text->Length is incorrect." & i & vbCrLf)
            status.Content = "숫자의 길이는 " & i & "이여야 합니다."

            System.Windows.Forms.Application.DoEvents()
            For appear As Integer = 0 To 80
                status.Opacity = (appear / 100)
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(10)
            Next

            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
            For appear As Integer = 0 To 80
                status.Opacity = (Math.Abs(appear - 80) / 100)
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(30)
            Next
            status.Opacity = 0

        Else
            If IsNumeric(ttx.Text) = False Then
                'out.Content = "값은 숫자여야 합니다."
                textboxproccess.AppendText("Error! Text is not numberic." & i & vbCrLf)
                status.Content = "값은 숫자여야 합니다."

                System.Windows.Forms.Application.DoEvents()
                For appear As Integer = 0 To 80
                    status.Opacity = (appear / 100)
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(10)
                Next

                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
                For appear As Integer = 0 To 80
                    status.Opacity = (Math.Abs(appear - 80) / 100)
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(30)
                Next
                status.Opacity = 0

            Else
                Dim ball = 0, strike = 0
                Dim smp As Integer = ttx.Text
                Dim rmp As Integer = f
                Dim i As Integer = 0
                While True
                    If smp = 0 Or rmp = 0 Then
                        Exit While
                    End If
                    Dim tmp As Integer = f
                    Dim j As Integer = 0
                    While True
                        If tmp = 0 Then
                            Exit While
                        End If
                        If smp Mod 10 = tmp Mod 10 Then
                            If i = j Then
                                strike += 1
                            Else
                                ball += 1
                            End If
                            Exit While
                        End If
                        tmp = Int(tmp / 10)
                        j += 1
                    End While
                    smp = Int(smp / 10)
                    rmp = Int(rmp / 10)
                    i += 1
                End While

                'SystemColors.con
                tout.Foreground = CType(Me.FindResource(System.Windows.SystemColors.ControlBrushKey), System.Windows.Media.Brush)
                'tout.Foreground = System.System.Windows.Media.Brushes("#FFE2E2E2")
                'If strike = Me.i Then
                '    out.Content = "게임이 끝났습니다."
                '    textboxproccess.AppendText("    Exit : Count " & count & vbCrLf)
                '    Exit Sub
                'End If
                Me.strike.SetNumber(strike)
                Me.ball.SetNumber(ball)

                If strike = Me.i Then
                    status.Content = "게임이 끝났습니다."
                    textboxproccess.AppendText("    Exit : Count " & count & vbCrLf)
                    System.Windows.Forms.Application.DoEvents()
                    For appear As Integer = 0 To 80
                        status.Opacity = (appear / 100)
                        System.Windows.Forms.Application.DoEvents()
                        System.Threading.Thread.Sleep(10)
                    Next
                    button1.IsEnabled = True
                    grid.IsEnabled = False
                    cmb.IsEnabled = True
                    aend.IsEnabled = False
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                    For appear As Integer = 0 To 80
                        status.Opacity = (Math.Abs(appear - 80) / 100)
                        System.Windows.Forms.Application.DoEvents()
                        System.Threading.Thread.Sleep(30)
                    Next
                    status.Opacity = 0
                    Exit Sub
                End If

                'If ball Then
                '    If strike Then
                '        out.Content = "Strike : " & strike & " Ball : " & ball
                '    Else
                '        out.Content = "Ball : " & ball
                '    End If
                'Else
                '    If strike Then
                '        out.Content = "Strike : " & strike
                '    Else
                '        out.Content = "Out!"
                '    End If
                'End If

                textboxproccess.AppendText("    Run : Strike " & strike & ", Ball " & ball & vbCrLf)
                If ball Or strike Then
                    textboxproccess.AppendText("    Jubge : Partial Match" & vbCrLf)
                Else
                    textboxproccess.AppendText("    Jubge : All incorrect" & vbCrLf)
                    '#FFE2E2E2
                    'tout.Foreground = CType(Me.FindResource(System.Windows.SystemColors.ControlDarkDarkBrushKey), System.Windows.Media.Brush)
                    tout.Foreground = System.Windows.Media.Brushes.Red
                    'tout.Foreground = CType(Me.FindResource(System.Windows.SystemColors.HighlightColorKey), System.Windows.Media.Brush)
                End If
                'If strike = 0 And ball = 0 Then
                'End If
                now_count += 1
                If now_count = max_count Then
                    status.Content = "게임에서 졌습니다."
                    textboxproccess.AppendText("    Exit If :  " & max_count & vbCrLf)
                    textboxproccess.AppendText("    Exit : Count " & count & vbCrLf)
                    System.Windows.Forms.Application.DoEvents()
                    For appear As Integer = 0 To 80
                        status.Opacity = (appear / 100)
                        System.Windows.Forms.Application.DoEvents()
                        System.Threading.Thread.Sleep(10)
                    Next
                    button1.IsEnabled = True
                    grid.IsEnabled = False
                    cmb.IsEnabled = True
                    aend.IsEnabled = False
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                    For appear As Integer = 0 To 80
                        status.Opacity = (Math.Abs(appear - 80) / 100)
                        System.Windows.Forms.Application.DoEvents()
                        System.Threading.Thread.Sleep(30)
                    Next
                    status.Opacity = 0
                    Exit Sub
                End If

                ttx.Text = ""
            End If
        End If
    End Sub

    Private Sub restart_click(sender As Object, e As System.Windows.RoutedEventArgs)
        End
    End Sub

    Private Sub aend_click(sender As Object, e As System.Windows.RoutedEventArgs)
        tout.Foreground = CType(Me.FindResource(System.Windows.SystemColors.ControlBrushKey), System.Windows.Media.Brush)
        textboxproccess.AppendText("    Exit : Count " & count & vbCrLf)
        button1.IsEnabled = True
        grid.IsEnabled = False
        cmb.IsEnabled = True
        aend.IsEnabled = False
        Me.strike.SetNumber(0)
        Me.ball.SetNumber(0)

    End Sub

    Private Sub ttx_KeyUp(sender As Object, e As System.Windows.Input.KeyEventArgs) Handles ttx.KeyUp
        If e.Key = System.Windows.Input.Key.Enter Then
            Button_Click_1(0, New System.Windows.RoutedEventArgs)
        End If
    End Sub

    Private Sub UserControl1_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles Me.Loaded

        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini")
        If fileExists Then
            Dim a As String = ReadIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT_USE")
            If a = "TRUE" Then
                Dim b As Integer = ReadIni(System.IO.Directory.GetCurrentDirectory & "\baseballsetting.ini", "NUMBERIC", "MAXCOUNT")
                max_count = b
            End If
        End If
    End Sub
End Class
