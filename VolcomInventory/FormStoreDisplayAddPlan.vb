Public Class FormStoreDisplayAddPlan
    Public id_trans As String = "-1"
    Dim id_comp As String = "-1"

    Private Sub FormStoreDisplayAddPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_comp = execute_query("SELECT id_comp FROM tb_display_pps WHERE id_display_pps='" + id_trans + "' ", 0, True, "", "", "", "")

        viewSeason()
        actionLoad()
    End Sub

    Sub viewSeason()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_season`, 0 AS id_delivery, '- Select Season -' AS `season_del`
        UNION ALL
        SELECT dps.id_season, dps.id_delivery, CONCAT(ss.season, ' D', sd.delivery) AS `season_del`
        FROM tb_display_pps_season dps 
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = dps.id_delivery
        INNER JOIN tb_season ss ON ss.id_season = dps.id_season
        INNER JOIN tb_display_pps dp ON dp.id_display_pps = dps.id_display_pps
        WHERE dps.id_display_pps=" + id_trans + " AND sd.delivery_date > dp.in_store_date AND dps.id_season!=dp.id_season "
        viewSearchLookupQuery(SLESeason, query, "id_delivery", "season_del", "id_delivery")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        TxtQtySKU.EditValue = 0
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormStoreDisplayAddPlan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        GVData.ActiveFilterString = ""
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount <= 0 Then
            warningCustom("Please select class first")
        ElseIf TxtQtySKU.EditValue <= 0 Then
            warningCustom("Please input qty")
        Else
            Dim id_delivery As String = SLESeason.EditValue.ToString
            Dim id_season As String = SLESeason.Properties.View.GetFocusedRowCellValue("id_season").ToString
            Dim query As String = "INSERT INTO tb_display_pps_plan(id_display_pps, id_season, id_delivery, id_class_group, qty_sku) VALUES "
            For i As Integer = 0 To GVData.RowCount - 1
                Dim id_class_group As String = GVData.GetRowCellValue(i, "id_class_group").ToString
                Dim qty_sku As String = decimalSQL(TxtQtySKU.EditValue.ToString)
                If i > 0 Then
                    query += ","
                End If
                query += "('" + id_trans + "', '" + id_season + "', '" + id_delivery + "', '" + id_class_group + "', '" + qty_sku + "') "
            Next
            If GVData.RowCount > 0 Then
                execute_non_query(query, True, "", "", "", "")
            End If
            FormStoreDisplayDet.viewPlan()
            actionLoad()
            viewClassGroup()
        End If
        GVData.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        Dim id_del As String = "0"
        Try
            id_del = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try

        If id_del = "0" Then
            GCData.DataSource = Nothing
        Else
            viewClassGroup()
        End If
    End Sub

    Sub viewClassGroup()
        Cursor = Cursors.WaitCursor
        Dim id_del As String = "0"
        Try
            id_del = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT cg.id_class_group, cg.class_group, 'No' AS `is_select` 
        FROM tb_class_group cg 
        INNER JOIN (
            SELECT dm.id_class_group 
            FROM tb_display_master dm
            WHERE dm.id_comp=" + id_comp + " AND dm.is_active=1 AND dm.qty>0
            GROUP BY dm.id_class_group
        ) dm ON dm.id_class_group = cg.id_class_group
        LEFT JOIN tb_display_pps_plan dpp ON dpp.id_class_group = cg.id_class_group AND dpp.id_display_pps='" + id_trans + "' AND dpp.id_delivery='" + id_del + "'
        WHERE cg.is_active=1 AND ISNULL(dpp.id_class_group)
        ORDER BY cg.class_group ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class