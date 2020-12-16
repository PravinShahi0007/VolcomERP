Public Class FormSalesPOSCompare
    Public dt_xls As DataTable
    Public dt_stock As DataTable
    Public dt_prc As DataTable

    Private Sub FormSalesPOSCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
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
                        .limit_qty = If(rs Is Nothing, 0, rs("qty_all_product")),
                        .sales_qty = table1("qty"),
                        .sales_pos_det_qty = If(table1("qty") <= If(rs Is Nothing, 0, rs("qty_all_product")), table1("qty"), If(rs Is Nothing, 0, rs("qty_all_product"))),
                        .no_stock_qty = table1("qty") - If(table1("qty") <= If(rs Is Nothing, 0, rs("qty_all_product")), table1("qty"), If(rs Is Nothing, 0, rs("qty_all_product"))),
                        .id_design_price = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                        .design_price = If(rp Is Nothing, 0, rp("design_price")),
                        .design_price_type = If(rp Is Nothing, "", rp("design_price_type").ToString),
                        .id_design_price_retail = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                        .design_price_retail = If(rp Is Nothing, 0, rp("design_price")),
                        .input_price = table1("price"),
                        .id_design = If(rp Is Nothing, "0", rp("id_design").ToString),
                        .id_product = If(rp Is Nothing, "0", rp("id_product").ToString),
                        .is_select = "No",
                        .note = If(rs Is Nothing, "Product not found", If(table1("qty") > If(rs Is Nothing, 0, rs("qty_all_product")), "+" + (table1("qty") - If(rs Is Nothing, 0, rs("qty_all_product"))).ToString, "OK")),
                        .note_price = If(If(rp Is Nothing, 0, rp("design_price")) = table1("price"), "OK", "Not Match"),
                        .status = If(If(rs Is Nothing, "Product not found", If(table1("qty") > If(rs Is Nothing, 0, rs("qty_all_product")), "+" + (table1("qty") - If(rs Is Nothing, 0, rs("qty_all_product"))).ToString, "OK")) = "OK" And If(If(rp Is Nothing, 0, rp("design_price")) = table1("price"), "OK", "Not Match") = "OK", "OK", "Not Match"),
                        .id_sales_pos_det = "0"
                    }
        GCData.DataSource = Nothing
        GCData.DataSource = query.ToList()
        GCData.RefreshDataSource()
        GVData.RefreshData()
        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FormSalesPOSCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        If e.Column.FieldName.ToString = "status" Then
            Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("status")).ToString
            If stt <> "OK" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        End If
    End Sub
End Class