Public Class FormPopUpSampleAdj 
    Public id_pop_up As String
    Public id_comp_from, id_wh, action As String
    Public id_sample_edit As String
    Dim id_sample_old As String
    Public id_wh_rack_edit, id_wh_locator_edit, id_wh_drawer_edit, adj_x_sample_det_note As String
    Public adj_x_sample_det_qty, adj_x_sample_det_price, adj_x_sample_det_kurs As Decimal
    Dim ketemu As Boolean = False
    Public indeks_edit As Integer
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_adj_x_sample_det As String
    Dim id_sample_price_selected As String
    '--------------------------------

    'Form
    Private Sub FormSampleReturnPickSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewWHStock()
        viewStock()
        If action = "upd" Then
            SLEWH.EditValue = id_wh
            SLELocator.EditValue = id_wh_locator_edit
            SLERack.EditValue = id_wh_rack_edit
            SLEDrawer.EditValue = id_wh_drawer_edit
            'TxtCost.EditValue = adj_x_sample_det_price / adj_x_sample_det_kurs
            'TxtKurs.EditValue = adj_x_sample_det_kurs
            'TxtRealCost.EditValue = adj_x_sample_det_price
            SPQtyPL.EditValue = adj_x_sample_det_qty
            MENote.Text = adj_x_sample_det_note.ToString
        ElseIf action = "ins" Then
            TxtKurs.EditValue = 1
            SPQtyPL.EditValue = 1
        End If
    End Sub
    Private Sub FormSampleReturnPickSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View
    Sub viewStock()
        'Updated 17 October 2014
        Dim query As String = "CALL view_sample()"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim i As Integer = data.Rows.Count - 1
        GCSample.DataSource = data
        viewCost()
        viewImg()
        chooseCondition()

        If action = "ins" Then
            checkExistInput()
        End If
    End Sub
    Sub viewCost()
        'Updated 17 Oktober 2014
        Dim id_sample As String = "-1"
        Try
            id_sample = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        Dim query As String = ""
        query += "SELECT a.id_sample_price, (a.sample_price) AS cost, a.sample_price_name, a.sample_price_date, c.comp_name, c1.currency  FROM tb_m_sample_price a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact = b.id_comp_contact "
        query += "INNER JOIN tb_lookup_currency c1 ON c1.id_currency = a.id_currency "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp WHERE a.id_sample='" + id_sample + "' AND a.id_currency = '" + FormSampleAdjustmentInSingle.LECurrency.EditValue.ToString + "' AND a.is_default_cost='1' ORDER BY sample_price_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCost.DataSource = data
        getCostCursored()
        chooseCondition()
    End Sub
    Sub getCostCursored()
        Dim cost_cursor As Decimal = 0.0
        'Try
        cost_cursor = Decimal.Parse(GVCost.GetFocusedRowCellValue("cost"))
        'Catch ex As Exception
        'End Try
        TxtRealCost.EditValue = cost_cursor
        id_sample_price_selected = 0
        'Try
        id_sample_price_selected = GVCost.GetFocusedRowCellValue("id_sample_price").ToString
        ' Catch ex As Exception
        'End Try
    End Sub
    Sub viewImg()
        Try
            Dim id_sample As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
            pre_viewImages("1", PictureEdit1, id_sample, False)
        Catch ex As Exception

        End Try
    End Sub
    Sub viewWHStock()
        Dim query As String = ""
        'get id category on opt
        query = "SELECT id_comp_cat_wh FROM tb_opt "
        Dim id_comp_cat_wh As String = execute_query(query, 0, True, "", "", "", "")

        'view data comp/warehouse
        query = ""
        query += "SELECT a.id_comp, a.comp_number, a.comp_name FROM tb_m_comp a WHERE a.id_comp_cat = '" + id_comp_cat_wh + "'  "
        If id_wh <> "-1" Then
            query += "AND a.id_comp = '" + id_wh + "' "
        End If
        query += "AND a.id_departement='" + id_departement_user + "' "
        query += "ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub
    Sub viewWHLocatorSLE()
        Dim id_comp As String = ""
        Try
            id_comp = SLEWH.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Sub viewWHRack()
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = ""
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Sub viewWHDrawer()
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = ""
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    'Button Actoion
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        'UPDATED 17 Oktober 2014

        Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyPL.EditValue)
        If qty_input_grid > 0 Then
            If action = "ins" Then
                'Edit di Induk insert save langsung ke db
                checkExistInput()
                If Not ketemu Then
                    If id_adj_x_sample_det <> "0" Then
                        'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process, are you sure to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        'If confirm = Windows.Forms.DialogResult.Yes Then
                        '    If id_pop_up = "1" Then 'Ins DB Adj In
                        '        Dim query_ins_return_det As String = "INSERT tb_adj_in_sample_det(id_adj_in_sample, adj_in_sample_det_note, adj_in_sample_det_qty, id_wh_drawer, id_sample, adj_in_sample_det_kurs, adj_in_sample_det_price) "
                        '        query_ins_return_det += "VALUES('" + FormSampleAdjustmentInSingle.id_adj_in_sample + "','" + MENote.Text + "', '" + decimalSQL(SPQtyPL.EditValue.ToString) + "', '" + SLEDrawer.EditValue.ToString + "', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + decimalSQL(TxtKurs.EditValue.ToString) + "', '" + decimalSQL(TxtRealCost.EditValue.ToString) + "') "
                        '        execute_non_query(query_ins_return_det, True, "", "", "", "")
                        '        Dim id_adj_in_sample_det_new As String = execute_query("SELECT LAST_INSERT_ID()", 0, True, "", "", "", "")

                        '        Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                        '        query_upd_storage += "VALUES('" + SLEDrawer.EditValue.ToString + "', '1', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + decimalSQL(SPQtyPL.EditValue.ToString) + "', NOW(), 'Data Edited, Adjustment In Sample No. : " + FormSampleAdjustmentInSingle.TxtAdjNumber.Text + "')"
                        '        execute_non_query(query_upd_storage, True, "", "", "", "")

                        '        FormSampleAdjustmentInSingle.newRows()
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_adj_in_sample_det", id_adj_in_sample_det_new)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("sample_name").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("Size").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("sample_code").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_qty", qty_input_grid)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_price", TxtRealCost.EditValue)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_kurs", TxtKurs.EditValue)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_amount", TxtAmount.EditValue)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_note", MENote.Text)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                        '        FormSampleAdjustmentInSingle.GVDetail.CloseEditor()
                        '        FormSampleAdjustmentInSingle.GCDetail.RefreshDataSource()
                        '        FormSampleAdjustmentInSingle.GVDetail.RefreshData()
                        '        Close()
                        '    End If
                        'End If
                    Else
                        If id_pop_up = 1 Then 'Ins Standard Adj In
                            FormSampleAdjustmentInSingle.newRows()
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_adj_in_sample_det", "0")
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("sample_name").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("Size").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("sample_code").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("color", GVSample.GetFocusedRowCellValue("Color").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_qty", qty_input_grid)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_price", TxtRealCost.EditValue)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_sample_price", id_sample_price_selected)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_kurs", TxtKurs.EditValue)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_amount", TxtAmount.EditValue)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_note", MENote.Text)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormSampleAdjustmentInSingle.GVDetail.CloseEditor()
                            FormSampleAdjustmentInSingle.GCDetail.RefreshDataSource()
                            FormSampleAdjustmentInSingle.GVDetail.RefreshData()
                            'get total (Updated 17 Oktober 2014)
                            FormSampleAdjustmentInSingle.total_amount = Double.Parse(FormSampleAdjustmentInSingle.GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.SummaryValue.ToString)
                            FormSampleAdjustmentInSingle.METotSay.Text = ConvertCurrencyToEnglish(FormSampleAdjustmentInSingle.total_amount, FormSampleAdjustmentInSingle.LECurrency.EditValue.ToString)
                            Close()
                        End If
                    End If
                Else
                    errorCustom("This sample already exist in Adjustment List !")
                End If
            ElseIf action = "upd" Then
                If Not ketemu Then
                    'Edit di Induk update save langsung ke db
                    If id_adj_x_sample_det <> "0" Then
                        'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process, are you sure to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        'If confirm = Windows.Forms.DialogResult.Yes Then
                        '    If id_pop_up = "1" Then 'Edit DB Adj In
                        '        Dim query_upd_return_det As String = "UPDATE tb_adj_in_sample_det SET id_sample = '" + GVSample.GetFocusedRowCellValue("id_sample").ToString + "' ,id_adj_in_sample = '" + FormSampleAdjustmentInSingle.id_adj_in_sample + "',adj_in_sample_det_note = '" + MENote.Text + "', adj_in_sample_det_qty = '" + decimalSQL(SPQtyPL.EditValue.ToString) + "', id_wh_drawer = '" + SLEDrawer.EditValue.ToString + "', adj_in_sample_det_kurs = '" + decimalSQL(TxtKurs.EditValue) + "', adj_in_sample_det_price = '" + decimalSQL(TxtRealCost.EditValue.ToString) + "' WHERE id_adj_in_sample_det = '" + id_adj_x_sample_det + "' "
                        '        execute_non_query(query_upd_return_det, True, "", "", "", "")
                        '        Dim query_upd_storage1 As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                        '        query_upd_storage1 += "VALUES('" + id_wh_drawer_edit.ToString + "', '2', '" + id_sample_edit + "', '" + adj_x_sample_det_qty.ToString + "', NOW(), 'Data Edited, Adjustment In Sample No. : " + FormSampleAdjustmentInSingle.TxtAdjNumber.Text + "')"
                        '        execute_non_query(query_upd_storage1, True, "", "", "", "")
                        '        Dim query_upd_storage2 As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                        '        query_upd_storage2 += "VALUES('" + SLEDrawer.EditValue.ToString + "', '1', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + decimalSQL(SPQtyPL.EditValue.ToString) + "', NOW(), 'Data Edited, Adjustment In Sample No. : " + FormSampleAdjustmentInSingle.TxtAdjNumber.Text + "')"
                        '        execute_non_query(query_upd_storage2, True, "", "", "", "")

                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_adj_in_sample_det", id_adj_x_sample_det)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("sample_name").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("Size").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("sample_code").ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_qty", qty_input_grid)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_price", TxtRealCost.EditValue)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_kurs", TxtKurs.EditValue)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_amount", TxtAmount.EditValue)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_note", MENote.Text)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                        '        FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                        '        FormSampleAdjustmentInSingle.GVDetail.CloseEditor()
                        '        FormSampleAdjustmentInSingle.GCDetail.RefreshDataSource()
                        '        FormSampleAdjustmentInSingle.GVDetail.RefreshData()
                        '        Close()
                        '    ElseIf id_pop_up = "2" Then 'Edit DB Adj Out

                        '    End If
                        'End If
                    Else
                        If id_pop_up = "1" Then 'Edit Standard Adj In
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_adj_in_sample_det", "0")
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("sample_name").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("Size").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("sample_code").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("color", GVSample.GetFocusedRowCellValue("Color").ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_qty", qty_input_grid)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_price", TxtRealCost.EditValue)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_sample_price", id_sample_price_selected)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_kurs", TxtKurs.EditValue)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_amount", TxtAmount.EditValue)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("adj_in_sample_det_note", MENote.Text)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormSampleAdjustmentInSingle.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormSampleAdjustmentInSingle.GVDetail.CloseEditor()
                            FormSampleAdjustmentInSingle.GCDetail.RefreshDataSource()
                            FormSampleAdjustmentInSingle.GVDetail.RefreshData()
                            'get total (Updated 17 Oktober 2014)
                            FormSampleAdjustmentInSingle.total_amount = Double.Parse(FormSampleAdjustmentInSingle.GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.SummaryValue.ToString)
                            FormSampleAdjustmentInSingle.METotSay.Text = ConvertCurrencyToEnglish(FormSampleAdjustmentInSingle.total_amount, FormSampleAdjustmentInSingle.LECurrency.EditValue.ToString)
                            Close()
                        End If
                    End If
                Else
                    errorCustom("This sample already exist in Adjustment List !")
                End If
            End If
            FormSampleAdjustmentInSingle.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
            FormSampleAdjustmentInSingle.total_amount = Double.Parse(FormSampleAdjustmentInSingle.GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.SummaryValue.ToString)
            FormSampleAdjustmentInSingle.METotSay.Text = ConvertCurrencyToEnglish(FormSampleAdjustmentInSingle.total_amount, FormSampleAdjustmentInSingle.LECurrency.EditValue.ToString)
        Else
            errorCustom("Qty not allowed zero value ! ")
        End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

    End Sub
    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Try
            Dim id_sample As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
            pre_viewImages("1", PictureEdit1, id_sample, True)
        Catch ex As Exception
        End Try
    End Sub

    'GridView
    Private Sub GVSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSample.RowClick
        
    End Sub

    'SLE EVENT
    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        Try
            'MsgBox("Load Locator")
            viewWHLocatorSLE()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        Try
            'MsgBox("Load Rack")
            viewWHRack()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Try
            'MsgBox("Load Drawer")
            viewWHDrawer()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SLEDrawer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawer.EditValueChanged
        Try
            chooseCondition()
            checkExistInput()
        Catch ex As Exception

        End Try
    End Sub

    'Aneka Function
    Sub chooseCondition()
        Dim id_sample As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        If SLEDrawer.EditValue Is Nothing Or id_sample = "" Then
            'MsgBox("Kosong")
            BtnChoose.Enabled = False
            LabelAttention.Text = "Drawer is not available this time"
            LabelAttention.Visible = True
            SPQtyPL.Enabled = False
            MENote.Enabled = False
            TxtCost.Enabled = False
            TxtKurs.Enabled = False
        Else
            'MsgBox("Isi")
            BtnChoose.Enabled = True
            LabelAttention.Visible = False
            SPQtyPL.Enabled = True
            MENote.Enabled = True
            TxtCost.Enabled = True
            TxtKurs.Enabled = True
        End If
        If TxtRealCost.EditValue = 0.0 Then
            BtnChoose.Enabled = False
            LabelAttention.Text = "Price can't blank"
            LabelAttention.Visible = True
            MENote.Enabled = False
            TxtCost.Enabled = False
            TxtKurs.Enabled = False
        Else
            'MsgBox("Isi")
            BtnChoose.Enabled = True
            LabelAttention.Visible = False
            MENote.Enabled = True
            TxtCost.Enabled = True
            TxtKurs.Enabled = True
        End If
    End Sub

    Sub checkExistInput()
        'UPDATED 17 OCTOBER 2014
        ketemu = False
        Try
            Dim id_sample_cek As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
            Dim id_wh_drawer_cek As String = SLEDrawer.EditValue.ToString
            For i As Integer = 0 To (FormSampleAdjustmentInSingle.GVDetail.RowCount - 1)
                Try
                    Dim id_sample_data As String = FormSampleAdjustmentInSingle.GVDetail.GetRowCellValue(i, "id_sample")
                    Dim id_sample_price_data As String = FormSampleAdjustmentInSingle.GVDetail.GetRowCellValue(i, "id_sample_price")
                    Dim id_wh_drawer_data As String = FormSampleAdjustmentInSingle.GVDetail.GetRowCellValue(i, "id_wh_drawer")
                    If id_sample_data <> "" Then
                        If action = "ins" Then
                            If id_sample_cek = id_sample_data And id_wh_drawer_cek = id_wh_drawer_data And id_sample_price_selected = id_sample_price_data Then
                                ketemu = True
                                Exit For
                            End If
                        ElseIf action = "upd" Then
                            If id_sample_cek = id_sample_data And id_wh_drawer_cek = id_wh_drawer_data And id_sample_price_selected = id_sample_price_data And i <> indeks_edit Then
                                ketemu = True
                                Exit For
                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception
            chooseCondition()
        End Try
    End Sub

    Private Sub GVSample_BeforeLeaveRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GVSample.BeforeLeaveRow
        id_sample_old = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
    End Sub

    Private Sub GVSample_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSample.DoubleClick
        'FormInfoDrawer.id_sample = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        'FormInfoDrawer.LabelSubTitle.Text = GVSample.GetFocusedRowCellDisplayText("sample_code").ToString + "/" + GVSample.GetFocusedRowCellDisplayText("sample_name").ToString
        'FormInfoDrawer.ShowDialog()
    End Sub

    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        viewCost()
        viewImg()
        'TxtRealCost.EditValue = 0.0
        chooseCondition()
        checkExistInput()
        Cursor = Cursors.Default
    End Sub
    Sub getRealCost()
        ' Try
        Dim po_price_dec As Decimal = TxtCost.EditValue
        Dim kurs, price As Decimal
        kurs = TxtKurs.EditValue
        'MsgBox(TxtKurs.EditValue)
        price = kurs * po_price_dec
        ' TxtRealCost.EditValue = price
        'Catch ex As Exception

        'End Try
    End Sub

    Sub getAmount()
        Dim qty As Decimal = Decimal.Parse(SPQtyPL.EditValue)
        Dim cost As Decimal = Decimal.Parse(TxtRealCost.EditValue)
        TxtAmount.EditValue = qty * cost
    End Sub

    Private Sub GVCost_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVCost.FocusedColumnChanged

    End Sub

    Private Sub GVCost_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCost.FocusedRowChanged
        getCostCursored()
        chooseCondition()
    End Sub

    'Private Sub TxtAmount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAmount.EditValueChanged
    '    Dim qty As Decimal = Decimal.Parse(SPQtyPL.EditValue.ToString)
    '    Dim real_cost As Decimal = Decimal.Parse(TxtRealCost.EditValue.ToString)
    '    TxtAmount.EditValue = qty * real_cost
    'End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        MsgBox(TxtCost.EditValue)
    End Sub

    Private Sub TxtCost_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCost.EditValueChanged
        getRealCost()
    End Sub

    Private Sub TxtKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKurs.EditValueChanged
        getRealCost()
    End Sub

    Private Sub SPQtyPL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtyPL.EditValueChanged
        getAmount()
    End Sub

    Private Sub TxtRealCost_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRealCost.EditValueChanged
        getAmount()
    End Sub

    Private Sub BtnGetCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetCost.Click
        getCostCursored()
        chooseCondition()
    End Sub

    Private Sub GVSample_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSample.ColumnFilterChanged
        viewCost()
        viewImg()
        ' TxtRealCost.EditValue = 0.0
        chooseCondition()
        checkExistInput()
    End Sub
End Class