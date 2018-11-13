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
        SELECT r.id_departement, " + id_storage_cat + ", rd.id_item, getAvgCost(rd.id_item), 154, r.id_item_req, rd.qty, NOW(), 1
        FROM tb_item_req r
        INNER JOIN tb_item_req_det rd ON rd.id_item_req = r.id_item_req
        WHERE r.id_item_req=" + id_item_req + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
