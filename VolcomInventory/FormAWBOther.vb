Public Class FormAWBOther
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAWBOther_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAWBOther_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVAWB.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_form()
    End Sub

    Sub load_form()

    End Sub

    Private Sub FormAWBOther_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        '
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT 'ALL' AS id_comp,'ALL' comp_name
UNION ALL
SELECT id_comp,comp_name FROM tb_m_comp WHERE id_comp_cat='7' AND is_active='1'"
        viewSearchLookupQuery(SLECargo, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        DEUntil.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        DEStart.Properties.MaxValue = DEUntil.EditValue
    End Sub
End Class