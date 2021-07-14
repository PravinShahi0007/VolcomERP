Public Class FormStockTakePartial
    Private Sub FormStockTakePartial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormStockTakePartial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT s.id_st_store_partial, s.number, s.note, r.report_status, e.employee_name AS created_by, DATE_FORMAT(created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_st_store_partial AS s
            LEFT JOIN tb_lookup_report_status AS r ON r.id_report_status = s.id_report_status
            LEFT JOIN tb_m_user AS u ON s.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            ORDER BY s.id_st_store_partial DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub FormStockTakePartial_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormStockTakePartial_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class