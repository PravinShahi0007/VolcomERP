Public Class FormWHCargo
    Private Sub FormWHCargo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cargo()
    End Sub
    Sub load_cargo()
        Dim query As String = "SELECT * FROM tb_m_comp WHERE id_cat='7'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCompany.DataSource = data
        GVCompany.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

End Class