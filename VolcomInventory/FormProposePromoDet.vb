Public Class FormProposePromoDet
    Public id_propose_promo As String = "0"

    Private Sub FormProposePromoDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormProposePromoDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormProposePromoPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVProduct.DeleteSelectedRows()
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        If TENama.EditValue.ToString = "" Or MEAlamat.EditValue.ToString = "" Or (TEKTP.EditValue.ToString = "" And TENPWP.EditValue.ToString = "") Then
            stopCustom("Please check your input.")
        Else
            GVProduct.FindFilterText = ""
            GVProduct.ActiveFilterString = ""
            GVProduct.ClearColumnsFilter()

            If GVProduct.RowCount > 0 Then
                'stock check
                For i = 0 To GVProduct.RowCount - 1
                    If GVProduct.IsValidRowHandle(i) Then
                        Dim query_sc As String = "DELETE FROM tb_temp_val_stock WHERE id_user='" + id_user + "'; INSERT INTO tb_temp_val_stock(id_user, code, name, size, id_product, qty) VALUES ('" + id_user + "', '" + GVProduct.GetRowCellValue(i, "code").ToString + "', '" + addSlashes(GVProduct.GetRowCellValue(i, "name").ToString) + "', '" + GVProduct.GetRowCellValue(i, "size").ToString + "', '" + GVProduct.GetRowCellValue(i, "id_product").ToString + "', '" + decimalSQL(GVProduct.GetRowCellValue(i, "qty").ToString) + "'); CALL view_validate_stock(" + id_user + ", " + GVProduct.GetRowCellValue(i, "id_comp").ToString + ", '" + GVProduct.GetRowCellValue(i, "id_product").ToString + "', 1);"

                        Dim data_sc As DataTable = execute_query(query_sc, -1, True, "", "", "", "")

                        If data_sc.Rows.Count > 0 Then
                            stopCustom("No stock available for some items.")

                            FormValidateStock.dt = data_sc

                            FormValidateStock.ShowDialog()

                            Exit Sub
                        End If
                    End If
                Next

                Dim confirm As DialogResult

                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim nama As String = addSlashes(TENama.EditValue.ToString)
                    Dim ktp As String = addSlashes(TEKTP.EditValue.ToString)
                    Dim npwp As String = addSlashes(TENPWP.EditValue.ToString)
                    Dim alamat As String = addSlashes(MEAlamat.EditValue.ToString)
                    Dim report_mark_type As String = "358"

                    For i = 0 To GVProduct.RowCount - 1
                        If GVProduct.IsValidRowHandle(i) Then
                            If Not GVProduct.GetRowCellValue(i, "id_comp").ToString = "437" Then
                                report_mark_type = "362"
                            End If
                        End If
                    Next

                    Dim query As String = "INSERT INTO tb_propose_promo (nama, ktp, npwp, alamat, created_at, created_by, id_report_status, report_mark_type) VALUES ('" + nama + "', '" + ktp + "', '" + npwp + "', '" + alamat + "', NOW(), '" + id_employee_user + "', 1, " + report_mark_type + "); SELECT LAST_INSERT_ID();"

                    id_propose_promo = execute_query(query, 0, True, "", "", "", "")

                    Dim query_detail As String = "INSERT INTO tb_propose_promo_det (id_propose_promo, id_comp, id_product, id_design_price, design_price, qty) VALUES "

                    For i = 0 To GVProduct.RowCount - 1
                        If GVProduct.IsValidRowHandle(i) Then
                            Dim id_comp As String = GVProduct.GetRowCellValue(i, "id_comp").ToString
                            Dim id_product As String = GVProduct.GetRowCellValue(i, "id_product").ToString
                            Dim id_design_price As String = GVProduct.GetRowCellValue(i, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVProduct.GetRowCellValue(i, "design_price").ToString)
                            Dim qty As String = decimalSQL(GVProduct.GetRowCellValue(i, "qty").ToString)

                            query_detail += "(" + id_propose_promo + ", " + id_comp + ", " + id_product + ", " + id_design_price + ", '" + design_price + "', '" + qty + "'), "
                        End If
                    Next

                    query_detail = query_detail.Substring(0, query_detail.Length - 2)

                    execute_non_query(query_detail, True, "", "", "", "")

                    execute_non_query("CALL gen_number(" + id_propose_promo + ", '" + report_mark_type + "')", True, "", "", "", "")

                    submit_who_prepared(report_mark_type, id_propose_promo, id_user)

                    form_load()

                    'reserved stock
                    For i = 0 To GVProduct.RowCount - 1
                        If GVProduct.IsValidRowHandle(i) Then
                            Dim id_wh_drawer_reserved As String = execute_query("
                                SELECT id_drawer_def FROM tb_m_comp WHERE id_comp = " + GVProduct.GetRowCellValue(i, "id_comp").ToString + "
                            ", 0, True, "", "", "", "")

                            Dim query_reserved As String = "INSERT INTO tb_storage_fg (id_wh_drawer, id_storage_category, id_product, bom_unit_price, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status, report_mark_type, id_report) VALUES ('" + id_wh_drawer_reserved + "', '2', '" + GVProduct.GetRowCellValue(i, "id_product").ToString + "', '" + decimalSQL(GVProduct.GetRowCellValue(i, "design_cop").ToString) + "', '" + decimalSQL(GVProduct.GetRowCellValue(i, "qty").ToString) + "', NOW(), 'Propose Promo: " + TENumber.EditValue.ToString + " / " + addSlashes(TENama.EditValue.ToString) + "', '2', '" + report_mark_type + "', '" + id_propose_promo + "')"

                            execute_non_query(query_reserved, True, "", "", "", "")
                        End If
                    Next

                    infoCustom("Submitted.")
                End If
            Else
                stopCustom("Please select product.")
            End If
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_propose_promo WHERE id_propose_promo = '" + id_propose_promo + "'", 0, True, "", "", "", "")

        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.id_report = id_propose_promo

        FormReportMark.ShowDialog()
    End Sub

    Sub form_load()
        Dim query_head As String = "
            SELECT p.number, p.nama, p.ktp, p.npwp, p.alamat, DATE_FORMAT(p.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, r.report_status
            FROM tb_propose_promo AS p
            LEFT JOIN tb_m_employee AS e ON p.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON p.id_report_status = r.id_report_status
            WHERE p.id_propose_promo = " + id_propose_promo + "
        "

        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")

        If data_head.Rows.Count > 0 Then
            TENumber.EditValue = data_head.Rows(0)("number").ToString
            TEReportStatus.EditValue = data_head.Rows(0)("report_status").ToString
            TENama.EditValue = data_head.Rows(0)("nama").ToString
            TEKTP.EditValue = data_head.Rows(0)("ktp").ToString
            TENPWP.EditValue = data_head.Rows(0)("npwp").ToString
            TECreatedAt.EditValue = data_head.Rows(0)("created_at").ToString
            TECreatedBy.EditValue = data_head.Rows(0)("created_by").ToString
            MEAlamat.EditValue = data_head.Rows(0)("alamat").ToString
        Else
            TENumber.EditValue = "[autogenerate]"
            TECreatedAt.EditValue = DateTime.Parse(Now()).ToString("dd MMMM yyyy HH:mm:ss")
            TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        End If

        Dim query_detail As String = "
            SELECT d.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, d.id_product, p.product_display_name AS name, p.product_full_code AS code, z.code_detail_name AS size, d.id_design_price, d.qty, e.design_cop, (d.qty * e.design_cop) AS design_cop_amount, d.design_price, (d.qty * d.design_price) AS design_price_amount
            FROM tb_propose_promo_det AS d
            LEFT JOIN tb_m_comp AS c ON d.id_comp = c.id_comp
            LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
            LEFT JOIN tb_m_design AS e ON p.id_design = e.id_design
            LEFT JOIN (
                SELECT c.id_product, d.code_detail_name
                FROM tb_m_product_code AS c
                LEFT JOIN tb_m_code_detail AS d ON d.id_code_detail = c.id_code_detail
            ) AS z ON d.id_product = z.id_product
            WHERE d.id_propose_promo = " + id_propose_promo + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCProduct.DataSource = data_detail

        GVProduct.BestFitColumns()

        'control
        If id_propose_promo = "0" Then
            TENama.ReadOnly = False
            TEKTP.ReadOnly = False
            TENPWP.ReadOnly = False
            MEAlamat.ReadOnly = False
            SBSubmit.Enabled = True
            SBPrint.Enabled = False
            SBAttachment.Enabled = False
            SBMark.Enabled = False
            SBAdd.Enabled = True
            SBRemove.Enabled = True
        Else
            TENama.ReadOnly = True
            TEKTP.ReadOnly = True
            TENPWP.ReadOnly = True
            MEAlamat.ReadOnly = True
            SBSubmit.Enabled = False
            SBPrint.Enabled = True
            SBAttachment.Enabled = True
            SBMark.Enabled = True
            SBAdd.Enabled = False
            SBRemove.Enabled = False
        End If
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_propose_promo WHERE id_propose_promo = '" + id_propose_promo + "'", 0, True, "", "", "", "")

        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_propose_promo
        FormDocumentUpload.report_mark_type = report_mark_type

        FormDocumentUpload.ShowDialog()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As New ReportProposePromo()

        report.id_propose_promo = id_propose_promo

        report.XLNumber.Text = TENumber.EditValue.ToString
        report.XLKTP.Text = TEKTP.EditValue.ToString
        report.XLNama.Text = TENama.EditValue.ToString
        report.XLNPWP.Text = TENPWP.EditValue.ToString
        report.XLCreatedAt.Text = TECreatedAt.EditValue.ToString
        report.XLCreatedBy.Text = TECreatedBy.EditValue.ToString
        report.XLAlamat.Text = MEAlamat.EditValue.ToString

        report.GCProduct.DataSource = GCProduct.DataSource

        report.GVProduct.BestFitColumns()

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub

    Sub create_too(id_report As String)
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_propose_promo WHERE id_propose_promo = '" + id_report + "'", 0, True, "", "", "", "")

        Dim group_id_comp As DataTable = execute_query("
            SELECT id_comp FROM tb_propose_promo_det WHERE id_propose_promo = '" + id_report + "' GROUP BY id_comp
        ", -1, True, "", "", "", "")

        For i = 0 To group_id_comp.Rows.Count - 1
            Dim id_comp As String = group_id_comp.Rows(i)("id_comp").ToString

            If id_comp <> "437" Then
                Dim id_sales_order As String = execute_query("
                    INSERT INTO tb_sales_order (id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created, id_emp_uni_period, id_uni_type, sales_order_ol_shop_number, sales_order_ol_shop_date, is_transfer_data, is_sync_stock, customer_name, id_propose_promo)
                    SELECT '611' AS id_store_contact_to, (SELECT id_comp_contact FROM tb_m_comp_contact WHERE id_comp = '" + id_comp + "' AND is_default = 1) AS id_warehouse_contact_to, '' AS sales_order_number, NOW() AS sales_order_date, CONCAT('Propose Promo: ', p.number, ' / ', p.nama) AS sales_order_note, '0' AS id_so_type, '6' AS id_report_status, '5' AS id_so_status, (SELECT MIN(id_user) FROM tb_m_user WHERE id_employee = p.created_by) AS id_user_created, NULL AS id_emp_uni_period, NULL AS id_uni_type, '' AS sales_order_ol_shop_number, NULL AS sales_order_ol_shop_date, '2' AS is_transfer_data, '2' AS is_sync_stock, NULL AS customer_name, '" + id_report + "' AS id_propose_promo
                    FROM tb_propose_promo AS p
                    WHERE p.id_propose_promo = '" + id_report + "';
                    SELECT LAST_INSERT_ID();
                ", 0, True, "", "", "", "")

                execute_non_query("
                    INSERT INTO tb_sales_order_det (id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note, item_id, ol_store_id, id_ol_promo_collection_sku_replace)
                    SELECT '" + id_sales_order + "' AS id_sales_order, d.id_product, d.id_design_price, d.design_price, d.qty AS sales_order_det_qty, '' AS sales_order_det_note, '' AS item_id, '' AS ol_store_id, NULL AS id_ol_promo_collection_sku_replace
                    FROM tb_propose_promo_det AS d
                    WHERE d.id_propose_promo = '" + id_report + "' AND d.id_comp = '" + id_comp + "';
                ", True, "", "", "", "")

                execute_non_query("
                    INSERT INTO tb_storage_fg (id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
                    (SELECT (SELECT id_drawer_def FROM tb_m_comp WHERE id_comp = d.id_comp) AS id_wh_drawer, '1' AS id_storage_category, d.id_product, s.design_cop AS bom_unit_price, '" + report_mark_type + "' AS report_mark_type, d.id_propose_promo AS id_report, d.qty AS storage_product_qty, NOW() AS storage_product_datetime, CONCAT('Propose Promo: ', o.number, ' / ', o.nama) AS storage_product_notes, '2' AS id_stock_status
                    FROM tb_propose_promo_det AS d
                    LEFT JOIN tb_propose_promo AS o ON d.id_propose_promo = o.id_propose_promo
                    LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
                    LEFT JOIN tb_m_design AS s ON p.id_design = s.id_design
                    WHERE d.id_propose_promo = '" + id_report + "' AND d.id_comp = '" + id_comp + "')
                    UNION ALL
                    (SELECT getCompByContact(so.id_warehouse_contact_to, 4) AS id_wh_drawer, '2' AS id_storage_category, so_det.id_product, IFNULL(dsg.design_cop, 0) AS bom_unit_price, '39' AS report_mark_type, '" + id_sales_order + "' AS id_report, so_det.sales_order_det_qty, NOW() AS storage_product_datetime, '' AS storage_product_notes, '2' AS id_stock_status
                    FROM tb_sales_order AS so
                    INNER JOIN tb_sales_order_det AS so_det ON so_det.id_sales_order = so.id_sales_order
                    INNER JOIN tb_m_product AS prod ON prod.id_product = so_det.id_product
                    INNER JOIN tb_m_design AS dsg ON dsg.id_design = prod.id_design
                    WHERE so.id_sales_order = '" + id_sales_order + "')
                ", True, "", "", "", "")
            End If
        Next
    End Sub

    Sub create_nmo(id_report As String)
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_propose_promo WHERE id_propose_promo = '" + id_report + "'", 0, True, "", "", "", "")

        Dim id_report_status As String = "6"

        Dim other_id_comp As DataTable = execute_query("
            SELECT id_comp FROM tb_propose_promo_det WHERE id_propose_promo = '" + id_report + "' AND id_comp <> 437
        ", -1, True, "", "", "", "")

        If other_id_comp.Rows.Count > 0 Then
            id_report_status = "1"
        End If

        Dim id_sales_order As String = execute_query("
            INSERT INTO tb_sales_order (id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created, id_emp_uni_period, id_uni_type, sales_order_ol_shop_number, sales_order_ol_shop_date, is_transfer_data, is_sync_stock, customer_name, id_propose_promo)
            SELECT '584' AS id_store_contact_to, '611' AS id_warehouse_contact_to, '' AS sales_order_number, NOW() AS sales_order_date, CONCAT('Propose Promo: ', p.number, ' / ', p.nama) AS sales_order_note, '0' AS id_so_type, '" + id_report_status + "' AS id_report_status, '3' AS id_so_status, (SELECT MIN(id_user) FROM tb_m_user WHERE id_employee = p.created_by) AS id_user_created, NULL AS id_emp_uni_period, NULL AS id_uni_type, '' AS sales_order_ol_shop_number, NULL AS sales_order_ol_shop_date, '2' AS is_transfer_data, '2' AS is_sync_stock, NULL AS customer_name, '" + id_report + "' AS id_propose_promo
            FROM tb_propose_promo AS p
            WHERE p.id_propose_promo = '" + id_report + "';
            SELECT LAST_INSERT_ID();
        ", 0, True, "", "", "", "")

        execute_non_query("
            INSERT INTO tb_sales_order_det (id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note, item_id, ol_store_id, id_ol_promo_collection_sku_replace)
            SELECT '" + id_sales_order + "' AS id_sales_order, d.id_product, d.id_design_price, d.design_price, d.qty AS sales_order_det_qty, '' AS sales_order_det_note, '' AS item_id, '' AS ol_store_id, NULL AS id_ol_promo_collection_sku_replace
            FROM tb_propose_promo_det AS d
            WHERE d.id_propose_promo = '" + id_report + "' AND d.id_comp = '437';
        ", True, "", "", "", "")

        execute_non_query("
            INSERT INTO tb_storage_fg (id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
            (SELECT (SELECT id_drawer_def FROM tb_m_comp WHERE id_comp = d.id_comp) AS id_wh_drawer, '1' AS id_storage_category, d.id_product, s.design_cop AS bom_unit_price, '" + report_mark_type + "' AS report_mark_type, d.id_propose_promo AS id_report, d.qty AS storage_product_qty, NOW() AS storage_product_datetime, CONCAT('Propose Promo: ', o.number, ' / ', o.nama) AS storage_product_notes, '2' AS id_stock_status
            FROM tb_propose_promo_det AS d
            LEFT JOIN tb_propose_promo AS o ON d.id_propose_promo = o.id_propose_promo
            LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
            LEFT JOIN tb_m_design AS s ON p.id_design = s.id_design
            WHERE d.id_propose_promo = '" + id_report + "' AND d.id_comp = '437')
            UNION ALL
            (SELECT getCompByContact(so.id_warehouse_contact_to, 4) AS id_wh_drawer, '2' AS id_storage_category, so_det.id_product, IFNULL(dsg.design_cop, 0) AS bom_unit_price, '39' AS report_mark_type, '" + id_sales_order + "' AS id_report, so_det.sales_order_det_qty, NOW() AS storage_product_datetime, '' AS storage_product_notes, '2' AS id_stock_status
            FROM tb_sales_order AS so
            INNER JOIN tb_sales_order_det AS so_det ON so_det.id_sales_order = so.id_sales_order
            INNER JOIN tb_m_product AS prod ON prod.id_product = so_det.id_product
            INNER JOIN tb_m_design AS dsg ON dsg.id_design = prod.id_design
            WHERE so.id_sales_order = '" + id_sales_order + "')
        ", True, "", "", "", "")

        execute_non_query("UPDATE tb_propose_promo SET id_sales_order = '" + id_sales_order + "' WHERE id_propose_promo = '" + id_report + "'", True, "", "", "", "")
    End Sub
End Class