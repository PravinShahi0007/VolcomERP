Public Class FormItemCatProposeDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"

    Private Sub FormItemCatProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormItemCatProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim query_c As New ClassItemCat()
        Dim query As String = query_c.queryMain("AND ip.id_item_cat_propose=" + id + "", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString

        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT d.id_item_cat_propose_det, d.id_item_cat_propose, d.id_expense_type, ex.expense_type, d.item_cat, d.item_cat_en 
        FROM tb_item_cat_propose_det d 
        INNER JOIN tb_lookup_expense_type ex ON ex.id_expense_type = d.id_expense_type
        WHERE d.id_item_cat_propose=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            GVData.OptionsBehavior.Editable = True
            MENote.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            GVData.OptionsBehavior.Editable = False
            MENote.Enabled = False
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
            GVData.OptionsBehavior.Editable = False
            MENote.Enabled = False
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "134"
        FormReportMark.id_report = id
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'update confirm
            Dim query As String = "UPDATE tb_item_cat_propose SET is_confirm=1 WHERE id_item_cat_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'submit approval
            submit_who_prepared(134, id, id_user)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "134"
        FormDocumentUpload.id_report = id
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
            Dim query As String = "UPDATE tb_item_cat_propose SET id_report_status=5 WHERE id_item_cat_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")
            FormItemCatPropose.viewPropose()
            FormItemCatPropose.GVData.FocusedRowHandle = find_row(FormItemCatPropose.GVData, "id_item_cat_propose", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this category ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_item_cat_propose_det WHERE id_item_cat_propose_det='" + GVData.GetFocusedRowCellValue("id_item_cat_propose_det").ToString + "'"
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormItemCatProposeAdd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub MENote_EditValueChanged(sender As Object, e As EventArgs) Handles MENote.EditValueChanged
        Dim query_upd As String = "UPDATE tb_item_cat_propose SET note='" + addSlashes(MENote.Text) + "' WHERE id_item_cat_propose='" + id + "' "
        execute_non_query(query_upd, True, "", "", "", "")
        FormItemCatPropose.viewPropose()
        FormItemCatPropose.GVData.FocusedRowHandle = find_row(FormItemCatPropose.GVData, "id_item_cat_propose", id)
    End Sub
End Class