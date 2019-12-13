﻿Public Class ClassMailManage
    Public id_mail_manage As String = "-1"
    Public mail_subject As String = ""
    Public mail_title As String = ""
    Public rmt As String = "-1"
    Public par1 As String = ""

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

    Sub createEmail()
        Dim query_mail_manage As String = "INSERT INTO tb_mail_manage(number, created_date, created_by, updated_date, updated_by, report_mark_type, id_mail_status, mail_status_note, mail_subject, mail_parameter) 
        VALUES('', NOW(), NULL, NOW(), NULL, " + rmt + ", 1, 'Draft', '" + mail_subject + "', '" + par1 + "'); SELECT LAST_INSERT_ID(); "
        id_mail_manage = execute_query(query_mail_manage, 0, True, "", "", "", "")
        'update number mail
        execute_non_query("CALL gen_number(" + id_mail_manage + ", " + rmt + ");", True, "", "", "", "")
        'insert member & detil
        Dim query_mail_detail As String = "/*member*/
        INSERT INTO tb_mail_manage_member(id_mail_manage, id_mail_member_type, id_user, id_comp_contact, mail_address) 
        SELECT " + id_mail_manage + " AS `id_mail_manage`, m.id_mail_member_type, m.id_user, NULL AS `id_comp_contact`, e.email_external AS `mail_address`
        FROM tb_mail_manage_mapping_intern m
        INNER JOIN tb_m_user u ON u.id_user = m.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE m.report_mark_type=" + rmt + ";
        /*detil*/
        INSERT INTO tb_mail_manage_det(id_mail_manage, report_mark_type, id_report, report_number) "
        If rmt = "230" Then
            query_mail_detail += "SELECT " + id_mail_manage + ", " + rmt + ", g.id_comp_group AS `id_report`, NULL AS `report_number` 
            FROM tb_m_comp_group g WHERE g.id_comp_group IN(" + par1 + ") "
        End If
        execute_non_query(query_mail_detail, True, "", "", "", "")
    End Sub

    Function getDetailData() As DataTable
        Dim dt As New DataTable

        'get id_report
        Dim query_get_id As String = "SELECT GROUP_CONCAT(md.id_report) AS `id_report`
        FROM tb_mail_manage_det md
        WHERE md.id_mail_manage=" + id_mail_manage + " "
        Dim id_trans As String = execute_query(query_get_id, 0, True, "", "", "", "")

        If rmt = "230" Then
            Dim query As String = "SELECT  g.id_comp_group,g.description AS `group_store`
            FROM tb_m_comp_group g
            WHERE g.id_comp_group IN (" + id_trans + "); "
            dt = execute_query(query, -1, True, "", "", "", "")
        End If
        Return dt
    End Function

    Function queryInsertLog(ByVal id_status_par As String, ByVal note_par As String) As String
        Dim query As String = ""
        If id_mail_manage <> "-1" Then
            query = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by=NULL, 
            id_mail_status=" + id_status_par + ", mail_status_note='" + addSlashes(note_par) + "' WHERE id_mail_manage='" + id_mail_manage + "'; 
            INSERT INTO tb_mail_manage_log(id_mail_manage, log_date, id_user, id_mail_status, note) VALUES 
            ('" + id_mail_manage + "', NOW(),NULL, '" + id_status_par + "', '" + addSlashes(note_par) + "'); "
        End If
        Return query
    End Function
End Class
