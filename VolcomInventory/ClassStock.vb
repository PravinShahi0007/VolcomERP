Public Class ClassStock
    Private dt_stock As New DataTable

    'constructor
    Public Sub New()
        dt_stock.Columns.Add("id_wh_drawer")
        dt_stock.Columns.Add("id_storage_category") 'in/out
        dt_stock.Columns.Add("id_product")
        dt_stock.Columns.Add("id_cost")
        dt_stock.Columns.Add("cost")
        dt_stock.Columns.Add("report_mark_type")
        dt_stock.Columns.Add("id_report")
        dt_stock.Columns.Add("qty")
        dt_stock.Columns.Add("note")
        dt_stock.Columns.Add("id_stock_status") 'normal/reserved
    End Sub

    Public Sub prepInsStockFG(ByVal id_wh_drawer_par As String, ByVal id_storage_category_par As String, ByVal id_product_par As String, ByVal cost_par As String, ByVal report_mark_type_par As String, ByVal id_report_par As String, ByVal qty_par As String, ByVal note_par As String, ByVal id_stock_status_par As String)
        Dim R As DataRow = dt_stock.NewRow
        R("id_wh_drawer") = id_wh_drawer_par
        R("id_storage_category") = id_storage_category_par
        R("id_product") = id_product_par
        R("cost") = cost_par
        R("report_mark_type") = report_mark_type_par
        R("id_report") = id_report_par
        R("qty") = qty_par
        R("note") = note_par
        R("id_stock_status") = id_stock_status_par
        dt_stock.Rows.Add(R)
    End Sub

    Public Sub insStockFG()
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) VALUES "
        If dt_stock.Rows.Count > 0 Then
            For i As Integer = 0 To dt_stock.Rows.Count - 1
                If i > 0 Then
                    query += ", "
                End If
                query += "('" + dt_stock.Rows(i)("id_wh_drawer") + "', '" + dt_stock.Rows(i)("id_storage_category") + "', '" + dt_stock.Rows(i)("id_product") + "', '" + dt_stock.Rows(i)("cost") + "', '" + dt_stock.Rows(i)("report_mark_type") + "', '" + dt_stock.Rows(i)("id_report") + "', '" + dt_stock.Rows(i)("qty") + "', NOW(), '" + dt_stock.Rows(i)("note") + "', '" + dt_stock.Rows(i)("id_stock_status") + "') "
            Next
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Public Sub prepInsStockSample(ByVal id_wh_drawer_par As String, ByVal id_storage_category_par As String, ByVal id_product_par As String, ByVal id_cost_par As String, ByVal cost_par As String, ByVal report_mark_type_par As String, ByVal id_report_par As String, ByVal qty_par As String, ByVal note_par As String, ByVal id_stock_status_par As String)
        Dim R As DataRow = dt_stock.NewRow
        R("id_wh_drawer") = id_wh_drawer_par
        R("id_storage_category") = id_storage_category_par
        R("id_product") = id_product_par
        R("id_cost") = id_cost_par
        R("cost") = cost_par
        R("report_mark_type") = report_mark_type_par
        R("id_report") = id_report_par
        R("qty") = qty_par
        R("note") = note_par
        R("id_stock_status") = id_stock_status_par
        dt_stock.Rows.Add(R)
    End Sub

    Public Sub insStockSample()
        Dim query As String = "INSERT INTO tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, report_mark_type, id_report, qty_sample, datetime_storage_sample, storage_sample_notes, id_stock_status) VALUES "
        If dt_stock.Rows.Count > 0 Then
            For i As Integer = 0 To dt_stock.Rows.Count - 1
                If i > 0 Then
                    query += ", "
                End If
                query += "('" + dt_stock.Rows(i)("id_wh_drawer") + "', '" + dt_stock.Rows(i)("id_storage_category") + "', '" + dt_stock.Rows(i)("id_product") + "', '" + dt_stock.Rows(i)("id_cost") + "','" + dt_stock.Rows(i)("cost") + "', '" + dt_stock.Rows(i)("report_mark_type") + "', '" + dt_stock.Rows(i)("id_report") + "', '" + dt_stock.Rows(i)("qty") + "', NOW(), '" + dt_stock.Rows(i)("note") + "', '" + dt_stock.Rows(i)("id_stock_status") + "') "
            Next
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub
End Class
