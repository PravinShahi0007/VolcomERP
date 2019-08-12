Public Class FormEmpOvertimeVerification
    Public id_ot As String = ""

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Dim date_search As String = Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")

        'attendance
        Dim query_att As String = "
            SELECT emp.id_employee, emp.employee_code, emp.employee_name, att_in.datetime, att_out.datetime
            FROM tb_m_employee AS emp
            LEFT JOIN (
	            SELECT MIN(DATETIME) AS DATETIME, id_employee
	            FROM tb_emp_attn
	            WHERE type_log = 1 AND DATE(DATETIME) = '" + date_search.ToString + "'
	            GROUP BY id_employee
            ) AS att_in ON emp.id_employee = att_in.id_employee
            LEFT JOIN (
	            SELECT MAX(DATETIME) AS DATETIME, id_employee
	            FROM tb_emp_attn
	            WHERE type_log = 2 AND DATE(DATETIME) = '" + date_search.ToString + "'
	            GROUP BY id_employee
            ) AS att_out ON emp.id_employee = att_out.id_employee
        "

        Dim data_att As DataTable = execute_query(query_att, -1, True, "", "", "", "")

        GCAttendance.DataSource = data_att
    End Sub

    Private Sub FormEmpOvertimeVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'propose
    End Sub

    Private Sub FormEmpOvertimeVerification_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class