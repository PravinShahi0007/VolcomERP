Public Class FormMasterItemColorSingle
    Public action As String
    Public id_item_color As String

    'Validate
    Private Sub TxtCodeColor_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodeItemColor.Validated
        EP_TE_cant_blank(ErrorProviderColor, TxtCodeItemColor)
    End Sub
    'Validate
    Private Sub TxtItemColor_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtItemColor.Validating
        EP_TE_cant_blank(ErrorProviderColor, TxtItemColor)
    End Sub
    'Form Close
    Private Sub FormMasterItemColorSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'CANCEL
    Private Sub btnCancelItemColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelItemColor.Click
        Close()
    End Sub
    'SAVE
    Private Sub btnSaveItemColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveItemColor.Click
        Cursor = Cursors.WaitCursor
        Me.ValidateChildren()
        If TxtCodeItemColor.Text.ToString.Length < 1 Or TxtItemColor.Text.ToString.Length < 1 Then
            errorInput()
        Else
            Dim code_item_color As String = TxtCodeItemColor.Text.ToString
            Dim item_color As String = TxtItemColor.Text.ToString
            Dim descrtiption_item_color As String = MemoDescription.Text.ToString
            Dim query As String
            If action = "ins" Then
                Try
                    query = String.Format("INSERT INTO tb_m_item_color(code_item_color, item_color, description_item_color) VALUES('{0}', '{1}', '{2}')", code_item_color, item_color, descrtiption_item_color)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterItemColor.viewMasterItemColor()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = String.Format("UPDATE tb_m_item_color SET code_item_color='{0}', item_color='{1}', description_item_color='{2}' WHERE id_item_color='{3}'", code_item_color, item_color, descrtiption_item_color, id_item_color)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterItemColor.viewMasterItemColor()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    'Form Load
    Private Sub FormMasterItemColorSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If action = "upd" Then
            Dim query As String = String.Format("SELECT * FROM tb_m_item_color WHERE id_item_color = '{0}'", id_item_color)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtCodeItemColor.Text = data.Rows(0)("code_item_color").ToString
            TxtItemColor.Text = data.Rows(0)("item_color").ToString
            MemoDescription.Text = data.Rows(0)("description_item_color").ToString
        End If
    End Sub
End Class