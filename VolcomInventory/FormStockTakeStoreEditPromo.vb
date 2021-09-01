Public Class FormStockTakeStoreEditPromo
    Private Sub FormStockTakeStoreEditPromo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPrice.EditValue = FormStockTakeStoreVerDet.BGVData.GetFocusedRowCellValue("price")
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim query As String = "
            UPDATE tb_st_store_bap_det SET price = " + decimalSQL(TEPrice.EditValue.ToString) + ", is_edited_price = 1 WHERE id_st_store_bap = " + FormStockTakeStoreVerDet.id_st_store_bap + " AND id_product = " + FormStockTakeStoreVerDet.BGVData.GetFocusedRowCellValue("id_product").ToString + "
        "

        execute_non_query(query, True, "", "", "", "")

        Dim i As Integer = FormStockTakeStoreVerDet.BGVData.FocusedRowHandle

        FormStockTakeStoreVerDet.form_load()

        FormStockTakeStoreVerDet.BGVData.FocusedRowHandle = i

        Close()
    End Sub
End Class