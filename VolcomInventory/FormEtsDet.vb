Public Class FormEtsDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Dim rmt As String = "370"
    Dim dvs As System.IO.Stream

    Private Sub FormEtsDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormEtsDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'cek on process
            Dim qcek As String = "SELECT * FROM tb_ets c WHERE c.id_report_status<5 "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                Cursor = Cursors.Default
                stopCustom("Please complete all pending propose first")
                Close()
            End If

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
            DEEffectDate.EditValue = curr_date
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim mkd As New ClassEts()
            Dim query As String = mkd.queryMain("AND  e.id_ets='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DEEffectDate.EditValue = data.Rows(0)("effective_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            is_confirm = data.Rows(0)("is_confirm").ToString
            Dim is_show_all As String = ""
            If is_confirm = "2" And id_report_status = "1" Then
                is_show_all = "1"
            Else
                is_show_all = "2"
                XTCData.SelectedTabPageIndex = 1
            End If

            'detail
            viewDetailPTH()
            viewDetail(is_show_all)
            allowStatus()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailPTH()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_pp_change, p.number, p.effective_date, p.plan_end_date 
        FROM tb_ets_det e
        INNER JOIN tb_pp_change_det pd ON pd.id_pp_change_det = e.id_pp_change_det
        INNER JOIN tb_pp_change p ON p.id_pp_change = pd.id_pp_change
        WHERE e.id_ets='" + id + "'
        GROUP BY p.id_pp_change "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPTH.DataSource = data
        GVPTH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail(ByVal is_show_all As String)
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ed.id_ets_det, ed.id_ets, ed.id_pp_change_det, 
        ed.id_design, d.design_code AS `code`, cd.class, d.design_display_name AS `name`, cd.sht, cd.color,
        ed.id_design_price, ed.design_price, ed.id_propose_type, pt.propose_type,ed.note, 'No' AS `is_select`
        FROM tb_ets_det ed
        INNER JOIN tb_m_design d ON d.id_design = ed.id_design
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
        ) cd ON cd.id_design = d.id_design
        INNER JOIN tb_lookup_propose_type pt ON pt.id_propose_type = ed.id_propose_type
        WHERE ed.id_ets='" + id + "' "
        If is_show_all = "2" Then
            query += "AND ed.id_propose_type=1 "
        End If
        query += "ORDER BY id_propose_type DESC, class ASC, `name` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        GVProduct.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        BtnCreateNew.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        DEEffectDate.Enabled = False
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVProduct.OptionsBehavior.ReadOnly = False
            GVPTH.OptionsBehavior.ReadOnly = False
            BtnChangeEffectiveDate.Enabled = True
            BtnAllProduct.Visible = False
            BtnFinalPropose.Visible = False
            GridColumnnote.Visible = True
            BtnBulkEdit.Visible = True
            PanelOpt.Visible = True
            PanelControlNavPTH.Visible = True
            GridColumnis_select.VisibleIndex = 0
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVProduct.OptionsBehavior.ReadOnly = True
            GVPTH.OptionsBehavior.ReadOnly = True
            BtnChangeEffectiveDate.Enabled = False
            BtnAllProduct.Visible = True
            BtnFinalPropose.Visible = True
            GridColumnnote.Visible = False
            BtnBulkEdit.Visible = False
            PanelOpt.Visible = False
            PanelControlNavPTH.Visible = False
            GridColumnis_select.Visible = False
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
            GVProduct.OptionsBehavior.ReadOnly = True
            GVPTH.OptionsBehavior.ReadOnly = True
            BtnAllProduct.Visible = False
            BtnFinalPropose.Visible = False
            GridColumnnote.Visible = False
            BtnBulkEdit.Visible = False
            PanelOpt.Visible = False
            PanelControlNavPTH.Visible = False
            GridColumnis_select.Visible = False
        End If
    End Sub

    Sub saveHead()
        'head
        Dim effective_date As String = DateTime.Parse(DEEffectDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim note As String = addSlashes(MENote.Text)
        If action = "ins" Then
            Dim query_head As String = "INSERT INTO tb_ets(created_date, effective_date, note, id_report_status)
            VALUES(NOW(), '" + effective_date + "','" + note + "', 1); SELECT LAST_INSERT_ID(); "
            id = execute_query(query_head, 0, True, "", "", "", "")
            'update number
            execute_non_query("CALL gen_number('" + id + "', '" + rmt + "');", True, "", "", "", "")
            FormEts.viewData()
            FormEts.GVData.FocusedRowHandle = find_row(FormEts.GVData, "id_ets", id)
            FormEts.is_load_new = True
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_ets SET note='" + note + "' WHERE id_ets='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Function checkHead()
        If DEEffectDate.EditValue <> Nothing And MENote.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If Not checkHead() Then
            warningCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create new propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        GVProduct.ActiveFilterString = ""
        If GVProduct.RowCount <= 0 Or Not checkHead() Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_ets SET is_confirm=1, confirm_date=NOW(), confirm_by='" + id_user + "' WHERE id_ets='" + id + "'"
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
                    FormEts.viewData()
                    FormEts.GVData.FocusedRowHandle = find_row(FormEts.GVData, "id_ets", id)
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
                UPDATE tb_ets SET is_confirm=2, confirm_date=NULL, confirm_by=NULL WHERE id_ets=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                FormEts.viewData()
                FormEts.GVData.FocusedRowHandle = find_row(FormEts.GVData, "id_ets", id)
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
            Dim query As String = "UPDATE tb_ets SET id_report_status=5 WHERE id_ets='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormEts.viewData()
            FormEts.GVData.FocusedRowHandle = find_row(FormEts.GVData, "id_ets", id)
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
        ReportEts.id = id
        ReportEts.dt = GCProduct.DataSource
        ReportEts.rmt = rmt
        Dim Report As New ReportEts()

        '... 
        ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVProduct.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVProduct.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVProduct)

        'Parse Val
        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToUpper
        Report.LNote.Text = MENote.Text
        Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        Report.LabelEffectDate.Text = DEEffectDate.Text.ToUpper

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
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

    Private Sub GVPTH_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPTH.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If GVProduct.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "ets_" + id + ".xlsx"
            exportToXLS(path, "ets_" + id, GCProduct)
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

    Private Sub BtnAllProduct_Click(sender As Object, e As EventArgs) Handles BtnAllProduct.Click
        viewDetail(1)
        allowStatus()
    End Sub

    Private Sub BtnFinalPropose_Click(sender As Object, e As EventArgs) Handles BtnFinalPropose.Click
        viewDetail(2)
        allowStatus()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        For i As Integer = 0 To GVProduct.RowCount - 1
            If CESelectAll.EditValue = True Then
                FormMain.SplashScreenManager1.SetWaitFormDescription("Checking " + (i + 1).ToString + "/" + GVProduct.RowCount.ToString)
                GVProduct.SetRowCellValue(i, "is_select", "Yes")
            Else
                FormMain.SplashScreenManager1.SetWaitFormDescription("Unchecking " + (i + 1).ToString + "/" + GVProduct.RowCount.ToString)
                GVProduct.SetRowCellValue(i, "is_select", "No")
            End If
        Next
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeletePTH_Click(sender As Object, e As EventArgs) Handles BtnDeletePTH.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_pp_change As String = GVPTH.GetFocusedRowCellValue("id_pp_change").ToString
            Dim query As String = "DELETE FROM tb_ets_det WHERE id_pp_change='" + id_pp_change + "' "
            execute_non_query(query, True, "", "", "", "")
            viewDetailPTH()
            viewDetail(1)
        End If
    End Sub

    Private Sub BtnAddPTH_Click(sender As Object, e As EventArgs) Handles BtnAddPTH.Click
        Cursor = Cursors.WaitCursor
        FormEtsSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBulkEdit_Click(sender As Object, e As EventArgs) Handles BtnBulkEdit.Click
        'check ud extended ato belum
        Cursor = Cursors.WaitCursor
        Dim last_filter As String = GVProduct.ActiveFilterString.ToString
        Dim ftr As String = "[is_select]='Yes' "
        If last_filter <> "" Then
            ftr += "AND " + last_filter
        End If
        GVProduct.ActiveFilterString = ftr
        If GVProduct.RowCount > 0 Then
            FormEtsProposeType.ShowDialog()
        Else
            stopCustom("No selected items")
        End If
        GVProduct.ActiveFilterString = "" + last_filter
        Cursor = Cursors.Default
    End Sub
End Class