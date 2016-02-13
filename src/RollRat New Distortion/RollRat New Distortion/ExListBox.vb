'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class ExListBox
    Inherits ListBox

    Public MaxColoredTextLength As Integer = 0

    Public Sub New()
        Me.Hide()
        Me.BackColor = System.Drawing.Color.FromArgb(64, 64, 64)
        Me.ScrollAlwaysVisible = True
        Me.DrawMode = DrawMode.OwnerDrawVariable
    End Sub

    Public Shared Function MeasureText(Text As String, Font As Font) As Size
        Dim flags As TextFormatFlags = TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix
        Dim szProposed As New Size(Integer.MaxValue, Integer.MaxValue)
        Dim sz1 As Size = TextRenderer.MeasureText(".", Font, szProposed, flags)
        Dim sz2 As Size = TextRenderer.MeasureText(Text & Convert.ToString("."), Font, szProposed, flags)
        Return New Size(sz2.Width - sz1.Width, sz2.Height)
    End Function

    Private Sub ExListBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()

        If (e.State And DrawItemState.Selected) Then
            e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds)
        End If

        Dim firstdraw As String = Me.Items(e.Index).ToString().Substring(0, MaxColoredTextLength)
        e.Graphics.DrawString(firstdraw, Me.Font, Brushes.Orange, New PointF(e.Bounds.X, e.Bounds.Y))

        Dim mesaure As Integer = MeasureText(firstdraw, Me.Font).Width
        e.Graphics.DrawString(Me.Items(e.Index).ToString().Substring(MaxColoredTextLength), Me.Font, Brushes.White, _
                              New PointF(e.Bounds.X + mesaure, e.Bounds.Y))

        e.DrawFocusRectangle()
    End Sub

    Private Sub ExListBox_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles Me.MeasureItem
        If Me.Items.Count > 0 Then
            Dim size As SizeF = e.Graphics.MeasureString(Me.Items.Item(e.Index).ToString, Me.Font)
            e.ItemHeight = size.Height
            e.ItemWidth = size.Width
        End If
    End Sub

End Class
