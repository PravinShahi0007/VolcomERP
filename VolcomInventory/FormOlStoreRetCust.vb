Public Class FormOlStoreRetCust
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormSalesPOS_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesPOS_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        'hide all except new
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormOlStoreRetCust_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp_group()
        view_order()
    End Sub

    Sub view_comp_group()
        Dim q As String = "SELECT 0 AS id_comp_group,'ALL' AS comp_group,'ALL' AS description
UNION
SELECT cg.id_comp_group,cg.comp_group,cg.description
FROM tb_m_comp c
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
WHERE c.id_commerce_type='2'  AND cg.is_marketplace=2
GROUP BY cg.`id_comp_group`"
        viewSearchLookupQuery(SLECompGroup, q, "id_comp_group", "description", "id_comp_group")
    End Sub

    Sub view_order()
        Dim q As String = "SELECT 'ALL' AS sales_order_ol_shop_number
UNION
SELECT sales_order_ol_shop_number
FROM `tb_ol_store_ret_list` rl
INNER JOIN `tb_ol_store_ret_det` retd ON retd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
INNER JOIN tb_ol_store_ret ret ON retd.id_ol_store_ret=ret.id_ol_store_ret
WHERE ret.id_report_status=6 AND (rl.`id_ol_store_ret_stt`=4 OR rl.id_ol_store_ret_stt=5)
GROUP BY ret.sales_order_ol_shop_number"
        viewSearchLookupQuery(SLEOrder, q, "sales_order_ol_shop_number", "sales_order_ol_shop_number", "sales_order_ol_shop_number")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_view()
    End Sub

    Sub load_view()
        If XTCRetCust.SelectedTabPageIndex = 0 Then
            view_list_ret()
        Else
            view_ret_req()
        End If
    End Sub

    Private Sub FormOlStoreRetCust_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_ret_req()
        Dim q_where As String = ""

        If Not SLECompGroup.EditValue.ToString = "0" Then
            q_where += " AND cg.id_comp_group='" & SLECompGroup.EditValue.ToString & "' "
        End If

        If Not SLEOrder.EditValue.ToString = "ALL" Then
            q_where += " AND r.sales_order_ol_shop_number='" & SLEOrder.EditValue.ToString & "' "
        End If

        Dim q As String = "SELECT rl.`id_ol_store_ret_list`,c.comp_name AS group_name,c.address_primary AS group_address,c.phone AS group_phone,ct.`city` AS group_city,c.postal_code AS group_postal_code,state.state AS group_region,cg.is_ret_to_cust,cg.`description` AS store_group,r.`number`,r.`ret_req_number`,sod.`item_id`,r.`sales_order_ol_shop_number`,r.`ret_req_number`,p.`product_display_name`,cd.`code_detail_name` AS size,stt.`ol_store_ret_stt`,emp.`employee_name`,rl.`update_date`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS full_code
,IF(so.shipping_address1='' OR ISNULL(so.shipping_address1),so.shipping_address,CONCAT(so.shipping_address1,' ',so.shipping_address2)) AS cust_address,so.shipping_city AS cust_city,so.shipping_phone AS cust_phone,so.shipping_post_code AS cust_postal_code,so.shipping_region AS cust_region,so.`shipping_name` AS cust_name
FROM tb_ol_store_ret_list rl
INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
INNER JOIN tb_ol_store_ret r ON r.`id_ol_store_ret`=rd.`id_ol_store_ret`
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=r.`id_comp_group`
LEFT JOIN tb_m_comp c ON c.id_comp=cg.id_comp
LEFT JOIN tb_m_sub_district sd ON sd.id_sub_district=c.id_sub_district
LEFT JOIN tb_m_city ct ON ct.id_city=sd.id_city
LEFT JOIN tb_m_state state ON state.id_state=ct.id_state
INNER JOIN tb_sales_order_det sod ON sod.`id_sales_order_det`=rd.id_sales_order_det
INNER JOIN tb_sales_order so ON so.id_sales_order=sod.id_sales_order
INNER JOIN tb_m_product p ON p.`id_product`=sod.`id_product`
INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt
LEFT JOIN tb_m_user usr ON usr.id_user=rl.`update_by`
LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE rl.id_ol_store_ret_stt='4' " & q_where

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCRetReq.DataSource = dt
        GVRetReq.BestFitColumns()
        '
        If GVRetReq.RowCount > 0 And Not SLECompGroup.EditValue.ToString = "0" And Not SLEOrder.EditValue.ToString = "" Then
            BRetCust.Visible = True
        Else
            BRetCust.Visible = False
        End If
    End Sub

    Sub view_list_ret()
        Dim q_where As String = ""

        If SLECompGroup.EditValue.ToString = "0" Then
            q_where += " WHERE 1=1 "
        Else
            q_where += " WHERE g.id_comp_group='" & SLECompGroup.EditValue.ToString & "' "
        End If

        If SLEOrder.EditValue.ToString = "ALL" Then
            q_where += " AND 1=1 "
        Else
            q_where += " AND retc.sales_order_ol_shop_number='" & SLEOrder.EditValue.ToString & "' "
        End If

        Dim q As String = "SELECT retc.`id_ol_store_cust_ret`,retc.`created_date`,retc.`number`,g.`description` AS store_group,emp.`employee_name`,retc.`sales_order_ol_shop_number`,sts.`report_status`
FROM `tb_ol_store_cust_ret` retc
INNER JOIN tb_m_comp_group g ON g.`id_comp_group`=retc.`id_comp_group`
INNER JOIN tb_m_user usr ON usr.`id_user`=retc.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=retc.`id_report_status`
" & q_where

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCRetCust.DataSource = dt
        GVRetCust.BestFitColumns()
    End Sub

    Private Sub BRetCust_Click(sender As Object, e As EventArgs) Handles BRetCust.Click
        If GVRetReq.RowCount > 0 And Not SLECompGroup.EditValue.ToString = "0" And Not SLEOrder.EditValue.ToString = "" Then
            FormOlStoreRetCustDet.ShowDialog()
        Else
            stopCustom("Please select order want to return first.")
        End If
    End Sub

    Private Sub GVRetCust_DoubleClick(sender As Object, e As EventArgs) Handles GVRetCust.DoubleClick
        If GVRetCust.RowCount > 0 Then
            FormOlStoreRetCustDet.id_ret = GVRetCust.GetFocusedRowCellValue("id_ol_store_cust_ret")
            FormOlStoreRetCustDet.ShowDialog()
        End If
    End Sub
End Class