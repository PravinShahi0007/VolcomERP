Public Class FormStoreStatusHistory
    Public id_comp_cat As String = "-1"

    Private Sub FormStoreStatusHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT l.log_date, e.employee_name, c.comp_number, c.comp_name, IF(c.is_active=1,'Active','Not Active') AS `status`, l.reason
        FROM tb_log_store_activation l
        INNER JOIN tb_m_comp c ON c.id_comp = l.id_comp
        INNER JOIN tb_m_user u ON u.id_user = l.log_updated_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        ORDER BY l.log_date DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormStoreStatusHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub
End Class