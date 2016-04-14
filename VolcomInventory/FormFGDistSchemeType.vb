Public Class FormFGDistSchemeType 
    Public id_data_reff As String = "-1"
    Public id_pop_up As String = "-1"
    Public id_season_par As String = "-1"

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        If id_season_par <> "-1" Then
            query += "WHERE a.id_season = '" + id_season_par + "' "
        End If
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    'distribution schema type
    Sub viewDSType()
        Dim query As String = "SELECT * FROM tb_lookup_ds_type a ORDER BY a.id_ds_type ASC "
        viewSearchLookupQuery(SLEType, query, "id_ds_type", "ds_type", "id_ds_type")
    End Sub

    Private Sub FormFGDistSchemeType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
        viewDSType()
    End Sub

    Sub copyFromTarget()
        Dim query As String = ""
        query += "INSERT INTO tb_fg_ds(id_fg_ds_store, id_product, fg_ds_qty, id_ds_type) "
        query += "SELECT ds.id_fg_ds_store, ds.id_product, ds.fg_ds_qty, '" + FormFGDistScheme.SLEType.EditValue.ToString + "' "
        query += "FROM tb_fg_ds ds "
        query += "INNER JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds_store.id_fg_ds_store "
        query += "WHERE ds.id_ds_type = '" + SLEType.EditValue.ToString + "' AND ds_store.id_season = '" + SLESeason.EditValue.ToString + "' "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGDistSchemeType_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        If id_pop_up = "1" Then ' show data reference -form distribution scheme
            Cursor = Cursors.WaitCursor
            FormFGDistScheme.loadDS(SLESeason.EditValue.ToString, SLEType.EditValue.ToString, FormFGDistScheme.GCCompare, FormFGDistScheme.GVCompare)
            FormFGDistScheme.LabelControlCompare.Text = SLESeason.Text + " / " + SLEType.Text.ToUpper
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "2" Then 'copy from - form distribution scheme
            Dim query As String = ""
            query += "SELECT COUNT(*) "
            query += "FROM tb_fg_ds ds "
            query += "INNER JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds.id_fg_ds_store "
            query += "WHERE ds.id_ds_type = '" + FormFGDistScheme.SLEType.EditValue.ToString + "' AND ds_store.id_season = '" + FormFGDistScheme.SLESeason.EditValue.ToString + "' "
            Dim jum As String = execute_query(query, 0, True, "", "", "", "")
            If jum <= 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to copy from this type ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        copyFromTarget()
                        FormFGDistScheme.loadDS(FormFGDistScheme.SLESeason.EditValue.ToString, FormFGDistScheme.SLEType.EditValue.ToString, FormFGDistScheme.GCDS, FormFGDistScheme.GVDS)
                        Close()
                    Catch ex As Exception
                        errorProcess()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to replace from this type ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim query_del As String = ""
                    query_del += "DELETE "
                    query_del += "FROM tb_fg_ds "
                    query_del += "WHERE id_fg_ds IN ( "
                    query_del += "SELECT * FROM ( "
                    query_del += "Select id_fg_ds "
                    query_del += "FROM tb_fg_ds "
                    query_del += "INNER JOIN tb_fg_ds_store ON tb_fg_ds.id_fg_ds_store = tb_fg_ds_store.id_fg_ds_store "
                    query_del += "WHERE tb_fg_ds.id_ds_type = '" + FormFGDistScheme.SLEType.EditValue.ToString + "' AND tb_fg_ds_store.id_season = '" + FormFGDistScheme.SLESeason.EditValue.ToString + "' "
                    query_del += ") a "
                    query_del += ") "
                    Try
                        execute_non_query(query_del, True, "", "", "", "")
                        copyFromTarget()
                        FormFGDistScheme.loadDS(FormFGDistScheme.SLESeason.EditValue.ToString, FormFGDistScheme.SLEType.EditValue.ToString, FormFGDistScheme.GCDS, FormFGDistScheme.GVDS)
                        Close()
                    Catch ex As Exception
                        errorProcess()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf id_pop_up = "3" Then ' show data reference - form analysis SO
            Cursor = Cursors.WaitCursor

            FormFGDistScheme.loadDS(SLESeason.EditValue.ToString, SLEType.EditValue.ToString, FormFGDistScheme.GCCompare, FormFGDistScheme.GVCompare)
            FormFGDistScheme.LabelControlCompare.Text = SLESeason.Text + " / " + SLEType.Text.ToUpper

            Dim query_c As ClassDesign = New ClassDesign()
            query_c.loadDS(SLESeason.EditValue.ToString, SLEType.EditValue.ToString, FormFGSalesOrderReffDet.GCCompare, FormFGSalesOrderReffDet.GVCompare, "-1", "1")
            FormFGSalesOrderReffDet.LabelControlCompare.Text = SLESeason.Text + " / " + SLEType.Text.ToUpper
            Close()
            Cursor = Cursors.Default
        End If
    End Sub
End Class