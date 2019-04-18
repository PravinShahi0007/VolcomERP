Public Class ClassSalesTarget
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

        Dim query As String = "SELECT t.id_sales_trg_propose, t.year, t.number, 
        t.created_date, t.updated_date, 
        t.note, t.id_report_status, rs.report_status, t.is_confirm
        FROM tb_sales_trg_propose t
        INNER JOIN tb_sales_trg_propose_det td ON td.id_sales_trg_propose = t.id_sales_trg_propose
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = t.id_report_status
        WHERE t.id_sales_trg_propose>0 "
        query += condition + " "
        query += "ORDER BY t.id_sales_trg_propose " + order_type
        Return query
    End Function
End Class
