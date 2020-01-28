Public Class FormPurcAssetHistory
    Public id_purc_rec_asset As String = "-1"

    Private Sub FormPurcAssetHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT e.employee_name, d.departement, h.location, h.location_date
            FROM tb_purc_rec_asset_history AS h
            LEFT JOIN tb_m_employee AS e ON h.id_employee = e.id_employee
            LEFT JOIN tb_m_departement AS d ON h.id_departement = d.id_departement
            WHERE h.id_purc_rec_asset = " + id_purc_rec_asset + "
            ORDER BY h.location_date DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCHistory.DataSource = data

        GVHistory.BestFitColumns()
    End Sub

    Private Sub FormPurcAssetHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class