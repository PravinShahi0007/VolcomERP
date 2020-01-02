Public Class ReportDelManifest
    Public id_del_manifest As String = "0"
    Public dt As DataTable = New DataTable

    Private Sub ReportDelManifest_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim id_emp_wh_manager As String = get_setup_field("id_emp_wh_manager")

        CAdminWH.Text = get_emp(id_employee_user, "2").ToString.ToUpper
        CAdminWHPosition.Text = get_emp(id_employee_user, "6")
        CWHManager.Text = get_emp(id_emp_wh_manager, "2").ToString.ToUpper
        CWHManagerPosition.Text = get_emp(id_emp_wh_manager, "6")
        LabelPrintedDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        For i = 0 To dt.Rows.Count - 1
            row = XrTable.InsertRowBelow(row)

            row.HeightF = 25
            row.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            row.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size, FontStyle.Regular)

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = dt.Rows(i)("no").ToString
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

            'delivery slip
            Dim do_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            do_no.Text = dt.Rows(i)("do_no").ToString

            'number
            Dim number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            number.Text = dt.Rows(i)("pl_sales_order_del_number").ToString

            'store account
            Dim comp_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            comp_number.Text = dt.Rows(i)("comp_number").ToString

            'store name
            Dim comp_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            comp_name.Text = dt.Rows(i)("comp_name").ToString

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            qty.Text = dt.Rows(i)("qty").ToString
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'destination
            Dim city As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            city.Text = dt.Rows(i)("city").ToString

            'weight
            Dim weight As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            weight.Text = dt.Rows(i)("weight").ToString
            weight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'p
            Dim width As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

            width.Text = Decimal.Round(dt.Rows(i)("width"), 2)
            width.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'l
            Dim length As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)

            length.Text = Decimal.Round(dt.Rows(i)("length"), 2)
            length.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            't
            Dim height As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)

            height.Text = Decimal.Round(dt.Rows(i)("height"), 2)
            height.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'dim
            Dim volume As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)

            volume.Text = Decimal.Round(dt.Rows(i)("volume"), 2)
            volume.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'final weight
            Dim c_weight As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)

            c_weight.Text = Decimal.Round(dt.Rows(i)("c_weight"), 2)
            c_weight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'remark
            Dim remark As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(13)

            'add last border
            If i = dt.Rows.Count - 1 Then
                no.Borders = no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                do_no.Borders = do_no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                number.Borders = number.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                comp_number.Borders = comp_number.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                comp_name.Borders = comp_name.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                qty.Borders = qty.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                city.Borders = city.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                weight.Borders = weight.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                width.Borders = width.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                length.Borders = length.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                height.Borders = height.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                volume.Borders = volume.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                c_weight.Borders = c_weight.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                remark.Borders = remark.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
            End If
        Next
    End Sub
End Class