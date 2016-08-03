Public Class FormRejectTypeDet
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        If formIsValid(ErrorProvider1) Then
            Dim query As String = "INSERT INTO tb_m_reject_type(reject_type) VALUES('" + addSlashes(TextEdit1.Text) + "') "
            execute_non_query(query, True, "", "", "", "")
            FormRejectType.viewRejectType()
            Dispose()
        Else
            errorInput()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormRejectTypeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TextEdit1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextEdit1.Validating
        Dim query As String = "SELECT COUNT(*) FROM tb_m_reject_type WHERE reject_type='" + addSlashes(TextEdit1.Text) + "' "
        Dim jum As String = execute_query(query, 0, True, "", "", "", "")
        If jum > 0 Then
            EP_TE_already_used(ErrorProvider1, TextEdit1, "Already exist")
        Else
            ErrorProvider1.SetError(TextEdit1, String.Empty)
        End If
    End Sub
End Class