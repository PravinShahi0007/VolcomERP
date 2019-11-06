Public Class FormEmpAttnSumDetailSick
    Public id_employee As String = "-1"
    Public date_from As Date = Date.Now
    Public date_to As Date = Date.Now
    Public month As Date = Nothing

    Private Sub FormEmpAttnSumDetailSick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_employee As DataTable = execute_query("SELECT employee_code, employee_name FROM tb_m_employee WHERE id_employee = " + id_employee, -1, True, "", "", "", "")

        TEEmployeeCode.EditValue = data_employee.Rows(0)("employee_code").ToString
        TEEmployeeName.EditValue = data_employee.Rows(0)("employee_name").ToString

        Dim where_month As String = ""

        If Not month = Nothing Then
            where_month = "AND YEAR(leave_det.datetime_start) = " + month.ToString("yyyy") + " AND MONTH(leave_det.datetime_start) = " + month.ToString("MM")
        End If

        Dim query_list As String = "
            SELECT DATE_FORMAT(leave_det.datetime_start, '%M %Y') AS leave_month, DATE_FORMAT(leave_det.datetime_start, '%d %M %Y') AS leave_date, DATE_FORMAT(leave_det.datetime_start, '%H:%i:%s') AS leave_from, DATE_FORMAT(leave_det.datetime_until, '%H:%i:%s') AS leave_to, (leave_det.minutes_total / 60) AS leave_total, leave.leave_purpose
            FROM tb_emp_leave_det AS leave_det
            LEFT JOIN tb_emp_leave AS `leave` ON leave_det.id_emp_leave = leave.id_emp_leave
            WHERE leave.id_report_status = 6 AND leave.id_leave_type = 2 AND leave_det.datetime_start BETWEEN '" + date_from.ToString("yyyy-MM-dd") + "' AND '" + date_to.ToString("yyyy-MM-dd") + "' AND leave.id_emp = " + id_employee + " " + where_month + "
            ORDER BY leave_det.datetime_start ASC
        "

        Dim data_list As DataTable = execute_query(query_list, -1, True, "", "", "", "")

        GCList.DataSource = data_list

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpAttnSumDetailSick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class