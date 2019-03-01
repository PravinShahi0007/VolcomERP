Public Class FormOLStoreDet
    Private Sub BtnBrowseFile_Click(sender As Object, e As EventArgs) Handles BtnBrowseFile.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "41"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormOLStoreDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewDetail()
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT so.id_sales_order, sod.id_sales_order_det, 
        so.id_warehouse_contact_to, '0' AS `id_wh_drawer`, '' AS `comp`,
        so.id_store_contact_to,  '' AS `store`,
        so.sales_order_number,so.sales_order_ol_shop_number, so.sales_order_date, so.sales_order_ol_shop_date,
        sod.id_product,'' AS `code`, '' AS `name`, '' AS `item_id`, '' AS `ol_store_id`, sod.sales_order_det_qty, 0 AS `id_design_cat`,sod.id_design_price, sod.design_price, 
        so.customer_name, so.shipping_name, so.shipping_address, so.shipping_phone, so.shipping_city, 
        so.shipping_post_code, so.shipping_region, so.payment_method, so.tracking_code, 0 AS `no`, '' AS `status`
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        WHERE so.id_sales_order=0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
    End Sub

    Sub viewCompGroup()
        Dim query As String = "SELECT g.id_comp_group, g.description
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
        WHERE c.id_commerce_type=2 AND c.is_active=1
        GROUP BY c.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
    End Sub

    Private Sub FormOLStoreDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        makeSafeGV(GVDetail)
        makeSafeGV(GVProduct)

        'checkstock harus di grup
        Cursor = Cursors.WaitCursor
        Dim cond_stock As Boolean = True
        For i As Integer = 0 To GVProduct.RowCount - 1
            Dim id_product As String = GVProduct.GetRowCellValue(i, "id_product").ToString
            Dim id_wh_drawer As String = GVProduct.GetRowCellValue(i, "id_wh_drawer").ToString
            Dim query As String = "SELECT f.id_wh_drawer, f.id_product, IFNULL(SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0) AS `available_qty` 
            FROM tb_storage_fg f
            WHERE f.id_wh_drawer='" + id_wh_drawer + "' AND f.id_product='" + id_product + "' "
            Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                If GVProduct.GetRowCellValue(i, "qty") > dt.Rows(0)("available_qty") Then
                    cond_stock = False
                    GVProduct.SetRowCellValue(i, "status", "Qty can't exceed : " + dt.Rows(0)("available_qty").ToString + " ")
                Else
                    GVProduct.SetRowCellValue(i, "status", "OK")
                End If
            Else
                cond_stock = False
                GVProduct.SetRowCellValue(i, "status", "No available qty")
            End If
        Next
        Cursor = Cursors.Default

        If Not cond_stock Then
            stopCustom("Can't procees these order, please make sure available stock ")
            GridColumnProdStatus.VisibleIndex = 100
            XTCOrder.SelectedTabPageIndex = 1
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                createOrder("1")
                createOrder("2")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub createOrder(ByVal id_store_type As String)
        Dim id_order_last As String = ""
        Dim order_last As String = ""

        makeSafeGV(GVDetail)
        GVDetail.ActiveFilterString = "[id_design_cat]='" + id_store_type + "' "
        GridColumnOrderNumber.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        For i As Integer = 0 To GVDetail.RowCount - 1
            Dim id_warehouse_contact_to As String = GVDetail.GetRowCellValue(i, "id_warehouse_contact_to").ToString.Trim
            Dim id_store_contact_to As String = GVDetail.GetRowCellValue(i, "id_store_contact_to").ToString.Trim
            Dim sales_order_ol_shop_number As String = GVDetail.GetRowCellValue(i, "sales_order_ol_shop_number").ToString.Trim
            Dim sales_order_ol_shop_date As String = DateTime.Parse(GVDetail.GetRowCellValue(i, "sales_order_ol_shop_date").ToString).ToString("yyyy-MM-dd HH:mm")
            Dim sales_order_note As String = ""
            Dim id_so_type As String = "0"
            Dim id_so_status As String = "6"
            Dim id_report_status As String = "6"
            Dim id_user_created As String = id_user
            Dim customer_name As String = addSlashes(GVDetail.GetRowCellValue(i, "customer_name").ToString.Trim)
            Dim shipping_name As String = addSlashes(GVDetail.GetRowCellValue(i, "shipping_name").ToString.Trim)
            Dim shipping_address = addSlashes(GVDetail.GetRowCellValue(i, "shipping_address").ToString.Trim)
            Dim shipping_phone = addSlashes(GVDetail.GetRowCellValue(i, "shipping_phone").ToString.Trim)
            Dim shipping_city = addSlashes(GVDetail.GetRowCellValue(i, "shipping_city").ToString.Trim)
            Dim shipping_post_code = addSlashes(GVDetail.GetRowCellValue(i, "shipping_post_code").ToString.Trim)
            Dim shipping_region = addSlashes(GVDetail.GetRowCellValue(i, "shipping_region").ToString.Trim)
            Dim payment_method = addSlashes(GVDetail.GetRowCellValue(i, "payment_method").ToString.Trim)
            Dim tracking_code = addSlashes(GVDetail.GetRowCellValue(i, "tracking_code").ToString.Trim)

            'cek order baru atau lama
            If order_last <> sales_order_ol_shop_number Then
                'new order
                Dim query_main As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_ol_shop_number, 
                sales_order_date, sales_order_ol_shop_date, sales_order_note, id_so_type, id_so_status, id_report_status, id_user_created, 
                customer_name, shipping_name, shipping_address, shipping_phone, shipping_city, shipping_post_code, shipping_region, payment_method, tracking_code) 
                VALUES('" + id_store_contact_to + "', '" + id_warehouse_contact_to + "', '', '" + sales_order_ol_shop_number + "',
                NOW(), '" + sales_order_ol_shop_date + "', '" + sales_order_note + "', '" + id_so_type + "', '" + id_so_status + "', '" + id_report_status + "', '" + id_user_created + "',
                '" + customer_name + "', '" + shipping_name + "', '" + shipping_address + "', '" + shipping_phone + "', '" + shipping_city + "', '" + shipping_post_code + "', '" + shipping_region + "', '" + payment_method + "', '" + tracking_code + "'); 
                SELECT LAST_INSERT_ID(); "
                id_order_last = execute_query(query_main, 0, True, "", "", "", "")
            End If

            'detail
            Dim id_product As String = GVDetail.GetRowCellValue(i, "id_product").ToString
            Dim id_design_price As String = GVDetail.GetRowCellValue(i, "id_design_price").ToString
            Dim design_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "design_price").ToString)
            Dim item_id As String = GVDetail.GetRowCellValue(i, "item_id").ToString.Trim
            Dim ol_store_id As String = GVDetail.GetRowCellValue(i, "ol_store_id").ToString.Trim
            Dim sales_order_det_qty As String = decimalSQL(GVDetail.GetRowCellValue(i, "sales_order_det_qty").ToString)
            Dim sales_order_det_note As String = ""
            Dim query_det As String = "INSERT tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, 
            item_id, ol_store_id, sales_order_det_qty, sales_order_det_note) 
            VALUES('" + id_order_last + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "',
            '" + item_id + "', '" + ol_store_id + "', '" + sales_order_det_qty + "', '" + sales_order_det_note + "'); "
            execute_non_query(query_det, True, "", "", "", "")

            'reserved
        Next
    End Sub
End Class