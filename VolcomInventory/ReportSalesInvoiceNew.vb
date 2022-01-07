Public Class ReportSalesInvoiceNew
    Public Shared id_sales_pos As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"


    Private Sub ReportSalesInvoiceNew_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "CALL view_sales_pos_head_report_v2(" + id_sales_pos + ", " + id_user + "); "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DataSource = data

        'set footer detail
        RowTotalQty.Text = Decimal.Parse(data.Rows(0)("total_qty").ToString).ToString("N0")
        RowTotalAmount.Text = Decimal.Parse(data.Rows(0)("total_amo").ToString).ToString("N0")

        'set invocie value info
        LabelDiscountValue.Text = Decimal.Parse(data.Rows(0)("discount_value").ToString).ToString("N0")
        LabelPotPenjualan.Text = Decimal.Parse(data.Rows(0)("pot_penjualan").ToString).ToString("N0")
        LabelNetto.Text = Decimal.Parse(data.Rows(0)("netto").ToString).ToString("N0")
        LabelDasarPPN.Text = Decimal.Parse(data.Rows(0)("dasar_ppn").ToString).ToString("N0")
        LabelPPN.Text = Decimal.Parse(data.Rows(0)("ppn").ToString).ToString("N0")
        LabelSay.Text = "Say : " + ConvertCurrencyToEnglish(data.Rows(0)("netto"), get_setup_field("id_currency_default"))

        'detail
        Dim inv As New ClassSalesPOS()
        inv.detailReport(id_sales_pos, XTable, XTRow)

        'report status
        Dim itime As String = "2"
        If id_report_status = "1" Then
            itime = "2"
            LabelNotice.Visible = False
        ElseIf id_report_status = "6" Then
            itime = "1"
            LabelNotice.Visible = True
        End If
        pre_load_mark_horz_plain_acc(rmt, id_sales_pos, "(                       )", itime, XrTable1)
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class