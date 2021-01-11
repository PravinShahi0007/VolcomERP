Public Class FormCompareStockWebsiteDetailBook
    Public id_log As String = "-1"
    Private Sub FormCompareStockWebsiteDetailBook_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormCompareStockWebsiteDetailBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT s.id_order, s.order_number, s.order_date, s.customer_name, s.sku, s.qty, s.id_log_compare_shopify 
        FROM tb_shopify_open_order s 
        WHERE s.id_log_compare_shopify=" + id_log + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewBook_Click(sender As Object, e As EventArgs) Handles BtnViewBook.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "Item Booked Detail")
        Cursor = Cursors.Default
    End Sub
End Class