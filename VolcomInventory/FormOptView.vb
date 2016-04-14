Public Class FormOptView
    Public frm_opt_name As String = "-1"
    Public gv_opt_name As String = "-1"
    Public tag_opt_name As String = "-1"
    Public dt As DataTable = Nothing

    Private Sub FormOptView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewTemp()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub viewTemp()
        Dim query As String = "SELECT * FROM tb_options_view a WHERE a.options_view_form='" + frm_opt_name + "' AND a.options_view_gv='" + gv_opt_name + "' AND a.options_view_tag='" + tag_opt_name + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCTemplate.DataSource = data
        If GVTemplate.RowCount > 0 Then
            GVTemplate.FocusedRowHandle = 0
        End If
        viewTempDet()
        viewRole()
        checkBut()
    End Sub

    Sub viewTempDet()
        Dim id_options_view As String = "-1"
        Try
            id_options_view = GVTemplate.GetFocusedRowCellValue("id_options_view").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT * FROM tb_options_view_det WHERE id_options_view='" + id_options_view + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSetup.DataSource = data
    End Sub

    Sub viewRole()
        Dim id_options_view As String = "-1"
        Try
            id_options_view = GVTemplate.GetFocusedRowCellValue("id_options_view").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT r.id_role, r.role, If(isnull(r_opt.id_options_view),'No', 'Yes') AS `is_select` FROM tb_m_role r "
        query += "LEFT JOIN tb_options_view_role r_opt ON r_opt.id_role = r.id_role AND r_opt.id_options_view='" + id_options_view + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRole.DataSource = data
    End Sub

    Sub checkBut()
        If GVTemplate.RowCount > 0 And GVTemplate.FocusedRowHandle >= 0 Then
            BtnDelete.Enabled = True
            BtnSave.Enabled = True
        Else
            BtnDelete.Enabled = False
            BtnSave.Enabled = False
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormOptView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim newRow As DataRow = (TryCast(GCTemplate.DataSource, DataTable)).NewRow()
        newRow("id_options_view") = "0"
        newRow("options_view_name") = ""
        TryCast(GCTemplate.DataSource, DataTable).Rows.Add(newRow)
        GCTemplate.RefreshDataSource()
        GVTemplate.RefreshData()
        GVTemplate.FocusedRowHandle = GVTemplate.RowCount - 1
        GVTemplate.FocusedColumn = GridColumnName
    End Sub

    Private Sub GVTemplate_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVTemplate.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As Integer = e.RowHandle
        Dim col As String = e.Column.FieldName.ToString
        If col = "options_view_name" Then
            Dim id As String = GVTemplate.GetRowCellValue(row_foc, "id_options_view").ToString
            If id = "0" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure your input before continue this process. Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "INSERT INTO tb_options_view(options_view_name, options_view_tag, options_view_form, options_view_gv) "
                    query += "VALUES('" + e.Value.ToString + "', '" + tag_opt_name + "', '" + frm_opt_name + "', '" + gv_opt_name + "'); SELECT LAST_INSERT_ID(); "
                    Dim id_opt As String = execute_query(query, 0, True, "", "", "", "")

                    'det
                    Dim query_det As String = "INSERT INTO tb_options_view_det(id_options_view, options_view_det_band, options_view_det_caption,options_view_det_column, options_view_det_visible) VALUES "
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If i > 0 Then
                            query_det += ", "
                        End If

                        query_det += "('" + id_opt + "', '" + dt.Rows(i)("options_view_det_band").ToString + "', '" + dt.Rows(i)("options_view_det_caption").ToString + "', '" + dt.Rows(i)("options_view_det_column").ToString + "', '" + dt.Rows(i)("options_view_det_visible").ToString + "') "

                        If dt.Rows.Count - 1 = i Then
                            execute_non_query(query_det, True, "", "", "", "")
                        End If
                    Next
                    viewTemp()
                    GVTemplate.FocusedRowHandle = find_row(GVTemplate, "id_options_view", id_opt)
                End If
            Else
                Dim query As String = "UPDATE tb_options_view SET options_view_name='" + e.Value.ToString + "' WHERE id_options_view='" + id + "' "
                execute_non_query(query, True, "", "", "", "")
                viewTemp()
                GVTemplate.FocusedRowHandle = find_row(GVTemplate, "id_options_view", id)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim query As String = "DELETE FROM tb_options_view WHERE id_options_view='" + GVTemplate.GetFocusedRowCellValue("id_options_view").ToString + "' "
                execute_non_query(query, True, "", "", "", "")
                viewTemp()
            Catch ex As Exception
                errorConnection()
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVTemplate_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVTemplate.FocusedRowChanged
        viewTempDet()
        viewRole()
        checkBut()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        'column
        For i As Integer = 0 To ((GVSetup.RowCount - 1) - GetGroupRowCount(GVSetup))
            Dim id_options_view_det As String = GVSetup.GetRowCellValue(i, "id_options_view_det").ToString
            Dim options_view_det_visible As String = GVSetup.GetRowCellValue(i, "options_view_det_visible").ToString
            Dim query As String = "UPDATE tb_options_view_det SET options_view_det_visible='" + options_view_det_visible + "' WHERE id_options_view_det='" + id_options_view_det + "' "
            execute_non_query(query, True, "", "", "", "")
        Next

        'role
        Dim id_opt As String = "-1"
        Try
            id_opt = GVTemplate.GetFocusedRowCellValue("id_options_view").ToString
        Catch ex As Exception
        End Try
        Dim query_del_role As String = "DELETE FROM tb_options_view_role WHERE id_options_view='" + id_opt + "' "
        execute_non_query(query_del_role, True, "", "", "", "")

        Dim ins As Integer = 0
        Dim query_role As String = "INSERT tb_options_view_role(id_options_view, id_role) VALUES "
        For j As Integer = 0 To ((GVRole.RowCount - 1) - GetGroupRowCount(GVRole))
            Dim is_select As String = GVRole.GetRowCellValue(j, "is_select").ToString
            Dim id_role As String = GVRole.GetRowCellValue(j, "id_role").ToString
            If is_select = "Yes" Then
                If ins > 0 Then
                    query_role += ", "
                End If
                query_role += "('" + id_opt + "', '" + id_role + "') "
                ins += 1
            End If
        Next
        If ins > 0 Then
            execute_non_query(query_role, True, "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub
End Class