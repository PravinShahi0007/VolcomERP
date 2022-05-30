Public Class FormMasterExtraTag
    Private Sub FormMasterExtraTag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dt.id_design_tag, dt.design_tag FROM tb_m_design_tag dt
        ORDER BY dt.id_design_tag ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterExtraTag_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub createNew()
        Cursor = Cursors.WaitCursor
        FormMasterExtraTagDet.action = "ins"
        FormMasterExtraTagDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMasterExtraTagDet.action = "upd"
            FormMasterExtraTagDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        viewDetail()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        createNew()
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim id_design_tag As String = GVData.GetFocusedRowCellValue("id_design_tag").ToString
                execute_non_query("DELETE FROM tb_m_design_tag WHERE id_design_tag='" + id_design_tag + "' ", True, "", "", "", "")
                viewData()
            Catch ex As Exception
                errorDelete()
            End Try
        End If
    End Sub
End Class