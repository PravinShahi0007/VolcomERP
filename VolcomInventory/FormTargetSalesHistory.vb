Public Class FormTargetSalesHistory
    Public id_store As String = "-1"

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "Proposal Changes History : " + FormTargetSales.GVData.GetFocusedRowCellValue("comp_number").ToString + " - " + FormTargetSales.GVData.GetFocusedRowCellValue("comp_name").ToString)
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTargetSalesHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pt.id_b_revenue_propose, pt.`number`, pt.`year`, t.proposal_type, pt.`total`,
        pt.created_date, pt.id_created_user, e.employee_name AS `created_user`, pt.note
        FROM (
	        SELECT ptd.id_b_revenue_propose 
	        FROM tb_b_revenue_propose_det ptd
	        WHERE ptd.id_store='" + id_store + "'
	        GROUP BY ptd.id_b_revenue_propose
        ) ptd
        INNER JOIN tb_b_revenue_propose pt ON pt.id_b_revenue_propose = ptd.id_b_revenue_propose
        INNER JOIN tb_m_user u ON u.id_user = pt.id_created_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_lookup_proposal_type t ON t.id_proposal_type = pt.id_proposal_type
        WHERE pt.id_report_status=6
        ORDER BY pt.id_b_revenue_propose DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTargetSalesHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub RepoLinkNo_Click(sender As Object, e As EventArgs) Handles RepoLinkNo.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim sm As New ClassShowPopUp()
            sm.report_mark_type = "414"
            sm.id_report = GVData.GetFocusedRowCellValue("id_b_revenue_propose").ToString
            sm.show()
            Cursor = Cursors.Default
        End If
    End Sub
End Class