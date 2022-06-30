Public Class FormPromoRulesDet
    Public id As String = "-1"
    Public action As String = "-1"

    Private id_product As String = "-1"

    Sub viewDesignCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT * FROM tb_lookup_design_cat c"
        viewLookupQuery(LEProductStatus, query, 0, "design_cat", "id_design_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPromoRulesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesignCat()
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'dteail
            Dim qd As String = "SELECT o.*, 'no' AS `is_select` FROM tb_outlet o "
            Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
            GCStore.DataSource = dd
            GVStore.BestFitColumns()

            TxtLimitValue.EditValue = 0
            LEProductStatus.Focus()
            ActiveControl = LEProductStatus

            Dim curr_date As DateTime = getTimeDB()
            DEStart.EditValue = curr_date
            DEEnd.EditValue = curr_date

            LEProductStatus.ReadOnly = False
            TxtCode.ReadOnly = False
            DEStart.ReadOnly = False
            DEEnd.ReadOnly = False
            TxtLimitValue.ReadOnly = False
            GVStore.OptionsBehavior.ReadOnly = False
            BtnSave.Enabled = True
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BtnMark.Enabled = False

            TxtNumber.EditValue = "[autogenerate]"
            TxtCreatedDate.EditValue = DateTime.Now().ToString("dd MMMM yyyy HH:mm:ss")
            TxtCreatedBy.EditValue = get_emp(id_employee_user, "2")
        ElseIf action = "upd" Then
            Dim query As String = "SELECT r.id_rules, r.report_number, r.id_design_cat, dc.design_cat, r.limit_value, r.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`,
            r.period_start, r.period_end, e.employee_name AS created_by, DATE_FORMAT(r.created_date, '%d %M %Y %H:%i:%s') AS created_date, st.report_status
            FROM tb_promo_rules r 
            INNER JOIN tb_lookup_design_cat dc ON dc.id_design_cat = r.id_design_cat
            INNER JOIN tb_m_product p ON p.id_product = r.id_product 
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_employee e ON r.created_by = e.id_employee
            INNER JOIN tb_lookup_report_status st ON r.id_report_status = st.id_report_status
            WHERE r.id_rules='" + id + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEProductStatus.ItemIndex = LEProductStatus.Properties.GetDataSourceRowIndex("id_design_cat", data.Rows(0)("id_design_cat").ToString)
            TxtLimitValue.EditValue = data.Rows(0)("limit_value")
            id_product = data.Rows(0)("id_product").ToString
            TxtCode.Text = data.Rows(0)("code").ToString
            TxtName.Text = data.Rows(0)("name").ToString
            TxtSize.Text = data.Rows(0)("size").ToString
            DEStart.EditValue = data.Rows(0)("period_start")
            DEEnd.EditValue = data.Rows(0)("period_end")

            TxtNumber.EditValue = data.Rows(0)("report_number").ToString
            TxtCreatedDate.EditValue = data.Rows(0)("created_date").ToString
            TxtCreatedBy.EditValue = data.Rows(0)("created_by").ToString
            TxtReportStatus.EditValue = data.Rows(0)("report_status").ToString

            'detail
            Dim qd As String = "SELECT c.id_outlet, c.outlet_name, IF(!ISNULL(rd.id_outlet), 'yes', 'no') AS `is_select`
            FROM tb_outlet c
            LEFT JOIN tb_promo_rules_det rd ON rd.id_outlet = c.id_outlet AND rd.id_rules=" + id + " "
            Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
            GCStore.DataSource = dd
            GVStore.BestFitColumns()

            LEProductStatus.ReadOnly = True
            TxtCode.ReadOnly = True
            DEStart.ReadOnly = True
            DEEnd.ReadOnly = True
            TxtLimitValue.ReadOnly = True
            GVStore.OptionsBehavior.ReadOnly = True
            BtnSave.Enabled = False
            BtnPrint.Enabled = True
            BtnAttachment.Enabled = True
            BtnMark.Enabled = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormPromoRulesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim code As String = addSlashes(TxtCode.Text)
            Dim query As String = "SELECT p.id_product, p.product_full_code AS `code`, CONCAT(class.code, ' ', d.design_name, ' ', color.display_name) AS `name`, cd.code_detail_name AS `size` 
            FROM tb_m_product p
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            LEFT JOIN (
                SELECT c.id_design, d.code
                FROM tb_m_design_code AS c
                LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
                WHERE d.id_code = 30
            ) AS class ON d.id_design = class.id_design
            LEFT JOIN (
                SELECT c.id_design, d.display_name
                FROM tb_m_design_code AS c
                LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
                WHERE d.id_code = 14
            ) AS color ON d.id_design = color.id_design
            WHERE d.id_lookup_status_order!=2 AND d.id_active=1 AND p.product_full_code='" + code + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                id_product = data.Rows(0)("id_product").ToString
                TxtCode.Text = data.Rows(0)("code").ToString
                TxtName.Text = data.Rows(0)("name").ToString
                TxtSize.Text = data.Rows(0)("size").ToString
            Else
                stopCustom("Code not found")
                TxtCode.Text = ""
                resetProduct()
            End If
            Cursor = Cursors.Default
        Else
            resetProduct()
        End If
    End Sub

    Sub resetProduct()
        id_product = "-1"
        TxtName.Text = ""
    End Sub

    Sub insertDetail()
        'detail
        makeSafeGV(GVStore)
        GVStore.ActiveFilterString = "[is_select]='yes'"
        Dim query_det As String = "INSERT INTO tb_promo_rules_det(id_rules, id_outlet) VALUES "
        For i As Integer = 0 To GVStore.RowCount - 1
            If i > 0 Then
                query_det += ", "
            End If
            query_det += "(" + id + ", " + GVStore.GetRowCellValue(i, "id_outlet").ToString + ") "
        Next
        If GVStore.RowCount > 0 Then
            execute_non_query(query_det, True, "", "", "", "")
        End If
        GVStore.ActiveFilterString = ""
    End Sub

    Sub syncStore()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVStore)
        GVStore.ActiveFilterString = "[is_select]='yes'"
        For i As Integer = 0 To GVStore.RowCount - 1
            Dim id_outlet As String = GVStore.GetRowCellValue(i, "id_outlet").ToString
            Dim host As String = GVStore.GetRowCellValue(i, "host").ToString
            Dim username As String = GVStore.GetRowCellValue(i, "username").ToString
            Dim pass As String = GVStore.GetRowCellValue(i, "pass").ToString
            Dim db As String = GVStore.GetRowCellValue(i, "db").ToString
            Dim period_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim period_end As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim query As String = "INSERT INTO tb_promo_rules(id_rules, id_design_cat, limit_value, id_product, product_code, product_name, period_start, period_end) VALUES
            ('" + id + "', '" + LEProductStatus.EditValue.ToString + "', '" + decimalSQL(TxtLimitValue.EditValue.ToString) + "', '" + id_product + "', '" + addSlashes(TxtCode.Text) + "', '" + addSlashes(TxtName.Text) + "', '" + period_start + "', '" + period_end + "'); "
            execute_non_query_long(query, False, host, username, pass, db)
        Next
        GVStore.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_product = "-1" Then
            stopCustom("Product not found")
        Else
            Dim id_design_cat As String = LEProductStatus.EditValue.ToString
            Dim limit_value As String = decimalSQL(TxtLimitValue.EditValue.ToString)
            Dim product_code As String = addSlashes(TxtCode.Text)
            Dim product_name As String = addSlashes(TxtName.Text)
            Dim period_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim period_end As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this rule ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'main
                    Dim query As String = "INSERT INTO tb_promo_rules(id_design_cat, limit_value, id_product, product_code, product_name,period_start, period_end, id_report_status, created_date, created_by) VALUES (" + id_design_cat + ", " + limit_value + ", " + id_product + ", '" + product_code + "', '" + product_name + "', '" + period_start + "', '" + period_end + "', 1, NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    insertDetail()

                    'sync to store
                    'syncStore()

                    execute_non_query("CALL gen_number(" + id + ", '413')", True, "", "", "", "")

                    submit_who_prepared("413", id, id_user)

                    'refresh
                    FormPromoRules.viewRules()
                    'FormPromoRules.viewStore()
                    FormPromoRules.GVRules.FocusedRowHandle = find_row(FormPromoRules.GVRules, "id_rules", id)
                    'Close()

                    action = "upd"

                    actionLoad()
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes this rule ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    'hapus di toko
                    Dim qold As String = "SELECT * 
                    FROM tb_promo_rules_det rd
                    INNER JOIN tb_store_conn c ON c.id_outlet = rd.id_outlet
                    WHERE rd.id_rules=" + id + " "
                    Dim dold As DataTable = execute_query(qold, -1, True, "", "", "", "")
                    For i As Integer = 0 To dold.Rows.Count - 1
                        Dim id_outlet As String = dold.Rows(i)("id_outlet").ToString
                        Dim host As String = dold.Rows(i)("host").ToString
                        Dim username As String = dold.Rows(i)("username").ToString
                        Dim pass As String = dold.Rows(i)("pass").ToString
                        Dim db As String = dold.Rows(i)("db").ToString

                        Dim qds As String = "DELETE FROM tb_promo_rules WHERE id_rules='" + id + "' "
                        execute_non_query_long(qds, False, host, username, pass, db)
                    Next

                    'main 
                    Dim query As String = "UPDATE tb_promo_rules Set id_design_cat='" + id_design_cat + "', limit_value='" + limit_value + "', id_product='" + id_product + "', product_code='" + product_code + "', product_name='" + product_name + "',period_start='" + period_start + "', period_end='" + period_end + "' WHERE id_rules='" + id + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'detail
                    Dim query_det As String = "DELETE FROM tb_promo_rules_det WHERE id_rules='" + id + "' "
                    execute_non_query(query_det, True, "", "", "", "")
                    insertDetail()

                    'synv
                    'syncStore()

                    'refresh
                    FormPromoRules.viewRules()
                    'FormPromoRules.viewStore()
                    FormPromoRules.GVRules.FocusedRowHandle = find_row(FormPromoRules.GVRules, "id_rules", id)
                    actionLoad()
                    'Close()

                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Dim report_mark_type As String = "413"

        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Dim report_mark_type As String = "413"

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = report_mark_type

        FormDocumentUpload.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim report As New ReportPromoRules()

        report.id = id

        report.XLNumber.Text = TxtNumber.EditValue.ToString
        report.XLCreatedAt.Text = TxtCreatedDate.EditValue.ToString
        report.XLCreatedBy.Text = TxtCreatedBy.EditValue.ToString
        report.XLProductStatus.Text = LEProductStatus.Text
        report.XLProductCode.Text = TxtCode.EditValue.ToString
        report.XLDescription.Text = TxtName.EditValue.ToString
        report.XLActiveDate.Text = DEStart.Text.ToString + " - " + DEEnd.Text.ToString
        report.XLLimitSize.Text = Format(TxtLimitValue.EditValue, "##,##0")
        report.XLSize.Text = TxtSize.EditValue.ToString

        Dim all As DataTable = GCStore.DataSource

        Dim data As DataTable = all.Clone

        For i = 0 To all.Rows.Count - 1
            If all.Rows(i)("is_select").ToString = "yes" Then
                data.ImportRow(all.Rows(i))
            End If
        Next

        report.GCStore.DataSource = data

        report.GVStore.BestFitColumns()

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub
End Class