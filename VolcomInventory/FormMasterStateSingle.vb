Public Class FormMasterStateSingle
    Private Sub FormMasterStateSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Public id_state As String = "-1"
    Public id_region As String = "-1"
    Private Sub FormMasterStateSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If id_state <> "-1" Then
                'edit
                Dim query As String = String.Format("SELECT * FROM tb_m_state WHERE id_state = '{0}'", id_state)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Dim state As String = data.Rows(0)("state").ToString

                data.Dispose()

                TEState.Text = state
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim state As String = TEState.Text

        Try
            If id_state <> "-1" Then
                'update
                If Not formIsValid(EPState) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_m_state SET state='{0}' WHERE id_state='{1}'", state, id_state)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_state(id_region)
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(EPState) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_m_state(state,id_region) VALUES('{0}','{1}')", state, id_region)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_state(id_region)
                    Close()
                End If
            End If
        Catch ex As Exception
            errorConnection()
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub TEState_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEState.Validating
        EP_TE_cant_blank(EPState, TEState)
        '
        Dim query_jml As String = String.Format("SELECT COUNT(id_state) FROM tb_m_state WHERE state='{0}' AND id_state!='{1}'", TEState.Text, id_state)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPState, TEState, "1")
        End If
    End Sub
End Class