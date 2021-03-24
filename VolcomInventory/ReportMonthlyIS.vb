Public Class ReportMonthlyIS
    Public dt As DataTable
    Public languange As String = "eng"
    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        Dim font_row_style As New Font("Segoe UI", 9, FontStyle.Regular)

        Dim tot_report_sub As Decimal = 0.00
        Dim tot_report_head As Decimal = 0.00
        Dim tot_sub As Decimal = 0.00
        Dim tot_head As Decimal = 0.00

        Dim total As Decimal = 0.00

        For i = 0 To dt.Rows.Count - 1
            'detail
            Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
            row_det.HeightF = 25

            'Desc
            Dim no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            no.Text = dt.Rows(i)("acc_description").ToString
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style
            no.WidthF = 240
            no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            no.Padding = 10

            row_det.Cells.Add(no)

            'Amount
            Dim amount As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            amount.Text = Decimal.Parse(Math.Abs(dt.Rows(i)("this_month")).ToString).ToString("N2")
            amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amount.BackColor = Color.Transparent
            amount.Font = font_row_style
            amount.WidthF = 240
            amount.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            amount.Padding = 10
            '
            total += dt.Rows(i)("this_month")
            '
            row_det.Cells.Add(amount)

            'Percentage
            Dim percent As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            percent.Text = Decimal.Parse(Math.Abs(dt.Rows(i)("percent_this_month")).ToString).ToString("N0") & " % "
            percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            percent.BackColor = Color.Transparent
            percent.Font = font_row_style
            percent.WidthF = 243
            percent.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right
            percent.Padding = 10

            row_det.Cells.Add(percent)

            XrTable2.Rows.Add(row_det)
            '
            If Not i = dt.Rows.Count - 1 Then
                'sub
                If Not dt.Rows(i)("sub_desc").ToString = dt.Rows(i + 1)("sub_desc").ToString Then
                    tot_sub += dt.Rows(i)("this_month")

                    Dim percentage As Decimal = (tot_sub / dt.Rows(i)("this_month_sale")) * 100

                    If dt.Rows(i)("sub_name").ToString = "8" Or dt.Rows(i)("sub_name").ToString = "6" Then
                        'other income + cogs skip
                    Else
                        add_head(dt.Rows(i)("sub_desc").ToString, Decimal.Parse(Math.Abs(tot_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                    End If

                    tot_sub = 0
                Else
                    tot_sub += dt.Rows(i)("this_month")
                End If
                'head
                If Not dt.Rows(i)("head_desc").ToString = dt.Rows(i + 1)("head_desc").ToString Then
                    tot_head += dt.Rows(i)("this_month")

                    Dim percentage As Decimal = (tot_head / dt.Rows(i)("this_month_sale")) * 100

                    If dt.Rows(i)("head_name").ToString = "4" Then
                        'biaya skip
                    Else
                        add_head(dt.Rows(i)("head_desc").ToString, Decimal.Parse(Math.Abs(tot_head).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                    End If

                    tot_head = 0
                Else
                    tot_head += dt.Rows(i)("this_month")
                End If
                'report sub
                If Not dt.Rows(i)("report_sub").ToString = dt.Rows(i + 1)("report_sub").ToString Then
                    tot_report_sub += dt.Rows(i)("this_month")

                    Dim percentage As Decimal = (tot_report_sub / dt.Rows(i)("this_month_sale")) * 100

                    If dt.Rows(i)("id_consolidation_report_sub").ToString = "1" Then 'operasional
                        If languange = "ind" Then
                            If tot_report_sub > 0 Then
                                add_head("Keuntungan Operasional", Decimal.Parse(Math.Abs(tot_report_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                            Else
                                add_head("Kerugian Operasional", Decimal.Parse(Math.Abs(tot_report_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                            End If
                        Else
                            If tot_report_sub > 0 Then
                                add_head("Operational Profit", Decimal.Parse(Math.Abs(tot_report_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                            Else
                                add_head("Operational Loss", Decimal.Parse(Math.Abs(tot_report_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                            End If
                        End If
                    ElseIf dt.Rows(i)("id_consolidation_report_sub").ToString = "1" Then 'biaya/pendapatan 
                        If languange = "ind" Then
                            If tot_report_sub > 0 Then
                                add_head("Pendapatan Lain-lain", Decimal.Parse(Math.Abs(tot_report_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                            Else
                                add_head("Biaya Lain-lain", Decimal.Parse(Math.Abs(tot_report_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                            End If
                        Else
                            If tot_report_sub > 0 Then
                                add_head("Other Income", Decimal.Parse(Math.Abs(tot_report_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                            Else
                                add_head("Other Expense", Decimal.Parse(Math.Abs(tot_report_sub).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                            End If
                        End If
                    End If

                    tot_report_sub = 0
                Else
                    tot_report_sub += dt.Rows(i)("this_month")
                End If
                'report head
                If Not dt.Rows(i)("report_head").ToString = dt.Rows(i + 1)("report_head").ToString Then
                    tot_report_head += dt.Rows(i)("this_month")

                    Dim percentage As Decimal = (tot_report_head / dt.Rows(i)("this_month_sale")) * 100
                    If languange = "ind" Then
                        If tot_report_head > 0 Then
                            add_head("Keuntungan Bersih Sebelum Pajak", Decimal.Parse(Math.Abs(tot_report_head).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                        Else
                            add_head("Kerugian Bersih Sebelum Pajak", Decimal.Parse(Math.Abs(tot_report_head).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                        End If
                    Else
                        If tot_report_head > 0 Then
                            add_head("Net Profit Before Tax", Decimal.Parse(Math.Abs(tot_report_head).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                        Else
                            add_head("Net Loss Before Tax", Decimal.Parse(Math.Abs(tot_report_head).ToString).ToString("N2"), Decimal.Parse(Math.Abs(percentage).ToString).ToString("N0"))
                        End If
                    End If

                    tot_report_head = 0
                Else
                    tot_report_head += dt.Rows(i)("this_month")
                End If
            ElseIf i = dt.Rows.Count - 1 Then
                'end footer net profit after tax
                If languange = "ind" Then
                    If total > 0 Then
                        add_head("Keuntungan Bersih Setelah Pajak", Decimal.Parse(Math.Abs(total).ToString).ToString("N2"), "100")
                    Else
                        add_head("Kerugian Bersih Setelah Pajak", Decimal.Parse(Math.Abs(total).ToString).ToString("N2"), "100")
                    End If
                Else
                    If total > 0 Then
                        add_head("Net Profit After Tax", Decimal.Parse(Math.Abs(total).ToString).ToString("N2"), "100")
                    Else
                        add_head("Net Loss After Tax", Decimal.Parse(Math.Abs(total).ToString).ToString("N2"), "100")
                    End If
                End If
            End If
        Next
        '
        pre_load_list_horz("303", 2, 1, XrTable1)
    End Sub

    Sub add_head(ByVal desc As String, ByVal amountx As String, ByVal percentage As String)
        Dim font_row_style As New Font("Segoe UI", 9, FontStyle.Bold)

        Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        row_det.HeightF = 25

        'Desc
        Dim no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        no.Text = desc
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        no.BackColor = Color.Transparent
        no.Font = font_row_style
        no.WidthF = 240
        no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
        no.Padding = 10

        row_det.Cells.Add(no)

        'Amount
        Dim amount As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        amount.Text = amountx
        amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amount.BackColor = Color.Transparent
        amount.Font = font_row_style
        amount.WidthF = 240
        amount.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
        amount.Padding = 10

        row_det.Cells.Add(amount)

        'Percentage
        Dim percent As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        percent.Text = percentage & " % "
        percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percent.BackColor = Color.Transparent
        percent.Font = font_row_style
        percent.WidthF = 243
        percent.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right
        percent.Padding = 10

        row_det.Cells.Add(percent)

        XrTable2.Rows.Add(row_det)
    End Sub
End Class