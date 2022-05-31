Public Class FormPromoRules
    Private Sub FormPromoRules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRules()
    End Sub

    Sub viewRules()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_rules, r.report_number, r.id_design_cat, dc.design_cat, r.limit_value, r.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`, e.employee_name AS created_by, DATE_FORMAT(r.created_date, '%d %M %Y %H:%i:%s') AS created_date, st.report_status
        FROM tb_promo_rules r 
        INNER JOIN tb_lookup_design_cat dc ON dc.id_design_cat = r.id_design_cat
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
End Class