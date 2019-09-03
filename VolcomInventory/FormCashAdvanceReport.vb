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
End Class