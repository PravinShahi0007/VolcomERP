Public Class ReportProposePriceMKD
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = ""
    Public Shared is_pre As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportProposePriceMKD_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt
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

    Dim tot_sal As Decimal
    Dim tot_bos As Decimal
    Dim tot_sal_grp As Decimal
    Dim tot_bos_grp As Decimal
    Dim tot_price As Decimal
    Dim tot_cost As Decimal
    Dim tot_price_grp As Decimal
    Dim tot_cost_grp As Decimal
    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_sal = 0.0
            tot_bos = 0.0
            tot_sal_grp = 0.0
            tot_bos_grp = 0.0

            tot_price = 0.0
            tot_cost = 0.0
            tot_price_grp = 0.0
            tot_cost_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim sal As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_sal").ToString, "0.00"))
            Dim bos As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_bos").ToString, "0.00"))
            Dim price As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_propose_value").ToString, "0.00"))
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "total_cost").ToString, "0.00"))
            Select Case summaryID
                Case "sas_sum"
                    tot_sal += sal
                    tot_bos += bos
                Case "sas_grp_sum"
                    tot_sal_grp += sal
                    tot_bos_grp += bos
                Case "markup_sum"
                    tot_price += price
                    tot_cost += cost
                Case "markup_grp_sum"
                    tot_price_grp += price
                    tot_cost_grp += cost
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "sas_sum" 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_sal / tot_bos) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "sas_grp_sum" 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_sal_grp / tot_bos_grp) * 100
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "markup_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_price / tot_cost)
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "markup_grp_sum"
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = (tot_price_grp / tot_cost_grp)
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "class_sum"
                    e.TotalValue = GVData.GetGroupRowValue(e.RowHandle).ToString + " Total"
            End Select
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class