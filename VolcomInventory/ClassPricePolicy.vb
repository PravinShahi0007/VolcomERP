Public Class ClassPricePolicy
    Function dataMain(ByVal condition As String, ByVal order_type As String) As DataTable
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

        Dim query As String = "SELECT cd.id_code_detail, cd.`code`, cd.code_detail_name AS `description`,
        pp.normal, pp.mkd_30, pp.mkd_50, pp.mkd_70, pp.mkd_fix
        FROM tb_m_code_detail cd
        INNER JOIN tb_m_design_price_policy pp ON pp.id_code_detail = cd.id_code_detail
        WHERE cd.id_code IN (SELECT id_code_price_policy FROM tb_opt) "
        query += condition + " "
        query += "ORDER BY cd.code " + order_type
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function
End Class
