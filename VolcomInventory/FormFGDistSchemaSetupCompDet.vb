Public Class FormFGDistSchemaSetupCompDet 
    Public id_pd_alloc_par As String = "-1"

    Private Sub FormFGDistSchemaSetupCompDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewComp()
    End Sub

    Private Sub FormFGDistSchemaSetupCompDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewComp()
        Dim query As String = ""
        query += "SELECT a.id_comp, a.comp_number, a.comp_name, b.comp_cat_name, ('No') AS `is_select` "
        query += "FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "WHERE ISNULL(a.id_pd_alloc) "
        query += "ORDER BY a.comp_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCodeDetail.DataSource = data
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        GVCodeDetail.ActiveFilterString = "[is_select] = 'Yes' "
        Dim jum_str As Integer = 0

        If GVCodeDetail.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to choose this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                'prepare query
                Dim query_ins As String = ""
                For l As Integer = 0 To ((GVCodeDetail.RowCount - 1) - GetGroupRowCount(GVCodeDetail))
                    If GVCodeDetail.GetRowCellValue(l, "is_select") = "Yes" Then
                        If jum_str = 0 Then
                            query_ins += "BEGIN; "
                        End If
                        query_ins += "UPDATE tb_m_comp SET id_pd_alloc ='" + id_pd_alloc_par.ToString + "' WHERE id_comp='" + GVCodeDetail.GetRowCellValue(l, "id_comp").ToString + "'; "
                        jum_str += 1
                    End If
                Next
                If jum_str > 0 Then
                    query_ins += "COMMIT; "
                End If
                execute_non_query(query_ins, True, "", "", "", "")
                FormFGDistSchemaSetup.viewAllocMember()
                Close()
                Cursor = Cursors.Default
            Else
                makeSafeGV(GVCodeDetail)
            End If
        Else
            stopCustom("Nothing item selected!")
            makeSafeGV(GVCodeDetail)
        End If


        Cursor = Cursors.Default
    End Sub
End Class