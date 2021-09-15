Public Class ReportSNIBudget
    Public Shared id_pps As String = "-1"
    Public Shared tot_qty As Decimal = 1

    Private Sub ReportSNIBudget_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim q As String = "SELECT sni.number,ssn.season 
FROM `tb_sni_pps` sni
INNER JOIN `tb_season` ssn ON ssn.id_season=sni.`id_season`
WHERE sni.`id_sni_pps`='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        DataSource = dt
        '
        Dim qdet As String = "SELECT ppsb.*,budget_qty*budget_value AS  sub_amount
FROM 
`tb_sni_pps_budget` ppsb
LEFT JOIN tb_m_design dsg ON dsg.`id_design`=ppsb.`id_design`
WHERE ppsb.`id_sni_pps`='" & id_pps & "'"
        Dim dtdet As DataTable = execute_query(qdet, -1, True, "", "", "", "")

        Dim row_baru As DevExpress.XtraReports.UI.XRTableRow = XRDetail
        Dim tot_nilai As Decimal = 0.00
        For i = 0 To dtdet.Rows.Count - 1
            insert_row(row_baru, dtdet, i)
            'add summary
            tot_nilai += dtdet.Rows(i)("sub_amount")
            If i = dtdet.Rows.Count - 1 Then
                insert_footer(row_baru, tot_nilai, "Total Budget")
                insert_footer(row_baru, tot_qty, "Total Qty Artikel KIDS")
                insert_footer(row_baru, Math.Round(tot_nilai / tot_qty, 2), "Cost per Pcs")
                insert_footer(row_baru, Math.Round(tot_nilai * 0.1, 2), "VAT 10%")
                insert_footer(row_baru, Math.Round(tot_nilai * 1.1, 2), "Grand Total Budget")
            End If
        Next
        '
        pre_load_mark_horz("319", id_pps, "2", "2", XrTable2)
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size, FontStyle.Regular)

        If Not row_i = 0 Then
            row = XTDetail.InsertRowBelow(row)
        End If

        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style

        'No
        Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        no.Text = row_i + 1
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        no.Font = font_row_style

        'desc
        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        desc.Text = dt.Rows(row_i)("budget_desc").ToString
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        'value
        Dim harga As String = Decimal.Parse(dt.Rows(row_i)("budget_value").ToString).ToString("N2")

        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        total_nilai.Text = harga
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style

        'qty
        Dim qty As String = Decimal.Parse(dt.Rows(row_i)("budget_qty").ToString).ToString("N2")

        Dim col_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        col_qty.Text = qty
        col_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qty.Font = font_row_style

        'sub_amount
        Dim sub_amount As String = Decimal.Parse(dt.Rows(row_i)("sub_amount").ToString).ToString("N2")

        Dim sub_amount_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        sub_amount_col.Text = sub_amount
        sub_amount_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_col.Font = font_row_style
    End Sub

    Sub insert_footer(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal total As Decimal, ByVal keterangan As String)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size + 1, FontStyle.Bold)

        row = XTDetail.InsertRowBelow(row)

        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 25
        row.Font = font_row_style

        'No
        Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        no.Text = ""
        no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        no.Font = font_row_style

        'desc
        Dim awb_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        awb_no.Text = keterangan
        awb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        awb_no.Font = font_row_style

        'value
        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        total_nilai.Text = ""
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style

        'qty
        Dim col_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        col_qty.Text = ""
        col_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qty.Font = font_row_style

        'sub_amount
        Dim sub_amount As String = Decimal.Parse(total.ToString).ToString("N2")

        Dim sub_amount_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        sub_amount_col.Text = sub_amount
        sub_amount_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_col.Font = font_row_style
    End Sub
End Class