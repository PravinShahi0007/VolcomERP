Public Class FormSOHPriceDet 
    Public id_soh_periode As String = "-1"
    Private Sub FormSOHPriceDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        view_list_price()
    End Sub

    Private Sub FormSOHPriceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Sub view_list_price()
        Dim query As String = "SELECT id_soh_price,style_code,prod_class,prod_desc,prod_price,prod_cost "
        query += " FROM tb_soh_price"
        query += " WHERE id_soh_periode='" & id_soh_periode & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSelf.DataSource = data
        If data.Rows.Count > 0 Then
            BEmpty.Visible = True
        Else
            BEmpty.Visible = False
        End If
    End Sub

    Private Sub BImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImport.Click
        FormImportExcel.id_pop_up = "5"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub GVSelf_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSelf.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BEmpty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEmpty.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to empty the list ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_soh_price WHERE id_soh_periode = '{0}'", id_soh_periode)
                execute_non_query(query, True, "", "", "", "")
                view_list_price()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class