Public Class ReportFollowUpAR
    Public id_follow_up_recap As String = "0"

    Private Sub ReportFollowUpAR_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        XrLabelYear.Text = "Tahun " + execute_query("SELECT YEAR(follow_up_date) AS follow_up_date FROM tb_follow_up_recap WHERE id_follow_up_recap = " + id_follow_up_recap, 0, True, "", "", "", "")

        Dim fill As DataTable = execute_query("
            SELECT r.id_follow_up_recap, e.employee_name AS created_by, DATE_FORMAT(r.created_date, '%d %M %Y %H:%i:%s') AS created_date, DATE_FORMAT(r.follow_up_date, '%d %M %Y') AS follow_up_date, s.report_status
            FROM tb_follow_up_recap AS r
            LEFT JOIN tb_m_user AS u ON r.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee= e.id_employee
            LEFT JOIN tb_lookup_report_status AS s ON r.id_report_status = s.id_report_status
            WHERE r.id_follow_up_recap = " + id_follow_up_recap,
        -1, True, "", "", "", "")

        XrLabelReportStatus.Text = fill.Rows(0)("report_status").ToString
        XrLabelFollowUpDate.Text = fill.Rows(0)("follow_up_date").ToString
        XrLabelCreatedBy.Text = fill.Rows(0)("created_by").ToString
        XrLabelCreatedDate.Text = fill.Rows(0)("created_date").ToString

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

        'mark
        Dim id_pre As String = execute_query("SELECT IF(id_report_status = 6, -1, 1) AS id_pre FROM tb_follow_up_recap WHERE id_follow_up_recap = " + id_follow_up_recap, 0, True, "", "", "", "")

        If id_pre = "-1" Then
            load_mark_horz("234", id_follow_up_recap, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("234", id_follow_up_recap, "2", "2", XrTable1)
        End If

        'force align left
        For i = 0 To XrTable1.Rows.Count - 1
            For j = 0 To XrTable1.Rows.Item(i).Cells.Count - 1
                XrTable1.Rows.Item(i).Cells.Item(j).Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                XrTable1.Rows.Item(i).Cells.Item(j).TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Next
        Next
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