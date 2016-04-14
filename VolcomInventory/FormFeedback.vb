Public Class FormFeedback 

    Private Sub FormFeedback_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        viewFeedback()
    End Sub

    Sub viewFeedback()
        Dim id_role_admin = get_setup_field("id_role_super_admin")
        Dim query As String = "SELECT * FROM feedback a "
        query += "INNER JOIN tb_m_user b ON b.id_user = a.id_user "
        query += "INNER JOIN tb_m_employee c ON c.id_employee = b.id_employee "
        If id_role_login <> id_role_admin Then
            query += "WHERE a.id_user = '" + id_user + "' "
        End If
        query += "ORDER BY a.feedback_time ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFeedback.DataSource = data
        If GVFeedback.RowCount > 0 Then
            BtnDelete.Enabled = True
        Else
            BtnDelete.Enabled = False
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFeedbackDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFeedback_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this feedback?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim query As String = ""
                query = String.Format("DELETE FROM feedback WHERE id_feedback = '{0}'", Me.GVFeedback.GetFocusedRowCellValue("id_feedback"))
                execute_non_query(query, True, "", "", "", "")
                viewFeedback()
            Catch ex As Exception
                errorConnection()
            End Try
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub
End Class