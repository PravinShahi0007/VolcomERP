Public Class FormOLStoreSummary
    Private Sub FormOLStoreSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub FormOLStoreSummary_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormOLStoreSummary_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormOLStoreSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        viewComp()

    End Sub

    Sub viewComp()
        Dim query As String = "SELECT c.id_comp,cc.id_comp_contact, c.comp_number,c.comp_name 
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1 
        WHERE c.id_commerce_type=2 "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewRmt()
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim id_comp As String = SLEComp.EditValue.ToString
        Dim query As String = "SELECT so.sales_order_number, so.sales_order_ol_shop_number, 
        GROUP_CONCAT(DISTINCT del.pl_sales_order_del_number ORDER BY del.pl_sales_order_del_number ASC SEPARATOR ', ') AS `pl_sales_order_del_number`,
        GROUP_CONCAT(DISTINCT ro.sales_return_order_number ORDER BY ro.id_sales_return_order ASC SEPARATOR ', ') AS `sales_return_order_number`,
        GROUP_CONCAT(DISTINCT r.sales_return_number ORDER BY r.id_sales_return ASC SEPARATOR ', ') AS `sales_return_number`,
        GROUP_CONCAT(DISTINCT inv.sales_pos_number ORDER BY inv.id_sales_pos ASC SEPARATOR ', ') AS `sales_pos_number`,
        GROUP_CONCAT(DISTINCT cn.sales_pos_number ORDER BY cn.id_sales_pos ASC SEPARATOR ', ') AS `sales_pos_cn_number`,
        IF(ISNULL(inv.id_sales_pos),'Pending','Paid') AS `paid_status`, '0' AS `report_mark_type`
        FROM tb_sales_order so 
        INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
        LEFT JOIN tb_pl_sales_order_del del ON del.id_sales_order = so.id_sales_order AND del.id_report_status=6
        LEFT JOIN tb_sales_return_order ro ON ro.id_sales_order = so.id_sales_order  AND ro.id_report_status=6
        LEFT JOIN tb_sales_return r ON r.id_sales_return_order = ro.id_sales_return_order  AND r.id_report_status=6
        LEFT JOIN tb_sales_pos inv ON inv.id_pl_sales_order_del = del.id_pl_sales_order_del AND inv.id_report_status=6 AND inv.id_memo_type=1
        LEFT JOIN tb_sales_pos cn ON cn.id_sales_pos_ref = inv.id_sales_pos AND cn.id_report_status=6 AND cn.id_memo_type=2
        WHERE c.id_comp=" + id_comp + " AND so.id_report_status=6 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewRmt()
        Dim query As String = "SELECT 0 AS report_mark_type, '-Select-' AS  report_mark_type_name UNION ALL
        SELECT rmt.report_mark_type, rmt.report_mark_type_name 
        FROM tb_lookup_report_mark_type rmt 
        WHERE rmt.report_mark_type=39
        OR rmt.report_mark_type=43
        OR rmt.report_mark_type=48
        OR rmt.report_mark_type=118
        OR rmt.report_mark_type=119
        OR rmt.report_mark_type=120 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoAttach.DataSource = data
        RepoAttach.DisplayMember = "report_mark_type_name"
        RepoAttach.ValueMember = "report_mark_type"
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanging
        If e.Column.FieldName = "report_mark_type" Then
            Dim rh As Integer = e.RowHandle
            Dim val As String = e.Value.ToString
            If val <> "0" Then
                MsgBox(val)
                GVData.SetRowCellValue(rh, "report_mark_type", 0)
            End If
        End If
    End Sub
End Class