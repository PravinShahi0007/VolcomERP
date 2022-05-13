Public Class FormDropChangesDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "410"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormDropChangesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/dropchanges-det/" + id + "")

        viewSeason()
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormDropChangesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewSeason()
        viewSearchLookupQueryO(SLESeason, volcomErpApiGetDT(dt_json, 1), "id_season", "season", "id_season")
    End Sub

    Sub viewReportStatus()
        viewLookupQueryO(LEReportStatus, volcomErpApiGetDT(dt_json, 0), 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnCreateNew.Visible = True
            Width = 459
            Height = 155
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            'FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControlBottom.Visible = False
            PanelControl1.Visible = False
            PanelControlNav.Visible = False

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
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim data As DataTable = volcomErpApiGetDT(dt_json, 2)
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.Text = data.Rows(0)("created_date")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            SLESeason.EditValue = data.Rows(0)("id_season").ToString
            MENote.Text = data.Rows(0)("note").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString

            'detail
            viewDetail()
            allowStatus()
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dc.id_drop_changes_det, dc.id_drop_changes, 
        dc.id_design, d.design_code, cd.class, d.design_display_name, cd.color, cd.sht,
        dc.id_season_from, dc.id_delivery_from, CONCAT(sf.season, ' ', df.delivery) AS `season_del_from`, df.delivery_date AS `in_store_date_from`,
        dc.id_season_to, dc.id_delivery_to ,CONCAT(st.season, ' ', dt.delivery) AS `season_del_to`, dt.delivery_date AS `in_store_date_to`,
        dc.id_lookup_status_order AS `id_stt`, stt.lookup_status_order AS `stt`, dc.reason
        FROM tb_drop_changes_det dc
        INNER JOIN tb_m_design d ON d.id_design = dc.id_design
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
        INNER JOIN tb_season sf ON sf.id_season = dc.id_season_from
        INNER JOIN tb_season_delivery df ON df.id_delivery = dc.id_delivery_from
        INNER JOIN tb_season st ON st.id_season = dc.id_season_to
        INNER JOIN tb_season_delivery dt ON dt.id_delivery = dc.id_delivery_to
        INNER JOIN tb_lookup_status_order stt ON stt.id_lookup_status_order = dc.id_lookup_status_order
        WHERE dc.id_drop_changes=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        BtnCreateNew.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        SLESeason.Enabled = False
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
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
        End If
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If SLESeason.EditValue = Nothing Then
            warningCustom("Please input all data")
            Exit Sub
        End If

        Dim qcek As String = "SELECT * FROM tb_drop_changes p WHERE p.id_season='" + SLESeason.EditValue.ToString + "' AND p.id_report_status!=5 "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")

        If dcek.Rows.Count > 0 Then
            warningCustom("Please complete all pending propose first")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create New propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If
    End Sub

    Sub saveHead()
        Dim id_season As String = SLESeason.EditValue.ToString
        Dim note As String = addSlashes(MENote.Text)
        If action = "ins" Then
            Dim query_head As String = "INSERT INTO tb_drop_changes(created_date, created_by, id_season, note, id_report_status, is_confirm)
            VALUES(NOW(), '" + id_user + "', '" + id_season + "', '" + note + "',1, 2); SELECT LAST_INSERT_ID(); "
            id = execute_query(query_head, 0, True, "", "", "", "")
            'update number
            execute_non_query("CALL gen_number('" + id + "', '" + rmt + "');", True, "", "", "", "")
            FormDropChanges.viewData()
            FormDropChanges.GVData.FocusedRowHandle = find_row(FormDropChanges.GVData, "id_drop_changes", id)
            FormDropChanges.is_load_new = True
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_drop_changes SET note='" + note + "' WHERE id_drop_changes='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Function checkHead()
        If SLESeason.EditValue <> Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        GVData.ActiveFilterString = ""
        If GVData.RowCount <= 0 Or Not checkHead() Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_drop_changes SET is_confirm=1 WHERE id_drop_changes='" + id + "'"
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
                    FormDropChanges.viewData()
                    FormDropChanges.GVData.FocusedRowHandle = find_row(FormDropChanges.GVData, "id_drop_changes", id)
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
                UPDATE tb_drop_changes SET is_confirm=2 WHERE id_drop_changes=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                FormDropChanges.viewData()
                FormDropChanges.GVData.FocusedRowHandle = find_row(FormDropChanges.GVData, "id_drop_changes", id)
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
            Dim query As String = "UPDATE tb_drop_changes SET id_report_status=5 WHERE id_drop_changes='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormDropChanges.viewData()
            FormDropChanges.GVData.FocusedRowHandle = find_row(FormDropChanges.GVData, "id_drop_changes", id)
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

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAddPTH_Click(sender As Object, e As EventArgs) Handles BtnAddPTH.Click

    End Sub

    Private Sub BtnDeletePTH_Click(sender As Object, e As EventArgs) Handles BtnDeletePTH.Click

    End Sub
End Class