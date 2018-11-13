Public Class FormItemReqAdd
    Private Sub FormItemReqAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCat()
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemReqAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Dim id_item_cat As String = LECat.EditValue.ToString
        If id_item_cat = "0" Then
            id_item_cat = ""
        Else
            id_item_cat = "AND im.id_item_cat='" + id_item_cat + "' "
        End If
        Dim cond As String = "AND i.id_departement=" + id_departement_user + " " + id_item_cat

        Dim stc As New ClassPurcItemStock()
        Dim query As String = stc.queryGetStock(cond, date_until_selected)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        GVSOH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged
        GCSOH.DataSource = Nothing
    End Sub
End Class