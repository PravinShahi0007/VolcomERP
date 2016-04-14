Public Class ReportSalesOrder
    Public Shared id_sales_order As String
    Public Shared dt As DataTable

   
    Private Sub GVSalesOrder_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportSalesOrder_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSalesOrder.DataSource = dt
        load_mark_horz("39", id_sales_order, "2", "1", XrTable1)
    End Sub
End Class