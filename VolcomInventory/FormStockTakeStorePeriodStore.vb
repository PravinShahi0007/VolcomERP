Public Class FormStockTakeStorePeriodStore
    Private Sub FormStockTakeStorePeriodStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT 'no' AS is_select, id_store, store_name
            FROM tb_m_store
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            For j = 0 To FormStockTakeStorePeriodDet.id_store.Count - 1
                If data.Rows(i)("id_store").ToString = FormStockTakeStorePeriodDet.id_store(j).ToString Then
                    data.Rows(i)("is_select") = "yes"
                End If
            Next
        Next

        GCData.DataSource = data

        GVData.BestFitColumns()
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

        Close()
    End Sub
End Class