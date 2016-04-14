Public Class FormFGDistSchemeStoreCopy 

    Private Sub FormFGDistSchemeStoreCopy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range AND b.is_md='1' "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub BtnCopyFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopyFrom.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to copy from this season?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim query As String = "INSERT INTO tb_fg_ds_store(id_season, id_comp, id_store_rate) SELECT '" + FormFGDistSchemeStore.id_season_par.ToString + "', a.id_comp, a.id_store_rate FROM tb_fg_ds_store a WHERE a.id_season='" + SLESeason.EditValue.ToString + "' "
                execute_non_query(query, True, "", "", "", "")
                FormFGDistSchemeStore.viewDsStore()
                Close()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormFGDistSchemeStoreCopy_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class