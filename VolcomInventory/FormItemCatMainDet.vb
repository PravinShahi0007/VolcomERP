Public Class FormItemCatMainDet
    Public id_propose As String = "-1"

    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Public show_mark As Boolean = False

    Private Sub FormItemCatMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormItemCatMainDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormItemCatMainDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim query As String = "SELECT ip.id_item_cat_main_pps, ip.number, ip.created_date, ip.note, ip.id_report_status, stt.report_status, ip.is_confirm
        FROM tb_item_cat_main_pps ip
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ip.id_report_status
        WHERE ip.id_item_cat_main_pps>0 AND ip.id_item_cat_main_pps='" & id_propose & "' ORDER BY ip.id_item_cat_main_pps"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)


        viewDetail()
        allow_status()
        If show_mark Then
            openMark()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "Select d.id_item_cat_main_pps_det, d.id_item_cat_main_pps, d.id_expense_type, ex.expense_type, d.item_cat_main , IF(d.is_fixed_asset='1','yes','no') AS is_fixed_asset
        FROM tb_item_cat_main_pps_det d 
        INNER JOIN tb_lookup_expense_type ex ON ex.id_expense_type = d.id_expense_type
        WHERE d.id_item_cat_main_pps=" + id_propose + " ORDER BY d.id_item_cat_main_pps_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        If GVData.RowCount > 0 Then
            BtnDelete.Visible = True
        Else
            BtnDelete.Visible = False
        End If
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = True
            PanelControlNav.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            PanelControlNav.Visible = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Visible = True
        Else
            BtnPrint.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            GVData.OptionsBehavior.Editable = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            PanelControlNav.Visible = False
            BtnPrint.Visible = False
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        openMark()
    End Sub

    Sub openMark()
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "207"
        FormReportMark.id_report = id_propose
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'update confirm
            Dim query As String = "UPDATE tb_item_cat_main_pps SET is_confirm=1 WHERE id_item_cat_main_pps='" + id_propose + "'"
            execute_non_query(query, True, "", "", "", "")

            'submit approval
            submit_who_prepared(207, id_propose, id_user)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "207"
        FormDocumentUpload.id_report = id_propose
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_item_cat_main_pps SET id_report_status=5 WHERE id_item_cat_main_pps='" + id_propose + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 207, id_propose, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormItemCatMain.view_propose()
            FormItemCatMain.GVData.FocusedRowHandle = find_row(FormItemCatMain.GVData, "id_item_cat_main_pps", id_propose)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this category ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_item_cat_main_pps_det WHERE id_item_cat_main_pps_det='" + GVData.GetFocusedRowCellValue("id_item_cat_main_pps_det").ToString + "'"
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormItemCatMainAdd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub MENote_EditValueChanged(sender As Object, e As EventArgs) Handles MENote.EditValueChanged
        If is_confirm = 2 And id_report_status = "1" Then
            Dim query_upd As String = "UPDATE tb_item_cat_main_pps SET note='" + addSlashes(MENote.Text) + "' WHERE id_item_cat_main_pps='" + id_propose + "' "
            execute_non_query(query_upd, True, "", "", "", "")
            FormItemCatMain.view_propose()
            FormItemCatMain.GVData.FocusedRowHandle = find_row(FormItemCatMain.GVData, "id_item_cat_main_pps", id_propose)
        End If
    End Sub
End Class