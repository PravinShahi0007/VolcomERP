Public Class FormReportBalanceTaxSummaryDet
    Private Sub FormReportBalanceTaxSummaryDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateFrom.EditValue = Now
        DEDateTo.EditValue = Now
    End Sub

    Private Sub FormReportBalanceTaxSummaryDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBGenerateSummary_Click(sender As Object, e As EventArgs) Handles SBGenerateSummary.Click
        Dim data As DataTable = execute_query("CALL view_summary_tax_pph('" + Date.Parse(DEDateFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEDateTo.EditValue.ToString).ToString("yyyy-MM-dd") + "')", -1, True, "", "", "", "")

        GCSummary.DataSource = data

        GVSummary.BestFitColumns()
    End Sub

    Sub view_period()

    End Sub
End Class