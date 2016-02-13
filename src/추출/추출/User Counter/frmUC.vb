Public Class frmUC

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckBox1.Checked = False Then
            For Ff = CInt(TextBox8.Text) To CInt(TextBox6.Text)
                If Button1.Text = "Enable" Then
                    If TextBox5.Text > 0 Then
                        If Ff Mod TextBox5.Text = 0 Then
                            If CheckBox2.Checked = True Then
                                If CheckBox3.Checked = True Then
                                    If CheckBox4.Checked = True Then
                                        RichTextBox1.AppendText(TextBox3.Text & TextBox7.Text & TextBox1.Text & Ff & TextBox2.Text)
                                    Else
                                        RichTextBox1.AppendText(TextBox7.Text & TextBox1.Text & Ff & TextBox2.Text & TextBox3.Text)
                                    End If
                                Else
                                    If CheckBox4.Checked = True Then
                                        RichTextBox1.AppendText(TextBox3.Text & TextBox1.Text & Ff & TextBox2.Text & TextBox7.Text)
                                    Else
                                        RichTextBox1.AppendText(TextBox1.Text & Ff & TextBox2.Text & TextBox3.Text & TextBox7.Text)
                                    End If
                                    RichTextBox1.AppendText(TextBox1.Text & Ff & TextBox2.Text & TextBox3.Text & TextBox7.Text)
                                End If
                            Else
                                RichTextBox1.AppendText(TextBox1.Text & Ff & TextBox2.Text & TextBox7.Text & TextBox3.Text)
                            End If
                        Else
                            RichTextBox1.AppendText(TextBox1.Text & Ff & TextBox2.Text & TextBox3.Text)
                        End If
                    End If
                Else
                    RichTextBox1.AppendText(TextBox1.Text & Ff & TextBox2.Text & TextBox3.Text)
                End If
                If TextBox4.Text > 0 Then
                    If Ff Mod TextBox4.Text = 0 Then
                        RichTextBox1.AppendText(vbCrLf)
                    End If
                End If
            Next
        Else
            For Ff = CInt(TextBox8.Text) To CInt(TextBox6.Text)
                If Button1.Text = "Enable" Then
                    If TextBox5.Text > 0 Then
                        If Ff Mod TextBox5.Text = 0 Then
                            If CheckBox2.Checked = True Then
                                If CheckBox3.Checked = True Then
                                    If CheckBox4.Checked = True Then
                                        RichTextBox1.AppendText(TextBox3.Text & TextBox7.Text & TextBox1.Text & Ff.ToString("X") & TextBox2.Text)
                                    Else
                                        RichTextBox1.AppendText(TextBox7.Text & TextBox1.Text & Ff.ToString("X") & TextBox2.Text & TextBox3.Text)
                                    End If
                                Else
                                    If CheckBox4.Checked = True Then
                                        RichTextBox1.AppendText(TextBox3.Text & TextBox1.Text & Ff.ToString("X") & TextBox2.Text & TextBox7.Text)
                                    Else
                                        RichTextBox1.AppendText(TextBox1.Text & Ff.ToString("X") & TextBox2.Text & TextBox3.Text & TextBox7.Text)
                                    End If
                                    RichTextBox1.AppendText(TextBox1.Text & Ff.ToString("X") & TextBox2.Text & TextBox3.Text & TextBox7.Text)
                                End If
                            Else
                                RichTextBox1.AppendText(TextBox1.Text & Ff.ToString("X") & TextBox2.Text & TextBox7.Text & TextBox3.Text)
                            End If
                        Else
                            RichTextBox1.AppendText(TextBox1.Text & Ff.ToString("X") & TextBox2.Text & TextBox3.Text)
                        End If
                    End If
                Else
                    RichTextBox1.AppendText(TextBox1.Text & Ff.ToString("X") & TextBox2.Text & TextBox3.Text)
                End If
                If TextBox4.Text > 0 Then
                    If Ff Mod TextBox4.Text = 0 Then
                        RichTextBox1.AppendText(vbCrLf)
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Disenable" Then
            Button1.Text = "Enable"
        Else
            Button1.Text = "Disenable"
        End If
    End Sub

    Private Sub frmUC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class