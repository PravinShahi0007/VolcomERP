Public Class ReportOutboundLabel
    Public id_awbill As String = ""
    Public dt As DataTable = New DataTable

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        XRBarcode.Text = id_awbill
        XRNumber.Text = id_awbill
        '
        Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        Dim number As Integer = 0

        Dim total_qty As Integer = 0
        Dim rowspan_del_manifest As Integer = 0
        Dim rowspan_koli As Integer = 0

        For i = 0 To dt.Rows.Count - 1
            'count number
            number = number + 1

            row = XrTable.InsertRowBelow(row)

            row.HeightF = 15
            row.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            row.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size, FontStyle.Regular)

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = number.ToString
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

            'delivery slip
            Dim do_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            do_no.Text = dt.Rows(i)("number").ToString

            'store account
            Dim comp_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            comp_number.Text = dt.Rows(i)("comp_number").ToString

            'store name
            Dim comp_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            comp_name.Text = dt.Rows(i)("comp_name").ToString

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            qty.Text = Decimal.Parse(dt.Rows(i)("qty").ToString).ToString("N0")
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            total_qty = total_qty + dt.Rows(i)("qty")
        Next

        XRTotal.Text = total_qty
        XRTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        XrTableRowTotal.HeightF = 15
    End Sub
End Class