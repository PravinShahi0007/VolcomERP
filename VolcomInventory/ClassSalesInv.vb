Public Class ClassSalesInv
    Public Function queryMain(ByVal condition_param As String, ByVal order_type_param As String) As String
        Dim query As String = "CALL view_sales_inv_main('" + condition_param + "', '" + order_type_param + "') "
        Return query
    End Function

    Public Function queryMainReport(ByVal condition_param As String, ByVal order_type_param As String) As String
        Dim query As String = "CALL view_sales_inv_report('" + condition_param + "', '" + order_type_param + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sales_pos('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryDetailReport(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sales_pos_report_new('" + id_report_param + "')"
        Return query
    End Function

    ' ----------------------
    'for stock out
    ' ----------------------
    Public Sub reservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'reserved stock
        Dim query_res As String = "CALL view_sales_pos('" + id_report_param + "') "
        Dim dt_rsv As DataTable = execute_query(query_res, -1, True, "", "", "", "")
        Dim stc_rsv As ClassStock = New ClassStock()
        For s As Integer = 0 To dt_rsv.Rows.Count - 1
            stc_rsv.prepInsStockFG(dt_rsv.Rows(s)("id_wh_drawer").ToString, "2", dt_rsv.Rows(s)("id_product").ToString, decimalSQL(dt_rsv.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_rsv.Rows(s)("sales_pos_det_qty").ToString), "", "2")
        Next
        stc_rsv.insStockFG()
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'cancelled reserved stock
        Dim query_compl As String = "CALL view_sales_pos('" + id_report_param + "') "
        Dim dt_cancel As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        Dim stc_remove_rsv As ClassStock = New ClassStock()
        For s As Integer = 0 To dt_cancel.Rows.Count - 1
            stc_remove_rsv.prepInsStockFG(dt_cancel.Rows(s)("id_wh_drawer").ToString, "1", dt_cancel.Rows(s)("id_product").ToString, decimalSQL(dt_cancel.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_cancel.Rows(s)("sales_pos_det_qty").ToString), "", "2")
        Next
        stc_remove_rsv.insStockFG()
    End Sub

    Public Sub completeReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'complete
        Dim query_compl As String = "CALL view_sales_pos('" + id_report_param + "') "
        Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        Dim stc_remove_rsv As ClassStock = New ClassStock()
        Dim stc_compl As ClassStock = New ClassStock()
        For s As Integer = 0 To dt_compl.Rows.Count - 1
            stc_remove_rsv.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_pos_det_qty").ToString), "", "2")
            stc_compl.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "2", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_pos_det_qty").ToString), "", "1")
        Next
        stc_remove_rsv.insStockFG()
        stc_compl.insStockFG()
    End Sub

    ' ----------------------
    'for stock in
    ' ----------------------
    Public Sub completeInStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'complete
        Dim query_compl As String = "CALL view_sales_pos('" + id_report_param + "') "
        Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")
        Dim stc_compl As ClassStock = New ClassStock()
        For s As Integer = 0 To dt_compl.Rows.Count - 1
            stc_compl.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_pos_det_qty").ToString), "", "1")
        Next
        stc_compl.insStockFG()
    End Sub

End Class
