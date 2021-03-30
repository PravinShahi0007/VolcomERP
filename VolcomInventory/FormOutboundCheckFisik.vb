Public Class FormOutboundCheckFisik
    Private Sub TEOutboundNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TEOutboundNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim q As String = "SELECT awb.id_awbill,SUM(awbd.qty) AS qty,dis.sub_district,IFNULL(c.comp_number,cg.comp_group) AS comp_number,IFNULL(c.comp_name,cg.description) AS comp_name,awb.ol_number
,GROUP_CONCAT(DISTINCT pl.`pl_sales_order_del_number`) AS sdo_number,GROUP_CONCAT(DISTINCT cb.`combine_number`) AS combine_number,GROUP_CONCAT(DISTINCT so.sales_order_ol_shop_number) AS online_order_number
FROM `tb_wh_awbill` awb 
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awb.id_sub_district
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
LEFT JOIN tb_m_comp c ON c.id_comp=awb.id_store
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=awbd.id_pl_sales_order_del
LEFT JOIN `tb_pl_sales_order_del_combine` cb ON cb.id_combine=pl.id_combine
INNER JOIN tb_sales_order so ON so.id_sales_order=pl.id_sales_order
INNER JOIN tb_m_comp_contact ccx ON ccx.id_comp_contact = pl.id_store_contact_to
INNER JOIN tb_m_comp cx ON cx.id_comp = ccx.id_comp
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=cx.`id_comp_group`
WHERE awb.is_old_ways!=1 AND awb.id_report_status!=5 AND awb.id_report_status!=6 AND awb.status_check_fisik!=3 AND awb.step=1 AND awb.ol_number='" & addSlashes(TEOutboundNumber.Text) & "'
GROUP BY awb.id_awbill"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                BReset.Visible = True
                TEOutboundNumber.Properties.ReadOnly = True
                '
                Dim q_item As String = "SELECT p.`id_product`,CONCAT(p.`product_full_code`,delc.pl_sales_order_del_det_counting) AS full_code,COUNT(CONCAT(p.`product_full_code`,delc.pl_sales_order_del_det_counting)) AS qty
,0 AS qty_scan
FROM tb_wh_awbill awb 
INNER JOIN tb_wh_awbill_det awbd ON awbd.`id_awbill`=awb.`id_awbill` AND awb.`ol_number`='" & addSlashes(TEOutboundNumber.Text) & "'
INNER JOIN `tb_pl_sales_order_del` del ON del.`id_pl_sales_order_del`=awbd.`id_pl_sales_order_del`
INNER JOIN `tb_pl_sales_order_del_det` deld ON deld.`id_pl_sales_order_del`=del.`id_pl_sales_order_del`
INNER JOIN tb_m_product p ON p.`id_product`=deld.`id_product`
INNER JOIN `tb_pl_sales_order_del_det_counting` delc ON delc.`id_pl_sales_order_del_det`=deld.`id_pl_sales_order_del_det`
GROUP BY full_code"
                Dim dt_item As DataTable = execute_query(q_item, -1, True, "", "", "", "")
                GCItemList.DataSource = dt_item
                GVItemList.BestFitColumns()
            Else
                warningCustom("Outbound number not found")
            End If
        End If
    End Sub

    Private Sub FormOutboundCheckFisik_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BReset.Click

    End Sub
End Class