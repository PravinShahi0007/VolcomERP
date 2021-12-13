Public Class FormMKDEvent
    Private Sub FormMKDEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewOption()
    End Sub

    Private Sub FormMKDEvent_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMKDEvent_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub ViewOption()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `eos_day`, 'All' AS `note`
        UNION ALL
        SELECT r.eos_day, r.note 
        FROM tb_eos_reminder r
        ORDER BY eos_day ASC "
        viewSearchLookupQuery(SLEOption, query, "eos_day", "note", "eos_day")
        SLEOption.EditValue = 0
        Cursor = Cursors.Default
    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_pp_change, p.number, 
        DATE_FORMAT(p.effective_date,'%d-%m-%Y') AS `start_date`, 
        DATE_FORMAT(p.plan_end_date,'%d-%m-%Y') AS `end_date`, 
        p.note, datediff(DATE(NOW()), p.plan_end_date) AS `count_day`, o.eos_body_mail1, o.eos_body_mail2
        FROM tb_pp_change p 
        JOIN tb_opt o
        WHERE p.id_report_status=6 AND p.id_design_mkd=1 AND p.plan_end_date>=NOW()
        GROUP BY p.id_pp_change 
        HAVING 1=1 "
        'cond
        If SLEOption.EditValue.ToString <> "0" Then
            query += "AND count_day IN (" + SLEOption.EditValue.ToString + ") "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewList()
    End Sub
End Class