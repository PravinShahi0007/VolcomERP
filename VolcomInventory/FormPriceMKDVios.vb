Public Class FormPriceMKDVios
    Public id_report As String = "-1"
    Public rmt As String = "-1"

    Private Sub FormPriceMKDVios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'viewLatestProposal()
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnLastPropose_Click(sender As Object, e As EventArgs) Handles BtnLastPropose.Click
        viewLatestProposal()
    End Sub

    Sub viewLatestProposal()
        Cursor = Cursors.WaitCursor
        Dim qh As String = "SELECT GROUP_CONCAT(p.id_pp_change) AS `id_report`, GROUP_CONCAT(p.number) AS `pp_number`, 306 AS `rmt`,
        p.effective_date
        FROM tb_pp_change p
        WHERE p.id_report_status=6 AND p.effective_date IN (
	        SELECT MAX(p.effective_date) FROM tb_pp_change p WHERE p.id_report_status=6
        ) "
        Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
        If dh.Rows.Count <= 0 Then
            stopCustom("No latest proposal")
            refreshView()
        Else
            id_report = dh.Rows(0)("id_report").ToString
            rmt = dh.Rows(0)("rmt").ToString
            BtnUpdatePrice.Visible = True

            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            FormMain.SplashScreenManager1.SetWaitFormDescription("Loading detail")

            makeSafeGV(GVData)
            Dim err_get_product As String = ""
            Dim query As String = "SELECT ppd.id_pp_change AS `id_report`, 306 AS `rmt`,p.id_product, p.product_full_code, cls.class, p.product_name, sht.sht_name, sz.code_detail_name AS `size`, 
                CAST(price_normal.design_price AS DECIMAL(15,0)) AS `normal_price`, CAST(ppd.propose_price_final AS DECIMAL(15,0)) AS `propose_price`, 0 AS `shopify_price`, l.sync_date, IFNULL(l.sync_note,'') AS `sync_note`, '' AS `variant_id`
                FROM tb_pp_change_det ppd
                INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
                INNER JOIN tb_m_product p ON p.id_design = d.id_design
                LEFT JOIN tb_m_product_void pv ON pv.id_product = p.id_product
                INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
                INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
                LEFT JOIN (
                   SELECT id_design, ROUND(design_price) AS design_price
                   FROM tb_m_design_price
                   WHERE id_design_price IN (
                       SELECT MAX(id_design_price) AS id_design_price
                       FROM tb_m_design_price
                       WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                       GROUP BY id_design
                   )
                ) AS price_normal ON d.id_design = price_normal.id_design
                LEFT JOIN (
	                SELECT dc.id_design, cd.display_name AS `class` 
	                FROM tb_m_design_code dc
	                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail
	                WHERE cd.id_code IN (SELECT id_code_fg_class FROM tb_opt)
	                GROUP BY dc.id_design
                ) cls ON cls.id_design = d.id_design
                LEFT JOIN (
	                SELECT dc.id_design, cd.display_name AS `sht_name` 
	                FROM tb_m_design_code dc
	                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail
	                WHERE cd.id_code IN (SELECT id_code_fg_sht FROM tb_opt)
	                GROUP BY dc.id_design
                ) sht ON sht.id_design = d.id_design
                LEFT JOIN (
	                SELECT mp.id_report, mp.id_product, mp.sync_date, mp.sync_note
	                FROM tb_ol_store_mkd_price mp
	                WHERE mp.report_mark_type=306 AND mp.id_report IN (" + id_report + ")
	                AND mp.sync_note ='OK'
                    GROUP BY mp.id_product
                ) l ON l.id_product = p.id_product
                WHERE ppd.id_pp_change IN (" + id_report + ")  AND ISNULL(pv.id_product)
                AND (ppd.propose_price_final>0 AND !ISNULL(ppd.propose_price_final))
                ORDER BY p.product_display_name ASC, p.product_full_code ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCData.DataSource = data
            GVData.BestFitColumns()
            If GVData.RowCount > 0 Then
                TxtProposeNo.Text = dh.Rows(0)("pp_number").ToString
                DEEffDate.EditValue = dh.Rows(0)("effective_date")

                'get procuct VIOS
                Dim vios As New ClassShopifyApi()
                FormMain.SplashScreenManager1.SetWaitFormDescription("Get VIOS Product")
                Dim dtp As DataTable
                Try
                    dtp = vios.get_product()
                Catch ex As Exception
                    dtp = Nothing
                    err_get_product = ex.ToString
                End Try

                'get current vios price
                If dtp IsNot Nothing AndAlso dtp.Rows.Count > 0 Then
                    For i As Integer = 0 To GVData.RowCount - 1
                        FormMain.SplashScreenManager1.SetWaitFormDescription("Get current VIOS Price : " + (i + 1).ToString + "/" + GVData.RowCount.ToString)
                        Dim sku_find As String = GVData.GetRowCellValue(i, "product_full_code").ToString
                        Dim dtp_filter As DataRow() = dtp.Select("[sku]='" + sku_find + "' ")
                        If dtp_filter.Length <= 0 Then
                            GVData.SetRowCellValue(i, "variant_id", "")
                            GVData.SetRowCellValue(i, "shopify_price", 0)
                        ElseIf dtp_filter.Length > 1 Then
                            GVData.SetRowCellValue(i, "variant_id", "?")
                            GVData.SetRowCellValue(i, "shopify_price", 0)
                        Else
                            Dim col_prc As String() = Split(dtp_filter(0)("design_price").ToString, ".")
                            GVData.SetRowCellValue(i, "variant_id", dtp_filter(0)("variant_id").ToString)
                            GVData.SetRowCellValue(i, "shopify_price", Decimal.Parse(col_prc(0)))
                        End If
                    Next
                End If
            Else
                refreshView()
            End If
            GCData.Refresh()
            GVData.RefreshData()
            FormMain.SplashScreenManager1.CloseWaitForm()
            If err_get_product <> "" Then
                warningCustom("Problem get product : " + err_get_product)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewLatestProposalOld()
        'Cursor = Cursors.WaitCursor
        'Dim qh As String = "SELECT pp.id_pp_change AS `id_report`, 306 AS `rmt`, pp.number AS `pp_number`, pp.created_date, pp.effective_date, pt.design_price_type
        'FROM tb_pp_change pp
        'INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = pp.id_design_price_type
        'WHERE pp.id_report_status=6
        'UNION ALL
        'SELECT pm.id_fg_price AS `id_report`, 82 AS `rmt`, pm.fg_price_number AS `pp_number`, pm.fg_price_date AS `created_date`, pm.fg_effective_date AS `effective_date`, pt.design_price_type
        'FROM tb_fg_price pm
        'INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = pm.id_design_price_type
        'WHERE pm.id_report_status=6 AND pt.id_design_price_type!=1
        'ORDER BY effective_date DESC
        'LIMIT 1 "
        'Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
        'If dh.Rows.Count <= 0 Then
        '    stopCustom("No latest proposal")
        '    refreshView()
        'Else
        '    id_report = dh.Rows(0)("id_report").ToString
        '    rmt = dh.Rows(0)("rmt").ToString
        '    BtnUpdatePrice.Visible = True

        '    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
        '        FormMain.SplashScreenManager1.ShowWaitForm()
        '    End If
        '    FormMain.SplashScreenManager1.SetWaitFormDescription("Loading detail")

        '    makeSafeGV(GVData)
        '    Dim err_get_product As String = ""
        '    If rmt = "82" Then 'propose by excel
        '        Dim query As String = "SELECT ppd.id_fg_price AS `id_report`, 82 AS `rmt`,p.id_product, p.product_full_code, cls.class, p.product_name, sht.sht_name, sz.code_detail_name AS `size`, 
        '        CAST(price_normal.design_price AS DECIMAL(15,0)) AS `normal_price`, CAST(ppd.design_price AS DECIMAL(15,0)) AS `propose_price`, 0 AS `shopify_price`, l.sync_date, IFNULL(l.sync_note,'') AS `sync_note`, '' AS `variant_id`
        '        FROM tb_fg_price_det ppd
        '        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        '        INNER JOIN tb_m_product p ON p.id_design = d.id_design
        '        LEFT JOIN tb_m_product_void pv ON pv.id_product = p.id_product
        '        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        '        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
        '        LEFT JOIN (
        '           SELECT id_design, ROUND(design_price) AS design_price
        '           FROM tb_m_design_price
        '           WHERE id_design_price IN (
        '               SELECT MAX(id_design_price) AS id_design_price
        '               FROM tb_m_design_price
        '               WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
        '               GROUP BY id_design
        '           )
        '        ) AS price_normal ON d.id_design = price_normal.id_design
        '        LEFT JOIN (
        '         SELECT dc.id_design, cd.display_name AS `class` 
        '         FROM tb_m_design_code dc
        '         INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail
        '         WHERE cd.id_code IN (SELECT id_code_fg_class FROM tb_opt)
        '         GROUP BY dc.id_design
        '        ) cls ON cls.id_design = d.id_design
        '        LEFT JOIN (
        '         SELECT dc.id_design, cd.display_name AS `sht_name` 
        '         FROM tb_m_design_code dc
        '         INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail
        '         WHERE cd.id_code IN (SELECT id_code_fg_sht FROM tb_opt)
        '         GROUP BY dc.id_design
        '        ) sht ON sht.id_design = d.id_design
        '        LEFT JOIN (
        '         SELECT mp.id_report, mp.id_product, mp.sync_date, mp.sync_note
        '         FROM tb_ol_store_mkd_price mp
        '         WHERE mp.report_mark_type=" + rmt + " AND mp.id_report=" + id_report + "
        '         AND mp.sync_note ='OK'
        '            GROUP BY mp.id_product
        '        ) l ON l.id_product = p.id_product
        '        WHERE ppd.id_fg_price=" + id_report + "  AND ISNULL(pv.id_product)
        '        ORDER BY p.product_display_name ASC, p.product_full_code ASC "
        '        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '        GCData.DataSource = data
        '        GVData.BestFitColumns()
        '    ElseIf rmt = "306" Then 'real propose 
        '        Dim query As String = "SELECT ppd.id_pp_change AS `id_report`, 306 AS `rmt`,p.id_product, p.product_full_code, cls.class, p.product_name, sht.sht_name, sz.code_detail_name AS `size`, 
        '        CAST(price_normal.design_price AS DECIMAL(15,0)) AS `normal_price`, CAST(ppd.propose_price_final AS DECIMAL(15,0)) AS `propose_price`, 0 AS `shopify_price`, l.sync_date, IFNULL(l.sync_note,'') AS `sync_note`, '' AS `variant_id`
        '        FROM tb_pp_change_det ppd
        '        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        '        INNER JOIN tb_m_product p ON p.id_design = d.id_design
        '        LEFT JOIN tb_m_product_void pv ON pv.id_product = p.id_product
        '        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        '        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
        '        LEFT JOIN (
        '           SELECT id_design, ROUND(design_price) AS design_price
        '           FROM tb_m_design_price
        '           WHERE id_design_price IN (
        '               SELECT MAX(id_design_price) AS id_design_price
        '               FROM tb_m_design_price
        '               WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
        '               GROUP BY id_design
        '           )
        '        ) AS price_normal ON d.id_design = price_normal.id_design
        '        LEFT JOIN (
        '         SELECT dc.id_design, cd.display_name AS `class` 
        '         FROM tb_m_design_code dc
        '         INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail
        '         WHERE cd.id_code IN (SELECT id_code_fg_class FROM tb_opt)
        '         GROUP BY dc.id_design
        '        ) cls ON cls.id_design = d.id_design
        '        LEFT JOIN (
        '         SELECT dc.id_design, cd.display_name AS `sht_name` 
        '         FROM tb_m_design_code dc
        '         INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail
        '         WHERE cd.id_code IN (SELECT id_code_fg_sht FROM tb_opt)
        '         GROUP BY dc.id_design
        '        ) sht ON sht.id_design = d.id_design
        '        LEFT JOIN (
        '         SELECT mp.id_report, mp.id_product, mp.sync_date, mp.sync_note
        '         FROM tb_ol_store_mkd_price mp
        '         WHERE mp.report_mark_type=306 AND mp.id_report=" + id_report + "
        '         AND mp.sync_note ='OK'
        '            GROUP BY mp.id_product
        '        ) l ON l.id_product = p.id_product
        '        WHERE ppd.id_pp_change=" + id_report + "  AND ISNULL(pv.id_product)
        '        AND (ppd.propose_price_final>0 AND !ISNULL(ppd.propose_price_final))
        '        ORDER BY p.product_display_name ASC, p.product_full_code ASC "
        '        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '        GCData.DataSource = data
        '        GVData.BestFitColumns()
        '    End If
        '    If GVData.RowCount > 0 Then
        '        TxtProposeNo.Text = dh.Rows(0)("pp_number").ToString
        '        DEEffDate.EditValue = dh.Rows(0)("effective_date")

        '        'get procuct VIOS
        '        Dim vios As New ClassShopifyApi()
        '        FormMain.SplashScreenManager1.SetWaitFormDescription("Get VIOS Product")
        '        Dim dtp As DataTable
        '        Try
        '            dtp = vios.get_product()
        '        Catch ex As Exception
        '            dtp = Nothing
        '            err_get_product = ex.ToString
        '        End Try

        '        'get current vios price
        '        If dtp IsNot Nothing AndAlso dtp.Rows.Count > 0 Then
        '            For i As Integer = 0 To GVData.RowCount - 1
        '                FormMain.SplashScreenManager1.SetWaitFormDescription("Get current VIOS Price : " + (i + 1).ToString + "/" + GVData.RowCount.ToString)
        '                Dim sku_find As String = GVData.GetRowCellValue(i, "product_full_code").ToString
        '                Dim dtp_filter As DataRow() = dtp.Select("[sku]='" + sku_find + "' ")
        '                If dtp_filter.Length <= 0 Then
        '                    GVData.SetRowCellValue(i, "variant_id", "")
        '                    GVData.SetRowCellValue(i, "shopify_price", 0)
        '                ElseIf dtp_filter.Length > 1 Then
        '                    GVData.SetRowCellValue(i, "variant_id", "?")
        '                    GVData.SetRowCellValue(i, "shopify_price", 0)
        '                Else
        '                    Dim col_prc As String() = Split(dtp_filter(0)("design_price").ToString, ".")
        '                    GVData.SetRowCellValue(i, "variant_id", dtp_filter(0)("variant_id").ToString)
        '                    GVData.SetRowCellValue(i, "shopify_price", Decimal.Parse(col_prc(0)))
        '                End If
        '            Next
        '        End If
        '    Else
        '        refreshView()
        '    End If
        '    GCData.Refresh()
        '    GVData.RefreshData()
        '    FormMain.SplashScreenManager1.CloseWaitForm()
        '    If err_get_product <> "" Then
        '        warningCustom("Problem get product : " + err_get_product)
        '    End If
        'End If
        'Cursor = Cursors.Default
    End Sub

    Sub refreshView()
        id_report = "-1"
        rmt = "-1"
        TxtProposeNo.Text = ""
        DEEffDate.EditValue = Nothing
        GCData.DataSource = Nothing
        BtnUpdatePrice.Visible = False
    End Sub

    Private Sub BtnUpdatePrice_Click(sender As Object, e As EventArgs) Handles BtnUpdatePrice.Click
        'check date
        Dim curr_date As DateTime = getTimeDB()
        If curr_date < DEEffDate.EditValue Then
            warningCustom("Please update the price on or after the effective date")
            Exit Sub
        End If

        'check match
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[check]='Not Match'"
        If GVData.RowCount <= 0 Then
            warningCustom("All product price already match")
            GVData.ActiveFilterString = ""
            Exit Sub
        End If

        'check variant id kosong
        Dim err_vid As String = ""
        Dim jum_vid_not_found As Integer = 0
        GVData.ActiveFilterString = ""
        GVData.ActiveFilterString = "[variant_id]=''"
        jum_vid_not_found = GVData.RowCount
        'check variant id duplikat
        Dim jum_vid_dupe As Integer = 0
        GVData.ActiveFilterString = "[variant_id]='?'"
        jum_vid_dupe = GVData.RowCount
        'check variant id OK
        Dim jum_vid_ok As Integer = 0
        GVData.ActiveFilterString = "[variant_id]<>'' AND [variant_id]<>'?'"
        jum_vid_ok = GVData.RowCount
        GVData.ActiveFilterString = ""
        Dim var_check As String = "OK : " + jum_vid_ok.ToString + System.Environment.NewLine
        var_check += "Not found : " + jum_vid_not_found.ToString + System.Environment.NewLine
        var_check += "Duplicate : " + jum_vid_dupe.ToString + System.Environment.NewLine

        If err_vid <> "" Then
            warningCustom("These product not found in VIOS product list : " + System.Environment.NewLine + err_vid)
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("SKU check result : " + System.Environment.NewLine + var_check + "Are you sure you want to update price to VIOS?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If
                GVData.ActiveFilterString = "[check]='Not Match' AND [variant_id]<>'' AND [variant_id]<>'?'"
                For i As Integer = 0 To GVData.RowCount - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Sync " + (i + 1).ToString + "/" + GVData.RowCount.ToString)
                    Try
                        Dim vios As New ClassShopifyApi()
                        vios.upd_price_by_variant(GVData.GetRowCellValue(i, "variant_id").ToString, GVData.GetRowCellValue(i, "normal_price").ToString, GVData.GetRowCellValue(i, "propose_price").ToString)
                        execute_non_query("INSERT INTO tb_ol_store_mkd_price(id_report, report_mark_type, id_product, sync_date, sync_note) VALUES('" + GVData.GetRowCellValue(i, "id_report").ToString + "', '" + GVData.GetRowCellValue(i, "rmt").ToString + "', '" + GVData.GetRowCellValue(i, "id_product").ToString + "', NOW(), 'OK')", True, "", "", "", "")
                    Catch ex As Exception
                        execute_non_query("INSERT INTO tb_ol_store_mkd_price(id_report, report_mark_type, id_product, sync_date, sync_note) VALUES('" + GVData.GetRowCellValue(i, "id_report").ToString + "', '" + GVData.GetRowCellValue(i, "rmt").ToString + "', '" + GVData.GetRowCellValue(i, "id_product").ToString + "', NOW(), 'Failed:" + addSlashes(ex.ToString) + "')", True, "", "", "", "")
                    End Try
                Next
                GVData.ActiveFilterString = ""
                FormMain.SplashScreenManager1.CloseWaitForm()
                viewLatestProposal()
            End If
        End If
    End Sub

    Private Sub BtnImportToXLS_Click(sender As Object, e As EventArgs) Handles BtnImportToXLS.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.DataAware

            GVData.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles BtnHistory.Click
        Cursor = Cursors.WaitCursor
        FormPriceMKDViosHist.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPriceMKDVios_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPriceMKDVios_CursorChanged(sender As Object, e As EventArgs) Handles MyBase.CursorChanged

    End Sub

    Private Sub FormPriceMKDVios_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPriceMKDVios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class