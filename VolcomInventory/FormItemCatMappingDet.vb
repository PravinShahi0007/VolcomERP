Public Class FormItemCatMappingDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"

    Private Sub FormItemCatMappingDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormItemCatMappingDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEExp, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEInv, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub actionLoad()
        CheckEditCat.EditValue = False
        SLEInv.Enabled = False
        Dim query_c As New ClassItemCat()
        Dim query As String = query_c.queryMappingPropose("AND cp.id_item_coa_propose=" + id + "", "2")
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
        GCMaping.DataSource = data
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            GVMapping.OptionsBehavior.Editable = True
            MENote.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            GVMapping.OptionsBehavior.Editable = False
            MENote.Enabled = False
            GCMaping.ContextMenuStrip = Nothing
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Visible = True
        Else
            BtnPrint.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            GVMapping.OptionsBehavior.Editable = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            GVMapping.OptionsBehavior.Editable = False
            MENote.Enabled = False
            GCMaping.ContextMenuStrip = Nothing
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
            Dim query As String = "UPDATE tb_item_coa_propose SET is_confirm=1 WHERE id_item_coa_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'submit approval
            submit_who_prepared(135, id, id_user)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCMaping, "")
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "135"
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
            Dim query As String = "UPDATE tb_item_coa_propose SET id_report_status=5 WHERE id_item_coa_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 135, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormItemCatMapping.viewPropose()
            FormItemCatMapping.GVPropose.FocusedRowHandle = find_row(FormItemCatMapping.GVPropose, "id_item_coa_propose", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        'Cursor = Cursors.WaitCursor
        'FormItemCatProposeAdd.ShowDialog()
        'Cursor = Cursors.Default
    End Sub

    Private Sub MENote_EditValueChanged(sender As Object, e As EventArgs) Handles MENote.EditValueChanged
        Dim query_upd As String = "UPDATE tb_item_coa_propose SET note='" + addSlashes(MENote.Text) + "' WHERE id_item_coa_propose='" + id + "' "
        execute_non_query(query_upd, True, "", "", "", "")
        FormItemCatMapping.viewPropose()
        FormItemCatMapping.GVPropose.FocusedRowHandle = find_row(FormItemCatMapping.GVPropose, "id_item_coa_propose", id)
    End Sub

    Private Sub XTPNewMapping_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged

    End Sub

    Private Sub CheckEditCat_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditCat.CheckedChanged
        If CheckEditCat.EditValue = True Then
            SLEInv.Enabled = True
        Else
            SLEInv.Enabled = False
        End If
    End Sub

    Private Sub BtnAdd_Click_1(sender As Object, e As EventArgs) Handles BtnAdd.Click
        add()
    End Sub

    Sub add()
        Dim id_item_cat As String = LECat.EditValue.ToString
        Dim id_departement As String = LEDeptSum.EditValue.ToString
        Dim id_coa_out As String = SLEExp.EditValue.ToString
        Dim id_coa_in As String = ""
        If CheckEditCat.EditValue = True Then
            id_coa_in = SLEInv.EditValue.ToString
        Else
            id_coa_in = "NULL"
        End If
        Dim is_request As String = ""
        If CheckEditReq.EditValue = True Then
            is_request = "1"
        Else
            is_request = "2"
        End If
        Dim is_expense As String = ""
        If CheckEditExpense.EditValue = True Then
            is_expense = "1"
        Else
            is_expense = "2"
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnAddMulti.Click
        Cursor = Cursors.WaitCursor
        FormItemCoaProposeAdd.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class