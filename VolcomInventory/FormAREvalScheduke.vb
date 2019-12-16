Public Class FormAREvalScheduke
    Private Sub FormAREvalScheduke_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewYear()
    End Sub

    Private Sub FormAREvalScheduke_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAREvalScheduke_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAREvalScheduke_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cond_year As String = "AND YEAR(e.ar_eval_setup_date)='" + LEYear.EditValue.ToString + "' "
        Dim query As String = "SELECT e.id_ar_eval_setup_date,
        DATE_FORMAT(e.ar_eval_setup_date, '%W') AS `day_name`,
        MONTH(e.ar_eval_setup_date) AS `mth`,DATE_FORMAT(e.ar_eval_setup_date, '%M') AS `mth_name`,
        e.ar_eval_setup_date 
        FROM tb_ar_eval_setup_date e
        WHERE 1=1 " + cond_year + "
        ORDER BY e.ar_eval_setup_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewYear()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT YEAR(e.ar_eval_setup_date) AS `year` 
        FROM tb_ar_eval_setup_date e GROUP BY YEAR(e.ar_eval_setup_date) 
        ORDER BY YEAR(e.ar_eval_setup_date) DESC "
        viewLookupQuery(LEYear, query, 0, "year", "year")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Private Sub LEYear_EditValueChanged(sender As Object, e As EventArgs) Handles LEYear.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class