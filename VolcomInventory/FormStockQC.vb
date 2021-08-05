﻿Public Class FormStockQC
    Public id_dsg As String = "-1"

    Private Sub FormStockQC_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormStockQC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dt now
        Dim dt As DateTime = getTimeDB()
        DEDate.EditValue = dt

        DEStockFrom.EditValue = Now
        DEStockTo.EditValue = Now

        viewVendor()
        viewSeason()
        viewType()
    End Sub

    Private Sub FormStockQC_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewSOH()
        Cursor = Cursors.WaitCursor

        'design
        Dim cond_dsg As String = ""
        If id_dsg <> "-1" Then
            cond_dsg = "AND dsg.id_design='" + id_dsg + "' "
        End If

        'season 
        Dim cond_season As String = ""
        If SLESeason.EditValue.ToString <> "0" Then
            cond_season = "AND ss.id_season=" + SLESeason.EditValue.ToString + " "
        End If

        'vendor
        Dim cond_vendor As String = ""
        If SLEVendor.EditValue.ToString <> "0" Then
            cond_vendor = "AND comp.id_comp=" + SLEVendor.EditValue.ToString + " "
        End If

        'date
        Dim date_filter As String = "9999-01-01"
        Try
            date_filter = DateTime.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try


        Dim query As String = "SELECT pod.id_prod_order_det, pod.id_prod_order,
        po.prod_order_number, CONCAT(comp.comp_number, ' - ', comp.comp_name) AS `vendor`,
        dsg.design_code AS `code`,prod.product_full_code AS `barcode`,prod.product_display_name AS `name`, cd.code_detail_name AS `size`, ss.season,
        IFNULL((prec.prod_order_rec_det_qty + (COALESCE(rin.tot_ret_in, 0)-COALESCE(rout.tot_ret_out, 0) )) - COALESCE(pl.tot_pl, 0) +  COALESCE(adj_in.tot_adj_in,0) -  COALESCE(adj_out.tot_adj_out,0) - COALESCE(ass.tot_ass,0) - COALESCE(sni.qty,0),0) AS qty,
        IF(dsg.final_is_approve=1,dsg.design_cop,IF(dsg.pp_is_approve=1,dsg.pp_cop_value,0)) AS `cop`, IF(dsg.id_cop_status=1,'Pre Final', 'Final') AS `cop_status`
        FROM tb_prod_order po
        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
        INNER JOIN tb_season_delivery del ON del.id_delivery = po.id_delivery
        INNER JOIN tb_season ss ON ss.id_season = del.id_season
        INNER JOIN tb_prod_order_wo wo On wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor='1' AND wo.id_report_status!=5
        INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price = wo.id_ovh_price
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
        INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp
        INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product = pod.id_prod_demand_product
        INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
        INNER JOIN tb_m_product_code prodcode ON prodcode.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodcode.id_code_detail
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        LEFT JOIN (
	        SELECT b1.id_prod_order_det, b2.id_prod_order_rec, SUM(b1.prod_order_rec_det_qty) AS  prod_order_rec_det_qty
	        FROM tb_prod_order_rec_det b1
	        INNER JOIN tb_prod_order_rec b2 ON b1.id_prod_order_rec = b2.id_prod_order_rec
	        WHERE b2.id_report_status =6 AND b2.complete_date<='" + date_filter + "'
	        GROUP BY b1.id_prod_order_det
        ) prec ON prec.id_prod_order_det = pod.id_prod_order_det
        LEFT JOIN (
	        SELECT d1.id_prod_order_det, d2.id_prod_order_ret_out, SUM(d1.prod_order_ret_out_det_qty) AS tot_ret_out FROM tb_prod_order_ret_out_det d1 
	        INNER JOIN tb_prod_order_ret_out d2 ON d1.id_prod_order_ret_out = d2.id_prod_order_ret_out 
	        WHERE d2.id_report_status !=5 AND d2.complete_date <= '" + date_filter + "'
	        GROUP BY d1.id_prod_order_det
        ) rout ON rout.id_prod_order_det = pod.id_prod_order_det
        LEFT JOIN(
	        SELECT e1.id_prod_order_det, e2.id_prod_order_ret_in,SUM(e1.prod_order_ret_in_det_qty) AS tot_ret_in FROM tb_prod_order_ret_in_det e1 
	        INNER JOIN tb_prod_order_ret_in e2 ON e1.id_prod_order_ret_in = e2.id_prod_order_ret_in 
	        WHERE e2.id_report_status =6 AND e2.complete_date<='" + date_filter + "'
	        GROUP BY e1.id_prod_order_det
        ) rin ON rin.id_prod_order_det = pod.id_prod_order_det
        LEFT JOIN(
	        SELECT j1.id_prod_order_det, j2.id_pl_prod_order,SUM(j1.pl_prod_order_det_qty) AS tot_pl FROM tb_pl_prod_order_det j1 
	        INNER JOIN tb_pl_prod_order j2 ON j1.id_pl_prod_order = j2.id_pl_prod_order 
	        WHERE j2.id_report_status !=5 AND j2.complete_date<='" + date_filter + "'
	        GROUP BY j1.id_prod_order_det
        ) pl ON pl.id_prod_order_det = pod.id_prod_order_det
        LEFT JOIN(
	        SELECT adj_in_d.id_prod_order_det, adj_in_d.id_prod_order_qc_adj_in_det,SUM(adj_in_d.prod_order_qc_adj_in_det_qty) AS tot_adj_in
	        FROM tb_prod_order_qc_adj_in_det adj_in_d
	        INNER JOIN tb_prod_order_qc_adj_in adj_in ON adj_in_d.id_prod_order_qc_adj_in = adj_in.id_prod_order_qc_adj_in 
	        WHERE adj_in.id_report_status =6 AND adj_in.complete_date<='" + date_filter + "'
	        GROUP BY adj_in_d.id_prod_order_det
        ) adj_in ON adj_in.id_prod_order_det = pod.id_prod_order_det 
        LEFT JOIN (
	        SELECT adj_out_d.id_prod_order_det, adj_out_d.id_prod_order_qc_adj_out_det,SUM(adj_out_d.prod_order_qc_adj_out_det_qty) AS tot_adj_out
	        FROM tb_prod_order_qc_adj_out_det adj_out_d
	        INNER JOIN tb_prod_order_qc_adj_out adj_out ON adj_out_d.id_prod_order_qc_adj_out = adj_out.id_prod_order_qc_adj_out 
	        WHERE adj_out.id_report_status !=5 AND adj_out.complete_date<='" + date_filter + "'
	        GROUP BY adj_out_d.id_prod_order_det
        ) adj_out ON adj_out.id_prod_order_det = pod.id_prod_order_det 
        LEFT JOIN (
	        SELECT acd.id_prod_order_det, SUM(acd.prod_ass_comp_qty_det) AS `tot_ass` 
	        FROM tb_prod_ass_comp_det acd
	        INNER JOIN tb_prod_ass_det ad ON ad.id_prod_ass_det = acd.id_prod_ass_det
	        INNER JOIN tb_prod_ass a ON a.id_prod_ass = ad.id_prod_ass
	        WHERE a.id_report_status!=5 AND a.complete_date<='" + date_filter + "'
	        GROUP BY acd.id_prod_order_det
        ) ass ON ass.id_prod_order_det = pod.id_prod_order_det
        LEFT JOIN
		(
			SELECT io.id_prod_order_det,IF((SELECT is_enable_sni FROM tb_opt_prod)=1,SUM(io.`qty`),0) AS qty
			FROM tb_sni_in_out io 
			WHERE io.date_reff<='" + date_filter + "'
			GROUP BY io.`id_prod_order_det`
		)sni_out ON sni_out.id_prod_order_det=a.`id_prod_order_det`
        WHERE po.id_report_status=6  
        " + cond_season + " 
        " + cond_vendor + "
        " + cond_dsg + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        viewSOH()
    End Sub

    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label 
        UNION "
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
        Dim query As String = "SELECT '0' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewType()
        Dim query As String = "SELECT id_cop_status, cop_status FROM tb_lookup_cop_status"
        viewSearchLookupQuery(SLEType, query, "id_cop_status", "cop_status", "id_cop_status")
    End Sub

    Sub resetNew()
        GCSOH.DataSource = Nothing
        id_dsg = "-1"
        TxtProduct.Text = ""
    End Sub

    Private Sub CEFindAllProduct_CheckedChanged(sender As Object, e As EventArgs) Handles CEFindAllProduct.CheckedChanged
        resetNew()
        If CEFindAllProduct.EditValue = True Then
            BtnBrowseProduct.Enabled = False
        Else
            BtnBrowseProduct.Enabled = True
        End If
    End Sub

    Private Sub BtnBrowseProduct_Click(sender As Object, e As EventArgs) Handles BtnBrowseProduct.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "3"
        FormSearchDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        resetNew()
    End Sub

    Private Sub SLEVendor_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendor.EditValueChanged
        resetNew()
    End Sub

    Private Sub BSearchSC_Click(sender As Object, e As EventArgs) Handles BSearchSC.Click
        view_stock_card()
    End Sub

    Sub view_stock_card()
        Dim po_number As String = TxtProductSC.EditValue.ToString

        If Not po_number = "" Then
            Dim query As String = ""

            'detail
            query = "
                SELECT comp.comp_name AS vendor, d.design_code, d.design_display_name
                FROM tb_prod_order AS po
                LEFT JOIN tb_prod_demand_design AS pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
                LEFT JOIN tb_m_design AS d ON d.id_design = pdd.id_design
                LEFT JOIN tb_prod_order_wo AS wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor = 1
                LEFT JOIN tb_m_ovh_price AS ovh ON ovh.id_ovh_price = wo.id_ovh_price
                LEFT JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = ovh.id_comp_contact 
                LEFT JOIN tb_m_comp AS comp ON comp.id_comp = cc.id_comp
                WHERE po.prod_order_number = '" + po_number + "'
            "

            Dim data_detail As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtVendor.EditValue = data_detail.Rows(0)("vendor")
            TxtCode.EditValue = data_detail.Rows(0)("design_code")
            TxtDescription.EditValue = data_detail.Rows(0)("design_display_name")

            'list
            query = "CALL view_stock_card_qc('" + po_number + "')"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCSC.DataSource = data

            GVSC.BestFitColumns()
        End If
    End Sub

    Private Sub BtnBrowsePOSC_Click(sender As Object, e As EventArgs) Handles BtnBrowsePOSC.Click
        FormStockQCBrowsePO.ShowDialog()
    End Sub

    Private Sub SBStockView_Click(sender As Object, e As EventArgs) Handles SBStockView.Click
        Cursor = Cursors.WaitCursor

        Dim d_from As String = Date.Parse(DEStockFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim d_to As String = Date.Parse(DEStockTo.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim data As DataTable = execute_query("CALL view_stock_summary_qc('" + d_from + "', '" + d_to + "', '" + SLEType.EditValue.ToString + "')", -1, True, "", "", "", "")

        GCStockReport.DataSource = data

        GVStockReport.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBPrintStock_Click(sender As Object, e As EventArgs) Handles SBPrintStock.Click
        'modify period
        Dim period_from As String = ""
        Dim period_until As String = ""
        period_from = Date.Parse(DEStockFrom.EditValue.ToString).ToString("dd MMM yyyy")
        period_until = Date.Parse(DEStockTo.EditValue.ToString).ToString("dd MMM yyyy")

        '... 
        ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVStockReport.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        ReportStockQCSummary.dt = GCStockReport.DataSource
        Dim Report As New ReportStockQCSummary()
        Report.XrLabel2.Text = SLEType.Text
        Report.LabelPeriod.Text = period_from + " / " + period_until
        Report.GVStockReport.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        ReportStyleGridview(Report.GVStockReport)

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Sub view_stock_summary()
        Dim query As String = "
            SELECT s.id_wip_summary, s.number, s.start_period, s.end_period, s.created_date, e.employee_name AS created_by, r.report_status
            FROM tb_wip_summary AS s
            LEFT JOIN tb_m_employee AS e ON s.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON s.id_report_status = r.id_report_status
            ORDER BY s.created_date DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GridControlSummary.DataSource = data

        GridViewSummary.BestFitColumns()
    End Sub

    Private Sub XTCStock_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCStock.SelectedPageChanged
        If XTCStock.SelectedTabPage.Name = "XTPSummary" Then
            view_stock_summary()
        End If
    End Sub

    Private Sub SBCreateSummary_Click(sender As Object, e As EventArgs) Handles SBCreateSummary.Click
        FormStockQCStockReportSummary.id_wip_summary = "-1"
        FormStockQCStockReportSummary.ShowDialog()
    End Sub

    Private Sub GridViewSummary_DoubleClick(sender As Object, e As EventArgs) Handles GridViewSummary.DoubleClick
        FormStockQCStockReportSummary.id_wip_summary = GridViewSummary.GetFocusedRowCellValue("id_wip_summary").ToString
        FormStockQCStockReportSummary.ShowDialog()
    End Sub
End Class