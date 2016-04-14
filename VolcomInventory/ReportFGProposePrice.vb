Public Class ReportFGProposePrice
    Public Shared dt As New DataTable
    Public Shared id_fg_propose_price As String = "-1"
    Public Shared is_import As Boolean = False


    Private Sub ReportFGProposePrice_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
        load_mark_horz("70", id_fg_propose_price, "2", "1", XrTable1)
    End Sub
    'CUSTOM SUMMARY IMPORT
    Dim custom_sum_final_price As Decimal
    Dim custom_sum_cop_pd As Decimal
    Dim custom_sum_cop_act_rate As Decimal
    Dim custom_sum_cop_rate_app As Decimal
    Dim custom_sum_markup_act_rate_prc As Decimal
    Dim custom_sum_markup_act_rate_cop As Decimal
    Dim custom_sum_markup_rate_app_prc As Decimal
    Dim custom_sum_markup_rate_app_cop As Decimal

    'CUSTOM SUMMARY LOCAL
    Dim custom_sum_final_price_loc As Decimal
    Dim custom_sum_cop_act_rate_loc As Decimal
    Dim custom_sum_markup_act_rate_prc_loc As Decimal
    Dim custom_sum_markup_act_rate_cop_loc As Decimal
    Private Sub GridView1_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        If is_import Then
            ' Get the summary ID. 
            Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                custom_sum_final_price = 0
                custom_sum_cop_pd = 0
                custom_sum_cop_act_rate = 0
                custom_sum_cop_rate_app = 0
                custom_sum_markup_act_rate_prc = 0
                custom_sum_markup_act_rate_cop = 0
                custom_sum_markup_rate_app_prc = 0
                custom_sum_markup_rate_app_cop = 0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim qty As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "fg_propose_price_det_qty").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "price_final"), "0.00"))
                Dim cop_pd As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_pd"), "0.00"))
                Dim cop_act_rate As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_bom"), "0.0"))
                Dim cop_rate_app As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_management"), "0.0"))
                Select Case summaryID
                    Case 1
                        custom_sum_final_price += prc * qty
                    Case 2
                        custom_sum_cop_pd += cop_pd * qty
                    Case 3
                        custom_sum_cop_act_rate += cop_act_rate * qty
                    Case 4
                        custom_sum_cop_rate_app += cop_rate_app * qty
                    Case 5
                        custom_sum_markup_act_rate_prc += prc * qty
                        custom_sum_markup_act_rate_cop += cop_act_rate * qty
                    Case 6
                        custom_sum_markup_rate_app_prc = prc * qty
                        custom_sum_markup_rate_app_cop = cop_rate_app * qty
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 1
                        e.TotalValue = custom_sum_final_price
                    Case 2
                        e.TotalValue = custom_sum_cop_pd
                    Case 3
                        e.TotalValue = custom_sum_cop_act_rate
                    Case 4
                        e.TotalValue = custom_sum_cop_rate_app
                    Case 5
                        Dim res_mk_act = 0.0
                        Try
                            res_mk_act = custom_sum_markup_act_rate_prc / custom_sum_markup_act_rate_cop
                        Catch ex As Exception
                        End Try
                        e.TotalValue = res_mk_act
                    Case 6
                        Dim res_mk_app = 0.0
                        Try
                            res_mk_app = custom_sum_markup_rate_app_prc / custom_sum_markup_rate_app_cop
                        Catch ex As Exception
                        End Try
                        e.TotalValue = res_mk_app
                End Select
            End If
        Else
            ' Get the summary ID. 
            Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                custom_sum_final_price_loc = 0
                custom_sum_cop_act_rate_loc = 0
                custom_sum_markup_act_rate_prc_loc = 0
                custom_sum_markup_act_rate_cop_loc = 0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim qty As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "fg_propose_price_det_qty").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "price_final"), "0.00"))
                Dim cop_act_rate As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_bom"), "0.0"))
                Dim cop_rate_app As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_management"), "0.0"))
                Select Case summaryID
                    Case 1
                        custom_sum_final_price_loc += prc * qty
                    Case 2
                        custom_sum_cop_act_rate_loc += cop_act_rate * qty
                    Case 3
                        custom_sum_markup_act_rate_prc_loc += prc * qty
                        custom_sum_markup_act_rate_cop_loc += cop_act_rate * qty
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 1
                        e.TotalValue = custom_sum_final_price_loc
                    Case 2
                        e.TotalValue = custom_sum_cop_act_rate_loc
                    Case 3
                        Dim res_mk_act = 0.0
                        Try
                            res_mk_act = custom_sum_markup_act_rate_prc_loc / custom_sum_markup_act_rate_cop_loc
                        Catch ex As Exception
                        End Try
                        e.TotalValue = res_mk_act
                End Select
            End If
        End If
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class