Public Class FormShipInvoiceDet
    Public id As String = "-1"
    Public report_mark_type As String = "249"
    Public is_view = "-1"

    Private Sub FormShipInvoiceDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id
        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
End Class