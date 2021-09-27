Public Class FormStockTakeStorePeriodStore
    Private Sub FormStockTakeStorePeriodStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query_surat As String = "
            SELECT -1 AS id_st_store_propose, NULL AS number, NULL AS period, NULL AS comp_group, NULL AS id_store, NULL AS period_start, NULL AS period_end
            UNION ALL
            SELECT h.id_st_store_propose, h.number, CONCAT(DATE_FORMAT(d.period_start, '%d %M %Y %H:%i:%s'), ' - ', DATE_FORMAT(d.period_end, '%d %M %Y %H:%i:%s')) period, CONCAT(g.comp_group, ' - ', g.description) AS comp_group, GROUP_CONCAT(d.id_store) AS id_store, d.period_start, d.period_end
            FROM tb_st_store_propose_det AS d
            LEFT JOIN tb_st_store_propose AS h ON d.id_st_store_propose = h.id_st_store_propose
            LEFT JOIN tb_m_comp_group AS g ON h.id_comp_group = g.id_comp_group
            GROUP BY h.id_st_store_propose, d.period_start, d.period_end
        "

        Dim data_surat As DataTable = execute_query(query_surat, -1, True, "", "", "", "")

        GCSurat.DataSource = data_surat

        GVSurat.BestFitColumns()

        If Not FormStockTakeStorePeriodDet.id_st_store_propose = "-1" Then
            Dim i_row_handle As Integer = 0

            For i = 0 To GVSurat.RowCount - 1
                Try
                    If GVSurat.GetRowCellValue(i, "id_st_store_propose").ToString = FormStockTakeStorePeriodDet.id_st_store_propose And GVSurat.GetRowCellValue(i, "period_start") = FormStockTakeStorePeriodDet.period_start And GVSurat.GetRowCellValue(i, "period_end") = FormStockTakeStorePeriodDet.period_end Then
                        i_row_handle = i
                    End If
                Catch ex As Exception
                End Try
            Next

            GVSurat.FocusedRowHandle = i_row_handle
        End If

        select_store()

        If FormStockTakeStorePeriodDet.id_store.Count > 0 Then
            For i = 0 To GVData.RowCount - 1
                GVData.SetRowCellValue(i, "is_select", "no")
            Next

            For i = 0 To FormStockTakeStorePeriodDet.id_store.Count - 1
                For j = 0 To GVData.RowCount - 1
                    If FormStockTakeStorePeriodDet.id_store(i).ToString = GVData.GetRowCellValue(j, "id_store").ToString Then
                        GVData.SetRowCellValue(j, "is_select", "yes")
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub FormStockTakeStorePeriodStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormStockTakeStorePeriodDet.view_user()
        'FormStockTakeStorePeriodDet.min_start_date()

        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBSelect.Click
        GVData.FindFilterText = ""
        GVData.ClearColumnsFilter()
        GVData.ActiveFilterString = "[is_select] = 'yes'"

        FormStockTakeStorePeriodDet.id_store.Clear()

        For i = 0 To GVData.RowCount - 1
            If GVData.IsValidRowHandle(i) Then
                FormStockTakeStorePeriodDet.id_store.Add(GVData.GetRowCellValue(i, "id_store").ToString)
            End If
        Next

        FormStockTakeStorePeriodDet.id_st_store_propose = GVSurat.GetFocusedRowCellValue("id_st_store_propose").ToString

        Try
            FormStockTakeStorePeriodDet.period_start = GVSurat.GetFocusedRowCellValue("period_start")
            FormStockTakeStorePeriodDet.period_end = GVSurat.GetFocusedRowCellValue("period_end")
        Catch ex As Exception
        End Try

        FormStockTakeStorePeriodDet.DEStart.EditValue = GVSurat.GetFocusedRowCellValue("period_start").ToString
        FormStockTakeStorePeriodDet.DEEnd.EditValue = GVSurat.GetFocusedRowCellValue("period_end").ToString

        Close()
    End Sub

    Private Sub GVSurat_Click(sender As Object, e As EventArgs) Handles GVSurat.Click
        select_store()
    End Sub

    Sub select_store()
        Dim in_store As String = GVSurat.GetFocusedRowCellValue("id_store").ToString

        Dim is_select As String = "yes"
        Dim where_id_store As String = "WHERE id_store IN (" + in_store + ")"

        If GVSurat.GetFocusedRowCellValue("id_st_store_propose").ToString = "-1" Then
            is_select = "no"
            where_id_store = ""
        End If

        Dim query As String = "
            SELECT '" + is_select + "' AS is_select, id_store, store_name
            FROM tb_m_store
            " + where_id_store + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub
End Class