Public Class FormEmpInputAttendance
    Public is_hrd As String = "-1"

    Private Sub FormEmpInputAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Date.Parse(Now.Year.ToString + "-" + Now.Month.ToString + "-1")
        DETo.EditValue = Date.Parse(Now.Year.ToString + "-" + Now.Month.ToString + "-" + Date.DaysInMonth(Now.Year, Now.Month).ToString)

        view_attendance()
    End Sub

    Sub view_attendance()
        Dim departement_include As String = If(is_hrd = "1", "", "AND att.id_emp_attn_input IN (SELECT id_emp_attn_input FROM tb_emp_attn_input_det WHERE id_departement IN (SELECT allow_input_departement FROM tb_emp_attn_input_dep WHERE id_departement = " + id_departement_user + "))")

        Dim query As String = "
            SELECT att.id_emp_attn_input, att.number, att.note, att.id_report_status, sts.report_status, DATE_FORMAT(att.created_at, '%d %M %Y %H:%i:%s') AS created_at, created_by.employee_name AS created_by
            FROM tb_emp_attn_input AS att
            LEFT JOIN tb_lookup_report_status AS sts ON att.id_report_status = sts.id_report_status
            LEFT JOIN tb_m_employee AS created_by ON att.created_by = created_by.id_employee
            WHERE 1 " + departement_include + "
            ORDER BY att.number DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Sub view_employee()
        Dim departement_include As String = If(is_hrd = "1", "", "AND att_det.id_departement IN (SELECT allow_input_departement FROM tb_emp_attn_input_dep WHERE id_departement = " + id_departement_user + ")")

        Dim query As String = "
            SELECT att_det.id_emp_attn_input_det, att_det.id_departement, departement.departement, att_det.id_employee, employee.employee_code, employee.employee_name, att_det.employee_position, att_det.id_employee_status, sts.employee_status, att_det.date, att_det.time_in, att_det.time_out, att.id_emp_attn_input, att.number, att.note, att.id_report_status, report_sts.report_status, DATE_FORMAT(att.created_at, '%d %M %Y %H:%i:%s') AS created_at, created_by.employee_name AS created_by
            FROM tb_emp_attn_input_det AS att_det
            LEFT JOIN tb_emp_attn_input AS att ON att.id_emp_attn_input = att_det.id_emp_attn_input
            LEFT JOIN tb_m_employee AS employee ON att_det.id_employee = employee.id_employee
            LEFT JOIN tb_m_departement AS departement ON att_det.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_employee_status AS sts ON att_det.id_employee_status = sts.id_employee_status
            LEFT JOIN tb_lookup_report_status AS report_sts ON att.id_report_status = report_sts.id_report_status
            LEFT JOIN tb_m_employee AS created_by ON att.created_by = created_by.id_employee
            WHERE att_det.date BETWEEN '" + Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") + "' " + departement_include + "
            ORDER BY employee.employee_name ASC, att_det.date DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        GVEmployee.BestFitColumns()
    End Sub

    Private Sub FormEmpInputAttendance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpInputAttendance_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormEmpInputAttendance_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GCList_DoubleClick(sender As Object, e As EventArgs) Handles GCList.DoubleClick
        Try
            FormEmpInputAttendanceDet.id = GVList.GetFocusedRowCellValue("id_emp_attn_input").ToString

            FormEmpInputAttendanceDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        view_employee()
    End Sub
End Class