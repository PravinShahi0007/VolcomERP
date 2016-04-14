Public Class FormPopUpMaterial 
    Private Sub FormPopUpMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewMat()
    End Sub
    Private Sub FormPopUpMaterial_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Sub viewMat()
        Dim query As String = "SELECT * FROM tb_m_mat a "
        query += "INNER JOIN tb_m_uom b ON a.id_uom = b.id_uom "
        query += "INNER JOIN tb_m_mat_cat c ON a.id_mat_cat = c.id_mat_cat "
        query += "ORDER BY a.mat_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRawMat.DataSource = data
        If data.Rows.Count > 0 Then
            viewMatDetail()
            XTPMaterialDetail.PageEnabled = True
        Else
            XTPMaterialDetail.PageEnabled = False
        End If
    End Sub
    'View Material Detail
    Sub viewMatDetail()
        LabelMatContent.Text = GVRawMat.GetFocusedRowCellDisplayText("mat_name").ToString
        Dim query As String = "SELECT * FROM tb_m_mat_det a  "
        query += "INNER JOIN tb_m_mat b ON a.id_mat = b.id_mat  "
        query += "LEFT JOIN tb_lookup_inventory_method c ON a.id_method = c.id_method  "
        query += "WHERE a.id_mat = '" + GVRawMat.GetFocusedRowCellDisplayText("id_mat").ToString + "' "
        query += "ORDER BY a.mat_det_date ASC,  id_mat_det ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatDetail.DataSource = data
    End Sub
    Private Sub GVRawMat_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVRawMat.RowClick
        viewMatDetail()
    End Sub

    Private Sub BAddMatType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMatType.Click
        FormMasterRawMaterialSingle.action = "ins"
        FormMasterRawMaterialSingle.ShowDialog()
    End Sub

    Private Sub BEditMatType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditMatType.Click
        FormMasterRawMaterialSingle.action = "upd"
        FormMasterRawMaterialSingle.id_mat = GVRawMat.GetFocusedRowCellDisplayText("id_mat").ToString
        FormMasterRawMaterialSingle.ShowDialog()
    End Sub

    Private Sub BDelMatType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMatType.Click
        Dim confirm As DialogResult
        Dim query As String

        Cursor = Cursors.WaitCursor
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this material type?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim id_mat As String = GVRawMat.GetFocusedRowCellDisplayText("id_mat").ToString
                query = "DELETE FROM tb_m_mat WHERE id_mat ='" + id_mat + "'"
                execute_non_query(query, True, "", "", "", "")
                logData("tb_m_mat", 3)
                FormMasterRawMaterial.viewMat()
            Catch ex As Exception
                errorConnection()
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        FormMasterRawMaterialDetSingle.action = "ins"
        FormMasterRawMaterialDetSingle.ShowDialog()
    End Sub

    Private Sub BEditMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditMat.Click
        FormMasterRawMaterialDetSingle.action = "upd"
        FormMasterRawMaterialDetSingle.id_mat_det = GVMatDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString
        FormMasterRawMaterialDetSingle.ShowDialog()
    End Sub

    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        Dim query As String

        Cursor = Cursors.WaitCursor
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this material detail?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim id_mat_det As String = GVMatDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString
                query = "DELETE FROM tb_m_mat_det WHERE id_mat_det ='" + id_mat_det + "'"
                execute_non_query(query, True, "", "", "", "")
                logData("tb_m_mat_det", 3)
                FormMasterRawMaterial.viewMatDetail()
            Catch ex As Exception
                errorConnection()
            End Try
        End If
        Cursor = Cursors.Default
    End Sub
End Class