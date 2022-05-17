Public Class FormDropChangesMoveHistory
    Public id_design As String = "-1"
    Public id_exclude As String = "-1"

    Private Sub FormDropChangesMoveHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dh.id_drop_changes, dh.`number`, 
        CONCAT(sf.season, ' D', df.delivery) AS `season_del_from`,
        CONCAT(st.season, ' D', dt.delivery) AS `season_del_to`
        FROM tb_m_design d
        INNER JOIN tb_drop_changes_det dd ON dd.id_design = d.id_design
        INNER JOIN tb_drop_changes dh ON dh.id_drop_changes = dd.id_drop_changes AND dh.id_report_status=6
        INNER JOIN tb_season_delivery df ON df.id_delivery = dd.id_delivery_from
        INNER JOIN tb_season sf ON sf.id_season = dd.id_season_from
        INNER JOIN tb_season_delivery dt ON dt.id_delivery = dd.id_delivery_to
        INNER JOIN tb_season st ON st.id_season = dd.id_season_to
        WHERE d.id_design=" + id_design + " "
        If id_exclude <> "-1" Then
            query += "AND dh.id_drop_changes!='" + id_exclude + "' "
        End If
        query += "ORDER BY dh.created_date DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDropChangesMoveHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class