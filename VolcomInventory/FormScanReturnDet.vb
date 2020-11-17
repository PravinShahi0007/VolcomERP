Public Class FormScanReturnDet
    Public id_scan_return As String = "-1"
    Public id_return_note As String = "-1"
    Dim dt_product As DataTable

    Private Sub FormScanReturnDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormScanReturnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det()
        load_product()
    End Sub

    Sub load_product()
        Dim q As String = "SELECT id_product,product_full_code,product_display_name FROM tb_m_product WHERE "
        dt_product = execute_query(q, -1, True, "", "", "", "")
    End Sub

    Sub load_det()
        Dim q As String = "SELECT id_scan_return_det,scanned_code,`type` FROM `tb_scan_return_det`
WHERE id_scan_return='" & id_scan_return & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListProduct.DataSource = dt
        GVListProduct.BestFitColumns()
    End Sub

    Private Sub TEReturnLabel_KeyDown(sender As Object, e As KeyEventArgs) Handles TEReturnLabel.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim q As String = "SELECT rn.*,st_list.store FROM `tb_return_note` rn
LEFT JOIN
(
    SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\r\n') AS store
    FROM `tb_return_note_store` st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_return_note`
)st_list ON st_list.id_return_note=rn.id_return_note
WHERE rn.label_number='" & addSlashes(TEReturnLabel.Text) & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                id_return_note = dt.Rows(0)("id_return_note").ToString
                TEQty.EditValue = dt.Rows(0)("qty")
                MEListStore.Text = dt.Rows(0)("store").ToString
                TEReturnLabel.Enabled = False
                TEScan.Focus()
            End If
        End If
    End Sub

    Private Sub TEScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TEScan.KeyDown

    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        id_return_note = "-1"
        TEQty.EditValue = 0
        MEListStore.Text = ""
        TEReturnLabel.Text = ""
        TEReturnLabel.Enabled = True
    End Sub

    Private Sub BDeleteScan_Click(sender As Object, e As EventArgs) Handles BDeleteScan.Click
        If GVListProduct.RowCount > 0 Then
            GVListProduct.DeleteSelectedRows()
        End If
    End Sub
End Class