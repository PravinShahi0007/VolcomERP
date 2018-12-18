Public Class FormItemReqAddStore
    Private Sub FormItemReqAddStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCat()
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub


    Sub viewItem()
        Cursor = Cursors.WaitCursor
        Dim id_item_cat As String = "-1"
        Try
            id_item_cat = SLECat.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim cond As String = ""
        If id_item_cat = "0" Then
            cond = ""
        Else
            cond = "AND i.id_item_cat = '" + id_item_cat + "' "
        End If
        Dim query As String = "SELECT i.id_item, i.item_desc , u.uom
        FROM tb_item i 
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        WHERE i.id_item>0 " + cond
        viewSearchLookupQuery(SLEItem, query, "id_item", "item_desc", "id_item")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormItemReqAddStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLECat_EditValueChanged(sender As Object, e As EventArgs) Handles SLECat.EditValueChanged
        viewItem()
    End Sub
End Class