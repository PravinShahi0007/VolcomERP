Public Class FormPriceMKDVios
    Public id_report As String = "-1"
    Public rmt As String = "-1"

    Private Sub FormPriceMKDVios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewLatestProposal()
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnLastPropose_Click(sender As Object, e As EventArgs) Handles BtnLastPropose.Click
        viewLatestProposal()
    End Sub

    Sub viewLatestProposal()
        Cursor = Cursors.WaitCursor
        Dim qh As String = "SELECT pp.id_pp_change AS `id_report`, 306 AS `rmt`, pp.number AS `pp_number`, pp.created_date, pp.effective_date, pt.design_price_type
        FROM tb_pp_change pp
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = pp.id_design_price_type
        WHERE pp.id_report_status=6
        UNION ALL
        SELECT pm.id_fg_price AS `id_report`, 82 AS `rmt`, pm.fg_price_number AS `pp_number`, pm.fg_price_date AS `created_date`, pm.fg_effective_date AS `effective_date`, pt.design_price_type
        FROM tb_fg_price pm
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = pm.id_design_price_type
        WHERE pm.id_report_status=6 AND pt.id_design_price_type!=1
        ORDER BY effective_date DESC
        LIMIT 1 "
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
            If rmt = "82" Then 'propose by excel
                Dim query As String = "SELECT ppd.id_fg_price AS `id_report`, 82 AS `rmt`,p.id_product, p.product_full_code, cls.class, p.product_name, sht.sht_name, sz.code_detail_name AS `size`, 
                price_normal.design_price AS `normal_price`, ppd.design_price AS `propose_price`, 0 AS `shopify_price`, l.sync_date, IFNULL(l.sync_note,'') AS `sync_note`, '' AS `variant_id`
                FROM tb_fg_price_det ppd
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
	                WHERE mp.report_mark_type=" + rmt + " AND mp.id_report=" + id_report + "
	                AND mp.sync_note ='OK'
                ) l ON l.id_product = p.id_product
                WHERE ppd.id_fg_price=" + id_report + "  AND ISNULL(pv.id_product)
                ORDER BY p.product_display_name ASC, p.product_full_code ASC "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCData.DataSource = data
                GVData.BestFitColumns()
            ElseIf rmt = "306" Then 'real propose 
                Dim query As String = "SELECT ppd.id_pp_change AS `id_report`, 306 AS `rmt`,p.id_product, p.product_full_code, cls.class, p.product_name, sht.sht_name, sz.code_detail_name AS `size`, 
                price_normal.design_price AS `normal_price`, ppd.propose_price_final AS `propose_price`, 0 AS `shopify_price`, l.sync_date, IFNULL(l.sync_note,'') AS `sync_note`, '' AS `variant_id`
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
	                WHERE mp.report_mark_type=306 AND mp.id_report=" + id_report + "
	                AND mp.sync_note ='OK'
                ) l ON l.id_product = p.id_product
                WHERE ppd.id_pp_change=" + id_report + "  AND ISNULL(pv.id_product)
                ORDER BY p.product_display_name ASC, p.product_full_code ASC "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCData.DataSource = data
                GVData.BestFitColumns()
            End If
            If GVData.RowCount > 0 Then
                TxtProposeNo.Text = dh.Rows(0)("pp_number").ToString
                DEEffDate.EditValue = dh.Rows(0)("effective_date")

                'get procuct VIOS
                Dim vios As New ClassShopifyApi()
                FormMain.SplashScreenManager1.SetWaitFormDescription("Get VIOS Product")
                Dim dtp As DataTable
                Try
                    dtp = vios.get_product_price_dec()
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
                        If dtp_filter.Length <= 0 Or dtp_filter.Length > 1 Then
                            GVData.SetRowCellValue(i, "variant_id", "")
                            GVData.SetRowCellValue(i, "shopify_price", 0)
                        Else
                            GVData.SetRowCellValue(i, "variant_id", dtp_filter(0)("variant_id").ToString)
                            GVData.SetRowCellValue(i, "shopify_price", dtp_filter(0)("design_price"))
                        End If
                    Next
                End If
            Else
                refreshView()
            End If
            FormMain.SplashScreenManager1.CloseWaitForm()
            If err_get_product <> "" Then
                warningCustom("Problem get product : " + err_get_product)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub refreshView()
        id_report = "-1"
        rmt = "-1"
        TxtProposeNo.Text = ""
        DEEffDate.EditValue = Nothing
        GCData.DataSource = Nothing
        BtnUpdatePrice.Visible = False
    End Sub
End Class