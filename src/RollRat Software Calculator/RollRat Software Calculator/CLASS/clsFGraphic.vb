Imports System.Drawing

Public Class FGraphic

    Public Shared Sub DrawLines(ByVal e As PaintEventArgs, ByVal XYPointG_1 As Point, ByVal XYPointG_2 As Point, ByVal color As Color)
        e.Graphics.DrawLine(New Pen(color, 1), XYPointG_1, XYPointG_2)
    End Sub

    Public Shared Sub DrawSide(ByVal e As PaintEventArgs, ByVal color As Color, ByVal t As Integer, ByVal Width As Integer, ByVal Height As Integer)
        e.Graphics.DrawRectangle(New Pen(color, t), _
                                    t - 1, t - 1, _
                                    Width - t, _
                                    Height - t)
    End Sub

    Public Shared Sub DrawRect(ByVal e As PaintEventArgs, ByVal color As Color, ByVal x As Integer, ByVal y As Integer, ByVal Width As Integer, ByVal Height As Integer)
        e.Graphics.FillRectangle(New SolidBrush(color), New Rectangle(New Point(x, y), New Size(New Point(Width, Height))))
    End Sub

End Class
