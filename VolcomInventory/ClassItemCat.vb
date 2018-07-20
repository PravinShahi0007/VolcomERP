Public Class ClassItemCat
    Public Function queryMaster(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT c.id_item_cat, c.id_expense_type, e.expense_type, c.item_cat, c.item_cat_en 
        FROM tb_item_cat c
        INNER JOIN tb_lookup_expense_type e ON e.id_expense_type = c.id_expense_type
        WHERE c.id_item_cat>0 "
        query += condition + " "
        query += "ORDER BY c.id_item_cat " + order_type
        Return query
    End Function

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

        Dim query As String = "SELECT ip.id_item_cat_propose, ip.number, ip.created_date, ip.note, ip.id_report_status, stt.report_status 
        FROM tb_item_cat_propose ip
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ip.id_report_status
        WHERE ip.id_item_cat_propose>0 "
        query += condition + " "
        query += "ORDER BY ip.id_item_cat_propose " + order_type
        Return query
    End Function
End Class
