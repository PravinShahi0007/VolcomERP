Public Class FormEmpInputAttendance
    Private Sub FormEmpInputAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_attendance()
    End Sub

    Sub view_attendance()
        Dim query As String = "
            SELECT att.id_emp_attn_input, att.number, att.id_report_status, sts.report_status, DATE_FORMAT(att.created_at, '%d %M %Y %H:%i:%s') AS created_at, created_by.employee_name AS created_by
            FROM tb_emp_attn_input AS att
            LEFT JOIN tb_lookup_report_status AS sts ON att.id_report_status = sts.id_report_status
            LEFT JOIN tb_m_employee AS created_by ON att.created_by = created_by.id_employee
            ORDER BY att.number DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
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
End Class