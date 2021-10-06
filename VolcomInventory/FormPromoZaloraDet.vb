Public Class FormPromoZaloraDet
    Public id As String = "-1"
    Public action As String = ""
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim id_report_status_recon As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_confirm_recon As String = "-1"
    Dim rmt_propose As String = "351"
    Dim rmt_recon As String = "352"
    Public id_menu As String = "1" '1=>propose; 2=>rekon

    Private Sub FormPromoZaloraDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCPromoZalora.TabPages
            XTCPromoZalora.SelectedTabPage = t
        Next t
        XTCPromoZalora.SelectedTabPage = XTCPromoZalora.TabPages(0)

        viewReportStatus()
        viewType()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewReportStatusRecon()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatusRecon, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewType()
        Dim query As String = "SELECT t.id_promo_zalora_type, t.promo_zalora_type FROM tb_promo_zalora_type t "
        viewLookupQuery(LEType, query, 0, "promo_zalora_type", "id_promo_zalora_type")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        TxtDiscountValue.EditValue = 0.00
        TxtVolcomPros.EditValue = 0.00
        XTPReconcile.PageVisible = False

        If action = "ins" Then
            'option
            BtnCreateNew.Visible = True
            Width = 441
            Height = 294
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControl1.Visible = False
            PanelControlBottom.Visible = False
            'location form
            Dim r As Rectangle
            If Parent IsNot Nothing Then
                r = Parent.RectangleToScreen(Parent.ClientRectangle)
            Else
                r = Screen.FromPoint(Location).WorkingArea
            End If

            Dim x = r.Left + (r.Width - Width) \ 2
            Dim y = r.Top + (r.Height - Height) \ 2
            Location = New Point(x, y)

            'default date
            Dim curr_date As DateTime = getTimeDB()
            DEStart.EditValue = curr_date
            DEEnd.EditValue = curr_date
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim pz As New ClassPromoZalora()
            Dim query As String = pz.queryMain("AND p.id_promo_zalora='" + id + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            LEType.ItemIndex = LEType.Properties.GetDataSourceRowIndex("id_promo_zalora_type", data.Rows(0)("id_promo_zalora_type").ToString)
            DECreated.EditValue = data.Rows(0)("propose_created_date")
            TxtCreatedBy.Text = data.Rows(0)("propose_created_by_name").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtPromoName.Text = data.Rows(0)("promo_name").ToString
            TxtDiscountCode.Text = data.Rows(0)("discount_code").ToString
            TxtDiscountValue.EditValue = data.Rows(0)("discount_value")
            TxtVolcomPros.EditValue = data.Rows(0)("volcom_pros")
            DEStart.EditValue = data.Rows(0)("start_period")
            DEEnd.EditValue = data.Rows(0)("end_period")
            MENote.Text = data.Rows(0)("propose_note").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString

            'detail
            viewDetail()
            allow_status()

            'recon
            If id_report_status = "6" Then
                XTPReconcile.PageVisible = True
                viewReportStatusRecon()

                DECreatedRecon.EditValue = data.Rows(0)("recon_created_date")
                TxtCreatedByRecon.Text = data.Rows(0)("recon_created_by_name").ToString
                LEReportStatusRecon.ItemIndex = LEReportStatusRecon.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status_recon").ToString)
                id_report_status_recon = data.Rows(0)("id_report_status_recon").ToString
                is_confirm_recon = data.Rows(0)("is_confirm_recon").ToString

                viewDetailRecon()
                allow_status_recon()
            End If
            'recon approval
            If id_menu = "2" Then
                XTCPromoZalora.SelectedTabPageIndex = 1
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If Not checkHead() Then
            warningCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create New propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If
    End Sub

    Function checkHead()
        If TxtPromoName.Text <> "" And TxtDiscountCode.Text <> "" And TxtDiscountValue.EditValue <> 0 And TxtVolcomPros.EditValue <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Sub saveHead()
        Cursor = Cursors.WaitCursor
        Dim promo_name As String = addSlashes(TxtPromoName.Text)
        Dim discount_code As String = addSlashes(TxtDiscountCode.Text)
        Dim discount_value As String = decimalSQL(TxtDiscountValue.EditValue.ToString)
        Dim volcom_pros As String = decimalSQL(TxtVolcomPros.EditValue.ToString)
        Dim start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd HH: mm:ss")
        Dim end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Dim propose_note As String = addSlashes(MENote.Text)

        If action = "ins" Then
            Dim query As String = "INSERT INTO tb_promo_zalora(`promo_name`,`discount_code` ,`discount_value`,`volcom_pros`,`start_period`,`end_period` ,`propose_created_date`,`propose_created_by`,`id_report_status`,`rmt_propose`,`propose_note`)
            VALUES ('" + promo_name + "','" + discount_code + "' ,'" + discount_value + "','" + volcom_pros + "','" + start_period + "','" + end_period + "' ,NOW(),'" + id_user + "','1','" + rmt_propose + "','" + propose_note + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")

            'gen number
            execute_non_query("CALL gen_number(" + id + ", " + rmt_propose + ")", True, "", "", "", "")

            refreshMainview()
            FormPromoZalora.is_load_new = True
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_promo_zalora p SET promo_name='" + promo_name + "', 
            discount_code='" + discount_code + "', discount_value='" + discount_value + "', volcom_pros='" + volcom_pros + "',
            start_period='" + start_period + "',  end_period='" + end_period + "', propose_note='" + propose_note + "'
            WHERE p.id_promo_zalora='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            refreshMainview()
            actionLoad()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub refreshMainview()
        FormPromoZalora.viewData()
        FormPromoZalora.GVData.FocusedRowHandle = find_row(FormPromoZalora.GVData, "id_promo_zalora", id)
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pd.id_promo_zalora_det, pd.id_promo_zalora, 
        pd.id_product, p.product_full_code AS `code`, cd.`class`, p.product_display_name AS `name`, cd.sht,cd.color, sz.display_name AS `size`, 
        pd.total_qty, pd.id_design_price, pd.design_price 
        FROM tb_promo_zalora_det pd
        INNER JOIN tb_m_product p ON p.id_product = pd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
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
        ) cd ON cd.id_design = p.id_design
        WHERE pd.id_promo_zalora=" + id + " 
        ORDER BY `class` ASC, `name` ASC, `code` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemPropose.DataSource = data
        GVtemPropose.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailRecon()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT IF(pd.is_app_zalora=1,'Yes', 'No') AS `is_app_zalora_view`,pd.is_app_zalora,pd.id_promo_zalora_det, pd.id_promo_zalora, 
        pd.id_product, p.product_full_code AS `code`, cd.`class`, p.product_display_name AS `name`, cd.sht,cd.color, sz.display_name AS `size`, 
        pd.total_qty, pd.id_design_price, pd.design_price 
        FROM tb_promo_zalora_det pd
        INNER JOIN tb_m_product p ON p.id_product = pd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
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
        ) cd ON cd.id_design = p.id_design
        WHERE pd.id_promo_zalora=" + id + " 
        ORDER BY `class` ASC, `name` ASC, `code` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRecon.DataSource = data
        GVRecon.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        BtnExportToXLS.Visible = True
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            DEStart.Enabled = True
            DEEnd.Enabled = True
            TxtPromoName.Enabled = True
            TxtDiscountCode.Enabled = True
            TxtDiscountValue.Enabled = True
            TxtVolcomPros.Enabled = True
            BtnImportExcel.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            DEStart.Enabled = False
            DEEnd.Enabled = False
            TxtPromoName.Enabled = False
            TxtDiscountCode.Enabled = False
            TxtDiscountValue.Enabled = False
            TxtVolcomPros.Enabled = False
            BtnImportExcel.Visible = False
        End If

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            DEStart.Enabled = False
            DEEnd.Enabled = False
            TxtPromoName.Enabled = False
            TxtDiscountCode.Enabled = False
            TxtDiscountValue.Enabled = False
            TxtVolcomPros.Enabled = False
            BtnImportExcel.Visible = False
        End If
    End Sub

    Sub allow_status_recon()
        BtnAttachmentRecon.Visible = True
        If is_confirm_recon = "2" And is_view = "-1" Then
            BtnConfirmRecon.Visible = True
            BtnMarkRecon.Visible = False
            BtnPrintRecon.Visible = False
            MENoteRecon.Enabled = True
            GridColumnis_app_zalora_view.VisibleIndex = 0
            GridColumnis_app_zalora_view_raw.Visible = False
        Else
            BtnConfirmRecon.Visible = False
            BtnMarkRecon.Visible = True
            BtnPrintRecon.Visible = True
            MENoteRecon.Enabled = False
            GridColumnis_app_zalora_view.Visible = False
            GridColumnis_app_zalora_view_raw.VisibleIndex = 20
        End If

        'reset propose
        If is_view = "-1" And is_confirm_recon = "1" Then
            BtnResetProposeRecon.Visible = True
        Else
            BtnResetProposeRecon.Visible = False
        End If

        If id_report_status_recon = "6" Then
            BtnResetProposeRecon.Visible = False
        ElseIf id_report_status_recon = "5" Then
            BtnResetProposeRecon.Visible = False
            BtnConfirmRecon.Visible = False
            MENoteRecon.Enabled = False
            GridColumnis_app_zalora_view.Visible = False
            GridColumnis_app_zalora_view_raw.VisibleIndex = 20
        End If
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If GVtemPropose.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "promo_zalora_" + id + ".xlsx"
            exportToXLS(path, "promo_zalora_" + id, GCItemPropose)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVtemPropose)

        If GVtemPropose.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        ElseIf Not checkHead() Then
            stopCustom("Please complete all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose  ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_promo_zalora SET is_confirm=1 WHERE id_promo_zalora='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt_propose, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        If checkHead() Then
            saveHead()
        Else
            stopCustom("Please complete all data")
        End If
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        'reset propose
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt_propose + " AND rm.id_report_status=3 
        AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt_propose + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_promo_zalora SET is_confirm=2,id_report_status=1 WHERE id_promo_zalora=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                refreshMainview()
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_promo_zalora SET id_report_status=5 WHERE id_promo_zalora='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt_propose, id)
            execute_non_query(queryrm, True, "", "", "", "")

            'refresh
            refreshMainview()
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt_propose
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_no_delete = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = GVtemPropose
        ReportPromoZalora.dt = GCItemPropose.DataSource
        ReportPromoZalora.id = id
        If id_report_status <> "6" Then
            ReportPromoZalora.is_pre = "1"
        Else
            ReportPromoZalora.is_pre = "-1"
        End If
        ReportPromoZalora.id_report_status = LEReportStatus.EditValue.ToString
        ReportPromoZalora.rmt = rmt_propose

        Dim Report As New ReportPromoZalora()
        '... 
        ' creating And saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVtemPropose.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'style
        Report.GVtemPropose.OptionsPrint.UsePrintStyles = True
        Report.GVtemPropose.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVtemPropose.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 8, FontStyle.Regular)

        Report.GVtemPropose.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        Report.GVtemPropose.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 8, FontStyle.Bold)

        Report.GVtemPropose.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVtemPropose.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.GroupRow.Font = New Font("Tahoma", 8, FontStyle.Bold)


        Report.GVtemPropose.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVtemPropose.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)

        Report.GVtemPropose.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        Report.GVtemPropose.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 8.3, FontStyle.Bold)

        Report.GVtemPropose.AppearancePrint.Row.Font = New Font("Tahoma", 8.3, FontStyle.Regular)

        Report.GVtemPropose.OptionsPrint.ExpandAllDetails = True
        Report.GVtemPropose.OptionsPrint.UsePrintStyles = True
        Report.GVtemPropose.OptionsPrint.PrintDetails = True
        Report.GVtemPropose.OptionsPrint.PrintFooter = True

        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelPromoType.Text = LEType.Text.ToUpper
        Report.LabelPromoName.Text = TxtPromoName.Text.ToUpper
        Report.LabelDiscountCode.Text = TxtDiscountCode.Text
        Report.LabelDiscountValue.Text = TxtDiscountValue.Text
        Report.LabelVolcomCharge.Text = TxtVolcomPros.Text
        Report.LabelStartPeriod.Text = DEStart.Text.ToUpper
        Report.LabelEndPeriod.Text = DEEnd.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToUpper
        Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        Report.LNote.Text = MENote.Text.ToUpper


        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt_propose
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVtemPropose_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVtemPropose.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnImportExcel_Click(sender As Object, e As EventArgs) Handles BtnImportExcel.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "62"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPromoZaloraDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirmRecon_Click(sender As Object, e As EventArgs) Handles BtnConfirmRecon.Click
        makeSafeGV(GVRecon)

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose  ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'update product
            GVRecon.ActiveFilterString = ""
            For i As Integer = 0 To GVRecon.RowCount - 1
                Dim id_promo_zalora_det As String = GVRecon.GetRowCellValue(i, "id_promo_zalora_det").ToString
                Dim is_app_zalora As String = ""
                If GVRecon.GetRowCellValue(i, "is_app_zalora_view").ToString = "Yes" Then
                    is_app_zalora = "1"
                Else
                    is_app_zalora = "2"
                End If
                execute_non_query("UPDATE tb_promo_zalora_det SET is_app_zalora='" + is_app_zalora + "' WHERE id_promo_zalora_det='" + id_promo_zalora_det + "' ", True, "", "", "", "")
            Next

            'update confirm
            Dim query As String = "UPDATE tb_promo_zalora SET is_confirm_recon=1,recon_created_date=NOW(), recon_created_by='" + id_user + "', id_report_status_recon='1', rmt_recon='" + rmt_recon + "', recon_note='" + addSlashes(MENoteRecon.text) + "'  WHERE id_promo_zalora='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'submit approval 
            submit_who_prepared(rmt_recon, id, id_user)
            BtnConfirmRecon.Visible = False
            actionLoad()
            XTCPromoZalora.SelectedTabPageIndex = 1
            infoCustom("Propose submitted. Waiting for approval.")
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnResetProposeRecon_Click(sender As Object, e As EventArgs) Handles BtnResetProposeRecon.Click
        'reset propose
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt_recon + " AND rm.id_report_status=3 
        AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt_recon + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_promo_zalora SET is_confirm_recon=2,id_report_status_recon=1,recon_created_date=NULL, recon_created_by=NULL, rmt_recon=NULL WHERE id_promo_zalora=" + id + "; 
                UPDATE tb_promo_zalora_det SET is_app_zalora=1 WHERE id_promo_zalora='" + id + "'; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                refreshMainview()
                actionLoad()
                XTCPromoZalora.SelectedTabPageIndex = 1
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnAttachmentRecon_Click(sender As Object, e As EventArgs) Handles BtnAttachmentRecon.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt_recon
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_no_delete = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintRecon_Click(sender As Object, e As EventArgs) Handles BtnPrintRecon.Click
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = GVRecon
        ReportPromoZalora.dt = GCRecon.DataSource
        ReportPromoZalora.id = id
        If id_report_status_recon <> "6" Then
            ReportPromoZalora.is_pre = "1"
        Else
            ReportPromoZalora.is_pre = "-1"
        End If
        ReportPromoZalora.id_report_status = LEReportStatus.EditValue.ToString
        ReportPromoZalora.rmt = rmt_recon

        Dim Report As New ReportPromoZalora()
        '... 
        ' creating And saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVtemPropose.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'style
        Report.GVtemPropose.OptionsPrint.UsePrintStyles = True
        Report.GVtemPropose.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVtemPropose.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 8, FontStyle.Regular)

        Report.GVtemPropose.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        Report.GVtemPropose.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 8, FontStyle.Bold)

        Report.GVtemPropose.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVtemPropose.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.GroupRow.Font = New Font("Tahoma", 8, FontStyle.Bold)


        Report.GVtemPropose.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVtemPropose.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)

        Report.GVtemPropose.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        Report.GVtemPropose.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVtemPropose.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 8.3, FontStyle.Bold)

        Report.GVtemPropose.AppearancePrint.Row.Font = New Font("Tahoma", 8.3, FontStyle.Regular)

        Report.GVtemPropose.OptionsPrint.ExpandAllDetails = True
        Report.GVtemPropose.OptionsPrint.UsePrintStyles = True
        Report.GVtemPropose.OptionsPrint.PrintDetails = True
        Report.GVtemPropose.OptionsPrint.PrintFooter = True

        Report.LabelTitle.Text = "REKONSILIASI ITEM PROMO ZALORA"
        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelPromoName.Text = TxtPromoName.Text.ToUpper
        Report.LabelDiscountCode.Text = TxtDiscountCode.Text
        Report.LabelDiscountValue.Text = TxtDiscountValue.Text
        Report.LabelVolcomCharge.Text = TxtVolcomPros.Text
        Report.LabelStartPeriod.Text = DEStart.Text.ToUpper
        Report.LabelEndPeriod.Text = DEEnd.Text.ToUpper
        Report.LabelDate.Text = DECreatedRecon.Text.ToUpper
        Report.LabelStatus.Text = LEReportStatusRecon.Text.ToUpper
        Report.LNote.Text = MENoteRecon.Text.ToUpper


        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub BtnMarkRecon_Click(sender As Object, e As EventArgs) Handles BtnMarkRecon.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt_recon
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRecon_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRecon.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub LEType_EditValueChanged(sender As Object, e As EventArgs) Handles LEType.EditValueChanged
        Dim typ As String = "-1"
        Try
            typ = LEType.EditValue.ToString
        Catch ex As Exception
        End Try
        If typ = "2" Then
            TxtVolcomPros.EditValue = 100
        Else
            TxtVolcomPros.EditValue = 0
        End If
    End Sub
End Class