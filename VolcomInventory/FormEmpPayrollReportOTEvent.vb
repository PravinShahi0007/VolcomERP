Public Class FormEmpPayrollReportOTEvent
    Public id_payroll As String = ""
    Private Sub FormEmpPayrollReportSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_sum()
    End Sub
    Sub load_sum()
        Dim query As String = "CALL view_payroll_ot_event('" & id_payroll & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollReportSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class