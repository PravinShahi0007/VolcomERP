Public Class FormInfoSalesReturnOrder 
    Public id_sales_return_order As String = "-1"
    Public id_sales_return_order_det As String = "-1"
    Public id_sales_return As String = "0"
    Public id_pop_up As String
    Dim id_store As String = "-1"

    Public id_wh_drawer As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_locator As String = "-1"


    Private Sub FormInfoSalesReturnOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_sales_return_order WHERE id_sales_return_order = '" + id_sales_return_order + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelSubTitle.Text = "Return Order No. :" + data.Rows(0)("sales_return_order_number").ToString
        id_store = get_company_contact_x(data.Rows(0)("id_store_contact_to").ToString, "3")
        view_list_so(id_sales_return_order)
    End Sub

    Sub view_list_so(ByVal id_sales_return_order As String)
        Dim query As String = ""
        If id_pop_up = "1" Then
            query = "CALL view_sales_return_order_limit('" + id_sales_return_order + "', '" + id_sales_return_order_det + "', '" + id_sales_return + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim dt As DataTable = execute_query("CALL view_stock_fg('" + id_store + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '9999-01-01')", -1, True, "", "", "", "")
            Dim tb1 = data.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()
            Dim query_new = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                            .code = table1.Field(Of String)("code"),
                            .name = table1.Field(Of String)("name"),
                            .size = table1.Field(Of String)("size"),
                            .sales_return_order_det_qty = CType(table1("sales_return_order_det_qty"), Decimal),
                            .sales_return_det_qty_view = CType(table1("sales_return_det_qty_view"), Decimal),
                            .soh = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                            .design_price = CType(table1("design_price"), Decimal),
                           .amount = CType(table1("amount"), Decimal)
                            }
            GCItemList.DataSource = query_new.ToList
        End If
    End Sub

    Private Sub FormInfoSalesReturnOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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