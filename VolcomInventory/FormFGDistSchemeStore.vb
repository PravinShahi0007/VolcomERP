Public Class FormFGDistSchemeStore 
    Public id_season_par As String = "-1"

    'form load
    Private Sub FormFGDistSchemeStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDsStore()
        check_but()
    End Sub

    'distribution schema type
    Sub viewDsStore()
        Dim query As String = ""
        query += "SELECT alloc.id_pd_alloc, IFNULL(alloc.pd_alloc, '-') AS `pd_alloc`, area.id_area, IFNULL(area.area, '-') AS `area`, store.id_fg_ds_store, ss.id_season, ss.season, comp.id_comp, comp.comp_number, comp.comp_name, rat.id_store_rate, rat.store_rate "
        query += "FROM tb_fg_ds_store store "
        query += "INNER JOIN tb_season ss ON ss.id_season = store.id_season "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = store.id_comp "
        query += "INNER JOIN tb_lookup_store_rate rat ON rat.id_store_rate = store.id_store_rate "
        query += "LEFT JOIN tb_m_area area ON area.id_area = comp.id_area "
        query += "LEFT JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = comp.id_pd_alloc "
        query += "LEFT JOIN tb_lookup_so_cat cat ON cat.id_so_cat = alloc.id_so_cat "
        query += "WHERE store.id_season = '" + id_season_par + "' ORDER BY cat.id_so_cat ASC, comp.comp_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAccount.DataSource = data
    End Sub

    'check but
    Sub check_but()
        Dim indeks As Integer = -1
        Try
            indeks = GVAccount.FocusedRowHandle
        Catch ex As Exception
        End Try

        If GVAccount.RowCount > 0 And indeks >= 0 Then
            BtnDel.Enabled = True
        Else
            BtnDel.Enabled = False
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGDistSchemeStoreDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVAccount_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVAccount.FocusedRowChanged
        check_but()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this account ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim id_fg_ds_store As String = GVAccount.GetFocusedRowCellValue("id_fg_ds_store").ToString

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_fg_ds_store WHERE id_fg_ds_store = '{0}'", id_fg_ds_store)
                execute_non_query(query, True, "", "", "", "")
                viewDsStore()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Cursor = Cursors.WaitCursor
        FormFGDistSchemeStoreCopy.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGDistSchemeStore_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'If GVAccount.RowCount > 0 Then
        Cursor = Cursors.WaitCursor
        FormFGDistScheme.loadDS(FormFGDistScheme.SLESeason.EditValue.ToString, FormFGDistScheme.SLEType.EditValue.ToString, FormFGDistScheme.GCDS, FormFGDistScheme.GVDS)
        Cursor = Cursors.Default
        'End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCAccount, GroupControl1.Text)
        Cursor = Cursors.Default
    End Sub
End Class