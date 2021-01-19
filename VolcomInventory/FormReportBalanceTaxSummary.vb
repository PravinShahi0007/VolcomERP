Public Class FormReportBalanceTaxSummary
    Private Sub FormReportBalanceTaxSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormReportBalanceTaxSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBNewSummary_Click(sender As Object, e As EventArgs) Handles SBNewSummary.Click
        FormReportBalanceTaxSummaryDet.id_summary = "-1"
        FormReportBalanceTaxSummaryDet.ShowDialog()
    End Sub
End Class