Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ProgressBar1
            .Minimum = 1
            .Maximum = 100000
            .Value = 1
            .Step = 1

            For i As Integer = .Minimum To .Maximum
                ' Perform one step of the action being tracked.
                .PerformStep()
            Next i

        End With
        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists("G:\★pass.dat")
        If fileExists = True Then
            Dim fileContents As String
            fileContents = My.Computer.FileSystem.ReadAllText("G:\★pass.dat")
            If fileContents = "ghg4j65g4h65j46f5g4j321gh32465d4f32h1set4y8rsdh79gf4j5hgd13m21hg53m4cb654gb8x9gd7fs8hg4354era61g32fd14d6b87897bxn897m878c7n6847m465bv4c65n456g6h465s4dfh654s56t4dy5e4s654w564er56g45sfd431b32132ns13543x545cvn6456x4bvn5x465c4n64xcv8h7s98h7er4hg65r4e23g1df32s5n4g65f465x4cv654v6b7d8sf97y98ew87y8r4y564w65er4y5643s21n5x6cv4xb56s4f56g4ds5f1g32sr4g56dfh132cb1n23cb45n64z56423a12e16w5q4g5er64ag65fda4h5645gd456b456d4fs564g56465w45648r7ta54231v564ca8s75e421f54d8a68fe6s454f56g123zxc1b2v3zcxb12c1xv32b456a4dfg89qre7t65we4f321sda21v2cb1z5xcv45asd6f7ds8r9w56q5s4ad3sv21zc3x21v2cb3z5x4g65das7r8e9wq65d46sa4g21b2c3z1cv32z45f6ds57q89er5ew4t54g2d1a2313b45a6s46dg65sd7t8r6as5g4f564a56n4123a1bfa6d54t" Then
                ProgressBar1.Visible = False
            Else
                MsgBox("★Pass.dat is damaged.", MsgBoxStyle.Critical, "Error 000x002")
                End
            End If
        Else
            MsgBox("G drive connectivity or file does not exist.", MsgBoxStyle.Critical, "Error 000x001")
            End
        End If
    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class
