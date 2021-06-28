Public Class FormStockTakeStorePeriodAccount
    Private Sub FormStockTakeStorePeriodAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS comp_name
            FROM tb_m_comp
            WHERE id_comp IN (SELECT id_comp FROM tb_st_store_soh WHERE id_st_store_period = " + FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + ")
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCAccount.DataSource = data

        GVAccount.BestFitColumns()
    End Sub

    Private Sub FormStockTakeStorePeriodAccount_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormStockTakeStorePeriod.BGVCompare.ActiveFilterString = ""

        Dispose()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim id_period As String = FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString

        For i = 0 To FormStockTakeStorePeriod.BGVCompare.RowCount - 1
            If FormStockTakeStorePeriod.BGVCompare.IsValidRowHandle(i) Then
                Dim id_product As String = FormStockTakeStorePeriod.BGVCompare.GetRowCellValue(i, "id_product").ToString
                Dim id_comp As String = GVAccount.GetFocusedRowCellValue("id_comp").ToString
                Dim is_auto As String = "2"

                Dim query As String = "UPDATE tb_st_store SET id_comp = " + id_comp + ", is_auto = " + is_auto + " WHERE id_st_store_period = " + id_period + " AND id_product = " + id_product

                execute_non_query(query, True, "", "", "", "")
            End If
        Next

        Close()

        FormStockTakeStorePeriod.view_compare()
    End Sub
End Class