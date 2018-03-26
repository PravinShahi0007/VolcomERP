Public Class ReportEmpUni
    Public Shared id_period As String = "-1"

    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "CALL view_emp_uni_budget(" & id_period & ",0)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        DataSource = data
    End Sub
End Class