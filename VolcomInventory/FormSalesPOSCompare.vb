Public Class FormSalesPOSCompare
    Public dt_xls As DataTable
    Public dt_stock As DataTable
    Public dt_prc As DataTable

    Private Sub FormSalesPOSCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tb1 = dt_xls.AsEnumerable()
        Dim tb2 = dt_stock.AsEnumerable
        Dim tb3 = dt_prc.AsEnumerable()
        Dim query = From table1 In tb1
                    Group Join table_tmp In tb2
                    On table1("code").ToString Equals table_tmp("code").ToString Into sjoin = Group
                    From rs In sjoin.DefaultIfEmpty()
                    Group Join table_price In tb3
                    On table1("code").ToString Equals table_price("product_full_code").ToString Into pjoin = Group
                    From rp In pjoin.DefaultIfEmpty
                    Select New With
                    {
                        .code = table1("code").ToString,
                        .name = If(rp Is Nothing, "", rp("design_display_name").ToString),
                        .size = If(rp Is Nothing, "", rp("size").ToString),
                        .sales_pos_det_qty = table1("qty"),
                        .limit_qty = If(rs Is Nothing, 0, rs("qty_all_product")),
                        .id_design_price = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                        .design_price = If(rp Is Nothing, 0, rp("design_price")),
                        .design_price_type = If(rp Is Nothing, "", rp("design_price_type").ToString),
                        .id_design_price_retail = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                        .design_price_retail = If(table1("price").ToString = "", If(rp Is Nothing, 0, rp("design_price")), table1("price")),
                        .id_design = If(rp Is Nothing, "0", rp("id_design").ToString),
                        .id_product = If(rp Is Nothing, "0", rp("id_product").ToString),
                        .is_select = "No",
                        .note = If(rp Is Nothing, "Product not found", If(table1("qty") > If(rs Is Nothing, 0, rs("qty_all_product")), "+" + (table1("qty") - If(rs Is Nothing, 0, rs("qty_all_product"))).ToString, "OK")),
                        .id_sales_pos_det = "0"
                    }
        GCData.DataSource = Nothing
        GCData.DataSource = query.ToList()
        GCData.RefreshDataSource()
        GVData.RefreshData()
    End Sub

    Private Sub FormSalesPOSCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub
End Class