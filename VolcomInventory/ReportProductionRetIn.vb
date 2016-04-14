Public Class ReportProductionRetIn
    Public Shared id_prod_order_ret_in As String = "0"
    Public Shared dt As DataTable

    Private Sub GVRetDetail_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportProductionRetOut_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCRetDetail.DataSource = dt
        load_mark_horz("32", id_prod_order_ret_in, "2", "1", XrTable1)
    End Sub
End Class