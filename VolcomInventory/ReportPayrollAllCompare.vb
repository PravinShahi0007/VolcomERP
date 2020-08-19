Public Class ReportPayrollAllCompare
    Public id_pre As String
    Public id_payroll As String = ""
    Public type As String = ""
    Public dt_office As DataTable = New DataTable
    Public dt_store As DataTable = New DataTable

    Private Sub ReportPayrollAllCompare_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPayrollOffice.DataSource = dt_office
        GCPayrollStore.DataSource = dt_store

        GVPayrollOffice.Columns("employee_name").SummaryItem.DisplayFormat = "Grand Total: " + XLLocationOffice.Text.ToUpper
        GVPayrollStore.Columns("employee_name").SummaryItem.DisplayFormat = "Grand Total: " + XLLocationStore.Text.ToUpper

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

    'office
    Private Sub GVPayrollOffice_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPayrollOffice.CustomColumnDisplayText
        If e.IsForGroupRow Then
            'sogo
            If e.DisplayText.ToString.Contains("SOGO") Then
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = "Sub Departement: " + e.DisplayText
                End If
            Else
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = ""
                End If
            End If
        End If
    End Sub

    'store
    Private Sub GVPayrollStore_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPayrollStore.CustomColumnDisplayText
        If e.IsForGroupRow Then
            'sogo
            If e.DisplayText.ToString.Contains("SOGO") Then
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = "Sub Departement: " + e.DisplayText
                End If
            Else
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = ""
                End If
            End If
        End If
    End Sub

    Private Sub GVPayrollOffice_RowCountChanged(sender As Object, e As EventArgs) Handles GVPayrollOffice.RowCountChanged
        Dim j As Integer = 0

        For i = 0 To GVPayrollOffice.RowCount - 1
            If GVPayrollOffice.IsValidRowHandle(i) Then
                j = j + 1

                GVPayrollOffice.SetRowCellValue(i, "no", j)
            End If
        Next
    End Sub

    Private Sub GVPayrollStore_RowCountChanged(sender As Object, e As EventArgs) Handles GVPayrollStore.RowCountChanged
        Dim j As Integer = 0

        For i = 0 To GVPayrollStore.RowCount - 1
            If GVPayrollStore.IsValidRowHandle(i) Then
                j = j + 1

                GVPayrollStore.SetRowCellValue(i, "no", j)
            End If
        Next
    End Sub

    Private Sub GVPayrollOffice_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVPayrollOffice.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "employee_name" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(GVPayrollOffice.GetRowCellValue(e.RowHandle, "departement").ToString, "\(([A-Z])\)", "").ToString()
                    Dim alphabet As String = GVPayrollOffice.GetRowCellValue(e.RowHandle, "departement").ToString.Replace(curr_departement, "")

                    Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(GVPayrollOffice.GetRowCellValue(e.RowHandle, "departement_sub").ToString, "\(([A-Z][0-9])\)", "").ToString()
                    Dim alphabet_sub As String = GVPayrollOffice.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Replace(curr_departement_sub, "")

                    If GVPayrollOffice.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If e.GroupLevel = 1 Then
                            e.TotalValue = "Total: " + alphabet_sub.Replace("(", "").Replace(")", "")
                        Else
                            e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub GVPayrollStore_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVPayrollStore.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "employee_name" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(GVPayrollStore.GetRowCellValue(e.RowHandle, "departement").ToString, "\(([A-Z])\)", "").ToString()
                    Dim alphabet As String = GVPayrollStore.GetRowCellValue(e.RowHandle, "departement").ToString.Replace(curr_departement, "")

                    Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(GVPayrollStore.GetRowCellValue(e.RowHandle, "departement_sub").ToString, "\(([A-Z][0-9])\)", "").ToString()
                    Dim alphabet_sub As String = GVPayrollStore.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Replace(curr_departement_sub, "")

                    If GVPayrollStore.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If e.GroupLevel = 1 Then
                            e.TotalValue = "Total: " + alphabet_sub.Replace("(", "").Replace(")", "")
                        Else
                            e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                        End If
                    End If
            End Select
        End If
    End Sub
End Class