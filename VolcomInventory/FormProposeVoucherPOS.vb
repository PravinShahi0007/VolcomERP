Public Class FormProposeVoucherPOS
    Private Sub FormProposeVoucherPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_view()
    End Sub

    Private Sub FormProposeVoucherPOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProposeVoucherPOS_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormProposeVoucherPOS_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub load_view()
        Dim query As String = "
            SELECT p.id_voucher_pps, p.number, DATE_FORMAT(p.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, p.note, r.report_status
            FROM tb_pos_voucher_pps AS p
            LEFT JOIN tb_m_employee AS e ON p.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON p.id_report_status = r.id_report_status
            ORDER BY p.id_voucher_pps DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub

    Private Sub GCData_DoubleClick(sender As Object, e As EventArgs) Handles GCData.DoubleClick
        FormMain.but_edit()
    End Sub
End Class