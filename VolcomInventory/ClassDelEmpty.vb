Public Class ClassDelEmpty
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

        Dim query As String = "SELECT del.id_wh_del_empty, del.wh_del_empty_number, 
        del.id_store_contact_from, cc.id_comp, CONCAT(c.comp_number,' - ', c.comp_name) AS `store`, COUNT(deld.id_wh_del_empty_det) AS `total`,
        del.wh_del_empty_date, del.id_report_status 
        FROM tb_wh_del_empty del
        INNER JOIN tb_wh_del_empty_det deld ON deld.id_wh_del_empty = del.id_wh_del_empty
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_from
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        WHERE del.id_wh_del_empty>0 "
        query += condition + " "
        query += "GROUP BY del.id_wh_del_empty  "
        query += "ORDER BY del.id_wh_del_empty " + order_type
        Return query
    End Function
End Class
