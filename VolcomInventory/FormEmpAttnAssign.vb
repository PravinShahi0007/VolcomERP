Public Class FormEmpAttnAssign
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormEmpAttnAssign_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpAttnAssign_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpAttnAssign_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpAttnAssign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dept()
    End Sub
    '
    Sub load_dept()
        Dim query As String = "(SELECT id_departement,departement FROM tb_m_departement a WHERE id_departement='" + id_departement_user + "' ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        LEDeptSum.ItemIndex = 0
    End Sub
End Class