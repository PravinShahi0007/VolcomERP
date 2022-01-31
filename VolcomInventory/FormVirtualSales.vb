Public Class FormVirtualSales
    Public is_load_new As New Boolean

    Private Sub FormVirtualSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSalesList()
    End Sub

    Private Sub FormVirtualSales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewSalesList()
        Cursor = Cursors.WaitCursor
        Dim vs As New ClassVirtualSales()
        Dim query As String = vs.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data
        GVSales.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Cursor = Cursors.WaitCursor
        FormVirtualSalesDet.action = "ins"
        FormVirtualSalesDet.id = GVSales.GetFocusedRowCellValue("id_virtual_sales").ToString
        FormVirtualSalesDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class