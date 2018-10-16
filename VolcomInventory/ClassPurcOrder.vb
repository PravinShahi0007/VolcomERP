Public Class ClassPurcOrder
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

        Dim query As String = "SELECT po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name as emp_created,po.last_update,emp_upd.employee_name AS emp_updated 
        FROM tb_purc_order po
        INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
        INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
        INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
        INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
        INNER JOIN (
            SELECT pod.id_purc_order 
            FROM tb_purc_order_det pod
            INNER JOIN tb_purc_order po ON po.id_purc_order = pod.id_purc_order
            INNER JOIN tb_item i ON i.id_item = pod.id_item
            INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
            WHERE po.id_report_status=6 AND cat.id_expense_type=1
            GROUP BY pod.id_purc_order
        ) o ON o.id_purc_order = po.id_purc_order 
        WHERE po.id_purc_order>0 "
        query += condition + " "
        query += "ORDER BY po.id_purc_order " + order_type
        Return query
    End Function
End Class