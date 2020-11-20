Public Class FormScanReturnBAP
    Public id_bap As String = "-1"
    Private Sub FormScanReturnBAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEBAP.EditValue = Now
        load_surat_jalan()
        load_type()
        load_det()
    End Sub

    Private Sub BDeleteScan_Click(sender As Object, e As EventArgs) Handles BDeleteScan.Click
        If GVListProduct.RowCount > 0 Then
            GVListProduct.DeleteSelectedRows()
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT id_type,id_product,`code`,description,size,qty,note
FROM tb_scan_return_bap_det WHERE id_scan_return_bap='" & id_bap & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListProduct.DataSource = dt
        GVListProduct.BestFitColumns()
    End Sub

    Sub load_surat_jalan()
        Dim q As String = "SELECT rn.`id_return_note`,rn.`label_number`,rn.`number_return_note`,rn.`qty`,IFNULL(sc.qty_scan,0) AS qty_scan
FROM tb_return_note rn
INNER JOIN
(
	SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
	FROM `tb_return_note_store` st
	INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
	GROUP BY st.`id_return_note`
)store ON store.id_return_note=rn.`id_return_note`
LEFT JOIN
(
	SELECT sc.id_return_note,sc.id_scan_return,COUNT(scd.id_scan_return_det) AS qty_scan
	FROM `tb_scan_return_det` scd
	INNER JOIN tb_scan_return sc ON sc.id_scan_return=scd.id_scan_return
	WHERE sc.is_void=2
	GROUP BY sc.id_scan_return
)sc ON sc.id_return_note=rn.`id_return_note`
WHERE rn.`is_lock`=2 AND rn.`is_void`=2"
        viewSearchLookupRepositoryQuery(RISLEReturnNote, q, 0, "", "")
    End Sub

    Sub load_type()
        Dim q As String = "SELECT '1' AS id_type,'Missing' AS `type`
UNION ALL
SELECT '2' AS id_type,'Over' AS `type`"
        viewSearchLookupRepositoryQuery(RISLEType, q, 0, "id_type", "type")
    End Sub

    Private Sub FormScanReturnBAP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

    End Sub

    Sub check_but()
        If GVListProduct.RowCount > 0 Then
            BDeleteScan.Visible = True
        Else
            BDeleteScan.Visible = False
        End If
    End Sub

    Private Sub CEAlasanLain_CheckedChanged(sender As Object, e As EventArgs) Handles CEAlasanLain.CheckedChanged
        If CEAlasanLain.Checked = True Then
            TEAlasanLain.Enabled = True
        Else
            TEAlasanLain.Enabled = False
        End If
    End Sub

    Private Sub BInputManual_Click(sender As Object, e As EventArgs) Handles BInputManual.Click
        GVListProduct.AddNewRow()
        GVListProduct.FocusedRowHandle = GVListProduct.RowCount - 1
        '
        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "type", "1")
        GVListProduct.SetRowCellValue(GVListProduct.RowCount - 1, "qty", 1)
        '
        FormScanReturnDet.GVListProduct.RefreshData()
        check_but()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click

    End Sub
End Class