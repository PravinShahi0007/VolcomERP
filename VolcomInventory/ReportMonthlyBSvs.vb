Public Class ReportMonthlyBSvs
    Public dt As DataTable
    Public languange As String = "eng"

    Private Sub ReportMonthlyBSvs_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim font_row_style As New Font("Segoe UI", 9, FontStyle.Regular)

        Dim tot_sub_t As Decimal = 0.00
        Dim tot_head_t As Decimal = 0.00
        Dim tot_sub_p As Decimal = 0.00
        Dim tot_head_p As Decimal = 0.00

        Dim total_t As Decimal = 0.00
        Dim total_p As Decimal = 0.00

        For i = 0 To dt.Rows.Count - 1
            If i = 0 Then
                add_head(dt.Rows(i)("head_desc").ToString, "", "", "")
                add_head(dt.Rows(i)("sub_desc").ToString, "", "", "")
            Else
                If Not dt.Rows(i)("head_desc").ToString = dt.Rows(i - 1)("head_desc").ToString Then
                    add_head(dt.Rows(i)("head_desc").ToString, "", "", "")
                End If
                If Not dt.Rows(i)("sub_desc").ToString = dt.Rows(i - 1)("sub_desc").ToString Then
                    add_head(dt.Rows(i)("sub_desc").ToString, "", "", "")
                End If
            End If

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
            desc_.Padding = 5

            row_det.Cells.Add(desc_)

            'prev month
            Dim prev_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            prev_month.Text = Decimal.Parse(Math.Abs(dt.Rows(i)("prev_month")).ToString).ToString("N2")
            prev_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            prev_month.BackColor = Color.Transparent
            prev_month.Font = font_row_style
            prev_month.WidthF = 190
            prev_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            prev_month.Padding = 5
            '
            total_p += dt.Rows(i)("prev_month")
            '
            row_det.Cells.Add(prev_month)

            'this month
            Dim this_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            this_month.Text = Decimal.Parse(Math.Abs(dt.Rows(i)("this_month")).ToString).ToString("N2")
            this_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            this_month.BackColor = Color.Transparent
            this_month.Font = font_row_style
            this_month.WidthF = 190
            this_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            this_month.Padding = 5
            '
            total_t += dt.Rows(i)("this_month")
            '
            row_det.Cells.Add(this_month)

            'Percentage
            Dim percent As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            percent.Text = Decimal.Parse(dt.Rows(i)("percentage").ToString).ToString("N2") & " % "
            percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            percent.BackColor = Color.Transparent
            percent.Font = font_row_style
            percent.WidthF = 123
            percent.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right
            percent.Padding = 5

            row_det.Cells.Add(percent)
            XrTable2.Rows.Add(row_det)
            '
            If Not i = dt.Rows.Count - 1 Then
                'sub
                If Not dt.Rows(i)("sub_desc").ToString = dt.Rows(i + 1)("sub_desc").ToString Then
                    tot_sub_t += dt.Rows(i)("this_month")
                    tot_sub_p += dt.Rows(i)("prev_month")

                    Dim percentage As Decimal = 0.00
                    Try
                        percentage = ((tot_sub_t - tot_sub_p) / tot_sub_p) * 100
                    Catch ex As Exception

                    End Try

                    add_head("Total " & dt.Rows(i)("sub_desc").ToString, Decimal.Parse(Math.Abs(tot_sub_p).ToString).ToString("N2"), Decimal.Parse(Math.Abs(tot_sub_t).ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N2"))

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

                    Dim percentage As Decimal = 0.00
                    Try
                        percentage = ((tot_head_t - tot_head_p) / tot_head_p) * 100
                    Catch ex As Exception

                    End Try

                    add_head("Total " & dt.Rows(i)("head_desc").ToString, Decimal.Parse(Math.Abs(tot_head_p).ToString).ToString("N2"), Decimal.Parse(Math.Abs(tot_head_t).ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N2"))

                    tot_head_t = 0
                    tot_head_p = 0
                Else
                    tot_head_t += dt.Rows(i)("this_month")
                    tot_head_p += dt.Rows(i)("prev_month")
                End If
            ElseIf i = dt.Rows.Count - 1 Then
                'end footer net profit after tax
                'sub
                tot_sub_t += dt.Rows(i)("this_month")
                tot_sub_p += dt.Rows(i)("prev_month")

                Dim percentage As Decimal = 0.00
                Try
                    percentage = ((tot_sub_t - tot_sub_p) / tot_sub_p) * 100
                Catch ex As Exception

                End Try

                add_head("Total " & dt.Rows(i)("sub_desc").ToString, Decimal.Parse(Math.Abs(tot_sub_p).ToString).ToString("N2"), Decimal.Parse(Math.Abs(tot_sub_t).ToString).ToString("N2"), Decimal.Parse(percentage.ToString).ToString("N2"))
                'header
                tot_head_t += dt.Rows(i)("this_month")
                tot_head_p += dt.Rows(i)("prev_month")

                Dim percentage_head As Decimal = 0.00
                Try
                    percentage_head = ((tot_head_t - tot_head_p) / tot_head_p) * 100
                Catch ex As Exception

                End Try

                add_head("Total " & dt.Rows(i)("head_desc").ToString, Decimal.Parse(Math.Abs(tot_head_p).ToString).ToString("N2"), Decimal.Parse(Math.Abs(tot_head_t).ToString).ToString("N2"), Decimal.Parse(percentage_head.ToString).ToString("N2"))
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
        desc_.Padding = 5

        row_det.Cells.Add(desc_)

        'Prev Month
        Dim prev_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        prev_month.Text = amount_prev_month
        prev_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        prev_month.BackColor = Color.Transparent
        prev_month.Font = font_row_style
        prev_month.WidthF = 190
        prev_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
        prev_month.Padding = 5

        row_det.Cells.Add(prev_month)

        'This Month
        Dim this_month As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        this_month.Text = amount_this_month
        this_month.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        this_month.BackColor = Color.Transparent
        this_month.Font = font_row_style
        this_month.WidthF = 190
        this_month.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
        this_month.Padding = 5

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
        percent.Padding = 5

        row_det.Cells.Add(percent)

        XrTable2.Rows.Add(row_det)
    End Sub
End Class