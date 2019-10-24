Public Class FormBuktiPickupDet
    Public id_pickup As String = "0"

    Private Sub FormBuktiPickupDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp()
        load_form()
    End Sub

    Sub load_form()
        If id_pickup = "0" Then
            TECreatedBy.EditValue = get_emp(id_employee_user, "2")
            DECreatedDate.EditValue = Now
        Else
        End If
    End Sub

    Sub view_comp()
        Dim query As String = "SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7"

        viewSearchLookupQuery(SLUECompany, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormBuktiPickupPick.id_comp = SLUECompany.EditValue.ToString
        FormBuktiPickupPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVList.DeleteSelectedRows()
    End Sub

    Private Sub FormBuktiPickupDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBComplete_Click(sender As Object, e As EventArgs) Handles SBComplete.Click

    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click

    End Sub

    Private Sub SBAttachement_Click(sender As Object, e As EventArgs) Handles SBAttachement.Click

    End Sub
End Class