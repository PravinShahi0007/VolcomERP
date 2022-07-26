Public Class FormPromoRulesClose
    Public id As String = "0"

    Private Sub FormPromoRulesClose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        viewProposedRules()

        TxtNumber.EditValue = "[autogenerate]"
        TxtCreatedDate.EditValue = Date.Parse(getTimeDB()).ToString("dd MMMM yyyy HH:mm:ss")
        TxtCreatedBy.EditValue = get_emp(id_employee_user, "2")
        MEReason.EditValue = ""

        SLUEProposedGWP.ReadOnly = False
        BtnSave.Enabled = True
        BtnPrint.Enabled = False
        BtnAttachment.Enabled = False
        BtnMark.Enabled = False
        MEReason.ReadOnly = False
        GVStore.OptionsBehavior.Editable = True

        If Not id = "0" Then
            Dim query_head As String = "
                SELECT c.report_number, DATE_FORMAT(c.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, t.report_status, c.note
                FROM tb_close_promo_rules AS c
                LEFT JOIN tb_m_employee AS e ON c.created_by = e.id_employee
                LEFT JOIN tb_lookup_report_status t ON c.id_report_status = t.id_report_status
                WHERE c.id_close_promo_rules = " + id + "
            "

            Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")

            TxtNumber.EditValue = data_head.Rows(0)("report_number").ToString
            TxtCreatedDate.EditValue = data_head.Rows(0)("created_date").ToString
            TxtCreatedBy.EditValue = data_head.Rows(0)("created_by").ToString
            TxtReportStatus.EditValue = data_head.Rows(0)("report_status").ToString
            MEReason.EditValue = data_head.Rows(0)("note").ToString

            SLUEProposedGWP.ReadOnly = True
            BtnSave.Enabled = False
            BtnPrint.Enabled = True
            BtnAttachment.Enabled = True
            BtnMark.Enabled = True
            MEReason.ReadOnly = True
            GVStore.OptionsBehavior.Editable = False

            Dim query_detail As String = "
                SELECT o.id_outlet, o.outlet_name, 'yes' AS is_select
                FROM tb_close_promo_rules_det AS d
                LEFT JOIN tb_outlet AS o ON d.id_outlet = o.id_outlet
                WHERE d.id_close_promo_rules = " + id + "
            "

            Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

            GCStore.DataSource = data_detail
        End If
    End Sub

    Sub viewProposedRules()
        Dim query As String = ""

        If id = "0" Then
            query = "
                SELECT r.id_rules, r.report_number, r.product_code, r.product_name
                FROM tb_promo_rules AS r
                LEFT JOIN (
	                SELECT id_rules, COUNT(id_rules) AS total
	                FROM tb_promo_rules_det
	                GROUP BY id_rules
                ) AS s ON r.id_rules = s.id_rules
                LEFT JOIN (
	                SELECT r.id_rules, COUNT(r.id_rules) AS total
	                FROM tb_close_promo_rules_det AS d
	                LEFT JOIN tb_close_promo_rules AS r ON d.id_close_promo_rules = r.id_close_promo_rules
                    WHERE r.id_report_status <> 5
	                GROUP BY r.id_rules
                ) AS c ON r.id_rules = c.id_rules
                WHERE r.period_end >= DATE(NOW()) AND r.id_report_status = 6 AND s.total > IFNULL(c.total, 0)
            "
        Else
            query = "
                SELECT r.id_rules, r.report_number, r.product_code, r.product_name
                FROM tb_promo_rules AS r
                WHERE r.id_rules = (SELECT id_rules FROM tb_close_promo_rules WHERE id_close_promo_rules = " + id + ")
            "
        End If

        viewSearchLookupQuery(SLUEProposedGWP, query, "id_rules", "report_number", "id_rules")
    End Sub

    Sub viewStore()
        Dim query As String = "
            SELECT o.id_outlet, o.outlet_name, 'no' AS is_select
            FROM tb_promo_rules_det AS d
            LEFT JOIN tb_outlet AS o ON d.id_outlet = o.id_outlet
            WHERE d.id_rules = " + SLUEProposedGWP.EditValue.ToString + " AND d.id_outlet NOT IN (
                SELECT x.id_outlet
                FROM tb_close_promo_rules_det AS x
                LEFT JOIN tb_close_promo_rules AS s ON x.id_close_promo_rules = s.id_close_promo_rules
                WHERE s.id_report_status <> 5 AND s.id_rules = d.id_rules
            )
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCStore.DataSource = data
    End Sub

    Private Sub SLUEProposedGWP_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEProposedGWP.EditValueChanged
        viewStore()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormPromoRulesClose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Dim report_mark_type As String = "416"

        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Dim report_mark_type As String = "416"

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = report_mark_type

        FormDocumentUpload.ShowDialog()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor

        If MEReason.EditValue.ToString = "" Then
            stopCustom("Please fill reason.")

            Cursor = Cursors.Default

            Exit Sub
        End If

        GVStore.ActiveFilterString = "[is_select]='yes'"

        If GVStore.RowCount = 0 Then
            stopCustom("Please select store.")

            GVStore.ActiveFilterString = ""

            Cursor = Cursors.Default

            Exit Sub
        End If

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close this GWP ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query_head As String = "
                INSERT INTO tb_close_promo_rules (id_rules, note, id_report_status, created_date, created_by) VALUES (" + SLUEProposedGWP.EditValue.ToString + ", '" + addSlashes(MEReason.EditValue.ToString) + "', 1, NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();
            "

            id = execute_query(query_head, 0, True, "", "", "", "")

            Dim query_detail As String = "INSERT INTO tb_close_promo_rules_det (id_close_promo_rules, id_outlet) VALUES "

            For i = 0 To GVStore.RowCount - 1
                query_detail += "(" + id + ", " + GVStore.GetRowCellValue(i, "id_outlet").ToString + "), "
            Next

            query_detail = query_detail.Substring(0, query_detail.Length - 2)

            execute_non_query(query_detail, True, "", "", "", "")

            execute_non_query("CALL gen_number(" + id + ", '416')", True, "", "", "", "")

            submit_who_prepared("416", id, id_user)

            FormPromoRules.viewClosed()
            FormPromoRules.GVClosed.FocusedRowHandle = find_row(FormPromoRules.GVClosed, "id_close_promo_rules", id)

            actionLoad()
        End If

        GVStore.ActiveFilterString = ""

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub
End Class