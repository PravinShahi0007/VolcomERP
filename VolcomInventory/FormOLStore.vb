Public Class FormOLStore
    Private Sub FormOLStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setDateNow()
        viewComp()
    End Sub

    Sub setDateNow()
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Sub viewComp()
        Dim query As String = "SELECT c.id_comp,cc.id_comp_contact, c.comp_number,c.comp_name 
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1 
        WHERE c.id_commerce_type=2 AND c.is_active=1 "
        viewSearchLookupQuery(SLECompDetail, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormOLStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormOLStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormOLStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub BtnViewDetail_Click(sender As Object, e As EventArgs) Handles BtnViewDetail.Click
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            viewDetail()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            viewDetailCancell()
        End If
    End Sub

    Sub viewDetailCancell()
        Cursor = Cursors.WaitCursor
        Dim data As DataTable = mainQuery(True)
        GCCancellOrder.DataSource = data
        GVCancellOrder.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim data As DataTable = mainQuery(False)
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Function mainQuery(ByVal is_show_cancell As Boolean)
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim id_comp As String = SLECompDetail.EditValue.ToString
        Dim query As String = "SELECT 'No' AS `is_select`,c.id_comp, c.comp_number, c.comp_name,
        so.id_sales_order AS `id_order`, so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, so.sales_order_date AS `order_date`,
        sod.id_sales_order_det, sod.item_id, sod.ol_store_id, sod.id_product, prod.product_full_code AS `code`, prod.product_display_name AS `name`, 
        sod.id_design_price, sod.design_price, sod.sales_order_det_qty AS `order_qty`, sod.sales_order_det_note,
        so.id_prepare_status, stt.prepare_status,
        so.`customer_name` , so.`shipping_name` , so.`shipping_address`, so.`shipping_phone` , so.`shipping_city` , 
        so.`shipping_post_code` , so.`shipping_region` , so.`payment_method`, so.`tracking_code`, IFNULL(stt.`status`, '-') AS `ol_store_status`, stt.status_date AS `ol_store_date`
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del AND d.id_report_status!=5
        INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
        INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
        LEFT JOIN (
            SELECT * FROM (
	            SELECT stt.id_sales_order_det, stt.`status`, stt.status_date 
	            FROM tb_sales_order_det_status stt
	            ORDER BY stt.status_date DESC
            ) a
            GROUP BY a.id_sales_order_det
        ) stt ON stt.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_lookup_prepare_status stt ON stt.id_prepare_status = so.id_prepare_status
        WHERE c.id_comp='" + id_comp + "' AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') "
        If is_show_cancell Then
            query += "AND so.id_prepare_status=2 AND ISNULL(d.id_pl_sales_order_del) "
        Else
            query += "AND (so.id_prepare_status=1 OR (so.id_prepare_status=2 AND !ISNULL(d.id_pl_sales_order_del))) "
        End If
        query += "ORDER BY so.id_sales_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function


    Private Sub BtnUpdateStt_Click(sender As Object, e As EventArgs) Handles BtnUpdateStt.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "42"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormOLStoreOrderId.Text += " : " + GVDetail.GetFocusedRowCellValue("order_number").ToString
            FormOLStoreOrderId.TxtOrderNumber.Text = GVDetail.GetFocusedRowCellValue("ol_store_order_number").ToString
            FormOLStoreOrderId.TxtItemId.Text = GVDetail.GetFocusedRowCellValue("item_id").ToString
            FormOLStoreOrderId.TxtOLStoreId.Text = GVDetail.GetFocusedRowCellValue("ol_store_id").ToString
            FormOLStoreOrderId.id_main = GVDetail.GetFocusedRowCellValue("id_order").ToString
            FormOLStoreOrderId.id_det = GVDetail.GetFocusedRowCellValue("id_sales_order_det").ToString
            FormOLStoreOrderId.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToBOF_Click(sender As Object, e As EventArgs) Handles BtnExportToBOF.Click
        makeSafeGV(GVDetail)
        GVDetail.ActiveFilterString = "[is_select]='Yes'"
        If GVDetail.RowCount > 0 Then
            Dim id_so As String = ""
            For i As Integer = 0 To GVDetail.RowCount - 1
                If i > 0 Then
                    id_so += "OR "
                End If
                id_so += "so.id_sales_order='" + GVDetail.GetRowCellValue(i, "id_order").ToString + "' "
            Next
            Dim so As New ClassSalesOrder()
            Dim res As String = so.generateXLSForBOF(id_so)
            If res = "True" Then
                infoCustom("File exported successfully")
                viewDetail()
            Else
                stopCustom(res)
            End If
        Else
            stopCustom("No item selected")
        End If
        makeSafeGV(GVDetail)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            BtnExportToBOF.Enabled = True
        Else
            BtnExportToBOF.Enabled = False
        End If
    End Sub
End Class