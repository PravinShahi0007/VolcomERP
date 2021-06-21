Public Class ReportMBSVsYear
    Public dt As DataTable = New DataTable
    Public languange As String = "eng"

    Private Sub ReportMBSVsYear_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If languange = "ind" Then
            Dim current_header As String = ""
            Dim total_sub_tm As Decimal = 0.00
            Dim total_tm As Decimal = 0.00
            Dim total_sub_py As Decimal = 0.00
            Dim total_py As Decimal = 0.00
            '
            Dim row_aktiva As DevExpress.XtraReports.UI.XRTableRow = XTRow
            For i = 0 To dt.Rows.Count - 1
                If Not current_header = dt.Rows(i)("sub_name").ToString Then
                    current_header = dt.Rows(i)("sub_name").ToString
                    total_sub_tm = 0
                    total_sub_py = 0
                    insert_row(row_aktiva, "bold", XTBalanceSheet, dt.Rows(i)("sub_name").ToString, "", "", "", "")
                End If

                If dt.Rows(i)("is_appear_zero").ToString = "2" Then
                    insert_row(row_aktiva, "reguler", XTBalanceSheet, dt.Rows(i)("acc_description").ToString, Decimal.Parse(dt.Rows(i)("prev_year").ToString).ToString("N2"), Decimal.Parse(dt.Rows(i)("percent_asset_py").ToString).ToString("N2") & " %", Decimal.Parse(dt.Rows(i)("this_month").ToString).ToString("N2"), Decimal.Parse(dt.Rows(i)("percent_asset_tm").ToString).ToString("N2") & " %")
                    total_sub_tm += Decimal.Parse(dt.Rows(i)("this_month").ToString)
                    total_tm += Decimal.Parse(dt.Rows(i)("this_month").ToString)
                    total_sub_py += Decimal.Parse(dt.Rows(i)("prev_year").ToString)
                    total_py += Decimal.Parse(dt.Rows(i)("prev_year").ToString)
                End If

                'row total
                If i < dt.Rows.Count - 1 Then
                    'ini cek ada setelahnya
                    Dim space As Boolean = False

                    If Not current_header = dt.Rows(i + 1)("sub_name").ToString Then
                        insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("sub_name").ToString, Decimal.Parse(total_sub_py.ToString).ToString("N2"), Decimal.Parse((total_sub_py / dt.Rows(i)("total_asset_py") * 100).ToString).ToString("N2") & " %", Decimal.Parse(total_sub_tm.ToString).ToString("N2"), Decimal.Parse((total_sub_tm / dt.Rows(i)("total_asset_tm") * 100).ToString).ToString("N2") & " %")
                        space = True
                        '
                        total_sub_py = 0
                        total_sub_tm = 0
                    End If
                    If Not dt.Rows(i)("head_name").ToString = dt.Rows(i + 1)("head_name").ToString Then
                        insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("head_name").ToString, Decimal.Parse(total_py.ToString).ToString("N2"), Decimal.Parse((total_py / dt.Rows(i)("total_asset_py") * 100).ToString).ToString("N2") & " %", Decimal.Parse(total_tm.ToString).ToString("N2"), Decimal.Parse((total_tm / dt.Rows(i)("total_asset_tm") * 100).ToString).ToString("N2") & " %")
                        space = True
                        total_tm = 0
                        total_py = 0
                    End If

                    If space Then
                        insert_row(row_aktiva, "bold", XTBalanceSheet, "", "", "", "", "")
                    End If
                ElseIf i = dt.Rows.Count - 1 Then
                    'ini row terakhir
                    insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("sub_name").ToString, Decimal.Parse(total_sub_py.ToString).ToString("N2"), Decimal.Parse((total_sub_py / dt.Rows(i)("total_asset_py") * 100).ToString).ToString("N2") & " %", Decimal.Parse(total_sub_tm.ToString).ToString("N2"), Decimal.Parse((total_sub_tm / dt.Rows(i)("total_asset_tm") * 100).ToString).ToString("N2") & " %")
                    insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("head_name").ToString, Decimal.Parse(total_py.ToString).ToString("N2"), Decimal.Parse((total_py / dt.Rows(i)("total_asset_py") * 100).ToString).ToString("N2") & " %", Decimal.Parse(total_tm.ToString).ToString("N2"), Decimal.Parse((total_tm / dt.Rows(i)("total_asset_tm") * 100).ToString).ToString("N2") & " %")
                End If
            Next
            'XRTotalAsset.Text = Decimal.Parse(total.ToString).ToString("N2")
            'XRTotalAssetPercent.Text = Decimal.Parse((total / dt.Rows(0)("total_asset") * 100).ToString).ToString("N2") & " %"
        Else
            Dim current_header As String = ""
            Dim total_sub_tm As Decimal = 0.00
            Dim total_tm As Decimal = 0.00
            Dim total_sub_py As Decimal = 0.00
            Dim total_py As Decimal = 0.00

            Dim row_aktiva As DevExpress.XtraReports.UI.XRTableRow = XTRow
            For i = 0 To dt.Rows.Count - 1
                If Not current_header = dt.Rows(i)("sub_name_eng").ToString Then
                    current_header = dt.Rows(i)("sub_name_eng").ToString
                    total_sub_tm = 0.00
                    total_sub_py = 0.00
                    insert_row(row_aktiva, "bold", XTBalanceSheet, dt.Rows(i)("sub_name_eng").ToString, "", "", "", "")
                End If

                If dt.Rows(i)("is_appear_zero").ToString = "2" Then
                    insert_row(row_aktiva, "reguler", XTBalanceSheet, dt.Rows(i)("acc_description_eng").ToString, Decimal.Parse(dt.Rows(i)("prev_year").ToString).ToString("N2"), Decimal.Parse(dt.Rows(i)("percent_asset_py").ToString).ToString("N2") & " %", Decimal.Parse(dt.Rows(i)("this_month").ToString).ToString("N2"), Decimal.Parse(dt.Rows(i)("percent_asset_tm").ToString).ToString("N2") & " %")
                    total_sub_tm += Decimal.Parse(dt.Rows(i)("this_month").ToString)
                    total_tm += Decimal.Parse(dt.Rows(i)("this_month").ToString)
                    total_sub_py += Decimal.Parse(dt.Rows(i)("prev_year").ToString)
                    total_py += Decimal.Parse(dt.Rows(i)("prev_year").ToString)
                End If

                'row total
                If i < dt.Rows.Count - 1 Then
                    'ini cek ada setelahnya
                    Dim space As Boolean = False

                    If Not current_header = dt.Rows(i + 1)("sub_name_eng").ToString Then
                        'insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("sub_name_eng").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                        insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("sub_name_eng").ToString, Decimal.Parse(total_sub_py.ToString).ToString("N2"), Decimal.Parse((total_sub_py / dt.Rows(i)("total_asset_py") * 100).ToString).ToString("N2") & " %", Decimal.Parse(total_sub_tm.ToString).ToString("N2"), Decimal.Parse((total_sub_tm / dt.Rows(i)("total_asset_tm") * 100).ToString).ToString("N2") & " %")
                        space = True
                        '
                    End If
                    If Not dt.Rows(i)("head_name_eng").ToString = dt.Rows(i + 1)("head_name_eng").ToString Then
                        insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("head_name_eng").ToString, Decimal.Parse(total_py.ToString).ToString("N2"), Decimal.Parse((total_py / dt.Rows(i)("total_asset_py") * 100).ToString).ToString("N2") & " %", Decimal.Parse(total_tm.ToString).ToString("N2"), Decimal.Parse((total_tm / dt.Rows(i)("total_asset_tm") * 100).ToString).ToString("N2") & " %")
                        space = True
                        total_tm = 0
                        total_py = 0
                    End If
                    If space Then
                        insert_row(row_aktiva, "bold", XTBalanceSheet, "", "", "", "", "")
                    End If
                ElseIf i = dt.Rows.Count - 1 Then
                    'ini row terakhir
                    'insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("sub_name_eng").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                    insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("sub_name_eng").ToString, Decimal.Parse(total_sub_py.ToString).ToString("N2"), Decimal.Parse((total_sub_py / dt.Rows(i)("total_asset_py") * 100).ToString).ToString("N2") & " %", Decimal.Parse(total_sub_tm.ToString).ToString("N2"), Decimal.Parse((total_sub_tm / dt.Rows(i)("total_asset_tm") * 100).ToString).ToString("N2") & " %")
                    insert_row(row_aktiva, "bold", XTBalanceSheet, "TOTAL " & dt.Rows(i)("head_name_eng").ToString, Decimal.Parse(total_py.ToString).ToString("N2"), Decimal.Parse((total_py / dt.Rows(i)("total_asset_py") * 100).ToString).ToString("N2") & " %", Decimal.Parse(total_tm.ToString).ToString("N2"), Decimal.Parse((total_tm / dt.Rows(i)("total_asset_tm") * 100).ToString).ToString("N2") & " %")
                    '
                End If
            Next
            'XRTotalAsset.Text = Decimal.Parse(total.ToString).ToString("N2")
            'XRTotalAssetPercent.Text = Decimal.Parse((total / dt.Rows(0)("total_asset") * 100).ToString).ToString("N2") & " %"
        End If

        pre_load_list_horz("303", 2, 1, XRTableMark)
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal opt As String, ByVal xtable As DevExpress.XtraReports.UI.XRTable, ByVal descvar As String, ByVal amo_py_var As String, ByVal percent_py_var As String, ByVal amo_tm_var As String, ByVal percent_tm_var As String)
        Dim font_row_style As New Font(xtable.Font.FontFamily, xtable.Font.Size - 1, FontStyle.Regular)

        If opt = "bold" Then
            font_row_style = New Font(xtable.Font.FontFamily, xtable.Font.Size - 1, FontStyle.Bold)
        End If

        'row setting
        row = xtable.InsertRowBelow(row)
        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = row.HeightF
        row.Font = font_row_style

        'desc
        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = descvar
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        'amount
        Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        amo.Text = amo_py_var
        amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amo.Font = font_row_style

        'percent
        Dim percent As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        percent.Text = percent_py_var
        percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percent.Font = font_row_style

        'amount
        Dim amo_tm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        amo_tm.Text = amo_tm_var
        amo_tm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amo_tm.Font = font_row_style

        'percent
        Dim percent_tm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        percent_tm.Text = percent_tm_var
        percent_tm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percent_tm.Font = font_row_style
    End Sub
End Class