<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResult
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
        Me.bEnd = New System.Windows.Forms.Button()
        Me.lvResult = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bRun = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bEnd
        '
        Me.bEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bEnd.Location = New System.Drawing.Point(498, 232)
        Me.bEnd.Name = "bEnd"
        Me.bEnd.Size = New System.Drawing.Size(150, 35)
        Me.bEnd.TabIndex = 0
        Me.bEnd.Text = "&Close"
        Me.bEnd.UseVisualStyleBackColor = True
        '
        'lvResult
        '
        Me.lvResult.AllowDrop = True
        Me.lvResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvResult.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.lvResult.FullRowSelect = True
        Me.lvResult.GridLines = True
        Me.lvResult.Location = New System.Drawing.Point(12, 13)
        Me.lvResult.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvResult.Name = "lvResult"
        Me.lvResult.Size = New System.Drawing.Size(636, 212)
        Me.lvResult.TabIndex = 22
        Me.lvResult.UseCompatibleStateImageBehavior = False
        Me.lvResult.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Index"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Line"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 46
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Data"
        Me.ColumnHeader3.Width = 496
        '
        'bRun
        '
        Me.bRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bRun.Location = New System.Drawing.Point(12, 232)
        Me.bRun.Name = "bRun"
        Me.bRun.Size = New System.Drawing.Size(150, 35)
        Me.bRun.TabIndex = 23
        Me.bRun.Text = "&Run File"
        Me.bRun.UseVisualStyleBackColor = True
        '
        'frmResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 279)
        Me.Controls.Add(Me.bRun)
        Me.Controls.Add(Me.lvResult)
        Me.Controls.Add(Me.bEnd)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(676, 318)
        Me.Name = "frmResult"
        Me.Text = "Grep Result:"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bEnd As System.Windows.Forms.Button
    Friend WithEvents lvResult As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents bRun As System.Windows.Forms.Button
End Class
