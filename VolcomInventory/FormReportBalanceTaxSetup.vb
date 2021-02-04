Public Class FormReportBalanceTaxSetup
    Private Sub FormReportBalanceTaxSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormReportBalanceTaxSetup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBNewSummary_Click(sender As Object, e As EventArgs) Handles SBNewSetupTax.Click
        FormReportBalanceTaxSetupDet.id_setup_tax = "-1"
        FormReportBalanceTaxSetupDet.ShowDialog()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT s.id_setup_tax, s.number, t.tax_report, p.total, DATE_FORMAT(s.period_from, '%M %Y') AS period_from, DATE_FORMAT(s.period_to, '%M %Y') AS period_to, r.report_status, e.employee_name AS created_by, DATE_FORMAT(s.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_setup_tax_installment AS s
            LEFT JOIN tb_lookup_tax_report AS t ON s.id_tax_report = t.id_tax_report
            LEFT JOIN (
	            SELECT id_setup_tax, SUM(balance) AS total
	            FROM tb_setup_tax_installment_det
	            GROUP BY id_setup_tax
            ) AS p ON s.id_setup_tax = p.id_setup_tax
            LEFT JOIN tb_m_employee AS e ON s.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON s.id_report_status = r.id_report_status
            ORDER BY s.id_setup_tax DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSetupTax.DataSource = data

        GVSetupTax.BestFitColumns()
    End Sub

    Private Sub GVSetupTax_DoubleClick(sender As Object, e As EventArgs) Handles GVSetupTax.DoubleClick
        FormReportBalanceTaxSetupDet.id_setup_tax = GVSetupTax.GetFocusedRowCellValue("id_setup_tax").ToString
        FormReportBalanceTaxSetupDet.ShowDialog()
    End Sub
End Class