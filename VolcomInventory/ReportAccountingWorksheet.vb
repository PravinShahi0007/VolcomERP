Public Class ReportAccountingWorksheet
    Public data As DataTable = New DataTable
    Public id_is_det As String = "1"

    Private Sub ReportAccountingLedger_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'single group
        If id_is_det = "2" Then
            'GVAccountingWorksheet.Columns("acc_name").GroupIndex = 0
        Else
            'multi group
            'add column
            Dim last_g As Integer = Integer.Parse(data.Columns.Item(data.Columns.Count - 1).ColumnName.Replace("parent_group_", ""))

            For i = 0 To last_g
                Dim col As DevExpress.XtraGrid.Columns.GridColumn = GVAccountingWorksheet.Columns.Add()

                col.Caption = "Account"
                col.FieldName = "group_" + i.ToString
            Next

            'group index
            For i = last_g To 0 Step -1
                Dim group_i As String = "group_" + i.ToString

                GVAccountingWorksheet.Columns(group_i).GroupIndex = last_g - i
            Next
        End If

        GCAccountingWorksheet.DataSource = data

        GVAccountingWorksheet.BestFitColumns()
    End Sub

    Private Sub GVAccountingLedger_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVAccountingWorksheet.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "number" Then
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                e.TotalValue = "Sub Total" + GVAccountingWorksheet.GetGroupRowDisplayText(e.GroupRowHandle).Replace("Account", "")
            End If
        End If
    End Sub
End Class