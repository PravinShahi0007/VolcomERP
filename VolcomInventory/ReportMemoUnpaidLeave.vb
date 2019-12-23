Public Class ReportMemoUnpaidLeave
    Public Shared report_mark_type As String = "-1"
    Public Shared id_report As String = "-1"

    Private Sub ReportMemoUnpaidLeave_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "SELECT formdc.form_dc,empl.id_emp,empl.emp_leave_number,empl.leave_purpose,lt.leave_type,empl.report_mark_type, empl.id_leave_type,
                                emp.employee_name, emp.employee_code, emp.employee_position, dep.departement, 
                                emp_ch.employee_name AS name_ch, emp_ch.employee_code AS code_ch,emp.employee_join_date,
                                ROUND(empl.leave_remaining/60) AS leave_remaining,ROUND(empl.leave_total/60) AS leave_total,
                                periode.start_periode,periode.end_periode
                                FROM tb_emp_leave empl
                                INNER JOIN tb_lookup_leave_type lt ON lt.id_leave_type=empl.id_leave_type
                                INNER JOIN tb_m_employee emp ON emp.id_employee=empl.id_emp
                                INNER JOIN tb_m_employee emp_ch ON emp_ch.id_employee=empl.id_emp_change
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                LEFT JOIN tb_lookup_form_dc formdc ON formdc.id_form_dc=empl.id_form_dc
                                LEFT JOIN (SELECT id_emp_leave,MIN(datetime_start) AS start_periode,MAX(datetime_until) AS end_periode FROM tb_emp_leave_det GROUP BY id_emp_leave)
                                periode ON periode.id_emp_leave=empl.id_emp_leave
                                WHERE empl.id_emp_leave='" & id_report & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        XLNama.Text = data.Rows(0)("employee_name").ToString + " / " + data.Rows(0)("employee_code").ToString
        XLPosisi.Text = data.Rows(0)("employee_position").ToString
        XLDepartemen.Text = data.Rows(0)("departement").ToString
        XLPeriode.Text = Date.Parse(data.Rows(0)("start_periode").ToString).ToString("dd MMMM yyyy HH:mm") & " sampai " & Date.Parse(data.Rows(0)("end_periode").ToString).ToString("dd MMMM yyyy HH:mm")
        XLKeperluan.Text = data.Rows(0)("leave_purpose").ToString
        XLLama.Text = data.Rows(0)("leave_total").ToString & " jam"

        Dim query_head As String = "
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT leave_memo_to1 FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT leave_memo_to2 FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT leave_memo_cc1 FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT id_employee, employee_name, employee_position
            FROM tb_m_employee
            WHERE id_employee = (
	            SELECT usr.id_employee
	            FROM tb_m_employee AS emp
	            LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
	            LEFT JOIN tb_m_user AS usr ON dep.id_user_head = usr.id_user
	            WHERE emp.id_employee = " + data.Rows(0)("id_emp").ToString + "
            )
        "

        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")

        If data_head(2)("id_employee").ToString = data_head(3)("id_employee").ToString Then
            XrLabel20.Visible = False
            XLCC1Dot.Visible = False
            XLCC1.Visible = False
            XLCC1Position.Visible = False

            XPFrom.LocationF = New PointF(0, 56)

            SubBand1.HeightF = SubBand1.HeightF - 23
        End If

        XLTo1.Text = data_head(0)("employee_name").ToString
        XLToPosition1.Text = data_head(0)("employee_position").ToString
        XLTo2.Text = data_head(1)("employee_name").ToString
        XLToPosition2.Text = data_head(1)("employee_position").ToString
        XLCC1.Text = data_head(2)("employee_name").ToString
        XLCC1Position.Text = data_head(2)("employee_position").ToString
        XLFrom.Text = data_head(3)("employee_name").ToString
        XLFromPosition.Text = data_head(3)("employee_position").ToString

        pre_load_asg_horz(report_mark_type, data.Rows(0)("id_emp").ToString, XrTable1, "1")
    End Sub
End Class