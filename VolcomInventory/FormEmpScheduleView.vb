﻿Public Class FormEmpScheduleView
    Public id_employee As String = "-1"

    Private Sub FormEmpScheduleView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_date_edit()
        load_schedule()
        If FormEmpSchedule.is_security = "1" Then
            BTempSchedule.Visible = False
        End If
    End Sub

    Sub load_date_edit()
        Dim query As String = "SELECT MIN(`date`) as min_date
,MAX(`date`) as max_date
,DATE_FORMAT(MAX(`date`),'%Y-01-01') AS year_start 
FROM tb_emp_schedule 
WHERE id_employee='" & id_employee & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim date_start, date_until As Date

        If Not IsDBNull(data.Rows(0)("min_date")) Then
            'date_start = data.Rows(0)("min_date")
            date_start = data.Rows(0)("year_start")
            date_until = data.Rows(0)("max_date")
        Else
            date_start = Now
            date_until = Now
        End If

        DEStart.EditValue = date_start
        DEUntil.EditValue = date_until
    End Sub

    Private Sub FormEmpScheduleView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BTempSchedule_Click(sender As Object, e As EventArgs) Handles BTempSchedule.Click
        FormEmpScheduleViewSet.id_employee = id_employee
        FormEmpScheduleViewSet.ShowDialog()
    End Sub

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            load_schedule()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            load_report()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            get_log()
        End If
    End Sub

    Sub get_log()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = "SELECT emp.employee_code,emp.employee_name,att.datetime,type_log.type_log,fp.name AS fp_machine,IF(att.scan_method=1,'Fingerprint','Face') AS scan_method FROM tb_emp_attn att
                                INNER JOIN tb_m_employee emp ON emp.id_employee=att.id_employee AND emp.id_employee='" & id_employee & "'
                                INNER JOIN tb_lookup_type_log type_log ON type_log.id_type_log=att.type_log
                                INNER JOIN tb_m_fingerprint fp ON fp.id_fingerprint=att.id_fingerprint
                                WHERE DATE(att.datetime) >='" & date_start & "' AND DATE(att.datetime) <='" & date_until & "'
                                ORDER BY att.datetime ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLogAttn.DataSource = data
        GVLogAttn.BestFitColumns()
    End Sub

    Sub load_report()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim id_dep As String = execute_query("SELECT id_departement FROM tb_m_employee WHERE id_employee = " + id_employee, 0, True, "", "", "", "")

        Dim tb_attn As String = "
            (SELECT * FROM tb_emp_attn WHERE id_employee = " & id_employee & " AND DATE(`datetime`) >= DATE_ADD('" & date_start & "', INTERVAL -1 DAY) AND DATE(`datetime`) <= DATE_ADD('" & date_until & "', INTERVAL 1 DAY))
            UNION ALL
            (SELECT 0 AS id_emp_attn, 0 AS id_fingerprint, e.employee_code, d.id_employee, d.time_in AS `datetime`, 1 AS type_log, 0 AS scan_method
            FROM `tb_emp_attn_input_det` AS d
            LEFT JOIN `tb_emp_attn_input` AS a ON d.id_emp_attn_input = a.id_emp_attn_input
            LEFT JOIN `tb_m_employee` AS e ON d.id_employee = e.id_employee
            WHERE d.id_departement = 17 AND d.id_employee = " & id_employee & " AND d.date >= DATE_ADD('" & date_start & "', INTERVAL 1 DAY) AND d.date <= DATE_ADD('" & date_until & "', INTERVAL -1 DAY))
            UNION ALL
            (SELECT 0 AS id_emp_attn, 0 AS id_fingerprint, e.employee_code, d.id_employee, d.time_out AS `datetime`, 2 AS type_log, 0 AS scan_method
            FROM `tb_emp_attn_input_det` AS d
            LEFT JOIN `tb_emp_attn_input` AS a ON d.id_emp_attn_input = a.id_emp_attn_input
            LEFT JOIN `tb_m_employee` AS e ON d.id_employee = e.id_employee
            WHERE d.id_departement = 17 AND d.id_employee = " & id_employee & " AND d.date >= DATE_ADD('" & date_start & "', INTERVAL 1 DAY) AND d.date <= DATE_ADD('" & date_until & "', INTERVAL -1 DAY))
        "

        'tb_attn = "tb_emp_attn"

        Dim query As String = ""
        query = "SELECT tb.*,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),(tb.minutes_work-tb.over_break-tb.late+IF(tb.over<0,tb.over,0)),0) AS work_hour,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out),1,0) AS present FROM
                (
                    SELECT sch.id_schedule,lvl.employee_level,emp.employee_position,ket.id_leave_type,ket.leave_type,sch.info_leave,active.employee_active,active.id_employee_active,sch.id_employee,emp.employee_name,emp.employee_code,emp.id_departement,dept.departement,sch.date,DAYNAME(sch.date) weekday,
                    sch.in,sch.in_tolerance,
                    IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) AS `att_in`, 
                    sch.out,
                    IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime)) AS `att_out`, 
                    sch.break_out,MIN(at_brout.datetime) AS start_break, 
                    sch.break_in,MAX(at_brin.datetime) AS end_break, 
                    scht.id_schedule_type,
                    scht.schedule_type,note ,
                    sch.minutes_work,
                    IF(IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))<0,0,IF(MIN(at_in.datetime)>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,MIN(at_in.datetime)),0) - IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_until=sch.out,0,lv.minutes_total+60))) AS late ,
                    IF(lv.is_full_day=1,0,IF(TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60)))<-(sch.out_tolerance),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60))),TIMESTAMPDIFF(MINUTE,sch.out,MAX(at_out.datetime)) + IF(lv.is_full_day=1 OR ISNULL(lv.datetime_until),0,IF(lv.datetime_start=sch.in_tolerance,0,IF(lv.id_leave_type=5 OR lv.id_leave_type=6,lv.minutes_total,lv.minutes_total+60))))) AS over,
                IF(TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),
                TIMESTAMPDIFF(MINUTE,MIN(at_brout.datetime),MAX(at_brin.datetime))-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break ,
                TIMESTAMPDIFF(MINUTE,IF(sch.id_schedule_type='1',MIN(at_in.datetime),MIN(at_in_hol.datetime)) ,IF(sch.id_schedule_type='1',MAX(at_out.datetime),MAX(at_out_hol.datetime))) AS actual_work_hour 
                FROM tb_emp_schedule sch 
                LEFT JOIN
                (
                SELECT eld.*,el.`id_leave_type` FROM tb_emp_leave_det eld
                INNER JOIN tb_emp_leave el ON el.id_emp_leave=eld.id_emp_leave
                WHERE el.id_report_status='6' 
                ) lv ON lv.id_schedule=sch.id_schedule
                LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type=sch.id_leave_type 
                INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee 
                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                INNER JOIN tb_m_departement dept ON dept.id_departement=emp.id_departement 
                INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type 
                INNER JOIN tb_lookup_employee_active active ON emp.id_employee_active=active.id_employee_active
                LEFT JOIN (" + tb_attn + ") at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime>=(sch.out - INTERVAL 1 DAY) AND at_in.datetime<=sch.out) AND at_in.type_log = 1 
                LEFT JOIN (" + tb_attn + ") at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime>=sch.in AND at_out.datetime<=(sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
                LEFT JOIN (" + tb_attn + ") at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.Date AND at_brout.type_log = 3 
                LEFT JOIN (" + tb_attn + ") at_brin ON at_brin.id_employee=sch.id_employee AND DATE(at_brin.datetime) = sch.Date AND at_brin.type_log = 4
                LEFT JOIN (" + tb_attn + ") at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
                LEFT JOIN (" + tb_attn + ") at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2
                WHERE sch.id_employee='" & id_employee & "'
                And sch.date >='" & date_start & "'
                And sch.date <='" & date_until & "'
                GROUP BY sch.id_schedule
                ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAttendance.DataSource = data
        GVAttendance.BestFitColumns()
    End Sub

    Sub load_schedule()
        Dim query As String = ""
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        query = "SELECT * FROM tb_emp_schedule sch INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type"
        query += " WHERE sch.`date`>='" & date_start & "' AND sch.`date`<='" & date_until & "' AND sch.id_employee='" & id_employee & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub
End Class