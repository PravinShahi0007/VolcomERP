Public Class FormAccount
    Public change As Boolean = False

    'Validating
    Private Sub TEUsername_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEUsername.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_user) FROM tb_m_user WHERE username='{0}' AND id_user!='{1}'", TEUsername.Text, id_user)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPUser, TEUsername, "1")
        Else
            EP_TE_cant_blank(EPUser, TEUsername)
        End If
    End Sub
    Private Sub TEPassword_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPassword.Validating
        EP_TE_cant_blank(EPUser, TEPassword)
    End Sub
    Private Sub TERepeatPassword_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TERepeatPassword.Validating
        EP_TE_must_same(EPUser, TERepeatPassword, TEPassword)
    End Sub
    'Btn Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Form Closed
    Private Sub FormAccount_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        If Not change Then
            FormMain.logOutCmd()
        End If
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPUser) Then
            errorInput()
        Else
            Try
                Dim query As String = "UPDATE tb_m_user SET tb_m_user.username = '" + addSlashes(TEUsername.Text) + "', tb_m_user.password = MD5('" + addSlashes(TEPassword.Text) + "'), tb_m_user.is_change = '1' WHERE id_user = '" + id_user + "' "
                execute_non_query(query, True, "", "", "", "")
                logData("tb_m_user", 2)
                DevExpress.XtraEditors.XtraMessageBox.Show("Edit data successfully. Application will restart, please log in with new username and password.", "Info")
                change = True
                Close()
                FormMain.logOutCmd()
            Catch ex As Exception
                errorConnection()
            End Try
        End If
    End Sub

    Private Sub FormAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_m_user WHERE id_user = '" + id_user + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TEUsername.Text = data.Rows(0)("username")
    End Sub
End Class