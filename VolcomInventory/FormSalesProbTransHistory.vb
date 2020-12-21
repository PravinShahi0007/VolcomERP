Public Class FormSalesProbTransHistory
    Public id_sales_pos_prob As String = "-1"
    Private Sub FormSalesProbTransHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormSalesProbTransHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewPriceRecon()
        Cursor = Cursors.WaitCursor
        Dim cond_det As String = ""
        If id_sales_pos_prob <> "-1" Then
            cond_det = "AND rd.id_sales_pos_prob='" + id_sales_pos_prob + "' "
        End If
        Dim query As String = "SELECT r.id_sales_pos_recon, r.number, r.created_date, r.note, r.id_report_status, stt.report_status, r.is_confirm
        FROM tb_sales_pos_recon r
        INNER JOIN tb_sales_pos_recon_det rd ON rd.id_sales_pos_recon = r.id_sales_pos_recon
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        WHERE r.id_sales_pos_recon>0 " + cond_det + "
        GROUP BY r.id_sales_pos_recon
        ORDER BY r.id_sales_pos_recon DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPriceRecon.DataSource = data
        GVPriceRecon.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPriceRecon_DoubleClick(sender As Object, e As EventArgs) Handles GVPriceRecon.DoubleClick
        If GVPriceRecon.RowCount > 0 And GVPriceRecon.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesPosPriceRecon.action = "upd"
            FormSalesPosPriceRecon.id = GVPriceRecon.GetFocusedRowCellValue("id_sales_pos_recon").ToString
            FormSalesPosPriceRecon.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewPriceRecon_Click(sender As Object, e As EventArgs) Handles BtnViewPriceRecon.Click
        viewPriceRecon()
    End Sub
End Class