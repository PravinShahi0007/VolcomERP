Public Class FormSalesReturnOrderRevise
    Public id_sales_return_order As String = "-1"
    Public id_sales_return_order_det As String = "-1"

    Private Sub TextEdit5_Properties_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtProcess.Properties.KeyUp, TxtOutstanding.Properties.KeyUp, TxtAdd.Properties.KeyUp

    End Sub

    Private Sub FormSalesReturnOrderRevise_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesReturnOrderRevise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_sales_return_order_limit('" + id_sales_return_order + "','" + id_sales_return_order_det + "','0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtCode.Text = data.Rows(0)("code").ToString
        TxtDesign.Text = data.Rows(0)("name").ToString
        TxtSize.Text = data.Rows(0)("size").ToString
        TxtProcess.EditValue = data.Rows(0)("sales_return_det_qty_view")
        TxtOutstanding.EditValue = data.Rows(0)("sales_return_det_qty_limit")
        getTotalOrder()
        ActiveControl = TxtOutstanding
    End Sub

    Sub getTotalOrder()
        Dim process As Integer = 0
        Try
            process = TxtProcess.EditValue
        Catch ex As Exception

        End Try
        Dim outstand As Integer = 0
        Try
            outstand = TxtOutstanding.EditValue
        Catch ex As Exception

        End Try
        Dim total As Integer = process + outstand
        TxtAdd.EditValue = total
    End Sub
End Class