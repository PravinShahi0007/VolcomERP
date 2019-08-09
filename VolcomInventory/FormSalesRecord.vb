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
        SELECT d.id_departement AS `id_outlet`, d.departement AS `outlet`
        FROM tb_m_departement d 
        INNER JOIN tb_store_conn sc ON sc.id_outlet = d.id_departement
        WHERE d.is_store=1
        ORDER BY id_outlet ASC "
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
        'sal.syncOutlet()
        SplashScreenManager1.CloseWaitForm()
    End Sub
End Class