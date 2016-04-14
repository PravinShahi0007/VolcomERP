Public Class ClassSamplePLtoWH
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT pl.id_sample_pl, pl.sample_pl_number, pl.sample_pl_date, DATE_FORMAT(sample_pl_date,'%Y-%m-%d') AS sample_pl_datex, pl.sample_pl_note, "
        query += "pl.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer, rck.id_wh_rack, loc.id_wh_locator, "
        query += "pl.id_comp_contact_to, getCompByContact(pl.id_comp_contact_to, 1) AS id_comp_to, getCompByContact(pl.id_comp_contact_to, 5) AS comp_to, getCompByContact(pl.id_comp_contact_to, 2) AS comp_to_code, getCompByContact(pl.id_comp_contact_to, 3) AS comp_to_name, "
        query += "pl.id_comp_contact_from, getCompByContact(pl.id_comp_contact_from, 1) AS id_comp_from, getCompByContact(pl.id_comp_contact_from, 5) AS comp_from, getCompByContact(pl.id_comp_contact_from, 2) AS comp_from_code, getCompByContact(pl.id_comp_contact_from, 3) AS comp_from_name, "
        query += "pl.id_report_status, stt.report_status "
        query += "FROM tb_sample_pl pl "
        query += "INNER JOIN tb_lookup_report_status stt ON pl.id_report_status = stt.id_report_status "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = pl.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "WHERE pl.id_sample_pl>0 "
        query += condition + " "
        query += "ORDER BY pl.id_sample_pl " + order_type
        Return query
    End Function

    ' ----------------------
    'for stock out
    ' ----------------------
    Public Sub reservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'reserved stock
        Dim query_res As String = "CALL view_sample_pl('" + id_report_param + "') "
        Dim dt_rsv As DataTable = execute_query(query_res, -1, True, "", "", "", "")
        Dim stc_rsv As ClassStock = New ClassStock()
        For s As Integer = 0 To dt_rsv.Rows.Count - 1
            stc_rsv.prepInsStockSample(dt_rsv.Rows(s)("id_wh_drawer").ToString, "2", dt_rsv.Rows(s)("id_sample").ToString, dt_rsv.Rows(s)("id_sample_price").ToString, decimalSQL(dt_rsv.Rows(s)("sample_price").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_rsv.Rows(s)("sample_pl_det_qty").ToString), "", "2")
        Next
        stc_rsv.insStockSample()
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'cancelled reserved stock
        Dim query_compl As String = "CALL view_sample_pl('" + id_report_param + "') "
        Dim dt_cancel As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        Dim stc_remove_rsv As ClassStock = New ClassStock()
        For s As Integer = 0 To dt_cancel.Rows.Count - 1
            stc_remove_rsv.prepInsStockSample(dt_cancel.Rows(s)("id_wh_drawer").ToString, "1", dt_cancel.Rows(s)("id_sample").ToString, dt_cancel.Rows(s)("id_sample_price").ToString, decimalSQL(dt_cancel.Rows(s)("sample_price").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_cancel.Rows(s)("sample_pl_det_qty").ToString), "", "2")
        Next
        stc_remove_rsv.insStockSample()
    End Sub

    Public Sub completeReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'complete
        Dim query_compl As String = "CALL view_sample_pl('" + id_report_param + "') "
        Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        Dim stc_remove_rsv As ClassStock = New ClassStock()
        Dim stc_compl As ClassStock = New ClassStock()
        For s As Integer = 0 To dt_compl.Rows.Count - 1
            stc_remove_rsv.prepInsStockSample(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_sample").ToString, dt_compl.Rows(s)("id_sample_price").ToString, decimalSQL(dt_compl.Rows(s)("sample_price").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sample_pl_det_qty").ToString), "", "2")
            stc_compl.prepInsStockSample(dt_compl.Rows(s)("id_wh_drawer").ToString, "2", dt_compl.Rows(s)("id_sample").ToString, dt_compl.Rows(s)("id_sample_price").ToString, decimalSQL(dt_compl.Rows(s)("sample_price").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sample_pl_det_qty").ToString), "", "1")
        Next
        stc_remove_rsv.insStockSample()
        stc_compl.insStockSample()
    End Sub

End Class
