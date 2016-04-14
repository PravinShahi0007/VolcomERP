Public Class FormInfoSalesOrder 
    Public id_sales_order As String = "-1"
    Public id_sales_order_det As String = "-1"
    Public id_pl_sales_order_del As String = "0"
    Public id_pop_up As String

    Private Sub FormInfoSalesOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_sales_order WHERE id_sales_order = '" + id_sales_order + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelSubTitle.Text = "Sales Order No. :" + data.Rows(0)("sales_order_number").ToString
        view_list_so(id_sales_order)
    End Sub

    Sub view_list_so(ByVal id_sales_order As String)
        Dim query As String = ""
        If id_pop_up = "1" Then
            query = "CALL view_sales_order_limit('" + id_sales_order + "', '" + id_sales_order_det + "', '" + id_pl_sales_order_del + "')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub FormInfoSalesOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class