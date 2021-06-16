Public Class FormAWBOther
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