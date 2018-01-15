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
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim id_comp As String = SLEComp.EditValue.ToString
        Dim query As String = "SELECT so.sales_order_number, so.sales_order_ol_shop_number, so.sales_order_date AS `order_date`, del.pl_sales_order_del_number, del.pl_sales_order_del_date AS `del_date`,ro.sales_return_order_number, ro.sales_return_order_date as `ro_date`, r.sales_return_number, r.sales_return_date AS `ret_date`, inv.sales_pos_number, inv.sales_pos_number AS `inv_date`, cn.sales_pos_cn_number, cn.sales_pos_cn_date AS `cn_date`,
        IF(ISNULL(inv.id_sales_pos),'Pending',IF(inv.id_report_status<5,'Prepared',IF(j.id_status_open=2,'Paid','Invoice Sent'))) AS `paid_status`, '0' AS `report_mark_type`,
        so.id_sales_order, del.id_del,ro.id_ro, r.id_ret, inv.id_inv, cn.id_cn
        FROM tb_sales_order so 
        INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
        LEFT JOIN (
            SELECT del.id_pl_sales_order_del,
            IF(ISNULL(del.id_pl_sales_order_del),0,GROUP_CONCAT(DISTINCT del.id_pl_sales_order_del ORDER BY del.id_pl_sales_order_del ASC SEPARATOR '#')) AS `id_del`,
            GROUP_CONCAT(DISTINCT del.pl_sales_order_del_number ORDER BY del.id_pl_sales_order_del ASC SEPARATOR ', ') AS `pl_sales_order_del_number`, del.pl_sales_order_del_date,
            del.id_sales_order
            FROM tb_pl_sales_order_del del
            WHERE del.id_report_status=6
            GROUP BY del.id_sales_order
        ) del ON del.id_sales_order = so.id_sales_order
        LEFT JOIN (
            SELECT ro.id_sales_return_order,
            GROUP_CONCAT(DISTINCT ro.sales_return_order_number ORDER BY ro.id_sales_return_order ASC SEPARATOR ', ') AS `sales_return_order_number`,
            IF(ISNULL(ro.id_sales_return_order),0,GROUP_CONCAT(DISTINCT ro.id_sales_return_order ORDER BY ro.id_sales_return_order ASC SEPARATOR '#')) AS `id_ro`, ro.sales_return_order_date,
            ro.id_sales_order
            FROM tb_sales_return_order ro
            WHERE ro.id_report_status=6
            GROUP BY ro.id_sales_order                    
        ) ro ON ro.id_sales_order = so.id_sales_order  
        LEFT JOIN (
            SELECT r.id_sales_return,
            GROUP_CONCAT(DISTINCT r.sales_return_number ORDER BY r.id_sales_return ASC SEPARATOR ', ') AS `sales_return_number`,
            IF(ISNULL(r.id_sales_return),0,GROUP_CONCAT(DISTINCT r.id_sales_return ORDER BY r.id_sales_return ASC SEPARATOR '#')) AS `id_ret`, r.sales_return_date,
            ro.id_sales_order
            FROM tb_sales_return r
            INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = r.id_sales_return_order
            WHERE r.id_report_status=6
            GROUP BY ro.id_sales_order      
        ) r ON r.id_sales_order = so.id_sales_order 
        LEFT JOIN (
            SELECT inv.id_sales_pos,
            GROUP_CONCAT(DISTINCT inv.sales_pos_number ORDER BY inv.id_sales_pos ASC SEPARATOR ', ') AS `sales_pos_number`,
            IF(ISNULL(inv.id_sales_pos),0,GROUP_CONCAT(DISTINCT inv.id_sales_pos ORDER BY inv.id_sales_pos ASC SEPARATOR '#')) AS `id_inv`, inv.sales_pos_date, inv.id_report_status,
            del.id_sales_order
            FROM tb_sales_pos inv
            INNER JOIN tb_sales_pos_det invd ON invd.id_sales_pos = inv.id_sales_pos
            INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del_det = invd.id_pl_sales_order_del_det
            INNER JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = deld.id_pl_sales_order_del
            WHERE inv.id_report_status=6 AND inv.id_memo_type=1
            GROUP BY del.id_sales_order  
        ) inv ON inv.id_sales_order = so.id_sales_order 
        LEFT JOIN (
            SELECT cn.id_sales_pos,
            GROUP_CONCAT(DISTINCT cn.sales_pos_number ORDER BY cn.id_sales_pos ASC SEPARATOR ', ') AS `sales_pos_cn_number`,
            IF(ISNULL(cn.id_sales_pos),0,GROUP_CONCAT(DISTINCT cn.id_sales_pos ORDER BY cn.id_sales_pos ASC SEPARATOR '#')) AS `id_cn`, cn.sales_pos_date AS `sales_pos_cn_date`,
            del.id_sales_order
            FROM tb_sales_pos cn
            INNER JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos = cn.id_sales_pos
            INNER JOIN tb_sales_pos_det invd ON invd.id_sales_pos_det = cnd.id_sales_pos_det_ref
            INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del_det = invd.id_pl_sales_order_del_det
            INNER JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = deld.id_pl_sales_order_del
            WHERE cn.id_report_status=6 AND cn.id_memo_type=2
            GROUP BY del.id_sales_order  
        ) cn ON cn.id_sales_order = so.id_sales_order 
        LEFT JOIN (
            SELECT ad.id_acc_trans_det,sod.id_sales_order, ad.id_status_open
            FROM tb_a_acc_trans_det ad
            INNER JOIN tb_a_acc_trans a ON a.id_acc_trans = ad.id_acc_trans
            INNER JOIN tb_a_acc coa ON coa.id_acc = ad.id_acc
            INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = ad.id_report
            INNER JOIN tb_sales_pos_det invd ON invd.id_sales_pos = inv.id_sales_pos
            INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = invd.id_pl_sales_order_del_det
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
            WHERE a.id_report_status=6 AND (ad.report_mark_type=48 OR ad.report_mark_type=54) AND coa.acc_name LIKE '1113%'
            GROUP BY sod.id_sales_order
        ) j ON j.id_sales_order = so.id_sales_order
        WHERE c.id_comp=" + id_comp + " AND so.id_report_status=6 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') "
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

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        If e.Column.FieldName = "report_mark_type" Then
            Dim rh As Integer = e.RowHandle
            Dim val As String = e.Value.ToString
            If val <> "0" Then
                'MsgBox(val)
                FormSuperUser.ShowDialog()
                GVData.SetFocusedRowCellValue("report_mark_type", 0)
            End If
        End If
    End Sub


    Private Sub RepoAttach_EditValueChanged(sender As Object, e As EventArgs) Handles RepoAttach.EditValueChanged
        Cursor = Cursors.WaitCursor
        Dim LE As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim val As String = LE.EditValue.ToString
        Dim id As String = ""
        Dim id_arr() As String
        Dim cond As String = ""
        If val <> "0" Then
            If val = "39" Then
                id = GVData.GetFocusedRowCellValue("id_sales_order").ToString
            ElseIf val = "43" Then
                id = GVData.GetFocusedRowCellValue("id_del").ToString
            ElseIf val = "48" Then
                id = GVData.GetFocusedRowCellValue("id_inv").ToString
            ElseIf val = "118" Then
                id = GVData.GetFocusedRowCellValue("id_cn").ToString
            ElseIf val = "119" Then
                id = GVData.GetFocusedRowCellValue("id_ro").ToString
            ElseIf val = "120" Then
                id = GVData.GetFocusedRowCellValue("id_ret").ToString
            End If

            id_arr = id.Split("#")
            FormDocumentUpload.is_view = "1"
            For i = 0 To id_arr.Length - 1
                If i = 0 Then
                    FormDocumentUpload.id_report = id_arr(i).ToString
                Else
                    cond += "OR id_report='" + id_arr(i).ToString + "' "
                End If
            Next
            FormDocumentUpload.report_mark_type = val
            FormDocumentUpload.cond = cond
            FormDocumentUpload.ShowDialog()
            LE.ItemIndex = 0
        End If
        Cursor = Cursors.Default
    End Sub

End Class