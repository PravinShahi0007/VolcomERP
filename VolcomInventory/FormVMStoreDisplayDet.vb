Public Class FormVMStoreDisplayDet
    Public id_store As String = "-1"

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print(GCData, "Display Item List")
    End Sub

    Private Sub FormVMStoreDisplayDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormVMStoreDisplayDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ds.id_item, i.item_desc, dt.display_type,  SUM(ds.qty) AS `qty`
        FROM tb_display_store ds 
        INNER JOIN tb_item i ON i.id_item = ds.id_item
        INNER JOIN tb_display_type dt ON dt.id_display_type = i.id_display_type
        WHERE ds.id_comp=" + id_store + "
        GROUP BY i.id_item
        ORDER BY i.item_desc ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddItem_Click(sender As Object, e As EventArgs) Handles BtnAddItem.Click
        Cursor = Cursors.WaitCursor
        FormVMStoreDisplayQty.id_item = "-1"
        FormVMStoreDisplayQty.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class