Public Class FormMasterOVH
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Private Sub FormMasterOVH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_ovh()
    End Sub
    Sub view_ovh()
        Dim data As DataTable = execute_query("SELECT * FROM tb_m_ovh a INNER JOIN tb_m_uom b ON b.id_uom = a.id_uom INNER JOIN tb_m_ovh_cat cat ON cat.id_ovh_cat=a.id_ovh_cat ORDER BY overhead_code ASC", -1, True, "", "", "", "")
        GCOVH.DataSource = data

    End Sub
    Sub check_but()
        If GVOVH.RowCount > 0 Then
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
    Private Sub FormMasterOVH_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_but()
    End Sub
    Private Sub FormMasterOVH_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class