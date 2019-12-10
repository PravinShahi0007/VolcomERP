Public Class FormSalesRecord
    Private Sub FormSalesRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewOutlet()
        Dim dt As DateTime = getTimeDB()
        DEFrom.EditValue = dt
        DEUntil.EditValue = dt
    End Sub

    Sub viewOutlet()
        Dim query As String = "SELECT 0 AS `id_outlet`, 'All Outlet' AS `outlet`
        UNION
        SELECT sc.`id_outlet`, sc.outlet_name AS `outlet`
        FROM tb_store_conn sc ORDER BY id_outlet ASC "
        viewSearchLookupQuery(SLEOutlet, query, "id_outlet", "outlet", "id_outlet")
    End Sub

    Private Sub FormSalesRecord_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesRecord_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesRecord_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnGetData_Click(sender As Object, e As EventArgs) Handles BtnGetData.Click
        SplashScreenManager1.ShowWaitForm()
        Dim sal As New ClassSalesPOS
        sal.splash = SplashScreenManager1
        Dim query As String = "SELECT sc.id_store_conn, sc.id_outlet, sc.outlet_name AS `outlet`, sc.host, sc.username, sc.pass, sc.db 
        FROM tb_store_conn sc "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            sal.syncOutlet(data.Rows(i)("id_outlet").ToString, data.Rows(i)("outlet").ToString, data.Rows(i)("host").ToString, data.Rows(i)("username").ToString, data.Rows(i)("pass").ToString, data.Rows(i)("db").ToString)
        Next
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BtnViewData_Click(sender As Object, e As EventArgs) Handles BtnViewData.Click
        viewSales()
    End Sub

    Sub viewSales()
        Cursor = Cursors.WaitCursor
        Dim date_from As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim outlet As String = ""
        If SLEOutlet.EditValue.ToString <> "0" Then
            outlet = "AND pc.id_outlet='" + SLEOutlet.EditValue.ToString + "' "
        End If
        Dim cond As String = outlet + "AND (DATE(pc.pos_date)>='" + date_from + "' AND DATE(pc.pos_date)<='" + date_until + "') "
        Dim p As New ClassSalesPOS()
        Dim query As String = p.querySalesRecord(cond, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormSalesRecordDet.id = GVData.GetFocusedRowCellValue("id_pos_combine").ToString
            FormSalesRecordDet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub
End Class