'/*************************************************************************
'
'   Copyright (C) 2015. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO

Public Class frmPicviewer

    Private SelectedViewer As ucViewer

    Private Sub ucViewer_MouseClick(sender As Object, e As MouseEventArgs)
        If Not IsNothing(SelectedViewer) Then
            SelectedViewer.IsSelect = False
        End If
        SelectedViewer = sender
        SelectedViewer.IsSelect = True
    End Sub

    Private Sub ucViewer_MouseDoubleClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub AddImageLabelFolder(ByVal addr As String)
        Dim ucv As New ucViewer
        Dim AddrSplit As String() = addr.Split("\")

        ucv.SetLabel(AddrSplit(AddrSplit.Length - 2), TextBox1.Font)
        ucv.Dock = DockStyle.Bottom
        ucv.SetImageFromAddress(addr, 256, 256)
        ucv.Width = (64 * 4)
        ucv.Height = (64 * 4)
        AddHandler ucv.MouseClick, New MouseEventHandler(AddressOf ucViewer_MouseClick)
        ' AddHandler ucv.MouseDoubleClick, New MouseEventHandler(AddressOf ucViewer_MouseDoubleClick)

        CustomPanel1.Controls.Add(ucv)
    End Sub

    Protected Overrides Function ScrollToControl(activeControl As Control) As Point
        Return Me.AutoScrollPosition
    End Function

    Private Sub frmPicviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        For Each addr As String In frmMain.PicViewerPictureList
            AddImageLabelFolder(addr)
            Application.DoEvents()
        Next
    End Sub

End Class