Public Class ReportMonthlyISVs
    Public dt As DataTable
    Public languange As String = "eng"

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        Dim font_row_style As New Font("Segoe UI", 9, FontStyle.Regular)

        Dim tot_report_sub_t As Decimal = 0.00
        Dim tot_report_head_t As Decimal = 0.00
        Dim tot_sub_t As Decimal = 0.00
        Dim tot_head_t As Decimal = 0.00

        Dim tot_report_sub_p As Decimal = 0.00
        Dim tot_report_head_p As Decimal = 0.00
        Dim tot_sub_p As Decimal = 0.00
        Dim tot_head_p As Decimal = 0.00

        Dim total_t As Decimal = 0.00
        Dim total_p As Decimal = 0.00

        For i = 0 To dt.Rows.Count - 1
            'detail
            Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
            row_det.HeightF = 25

            'Desc
            Dim desc_ As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            desc_.Text = dt.Rows(i)("acc_description").ToString
            desc_.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            desc_.BackColor = Color.Transparent
            desc_.Font = font_row_style
            desc_.WidthF = 220
            desc_.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            desc_.Padding = 10

            row_det.Cells.Add(desc_)

            'prev month
            Dim prev_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            prev_month.Text = Decimal.Parse((dt.Rows(i)("prev_month") * dt.Rows(i)("factored")).ToString).ToString("N2")
            prev_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            prev_month.BackColor = Color.Transparent
            prev_month.Font = font_row_style
            prev_month.WidthF = 190
            prev_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            prev_month.Padding = 10
            '
            total_p += dt.Rows(i)("prev_month")
            '
            row_det.Cells.Add(prev_month)

            'this month
            Dim this_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            this_month.Text = Decimal.Parse((dt.Rows(i)("this_month") * dt.Rows(i)("factored")).ToString).ToString("N2")
            this_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            this_month.BackColor = Color.Transparent
            this_month.Font = font_row_style
            this_month.WidthF = 190
            this_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            this_month.Padding = 10
            '
            total_t += dt.Rows(i)("this_month")
            '
            row_det.Cells.Add(this_month)

            'Percentage
            Dim percent As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            percent.Text = Decimal.Parse(dt.Rows(i)("percentage").ToString).ToString("N0") & " % "
            percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            percent.BackColor = Color.Transparent
            percent.Font = font_row_style
            percent.WidthF = 123
            percent.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right
            percent.Padding = 10

            row_det.Cells.Add(percent)
            XrTable2.Rows.Add(row_det)
            '
            If Not i = dt.Rows.Count - 1 Then
                'sub
                If Not dt.Rows(i)("sub_desc").ToString = dt.Rows(i + 1)("sub_desc").ToString Then
                    tot_sub_t += dt.Rows(i)("this_month")
                    tot_sub_p += dt.Rows(i)("prev_month")

                    Dim percentage As Decimal = ((tot_sub_t - tot_sub_p) / tot_sub_p) * 100

                    If dt.Rows(i)("sub_name").ToString = "8" Or dt.Rows(i)("sub_name").ToString = "6" Then
                        'other income + cogs skip
                    Else
                        add_head(dt.Rows(i)("sub_desc").ToString, Decimal.Parse((tot_sub_p * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((tot_sub_t * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                    End If

                    tot_sub_t = 0
                    tot_sub_p = 0
                Else
                    tot_sub_t += dt.Rows(i)("this_month")
                    tot_sub_p += dt.Rows(i)("prev_month")
                End If

                'head
                If Not dt.Rows(i)("head_desc").ToString = dt.Rows(i + 1)("head_desc").ToString Then
                    tot_head_t += dt.Rows(i)("this_month")
                    tot_head_p += dt.Rows(i)("prev_month")

                    Dim percentage As Decimal = ((tot_head_t - tot_head_p) / tot_head_p) * 100

                    If dt.Rows(i)("head_name").ToString = "4" Then
                        'biaya skip
                    Else
                        add_head(dt.Rows(i)("head_desc").ToString, Decimal.Parse((tot_head_p).ToString).ToString("N2"), Decimal.Parse((tot_head_t).ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                    End If

                    tot_head_t = 0
                    tot_head_p = 0
                Else
                    tot_head_t += dt.Rows(i)("this_month")
                    tot_head_p += dt.Rows(i)("prev_month")
                End If

                'report sub
                If Not dt.Rows(i)("report_sub").ToString = dt.Rows(i + 1)("report_sub").ToString Then
                    tot_report_sub_t += dt.Rows(i)("this_month")
                    tot_report_sub_p += dt.Rows(i)("prev_month")

                    Dim percentage As Decimal = ((tot_report_sub_t - tot_report_sub_p) / tot_report_sub_p) * 100

                    If dt.Rows(i)("id_consolidation_report_sub").ToString = "1" Then 'operasional
                        If languange = "ind" Then
                            add_head("Keuntungan Operasional", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                        Else
                            add_head("Operational Profit", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                        End If
                    ElseIf dt.Rows(i)("id_consolidation_report_sub").ToString = "1" Then 'biaya/pendapatan 
                        If languange = "ind" Then
                            add_head("Pendapatan Lain-lain", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                        Else
                            add_head("Other Income", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                        End If
                    End If

                    tot_report_sub_t = 0
                    tot_report_sub_p = 0
                Else
                    tot_report_sub_t += dt.Rows(i)("this_month")
                    tot_report_sub_p += dt.Rows(i)("prev_month")
                End If

                'report head
                If Not dt.Rows(i)("report_head").ToString = dt.Rows(i + 1)("report_head").ToString Then
                    tot_report_head_t += dt.Rows(i)("this_month")
                    tot_report_head_p += dt.Rows(i)("prev_month")

                    Dim percentage As Decimal = ((tot_report_head_t - tot_report_head_p) / tot_report_head_p) * 100

                    If languange = "ind" Then
                        add_head("Keuntungan Bersih Sebelum Pajak", Decimal.Parse(tot_report_head_p.ToString).ToString("N2"), Decimal.Parse(tot_report_head_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                    Else
                        add_head("Net Profit Before Tax", Decimal.Parse(tot_report_head_p.ToString).ToString("N2"), Decimal.Parse(tot_report_head_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                    End If

                    tot_report_head_t = 0
                    tot_report_head_p = 0
                Else
                    tot_report_head_t += dt.Rows(i)("this_month")
                    tot_report_head_p += dt.Rows(i)("prev_month")
                End If
            ElseIf i = dt.Rows.Count - 1 Then
                'end footer net profit after tax
                Dim percentage As Decimal = ((total_t - total_p) / total_p) * 100

                If languange = "ind" Then
                    add_head("Keuntungan Bersih Setelah Pajak", Decimal.Parse(total_p.ToString).ToString("N2"), Decimal.Parse(total_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                Else
                    add_head("Net Profit After Tax", Decimal.Parse(total_p.ToString).ToString("N2"), Decimal.Parse(total_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                End If
            End If
        Next
        '
        pre_load_list_horz("303", 2, 1, XRTableMark)
    End Sub

    Sub add_head(ByVal desc As String, ByVal amount_prev_month As String, ByVal amount_this_month As String, ByVal percentage As String)
        Dim font_row_style As New Font("Segoe UI", 9, FontStyle.Bold)

        Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        row_det.HeightF = 25

        'Desc
        Dim desc_ As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        desc_.Text = desc
        desc_.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc_.BackColor = Color.Transparent
        desc_.Font = font_row_style
        desc_.WidthF = 220
        desc_.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
        desc_.Padding = 10

        row_det.Cells.Add(desc_)

        'Prev Month
        Dim prev_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        prev_month.Text = amount_prev_month
        prev_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        prev_month.BackColor = Color.Transparent
        prev_month.Font = font_row_style
        prev_month.WidthF = 190
        prev_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
        prev_month.Padding = 10

        row_det.Cells.Add(prev_month)

        'This Month
        Dim this_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        this_month.Text = amount_this_month
        this_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        this_month.BackColor = Color.Transparent
        this_month.Font = font_row_style
        this_month.WidthF = 190
        this_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
        this_month.Padding = 10

        row_det.Cells.Add(this_month)

        'Percentage
        Dim percent As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        If percentage = "" Then
            percent.Text = ""
        Else
            percent.Text = percentage & " % "
        End If

        percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percent.BackColor = Color.Transparent
        percent.Font = font_row_style
        percent.WidthF = 123
        percent.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right
        percent.Padding = 10

        row_det.Cells.Add(percent)

        XrTable2.Rows.Add(row_det)
    End Sub
End Class