Imports MySql.Data.MySqlClient

Public Class ClassSalesPOS
    Public Function queryMainNoStock(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT ns.id_sales_pos_no_stock, ns.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, 
        ns.`number`, ns.created_date, 
        ns.period_from, ns.period_until, ns.created_by, emp.employee_name AS `created_by_name`, ns.note, ns.id_report_status, stt.report_status
        FROM tb_sales_pos_no_stock ns
        INNER JOIN tb_m_comp c ON c.id_comp = ns.id_comp
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ns.id_report_status
        INNER JOIN tb_m_user u ON u.id_user = ns.created_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        WHERE ns.id_sales_pos_no_stock>0 "
        query += condition + " "
        query += "ORDER BY ns.id_sales_pos_no_stock " + order_type
        Return query
    End Function

    Public Sub syncOutlet(ByVal id_outlet_par As String, ByVal host_par As String, ByVal username_par As String, ByVal pass_par As String, ByVal db_par As String)
        Dim curr_time As String = getTimeDB()
        Dim last_upd As String = ""
        Dim constring As String = "server=" + host_par + ";user=" + username_par + ";pwd=" + pass_par + ";database=" + db_par + ";"
        Dim path_root As String = Application.StartupPath
        Dim fileName As String = "bup" + ".sql"
        Dim file As String = IO.Path.Combine(path_root, fileName)
        Dim dic As New Dictionary(Of String, String)()

        Dim ql As String = "SELECT a.sync_time FROM tb_sync_log a WHERE a.id_sync_data=1 AND a.is_success=1 ORDER BY a.sync_time DESC LIMIT 1"
        Dim dql As DataTable = execute_query(ql, -1, True, "", "", "", "")
        If dql.Rows.Count > 0 Then
            last_upd = DateTime.Parse(dql.Rows(0)("sync_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Else
            last_upd = "1945-08-17 00:00:10"
        End If
        dic.Add("tb_m_code_detail", "SELECT cd.* FROM tb_m_code_detail cd JOIN tb_opt o WHERE (cd.id_code= 14 OR cd.id_code=30 OR id_code=33) AND cd.last_updated>'" + last_upd + "';")


    End Sub

    Public Sub syncAllOutlet()
        Dim query As String = "SELECT d.id_departement AS `id_outlet`, d.departement AS `outlet`,
        sc.host, sc.username, sc.pass, sc.db
        FROM tb_m_departement d 
        INNER JOIN tb_store_conn sc ON sc.id_outlet = d.id_departement
        WHERE d.is_store=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            syncOutlet(data.Rows(i)("id_outlet").ToString, data.Rows(i)("host").ToString, data.Rows(i)("username").ToString, data.Rows(i)("pass").ToString, data.Rows(i)("db").ToString)
        Next
    End Sub
End Class
