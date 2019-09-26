Public Class FormCashAdvanceReport
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_ca()
    End Sub

    Private Sub FormCashAdvanceReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormCashAdvanceReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateFrom.EditValue = Now
        DateTo.EditValue = Now
    End Sub

    Sub load_ca()
        Dim date_from As String = ""
        Dim date_to As String = ""

        Try
            date_from = DateTime.Parse(DateFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            date_to = DateTime.Parse(DateTo.EditValue.ToString).ToString("yyyy-MM-dd")


            Dim where_string As String = ""

            Dim query As String = "CALL view_cash_advance_report('" & date_from & "','" & date_to & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCReport.DataSource = data
            GVReport.BestFitColumns()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        GridColumnDateCreated.Visible = False
        GridColumnStatus.Visible = False
        GridColumnReconcileDueDate.Visible = False
        GridColumnCashInAdvancePeriode.Visible = False
        GridColumnCashOnHandOut.Visible = False
        GridColumnAdvance.Visible = False
        GridColumnOverdue.Visible = False
        '
        GVReport.ActiveFilterString = "[expense]>0"
        '
        print(Me.GCReport, "Expense Report (" & DateTime.Parse(DateFrom.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & DateTime.Parse(DateTo.EditValue.ToString).ToString("dd MMMM yyyy") & ")")
        '
        GVReport.ActiveFilterString = ""
        '
        GridColumnNumber.VisibleIndex = 0
        GridColumnDateCreated.VisibleIndex = 1
        GridColumnEmployee.VisibleIndex = 2
        GridColumnPurpose.VisibleIndex = 3
        GridColumnStatus.VisibleIndex = 4
        GridColumnReconcileDueDate.VisibleIndex = 5
        GridColumnReconcileActualDate.VisibleIndex = 6
        GridColumnCashInAdvancePeriode.VisibleIndex = 7
        GridColumnCashInAdvance.VisibleIndex = 8
        GridColumnExpense.VisibleIndex = 9
        GridColumnAdvance.VisibleIndex = 10
        GridColumnCashOnHandOut.VisibleIndex = 11
        GridColumnOverdue.VisibleIndex = 12
    End Sub

    Private Sub BPrintAdvance_Click(sender As Object, e As EventArgs) Handles BPrintAdvance.Click
        GridColumnDateCreated.Visible = False
        GridColumnStatus.Visible = False
        GridColumnReconcileActualDate.Visible = False
        GridColumnCashInAdvancePeriode.Visible = False
        GridColumnCashInAdvance.Visible = False
        GridColumnExpense.Visible = False
        GridColumnCashOnHandOut.Visible = False
        '
        GVReport.ActiveFilterString = "[advance]>0"
        '
        print(Me.GCReport, "Advance Report (" & DateTime.Parse(DateFrom.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & DateTime.Parse(DateTo.EditValue.ToString).ToString("dd MMMM yyyy") & ")")
        '
        GVReport.ActiveFilterString = ""
        '
        GridColumnNumber.VisibleIndex = 0
        GridColumnDateCreated.VisibleIndex = 1
        GridColumnEmployee.VisibleIndex = 2
        GridColumnPurpose.VisibleIndex = 3
        GridColumnStatus.VisibleIndex = 4
        GridColumnReconcileDueDate.VisibleIndex = 5
        GridColumnReconcileActualDate.VisibleIndex = 6
        GridColumnCashInAdvancePeriode.VisibleIndex = 7
        GridColumnCashInAdvance.VisibleIndex = 8
        GridColumnExpense.VisibleIndex = 9
        GridColumnAdvance.VisibleIndex = 10
        GridColumnCashOnHandOut.VisibleIndex = 11
        GridColumnOverdue.VisibleIndex = 12
    End Sub
End Class