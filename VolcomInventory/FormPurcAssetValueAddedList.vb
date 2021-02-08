Public Class FormPurcAssetValueAddedList
    Public id_parent As String = ""
    Public id_coa_tag As String = ""

    Private Sub FormPurcAssetValueAddedList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        'Dim query As String = a.queryMain("AND a.id_parent='" + id_parent + "' AND a.is_value_added=1 ", "2", False)
        Dim query As String = "SELECT ass.id_coa_tag.ass.asset_number,ass.asset_name,kap.number,kap.id_purc_rec_asset_kap,kap.id_purc_rec_asset,kap.created_date,kap.created_by,kap.id_po_reff,kap.coa_biaya,kap.added_month,kap.added_value,kap.note,kap.id_report_status
FROM `tb_purc_rec_asset_kap` kap
INNER JOIN `tb_purc_rec_asset` ass ON ass.id_purc_rec_asset=kap.id_purc_rec_asset
WHERE kap.id_purc_rec_asset='" & id_parent & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Private Sub FormPurcAssetValueAddedList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub LabelLinkAssetNumber_Click(sender As Object, e As EventArgs) Handles LabelLinkAssetNumber.Click
        Cursor = Cursors.WaitCursor
        Dim s As New ClassShowPopUp()
        s.id_report = id_parent
        s.report_mark_type = "160"
        s.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormPurcAssetValueAdded.action = "ins"
        FormPurcAssetValueAdded.id_parent = id_parent
        FormPurcAssetValueAdded.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormPurcAssetValueAdded.action = "upd"
            FormPurcAssetValueAdded.id_parent = id_parent
            FormPurcAssetValueAdded.id = GVData.GetFocusedRowCellValue("id_purc_rec_asset_kap")
            FormPurcAssetValueAdded.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub
End Class