Public Class ReportPreCalReport
    Public id_report As String = "-1"
    Private Sub ReportPreCalReport_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim qorign As String = "SELECT l.duty
,SUM((l.`price`*cal.`rate_management`)*l.`qty`) AS tot_fob_rp
,SUM(ROUND((tot_freight.tot_freight/tot_fgpo.tot_qty_sales)*l.`qty`*(cal.`sales_percent`/100),2)) AS tot_freight
,SUM(ROUND((tot_freight.tot_freight/tot_fgpo.tot_qty_sales)*l.`qty`*(cal.`sales_percent`/100),2))+SUM((l.`price`*cal.`rate_management`)*l.`qty`) AS tot_cif
,ROUND((SUM(ROUND((tot_freight.tot_freight/tot_fgpo.tot_qty_sales)*l.`qty`*(cal.`sales_percent`/100),2))+SUM((l.`price`*cal.`rate_management`)*l.`qty`))*(l.duty/100),2) AS tot_duty
FROM `tb_pre_cal_fgpo_list` l
INNER JOIN tb_pre_cal_fgpo cal ON cal.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=l.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design d ON d.`id_design`=pdd.`id_design`
INNER JOIN 
(
	SELECT det.`total_in_rp` AS tot_freight
	FROM tb_pre_cal_fgpo_det det
	INNER JOIN tb_pre_cal_fgpo f ON f.`id_pre_cal_fgpo`=det.`id_pre_cal_fgpo` AND f.`choosen_id_comp`=det.`id_comp`
	WHERE det.`id_pre_cal_fgpo`='7' AND det.id_type=1
)tot_freight 
INNER JOIN 
(
	SELECT SUM(l.`qty`) AS tot_qty,SUM(ROUND(l.`qty`*(f.`sales_percent`/100))) AS tot_qty_sales
	FROM tb_pre_cal_fgpo_list l
	INNER JOIN tb_pre_cal_fgpo f ON f.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo` 
	WHERE f.`id_pre_cal_fgpo`='" & id_report & "'
)tot_fgpo
WHERE l.`id_pre_cal_fgpo`='" & id_report & "'
GROUP BY l.duty"
        Dim dt_orign As DataTable = execute_query(qorign, -1, True, "", "", "", "")

        For i = 0 To dt_orign.Rows.Count - 1
            insert_row_bm(RowBM, dt_orign, i)
        Next
        '
        Dim q_duty As String = "SELECT po.`prod_order_number`,d.`design_code`,d.`design_display_name`,l.`qty`,l.`price`,cal.`rate_management`
,(l.`price`*cal.`rate_management`) AS fob_rp,(l.`price`*cal.`rate_management`)*l.`qty` AS tot_fob_rp
,ROUND(pdd.`prod_demand_design_propose_price`) AS price,ROUND(((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) AS price_commision
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)) AS price_ppn
,ROUND(l.`qty`*(cal.`sales_percent`/100)) AS qty_sales
,ROUND(tot_freight.tot_freight/tot_fgpo.tot_qty_sales,2) AS freight_cost
,ROUND((tot_freight.tot_freight/tot_fgpo.tot_qty_sales)*l.`qty`*(cal.`sales_percent`/100),2) AS tot_freight
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100),2) AS royalty
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS tot_royalty
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100),2) AS bm
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100) * ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS tot_bm
,ROUND((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.ppn/100),2) AS ppn_royalty
,ROUND((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.pph/100),2) AS pph_royalty
,ROUND((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.ppn/100)*ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS total_ppn_royalty
,ROUND((((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100))+((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)*(cal.sales_royalty/100) * (l.duty/100)))*(cal.pph/100)*ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS total_pph_royalty
FROM `tb_pre_cal_fgpo_list` l
INNER JOIN tb_pre_cal_fgpo cal ON cal.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=l.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design d ON d.`id_design`=pdd.`id_design`
INNER JOIN 
(
	SELECT det.`total_in_rp` AS tot_freight
	FROM tb_pre_cal_fgpo_det det
	INNER JOIN tb_pre_cal_fgpo f ON f.`id_pre_cal_fgpo`=det.`id_pre_cal_fgpo` AND f.`choosen_id_comp`=det.`id_comp`
	WHERE det.`id_pre_cal_fgpo`='" & id_report & "' AND det.id_type=1
)tot_freight 
INNER JOIN 
(
	SELECT SUM(l.`qty`) AS tot_qty,SUM(ROUND(l.`qty`*(f.`sales_percent`/100))) AS tot_qty_sales
	FROM tb_pre_cal_fgpo_list l
	INNER JOIN tb_pre_cal_fgpo f ON f.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo` 
	WHERE f.`id_pre_cal_fgpo`='" & id_report & "'
)tot_fgpo
WHERE l.`id_pre_cal_fgpo`='" & id_report & "'"
        Dim dt_duty As DataTable = execute_query(q_duty, -1, True, "", "", "", "")

        For i = 0 To dt_duty.Rows.Count - 1
            insert_row_duty(RowBreakDown, dt_orign, i)
        Next
    End Sub

    Sub insert_row_duty(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size, FontStyle.Regular)

        If Not row_i = 0 Then
            row = XTBreakdown.InsertRowBelow(row)
        End If

        row.HeightF = 15
        row.Font = font_row_style

        'po#
        Dim pono As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        pono.Text = dt.Rows(row_i)("prod_order_number").ToString
        pono.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        pono.Font = font_row_style

        'code
        Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        code.Text = dt.Rows(row_i)("design_code").ToString
        code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        code.Font = font_row_style

        'design_name
        Dim dsg As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        dsg.Text = dt.Rows(row_i)("design_display_name").ToString
        dsg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        dsg.Font = font_row_style

        'qty po
        'fob $
        'tot fob $
        'fob in rp
        'rate management
        'total fob in rp
        'est harga jual
        'harga jual margin
        'harga after ppn
        'qty sales
        'freight per pc
        'total freight
        'royalty
        'total royalty
        'bm
        'total bm
        'total ppn
        'total pph

        ''cif
        'Dim cif As String = Decimal.Parse(dt.Rows(row_i)("tot_cif").ToString).ToString("N2")

        'Dim tot_cif As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        'tot_cif.Text = cif
        'tot_cif.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'tot_cif.Font = font_row_style

        ''duty percent
        'Dim duty As String = Decimal.Parse(dt.Rows(row_i)("duty").ToString).ToString("N2") & " %"

        'Dim duty_t As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        'duty_t.Text = duty
        'duty_t.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'duty_t.Font = font_row_style

        ''=
        'Dim separator As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        'separator.Text = "="
        'separator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'separator.Font = font_row_style

        ''tot_duty
        'Dim tot_duty As String = Decimal.Parse(dt.Rows(row_i)("tot_duty").ToString).ToString("N2")

        'Dim tot_duty_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        'tot_duty_col.Text = tot_duty
        'tot_duty_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        'tot_duty_col.Font = font_row_style
    End Sub

    Sub insert_row_bm(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size, FontStyle.Regular)

        If Not row_i = 0 Then
            row = XTBM.InsertRowBelow(row)
        End If

        row.HeightF = 20
        row.Font = font_row_style

        'cif
        Dim cif As String = Decimal.Parse(dt.Rows(row_i)("tot_cif").ToString).ToString("N2")

        Dim tot_cif As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        tot_cif.Text = cif
        tot_cif.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_cif.Font = font_row_style

        'duty percent
        Dim duty As String = Decimal.Parse(dt.Rows(row_i)("duty").ToString).ToString("N2") & " %"

        Dim duty_t As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        duty_t.Text = duty
        duty_t.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        duty_t.Font = font_row_style

        '=
        Dim separator As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        separator.Text = "="
        separator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        separator.Font = font_row_style

        'tot_duty
        Dim tot_duty As String = Decimal.Parse(dt.Rows(row_i)("tot_duty").ToString).ToString("N2")

        Dim tot_duty_col As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        tot_duty_col.Text = tot_duty
        tot_duty_col.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_duty_col.Font = font_row_style
    End Sub
End Class