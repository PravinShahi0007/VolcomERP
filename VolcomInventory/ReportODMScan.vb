Public Class ReportODMScan
    Public id_odm_sc As String = ""
    Public dt As DataTable = New DataTable

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow

        If XrLabel3PL.Text = "WAREHOUSE" Then
            row = XRRowWH
            XrTableRow.Visible = False
        Else
            row = XrTableRow
            XRRowWH.Visible = False
        End If

        Dim last_collie As String = ""
        Dim last_del_manifest As String = ""
        Dim last_combine As String = ""

        Dim number As Integer = 0

        Dim total_qty As Integer = 0
        Dim total_final_weight As Decimal = 0.00

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

            'If Not last_collie = dt.Rows(i)("id_awbill").ToString Then
            '    no.RowSpan = rowspan_koli
            'End If

            If Not last_collie = dt.Rows(i)("id_awbill").ToString Then
                no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                no.Text = ""
                no.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'awb number
            Dim awbill_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            awbill_no.Text = dt.Rows(i)("awbill_no").ToString

            'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
            '    awbill_no.RowSpan = rowspan_del_manifest
            'End If

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                awbill_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                awbill_no.Text = ""
                awbill_no.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'collie
            Dim collie As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            collie.Text = dt.Rows(i)("ol_number").ToString

            'If Not last_collie = dt.Rows(i)("id_awbill").ToString Then
            '    collie.RowSpan = rowspan_koli
            'End If

            If Not last_collie = dt.Rows(i)("id_awbill").ToString Then
                collie.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                collie.Text = ""
                collie.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'delivery slip
            Dim do_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            do_no.Text = dt.Rows(i)("combine_number").ToString

            If Not last_combine = dt.Rows(i)("combine_number").ToString Then
                do_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                do_no.Text = ""
                do_no.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'store account
            Dim comp_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            comp_number.Text = dt.Rows(i)("comp_number").ToString

            'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
            '    comp_number.RowSpan = rowspan_del_manifest
            'End If

            If Not last_combine = dt.Rows(i)("combine_number").ToString Then
                comp_number.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                comp_number.Text = ""
                comp_number.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'store name
            Dim comp_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            comp_name.Text = dt.Rows(i)("comp_name").ToString

            'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
            '    comp_name.RowSpan = rowspan_del_manifest
            'End If

            If Not last_combine = dt.Rows(i)("combine_number").ToString Then
                comp_name.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                comp_name.Text = ""
                comp_name.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            qty.Text = dt.Rows(i)("qty").ToString
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            If Not last_combine = dt.Rows(i)("combine_number").ToString Then
                qty.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                qty.Text = ""
                qty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'destination
            Dim city As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            city.Text = dt.Rows(i)("city").ToString

            'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
            '    city.RowSpan = rowspan_del_manifest
            'End If

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                city.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                city.Text = ""
                city.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'district
            Dim dis As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

            dis.Text = dt.Rows(i)("sub_district").ToString

            'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
            '    dis.RowSpan = rowspan_del_manifest
            'End If

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                dis.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            Else
                dis.Text = ""
                dis.Borders = DevExpress.XtraPrinting.BorderSide.Left
            End If

            'weight
            Dim weight As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)

            weight.Text = dt.Rows(i)("weight").ToString
            weight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
            '    weight.RowSpan = rowspan_del_manifest
            'End If

            'pak hendri 22 november 2021, per koli
            'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
            '    weight.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            'Else
            '    weight.Text = ""
            '    weight.Borders = DevExpress.XtraPrinting.BorderSide.Left
            'End If

            weight.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top

            If XrLabel3PL.Text = "WAREHOUSE" Then
                'rec by
                Dim rec_by As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)

                rec_by.Text = ""
                rec_by.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    width.RowSpan = rowspan_del_manifest
                'End If

                If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                    rec_by.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
                Else
                    rec_by.Text = ""
                    rec_by.Borders = DevExpress.XtraPrinting.BorderSide.Left
                End If

                'rec_date
                Dim rec_date As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)

                rec_date.Text = ""
                rec_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    width.RowSpan = rowspan_del_manifest
                'End If

                If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                    rec_date.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
                Else
                    rec_date.Text = ""
                    rec_date.Borders = DevExpress.XtraPrinting.BorderSide.Left
                End If

                'remark
                Dim remark As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)

                remark.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right

                If Not last_combine = dt.Rows(i)("combine_number").ToString Then
                    remark.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right
                Else
                    remark.Text = ""
                    remark.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
                End If
            Else
                'p
                Dim width As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)

                width.Text = Decimal.Round(dt.Rows(i)("width"), 2)
                width.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    width.RowSpan = rowspan_del_manifest
                'End If

                'pak hendri 22 november 2021, per koli
                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    width.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
                'Else
                '    width.Text = ""
                '    width.Borders = DevExpress.XtraPrinting.BorderSide.Left
                'End If

                width.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top

                'l
                Dim length As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)

                length.Text = Decimal.Round(dt.Rows(i)("length"), 2)
                length.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    length.RowSpan = rowspan_del_manifest
                'End If

                'pak hendri 22 november 2021, per koli
                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    length.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
                'Else
                '    length.Text = ""
                '    length.Borders = DevExpress.XtraPrinting.BorderSide.Left
                'End If

                length.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top

                't
                Dim height As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)

                height.Text = Decimal.Round(dt.Rows(i)("height"), 2)
                height.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    height.RowSpan = rowspan_del_manifest
                'End If

                'pak hendri 22 november 2021, per koli
                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    height.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
                'Else
                '    height.Text = ""
                '    height.Borders = DevExpress.XtraPrinting.BorderSide.Left
                'End If
                height.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top

                'dim
                Dim volume As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(13)

                volume.Text = Decimal.Round(dt.Rows(i)("volume"), 2)
                volume.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    volume.RowSpan = rowspan_del_manifest
                'End If

                'pak hendri 22 november 2021, per koli
                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    volume.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
                'Else
                '    volume.Text = ""
                '    volume.Borders = DevExpress.XtraPrinting.BorderSide.Left
                'End If

                volume.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top

                'final weight
                Dim c_weight As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(14)

                c_weight.Text = Decimal.Round(dt.Rows(i)("c_weight"), 2)
                c_weight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                'If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                '    c_weight.RowSpan = rowspan_del_manifest
                'End If

                If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                    c_weight.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
                Else
                    c_weight.Text = ""
                    c_weight.Borders = DevExpress.XtraPrinting.BorderSide.Left
                End If

                'remark
                Dim remark As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(15)

                remark.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right

                If Not last_combine = dt.Rows(i)("combine_number").ToString Then
                    remark.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right
                Else
                    remark.Text = ""
                    remark.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
                End If
            End If

            If Not last_combine = dt.Rows(i)("combine_number").ToString Then
                total_qty = total_qty + dt.Rows(i)("qty").ToString
            Else
                row.HeightF = 0
            End If

            If Not last_del_manifest = dt.Rows(i)("id_del_manifest").ToString Then
                total_final_weight += Decimal.Round(dt.Rows(i)("c_weight"), 2)
            End If

            last_del_manifest = dt.Rows(i)("id_del_manifest").ToString
            last_collie = dt.Rows(i)("id_awbill").ToString
            last_combine = dt.Rows(i)("combine_number").ToString
        Next

        XrTableRowTotal.HeightF = 25

        XTCCollie.Text = total_qty
        XTCFW.Text = total_final_weight

        XrLabelJumlahKoli.Text = number.ToString
    End Sub
End Class