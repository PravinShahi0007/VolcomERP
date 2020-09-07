Public Class FormSampleDevelopment
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Sub check_menu()
        If GVDesign.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormSampleDevelopment_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSampleDevelopment_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSampleDevelopment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        '
        viewDesign()
        viewVendor()
        viewSeasonPo()
    End Sub

    Sub viewSeasonPo()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeasonPO, query, "id_season", "season", "id_season")
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
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.id_range >0 "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewData()
        GVDesign.RowHeight = 10

        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim cond As String = ""
        If id_ss = "-1" Then
            cond = "-1"
        Else
            cond = "And f1.id_season=" + id_ss + " "
        End If
        Dim query As String = "CALL view_sample_dev('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDesign.DataSource = data
        GVDesign.BestFitColumns()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        FormSampleDevelopmentDet.id_design = GVDesign.GetFocusedRowCellValue("id_design").ToString
        FormSampleDevelopmentDet.ShowDialog()
    End Sub

    Private Sub CheckEditFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditFreeze.CheckedChanged
        If CheckEditFreeze.Checked = True Then
            GBDesign.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GBDesign.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
        End If
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Cursor = Cursors.WaitCursor
        view_production_order()
        Cursor = Cursors.Default
    End Sub

    Sub view_production_order()
        Dim query_where As String = ""

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query_where += " AND b.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
        End If

        If Not SLESeasonPO.EditValue.ToString = "-1" Then
            query_where += " AND e.id_season='" & SLESeasonPO.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND cc.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query = "SELECT 'no' AS is_check,'' AS NO,
a.id_term_production ,comp.id_comp,cc.id_comp_contact,comp.comp_name,comp.comp_number,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code,d.design_code_import, h.term_production, g.po_type,d.design_cop, 
a.prod_order_date,a.id_report_status,c.report_status,season_del_dsg.est_wh_date,season_del_dsg.delivery_date,
b.id_design,b.id_delivery, e.delivery, f.season, e.id_season,`range`.range,
RIGHT(d.design_display_name,3) AS color,LEFT(d.design_display_name,LENGTH(d.design_display_name)-3) AS class_dsg 
,py.payment,DATE_ADD(wo.prod_order_wo_del_date,INTERVAL prod_order_wo_lead_time DAY) AS est_del_date,IF(ISNULL(ko.lead_time_prod),NULL,DATE_ADD(wo.prod_order_wo_del_date,INTERVAL ko.lead_time_prod DAY)) AS est_del_date_ko,wo.prod_order_wo_lead_time AS lead_time,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL (wo.prod_order_wo_lead_time+wo.prod_order_wo_top) DAY) AS payment_due_date,prod_order_wo_top AS lead_time_pay 
,wo_price.prod_order_wo_vat AS vat,wo_price.wo_price AS po_amount_rp,wo_price.wo_price_no_kurs AS po_amount,wo_price.currency AS po_curr,wo_price.prod_order_wo_kurs AS po_kurs,IFNULL(SUM(pod.prod_order_qty),0)*(d.prod_order_cop_bom * d.prod_order_cop_bom_curr) AS bom_amount,(d.prod_order_cop_bom * d.prod_order_cop_bom_curr) AS bom_unit 
,IF(ISNULL(kp.sample_proto_2),a.sample_proto_2,kp.sample_proto_2) AS sample_proto_2 
FROM tb_prod_order a 
INNER JOIN tb_prod_order_det pod ON pod.id_prod_order=a.id_prod_order 
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
LEFT JOIN (
	SELECT wo.id_prod_order, wo.id_ovh_price, wo.prod_order_wo_kurs, cur.currency,wo.prod_order_wo_vat,
	(SUM(CAST(wod.prod_order_wo_det_price * pod.prod_order_qty AS DECIMAL(13,2))) * wo.prod_order_wo_kurs * (100 + wo.prod_order_wo_vat)/100) AS `wo_price`
	,(SUM(CAST(wod.prod_order_wo_det_price * pod.prod_order_qty AS DECIMAL(13,2))) * (100 + wo.prod_order_wo_vat)/100) AS `wo_price_no_kurs`
	FROM tb_prod_order_wo wo
	INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
	INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
	INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	WHERE wo.is_main_vendor=1 
	GROUP BY wo.id_prod_order_wo
) wo_price ON wo_price.id_prod_order= a.id_prod_order 
LEFT JOIN (
    SELECT * FROM (
	    SELECT * FROM tb_prod_order_ko_det
	    ORDER BY id_prod_order_ko_det DESC
    )ko GROUP BY ko.id_prod_order
) ko ON ko.id_prod_order=a.id_prod_order 
LEFT JOIN (
    SELECT * FROM (
	    SELECT * FROM tb_prod_order_kp_det
	    ORDER BY id_prod_order_kp_det DESC
    )kp GROUP BY kp.id_prod_order
) kp ON kp.id_prod_order=a.id_prod_order 
WHERE 1=1 " & query_where & "
GROUP BY a.id_prod_order"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProd.DataSource = data
        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            GVProd.BestFitColumns()
            GVProd.ExpandAllGroups()
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click

    End Sub
End Class