Public Class FormEmpFP
    Private Sub FormEmpFP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewFP()
    End Sub

    Sub viewFP()
        Dim query As String = "SELECT id_fingerprint,name,sn,ip,port,is_register, IF(is_register='1','Yes','No') AS `register` FROM tb_m_fingerprint"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFP.DataSource = data
    End Sub

    Private Sub FormEmpFP_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormEmpFP_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpFP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set as register machine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query_upd As String = "UPDATE tb_m_fingerprint SET is_register='2'"
            execute_non_query(query_upd, True, "", "", "", "")
            Dim query As String = "UPDATE tb_m_fingerprint SET is_register='1' WHERE id_fingerprint='" + GVFP.GetFocusedRowCellValue("id_fingerprint").ToString + "' "
            execute_non_query(query, True, "", "", "", "")
            viewFP()
        End If
    End Sub
End Class