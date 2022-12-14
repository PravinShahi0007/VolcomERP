Public Class ReportSNIRealisasi
    Public Shared id As String = "-1"
    Public Shared tot_qty As Decimal = 1

    Private Sub ReportSNIBudget_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim q As String = "SELECT sni.number,snib.number AS budget_number
FROM `tb_sni_realisasi` sni
INNER JOIN tb_sni_pps snib ON snib.id_sni_pps=sni.id_sni_pps
WHERE sni.`id_sni_realisasi`='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        DataSource = dt
        '
        '        Dim qdet As String = "SELECT ppsb.desc,ppsb.qty,ppsb.value,ppsb.qty*ppsb.`value` AS  sub_amount
        'FROM 
        '`tb_sni_realisasi_budget` ppsb
        'WHERE ppsb.`id_sni_realisasi`='" & id & "'
        'UNION ALL
        'SELECT CONCAT('Biaya sample ',d.design_display_name) AS `desc`,(ppsb.rec_qty-ppsb.ret_qty) AS qty,ppsb.bom_price AS `value`,(ppsb.rec_qty-ppsb.ret_qty)*ppsb.`bom_price` AS  sub_amount
        'FROM 
        '`tb_sni_realisasi_return` ppsb
        'INNER JOIN tb_m_product p ON p.id_product=ppsb.id_product
        'INNER JOIN tb_m_design d ON d.id_design=p.id_design
        'WHERE ppsb.`id_sni_realisasi`='" & id & "' AND ppsb.ret_qty>0"

        Dim qdet As String = "SELECT CONCAT('Biaya sample ',d.design_display_name) AS `desc`,(ppsb.rec_qty-ppsb.ret_qty) AS qty
,ppsb.bom_price AS `value`,(ppsb.rec_qty-ppsb.ret_qty)*ppsb.`bom_price` AS  sub_amount
,b.budget_qty,b.budget_qty*b.budget_value AS budget_amount,b.budget_value
FROM 
`tb_sni_realisasi_return` ppsb
INNER JOIN `tb_sni_realisasi` r ON r.id_sni_realisasi=ppsb.id_sni_realisasi
INNER JOIN tb_m_product p ON p.id_product=ppsb.id_product
INNER JOIN tb_m_design d ON d.id_design=p.id_design
INNER JOIN tb_sni_pps_budget b ON b.id_sni_pps=r.id_sni_pps AND b.id_product=ppsb.id_product
WHERE ppsb.`id_sni_realisasi`='" & id & "' 
UNION ALL
SELECT ppsb.desc,ppsb.qty,ppsb.value,ppsb.qty*ppsb.`value` AS  sub_amount
,IFNULL(b.budget_qty,0) AS budget_qty,IFNULL(b.budget_qty*b.budget_value,0) AS budget_amount,IFNULL(b.budget_value,0) AS budget_value
FROM `tb_sni_realisasi_budget` ppsb
INNER JOIN `tb_sni_realisasi` r ON r.id_sni_realisasi=ppsb.id_sni_realisasi
LEFT JOIN `tb_sni_pps_budget` b ON b.id_sni_pps=r.id_sni_pps AND ppsb.desc=b.`budget_desc`
WHERE ppsb.`id_sni_realisasi`='" & id & "'
UNION ALL
SELECT b.`budget_desc` AS `desc`,0 AS qty,0 AS `value`,0 AS  sub_amount
,b.budget_qty,b.budget_qty*b.budget_value AS budget_amount,b.budget_value
FROM `tb_sni_realisasi` r 
INNER JOIN `tb_sni_pps_budget` b ON b.id_sni_pps=r.id_sni_pps AND ISNULL(b.`id_product`)
LEFT JOIN tb_sni_realisasi_budget ppsb ON ppsb.`desc`=b.`budget_desc` 
WHERE r.`id_sni_realisasi`='" & id & "' AND ISNULL(ppsb.`id_sni_realisasi_budget`)"

        Dim dtdet As DataTable = execute_query(qdet, -1, True, "", "", "", "")

        Dim row_baru As DevExpress.XtraReports.UI.XRTableRow = XRDetail
        Dim tot_nilai As Decimal = 0.00
        Dim tot_budget As Decimal = 0.00
        For i = 0 To dtdet.Rows.Count - 1
            insert_row(row_baru, dtdet, i)
            'add summary
            tot_nilai += dtdet.Rows(i)("sub_amount")
            tot_budget += dtdet.Rows(i)("budget_amount")
            If i = dtdet.Rows.Count - 1 Then
                insert_footer(row_baru, tot_budget, tot_nilai, "Total")
                insert_footer(row_baru, 0, tot_qty, "Total Qty Artikel KIDS")
                insert_footer(row_baru, Math.Round(tot_budget / tot_qty, 2), Math.Round(tot_nilai / tot_qty, 2), "Cost per Pcs")
            End If
        Next
        '
        pre_load_mark_horz("327", id, "2", "2", XrTable2)
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
        desc.Text = dt.Rows(row_i)("desc").ToString
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        'budget
        Dim budget As String = Decimal.Parse(dt.Rows(row_i)("budget_value").ToString).ToString("N2")

        Dim budgetc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        budgetc.Text = budget
        budgetc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        budgetc.Font = font_row_style

        'qty
        Dim budget_qty As String = Decimal.Parse(dt.Rows(row_i)("budget_qty").ToString).ToString("N2")

        Dim col_budget_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        col_budget_qty.Text = budget_qty
        col_budget_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_budget_qty.Font = font_row_style

        'sub_amount
        Dim budget_amount As String = Decimal.Parse(dt.Rows(row_i)("budget_amount").ToString).ToString("N2")

        Dim budget_amount_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        budget_amount_col.Text = budget_amount
        budget_amount_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        budget_amount_col.Font = font_row_style

        'value
        Dim harga As String = Decimal.Parse(dt.Rows(row_i)("value").ToString).ToString("N2")

        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        total_nilai.Text = harga
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style

        'qty
        Dim qty As String = Decimal.Parse(dt.Rows(row_i)("qty").ToString).ToString("N2")

        Dim col_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        col_qty.Text = qty
        col_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qty.Font = font_row_style

        'sub_amount
        Dim sub_amount As String = Decimal.Parse(dt.Rows(row_i)("sub_amount").ToString).ToString("N2")

        Dim sub_amount_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        sub_amount_col.Text = sub_amount
        sub_amount_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_col.Font = font_row_style
    End Sub

    Sub insert_footer(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal total_budget As Decimal, ByVal total As Decimal, ByVal keterangan As String)
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
        Dim col_budget As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        col_budget.Text = ""
        col_budget.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_budget.Font = font_row_style

        'qty
        Dim col_budget_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        col_budget_qty.Text = ""
        col_budget_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_budget_qty.Font = font_row_style

        'sub_amount
        Dim budget_amount As String = Decimal.Parse(total_budget.ToString).ToString("N2")

        Dim col_budget_amount As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        If total_budget = 0 Then
            col_budget_amount.Text = ""
        Else
            col_budget_amount.Text = budget_amount
        End If

        col_budget_amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_budget_amount.Font = font_row_style

        'value
        Dim total_nilai As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        total_nilai.Text = ""
        total_nilai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        total_nilai.Font = font_row_style

        'qty
        Dim col_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        col_qty.Text = ""
        col_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        col_qty.Font = font_row_style

        'sub_amount
        Dim sub_amount As String = Decimal.Parse(total.ToString).ToString("N2")

        Dim sub_amount_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        sub_amount_col.Text = sub_amount
        sub_amount_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        sub_amount_col.Font = font_row_style
    End Sub
End Class