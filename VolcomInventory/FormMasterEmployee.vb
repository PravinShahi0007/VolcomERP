Public Class FormMasterEmployee 

    Private Sub FormMasterEmployee_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMasterEmployee_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewEmployee()
        Dim query As String = ""
        query += "SELECT * FROM tb_m_employee a "
        query += "INNER JOIN tb_lookup_sex b ON a.id_sex = b.id_sex "
        query += "INNER JOIN tb_m_departement c ON a.id_departement = c.id_departement "
        query += "ORDER BY a.employee_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
    End Sub

    Private Sub FormMasterEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewEmployee()
    End Sub
End Class