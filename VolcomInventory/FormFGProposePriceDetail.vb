Public Class FormFGProposePriceDetail
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Public id_division As String = "-1"
    Public id_source As String = "-1"
    Dim rmt As String = "70"


    Private Sub FormFGProposePriceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSeason()
        viewPriceType()
        actionLoad()
    End Sub

    Sub viewPriceType()
        Dim query As String = "SELECT * FROM tb_lookup_design_price_type a ORDER BY a.id_design_price_type "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPriceType, query, 0, "design_price_type", "id_design_price_type")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub


    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'main
        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim query As String = query_c.queryMain("AND tb_fg_propose_price.id_fg_propose_price=''" + id + "'' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("fg_propose_price_number").ToString
        MENote.Text = data.Rows(0)("fg_propose_price_note").ToString
        DECreated.EditValue = data.Rows(0)("fg_propose_price_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        SLESeason.EditValue = data.Rows(0)("id_season").ToString
        id_division = data.Rows(0)("id_division").ToString
        id_source = data.Rows(0)("id_source").ToString
        TxtSource.Text = data.Rows(0)("source").ToString
        LEPriceType.EditValue = data.Rows(0)("id_design_price_type").ToString
        If data.Rows(0)("is_print").ToString = "1" Then
            CEIsPrint.EditValue = True
        Else
            CEIsPrint.EditValue = False
        End If

        'detail
        viewDetail()
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 'No' AS `is_select`, 0 AS `no`,ppd.id_fg_propose_price_detail, ppd.id_fg_propose_price, 
        ppd.id_design, d.design_code, d.design_code_import, del.id_delivery, del.delivery, d.id_season_orign, ss_org.season_orign, ctr.id_country, ctr.country,
        src.id_src, src.src AS `source`,cls.id_class, cls.class, d.design_display_name, col.id_color, col.color, sc.size_chart, 
        DATE_FORMAT(d.design_eos,'%Y%m') AS `eos_date`, rc.ret_code, DATE_FORMAT(rc.ret_date, '%Y%m') AS `ret_date`, PERIOD_DIFF(DATE_FORMAT(rc.ret_date, '%Y%m'),DATE_FORMAT(del.delivery_date, '%Y%m')) AS `age`,
        ppd.id_prod_demand_design, po.id_prod_order,po.prod_order_number, po.vendor, po.qty AS `qty_po`, rec.qty AS `qty_rec`, IF(ppd.id_cop_status=1,po.qty, rec.qty) AS `qty`,
        ppd.id_cop_status, ppd.msrp, ppd.additional_cost, 
        IF(ppd.cop_rate_cat=1,'BOM', 'Payment') AS `rate_type`,ppd.cop_rate_cat, ppd.cop_kurs, ppd.cop_value, (ppd.cop_value - ppd.additional_cost) AS `cop_value_min_add`,
        ppd.cop_mng_kurs, ppd.cop_mng_value, (ppd.cop_mng_value - ppd.additional_cost) AS `cop_mng_value_min_add`,
        ppd.price, ppd.additional_price, ppd.cop_date,
        ppd.remark 
        FROM tb_fg_propose_price_detail ppd
        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        INNER JOIN tb_season_delivery del ON del.id_delivery = d.id_delivery
        INNER JOIN tb_season_orign ss_org ON ss_org.id_season_orign = d.id_season_orign
        INNER JOIN tb_m_country ctr ON ctr.id_country = ss_org.id_country
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_src`, cls.display_name AS `src` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=5
          GROUP BY d.id_design
        ) src ON src.id_design = d.id_design
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
          GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_color`, cls.display_name AS `color` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=14
          GROUP BY d.id_design
        ) col ON col.id_design = d.id_design
        LEFT JOIN (
	        SELECT pdp.id_prod_demand_design, GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`
	        FROM tb_prod_demand_product pdp
	        INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
	        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
	        GROUP BY pdp.id_prod_demand_design
        ) sc ON sc.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN (
	        SELECT po.id_prod_demand_design,po.id_prod_order,po.prod_order_number, c.comp_name AS `vendor`, SUM(pod.prod_order_qty) AS `qty`
	        FROM tb_prod_order po
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
	        INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
	        INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price = wo.id_ovh_price
	        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
	        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
	        WHERE po.id_report_status!=5
	        GROUP BY po.id_prod_demand_design
        ) po ON po.id_prod_demand_design = ppd.id_prod_demand_design
        LEFT JOIN (
	        SELECT po.id_prod_demand_design, SUM(recd.prod_order_rec_det_qty) AS `qty`
	        FROM tb_prod_order po
	        INNER JOIN tb_prod_order_rec rec ON rec.id_prod_order = po.id_prod_order
	        INNER JOIN tb_prod_order_rec_det recd ON recd.id_prod_order_rec = rec.id_prod_order_rec
	        WHERE rec.id_report_status=6
	        GROUP BY po.id_prod_demand_design
        ) rec ON rec.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN tb_lookup_ret_code rc ON rc.id_ret_code = d.id_ret_code
        WHERE ppd.id_fg_propose_price=" + id + "
        ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            PanelControlNav.Visible = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            LEPriceType.Enabled = True
            CEIsPrint.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            LEPriceType.Enabled = False
            CEIsPrint.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            LEPriceType.Enabled = False
            CEIsPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGProposePriceSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click

    End Sub

    Private Sub BtnUpdateCOP_Click(sender As Object, e As EventArgs) Handles BtnUpdateCOP.Click

    End Sub

    Private Sub FormFGProposePriceDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_fg_propose_price SET id_report_status=5 WHERE id_fg_propose_price='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormFGProposePrice.viewPropose()
            FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If Not check_allow_print(id_report_status, rmt, id) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            'If XTCRevision.SelectedTabPageIndex = 0 Then
            '    gv = GVRevision
            '    ReportProdDemandRev.dt = GCRevision.DataSource
            '    ReportProdDemandRev.type = "1"
            'ElseIf XTCRevision.SelectedTabPageIndex = 1 Then
            '    gv = GVData
            '    ReportProdDemandRev.dt = GCData.DataSource
            '    ReportProdDemandRev.type = "2"
            'End If
            'ReportProdDemandRev.id = id
            'If id_report_status <> "6" Then
            '    ReportProdDemandRev.is_pre = "1"
            'Else
            '    ReportProdDemandRev.is_pre = "-1"
            'End If
            'ReportProdDemandRev.id_report_status = LEReportStatus.EditValue.ToString

            'ReportProdDemandRev.rmt = rmt
            'Dim Report As New ReportProdDemandRev()

            '... 
            ' creating and saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)

            ''style
            'Report.GVData.OptionsPrint.UsePrintStyles = True
            'Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

            'Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

            'Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


            'Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

            'Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

            'Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

            'Report.GVData.OptionsPrint.ExpandAllDetails = True
            'Report.GVData.OptionsPrint.UsePrintStyles = True
            'Report.GVData.OptionsPrint.PrintDetails = True
            'Report.GVData.OptionsPrint.PrintFooter = True

            'Report.LabelNumber.Text = TxtProdDemandNumber.Text
            'Report.LabelRev.Text = TxtRevision.Text
            'Report.LabelDate.Text = DECreated.Text.ToUpper
            'Report.LabelSeason.Text = season.ToUpper
            'Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
            'Report.LNote.Text = MENote.Text

            '' Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreviewDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'head
            Dim fg_propose_price_note As String = addSlashes(MENote.Text)
            Dim id_design_price_type As String = LEPriceType.EditValue.ToString
            Dim is_print As String = ""
            If CEIsPrint.EditValue = True Then
                is_print = "1"
            Else
                is_print = "2"
            End If
            Dim query_head As String = "UPDATE tb_fg_propose_price SET fg_propose_price_note='" + fg_propose_price_note + "', 
            id_design_price_type='" + id_design_price_type + "',  is_print='" + is_print + "' WHERE id_fg_propose_price='" + id + "' "
            execute_non_query(query_head, True, "", "", "", "")
            actionLoad()
            FormFGProposePrice.viewPropose()
            FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id)
        End If
    End Sub
End Class