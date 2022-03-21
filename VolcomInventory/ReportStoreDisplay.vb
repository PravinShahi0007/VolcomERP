Public Class ReportStoreDisplay
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = ""
    Public Shared is_pre As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportStoreDisplay_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCRencanaSKU.DataSource = dt
        GVRencanaSKU.BestFitColumns()

        If is_pre = "1" Then
            pre_load_mark_horz_pd(rmt, id, "2", "2", XrTable1)
        Else
            load_mark_horz(rmt, id, "2", "1", XrTable1)
        End If

        'sattus
        If id_report_status = "6" Then
            LabelTitleApprovedDate.Visible = True
            LabelDotApprovedDate.Visible = True
            LabelApprovedDate.Visible = True
        End If

        'printed date & approved date
        Dim qpd As String = "SELECT UPPER(DATE_FORMAT(rm.report_mark_datetime, '%d %M %Y')) AS `approved_date`, DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date` 
        FROM tb_report_mark rm 
        WHERE rm.id_report=" + id + " AND rm.report_mark_type=" + rmt + " AND rm.id_mark=2
        ORDER BY rm.id_report_mark DESC LIMIT 1 "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub

    Dim footgroup_cat As String = ""
    Dim footgroup_div As String = ""
    Private Sub GVRencanaSKU_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVRencanaSKU.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            footgroup_cat = ""
            footgroup_div = ""
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cat As String = View.GetRowCellValue(e.RowHandle, "GROUP INFO|CATEGORY").ToString
            Dim division As String = View.GetRowCellValue(e.RowHandle, "GROUP INFO|DIVISION").ToString
            Select Case summaryID
                Case "footgroup"
                    footgroup_cat = cat
                    footgroup_div = division
            End Select
        End If


        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "foot" 'total summary estimate
                    e.TotalValue = "TOTAL"
                Case "footgroup" 'group summary  cat
                    If e.GroupLevel.ToString = "1" Then
                        e.TotalValue = "SUB TOTAL " + footgroup_div.ToUpper + " " + footgroup_cat.ToUpper
                    Else
                        e.TotalValue = "SUB TOTAL " + footgroup_div.ToUpper
                    End If
            End Select
        End If
    End Sub
End Class