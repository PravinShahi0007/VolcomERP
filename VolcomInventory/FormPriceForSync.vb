Public Class FormPriceForSync
    Private Sub FormPriceForSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT p.product_full_code, p.product_display_name, IFNULL(prc.design_price, 0) AS design_price, IFNULL(prn.design_price, 0) AS compare_price
            FROM tb_m_product p
            INNER JOIN tb_m_design d ON p.id_design = d.id_design
            INNER JOIN (
                SELECT * FROM (
                    SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, price_type.design_price_type
                    FROM tb_m_design_price price 
                    INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
                    WHERE price.is_active_wh=1 AND price.design_price_start_date <= DATE(NOW())
                    ORDER BY price.design_price_start_date DESC, price.id_design_price DESC
                 ) a 
                GROUP BY a.id_design
            ) prc ON prc.id_design = d.id_design
            INNER JOIN (
                SELECT * FROM (
                    SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, price_type.design_price_type
                    FROM tb_m_design_price price 
                    INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
                    WHERE price.is_active_wh=1 AND price.design_price_start_date <= DATE(NOW()) AND price.id_design_price_type = 1
                    ORDER BY price.design_price_start_date DESC, price.id_design_price DESC
                 ) a 
                GROUP BY a.id_design
            ) prn ON prn.id_design = d.id_design
            INNER JOIN tb_m_product_shopify s ON p.product_full_code = s.sku
            WHERE p.id_product > 0 AND s.variant_id IS NOT NULL
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCBrowsePrice.DataSource = data

        GVBrowsePrice.BestFitColumns()
    End Sub

    Private Sub FormPriceForSync_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormPriceForSync_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBSync_Click(sender As Object, e As EventArgs) Handles SBSync.Click
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

                    execute_non_query("INSERT INTO tb_shopify_api_log (report_mark_type, sku, price, message, date) VALUES (70, '" + GVBrowsePrice.GetRowCellValue(i, "product_full_code").ToString + "', '" + design_price + "', '" + addSlashes(msg) + "', NOW())", True, "", "", "", "")
                End If
            End If
        Next

        Cursor = Cursors.Default

        infoCustom("Sync Complete.")
    End Sub
End Class