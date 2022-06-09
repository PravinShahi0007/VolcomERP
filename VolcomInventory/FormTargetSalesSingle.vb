Public Class FormTargetSalesSingle
    Public id_store As String = "-1"
    Public year As String = FormTargetSalesDet.TxtYear.Text.ToString
    Public id_propose As String = FormTargetSalesDet.id

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` 
        FROM tb_m_comp c 
        LEFT JOIN tb_b_revenue_propose_det ptd ON ptd.id_store = c.id_comp AND ptd.id_b_revenue_propose='" + id_propose + "'
        WHERE c.id_comp_cat=6 AND c.is_active!=2 "
        If id_store <> "-1" Then
            query += "AND c.id_comp='" + id_store + "' "
        Else
            query += "AND ISNULL(ptd.id_store) "
        End If
        query += "GROUP BY c.id_comp ORDER BY c.comp_number ASC "
        viewSearchLookupQuery(SLEStore, query, "id_comp", "comp", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTargetSalesSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewStore()
        If id_store = "-1" Then
            'new
            SLEStore.EditValue = Nothing
        Else
            'edit
            SLEStore.Enabled = False
        End If
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

        If id_store_selected = "" Then
            GCData.Enabled = False
        Else
            GCData.Enabled = True
        End If

        Dim query As String = ""
        If id_store = "-1" Then
            'new
            query = "SELECT bln.id_month, bln.`month`, SUM(IFNULL(t.b_revenue,0.00)) AS `value_bef`, 0.00 AS `value`
            FROM tb_lookup_month bln
            LEFT JOIN tb_b_revenue t ON t.`month` = bln.id_month AND t.`year`=" + year + " AND t.id_store='" + id_store_selected + "' AND t.is_active=1
            GROUP BY bln.id_month "
        Else
            'edit
            query = "SELECT bln.id_month, bln.`month`, SUM(ptd.value_before) AS `value_bef`, SUM(ptd.value_propose) AS `value`
            FROM tb_b_revenue_propose_det ptd
            INNER JOIN tb_lookup_month bln ON bln.id_month = ptd.`month`
            WHERE ptd.id_b_revenue_propose='" + id_propose + "' AND ptd.id_store='" + id_store + "'
            GROUP BY ptd.`month` "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        If id_store = "-1" Then
            'new
            Dim sid_store As String = SLEStore.EditValue.ToString
            For i As Integer = 0 To GVData.RowCount - 1

                Dim smonth As String = GVData.GetRowCellValue(i, "id_month").ToString
                Dim svalue_before As String = decimalSQL(GVData.GetRowCellValue(i, "value_bef").ToString)
                Dim svalue_propose As String = decimalSQL(GVData.GetRowCellValue(i, "value").ToString)
                Dim query As String = "INSERT INTO tb_b_revenue_propose_det(id_b_revenue_propose, id_store, month, value_before, value_propose)
                VALUES('" + id_propose + "', '" + sid_store + "', '" + smonth + "', '" + svalue_before + "', '" + svalue_propose + "'); "
                execute_non_query(query, True, "", "", "", "")
            Next
            FormTargetSalesDet.viewDetail()
            viewStore()
            SLEStore.EditValue = Nothing
        Else
            'edit
            Dim sid_store As String = SLEStore.EditValue.ToString
            For i As Integer = 0 To GVData.RowCount - 1
                Dim smonth As String = GVData.GetRowCellValue(i, "id_month").ToString
                Dim svalue_before As String = decimalSQL(GVData.GetRowCellValue(i, "value_bef").ToString)
                Dim svalue_propose As String = decimalSQL(GVData.GetRowCellValue(i, "value").ToString)
                Dim query As String = "UPDATE tb_b_revenue_propose_det SET value_before='" + svalue_before + "', value_propose='" + svalue_propose + "'
                WHERE id_b_revenue_propose='" + id_propose + "' AND id_store='" + sid_store + "' AND month='" + smonth + "' "
                execute_non_query(query, True, "", "", "", "")
            Next
            FormTargetSalesDet.viewDetail()
            Close()
        End If
        Cursor = Cursors.Default
    End Sub
End Class