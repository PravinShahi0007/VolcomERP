Public Class FormSalesOrderRef
    Public id_pop_up As String = "-1"

    Private Sub FormSalesOrderRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view()
    End Sub

    Sub view()
        Dim query As String = ""
        query += "Select  gen.id_sales_order_gen, gen.id_so_status, stt.so_status, gen.sales_order_gen_reff, IFNULL(del.created,0) As `created`, gen.sales_order_gen_date  "
        query += "From tb_sales_order_gen gen "
        query += "INNER Join tb_lookup_so_status stt ON stt.id_so_status = gen.id_so_status  "
        query += "Left Join( "
        query += "SELECT so.id_sales_order_gen, COUNT(del.id_pl_sales_order_del) AS `created`  "
        query += "From tb_sales_order so  "
        query += "INNER Join tb_pl_sales_order_del del ON del.id_sales_order = so.id_sales_order  "
        query += "WHERE so.id_report_status=6 And del.id_report_status!= 5  "
        query += "And !ISNULL(so.id_sales_order_gen)  "
        query += "GROUP BY so.id_sales_order_gen "
        query += ") del ON del.id_sales_order_gen = gen.id_sales_order_gen "
        query += "WHERE gen.id_report_status = 6 "
        query += "ORDER BY gen.sales_order_gen_date DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        check_but()
    End Sub

    Sub check_but()
        Dim id_sales_order_gen As String = "-1"
        Try
            id_sales_order_gen = GVList.GetFocusedRowCellValue("id_sales_order_gen").ToString
        Catch ex As Exception
        End Try
        If id_sales_order_gen = "-1" Then
            SimpleButton1.Enabled = False
        Else
            SimpleButton1.Enabled = True
        End If
    End Sub

    Sub choose()
        Dim no As String = ""
        Try
            no = GVList.GetFocusedRowCellValue("sales_order_gen_reff").ToString
        Catch ex As Exception
        End Try
        Dim id_sales_order_gen As String = "-1"
        Try
            id_sales_order_gen = GVList.GetFocusedRowCellValue("id_sales_order_gen").ToString
        Catch ex As Exception
        End Try

        If id_pop_up = "1" Then
            FormSalesDelOrder.TxtNoParam.Text = no
            FormSalesDelOrder.id_sales_order_gen = id_sales_order_gen
            FormSalesDelOrder.viewrRef()
            Close()
        End If
    End Sub

    Private Sub FormSalesOrderRef_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVList_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVList.ColumnFilterChanged
        check_but()
    End Sub

    Private Sub GVList_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVList.FocusedRowChanged
        check_but()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        choose()
        Cursor = Cursors.Default
    End Sub
End Class