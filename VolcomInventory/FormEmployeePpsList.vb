Public Class FormEmployeePpsList
    Private Sub FormEmployeePpsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT e.id_employee, d.departement, e.employee_code, e.employee_name, e.employee_position, ls.employee_status, la.employee_active
            FROM tb_m_employee AS e 
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement 
            LEFT JOIN tb_lookup_employee_status AS ls ON e.id_employee_status = ls.id_employee_status
            LEFT JOIN tb_lookup_employee_active AS la ON e.id_employee_active = la.id_employee_active
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployeeList.DataSource = data

        GVEmployeeList.BestFitColumns()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBSelect.Click
        Close()

        FormEmployeePpsDet.id_employee = GVEmployeeList.GetFocusedRowCellValue("id_employee")

        FormEmployeePpsDet.ShowDialog()
    End Sub

    Private Sub FormEmployeePpsList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class