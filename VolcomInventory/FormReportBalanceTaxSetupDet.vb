Public Class FormReportBalanceTaxSetupDet
    Public id_setup_tax As String = "-1"

    Private Sub FormReportBalanceTaxSetupDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_coa_tag()
        view_setup_tax()
        view_report_status()

        form_load()
    End Sub

    Private Sub FormReportBalanceTaxSetupDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBGenerateSummary_Click(sender As Object, e As EventArgs) Handles SBGenerateSetupTax.Click
        If Not (TETotal.Text = "" Or TETotal.EditValue <= 0) Then
            Dim from_date As Date = Date.Parse("1 " + DEDateFrom.Text)
            Dim to_date As Date = Date.Parse("1 " + DEDateTo.Text)

            Dim continue_loop As Boolean = True

            GCSetupTax.DataSource = Nothing

            Dim data As DataTable = New DataTable

            data.Columns.Add("no", GetType(Integer))
            data.Columns.Add("bulan", GetType(Date))
            data.Columns.Add("total", GetType(Decimal))

            Dim no As Integer = 1
            Dim total As Decimal = Decimal.Round(TETotal.EditValue / (DateDiff(DateInterval.Month, from_date, to_date) + 1), 2)

            While continue_loop
                Dim row As DataRow = data.NewRow

                row("no") = no
                row("bulan") = Date.Parse(from_date.ToString)
                row("total") = total

                data.Rows.Add(row)

                from_date = from_date.AddMonths(1)

                no = no + 1

                If from_date > to_date Then
                    continue_loop = False
                End If
            End While

            GCSetupTax.DataSource = data
        Else
            errorCustom("Please check your input.")
        End If
    End Sub

    Sub view_coa_tag()
        Dim query As String = "
            SELECT id_coa_tag, tag_description
            FROM tb_coa_tag
        "

        viewSearchLookupQuery(SLUETag, query, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Sub view_setup_tax()
        Dim where As String = ""

        If SLUETag.EditValue.ToString = "1" Then
            where = "available_in_office_tag = 1"
        Else
            where = "available_in_store_tag = 1"
        End If

        Dim query As String = "
            SELECT id_tax_report, tax_report
            FROM tb_lookup_tax_report
            WHERE id_type = 1 AND " + where + "
            ORDER BY sorting
        "

        viewSearchLookupQuery(SLUETax, query, "id_tax_report", "tax_report", "id_tax_report")
    End Sub

    Sub view_report_status()
        Dim query As String = "
            SELECT 0 AS id_report_status, '' AS report_status
            UNION ALL
            SELECT id_report_status, report_status
            FROM tb_lookup_report_status
        "

        viewSearchLookupQuery(SLUEReportStatus, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "288"
        FormReportMark.id_report = id_setup_tax

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim period_from As String = Date.Parse("1 " + DEDateFrom.Text).ToString("yyyy-MM-dd")
            Dim period_to As String = Date.Parse("1 " + DEDateTo.Text).ToString("yyyy-MM-dd")

            Dim query As String = "INSERT INTO tb_setup_tax_installment (id_coa_tag, id_tax_report, period_from, period_to, id_report_status, created_at, created_by) VALUES (" + SLUETag.EditValue.ToString + ", " + SLUETax.EditValue.ToString + ", '" + period_from + "', '" + period_to + "', 1, NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

            id_setup_tax = execute_query(query, 0, True, "", "", "", "")

            Dim query_detail As String = "INSERT INTO tb_setup_tax_installment_det (id_setup_tax, month_year, balance) VALUES "

            For i = 0 To GVSetupTax.RowCount - 1
                If GVSetupTax.IsValidRowHandle(i) Then
                    query_detail = query_detail + "(" + id_setup_tax + ", '" + Date.Parse(GVSetupTax.GetRowCellValue(i, "bulan").ToString).ToString("yyyy-MM-dd") + "', '" + decimalSQL(GVSetupTax.GetRowCellValue(i, "total").ToString) + "'), "
                End If
            Next

            query_detail = query_detail.Substring(0, query_detail.Length - 2)

            execute_non_query(query_detail, True, "", "", "", "")

            execute_non_query("UPDATE tb_setup_tax_installment SET `number` = CONCAT('STINS', LPAD(" + id_setup_tax + ", 7, '0'))  WHERE id_setup_tax = " + id_setup_tax + ";", True, "", "", "", "")

            submit_who_prepared("288", id_setup_tax, id_user)

            infoCustom("Saved.")

            form_load()
        End If
    End Sub

    Sub form_load()
        TENumber.EditValue = "[autogenerate]"

        DEDateFrom.EditValue = Now
        DEDateTo.EditValue = Now

        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        TECreatedAt.EditValue = DateTime.Parse(execute_query("SELECT NOW()", 0, True, "", "", "", "")).ToString("dd MMMM yyyy HH:mm:ss")
        SLUEReportStatus.EditValue = "0"
        SLUETax.EditValue = "15"
        TETotal.EditValue = 0.00

        If Not id_setup_tax = "-1" Then
            Dim query As String = "
                SELECT s.id_coa_tag, s.id_tax_report, s.number, DATE_FORMAT(s.period_from, '%d %M %Y') AS period_from, DATE_FORMAT(s.period_to, '%d %M %Y') AS period_to, s.id_report_status, e.employee_name AS created_by, DATE_FORMAT(s.created_at, '%d %M %Y %H:%i:%s') AS created_at, p.total
                FROM tb_setup_tax_installment AS s
                LEFT JOIN (
	                SELECT id_setup_tax, SUM(balance) AS total
	                FROM tb_setup_tax_installment_det
                    WHERE id_setup_tax = " + id_setup_tax + "
                ) AS p ON s.id_setup_tax = p.id_setup_tax
                LEFT JOIN tb_m_employee AS e ON s.created_by = e.id_employee
                WHERE s.id_setup_tax = " + id_setup_tax + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            SLUETag.EditValue = data.Rows(0)("id_coa_tag").ToString
            SLUETax.EditValue = data.Rows(0)("id_tax_report").ToString
            TETotal.EditValue = data.Rows(0)("total")
            TENumber.EditValue = data.Rows(0)("number").ToString
            DEDateFrom.EditValue = data.Rows(0)("period_from").ToString
            DEDateTo.EditValue = data.Rows(0)("period_to").ToString
            TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
            TECreatedAt.EditValue = data.Rows(0)("created_at").ToString
            SLUEReportStatus.EditValue = data.Rows(0)("id_report_status").ToString

            Dim query_detail As String = "
                SELECT 0 AS `no`, month_year AS bulan, balance AS total
                FROM tb_setup_tax_installment_det
                WHERE id_setup_tax = " + id_setup_tax + "
            "

            Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

            'numbering
            Dim last_tag_description As String = "0"

            Dim no As Integer = 0

            For i = 0 To data_detail.Rows.Count - 1
                no = no + 1

                data_detail.Rows(i)("no") = no
            Next

            GCSetupTax.DataSource = data_detail
        End If

        'controls
        If SLUEReportStatus.EditValue.ToString = "0" Then
            SBPrint.Visible = False
            SBAttachment.Visible = False
            SBMark.Visible = False
            SBSubmit.Visible = True

            DEDateFrom.ReadOnly = False
            DEDateTo.ReadOnly = False
            SLUETax.ReadOnly = False
            SLUETag.ReadOnly = False
            TETotal.ReadOnly = False
            SBGenerateSetupTax.Enabled = True
        Else
            SBPrint.Visible = True
            SBAttachment.Visible = True
            SBMark.Visible = True
            SBSubmit.Visible = False

            DEDateFrom.ReadOnly = True
            DEDateTo.ReadOnly = True
            SLUETax.ReadOnly = True
            SLUETag.ReadOnly = True
            TETotal.ReadOnly = True
            SBGenerateSetupTax.Enabled = False
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As New ReportBalanceTaxSetup()

        report.id_setup_tax = id_setup_tax
        report.data = GCSetupTax.DataSource
        report.id_pre = If(SLUEReportStatus.EditValue.ToString = "6", "-1", "1")

        report.XLNumber.Text = TENumber.Text
        report.XLDate.Text = report.XLDate.Text.Replace("[date]", TECreatedAt.Text)
        report.XLPeriod.Text = report.XLPeriod.Text.Replace("[period_from]", DEDateFrom.Text)
        report.XLPeriod.Text = report.XLPeriod.Text.Replace("[period_to]", DEDateTo.Text)
        report.XLTaxReport.Text = report.XLTaxReport.Text.Replace("[tax_report]", SLUETax.Text)
        report.XLTag.Text = report.XLTag.Text.Replace("[tag]", SLUETag.Text)

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_setup_tax
        FormDocumentUpload.report_mark_type = "288"
        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SLUETag_EditValueChanged(sender As Object, e As EventArgs) Handles SLUETag.EditValueChanged
        view_setup_tax()
    End Sub
End Class