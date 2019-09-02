Public Class ReportSalesInvoiceNew
    Public Shared id_sales_pos As String = "-1"

    Private Sub ReportSalesInvoiceNew_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "CALL view_sales_pos_head_report(" + id_sales_pos + "); "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DataSource = data
        viewDetail()
    End Sub

    Sub viewDetail()
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        Dim query As String = "CALL view_sales_pos_less('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
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
            no.Borders = DevExpress.XtraPrinting.BorderSide.All
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent

            'barcode
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = data.Rows(i)("code").ToString
            code.Borders = DevExpress.XtraPrinting.BorderSide.All
            code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            code.BackColor = Color.Transparent

            'descrition
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            descrip.Text = "test"
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.All
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            descrip.Text = data.Rows(i)("size").ToString
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.All
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            qty.Text = Decimal.Parse(data.Rows(i)("sales_pos_det_qty").ToString).ToString("N0")
            qty.Borders = DevExpress.XtraPrinting.BorderSide.All
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            qty.BackColor = Color.Transparent

            'price
            Dim price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            price.Text = Decimal.Parse(data.Rows(i)("design_price_retail").ToString).ToString("N0")
            price.Borders = DevExpress.XtraPrinting.BorderSide.All
            price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            price.BackColor = Color.Transparent

            'amount
            Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            amo.Text = Decimal.Parse(data.Rows(i)("sales_pos_det_amount").ToString).ToString("N0")
            amo.Borders = DevExpress.XtraPrinting.BorderSide.All
            amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amo.BackColor = Color.Transparent
        Next
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class