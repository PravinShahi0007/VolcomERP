Public Class ClassItemRequest
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT r.id_item_req, r.id_departement, dept.departement, r.`number`, r.created_date, r.created_by, e.employee_name AS `created_by_name`, r.note, r.id_report_status, stt.report_status
        FROM tb_item_req r
        INNER JOIN tb_m_departement dept ON dept.id_departement = r.id_departement
        INNER JOIN tb_m_user u ON u.id_user = r.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        WHERE r.id_item_req>0 "
        query += condition + " "
        query += "ORDER BY r.id_item_req " + order_type
        Return query
    End Function

    Public Sub updateStock(ByVal id_item_req As String, ByVal id_storage_cat As String)
        Dim query As String = "INSERT INTO tb_storage_item (id_departement, id_storage_category,id_item, `value`, report_mark_type, id_report, storage_item_qty, storage_item_datetime, id_stock_status)
        SELECT req.id_departement, " + id_storage_cat + ",rd.id_item, getAvgCost(rd.id_item) AS `cost`, 152, rd.id_purc_return,rd.qty, NOW(),1
        FROM tb_purc_return_det rd
        INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
        INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req_det = pod.id_purc_req_det
        INNER JOIN tb_purc_req req ON req.id_purc_req = reqd.id_purc_req
        WHERE rd.id_purc_return=" + id_purc_return + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
