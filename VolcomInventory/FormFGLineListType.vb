Public Class FormFGLineListType 

    Private Sub FormFGLineListType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewLineType()
    End Sub

    Sub viewLineType()
        Dim query As String = "SELECT * FROM tb_lookup_pd_type ORDER BY id_pd_type ASC "
        viewSearchLookupQuery(SLETypeLineList, query, "id_pd_type", "pd_type", "id_pd_type")
    End Sub

    Private Sub BtnCopyFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopyFrom.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to copy data from this type?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_str As String = ""
            Dim jum_str As Integer = 0

            For l As Integer = 0 To ((FormFGLineList.BGVLineList.RowCount - 1) - GetGroupRowCount(FormFGLineList.BGVLineList))
                If FormFGLineList.BGVLineList.GetRowCellValue(l, "Select_sct") = "Yes" Then
                    If jum_str > 0 Then
                        id_str += ";"
                    End If
                    id_str += myCoalesce(FormFGLineList.BGVLineList.GetRowCellValue(l, "id_design").ToString, "0")
                    jum_str += 1
                End If
            Next
            Dim query As String = "CALL generate_pd_copy_from('" + id_str + "', '" + SLETypeLineList.EditValue.ToString + "', '" + FormFGLineList.SLETypeLineList.EditValue.ToString + "')"
            execute_non_query(query, True, "", "", "", "")
            FormFGLineList.viewLineList()
            infoCustom("Copy succesfully.")
            FormFGLineList.CheckEditSelAll.EditValue = False
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGLineListType_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class