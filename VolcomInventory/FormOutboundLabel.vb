Public Class FormOutboundLabel
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_from_do()
    End Sub

    Sub load_from_do()
        Dim q_where As String = ""

        If Not SLEComp.EditValue.ToString = "0" Then
            q_where += " AND c.id_comp='" + addSlashes(SLEComp.EditValue.ToString) + "'"
        End If

        Dim query As String = "SELECT d.id_pl_sales_order_del, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
c.comp_number AS `store_number`,c.id_commerce_type,c.id_sub_district,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'no' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
FROM tb_pl_sales_order_del d
INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
WHERE d.`id_report_status`=1 AND so.is_export_awb=2  AND ISNULL(awb.id_awbill) " & q_where & "
GROUP BY d.id_pl_sales_order_del 
ORDER BY d.id_pl_sales_order_del DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GVDOERP.ActiveFilterString = ""
        GCDOERP.DataSource = data
        GVDOERP.BestFitColumns()
    End Sub

    Private Sub FormOutboundLabel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class