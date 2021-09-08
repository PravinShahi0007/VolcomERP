Public Class FormPriceMKDViosHist
    Private Sub GroupControl1_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub FormPriceMKDViosHist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_report, p.report_mark_type, IF(p.report_mark_type=306,pp.number, pe.fg_price_number) AS `propose_no`,
        IF(p.report_mark_type=306,pp.effective_date, pe.fg_effective_date) AS `eff_date`
        FROM tb_ol_store_mkd_price p 
        LEFT JOIN tb_pp_change pp ON pp.id_pp_change = p.id_report
        LEFT JOIN tb_fg_price pe ON pe.id_fg_price = p.id_report
        GROUP BY p.report_mark_type, p.id_report "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProposal.DataSource = data
        GVProposal.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoBtnDetail_Click(sender As Object, e As EventArgs) Handles RepoBtnDetail.Click
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub
End Class