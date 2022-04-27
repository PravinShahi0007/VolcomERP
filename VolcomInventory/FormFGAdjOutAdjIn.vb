Public Class FormFGAdjOutAdjIn
    Private Sub FormFGAdjOutAdjIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_product()
    End Sub

    Private Sub FormFGAdjOutAdjIn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        GVAdjIn.ActiveFilterString = "[is_checked] = 'yes'"

        Dim adj_in_qty As Double = Double.Parse(execute_query("SELECT adj_in_fg_det_qty FROM tb_adj_in_fg_det WHERE id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString, 0, True, "", "", "", ""))

        Dim total_qty As Double = Double.Parse(GVAdjIn.Columns("adj_out_fg_det_qty").SummaryItem.SummaryValue.ToString)

        If total_qty <> adj_in_qty Then
            stopCustom("Total qty must equal to " + Math.Round(adj_in_qty).ToString)
        Else
            For i = 0 To GVAdjIn.RowCount - 1
                If GVAdjIn.IsValidRowHandle(i) Then
                    FormFGAdjOutDet.newRows()
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_product", GVAdjIn.GetRowCellValue(i, "id_product").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("name", GVAdjIn.GetRowCellValue(i, "name").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("code", GVAdjIn.GetRowCellValue(i, "code").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("size", GVAdjIn.GetRowCellValue(i, "size").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_qty", GVAdjIn.GetRowCellValue(i, "adj_out_fg_det_qty"))
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_note", GVAdjIn.GetRowCellValue(i, "adj_out_fg_det_note").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("uom", GVAdjIn.GetRowCellValue(i, "uom").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("wh_drawer", GVAdjIn.GetRowCellValue(i, "wh_drawer").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("comp", GVAdjIn.GetRowCellValue(i, "comp_number").ToString + " - " + GVAdjIn.GetRowCellValue(i, "comp_name").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_locator", GVAdjIn.GetRowCellValue(i, "id_wh_locator").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_drawer", GVAdjIn.GetRowCellValue(i, "id_wh_drawer").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_wh_rack", GVAdjIn.GetRowCellValue(i, "id_wh_rack").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_comp", GVAdjIn.GetRowCellValue(i, "id_comp").ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_price", GVAdjIn.GetRowCellValue(i, "adj_out_fg_det_price"))
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("adj_out_fg_det_amount", GVAdjIn.GetRowCellValue(i, "adj_out_fg_det_amount"))
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("retail_price", GVAdjIn.GetRowCellValue(i, "retail_price"))
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("retail_price_amount", GVAdjIn.GetRowCellValue(i, "retail_price_amount"))
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("id_adj_in_fg_det", SLUEProduct.EditValue.ToString)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("code_old", SLUEProduct.Text)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("name_old", TextEditName.Text)
                    FormFGAdjOutDet.GVDetail.SetFocusedRowCellValue("size_old", TextEditSize.Text)

                    'Save in Gridview
                    FormFGAdjOutDet.GVDetail.CloseEditor()
                    FormFGAdjOutDet.GCDetail.RefreshDataSource()
                    FormFGAdjOutDet.GVDetail.RefreshData()
                    FormFGAdjOutDet.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
                    FormFGAdjOutDet.check_but()
                    FormFGAdjOutDet.total_amount = Double.Parse(FormFGAdjOutDet.GVDetail.Columns("adj_out_fg_det_amount").SummaryItem.SummaryValue.ToString)
                    FormFGAdjOutDet.METotSay.Text = ConvertCurrencyToEnglish(FormFGAdjOutDet.total_amount, FormFGAdjOutDet.LECurrency.EditValue.ToString)
                End If
            Next
        End If

        GCAdjIn.DataSource = Nothing

        view_product()

        GVAdjIn.ActiveFilterString = ""
    End Sub

    Sub view_product()
        Dim id_adj_in_fg_det_in As String = "0"

        For i = 0 To FormFGAdjOutDet.GVDetail.RowCount - 1
            If FormFGAdjOutDet.GVDetail.IsValidRowHandle(i) Then
                id_adj_in_fg_det_in += ", " + FormFGAdjOutDet.GVDetail.GetRowCellValue(i, "id_adj_in_fg_det").ToString
            End If
        Next

        Dim query As String = "
            (SELECT '' AS id_adj_in_fg_det, '<Select>' AS code, '' AS name, '' AS size, '' AS account, '' AS price, '' AS qty)
            UNION ALL
            (SELECT d.id_adj_in_fg_det, p.product_full_code AS code, p.product_display_name AS name, s.code_detail_name AS size, CONCAT(c.comp_number, ' - ', c.comp_display_name) AS account, FORMAT(d.retail_price, 2) price, d.adj_in_fg_det_qty AS qty
            FROM tb_adj_in_fg_det AS d
            LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
            LEFT JOIN (
	            SELECT c.id_product, d.display_name, d.code_detail_name
	            FROM tb_m_product_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
            ) AS s ON d.id_product = s.id_product
            LEFT JOIN tb_m_wh_drawer AS w ON d.id_wh_drawer = w.id_wh_drawer
            LEFT JOIN tb_m_wh_rack AS r ON w.id_wh_rack = r.id_wh_rack
            LEFT JOIN tb_m_wh_locator AS l ON r.id_wh_locator = l.id_wh_locator
            LEFT JOIN tb_m_comp AS c ON l.id_comp = c.id_comp
            WHERE d.id_adj_in_fg = " + FormFGAdjOutDet.SLUEAdjIn.EditValue.ToString + " AND d.id_adj_in_fg_det NOT IN (" + id_adj_in_fg_det_in + "))
        "

        viewSearchLookupQuery(SLUEProduct, query, "id_adj_in_fg_det", "code", "id_adj_in_fg_det")
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Dim fg_year As String = execute_query("SELECT YEAR((STR_TO_DATE(DATE_SUB(CONCAT(YEAR(NOW()), '-', MONTH(NOW()),'-', '01'), INTERVAL 1 DAY), '%Y-%m-%d')))", 0, True, "", "", "", "")

        Dim query As String = "
            SELECT 'no' AS is_checked, s.id_product, p.product_display_name AS `name`, z.code_detail_name AS `size`, p.product_full_code AS code, s.qty_avl AS adj_out_fg_det_qty, '' AS adj_out_fg_det_note, u.uom, w.wh_drawer, o.comp_number, o.comp_name, r.id_wh_locator, s.id_wh_drawer, w.id_wh_rack, l.id_comp AS id_comp, d.design_cop AS adj_out_fg_det_price, (d.design_cop * s.qty_avl) AS adj_out_fg_det_amount, c.design_price AS retail_price, (c.design_price * s.qty_avl) AS retail_price_amount, s.qty_avl AS qty_fixed
            FROM (
                SELECT f.id_wh_drawer, f.id_product, SUM(f.qty_avl) AS qty_avl
                FROM (
                    (SELECT f.id_wh_drawer, f.id_product, f.qty_avl
                    FROM tb_storage_fg_" + fg_year + " f
                    WHERE f.month = MONTH((STR_TO_DATE(DATE_SUB(CONCAT(YEAR(NOW()), '-', MONTH(NOW()),'-', '01'), INTERVAL 1 DAY), '%Y-%m-%d'))) AND f.id_wh_drawer = (SELECT id_wh_drawer FROM tb_adj_in_fg_det WHERE id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString + ") AND f.id_product <> (SELECT id_product FROM tb_adj_in_fg_det WHERE id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString + "))
                    UNION ALL
                    (SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS qty_avl
                    FROM tb_storage_fg AS f
                    WHERE f.storage_product_datetime >= CONCAT(STR_TO_DATE(CONCAT(YEAR(NOW()), '-', MONTH(NOW()), '-', '01'), '%Y-%m-%d'), ' 00:00:00') AND f.storage_product_datetime <= CONCAT(DATE(NOW()), ' 23:59:59') AND f.id_wh_drawer = (SELECT id_wh_drawer FROM tb_adj_in_fg_det WHERE id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString + ") AND f.id_product <> (SELECT id_product FROM tb_adj_in_fg_det WHERE id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString + ")
                    GROUP BY f.id_wh_drawer, f.id_product)
                ) AS f
                GROUP BY f.id_wh_drawer, f.id_product
                HAVING SUM(f.qty_avl) > 0
            ) AS s
            LEFT JOIN tb_m_product AS p ON s.id_product = p.id_product
            LEFT JOIN tb_m_design AS d ON p.id_design = d.id_design
            LEFT JOIN tb_m_wh_drawer AS w ON s.id_wh_drawer = w.id_wh_drawer
            LEFT JOIN tb_m_wh_rack AS r ON w.id_wh_rack = r.id_wh_rack
            LEFT JOIN tb_m_wh_locator AS l ON r.id_wh_locator = l.id_wh_locator
            LEFT JOIN tb_m_comp AS o ON l.id_comp = o.id_comp
            LEFT JOIN tb_m_uom AS u ON d.id_uom = u.id_uom
            LEFT JOIN (
                SELECT id_design, design_price
                FROM tb_m_design_price
                WHERE id_design_price IN (
                    SELECT MAX(id_design_price) AS id_design_price
                    FROM tb_m_design_price
                    WHERE design_price_start_date <= (SELECT sales_pos_end_period FROM tb_sales_pos AS s WHERE id_sales_pos = (SELECT id_sales_pos FROM tb_sales_pos_det WHERE id_sales_pos_det = (SELECT id_sales_pos_det FROM tb_adj_in_fg_det WHERE id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString + "))) AND is_active_wh = 1 AND is_design_cost = 0
                    GROUP BY id_design
                )
            ) AS c ON p.id_design = c.id_design
            LEFT JOIN (
                SELECT c.id_product, d.code_detail_name
                FROM tb_m_product_code AS c
                LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
            ) AS z ON s.id_product = z.id_product
            WHERE c.design_price = (SELECT retail_price FROM tb_adj_in_fg_det WHERE id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString + ")
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'calculate stock with stored value
        For i = 0 To data.Rows.Count - 1
            For j = 0 To FormFGAdjOutDet.GVDetail.RowCount - 1
                If FormFGAdjOutDet.GVDetail.IsValidRowHandle(j) Then
                    If data.Rows(i)("id_product").ToString = FormFGAdjOutDet.GVDetail.GetRowCellValue(j, "id_product").ToString Then
                        data.Rows(i)("adj_out_fg_det_qty") = data.Rows(i)("adj_out_fg_det_qty") - FormFGAdjOutDet.GVDetail.GetRowCellValue(j, "adj_out_fg_det_qty")
                        data.Rows(i)("qty_fixed") = data.Rows(i)("adj_out_fg_det_qty")
                        data.Rows(i)("adj_out_fg_det_amount") = data.Rows(i)("adj_out_fg_det_qty") * data.Rows(i)("adj_out_fg_det_price")
                        data.Rows(i)("retail_price_amount") = data.Rows(i)("adj_out_fg_det_qty") * data.Rows(i)("retail_price")
                    End If
                End If
            Next
        Next

        'max qty
        Dim adj_in_qty As Double = Double.Parse(execute_query("SELECT adj_in_fg_det_qty FROM tb_adj_in_fg_det WHERE id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString, 0, True, "", "", "", ""))

        For i = 0 To data.Rows.Count - 1
            If Not data.Rows(i)("adj_out_fg_det_qty") <= adj_in_qty Then
                data.Rows(i)("adj_out_fg_det_qty") = adj_in_qty
                data.Rows(i)("qty_fixed") = adj_in_qty

                data.Rows(i)("retail_price_amount") = data.Rows(i)("adj_out_fg_det_qty") * data.Rows(i)("retail_price")
            End If
        Next

        GCAdjIn.DataSource = data

        GVAdjIn.BestFitColumns()
    End Sub

    Private Sub GVAdjIn_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVAdjIn.CellValueChanged
        If e.Column.FieldName = "adj_out_fg_det_qty" Then
            If GVAdjIn.GetRowCellValue(e.RowHandle, "adj_out_fg_det_qty") <= GVAdjIn.GetRowCellValue(e.RowHandle, "qty_fixed") Then
                GVAdjIn.SetRowCellValue(e.RowHandle, "adj_out_fg_det_amount", GVAdjIn.GetRowCellValue(e.RowHandle, "adj_out_fg_det_price") * GVAdjIn.GetRowCellValue(e.RowHandle, "adj_out_fg_det_qty"))
                GVAdjIn.SetRowCellValue(e.RowHandle, "retail_price_amount", GVAdjIn.GetRowCellValue(e.RowHandle, "retail_price") * GVAdjIn.GetRowCellValue(e.RowHandle, "adj_out_fg_det_qty"))
            Else
                stopCustom("Value not greater than " + GVAdjIn.GetRowCellValue(e.RowHandle, "qty_fixed").ToString)

                GVAdjIn.SetRowCellValue(e.RowHandle, "adj_out_fg_det_qty", 1)
            End If
        End If
    End Sub

    Private Sub SLUEProduct_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEProduct.EditValueChanged
        Try
            Dim query As String = "
                SELECT d.id_adj_in_fg_det, p.product_full_code AS code, p.product_display_name AS name, s.code_detail_name AS size, CONCAT(c.comp_number, ' - ', c.comp_display_name) AS account, FORMAT(d.retail_price, 2) price, d.adj_in_fg_det_qty AS qty
                FROM tb_adj_in_fg_det AS d
                LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
                LEFT JOIN (
	                SELECT c.id_product, d.display_name, d.code_detail_name
	                FROM tb_m_product_code AS c
	                LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
                ) AS s ON d.id_product = s.id_product
                LEFT JOIN tb_m_wh_drawer AS w ON d.id_wh_drawer = w.id_wh_drawer
                LEFT JOIN tb_m_wh_rack AS r ON w.id_wh_rack = r.id_wh_rack
                LEFT JOIN tb_m_wh_locator AS l ON r.id_wh_locator = l.id_wh_locator
                LEFT JOIN tb_m_comp AS c ON l.id_comp = c.id_comp
                WHERE d.id_adj_in_fg_det = " + SLUEProduct.EditValue.ToString + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TextEditName.EditValue = data.Rows(0)("name").ToString
            TextEditSize.EditValue = data.Rows(0)("size").ToString
            TextEditAccount.EditValue = data.Rows(0)("account").ToString
            TextEditPrice.EditValue = data.Rows(0)("price").ToString
            TextEditQty.EditValue = data.Rows(0)("qty").ToString
        Catch ex As Exception
        End Try

        GCAdjIn.DataSource = Nothing
    End Sub
End Class