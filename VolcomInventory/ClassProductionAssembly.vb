Public Class ClassProductionAssembly
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

        Dim query As String = "SELECT a.id_prod_ass, a.prod_ass_number, a.prod_ass_date, 
        a.id_design, d.design_code AS `code`, d.design_display_name AS `name`, SUM(b.prod_ass_det_qty) AS `total`, a.prod_ass_note, 
        a.id_report_status, rs.report_status
        FROM tb_prod_ass a
        INNER JOIN tb_prod_ass_det b ON a.id_prod_ass = b.id_prod_ass
        INNER JOIN tb_m_design d ON d.id_design = a.id_design
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = a.id_report_status
        WHERE a.id_prod_ass>0 "
        query += condition + " "
        query += "GROUP BY a.id_prod_ass "
        query += "ORDER BY a.id_prod_ass " + order_type
        Return query
    End Function
End Class
