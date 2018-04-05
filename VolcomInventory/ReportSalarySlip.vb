Public Class ReportSalarySlip
    Public Shared where_string As String = ""
    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "CALL view_salary_slip('" & where_string & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        DataSource = data
    End Sub
End Class