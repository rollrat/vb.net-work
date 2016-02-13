Imports System.Drawing

Public Class Form1

    '
    ' simple graph plot
    '
    ' copyright (c) rollrat. 2014. all rights reserved.
    '


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

    Public Shared Sub DrawRect(ByVal e As PaintEventArgs, ByVal color As Color, ByVal x As Integer, ByVal y As Integer, ByVal Width As Integer, ByVal Height As Integer)
        e.Graphics.FillRectangle(New SolidBrush(color), New Rectangle(New Point(x, y), New Size(New Point(Width, Height))))
    End Sub

    Dim optimizeofthat As Integer = 10

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t(1000) As Point

        For it = 1 To 1000
            Dim ta As Double = 0
            For s = 1 To Convert.ToInt64(TextBox3.Text)
                'ta += 1 / s * Math.Sin(s * it / 100)
                ta += var(TextBox4.Text, s, it, 0, TextBox4.TextLength)
            Next
            t(it).Y = PictureBox1.Height / 2 - ta * TextBox1.Text
            t(it).X = (it)
        Next

        Dim a = PictureBox1.CreateGraphics()
        PictureBox1.Refresh()
        DrawLines(a, New Point(0, PictureBox1.Height / 2), New Point(PictureBox1.Width, PictureBox1.Height / 2), Color.Black)
        DrawLines(a, New Point(0, 0), New Point(0, PictureBox1.Height), Color.Black)

        a.DrawCurve(Pens.Red, t)
    End Sub

    Function factor(sic As String, n As Double, s As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = 0
        If (sic(sic_stmt) = "(") Then
            sic_stmt += 1
            ta = var(sic, n, s, sic_stmt, len)
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
        ElseIf sic(sic_stmt) = "n" Then
            sic_stmt += 1
            Return n
        ElseIf sic(sic_stmt) = "x" Then
            sic_stmt += 1
            Return s
        ElseIf sic(sic_stmt) = "s" Then
            '원래 sin이 확실히 맞는지 검사해야되는데 구현이 귀찮아서 안함
            sic_stmt += 3
            Return Math.Sin(factor(sic, n, s, sic_stmt, len))
        ElseIf sic(sic_stmt) = "c" Then
            sic_stmt += 3
            Return Math.Cos(factor(sic, n, s, sic_stmt, len))
        ElseIf sic(sic_stmt) = "p" Then
            sic_stmt += 2
            Return Math.PI
        ElseIf sic(sic_stmt) = "e" Then
            sic_stmt += 1
            Return Math.E
        End If
        Return ta
    End Function

    Function exp(sic As String, n As Double, s As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = factor(sic, n, s, sic_stmt, len)
        While sic(sic_stmt) = "*" Or sic(sic_stmt) = "/"
            If (sic(sic_stmt) = "*") Then
                sic_stmt += 1
                ta *= factor(sic, n, s, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            Else
                sic_stmt += 1
                ta /= factor(sic, n, s, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            End If
        End While
        Return ta
    End Function

    Function var(sic As String, n As Double, s As Double, ByRef sic_stmt As Double, len As Integer) As Double
        Dim ta As Double = exp(sic, n, s, sic_stmt, len)
        If sic_stmt >= len Then Return ta
        While sic(sic_stmt) = "+" Or sic(sic_stmt) = "-"
            If (sic(sic_stmt) = "+") Then
                sic_stmt += 1
                ta += exp(sic, n, s, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            Else
                sic_stmt += 1
                ta -= exp(sic, n, s, sic_stmt, len)
                If sic_stmt >= len Then Return ta
            End If
        End While
        Return ta
    End Function

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim t(1000) As Point

        For it = 1 To 1000
            Dim ta As Double = 0
            For s = 1 To Convert.ToInt64(HScrollBar1.Value)
                'ta += 1 / s * Math.Sin(s * it / 100)
                ' ta += var(TextBox4.Text, s, it, 0, TextBox4.TextLength)
                ta += 1 / (Math.Sqrt(s)) * Math.Sin(s * it / 100)
            Next
            t(it).Y = PictureBox1.Height / 2 - ta * 50
            t(it).X = (it)
        Next

        Dim a = PictureBox1.CreateGraphics()
        PictureBox1.Refresh()
        DrawLines(a, New Point(0, PictureBox1.Height / 2), New Point(PictureBox1.Width, PictureBox1.Height / 2), Color.Black)
        DrawLines(a, New Point(0, 0), New Point(0, PictureBox1.Height), Color.Black)

        a.DrawCurve(Pens.Red, t)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

End Class
