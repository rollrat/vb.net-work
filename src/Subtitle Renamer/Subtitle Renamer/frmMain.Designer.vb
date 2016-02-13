<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cbAnime = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbSubtitleAddr = New System.Windows.Forms.TextBox()
        Me.tbMovieAddr = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.bSubtitle = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbAnime
        '
        Me.cbAnime.AutoSize = True
        Me.cbAnime.Checked = True
        Me.cbAnime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAnime.Location = New System.Drawing.Point(669, 94)
        Me.cbAnime.Name = "cbAnime"
        Me.cbAnime.Size = New System.Drawing.Size(122, 19)
        Me.cbAnime.TabIndex = 80
        Me.cbAnime.Text = "숫자 두 자리 맞춤"
        Me.cbAnime.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(105, 98)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(406, 15)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "구조가 조금 다르더라도 패턴이 같으면 제일 많이 다른 패턴만 치환합니다."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(105, 113)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(439, 15)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "또한, ""숫자 두 자리 맞춤""에 체크가 해제되면 파일 이름 순서에 따라 치환합니다."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(105, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(481, 15)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "동영상에선 숫자를 제외한 부분을, 자막에선 숫자 부분만을 가져와 자막에 적용시킵니다."
        '
        'tbSubtitleAddr
        '
        Me.tbSubtitleAddr.AllowDrop = True
        Me.tbSubtitleAddr.Location = New System.Drawing.Point(96, 46)
        Me.tbSubtitleAddr.Name = "tbSubtitleAddr"
        Me.tbSubtitleAddr.Size = New System.Drawing.Size(525, 23)
        Me.tbSubtitleAddr.TabIndex = 76
        '
        'tbMovieAddr
        '
        Me.tbMovieAddr.AllowDrop = True
        Me.tbMovieAddr.Location = New System.Drawing.Point(96, 15)
        Me.tbMovieAddr.Name = "tbMovieAddr"
        Me.tbMovieAddr.Size = New System.Drawing.Size(525, 23)
        Me.tbMovieAddr.TabIndex = 75
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(24, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 15)
        Me.Label14.TabIndex = 74
        Me.Label14.Text = "자막 폴더: "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "동영상 폴더: "
        '
        'bSubtitle
        '
        Me.bSubtitle.Location = New System.Drawing.Point(646, 21)
        Me.bSubtitle.Name = "bSubtitle"
        Me.bSubtitle.Size = New System.Drawing.Size(176, 41)
        Me.bSubtitle.TabIndex = 72
        Me.bSubtitle.Text = "동영상 && 자막 맞추기"
        Me.bSubtitle.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 15)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Copyright (C) 2015. rollrat. All Rights Reserved."
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 169)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbAnime)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.tbSubtitleAddr)
        Me.Controls.Add(Me.tbMovieAddr)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.bSubtitle)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Subtitle Renamer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbAnime As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbSubtitleAddr As System.Windows.Forms.TextBox
    Friend WithEvents tbMovieAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents bSubtitle As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
