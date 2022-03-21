Public Class FormClassGroup
    Private Sub FormClassGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Private Sub FormClassGroup_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormClassGroup_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormClassGroupDet.id_class_group = "-1"
        FormClassGroupDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to remove : '" + GVData.GetFocusedRowCellValue("class_group").ToString + "'?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                execute_non_query("DELETE FROM tb_class_group WHERE id_class_group='" + GVData.GetFocusedRowCellValue("id_class_group").ToString + "' ", True, "", "", "", "")
                viewData()
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "Class Group")
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_class_group, dv.display_name AS `division`, typ.class_type, UPPER(cat.class_cat) AS `class_cat`,
GROUP_CONCAT(DISTINCT cls.display_name ORDER BY cls.display_name ASC) AS `class_group`, cg.estimasi_sku
FROM tb_class_group cg 
INNER JOIN tb_class_group_det cgd ON cgd.id_class_group = cg.id_class_group
INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = cgd.id_class
INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
INNER JOIN tb_class_type typ ON typ.id_class_type = cg.id_class_type
INNER JOIN tb_class_cat cat ON cat.id_class_cat = cg.id_class_cat
GROUP BY cg.id_class_group
ORDER BY division ASC, cg.id_class_group ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        detail()
    End Sub

    Sub detail()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormClassGroupDet.id_class_group = GVData.GetFocusedRowCellValue("id_class_group").ToString
            FormClassGroupDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class