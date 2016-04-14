Public Class FormMasterCompanyCategorySingle
    Public id_company_category As String = "-1"

    Private Sub TECompanyCategory_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECompanyCategory.Validating
        EP_TE_cant_blank(EPCompanyCategory, TECompanyCategory)
        '
        Dim query_jml As String
        If id_company_category = "-1" Then
            query_jml = String.Format("SELECT COUNT(id_comp_cat) FROM tb_m_comp_cat WHERE comp_cat_name='{0}'", TECompanyCategory.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_comp_cat) FROM tb_m_comp_cat WHERE comp_cat_name='{0}' AND id_comp_cat!={1}", TECompanyCategory.Text, id_company_category)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPCompanyCategory, TECompanyCategory, "1")
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim company_category As String = TECompanyCategory.Text
        Dim detail As String = MECompanyCategoryDescription.Text

        Try
            If id_company_category <> "-1" Then
                'update
                If Not formIsValid(EPCompanyCategory) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_m_comp_cat SET comp_cat_name='{0}',description='{1}' WHERE id_comp_cat='{2}'", company_category, detail, id_company_category)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterCompanyCategory.view_company_category()
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(EPCompanyCategory) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_m_comp_cat(comp_cat_name,description) VALUES('{0}','{1}')", company_category, detail)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterCompanyCategory.view_company_category()
                    Close()
                End If
            End If
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterCompanyCategorySingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        checkFormAccess("FormMasterCompanyCategory")
    End Sub

    Private Sub FormMasterCompanyCategorySingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If id_company_category <> "-1" Then
                'edit
                Dim query As String = String.Format("SELECT * FROM tb_m_comp_cat WHERE id_comp_cat = '{0}'", id_company_category)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Dim company_category As String = data.Rows(0)("comp_cat_name").ToString
                Dim description As String = data.Rows(0)("description").ToString

                data.Dispose()

                TECompanyCategory.Text = company_category
                MECompanyCategoryDescription.Text = description
            End If
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub
End Class