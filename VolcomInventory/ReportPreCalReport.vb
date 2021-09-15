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