Public Class FormEmpBPJSKesehatan
    Public is_approve As String = "0"

    Sub load_form()
        Dim query As String = "
            SELECT bpjs.id_pay_bpjs_kesehatan, bpjs.number, DATE_FORMAT(py.periode_end, '%M %Y') AS payroll_periode, IF(py.id_payroll_type = 1, 'Organic', 'Daily Worker') AS payroll_type, IF(bpjs.id_report_status = 0, 'Draft', rs.report_status) AS report_status, emp.employee_name AS created_by, DATE_FORMAT(bpjs.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_pay_bpjs_kesehatan AS bpjs
            LEFT JOIN tb_emp_payroll AS py ON bpjs.id_payroll = py.id_payroll
            LEFT JOIN tb_lookup_report_status AS rs ON bpjs.id_report_status = rs.id_report_status
            LEFT JOIN tb_m_employee AS emp ON bpjs.created_by = emp.id_employee
            ORDER BY py.periode_end DESC, py.id_payroll_type ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpBPJSKesehatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Private Sub FormEmpBPJSKesehatan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpBPJSKesehatan_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        If is_approve = "0" Then
            button_main("1", "1", "0")
        Else
            button_main("0", "0", "0")
        End If
    End Sub

    Private Sub FormEmpBPJSKesehatan_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormEmpBPJSKesehatanDet.id = GVList.GetFocusedRowCellValue("id_pay_bpjs_kesehatan").ToString
        FormEmpBPJSKesehatanDet.is_approve = is_approve

        FormEmpBPJSKesehatanDet.ShowDialog()
    End Sub
End Class