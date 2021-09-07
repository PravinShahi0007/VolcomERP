﻿Public Class ReportProductionFinalClearSummary
    Public id As String = "0"
    Public data As DataTable = New DataTable
    Public id_pre As String = "-1"

    Private Sub ReportProductionFinalClearSummary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSummary.DataSource = data

        GVSummary.Columns("qty_po").Caption = GVSummary.Columns("qty_po").Caption.Replace(" ", Environment.NewLine)
        GVSummary.Columns("qty_rec").Caption = GVSummary.Columns("qty_rec").Caption.Replace(" ", Environment.NewLine)
        GVSummary.Columns("total_reject").Caption = GVSummary.Columns("total_reject").Caption.Replace(" ", Environment.NewLine)
        GVSummary.Columns("persentase_reject").Caption = GVSummary.Columns("persentase_reject").Caption.Replace(" ", Environment.NewLine)
        GVSummary.Columns("prod_fc_date").Caption = GVSummary.Columns("prod_fc_date").Caption.Replace(" ", Environment.NewLine)

        GVSummary.BestFitColumns()

        If id_pre = "-1" Then
            load_mark_horz("222", id, "2", "1", XrTable)
        Else
            pre_load_mark_horz("222", id, "2", "2", XrTable)
        End If

        'force align left
        For i = 0 To XrTable.Rows.Count - 1
            For j = 0 To XrTable.Rows.Item(i).Cells.Count - 1
                XrTable.Rows.Item(i).Cells.Item(j).Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                XrTable.Rows.Item(i).Cells.Item(j).TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Next
        Next
    End Sub

    Private Sub GVSummary_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSummary.RowCellStyle
        Try
            If GVSummary.GetRowCellValue(e.RowHandle, "prod_fc_date").ToString.Contains("Cancel") Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVSummary_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVSummary.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "persentase_reject" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim percentage As Decimal = 0.00

                    Try
                        If e.IsGroupSummary Then
                            percentage = e.GetGroupSummary(e.GroupRowHandle, GVSummary.GroupSummary.Item(6)) / e.GetGroupSummary(e.GroupRowHandle, GVSummary.GroupSummary.Item(5)) * 100

                            e.TotalValue = Decimal.Round(percentage, 2)
                        ElseIf e.IsTotalSummary Then
                            percentage = GVSummary.Columns("total_reject").SummaryItem.SummaryValue / GVSummary.Columns("qty_rec").SummaryItem.SummaryValue * 100

                            e.TotalValue = Decimal.Round(percentage, 2)
                        End If
                    Catch ex As Exception
                    End Try
            End Select
        End If
    End Sub
End Class