Public Class FormProdDemandPrintOpt
    Dim id As String = FormProdDemandSingle.id_prod_demand
    Dim rmt As String = FormProdDemandSingle.report_mark_type

    Private Sub FormProdDemandPrintOpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'checked
        Dim qc As String = "SELECT rm.id_report_mark, e.employee_name
        FROM tb_report_mark rm 
        INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
        WHERE rm.report_mark_type=" + rmt + " AND rm.id_report=" + id + " AND rm.id_report_status=2 "
        viewSearchLookupQuery(SLEChecked, qc, "id_report_mark", "employee_name", "id_report_mark")

        'aproved
        Dim qa As String = "SELECT rm.id_report_mark, e.employee_name
        FROM tb_report_mark rm 
        INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
        WHERE rm.report_mark_type=" + rmt + " AND rm.id_report=" + id + " AND rm.id_report_status=3 "
        viewSearchLookupQuery(SLEApproved, qa, "id_report_mark", "employee_name", "id_report_mark")
    End Sub

    Private Sub FormProdDemandPrintOpt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim id_checked As String = SLEChecked.EditValue.ToString
        Dim id_app As String = SLEApproved.EditValue.ToString
        Dim query_upd_all As String = "UPDATE tb_report_mark rm SET rm.is_use=2 WHERE rm.report_mark_type=" + rmt + " AND rm.id_report=" + id + " AND (rm.id_report_status=2 OR rm.id_report_status=3);
        UPDATE tb_report_mark rm SET rm.is_use=1 WHERE rm.id_report_mark = " + id_checked + "; 
        UPDATE tb_report_mark rm SET rm.is_use=1 WHERE rm.id_report_mark = " + id_app + "; "
        execute_non_query(query_upd_all, True, "", "", "", "")
        Close()
    End Sub
End Class