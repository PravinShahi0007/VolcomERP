Public Class ReportBalanceSheet
    Private Sub ReportBalanceSheet_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim pembanding As String = "0"
        Dim pembanding_sub As String = "0"
        Dim sub_this_month_value As Decimal = 0.0
        Dim sub_prev_month_value As Decimal = 0.0

        Dim font_row_style As New Font("Segoe UI", 6.5, FontStyle.Regular)
        '
        For i = 0 To FormReportBalanceSheet.GVAktiva.RowCount - 1 - GetGroupRowCount(FormReportBalanceSheet.GVAktiva)
            'header/sub header or footer
            'head footer

            'If Not pembanding = Strings.Left(FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "acc_name").ToString, 1) And Not pembanding = "0" Then
            '    add_row(XTableAktiva, FormReportBalanceSheet.GVAktiva.GetRowCellValue(i - 1, "head_name").ToString, "Total " & FormReportBalanceSheet.GVAktiva.GetRowCellValue(i - 1, "head_desc").ToString, 5, True, "", "")
            'End If

            ''sub footer
            'If Not pembanding_sub = Strings.Left(FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "acc_name").ToString, 2) And Not pembanding_sub = "0" Then
            '    add_row(XTableAktiva, FormReportBalanceSheet.GVAktiva.GetRowCellValue(i - 1, "sub_name").ToString, "Total " & FormReportBalanceSheet.GVAktiva.GetRowCellValue(i - 1, "sub_desc").ToString, 7, True, Decimal.Parse(sub_prev_month_value.ToString).ToString("N2"), Decimal.Parse(sub_this_month_value.ToString).ToString("N2"))
            '    sub_this_month_value = 0.0
            '    sub_prev_month_value = 0.0
            'End If

            ''header
            'If Not pembanding = Strings.Left(FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "acc_name").ToString, 1) Then
            '    add_row(XTableAktiva, FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "head_name").ToString, FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "head_desc").ToString, 5, False, "", "")
            'End If

            ''sub header
            'If Not pembanding_sub = Strings.Left(FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "acc_name").ToString, 2) Then
            '    add_row(XTableAktiva, FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "sub_name").ToString, FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "sub_desc").ToString, 7, False, "", "")
            'End If

            'pembanding = Strings.Left(FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "acc_name").ToString, 1)
            'pembanding_sub = Strings.Left(FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "acc_name").ToString, 2)

            If Not pembanding = FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "head_name").ToString And Not pembanding = "0" Then
                add_row(XTableAktiva, "", "Total " & FormReportBalanceSheet.GVAktiva.GetRowCellValue(i - 1, "head_desc").ToString, 5, True, "", "")
            End If

            'sub footer
            If Not pembanding_sub = FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "sub_name").ToString And Not pembanding_sub = "0" Then
                add_row(XTableAktiva, "", "Total " & FormReportBalanceSheet.GVAktiva.GetRowCellValue(i - 1, "sub_desc").ToString, 7, True, Decimal.Parse(sub_prev_month_value.ToString).ToString("N2"), Decimal.Parse(sub_this_month_value.ToString).ToString("N2"))
                sub_this_month_value = 0.0
                sub_prev_month_value = 0.0
            End If

            'header
            If Not pembanding = FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "head_name").ToString Then
                add_row(XTableAktiva, "", FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "head_desc").ToString, 5, False, "", "")
            End If

            'sub header
            If Not pembanding_sub = FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "sub_name").ToString Then
                add_row(XTableAktiva, "", FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "sub_desc").ToString, 7, False, "", "")
            End If

            '
            If pembanding = "0" Then
                CellFooterAsset.Text = "Total " & FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "head_desc").ToString
            End If
            '

            pembanding = FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "head_name").ToString
            pembanding_sub = FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "sub_name").ToString

            'detail
            Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
            row_det.HeightF = 10

            'No
            Dim no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            no.Text = FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "acc_name").ToString
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style
            no.WidthF = 70
            no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            no.Padding = 10

            row_det.Cells.Add(no)

            'Name
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            descrip.Text = FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "acc_description").ToString
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent
            descrip.Font = font_row_style
            descrip.WidthF = 230
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            descrip.Padding = 10

            row_det.Cells.Add(descrip)

            'Prev Month
            Dim prev_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            prev_month.Text = Decimal.Parse(FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "prev_month").ToString).ToString("N2")
            sub_prev_month_value += FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "prev_month")
            prev_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            prev_month.BackColor = Color.Transparent
            prev_month.Font = font_row_style
            prev_month.WidthF = 100
            prev_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            prev_month.Padding = 5

            row_det.Cells.Add(prev_month)

            'this month
            Dim this_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            this_month.Text = Decimal.Parse(FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "this_month").ToString).ToString("N2")
            sub_this_month_value += FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "this_month")
            this_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            this_month.BackColor = Color.Transparent
            this_month.Font = font_row_style
            this_month.WidthF = 100
            this_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            this_month.Padding = 5

            row_det.Cells.Add(this_month)
            XTableAktiva.Rows.Add(row_det)
            '
            If i = FormReportBalanceSheet.GVAktiva.RowCount - 1 - GetGroupRowCount(FormReportBalanceSheet.GVAktiva) Then
                add_row(XTableAktiva, "", "Total " & FormReportBalanceSheet.GVAktiva.GetRowCellValue(i, "sub_desc").ToString, 7, True, Decimal.Parse(sub_prev_month_value.ToString).ToString("N2"), Decimal.Parse(sub_this_month_value.ToString).ToString("N2"))
            End If
        Next
        XTableAktiva.DeleteRow(Xrowaktiva)
        '
        pembanding = "0"
        pembanding_sub = "0"
        sub_this_month_value = 0.00
        sub_prev_month_value = 0.00

        For i = 0 To FormReportBalanceSheet.GVPasiva.RowCount - 1 - GetGroupRowCount(FormReportBalanceSheet.GVPasiva)
            'header/sub header or footer
            'head footer
            'If Not pembanding = Strings.Left(FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "acc_name").ToString, 1) And Not pembanding = "0" Then
            '    add_row(XTablePasiva, FormReportBalanceSheet.GVPasiva.GetRowCellValue(i - 1, "head_name").ToString, "Total " & FormReportBalanceSheet.GVPasiva.GetRowCellValue(i - 1, "head_desc").ToString, 5, True, "", "")
            'End If

            ''sub footer
            'If Not pembanding_sub = Strings.Left(FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "acc_name").ToString, 2) And Not pembanding_sub = "0" Then
            '    add_row(XTablePasiva, FormReportBalanceSheet.GVPasiva.GetRowCellValue(i - 1, "sub_name").ToString, "Total " & FormReportBalanceSheet.GVPasiva.GetRowCellValue(i - 1, "sub_desc").ToString, 7, True, Decimal.Parse(sub_prev_month_value.ToString).ToString("N2"), Decimal.Parse(sub_this_month_value.ToString).ToString("N2"))
            '    sub_this_month_value = 0.0
            '    sub_prev_month_value = 0.0
            'End If

            ''header
            'If Not pembanding = Strings.Left(FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "acc_name").ToString, 1) Then
            '    add_row(XTablePasiva, FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "head_name").ToString, FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "head_desc").ToString, 5, False, "", "")
            'End If

            ''sub header
            'If Not pembanding_sub = Strings.Left(FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "acc_name").ToString, 2) Then
            '    add_row(XTablePasiva, FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "sub_name").ToString, FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "sub_desc").ToString, 7, False, "", "")
            'End If

            'pembanding = Strings.Left(FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "acc_name").ToString, 1)
            'pembanding_sub = Strings.Left(FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "acc_name").ToString, 2)

            If Not pembanding = FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "head_name").ToString And Not pembanding = "0" Then
                add_row(XTablePasiva, "", "Total " & FormReportBalanceSheet.GVPasiva.GetRowCellValue(i - 1, "head_desc").ToString, 5, True, "", "")
            End If

            'sub footer
            If Not pembanding_sub = FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "sub_name").ToString And Not pembanding_sub = "0" Then
                add_row(XTablePasiva, "", "Total " & FormReportBalanceSheet.GVPasiva.GetRowCellValue(i - 1, "sub_desc").ToString, 7, True, Decimal.Parse(sub_prev_month_value.ToString).ToString("N2"), Decimal.Parse(sub_this_month_value.ToString).ToString("N2"))
                sub_this_month_value = 0.0
                sub_prev_month_value = 0.0
            End If

            'header
            If Not pembanding = FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "head_name").ToString Then
                add_row(XTablePasiva, "", FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "head_desc").ToString, 5, False, "", "")
            End If

            'sub header
            If Not pembanding_sub = FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "sub_name").ToString Then
                add_row(XTablePasiva, "", FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "sub_desc").ToString, 7, False, "", "")
            End If

            If pembanding = "0" Then
                CellFooterLiability.Text = "Total " & FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "head_desc").ToString
            End If

            pembanding = FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "head_name").ToString
            pembanding_sub = FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "sub_name").ToString

            'detail
            Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
            row_det.HeightF = 10

            'No
            Dim no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            no.Text = FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "acc_name").ToString
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style
            no.WidthF = 70
            no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            no.Padding = 10

            row_det.Cells.Add(no)

            'Name
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            descrip.Text = FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "acc_description").ToString
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent
            descrip.Font = font_row_style
            descrip.WidthF = 230
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            descrip.Padding = 10

            row_det.Cells.Add(descrip)

            'Prev Month
            Dim prev_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            prev_month.Text = Decimal.Parse(FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "prev_month").ToString).ToString("N2")
            sub_prev_month_value += FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "prev_month")
            prev_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            prev_month.BackColor = Color.Transparent
            prev_month.Font = font_row_style
            prev_month.WidthF = 100
            prev_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            prev_month.Padding = 5

            row_det.Cells.Add(prev_month)

            'this month
            Dim this_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            this_month.Text = Decimal.Parse(FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "this_month").ToString).ToString("N2")
            sub_this_month_value += FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "this_month")
            this_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            this_month.BackColor = Color.Transparent
            this_month.Font = font_row_style
            this_month.WidthF = 100
            this_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            this_month.Padding = 5

            row_det.Cells.Add(this_month)
            XTablePasiva.Rows.Add(row_det)
            '
            If i = FormReportBalanceSheet.GVPasiva.RowCount - 1 - GetGroupRowCount(FormReportBalanceSheet.GVPasiva) Then
                add_row(XTablePasiva, "", "Total " & FormReportBalanceSheet.GVPasiva.GetRowCellValue(i, "sub_desc").ToString, 7, True, Decimal.Parse(sub_prev_month_value.ToString).ToString("N2"), Decimal.Parse(sub_this_month_value.ToString).ToString("N2"))
            End If
        Next
        XTablePasiva.DeleteRow(XRowPasiva)
        '
        CAThisMonth.Text = Decimal.Parse(FormReportBalanceSheet.GVAktiva.Columns("this_month").SummaryItem.SummaryValue.ToString).ToString("N2")
        CAPrevMonth.Text = Decimal.Parse(FormReportBalanceSheet.GVAktiva.Columns("prev_month").SummaryItem.SummaryValue.ToString).ToString("N2")
        '
        CPThisMonth.Text = Decimal.Parse(FormReportBalanceSheet.GVPasiva.Columns("this_month").SummaryItem.SummaryValue.ToString).ToString("N2")
        CPPrevMonth.Text = Decimal.Parse(FormReportBalanceSheet.GVPasiva.Columns("prev_month").SummaryItem.SummaryValue.ToString).ToString("N2")
        '
        Lunit.Text = FormReportBalanceSheet.SLEUnit.Text
        Luntil.Text = FormReportBalanceSheet.DEUntil.Text
    End Sub

    Sub add_row(ByVal xtb As DevExpress.XtraReports.UI.XRTable, ByVal acc_name As String, ByVal acc_desc As String, ByVal pad As Integer, ByVal border_all As Boolean, ByVal prev_month_value As String, ByVal this_month_value As String)
        Dim font_row_style As New Font("Segoe UI", 6.5, FontStyle.Regular)
        Dim pad_info As New DevExpress.XtraPrinting.PaddingInfo(pad, 5, 0, 0, 100.0F)
        'insert header
        Dim row_header As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        row_header.HeightF = 10
        row_header.BorderColor = Color.Black

        'No
        Dim header_no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        header_no.Text = acc_name
        header_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        header_no.BackColor = Color.Transparent
        header_no.Font = font_row_style
        header_no.WidthF = 70
        If border_all Then
            header_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
        Else
            header_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
        End If
        header_no.Padding = pad_info

        row_header.Cells.Add(header_no)

        'Name
        Dim header_descrip As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        header_descrip.Text = acc_desc
        header_descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        header_descrip.BackColor = Color.Transparent
        header_descrip.Font = font_row_style
        header_descrip.WidthF = 230
        If border_all Then
            header_descrip.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
        Else
            header_descrip.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
        End If
        header_descrip.Padding = pad_info

        row_header.Cells.Add(header_descrip)

        'Prev Month
        Dim header_prev_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        header_prev_month.Text = prev_month_value
        header_prev_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        header_prev_month.BackColor = Color.Transparent
        header_prev_month.Font = font_row_style
        header_prev_month.WidthF = 100
        If border_all Then
            header_prev_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
        Else
            header_prev_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
        End If
        header_prev_month.Padding = pad_info

        row_header.Cells.Add(header_prev_month)

        'this month
        Dim header_this_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        header_this_month.Text = this_month_value
        header_this_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        header_this_month.BackColor = Color.Transparent
        header_this_month.Font = font_row_style
        header_this_month.WidthF = 100
        If border_all Then
            header_this_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
        Else
            header_this_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
        End If
        header_this_month.Padding = pad_info

        row_header.Cells.Add(header_this_month)

        xtb.Rows.Add(row_header)
    End Sub
End Class