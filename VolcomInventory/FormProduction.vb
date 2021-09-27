﻿Imports System.Globalization

Public Class FormProduction
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Private Images As Hashtable = New Hashtable()
    Dim product_image_path As String = get_setup_field("pic_path_product") & "\"
    '
    Dim id_season As String = "0"
    Dim id_vendor As String = "-1"
    Dim id_design As String = "0"

    Private Sub FormProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RCIMainVendor.ValueChecked = Convert.ToSByte(1)
        RCIMainVendor.ValueUnchecked = Convert.ToSByte(2)
        DEStart.EditValue = Now()
        DEEnd.EditValue = Now()
        '
        viewDesign()
        viewDesignWO()
        viewDesignMRS()
        '
        viewSeason()
        viewSeasonWO()
        viewSeasonMRS()
        '
        viewStatusPD()
        viewVendor()
        '
        viewVendorKO()
        '
        checkFormAccess(Name)
    End Sub

    Sub viewStatusPD()
        Dim query As String = "SELECT '0' as id_statuspd, 'All' as status_pd 
                                UNION
                              SELECT '1' as id_statuspd, 'Already Created' as status_pd 
                                UNION
                              SELECT '2' as id_statuspd, 'Not yet created' as status_pd"
        viewSearchLookupQuery(SLEStatusPD, query, "id_statuspd", "status_pd", "id_statuspd")
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

    Sub viewSeasonWO()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeasonWO, query, "id_season", "season", "id_season")
    End Sub

    Sub viewSeasonMRS()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeasonMRS, query, "id_season", "season", "id_season")
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
    Sub viewDesignWO()
        Dim query As String = ""
        query += "CALL view_design_order(TRUE)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEDesignWO.Properties.DataSource = Nothing
        SLEDesignWO.Properties.DataSource = data
        SLEDesignWO.Properties.DisplayMember = "display_name"
        SLEDesignWO.Properties.ValueMember = "id_design"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignWO.EditValue = data.Rows(0)("id_design").ToString
        Else
            SLEDesignWO.EditValue = Nothing
        End If
    End Sub
    Sub viewDesignMRS()
        Dim query As String = ""
        query += "CALL view_design_order(TRUE)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEDesignMRS.Properties.DataSource = Nothing
        SLEDesignMRS.Properties.DataSource = data
        SLEDesignMRS.Properties.DisplayMember = "display_name"
        SLEDesignMRS.Properties.ValueMember = "id_design"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignMRS.EditValue = data.Rows(0)("id_design").ToString
        Else
            SLEDesignStockStore.EditValue = Nothing
        End If
    End Sub
    Private Sub FormProduction_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProduction_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub no_focus_gv(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub
    Sub view_production_order()
        Dim query_where As String = ""

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query_where += " AND b.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
        End If

        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " AND e.id_season='" & SLESeason.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND cc.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query = "SELECT 'no' as is_check,'' AS no,"
        query += "IFNULL(SUM(rec.prod_order_rec_det_qty),0) AS qty_rec, "
        query += "IFNULL(SUM(pod.prod_order_qty),0) As qty_order, "
        query += "IFNULL(SUM(qty_plwh.qty),0) As qty_plwh, "
        query += "IFNULL(SUM(qty_retin.qty),0) As qty_ret_in, "
        query += "IFNULL(SUM(qty_retout.qty),0) As qty_ret_out, "
        query += "IFNULL(SUM(qty_claim.qty),0) As qty_ret_claim, "
        query += "a.id_term_production ,comp.id_comp,cc.id_comp_contact,comp.comp_name,comp.comp_number,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code,d.design_code_import, h.term_production, g.po_type,d.design_cop, "
        query += "a.prod_order_date,a.id_report_status,c.report_status,season_del_dsg.est_wh_date,season_del_dsg.delivery_date,qty_plwh.pl_prod_order_date,rec.prod_order_rec_date, "
        query += "b.id_design,b.id_delivery, e.delivery, f.season, e.id_season,`range`.range "
        query += ",IF(ISNULL(mark.id_mark),'no','yes') AS is_submit,maxd.employee_name as last_mark,cd.color AS color,CONCAT(cd.class,' ',d.design_name) AS class_dsg "
        query += ",py.payment,DATE_ADD(wo.prod_order_wo_del_date,INTERVAL prod_order_wo_lead_time DAY) AS est_del_date,IF(ISNULL(ko.lead_time_prod),NULL,DATE_ADD(wo.prod_order_wo_del_date,INTERVAL ko.lead_time_prod DAY)) AS est_del_date_ko,wo.prod_order_wo_lead_time AS lead_time,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL (wo.prod_order_wo_lead_time+wo.prod_order_wo_top) DAY) AS payment_due_date,prod_order_wo_top AS lead_time_pay "
        query += ",wo_price.prod_order_wo_vat as vat,wo_price.wo_price AS po_amount_rp,wo_price.wo_price_no_kurs AS po_amount,wo_price.currency as po_curr,wo_price.prod_order_wo_kurs AS po_kurs,IFNULL(SUM(pod.prod_order_qty),0)*(d.prod_order_cop_bom * d.prod_order_cop_bom_curr) AS bom_amount,(d.prod_order_cop_bom * d.prod_order_cop_bom_curr) AS bom_unit "
        query += ",IF(ISNULL(kp.sample_proto_2),a.sample_proto_2,kp.sample_proto_2) AS sample_proto_2,cd.class,cd.color "
        query += "FROM tb_prod_order a "
        query += "INNER JOIN tb_prod_order_det pod ON pod.id_prod_order=a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b On a.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d On b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e On b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season_delivery season_del_dsg On d.id_delivery=season_del_dsg.id_delivery "
        query += "INNER JOIN tb_season f On f.id_season=e.id_season "
        query += "INNER JOIN tb_range `range` On `range`.id_range=`f`.id_range "
        query += "INNER JOIN tb_lookup_po_type g On g.id_po_type=a.id_po_type "
        query += "INNER JOIN tb_lookup_term_production h On h.id_term_production=a.id_term_production "
        query += "LEFT JOIN tb_prod_order_wo wo On wo.id_prod_order=a.id_prod_order And wo.is_main_vendor='1' "
        query += "LEFT JOIN tb_lookup_payment py ON py.id_payment=wo.id_payment "
        query += "LEFT JOIN tb_m_ovh_price ovh_p On ovh_p.id_ovh_price=wo.id_ovh_price "
        query += "LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact "
        query += "LEFT JOIN tb_m_comp comp On comp.id_comp=cc.id_comp "
        query += "LEFT JOIN 
                    (
	                    SELECT * FROM tb_report_mark WHERE report_mark_type='22' GROUP BY report_mark_type,id_report
                    ) mark ON mark.id_report=a.id_prod_order AND mark.report_mark_type='22' "
        query += "LEFT JOIN (
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
) cd ON cd.id_design = d.id_design "
        query += "LEFT JOIN (
	                SELECT wo.id_prod_order, wo.id_ovh_price, wo.prod_order_wo_kurs, cur.currency,wo.prod_order_wo_vat,
	                (SUM(CAST(wod.prod_order_wo_det_price * pod.prod_order_qty AS DECIMAL(13,2))) * wo.prod_order_wo_kurs * (100 + wo.prod_order_wo_vat)/100) AS `wo_price`
                    ,(SUM(CAST(wod.prod_order_wo_det_price * pod.prod_order_qty AS DECIMAL(13,2))) * (100 + wo.prod_order_wo_vat)/100) AS `wo_price_no_kurs`
	                FROM tb_prod_order_wo wo
	                INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
	                INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
                    INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	                WHERE wo.is_main_vendor=1 
	                GROUP BY wo.id_prod_order_wo
                ) wo_price ON wo_price.id_prod_order= a.id_prod_order "
        query += "LEFT JOIN  "
        query += "
