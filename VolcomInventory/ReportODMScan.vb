Public Class ReportODMScan
    Public id_odm_sc As String = ""
    Public dt As DataTable = New DataTable

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        Dim last_collie As String = ""
        Dim last_combine As String = ""
        Dim last_del_manifest As String = ""

        Dim number As Integer = 0

        Dim total_qty As Integer = 0
        Dim rowspan_del_manifest As Integer = 0
        Dim rowspan_koli As Integer = 0

        For i = 0 To dt.Rows.Count - 1
            'If i = 0 Then
            '    last_collie = dt.Rows(i)("id_awbill").ToString
            '    last_combine = dt.Rows(i)("combine_number").ToString
            'End If

            rowspan_del_manifest = 0
            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                'cek how many rowspan
                Dim q As String = "SELECT id_del_manifest_det FROM tb_del_manifest_det WHERE id_del_manifest='" & dt.Rows(i)("id_del_manifest").ToString & "'"
                Dim dtq As DataTable = execute_query(q, -1, True, "", "", "", "")
                rowspan_del_manifest = dtq.Rows.Count
            End If

            rowspan_koli = 0
            If Not last_collie = dt.Rows(i)("id_awbill").ToString Then
                'cek how many rowspan
                Dim q As String = "SELECT id_wh_awb_det FROM tb_wh_awbill_det WHERE id_awbill='" & dt.Rows(i)("id_awbill").ToString & "'"
                Dim dtq As DataTable = execute_query(q, -1, True, "", "", "", "")
                rowspan_koli = dtq.Rows.Count
            End If

            'skip same combine
            'If last_combine = dt.Rows(i)("combine_number").ToString And Not i = 0 Then
            'Continue For
            'End If

            'count number
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

            If Not last_collie = dt.Rows(i)("id_awbill").ToString Then
                no.RowSpan = rowspan_koli
            End If

            'del manifest
            Dim del_manifest As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            del_manifest.Text = dt.Rows(i)("number").ToString

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                del_manifest.RowSpan = rowspan_del_manifest
            End If

            'collie
            Dim collie As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            collie.Text = dt.Rows(i)("id_awbill").ToString

            If Not last_collie = dt.Rows(i)("id_awbill").ToString Then
                collie.RowSpan = rowspan_koli
            End If

            'delivery slip
            Dim do_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            do_no.Text = dt.Rows(i)("combine_number").ToString

            'awb number
            Dim awbill_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            awbill_no.Text = dt.Rows(i)("awbill_no").ToString

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                awbill_no.RowSpan = rowspan_del_manifest
            End If

            'store account
            Dim comp_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            comp_number.Text = dt.Rows(i)("comp_number").ToString

            'store name
            Dim comp_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            comp_name.Text = dt.Rows(i)("comp_name").ToString

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            qty.Text = dt.Rows(i)("qty").ToString
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'destination
            Dim city As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

            city.Text = dt.Rows(i)("city").ToString

            'weight
            Dim weight As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)

            weight.Text = dt.Rows(i)("weight").ToString
            weight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                weight.RowSpan = rowspan_del_manifest
            End If

            'p
            Dim width As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)

            width.Text = Decimal.Round(dt.Rows(i)("width"), 2)
            width.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                width.RowSpan = rowspan_del_manifest
            End If

            'l
            Dim length As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)

            length.Text = Decimal.Round(dt.Rows(i)("length"), 2)
            length.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                length.RowSpan = rowspan_del_manifest
            End If

            't
            Dim height As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)

            height.Text = Decimal.Round(dt.Rows(i)("height"), 2)
            height.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                height.RowSpan = rowspan_del_manifest
            End If

            'dim
            Dim volume As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(13)

            volume.Text = Decimal.Round(dt.Rows(i)("volume"), 2)
            volume.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                volume.RowSpan = rowspan_del_manifest
            End If

            'final weight
            Dim c_weight As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(14)

            c_weight.Text = Decimal.Round(dt.Rows(i)("c_weight"), 2)
            c_weight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                c_weight.RowSpan = rowspan_del_manifest
            End If

            'remark
            Dim remark As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(15)

            last_del_manifest = dt.Rows(i)("id_del_manifest").ToString
            last_collie = dt.Rows(i)("id_awbill").ToString
            last_combine = dt.Rows(i)("combine_number").ToString

            total_qty = total_qty + dt.Rows(i)("qty").ToString
        Next

        XrTableRowTotal.HeightF = 25

        XTCCollie.Text = total_qty

        XrLabelJumlahKoli.Text = number.ToString
    End Sub
End Class