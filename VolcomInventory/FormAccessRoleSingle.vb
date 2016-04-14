Public Class FormAccessRoleSingle
    Public action As String
    Public id_role As String
    Private Sub FormMasterUserRoleSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If action = "ins" Then
        ElseIf action = "upd" Then
        End If
    End Sub
    'Validating
    Private Sub TxtRoleName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRoleName.Validating
        EP_TE_cant_blank(EPRole, TxtRoleName)
    End Sub
    'sAVE
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPRole) Then
            errorInput()
        Else
            Dim query As String
            Dim role As String = TxtRoleName.Text.ToString
            If action = "ins" Then
                'INSERT
                Try
                    query = String.Format("INSERT INTO tb_m_role(role) VALUES('{0}')", role)
                    execute_non_query(query, True, "", "", "", "")
                    FormAccess.viewRole()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                'UPDATE
                Try
                    query = String.Format("UPDATE tb_m_role SET role='{0}' WHERE id_role='{1}'", role, id_role)
                    execute_non_query(query, True, "", "", "", "")
                    FormAccess.viewRole()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub
    'Close
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Form Closed
    Private Sub FormMasterUserRoleSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class