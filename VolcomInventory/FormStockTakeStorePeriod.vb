Public Class FormStockTakeStorePeriod
    Private Sub FormStockTakeStorePeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Private Sub FormStockTakeStorePeriod_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormStockTakeStorePeriod_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormStockTakeStorePeriod_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub load_form()
        Dim query As String = "
            SELECT DATE_FORMAT(p.soh_date, '%d %M %Y') AS soh_date, s.store_name, DATE_FORMAT(p.schedule_start, '%d %M %Y') AS schedule_start, DATE_FORMAT(p.schedule_end, '%d %M %Y') AS schedule_end
            FROM tb_st_store_period AS p
            LEFT JOIN tb_m_store AS s ON p.id_store = s.id_store
            ORDER BY p.id_st_store_period DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCPeriod.DataSource = data

        GVPeriod.BestFitColumns()
    End Sub
End Class