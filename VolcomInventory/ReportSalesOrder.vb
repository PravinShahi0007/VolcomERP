Public Class ReportSalesOrder
    Public Shared id_sales_order As String
    Public Shared dt As DataTable

   
    Private Sub GVSalesOrder_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportSalesOrder_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'title so
        Dim qh As String = "SELECT ot.description FROM tb_sales_order so 
        INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = so.id_so_status
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = cat.id_order_type
        WHERE so.id_sales_order=" + id_sales_order + " "
        Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
        LTitle.Text = dh.Rows(0)("description").ToString.ToUpper

        GCSalesOrder.DataSource = dt
        load_mark_horz("39", id_sales_order, "2", "1", XrTable1)
    End Sub
End Class