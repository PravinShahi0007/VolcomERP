Public Class FormSalesDelOrderSingle 
    Public id_comp As String = "-1"
    Public id_product As String = "-1"
    Public indeks_edit As Integer = 0
    Public jum_edit As Decimal = 0.0
    Public id_wh_drawer_edit As String = "-1"
    Public action_pop As String
    Dim currency As String
    Public id_pop_up As String = "-1"

    Private Sub FormSalesDelOrderSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default currency
        Dim query_currency As String = "SELECT b.currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        currency = execute_query(query_currency, 0, True, "", "", "", "")

        'view stock
        viewWHStockFG()
        viewFGStorage()

        'updated 30 desember 2014
        SLEWH.Enabled = False
    End Sub

    Sub viewFGStorage()
        Cursor = Cursors.WaitCursor
        Dim id_wh_drawer_view As String = "-1"
        Try
            id_wh_drawer_view = SLEDrawer.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_wh_rack_view As String = "-1"
        Try
            id_wh_rack_view = SLERack.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_wh_locator_view As String = "-1"
        Try
            id_wh_locator_view = SLELocator.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim id_wh_view As String = "-1"
        Try
            id_wh_view = SLEWH.EditValue.ToString
        Catch ex As Exception
        End Try

        Try
            'updated 24 December 2014
            If id_pop_up <> "-1" Then
                If id_pop_up = "1" Then
                    'TRF
                    Dim query As String = "CALL view_stock_fg('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '" + id_product + "','4', '9999-01-01')"
                    Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
                    Dim filter_q As String = ""
                    For f As Integer = 0 To ((FormFGTrfDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGTrfDet.GVItemList))
                        Dim id_prod_param As String = FormFGTrfDet.GVItemList.GetRowCellValue(f, "id_product").ToString
                        filter_q += "id_product = '" + id_prod_param + "' "
                        If f < ((FormFGTrfDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGTrfDet.GVItemList)) Then
                            filter_q += "OR "
                        End If
                    Next
                    dtd_temp.DefaultView.RowFilter = filter_q
                    Dim data As DataTable = dtd_temp.DefaultView.ToTable

                    'jika dia sudah tersimpan di db
                    If id_wh_drawer_edit <> "-1" Then
                        For i As Integer = 0 To (data.Rows.Count - 1)
                            If data.Rows(i)("id_wh_drawer").ToString = id_wh_drawer_edit Then
                                data.Rows(i)("qty_all_product") = data.Rows(i)("qty_all_product") + 1
                            End If
                        Next
                    End If
                    GCProduct.DataSource = data
                ElseIf id_pop_up = "2" Then
                    'WRITE OFF
                    Dim query As String = "CALL view_stock_fg('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '" + id_product + "','4', '9999-01-01')"
                    Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
                    Dim filter_q As String = ""
                    For f As Integer = 0 To ((FormFGWoffDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGWoffDet.GVItemList))
                        Dim id_prod_param As String = FormFGWoffDet.GVItemList.GetRowCellValue(f, "id_product").ToString
                        filter_q += "id_product = '" + id_prod_param + "' "
                        If f < ((FormFGWoffDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGWoffDet.GVItemList)) Then
                            filter_q += "OR "
                        End If
                    Next
                    dtd_temp.DefaultView.RowFilter = filter_q
                    Dim data As DataTable = dtd_temp.DefaultView.ToTable

                    'jika dia sudah tersimpan di db
                    If id_wh_drawer_edit <> "-1" Then
                        For i As Integer = 0 To (data.Rows.Count - 1)
                            If data.Rows(i)("id_wh_drawer").ToString = id_wh_drawer_edit Then
                                data.Rows(i)("qty_all_product") = data.Rows(i)("qty_all_product") + 1
                            End If
                        Next
                    End If
                    GCProduct.DataSource = data
                ElseIf id_pop_up = "3" Then 'TRF STANDART
                    'TRF
                    Dim query As String = "CALL view_stock_fg('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '" + id_product + "','4', '9999-01-01')"
                    Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
                    Dim filter_q As String = ""
                    For f As Integer = 0 To ((FormFGTrfNewDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGTrfNewDet.GVItemList))
                        Dim id_prod_param As String = FormFGTrfNewDet.GVItemList.GetRowCellValue(f, "id_product").ToString
                        filter_q += "id_product = '" + id_prod_param + "' "
                        If f < ((FormFGTrfNewDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGTrfNewDet.GVItemList)) Then
                            filter_q += "OR "
                        End If
                    Next
                    dtd_temp.DefaultView.RowFilter = filter_q
                    Dim data As DataTable = dtd_temp.DefaultView.ToTable

                    'jika dia sudah tersimpan di db
                    If id_wh_drawer_edit <> "-1" Then
                        For i As Integer = 0 To (data.Rows.Count - 1)
                            If data.Rows(i)("id_wh_drawer").ToString = id_wh_drawer_edit Then
                                data.Rows(i)("qty_all_product") = data.Rows(i)("qty_all_product") + 1
                            End If
                        Next
                    End If
                    GCProduct.DataSource = data
                End If
            Else
                'DELIVERY ORDER
                Dim query As String = "CALL view_stock_fg('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '" + id_product + "','4', '9999-01-01')"
                Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
                Dim filter_q As String = ""
                For f As Integer = 0 To ((FormSalesDelOrderDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormSalesDelOrderDet.GVItemList))
                    Dim id_prod_param As String = FormSalesDelOrderDet.GVItemList.GetRowCellValue(f, "id_product").ToString
                    filter_q += "id_product = '" + id_prod_param + "' "
                    If f < ((FormSalesDelOrderDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormSalesDelOrderDet.GVItemList)) Then
                        filter_q += "OR "
                    End If
                Next
                dtd_temp.DefaultView.RowFilter = filter_q
                Dim data As DataTable = dtd_temp.DefaultView.ToTable

                'jika dia sudah tersimpan di db
                If id_wh_drawer_edit <> "-1" Then
                    For i As Integer = 0 To (data.Rows.Count - 1)
                        If data.Rows(i)("id_wh_drawer").ToString = id_wh_drawer_edit Then
                            data.Rows(i)("qty_all_product") = data.Rows(i)("qty_all_product") + 1
                        End If
                    Next
                End If
                GCProduct.DataSource = data
            End If
            GVProduct.ActiveFilterString = "[qty_all_product]>0.00 "
        Catch ex As Exception
            errorConnection()
        End Try

        Dim id_designx As String = "0"
        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try
        pre_viewImages("2", PictureEdit1, id_designx, False)

        Cursor = Cursors.Default
    End Sub

    Sub viewWHStockFG()
        Dim query As String = ""
        query += "SELECT e.id_comp, e.comp_number, e.comp_name FROM tb_storage_fg a "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack c ON b.id_wh_rack = c.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        If id_comp <> "-1" Then
            query += "WHERE e.id_comp = '" + id_comp + "' "
        End If
        query += "GROUP BY e.id_comp "
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub
    
    Sub viewWHLocatorSLEFG()
        Dim id_comp As String = "0"
        Try
            id_comp = SLEWH.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL "
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub

    Sub viewWHRackStockFG()
        Dim id_locator As String = "0"
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL "
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    
    Sub viewWHDrawerStockFG()
        Dim id_rack As String = "0"
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL "
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        viewWHLocatorSLEFG()
    End Sub

    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        viewWHRackStockFG()
    End Sub

    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        viewWHDrawerStockFG()
    End Sub

    Private Sub SLEDrawer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawer.EditValueChanged
        If SLEDrawer.EditValue Is Nothing Then
            BtnViewStock.Enabled = False
        Else
            BtnViewStock.Enabled = True
        End If
    End Sub

    Private Sub BtnViewStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStock.Click
        viewFGStorage()
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        'get image
        Dim id_designx As String = "0"
        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_designx, False)

        'set qty
        TECurrency.Text = currency
        'Try
        '    TECurrency.Text = GVProduct.GetFocusedRowCellValue("currency").ToString
        'Catch ex As Exception
        'End Try
        TEUnitCost.EditValue = 0.0
        Try
            TEUnitCost.EditValue = GVProduct.GetFocusedRowCellValue("bom_unit_price")
        Catch ex As Exception
        End Try
        TxtQtyLimit.EditValue = 0.0
        Try
            TxtQtyLimit.EditValue = GVProduct.GetFocusedRowCellValue("qty_all_product")
        Catch ex As Exception
        End Try

        'activate image n choose btn
        If id_designx = "0" Then
            BtnImg.Enabled = False
            BtnChoose.Enabled = False
        Else
            BtnImg.Enabled = True
            BtnChoose.Enabled = True
        End If
    End Sub

    Private Sub BtnImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImg.Click
        Dim id_designx As String = "0"
        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_designx, True)
    End Sub

    Private Sub FormSalesDelOrderSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Dim qty_limit As Decimal = Decimal.Parse(TxtQtyLimit.EditValue)
        Dim qty_del As Decimal = Decimal.Parse(SPQtySaved.EditValue)
        Dim uom As String = GVProduct.GetFocusedRowCellValue("uom").ToString
        If qty_del > qty_limit Then
            errorCustom("This item cannot exceed " + qty_limit.ToString + " " + uom.ToString + "")
        ElseIf qty_del = 0.0 Then
            errorCustom("Please input qty item")
        Else
            If id_pop_up = "1" Then
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormFGTrfDet.GVDrawer.RowCount - 1)
                    Dim id_product_i As String = "-1"
                    Dim id_wh_drawer_i As String = "-1"
                    Dim cost_i As Decimal = 0.0
                    Try
                        id_product_i = FormFGTrfDet.GVDrawer.GetRowCellValue(i, "id_product").ToString
                        id_wh_drawer_i = FormFGTrfDet.GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                        cost_i = Decimal.Parse(FormFGTrfDet.GVDrawer.GetRowCellValue(i, "bom_unit_price").ToString)
                    Catch ex As Exception
                    End Try
                    If action_pop = "ins" Then ' jika new
                        If id_product_i = GVProduct.GetFocusedRowCellValue("id_product").ToString And id_wh_drawer_i = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString And cost_i = GVProduct.GetFocusedRowCellValue("bom_unit_price").ToString Then
                            is_duplicate = True
                            Exit For
                        End If
                    Else 'jika edit
                        If id_product_i = GVProduct.GetFocusedRowCellValue("id_product").ToString And id_wh_drawer_i = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString And cost_i = GVProduct.GetFocusedRowCellValue("bom_unit_price").ToString And i <> indeks_edit Then
                            is_duplicate = True
                            Exit For
                        End If
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This item already exist on drawer list")
                Else
                    'code here
                    FormSalesDelOrderDet.GVItemList.ActiveFilterString = "[id_product]='" + GVProduct.GetFocusedRowCellValue("id_product").ToString + "' "
                    FormSalesDelOrderDet.GVItemList.FocusedRowHandle = 0
                    Dim qty_limit_so As String = FormSalesDelOrderDet.GVItemList.GetFocusedRowCellValue("sales_order_det_qty_limit")
                    Dim qty_from_wh_so As String = FormSalesDelOrderDet.GVItemList.GetFocusedRowCellValue("qty_frow_wh")
                    makeSafeGV(FormSalesDelOrderDet.GVItemList)

                    If (qty_del + qty_from_wh_so) <= qty_limit_so Then
                        If action_pop = "ins" Then
                            Dim newRow As DataRow = (TryCast(FormFGTrfDet.GCDrawer.DataSource, DataTable)).NewRow()
                            newRow("id_fg_trf_det_drawer") = "0"
                            newRow("id_comp") = GVProduct.GetFocusedRowCellValue("id_comp").ToString
                            newRow("id_wh_locator") = GVProduct.GetFocusedRowCellValue("id_wh_locator").ToString
                            newRow("id_wh_rack") = GVProduct.GetFocusedRowCellValue("id_wh_rack").ToString
                            newRow("id_wh_drawer") = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString
                            newRow("wh") = GVProduct.GetFocusedRowCellValue("wh").ToString
                            newRow("locator") = GVProduct.GetFocusedRowCellValue("locator").ToString
                            newRow("rack") = GVProduct.GetFocusedRowCellValue("rack").ToString
                            newRow("drawer") = GVProduct.GetFocusedRowCellValue("drawer").ToString
                            newRow("bom_unit_price") = GVProduct.GetFocusedRowCellValue("bom_unit_price")
                            newRow("id_product") = GVProduct.GetFocusedRowCellValue("id_product").ToString
                            newRow("qty_all_product") = SPQtySaved.EditValue
                            newRow("total_cost") = (GVProduct.GetFocusedRowCellValue("bom_unit_price") * SPQtySaved.EditValue)
                            newRow("code") = GVProduct.GetFocusedRowCellValue("code").ToString
                            newRow("name") = GVProduct.GetFocusedRowCellValue("name").ToString
                            newRow("size") = GVProduct.GetFocusedRowCellValue("size").ToString
                            TryCast(FormFGTrfDet.GCDrawer.DataSource, DataTable).Rows.Add(newRow)
                            FormFGTrfDet.GCDrawer.RefreshDataSource()
                            FormFGTrfDet.GVDrawer.RefreshData()
                            FormFGTrfDet.countQtyFromWh(GVProduct.GetFocusedRowCellValue("id_product").ToString)
                            FormFGTrfDet.check_but_drawer()
                            Close()
                        ElseIf action_pop = "upd" Then
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("id_fg_trf_det_drawer", "0")
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("id_comp", GVProduct.GetFocusedRowCellValue("id_comp").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVProduct.GetFocusedRowCellValue("id_wh_locator").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVProduct.GetFocusedRowCellValue("id_wh_rack").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("wh", GVProduct.GetFocusedRowCellValue("wh").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("locator", GVProduct.GetFocusedRowCellValue("locator").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("rack", GVProduct.GetFocusedRowCellValue("rack").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("drawer", GVProduct.GetFocusedRowCellValue("drawer").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("bom_unit_price", GVProduct.GetFocusedRowCellValue("bom_unit_price"))
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("code", GVProduct.GetFocusedRowCellValue("code").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("name", GVProduct.GetFocusedRowCellValue("name").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("size", GVProduct.GetFocusedRowCellValue("size").ToString)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("qty_all_product", SPQtySaved.EditValue)
                            FormFGTrfDet.GVDrawer.SetFocusedRowCellValue("total_cost", GVProduct.GetFocusedRowCellValue("bom_unit_price") * SPQtySaved.EditValue)
                            FormFGTrfDet.GCDrawer.RefreshDataSource()
                            FormFGTrfDet.GVDrawer.RefreshData()
                            FormFGTrfDet.countQtyFromWh(GVProduct.GetFocusedRowCellValue("id_product").ToString)
                            FormFGTrfDet.check_but_drawer()
                            Close()
                        End If
                    Else
                        stopCustom(GVProduct.GetFocusedRowCellValue("name").ToString + "/Size : " + GVProduct.GetFocusedRowCellValue("size").ToString + " can't exceed " + qty_limit_so.ToString)
                    End If
                End If
            ElseIf id_pop_up = "2" Then
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormFGWoffDet.GVDrawer.RowCount - 1)
                    Dim id_product_i As String = "-1"
                    Dim id_wh_drawer_i As String = "-1"
                    Dim cost_i As Decimal = 0.0
                    Try
                        id_product_i = FormFGWoffDet.GVDrawer.GetRowCellValue(i, "id_product").ToString
                        id_wh_drawer_i = FormFGWoffDet.GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                        cost_i = Decimal.Parse(FormFGWoffDet.GVDrawer.GetRowCellValue(i, "bom_unit_price").ToString)
                    Catch ex As Exception
                    End Try
                    If action_pop = "ins" Then ' jika new
                        If id_product_i = GVProduct.GetFocusedRowCellValue("id_product").ToString And id_wh_drawer_i = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString And cost_i = GVProduct.GetFocusedRowCellValue("bom_unit_price").ToString Then
                            is_duplicate = True
                            Exit For
                        End If
                    Else 'jika edit
                        If id_product_i = GVProduct.GetFocusedRowCellValue("id_product").ToString And id_wh_drawer_i = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString And cost_i = GVProduct.GetFocusedRowCellValue("bom_unit_price").ToString And i <> indeks_edit Then
                            is_duplicate = True
                            Exit For
                        End If
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This item already exist on drawer list")
                Else
                    'code here
                    If action_pop = "ins" Then
                        Dim newRow As DataRow = (TryCast(FormFGWoffDet.GCDrawer.DataSource, DataTable)).NewRow()
                        newRow("id_fg_woff_det_drawer") = "0"
                        newRow("id_comp") = GVProduct.GetFocusedRowCellValue("id_comp").ToString
                        newRow("id_wh_locator") = GVProduct.GetFocusedRowCellValue("id_wh_locator").ToString
                        newRow("id_wh_rack") = GVProduct.GetFocusedRowCellValue("id_wh_rack").ToString
                        newRow("id_wh_drawer") = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString
                        newRow("wh") = GVProduct.GetFocusedRowCellValue("wh").ToString
                        newRow("locator") = GVProduct.GetFocusedRowCellValue("locator").ToString
                        newRow("rack") = GVProduct.GetFocusedRowCellValue("rack").ToString
                        newRow("drawer") = GVProduct.GetFocusedRowCellValue("drawer").ToString
                        newRow("bom_unit_price") = GVProduct.GetFocusedRowCellValue("bom_unit_price")
                        newRow("id_product") = GVProduct.GetFocusedRowCellValue("id_product").ToString
                        newRow("qty_all_product") = SPQtySaved.EditValue
                        newRow("total_cost") = (GVProduct.GetFocusedRowCellValue("bom_unit_price") * SPQtySaved.EditValue)
                        newRow("code") = GVProduct.GetFocusedRowCellValue("code").ToString
                        newRow("name") = GVProduct.GetFocusedRowCellValue("name").ToString
                        newRow("size") = GVProduct.GetFocusedRowCellValue("size").ToString
                        TryCast(FormFGWoffDet.GCDrawer.DataSource, DataTable).Rows.Add(newRow)
                        FormFGWoffDet.GCDrawer.RefreshDataSource()
                        FormFGWoffDet.GVDrawer.RefreshData()
                        FormFGWoffDet.countQtyFromWh(GVProduct.GetFocusedRowCellValue("id_product").ToString)
                        FormFGWoffDet.check_but_drawer()
                        Close()
                    ElseIf action_pop = "upd" Then
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("id_fg_woff_det_drawer", "0")
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("id_comp", GVProduct.GetFocusedRowCellValue("id_comp").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVProduct.GetFocusedRowCellValue("id_wh_locator").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVProduct.GetFocusedRowCellValue("id_wh_rack").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("wh", GVProduct.GetFocusedRowCellValue("wh").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("locator", GVProduct.GetFocusedRowCellValue("locator").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("rack", GVProduct.GetFocusedRowCellValue("rack").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("drawer", GVProduct.GetFocusedRowCellValue("drawer").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("bom_unit_price", GVProduct.GetFocusedRowCellValue("bom_unit_price"))
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("code", GVProduct.GetFocusedRowCellValue("code").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("name", GVProduct.GetFocusedRowCellValue("name").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("size", GVProduct.GetFocusedRowCellValue("size").ToString)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("qty_all_product", SPQtySaved.EditValue)
                        FormFGWoffDet.GVDrawer.SetFocusedRowCellValue("total_cost", GVProduct.GetFocusedRowCellValue("bom_unit_price") * SPQtySaved.EditValue)
                        FormFGWoffDet.GCDrawer.RefreshDataSource()
                        FormFGWoffDet.GVDrawer.RefreshData()
                        FormFGWoffDet.countQtyFromWh(GVProduct.GetFocusedRowCellValue("id_product").ToString)
                        FormFGWoffDet.check_but_drawer()
                        Close()
                    End If
                End If
            ElseIf id_pop_up = "3" Then
                Dim is_duplicate As Boolean = False


                If is_duplicate Then
                    errorCustom("This item already exist on drawer list")
                Else
                    'code here
                    FormFGTrfNewDet.GVItemList.ActiveFilterString = "[id_product]='" + GVProduct.GetFocusedRowCellValue("id_product").ToString + "' "
                    FormFGTrfNewDet.GVItemList.FocusedRowHandle = 0
                    Dim qty_limit_so As String = FormFGTrfNewDet.GVItemList.GetFocusedRowCellValue("sales_order_det_qty_limit")
                    Dim qty_from_wh_so As String = FormFGTrfNewDet.GVItemList.GetFocusedRowCellValue("qty_frow_wh")
                    makeSafeGV(FormFGTrfNewDet.GVItemList)
                End If
            End If
        End If
    End Sub
End Class