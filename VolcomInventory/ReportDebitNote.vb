Public Class ReportDebitNote
    Public Shared id_period As String = "-1"
    Public row_number As Integer = 0
    Private Sub ReportDebitNote_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "SELECT id_prod_order_rec FROM tb_prod_debit_note_det WHERE id_prod_debit_note='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        DataSource = data
    End Sub

    Private Sub XrTableCell1_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrTableCell1.BeforePrint
        row_number += 1
        Dim cell As DevExpress.XtraReports.UI.XRTableCell = CType(sender, DevExpress.XtraReports.UI.XRTableCell)
        cell.Text = row_number.ToString
    End Sub
End Class