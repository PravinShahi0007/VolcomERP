Public Class ClassSampleDel
    Public Function queryMain() As String
        Dim query As String = ""
        query += "SELECT del.id_sample_del, del.sample_del_date, del.sample_del_number, "
        query += "del.id_report_status, del.id_comp_contact_to, del.id_comp_contact_from, "
        query += "(comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
        query += "(comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, "
        query += "stt.report_status, pl_cat.id_pl_category, pl_cat.pl_category, IFNULL(rec.total_qty_received, 0.00) AS total_qty_received, "
        query += "del_sum.total_qty_delivered "
        query += "FROM tb_sample_del del "
        query += "INNER JOIN tb_m_comp_contact cont_from ON cont_from.id_comp_contact = del.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp comp_from ON comp_from.id_comp = cont_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact cont_to ON cont_to.id_comp_contact = del.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp comp_to ON comp_to.id_comp = cont_to.id_comp "
        query += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = del.id_report_status "
        query += "INNER JOIN tb_lookup_pl_category pl_cat ON pl_cat.id_pl_category = del.id_pl_category "
        query += "LEFT JOIN( "
        query += "SELECT recv.id_sample_del,det.id_sample_del_det, SUM(det.sample_del_rec_det_qty) AS total_qty_received  "
        query += "FROM tb_sample_del_rec_det det "
        query += "INNER JOIN tb_sample_del_rec recv ON recv.id_sample_del_rec = det.id_sample_del_rec "
        query += "WHERE recv.id_report_status != '5' "
        query += "GROUP BY recv.id_sample_del "
        query += ") rec ON rec.id_sample_del = del.id_sample_del "
        query += "INNER JOIN ( "
        query += "SELECT del_sub.id_sample_del,SUM(det_sub.sample_del_det_qty) AS total_qty_delivered FROM tb_sample_del del_sub "
        query += "INNER JOIN tb_sample_del_det det_sub ON del_sub.id_sample_del = det_sub.id_sample_del "
        query += "WHERE del_sub.id_report_status ='6' "
        query += "GROUP BY det_sub.id_sample_del "
        query += ") del_sum ON del_sum.id_sample_del = del.id_sample_del "
        query += "WHERE del.id_report_status='6' "
        query += "ORDER BY del.id_sample_del ASC "
        Return query
    End Function

    Public Function queryDetail(ByVal id_sample_del_param As String) As String
        Dim query As String = "CALL view_sample_del('" + id_sample_del_param + "')"
        Return query
    End Function
End Class
