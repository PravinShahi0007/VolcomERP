Public Class FormMasterItemSizeSingle 
    Public action As String
    Public id_item_size As String
    'SAVE
    Private Sub btnSaveItemSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveItemSize.Click
        Cursor = Cursors.WaitCursor
        Dim code_item_size As String = TxtCodeSize.Text.ToString
        Dim item_size As String = TxtItemSize.Text.ToString
        Dim description_item_size As String = MemoDescription.Text.ToString
        Dim query As String
        Me.ValidateChildren()
        If code_item_size.Length < 1 Or item_size.Length < 1 Then
            errorInput()
        Else
            If action = "ins" Then
                Try
                    query = String.Format("INSERT INTO tb_m_item_size(code_item_size, item_size, description_item_size) VALUES('{0}','{1}','{2}')", code_item_size, item_size, description_item_size)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterItemSize.viewMasterItemSize()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = String.Format("UPDATE tb_m_item_size SET code_item_size = '{0}', item_size='{1}', description_item_size='{2}' WHERE id_item_size={3}", code_item_size, item_size, description_item_size, id_item_size)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterItemSize.viewMasterItemSize()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    'Validate
    Private Sub TxtCodeSize_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodeSize.Validating
        EP_TE_cant_blank(ErrorProviderItemSize, TxtCodeSize)
    End Sub
    'validate
    Private Sub TxtItemSize_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtItemSize.Validating
        EP_TE_cant_blank(ErrorProviderItemSize, TxtItemSize)
    End Sub
    'Cancel
    Private Sub btnCancelItemSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelItemSize.Click
        Close()
    End Sub
    'Form Close
    Private Sub FormMasterItemSizeSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Form Load
    Private Sub FormMasterItemSizeSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If action = "upd" Then
            Try
                Dim query As String = String.Format("SELECT * FROM tb_m_item_size WHERE id_item_size = '{0}'", id_item_size)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtCodeSize.Text = data.Rows(0)("code_item_size").ToString
                MemoDescription.Text = data.Rows(0)("description_item_size").ToString
                TxtItemSize.Text = data.Rows(0)("item_size")
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        End If
    End Sub
End Class