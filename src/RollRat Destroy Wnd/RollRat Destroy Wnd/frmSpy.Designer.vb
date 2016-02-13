<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpy
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSpy))
        Me.labelFinderTool = New System.Windows.Forms.Label()
        Me.pictureBox = New System.Windows.Forms.PictureBox()
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelFinderTool
        '
        Me.labelFinderTool.Location = New System.Drawing.Point(12, 17)
        Me.labelFinderTool.Name = "labelFinderTool"
        Me.labelFinderTool.Size = New System.Drawing.Size(80, 18)
        Me.labelFinderTool.TabIndex = 20
        Me.labelFinderTool.Text = "Finder Tool:"
        '
        'pictureBox
        '
        Me.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pictureBox.Image = CType(resources.GetObject("pictureBox.Image"), System.Drawing.Image)
        Me.pictureBox.Location = New System.Drawing.Point(98, 7)
        Me.pictureBox.Name = "pictureBox"
        Me.pictureBox.Size = New System.Drawing.Size(31, 28)
        Me.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox.TabIndex = 13
        Me.pictureBox.TabStop = False
        '
        'imageList
        '
        Me.imageList.ImageStream = CType(resources.GetObject("imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList.Images.SetKeyName(0, "")
        Me.imageList.Images.SetKeyName(1, "")
        '
        'frmSpy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(145, 43)
        Me.Controls.Add(Me.labelFinderTool)
        Me.Controls.Add(Me.pictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSpy"
        Me.Text = "Spy"
        CType(Me.pictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents labelFinderTool As System.Windows.Forms.Label
    Private WithEvents pictureBox As System.Windows.Forms.PictureBox
    Private WithEvents imageList As System.Windows.Forms.ImageList
    Private WithEvents toolTip As System.Windows.Forms.ToolTip
End Class
