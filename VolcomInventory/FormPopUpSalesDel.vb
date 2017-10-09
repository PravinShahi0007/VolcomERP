Public Class FormPopUpSalesDel
    Public id_so_status As String = "-1"

    Sub view_detail()
        If GVSalesDelOrder.RowCount > 0 Then
            Dim query_det As String = "CALL view_pl_sales_order_del_inv('" + GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString + "')"
            Dim data_det As DataTable = execute_query(query_det, "-1", True, "", "", "", "")
            GCItemList.DataSource = data_det
        End If
    End Sub

    Private Sub GVSalesDelOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesDelOrder.FocusedRowChanged
        view_detail()
    End Sub

    Private Sub GVSalesDelOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesDelOrder.ColumnFilterChanged
        view_detail()
    End Sub

    Sub viewSalesDelOrder()
        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim query As String = query_c.queryMainInvoice(id_so_status + "AND a.id_report_status='6' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
    End Sub

    Private Sub FormPopUpSalesDel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSalesDelOrder()
    End Sub

    Private Sub FormPopUpSalesDel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVSalesDelOrder.RowCount > 0 Then
            FormSalesPOSDet.TEDO.Text = GVSalesDelOrder.GetFocusedRowCellValue("pl_sales_order_del_number").ToString
            FormSalesPOSDet.id_do = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            FormSalesPOSDet.view_do()
            FormSalesPOSDet.calculate()
            Close()
        Else
            stopCustom("Please select delivery order first.")
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class