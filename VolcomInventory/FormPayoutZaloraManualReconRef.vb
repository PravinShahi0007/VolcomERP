Public Class FormPayoutZaloraManualReconRef
    Public id_payout_zalora_det As String = "-1"
    Private Sub FormPayoutZaloraManualReconRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim order_no As String = addSlashes(TxtOrderNo.Text)
        Dim query As String = "-- invoice
        SELECT 'No' AS `is_select`,sod.item_id, p.product_full_code AS `code`, p.product_name, cd.display_name AS `size`,CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y'))  AS `name`,
        2 AS `id_group`, 'Commision' AS `group`, sp.id_sales_pos AS `id_ref`, spd.id_sales_pos_det AS `id_ref_det`, sp.report_mark_type AS `rmt_ref`, rmt.report_mark_type_name, sp.sales_pos_number AS `ref`,
        spd.design_price_retail AS `amo`, sp.id_acc_ar AS `id_acc`, c.id_comp, c.comp_number 
        FROM tb_sales_pos sp
        INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = spd.id_pl_sales_order_del_det
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = sp.id_store_contact_from
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp AND c.id_comp_group=64
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = sp.report_mark_type
        INNER JOIN tb_m_product p ON p.id_product = spd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE sp.id_report_status = 6 AND sp.report_mark_type=48 AND so.sales_order_ol_shop_number='" + order_no + "' AND sp.is_close_rec_payment=2
        -- CN
        UNION ALL
        SELECT 'No' AS `is_select`,sod.item_id, p.product_full_code AS `code`, p.product_name, cd.display_name AS `size`,CONCAT(c.comp_name,' Per ', DATE_FORMAT(cn.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(cn.sales_pos_end_period,'%d-%m-%y'))  AS `name`,
        2 AS `id_group`, 'Commision' AS `group`, cn.id_sales_pos AS `id_ref`, cnd.id_sales_pos_det AS `id_ref_det`, cn.report_mark_type AS `rmt_ref`, rmt.report_mark_type_name, cn.sales_pos_number AS `ref`,
        cnd.design_price_retail AS `amo`, cn.id_acc_ar AS `id_acc`, c.id_comp, c.comp_number 
        FROM tb_sales_pos cn
        INNER JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos = cn.id_sales_pos
        INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = cnd.id_sales_pos_det_ref
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = spd.id_pl_sales_order_del_det
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = cn.id_store_contact_from
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp AND c.id_comp_group=64
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = cn.report_mark_type
        INNER JOIN tb_m_product p ON p.id_product = spd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE cn.id_report_status=6 AND cn.report_mark_type=118 AND so.sales_order_ol_shop_number='" + order_no + "' AND cn.is_close_rec_payment=2
        -- cancel cn
        UNION ALL
        SELECT 'No' AS `is_select`,sod.item_id, p.product_full_code AS `code`, p.product_name, cd.display_name AS `size`,CONCAT(c.comp_name,' Per ', DATE_FORMAT(dn.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(dn.sales_pos_end_period,'%d-%m-%y'))  AS `name`,
        2 AS `id_group`, 'Commision' AS `group`, dn.id_sales_pos AS `id_ref`, dnd.id_sales_pos_det AS `id_ref_det`, dn.report_mark_type AS `rmt_ref`, rmt.report_mark_type_name, dn.sales_pos_number AS `ref`,
        dnd.design_price_retail AS `amo`, dn.id_acc_ar AS `id_acc`, c.id_comp, c.comp_number 
        FROM tb_sales_pos dn
        INNER JOIN tb_sales_pos_det dnd ON dnd.id_sales_pos = dn.id_sales_pos
        INNER JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos_det = dnd.id_cn_det
        INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = cnd.id_sales_pos_det_ref
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = spd.id_pl_sales_order_del_det
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = dn.id_store_contact_from
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp AND c.id_comp_group=64
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = dn.report_mark_type
        INNER JOIN tb_m_product p ON p.id_product = spd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE dn.id_report_status=6 AND dn.report_mark_type=292 AND so.sales_order_ol_shop_number='" + order_no + "' AND dn.is_close_rec_payment=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_exist As DataTable = FormPayoutZaloraManualReconSingle.GCData.DataSource
        If data_exist.Rows.Count = 0 Then
            GCData.DataSource = data
            GVData.BestFitColumns()
        Else
            Dim t1 = data.AsEnumerable()
            Dim t2 = data_exist.AsEnumerable()
            Try
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_ref_det").ToString Equals _t2("id_ref_det").ToString And _t1("rmt_ref").ToString Equals _t2("rmt_ref").ToString Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
                GVData.BestFitColumns()
            Catch ex As Exception
                GCData.DataSource = Nothing
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPayoutZaloraManualReconRef_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[is_select]='No'"
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'cek di tabel
            Dim id_ref_det_cek As String = ""
            For c As Integer = 0 To GVData.RowCount.ToString - 1
                If c > 0 Then
                    id_ref_det_cek += ","
                End If
                id_ref_det_cek += GVData.GetRowCellValue(c, "id_ref_det").ToString
            Next
            Dim qcek As String = "SELECT * 
            FROM tb_payout_zalora_det_addition a
            INNER JOIN tb_payout_zalora_det d ON d.id_payout_zalora_det = a.id_payout_zalora_det 
            WHERE a.id_ref_det IN (" + id_ref_det_cek + ") AND a.rmt_ref IN (48,118, 292) "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                stopCustom("Some items already used")
            Else
                Dim qins As String = "INSERT INTO tb_payout_zalora_det_addition(id_payout_zalora_det, erp_amount, id_acc, is_use_ref, id_ref, id_ref_det, rmt_ref) VALUES "
                For i As Integer = 0 To GVData.RowCount.ToString - 1
                    If i > 0 Then
                        qins += ","
                    End If
                    qins += "('" + id_payout_zalora_det + "', '" + decimalSQL(GVData.GetRowCellValue(i, "amo").ToString) + "','" + GVData.GetRowCellValue(i, "id_acc").ToString + "', 1, '" + GVData.GetRowCellValue(i, "id_ref").ToString + "', '" + GVData.GetRowCellValue(i, "id_ref_det").ToString + "', '" + GVData.GetRowCellValue(i, "rmt_ref").ToString + "') "
                Next
                If GVData.RowCount.ToString > 0 Then
                    execute_non_query(qins, True, "", "", "", "")
                End If
                FormPayoutZaloraManualReconSingle.viewDetail()
                FormPayoutZaloraManualReconSingle.getTotal()
                viewData()
            End If
            Cursor = Cursors.Default
        Else
            warningCustom("Please select reference")
        End If
        GVData.ActiveFilterString = ""
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        If TxtOrderNo.Text <> "" Then
            viewData()
        End If
    End Sub
End Class