Public Class CustomPanel
    Inherits FlowLayoutPanel
    Protected Overrides Function ScrollToControl(activeControl As Control) As Point
        ' Returning the current location prevents the panel from
        ' scrolling to the active control when the panel loses and regains focus
        Return DisplayRectangle.Location
    End Function
End Class