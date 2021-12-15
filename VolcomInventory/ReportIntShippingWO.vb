Public Class ReportIntShippingWO
    Public id_report As String = ""

    Private Sub ReportIntShippingWO_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim qorign As String = "SELECT d.`design_display_name`,d.`design_code`,pcl.id_prod_order,a.prod_order_number,CONCAT(a.prod_order_number,' - ',IFNULL(cd.class,''),' ',d.design_name,' ',IFNULL(cd.color,'')) AS `description`,pcl.qty,pcl.id_currency,pcl.price,pcl.duty,(pcl.qty*pcl.`price`) AS amount
FROM `tb_pre_cal_fgpo_list` pcl
INNER JOIN tb_prod_order a ON a.id_prod_order=pcl.id_prod_order 
INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
INNER JOIN tb_m_design d ON b.id_design = d.id_design
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43)
	GROUP BY dc.id_design
) cd ON cd.id_design = d.id_design
WHERE pcl.id_pre_cal_fgpo='" & id_report & "'"
        Dim dt_orign As DataTable = execute_query(qorign, -1, True, "", "", "", "")

        ' Dim total As Decimal = 0.00

        For i = 0 To dt_orign.Rows.Count - 1
            insert_row_bm(RowBM, dt_orign, i)
            'total += dt_orign.Rows(i)("amount")
            'If i = dt_orign.Rows.Count - 1 Then
            '    insert_row_bm_total(RowBM, total)
            'End If
        Next
    End Sub

    Sub insert_row_bm(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size - 2, FontStyle.Regular)

        row = XTBM.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style

        'desc

        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = dt.Rows(row_i)("description").ToString
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        desc.Font = font_row_style

        'qty
        Dim qty As String = Decimal.Parse(dt.Rows(row_i)("qty").ToString).ToString("N2")

        Dim qty_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        qty_col.Text = qty
        qty_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_col.Font = font_row_style

        ''price
        'Dim price As String = Decimal.Parse(dt.Rows(row_i)("price").ToString).ToString("N2")

        'Dim price_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        'price_col.Text = "$ " & price
        'price_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'price_col.Font = font_row_style

        ''tot_price
        'Dim tot_price As String = Decimal.Parse(dt.Rows(row_i)("amount").ToString).ToString("N2")

        'Dim tot_price_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        'tot_price_col.Text = "$ " & tot_price
        'tot_price_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'tot_price_col.Font = font_row_style
    End Sub

    Sub insert_row_bm_total(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal total As Decimal)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size, FontStyle.Regular)

        row = XTBM.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style

        'desc

        Dim desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        desc.Text = ""
        desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        desc.Font = font_row_style

        'qty
        Dim qty_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        qty_col.Text = ""
        qty_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_col.Font = font_row_style

        ''price
        'Dim price_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        'price_col.Text = "Total"
        'price_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'price_col.Font = font_row_style

        ''tot_price
        'Dim tot_price As String = Decimal.Parse(total.ToString).ToString("N2")

        'Dim tot_price_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        'tot_price_col.Text = "$ " & tot_price
        'tot_price_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'tot_price_col.Font = font_row_style
    End Sub
End Class