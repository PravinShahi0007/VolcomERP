Public Class ReportMISVsYear
    Public dt As DataTable
    Public languange As String = "eng"

    Private Sub ReportMISVsYear_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If languange = "ind" Then
            '
            Dim row_aktiva As DevExpress.XtraReports.UI.XRTableRow = XTDetail
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
            'insert_row(row_aktiva, "bold", XTIncome, dt.Rows(i)("acc_description_eng").ToString, "", "", "", "")
            For i = 0 To dt.Rows.Count - 1
                insert_row(row_aktiva, "regular", XTIncome, dt.Rows(i)("acc_description_eng").ToString, Decimal.Parse((dt.Rows(i)("prev_year") * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((dt.Rows(i)("percent_sales_prev_year") * dt.Rows(i)("factored")).ToString).ToString("N0"), Decimal.Parse((dt.Rows(i)("this_month") * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((dt.Rows(i)("percent_sales_this_month") * dt.Rows(i)("factored")).ToString).ToString("N0"))
                total_t += dt.Rows(i)("this_month")
                total_p += dt.Rows(i)("prev_year")

                If Not i = dt.Rows.Count - 1 Then
                    'sub
                    If Not dt.Rows(i)("sub_desc").ToString = dt.Rows(i + 1)("sub_desc").ToString Then
                        tot_sub_t += dt.Rows(i)("this_month")
                        tot_sub_p += dt.Rows(i)("prev_year")

                        Dim percentage As Decimal = ((tot_sub_t - tot_sub_p) / tot_sub_p) * 100 * dt.Rows(i)("factored")

                        If dt.Rows(i)("sub_name").ToString = "8" Or dt.Rows(i)("sub_name").ToString = "6" Then
                            'other income + cogs skip
                        Else
                            insert_row(row_aktiva, "bold", XTIncome, dt.Rows(i)("sub_desc").ToString, Decimal.Parse((tot_sub_p * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((tot_sub_p / dt.Rows(i)("prev_year_sales") * 100 * dt.Rows(i)("factored")).ToString).ToString("N0"), Decimal.Parse((tot_sub_t * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((tot_sub_t / dt.Rows(i)("this_month_sales") * 100 * dt.Rows(i)("factored")).ToString).ToString("N0"))
                        End If

                        tot_sub_t = 0
                        tot_sub_p = 0
                    Else
                        tot_sub_t += dt.Rows(i)("this_month")
                        tot_sub_p += dt.Rows(i)("prev_year")
                    End If

                    'head
                    If Not dt.Rows(i)("head_desc").ToString = dt.Rows(i + 1)("head_desc").ToString Then
                        tot_head_t += dt.Rows(i)("this_month")
                        tot_head_p += dt.Rows(i)("prev_year")

                        Dim percentage As Decimal = ((tot_head_t - tot_head_p) / tot_head_p) * 100

                        If dt.Rows(i)("head_name").ToString = "4" Then
                            'biaya skip
                        Else
                            insert_row(row_aktiva, "bold", XTIncome, dt.Rows(i)("head_desc").ToString, Decimal.Parse((tot_head_p).ToString).ToString("N2"), Decimal.Parse((tot_head_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((tot_head_t).ToString).ToString("N2"), Decimal.Parse((tot_head_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))
                        End If

                        tot_head_t = 0
                        tot_head_p = 0
                    Else
                        tot_head_t += dt.Rows(i)("this_month")
                        tot_head_p += dt.Rows(i)("prev_year")
                    End If

                    'report sub
                    If Not dt.Rows(i)("report_sub").ToString = dt.Rows(i + 1)("report_sub").ToString Then
                        tot_report_sub_t += dt.Rows(i)("this_month")
                        tot_report_sub_p += dt.Rows(i)("prev_year")

                        Dim percentage As Decimal = ((tot_report_sub_t - tot_report_sub_p) / tot_report_sub_p) * 100

                        If dt.Rows(i)("id_consolidation_report_sub").ToString = "1" Then 'operasional
                            'If languange = "ind" Then
                            '    add_head("Keuntungan Operasional", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                            'Else
                            '    add_head("Operational Profit", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                            'End If
                            insert_row(row_aktiva, "bold", XTIncome, "Operational Profit", Decimal.Parse((tot_report_sub_p).ToString).ToString("N2"), Decimal.Parse((tot_report_sub_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((tot_report_sub_t).ToString).ToString("N2"), Decimal.Parse((tot_report_sub_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))

                        ElseIf dt.Rows(i)("id_consolidation_report_sub").ToString = "1" Then 'biaya/pendapatan 
                            'If languange = "ind" Then
                            '    add_head("Pendapatan Lain-lain", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                            'Else
                            '    add_head("Other Income", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                            'End If

                            insert_row(row_aktiva, "bold", XTIncome, "Other Income", Decimal.Parse((tot_report_sub_p).ToString).ToString("N2"), Decimal.Parse((tot_report_sub_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((tot_report_sub_t).ToString).ToString("N2"), Decimal.Parse((tot_report_sub_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))
                        End If

                        tot_report_sub_t = 0
                        tot_report_sub_p = 0
                    Else
                        tot_report_sub_t += dt.Rows(i)("this_month")
                        tot_report_sub_p += dt.Rows(i)("prev_year")
                    End If

                    'report head
                    If Not dt.Rows(i)("report_head").ToString = dt.Rows(i + 1)("report_head").ToString Then
                        tot_report_head_t += dt.Rows(i)("this_month")
                        tot_report_head_p += dt.Rows(i)("prev_year")

                        Dim percentage As Decimal = ((tot_report_head_t - tot_report_head_p) / tot_report_head_p) * 100

                        'If languange = "ind" Then
                        '    add_head("Keuntungan Bersih Sebelum Pajak", Decimal.Parse(tot_report_head_p.ToString).ToString("N2"), Decimal.Parse(tot_report_head_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                        'Else
                        '    add_head("Net Profit Before Tax", Decimal.Parse(tot_report_head_p.ToString).ToString("N2"), Decimal.Parse(tot_report_head_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                        'End If

                        insert_row(row_aktiva, "bold", XTIncome, "Net Profit Before Tax", Decimal.Parse((tot_report_head_p).ToString).ToString("N2"), Decimal.Parse((tot_report_head_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((tot_report_head_t).ToString).ToString("N2"), Decimal.Parse((tot_report_head_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))

                        tot_report_head_t = 0
                        tot_report_head_p = 0
                    Else
                        tot_report_head_t += dt.Rows(i)("this_month")
                        tot_report_head_p += dt.Rows(i)("prev_year")
                    End If
                ElseIf i = dt.Rows.Count - 1 Then
                    'end footer net profit after tax
                    Dim percentage As Decimal = ((total_t - total_p) / total_p) * 100

                    'If languange = "ind" Then
                    '    add_head("Keuntungan Bersih Setelah Pajak", Decimal.Parse(total_p.ToString).ToString("N2"), Decimal.Parse(total_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                    'Else
                    '    add_head("Net Profit After Tax", Decimal.Parse(total_p.ToString).ToString("N2"), Decimal.Parse(total_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                    'End If

                    insert_row(row_aktiva, "bold", XTIncome, "Net Profit After Tax", Decimal.Parse((total_p).ToString).ToString("N2"), Decimal.Parse((total_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((total_t).ToString).ToString("N2"), Decimal.Parse((total_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))
                End If
            Next
        ElseIf languange = "eng" Then
            '
            Dim row_aktiva As DevExpress.XtraReports.UI.XRTableRow = XTDetail
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
            'insert_row(row_aktiva, "bold", XTIncome, dt.Rows(i)("acc_description_eng").ToString, "", "", "", "")
            For i = 0 To dt.Rows.Count - 1
                insert_row(row_aktiva, "regular", XTIncome, dt.Rows(i)("acc_description_eng").ToString, Decimal.Parse((dt.Rows(i)("prev_year") * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((dt.Rows(i)("percent_sales_prev_year") * dt.Rows(i)("factored")).ToString).ToString("N0"), Decimal.Parse((dt.Rows(i)("this_month") * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((dt.Rows(i)("percent_sales_this_month") * dt.Rows(i)("factored")).ToString).ToString("N0"))
                total_t += dt.Rows(i)("this_month")
                total_p += dt.Rows(i)("prev_year")

                If Not i = dt.Rows.Count - 1 Then
                    'sub
                    If Not dt.Rows(i)("sub_desc_eng").ToString = dt.Rows(i + 1)("sub_desc_eng").ToString Then
                        tot_sub_t += dt.Rows(i)("this_month")
                        tot_sub_p += dt.Rows(i)("prev_year")

                        Dim percentage As Decimal = ((tot_sub_t - tot_sub_p) / tot_sub_t) * 100 * dt.Rows(i)("factored")

                        If dt.Rows(i)("sub_name").ToString = "8" Or dt.Rows(i)("sub_name").ToString = "6" Then
                            'other income + cogs skip
                        Else
                            insert_row(row_aktiva, "bold", XTIncome, dt.Rows(i)("sub_desc_eng").ToString, Decimal.Parse((tot_sub_p * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((tot_sub_p / dt.Rows(i)("prev_year_sales") * 100 * dt.Rows(i)("factored")).ToString).ToString("N0"), Decimal.Parse((tot_sub_t * dt.Rows(i)("factored")).ToString).ToString("N2"), Decimal.Parse((tot_sub_t / dt.Rows(i)("this_month_sales") * 100 * dt.Rows(i)("factored")).ToString).ToString("N0"))
                        End If

                        tot_sub_t = 0
                        tot_sub_p = 0
                    Else
                        tot_sub_t += dt.Rows(i)("this_month")
                        tot_sub_p += dt.Rows(i)("prev_year")
                    End If

                    'head
                    If Not dt.Rows(i)("head_desc_eng").ToString = dt.Rows(i + 1)("head_desc_eng").ToString Then
                        tot_head_t += dt.Rows(i)("this_month")
                        tot_head_p += dt.Rows(i)("prev_year")

                        Dim percentage As Decimal = ((tot_head_t - tot_head_p) / tot_head_t) * 100

                        If dt.Rows(i)("head_name").ToString = "4" Then
                            'biaya skip
                        Else
                            insert_row(row_aktiva, "bold", XTIncome, dt.Rows(i)("head_desc_eng").ToString, Decimal.Parse((tot_head_p).ToString).ToString("N2"), Decimal.Parse((tot_head_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((tot_head_t).ToString).ToString("N2"), Decimal.Parse((tot_head_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))
                        End If

                        tot_head_t = 0
                        tot_head_p = 0
                    Else
                        tot_head_t += dt.Rows(i)("this_month")
                        tot_head_p += dt.Rows(i)("prev_year")
                    End If

                    'report sub
                    If Not dt.Rows(i)("report_sub_eng").ToString = dt.Rows(i + 1)("report_sub_eng").ToString Then
                        tot_report_sub_t += dt.Rows(i)("this_month")
                        tot_report_sub_p += dt.Rows(i)("prev_year")

                        Dim percentage As Decimal = ((tot_report_sub_t - tot_report_sub_p) / tot_report_sub_p) * 100

                        If dt.Rows(i)("id_consolidation_report_sub").ToString = "1" Then 'operasional
                            'If languange = "ind" Then
                            '    add_head("Keuntungan Operasional", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                            'Else
                            '    add_head("Operational Profit", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                            'End If
                            insert_row(row_aktiva, "bold", XTIncome, "Operational Profit", Decimal.Parse((tot_report_sub_p).ToString).ToString("N2"), Decimal.Parse((tot_report_sub_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((tot_report_sub_t).ToString).ToString("N2"), Decimal.Parse((tot_report_sub_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))

                        ElseIf dt.Rows(i)("id_consolidation_report_sub").ToString = "1" Then 'biaya/pendapatan 
                            'If languange = "ind" Then
                            '    add_head("Pendapatan Lain-lain", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                            'Else
                            '    add_head("Other Income", Decimal.Parse(tot_report_sub_p.ToString).ToString("N2"), Decimal.Parse(tot_report_sub_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                            'End If

                            insert_row(row_aktiva, "bold", XTIncome, "Other Income", Decimal.Parse((tot_report_sub_p).ToString).ToString("N2"), Decimal.Parse((tot_report_sub_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((tot_report_sub_t).ToString).ToString("N2"), Decimal.Parse((tot_report_sub_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))
                        End If

                        tot_report_sub_t = 0
                        tot_report_sub_p = 0
                    Else
                        tot_report_sub_t += dt.Rows(i)("this_month")
                        tot_report_sub_p += dt.Rows(i)("prev_year")
                    End If

                    'report head
                    If Not dt.Rows(i)("report_head_eng").ToString = dt.Rows(i + 1)("report_head_eng").ToString Then
                        tot_report_head_t += dt.Rows(i)("this_month")
                        tot_report_head_p += dt.Rows(i)("prev_year")

                        Dim percentage As Decimal = ((tot_report_head_t - tot_report_head_p) / tot_report_head_p) * 100

                        'If languange = "ind" Then
                        '    add_head("Keuntungan Bersih Sebelum Pajak", Decimal.Parse(tot_report_head_p.ToString).ToString("N2"), Decimal.Parse(tot_report_head_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                        'Else
                        '    add_head("Net Profit Before Tax", Decimal.Parse(tot_report_head_p.ToString).ToString("N2"), Decimal.Parse(tot_report_head_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                        'End If

                        insert_row(row_aktiva, "bold", XTIncome, "Net Profit Before Tax", Decimal.Parse((tot_report_head_p).ToString).ToString("N2"), Decimal.Parse((tot_report_head_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((tot_report_head_t).ToString).ToString("N2"), Decimal.Parse((tot_report_head_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))

                        tot_report_head_t = 0
                        tot_report_head_p = 0
                    Else
                        tot_report_head_t += dt.Rows(i)("this_month")
                        tot_report_head_p += dt.Rows(i)("prev_year")
                    End If
                ElseIf i = dt.Rows.Count - 1 Then
                    'end footer net profit after tax
                    Dim percentage As Decimal = ((total_t - total_p) / total_p) * 100

                    'If languange = "ind" Then
                    '    add_head("Keuntungan Bersih Setelah Pajak", Decimal.Parse(total_p.ToString).ToString("N2"), Decimal.Parse(total_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                    'Else
                    '    add_head("Net Profit After Tax", Decimal.Parse(total_p.ToString).ToString("N2"), Decimal.Parse(total_t.ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N0"))
                    'End If

                    insert_row(row_aktiva, "bold", XTIncome, "Net Profit After Tax", Decimal.Parse((total_p).ToString).ToString("N2"), Decimal.Parse((total_p / dt.Rows(i)("prev_year_sales") * 100).ToString).ToString("N0"), Decimal.Parse((total_t).ToString).ToString("N2"), Decimal.Parse((total_t / dt.Rows(i)("this_month_sales") * 100).ToString).ToString("N0"))
                End If
            Next
        End If

        pre_load_list_horz("303", 2, 1, XRTableMark)
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal opt As String, ByVal xtable As DevExpress.XtraReports.UI.XRTable, ByVal descvar As String, ByVal amo_py_var As String, ByVal percent_py_var As String, ByVal amo_tm_var As String, ByVal percent_tm_var As String)
        Dim font_row_style As New Font(xtable.Font.FontFamily, xtable.Font.Size, FontStyle.Regular)

        If opt = "bold" Then
            font_row_style = New Font(xtable.Font.FontFamily, xtable.Font.Size, FontStyle.Bold)
        End If

        'row setting
        row = xtable.InsertRowBelow(row)
        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 17
        row.Padding = 3
        row.Font = font_row_style

        'desc
        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = descvar
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        'amount py
        Dim amo_py As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        amo_py.Text = amo_py_var
        amo_py.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amo_py.Font = font_row_style

        'percent py
        Dim percent_py As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        percent_py.Text = percent_py_var & " %"
        percent_py.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percent_py.Font = font_row_style

        'amount tm
        Dim amo_tm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        amo_tm.Text = amo_tm_var
        amo_tm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amo_tm.Font = font_row_style

        'percent tm
        Dim percent_tm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        percent_tm.Text = percent_tm_var & " %"
        percent_tm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percent_tm.Font = font_row_style

        'percentage
        Dim percentage_amo As String = ""

        If amo_py_var = "" Or amo_py_var = "" Then
        ElseIf Decimal.Parse(amo_tm_var.ToString) = 0 Or Decimal.Parse(amo_py_var.ToString) = 0 Then
            percentage_amo = Decimal.Parse("0").ToString("N0") & " %"
        Else
            percentage_amo = ((Decimal.Parse(amo_tm_var.ToString) - Decimal.Parse(amo_py_var.ToString)) / Decimal.Parse(amo_py_var.ToString()) * 100).ToString("N0") & " %"
        End If

        Dim percentage_vs As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        percentage_vs.Text = percentage_amo
        percentage_vs.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percentage_vs.Font = font_row_style
    End Sub
End Class