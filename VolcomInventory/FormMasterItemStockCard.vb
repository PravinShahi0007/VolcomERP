Public Class FormMasterItemStockCard
    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_item()
    End Sub

    Private Sub FormMasterItemStockCard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterItemStockCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_item()
        Dim q As String = "SELECT scd.id_item_detail,it.`item_desc`,scd.`item_detail`,scd.`remark`
FROM `tb_stock_card_dep_item` scd
INNER JOIN tb_item it ON it.`id_item`=scd.`id_item`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCItem.DataSource = dt
        GVItem.BestFitColumns()
    End Sub

    Private Sub BNewItem_Click(sender As Object, e As EventArgs) Handles BNewItem.Click
        FormMasterItemStockCardDet.ShowDialog()
    End Sub
End Class