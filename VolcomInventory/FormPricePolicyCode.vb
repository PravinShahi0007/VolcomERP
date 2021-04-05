Public Class FormPricePolicyCode
    Public is_single As Boolean = False

    Private Sub FormPricePolicyCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
        If is_single Then
            PCDeliveryTitle.Visible = True
        End If
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cd.id_code_detail, cd.display_name AS `code`, cd.code_detail_name AS `description`,
        CONCAT(CAST(MAX(CASE WHEN p.id_disc_type=1 THEN p.age_min END) AS DECIMAL(5,0)),'-',CAST(MAX(CASE WHEN p.id_disc_type=1 THEN p.age_max END) AS DECIMAL(5,0))) AS `normal_view`,
        CONCAT(CAST(MAX(CASE WHEN p.id_disc_type=2 THEN p.age_min END) AS DECIMAL(5,0)),'-',CAST(MAX(CASE WHEN p.id_disc_type=2 THEN p.age_max END) AS DECIMAL(5,0))) AS `mkd_30_view`,
        CONCAT(CAST(MAX(CASE WHEN p.id_disc_type=3 THEN p.age_min END) AS DECIMAL(5,0)),'-',CAST(MAX(CASE WHEN p.id_disc_type=3 THEN p.age_max END) AS DECIMAL(5,0))) AS `mkd_50_view`,
        CONCAT(CAST(MAX(CASE WHEN p.id_disc_type=4 THEN p.age_min END) AS DECIMAL(5,0)),'-',CAST(MAX(CASE WHEN p.id_disc_type=4 THEN p.age_max END) AS DECIMAL(5,0))) AS `mkd_70_view`
        FROM tb_m_code_detail cd
        LEFT JOIN tb_m_design_price_policy p ON p.id_code_detail = cd.id_code_detail
        LEFT JOIN tb_lookup_disc_type dt ON dt.id_disc_type = p.id_disc_type
        WHERE cd.id_code IN (SELECT id_code_price_policy FROM tb_opt)
        GROUP BY p.id_code_detail
        ORDER BY cd.display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPricePolicyCode_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPricePolicyCode_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        upd()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        upd()
    End Sub

    Sub upd()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Cursor = Cursors.WaitCursor
        FormPricePolicyCodeDet.action = "ins"
        FormPricePolicyCodeDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm_delm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this code ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_code_detail As String = GVData.GetFocusedRowCellValue("id_code_detail").ToString
            If confirm_delm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim query_delm As String = String.Format("DELETE FROM tb_m_code_detail WHERE id_code_detail = '{0}'", id_code_detail)
                    execute_non_query(query_delm, True, "", "", "", "")
                    viewData()
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("This code already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class