Public Class ReportAwbInv
    Public Shared id_ver As String
    Public Shared dt As DataTable

    Private Sub ReportAwbInv_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCInvoice.DataSource = dt

        pre_load_mark_horz("310", id_ver, "2", "2", XrTable1)
    End Sub

    Private Sub GVInvoice_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVInvoice.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class