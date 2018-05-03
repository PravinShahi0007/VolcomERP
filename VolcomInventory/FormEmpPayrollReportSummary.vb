Public Class FormEmpPayrollReportSummary
    Public id_payroll As String = ""
    Private Sub FormEmpPayrollReportSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_sum()
    End Sub
    Sub load_sum()
        Dim query As String = "CALL"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    End Sub
End Class