Public Class FormFGAdjInInvoice
    Private Sub FormFGAdjInInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_store()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        GVInvoice.ClearColumnsFilter()

        GVInvoice.ActiveFilterString = "[is_checked] = 'yes'"

        If GVInvoice.RowCount > 0 Then
            For i = 0 To GVInvoice.RowCount - 1
                If GVInvoice.IsValidRowHandle(i) Then
                    FormFGAdjInDet.newRows()
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_adj_in_fg_det", 0)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("sales_pos_number", GVInvoice.GetRowCellValue(i, "sales_pos_number").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_sales_pos_det", GVInvoice.GetRowCellValue(i, "id_sales_pos_det"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_product", GVInvoice.GetRowCellValue(i, "id_product"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("name", GVInvoice.GetRowCellValue(i, "name").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("size", GVInvoice.GetRowCellValue(i, "size").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("uom", GVInvoice.GetRowCellValue(i, "uom").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("code", GVInvoice.GetRowCellValue(i, "code").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_qty", GVInvoice.GetRowCellValue(i, "adj_in_fg_det_qty"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_price", GVInvoice.GetRowCellValue(i, "adj_in_fg_det_price"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_amount", GVInvoice.GetRowCellValue(i, "adj_in_fg_det_amount"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("retail_price", GVInvoice.GetRowCellValue(i, "retail_price"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("retail_price_amount", GVInvoice.GetRowCellValue(i, "retail_price_amount"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("adj_in_fg_det_note", GVInvoice.GetRowCellValue(i, "adj_in_fg_det_note").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_drawer", GVInvoice.GetRowCellValue(i, "id_wh_drawer"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_rack", GVInvoice.GetRowCellValue(i, "id_wh_rack"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_wh_locator", GVInvoice.GetRowCellValue(i, "id_wh_locator"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("id_comp", GVInvoice.GetRowCellValue(i, "id_comp"))
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("comp", GVInvoice.GetRowCellValue(i, "comp").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_drawer", GVInvoice.GetRowCellValue(i, "wh_drawer").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_rack", GVInvoice.GetRowCellValue(i, "wh_rack").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("wh_locator", GVInvoice.GetRowCellValue(i, "wh_locator").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("comp_name", GVInvoice.GetRowCellValue(i, "comp_name").ToString)
                    FormFGAdjInDet.GVDetail.SetFocusedRowCellValue("sales_period", GVInvoice.GetRowCellValue(i, "sales_period").ToString)
                    FormFGAdjInDet.GVDetail.CloseEditor()
                    FormFGAdjInDet.GCDetail.RefreshDataSource()
                    FormFGAdjInDet.GVDetail.RefreshData()
                End If
            Next

            Close()
        Else
            stopCustom("Please select invoice.")
        End If

        FormFGAdjInDet.check_but()

        GVInvoice.ActiveFilterString = ""
    End Sub

    Private Sub FormFGAdjInInvoice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVInvoice_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVInvoice.CellValueChanged
        If e.Column.FieldName = "adj_in_fg_det_qty" Then
            If GVInvoice.GetRowCellValue(e.RowHandle, "adj_in_fg_det_qty") <= GVInvoice.GetRowCellValue(e.RowHandle, "qty_fixed") Then
                GVInvoice.SetRowCellValue(e.RowHandle, "adj_in_fg_det_amount", GVInvoice.GetRowCellValue(e.RowHandle, "adj_in_fg_det_price") * GVInvoice.GetRowCellValue(e.RowHandle, "adj_in_fg_det_qty"))
                GVInvoice.SetRowCellValue(e.RowHandle, "retail_price_amount", GVInvoice.GetRowCellValue(e.RowHandle, "retail_price") * GVInvoice.GetRowCellValue(e.RowHandle, "adj_in_fg_det_qty"))
            Else
                stopCustom("Value not greater than " + GVInvoice.GetRowCellValue(e.RowHandle, "qty_fixed").ToString)

                GVInvoice.SetRowCellValue(e.RowHandle, "adj_in_fg_det_qty", 1)
            End If

            If GVInvoice.GetRowCellValue(e.RowHandle, "adj_in_fg_det_qty") <= 0 Then
                GVInvoice.SetRowCellValue(e.RowHandle, "adj_in_fg_det_qty", 1)
            End If
        End If
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Dim id_sales_pos_det_in As String = "0"

        For i = 0 To FormFGAdjInDet.GVDetail.RowCount - 1
            If FormFGAdjInDet.GVDetail.IsValidRowHandle(i) Then
                id_sales_pos_det_in += ", " + FormFGAdjInDet.GVDetail.GetRowCellValue(i, "id_sales_pos_det").ToString
            End If
        Next

        Dim query As String = "
            SELECT * 
            FROM (
                SELECT 'no' AS is_checked, z.id_sales_pos_det, a.id_sales_pos, a.sales_pos_number, CONCAT(DATE_FORMAT(a.sales_pos_start_period, '%d/%m/%Y'), ' - ' ,DATE_FORMAT(a.sales_pos_end_period, '%d/%m/%Y')) AS sales_period, c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp, c.id_drawer_def AS id_wh_drawer, d.wh_drawer, z.id_product, e.product_display_name AS `name`, g.code_detail_name AS `size`, i.uom AS uom, e.product_full_code AS code, (z.sales_pos_det_qty - IFNULL((SELECT SUM(x.adj_in_fg_det_qty) FROM tb_adj_in_fg_det AS x INNER JOIN tb_adj_in_fg AS y ON x.id_adj_in_fg = y.id_adj_in_fg WHERE x.id_sales_pos_det = z.id_sales_pos_det AND y.id_report_status <> 5), 0)) AS adj_in_fg_det_qty, h.design_cop AS adj_in_fg_det_price, z.sales_pos_det_qty * h.design_cop AS adj_in_fg_det_amount, f.design_price AS retail_price, z.sales_pos_det_qty * f.design_price AS retail_price_amount, '' AS adj_in_fg_det_note, d.id_wh_rack, j.id_wh_locator, j.wh_rack, k.wh_locator, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, (z.sales_pos_det_qty - IFNULL((SELECT SUM(x.adj_in_fg_det_qty) FROM tb_adj_in_fg_det AS x INNER JOIN tb_adj_in_fg AS y ON x.id_adj_in_fg = y.id_adj_in_fg WHERE x.id_sales_pos_det = z.id_sales_pos_det AND y.id_report_status <> 5), 0)) AS qty_fixed
                FROM tb_sales_pos_det AS z
                INNER JOIN tb_sales_pos AS a ON z.id_sales_pos = a.id_sales_pos
                INNER JOIN tb_m_comp_contact AS b ON a.id_store_contact_from = b.id_comp_contact 
                INNER JOIN tb_m_comp AS c ON c.id_comp = b.id_comp
                INNER JOIN tb_m_wh_drawer AS d ON c.id_drawer_def = d.id_wh_drawer
                INNER JOIN tb_m_product AS e ON z.id_product = e.id_product
                INNER JOIN tb_m_design_price AS f ON z.id_design_price = f.id_design_price
                LEFT JOIN (
                    SELECT c.id_product, d.display_name, d.code_detail_name
                    FROM tb_m_product_code AS c
                    LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
                ) AS g ON z.id_product = g.id_product
                INNER JOIN tb_m_design AS h ON e.id_design = h.id_design
                INNER JOIN tb_m_uom AS i ON h.id_uom = i.id_uom
                INNER JOIN tb_m_wh_rack AS j ON d.id_wh_rack = j.id_wh_rack
                INNER JOIN tb_m_wh_locator AS k ON j.id_wh_locator = k.id_wh_locator
                INNER JOIN tb_lookup_memo_type AS l ON a.id_memo_type = l.id_memo_type
                WHERE a.id_report_status = 6 AND l.is_receive_payment = 1 AND a.sales_pos_end_period BETWEEN DATE_SUB(DATE_SUB(DATE(NOW()), INTERVAL 2 WEEK), INTERVAL WEEKDAY(DATE_SUB(DATE(NOW()), INTERVAL 2 WEEK)) DAY) AND DATE_SUB(DATE_SUB(DATE(NOW()), INTERVAL 2 WEEK), INTERVAL (WEEKDAY(DATE_ADD(DATE(NOW()), INTERVAL 2 WEEK)) - 6) DAY) AND b.id_comp = '" + SLUEStore.EditValue.ToString + "' AND z.id_sales_pos_det NOT IN (" + id_sales_pos_det_in + ")
                ORDER BY a.id_sales_pos DESC
            ) AS tb
            WHERE tb.qty_fixed > 0
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCInvoice.DataSource = data

        GVInvoice.BestFitColumns()
    End Sub

    Sub view_store()
        Dim query As String = "
            SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS account
            FROM tb_m_comp
            WHERE id_comp_cat = 6 AND id_commerce_type = 1
        "

        viewSearchLookupQuery(SLUEStore, query, "id_comp", "account", "id_comp")
    End Sub
End Class