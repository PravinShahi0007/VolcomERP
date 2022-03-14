Public Class FormPreCalFGPOQty
    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        If TEQtyShipment.EditValue > 0 Then
            warningCustom("Qty shiement tidak boleh 0")
        Else
            FormPreCalFGPODet.GVListFGPO.SetFocusedRowCellValue("qty", TEQtyShipment.EditValue)
            Close()
        End If
    End Sub

    Private Sub FormPreCalFGPOQty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class