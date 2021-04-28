Public Class ReportMBalanceSheet
    Public dt_aktiva As DataTable = New DataTable
    Public dt_pasiva As DataTable = New DataTable
    Public languange As String = "eng"
    Private Sub ReportMBalanceSheet_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If languange = "ind" Then
            'aktiva
            Dim current_header As String = ""
            Dim total_sub As Decimal = 0.00
            Dim total As Decimal = 0.00
            Dim row_aktiva As DevExpress.XtraReports.UI.XRTableRow = XtRowAsset
            For i = 0 To dt_aktiva.Rows.Count - 1
                If Not current_header = dt_aktiva.Rows(i)("sub_name").ToString Then
                    current_header = dt_aktiva.Rows(i)("sub_name").ToString
                    total_sub = 0
                    insert_row(row_aktiva, "leftbold", XTAktiva, dt_aktiva.Rows(i)("sub_name").ToString, "", "")
                End If

                If dt_aktiva.Rows(i)("is_appear_zero").ToString = "2" Then
                    insert_row(row_aktiva, "left", XTAktiva, dt_aktiva.Rows(i)("acc_description").ToString, Decimal.Parse(dt_aktiva.Rows(i)("this_month").ToString).ToString("N2"), Decimal.Parse(dt_aktiva.Rows(i)("percentage").ToString).ToString("N2") & " %")
                    total_sub += Decimal.Parse(dt_aktiva.Rows(i)("this_month").ToString)
                    total += Decimal.Parse(dt_aktiva.Rows(i)("this_month").ToString)
                End If

                'row total
                If i < dt_aktiva.Rows.Count - 1 Then
                    'ini cek ada setelahnya
                    If Not current_header = dt_aktiva.Rows(i + 1)("sub_name").ToString Then
                        insert_row(row_aktiva, "leftbold", XTAktiva, "TOTAL " & dt_aktiva.Rows(i)("sub_name").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt_aktiva.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                        insert_row(row_aktiva, "leftbold", XTAktiva, "", "", "")
                    End If
                ElseIf i = dt_aktiva.Rows.Count - 1 Then
                    'ini row terakhir
                    insert_row(row_aktiva, "leftbold", XTAktiva, "TOTAL " & dt_aktiva.Rows(i)("sub_name").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt_aktiva.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                End If
            Next
            XRTotalAsset.Text = Decimal.Parse(total.ToString).ToString("N2")
            XRTotalAssetPercent.Text = Decimal.Parse((total / dt_aktiva.Rows(0)("total_asset") * 100).ToString).ToString("N2") & " %"
            'pasiva
            current_header = ""
            total_sub = 0.00
            total = 0.00
            Dim row_pasiva As DevExpress.XtraReports.UI.XRTableRow = XTRowPasiva
            For i = 0 To dt_pasiva.Rows.Count - 1
                If Not current_header = dt_pasiva.Rows(i)("sub_name").ToString Then
                    current_header = dt_pasiva.Rows(i)("sub_name").ToString
                    total_sub = 0.00
                    insert_row(row_pasiva, "rightbold", XTPasiva, dt_pasiva.Rows(i)("sub_name").ToString, "", "")
                End If

                If dt_pasiva.Rows(i)("is_appear_zero").ToString = "2" Then
                    insert_row(row_pasiva, "right", XTPasiva, dt_pasiva.Rows(i)("acc_description").ToString, Decimal.Parse(dt_pasiva.Rows(i)("this_month").ToString).ToString("N2"), Decimal.Parse(dt_pasiva.Rows(i)("percentage").ToString).ToString("N2") & " %")
                    total_sub += Decimal.Parse(dt_pasiva.Rows(i)("this_month").ToString)
                    total += Decimal.Parse(dt_pasiva.Rows(i)("this_month").ToString)
                End If

                'row total
                If i < dt_pasiva.Rows.Count - 1 Then
                    'ini cek ada setelahnya
                    If Not current_header = dt_pasiva.Rows(i + 1)("sub_name").ToString Then
                        If Not dt_pasiva.Rows(i)("id_consolidation_sub_header").ToString = "4" Then
                            insert_row(row_pasiva, "rightbold", XTPasiva, "TOTAL " & dt_pasiva.Rows(i)("sub_name").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt_pasiva.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                        End If
                        insert_row(row_pasiva, "rightbold", XTPasiva, "", "", "")
                    End If
                ElseIf i = dt_pasiva.Rows.Count - 1 Then
                    'ini row terakhir
                    insert_row(row_pasiva, "rightbold", XTPasiva, "TOTAL " & dt_pasiva.Rows(i)("sub_name").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt_pasiva.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                End If
            Next
            XRTotalPasiva.Text = Decimal.Parse(total.ToString).ToString("N2")
            XRTotalPasivaPercent.Text = Decimal.Parse((total / dt_pasiva.Rows(0)("total_asset") * 100).ToString).ToString("N2") & " %"
        Else
            'aktiva
            Dim current_header As String = ""
            Dim total_sub As Decimal = 0.00
            Dim total As Decimal = 0.00
            Dim row_aktiva As DevExpress.XtraReports.UI.XRTableRow = XtRowAsset
            For i = 0 To dt_aktiva.Rows.Count - 1
                If Not current_header = dt_aktiva.Rows(i)("sub_name_eng").ToString Then
                    current_header = dt_aktiva.Rows(i)("sub_name_eng").ToString
                    total_sub = 0.00
                    insert_row(row_aktiva, "leftbold", XTAktiva, dt_aktiva.Rows(i)("sub_name_eng").ToString, "", "")
                End If

                If dt_aktiva.Rows(i)("is_appear_zero").ToString = "2" Then
                    insert_row(row_aktiva, "left", XTAktiva, dt_aktiva.Rows(i)("acc_description_eng").ToString, Decimal.Parse(dt_aktiva.Rows(i)("this_month").ToString).ToString("N2"), Decimal.Parse(dt_aktiva.Rows(i)("percentage").ToString).ToString("N2") & " %")
                    total_sub += Decimal.Parse(dt_aktiva.Rows(i)("this_month").ToString)
                    total += Decimal.Parse(dt_aktiva.Rows(i)("this_month").ToString)
                End If

                'row total
                If i < dt_aktiva.Rows.Count - 1 Then
                    'ini cek ada setelahnya
                    If Not current_header = dt_aktiva.Rows(i + 1)("sub_name_eng").ToString Then
                        insert_row(row_aktiva, "leftbold", XTAktiva, "TOTAL " & dt_aktiva.Rows(i)("sub_name_eng").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt_aktiva.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                        insert_row(row_aktiva, "leftbold", XTAktiva, "", "", "")
                    End If
                ElseIf i = dt_aktiva.Rows.Count - 1 Then
                    'ini row terakhir
                    insert_row(row_aktiva, "leftbold", XTAktiva, "TOTAL " & dt_aktiva.Rows(i)("sub_name_eng").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt_aktiva.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                End If
            Next
            XRTotalAsset.Text = Decimal.Parse(total.ToString).ToString("N2")
            XRTotalAssetPercent.Text = Decimal.Parse((total / dt_aktiva.Rows(0)("total_asset") * 100).ToString).ToString("N2") & " %"
            'pasiva
            current_header = ""
            total_sub = 0.00
            total = 0.00
            Dim row_pasiva As DevExpress.XtraReports.UI.XRTableRow = XTRowPasiva
            For i = 0 To dt_pasiva.Rows.Count - 1
                If Not current_header = dt_pasiva.Rows(i)("sub_name_eng").ToString Then
                    current_header = dt_pasiva.Rows(i)("sub_name_eng").ToString
                    total_sub = 0.00
                    insert_row(row_pasiva, "rightbold", XTPasiva, dt_pasiva.Rows(i)("sub_name_eng").ToString, "", "")
                End If

                If dt_pasiva.Rows(i)("is_appear_zero").ToString = "2" Then
                    insert_row(row_pasiva, "right", XTPasiva, dt_pasiva.Rows(i)("acc_description_eng").ToString, Decimal.Parse(dt_pasiva.Rows(i)("this_month").ToString).ToString("N2"), Decimal.Parse(dt_pasiva.Rows(i)("percentage").ToString).ToString("N2") & " %")
                    total_sub += Decimal.Parse(dt_pasiva.Rows(i)("this_month"))
                    total += Decimal.Parse(dt_pasiva.Rows(i)("this_month").ToString)
                End If

                'row total
                If i < dt_pasiva.Rows.Count - 1 Then
                    'ini cek ada setelahnya
                    If Not current_header = dt_pasiva.Rows(i + 1)("sub_name_eng").ToString Then
                        If Not dt_pasiva.Rows(i)("id_consolidation_sub_header").ToString = "4" Then
                            insert_row(row_pasiva, "rightbold", XTPasiva, "TOTAL " & dt_pasiva.Rows(i)("sub_name_eng").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt_pasiva.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                        End If
                        insert_row(row_pasiva, "rightbold", XTPasiva, "", "", "")
                    End If
                ElseIf i = dt_pasiva.Rows.Count - 1 Then
                    'ini row terakhir
                    insert_row(row_pasiva, "rightbold", XTPasiva, "TOTAL " & dt_pasiva.Rows(i)("sub_name_eng").ToString, Decimal.Parse(total_sub.ToString).ToString("N2"), Decimal.Parse((total_sub / dt_pasiva.Rows(i)("total_asset") * 100).ToString).ToString("N2") & " %")
                End If
            Next
            XRTotalPasiva.Text = Decimal.Parse(total.ToString).ToString("N2")
            XRTotalPasivaPercent.Text = Decimal.Parse((total / dt_pasiva.Rows(0)("total_asset") * 100).ToString).ToString("N2") & " %"

            pre_load_list_horz("303", 2, 1, XRTableMark)
        End If
    End Sub
    '
    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal opt As String, ByVal xtable As DevExpress.XtraReports.UI.XRTable, ByVal descvar As String, ByVal amovar As String, ByVal percentvar As String)
        Dim font_row_style As New Font(xtable.Font.FontFamily, xtable.Font.Size - 1, FontStyle.Regular)

        If opt = "leftbold" Or opt = "rightbold" Then
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

        If opt = "right" Or opt = "rightbold" Then
            desc.Borders = DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top
        End If

        'amount
        Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        amo.Text = amovar
        amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amo.Font = font_row_style

        'percent
        Dim percent As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        percent.Text = percentvar
        percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percent.Font = font_row_style

        If opt = "left" Or opt = "leftbold" Then
            'space
            Dim space As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            space.Text = ""
        End If
    End Sub
End Class