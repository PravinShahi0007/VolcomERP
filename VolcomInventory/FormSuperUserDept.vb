Public Class FormSuperUserDept
    Private Sub FormSuperUserDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_m_departement"
        viewSearchLookupQuery(SearchLookUpEdit1, query, "id_departement", "departement", "id_departement")
        SearchLookUpEdit1.EditValue = id_departement_user
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        id_departement_user = SearchLookUpEdit1.EditValue.ToString
        Close()
    End Sub

    Private Sub FormSuperUserDept_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class