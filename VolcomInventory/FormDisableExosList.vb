Public Class FormDisableExosList
    Private Sub FormDisableExosList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT e.id_design, d.design_code AS `code`, cd.class, d.design_display_name AS `name`, cd.sht, cd.color, 'No' AS `is_select`
        FROM tb_design_extended_eos e
        INNER JOIN tb_m_design d ON d.id_design = e.id_design
        LEFT JOIN (
	        SELECT dc.id_design, 
	        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43)
	        GROUP BY dc.id_design
        ) cd ON cd.id_design = d.id_design
        WHERE e.is_active=1 
        ORDER BY `class` ASC, `name` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim dv As DataView = New DataView(data)
        Dim ftr As String = "1=1 "
        For d As Integer = 0 To FormDisableExosDet.GVItemList.RowCount - 1
            ftr += "AND NOT id_design='" + FormDisableExosDet.GVItemList.GetRowCellValue(d, "id_design").ToString + "' "
        Next
        dv.RowFilter = ftr
        data = dv.ToTable
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDisableExosList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        For i As Integer = 0 To GVData.RowCount - 1
            Dim val As String = ""
            If CESelectAll.EditValue = True Then
                val = "Yes"
            Else
                val = "No"
            End If
            GVData.SetRowCellValue(i, "is_select", val)
        Next
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[is_select]='Yes' "
        If GVData.RowCount <= 0 Then
            stopCustom("No item selected")
        Else
            For i As Integer = 0 To GVData.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormDisableExosDet.GCItemList.DataSource, DataTable)).NewRow()
                newRow("id_disable_exos_det") = "0"
                newRow("name") = GVData.GetRowCellValue(i, "name").ToString
                newRow("code") = GVData.GetRowCellValue(i, "code").ToString
                newRow("size") = GVData.GetRowCellValue(i, "size").ToString
                newRow("class") = GVData.GetRowCellValue(i, "class").ToString
                newRow("color") = GVData.GetRowCellValue(i, "color").ToString
                newRow("sht") = GVData.GetRowCellValue(i, "sht").ToString
                newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                TryCast(FormDisableExosDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                FormDisableExosDet.GCItemList.RefreshDataSource()
                FormDisableExosDet.GVItemList.RefreshData()
            Next
            viewData()
        End If
        GVData.ActiveFilterString = ""
    End Sub
End Class