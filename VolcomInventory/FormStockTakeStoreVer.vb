Public Class FormStockTakeStoreVer
    Private Sub FormStockTakeStoreVer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormStockTakeStoreVer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBNew_Click(sender As Object, e As EventArgs) Handles SBNew.Click
        FormStockTakeStoreVerCrt.ShowDialog()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT b.id_st_store_bap, b.number, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, DATE_FORMAT(b.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, r.report_status
            FROM tb_st_store_bap AS b
            LEFT JOIN tb_m_comp AS c ON b.id_comp = c.id_comp
            LEFT JOIN tb_m_user AS u ON b.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON b.id_report_status = r.id_report_status
            WHERE b.id_st_store_period = " + FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + "
            ORDER BY b.id_st_store_bap DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormStockTakeStoreVerDet.id_st_store_bap = GVData.GetFocusedRowCellValue("id_st_store_bap").ToString
        FormStockTakeStoreVerDet.ShowDialog()
    End Sub
End Class