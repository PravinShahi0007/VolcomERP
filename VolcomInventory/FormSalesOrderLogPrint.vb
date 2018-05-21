Public Class FormSalesOrderLogPrint
    Public id As String = ""

    Private Sub FormSalesOrderLogPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT a.id_sales_order,a.log_date AS `printed_date`, e.employee_name AS `printed_by` 
        FROM tb_sales_order_log_print a
        INNER JOIN tb_m_user u ON u.id_user = a.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE a.id_sales_order=" + id + "
        ORDER BY a.log_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLog.DataSource = data
    End Sub

    Private Sub FormSalesOrderLogPrint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCLog, "")
    End Sub
End Class