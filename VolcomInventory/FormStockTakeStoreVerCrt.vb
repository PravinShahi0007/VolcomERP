Public Class FormStockTakeStoreVerCrt
    Private Sub FormStockTakeStoreVerCrt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name
            FROM tb_m_comp AS c
            WHERE c.id_comp IN (SELECT id_comp FROM tb_st_store_soh WHERE id_st_store_period = " + FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + ")
        "

        viewSearchLookupQuery(SLUEAccount, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SBNew_Click(sender As Object, e As EventArgs) Handles SBNew.Click
        Dim count_created As String = execute_query("
            SELECT COUNT(*) 
            FROM tb_st_store_bap 
            WHERE id_st_store_period = " + FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + " AND id_report_status <> 5 AND id_comp = " + SLUEAccount.EditValue.ToString + "
        ", 0, True, "", "", "", "")

        If count_created = "0" Then
            Dim query_head As String = "
                INSERT INTO tb_st_store_bap (id_st_store_period, id_comp, id_report_status, report_mark_type, created_at, created_by) VALUES (" + FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + ", " + SLUEAccount.EditValue.ToString + ", 0, 0, NOW(), " + id_user + "); SELECT LAST_INSERT_ID();
            "

            Dim id_st_store_bap As String = execute_query(query_head, 0, True, "", "", "", "")

            'gen number
            execute_non_query("UPDATE tb_st_store_bap SET number = CONCAT('STCKBAP', LPAD(" + id_st_store_bap + ", 7, '0')) WHERE id_st_store_bap = " + id_st_store_bap, True, "", "", "", "")

            Dim query_detail As String = "INSERT INTO tb_st_store_bap_det (id_st_store_bap, id_product, soh_qty, scan_qty, id_price, price) VALUES "

            For i = 0 To FormStockTakeStorePeriod.BGVCompare.RowCount - 1
                If FormStockTakeStorePeriod.BGVCompare.IsValidRowHandle(i) Then
                    If FormStockTakeStorePeriod.BGVCompare.GetRowCellValue(i, "id_comp").ToString = SLUEAccount.EditValue.ToString Then
                        Dim id_product As String = FormStockTakeStorePeriod.BGVCompare.GetRowCellValue(i, "id_product")
                        Dim qty_soh As String = FormStockTakeStorePeriod.BGVCompare.GetRowCellValue(i, "qty_volcom")
                        Dim qty_scan As String = FormStockTakeStorePeriod.BGVCompare.GetRowCellValue(i, "qty_store")
                        Dim id_price As String = FormStockTakeStorePeriod.BGVCompare.GetRowCellValue(i, "id_price")
                        Dim price As String = FormStockTakeStorePeriod.BGVCompare.GetRowCellValue(i, "unit_price")

                        query_detail += "(" + id_st_store_bap + ", " + id_product + ", " + decimalSQL(qty_soh) + ", " + decimalSQL(qty_scan) + ", " + id_price + ", " + decimalSQL(price) + "), "
                    End If
                End If
            Next

            query_detail = query_detail.Substring(0, query_detail.Length - 2)

            execute_non_query(query_detail, True, "", "", "", "")

            FormStockTakeStoreVerDet.id_st_store_bap = id_st_store_bap

            FormStockTakeStoreVerDet.ShowDialog()

            Close()
        Else
            stopCustom("Verification already created.")
        End If
    End Sub
End Class