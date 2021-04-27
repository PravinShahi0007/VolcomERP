Public Class ReportSalesAchievement
    Public dt As DataTable = New DataTable
    Public languange As String = "eng"
    Private Sub ReportSalesAchievement_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        For i = 0 To dt.Rows.Count - 1
            insert_row(XRowMinNetSales, If(dt.Rows(i)("month_desc").ToString.Contains("GRAND TOTAL") Or dt.Rows(i)("month_desc").ToString.Contains("YTD"), "bold", ""), XTMinNetSales, dt.Rows(i)("month_desc").ToString, Decimal.Parse(dt.Rows(i)("bruto_target").ToString).ToString("N2"), Decimal.Parse(dt.Rows(i)("nett_target").ToString).ToString("N2"))
        Next
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal opt As String, ByVal xtable As DevExpress.XtraReports.UI.XRTable, ByVal monthvar As String, ByVal bruto As String, ByVal nett As String)
        Dim font_row_style As New Font(xtable.Font.FontFamily, xtable.Font.Size, FontStyle.Regular)

        If opt = "bold" Then
            font_row_style = New Font(xtable.Font.FontFamily, xtable.Font.Size, FontStyle.Bold)
        End If

        'row setting
        row = xtable.InsertRowBelow(row)
        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = row.HeightF
        row.Font = font_row_style

        'month
        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = monthvar
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        'bruto
        Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        amo.Text = bruto
        amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amo.Font = font_row_style

        'nett
        Dim percent As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        percent.Text = nett
        percent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        percent.Font = font_row_style
    End Sub
End Class