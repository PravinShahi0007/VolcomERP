Public Class ReportEmpUniPeriod
    Public Shared dt As DataTable

    Private Sub ReportEmpUniPeriod_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDetail.DataSource = dt
        'printed date & approved date
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date` "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub
End Class