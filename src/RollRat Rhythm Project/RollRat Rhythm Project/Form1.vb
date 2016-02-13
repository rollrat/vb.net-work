Imports System.Runtime.InteropServices

Public Class Form1

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.D Then
            PictureBox2.BackColor = Color.AliceBlue
            If Timer2.Enabled = True Then
                TextBox1.AppendText("1")
            End If
        Else
            If Timer2.Enabled = True Then
                TextBox1.AppendText("0")
            End If
        End If
        If e.KeyCode = Keys.F Then
            PictureBox3.BackColor = Color.AliceBlue
            If Timer2.Enabled = True Then
                TextBox1.AppendText("1")
            End If
        Else
            If Timer2.Enabled = True Then
                TextBox1.AppendText("0")
            End If
        End If
        If e.KeyCode = Keys.J Then
            PictureBox4.BackColor = Color.AliceBlue
            If Timer2.Enabled = True Then
                TextBox1.AppendText("1")
            End If
        Else
            If Timer2.Enabled = True Then
                TextBox1.AppendText("0")
            End If
        End If
        If e.KeyCode = Keys.K Then
            PictureBox5.BackColor = Color.AliceBlue
            If Timer2.Enabled = True Then
                TextBox1.AppendText("1" & vbCrLf)
            End If
        Else
            If Timer2.Enabled = True Then
                TextBox1.AppendText("0" & vbCrLf)
            End If
        End If
    End Sub

    Private Sub Button1_KeyUp(sender As Object, e As KeyEventArgs) Handles Button1.KeyUp
        If e.KeyCode = Keys.D Then
            PictureBox2.BackColor = Me.BackColor
        End If
        If e.KeyCode = Keys.F Then
            PictureBox3.BackColor = Me.BackColor
        End If
        If e.KeyCode = Keys.J Then
            PictureBox4.BackColor = Me.BackColor
        End If
        If e.KeyCode = Keys.K Then
            PictureBox5.BackColor = Me.BackColor
        End If
    End Sub

    Dim a(20), b(20), c(20), d(20) As Integer
    Dim s, p, f, u As Integer
    Dim af, bf, cf, df As Integer

    Private Sub Picturing_Tick(sender As Object, e As EventArgs) Handles Picturing.Tick
        Proc_A()
        Proc_B()
        Proc_C()
        Proc_D()
        Threading.Thread.Sleep(30)
    End Sub

    Sub Proc_A()
        Dim g As Graphics = PictureBox2.CreateGraphics
        For BZX = 0 To s
            g.FillRectangle(Brushes.Aqua, 0, a(BZX), PictureBox2.Width, 10)
        Next
        PictureBox2.Invalidate()
    End Sub
    Sub Proc_B()
        Dim g As Graphics = PictureBox3.CreateGraphics
        For BZX = 0 To p
            g.FillRectangle(Brushes.Aqua, 0, b(BZX), PictureBox3.Width, 10)
        Next
        PictureBox3.Invalidate()
    End Sub
    Sub Proc_C()
        Dim g As Graphics = PictureBox4.CreateGraphics
        For BZX = 0 To f
            g.FillRectangle(Brushes.Aqua, 0, c(BZX), PictureBox4.Width, 10)
        Next
        PictureBox4.Invalidate()
    End Sub
    Sub Proc_D()
        Dim g As Graphics = PictureBox5.CreateGraphics
        For BZX = 0 To u
            g.FillRectangle(Brushes.Aqua, 0, d(BZX), PictureBox5.Width, 10)
        Next
        PictureBox5.Invalidate()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For BXZ = 0 To s
            a(BXZ) += 10
        Next
        For BXZ = 0 To p
            b(BXZ) += 10
        Next
        For BXZ = 0 To f
            c(BXZ) += 10
        Next
        For BXZ = 0 To u
            d(BXZ) += 10
        Next
    End Sub

    Dim x As Integer

    Private Sub AnalPath_Tick(sender As Object, e As EventArgs) Handles AnalPath.Tick
        ListBox1.SelectedIndex = x
        Dim sd As String = ListBox1.SelectedItem.ToString
        If sd(0) = "1" Then
            If s <> 20 Then
                s += 1
            End If
            af += 1
            If af = 21 Then
                af = 0
            End If
            a(af) = 0
        End If
        If sd(1) = "1" Then
            If p <> 20 Then
                p += 1
            End If
            bf += 1
            If bf = 21 Then
                bf = 0
            End If
            b(bf) = 0
        End If
        If sd(2) = "1" Then
            If f <> 20 Then
                f += 1
            End If
            cf += 1
            If cf = 21 Then
                cf = 0
            End If
            c(cf) = 0
        End If
        If sd(3) = "1" Then
            If u <> 20 Then
                u += 1
            End If
            df += 1
            If df = 21 Then
                df = 0
            End If
            d(df) = 0
        End If
        x += 1
        If x = ListBox1.Items.Count Then
            x = 0
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Picturing.Enabled = True
        Timer1.Enabled = True
        AnalPath.Enabled = True
        Button1.Focus()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Timer2.Enabled = True
        Button1.Focus()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        TextBox1.AppendText("0000" & vbCrLf)
        Threading.Thread.Sleep(90)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RichTextBox1.Text = TextBox1.Text
    End Sub

End Class
