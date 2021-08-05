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
        Dim query As String = "SELECT nd.id_ar_eval_note_det,ns.id_ar_eval_note_store, ns.id_ar_eval_note, ns.id_comp_group, cg.description AS `store_group`, ns.overdue_inv,nd.note
        FROM tb_ar_eval_note_store ns
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = ns.id_comp_group
        LEFT JOIN tb_ar_eval_note_det nd ON nd.id_ar_eval_note_store =  ns.id_ar_eval_note_store
        WHERE ns.id_ar_eval_note=" + id + " AND ns.overdue_inv>0
        ORDER BY ns.id_ar_eval_note ASC "
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

    End Sub
End Class