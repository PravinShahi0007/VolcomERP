Public Class FormProductionStorageIn 
    Public id_design As String
    Public id_product As String
    Public id_sample As String
    Public action As String
    Public id_storage_fg As String
    Dim id_comp As String
    Dim id_design_price As String
    Dim currency_po As String
    Dim po_price As String
    Public id_pl_prod_order_rec_det As String
    Dim id_locator As String
    Dim id_rack As String
    Dim id_drawer As String
    Public colorku As String = ""
    Public sizeku As String = ""
    Public id_bomx As String = "0"
    Public bom_unit_pricex As Decimal
    Public jumx As Decimal
    Public id_report As String
    Public report_mark_type As String
    Public id_pop_up As String = "-1"

    Public id_transaction_det As String = "-1"
    Public cost As Decimal = 0.0
    Public id_wh As String = "-1"
    Public id_wh_origin As String = "-1"
    Public id_wh_drawer_origin As String = "-1"

    'fORM lOAD
    Private Sub FormProductionStorageIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = ""
        Dim data As DataTable

        'Load Image
        pre_viewImages("2", PictureEdit1, id_design, False)

        'Fill Lookup Edit
        viewComp()
        viewBom()

        If id_pop_up = "-1" Then
            'Load information
            If action = "ins" Then
                'Try
                query = "SELECT c1.prod_order_number, g.id_season, i.season, j.range, f.product_full_code, g.design_name, f.product_ean_code, g.id_sample, a.pl_prod_order_rec_det_qty, a.pl_prod_order_rec_det_qty_stored, "
                query += "a1.id_pl_prod_order_rec, a.id_pl_prod_order_rec_det, g.id_design, f.id_product FROM tb_pl_prod_order_rec_det a "
                query += "INNER JOIN tb_pl_prod_order_rec a1 ON a1.id_pl_prod_order_rec = a.id_pl_prod_order_rec "
                query += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det "
                query += "INNER JOIN tb_prod_order_det c ON c.id_prod_order_det = b.id_prod_order_det "
                query += "INNER JOIN tb_prod_order c1 ON c1.id_prod_order = c.id_prod_order "
                query += "INNER JOIN tb_prod_demand_product d ON c.id_prod_demand_product = d.id_prod_demand_product "
                query += "INNER JOIN tb_prod_demand_design e ON e.id_prod_demand_design = d.id_prod_demand_design "
                query += "INNER JOIN tb_m_product f ON f.id_product = d.id_product "
                query += "INNER JOIN tb_m_design g ON g.id_design = e.id_design "
                query += "INNER JOIN tb_m_sample h ON h.id_sample = g.id_sample "
                query += "INNER JOIN tb_season i ON i.id_season = g.id_season "
                query += "INNER JOIN tb_range j ON j.id_range = i.id_range "
                query += "WHERE a1.id_report_status !='5' AND a.id_pl_prod_order_rec_det = '" + id_pl_prod_order_rec_det + "' AND f.id_product = '" + id_product + "' "
                data = execute_query(query, -1, True, "", "", "", "")

                'get from query
                LabelCode.Text = data.Rows(0)("product_full_code").ToString
                LabelUSCode.Text = data.Rows(0)("product_ean_code").ToString
                LabelSampleName.Text = data.Rows(0)("design_name").ToString
                LabelSeasonOrign.Text = data.Rows(0)("season").ToString
                LabelRange.Text = data.Rows(0)("range").ToString
                LabelProdOrderNumb.Text = data.Rows(0)("prod_order_number").ToString

                'get from single main form
                LabelSize.Text = sizeku
                LabelColor.Text = colorku
                TxtCost.EditValue = cost

                Dim jum As Decimal = data.Rows(0)("pl_prod_order_rec_det_qty") - data.Rows(0)("pl_prod_order_rec_det_qty_stored")
                SPQtyLimit.EditValue = jum
                'Catch ex As Exception
                '    errorCustom(ex.ToString)
                '    Close()
                'End Try
            Else
                'Try
                LabelControl18.Visible = False
                LabelControl20.Visible = False
                LabelProdOrderNumb.Visible = False

                query += "SELECT a.product_full_code, a.product_ean_code, b.design_name,c.season, d.range "
                query += "FROM tb_m_product a "
                query += "INNER JOIN tb_m_design b ON a.id_design = b.id_design "
                query += "INNER JOIN tb_season c ON b.id_season = c.id_season "
                query += "INNER JOIN tb_range d ON c.id_range = d.id_range "
                query += "WHERE a.id_product = '" + id_product + "' "
                data = execute_query(query, -1, True, "", "", "", "")

                'get from query
                LabelCode.Text = data.Rows(0)("product_full_code").ToString
                LabelUSCode.Text = data.Rows(0)("product_ean_code").ToString
                LabelSampleName.Text = data.Rows(0)("design_name").ToString
                LabelSeasonOrign.Text = data.Rows(0)("season").ToString
                LabelRange.Text = data.Rows(0)("range").ToString

                'get from single main form
                LabelSize.Text = sizeku
                LabelColor.Text = colorku

                SPQtyLimit.EditValue = jumx
                SLEBOM.EditValue = Integer.Parse(id_bomx)
                SLEStorage.EditValue = FormMasterWH.SLEWHStockFG.EditValue
                SLELocator.EditValue = FormMasterWH.SLELocatorStockFG.EditValue
                SLERack.EditValue = FormMasterWH.SLERackStockFG.EditValue
                SLEDrawer.EditValue = FormMasterWH.SLEDrawerStockFG.EditValue
                'Catch ex As Exception
                '    errorCustom(ex.ToString)
                '    Close()
                'End Try
            End If
        ElseIf id_pop_up = "2" Then ' FROM RETURN
            Try
                query += "SELECT c.sales_return_number, g.id_season, i.season, j.range, f.product_full_code, g.design_name, f.product_ean_code, "
                query += "g.id_sample, a.sales_return_det_drawer_qty, a.sales_return_det_drawer_qty_stored,  "
                query += "c.id_sales_return, b.id_sales_return_det, g.id_design, f.id_product  "
                query += "FROM tb_sales_return_det_drawer a  "
                query += "INNER JOIN tb_sales_return_det b ON a.id_sales_return_det = b.id_sales_return_det  "
                query += "INNER JOIN tb_sales_return c ON c.id_sales_return = b.id_sales_return  "
                query += "INNER JOIN tb_m_product f ON f.id_product = b.id_product  "
                query += "INNER JOIN tb_m_design g ON g.id_design = f.id_design  "
                query += "INNER JOIN tb_m_sample h ON h.id_sample = g.id_sample  "
                query += "INNER JOIN tb_season i ON i.id_season = g.id_season  "
                query += "INNER JOIN tb_range j ON j.id_range = i.id_range  "
                query += "WHERE c.id_report_status !='5' AND a.id_sales_return_det_drawer = '" + id_transaction_det + "' AND f.id_product = '" + id_product + "' "
                data = execute_query(query, -1, True, "", "", "", "")

                'get from query
                LabelControl18.Text = "Return Number"
                LabelCode.Text = data.Rows(0)("product_full_code").ToString
                LabelUSCode.Text = data.Rows(0)("product_ean_code").ToString
                LabelSampleName.Text = data.Rows(0)("design_name").ToString
                LabelSeasonOrign.Text = data.Rows(0)("season").ToString
                LabelRange.Text = data.Rows(0)("range").ToString
                LabelProdOrderNumb.Text = data.Rows(0)("sales_return_number").ToString
                TxtCost.EditValue = cost

                'get from single main form
                LabelSize.Text = sizeku
                LabelColor.Text = colorku

                Dim jum As Decimal = data.Rows(0)("sales_return_det_drawer_qty") - data.Rows(0)("sales_return_det_drawer_qty_stored")
                SPQtyLimit.EditValue = jum
            Catch ex As Exception
                errorConnection()
                Close()
                Exit Sub
            End Try
        ElseIf id_pop_up = "3" Then
            'For return revision
        ElseIf id_pop_up = "4" Then
            Try
                query += "SELECT c.sales_return_qc_number, g.id_season, i.season, j.range, f.product_full_code, g.design_name, f.product_ean_code, "
                query += "g.id_sample, a.sales_return_qc_det_drawer_qty, a.sales_return_qc_det_drawer_qty_stored,  "
                query += "c.id_sales_return_qc, b.id_sales_return_qc_det, g.id_design, f.id_product  "
                query += "FROM tb_sales_return_qc_det_drawer a  "
                query += "INNER JOIN tb_sales_return_qc_det b ON a.id_sales_return_qc_det = b.id_sales_return_qc_det  "
                query += "INNER JOIN tb_sales_return_qc c ON c.id_sales_return_qc = b.id_sales_return_qc  "
                query += "INNER JOIN tb_m_product f ON f.id_product = b.id_product  "
                query += "INNER JOIN tb_m_design g ON g.id_design = f.id_design  "
                query += "INNER JOIN tb_m_sample h ON h.id_sample = g.id_sample  "
                query += "INNER JOIN tb_season i ON i.id_season = g.id_season  "
                query += "INNER JOIN tb_range j ON j.id_range = i.id_range  "
                query += "WHERE c.id_report_status !='5' AND a.id_sales_return_qc_det_drawer = '" + id_transaction_det + "' AND f.id_product = '" + id_product + "' "
                data = execute_query(query, -1, True, "", "", "", "")

                'get from query
                LabelControl18.Text = "Return QC Number"
                LabelCode.Text = data.Rows(0)("product_full_code").ToString
                LabelUSCode.Text = data.Rows(0)("product_ean_code").ToString
                LabelSampleName.Text = data.Rows(0)("design_name").ToString
                LabelSeasonOrign.Text = data.Rows(0)("season").ToString
                LabelRange.Text = data.Rows(0)("range").ToString
                LabelProdOrderNumb.Text = data.Rows(0)("sales_return_qc_number").ToString
                TxtCost.EditValue = cost

                'get from single main form
                LabelSize.Text = sizeku
                LabelColor.Text = colorku

                'get drawer origin 
                Dim query_find_drawer As String = ""
                query_find_drawer += "SELECT d.id_wh_drawer FROM tb_m_comp a "
                query_find_drawer += "INNER JOIN tb_m_wh_locator b ON a.id_comp = b.id_comp "
                query_find_drawer += "INNER JOIN tb_m_wh_rack c ON c.id_wh_locator = b.id_wh_locator "
                query_find_drawer += "INNER JOIN tb_m_wh_drawer d ON d.id_wh_rack = c.id_wh_rack "
                query_find_drawer += "WHERE a.id_comp = '" + id_wh_origin + "' "
                id_wh_drawer_origin = execute_query(query_find_drawer, 0, True, "", "", "", "")
                'MsgBox(id_wh_drawer_origin)

                Dim jum As Decimal = data.Rows(0)("sales_return_qc_det_drawer_qty") - data.Rows(0)("sales_return_qc_det_drawer_qty_stored")
                SPQtyLimit.EditValue = jum
            Catch ex As Exception
                errorConnection()
                Close()
                Exit Sub
            End Try
        ElseIf id_pop_up = "5" Then
            Try
                query += "SELECT c.fg_trf_number, g.id_season, i.season, j.range, f.product_full_code, g.design_name, f.product_ean_code, "
                query += "g.id_sample, b.fg_trf_det_qty_stored, b.fg_trf_det_qty,  "
                query += "c.id_fg_trf, b.id_fg_trf_det, g.id_design, f.id_product  "
                query += "FROM tb_fg_trf_det b "
                query += "INNER JOIN tb_fg_trf c ON c.id_fg_trf = b.id_fg_trf  "
                query += "INNER JOIN tb_m_product f ON f.id_product = b.id_product  "
                query += "INNER JOIN tb_m_design g ON g.id_design = f.id_design  "
                query += "INNER JOIN tb_m_sample h ON h.id_sample = g.id_sample  "
                query += "INNER JOIN tb_season i ON i.id_season = g.id_season  "
                query += "INNER JOIN tb_range j ON j.id_range = i.id_range  "
                query += "WHERE b.id_fg_trf_det = '" + id_transaction_det + "' AND f.id_product = '" + id_product + "' "
                data = execute_query(query, -1, True, "", "", "", "")

                'get from query
                LabelControl18.Text = "Transfer Number"
                LabelCode.Text = data.Rows(0)("product_full_code").ToString
                LabelUSCode.Text = data.Rows(0)("product_ean_code").ToString
                LabelSampleName.Text = data.Rows(0)("design_name").ToString
                LabelSeasonOrign.Text = data.Rows(0)("season").ToString
                LabelRange.Text = data.Rows(0)("range").ToString
                LabelProdOrderNumb.Text = data.Rows(0)("fg_trf_number").ToString
                TxtCost.EditValue = cost

                'get from single main form
                LabelSize.Text = sizeku
                LabelColor.Text = colorku

                Dim jum As Decimal = data.Rows(0)("fg_trf_det_qty") - data.Rows(0)("fg_trf_det_qty_stored")
                SPQtyLimit.EditValue = jum
            Catch ex As Exception
                errorConnection()
                Close()
                Exit Sub
            End Try
        End If
    End Sub

    'view BOM
    Sub viewBom()
        Try
            Dim query As String = "SELECT a.id_bom, a.bom_name, COALESCE(a.bom_unit_price, 0) AS bom_unit_price, b.term_production, a.bom_date_created FROM tb_bom a "
            query += "INNER JOIN tb_lookup_term_production b ON a.id_term_production = b.id_term_production "
            query += "WHERE a.id_product = '" + id_product + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEBOM.Properties.DataSource = Nothing
            SLEBOM.Properties.DataSource = data
            SLEBOM.Properties.DisplayMember = "bom_unit_price"
            SLEBOM.Properties.ValueMember = "id_bom"
            If data.Rows.Count.ToString >= 1 Then
                SLEBOM.EditValue = data.Rows(0)("id_bom").ToString
            Else
                SLEBOM.EditValue = Nothing
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    'View Company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        If id_wh <> "-1" Then
            query += "WHERE a.id_comp = '" + id_wh + "' "
        End If
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub
    'View Price
    Sub viewPrice()

    End Sub

    'View Locator
    Sub viewLoactor()
        Dim id_comp As String = ""
        Try
            id_comp = SLEStorage.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query = "SELECT * FROM tb_m_wh_locator a WHERE id_comp = '" + id_comp + "'"
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    'View Rack
    Sub viewRack()
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    'View Drawer
    Sub viewDrawer()
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    'Rekursif Comp-Locator
    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        viewLoactor()
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        viewRack()
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        viewDrawer()
    End Sub
    'View Image Picture
    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        Try
            pre_viewImages("2", PictureEdit1, id_design, True)
        Catch ex As Exception
        End Try
    End Sub
    'Cancel Butrton
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Form Closed
    Private Sub FormProductionStorageIn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Kurs Changed
    Private Sub SPKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPKurs.EditValueChanged
        Try
            Dim po_price_dec As Decimal = Decimal.Parse(po_price)
            Dim kurs, price As Decimal
            If SPKurs.Text.ToString = "" Or SPKurs.Text.ToString = "0" Then
                kurs = 0
                TxtPrice.Text = "0"
            Else
                kurs = Decimal.Parse(SPKurs.Text)
                price = kurs * po_price_dec
                TxtPrice.Text = price.ToString("0.00")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLEDrawer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLEDrawer.Validating
        EP_SLE_cant_blank(EPStoredSample, SLEDrawer)
    End Sub
    Sub validateMyForm()
        Try
            Dim qty_save As Decimal = Decimal.Parse(SPQtySaved.EditValue)
            Dim qty_limit As Decimal = Decimal.Parse(SPQtyLimit.EditValue)
            If qty_save > qty_limit Or qty_save = 0.0 Or qty_save = 0 Then
                EPStoredSample.SetError(SPQtySaved, "- Qty saved must be smaller than qty limit or equal to qty limit ! " + System.Environment.NewLine + "- Qty must higher than 0 ")
            Else
                EPStoredSample.SetError(SPQtySaved, String.Empty)
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Save
    Private Sub BtnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveNew.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPStoredSample, GroupControlLocator) Then
            errorInput()
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save finished goods in this locator?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_wh_locator As String = SLELocator.EditValue.ToString
                Dim id_wh_drawer As String = SLEDrawer.EditValue.ToString
                Dim id_dc As String = "1"
                Dim id_bom As String = SLEBOM.EditValue.ToString
                Dim bom_unit_price As String = decimalSQL(SLEBOM.Properties.GetDisplayValueByKeyValue(SLEBOM.EditValue).ToString)
                Dim query As String
                Dim storage_product_qty As String = decimalSQL(SPQtySaved.EditValue.ToString)
                Dim storage_product_notes As String = MEStored.Text
                Dim cost As String = decimalSQL(TxtCost.EditValue.ToString)

                'action
                If id_pop_up = "-1" Then
                    If action = "ins" Then
                        Try
                            'insert to tble storage
                            query = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, storage_product_datetime, id_product, storage_product_qty, storage_product_notes, bom_unit_price, id_report, report_mark_type, id_stock_status) "
                            query += "VALUES ('" + id_wh_drawer + "', '" + id_dc + "',  NOW(), '" + id_product + "', '" + storage_product_qty + "', '" + storage_product_notes + "', '" + cost + "', '" + id_report + "', '" + report_mark_type + "', '1') "
                            execute_non_query(query, True, "", "", "", "")

                            'Update store
                            query = "UPDATE tb_pl_prod_order_rec_det SET pl_prod_order_rec_det_qty_stored = pl_prod_order_rec_det_qty_stored + " + storage_product_qty + " WHERE id_pl_prod_order_rec_det = '" + id_pl_prod_order_rec_det + "'"
                            execute_non_query(query, True, "", "", "", "")

                            FormProductionPLToWHRecDet.viewDetail()
                            Close()
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    ElseIf action = "upd" Then
                        'Try
                        query = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, storage_product_datetime, id_product, storage_product_qty, storage_product_notes, id_bom, bom_unit_price) "
                        query += "VALUES ('" + FormMasterWH.SLEDrawerStockFG.EditValue.ToString + "', '2',  NOW(), '" + id_product + "', '" + storage_product_qty + "', '" + storage_product_notes + "', '" + id_bomx + "', '" + bom_unit_pricex.ToString + "') "
                        execute_non_query(query, True, "", "", "", "")

                        query = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, storage_product_datetime, id_product, storage_product_qty, storage_product_notes, id_bom, bom_unit_price) "
                        query += "VALUES ('" + id_wh_drawer + "', '1',  NOW(), '" + id_product + "', '" + storage_product_qty + "', '" + storage_product_notes + "', '" + id_bom + "', '" + bom_unit_price + "') "
                        execute_non_query(query, True, "", "", "", "")

                        FormMasterWH.viewFGStorage()
                        Close()
                        'Catch ex As Exception
                        '    errorConnection()
                        'End Try
                    End If
                ElseIf id_pop_up = "2" Then
                    If action = "ins" Then
                        Try
                            'insert to tble storage
                            query = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, storage_product_datetime, id_product, storage_product_qty, storage_product_notes, bom_unit_price, id_report, report_mark_type, id_stock_status) "
                            query += "VALUES ('" + id_wh_drawer + "', '" + id_dc + "',  NOW(), '" + id_product + "', '" + storage_product_qty + "', '" + storage_product_notes + "', '" + cost + "', '" + id_report + "', '" + report_mark_type + "', '1') "
                            execute_non_query(query, True, "", "", "", "")

                            'Update store
                            query = "UPDATE tb_sales_return_det_drawer SET sales_return_det_drawer_qty_stored = sales_return_det_drawer_qty_stored + " + storage_product_qty + " WHERE id_sales_return_det_drawer = '" + id_transaction_det + "'"
                            execute_non_query(query, True, "", "", "", "")

                            Close()
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    End If
                ElseIf id_pop_up = "3" Then
                    'FOR RETURN REVISION -> AFTER ACCOUNTING POSTING
                ElseIf id_pop_up = "4" Then
                    If action = "ins" Then
                        Try
                            'insert to tble storage
                            Dim queryx As String = ""
                            queryx = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, storage_product_datetime, id_product, storage_product_qty, storage_product_notes, bom_unit_price, id_report, report_mark_type, id_stock_status) VALUES "
                            queryx += "('" + id_wh_drawer_origin + "', '2',  NOW(), '" + id_product + "', '" + storage_product_qty + "', '" + storage_product_notes + "', '" + cost + "', '" + FormSalesReturnQCDet.id_sales_return + "', '46', '1'), "
                            queryx += "('" + id_wh_drawer + "', '" + id_dc + "',  NOW(), '" + id_product + "', '" + storage_product_qty + "', '" + storage_product_notes + "', '" + cost + "', '" + id_report + "', '" + report_mark_type + "', '1') "
                            execute_non_query(queryx, True, "", "", "", "")

                            'Update store
                            Dim querya As String = ""
                            querya = "UPDATE tb_sales_return_qc_det_drawer SET sales_return_qc_det_drawer_qty_stored = sales_return_qc_det_drawer_qty_stored + " + storage_product_qty + " WHERE id_sales_return_qc_det_drawer = '" + id_transaction_det + "'"
                            execute_non_query(querya, True, "", "", "", "")
                            '

                            FormSalesReturnQCDet.viewDetailDrawer()
                            Close()
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    End If
                ElseIf id_pop_up = "5" Then
                    If action = "ins" Then
                        Cursor = Cursors.WaitCursor
                        Try
                            'insert to tble storage
                            query = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, storage_product_datetime, id_product, storage_product_qty, storage_product_notes, bom_unit_price, id_report, report_mark_type, id_stock_status) "
                            query += "VALUES ('" + id_wh_drawer + "', '1',  NOW(), '" + id_product + "', '" + storage_product_qty + "', '" + storage_product_notes + "', '" + cost + "', '" + id_report + "', '" + report_mark_type + "', '1') "
                            execute_non_query(query, True, "", "", "", "")

                            'Update store
                            Dim querya As String = ""
                            querya = "UPDATE tb_fg_trf_det SET fg_trf_det_qty_stored = fg_trf_det_qty_stored + " + storage_product_qty + " WHERE id_fg_trf_det = '" + id_transaction_det + "'"
                            execute_non_query(querya, True, "", "", "", "")

                            FormFGTrfDet.viewDetail()
                            Close()
                        Catch ex As Exception
                            errorConnection()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub


    Private Sub SPQtySaved_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtySaved.EditValueChanged
        validateMyForm()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        'MsgBox(decimalSQL(TxtCost.EditValue.ToString))
    End Sub

    Private Sub SLEStorage_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLEStorage.Validating
        EP_SLE_cant_blank(EPStoredSample, SLEStorage)
    End Sub

    Private Sub SPQtySaved_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SPQtySaved.Validating
        validateMyForm()
    End Sub

    Private Sub SLELocator_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLELocator.Validating
        EP_SLE_cant_blank(EPStoredSample, SLELocator)
    End Sub

    Private Sub SLERack_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLERack.Validating
        EP_SLE_cant_blank(EPStoredSample, SLERack)
    End Sub
End Class