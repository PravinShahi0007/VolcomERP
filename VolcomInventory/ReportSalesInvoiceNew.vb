Public Class ReportSalesInvoiceNew
    Public Shared id_sales_pos As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"


    Private Sub ReportSalesInvoiceNew_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "CALL view_sales_pos_head_report(" + id_sales_pos + ", " + id_user + "); "
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
        viewDetail()

        'report status
        Dim itime As String = "2"
        If id_report_status = "1" Then
            itime = "2"
        ElseIf id_report_status = "6" Then
            itime = "1"
        End If
        pre_load_mark_horz_plain_acc(rmt, id_sales_pos, "(                       )", itime, XrTable1)
    End Sub

    Sub viewDetail()
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        Dim query As String = "CALL view_sales_pos_less('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        Dim font_row_style As New Font("Segoe UI", 7, FontStyle.Regular)
        For i = 0 To data.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)
                row.HeightF = 15
            Else
                row = XTable.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString + "."
            no.Borders = DevExpress.XtraPrinting.BorderSide.None
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style

            'barcode
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = data.Rows(i)("code").ToString
            code.Borders = DevExpress.XtraPrinting.BorderSide.None
            code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            code.BackColor = Color.Transparent
            code.Font = font_row_style

            'descrition
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            descrip.Text = data.Rows(i)("name").ToString
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.None
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent
            descrip.Font = font_row_style

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            size.Text = data.Rows(i)("size").ToString
            size.Borders = DevExpress.XtraPrinting.BorderSide.None
            size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            size.BackColor = Color.Transparent
            size.Font = font_row_style

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            qty.Text = Decimal.Parse(data.Rows(i)("sales_pos_det_qty").ToString).ToString("N0")
            qty.Borders = DevExpress.XtraPrinting.BorderSide.None
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.BackColor = Color.Transparent
            qty.Font = font_row_style

            'price
            Dim price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            price.Text = Decimal.Parse(data.Rows(i)("design_price_retail").ToString).ToString("N0")
            price.Borders = DevExpress.XtraPrinting.BorderSide.None
            price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            price.BackColor = Color.Transparent
            price.Font = font_row_style

            'amount
            Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            amo.Text = Decimal.Parse(data.Rows(i)("sales_pos_det_amount").ToString).ToString("N0")
            amo.Borders = DevExpress.XtraPrinting.BorderSide.None
            amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amo.BackColor = Color.Transparent
            amo.Font = font_row_style
        Next
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class