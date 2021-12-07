Public Class ReportPreCalReport
    Public id_report As String = "-1"
    Private Sub ReportPreCalReport_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim qorign As String = "SELECT l.duty
,SUM((l.`price`*cal.`rate_management`)*l.`qty`) AS tot_fob_rp
,SUM((tot_freight.tot_freight/tot_fgpo.tot_qty)*l.`qty`) AS tot_freight
,SUM((tot_freight.tot_freight/tot_fgpo.tot_qty)*l.`qty`)+SUM((l.`price`*cal.`rate_management`)*l.`qty`) AS tot_cif
,(SUM((tot_freight.tot_freight/tot_fgpo.tot_qty)*l.`qty`)+SUM((l.`price`*cal.`rate_management`)*l.`qty`))*(l.duty/100) AS tot_duty
FROM `tb_pre_cal_fgpo_list` l
INNER JOIN tb_pre_cal_fgpo cal ON cal.`id_pre_cal_fgpo`=l.`id_pre_cal_fgpo`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=l.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design d ON d.`id_design`=pdd.`id_design`
INNER JOIN 
(
	SELECT SUM(det.`total_in_rp`) AS tot_freight
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
WHERE l.`id_pre_cal_fgpo`='" & id_report & "'
GROUP BY l.duty"
        Dim dt_orign As DataTable = execute_query(qorign, -1, True, "", "", "", "")

        For i = 0 To dt_orign.Rows.Count - 1
            insert_row_bm(RowBM, dt_orign, i)
        Next
        '
        Dim row_baru As DevExpress.XtraReports.UI.XRTableRow = RowBreakDown
        '
        Dim q_duty As String = "SELECT po.`prod_order_number`,d.`design_code`,d.`design_display_name`,(l.`qty`*l.`price`) AS tot_fob,l.`qty`,l.`price`,cal.`rate_management`
,(l.`price`*cal.`rate_management`) AS fob_rp,(l.`price`*cal.`rate_management`)*l.`qty` AS tot_fob_rp
,ROUND(pdd.`prod_demand_design_propose_price`) AS pd_price,ROUND(((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) AS price_commision
,ROUND((((100-cal.`sales_commission`)/100)*pdd.`prod_demand_design_propose_price`) / ((100+cal.sales_ppn)/100)) AS price_ppn
,ROUND(l.`qty`*(cal.`sales_percent`/100)) AS qty_sales
,ROUND(tot_freight.tot_freight/tot_fgpo.tot_qty_sales,2) AS freight_cost
,ROUND((tot_freight.tot_freight/tot_fgpo.tot_qty_sales)*ROUND(l.`qty`*(cal.`sales_percent`/100)),2) AS tot_freight
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
	SELECT SUM(det.`total_in_rp`) AS tot_freight
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

        Dim tot_qty_po, tot_fob, tot_fob_rp, tot_qty_sales, tot_freight, tot_royalty, tot_bm, tot_royalty_ppn, tot_royalty_pph As Decimal

        tot_qty_po = 0
        tot_fob = 0
        tot_fob_rp = 0
        tot_qty_sales = 0
        tot_freight = 0
        tot_royalty = 0
        tot_bm = 0
        tot_royalty_ppn = 0
        tot_royalty_pph = 0

        For i = 0 To dt_duty.Rows.Count - 1
            insert_row_duty(row_baru, dt_duty, i)
            tot_qty_po += dt_duty.Rows(i)("qty")
            tot_fob += dt_duty.Rows(i)("tot_fob")
            tot_fob_rp += dt_duty.Rows(i)("tot_fob_rp")
            tot_qty_sales += dt_duty.Rows(i)("qty_sales")
            tot_freight += dt_duty.Rows(i)("tot_freight")
            tot_royalty += dt_duty.Rows(i)("tot_royalty")
            tot_bm += dt_duty.Rows(i)("tot_bm")
            tot_royalty_ppn += dt_duty.Rows(i)("total_ppn_royalty")
            tot_royalty_pph += dt_duty.Rows(i)("total_pph_royalty")
        Next
        '
        Dim dtx As DataTable = DataSource
        tot_freight = dtx.Rows(0)("tot_freight")
        '
        insert_row_duty_total(row_baru, tot_qty_po, tot_fob, tot_fob_rp, tot_qty_sales, tot_freight, tot_royalty, tot_bm, tot_royalty_ppn, tot_royalty_pph)

        pre_load_mark_horz("334", id_report, "2", "2", XrTable6)
    End Sub

    Sub insert_row_duty(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTBreakdown.Font.FontFamily, XTBreakdown.Font.Size - 1, FontStyle.Regular)

        row = XTBreakdown.InsertRowBelow(row)

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
        Dim qty_po As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        qty_po.Text = Decimal.Parse(dt.Rows(row_i)("qty").ToString).ToString("N0")
        qty_po.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_po.Font = font_row_style

        'fob $
        Dim fob As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        fob.Text = Decimal.Parse(dt.Rows(row_i)("price").ToString).ToString("N2")
        fob.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        fob.Font = font_row_style

        'tot fob $
        Dim tot_fob As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        tot_fob.Text = Decimal.Parse(dt.Rows(row_i)("tot_fob").ToString).ToString("N2")
        tot_fob.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_fob.Font = font_row_style

        'rate management
        Dim rate As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        rate.Text = Decimal.Parse(dt.Rows(row_i)("rate_management").ToString).ToString("N2")
        rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        rate.Font = font_row_style

        'fob in rp
        Dim fobrp As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        fobrp.Text = Decimal.Parse(dt.Rows(row_i)("fob_rp").ToString).ToString("N2")
        fobrp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        fobrp.Font = font_row_style

        'total fob in rp
        Dim tot_fobrp As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        tot_fobrp.Text = Decimal.Parse(dt.Rows(row_i)("tot_fob_rp").ToString).ToString("N2")
        tot_fobrp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_fobrp.Font = font_row_style

        'est harga jual
        Dim pd_price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
        pd_price.Text = Decimal.Parse(dt.Rows(row_i)("pd_price").ToString).ToString("N2")
        pd_price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        pd_price.Font = font_row_style

        'harga jual margin
        Dim price_commision As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
        price_commision.Text = Decimal.Parse(dt.Rows(row_i)("price_commision").ToString).ToString("N2")
        price_commision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        price_commision.Font = font_row_style

        'harga after ppn
        Dim price_after_tax As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)
        price_after_tax.Text = Decimal.Parse(dt.Rows(row_i)("price_ppn").ToString).ToString("N2")
        price_after_tax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        price_after_tax.Font = font_row_style

        'qty sales
        Dim qty_sales As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)
        qty_sales.Text = Decimal.Parse(dt.Rows(row_i)("qty_sales").ToString).ToString("N0")
        qty_sales.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_sales.Font = font_row_style

        'freight per pc
        Dim freight_cost As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(13)
        freight_cost.Text = Decimal.Parse(dt.Rows(row_i)("freight_cost").ToString).ToString("N2")
        freight_cost.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        freight_cost.Font = font_row_style

        'total freight
        Dim tot_freight As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(14)
        tot_freight.Text = Decimal.Parse(dt.Rows(row_i)("tot_freight").ToString).ToString("N2")
        tot_freight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_freight.Font = font_row_style

        'royalty
        Dim royalty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(15)
        royalty.Text = Decimal.Parse(dt.Rows(row_i)("royalty").ToString).ToString("N2")
        royalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        royalty.Font = font_row_style

        'total royalty
        Dim tot_royalty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(16)
        tot_royalty.Text = Decimal.Parse(dt.Rows(row_i)("tot_royalty").ToString).ToString("N2")
        tot_royalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_royalty.Font = font_row_style

        'bm
        Dim bm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(17)
        bm.Text = Decimal.Parse(dt.Rows(row_i)("bm").ToString).ToString("N2")
        bm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        bm.Font = font_row_style

        'total bm
        Dim tot_bm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(18)
        tot_bm.Text = Decimal.Parse(dt.Rows(row_i)("tot_bm").ToString).ToString("N2")
        tot_bm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_bm.Font = font_row_style

        'total ppn
        Dim tot_ppn_royalty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(19)
        tot_ppn_royalty.Text = Decimal.Parse(dt.Rows(row_i)("total_ppn_royalty").ToString).ToString("N2")
        tot_ppn_royalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_ppn_royalty.Font = font_row_style

        'total pph
        Dim tot_pph_royalty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(20)
        tot_pph_royalty.Text = Decimal.Parse(dt.Rows(row_i)("total_pph_royalty").ToString).ToString("N2")
        tot_pph_royalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_pph_royalty.Font = font_row_style

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

    Sub insert_row_duty_total(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal tot_qtyh As Decimal, ByVal tot_fobh As Decimal, ByVal tot_fob_rph As Decimal, ByVal qty_salesh As Decimal, ByVal tot_freighth As Decimal, ByVal tot_royaltyh As Decimal, ByVal tot_bmh As Decimal, ByVal total_ppn_royaltyh As Decimal, ByVal total_pph_royaltyh As Decimal)
        Dim font_row_style As New Font(XTBreakdown.Font.FontFamily, XTBreakdown.Font.Size - 1, FontStyle.Bold)

        row = XTBreakdown.InsertRowBelow(row)

        row.HeightF = 15
        row.Font = font_row_style

        'po#
        Dim pono As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        pono.Text = "TOTAL"
        pono.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        pono.Font = font_row_style

        'code
        Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        code.Text = ""
        code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        code.Font = font_row_style

        'design_name
        Dim dsg As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        dsg.Text = ""
        dsg.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        dsg.Font = font_row_style

        'qty po
        Dim qty_po As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        qty_po.Text = Decimal.Parse(tot_qtyh.ToString).ToString("N0")
        qty_po.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_po.Font = font_row_style

        'fob $
        Dim fob As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        fob.Text = ""
        fob.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        fob.Font = font_row_style

        'tot fob $
        Dim tot_fob As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        tot_fob.Text = Decimal.Parse(tot_fobh.ToString).ToString("N2")
        tot_fob.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_fob.Font = font_row_style

        'rate management
        Dim rate As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        rate.Text = ""
        rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        rate.Font = font_row_style

        'fob in rp
        Dim fobrp As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        fobrp.Text = ""
        fobrp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        fobrp.Font = font_row_style

        'total fob in rp
        Dim tot_fobrp As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        tot_fobrp.Text = Decimal.Parse(tot_fob_rph.ToString).ToString("N2")
        tot_fobrp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_fobrp.Font = font_row_style

        'est harga jual
        Dim pd_price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
        pd_price.Text = ""
        pd_price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        pd_price.Font = font_row_style

        'harga jual margin
        Dim price_commision As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
        price_commision.Text = ""
        price_commision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        price_commision.Font = font_row_style

        'harga after ppn
        Dim price_after_tax As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)
        price_after_tax.Text = ""
        price_after_tax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        price_after_tax.Font = font_row_style

        'qty sales
        Dim qty_sales As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(12)
        qty_sales.Text = Decimal.Parse(qty_salesh.ToString).ToString("N0")
        qty_sales.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_sales.Font = font_row_style

        'freight per pc
        Dim freight_cost As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(13)
        freight_cost.Text = ""
        freight_cost.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        freight_cost.Font = font_row_style

        'total freight
        Dim tot_freight As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(14)
        tot_freight.Text = Decimal.Parse(tot_freighth.ToString).ToString("N2")
        tot_freight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_freight.Font = font_row_style

        'royalty
        Dim royalty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(15)
        royalty.Text = ""
        royalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        royalty.Font = font_row_style

        'total royalty
        Dim tot_royalty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(16)
        tot_royalty.Text = Decimal.Parse(tot_royaltyh.ToString).ToString("N2")
        tot_royalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_royalty.Font = font_row_style

        'bm
        Dim bm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(17)
        bm.Text = ""
        bm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        bm.Font = font_row_style

        'total bm
        Dim tot_bm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(18)
        tot_bm.Text = Decimal.Parse(tot_bmh.ToString).ToString("N2")
        tot_bm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_bm.Font = font_row_style

        'total ppn
        Dim tot_ppn_royalty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(19)
        tot_ppn_royalty.Text = Decimal.Parse(total_ppn_royaltyh.ToString).ToString("N2")
        tot_ppn_royalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_ppn_royalty.Font = font_row_style

        'total pph
        Dim tot_pph_royalty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(20)
        tot_pph_royalty.Text = Decimal.Parse(total_pph_royaltyh.ToString).ToString("N2")
        tot_pph_royalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_pph_royalty.Font = font_row_style
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