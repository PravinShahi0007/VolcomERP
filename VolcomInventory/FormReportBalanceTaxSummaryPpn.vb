Public Class FormReportBalanceTaxSummaryPpn
    Private Sub FormReportBalanceTaxSummaryPpn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormReportBalanceTaxSummaryPpn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBNewSummary_Click(sender As Object, e As EventArgs) Handles SBNewSummary.Click
        FormReportBalanceTaxSummaryPpnDet.id_summary = "-1"
        FormReportBalanceTaxSummaryPpnDet.ShowDialog()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT s.id_summary, s.number, DATE_FORMAT(s.period_from, '%d %M %Y') AS period_from, DATE_FORMAT(s.period_to, '%d %M %Y') AS period_to, r.report_status, e.employee_name AS created_by, DATE_FORMAT(s.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_tax_ppn_summary AS s
            LEFT JOIN tb_m_employee AS e ON s.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON s.id_report_status = r.id_report_status
            ORDER BY s.id_summary DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSummary.DataSource = data

        GVSummary.BestFitColumns()
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick
        FormReportBalanceTaxSummaryPpnDet.id_summary = GVSummary.GetFocusedRowCellValue("id_summary").ToString
        FormReportBalanceTaxSummaryPpnDet.ShowDialog()
    End Sub
End Class