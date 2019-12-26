Public Class ClassAREvaluation
    Function dtCekEmailRelease(ByVal id_group As String) As DataTable
        Dim query_cek_email_release As String = "SELECT e.id_comp_group, IFNULL(ep.jum_not_active,0) AS `jum_not_active`
        FROM tb_ar_eval e
        LEFT JOIN (
          SELECT e.id_comp_group,
          COUNT(e.id_sales_pos) AS `jum_not_active`
          FROM tb_ar_eval e
          WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e)
          AND e.id_comp_group IN (" + id_group + ") AND e.is_active=1
          GROUP BY e.id_comp_group
        ) ep ON ep.id_comp_group = e.id_comp_group
        WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e)
        AND e.id_comp_group IN (" + id_group + ")
        GROUP BY e.id_comp_group
        HAVING jum_not_active=0 "
        Dim data_cek_email_release As DataTable = execute_query(query_cek_email_release, -1, True, "", "", "", "")
        Return data_cek_email_release
    End Function

    Sub holdDelivery(ByVal date_eval As String)
        Try
            'jalankan evaluasi
            Dim qins As String = "CALL getEvaluationAR('" + date_eval + "'); "
            execute_non_query(qins, True, "", "", "", "")

            'log
            Dim query_log As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log) 
            VALUES('" + date_eval + "', NOW(), 'Evaluation Success'); "
            execute_non_query(query_log, True, "", "", "", "")
        Catch ex As Exception
            'log
            Dim query_log As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log) 
            VALUES('" + date_eval + "', NOW(), 'Evaluation Failed : " + addSlashes(ex.ToString) + "'); "
            execute_non_query(query_log, True, "", "", "", "")
        End Try
    End Sub

    Sub sendEmailHoldDelivery(ByVal date_eval As String, ByVal date_eval_display As String)
        Dim mm As New ClassMailManage()
        Dim id_mail As String = "-1"
        Try
            Dim query_cek_eval As String = "SELECT COUNT(e.id_ar_eval) AS jum_eval FROM tb_ar_eval e WHERE e.eval_date='" + date_eval + "' "
            Dim data_cek_eval As DataTable = execute_query(query_cek_eval, -1, True, "", "", "", "")
            If data_cek_eval.Rows(0)("jum_eval") > 0 Then
                'create mail manage
                Dim mail_subject As String = get_setup_field("mail_subject_on_hold") + " - " + date_eval_display.ToString
                Dim mail_title As String = get_setup_field("mail_title_on_hold")
                Dim mail_content As String = get_setup_field("mail_content_on_hold")
                Dim query_mail_content_to As String = "SELECT CONCAT(e.employee_name, ' (',e.employee_position,')') AS `to_content_mail`
                    FROM tb_opt o
                    INNER JOIN tb_m_employee e ON e.id_employee = o.id_emp_wh_manager "
                Dim mail_content_to As String = execute_query(query_mail_content_to, 0, True, "", "", "", "")

                'send paramenter class
                mm.rmt = "228"
                mm.mail_subject = mail_subject
                mm.mail_title = mail_title
                mm.par1 = date_eval
                mm.createEmail(id_user, "NULL", "NULL", "")
                id_mail = mm.id_mail_manage

                'send email
                Dim sm As New ClassSendEmail()
                sm.id_report = id_mail
                sm.report_mark_type = "228"
                sm.design_code = mail_title
                sm.design = mail_subject
                sm.comment_by = mail_content_to
                sm.comment = mail_content
                sm.dt = mm.getDetailData()
                sm.send_email()

                Dim querylog As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log) 
                    VALUES('" + date_eval + "', NOW(), 'Email Sent successfully'); " + mm.queryInsertLog(id_user, "2", "Sent successfully") + "; "
                execute_non_query(querylog, True, "", "", "", "")
            End If
        Catch ex As Exception
            'Log
            Dim query_log As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log) 
            VALUES('" + date_eval + "', NOW(), 'Failed send email : " + addSlashes(ex.ToString) + "'); " + mm.queryInsertLog(id_user, "3", addSlashes(ex.ToString))
            execute_non_query(query_log, True, "", "", "", "")
        End Try

    End Sub
End Class