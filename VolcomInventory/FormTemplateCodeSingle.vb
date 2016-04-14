Public Class FormTemplateCodeSingle
    Public id_template_code As String = "-1"
    Private Sub TETemplateCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TETemplateCode.Validating
        EP_TE_cant_blank(EPTemplateCode, TETemplateCode)
    End Sub

    Private Sub FormTemplateCodeSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_template_code <> "-1" Then
            'edit
            Dim query As String = String.Format("SELECT * FROM tb_template_code WHERE id_template_code='{0}'", id_template_code)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim template_code As String = data.Rows(0)("template_code").ToString

            data.Dispose()

            TETemplateCode.Text = template_code
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Dim query As String
        Dim template_code As String = TETemplateCode.Text

        Try
            If id_template_code <> "-1" Then
                'update
                If Not formIsValid(EPTemplateCode) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_template_code SET template_code='{0}' WHERE id_template_code='{1}'", template_code, id_template_code)
                    execute_non_query(query, True, "", "", "", "")
                    FormTemplateCode.view_template()
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(EPTemplateCode) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_template_code(template_code) VALUES('{0}')", template_code)
                    execute_non_query(query, True, "", "", "", "")
                    FormTemplateCode.view_template()
                    Close()
                End If
            End If
        Catch ex As Exception
            errorConnection()
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub FormTemplateCodeSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class