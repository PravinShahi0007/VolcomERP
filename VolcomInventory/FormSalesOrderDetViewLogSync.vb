Public Class FormSalesOrderDetViewLogSync
    Private Sub FormSalesOrderDetViewLogSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCLog.DataSource = get_data("")

        GVLog.BestFitColumns()
    End Sub

    Private Sub FormSalesOrderDetViewLogSync_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Function get_data(id_log As String) As DataTable
        Dim where_id_log As String = If(id_log = "", "", " AND l.id_shopify_api_log IN (" + id_log + ")")

        Dim query As String = "
            SELECT 'no' AS is_check, l.*, IF(l.is_verify = 1, 'Yes', 'No') AS verify, IFNULL(q.qty,0) AS `qty`, j.inventory_item_id
            FROM tb_shopify_api_log l 
            INNER JOIN tb_fg_trf t ON t.id_fg_trf = l.id_report
            INNER JOIN tb_sales_order so ON so.id_sales_order = t.id_sales_order
            INNER JOIN (
                SELECT sod.id_sales_order, p.product_full_code AS `code`, sod.sales_order_det_qty AS `qty`
                FROM tb_sales_order_det sod
                INNER JOIN tb_m_product p ON p.id_product = sod.id_product
                WHERE sod.id_sales_order = " + FormSalesOrderDet.id_sales_order + "
            ) q ON q.id_sales_order = so.id_sales_order AND l.sku = q.`code`
            LEFT JOIN tb_m_product_shopify j ON l.sku = j.sku
            WHERE so.id_sales_order = " + FormSalesOrderDet.id_sales_order + where_id_log + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Return data
    End Function

    Private Sub SBResync_Click(sender As Object, e As EventArgs) Handles SBResync.Click
        GVLog.ActiveFilterString = "[is_check] = 'yes'"

        Cursor = Cursors.WaitCursor

        If GVLog.RowCount > 0 Then
            Dim cls As ClassShopifyApi = New ClassShopifyApi

            Dim id_log As String = ""

            For i = 0 To GVLog.RowCount - 1
                id_log += GVLog.GetRowCellValue(i, "id_shopify_api_log").ToString + ", "
            Next

            id_log = id_log.Substring(0, id_log.Length - 2)

            Dim data As DataTable = get_data(id_log)

            For i = 0 To data.Rows.Count - 1
                Dim compare As DataTable = cls.compare_qty_sku({data.Rows(i)("sku").ToString})

                If compare.Rows(0)("qty_erp") <> compare.Rows(0)("qty_shopify") Then
                    Dim location_id As String = cls.get_location_id()

                    Dim msg As String = "OK"

                    Try
                        Dim qty As String = Decimal.Round(data.Rows(i)("qty"), 0).ToString

                        Dim is_vsol_from As String = execute_query("SELECT IF(COUNT(*) = 0, 2, 1) AS is_vsol_from FROM tb_m_comp_volcom_ol WHERE id_comp = (SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = (SELECT id_warehouse_contact_to FROM tb_sales_order WHERE id_sales_order = " + FormSalesOrderDet.id_sales_order + "))", 0, True, "", "", "", "")

                        If is_vsol_from = "1" Then
                            qty = "-" + qty
                        End If

                        cls.add_product(location_id, data.Rows(i)("inventory_item_id").ToString, qty)
                    Catch ex As Exception
                        msg = ex.ToString
                    End Try

                    execute_non_query("UPDATE tb_shopify_api_log SET is_verify = '1' WHERE id_shopify_api_log = " + data.Rows(i)("id_shopify_api_log").ToString, True, "", "", "", "")

                    execute_non_query("INSERT INTO tb_shopify_api_log (report_mark_type, id_report, sku, message, id_user, date, is_verify) VALUES (57, '" + data.Rows(i)("id_report").ToString + "', '" + data.Rows(i)("sku").ToString + "', '" + addSlashes(msg) + "', '" + id_user + "', NOW(), " + If(msg = "OK", "1", "2") + ")", True, "", "", "", "")
                End If
            Next

            infoCustom("Sync completed.")

            GCLog.DataSource = get_data("")

            GVLog.BestFitColumns()
        Else
            stopCustom("Please select error log.")
        End If

        Cursor = Cursors.Default

        GVLog.ActiveFilterString = ""
    End Sub

    Private Sub GVLog_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVLog.FocusedRowChanged
        If GVLog.GetRowCellValue(e.FocusedRowHandle, "is_verify") = "1" Then
            RICE.ReadOnly = True
        Else
            RICE.ReadOnly = False
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        print(GCLog, FormSalesOrderDet.TxtSalesOrderNumber.Text + " (Sync Log)")
    End Sub
End Class