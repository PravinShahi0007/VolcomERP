Public Class FormSOHPeriode
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Private Sub FormSOHPeriode_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSOHPeriode_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSOHPeriode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_soh()
    End Sub

    Sub view_soh()
        Dim query As String = "SELECT * FROM tb_soh_periode ORDER BY id_soh_periode DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOHPeriode.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
End Class