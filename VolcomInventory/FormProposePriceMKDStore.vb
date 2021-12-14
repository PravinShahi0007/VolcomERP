Public Class FormProposePriceMKDStore
    Dim id_design_mkd As String = "-1"

    Private Sub FormProposePriceMKDStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_design_mkd = FormProposePriceMKD.GVSummary.GetFocusedRowCellValue("id_design_mkd").ToString
        TxtNumber.Text = FormProposePriceMKD.GVSummary.GetFocusedRowCellValue("number").ToString
        TxtType.Text = FormProposePriceMKD.GVSummary.GetFocusedRowCellValue("design_mkd").ToString
        viewStore()
    End Sub

    Private Sub FormProposePriceMKDStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description AS comp_group_desc
        FROM tb_m_comp c
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        WHERE c.id_comp_cat=6 AND c.is_active=1 AND c.id_commerce_type=1
        GROUP BY c.id_comp_group "
        viewSearchLookupQuery(SLEStore, query, "id_comp_group", "comp_group_desc", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        Cursor = Cursors.WaitCursor
        If id_design_mkd = "1" Then
            ReportMkdEOS.id = FormProposePriceMKD.GVSummary.GetFocusedRowCellValue("id_pp_change").ToString
            ReportMkdEOS.id_store = SLEStore.EditValue.ToString
            Dim Report As New ReportMkdEOS()
            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
        Cursor = Cursors.Default
    End Sub
End Class