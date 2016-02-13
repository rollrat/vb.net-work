Public Class Form1

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Draw()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Draw()
    End Sub

    Dim FromTo As Integer = 200

    Private Sub Draw()
        Dim Center As Integer = Convert.ToInt32(PictureBox1.Width / 2)

        Dim gp As Graphics = PictureBox1.CreateGraphics
        gp.Clear(PictureBox1.BackColor)
        gp.DrawEllipse(Pens.Black, New Rectangle( _
                       FromTo, FromTo, PictureBox1.Width - FromTo * 2, PictureBox1.Width - FromTo * 2))
        gp.DrawRectangle(Pens.Black, Center - 1, Center - 1, 2, 2)
        gp.FillRectangle(Brushes.Black, Center - 1, Center - 1, 2, 2)

        ' 원의 반지름
        Dim r As Integer = PictureBox1.Width / 2 - FromTo
        Dim angle As Integer = NumericUpDown1.Value '육십분법
        Dim BaseDegree As Double = Math.PI / 180.0F

        'Draw r line
        ' x^2+y^2=r^2
        ' y=sqrt(r^2-x^2)
        ' y=sqrt(r^2-r^2cos^2(t))
        ' y=r*sqrt(1-cos^2(t))
        ' y=r*sin(t)
        Dim Sine As Double = Math.Sin(angle * BaseDegree)
        Dim Cosine As Double = Math.Cos(angle * BaseDegree)
        Dim xS As Integer = r * Cosine
        Dim yS As Integer = r * Sine
        gp.DrawLine(Pens.Black, Center, Center, _
                    Center + xS, Center - yS)

        'Draw Tangent Line
        ' x1x+y1y=r^2
        ' y'=-x/y
        ' y=a(x-b)+c
        Dim a As Double = -1 / Math.Tan(angle * BaseDegree)
        Dim b As Double = xS
        Dim c As Double = yS
        'Dim tangent = Function(x) As Integer
        '                  Return a * (x - b) + c
        '              End Function
        'If angle = 0 Or angle = 360 Or angle = 180 Then
        '    gp.DrawLine(Pens.Black, Center + xS, Center + 1000, _
        '                Center + xS, Center - 1000)
        'Else
        '    gp.DrawLine(Pens.Black, Center + xS - 1000, Center - tangent(xS - 1000), _
        '                Center + xS + 1000, Center - tangent(xS + 1000))
        'End If

        'Draw Incidence & Reflection Line
        Dim irAngle As Integer = NumericUpDown2.Value
        ' y=tan(angle-iciangle+90)(x-b)+c
        Dim IncidenceAngle As Integer = angle - irAngle + 90
        Dim Incidence = Function(x) As Integer
                            Return Math.Tan(IncidenceAngle * BaseDegree) * (x - b) + c
                        End Function
        If Not (IncidenceAngle = 90 Or IncidenceAngle = 270 Or IncidenceAngle = -90 Or IncidenceAngle = -270) Then
            gp.DrawLine(Pens.Black, Center + xS - 1000, Center - Incidence(xS - 1000), _
                        Center + xS, Center - yS)
        End If

        ' y=tan(angle+iciangle-90)(x-b)+c
        Dim ReflectionAngle As Integer = angle + irAngle - 90
        Dim Reflection = Function(x) As Integer
                             Return Math.Tan(ReflectionAngle * BaseDegree) * (x - b) + c
                         End Function
        If Not (ReflectionAngle = 90 Or ReflectionAngle = 270 Or ReflectionAngle = -90 Or ReflectionAngle = -270) Then
            gp.DrawLine(Pens.Black, Center + xS + 1000, Center - Reflection(xS + 1000), _
                        Center + xS, Center - yS)
        End If

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value = 360 Then
            NumericUpDown1.Value = 1
        End If
        Draw()
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If NumericUpDown2.Value = 360 Then
            NumericUpDown2.Value = 1
        End If
        Draw()
    End Sub

End Class
