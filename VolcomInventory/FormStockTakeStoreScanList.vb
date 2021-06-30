Public Class FormStockTakeStoreScanList
    Public id_period As String = "-1"
    Public id_product As String = "-1"
    Private Sub FormStockTakeStoreScanList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormStockTakeStoreScanList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class