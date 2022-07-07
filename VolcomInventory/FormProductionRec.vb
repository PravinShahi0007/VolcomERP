﻿Public Class FormProductionRec 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"
    Dim product_image_path As String = get_setup_field("pic_path_product") & "\"

    Public is_ho_target As String = "-1"

    Private Sub FormProductionRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now

        view_comp()
        view_prod_order()
        '
        viewSeason()
        check_menu()
        '
        If is_ho_target = "1" Then
            PCUpdateHO.Visible = True
        Else
            PCUpdateHO.Visible = False
        End If
    End Sub

    Sub view_comp()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' AS season,'-1' AS `range` UNION
                                (SELECT a.id_season,a.season,b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLESeasonByCode, query, "range", "season", "range")
    End Sub

    Sub showMyToolHint()
        ToolTipControllerNew.HideHint()
        ToolTipControllerNew.ShowHint("Double click to see receiving number.", GCListProd, DevExpress.Utils.ToolTipLocation.RightCenter)
    End Sub

    Private Sub FormProductionRec_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProductionRec_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProductionRec_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCTabReceive.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVProdRec.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
            ToolTipControllerNew.HideHint()
        ElseIf XTCTabReceive.SelectedTabPageIndex = 1 Then
            'based on PO
            If GVProd.RowCount < 1 Then
                'hide all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
            showMyToolHint()
        End If
    End Sub


    Sub view_prod_order()
        Dim q_where As String = ""
        If Not SLEVendor.EditValue.ToString = "0" Then
            q_where = " AND wo.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If
        Dim query = "SELECT a.is_block_qc_in,a.is_need_cps2_verify,a.cps2_verify,wo.comp_number,wo.comp_name,wo.id_comp,IFNULL(cd.color,'-') AS color,IFNULL(cd.class,'-') AS class,
