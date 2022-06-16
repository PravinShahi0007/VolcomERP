Public Class FormMasterExtraTagDet
    Public action As String = "-1"
    Public id As String = "-1"

    Private Sub FormMasterExtraTagDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If action = "upd" Then
            id = FormMasterExtraTag.GVData.GetFocusedRowCellValue("id_design_tag").ToString
            TxtTag.Text = FormMasterExtraTag.GVData.GetFocusedRowCellValue("design_tag").ToString
        End If
    End Sub

    Private Sub FormMasterExtraTagDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Dim design_tag As String = addSlashes(TxtTag.Text.ToString)
        If action = "ins" Then
            Dim query As String = "INSERT INTO tb_m_design_tag(design_tag) VALUES('" + design_tag + "'); "
            execute_non_query(query, True, "", "", "", "")
            FormMasterExtraTag.viewData()
            Close()
        ElseIf action = "upd" Then
            Dim query As String = "UPDATE tb_m_design_tag SET design_tag='" + design_tag + "' WHERE id_design_tag='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormMasterExtraTag.viewData()
            Close()
        End If
        Cursor = Cursors.Default
    End Sub
End Class