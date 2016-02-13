Imports System.Drawing

Public Class Form1

    Public Shared Sub DrawLines(ByVal e As Drawing.Graphics, ByVal XYPointG_1 As Point, ByVal XYPointG_2 As Point, ByVal color As Color)
        e.DrawLine(New Pen(color, 1), XYPointG_1, XYPointG_2)
    End Sub

    '바깥에 사각형을 그림
    Public Shared Sub DrawSide(ByVal e As PaintEventArgs, ByVal color As Color, ByVal t As Integer, ByVal Width As Integer, ByVal Height As Integer)
        e.Graphics.DrawRectangle(New Pen(color, t), _
                                    t - 1, t - 1, _
                                    Width - t, _
                                    Height - t)
    End Sub

    '바깥에 사각형을 그림
    Public Shared Sub DrawSide(ByVal e As Drawing.Graphics, ByVal color As Color, ByVal t As Integer, ByVal Width As Integer, ByVal Height As Integer)
        e.DrawRectangle(New Pen(color, t), _
                                    t - 1, t - 1, _
                                    Width - t, _
                                    Height - t)
    End Sub

    Public Shared Sub DrawRect(ByVal e As PaintEventArgs, ByVal color As Color, ByVal x As Integer, ByVal y As Integer, ByVal Width As Integer, ByVal Height As Integer)
        e.Graphics.FillRectangle(New SolidBrush(color), New Rectangle(New Point(x, y), New Size(New Point(Width, Height))))
    End Sub

    Dim optimizeofthat As Integer = 20

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t(1000) As Point

        Dim a = PictureBox1.CreateGraphics()
        PictureBox1.Refresh()
        DrawLines(a, New Point(0, PictureBox1.Height / 2), New Point(PictureBox1.Width, PictureBox1.Height / 2), Color.Black)
        DrawLines(a, New Point(PictureBox1.Width / 2, 0), New Point(PictureBox1.Width / 2, PictureBox1.Height), Color.Black)

        For it = 0 To 1000
            Dim ta As Double = var(TextBox4.Text, -it / optimizeofthat, 0, TextBox4.TextLength)
            t(it).Y = PictureBox1.Height / 2 - ta * optimizeofthat
            t(it).X = (-it) + PictureBox1.Width / 2
        Next

        a.DrawCurve(Pens.Red, t)

        For it = 0 To 1000
            Dim ta As Double = var(TextBox4.Text, it / optimizeofthat, 0, TextBox4.TextLength)
            t(it).Y = PictureBox1.Height / 2 - ta * optimizeofthat
            t(it).X = (it) + PictureBox1.Width / 2
        Next

        a.DrawCurve(Pens.Red, t)
    End Sub

    Function factor(sic As String, n As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = 0
        If (sic(sic_stmt) = "(") Then
            sic_stmt += 1
            ta = var(sic, n, sic_stmt, len)
            If (sic(sic_stmt) = ")") Then
                sic_stmt += 1
                Return ta
            End If
        ElseIf "0" <= sic(sic_stmt) And sic(sic_stmt) <= "9" Then
            While True
                If "0" <= sic(sic_stmt) And sic(sic_stmt) <= "9" Then
                    ta *= 10
                    ta += sic(sic_stmt).ToString
                    sic_stmt += 1
                    If sic_stmt >= len Then Return ta
                Else
                    Exit While
                End If
            End While
        ElseIf sic(sic_stmt) = "x" Then
            sic_stmt += 1
            Return n
        ElseIf sic(sic_stmt) = "s" Then
            '원래 sin이 확실히 맞는지 검사해야되는데 구현이 귀찮아서 안함
            sic_stmt += 3
            Return Math.Sin(factor(sic, n, sic_stmt, len))
        ElseIf sic(sic_stmt) = "c" Then
            sic_stmt += 3
            Return Math.Cos(factor(sic, n, sic_stmt, len))
        ElseIf sic(sic_stmt) = "p" Then
            sic_stmt += 2
            Return Math.PI
        ElseIf sic(sic_stmt) = "e" Then
            sic_stmt += 1
            Return Math.E
        End If
        Return ta
    End Function

    Function exp(sic As String, n As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = factor(sic, n, sic_stmt, len)
        If sic_stmt >= len Then Return ta
        While sic(sic_stmt) = "*" Or sic(sic_stmt) = "/"
            If (sic(sic_stmt) = "*") Then
                sic_stmt += 1
                ta *= factor(sic, n, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            Else
                sic_stmt += 1
                ta /= factor(sic, n, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            End If
        End While
        Return ta
    End Function

    Function var(sic As String, n As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = exp(sic, n, sic_stmt, len)
        If sic_stmt >= len Then Return ta
        While sic(sic_stmt) = "+" Or sic(sic_stmt) = "-"
            If (sic(sic_stmt) = "+") Then
                sic_stmt += 1
                ta += exp(sic, n, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            Else
                sic_stmt += 1
                ta -= exp(sic, n, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            End If
        End While
        Return ta
    End Function

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim t(1000), x(1000) As Point

        For it = 0 To 1000
            Dim ta As Double = var(TextBox4.Text, -it / HScrollBar1.Value, 0, TextBox4.TextLength)
            t(it).Y = VScrollBar1.Value - ta * HScrollBar1.Value
            t(it).X = (-it) + HScrollBar2.Value
        Next

        For it = 0 To 1000
            Dim ta As Double = var(TextBox4.Text, it / HScrollBar1.Value, 0, TextBox4.TextLength)
            x(it).Y = VScrollBar1.Value - ta * HScrollBar1.Value
            x(it).X = (it) + HScrollBar2.Value
        Next

        Dim a = PictureBox1.CreateGraphics()
        PictureBox1.Refresh()
        DrawLines(a, New Point(0, VScrollBar1.Value), New Point(PictureBox1.Width, VScrollBar1.Value), Color.Black)
        DrawLines(a, New Point(HScrollBar2.Value, 0), New Point(HScrollBar2.Value, PictureBox1.Height), Color.Black)
        DrawSide(a, Color.Aqua, 2, PictureBox1.Width, PictureBox1.Height)

        a.DrawCurve(Pens.Red, t)
        a.DrawCurve(Pens.Red, x)
    End Sub

    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        Dim t(1000), x(1000) As Point

        For it = 0 To 1000
            Dim ta As Double = var(TextBox4.Text, -it / HScrollBar1.Value, 0, TextBox4.TextLength)
            t(it).Y = VScrollBar1.Value - ta * HScrollBar1.Value
            t(it).X = (-it) + HScrollBar2.Value
        Next

        For it = 0 To 1000
            Dim ta As Double = var(TextBox4.Text, it / HScrollBar1.Value, 0, TextBox4.TextLength)
            x(it).Y = VScrollBar1.Value - ta * HScrollBar1.Value
            x(it).X = (it) + HScrollBar2.Value
        Next

        Dim a = PictureBox1.CreateGraphics()
        PictureBox1.Refresh()
        DrawLines(a, New Point(0, VScrollBar1.Value), New Point(PictureBox1.Width, VScrollBar1.Value), Color.Black)
        DrawLines(a, New Point(HScrollBar2.Value, 0), New Point(HScrollBar2.Value, PictureBox1.Height), Color.Black)
        DrawSide(a, Color.Aqua, 2, PictureBox1.Width, PictureBox1.Height)

        a.DrawCurve(Pens.Red, t)
        a.DrawCurve(Pens.Red, x)
    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        Dim t(1000), x(1000) As Point

        For it = 0 To 1000
            Dim ta As Double = var(TextBox4.Text, -it / HScrollBar1.Value, 0, TextBox4.TextLength)
            t(it).Y = VScrollBar1.Value - ta * HScrollBar1.Value
            t(it).X = (-it) + HScrollBar2.Value
        Next

        For it = 0 To 1000
            Dim ta As Double = var(TextBox4.Text, it / HScrollBar1.Value, 0, TextBox4.TextLength)
            x(it).Y = VScrollBar1.Value - ta * HScrollBar1.Value
            x(it).X = (it) + HScrollBar2.Value
        Next

        Dim a = PictureBox1.CreateGraphics()
        PictureBox1.Refresh()
        DrawLines(a, New Point(0, VScrollBar1.Value), New Point(PictureBox1.Width, VScrollBar1.Value), Color.Black)
        DrawLines(a, New Point(HScrollBar2.Value, 0), New Point(HScrollBar2.Value, PictureBox1.Height), Color.Black)
        DrawSide(a, Color.Aqua, 2, PictureBox1.Width, PictureBox1.Height)

        a.DrawCurve(Pens.Red, t)
        a.DrawCurve(Pens.Red, x)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HScrollBar2.Maximum = PictureBox1.Width
        HScrollBar2.Value = PictureBox1.Width / 2
        VScrollBar1.Maximum = PictureBox1.Height
        VScrollBar1.Value = PictureBox1.Height / 2
    End Sub

End Class
