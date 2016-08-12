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
        query = "SELECT * FROM tb_emp_attn emp_attn"
        query += " INNER JOIN tb_m_employee emp ON emp.id_employee=emp_attn.id_employee"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
    End Sub
End Class