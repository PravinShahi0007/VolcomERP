Public Class FormFollowUpARHistory
    Public id_follow_up_recap As String = "0"
    Public is_view As String = "-1"

    Private Sub FormFollowUpARHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextEditReportStatus.Text = execute_query("SELECT s.report_status FROM tb_follow_up_recap AS r LEFT JOIN tb_lookup_report_status AS s ON r.id_report_status = s.id_report_status WHERE r.id_follow_up_recap = " + id_follow_up_recap, 0, True, "", "", "", "")

        Dim query As String = "
            SELECT (@no := IF(@last_group <> `group`, (@no + 1), @no)) AS `no`, `group`, `amount`, `due_date`, `follow_up_date`, `follow_up`, `follow_up_result`, (@last_group := `group`) AS `last_group`
            FROM (
                SELECT rd.group, rd.amount, DATE_FORMAT(rd.due_date, '%d %M %Y') AS due_date, DATE_FORMAT(rd.follow_up_date, '%d %M %Y') AS follow_up_date, rd.follow_up, rd.follow_up_result
                FROM tb_follow_up_recap_det AS rd
                LEFT JOIN tb_follow_up_recap AS r ON rd.id_follow_up_recap = r.id_follow_up_recap
                WHERE r.id_follow_up_recap = " + id_follow_up_recap + "
                ORDER BY rd.id_comp_group, rd.due_date, rd.follow_up_date
            ) AS tb, (SELECT @no := 0) AS `no`, (SELECT @last_group := '') AS last_group
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCActive.DataSource = data

        GVActive.BestFitColumns()
    End Sub

    Private Sub FormFollowUpARHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButtonMark_Click(sender As Object, e As EventArgs) Handles SimpleButtonMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "234"
        FormReportMark.id_report = id_follow_up_recap
        FormReportMark.is_view = is_view

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButtonClose_Click(sender As Object, e As EventArgs) Handles SimpleButtonClose.Click
        Close()
    End Sub

    Private Sub SimpleButtonPrint_Click(sender As Object, e As EventArgs) Handles SimpleButtonPrint.Click
        print_recap(id_follow_up_recap)
    End Sub

    Sub print_recap(ByVal id_follow_up_recap As String)
        Dim report As ReportFollowUpAR = New ReportFollowUpAR

        report.id_follow_up_recap = id_follow_up_recap

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub

    Private Sub GVActive_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVActive.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "group" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = "Total " + GVActive.GetRowCellValue(e.RowHandle, "group").ToString
            End Select
        End If
    End Sub
End Class