Public Class FormFGDistSchemeStoreDet 

    Private Sub FormFGDistSchemeStoreDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDetail()
        noEdit()
        GVCodeDetail.ActiveFilterString = "[pd_alloc]<>'-'"
        loadStoreRate()
    End Sub

    Sub loadStoreRate()
        Dim query_cat As String = "select * from tb_lookup_store_rate a order by a.id_store_rate asc "
        Dim data_cat As DataTable = execute_query(query_cat, -1, True, "", "", "", "")
        RepositoryItemSearchLookUpEdit1.DataSource = Nothing
        RepositoryItemSearchLookUpEdit1.DataSource = data_cat
        RepositoryItemSearchLookUpEdit1.PopulateViewColumns()
        RepositoryItemSearchLookUpEdit1.NullText = ""
        RepositoryItemSearchLookUpEdit1.View.Columns("id_store_rate").Visible = False
        RepositoryItemSearchLookUpEdit1.DisplayMember = "store_rate"
        RepositoryItemSearchLookUpEdit1.ValueMember = "id_store_rate"
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        query += "SELECT IFNULL(alloc.id_pd_alloc,'0') AS `id_pd_alloc`, IFNULL(alloc.pd_alloc, '-') AS `pd_alloc`, cmp.id_comp, cmp.comp_number, cmp.comp_name, are.id_area, IFNULL(are.area, '-') AS `area`, "
        query += "cmp_cat.id_comp_cat, cmp_cat.comp_cat_name, ('1') AS `id_store_rate`, ('No') AS is_select "
        query += "FROM tb_m_comp cmp "
        query += "INNER JOIN tb_m_comp_cat cmp_cat ON cmp.id_comp_cat = cmp_cat.id_comp_cat "
        query += "LEFT JOIN tb_m_area are ON are.id_area = cmp.id_area "
        query += "LEFT JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = cmp.id_pd_alloc "
        query += "WHERE cmp.is_active = '1' "
        query += "ORDER BY cmp.comp_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCodeDetail.DataSource = data
    End Sub

    Sub noEdit()
        If GVCodeDetail.FocusedRowHandle >= 0 Then
            Dim alloc_cek As String = GVCodeDetail.GetFocusedRowCellValue("id_pd_alloc").ToString
            If alloc_cek = "0" Then
                GVCodeDetail.Columns("is_select").OptionsColumn.AllowEdit = False
            Else
                GVCodeDetail.Columns("is_select").OptionsColumn.AllowEdit = True
            End If
        End If
    End Sub

    Private Sub BAddComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddComp.Click
        FormMasterCompanySingle.id_company = "-1"
        FormMasterCompanySingle.id_pop_up = "2"
        FormMasterCompanySingle.ShowDialog()
    End Sub

    Private Sub BEditComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditComp.Click
        FormMasterCompanySingle.id_company = GVCodeDetail.GetFocusedRowCellValue("id_comp").ToString
        FormMasterCompanySingle.id_pop_up = "2"
        FormMasterCompanySingle.ShowDialog()
    End Sub

    Private Sub BDelComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelComp.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this company ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim id_company As String = GVCodeDetail.GetFocusedRowCellValue("id_comp").ToString

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_m_comp WHERE id_comp = '{0}'", id_company)
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnRateStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRateStore.Click
        Cursor = Cursors.WaitCursor
        FormMasterRateStore.is_single = True
        FormMasterRateStore.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEdit1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEdit1.CheckedChanged
        If GVCodeDetail.RowCount > 0 Then
            Dim cek As String = CheckEdit1.EditValue.ToString
            For i As Integer = 0 To ((GVCodeDetail.RowCount - 1) - GetGroupRowCount(GVCodeDetail))
                If cek Then
                    GVCodeDetail.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVCodeDetail.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub GVCodeDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCodeDetail.FocusedRowChanged
        If GVCodeDetail.RowCount > 0 And GVCodeDetail.FocusedRowHandle >= 0 Then
            BEditComp.Enabled = True
            BDelComp.Enabled = True
        Else
            BEditComp.Enabled = False
            BDelComp.Enabled = False
        End If
        noEdit()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        Dim jum_tot As Integer = 0
        Dim cond_same As Boolean = False
        Dim string_same As String = "-1"
        Dim id_comp_same As String = "-1"
        Dim idx_same As Integer = 0
        For i As Integer = 0 To ((GVCodeDetail.RowCount - 1) - GetGroupRowCount(GVCodeDetail))
            If GVCodeDetail.GetRowCellValue(i, "is_select") = "Yes" Then
                jum_tot += 1
                For j As Integer = 0 To ((FormFGDistSchemeStore.GVAccount.RowCount - 1) - GetGroupRowCount(FormFGDistSchemeStore.GVAccount))
                    If FormFGDistSchemeStore.GVAccount.GetRowCellValue(j, "id_comp").ToString = GVCodeDetail.GetRowCellValue(i, "id_comp").ToString Then
                        string_same = "Account : " + GVCodeDetail.GetRowCellValue(i, "comp_number").ToString + "/" + GVCodeDetail.GetRowCellValue(i, "comp_name").ToString + ", already exist. "
                        idx_same = i
                        cond_same = True
                        Exit For
                    End If
                Next
               
                If cond_same Then
                    Exit For
                End If
            End If
        Next

        Dim id_str As String = ""
        Dim jum_str As Integer = 0
        If jum_tot > 0 Then
            If cond_same Then
                stopCustom(string_same)
                GVCodeDetail.FocusedRowHandle = idx_same
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to choose account lists?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    Dim query_ins As String = "INSERT INTO tb_fg_ds_store(id_season, id_comp, id_store_rate) VALUES "
                    For l As Integer = 0 To ((GVCodeDetail.RowCount - 1) - GetGroupRowCount(GVCodeDetail))
                        If GVCodeDetail.GetRowCellValue(l, "is_select") = "Yes" Then
                            If jum_str > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + FormFGDistSchemeStore.id_season_par + "', '" + GVCodeDetail.GetRowCellValue(l, "id_comp").ToString + "', '" + GVCodeDetail.GetRowCellValue(l, "id_store_rate").ToString + "') "
                            jum_str += 1
                        End If
                    Next
                    execute_non_query(query_ins, True, "", "", "", "")
                    FormFGDistSchemeStore.viewDsStore()
                    Close()
                    Cursor = Cursors.Default
                End If
            End If
        Else
            stopCustom("Nothing item selected!")
        End If
        Cursor = Cursors.Default
    End Sub
End Class