(
SELECT rec.prod_order_rec_date,recd.id_prod_order_det,SUM(recd.prod_order_rec_det_qty) AS prod_order_rec_det_qty
FROM 
tb_prod_order_rec rec 
LEFT JOIN tb_prod_order_rec_det recd On recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status != 5 
GROUP BY recd.id_prod_order_det 
) rec On rec.id_prod_order_det=pod.id_prod_order_det "
        query += "LEFT JOIN
                    (
                    SELECT pld.`id_prod_order_det`,SUM(pld.`pl_prod_order_det_qty`) as qty,pl.pl_prod_order_date FROM tb_pl_prod_order_det pld
                    INNER JOIN tb_pl_prod_order pl ON pl.`id_pl_prod_order`=pld.`id_pl_prod_order`
                    WHERE pl.`id_report_status`='6'
                    GROUP BY pld.`id_prod_order_det`
                    ) qty_plwh ON qty_plwh.id_prod_order_det=pod.id_prod_order_det "
        query += "LEFT JOIN
                    (
	                    SELECT retd.`id_prod_order_det`,SUM(retd.`prod_order_ret_in_det_qty`) AS qty FROM `tb_prod_order_ret_in_det` retd
	                    INNER JOIN `tb_prod_order_ret_in` ret ON ret.`id_prod_order_ret_in`=retd.`id_prod_order_ret_in`
	                    WHERE ret.`id_report_status`='6'
	                    GROUP BY retd.`id_prod_order_det`
                    ) qty_retin ON qty_retin.id_prod_order_det=pod.id_prod_order_det 

                    LEFT JOIN
                    (
	                    SELECT retd.`id_prod_order_det`,SUM(retd.`prod_order_ret_out_det_qty`) AS qty FROM `tb_prod_order_ret_out_det` retd
	                    INNER JOIN `tb_prod_order_ret_out` ret ON ret.`id_prod_order_ret_out`=retd.`id_prod_order_ret_out`
	                    WHERE ret.`id_report_status`='6'
	                    GROUP BY retd.`id_prod_order_det`
                    ) qty_retout ON qty_retout.id_prod_order_det=pod.id_prod_order_det 
                    LEFT JOIN
                    (
	                    SELECT retd.`id_prod_order_det`,SUM(retd.`qty`) AS qty FROM `tb_prod_claim_return_det` retd
	                    INNER JOIN `tb_prod_claim_return` ret ON ret.`id_prod_claim_return`=retd.`id_prod_claim_return`
	                    WHERE ret.`id_report_status`='6'
	                    GROUP BY retd.`id_prod_order_det`
                    ) qty_claim ON qty_claim.id_prod_order_det=pod.id_prod_order_det "
        query += "LEFT JOIN (
	                    SELECT * FROM (
		                    SELECT * FROM tb_prod_order_ko_det
		                    ORDER BY id_prod_order_ko_det DESC
	                    )ko GROUP BY ko.id_prod_order
                    ) ko ON ko.id_prod_order=a.id_prod_order "
        query += "LEFT JOIN (
	                    SELECT * FROM (
		                    SELECT * FROM tb_prod_order_kp_det
		                    ORDER BY id_prod_order_kp_det DESC
	                    )kp GROUP BY kp.id_prod_order
                    ) kp ON kp.id_prod_order=a.id_prod_order "
        query += "LEFT JOIN
                 (SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
                    FROM tb_report_mark mark
                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
                    INNER JOIN 
                    (
	                    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	                    FROM tb_report_mark mark
	                    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='22'
	                    GROUP BY report_mark_type,id_report
                    ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
                    WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='22'
                  ) maxd ON maxd.id_report = a.id_prod_order "
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
        check_but()
    End Sub

    Private Sub GVProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        no_focus_gv(sender, e)
    End Sub

    '=== prod demand ====
    'View Production Demand
    Sub viewProdDemand()
        Dim status_pd As String = SLEStatusPD.EditValue.ToString

        Dim query As String = "CALL view_design_demand_po(" & status_pd & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        If data.Rows.Count > 0 Then
            GVDesign.FocusedRowHandle = 0
            view_prod_demand_product()
        End If
        check_but()
    End Sub
    Sub view_prod_demand_product()
        Dim id_pdd As String = ""
        If GVDesign.RowCount > 0 Then
            id_pdd = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString()
        End If
        Dim query As String = "CALL view_prod_demand_product('" + id_pdd + "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
    End Sub

    Private Sub XTCTabProduction_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabProduction.SelectedPageChanged
        check_but()
    End Sub
    Sub check_but()
        If XTCTabProduction.SelectedTabPageIndex = 0 Then
            If GVProd.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XTCTabProduction.SelectedTabPageIndex = 1 Then
            If GVDesign.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVDesign_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDesign.RowClick
        view_prod_demand_product()
    End Sub

    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        Try
            view_prod_demand_product()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Cursor = Cursors.WaitCursor
        view_production_order()
        Cursor = Cursors.Default
    End Sub

    Private Sub BViewWO_Click(sender As Object, e As EventArgs) Handles BViewWO.Click
        view_wo()
    End Sub

    Sub view_wo()
        Dim query_where As String = ""

        If Not SLEDesignWO.EditValue.ToString = "0" Then
            query_where += " AND mdesg.id_design='" & SLEDesignWO.EditValue.ToString & "'"
        End If

        If Not SLESeasonWO.EditValue.ToString = "-1" Then
            query_where += " AND ssn.id_season='" & SLESeasonWO.EditValue.ToString & "'"
        End If

        Dim query = "SELECT po.id_prod_order,po.prod_order_number,mdesg.design_display_name,mdesg.design_code,a.id_report_status,h.report_status,a.id_prod_order_wo,a.id_ovh_price "
        query += ",(SELECT IFNULL(MAX(prod_order_wo_prog_percent),0) FROM tb_prod_order_wo_prog WHERE id_prod_order_wo = a.id_prod_order_wo) as progress,"
        query += "g.payment,a.is_main_vendor, "
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
        query += "a.prod_order_wo_date, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL a.prod_order_wo_lead_time DAY) AS prod_order_wo_lead_time, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL (a.prod_order_wo_top+a.prod_order_wo_lead_time) DAY) AS prod_order_wo_top "
        query += ",IF(ISNULL(mark.id_mark),'no','yes') AS is_submit,maxd.employee_name as last_mark "
        query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
        '
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order=a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pdd On po.id_prod_demand_design = pdd.id_prod_demand_design "
        query += "INNER JOIN tb_m_design mdesg On mdesg.id_design = pdd.id_design "
        query += "INNER JOIN tb_season_delivery sd On sd.id_delivery=pdd.id_delivery "
        query += "INNER JOIN tb_season ssn On ssn.id_season=sd.id_season "
        '
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        query += "LEFT JOIN 
                    (
	                    SELECT * FROM tb_report_mark WHERE report_mark_type='23' GROUP BY report_mark_type,id_report
                    ) mark ON mark.id_report=a.id_prod_order_wo AND mark.report_mark_type='23' "
        '
        query += "LEFT JOIN
                 (SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
                    FROM tb_report_mark mark
                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
                    INNER JOIN 
                    (
	                    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	                    FROM tb_report_mark mark
	                    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='23'
	                    GROUP BY report_mark_type,id_report
                    ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
                    WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='23'
                  ) maxd ON maxd.id_report = a.id_prod_order_wo "
        query += "WHERE 1=1 " & query_where

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdWO.DataSource = data
        GVProdWO.BestFitColumns()
        '
        If GVProdWO.RowCount > 0 Then
            BEditWO.Visible = True
        Else
            BEditWO.Visible = False
        End If
    End Sub

    Private Sub BViewMRS_Click(sender As Object, e As EventArgs) Handles BViewMRS.Click
        view_mrs()
    End Sub

    Sub view_mrs()
        Dim query_where As String = ""

        If Not SLEDesignMRS.EditValue.ToString = "0" Then
            query_where += " AND mdesg.id_design='" & SLEDesignMRS.EditValue.ToString & "'"
        End If

        If Not SLESeasonMRS.EditValue.ToString = "-1" Then
            query_where += " AND ssn.id_season='" & SLESeasonMRS.EditValue.ToString & "'"
        End If

        Dim query = "SELECT po.id_prod_order,po.prod_order_number,mdesg.design_display_name,mdesg.design_code,a.id_prod_order_mrs,a.prod_order_mrs_number,a.id_report_status,h.report_status,a.id_prod_order_wo,b.prod_order_wo_number, "
        query += "d.comp_name AS comp_name_req_from,c.id_comp_contact AS id_comp_name_req_from, "
        query += "f.comp_name AS comp_name_req_to,e.id_comp_contact AS id_comp_name_req_to, "
        query += "a.prod_order_mrs_date "
        query += ",IF(ISNULL(mark.id_mark),'no','yes') AS is_submit,maxd.employee_name as last_mark "
        query += "FROM tb_prod_order_mrs a "
        query += "LEFT JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
        '
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order=a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pdd On po.id_prod_demand_design = pdd.id_prod_demand_design "
        query += "INNER JOIN tb_m_design mdesg On mdesg.id_design = pdd.id_design "
        query += "INNER JOIN tb_season_delivery sd On sd.id_delivery=pdd.id_delivery "
        query += "INNER JOIN tb_season ssn On ssn.id_season=sd.id_season "
        '
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_req_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_req_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "LEFT JOIN 
                    (
	                    SELECT * FROM tb_report_mark GROUP BY report_mark_type,id_report
                    ) mark ON mark.id_report=a.id_prod_order_mrs AND mark.report_mark_type='29' "
        '
        query += "LEFT JOIN
                 (SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
                    FROM tb_report_mark mark
                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
                    INNER JOIN 
                    (
	                    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	                    FROM tb_report_mark mark
	                    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='29'
	                    GROUP BY report_mark_type,id_report
                    ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
                    WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='29'
                  ) maxd ON maxd.id_report = a.id_prod_order_mrs "
        query += "WHERE 1=1 " & query_where

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMRS.DataSource = data
        GVMRS.BestFitColumns()
        '
        If GVMRS.RowCount > 0 Then
            BEditMRS.Visible = True
        Else
            BEditMRS.Visible = False
        End If
    End Sub

    Private Sub BEditMRS_Click(sender As Object, e As EventArgs) Handles BEditMRS.Click
        edit_mrs()
    End Sub

    Private Sub BEditWO_Click(sender As Object, e As EventArgs) Handles BEditWO.Click
        edit_wo()
    End Sub
    Sub edit_wo()
        FormProductionWO.id_wo = GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
        FormProductionWO.id_po = GVProdWO.GetFocusedRowCellValue("id_prod_order").ToString
        FormProductionWO.ShowDialog()
    End Sub

    Sub edit_mrs()
        FormProductionMRS.id_prod_order = GVMRS.GetFocusedRowCellValue("id_prod_order").ToString
        FormProductionMRS.id_mrs = GVMRS.GetFocusedRowCellValue("id_prod_order_mrs").ToString
        FormProductionMRS.id_comp_req_from = GVMRS.GetFocusedRowCellValue("id_comp_name_req_from").ToString
        FormProductionMRS.id_comp_req_to = GVMRS.GetFocusedRowCellValue("id_comp_name_req_to").ToString
        FormProductionMRS.TEMRSNumber.Text = GVMRS.GetFocusedRowCellValue("prod_order_mrs_number").ToString
        FormProductionMRS.TEWONumber.Text = GVMRS.GetFocusedRowCellValue("prod_order_wo_number").ToString
        FormProductionMRS.TEPONumber.Text = GVMRS.GetFocusedRowCellValue("prod_order_number").ToString
        FormProductionMRS.TEDesign.Text = GVMRS.GetFocusedRowCellValue("design_display_name").ToString
        FormProductionMRS.TEDesignCode.Text = GVMRS.GetFocusedRowCellValue("design_code").ToString
        FormProductionMRS.ShowDialog()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewProdDemand()
    End Sub

    Private Sub GVProd_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVProd.RowStyle
        Try
            If GVProd.GetRowCellValue(e.RowHandle, "id_report_status").ToString = "5" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.ForeColor = Color.Red
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVDesign_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVDesign.RowStyle
        Try
            If GVDesign.GetRowCellValue(e.RowHandle, "id_lookup_status_order").ToString = "2" Or GVProd.GetRowCellValue(e.RowHandle, "jml_pdo") > 0 Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.ForeColor = Color.Red
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BShowPrintPanel_Click(sender As Object, e As EventArgs) Handles BShowPrintPanel.Click
        PCFilterDate.Visible = True
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        GVProd.ActiveFilterString = "[is_check]='yes'"
        Dim is_approved As Boolean = True
        For i As Integer = 0 To GVProd.RowCount - 1 - GetGroupRowCount(GVProd)
            'If GVProd.GetRowCellValue(i, "id_report_status").ToString = "1" Or GVProd.GetRowCellValue(i, "id_report_status").ToString = "5" Then
            '    is_approved = False
            'End If
            If Not check_allow_print(GVProd.GetRowCellValue(i, "id_report_status").ToString, "22", GVProd.GetRowCellValue(i, "id_prod_order").ToString) Then
                is_approved = False
            End If
        Next
        GVProd.ActiveFilterString = ""

        If is_approved = True Then
            FormProductionPrint.dt = GCProd.DataSource
            FormProductionPrint.is_report_view = False
            FormProductionPrint.GVProd.ActiveFilterString = "[is_check]='yes'"
            FormProductionPrint.ShowDialog()
        Else
            warningCustom("Please complete approval on PO first before create summary.")
        End If
    End Sub

    Private Sub BFilter_Click(sender As Object, e As EventArgs) Handles BFilter.Click
        GVProd.ActiveFilterString = "[prod_order_date] >= #" & Date.Parse(DEStart.EditValue.ToString).ToString("d") & "# AND [prod_order_date] <= #" & Date.Parse(DEEnd.EditValue.ToString).ToString("d") & "#"
    End Sub

    Private Sub BClearFilter_Click(sender As Object, e As EventArgs) Handles BClearFilter.Click
        GVProd.ActiveFilterString = ""
    End Sub

    Private Sub BPrintPD_Click(sender As Object, e As EventArgs) Handles BPrintPD.Click
        Cursor = Cursors.WaitCursor
        Try
            FormViewProdDemand.id_prod_demand = GVDesign.GetFocusedRowCellValue("id_prod_demand")
            FormViewProdDemand.is_for_production = True
            FormViewProdDemand.ShowDialog()
        Catch ex As Exception
            stopCustom("Please select PD first")
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVProd.RowCount > 0 Then
            For i As Integer = 0 To ((GVProd.RowCount - 1) - GetGroupRowCount(GVProd))
                If CheckEditSelAll.Checked = False Then
                    GVProd.SetRowCellValue(i, "is_check", "no")
                Else
                    GVProd.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Private Sub BViewKO_Click(sender As Object, e As EventArgs) Handles BViewKO.Click
        Dim query_where As String = ""
        '
        If Not SLEVendorKO.EditValue.ToString = "0" Then
            query_where += " AND c.id_comp='" & SLEVendorKO.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "SELECT ko.*,IF(ko.is_void='1','Void','-') AS status,c.`comp_name` ,GROUP_CONCAT(dsg.design_code,' - ',dsg.design_display_name SEPARATOR '\n') AS design_list
FROM tb_prod_order_ko ko
INNER JOIN tb_prod_order_ko_det kod ON kod.id_prod_order_ko=ko.id_prod_order_ko
INNER JOIN tb_prod_order po ON po.id_prod_order=kod.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ko.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE ko.id_prod_order_ko 
IN (SELECT MAX(id_prod_order_ko) AS id FROM `tb_prod_order_ko`
GROUP BY id_prod_order_ko_reff) AND is_purc_mat=2 " & query_where & " GROUP BY ko.id_prod_order_ko ORDER BY ko.id_prod_order_ko DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCKO.DataSource = data
        If GVKO.RowCount > 0 Then
            BEditKO.Visible = True
        Else
            BEditKO.Visible = False
        End If
        GVKO.BestFitColumns()
    End Sub
    Sub viewVendorKO()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendorKO, query, "id_comp", "comp_name_label", "id_comp")
        viewSearchLookupQuery(SLEVendorKP, query, "id_comp", "comp_name_label", "id_comp")
        viewSearchLookupQuery(SLEVendorCopyProto2, query, "id_comp", "comp_name_label", "id_comp")
    End Sub

    Sub view_ko()
        FormProductionKO.id_ko = GVKO.GetFocusedRowCellValue("id_prod_order_ko").ToString
        FormProductionKO.ShowDialog()
    End Sub

    Private Sub BEditKO_Click(sender As Object, e As EventArgs) Handles BEditKO.Click
        view_ko()
    End Sub

    Private Sub BViewKP_Click(sender As Object, e As EventArgs) Handles BViewKP.Click
        Dim query_where As String = ""
        '
        If Not SLEVendorKP.EditValue.ToString = "0" Then
            query_where += " AND c.id_comp='" & SLEVendorKP.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "SELECT kp.*,IF(kp.is_void='1','Void','-') AS status,c.`comp_name` ,GROUP_CONCAT(dsg.design_code,' - ',dsg.design_display_name SEPARATOR '\n') AS design_list
FROM tb_prod_order_kp kp
INNER JOIN tb_prod_order_kp_det kpd ON kpd.id_prod_order_kp=kp.id_prod_order_kp
INNER JOIN tb_prod_order po ON po.id_prod_order=kpd.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=kp.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE kp.id_prod_order_kp 
IN (SELECT MAX(id_prod_order_kp) AS id FROM `tb_prod_order_kp` GROUP BY id_prod_order_kp_reff ) 
AND is_purc_mat=2 " & query_where & "
GROUP BY kp.id_prod_order_kp
ORDER BY kp.id_prod_order_kp DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCKP.DataSource = data
        If GVKP.RowCount > 0 Then
            BEditKP.Visible = True
        Else
            BEditKP.Visible = False
        End If
        GVKP.BestFitColumns()
    End Sub

    Sub view_kp()
        FormProductionKP.id_kp = GVKP.GetFocusedRowCellValue("id_prod_order_kp").ToString
        FormProductionKP.ShowDialog()
    End Sub

    Private Sub BEditKP_Click(sender As Object, e As EventArgs) Handles BEditKP.Click
        view_kp()
    End Sub

    Private Sub BSearchCopyProto2_Click(sender As Object, e As EventArgs) Handles BSearchCopyProto2.Click
        Dim query_where As String = ""
        '
        If Not SLEVendorCopyProto2.EditValue.ToString = "0" Then
            query_where += " AND c.id_comp='" & SLEVendorCopyProto2.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "SELECT kp.*,IF(kp.is_void='1','Void','-') AS status,c.`comp_name` FROM tb_prod_order_cps2 kp
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=kp.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE kp.id_prod_order_cps2 
IN (SELECT MAX(id_prod_order_cps2) AS id FROM `tb_prod_order_cps2`
GROUP BY id_prod_order_cps2_reff) AND is_purc_mat=2 " & query_where & " ORDER BY kp.id_prod_order_cps2 DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCopyProto2.DataSource = data
        If GVCopyProto2.RowCount > 0 Then
            BEditCopyProto2.Visible = True
        Else
            BEditCopyProto2.Visible = False
        End If
        GVCopyProto2.BestFitColumns()
    End Sub

    Sub view_cps2()
        FormProductionSampleOrder.id = GVCopyProto2.GetFocusedRowCellValue("id_prod_order_cps2").ToString
        FormProductionSampleOrder.ShowDialog()
    End Sub

    Private Sub BEditCopyProto2_Click(sender As Object, e As EventArgs) Handles BEditCopyProto2.Click
        view_cps2()
    End Sub

    Private Sub ViewReceivingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewReceivingToolStripMenuItem.Click
        FormPopUpProdRec.id_po = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
        FormPopUpProdRec.ShowDialog()
    End Sub

    Private Sub BReportView_Click(sender As Object, e As EventArgs) Handles BReportView.Click
        'GVProd.ActiveFilterString = "[is_check]='yes' AND "
        'Dim is_approved As Boolean = True
        'For i As Integer = 0 To GVProd.RowCount - 1 - GetGroupRowCount(GVProd)
        '    'If GVProd.GetRowCellValue(i, "id_report_status").ToString = "1" Or GVProd.GetRowCellValue(i, "id_report_status").ToString = "5" Then
        '    '    is_approved = False
        '    'End If
        '    If Not check_allow_print(GVProd.GetRowCellValue(i, "id_report_status").ToString, "22", GVProd.GetRowCellValue(i, "id_prod_order").ToString) Then
        '        is_approved = False
        '    End If
        'Next
        'GVProd.ActiveFilterString = ""

        'If is_approved = True Then
        '    FormProductionPrint.dt = GCProd.DataSource
        '    FormProductionPrint.GVProd.ActiveFilterString = "[is_check]='yes'"
        '    FormProductionPrint.ShowDialog()
        'Else
        '    warningCustom("Please complete approval on PO first before create summary.")
        'End If

        FormProductionPrint.dt = GCProd.DataSource
        Dim dr As DataRow() = FormProductionPrint.dt.Select(GVProd.ActiveFilterString)
        FormProductionPrint.dt = dr.CopyToDataTable
        FormProductionPrint.is_report_view = True
        FormProductionPrint.ShowDialog()
    End Sub
End Class