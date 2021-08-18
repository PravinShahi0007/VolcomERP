Public Class ReportSNIOut
    Public Shared id_qc_sni_out As String = "-1"
    Public Shared dt As DataTable

    Private Sub GVDetail_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportSNIOut_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDetail.DataSource = dt
        load_mark_horz("330", id_qc_sni_out, "2", "1", XrTable1)
    End Sub
End Class