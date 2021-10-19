Public Class FormStockTakePropose
    Private Sub FormStockTakePropose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Private Sub FormStockTakePropose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_form()
        Dim query As String = "
            SELECT p.id_st_store_propose, p.number, DATE_FORMAT(p.start_period, '%d %M %Y') AS start_period, DATE_FORMAT(p.end_period, '%d %M %Y') AS end_period, CONCAT(g.comp_group, ' - ', g.description) AS comp_group, DATE_FORMAT(p.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, s.report_status
            FROM tb_st_store_propose AS p
            LEFT JOIN tb_m_comp_group AS g ON p.id_comp_group = g.id_comp_group
            LEFT JOIN tb_m_user AS u ON p.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            LEFT JOIN tb_lookup_report_status AS s ON p.id_report_status = s.id_report_status
            ORDER BY p.created_at DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormStockTakeProposeDet.id_st_store_propose = GVData.GetFocusedRowCellValue("id_st_store_propose").ToString
        FormStockTakeProposeDet.ShowDialog()
    End Sub

    Private Sub FormStockTakePropose_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormStockTakePropose_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class