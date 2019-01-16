Public Class FormProdTemplateKO
    Private Sub FormProdTemplateKO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProdTemplateKO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_template()
    End Sub

    Sub load_template()
        Dim query As String = "SELECT id_ko_template,description,year FROM tb_ko_template"
        viewSearchLookupQuery(SLETemplate, query, "id_ko_template", "description", "id_ko_template")
    End Sub

    Sub load_content()
        Dim query As String = "SELECT id_ko_template_det,id_ko_template,number,content FROM tb_ko_template_det WHERE id_ko_template='" & SLETemplate.EditValue.ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCKO.DataSource = data
        GVKO.BestFitColumns()
    End Sub

    Private Sub BViewTemplate_Click(sender As Object, e As EventArgs) Handles BViewTemplate.Click
        load_content()
    End Sub

    Sub check_but()
        If GVKO.RowCount > 0 Then
            BDel.Visible = True
            BEdit.Visible = True
        Else
            BDel.Visible = False
            BEdit.Visible = False
        End If
    End Sub
End Class