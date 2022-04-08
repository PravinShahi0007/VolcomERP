Public Class FormPriceForSync
    Sub getLastSync()
        Cursor = Cursors.WaitCursor
        LabelLastSync.Text = execute_query("SELECT DATE_FORMAT(p.date,'%d/%m/%Y %H:%i:%s') AS `last_sync` FROM tb_m_price_shopify p ORDER BY p.date DESC LIMIT 1", 0, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPriceForSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT p.product_full_code, p.product_display_name, cd.code_detail_name AS `size`, IFNULL(prc.design_price, 0) AS design_price, IFNULL(prn.design_price, 0) AS compare_price, IFNULL(prw.design_price, 0) AS design_price_web, IFNULL(prw.compare_price, 0) AS compare_price_web, IF((IFNULL(prc.design_price, 0)) = (IFNULL(prw.design_price, 0)), 'Yes', 'No') AS `match`
            FROM tb_m_product p
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design d ON p.id_design = d.id_design
            INNER JOIN (
                SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                price.id_design_price_type, price_type.design_price_type,
                cat.id_design_cat, cat.design_cat 
                FROM tb_m_design_price price 
                INNER JOIN (
	                SELECT MAX(price.id_design) AS `id_design`, MAX(price.id_design_price) AS  `id_design_price`
	                FROM tb_m_design_price price
	                INNER JOIN (
		                Select MAX(price.id_design) AS `id_design`, MAX(price.design_price_start_date) AS `design_price_start_date`
		                From tb_m_design_price price 
		                WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
		                GROUP BY price.id_design
	                ) maxdate ON maxdate.id_design = price.id_design AND maxdate.design_price_start_date = price.design_price_start_date
	                WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
	                GROUP BY price.id_design
                ) pricemax ON pricemax.id_design_price = price.id_design_price
                INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
                INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
            ) prc ON prc.id_design = d.id_design
            INNER JOIN (
                SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                price.id_design_price_type, price_type.design_price_type,
                cat.id_design_cat, cat.design_cat 
                FROM tb_m_design_price price 
                INNER JOIN (
	                SELECT MAX(price.id_design) AS `id_design`, MAX(price.id_design_price) AS  `id_design_price`
	                FROM tb_m_design_price price
	                INNER JOIN (
		                Select MAX(price.id_design) AS `id_design`, MAX(price.design_price_start_date) AS `design_price_start_date`
		                From tb_m_design_price price 
		                WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() AND price.id_design_price_type=1
		                GROUP BY price.id_design
	                ) maxdate ON maxdate.id_design = price.id_design AND maxdate.design_price_start_date = price.design_price_start_date
	                WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
	                GROUP BY price.id_design
                ) pricemax ON pricemax.id_design_price = price.id_design_price
                INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
                INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
            ) prn ON prn.id_design = d.id_design
            INNER JOIN (
                SELECT a.sku, a.compare_price, a.design_price, a.`date`
                FROM tb_m_price_shopify a 
                INNER JOIN (
	                SELECT sku, MAX(`date`) AS `date`
	                FROM tb_m_price_shopify
	                GROUP BY sku
                ) b ON b.sku = a.sku AND b.`date` = a.`date`
                GROUP BY a.sku
            ) prw ON prw.sku = p.product_full_code
            INNER JOIN tb_m_product_shopify s ON p.product_full_code = s.sku
            WHERE p.id_product > 0 AND s.variant_id IS NOT NULL
            ORDER BY p.product_display_name ASC, p.product_full_code ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCBrowsePrice.DataSource = data

        GVBrowsePrice.BestFitColumns()
        getLastSync
    End Sub

    Private Sub FormPriceForSync_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormPriceForSync_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBUpdate_Click(sender As Object, e As EventArgs) Handles SBUpdate.Click
        Cursor = Cursors.WaitCursor

        Dim cls As New ClassShopifyApi()

        For i = 0 To GVBrowsePrice.RowCount - 1
            If GVBrowsePrice.IsValidRowHandle(i) Then
                If GVBrowsePrice.IsRowSelected(i) Then
                    Dim compare_price As String = GVBrowsePrice.GetRowCellValue(i, "compare_price").ToString.Replace(",", ".")
                    Dim design_price As String = GVBrowsePrice.GetRowCellValue(i, "design_price").ToString.Replace(",", ".")

                    If compare_price = design_price Then
                        compare_price = ""
                    End If

                    Dim msg As String = "OK"

                    Try
                        cls.upd_price(GVBrowsePrice.GetRowCellValue(i, "product_full_code").ToString, compare_price, design_price)
                    Catch ex As Exception
                        msg = ex.ToString
                    End Try

                    execute_non_query("INSERT INTO tb_shopify_api_log (report_mark_type, sku, compare_price, design_price, message, date) VALUES (70, '" + GVBrowsePrice.GetRowCellValue(i, "product_full_code").ToString + "', '" + compare_price + "', '" + design_price + "', '" + addSlashes(msg) + "', NOW())", True, "", "", "", "")
                End If
            End If
        Next

        Cursor = Cursors.Default

        infoCustom("Update to Web Complete.")
    End Sub

    Private Sub SBSync_Click(sender As Object, e As EventArgs) Handles SBSync.Click
        Cursor = Cursors.WaitCursor

        Dim cls As New ClassShopifyApi()

        Dim no_duplicate As Boolean = cls.sync_sku()

        Cursor = Cursors.Default

        FormPriceForSync_Load(Me, New EventArgs)

        If no_duplicate Then
            infoCustom("Sync Complete.")
        End If

        GVBrowsePrice.ActiveFilterString = ""
    End Sub
End Class