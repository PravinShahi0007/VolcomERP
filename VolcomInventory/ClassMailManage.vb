Public Class ClassMailManage
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

        Dim query As String = "SELECT m.id_mail_manage, m.`number`, 
        m.created_date, m.created_by, ec.employee_name AS `created_by_name`, 
        m.updated_date, m.updated_by, eu.employee_name AS `updated_by_name`,
        m.report_mark_type, rmt.report_mark_type_name, 
        m.id_mail_status, ms.mail_status, m.mail_status_note, m.mail_subject, mto.`to`
        FROM tb_mail_manage m
        INNER JOIN tb_m_user uc ON uc.id_user = m.created_by
        INNER JOIN tb_m_employee ec ON ec.id_employee = uc.id_employee
        INNER JOIN tb_m_user uu ON uu.id_user = m.updated_by
        INNER JOIN tb_m_employee eu ON eu.id_employee = uu.id_employee
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = m.report_mark_type
        INNER JOIN tb_lookup_mail_status ms ON ms.id_mail_status = m.id_mail_status
        LEFT JOIN (
	        SELECT m.id_mail_manage, GROUP_CONCAT(DISTINCT m.mail_address ORDER BY m.id_mail_manage_member ASC SEPARATOR ', ') AS `to` 
	        FROM tb_mail_manage_member m WHERE m.id_mail_member_type=2 
	        GROUP BY m.id_mail_manage
        ) mto ON mto.id_mail_manage = m.id_mail_manage
        WHERE m.id_mail_manage>0 "
        query += condition + " "
        query += "ORDER BY m.id_mail_manage " + order_type
        Return query
    End Function
End Class
