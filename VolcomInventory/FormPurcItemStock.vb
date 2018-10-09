Public Class FormPurcItemStock
    Private Sub FormPurcItemStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewCat()
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcItemStock_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormPurcItemStock_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb(Name)
    End Sub
End Class