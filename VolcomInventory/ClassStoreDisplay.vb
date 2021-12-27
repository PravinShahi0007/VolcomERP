﻿Public Class ClassStoreDisplay
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

        Dim query As String = "SELECT p.id_display_pps, IFNULL(p.id_display_pps_ref,0) AS `id_display_pps_ref`, p.number, 
        p.created_date, p.created_by, ce.employee_name AS `created_by_name`,
        p.updated_date, p.updated_by, ue.employee_name AS `updated_by_name`,
        p.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, 
        p.id_season, ss.season, p.id_report_status, stt.report_status, p.note, p.is_confirm
        FROM tb_display_pps p
        INNER JOIN tb_m_user cu ON cu.id_user = p.created_by
        INNER JOIN tb_m_employee ce ON ce.id_employee = cu.id_employee
        INNER JOIN tb_m_user uu ON uu.id_user = p.updated_by
        INNER JOIN tb_m_employee ue ON ue.id_employee = uu.id_employee
        INNER JOIN tb_m_comp c ON c.id_comp = p.id_comp
        INNER JOIN tb_season ss ON ss.id_season = p.id_season
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = p.id_report_status
        WHERE p.id_display_pps>0 "
        query += condition + " "
        query += "ORDER BY p.id_display_pps " + order_type
        Return query
    End Function
End Class
