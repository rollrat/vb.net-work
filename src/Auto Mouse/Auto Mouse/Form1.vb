Public Class Form1
#Region "수정금지"
    Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)
    Private Declare Function GetMessageExtraInfo Lib "user32" () As Long
    Const MOUSEEVENTF_LEFTDOWN = 2
    Const MOUSEEVENTF_LEFTUP = 4
#End Region
#Region "오토마우스 설정"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call mouse_event(MOUSEEVENTF_LEFTDOWN, 100, 100, 0, GetMessageExtraInfo()) 'If error, solve Ctrl + F5
        Call mouse_event(MOUSEEVENTF_LEFTUP, 100, 100, 0, GetMessageExtraInfo())
        Label6.Text = (Label6.Text) + 1
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label3.Text = "Off"
        Label3.ForeColor = Color.Red
        Timer1.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = False
        NumericUpDown1.Enabled = True
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label3.Text = "On"
        Label3.ForeColor = Color.Lime
        Timer1.Interval = NumericUpDown1.Value
        Timer1.Enabled = True
        Button2.Enabled = True
        Button1.Enabled = False
        NumericUpDown1.Enabled = False
    End Sub
#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
