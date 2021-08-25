Public Class FormMasterSilhouetteDet
    Public id_class As String = "-1"

    Sub viewSht()
        Dim query As String = "SELECT 
        cd.id_code_detail,cd.code_detail_name 
        FROM tb_m_code_detail cd 
        LEFT JOIN tb_mapping_sht ms ON ms.id_sht = cd.id_code_detail AND ms.id_class = " + id_class + "
        WHERE cd.id_code IN (SELECT o.id_code_fg_sht FROM tb_opt o)
        AND ISNULL(ms.id_sht)
        ORDER BY cd.code_detail_name ASC "
        viewSearchLookupQuery(SLESHT, query, "id_code_detail", "code_detail_name", "id_code_detail")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ms.id_class, ms.id_sht, cd.code_detail_name AS `sht_name`
        FROM tb_mapping_sht ms 
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = ms.id_sht
        WHERE ms.id_class=" + id_class + "
        ORDER BY cd.display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterSilhouetteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSht()
        viewData()
    End Sub

    Private Sub BtnSet_Click(sender As Object, e As EventArgs) Handles BtnSet.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "INSERT INTO tb_mapping_sht(id_sht, id_class) VALUES('" + SLESHT.EditValue.ToString + "','" + id_class + "'); "
        execute_non_query(query, True, "", "", "", "")
        viewSht()
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub DeleteMappingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteMappingToolStripMenuItem.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to remove : '" + GVData.GetFocusedRowCellValue("sht_name").ToString + "', for this class?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            execute_non_query("DELETE FROM tb_mapping_sht WHERE id_sht='" + GVData.GetFocusedRowCellValue("id_sht").ToString + "' AND id_class='" + id_class + "' ", True, "", "", "", "")
            viewSht()
            viewData()
        End If
    End Sub
End Class