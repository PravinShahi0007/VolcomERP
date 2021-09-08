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
        showDetail()
    End Sub

    Sub showDetail()
        Cursor = Cursors.WaitCursor
        Dim rmt As String = GVProposal.GetFocusedRowCellValue("report_mark_type").ToString
        Dim id_report As String = GVProposal.GetFocusedRowCellValue("id_report").ToString
        Dim col_join As String = ""
        Dim col_info As String = ""
        If rmt = "306" Then
            col_join = "INNER JOIN tb_pp_change pp ON pp.id_pp_change = p.id_report "
            col_info = "pp.number, pp.effective_date"
        Else
            col_join = "INNER JOIN tb_fg_price pp ON pp.id_fg_price = p.id_report "
            col_info = "p.fg_price_number AS `number`, pp.fg_effective_date AS `effective_date` "
        End If

        Dim query As String = "SELECT p.id_report, p.report_mark_type, 
        " + col_info + ", 
        p.id_product, prod.product_full_code AS `code`, cls.class, prod.product_name AS `name`, sht.sht_name, sz.code_detail_name AS `size`, 
        p.sync_date, p.sync_note
        FROM tb_ol_store_mkd_price p 
        " + col_join + "
        INNER JOIN tb_m_product prod ON prod.id_product = p.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
        LEFT JOIN (
             SELECT dc.id_design, cd.display_name AS `class` 
             FROM tb_m_design_code dc
             INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail
             WHERE cd.id_code IN (SELECT id_code_fg_class FROM tb_opt)
             GROUP BY dc.id_design
        ) cls ON cls.id_design = prod.id_design
        LEFT JOIN (
             SELECT dc.id_design, cd.display_name AS `sht_name` 
             FROM tb_m_design_code dc
             INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail
             WHERE cd.id_code IN (SELECT id_code_fg_sht FROM tb_opt)
             GROUP BY dc.id_design
        ) sht ON sht.id_design = prod.id_design
        WHERE p.report_mark_type=" + rmt + " AND p.id_report=" + id_report + "
        ORDER BY prod.product_display_name ASC, prod.product_full_code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProposal_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProposal.FocusedRowChanged
        GCDetail.DataSource = Nothing
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCDetail, "")
        Cursor = Cursors.Default
    End Sub
End Class