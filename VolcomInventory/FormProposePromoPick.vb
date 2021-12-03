Public Class FormProposePromoPick
    Private Sub FormProposePromoPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_account_from()

        SLUEFromAccount.EditValue = "437"
    End Sub

    Private Sub FormProposePromoPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_account_from()
        Dim query As String = "
            SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS account
            FROM tb_m_comp
            WHERE id_comp_cat = 5 AND is_only_for_alloc = 2
        "

        viewSearchLookupQuery(SLUEFromAccount, query, "id_comp", "account", "id_comp")
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Dim id_product_in As String = "0, "

        For i = 0 To FormProposePromoDet.GVProduct.RowCount - 1
            If FormProposePromoDet.GVProduct.IsValidRowHandle(i) Then
                id_product_in += FormProposePromoDet.GVProduct.GetRowCellValue(i, "id_product").ToString + ", "
            End If
        Next

        id_product_in = id_product_in.Substring(0, id_product_in.Length - 2)

        Dim fg_year As String = execute_query("SELECT YEAR((STR_TO_DATE(DATE_SUB(CONCAT(YEAR(NOW()), '-', MONTH(NOW()),'-', '01'), INTERVAL 1 DAY), '%Y-%m-%d')))", 0, True, "", "", "", "")

        Dim query As String = "
            SELECT 'no' AS is_checked, s.id_product, p.product_display_name AS `name`, z.code_detail_name AS `size`, p.product_full_code AS code, s.qty_avl AS qty, l.id_comp, c.id_design_price, d.design_cop, (d.design_cop * s.qty_avl) AS design_cop_amount, c.design_price, (c.design_price * s.qty_avl) AS design_price_amount, s.qty_avl AS qty_fixed
            FROM (
                SELECT f.id_wh_drawer, f.id_product, SUM(f.qty_avl) AS qty_avl
                FROM (
                    (SELECT f.id_wh_drawer, f.id_product, f.qty_avl
                    FROM tb_storage_fg_" + fg_year + " f
                    WHERE f.month = MONTH((STR_TO_DATE(DATE_SUB(CONCAT(YEAR(NOW()), '-', MONTH(NOW()),'-', '01'), INTERVAL 1 DAY), '%Y-%m-%d'))) AND f.id_wh_drawer = (SELECT id_drawer_def FROM tb_m_comp WHERE id_comp = " + SLUEFromAccount.EditValue.ToString + ") AND f.id_product NOT IN (" + id_product_in + "))
                    UNION ALL
                    (SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS qty_avl
                    FROM tb_storage_fg AS f
                    WHERE f.storage_product_datetime >= CONCAT(STR_TO_DATE(CONCAT(YEAR(NOW()), '-', MONTH(NOW()), '-', '01'), '%Y-%m-%d'), ' 00:00:00') AND f.storage_product_datetime <= CONCAT(DATE(NOW()), ' 23:59:59') AND f.id_wh_drawer = (SELECT id_drawer_def FROM tb_m_comp WHERE id_comp = " + SLUEFromAccount.EditValue.ToString + ") AND f.id_product NOT IN (" + id_product_in + ")
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
                SELECT id_design, id_design_price, design_price
                FROM tb_m_design_price
                WHERE id_design_price IN (
                    SELECT MAX(id_design_price) AS id_design_price
                    FROM tb_m_design_price
                    WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
                    GROUP BY id_design
                )
            ) AS c ON p.id_design = c.id_design
            LEFT JOIN (
                SELECT c.id_product, d.code_detail_name
                FROM tb_m_product_code AS c
                LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
            ) AS z ON s.id_product = z.id_product
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProduct.DataSource = data

        GVProduct.BestFitColumns()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        GVProduct.ClearColumnsFilter()

        GVProduct.ActiveFilterString = "[is_checked] = 'yes'"

        If GVProduct.RowCount > 0 Then
            For i = 0 To GVProduct.RowCount - 1
                If GVProduct.IsValidRowHandle(i) Then
                    FormProposePromoDet.GVProduct.AddNewRow()

                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("id_comp", GVProduct.GetRowCellValue(i, "id_comp"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("comp_name", SLUEFromAccount.Text)
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("id_product", GVProduct.GetRowCellValue(i, "id_product"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("name", GVProduct.GetRowCellValue(i, "name"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("code", GVProduct.GetRowCellValue(i, "code"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("size", GVProduct.GetRowCellValue(i, "size"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("id_design_price", GVProduct.GetRowCellValue(i, "id_design_price"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("qty", GVProduct.GetRowCellValue(i, "qty"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("design_cop", GVProduct.GetRowCellValue(i, "design_cop"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("design_cop_amount", GVProduct.GetRowCellValue(i, "design_cop_amount"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("design_price", GVProduct.GetRowCellValue(i, "design_price"))
                    FormProposePromoDet.GVProduct.SetFocusedRowCellValue("design_price_amount", GVProduct.GetRowCellValue(i, "design_price_amount"))

                    FormProposePromoDet.GVProduct.CloseEditor()
                    FormProposePromoDet.GCProduct.RefreshDataSource()
                    FormProposePromoDet.GVProduct.RefreshData()

                    FormProposePromoDet.GVProduct.BestFitColumns()
                End If
            Next

            infoCustom("Product added.")

            SBView_Click(SBView, New EventArgs)
        Else
            stopCustom("Please select product.")
        End If

        GVProduct.ActiveFilterString = ""
    End Sub

    Private Sub SLUEFromAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEFromAccount.EditValueChanged
        GCProduct.DataSource = Nothing
    End Sub

    Private Sub GVProduct_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVProduct.CellValueChanged
        If e.Column.FieldName = "qty" Then
            If GVProduct.GetRowCellValue(e.RowHandle, "qty") > GVProduct.GetRowCellValue(e.RowHandle, "qty_fixed") Then
                stopCustom("Maximum qty is " + GVProduct.GetRowCellValue(e.RowHandle, "qty_fixed").ToString)

                GVProduct.SetRowCellValue(e.RowHandle, "qty", 1)
            End If

            If GVProduct.GetRowCellValue(e.RowHandle, "qty") <= 0 Then
                GVProduct.SetRowCellValue(e.RowHandle, "qty", 1)
            End If

            GVProduct.SetRowCellValue(e.RowHandle, "design_cop_amount", GVProduct.GetRowCellValue(e.RowHandle, "qty") * GVProduct.GetRowCellValue(e.RowHandle, "design_cop"))
            GVProduct.SetRowCellValue(e.RowHandle, "design_price_amount", GVProduct.GetRowCellValue(e.RowHandle, "qty") * GVProduct.GetRowCellValue(e.RowHandle, "design_price"))
        End If
    End Sub
End Class