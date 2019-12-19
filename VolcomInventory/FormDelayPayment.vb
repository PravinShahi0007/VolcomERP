Public Class FormDelayPayment
    Private Sub FormDelayPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDelayPayment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDelayPayment_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormDelayPayment_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class