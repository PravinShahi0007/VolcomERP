Public Class FormPromoRules
    Private Sub FormPromoRules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRules()
        viewClosed()
    End Sub

    Sub viewRules()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_rules, r.report_number, r.limit_value, r.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`, e.employee_name AS created_by, DATE_FORMAT(r.created_date, '%d %M %Y %H:%i:%s') AS created_date, st.report_status, (SELECT GROUP_CONCAT(design_price_type) FROM tb_lookup_design_price_type WHERE id_design_price_type IN (
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 1), ',', -1), 
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 2), ',', -1), 
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 3), ',', -1),
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 4), ',', -1),
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 5), ',', -1),
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 6), ',', -1),
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 7), ',', -1),
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 8), ',', -1),
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 9), ',', -1),
            SUBSTRING_INDEX(SUBSTRING_INDEX(r.id_design_price_type, ',', 10), ',', -1)
        )) AS design_cat
        FROM tb_promo_rules r
        INNER JOIN tb_m_product p ON p.id_product = r.id_product 
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_employee e ON r.created_by = e.id_employee
        INNER JOIN tb_lookup_report_status st ON r.id_report_status = st.id_report_status
        ORDER BY r.id_rules DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRules.DataSource = data
        GVRules.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewClosed()
        Dim query As String = "
            SELECT r.id_close_promo_rules, r.report_number, p.report_number AS proposed_number, s.store, DATE_FORMAT(r.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, t.report_status
            FROM tb_close_promo_rules AS r
            LEFT JOIN tb_promo_rules AS p ON p.id_rules = r.id_rules
            LEFT JOIN (
                SELECT d.id_close_promo_rules, GROUP_CONCAT(o.outlet_name) AS store
                FROM tb_close_promo_rules_det AS d
                LEFT JOIN tb_outlet AS o ON d.id_outlet = o.id_outlet
                GROUP BY d.id_close_promo_rules
            ) AS s ON r.id_close_promo_rules = s.id_close_promo_rules
            LEFT JOIN tb_m_employee AS e ON r.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status t ON r.id_report_status = t.id_report_status
            ORDER BY r.id_close_promo_rules DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCClosed.DataSource = data

        GVClosed.BestFitColumns()
    End Sub

    'Sub viewStore()
    '    Cursor = Cursors.WaitCursor
    '    Dim id_rules As String = "-1"
    '    Try
    '        id_rules = GVRules.GetFocusedRowCellValue("id_rules").ToString
    '    Catch ex As Exception
    '        id_rules = "-1"
    '    End Try
    '    Dim query As String = "SELECT c.id_outlet, c.outlet_name, IF(!ISNULL(rd.id_outlet), 'yes', 'no') AS `is_select`
    '    FROM tb_store_conn c
    '    LEFT JOIN tb_promo_rules_det rd ON rd.id_outlet = c.id_outlet AND rd.id_rules=" + id_rules + " "
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '    GCStore.DataSource = data
    '    GVStore.BestFitColumns()
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub FormPromoRules_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPromoRules_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'Private Sub GVRules_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRules.FocusedRowChanged
    '    viewStore()
    'End Sub

    'Private Sub GVRules_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRules.ColumnFilterChanged
    '    viewStore()
    'End Sub

    Private Sub GVRules_DoubleClick(sender As Object, e As EventArgs) Handles GVRules.DoubleClick
        If GVRules.RowCount > 0 And GVRules.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub GVClosed_DoubleClick(sender As Object, e As EventArgs) Handles GVClosed.DoubleClick
        If GVRules.RowCount > 0 And GVRules.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class