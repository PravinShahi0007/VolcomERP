Public Class ReportSalesInvoceDelSlip
    Public Shared id_sales_pos As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportSalesInvoceDelSlip_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "CALL view_sales_pos_head_report(" + id_sales_pos + ", " + id_user + "); "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DataSource = data

        'set footer detail
        RowTotalQty.Text = Decimal.Parse(data.Rows(0)("total_qty").ToString).ToString("N0")

        'detail
        Dim inv As New ClassSalesPOS()
        inv.detailReportDelSlip(id_sales_pos, XTable, XTRow)
    End Sub
End Class