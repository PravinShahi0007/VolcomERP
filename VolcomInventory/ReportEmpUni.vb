Public Class ReportEmpUni
    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim id_period As String = "4"
        Dim query As String = "CALL view_emp_uni_budget(" & id_period & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        DataSource = data
    End Sub
End Class