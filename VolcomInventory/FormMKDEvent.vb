Public Class FormMKDEvent
    Private Sub FormMKDEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewOption()
        viewMKD
    End Sub

    Private Sub FormMKDEvent_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMKDEvent_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub ViewOption()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `eos_day`, 'All' AS `note`
        UNION ALL
        SELECT r.eos_day, r.note 
        FROM tb_eos_reminder r
        ORDER BY eos_day ASC "
        viewSearchLookupQuery(SLEOption, query, "eos_day", "note", "eos_day")
        SLEOption.EditValue = 0
        Cursor = Cursors.Default
    End Sub

    Sub viewMKD()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pp.id_pp_change, pp.number FROM tb_pp_change pp WHERE pp.id_design_mkd=1 AND pp.id_report_status=6"
        viewSearchLookupQuery(SLEMKD, query, "id_pp_change", "number", "id_pp_change")
        Cursor = Cursors.Default
    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_pp_change, p.number, 
        DATE_FORMAT(p.effective_date,'%d-%m-%Y') AS `start_date`, 
        DATE_FORMAT(p.plan_end_date,'%d-%m-%Y') AS `end_date`, 
        p.note, datediff(DATE(NOW()), p.plan_end_date) AS `count_day`, o.eos_body_mail1, o.eos_body_mail2
        FROM tb_pp_change p 
        JOIN tb_opt o
        WHERE p.id_report_status=6 AND p.id_design_mkd=1 "
        'cond
        If SLEOption.EditValue.ToString <> "0" Then
            query += "AND p.plan_end_date>=NOW() "
        End If
        query += "GROUP BY p.id_pp_change 
        HAVING 1=1 "
        'cond
        If SLEOption.EditValue.ToString <> "0" Then
            query += "AND count_day IN (" + SLEOption.EditValue.ToString + ") "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewList()
    End Sub

    Private Sub BtnPrintList_Click(sender As Object, e As EventArgs) Handles BtnPrintList.Click
        print(GCList, "EOS List")
    End Sub

    Private Sub BtnPrintMKD_Click(sender As Object, e As EventArgs) Handles BtnPrintMKD.Click
        print(GCDetail, SLEMKD.Text)
    End Sub

    Private Sub SLEOption_EditValueChanged(sender As Object, e As EventArgs) Handles SLEOption.EditValueChanged
        GCList.DataSource = Nothing
    End Sub

    Private Sub SLEMKD_EditValueChanged(sender As Object, e As EventArgs) Handles SLEMKD.EditValueChanged
        GCDetail.DataSource = Nothing
    End Sub

    Private Sub BtnViewMKD_Click(sender As Object, e As EventArgs) Handles BtnViewMKD.Click
        viewDetail
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.product_full_code AS `kode_lengkap`, d.design_code AS `kode`, sz.display_name	AS `size`, 
        cd.class, d.design_display_name AS `deskripsi`, cd.color AS `warna`, cd.color_desc AS `deskripsi_warna`,
        normal_prc.design_price_normal AS `harga_normal`,CONCAT(CAST(ppd.propose_discount AS DECIMAL(10,0)),'%')AS `disc`, CAST(ppd.propose_price_final AS DECIMAL(15,0)) AS `harga_update`,
        IF(ppd.id_extended_eos=1, UPPER(exos.extended_eos), 'EOSS') AS `ket`
        FROM tb_pp_change_det ppd
        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        LEFT JOIN (
          SELECT dc.id_design, 
          MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
          MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
          MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
          MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
          MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
          MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
          MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
          MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
          MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
          FROM tb_m_design_code dc
          INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
          AND cd.id_code IN (32,30,14, 43)
          GROUP BY dc.id_design
        ) cd ON cd.id_design = d.id_design
        INNER JOIN tb_m_product p ON p.id_design = d.id_design
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
        LEFT JOIN tb_m_product_void pv ON pv.id_product = p.id_product
        INNER JOIN tb_lookup_extended_eos exos ON exos.id_extended_eos = ppd.id_extended_eos
        LEFT JOIN (
         SELECT p.id_design_price AS `id_design_price_normal`,
         p.design_price AS `design_price_normal`, p.id_design
         FROM tb_m_design_price p
         INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = p.id_design_price_type
         INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = pt.id_design_cat
         WHERE p.id_design_price IN (
            SELECT MAX(p.id_design_price) FROM tb_m_design_price p
            WHERE  p.id_design_price_type=1
            GROUP BY p.id_design
         )
        ) normal_prc ON normal_prc.id_design = ppd.id_design
        WHERE ppd.id_pp_change='" + SLEMKD.EditValue.ToString + "' AND ISNULL(pv.id_product) AND (ppd.propose_price_final>0 AND !ISNULL(ppd.propose_price_final))
        ORDER BY ket ASC, class ASC, deskripsi ASC, kode_lengkap ASC   "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCEvent_Click(sender As Object, e As EventArgs) Handles XTCEvent.Click
        If GVList.RowCount > 0 And GVList.FocusedRowHandle >= 0 Then
            SLEMKD.EditValue = GVList.GetFocusedRowCellValue("id_pp_change").ToString
            viewDetail()
            XTCEvent.SelectedTabPageIndex = 1
        End If
    End Sub

    Private Sub FormMKDEvent_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class