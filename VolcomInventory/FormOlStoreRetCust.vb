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
SELECT id_comp_group,comp_group,description FROM tb_m_comp_group"
        viewSearchLookupQuery(SLECompGroup, q, "id_comp_group", "description", "id_comp_group")
    End Sub

    Sub view_order()
        Dim q As String = "SELECT 'ALL' AS sales_order_ol_shop_number
UNION
SELECT sales_order_ol_shop_number
FROM `tb_ol_store_ret_list` rl
INNER JOIN `tb_ol_store_ret_det` retd ON retd.`id_ol_store_ret`=rl.id_ol_store_ret_det
INNER JOIN tb_ol_store_ret ret ON retd.id_ol_store_ret=ret.id_ol_store_ret
WHERE ret.id_report_status=6 AND (rl.`id_ol_store_ret_stt`=4 OR rl.id_ol_store_ret_stt=5)
GROUP BY ret.sales_order_ol_shop_number"
        viewSearchLookupQuery(SLEOrder, q, "sales_order_ol_shop_number", "sales_order_ol_shop_number", "sales_order_ol_shop_number")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_list_ret()
    End Sub

    Private Sub FormOlStoreRetCust_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
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
End Class