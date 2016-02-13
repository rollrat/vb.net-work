
'
'
' 출처 : http://www.codeproject.com/Articles/20013/Image-Thumbnail-Viewer-with-NET
'
' 이 코드는 위 사이트의 소스코드를 vb.net로 변환한 것 입니다.
'
'

Public Class ucViewer

    Private map As Image
    Private _IsSelect As Boolean = False
    Private label As String = ""
    Private Shadows font As Font

    Private Sub ucViewer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics

        ' 크기 조정 메서드
        Dim calcWidth As Integer = Me.Width - 8 - 30
        Dim calcHeight As Integer = Me.Height - 8 - 30

        Dim sizeCust As Double
        If (calcWidth / Convert.ToDouble(map.Width)) <= (calcHeight / Convert.ToDouble(map.Height)) Then
            sizeCust = (calcWidth / Convert.ToDouble(map.Width))
        Else
            sizeCust = (calcHeight / Convert.ToDouble(map.Height))
        End If

        ' 배열 설정
        Dim custWidth As Integer = map.Width * sizeCust
        Dim custHeight As Integer = map.Height * sizeCust

        Dim custX As Integer = 4 + (calcWidth - custWidth) / 2
        Dim custY As Integer = 4 + (calcHeight - custHeight) / 2

        ' 썸네일 그림자
        For j As Integer = 0 To 2
            g.DrawLine(New Pen(Color.DarkGray), _
                       New Point(custX + 3, custY + custHeight + 1 + j), _
                       New Point(custX + custWidth + 3, custY + custHeight + 1 + j))
            g.DrawLine(New Pen(Color.DarkGray), _
                       New Point(custX + custWidth + 1 + j, custY + 3), _
                       New Point(custX + custWidth + 1 + j, custY + custHeight + 3))
        Next

        ' 선택되었을 때 박스 그리기
        If _IsSelect Then
            g.DrawRectangle(New Pen(Color.White, 1), custX, custY, custWidth, custHeight)
            g.DrawRectangle(New Pen(Color.Blue, 2), custX - 2, custY - 2, custWidth + 4, custHeight + 4)
        End If

        g.DrawRectangle(New Pen(Brushes.Gray), custX, custY, custWidth, custHeight)
        g.DrawImage(map, custX, custY, custWidth, custHeight)

        If label <> "" Then
            g.DrawString(label, font, Brushes.Black, _
                         custX, custY + custHeight + 5)
        End If

    End Sub

    Public Property IsSelect() As Boolean
        Get
            Return _IsSelect
        End Get
        Set(value As Boolean)
            _IsSelect = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub SetLabel(ByVal label As String, ByVal font As Font)
        Me.label = label
        Me.font = font
    End Sub

    Public Sub SetImage(ByVal map As Image)
        Me.map = map
    End Sub

    Public Sub SetImageFromAddress(ByVal addr As String, ByVal pannelw As Integer, ByVal pannelh As Integer)
        Dim imt As Image = Image.FromFile(addr)

        Dim sizeCust As Double
        If (pannelw / Convert.ToDouble(imt.Width)) <= (pannelh / Convert.ToDouble(imt.Height)) Then
            sizeCust = (pannelw / Convert.ToDouble(imt.Width))
        Else
            sizeCust = (pannelh / Convert.ToDouble(imt.Height))
        End If

        Dim custWidth As Integer = imt.Width * sizeCust
        Dim custHeight As Integer = imt.Height * sizeCust

        map = New Bitmap(custWidth, custHeight)

        Dim g As Graphics = Graphics.FromImage(map)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(imt, 0, 0, custWidth, custHeight)
        g.Dispose()

        imt.Dispose()
    End Sub

    Private Sub ucViewer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Invalidate()
    End Sub

End Class
