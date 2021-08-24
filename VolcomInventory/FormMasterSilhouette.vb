Public Class FormMasterSilhouette
    Private Sub FormMasterSilhouette_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewClass()
    End Sub

    Sub viewClass()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cls.id_code_detail AS `id_class`, cls.display_name AS `class`, cls.code_detail_name AS `class_desc`, 
        sht.id_code_detail AS `id_sht`, sht.code_detail_name AS `sht_name`
        FROM tb_m_code_detail cls
        LEFT JOIN tb_mapping_sht ms ON ms.id_class = cls.id_code_detail
        INNER JOIN tb_m_code_detail sht ON sht.id_code_detail = ms.id_sht AND sht.id_code IN (SELECT o.id_code_fg_sht FROM tb_opt o)
        WHERE cls.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o)
        ORDER BY cls.display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterSilhouette_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs)

    End Sub
End Class