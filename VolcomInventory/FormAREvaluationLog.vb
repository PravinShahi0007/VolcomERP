Public Class FormAREvaluationLog
    Public eval_date As String = ""

    Private Sub FormAREvaluationLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT e.eval_date, e.log_time, e.log, IF(e.is_success=1,'Success', 'Failed') AS `log_status`
        FROM tb_ar_eval_log e WHERE e.eval_date='" + eval_date + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub FormAREvaluationLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class