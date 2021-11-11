﻿Public Class FormOLStore
    Private Sub FormOLStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setDateNow()
        'viewComp()
        viewOLStoreGroup()
        viewOLStore()
    End Sub

    Sub setDateNow()
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Sub viewOLStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.description 
        FROM tb_m_comp_group cg WHERE cg.is_use_api=1
        ORDER BY cg.idx_prior_order ASC "
        viewSearchLookupQuery(SLEOLStore, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewOLStoreGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_comp_group`, 'All Group' AS `description`
        UNION ALL
        SELECT cg.id_comp_group, cg.description 
        FROM tb_m_comp_group cg 
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group
        WHERE c.id_commerce_type=2
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLEGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewComp()
        Dim id_comp_group As String = "-1"
        Try
            id_comp_group = SLEGroup.EditValue.ToString
        Catch ex As Exception
            id_comp_group = "-1"
        End Try
        Dim cond_comp As String = ""
        If id_comp_group <> "0" Then
            cond_comp = "AND c.id_comp_group='" + id_comp_group + "' "
        End If
        Dim query As String = "
        SELECT 0 AS `id_comp`, 0 AS `id_comp_contact`, 'ALL' AS `comp_number`, 'All Store' AS `comp_name`
        UNION ALL
        SELECT c.id_comp,cc.id_comp_contact, c.comp_number,c.comp_name 
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1 
        WHERE c.id_commerce_type=2 AND c.is_active=1 " + cond_comp
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
            viewSummary()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            viewDetail()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
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

    Sub viewSummary()
        Cursor = Cursors.WaitCursor

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

        'account
        Dim id_comp As String = SLECompDetail.EditValue.ToString
        Dim comp As String = ""
        If id_comp <> "0" Then
            comp = "AND c.id_comp='" + id_comp + "' "
        End If

        'group
        Dim id_comp_group As String = SLEGroup.EditValue.ToString
        Dim comp_grp As String = ""
        If id_comp_group <> "0" Then
            comp_grp = "AND c.id_comp_group ='" + id_comp_group + "' "
        End If

        Dim query As String = "SELECT 'No' AS `is_select`,c.id_comp, c.comp_number, c.comp_name,
        CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`,
        CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`,
        so.id_sales_order AS `id_order`, so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, 
        so.sales_order_date AS `order_date`, so.sales_order_ol_shop_date AS `ol_store_order_date`,
        prod.product_full_code AS `code`, prod.product_display_name AS `name`, SUM(sod.sales_order_det_qty) AS `total_order`,
        so.id_prepare_status, stt.prepare_status, so.id_report_status, rs.report_status,
        so.`customer_name` , so.`shipping_name` , so.`shipping_address`, so.`shipping_phone` , so.`shipping_city` , 
        so.`shipping_post_code` , so.`shipping_region` , so.`payment_method`, so.`tracking_code`, 'No' AS `is_select`, IF(ISNULL(doc.id_report),'No', 'Yes') AS `is_attach`
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
        INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
        INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = so.id_warehouse_contact_to 
        INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp 
        INNER JOIN tb_lookup_prepare_status stt ON stt.id_prepare_status = so.id_prepare_status
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = so.id_report_status
        LEFT JOIN (
            SELECT d.id_report 
            FROM tb_doc d
            INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_report
            WHERE d.report_mark_type=39 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') 
            GROUP BY d.id_report
        ) doc ON doc.id_report = so.id_sales_order
        WHERE so.id_sales_order>0 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') 
        " + comp + " AND c.id_commerce_type=2 " + comp_grp + "
        GROUP BY so.id_sales_order 
        ORDER BY so.sales_order_ol_shop_date ASC, so.sales_order_ol_shop_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
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

        'account
        Dim id_comp As String = SLECompDetail.EditValue.ToString
        Dim comp As String = ""
        If id_comp <> "0" Then
            comp = "AND c.id_comp='" + id_comp + "' "
        End If

        'group
        Dim id_comp_group As String = SLEGroup.EditValue.ToString
        Dim comp_grp As String = ""
        If id_comp_group <> "0" Then
            comp_grp = "AND c.id_comp_group ='" + id_comp_group + "' "
        End If

        Dim query As String = "SELECT 'No' AS `is_select`,c.id_comp, c.comp_number, c.comp_name,
        so.id_sales_order AS `id_order`, so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, so.sales_order_date AS `order_date`,
        sod.id_sales_order_det, sod.item_id, sod.ol_store_id, sod.id_product, prod.product_full_code AS `code`, prod.product_display_name AS `name`, cd.code_detail_name AS `size`,
        sod.id_design_price, sod.design_price, sod.sales_order_det_qty AS `order_qty`, sod.sales_order_det_note,
        so.id_prepare_status, stt.prepare_status,
        so.`customer_name` , so.`shipping_name` , so.`shipping_address`, so.`shipping_phone` , so.`shipping_city` , 
        so.`shipping_post_code` , so.`shipping_region` , so.`payment_method`, so.`tracking_code`, IFNULL(stt.`status`, '-') AS `ol_store_status`, stt.status_date AS `ol_store_date`, c.id_comp_group
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del AND d.id_report_status!=5
        INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
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
        WHERE so.id_report_status=6 " + comp + " AND c.id_commerce_type=2 " + comp_grp + "
        AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') "
        If is_show_cancell Then
            query += "AND so.id_prepare_status=2 AND ISNULL(d.id_pl_sales_order_del) "
        Else
            query += "AND (so.id_prepare_status=1 OR (so.id_prepare_status=2 AND !ISNULL(d.id_pl_sales_order_del))) "
        End If
        query += "ORDER BY so.sales_order_ol_shop_number ASC "
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
        makeSafeGV(GVSummary)
        GVSummary.ActiveFilterString = "[is_select]='Yes'"
        If GVSummary.RowCount > 0 Then
            Dim id_so As String = ""
            For i As Integer = 0 To GVSummary.RowCount - 1
                If i > 0 Then
                    id_so += "OR "
                End If
                id_so += "so.id_sales_order='" + GVSummary.GetRowCellValue(i, "id_order").ToString + "' "
            Next
            Dim so As New ClassSalesOrder()
            Dim res As String = so.generateXLSForBOF(id_so)
            If res = "True" Then
                infoCustom("File exported successfully")
                viewSummary()
            Else
                stopCustom(res)
            End If
        Else
            stopCustom("No item selected")
        End If
        makeSafeGV(GVSummary)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged

    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        viewDetailOrder()
    End Sub

    Sub viewDetailOrder()
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesOrderDet.id_sales_order = GVSummary.GetFocusedRowCellValue("id_order").ToString
            FormSalesOrderDet.action = "upd"
            FormSalesOrderDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FileAttachmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileAttachmentToolStripMenuItem.Click
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            Dim id_report_status As String = GVSummary.GetFocusedRowCellValue("id_report_status").ToString
            Dim id_order As String = GVSummary.GetFocusedRowCellValue("id_order").ToString
            FormDocumentUpload.id_report = id_order
            FormDocumentUpload.report_mark_type = "39"
            If id_report_status <> "1" Then
                FormDocumentUpload.is_no_delete = "1"
                FormDocumentUpload.ShowDialog()
            Else
                FormDocumentUpload.ShowDialog()
                viewSummary()
                GVSummary.FocusedRowHandle = find_row(GVSummary, "id_order", id_order)
            End If
        End If
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick
        viewDetailOrder()
    End Sub

    Private Sub SLECompDetail_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompDetail.EditValueChanged
        GCSummary.DataSource = Nothing
        GCDetail.DataSource = Nothing
        GCCancellOrder.DataSource = Nothing
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        GCSummary.DataSource = Nothing
        GCDetail.DataSource = Nothing
        GCCancellOrder.DataSource = Nothing
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        GCSummary.DataSource = Nothing
        GCDetail.DataSource = Nothing
        GCCancellOrder.DataSource = Nothing
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        If GVSummary.RowCount > 0 Then
            Dim cek As String = CESelAll.EditValue.ToString
            For i As Integer = 0 To ((GVSummary.RowCount - 1) - GetGroupRowCount(GVSummary))
                If cek Then
                    GVSummary.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSummary.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub BtnOrderConfirmation_Click(sender As Object, e As EventArgs) Handles BtnOrderConfirmation.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVSummary)
        GVSummary.ActiveFilterString = "[is_select]='Yes'"
        If GVSummary.RowCount > 0 Then
            Dim id_so As String = ""
            Dim id_so_in As String = ""
            For i As Integer = 0 To GVSummary.RowCount - 1
                If i > 0 Then
                    id_so += "OR "
                    id_so_in += ","
                End If
                id_so += "so.id_sales_order='" + GVSummary.GetRowCellValue(i, "id_order").ToString + "' "
                id_so_in += GVSummary.GetRowCellValue(i, "id_order").ToString
            Next

            'cek order
            Dim query_cek As String = "SELECT so.id_sales_order, so.sales_order_ol_shop_number, so.sales_order_number, so.customer_name,so.tracking_code,
            CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`,
            CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`,
            so.id_report_status, stt.report_status, doc.id_report,
            IF(so.id_report_status!=1 OR ISNULL(doc.id_report), CONCAT(IF(so.id_report_status!=1, CONCAT('Already ', stt.report_status, ' ; '),''), IF(ISNULL(doc.id_report),'No file attached; ','')),'OK') AS `status_check`
            FROM tb_sales_order so
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = so.id_report_status
            INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
            INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = so.id_warehouse_contact_to 
            INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp
            LEFT JOIN (
	            SELECT doc.id_report 
	            FROM tb_doc doc
	            WHERE doc.report_mark_type=39 
	            GROUP BY doc.id_report
            ) doc ON doc.id_report = so.id_sales_order
            WHERE so.id_sales_order>0
            AND (" + id_so + ")
            ORDER BY sales_order_ol_shop_number ASC "
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            Dim data_cek_filter As DataRow() = data_cek.Select("[status_check]<>'OK'")
            If data_cek_filter.Count > 0 Then
                'show alert can't process
                stopCustom("Some order have problem. Click 'OK' to see checking result")
                FormOLStoreAlertConfirm.dt = data_cek
                FormOLStoreAlertConfirm.ShowDialog()
                makeSafeGV(GVSummary)
            Else
                'send email
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm these order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Get all orders")

                    Dim query As String = "SELECT so.sales_order_ol_shop_number, so.customer_name, cg.comp_group AS `group_store_code`, cg.description AS `group_store`
                    FROM tb_sales_order so 
                    INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
                    INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
                    INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
                    WHERE so.id_sales_order>0
                    AND (" + id_so + ")
                    GROUP BY so.sales_order_ol_shop_number "
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If data.Rows.Count > 0 Then
                        Dim source_path As String = get_setup_field("upload_dir")
                        For i As Integer = 0 To data.Rows.Count - 1
                            FormMain.SplashScreenManager1.SetWaitFormDescription("Processing order : " + (i + 1).ToString + " of " + data.Rows.Count.ToString)

                            'send email
                            Try
                                Dim em As New ClassSendEmail()
                                em.report_mark_type = "39"
                                em.id_report = id_so
                                em.design = data.Rows(i)("group_store").ToString
                                em.design_code = data.Rows(i)("sales_order_ol_shop_number").ToString
                                em.comment_by = data.Rows(i)("customer_name").ToString
                                em.comment = source_path
                                em.send_email()
                            Catch ex As Exception
                                execute_non_query("INSERT INTO tb_error_mail (`date`, description) VALUES (NOW(), 'Failed Send Online Store number = " + data.Rows(i)("sales_order_ol_shop_number").ToString + "')", True, "", "", "", "")
                            End Try

                            'completed status
                            Dim query_comp As String = "UPDATE tb_sales_order so SET so.id_report_status=6 
                            WHERE so.sales_order_ol_shop_number='" + data.Rows(i)("sales_order_ol_shop_number").ToString + "' AND (" + id_so + ") "
                            execute_non_query(query_comp, True, "", "", "", "")
                        Next
                    End If
                    makeSafeGV(GVSummary)

                    'GWP for zalora
                    Try
                        Dim qcg As String = "SELECT * FROM tb_ol_store_gwp g WHERE g.is_active=1 AND (NOW()>=g.start_period AND NOW()<=g.end_period) "
                        Dim dcg As DataTable = execute_query(qcg, -1, True, "", "", "", "")
                        If dcg.Rows.Count > 0 Then
                            Dim qog As String = "SELECT so.id_sales_order, s.id_comp_group, so.sales_order_ol_shop_number AS `order_no`
                            FROM tb_sales_order so
                            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
                            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp AND s.id_commerce_type=2
                            WHERE so.id_report_status=6 AND so.id_sales_order IN (" + id_so_in + ") "
                            Dim dog As DataTable = execute_query(qog, -1, True, "", "", "", "")
                            For j As Integer = 0 To dog.Rows.Count - 1
                                FormMain.SplashScreenManager1.SetWaitFormDescription("Processing GWP order : " + (j + 1).ToString + " of " + dog.Rows.Count.ToString)
                                execute_non_query_long("CALL create_ol_gwp_order(" + dog.Rows(j)("id_comp_group").ToString + ", '" + dog.Rows(j)("order_no").ToString + "')", True, "", "", "", "")
                            Next
                        End If
                    Catch ex As Exception
                        errorCustom("Problem with GWP Order" + System.Environment.NewLine.ToString + ex.ToString)
                    End Try

                    viewSummary()
                    FormMain.SplashScreenManager1.CloseWaitForm()
                Else
                    makeSafeGV(GVSummary)
                End If
            End If
        Else
            stopCustom("No item selected")
            makeSafeGV(GVSummary)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCVolcom, "")
        Cursor = Cursors.Default
    End Sub

    Sub viewVolcomOrder(ByVal cond As String)
        Dim query As String = "SELECT 'no' AS is_checked, vo.id, vo.sales_order_ol_shop_number, vo.sales_order_ol_shop_date, vo.customer_name, vo.shipping_name, vo.shipping_address, vo.shipping_phone, vo.shipping_city, vo.shipping_post_code,
        vo.shipping_region, vo.payment_method, vo.tracking_code, vo.ol_store_sku, vo.ol_store_id, vo.sku, vo.design_price, vo.sales_order_det_qty, vo.is_process, IF(vo.is_process=1,'Yes', 'No') AS `is_process_view`,
        vo.note_price, vo.id_design_cat, vo.id_design_price, vo.id_product, vo.note_stock, vo.note_promo,
        vo.id_report_trf_order, vo.rmt_trf_order, trf_order.sales_order_number AS `trf_order_number`,
        vo.id_report_trf, vo.rmt_trf, trf.fg_trf_number AS `trf_number`,
        vo.id_report_order, vo.rmt_order , actual_order.sales_order_number, vo.fail_reason, vo.id_comp_group, cg.comp_group, cg.description AS `comp_group_name`
        FROM tb_ol_store_order vo
        LEFT JOIN tb_sales_order trf_order ON trf_order.id_sales_order = vo.id_report_trf_order
        LEFT JOIN tb_sales_order actual_order ON actual_order.id_sales_order = vo.id_report_order
        LEFT JOIN tb_fg_trf trf ON trf.id_fg_trf = vo.id_report_trf
        LEFT JOIN tb_m_comp_group cg ON cg.id_comp_group = vo.id_comp_group
        WHERE 1=1 " + cond
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCVolcom.DataSource = data
    End Sub

    Private Sub BtnAllOrder_Click(sender As Object, e As EventArgs) Handles BtnAllOrder.Click
        Cursor = Cursors.WaitCursor
        viewVolcomOrder("")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPendingOrder_Click(sender As Object, e As EventArgs) Handles BtnPendingOrder.Click
        viewPendingOrders()
    End Sub

    Sub viewPendingOrders()
        Cursor = Cursors.WaitCursor
        viewVolcomOrder("AND vo.is_process=2 AND ISNULL(vo.id_ol_store_oos) ")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirmedOrder_Click(sender As Object, e As EventArgs) Handles BtnConfirmedOrder.Click
        Cursor = Cursors.WaitCursor
        viewVolcomOrder("AND vo.is_process=1")
        Cursor = Cursors.Default
    End Sub


    Private Sub BtnSyncOrder_Click(sender As Object, e As EventArgs) Handles BtnSyncOrder.Click
        syncOrder()
    End Sub

    Sub syncOrder()
        Cursor = Cursors.WaitCursor
        'initial general
        Dim err As String = ""

        'cek freeze
        Dim id_comp_group As String = SLEOLStore.EditValue.ToString
        Dim id_comp_in As String = execute_query("SELECT CONCAT(cc1.id_comp, ',',cc2.id_comp) AS `id_comp_all` 
        FROM tb_m_comp_group c 
        INNER JOIN tb_m_comp_contact cc1 ON cc1.id_comp_contact = c.id_wh_order_contact_normal
        INNER JOIN tb_m_comp_contact cc2 ON cc2.id_comp_contact = c.id_wh_order_contact_sale
        WHERE c.id_comp_group='" + id_comp_group + "'", 0, True, "", "", "", "")
        Dim qf As String = "SELECT * FROM tb_m_comp c WHERE c.id_comp IN (" + id_comp_in + ") AND c.is_active=2 "
        Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
        If df.Rows.Count > 0 Then
            Cursor = Cursors.Default
            stopCustom("WH already freeze")
            Exit Sub
        End If

        Dim is_processed_order As String = get_setup_field("is_processed_order")
        If is_processed_order = "1" Then
            stopCustom("Sync still running")
        Else
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            Dim ord As New ClassSalesOrder()
            ord.setProceccedWebOrder("1")
            ord.insertLogWebOrder("0", "Start", "0")

            'cek allow
            Dim is_must_ok_stock As String = "2"
            If CEAllow.EditValue = False Then
                is_must_ok_stock = "1"
            Else
                is_must_ok_stock = "2"
            End If

            'get api type
            Dim dt_grp As DataTable = execute_query("SELECT cg.id_api_type, cg.comp_group, cg.is_order_check_awb FROM tb_m_comp_group cg WHERE cg.id_comp_group='" + id_comp_group + "' ", -1, True, "", "", "", "")
            Dim id_api_type As String = dt_grp.Rows(0)("id_api_type").ToString
            Dim comp_group As String = dt_grp.Rows(0)("comp_group").ToString.ToUpper
            Dim is_order_check_awb As String = dt_grp.Rows(0)("is_order_check_awb").ToString.ToUpper

            'get order from web
            'hide when developed
            ord.insertLogWebOrder("0", "Get order from website. " + err, id_comp_group)
            If id_api_type = "1" Then
                'SHOPIFY
                Try
                    Dim shop As New ClassShopifyApi()
                    shop.get_order_erp()
                Catch ex As Exception
                    err = ex.ToString
                End Try
            ElseIf id_api_type = "2" Then
                'ZALORA
                Try
                    Dim shop As New ClassZaloraApi()
                    shop.get_order_list()
                Catch ex As Exception
                    err = ex.ToString
                End Try
            ElseIf id_api_type = "3" Then
                'BLIBLI
                Try
                    Dim shop As New ClassBliBliApi()
                    shop.get_order_list()
                Catch ex As Exception
                    err = ex.ToString
                End Try
            End If

            'get order yg belum diproses
            Dim qord As String = ""
            If is_order_check_awb = "1" Then
                qord = "SELECT o.id, o.sales_order_ol_shop_number,o.tracking_code  FROM tb_ol_store_order o
                WHERE o.is_process=2 AND o.id_comp_group='" + id_comp_group + "' AND ISNULL(o.id_ol_store_oos)
                GROUP BY o.id, o.tracking_code "
            Else
                qord = "SELECT o.id, o.sales_order_ol_shop_number  FROM tb_ol_store_order o
                WHERE o.is_process=2 AND o.id_comp_group='" + id_comp_group + "' AND ISNULL(o.id_ol_store_oos)
                GROUP BY o.id "
            End If
            Dim dord As DataTable = execute_query(qord, -1, True, "", "", "", "")
            Dim id_order_in As String = ""
            If dord.Rows.Count > 0 Then
                Try
                    For i As Integer = 0 To dord.Rows.Count - 1
                        FormMain.SplashScreenManager1.SetWaitFormDescription(comp_group + " ORDER : " + (i + 1).ToString + "/" + dord.Rows.Count.ToString)
                        If is_order_check_awb = "1" Then
                            execute_non_query_long("CALL create_web_order_grp_awb(" + dord.Rows(i)("id").ToString + ", " + is_must_ok_stock + ",'" + id_comp_group + "', '" + dord.Rows(i)("tracking_code").ToString + "');", True, "", "", "", "")
                        Else
                            execute_non_query_long("CALL create_web_order_grp(" + dord.Rows(i)("id").ToString + ", " + is_must_ok_stock + ",'" + id_comp_group + "');", True, "", "", "", "")
                        End If
                        If i > 0 Then
                            id_order_in += ","
                        End If
                        id_order_in += dord.Rows(i)("id").ToString
                    Next
                Catch ex As Exception
                    ord.insertLogWebOrder("0", ex.ToString, id_comp_group)
                    stopCustom(ex.ToString)
                End Try
            End If

            'other action after created order
            Dim err_other_act As String = ""
            If id_api_type = "2" Then
                'ZALORA
                Dim zal As New ClassZaloraApi()
                err_other_act = zal.setRTSPending()
            End If

            'evaluasi
            Dim jum_eval As Integer = 0
            If id_api_type <> "1" Then 'selain VIOS
                Dim query_eval As String = "SELECT od.id, od.sales_order_ol_shop_number AS `order_number`, IFNULL(od.tracking_code,'0') AS `tracking_code`
                FROM tb_ol_store_order od 
                WHERE od.id_comp_group='" + id_comp_group + "'  AND od.note_price='OK' AND od.note_promo='OK' AND od.note_stock<>'OK' AND od.is_process=2 AND ISNULL(od.id_ol_store_oos)
                GROUP BY od.id "
                If is_order_check_awb = "1" Then
                    query_eval += ", od.tracking_code "
                End If

                Dim data_eval As DataTable = execute_query(query_eval, -1, True, "", "", "", "")
                If data_eval.Rows.Count > 0 Then
                    For e As Integer = 0 To data_eval.Rows.Count - 1
                        jum_eval += 1
                        Dim id_order_eval As String = data_eval.Rows(e)("id").ToString
                        Dim no_eval As String = data_eval.Rows(e)("order_number").ToString
                        Dim awb_eval As String = data_eval.Rows(e)("tracking_code").ToString

                        FormMain.SplashScreenManager1.SetWaitFormDescription("Evaluate order : " + (e + 1).ToString + "/" + data_eval.Rows.Count.ToString)
                        'evaluate oos
                        Dim oos As New ClassOLStore()
                        If is_order_check_awb = "1" Then
                            oos.evaluateOOSAWB(id_order_eval, id_comp_group, awb_eval)
                            ord.insertLogWebOrderAWB(id_order_eval, "Evaluate OOS", id_comp_group, awb_eval)
                        Else
                            oos.evaluateOOS(id_order_eval, id_comp_group)
                            ord.insertLogWebOrder(id_order_eval, "Evaluate OOS", id_comp_group)
                        End If


                        'cek apa ada yang bisa restok
                        Dim is_restock As Boolean = False
                        If is_order_check_awb = "1" Then
                            is_restock = oos.checkOOSRestockOrderAWB(id_order_eval, id_comp_group, awb_eval)
                            ord.insertLogWebOrderAWB(id_order_eval, "Evaluating restock", id_comp_group, awb_eval)
                        Else
                            is_restock = oos.checkOOSRestockOrder(id_order_eval, id_comp_group)
                            ord.insertLogWebOrder(id_order_eval, "Evaluating restock", id_comp_group)
                        End If
                        If Not is_restock Then
                            'jika ndak ada yang bisa direstock langsung kirim email
                            Try
                                If is_order_check_awb = "1" Then
                                    oos.sendEmailOOSAWB(id_order_eval, id_comp_group, awb_eval)
                                    Dim id_oos As String = execute_query("SELECT id_ol_store_oos FROM tb_ol_store_oos WHERE id_comp_group='" + id_comp_group + "' AND id_order='" + id_order_eval + "' AND tracking_code='" + awb_eval + "' ", 0, True, "", "", "", "")
                                    execute_non_query("UPDATE tb_ol_store_oos SET id_ol_store_oos_stt=3, sent_email_date=NOW() WHERE id_ol_store_oos='" + id_oos + "' ", True, "", "", "", "")
                                    ord.insertLogWebOrderAWB(id_order_eval, "Evaluate result : No stock;Send Email OOS success; Status=email sent", id_comp_group, awb_eval)
                                Else
                                    oos.sendEmailOOS(id_order_eval, id_comp_group)
                                    Dim id_oos As String = execute_query("SELECT id_ol_store_oos FROM tb_ol_store_oos WHERE id_comp_group='" + id_comp_group + "' AND id_order='" + id_order_eval + "' ", 0, True, "", "", "", "")
                                    execute_non_query("UPDATE tb_ol_store_oos SET id_ol_store_oos_stt=3, sent_email_date=NOW() WHERE id_ol_store_oos='" + id_oos + "' ", True, "", "", "", "")
                                    ord.insertLogWebOrder(id_order_eval, "Evaluate result : No stock;Send Email OOS success; Status=email sent", id_comp_group)
                                End If
                            Catch ex As Exception
                                If is_order_check_awb = "1" Then
                                    ord.insertLogWebOrderAWB(id_order_eval, "Evaluate result : No stock & Send Email OOS failed", id_comp_group, awb_eval)
                                Else
                                    ord.insertLogWebOrder(id_order_eval, "Evaluate result : No stock & Send Email OOS failed", id_comp_group)
                                End If
                            End Try

                            'check jika kosong langsung di closed
                            If is_order_check_awb = "1" Then
                                oos.checkOOSEmptyOrderAWB(id_order_eval, id_comp_group, awb_eval)
                            Else
                                oos.checkOOSEmptyOrder(id_order_eval, id_comp_group)
                            End If

                            'other action
                            If id_api_type = "2" Then
                                'ZALORA
                                Dim zal As New ClassZaloraApi()
                                err_other_act = zal.setRTSPending()
                            End If
                        Else
                            If is_order_check_awb = "1" Then
                                ord.insertLogWebOrderAWB(id_order_eval, "Evaluate result : Restock process", id_comp_group, awb_eval)
                            Else
                                ord.insertLogWebOrder(id_order_eval, "Evaluate result : Restock process", id_comp_group)
                            End If
                        End If
                    Next
                End If
            End If

            ord.insertLogWebOrder("0", "End", "0")
            ord.setProceccedWebOrder("2")
            FormMain.SplashScreenManager1.CloseWaitForm()
            If err = "" And err_other_act = "" Then
                infoCustom("Sync completed.")
            Else
                infoCustom("Problem get order from web : " + System.Environment.NewLine + "- " + err + System.Environment.NewLine + "- " + err_other_act)
            End If
            GCVolcom.DataSource = Nothing
            If orderNotProcessed() Then
                stopCustom("Some orders cannot be processed")
                viewPendingOrders()
            End If
            If jum_eval > 0 Then
                stopCustom("Some orders out of stock.")
                viewOOSList()
            End If
        End If
        CEAllow.EditValue = False
        Cursor = Cursors.Default
    End Sub

    Function orderNotProcessed()
        Dim query As String = "SELECT * FROM tb_ol_store_order od WHERE od.is_process=2 AND ISNULL(od.id_ol_store_oos) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LinkTrfOrder_Click(sender As Object, e As EventArgs) Handles LinkTrfOrder.Click
        If GVVolcom.FocusedRowHandle >= 0 And GVVolcom.RowCount > 0 Then
            viewOrderRef(GVVolcom.GetFocusedRowCellValue("rmt_trf_order").ToString, GVVolcom.GetFocusedRowCellValue("id_report_trf_order").ToString)
        End If
    End Sub

    Sub viewOrderRef(ByVal rmt As String, ByVal id_report As String)
        Cursor = Cursors.WaitCursor
        Dim so As New ClassShowPopUp
        so.report_mark_type = rmt
        so.id_report = id_report
        so.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkSalesOrder_Click(sender As Object, e As EventArgs) Handles LinkSalesOrder.Click
        If GVVolcom.FocusedRowHandle >= 0 And GVVolcom.RowCount > 0 Then
            viewOrderRef(GVVolcom.GetFocusedRowCellValue("rmt_order").ToString, GVVolcom.GetFocusedRowCellValue("id_report_order").ToString)
        End If
    End Sub

    Private Sub LinkTrf_Click(sender As Object, e As EventArgs) Handles LinkTrf.Click
        If GVVolcom.FocusedRowHandle >= 0 And GVVolcom.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim so As New ClassShowPopUp
            so.report_mark_type = GVVolcom.GetFocusedRowCellValue("rmt_trf").ToString
            so.id_report = GVVolcom.GetFocusedRowCellValue("id_report_trf").ToString
            so.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CEAllow_CheckedChanged(sender As Object, e As EventArgs) Handles CEAllow.CheckedChanged

    End Sub

    Private Sub RICEIsCheck_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RICEIsCheck.EditValueChanging
        If Not GVVolcom.GetFocusedRowCellValue("is_process").ToString = "2" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub SBCloseOrder_Click(sender As Object, e As EventArgs) Handles SBCloseOrder.Click
        GVVolcom.ActiveFilterString = "[is_checked] = 'yes'"

        If GVVolcom.RowCount > 0 Then
            FormOLStoreCloseConfirm.ShowDialog()
        Else
            stopCustom("No order selected.")
        End If

        GVVolcom.ActiveFilterString = ""
    End Sub

    Private Sub GVDetail_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVDetail.PopupMenuShowing
        If GVDetail.GetFocusedRowCellValue("id_comp_group").ToString = "75" Then
            EditToolStripMenuItem.Visible = True
        Else
            EditToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub BtnUpdateStatusVIAAPI_Click(sender As Object, e As EventArgs) Handles BtnUpdateStatusVIAAPI.Click
        Cursor = Cursors.WaitCursor
        FormOLStoreUpdateStatus.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXLSSyncOrder_Click(sender As Object, e As EventArgs) Handles BtnXLSSyncOrder.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.is_save_as = True
        FormImportExcel.id_pop_up = "54"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEGroup.EditValueChanged
        viewComp()
        GCSummary.DataSource = Nothing
        GCDetail.DataSource = Nothing
        GCCancellOrder.DataSource = Nothing
    End Sub

    Private Sub BtnFollowUp_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnOOS_Click(sender As Object, e As EventArgs) Handles BtnOOS.Click
        viewOOSList()
    End Sub

    Sub viewOOSList()
        Cursor = Cursors.WaitCursor
        FormOLStoreOOS.id_type = "2"
        FormOLStoreOOS.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class