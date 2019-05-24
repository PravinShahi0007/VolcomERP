Public Class FormProposeEmpSalary
    Private Sub FormProposeEmpSalary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pps()
    End Sub

    Private Sub FormProposeEmpSalary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_pps()
        Dim query As String = "
            SELECT sal.id_employee_sal_pps, sal.number, DATE_FORMAT(sal.effective_date, '%d %M %Y') AS effective_date, sal.note, IFNULL(sts.report_status, 'Draft') AS report_status, emp.employee_name AS created_by, DATE_FORMAT(sal.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_employee_sal_pps AS sal
            LEFT JOIN tb_m_employee AS emp ON sal.created_by = emp.id_employee
            LEFT JOIN tb_lookup_report_status AS sts ON sal.id_report_status = sts.id_report_status
            ORDER BY sal.id_employee_sal_pps DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub FormProposeEmpSalary_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormProposeEmpSalary_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GCList_DoubleClick(sender As Object, e As EventArgs) Handles GCList.DoubleClick
        FormProposeEmpSalaryDet.id_employee_sal_pps = GVList.GetFocusedRowCellValue("id_employee_sal_pps")
        FormProposeEmpSalaryDet.is_duplicate = "-1"
        FormProposeEmpSalaryDet.ShowDialog()
    End Sub
End Class