Public Class FormEmpUniOrderNew
    Private Sub FormEmpUniOrderNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_emp_uni_budget(" + FormEmpUniPeriodDet.id_emp_uni_period + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GCDetail.Focus()
        GVDetail.Focus()
    End Sub

    Sub chooseEmp()
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            'Dim query As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created, id_emp_uni_period, id_uni_type) "
            'query += "VALUES('" + id_store_contact_to + "', '" + id_comp_contact_par + "', '" + sales_order_number + "', NOW(), '" + sales_order_note + "', '" + id_so_type + "', '" + id_report_status + "', '" + id_so_status + "', '" + id_user + "'," + id_emp_uni_period + ", " + id_uni_type + "); SELECT LAST_INSERT_ID(); "
            'FormEmpUniOrderDet.id_sales_order = execute_query(query, 0, True, "", "", "", "")
            FormEmpUniOrderDet.ShowDialog()
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        chooseEmp()
    End Sub

    Private Sub FormEmpUniOrderNew_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            chooseEmp()
        End If
    End Sub

    Private Sub FormEmpUniOrderNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class