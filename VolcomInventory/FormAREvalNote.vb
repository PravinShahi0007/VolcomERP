Public Class FormAREvalNote
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_submit As String = "-1"
    Dim rmt As String = "329"

    Private Sub FormAREvalNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormAREvalNote_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        'main
        Dim query As String = "SELECT n.id_ar_eval_note, n.id_ar_eval_pps, n.`number`, n.created_date, n.id_report_status, n.note, n.is_submit
        FROM tb_ar_eval_note n
        WHERE n.id_ar_eval_note=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        is_submit = data.Rows(0)("is_submit").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString

        'detail
        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT nd.id_ar_eval_note_det,ns.id_ar_eval_note_store, ns.id_ar_eval_note, ns.id_comp_group, cg.description AS `store_group`, ns.overdue_inv,nd.note,
        CONCAT(cg.description,ns.id_ar_eval_note) AS `sortcol`
        FROM tb_ar_eval_note_store ns
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = ns.id_comp_group
        LEFT JOIN tb_ar_eval_note_det nd ON nd.id_ar_eval_note_store =  ns.id_ar_eval_note_store
        WHERE ns.id_ar_eval_note=" + id + " AND ns.overdue_inv>0
        ORDER BY cg.description ASC, nd.id_ar_eval_note_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        If is_submit = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Properties.ReadOnly = False
            GVData.OptionsBehavior.ReadOnly = False
            GCData.ContextMenuStrip = ContextMenuStrip1
            PanelControlNav.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
            GCData.ContextMenuStrip = Nothing
            PanelControlNav.Visible = False
        End If

        'reset propose
        If is_view = "-1" And is_submit = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
            GCData.ContextMenuStrip = Nothing
            PanelControlNav.Visible = False
        End If
    End Sub

    Private Sub AddNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNoteToolStripMenuItem.Click
        If GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormAREvalNoteAdd.id_ar_eval_note_store = GVData.GetFocusedRowCellValue("id_ar_eval_note_store").ToString
            FormAREvalNoteAdd.id_ar_eval_note_det = "-1"
            FormAREvalNoteAdd.id_comp_group = GVData.GetFocusedRowCellValue("id_comp_group").ToString
            FormAREvalNoteAdd.action = "ins"
            FormAREvalNoteAdd.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormAREvalNoteAdd.id_ar_eval_note_store = GVData.GetFocusedRowCellValue("id_ar_eval_note_store").ToString
            FormAREvalNoteAdd.id_ar_eval_note_det = GVData.GetFocusedRowCellValue("id_ar_eval_note_det").ToString
            FormAREvalNoteAdd.id_comp_group = GVData.GetFocusedRowCellValue("id_comp_group").ToString
            FormAREvalNoteAdd.action = "upd"
            FormAREvalNoteAdd.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DeleteNoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteNoteToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item(s) ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_ar_eval_note_det As String = GVData.GetFocusedRowCellValue("id_ar_eval_note_det").ToString
                Dim query As String = "DELETE FROM tb_ar_eval_note_det WHERE id_ar_eval_note_det=" + id_ar_eval_note_det + " "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddBulk_Click(sender As Object, e As EventArgs) Handles BtnAddBulk.Click
        Cursor = Cursors.WaitCursor
        FormAREvalNoteBulk.id_ar_eval_note = id
        FormAREvalNoteBulk.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            saveHead()
            infoCustom("Save change success")
        End If
    End Sub

    Sub saveHead()
        'head
        Dim note As String = addSlashes(MENote.Text)
        Dim query_head As String = "UPDATE tb_ar_eval_note SET note='" + note + "' 
        WHERE id_ar_eval_note='" + id + "' "
        execute_non_query(query_head, True, "", "", "", "")
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_ar_eval_note SET is_submit=1 WHERE id_ar_eval_note='" + id + "' "
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose submitted. Waiting for approval.")
                Cursor = Cursors.Default
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
                UPDATE tb_ar_eval_note SET is_submit=2 WHERE id_ar_eval_note=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "5" Then
            Dim query_check As String = "SELECT * FROM tb_report_mark rm WHERE id_report='" + id + "' AND rm.report_mark_type='" + rmt + "' "
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            If data_check.Rows.Count <= 0 Then
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_submit = "1" Then
            FormDocumentUpload.is_no_delete = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        'gv = GVData
        'ReportDelayPaymentInv.dt = GCData.DataSource
        'ReportDelayPaymentInv.id = id
        'If id_report_status <> "6" Then
        '    ReportDelayPaymentInv.is_pre = "1"
        'Else
        '    ReportDelayPaymentInv.is_pre = "-1"
        'End If
        'ReportDelayPaymentInv.id_report_status = LEReportStatus.EditValue.ToString

        'ReportDelayPaymentInv.rmt = rmt
        'Dim Report As New ReportDelayPaymentInv()

        ''... 
        '' creating And saving the view's layout to a new memory stream 
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
        'Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)

        'Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        'Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
        'Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 7, FontStyle.Bold)

        'Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
        'Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
        'Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 7, FontStyle.Bold)

        'Report.GVData.AppearancePrint.HeaderPanel.BorderColor = Color.Black
        'Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        'Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        'Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)

        'Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        'Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
        'Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 7.3, FontStyle.Bold)

        'Report.GVData.AppearancePrint.Row.ForeColor = Color.Black
        'Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 7.3, FontStyle.Regular)

        'Report.GVData.AppearancePrint.Lines.BackColor = Color.Black

        'Report.GVData.OptionsPrint.ExpandAllDetails = True
        'Report.GVData.OptionsPrint.UsePrintStyles = True
        'Report.GVData.OptionsPrint.PrintDetails = True
        'Report.GVData.OptionsPrint.PrintFooter = True

        ''data
        'Report.LabelNumber.Text = "NO. " + TxtNumber.Text
        'Report.LabelDate.Text = DECreated.Text.ToUpper
        'Report.LNote.Text = MENote.Text
        'Report.LabelStoreGroup.Text = SLEStoreGroup.Text.ToUpper
        'Report.LabelDueDate.Text = DEDueDate.Text.ToUpper

        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreviewDialog()
        'Cursor = Cursors.Default
    End Sub
End Class