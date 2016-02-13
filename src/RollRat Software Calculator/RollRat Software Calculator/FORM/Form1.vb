Public Class Form1

    Dim optimizeofthat As Integer = 10
    Dim asdf As Boolean = False

#Region "   Mouse Control                "

    Dim LastMPoint As Point
    Dim MPoint As Point = Control.MousePosition
    Dim MDown As Boolean = False
    Dim LastMPointe As Point
    Dim LastMPointes As Point

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        MDown = True
        ReleaseCapture()
        SendMessage(Me.Handle.ToInt32(), WM_SYSCOMMAND, SC_FORMMOVE, 0)
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        MDown = False
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        LastMPoint = New Point(MPoint.X - LastMPoint.X, MPoint.Y - LastMPoint.Y)
        If MDown = True Then
            MPoint = New Point(MPoint.X - LastMPoint.X, MPoint.Y - LastMPoint.Y)
            'Me.Size = New Size(Me.Size.Width + MPoint.X, Me.Size.Height + MPoint.Y)
            LastMPoint = MPoint
        End If
    End Sub

    Private Sub Form1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            optimizeofthat += 1
            PictureBox1.Invalidate()
        Else
            If optimizeofthat > 10 Then
                optimizeofthat -= 1
                PictureBox1.Invalidate()
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        asdf = True
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        LastMPointes = Control.MousePosition
        If (LastMPointe.X <> LastMPointes.X) And (LastMPointe.Y <> LastMPointes.Y) Then
            If asdf Then
                Dim at As Graphics = PictureBox1.CreateGraphics
                at.DrawLine(New Pen(Color.CadetBlue, 2), New Point(e.X, 0), New Point(e.X, PictureBox1.Height))
                at.DrawLine(New Pen(Color.CadetBlue, 2), New Point(0, e.Y), New Point(PictureBox1.Width, e.Y))
                'PictureBox1.Update()
                LastMPointe = Control.MousePosition
            End If
        Else
            PictureBox1.Invalidate()
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        asdf = False
    End Sub

#End Region

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        FGraphic.DrawLines(e, New Point(0, PictureBox1.Height / 2), New Point(PictureBox1.Width, PictureBox1.Height / 2), Color.Black)
        FGraphic.DrawLines(e, New Point(PictureBox1.Width / 2, 0), New Point(PictureBox1.Width / 2, PictureBox1.Height), Color.Black)
        Dim i As Single = 0
        Do While i < PictureBox1.Width
            i += PictureBox1.Width / optimizeofthat
            FGraphic.DrawLines(e, New Point(i, PictureBox1.Height / 2 - 5), New Point(i, PictureBox1.Height / 2 + 5), Color.Black)
            'e.Graphics.DrawString(Convert.ToInt32(f), Me.Font, Brushes.Black, New PointF(i - 5, PictureBox1.Height / 2 + 5))
        Loop
        i = 0 ' set middle of x, y
        Do While i < PictureBox1.Height
            i += PictureBox1.Height / optimizeofthat
            FGraphic.DrawLines(e, New Point(PictureBox1.Width / 2 - 5, i), New Point(PictureBox1.Width / 2 + 5, i), Color.Black)
        Loop

        Dim t(1000) As Point
        For it = 0 To 1000
            t(it).Y = (PictureBox1.Height / 2 - Math.Sqrt(it) * optimizeofthat / 2)
            t(it).X = (PictureBox1.Width / 2 + it)
        Next
        e.Graphics.DrawCurve(Pens.Red, t)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        FGraphic.DrawSide(e, Color.Aqua, 2, Me.Size.Width, Me.Size.Height)
        FGraphic.DrawRect(e, Color.Aquamarine, 2, Me.Size.Height - 19, Me.Size.Width - 4, 17)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
