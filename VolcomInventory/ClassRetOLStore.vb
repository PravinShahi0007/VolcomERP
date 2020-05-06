Public Class ClassRetOLStore
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

        Dim query As String = "SELECT r.id_ol_store_ret, r.ol_store_id, so.order_number, so.customer_name, r.ret_req_number, r.rec_date, r.`number`,
        r.created_date, r.created_by, r.note, r.id_report_status, stt.report_status
        FROM tb_ol_store_ret r
        INNER JOIN (
	        SELECT so.id_sales_order_ol_shop AS `id_order`, so.sales_order_ol_shop_number AS `order_number`, so.customer_name
	        FROM tb_sales_order so
	        GROUP BY so.id_sales_order_ol_shop
        ) so ON so.id_order = r.ol_store_id
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        WHERE r.id_ol_store_ret>0 "
        query += condition + " "
        query += "ORDER BY r.id_ol_store_ret " + order_type
        Return query
    End Function
End Class
