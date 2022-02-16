Public Class FormReportFGPO
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormReportFGPO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormReportFGPO_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormReportFGPO_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_production_order("")
    End Sub

    Sub view_production_order(ByVal opt As String)
        Dim query_where As String = ""

        If opt = "date" Then
            query_where += " AND DATE(rec.prod_order_rec_date)>='" & Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(rec.prod_order_rec_date)<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        Else
            If Not SLEDesignStockStore.EditValue.ToString = "0" Then
                query_where += " AND b.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
            End If

            If Not SLESeason.EditValue.ToString = "-1" Then
                query_where += " AND e.id_season='" & SLESeason.EditValue.ToString & "'"
            End If

            If Not SLEVendor.EditValue.ToString = "0" Then
                query_where += " AND cc.id_comp='" & SLEVendor.EditValue.ToString & "'"
            End If
        End If

        Dim query = "SELECT f.season,a.id_prod_order,a.`prod_order_number`,a.prod_order_date,g.po_type
,comp.comp_name,IF(ISNULL(ko.lead_time_prod),NULL,DATE_ADD(wo.prod_order_wo_del_date,INTERVAL ko.lead_time_prod DAY)) AS est_del_date_ko,qty_plwh.pl_prod_order_date,rec.prod_order_rec_date,
season_del_dsg.delivery_date,season_del_dsg.est_wh_date,
d.design_display_name, d.design_code,d.design_code_import,
IFNULL(SUM(pod.prod_order_qty),0) AS qty_order, 
IFNULL(SUM(rec.prod_order_rec_det_qty),0) AS qty_rec, 
IFNULL(SUM(qty_plwh.qty),0) AS qty_plwh, 
IFNULL(SUM(qty_rec_plwh.qty),0) AS qty_rec_plwh, 
IFNULL(SUM(qty_retin.qty),0) AS qty_ret_in, 
IFNULL(SUM(qty_retout.qty),0) AS qty_ret_out, 
IFNULL(SUM(qty_claim.qty),0) AS qty_ret_claim,
IFNULL(SUM(qty_retin_closed.qty_closed),0) AS qty_ret_closed,
IFNULL(qr.qty_qr,0) AS qty_qr, 
IFNULL(qr.qty_normal,0) AS qty_normal, 
IFNULL(qr.qty_minor,0) AS qty_minor, 
IFNULL(qr.qty_major,0) AS qty_major, 
IFNULL(qr.qty_afkir,0) AS qty_afkir,
IFNULL(qr1.qty_qr,0) AS qc_report_1, 
IFNULL(qr1.qty_normal,0) AS qc_report_1_normal, 
IFNULL(qr1.qty_minor,0) AS qc_report_1_minor, 
IFNULL(qr1.qty_major,0) AS qc_report_1_major, 
IFNULL(qr1.qty_afkir,0) AS qc_report_1_afkir,
IFNULL(sni.qty,0) AS qty_sni
FROM tb_prod_order a 
INNER JOIN tb_prod_order_det pod ON pod.id_prod_order=a.id_prod_order AND a.`id_report_status`=6
INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status 
INNER JOIN tb_m_design d ON b.id_design = d.id_design 
INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery 
INNER JOIN tb_season_delivery season_del_dsg ON d.id_delivery=season_del_dsg.id_delivery 
INNER JOIN tb_season f ON f.id_season=e.id_season 
INNER JOIN tb_range `range` ON `range`.id_range=`f`.id_range 
INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type 
INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production 
LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order=a.id_prod_order AND wo.is_main_vendor='1' 
LEFT JOIN tb_lookup_payment py ON py.id_payment=wo.id_payment 
LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
LEFT JOIN  
( 
	SELECT rec.prod_order_rec_date,recd.id_prod_order_det,SUM(recd.prod_order_rec_det_qty) AS prod_order_rec_det_qty 
	FROM 
	tb_prod_order_rec rec 
	LEFT JOIN tb_prod_order_rec_det recd ON recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status != 5 
	GROUP BY recd.id_prod_order_det 
) rec ON rec.id_prod_order_det=pod.id_prod_order_det 
LEFT JOIN
(
	SELECT pld.`id_prod_order_det`,SUM(pld.`pl_prod_order_det_qty`) AS qty,pl.pl_prod_order_date FROM tb_pl_prod_order_det pld
	INNER JOIN tb_pl_prod_order pl ON pl.`id_pl_prod_order`=pld.`id_pl_prod_order`
	WHERE pl.`id_report_status`!='5'
	GROUP BY pld.`id_prod_order_det`
) qty_plwh ON qty_plwh.id_prod_order_det=pod.id_prod_order_det 
LEFT JOIN
(
	SELECT plld.`id_prod_order_det`,SUM(pld.`pl_prod_order_rec_det_qty`) AS qty,pl.pl_prod_order_rec_date 
	FROM tb_pl_prod_order_rec_det pld
	INNER JOIN tb_pl_prod_order_rec pl ON pl.`id_pl_prod_order_rec`=pld.`id_pl_prod_order_rec`
	INNER JOIN tb_pl_prod_order_det plld ON plld.`id_pl_prod_order_det`=pld.`id_pl_prod_order_det`
	WHERE pl.`id_report_status`!='5'
	GROUP BY plld.`id_prod_order_det`
) qty_rec_plwh ON qty_rec_plwh.id_prod_order_det=pod.id_prod_order_det 
LEFT JOIN
(
	SELECT retd.`id_prod_order_det`,SUM(retd.`prod_order_ret_in_det_qty`) AS qty FROM `tb_prod_order_ret_in_det` retd
	INNER JOIN `tb_prod_order_ret_in` ret ON ret.`id_prod_order_ret_in`=retd.`id_prod_order_ret_in` 
	WHERE ret.`id_report_status`!='5'
	GROUP BY retd.`id_prod_order_det`
) qty_retin ON qty_retin.id_prod_order_det=pod.id_prod_order_det 
LEFT JOIN
(
	SELECT reto.id_prod_order_det,reto.qty-reti.qty AS qty_closed FROM
    (
	    SELECT retd.`id_prod_order_det`,SUM(retd.`prod_order_ret_out_det_qty`) AS qty FROM `tb_prod_order_ret_out_det` retd
	    INNER JOIN `tb_prod_order_ret_out` ret ON ret.`id_prod_order_ret_out`=retd.`id_prod_order_ret_out`
	    WHERE ret.`id_report_status`!='5' AND ret.is_closed=1
	    GROUP BY retd.`id_prod_order_det`
    )reto
    LEFT JOIN
    (
	    SELECT retd.`id_prod_order_det`,SUM(retd.`prod_order_ret_in_det_qty`) AS qty FROM `tb_prod_order_ret_in_det` retd
	    INNER JOIN `tb_prod_order_ret_in` ret ON ret.`id_prod_order_ret_in`=retd.`id_prod_order_ret_in` 
	    INNER JOIN `tb_prod_order_ret_out` reto ON reto.`id_prod_order_ret_out`=ret.`id_prod_order_ret_out` AND reto.is_closed=1
	    WHERE ret.`id_report_status`!='5'
	    GROUP BY retd.`id_prod_order_det`
    )reti ON reto.`id_prod_order_det`=reti.id_prod_order_det
    HAVING qty_closed>0
) qty_retin_closed ON qty_retin_closed.id_prod_order_det=pod.id_prod_order_det 
LEFT JOIN
(
	SELECT retd.`id_prod_order_det`,SUM(retd.`prod_order_ret_out_det_qty`) AS qty FROM `tb_prod_order_ret_out_det` retd
	INNER JOIN `tb_prod_order_ret_out` ret ON ret.`id_prod_order_ret_out`=retd.`id_prod_order_ret_out`
	WHERE ret.`id_report_status`!='5'
	GROUP BY retd.`id_prod_order_det`
) qty_retout ON qty_retout.id_prod_order_det=pod.id_prod_order_det 
LEFT JOIN
(
	SELECT retd.`id_prod_order_det`,SUM(retd.`qty`) AS qty FROM `tb_prod_claim_return_det` retd
	INNER JOIN `tb_prod_claim_return` ret ON ret.`id_prod_claim_return`=retd.`id_prod_claim_return`
	WHERE ret.`id_report_status`='6'
	GROUP BY retd.`id_prod_order_det`
) qty_claim ON qty_claim.id_prod_order_det=pod.id_prod_order_det 
LEFT JOIN (
	SELECT * FROM (
	    SELECT * FROM tb_prod_order_ko_det
	    ORDER BY id_prod_order_ko_det DESC
	)ko GROUP BY ko.id_prod_order
) ko ON ko.id_prod_order=a.id_prod_order 
LEFT JOIN
(
    SELECT fc.`id_prod_order`,SUM(fcd.`prod_fc_det_qty`) AS qty_qr,SUM(IF(fc.`id_pl_category`=1,fcd.`prod_fc_det_qty`,0)) AS qty_normal,SUM(IF(fc.`id_pl_category`=2,fcd.`prod_fc_det_qty`,0)) AS qty_minor,SUM(IF(fc.`id_pl_category`=3,fcd.`prod_fc_det_qty`,0)) AS qty_major,SUM(IF(fc.`id_pl_category`=4,fcd.`prod_fc_det_qty`,0)) AS qty_afkir
    FROM tb_prod_fc_det fcd
    INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=fcd.`id_prod_fc` AND fc.`id_report_status`!=5
    GROUP BY fc.`id_prod_order`
)qr ON qr.id_prod_order=a.id_prod_order 
LEFT JOIN
(
    SELECT fc.`id_prod_order`,SUM(fcd.`qc_report1_det_qty`) AS qty_qr,SUM(IF(fc.`id_pl_category`=1,fcd.`qc_report1_det_qty`,0)) AS qty_normal,SUM(IF(fc.`id_pl_category`=2,fcd.`qc_report1_det_qty`,0)) AS qty_minor,SUM(IF(fc.`id_pl_category`=3,fcd.`qc_report1_det_qty`,0)) AS qty_major,SUM(IF(fc.`id_pl_category`=4,fcd.`qc_report1_det_qty`,0)) AS qty_afkir
    FROM tb_qc_report1_det fcd
    INNER JOIN tb_qc_report1 fc ON fc.`id_qc_report1`=fcd.`id_qc_report1` AND fc.`id_report_status`!=5
    GROUP BY fc.`id_prod_order`
)qr1 ON qr1.id_prod_order=a.id_prod_order 
LEFT JOIN
(
    SELECT rec.id_prod_order,IF((SELECT is_enable_sni FROM tb_opt_prod)=1,SUM(io.`qty`)*-1,0) AS qty
    FROM tb_sni_in_out io 
    INNER JOIN tb_prod_order_rec rec ON rec.id_prod_order_rec=io.id_prod_order_rec
    GROUP BY rec.`id_prod_order`
) sni ON sni.id_prod_order = a.id_prod_order
"
        query += "WHERE 1=1 " & query_where
        query += "GROUP BY a.id_prod_order"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'data.Columns.Add("images", GetType(Image))
        'For i As Integer = 0 To data.Rows.Count - 1
        '    Dim img As Image
        '    Dim fileName As String = ""
        '    If System.IO.File.Exists(product_image_path & data.Rows(i)("id_design").ToString & ".jpg".ToLower) Then
        '        fileName = product_image_path & data.Rows(i)("id_design").ToString & ".jpg".ToLower
        '    Else
        '        fileName = product_image_path & "Default" & ".jpg".ToLower
        '    End If

        '    img = Image.FromFile(fileName)

        '    data.Rows(i)("images") = img
        'Next

        GCProd.DataSource = data
        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            GVProd.BestFitColumns()
            GVProd.ExpandAllGroups()
        End If
    End Sub

    Private Sub FormReportFGPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DEUntil.EditValue = Now
        viewDesign()
        viewSeason()
        viewVendor()
    End Sub

    Sub viewDesign()
        Dim query As String = ""
        query += "CALL view_design_order(TRUE)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEDesignStockStore.Properties.DataSource = Nothing
        SLEDesignStockStore.Properties.DataSource = data
        SLEDesignStockStore.Properties.DisplayMember = "display_name"
        SLEDesignStockStore.Properties.ValueMember = "id_design"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignStockStore.EditValue = data.Rows(0)("id_design").ToString
        Else
            SLEDesignStockStore.EditValue = Nothing
        End If
    End Sub

    'view season
    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEVendor.Properties.DataSource = Nothing
        SLEVendor.Properties.DataSource = data
        SLEVendor.Properties.DisplayMember = "comp_name_label"
        SLEVendor.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEVendor.EditValue = Nothing
        End If
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print_raw(GCProd, "PO List")
    End Sub

    Private Sub BSearchTanggal_Click(sender As Object, e As EventArgs) Handles BSearchTanggal.Click
        view_production_order("date")
    End Sub

    Private Sub GVProd_DoubleClick(sender As Object, e As EventArgs) Handles GVProd.DoubleClick
        If GVProd.RowCount > 0 Then
            FormProductionDet.is_no_cost = "1"
            FormProductionDet.id_prod_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
            FormProductionDet.ShowDialog()
        End If
    End Sub
End Class