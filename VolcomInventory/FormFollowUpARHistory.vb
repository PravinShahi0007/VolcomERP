Public Class FormFollowUpARHistory
    Public id_follow_up_recap As String = "0"
    Public is_view As String = "-1"

    Private Sub FormFollowUpARHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fill As DataTable = execute_query("
            SELECT r.id_follow_up_recap, e.employee_name AS created_by, DATE_FORMAT(r.created_date, '%d %M %Y %H:%i:%s') AS created_date, DATE_FORMAT(r.follow_up_date, '%d %M %Y') AS follow_up_date, s.report_status
            FROM tb_follow_up_recap AS r
            LEFT JOIN tb_m_user AS u ON r.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee= e.id_employee
            LEFT JOIN tb_lookup_report_status AS s ON r.id_report_status = s.id_report_status
            WHERE r.id_follow_up_recap = " + id_follow_up_recap,
        -1, True, "", "", "", "")

        TextEditReportStatus.Text = fill.Rows(0)("report_status").ToString
        TextEditFollowUpDate.Text = fill.Rows(0)("follow_up_date").ToString
        TextEditCreatedBy.Text = fill.Rows(0)("created_by").ToString
        TextEditCreatedDate.Text = fill.Rows(0)("created_date").ToString

        Dim query As String = "
            SELECT (@no := IF(@last_group <> `group`, (@no + 1), @no)) AS `no`, `group`, `amount`, `due_date`, `follow_up_date`, `follow_up`, `follow_up_result`, `id_comp_group`, (@last_group := `group`) AS `last_group`
            FROM (
                SELECT rd.group, rd.amount, DATE_FORMAT(rd.due_date, '%d %M %Y') AS due_date, DATE_FORMAT(rd.follow_up_date, '%d %M %Y') AS follow_up_date, rd.follow_up, rd.follow_up_result, rd.id_comp_group
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

    Dim last_grp As String = ""
    Dim last_due As String = ""
    Dim tot_amo_grp As Double = 0.00
    Dim tot_amo As Double = 0.00

    Private Sub GVActive_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVActive.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "group" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = "Total " + GVActive.GetRowCellValue(e.RowHandle, "group").ToString
            End Select
        End If

        If item.FieldName.ToString = "amount" Then
            Dim summary_id As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)

            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_amo_grp = 0.00
                tot_amo = 0.00
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim grp As String = GVActive.GetRowCellValue(e.RowHandle, "id_comp_group").ToString
                Dim due As String = DateTime.Parse(GVActive.GetRowCellValue(e.RowHandle, "due_date").ToString).ToString("yyyy-MM-dd")
                Dim amo As Double = 0.00

                If grp <> last_grp Or due <> last_due Then
                    last_grp = grp
                    last_due = due
                    amo = CDec(myCoalesce(GVActive.GetRowCellValue(e.RowHandle, "amount").ToString, "0.00"))
                Else
                    amo = 0.00
                End If

                Select Case summary_id
                    Case 1
                        tot_amo_grp += amo
                    Case 2
                        tot_amo += amo
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summary_id
                    Case 1 'total group
                        Dim sum_res As Double = 0.00

                        Try
                            sum_res = tot_amo_grp
                        Catch ex As Exception
                        End Try

                        e.TotalValue = Format(sum_res, "##,##0").ToString.Replace(",", ".")
                    Case 2 'total 
                        Dim sum_res As Double = 0.00

                        Try
                            sum_res = tot_amo
                        Catch ex As Exception
                        End Try

                        e.TotalValue = Format(sum_res, "##,##0").ToString.Replace(",", ".")
                End Select
            End If
        End If
    End Sub
End Class