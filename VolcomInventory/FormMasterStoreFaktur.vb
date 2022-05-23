Public Class FormMasterStoreFaktur
    Private Sub FormMasterStoreFaktur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.description AS `store_group`, kp.npwp_name AS `nama_npwp_kantor_pusat`, TRIM(kp.npwp) AS `npwp_kantor_pusat`,
        c.comp_number AS `akun_toko`, c.comp_name AS `nama_toko`, c.address_efaktur
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp kp ON kp.id_comp = c.id_store_company
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        WHERE c.id_comp_cat = 6 AND c.is_active=1 AND c.id_comp_group!=7
        ORDER BY store_group ASC, akun_toko ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterStoreFaktur_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMasterStoreFaktur_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnImportXLS_Click(sender As Object, e As EventArgs) Handles BtnImportXLS.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "67"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class