Public Class ReportAccountingLedger
    Public data As DataTable = New DataTable

    Private Sub ReportAccountingLedger_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'add column
        Dim last_g As Integer = Integer.Parse(data.Columns.Item(data.Columns.Count - 1).ColumnName.Replace("parent_group_", ""))

        For i = 0 To last_g
            Dim col As DevExpress.XtraGrid.Columns.GridColumn = GVAccountingLedger.Columns.Add()

            col.Caption = "Account"
            col.FieldName = "group_" + i.ToString
        Next

        'group index
        For i = last_g To 0 Step -1
            Dim group_i As String = "group_" + i.ToString

            GVAccountingLedger.Columns(group_i).GroupIndex = last_g - i
        Next

        GVAccountingLedger.Columns("acc_name").GroupIndex = last_g + 1

        GCAccountingLedger.DataSource = data

        GVAccountingLedger.BestFitColumns()
    End Sub

    Private Sub GVAccountingLedger_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVAccountingLedger.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "number" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                e.TotalValue = "Sub Total" + GVAccountingLedger.GetGroupRowDisplayText(e.GroupRowHandle).Replace("Account", "")
            End If
        End If
    End Sub
End Class