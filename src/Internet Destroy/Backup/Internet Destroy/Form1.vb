Imports System.Deployment
Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Add("Read Internet")
        FolderBrowserDialog1.ShowDialog()
        ListBox2.Items.Add("Internet " + FolderBrowserDialog1.SelectedPath + "\iexplore.exe")
        ListBox1.Items.Add("Save Internet")
    End Sub
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        SendKeys.SendWait("{" + RichTextBox2.Text + "}")
        ListBox3.Items.Add("KeySend : " + "{" + RichTextBox2.Text + "}")
    End Sub
    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        For Each proc As Process In Process.GetProcessesByName(RichTextBox6.Text)
            proc.CloseMainWindow()
        Next
        ListBox7.Items.Add("Killprocess : " + RichTextBox6.Text)
    End Sub

   
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripContainer1_ContentPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripContainer1.ContentPanel.Load

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
