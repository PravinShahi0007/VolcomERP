Public Class FormFGWHAllocLog
    Private Sub FormFGWHAllocLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGWHAllocLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()

        'date now
        Dim query As String = "SELECT DATE(NOW()) AS `date_now` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("date_now")
        DEUntil.EditValue = data.Rows(0)("date_now")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT ('0') AS id_report_status, ('All Status') AS report_status UNION ALL "
        query += "SELECT id_report_status, report_status FROM tb_lookup_report_status WHERE id_report_status<>5 AND id_report_status<>7 ORDER BY id_report_status ASC "
        viewSearchLookupQuery(SLEStatusRec, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewLog()
    End Sub

    Sub viewLog()
        Cursor = Cursors.WaitCursor
        Dim cond_par As String = "-1"
        'status
        If SLEStatusRec.EditValue.ToString <> "0" Then
            cond_par = "AND alloc.id_report_status=" + SLEStatusRec.EditValue.ToString + " "
        Else
            cond_par = ""
        End If

        'Prepare date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        cond_par += "AND (pp.report_mark_datetime>=''" + date_from_selected + "'' AND pp.report_mark_datetime<=''" + date_until_selected + "'') "

        Dim query As String = "CALL view_fg_wh_alloc_log('" + cond_par + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGWHAlloc.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            SLEStatusRec.Focus()
            SLEStatusRec.ShowPopup()
        End If
    End Sub

    Private Sub SLE_KeyDown(sender As Object, e As KeyEventArgs) Handles SLEStatusRec.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewLog()
        End If
    End Sub

    Private Sub FormFGWHAllocLog_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGWHAllocLog_DeadActivated(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class