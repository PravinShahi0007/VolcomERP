Public Class FormPricePolicyCode
    Private Sub FormPricePolicyCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cpc As New ClassPricePolicy()
        GCData.DataSource = cpc.dataMain("-1", "1")
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class