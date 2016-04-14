Public Class FormMasterCompGroupDet 
    Public id_comp_group As String = "-1"
    Private Sub FormMasterCompGroupDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        If id_comp_group = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_m_comp_group(comp_group) VALUES('" + TECompanyGroup.Text + "');SELECT LAST_INSERT_ID() "
            id_comp_group = execute_query(query, 0, True, "", "", "", "")
            FormPopUpCompGroup.view_comp_group()
            FormPopUpCompGroup.GVGroupComp.FocusedRowHandle = find_row(FormPopUpCompGroup.GVGroupComp, "id_comp_group", id_comp_group)
            Close()
        Else 'edit
            Dim query As String = "UPDATE tb_m_comp_group SET comp_group='" + TECompanyGroup.Text + "' WHERE id_comp_group='" + id_comp_group + "'"
            execute_non_query(query, True, "", "", "", "")
            FormPopUpCompGroup.view_comp_group()
            FormPopUpCompGroup.GVGroupComp.FocusedRowHandle = find_row(FormPopUpCompGroup.GVGroupComp, "id_comp_group", id_comp_group)
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterCompGroupDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class