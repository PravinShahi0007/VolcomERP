Public Class FormSampleDelDrawerSingle
    Public id_comp As String = "-1"
    Public id_sample_edit As String = "-1"
    Public indeks_edit As Integer = 0
    Public jum_edit As Decimal = 0.0
    Public id_wh_drawer_edit As String = "-1"
    Public action_pop As String
    Dim currency As String
    Public id_pop_up As String = "-1"

    Private Sub FormSalesDelDrawerSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default currency
        Dim query_currency As String = "SELECT b.currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        currency = execute_query(query_currency, 0, True, "", "", "", "")

        'view stock
        viewWHStockSample()
        viewSampleStorage()
    End Sub

    Sub viewSampleStorage()
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
            Dim query As String = "CALL view_stock_sample('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "','9999-12-01','2')"
            Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
            dtd_temp.DefaultView.RowFilter = "id_sample = '" + id_sample_edit + "' "
            Dim data As DataTable = dtd_temp.DefaultView.ToTable
            'jika dia sudah tersimpan di db
            If id_wh_drawer_edit <> "-1" Then
                For i As Integer = 0 To (data.Rows.Count - 1)
                    If data.Rows(i)("id_wh_drawer").ToString = id_wh_drawer_edit Then
                        data.Rows(i)("qty_all_sample") = data.Rows(i)("qty_all_sample") + 1
                    End If
                Next
            End If

            GCProduct.DataSource = data

            'Active filter more than 0 qty
            GVProduct.ActiveFilterString = "[qty_all_sample] > 0.00"
        Catch ex As Exception
            errorConnection()
        End Try

        Dim id_sample As String = "0"
        Try
            id_sample = GVProduct.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_sample, False)

        Cursor = Cursors.Default
    End Sub

    Sub viewWHStockSample()
        Dim query As String = ""
        query += "SELECT e.id_comp, e.comp_number, e.comp_name FROM tb_storage_sample a "
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
        viewSampleStorage()
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        'get image
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, False)

        'set qty
        TECurrency.Text = currency
        TEUnitCost.EditValue = 0.0
        Try
            TEUnitCost.EditValue = GVProduct.GetFocusedRowCellValue("sample_price")
        Catch ex As Exception
        End Try
        TxtQtyLimit.EditValue = 0.0
        Try
            TxtQtyLimit.EditValue = GVProduct.GetFocusedRowCellValue("qty_all_sample")
        Catch ex As Exception
        End Try

        'activate image n choose btn
        If id_samplex = "0" Then
            BtnImg.Enabled = False
            BtnChoose.Enabled = False
        Else
            BtnImg.Enabled = True
            BtnChoose.Enabled = True
        End If
    End Sub

    Private Sub BtnImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImg.Click
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, True)
    End Sub

    Private Sub FormSampleDelDrawerSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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
            Dim is_duplicate As Boolean = False
            If id_pop_up = "-1" Then
                For i As Integer = 0 To (FormSampleDelDet.GVDrawer.RowCount - 1)
                    Dim id_sample_i As String = "-1"
                    Dim id_wh_drawer_i As String = "-1"
                    Dim cost_i As Decimal = 0.0
                    Try
                        id_sample_i = FormSampleDelDet.GVDrawer.GetRowCellValue(i, "id_sample").ToString
                        id_wh_drawer_i = FormSampleDelDet.GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                        cost_i = Decimal.Parse(FormSampleDelDet.GVDrawer.GetRowCellValue(i, "id_sample_price").ToString)
                    Catch ex As Exception
                    End Try
                    If action_pop = "ins" Then ' jika new
                        If id_sample_i = GVProduct.GetFocusedRowCellValue("id_sample").ToString And id_wh_drawer_i = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString And cost_i = GVProduct.GetFocusedRowCellValue("id_sample_price").ToString Then
                            is_duplicate = True
                            Exit For
                        End If
                    Else 'jika edit
                        If id_sample_i = GVProduct.GetFocusedRowCellValue("id_sample").ToString And id_wh_drawer_i = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString And cost_i = GVProduct.GetFocusedRowCellValue("id_sample_price").ToString And i <> indeks_edit Then
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
                        Dim newRow As DataRow = (TryCast(FormSampleDelDet.GCDrawer.DataSource, DataTable)).NewRow()
                        newRow("id_sample_del_det_drawer") = "0"
                        newRow("id_comp") = GVProduct.GetFocusedRowCellValue("id_comp").ToString
                        newRow("id_wh_locator") = GVProduct.GetFocusedRowCellValue("id_wh_locator").ToString
                        newRow("id_wh_rack") = GVProduct.GetFocusedRowCellValue("id_wh_rack").ToString
                        newRow("id_wh_drawer") = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString
                        newRow("wh") = GVProduct.GetFocusedRowCellValue("comp_name").ToString
                        newRow("locator") = GVProduct.GetFocusedRowCellValue("wh_locator").ToString
                        newRow("rack") = GVProduct.GetFocusedRowCellValue("wh_rack").ToString
                        newRow("drawer") = GVProduct.GetFocusedRowCellValue("wh_drawer").ToString
                        newRow("id_sample") = GVProduct.GetFocusedRowCellValue("id_sample")
                        newRow("id_sample_price") = GVProduct.GetFocusedRowCellValue("id_sample_price")
                        newRow("sample_price") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("sample_price").ToString)
                        newRow("qty_all_sample") = SPQtySaved.EditValue
                        newRow("sample_amount_all") = (GVProduct.GetFocusedRowCellValue("sample_price") * SPQtySaved.EditValue)
                        TryCast(FormSampleDelDet.GCDrawer.DataSource, DataTable).Rows.Add(newRow)
                        FormSampleDelDet.GCDrawer.RefreshDataSource()
                        FormSampleDelDet.GVDrawer.RefreshData()
                        FormSampleDelDet.countQtyFromWh(GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                        Close()
                    ElseIf action_pop = "upd" Then
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("id_sample_del_det_drawer", "0")
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("id_comp", GVProduct.GetFocusedRowCellValue("id_comp").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVProduct.GetFocusedRowCellValue("id_wh_locator").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVProduct.GetFocusedRowCellValue("id_wh_rack").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("wh", GVProduct.GetFocusedRowCellValue("comp_name").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("locator", GVProduct.GetFocusedRowCellValue("wh_locator").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("rack", GVProduct.GetFocusedRowCellValue("wh_rack").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("drawer", GVProduct.GetFocusedRowCellValue("wh_drawer").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("id_sample", GVProduct.GetFocusedRowCellValue("id_sample"))
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("id_sample_price", GVProduct.GetFocusedRowCellValue("id_sample_price"))
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("sample_price", GVProduct.GetFocusedRowCellValue("sample_price"))
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("id_sample", GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("qty_all_sample", SPQtySaved.EditValue)
                        FormSampleDelDet.GVDrawer.SetFocusedRowCellValue("sample_amount_all", GVProduct.GetFocusedRowCellValue("sample_price") * SPQtySaved.EditValue)
                        FormSampleDelDet.GCDrawer.RefreshDataSource()
                        FormSampleDelDet.GVDrawer.RefreshData()
                        FormSampleDelDet.countQtyFromWh(GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                        Close()
                    End If
                    FormSampleDelDet.check_but2()
                End If
            ElseIf id_pop_up = "1" Then
                '-----------------SAMPAI DISINI
                For i As Integer = 0 To (FormSampleDelOrderDet.GVDrawer.RowCount - 1)
                    Dim id_sample_i As String = "-1"
                    Dim id_wh_drawer_i As String = "-1"
                    Dim cost_i As Decimal = 0.0
                    Try
                        id_sample_i = FormSampleDelOrderDet.GVDrawer.GetRowCellValue(i, "id_sample").ToString
                        id_wh_drawer_i = FormSampleDelOrderDet.GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                        cost_i = Decimal.Parse(FormSampleDelOrderDet.GVDrawer.GetRowCellValue(i, "id_sample_price").ToString)
                    Catch ex As Exception
                    End Try
                    If action_pop = "ins" Then ' jika new
                        If id_sample_i = GVProduct.GetFocusedRowCellValue("id_sample").ToString And id_wh_drawer_i = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString And cost_i = GVProduct.GetFocusedRowCellValue("id_sample_price").ToString Then
                            is_duplicate = True
                            Exit For
                        End If
                    Else 'jika edit
                        If id_sample_i = GVProduct.GetFocusedRowCellValue("id_sample").ToString And id_wh_drawer_i = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString And cost_i = GVProduct.GetFocusedRowCellValue("id_sample_price").ToString And i <> indeks_edit Then
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
                        Dim newRow As DataRow = (TryCast(FormSampleDelOrderDet.GCDrawer.DataSource, DataTable)).NewRow()
                        newRow("id_pl_sample_order_del_det_drawer") = "0"
                        newRow("id_comp") = GVProduct.GetFocusedRowCellValue("id_comp").ToString
                        newRow("id_wh_locator") = GVProduct.GetFocusedRowCellValue("id_wh_locator").ToString
                        newRow("id_wh_rack") = GVProduct.GetFocusedRowCellValue("id_wh_rack").ToString
                        newRow("id_wh_drawer") = GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString
                        newRow("wh") = GVProduct.GetFocusedRowCellValue("comp_number").ToString
                        newRow("locator") = GVProduct.GetFocusedRowCellValue("wh_locator_code").ToString
                        newRow("rack") = GVProduct.GetFocusedRowCellValue("wh_rack_code").ToString
                        newRow("drawer") = GVProduct.GetFocusedRowCellValue("wh_drawer_code").ToString
                        newRow("id_sample") = GVProduct.GetFocusedRowCellValue("id_sample")
                        newRow("id_sample_price") = GVProduct.GetFocusedRowCellValue("id_sample_price")
                        newRow("sample_price") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("sample_price").ToString)
                        newRow("qty_all_sample") = SPQtySaved.EditValue
                        newRow("sample_amount_all") = (GVProduct.GetFocusedRowCellValue("sample_price") * SPQtySaved.EditValue)
                        TryCast(FormSampleDelOrderDet.GCDrawer.DataSource, DataTable).Rows.Add(newRow)
                        FormSampleDelOrderDet.GCDrawer.RefreshDataSource()
                        FormSampleDelOrderDet.GVDrawer.RefreshData()
                        FormSampleDelOrderDet.countQtyFromWh(GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                        Close()
                    ElseIf action_pop = "upd" Then
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("id_pl_sample_order_del_det_drawer ", "0")
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("id_comp", GVProduct.GetFocusedRowCellValue("id_comp").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVProduct.GetFocusedRowCellValue("id_wh_locator").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVProduct.GetFocusedRowCellValue("id_wh_rack").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVProduct.GetFocusedRowCellValue("id_wh_drawer").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("wh", GVProduct.GetFocusedRowCellValue("comp_number").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("locator", GVProduct.GetFocusedRowCellValue("wh_locator_code").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("rack", GVProduct.GetFocusedRowCellValue("wh_rack_code").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("drawer", GVProduct.GetFocusedRowCellValue("wh_drawer_code").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("id_sample", GVProduct.GetFocusedRowCellValue("id_sample"))
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("id_sample_price", GVProduct.GetFocusedRowCellValue("id_sample_price"))
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("sample_price", GVProduct.GetFocusedRowCellValue("sample_price"))
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("id_sample", GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("qty_all_sample", SPQtySaved.EditValue)
                        FormSampleDelOrderDet.GVDrawer.SetFocusedRowCellValue("sample_amount_all", GVProduct.GetFocusedRowCellValue("sample_price") * SPQtySaved.EditValue)
                        FormSampleDelOrderDet.GCDrawer.RefreshDataSource()
                        FormSampleDelOrderDet.GVDrawer.RefreshData()
                        FormSampleDelOrderDet.countQtyFromWh(GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                        Close()
                    End If
                    FormSampleDelOrderDet.check_but2()
                End If
            End If
        End If
    End Sub
End Class