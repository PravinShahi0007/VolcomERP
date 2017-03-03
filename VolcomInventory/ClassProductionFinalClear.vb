Public Class ClassProductionFinalClear
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

        Dim query As String = "SELECT f.id_prod_fc, f.id_prod_order, 
        f.id_comp_from, cf.comp_number AS `comp_from_number`, cf.comp_name AS `comp_from_name`, CONCAT(cf.comp_number, ' - ', cf.comp_name) AS `comp_from`,
        f.id_comp_to, ct.comp_number AS `comp_to_number`, ct.comp_name AS `comp_to_name`, CONCAT(ct.comp_number, ' - ', ct.comp_name) AS `comp_to`,
        f.id_pl_category, c.pl_category,
        f.prod_fc_number, f.prod_fc_date, f.prod_fc_note, d.`total`, f.id_report_status, r.report_status 
        FROM tb_prod_fc f 
        INNER JOIN tb_m_comp cf ON cf.id_comp = f.id_comp_from 
        INNER JOIN tb_m_comp ct ON ct.id_comp = f.id_comp_to 
        INNER JOIN tb_lookup_pl_category c ON c.id_pl_category = f.id_pl_category
        INNER JOIN tb_lookup_report_status r ON r.id_report_status = f.id_report_status
        LEFT JOIN(
	        SELECT det.id_prod_fc, SUM(det.prod_fc_det_qty) AS `total`
	        FROM tb_prod_fc_det det
	        GROUP BY det.id_prod_fc
        ) d ON d.id_prod_fc = f.id_prod_fc
        WHERE f.id_prod_fc>0 "
        query += condition + " "
        query += "ORDER BY f.id_prod_fc " + order_type
        Return query
    End Function
End Class
