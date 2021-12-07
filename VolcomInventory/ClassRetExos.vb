Public Class ClassRetExos
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

        Dim query As String = "SELECT r.id_ret_exos, r.number, r.created_date, r.return_est_date, r.return_del_date, 
        r.id_store, c.comp_number AS `store_acc`, c.comp_name AS `store`, 
        r.id_order_type, ot.order_type, r.id_return_clasification, rc.return_clasification, 
        r.id_report_status, stt.report_status, r.note 
        FROM tb_ret_exos r 
        INNER JOIN tb_m_comp c ON c.id_comp = r.id_store
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = r.id_order_type
        INNER JOIN tb_lookup_return_clasification rc ON rc.id_return_clasification = r.id_return_clasification
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status "
        query += "WHERE r.id_ret_exos>0 "
        query += condition + " "
        query += "ORDER BY r.id_ret_exos " + order_type
        Return query
    End Function

End Class
