Public Class FormMasterUser
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Private Sub FormMasterUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_user()
    End Sub
    'View User
    Sub view_user()
        Dim query As String = "SELECT * FROM tb_m_user a "
        query += "INNER JOIN tb_m_employee b ON a.id_employee = b.id_employee  "
        query += "INNER JOIN tb_m_departement c ON b.id_departement = c.id_departement  "
        query += "INNER JOIN tb_m_role d ON a.id_role = d.id_role "
        query += "INNER JOIN tb_lookup_answer e ON a.is_change = e.id_answer "
        query += "ORDER BY employee_name ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUser.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"

        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    'Menu Activated
    Private Sub FormMasterUser_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    'Form Closed
    Private Sub FormMasterUser_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Menu Deadactivate
    Private Sub FormMasterUser_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class