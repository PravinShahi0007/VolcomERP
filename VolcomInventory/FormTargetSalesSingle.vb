Public Class FormTargetSalesSingle
    Public id_store As String = "-1"
    Public year As String = FormTargetSalesDet.TxtYear.Text.ToString

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` 
        FROM tb_m_comp c WHERE c.id_comp_cat=6 AND c.is_active!=2 "
        If id_store <> "-1" Then
            query += "AND c.id_comp='" + id_store + "' "
        End If
        query += "ORDER BY c.comp_number ASC "
        viewSearchLookupQuery(SLEStore, query, "id_comp", "comp", "id_comp")
        SLEStore.EditValue = Nothing
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTargetSalesSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewStore()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormTargetSalesSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLEStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStore.EditValueChanged
        Dim id_store_selected As String = ""
        Try
            id_store_selected = SLEStore.EditValue.ToString
        Catch ex As Exception

        End Try
        Dim query As String = ""
        If id_store = "-1" Then
            'new
            query = "SELECT bln.id_month, bln.`month`, SUM(IFNULL(t.b_revenue,0.00)) AS `value_bef`, 0.00 AS `value`
            FROM tb_lookup_month bln
            LEFT JOIN tb_b_revenue t ON t.`month` = bln.id_month AND t.`year`=" + year + " AND t.id_store='" + id_store_selected + "' AND t.is_active=1
            GROUP BY bln.id_month "
        Else
            'edit
            query = ""
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub
End Class