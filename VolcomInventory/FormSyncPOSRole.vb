Public Class FormSyncPOSRole
    Private Sub FormSyncPOSRole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupQuery(SLUERole, "SELECT id_pos_role, role FROM tb_pos_role", "id_pos_role", "role", "id_pos_role")

        SLUERole.EditValue = execute_query("SELECT id_pos_role FROM tb_pos_user WHERE id_pos_user = " + FormSyncPOS.GVUser.GetFocusedRowCellValue("id_pos_user").ToString, 0, True, "", "", "", "")
    End Sub

    Private Sub FormSyncPOSRole_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        execute_non_query("UPDATE tb_pos_user SET id_pos_role = " + SLUERole.EditValue.ToString + " WHERE id_pos_user = " + FormSyncPOS.GVUser.GetFocusedRowCellValue("id_pos_user").ToString, True, "", "", "", "")

        FormSyncPOS.load_user()

        Close()
    End Sub
End Class