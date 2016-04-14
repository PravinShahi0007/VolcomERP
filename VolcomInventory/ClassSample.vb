Public Class ClassSample
    '***********************
    'MASTER PRICE FROM EXCEL
    '***********************
    Public Function queryPriceExcelMain(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT prc.id_sample_price, prc.id_design_price_type, prc.sample_price_number, prc.sample_price_date, DATE_FORMAT(prc.sample_price_date, '%Y-%m-%d') AS sample_price_datex,prc.sample_price_note, prc.id_report_status,stt.report_status "
        query += "FROM tb_sample_price prc "
        query += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = prc.id_report_status "
        query += "WHERE prc.id_sample_price>0 " + condition
        query += "ORDER BY prc.id_sample_price  " + order_type
        Return query
    End Function

    Public Function queryPriceExcelDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sample_price('" + id_report_param + "')"
        Return query
    End Function
End Class
