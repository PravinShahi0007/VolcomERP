Public Class FormBSPDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Dim rmt As String = "376"
    Dim dvs As System.IO.Stream

    Private Sub FormBSPDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewStore()
        actionLoad()
    End Sub

    Private Sub FormBSPDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewStore()
        Dim query As String = "SELECT c.id_comp, CONCAT(c.comp_number, ' - ',c.comp_name) AS `comp` 
        FROM tb_m_comp c WHERE c.id_comp_cat=6 AND c.id_store_type=3 "
        If action = "ins" Then
            query += "AND c.is_active=1 "
        End If
        viewSearchLookupQuery(SLEStore, query, "id_comp", "comp", "id_comp")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'option
            BtnCreateNew.Visible = True
            Width = 450
            Height = 200
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControl1.Visible = False
            PanelControlBottom.Visible = False
            XTCData.Visible = False
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
            DEStartDate.EditValue = curr_date
            DEEndDate.EditValue = curr_date
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim mkd As New ClassBSP()
            Dim query As String = mkd.queryMain("AND  b.id_bsp='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            SLEStore.EditValue = data.Rows(0)("id_comp").ToString
            DEStartDate.EditValue = data.Rows(0)("start_date")
            DEEndDate.EditValue = data.Rows(0)("end_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            is_confirm = data.Rows(0)("is_confirm").ToString
            If is_confirm = "1" Then
                XTCData.SelectedTabPageIndex = 1
            End If

            'detail
            viewDetail()
            viewSum()
            allowStatus()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading detail")
        Dim query As String = "SELECT bd.id_bsp_det, bd.id_bsp, 
        bd.id_product, p.product_full_code AS `code`, cd.class,p.product_display_name AS `name`, cd.color, cd.sht, sz.display_name AS `size`,
        bd.id_wh, bd.id_wh_drawer, c.comp_number AS `wh_number`, c.comp_name AS `wh_name`, bd.qty, 
        bd.id_design_price, bd.design_price , bd.note_stock
        FROM tb_bsp_det bd
        INNER JOIN tb_m_product p ON p.id_product = bd.id_product
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
        INNER JOIN tb_m_comp c ON c.id_comp = bd.id_wh
        WHERE bd.id_bsp=" + id + " 
        ORDER BY class ASC, `name` ASC , `code` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewSum()

    End Sub

    Sub allowStatus()
        BtnCreateNew.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        SLEStore.Enabled = False
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
            GVSum.OptionsBehavior.ReadOnly = False
            BtnChangeEffectiveDate.Enabled = True
            DEStartDate.Enabled = True
            DEEndDate.Enabled = True
            BtnImportXLS.Visible = True
            BtnDelete.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            GVSum.OptionsBehavior.ReadOnly = True
            BtnChangeEffectiveDate.Enabled = False
            DEStartDate.Enabled = False
            DEEndDate.Enabled = False
            BtnImportXLS.Visible = False
            BtnDelete.Visible = False
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
            GVData.OptionsBehavior.ReadOnly = True
            GVSum.OptionsBehavior.ReadOnly = True
            DEStartDate.Enabled = False
            DEEndDate.Enabled = False
            BtnImportXLS.Visible = False
            BtnDelete.Visible = False
        End If
    End Sub

    Sub saveHead()
        'head
        Dim id_comp As String = SLEStore.EditValue.ToString
        Dim start_date As String = DateTime.Parse(DEStartDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim end_date As String = DateTime.Parse(DEEndDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim note As String = addSlashes(MENote.Text)
        If action = "ins" Then
            Dim query_head As String = "INSERT INTO tb_bsp(created_date, created_by, id_comp, start_date, end_date, id_report_status, note)
            VALUES(NOW(), '" + id_user + "', '" + id_comp + "', '" + start_date + "','" + end_date + "',1, '" + note + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query_head, 0, True, "", "", "", "")
            'update number
            execute_non_query("CALL gen_number('" + id + "', '" + rmt + "');", True, "", "", "", "")
            FormBSP.viewData()
            FormBSP.GVData.FocusedRowHandle = find_row(FormBSP.GVData, "id_bsp", id)
            FormBSP.is_load_new = True
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_bsp SET start_date='" + start_date + "', end_date='" + end_date + "',note='" + note + "' WHERE id_bsp='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Function checkHead()
        If SLEStore.EditValue <> Nothing And DEStartDate.EditValue <> Nothing And DEEndDate.EditValue <> Nothing And MENote.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Dim cond_no_propose As Boolean = True
        Dim qcek As String = "SELECT * FROM tb_bsp WHERE id_report_status!=5 AND id_comp='" + SLEStore.EditValue.ToString + "' "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        If dcek.Rows.Count > 0 Then
            cond_no_propose = False
        End If

        If Not checkHead() Then
            warningCustom("Please input all data")
        ElseIf Not cond_no_propose Then
            warningCustom("This store already proposed")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create new propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        GVData.ActiveFilterString = ""
        If GVData.RowCount <= 0 Or Not checkHead() Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'check stock here


                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_bsp SET is_confirm=1 WHERE id_bsp='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Proposal submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        If Not checkHead() Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    'head
                    saveHead()

                    'actionLoad()
                    FormBSP.viewData()
                    FormBSP.GVData.FocusedRowHandle = find_row(FormBSP.GVData, "id_bsp", id)
                    actionLoad()
                    infoCustom("Save changes success")
                Catch ex As Exception
                    stopCustom("Error save changes, please contact administrator. " + ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report_status=2 
        AND rm.is_requisite=2 AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_bsp SET is_confirm=2 WHERE id_bsp=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                FormBSP.viewData()
                FormBSP.GVData.FocusedRowHandle = find_row(FormBSP.GVData, "id_bsp", id)
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
            Dim query As String = "UPDATE tb_bsp SET id_report_status=5 WHERE id_bsp='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormBSP.viewData()
            FormBSP.GVData.FocusedRowHandle = find_row(FormBSP.GVData, "id_bsp", id)
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
        'Cursor = Cursors.WaitCursor
        'ReportEts.id = id
        'ReportEts.dt = GCProduct.DataSource
        'ReportEts.rmt = rmt
        'Dim Report As New ReportEts()

        ''... 
        '' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVProduct.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVProduct.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVProduct)

        ''Parse Val
        'Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        'Report.LabelDate.Text = DECreated.Text.ToUpper
        'Report.LNote.Text = MENote.Text
        'Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        'Report.LabelEffectDate.Text = DEEffectDate.Text.ToUpper

        ''Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreviewDialog()
        'Cursor = Cursors.Default
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

    Private Sub BtnExportToXLSSummary_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSSummary.Click
        If GVSum.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "bspsum_" + id + ".xlsx"
            exportToXLS(path, "bspsum_" + id, GCSum)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportXLS_Click(sender As Object, e As EventArgs) Handles BtnExportXLS.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "bsp_" + id + ".xlsx"
            exportToXLS(path, "bsp_" + id, GCData)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_bsp_det As String = GVData.GetFocusedRowCellValue("id_bsp_det").ToString
            Dim query As String = "DELETE FROM tb_bsp_det WHERE id_bsp_det='" + id_bsp_det + "' "
            execute_non_query(query, True, "", "", "", "")
            viewDetail()
            viewSum()
        End If
    End Sub

    Private Sub BtnImportXLS_Click(sender As Object, e As EventArgs) Handles BtnImportXLS.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "63"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class