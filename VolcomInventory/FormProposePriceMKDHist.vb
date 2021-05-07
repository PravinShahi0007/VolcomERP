Public Class FormProposePriceMKDHist
    Public id As String = "-1"
    Public id_design As String = "-1"

    Private Sub FormProposePriceMKDHist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ppd.id_pp_change_det, ppd.id_pp_change, pp.`number`,pp.created_date, 
        ppd.erp_discount, ppd.propose_discount, ppd.propose_price, ppd.propose_price_final, ppd.note
        FROM tb_pp_change_det ppd
        INNER JOIN tb_pp_change pp ON pp.id_pp_change = ppd.id_pp_change
        WHERE ppd.id_design=" + id_design + " AND ppd.id_pp_change<" + id + "
        AND pp.id_report_status=6
        ORDER BY ppd.id_pp_change_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProposePriceMKDHist_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub RepoLinkNumber_Click(sender As Object, e As EventArgs) Handles RepoLinkNumber.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim mkd As New FormProposePriceMKDDet()
            mkd.is_view = "1"
            mkd.action = "upd"
            mkd.id = GVData.GetFocusedRowCellValue("id_pp_change").ToString
            mkd.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub
End Class