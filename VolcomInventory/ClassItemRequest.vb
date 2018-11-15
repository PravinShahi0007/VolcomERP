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

    Public Function queryDetailInfo(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT rd.id_item_req_det, rd.id_item_req, rd.id_item, i.item_desc, u.uom, rd.id_prepare_status, ps.prepare_status, rd.final_reason, rd.qty, IFNULL(dq.qty_del,0.0) AS `qty_del`,
        rd.remark, 'No' AS `is_select`
        FROM tb_item_req_det rd
        INNER JOIN tb_item i ON i.id_item = rd.id_item
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        LEFT JOIN (
	        SELECT dd.id_item_req_det, SUM(dd.qty) AS `qty_del`
	        FROM tb_item_del_det dd
	        INNER JOIN tb_item_del d ON d.id_item_del = dd.id_item_del
	        WHERE d.id_report_status=6
	        GROUP BY dd.id_item_req_det
        ) dq ON dq.id_item_req_det = rd.id_item_req_det
        INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = rd.id_prepare_status
        WHERE rd.id_item_req_det>0 "
        query += condition + " "
        query += "ORDER BY rd.id_item_req_det " + order_type
        Return query
    End Function
End Class
