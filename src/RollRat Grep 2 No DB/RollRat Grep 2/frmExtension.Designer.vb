<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtension
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
        Me.bSave = New System.Windows.Forms.Button()
        Me.lvList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbExtension = New System.Windows.Forms.TextBox()
        Me.bAdd = New System.Windows.Forms.Button()
        Me.bDefault = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bSave
        '
        Me.bSave.Location = New System.Drawing.Point(131, 263)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(101, 23)
        Me.bSave.TabIndex = 0
        Me.bSave.Text = "&Save"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'lvList
        '
        Me.lvList.AllowDrop = True
        Me.lvList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader4})
        Me.lvList.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.lvList.FullRowSelect = True
        Me.lvList.GridLines = True
        Me.lvList.Location = New System.Drawing.Point(12, 13)
        Me.lvList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvList.Name = "lvList"
        Me.lvList.Size = New System.Drawing.Size(220, 214)
        Me.lvList.TabIndex = 22
        Me.lvList.UseCompatibleStateImageBehavior = False
        Me.lvList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Index"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Extension"
        Me.ColumnHeader4.Width = 123
        '
        'tbExtension
        '
        Me.tbExtension.Location = New System.Drawing.Point(12, 234)
        Me.tbExtension.Name = "tbExtension"
        Me.tbExtension.Size = New System.Drawing.Size(113, 23)
        Me.tbExtension.TabIndex = 23
        '
        'bAdd
        '
        Me.bAdd.Location = New System.Drawing.Point(131, 234)
        Me.bAdd.Name = "bAdd"
        Me.bAdd.Size = New System.Drawing.Size(101, 23)
        Me.bAdd.TabIndex = 24
        Me.bAdd.Text = "&Add"
        Me.bAdd.UseVisualStyleBackColor = True
        '
        'bDefault
        '
        Me.bDefault.Location = New System.Drawing.Point(12, 263)
        Me.bDefault.Name = "bDefault"
        Me.bDefault.Size = New System.Drawing.Size(113, 23)
        Me.bDefault.TabIndex = 25
        Me.bDefault.Text = "&Default"
        Me.bDefault.UseVisualStyleBackColor = True
        '
        'frmExtension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(249, 299)
        Me.Controls.Add(Me.bDefault)
        Me.Controls.Add(Me.bAdd)
        Me.Controls.Add(Me.tbExtension)
        Me.Controls.Add(Me.lvList)
        Me.Controls.Add(Me.bSave)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExtension"
        Me.Text = "Set Extension"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bSave As System.Windows.Forms.Button
    Friend WithEvents lvList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbExtension As System.Windows.Forms.TextBox
    Friend WithEvents bAdd As System.Windows.Forms.Button
    Friend WithEvents bDefault As System.Windows.Forms.Button
End Class
