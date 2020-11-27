﻿Public Class ClassOLStore
    Sub evaluateOOS(ByVal id_order_par As String, ByVal id_comp_group_par As String)
        execute_non_query_long("CALL check_oos_web_order_grp(" + id_order_par + ", " + id_comp_group_par + ");", True, "", "", "", "")
    End Sub

    Sub checkOOSEmptyOrder(ByVal id_order_par As String, ByVal id_comp_group_par As String)
        execute_non_query_long("CALL check_oos_empty_order_grp(" + id_order_par + ", " + id_comp_group_par + ");", True, "", "", "", "")
    End Sub

    Function checkOOSRestockOrder(ByVal id_order_par As String, ByVal id_comp_group_par As String)
        Dim query_check As String = "SELECT * FROM tb_ol_store_order od WHERE od.id='" + id_order_par + "' AND od.id_comp_group='" + id_comp_group_par + "' AND od.is_poss_replace=1 "
        Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        If data_check.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub sendEmailOOS(ByVal id_order_par As String, ByVal id_comp_group_par As String)

    End Sub

    Function viewListOOS(ByVal type_par As String) As DataTable
        Dim query As String = "SELECT os.id_ol_store_oos, os.number, os.id_comp_group, cg.comp_group, os.id_order, od.sales_order_ol_shop_number AS `order_number`, os.created_date,
        os.is_sent_email, os.manual_send_email_reason, os.sent_email_date,
        od.customer_name, SUM(od.ol_order_qty) AS `total_order`, SUM(od.sales_order_det_qty) AS `total_fill`, 
        SUM(od.ol_order_qty)-SUM(od.sales_order_det_qty) AS `total_no_stock`,
        IF(os.is_closed=1, 'closed', IF(os.is_sent_email=2,'waiting for restock','waiting for confirmation')) AS `status`
        FROM tb_ol_store_oos os
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = os.id_comp_group
        INNER JOIN tb_ol_store_order od ON od.id_ol_store_oos = os.id_ol_store_oos
        GROUP BY os.id_order 
        HAVING 1=1 " + type_par + ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

End Class
