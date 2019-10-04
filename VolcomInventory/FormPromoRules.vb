Public Class FormPromoRules
    Private Sub FormPromoRules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRules()
    End Sub

    Sub viewRules()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_rules, r.id_design_cat, dc.design_cat, r.limit_value, r.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`
        FROM tb_promo_rules r 
        INNER JOIN tb_lookup_design_cat dc ON dc.id_design_cat = r.id_design_cat
        INNER JOIN tb_m_product p ON p.id_product = r.id_product "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRules.DataSource = data
        GVRules.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        Dim id_rules As String = "-1"
        Try
            id_rules = GVRules.GetFocusedRowCellValue("id_rules").ToString
        Catch ex As Exception
            id_rules = "-1"
        End Try
        Dim query As String = "SELECT c.id_outlet, c.outlet_name, IF(!ISNULL(rd.id_rules_det), 'yes', 'no') AS `is_select`
        FROM tb_store_conn c
        LEFT JOIN tb_promo_rules_det rd ON rd.id_outlet = c.id_outlet AND rd.id_rules=" + id_rules + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCStore.DataSource = data
        GVStore.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPromoRules_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPromoRules_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVRules_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRules.FocusedRowChanged
        viewStore()
    End Sub

    Private Sub GVRules_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRules.ColumnFilterChanged
        viewStore()
    End Sub
End Class