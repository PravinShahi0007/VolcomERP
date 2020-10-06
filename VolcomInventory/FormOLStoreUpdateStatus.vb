Public Class FormOLStoreUpdateStatus
    Private Sub FormOLStoreUpdateStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewOLStore()
    End Sub

    Sub viewOLStore()
        Cursor = Cursors.WaitCursor
        Dim id_vios As String = get_setup_field("shopify_comp_group")
        Dim query As String = "SELECT cg.id_comp_group, cg.description 
        FROM tb_m_comp_group cg WHERE cg.is_use_api=1 AND cg.id_comp_group NOT IN(" + id_vios + ")
        ORDER BY cg.idx_prior_order ASC "
        viewSearchLookupQuery(SLEOLStore, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub


    Private Sub FormOLStoreUpdateStatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub
End Class