Imports DevExpress.XtraEditors
Public Class FormMasterRawMaterialCatSingle
    Public action As String
    Public id_mat_cat As String
    'SAVE
    Private Sub SimpleButtonItemCategoryDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButtonItemCategoryDescription.Click
        Cursor = Cursors.WaitCursor
        Me.ValidateChildren()

        If Not formIsValid(ErrorProviderMasterItemCategory) Then
            errorInput()
        Else
            Dim mat_cat As String = addSlashes(TextEditItemCategory.Text.ToString)
            Dim query_item_category As String = ""

            If action = "ins" Then
                Try
                    query_item_category = "INSERT INTO tb_m_mat_cat(mat_cat) VALUES ('" + mat_cat + "')"
                    execute_non_query(query_item_category, True, "", "", "", "")
                    logData("tb_m_mat_cat", 1)
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query_item_category = String.Format("UPDATE tb_m_mat_cat SET mat_cat='{0}' WHERE id_mat_cat ='{1}'", mat_cat, id_mat_cat)
                    execute_non_query(query_item_category, True, "", "", "", "")
                    logData("tb_m_mat_cat", 2)
                Catch ex As Exception
                    errorConnection()
                End Try
            End If

            Cursor = Cursors.Default
            Close()
            Cursor = Cursors.WaitCursor
            Try
                FormMasterRawMaterialCat.view_master_item_category()
            Catch ex As Exception
                errorConnection()
            End Try
        End If

        Cursor = Cursors.Default
    End Sub
    'Form Close
    Private Sub FormMasterItemCategorySingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
    'Form Load
    Private Sub FormMasterItemCategorySingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If action = "upd" Then
            Try
                Dim query As String = String.Format("SELECT * FROM tb_m_mat_cat WHERE id_mat_cat = '{0}'", id_mat_cat)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TextEditItemCategory.Text = data.Rows(0)("mat_cat").ToString
            Catch ex As Exception
                errorProcess()
                Close()
            End Try
        End If
    End Sub
    'Validate
    Private Sub TextEditItemCategory_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextEditItemCategory.Validating
        EP_TE_cant_blank(ErrorProviderMasterItemCategory, TextEditItemCategory)
    End Sub
    'Cancel
    Private Sub SimpleButtonMasterItemCategoryCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButtonMasterItemCategoryCancel.Click
        Dispose()
    End Sub
End Class