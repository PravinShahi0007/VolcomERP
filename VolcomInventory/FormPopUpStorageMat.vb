Public Class FormPopUpStorageMat
    Public id_pop_up As String = "-1"
    Public id_wh As String = "-1"
    Public allow_all_wh As Boolean = True
    Public allow_all_locator As Boolean = True
    Public allow_all_rack As Boolean = True
    Public allow_all_drawer As Boolean = True
    Dim mat_image_path As String = get_setup_field("pic_path_mat") & "\"
    Dim id_mat_det As String
    Public action As String
    Dim id_prod_order_mrs_detx As String = ""
    Public id_wh_rack_edit, id_wh_locator_edit, id_wh_drawer_edit, pl_mrs_det_qty, pl_mrs_det_note, id_mat_edit, id_mat_edit_price As String

    Public id_pl_mrs_det As String = ""

    Public id_mat_ada As String = ""

    Public id_currency As String = "1"
    Public currency As String = ""
    '1 = PL
    '2 = Adjustment Out
    '3 = ret out

    'Form
    Private Sub FormPopUpStorageMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TECurrency.Text = currency

        If id_pop_up = "1" Then
            viewWHStock()
            LQtyOut.Visible = False
            SPQtyOut.Visible = False
            If action = "ins" Then
                viewMatStorage()
            ElseIf action = "upd" Then
                SLELocator.EditValue = id_wh_locator_edit
                SLERack.EditValue = id_wh_rack_edit
                SLEDrawer.EditValue = id_wh_drawer_edit
                viewMatStorage()
                SPQtyOut.Text = pl_mrs_det_qty.ToString
                MERemark.Text = pl_mrs_det_note.ToString
            End If
        ElseIf id_pop_up = "2" Then
            viewWHStock()
            If action = "ins" Then
                viewMatStorage()
            End If
        ElseIf id_pop_up = "3" Then
            viewWHStock()
            viewMatStorage()
        End If
    End Sub

    Private Sub FormPopUpStorageMat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'View Data
    Sub viewWHStock()
        Dim query As String = ""
        'get id category on opt
        query = "SELECT id_comp_cat_wh FROM tb_opt "
        Dim id_comp_cat_wh As String = execute_query(query, 0, True, "", "", "", "")

        'view data comp/warehouse
        query = ""
        If allow_all_wh Then
            query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name UNION ALL "
        End If
        query += "SELECT a.id_comp, a.comp_number, a.comp_name FROM tb_m_comp a WHERE a.id_comp_cat = '" + id_comp_cat_wh + "' "
        If id_wh <> "-1" Then
            query += "AND a.id_comp = '" + id_wh + "' "
        End If
        query += "ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewWHLocatorSLE()
        Dim id_comp As String = SLEWH.EditValue.ToString
        Dim query As String = ""
        If allow_all_locator Then
            query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL "
        End If
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Sub viewWHRack()
        Dim id_locator As String = SLELocator.EditValue.ToString
        Dim query As String = ""
        If allow_all_rack Then
            query += "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL "
        End If
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Sub viewWHDrawer()
        Dim id_rack As String = SLERack.EditValue.ToString
        Dim query As String = ""
        If allow_all_drawer Then
            query = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL "
        End If
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    Sub viewMatStorage()
        Cursor = Cursors.WaitCursor
        Dim id_wh_drawer_view As String = "-1"
        Dim id_wh_rack_view As String = "-1"
        Dim id_wh_locator_view As String = "-1"
        Dim id_wh_view As String = "-1"

        If Not SLEDrawer.EditValue = Nothing Then
            id_wh_drawer_view = SLEDrawer.EditValue.ToString
        End If
        If Not SLERack.EditValue = Nothing Then
            id_wh_rack_view = SLERack.EditValue.ToString()
        End If
        If Not SLELocator.EditValue = Nothing Then
            id_wh_locator_view = SLELocator.EditValue.ToString()
        End If
        If Not SLEWH.EditValue = Nothing Then
            id_wh_view = SLEWH.EditValue.ToString()
        End If

        Try
            If id_pop_up = "1" Then
                Dim id_ada As String = ""
                For k As Integer = 0 To FormMatPLSingle.id_mat_list.Count - 1
                    If k = 0 Then
                        id_ada += " id_mat_det ='" & FormMatPLSingle.id_mat_list(k).ToString() & "' "
                    Else
                        id_ada += " OR id_mat_det ='" & FormMatPLSingle.id_mat_list(k).ToString() & "' "
                    End If
                Next

                Dim query As String = "CALL view_stock_mat_crit('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '2')"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                If Not id_ada = "" Then
                    query = data.Rows(0)("sql_string").ToString & " WHERE " & id_ada
                Else
                    query = data.Rows(0)("sql_string").ToString
                End If

                data = execute_query(query, -1, True, "", "", "", "")

                For j As Integer = 0 To data.Rows.Count - 1
                    If action = "upd" Then
                        If id_pl_mrs_det <> "0" Then
                            If data.Rows(j)("id_wh_drawer") = id_wh_drawer_edit And data.Rows(j)("price") = FormMatPLSingle.GVDrawer.GetFocusedRowCellValue("pl_mrs_det_price").ToString And data.Rows(j)("id_mat_det_price") = FormMatPLSingle.GVDrawer.GetFocusedRowCellValue("id_mat_det_price").ToString Then
                                data.Rows(j)("qty_all_mat") = Decimal.Parse(data.Rows(j)("qty_all_mat")) + Decimal.Parse(pl_mrs_det_qty)
                            End If
                        End If
                    End If
                Next

                GCMat.DataSource = data

                If action = "ins" Then
                    GVMat.Columns("name").GroupIndex = 0
                End If
                If data.Rows.Count > 0 Then
                    BtnChoose.Enabled = True
                    BtnImg.Enabled = True
                Else
                    BtnChoose.Enabled = False
                    BtnImg.Enabled = False
                End If
                setRequired()
                checkRequisition()
            ElseIf id_pop_up = "3" Then '
                Dim query As String = "CALL view_stock_mat_crit('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '2')"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                If Not id_mat_ada = "" Then
                    query = data.Rows(0)("sql_string").ToString & " WHERE id_mat_det='" & id_mat_ada & "'"
                Else
                    query = data.Rows(0)("sql_string").ToString
                End If

                data = execute_query(query, -1, True, "", "", "", "")

                For j As Integer = 0 To data.Rows.Count - 1
                    If action = "upd" Then
                        If id_pl_mrs_det <> "0" Then
                            If data.Rows(j)("id_wh_drawer") = id_wh_drawer_edit And data.Rows(j)("price") = FormMatPLSingle.GVDrawer.GetFocusedRowCellValue("pl_mrs_det_price").ToString And data.Rows(j)("id_mat_det_price") = FormMatPLSingle.GVDrawer.GetFocusedRowCellValue("id_mat_det_price").ToString Then
                                data.Rows(j)("qty_all_mat") = Decimal.Parse(data.Rows(j)("qty_all_mat")) + Decimal.Parse(pl_mrs_det_qty)
                            End If
                        End If
                    End If
                Next

                GCMat.DataSource = data

                If action = "ins" Then
                    GVMat.Columns("name").GroupIndex = 0
                End If

                If data.Rows.Count > 0 Then
                    BtnChoose.Enabled = True
                    BtnImg.Enabled = True
                Else
                    BtnChoose.Enabled = False
                    BtnImg.Enabled = False
                End If
            End If
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
        Cursor = Cursors.Default
    End Sub
    Sub viewImg()
        If System.IO.File.Exists(mat_image_path & id_mat_det & ".jpg") Then
            PictureEdit1.LoadAsync(mat_image_path & id_mat_det & ".jpg")
            BtnImg.Enabled = True
        Else
            PictureEdit1.LoadAsync(mat_image_path & "default" & ".jpg")
            BtnImg.Enabled = False
        End If
        If id_mat_det <> "" Then
            BtnChoose.Enabled = True
            'BPickPrice.Enabled = True
            TEUnitPrice.EditValue = 0
        Else
            BtnChoose.Enabled = False
            'BPickPrice.Enabled = False
            TEUnitPrice.EditValue = 0
        End If
    End Sub
    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        Try
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
            If SLEDrawer.EditValue Is Nothing Then
                BtnViewStock.Enabled = False
            Else
                BtnViewStock.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Button
    Private Sub BtnViewStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStock.Click
        Try
            viewMatStorage()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPStorageMat, GroupControlInput) Then
            stopCustom("Please check your input.")
        Else
            If id_pop_up = "1" Then
                Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyOut.Text.ToString)
                'If qty_input_grid.ToString <> "0" Then '-------NEW----------
                If action = "ins" Then
                    'check exixt
                    Dim exist_list As Boolean = False
                    For i As Integer = 0 To FormMatPLSingle.GVDetail.RowCount - 1
                        Dim id_mat_cek As String = ""
                        Try
                            id_mat_cek = FormMatPLSingle.GVDetail.GetRowCellValue(i, "id_mat_det").ToString
                        Catch ex As Exception
                        End Try
                        If id_mat_cek = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString Then
                            exist_list = True
                            Exit For
                        End If
                    Next

                    'check duplicate
                    Dim already As Boolean = False
                    For i As Integer = 0 To FormMatPLSingle.GVDrawer.RowCount - 1
                        Dim id_mat_cek As String = ""
                        Dim id_wh_drawer_cek As String = ""
                        Try
                            id_mat_cek = FormMatPLSingle.GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString
                            id_wh_drawer_cek = FormMatPLSingle.GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                        Catch ex As Exception
                        End Try
                        If id_mat_cek = GVMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString And id_wh_drawer_cek = GVMat.GetFocusedRowCellDisplayText("id_wh_drawer").ToString Then
                            'MsgBox("sama")
                            already = True
                            Exit For
                        End If
                    Next

                    If exist_list Then
                        If Not already Then
                            If id_pl_mrs_det <> "0" Then
                                FormMatPLSingle.GVDetail.FocusedRowHandle = find_row(FormMatPLSingle.GVDetail, "id_prod_order_mrs_det", id_prod_order_mrs_detx)
                                Dim qty_curr As Decimal = Decimal.Parse(FormMatPLSingle.GVDetail.GetFocusedRowCellDisplayText("qty_real_mat").ToString)
                                Dim qty_pl As Decimal = Decimal.Parse(SPQtyOut.Text.ToString)
                                qty_pl = qty_pl + qty_curr
                                FormMatPLSingle.isAllowRequisition(GVMat.GetFocusedRowCellDisplayText("name").ToString, id_prod_order_mrs_detx, qty_pl.ToString)
                                If FormMatPLSingle.cond_check Then
                                    FormMatPLSingle.newRows()
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_mat_det_price", GVMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("name").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellValue("code").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_qty", qty_input_grid.ToString("N2"))
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_note", MERemark.Text)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_locator", GVMat.GetFocusedRowCellValue("wh_locator").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_rack", GVMat.GetFocusedRowCellValue("wh_rack").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_drawer", GVMat.GetFocusedRowCellValue("wh_drawer").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVMat.GetFocusedRowCellValue("id_wh_drawer").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVMat.GetFocusedRowCellValue("id_wh_locator").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVMat.GetFocusedRowCellValue("id_wh_rack").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("qty_all_mat", GVMat.GetFocusedRowCellValue("qty_all_mat").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_prod_order_mrs_det", id_prod_order_mrs_detx.ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellValue("uom").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_price", TEUnitPrice.EditValue)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("total_price", (TEUnitPrice.EditValue * qty_input_grid))

                                    'Save in Gridview
                                    FormMatPLSingle.GVDrawer.CloseEditor()
                                    AddHandler FormSamplePLDelSingle.GVDrawer.RowCellStyle, AddressOf FormSamplePLDelSingle.test_aw
                                    FormMatPLSingle.GCDrawer.RefreshDataSource()
                                    FormMatPLSingle.GVDrawer.RefreshData()
                                    FormMatPLSingle.getAmountReq(id_prod_order_mrs_detx, False)
                                    Close()
                                Else
                                    errorCustom("Material : '" + FormMatPLSingle.mat_check + "' cannot exceed " + FormMatPLSingle.allow_sum.ToString("N2") + ", please check in Info MRS ! ")
                                    FormMatPLSingle.infoSrs()
                                End If
                            Else
                                FormMatPLSingle.newRows()
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_pl_mrs_det", "0")
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_mat_det_price", GVMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("name").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellValue("code").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_qty", qty_input_grid.ToString("N2"))
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_note", MERemark.Text)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_locator", GVMat.GetFocusedRowCellValue("wh_locator").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_rack", GVMat.GetFocusedRowCellValue("wh_rack").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_drawer", GVMat.GetFocusedRowCellValue("wh_drawer").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVMat.GetFocusedRowCellValue("id_wh_drawer").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVMat.GetFocusedRowCellValue("id_wh_locator").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVMat.GetFocusedRowCellValue("id_wh_rack").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("qty_all_mat", GVMat.GetFocusedRowCellValue("qty_all_mat").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_prod_order_mrs_det", id_prod_order_mrs_detx)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellValue("uom").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_price", TEUnitPrice.EditValue)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("total_price", (TEUnitPrice.EditValue * qty_input_grid))

                                'Save in Gridview
                                FormMatPLSingle.GVDrawer.CloseEditor()
                                AddHandler FormMatPLSingle.GVDrawer.RowCellStyle, AddressOf FormMatPLSingle.test_aw
                                FormMatPLSingle.GCDrawer.RefreshDataSource()
                                FormMatPLSingle.GVDrawer.RefreshData()
                                FormMatPLSingle.getAmountReq(id_prod_order_mrs_detx, False)
                                Close()
                            End If
                        Else
                            stopCustom("This material already on list.")
                        End If
                    Else
                        stopCustom("Sorry, this material not found in this requisition list !")
                    End If
                ElseIf action = "upd" Then ' -------EDIT------------
                    'check exixt
                    Dim exist_list As Boolean = False
                    For i As Integer = 0 To FormMatPLSingle.GVDetail.RowCount - 1
                        Dim id_mat_cek As String = ""
                        Try
                            id_mat_cek = FormMatPLSingle.GVDetail.GetRowCellValue(i, "id_mat_det").ToString
                        Catch ex As Exception
                        End Try
                        If id_mat_cek = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString Then
                            exist_list = True
                            Exit For
                        End If
                    Next

                    'check duplicate
                    Dim already As Boolean = False
                    For i As Integer = 0 To FormMatPLSingle.GVDrawer.RowCount - 1
                        If Not FormMatPLSingle.GVDrawer.FocusedRowHandle = i Then
                            Dim id_mat_cek As String = ""
                            Dim id_wh_drawer_cek As String = ""
                            Try
                                id_mat_cek = FormMatPLSingle.GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString
                                id_wh_drawer_cek = FormMatPLSingle.GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                            Catch ex As Exception
                            End Try
                            If id_mat_cek = GVMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString And id_wh_drawer_cek = GVMat.GetFocusedRowCellDisplayText("id_wh_drawer").ToString Then
                                'MsgBox("sama")
                                already = True
                                Exit For
                            End If
                        End If
                    Next
                    'Edit di Induk update save langsung ke db
                    If exist_list Then
                        If Not already Then
                            If id_pl_mrs_det <> "0" Then
                                FormMatPLSingle.GVDetail.FocusedRowHandle = find_row(FormMatPLSingle.GVDetail, "id_prod_order_mrs_det", id_prod_order_mrs_detx)
                                Dim qty_curr As Decimal = Decimal.Parse(FormMatPLSingle.GVDetail.GetFocusedRowCellDisplayText("qty_real_mat").ToString) - Decimal.Parse(pl_mrs_det_qty.ToString)
                                Dim qty_pl As Decimal = Decimal.Parse(SPQtyOut.Text)
                                qty_pl = qty_pl + qty_curr
                                FormMatPLSingle.isAllowRequisition(GVMat.GetFocusedRowCellDisplayText("name").ToString, id_prod_order_mrs_detx, qty_pl.ToString)
                                If FormMatPLSingle.cond_check Then
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_mat_det_price", GVMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("name").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellValue("code").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_qty", qty_input_grid.ToString("N2"))
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_note", MERemark.Text)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_locator", GVMat.GetFocusedRowCellValue("wh_locator").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_rack", GVMat.GetFocusedRowCellValue("wh_rack").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_drawer", GVMat.GetFocusedRowCellValue("wh_drawer").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVMat.GetFocusedRowCellValue("id_wh_drawer").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVMat.GetFocusedRowCellValue("id_wh_locator").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVMat.GetFocusedRowCellValue("id_wh_rack").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("qty_all_mat", GVMat.GetFocusedRowCellValue("qty_all_mat").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_prod_order_mrs_det", id_prod_order_mrs_detx)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellValue("uom").ToString)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_price", TEUnitPrice.EditValue)
                                    FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("total_price", (TEUnitPrice.EditValue * qty_input_grid))

                                    'Save in Gridview
                                    FormMatPLSingle.GVDrawer.CloseEditor()
                                    AddHandler FormMatPLSingle.GVDrawer.RowCellStyle, AddressOf FormMatPLSingle.test_aw
                                    FormMatPLSingle.GCDrawer.RefreshDataSource()
                                    FormMatPLSingle.GVDrawer.RefreshData()
                                    FormMatPLSingle.getAmountReq(id_prod_order_mrs_detx, False)
                                    Close()
                                Else
                                    errorCustom("Material : '" + FormMatPLSingle.mat_check + "' cannot exceed " + FormMatPLSingle.allow_sum.ToString("N2") + ", please check in Info MRS ! ")
                                    FormMatPLSingle.infoSrs()
                                End If
                            Else
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_pl_mrs_det", "0")
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_mat_det_price", GVMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("name", GVMat.GetFocusedRowCellDisplayText("name").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("code", GVMat.GetFocusedRowCellValue("code").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_qty", qty_input_grid.ToString("N2"))
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_note", MERemark.Text)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_locator", GVMat.GetFocusedRowCellValue("wh_locator").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_rack", GVMat.GetFocusedRowCellValue("wh_rack").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("wh_drawer", GVMat.GetFocusedRowCellValue("wh_drawer").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVMat.GetFocusedRowCellValue("id_wh_drawer").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVMat.GetFocusedRowCellValue("id_wh_locator").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVMat.GetFocusedRowCellValue("id_wh_rack").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("qty_all_mat", GVMat.GetFocusedRowCellValue("qty_all_mat").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("id_prod_order_mrs_det", id_prod_order_mrs_detx)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("uom", GVMat.GetFocusedRowCellValue("uom").ToString)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("pl_mrs_det_price", TEUnitPrice.EditValue)
                                FormMatPLSingle.GVDrawer.SetFocusedRowCellValue("total_price", (TEUnitPrice.EditValue * qty_input_grid))

                                'Save in Gridview
                                FormMatPLSingle.GVDrawer.CloseEditor()
                                AddHandler FormMatPLSingle.GVDrawer.RowCellStyle, AddressOf FormMatPLSingle.test_aw
                                FormMatPLSingle.GCDrawer.RefreshDataSource()
                                FormMatPLSingle.GVDrawer.RefreshData()
                                FormMatPLSingle.getAmountReq(id_prod_order_mrs_detx, False)
                                Close()
                            End If
                        Else
                            stopCustom("This material already on list.")
                        End If
                    Else
                        stopCustom("Sorry, this material not found in this requisition list !")
                    End If

                End If
                'Else
                '    errorCustom("Qty PL not allowed zero value ! ")
                'End If
            ElseIf id_pop_up = "3" Then
            Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyOut.Text.ToString)
            FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("mat_purc_ret_out_det_qty", qty_input_grid)
            FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("id_wh_drawer", GVMat.GetFocusedRowCellValue("id_wh_drawer").ToString)
            FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("wh_drawer", GVMat.GetFocusedRowCellValue("wh_drawer").ToString)
            FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("price", TEUnitPrice.EditValue)
            FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("tot_price", TEUnitPrice.EditValue * qty_input_grid)
            Close()
        End If
        End If
    End Sub
    Private Sub BtnImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImg.Click
        Try
            If System.IO.File.Exists(mat_image_path & id_mat_det & ".jpg") Then
                Process.Start(mat_image_path & id_mat_det & ".jpg")
            Else
                Process.Start(mat_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'GridView
    Private Sub GVSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMat.RowClick
        Try
            setRequired()
            If id_pop_up = "2" Then
                checkRequisition()
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Set required
    Sub setRequired()
        id_mat_det = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
        viewImg()
        If Not id_mat_det = "" Then
            TxtQtyLimit.EditValue = GVMat.GetFocusedRowCellValue("qty_all_mat").ToString
            TECurrency.Text = GVMat.GetFocusedRowCellValue("currency").ToString
            TEUnitPrice.EditValue = GVMat.GetFocusedRowCellValue("price").ToString
            SPQtyOut.Text = "0"
            MERemark.Text = ""
        End If
        'Set Qty Limit in textbox
        Try

        Catch ex As Exception
        End Try
    End Sub

    Sub checkRequisition()
        ''check in sample req list
        Dim id_mat_check As String = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
        Dim found_mat As Boolean = False
        For i As Integer = 0 To (FormMatPLSingle.GVDetail.RowCount - 1)
            Try
                Dim id_mat_det_ls As String = FormMatPLSingle.GVDetail.GetRowCellValue(i, "id_mat_det").ToString
                Dim id_mat_det_requisition_det As String = FormMatPLSingle.GVDetail.GetRowCellValue(i, "id_prod_order_mrs_det").ToString
                If id_mat_det_ls = id_mat_check Then
                    id_prod_order_mrs_detx = id_mat_det_requisition_det
                    found_mat = True
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

    'Spin QTY
    Private Sub SPQtyPL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtyOut.EditValueChanged
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = SpQty.EditValue
            Dim qty_limit As Decimal = GVMat.GetFocusedRowCellDisplayText("qty_all_mat")
            Dim current_name As String = GVMat.GetFocusedRowCellDisplayText("name").ToString
            Dim current_uom As String = GVMat.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_limit Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Material : '" + current_name + "', cannot exceed " + qty_limit.ToString + " " + current_uom + " ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SpQty.EditValue = qty_limit
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVMat_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMat.FocusedRowChanged
        Try
            setRequired()
            If id_pop_up = "1" Then
                checkRequisition()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SPQtyPL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SPQtyOut.Validating
        If Not id_pop_up = "1" Then
            If SPQtyOut.EditValue = 0 Then
                EPStorageMat.SetError(SPQtyOut, "Value can't be zero")
            Else
                EPStorageMat.SetError(SPQtyOut, "")
            End If
        End If
    End Sub
End Class