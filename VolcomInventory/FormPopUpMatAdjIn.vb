Public Class FormPopUpMatAdjIn 
    Public id_pop_up As String
    Dim mat_image_path As String = get_setup_field("pic_path_mat") & "\"
    Public id_comp_from, id_wh, action As String
    Public id_mat_det_edit, id_mat_det_price_edit As String
    Dim id_mat_det_old As String
    Public id_wh_rack_edit, id_wh_locator_edit, id_wh_drawer_edit, adj_x_mat_det_note As String
    Public adj_x_mat_det_qty, adj_x_mat_det_price As Decimal
    Public adj_x_mat_det_kurs As Decimal = 1.0
    Dim ketemu As Boolean = False
    Public indeks_edit As Integer
    Public cond_check As Boolean = True
    Public mat_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_adj_x_mat_det As String
    '--------------------------------

    'Form
    Private Sub FormPopUpMatAdjIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewWHStock()
        viewStock()
        If action = "upd" Then
            SLEWH.EditValue = id_wh
            SLELocator.EditValue = id_wh_locator_edit
            SLERack.EditValue = id_wh_rack_edit
            SLEDrawer.EditValue = id_wh_drawer_edit
            TxtCost.EditValue = adj_x_mat_det_price / adj_x_mat_det_kurs
            TxtKurs.EditValue = adj_x_mat_det_kurs
            TxtRealCost.EditValue = adj_x_mat_det_price
            SPQtyPL.EditValue = adj_x_mat_det_qty
            MENote.Text = adj_x_mat_det_note.ToString
            GVMat.FocusedRowHandle = find_row(GVMat, "id_mat_det", id_mat_det_edit)
        ElseIf action = "ins" Then
            TxtKurs.EditValue = 1
        End If
    End Sub
    Private Sub FormPopUpMatAdjIn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View
    Sub viewStock()
        Dim query As String = "CALL view_mat()"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim i As Integer = data.Rows.Count - 1
        GCMat.DataSource = data
        viewCost()
        viewImg()
        chooseCondition()
        If action = "ins" Then
            checkExistInput()
        End If
    End Sub
    Sub viewCost()
        Dim id_mat_det As String = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
        Dim query As String = "SELECT tb_lookup_currency.currency,tb_m_mat_det_price.id_mat_det_price,tb_m_mat_det_price.mat_det_price_name,tb_m_mat_det_price.mat_det_price,tb_m_mat_det_price.mat_det_price_date FROM tb_m_mat_det_price,tb_lookup_currency WHERE tb_m_mat_det_price.id_currency=tb_lookup_currency.id_currency AND tb_m_mat_det_price.id_mat_det='" & id_mat_det & "' AND tb_m_mat_det_price.is_default_cost='1' ORDER BY tb_m_mat_det_price.id_mat_det_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPrice.DataSource = data
        If GVMatPrice.RowCount > 0 Then
            If action = "upd" Then
                GVMatPrice.FocusedRowHandle = find_row(GVMatPrice, "id_mat_det_price", id_mat_det_price_edit)
            End If
            getCostCursored()
            BtnChoose.Enabled = True
            SPQtyPL.Enabled = True
            MENote.Enabled = True
        Else
            TxtCost.EditValue = 0
            BtnChoose.Enabled = False
            SPQtyPL.Enabled = False
            MENote.Enabled = False
            TxtCost.EditValue = 0
            TxtAmount.EditValue = 0
            SPQtyPL.EditValue = 0
        End If
    End Sub
    Sub getCostCursored()
        Try
            Dim cost_cursor As Decimal = Decimal.Parse(GVMatPrice.GetFocusedRowCellValue("mat_det_price"))
            TxtRealCost.EditValue = cost_cursor
        Catch ex As Exception
        End Try
    End Sub
    Sub viewImg()
        Try
            Dim id_mat_det As String = GVmat.GetFocusedRowCellDisplayText("id_mat_det").ToString
            If System.IO.File.Exists(mat_image_path & id_mat_det & ".jpg") Then
                PictureEdit1.LoadAsync(mat_image_path & id_mat_det & ".jpg")
            Else
                PictureEdit1.LoadAsync(mat_image_path & "default" & ".jpg")
            End If
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
        query += "SELECT a.id_comp, a.comp_number, a.comp_name FROM tb_m_comp a WHERE a.id_comp_cat = '" + id_comp_cat_wh + "' "
        'If id_wh <> "-1" Then
        '    query += "AND a.id_comp = '" + id_wh + "' "
        'End If
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
        Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyPL.EditValue)
        If qty_input_grid > 0 Then
            If action = "ins" Then
                'Edit di Induk insert save langsung ke db
                checkExistInput()
                If Not ketemu Then
                    If id_adj_x_mat_det <> "0" Then
                        If id_pop_up = "1" Then 'edit
                            FormMatAdjInSingle.newRows()
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_mat_det_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("mat_name").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("size", GVMat.GetFocusedRowCellValue("size").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellValue("uom").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellValue("mat_det_code").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_qty", qty_input_grid)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_price", TxtRealCost.EditValue)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_amount", TxtAmount.EditValue)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_note", MENote.Text)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormMatAdjInSingle.GVDetail.CloseEditor()
                            FormMatAdjInSingle.GCDetail.RefreshDataSource()
                            FormMatAdjInSingle.GVDetail.RefreshData()
                            Close()
                        End If
                    Else
                        If id_pop_up = 1 Then 'Ins Standard Adj In
                            FormMatAdjInSingle.newRows()
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_adj_in_mat_det", "0")
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("mat_name").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("size", GVMat.GetFocusedRowCellValue("size").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellValue("uom").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellValue("mat_det_code").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_qty", qty_input_grid)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_mat_det_price", GVMatPrice.GetFocusedRowCellValue("id_mat_det_price").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_price", TxtRealCost.EditValue)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_amount", TxtAmount.EditValue)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_note", MENote.Text)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormMatAdjInSingle.GVDetail.CloseEditor()
                            FormMatAdjInSingle.GCDetail.RefreshDataSource()
                            FormMatAdjInSingle.GVDetail.RefreshData()
                            Close()
                        End If
                    End If
                Else
                    errorCustom("This material already exist in Adjustment List !")
                End If
            ElseIf action = "upd" Then
                checkExistInput()
                If Not ketemu Then
                    'Edit di Induk update save langsung ke db
                    If id_adj_x_mat_det <> "0" Then
                        If id_pop_up = "1" Then 'Edit DB Adj In
                            'Dim query_upd_return_det As String = "UPDATE tb_adj_in_mat_det SET id_mat_det = '" + GVMat.GetFocusedRowCellValue("id_mat_det").ToString + "',id_adj_in_mat = '" + FormMatAdjInSingle.id_adj_in_mat + "',adj_in_mat_det_note = '" + MENote.Text + "', adj_in_mat_det_qty = '" + decimalSQL(SPQtyPL.EditValue.ToString) + "', id_wh_drawer = '" + SLEDrawer.EditValue.ToString + "', adj_in_mat_det_price = '" + decimalSQL(TxtRealCost.EditValue.ToString) + "' WHERE id_adj_in_mat_det = '" + id_adj_x_mat_det + "' "
                            'execute_non_query(query_upd_return_det, True, "", "", "", "")
                            'Dim query_upd_storage1 As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes) "
                            'query_upd_storage1 += "VALUES('" + id_wh_drawer_edit.ToString + "', '2', '" + id_mat_det_edit + "', '" + adj_x_mat_det_qty.ToString + "', NOW(), 'Data Edited, Adjustment In mat No. : " + FormMatAdjInSingle.TxtAdjNumber.Text + "')"
                            'execute_non_query(query_upd_storage1, True, "", "", "", "")
                            'Dim query_upd_storage2 As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes) "
                            'query_upd_storage2 += "VALUES('" + SLEDrawer.EditValue.ToString + "', '1', '" + GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString + "', '" + decimalSQL(SPQtyPL.EditValue.ToString) + "', NOW(), 'Data Edited, Adjustment In mat No. : " + FormMatAdjInSingle.TxtAdjNumber.Text + "')"
                            'execute_non_query(query_upd_storage2, True, "", "", "", "")
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_mat_det_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("mat_name").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("size", GVMat.GetFocusedRowCellValue("size").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellValue("uom").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellValue("mat_det_code").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_qty", qty_input_grid)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_price", TxtRealCost.EditValue)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_amount", TxtAmount.EditValue)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_note", MENote.Text)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormMatAdjInSingle.GVDetail.CloseEditor()
                            FormMatAdjInSingle.GCDetail.RefreshDataSource()
                            FormMatAdjInSingle.GVDetail.RefreshData()
                            Close()
                        End If
                    Else
                        If id_pop_up = "1" Then 'Edit Standard Adj In
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_adj_in_mat_det", "0")
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_mat_det_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("mat_name").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("size", GVMat.GetFocusedRowCellValue("size").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellValue("uom").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellValue("mat_det_code").ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_qty", qty_input_grid)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_price", TxtRealCost.EditValue)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_amount", TxtAmount.EditValue)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("adj_in_mat_det_note", MENote.Text)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormMatAdjInSingle.GVDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormMatAdjInSingle.GVDetail.CloseEditor()
                            FormMatAdjInSingle.GCDetail.RefreshDataSource()
                            FormMatAdjInSingle.GVDetail.RefreshData()
                            Close()
                        End If
                    End If
                Else
                    errorCustom("This material already exist in Adjustment List !")
                End If
            End If
            FormMatAdjInSingle.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
            FormMatAdjInSingle.check_but()
            FormMatAdjInSingle.total_amount = Double.Parse(FormMatAdjInSingle.GVDetail.Columns("adj_in_mat_det_amount").SummaryItem.SummaryValue.ToString)
            FormMatAdjInSingle.METotSay.Text = ConvertCurrencyToEnglish(FormMatAdjInSingle.total_amount, FormMatAdjInSingle.LECurrency.EditValue.ToString)
        Else
            errorCustom("Qty not allowed zero value ! ")
        End If
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Try
            Dim id_mat_det As String = GVmat.GetFocusedRowCellDisplayText("id_mat_det").ToString
            If System.IO.File.Exists(mat_image_path & id_mat_det & ".jpg") Then
                Process.Start(mat_image_path & id_mat_det & ".jpg")
            Else
                Process.Start(mat_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
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
            viewWHRack()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Try
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
        Dim id_mat_det As String = GVmat.GetFocusedRowCellDisplayText("id_mat_det").ToString
        If SLEDrawer.EditValue Is Nothing Or id_mat_det = "" Then
            BtnChoose.Enabled = False
            LabelAttention.Text = "Drawer is not available this time"
            LabelAttention.Visible = True
            SPQtyPL.Enabled = False
            MENote.Enabled = False
            TxtCost.Enabled = False
            TxtKurs.Enabled = False
        Else
            BtnChoose.Enabled = True
            LabelAttention.Visible = False
            SPQtyPL.Enabled = True
            MENote.Enabled = True
            TxtCost.Enabled = True
            TxtKurs.Enabled = True
        End If
    End Sub

    Sub checkExistInput()
        ketemu = False
        Dim id_mat_det_cek As String = GVmat.GetFocusedRowCellDisplayText("id_mat_det").ToString
        Try
            Dim id_wh_drawer_cek As String = SLEDrawer.EditValue.ToString
            For i As Integer = 0 To (FormMatAdjInSingle.GVDetail.RowCount - 1)
                Try
                    Dim id_mat_det_data As String = FormMatAdjInSingle.GVDetail.GetRowCellValue(i, "id_mat_det")
                    Dim id_wh_drawer_data As String = FormMatAdjInSingle.GVDetail.GetRowCellValue(i, "id_wh_drawer")
                    If id_mat_det_data <> "" Then
                        If action = "ins" Then
                            If id_mat_det_cek = id_mat_det_data And id_wh_drawer_cek = id_wh_drawer_data Then
                                ketemu = True
                                Exit For
                            End If
                        ElseIf action = "upd" Then
                            If id_mat_det_cek = id_mat_det_data And id_wh_drawer_cek = id_wh_drawer_data And i <> indeks_edit Then
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

    Private Sub GVmat_BeforeLeaveRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GVmat.BeforeLeaveRow
        id_mat_det_old = GVmat.GetFocusedRowCellDisplayText("id_mat_det").ToString
    End Sub

    Private Sub GVmat_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVmat.DoubleClick
        Dim id_mat_det As String = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
        If Not id_mat_det = "" Then
            FormInfoDrawer.id_mat_det = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
            FormInfoDrawer.LabelSubTitle.Text = GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString + "/" + GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString
            FormInfoDrawer.ShowDialog()
        End If
    End Sub

    Private Sub GVmat_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVmat.FocusedRowChanged
        If action = "ins" Then
            Dim qty_input As Decimal = SPQtyPL.EditValue
            chooseCondition()
            viewCost()
            viewImg()
            checkExistInput()
        ElseIf action = "upd" Then
            chooseCondition()
            viewCost()
            viewImg()
        End If
    End Sub
    Sub getRealCost()
        Try
            Dim po_price_dec As Decimal = TxtCost.EditValue
            Dim kurs, price As Decimal
            kurs = TxtKurs.EditValue
            price = kurs * po_price_dec
            TxtRealCost.EditValue = price
        Catch ex As Exception
        End Try
    End Sub

    Sub getAmount()
        Dim qty As Decimal = Decimal.Parse(SPQtyPL.EditValue)
        Dim cost As Decimal = Decimal.Parse(TxtRealCost.EditValue)
        TxtAmount.EditValue = qty * cost
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

    Private Sub GVMat_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMat.CustomColumnDisplayText
        If e.Column.FieldName = "id_mat" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMat.IsGroupRow(rowhandle) Then
                rowhandle = GVMat.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMat.GetRowCellDisplayText(rowhandle, "mat_name")
            End If
        End If
    End Sub

    Private Sub GVMatPrice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPrice.FocusedRowChanged
        getCostCursored()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class