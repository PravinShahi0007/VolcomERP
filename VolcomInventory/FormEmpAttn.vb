Public Class FormEmpAttn
    Dim fp As New ClassFingerPrint
    Private Sub BGetData_Click(sender As Object, e As EventArgs) Handles BGetData.Click
        Cursor = Cursors.WaitCursor
        fp.connect()

        fp.get_attlog()
        fp.clear_attlog()

        fp.disconnect()
        Cursor = Cursors.Default
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Dim query As String = ""
        'query = "SELECT * FROM tb_emp_attn emp_attn"
        'query += " INNER JOIN tb_m_employee emp ON emp.id_employee=emp_attn.id_employee"
        query = "SELECT log_att.id_employee,emp.employee_code,emp.employee_name,"
        query += " log_att.log_masuk,att_masuk.scan_method AS meth_masuk,att_masuk.type_log AS type_masuk,"
        query += " log_att.log_pulang,att_pulang.scan_method As meth_pulang,att_pulang.type_log As type_pulang"
        query += " FROM "
        query += " ("
        query += " SELECT emp_attn.id_employee,MIN(emp_attn.datetime) AS log_masuk,MAX(emp_attn.datetime) AS log_pulang"
        query += " FROM tb_emp_attn emp_attn"
        query += " GROUP BY DATE(emp_attn.`datetime`),emp_attn.id_employee"
        query += " ) log_att "
        query += " INNER JOIN tb_m_employee emp ON emp.id_employee=log_att.id_employee"
        query += " INNER JOIN tb_emp_attn att_masuk On att_masuk.id_employee=log_att.id_employee And att_masuk.datetime=log_att.log_masuk"
        query += " INNER JOIN tb_emp_attn att_pulang ON att_pulang.id_employee=log_att.id_employee AND att_pulang.datetime=log_att.log_pulang"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
    End Sub
End Class