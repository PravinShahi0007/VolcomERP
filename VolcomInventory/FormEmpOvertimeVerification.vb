Public Class FormEmpOvertimeVerification
    Public id_ot As String = ""

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Dim date_search As String = Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")

        'attendance
        Dim query_att As String = "
            SELECT emp.id_employee, emp.employee_code, emp.employee_name, att_in.datetime, att_out.datetime
            FROM tb_m_employee AS emp
            LEFT JOIN (
                SELECT MIN(datetime) AS datetime, id_employee
                FROM tb_emp_attn
                WHERE type_log = 1 AND DATE(datetime) = '" + date_search.ToString + "'
                GROUP BY id_employee
            ) AS att_in ON emp.id_employee = att_in.id_employee
            LEFT JOIN (
                SELECT MAX(datetime) AS datetime, id_employee
                FROM tb_emp_attn
                WHERE type_log = 2 AND DATE(datetime) = '" + date_search.ToString + "'
                GROUP BY id_employee
            ) AS att_out ON emp.id_employee = att_out.id_employee
            WHERE att_in.datetime IS NOT NULL AND att_out.datetime IS NOT NULL
        "

        Dim data_att As DataTable = execute_query(query_att, -1, True, "", "", "", "")

        GCAttendance.DataSource = data_att
    End Sub

    Private Sub FormEmpOvertimeVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT 1 AS id_type, 'Salary' AS type UNION SELECT 2 AS id_type, 'DP' AS type", 0, "type", "id_type")

        'propose
        Dim query_pro As String = "
            SELECT ot_det.id_employee, IFNULL(ot_det.only_dp, IF(salary.salary > (SELECT (ump + 1000000) AS ump FROM tb_emp_payroll WHERE ump IS NOT NULL ORDER BY periode_end DESC LIMIT 1), 'yes', 'no')) AS only_dp, DATE_FORMAT(ot_det.ot_date, '%d %b %Y') AS date, ot_det.id_departement, departement.departement, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, ot_det.conversion_type, DATE_FORMAT(ot_det.ot_start_time, '%d %b %Y %H:%i:%s') AS start_work_sub, DATE_FORMAT(ot_det.ot_end_time, '%d %b %Y %H:%i:%s') AS end_work_sub, ot_det.ot_break AS break_hours_sub, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.ot_start_time, ot_det.ot_end_time) / 60) - ot_det.ot_break, 1) AS total_hours_sub
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
            LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
            LEFT JOIN (
                SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                FROM tb_m_employee
            ) AS salary ON ot_det.id_employee = salary.id_employee
            WHERE ot_det.id_ot = " + id_ot + "
            ORDER BY ot_det.ot_date ASC, employee.id_employee_level ASC, employee.employee_code ASC
        "

        Dim data_pro As DataTable = execute_query(query_pro, -1, True, "", "", "", "")

        GCEmployee.DataSource = data_pro

        GVEmployee.BestFitColumns()

        'limit date search
        DESearch.EditValue = Date.Now

        DESearch.Properties.MinValue = Date.Parse(data_pro.Rows(0)("date"))
        DESearch.Properties.MaxValue = Date.Parse(data_pro.Rows(data_pro.Rows.Count - 1)("date"))
    End Sub

    Private Sub FormEmpOvertimeVerification_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class