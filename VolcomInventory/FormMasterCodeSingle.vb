Public Class FormMasterCodeSingle
    Public id_code As String = "-1"

    Private Sub TECode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECode.Validating
        EP_TE_cant_blank(ErrorProviderCode, TECode)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim code As String = TECode.Text
        Dim dettail As String = MEDescription.Text
        Dim is_include_name As String = "0"
        Dim is_include_code As String = "0"

        If CEIsInclude.Checked = True Then
            is_include_name = "1"
        Else
            is_include_name = "0"
        End If

        If CEIncludeCode.Checked = True Then
            is_include_code = "1"
        Else
            is_include_code = "0"
        End If

        Try
            If id_code <> "-1" Then
                'update
                If Not formIsValid(ErrorProviderCode) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_m_code SET code_name='{0}',description='{1}',is_include_name='{2}',is_include_code='{3}' WHERE id_code='{4}'", code, dettail, is_include_name, is_include_code, id_code)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterCode.view_code()
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(ErrorProviderCode) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_m_code(code_name,description,is_include_name,is_include_code) VALUES('{0}','{1}','{2}','{3}')", code, dettail, is_include_name, is_include_code)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterCode.view_code()
                    Close()
                End If
            End If
        Catch ex As Exception
            errorConnection()
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterCodeSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterCodeSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_code <> "-1" Then
            'update
            Dim query As String = String.Format("SELECT * FROM tb_m_code WHERE id_code='{0}'", id_code)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim code_name As String = data.Rows(0)("code_name").ToString
            Dim description As String = data.Rows(0)("description").ToString
            Dim is_include_name As String = data.Rows(0)("is_include_name").ToString
            Dim is_include_code As String = data.Rows(0)("is_include_code").ToString

            data.Dispose()

            TECode.Text = code_name
            MEDescription.Text = description
            If is_include_name = "True" Then
                CEIsInclude.Checked = True
            Else
                CEIsInclude.Checked = False
            End If
            If is_include_code = "True" Then
                CEIncludeCode.Checked = True
            Else
                CEIncludeCode.Checked = False
            End If
        End If
    End Sub
End Class