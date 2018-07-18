Public Class FormBudgetRevProposeDet
    Public id As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "-1"

    Private Sub FormBudgetRevProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtTotalInput.EditValue = 0.00
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormBudgetRevProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim query_c As New ClassBudgetRevPropose()
        Dim query As String = query_c.queryMain("AND rp.id_b_revenue_propose=" + id + "", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TxtYear.Text = data.Rows(0)("year").ToString
        TxtTotal.EditValue = data.Rows(0)("total")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString

        viewDetail()
        getTotal()
        allow_status()
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_b_revenue_propose(" + id + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnChange.Enabled = True
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            GVData.OptionsBehavior.Editable = True
        Else
            BtnChange.Enabled = False
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            GVData.OptionsBehavior.Editable = False
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
            BtnChange.Enabled = False
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            GVData.OptionsBehavior.Editable = False
        End If
    End Sub

    Sub getTotal()
        Dim query As String = "SELECT IFNULL(SUM(bd.b_revenue_propose),0) AS `total` FROM tb_b_revenue_propose_det bd WHERE bd.id_b_revenue_propose=" + id + ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtTotalInput.EditValue = data.Rows(0)("total")
        TxtDiff.EditValue = TxtTotal.EditValue - TxtTotalInput.EditValue
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "133"
        FormReportMark.id_report = id
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnChange.Click
        Cursor = Cursors.WaitCursor
        FormBudgetRevProposeNew.action = "upd"
        FormBudgetRevProposeNew.id = id
        FormBudgetRevProposeNew.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim old_val As Decimal = GVData.ActiveEditor.OldEditValue
        Dim row_foc As String = e.RowHandle.ToString
        Dim month As String = e.Column.FieldName.ToString
        Dim id_store As String = GVData.GetRowCellValue(row_foc, "id_comp")
        Dim b_revenue_propose As String = decimalSQL(e.Value.ToString)
        If ((TxtTotalInput.EditValue - old_val) + e.Value) <= TxtTotal.EditValue Then
            Dim query As String = "DELETE FROM tb_b_revenue_propose_det 
            WHERE id_b_revenue_propose = " + id + " And id_store = " + id_store + " And month = " + month + ";
            INSERT INTO tb_b_revenue_propose_det(id_b_revenue_propose, id_store, month, b_revenue_propose)
            VALUES('" + id + "','" + id_store + "', '" + month + "','" + b_revenue_propose + "'); "
            execute_non_query(query, True, "", "", "", "")
            GVData.RefreshData()
            GVData.BestFitColumns()
            getTotal()
        Else
            stopCustom("Total budget higher than yearly budget.")
            GVData.SetRowCellValue(row_foc, month, old_val)
            GVData.RefreshData()
            GVData.BestFitColumns()
        End If

        Cursor = Cursors.Default
        'Dim id_comp As String = GVData.GetRowCellValue(row_foc, "id_comp").ToString
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this budget ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'update confirm
            Dim query As String = "UPDATE tb_b_revenue_propose SET is_confirm=1 WHERE id_b_revenue_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'submit approval
            submit_who_prepared(133, id, id_user)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "133"
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this budget ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_b_revenue_propose SET id_report_status=5 WHERE id_b_revenue_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")
            FormBudgetRevPropose.viewData()
            FormBudgetRevPropose.GVRev.FocusedRowHandle = find_row(FormBudgetRevPropose.GVRev, "id_b_revenue_propose", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub
End Class