Public Class FormFGDistSchemaSetup 

    Private Sub FormFGDistSchemaSetup_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormFGDistSchemaSetup_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormFGDistSchemaSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPDAlloc()
    End Sub

    Sub viewPDAlloc()
        Dim query As String = "SELECT * FROM tb_lookup_pd_alloc a INNER JOIN tb_lookup_answer b ON a.is_include_so = b.id_answer "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAlloc.DataSource = data
        If GVAlloc.RowCount > 0 Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub viewAllocMember()
        Dim id_pd_alloc_par As String = "-1"
        Try
            id_pd_alloc_par = GVAlloc.GetFocusedRowCellValue("id_pd_alloc").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT * from tb_m_comp WHERE id_pd_alloc = '" + id_pd_alloc_par + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCompList.DataSource = data
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGDistSchemaSetupAllocDet.action = "ins"
        FormFGDistSchemaSetupAllocDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub editAlloc()
        Cursor = Cursors.WaitCursor
        FormFGDistSchemaSetupAllocDet.action = "upd"
        FormFGDistSchemaSetupAllocDet.id_pd_alloc = GVAlloc.GetFocusedRowCellValue("id_pd_alloc").ToString
        FormFGDistSchemaSetupAllocDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        editAlloc()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_pd_alloc As String = "-1"
            Try
                id_pd_alloc = GVAlloc.GetFocusedRowCellValue("id_pd_alloc").ToString
            Catch ex As Exception
            End Try
            Dim query As String = "DELETE FROM tb_lookup_pd_alloc WHERE id_pd_alloc = '" + id_pd_alloc + "' "
            Try
                execute_non_query(query, True, "", "", "", "")
                viewPDAlloc()
            Catch ex As Exception
                errorDelete()
            End Try
        End If
    End Sub

    Private Sub GVAlloc_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVAlloc.DoubleClick
        editAlloc()
    End Sub

    Private Sub GVAlloc_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVAlloc.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        viewAllocMember()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVAlloc_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVAlloc.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        viewAllocMember()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeleteComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteComp.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim id_comp As String = "-1"
            Try
                id_comp = GVCompList.GetFocusedRowCellValue("id_comp").ToString
            Catch ex As Exception
            End Try
            Dim query As String = "UPDATE tb_m_comp SET id_pd_alloc = NULL WHERE id_comp= '" + id_comp + "' "
            Try
                execute_non_query(query, True, "", "", "", "")
                viewAllocMember()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAddComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddComp.Click
        Cursor = Cursors.WaitCursor
        Dim id_pd_alloc_par As String = "-1"
        Try
            id_pd_alloc_par = GVAlloc.GetFocusedRowCellValue("id_pd_alloc").ToString
        Catch ex As Exception
        End Try
        If id_pd_alloc_par = "" Or id_pd_alloc_par = "-1" Then
            errorCustom("Please select allocation group!")
        Else
            FormFGDistSchemaSetupCompDet.id_pd_alloc_par = GVAlloc.GetFocusedRowCellValue("id_pd_alloc").ToString
            FormFGDistSchemaSetupCompDet.LabelControl1.Text = GVAlloc.GetFocusedRowCellValue("pd_alloc").ToString
            FormFGDistSchemaSetupCompDet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub
End Class