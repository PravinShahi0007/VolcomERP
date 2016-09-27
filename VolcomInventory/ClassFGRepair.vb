Public Class ClassFGRepair
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

        Dim query As String = ""
        query += "Select r.id_fg_repair, "
        query +="r.id_wh_drawer_from, comp_frm.id_comp As `id_comp_from`, comp_frm.comp_number As `comp_number_from`, comp_frm.comp_name As `comp_name_from`, "
        query += "r.id_wh_drawer_to, comp_to.id_comp As `id_comp_to`, comp_frm.comp_number As `comp_number_to`, comp_frm.comp_name As `comp_name_to`, "
        query += "r.fg_repair_number, r.fg_repair_date, DATE_FORMAT(r.fg_repair_date, '%Y-%m-%d') AS fg_repair_datex, "
        query += "r.fg_repair_note, r.id_report_status "
        query +="From tb_fg_repair r "
        query += "INNER Join tb_m_wh_drawer drw_frm On drw_frm.id_wh_drawer = r.id_wh_drawer_from  "
        query +="INNER Join tb_m_comp comp_frm On comp_frm.id_drawer_def = drw_frm.id_wh_drawer  "
        query += "INNER Join tb_m_wh_drawer drw_to On drw_to.id_wh_drawer = r.id_wh_drawer_to "
        query +="INNER Join tb_m_comp comp_to On comp_to.id_drawer_def = drw_to.id_wh_drawer "
        query += "INNER Join tb_lookup_report_status stt On stt.id_report_status = r.id_report_status "
        query += "WHERE r.id_fg_repair>0 "
        query += condition + " "
        query += "ORDER BY r.id_fg_repair " + order_type
        Return query
    End Function


End Class
