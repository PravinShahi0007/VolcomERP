﻿Public Class ReportDelManifest
    Public id_del_manifest As String = "0"
    Public id_pre As String = "2"
    Public dt As DataTable = New DataTable

    Private Sub ReportDelManifest_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim id_emp_wh_manager As String = get_setup_field("id_emp_wh_manager")

        CAdminWH.Text = get_emp(id_employee_user, "2").ToString.ToUpper
        CAdminWHPosition.Text = get_emp(id_employee_user, "6")
        CWHManager.Text = get_emp(id_emp_wh_manager, "2").ToString.ToUpper
        CWHManagerPosition.Text = get_emp(id_emp_wh_manager, "6")
        LabelPrintedDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        Dim last_collie As String = ""

        Dim number As Integer = 1

        Dim total_qty As Integer = 0

        For i = 0 To dt.Rows.Count - 1
            If i = 0 Then
                last_collie = dt.Rows(i)("id_awbill").ToString
            End If

            If Not last_collie = dt.Rows(i)("id_awbill").ToString Then
                number = number + 1
            End If

            row = XrTable.InsertRowBelow(row)

            row.HeightF = 25
            row.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            row.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size, FontStyle.Regular)

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = number.ToString
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

            If Not i = 0 Then
                If last_collie = dt.Rows(i)("id_awbill").ToString Then
                    no.Text = ""
                    no.Borders = DevExpress.XtraPrinting.BorderSide.Left
                Else
                    no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
                End If
            End If

            'collie
            Dim collie As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            collie.Text = dt.Rows(i)("id_awbill").ToString

            'delivery slip
            Dim do_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            do_no.Text = dt.Rows(i)("do_no").ToString

            'number
            'Dim number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            'number.Text = dt.Rows(i)("pl_sales_order_del_number").ToString

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

            last_collie = dt.Rows(i)("id_awbill").ToString

            total_qty = total_qty + dt.Rows(i)("qty").ToString
        Next

        XrTableRowTotal.HeightF = 25

        XTCCollie.Text = total_qty

        XrLabelJumlahKoli.Text = number.ToString

        If id_pre = "1" Then
            XrLabelDraft.Text = "DRAFT"

            XrPanelSignature.Visible = False
        End If
    End Sub
End Class