NOW() AS date_now,b.id_design,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name,d.design_name , d.design_code, h.term_production, g.po_type, 
DATE_FORMAT(a.prod_order_date,'%d %M %Y') AS prod_order_date,a.id_report_status,c.report_status, 
b.id_delivery, e.delivery, f.season, e.id_season, 
DATE_FORMAT(a.prod_order_date,'%d %M %Y') AS prod_order_date, 
DATE_FORMAT(DATE_ADD(a.prod_order_date,INTERVAL a.prod_order_lead_time DAY),'%d %M %Y') AS prod_order_lead_time, 
(
  SELECT COUNT(tb_prod_order_rec.id_prod_order_rec) FROM tb_prod_order_rec 
  WHERE tb_prod_order_rec.id_prod_order = a.id_prod_order 
  AND tb_prod_order_rec.id_report_status != '5' 
) AS receive_created, 
rec.qty_rec,
wo.qty_po,
DATE_FORMAT(DATE_ADD(a.prod_order_date,INTERVAL a.prod_order_lead_time DAY),'%d %M %Y') AS prod_order_lead_time 
FROM tb_prod_order a 
LEFT JOIN 
(
	SELECT wo.`id_prod_order`,SUM(wod.prod_order_wo_det_qty) AS qty_po,c.`comp_name`,c.`comp_number`,c.`id_comp`
	FROM tb_prod_order_wo_det wod
    INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=wod.id_prod_order_wo
	INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
	INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
	INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	WHERE wo.id_report_status=6 AND wo.`is_main_vendor`=1
	GROUP BY wo.`id_prod_order`
)wo ON wo.id_prod_order=a.`id_prod_order`
LEFT JOIN (
        SELECT rec.`id_prod_order`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec 
        FROM tb_prod_order_rec_det recd
        INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec`
        WHERE rec.id_report_status != '5' 
        GROUP BY rec.`id_prod_order`
)rec ON rec.id_prod_order=a.`id_prod_order`
INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design 
INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status 
INNER JOIN tb_m_design d ON b.id_design = d.id_design 
INNER JOIN tb_season s ON s.id_season=d.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
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
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = d.id_design
INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery 
INNER JOIN tb_season f ON f.id_season=e.id_season 
INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type 
INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production 
WHERE (a.id_report_status = '6') AND is_closing_rec=2 " & q_where & " ORDER BY a.id_prod_order ASC "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data
        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            view_list_prod(GVProd.GetFocusedRowCellValue("id_prod_order"))
        End If
        check_menu()
    End Sub

    Sub view_list_prod(ByVal id_prod_order As String)
        Dim query = "CALL view_prod_order_det('" & id_prod_order & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProd.DataSource = data
    End Sub

    Private Sub XTCTabReceive_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabReceive.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        'Dim focusedRowHandle As Integer = -1
        'If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
        '    Return
        'End If
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'If e.FocusedRowHandle < 0 Then
        '    If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
        '        focusedRowHandle = 0
        '    ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
        '        focusedRowHandle = e.PrevFocusedRowHandle
        '    Else
        '        Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
        '        Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
        '        If prevRow > currRow Then
        '            focusedRowHandle = e.PrevFocusedRowHandle - 1
        '        Else
        '            focusedRowHandle = e.PrevFocusedRowHandle + 1
        '        End If
        '        If focusedRowHandle < 0 Then
        '            focusedRowHandle = 0
        '        End If
        '        If focusedRowHandle >= view.DataRowCount Then
        '            focusedRowHandle = view.DataRowCount - 1
        '        End If
        '    End If
        '    If focusedRowHandle < 0 Then
        '        view.FocusedRowHandle = 0
        '    Else
        '        view.FocusedRowHandle = focusedRowHandle
        '    End If
        'End If
        'Dim id_pod As String = "0"
        'Try
        '    id_pod = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
        'Catch ex As Exception
        'End Try
        'If id_pod = "" Then
        '    id_pod = "0"
        'End If
        If GVProd.RowCount > 0 And GVProd.FocusedRowHandle >= 0 Then
            view_list_prod(GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
            showMyToolHint()
        Else
            GCListProd.DataSource = Nothing
        End If
    End Sub

    Private Sub GVProd_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProd.DoubleClick
        If GVProd.RowCount > 0 Then
            'GVProdRec.ApplyFindFilter(GVProd.GetFocusedRowCellValue("prod_order_number").ToString)
            'XTCTabReceive.SelectedTabPageIndex = 0
            'check_menu()
            FormProductionDet.is_no_cost = "1"
            FormProductionDet.id_prod_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
            FormProductionDet.ShowDialog()
        End If
    End Sub

    Private Sub GVProd_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVProd.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_rec As Date

        If e.Column.FieldName = "prod_order_lead_time" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_rec = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("prod_order_lead_time")))
            'And View.GetRowCellDisplayText(e.RowHandle, View.Columns("qty_receive")) <= 0
            If date_now > date_rec Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
    End Sub

    Private Sub GVProd_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProd.RowClick

    End Sub


    Private Sub GVProd_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProd.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVProd.IsGroupRow(rowhandle) Then
                rowhandle = GVProd.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVProd.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVProd.IsGroupRow(rowhandle) Then
                rowhandle = GVProd.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVProd.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub

    Private Sub GCListProd_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCListProd.MouseHover
       
    End Sub

    Private Sub GVListProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVListProd.FocusedRowChanged
        showMyToolHint()
    End Sub

    Private Sub GVListProd_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProd.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVListProd_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVListProd.DoubleClick
        Cursor = Cursors.WaitCursor
        Try
            Dim id_prod_order_det As String = GVListProd.GetFocusedRowCellValue("id_prod_order_det").ToString
            Dim query As String = "SELECT b.prod_order_rec_number FROM tb_prod_order_rec_det a "
            query += "INNER JOIN tb_prod_order_rec b ON a.id_prod_order_rec = b.id_prod_order_rec "
            query += "WHERE a.id_prod_order_det = '" + id_prod_order_det + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim filter_str As String = ""
            For i As Integer = 0 To (data.Rows.Count - 1)
                If i > 0 Then
                    filter_str += "OR "
                End If
                filter_str += "[prod_order_rec_number] = '" + toDoubleQuote(data.Rows(i)("prod_order_rec_number").ToString) + "' "
            Next
            GVProdRec.ApplyFindFilter("")
            GVProdRec.ActiveFilterString = filter_str
            XTCTabReceive.SelectedTabPageIndex = 0
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdRec_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdRec.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVProdRec.RowCount > 0 And GVProdRec.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdRec_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdRec.FocusedRowChanged
        noManipulating()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVProdRec.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_prod_order_rec()
    End Sub

    Sub view_prod_order_rec()
        Dim query_where As String = ""
        '
        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " WHERE g.id_season='" & SLESeason.EditValue.ToString & "'"
        End If
        '
        Dim query = "SELECT a.id_report_status,h.report_status, g.id_season,g.season,a.id_prod_order_rec,a.prod_order_rec_number, "
        query += "(a.delivery_order_date) AS delivery_order_date,a.delivery_order_number, a.arrive_date,b.prod_order_number, "
        query += "(a.prod_order_rec_date) AS prod_order_rec_date, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_from, CONCAT(d.comp_number,' - ',d.comp_name) AS comp_to, dsg.design_code AS `code`
, CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS name
, SUM(ad.prod_order_rec_det_qty) AS `qty`, po_type.po_type "
        query += ",DATE_ADD(IFNULL(wo.prod_order_wo_del_date,b.prod_order_date), INTERVAL IF(ISNULL(ko.lead_time_prod),IFNULL(wo.prod_order_wo_lead_time,0),ko.lead_time_prod) DAY) AS est_qc_date
,DATEDIFF(DATE_ADD(IFNULL(wo.prod_order_wo_del_date,b.prod_order_date), INTERVAL IF(ISNULL(ko.lead_time_prod),IFNULL(wo.prod_order_wo_lead_time,0),ko.lead_time_prod) DAY), a.arrive_date) AS diff_day "
        query += "FROM tb_prod_order_rec a  "
        query += "INNER JOIN tb_prod_order_rec_det ad ON ad.id_prod_order_rec = a.id_prod_order_rec "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_from  "
        query += "INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp "
        query += "INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season = i.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
        query += "
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
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
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
"
        query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
        query += "LEFT JOIN 
( 
    SELECT id_prod_order,prod_order_wo_lead_time,prod_order_wo_del_date
    FROM tb_prod_order_wo
    WHERE id_report_status=6 AND is_main_vendor=1
) wo ON wo.id_prod_order=b.id_prod_order "
        query += "LEFT JOIN (
                    SELECT kod.* FROM 
                    tb_prod_order_ko_det kod
                    INNER JOIN(
                        SELECT id_prod_order,MAX(id_prod_order_ko_det) AS id_prod_order_ko_det
                        FROM tb_prod_order_ko_det kod
                        INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order)
                        GROUP BY id_prod_order
                    )ko ON ko.id_prod_order_ko_det=kod.id_prod_order_ko_det
                ) ko ON ko.id_prod_order=a.id_prod_order "
        query += query_where
        query += "GROUP BY a.id_prod_order_rec "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdRec.FocusedRowHandle = 0
        End If
        check_menu()
        GVProdRec.ExpandAllGroups()
    End Sub

    Private Sub BSearchByCode_Click(sender As Object, e As EventArgs) Handles BSearchByCode.Click
        Dim query_where As String = ""
        '
        If Not SLESeasonByCode.EditValue.ToString = "-1" Then
            query_where += " WHERE RIGHT(dsg.design_code,2)='" & SLESeasonByCode.EditValue.ToString & "'"
        End If
        '
        Dim query = "SELECT a.id_report_status,h.report_status, g.id_season,g.season,a.id_prod_order_rec,a.prod_order_rec_number, "
        query += "(a.delivery_order_date) AS delivery_order_date,a.delivery_order_number, a.arrive_date,b.prod_order_number, "
        query += "(a.prod_order_rec_date) AS prod_order_rec_date, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_from, CONCAT(d.comp_number,' - ',d.comp_name) AS comp_to, dsg.design_code AS `code`,(dsg.design_display_name) AS name, SUM(ad.prod_order_rec_det_qty) AS `qty`, po_type.po_type "
        query += ",DATE_ADD(IFNULL(wo.prod_order_wo_del_date,b.prod_order_date), INTERVAL IF(ISNULL(ko.lead_time_prod),IFNULL(wo.prod_order_wo_lead_time,0),ko.lead_time_prod) DAY) AS est_qc_date
,DATEDIFF(DATE_ADD(IFNULL(wo.prod_order_wo_del_date,b.prod_order_date), INTERVAL IF(ISNULL(ko.lead_time_prod),IFNULL(wo.prod_order_wo_lead_time,0),ko.lead_time_prod) DAY), a.arrive_date) AS diff_day "
        query += "FROM tb_prod_order_rec a  "
        query += "INNER JOIN tb_prod_order_rec_det ad ON ad.id_prod_order_rec = a.id_prod_order_rec "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_from  "
        query += "INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp "
        query += "INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season = i.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
        query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
        query += "LEFT JOIN 
( 
    SELECT id_prod_order,prod_order_wo_lead_time,prod_order_wo_del_date
    FROM tb_prod_order_wo
    WHERE id_report_status=6 AND is_main_vendor=1
) wo ON wo.id_prod_order=b.id_prod_order "
        query += "LEFT JOIN (
                    SELECT kod.* FROM 
                    tb_prod_order_ko_det kod
                    INNER JOIN(
                        SELECT id_prod_order,MAX(id_prod_order_ko_det) AS id_prod_order_ko_det
                        FROM tb_prod_order_ko_det kod
                        INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order)
                        GROUP BY id_prod_order
                    )ko ON ko.id_prod_order_ko_det=kod.id_prod_order_ko_det
                ) ko ON ko.id_prod_order=a.id_prod_order "
        query += query_where
        query += "GROUP BY a.id_prod_order_rec "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdRec.FocusedRowHandle = 0
        End If
        check_menu()
        GVProdRec.ExpandAllGroups()
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        If GVProdRec.RowCount > 0 Then
            FormProductionRecTargetHO.id_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
            FormProductionRecTargetHO.ShowDialog()
        End If
    End Sub

    Private Sub GVProdRec_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVProdRec.RowStyle
        Try
            If GVProdRec.GetRowCellValue(e.RowHandle, "diff_day").ToString < 0 Then
                e.Appearance.BackColor = Color.Crimson
                e.Appearance.ForeColor = Color.White
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BViewRec_Click(sender As Object, e As EventArgs) Handles BViewRec.Click
        view_prod_order()
        GVProd.BestFitColumns()
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        Try
            DEStart.Properties.MaxValue = DEUntil.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Dim query_where As String = " WHERE DATE(a.prod_order_rec_date)>=DATE('" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(a.prod_order_rec_date)<=DATE('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "') "
        '
        Dim query = "SELECT a.id_report_status,h.report_status, g.id_season,g.season,a.id_prod_order_rec,a.prod_order_rec_number, "
        query += "(a.delivery_order_date) AS delivery_order_date,a.delivery_order_number, a.arrive_date,b.prod_order_number, "
        query += "(a.prod_order_rec_date) AS prod_order_rec_date, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_from, CONCAT(d.comp_number,' - ',d.comp_name) AS comp_to, dsg.design_code AS `code`,(dsg.design_display_name) AS name, SUM(ad.prod_order_rec_det_qty) AS `qty`, po_type.po_type "
        query += ",DATE_ADD(IFNULL(wo.prod_order_wo_del_date,b.prod_order_date), INTERVAL IF(ISNULL(ko.lead_time_prod),IFNULL(wo.prod_order_wo_lead_time,0),ko.lead_time_prod) DAY) AS est_qc_date
,DATEDIFF(DATE_ADD(IFNULL(wo.prod_order_wo_del_date,b.prod_order_date), INTERVAL IF(ISNULL(ko.lead_time_prod),IFNULL(wo.prod_order_wo_lead_time,0),ko.lead_time_prod) DAY), a.arrive_date) AS diff_day "
        query += "FROM tb_prod_order_rec a  "
        query += "INNER JOIN tb_prod_order_rec_det ad ON ad.id_prod_order_rec = a.id_prod_order_rec "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_from  "
        query += "INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp "
        query += "INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season = i.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
        query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
        query += "LEFT JOIN 
( 
    SELECT id_prod_order,prod_order_wo_lead_time,prod_order_wo_del_date
    FROM tb_prod_order_wo
    WHERE id_report_status=6 AND is_main_vendor=1
) wo ON wo.id_prod_order=b.id_prod_order "
        query += "LEFT JOIN (
                    SELECT kod.* FROM 
                    tb_prod_order_ko_det kod
                    INNER JOIN(
                        SELECT id_prod_order,MAX(id_prod_order_ko_det) AS id_prod_order_ko_det
                        FROM tb_prod_order_ko_det kod
                        INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order)
                        GROUP BY id_prod_order
                    )ko ON ko.id_prod_order_ko_det=kod.id_prod_order_ko_det
                ) ko ON ko.id_prod_order=a.id_prod_order "
        query += query_where
        query += "GROUP BY a.id_prod_order_rec "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdRec.FocusedRowHandle = 0
        End If
        check_menu()
        GVProdRec.ExpandAllGroups()
    End Sub

    Private Sub BNewTimbang_Click(sender As Object, e As EventArgs) Handles BNewTimbang.Click
        FormProductWeight.ShowDialog()
    End Sub

    Sub load_weight_pps()
        Dim q As String = "SELECT pps.`created_date`,pps.`id_product_weight_pps`,pps.`number`,pps.`note`,emp.`employee_name`,sts.report_status,GROUP_CONCAT(DISTINCT dsg.design_display_name) AS design_name
FROM `tb_product_weight_pps` pps
INNER JOIN tb_product_weight_pps_det ppsd ON ppsd.id_product_weight_pps=pps.id_product_weight_pps
INNER JOIN tb_m_product p ON p.id_product=ppsd.id_product
INNER JOIN tb_m_design dsg ON dsg.id_design=p.id_design
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
GROUP BY pps.id_product_weight_pps
ORDER BY pps.id_product_weight_pps DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCTimbang.DataSource = dt
        GVTimbang.BestFitColumns()
    End Sub

    Private Sub BRefreshDisp_Click(sender As Object, e As EventArgs) Handles BRefreshDisp.Click
        load_weight_pps()
    End Sub

    Private Sub GVTimbang_DoubleClick(sender As Object, e As EventArgs) Handles GVTimbang.DoubleClick
        If GVTimbang.RowCount > 0 Then
            FormProductWeight.id_trans = GVTimbang.GetFocusedRowCellValue("id_product_weight_pps").ToString
            FormProductWeight.ShowDialog()
        End If
    End Sub
End Class