Public Class ClassBSP
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

        Dim query As String = "SELECT b.id_bsp, b.number, b.created_date, b.created_by, 
        b.id_comp, c.comp_number, c.comp_name, c.id_comp_group,cg.description AS `comp_group_desc`,
        b.start_date, b.end_date, 
        b.id_report_status, stt.report_status, b.note, b.is_confirm
        FROM tb_bsp b
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = b.id_report_status 
        INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group "
        query += "WHERE b.id_bsp>0 "
        query += condition + " "
        query += "ORDER BY b.id_bsp " + order_type
        Return query
    End Function
End Class
