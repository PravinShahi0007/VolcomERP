Public Class FormMasterSilhouette
    Private Sub FormMasterSilhouette_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewClass()
    End Sub

    Sub viewClass()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 'No' AS `is_select`,cd.id_code_detail, cd.display_name, cd.code_detail_name 
        FROM tb_m_code_detail cd
        WHERE cd.id_code IN (SELECT o.id_code_fg_class  FROM tb_opt o)
        ORDER BY cd.display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterSilhouette_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click

    End Sub
End Class