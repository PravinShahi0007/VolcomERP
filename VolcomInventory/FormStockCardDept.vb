Public Class FormStockCardDept
    Private Sub BtnViewSC_Click(sender As Object, e As EventArgs) Handles BtnViewSC.Click

    End Sub

    Private Sub BAddInOut_Click(sender As Object, e As EventArgs) Handles BAddInOut.Click
        FormStockCardDepDet.ShowDialog()
    End Sub
End Class