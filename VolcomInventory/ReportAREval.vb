Public Class ReportAREval
    Public Shared dt As DataTable
    Public Shared eval_date_label As String = ""
    Public Shared eval_number As String = ""

    Private Sub ReportAREval_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'data
        GCInvoiceDetail.DataSource = dt

        'printed date & approved date
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date`, '" + eval_date_label + "' AS `eval_date`, '" + eval_number + "' AS `eval_number`, DATE_FORMAT(NOW(), '%d %M %Y') AS `curr_date` "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub
End Class