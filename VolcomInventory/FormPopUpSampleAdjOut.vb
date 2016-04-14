Public Class FormPopUpSampleAdjOut 
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
    Dim first_load As Boolean = True
    Dim id_sample_price_selected As String
    '--------------------------------

    'Form
    Private Sub FormSampleReturnPickSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        first_load = False
        SplitContainerControl1.Panel2.Hide()
        If action = "upd" Then
            viewWHStock()
            MENote.Text = adj_x_sample_det_note.ToString
            viewStock()
        ElseIf action = "ins" Then
            TxtKurs.EditValue = 1
            viewWHStock()
            viewStock()
            SPQtyPL.EditValue = 1
        End If
    End Sub
    Private Sub FormSampleReturnPickSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View
    Sub viewStock()
        GVSample.ActiveFilter.Clear()
        Try
            'UPDATED 17 October 2014
            Dim id_wh_drawer_view As String = SLEDrawer.EditValue.ToString
            Dim id_wh_rack_view As String = SLERack.EditValue.ToString
            Dim id_wh_locator_view As String = SLELocator.EditValue.ToString
            Dim id_wh_view As String = SLEWH.EditValue.ToString

            Dim query As String = "CALL view_stock_sample('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '9999-12-01','2')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSample.DataSource = data
            GVSample.ActiveFilterString = "[qty_all_sample]>0"
            GVSample.Columns("name").GroupIndex = 0

            viewCost()
            viewImg()
            chooseCondition()
            checkExistInput()
            getQTYLimit()
            cantEdit()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub viewCost()
        
    End Sub
    Sub getCostCursored()
        Try
            Dim cost_cursor As Decimal = 0.0
            Try
                cost_cursor = Decimal.Parse(GVSample.GetFocusedRowCellValue("sample_price"))
                id_sample_price_selected = GVSample.GetFocusedRowCellValue("id_sample_price").ToString
            Catch ex As Exception
            End Try
            TxtRealCost.EditValue = cost_cursor
        Catch ex As Exception
        End Try
    End Sub
    Sub viewImg()
        Dim id_sample As String = ""
        Try
            id_sample = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
         pre_viewImages("1", PictureEdit1, id_sample, False)
    End Sub
    Sub viewWHStock()
        Dim query As String = ""
        'get id category on opt
        query = "SELECT id_comp_cat_wh FROM tb_opt "
        Dim id_comp_cat_wh As String = execute_query(query, 0, True, "", "", "", "")

        'view data comp/warehouse
        query = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name UNION ALL "
        query += "SELECT a.id_comp, a.comp_number, a.comp_name FROM tb_m_comp a WHERE a.id_comp_cat = '" + id_comp_cat_wh + "' "
        If id_wh <> "-1" Then
            query += "AND a.id_comp = '" + id_wh + "' "
        End If
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
        query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL "
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
        query += "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL "
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
        query = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL "
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    'Button Actoion
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyPL.EditValue)
        Dim qty_rec As Decimal = 0.0
        Dim qty_limit As Decimal = 0.0
        Dim current_name As String = 0.0
        Dim current_uom As String = ""
        Try
            qty_rec = Decimal.Parse(SPQtyPL.EditValue)
            qty_limit = Decimal.Parse(GVSample.GetFocusedRowCellValue("qty_all_sample"))
            current_name = GVSample.GetFocusedRowCellValue("name").ToString
            current_uom = GVSample.GetFocusedRowCellValue("uom").ToString
        Catch ex As Exception
        End Try

        If qty_input_grid > 0 And TxtRealCost.EditValue > 0 And qty_rec <= qty_limit Then
            If action = "ins" Then
                'Edit di Induk insert save langsung ke db
                checkExistInput()
                If Not ketemu Then
                    FormSampleAdjustmentOutSingle.newRows()
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_adj_out_sample_det", "0")
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellValue("id_sample").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("size").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("color", GVSample.GetFocusedRowCellValue("color").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("adj_out_sample_det_qty", qty_input_grid)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("adj_out_sample_det_price", TxtRealCost.EditValue)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_sample_price", id_sample_price_selected)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("adj_out_sample_det_amount", TxtAmount.EditValue)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("adj_out_sample_det_note", MENote.Text)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", GVSample.GetFocusedRowCellValue("id_wh_rack").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", GVSample.GetFocusedRowCellValue("id_wh_locator").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_comp", GVSample.GetFocusedRowCellValue("id_comp").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", GVSample.GetFocusedRowCellValue("wh_drawer").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("wh_rack", GVSample.GetFocusedRowCellValue("wh_rack").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("wh_locator", GVSample.GetFocusedRowCellValue("wh_locator").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("comp_name", GVSample.GetFocusedRowCellValue("comp_name").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.CloseEditor()
                    FormSampleAdjustmentOutSingle.GCDetail.RefreshDataSource()
                    FormSampleAdjustmentOutSingle.GVDetail.RefreshData()
                    Close()
                Else
                    errorCustom("This sample already exist in Adjustment List !")
                End If
            ElseIf action = "upd" Then
                If Not ketemu Then
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_adj_out_sample_det", "0")
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellValue("id_sample").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("size").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("color", GVSample.GetFocusedRowCellValue("color").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("adj_out_sample_det_qty", qty_input_grid)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("adj_out_sample_det_price", TxtRealCost.EditValue)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_sample_price", id_sample_price_selected)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("adj_out_sample_det_amount", TxtAmount.EditValue)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("adj_out_sample_det_note", MENote.Text)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_wh_drawer", GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_wh_rack", GVSample.GetFocusedRowCellValue("id_wh_rack").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_wh_locator", GVSample.GetFocusedRowCellValue("id_wh_locator").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("id_comp", GVSample.GetFocusedRowCellValue("id_comp").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("wh_drawer", GVSample.GetFocusedRowCellValue("wh_drawer").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("wh_rack", GVSample.GetFocusedRowCellValue("wh_rack").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("wh_locator", GVSample.GetFocusedRowCellValue("wh_locator").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.SetFocusedRowCellValue("comp_name", GVSample.GetFocusedRowCellValue("comp_name").ToString)
                    FormSampleAdjustmentOutSingle.GVDetail.CloseEditor()
                    FormSampleAdjustmentOutSingle.GCDetail.RefreshDataSource()
                    FormSampleAdjustmentOutSingle.GVDetail.RefreshData()
                    Close()
                Else
                    errorCustom("This sample already exist in Adjustment List !")
                End If
            End If
            FormSampleAdjustmentOutSingle.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
            FormSampleAdjustmentOutSingle.sayCurr()
        Else
            errorCustom("Qty/cost not allowed zero value and cannot exceed " + qty_limit.ToString + " " + current_uom + " ")
        End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

    End Sub
    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Try
            Dim id_sample As String = GVSample.GetFocusedRowCellValue("id_sample").ToString
            pre_viewImages("1", PictureEdit1, id_sample, True)
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
            If SLEDrawer.EditValue Is Nothing Then
                BtnViewStock.Enabled = False
            Else
                BtnViewStock.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Aneka Function
    Sub chooseCondition()
        Dim id_sample As String = ""
        Try
            id_sample = GVSample.GetFocusedRowCellValue("id_sample").ToString()
        Catch ex As Exception
        End Try

        If id_sample = "" Or GVSample.RowCount < 1 Then
            BtnChoose.Enabled = False
            LabelAttention.Text = "Please select specific drawer"
            LabelAttention.Visible = True
            SPQtyPL.Enabled = False
            MENote.Enabled = False
            TxtKurs.Enabled = False
        Else
            BtnChoose.Enabled = True
            LabelAttention.Visible = False
            SPQtyPL.Enabled = True
            MENote.Enabled = True
            TxtKurs.Enabled = True
        End If
        If TxtRealCost.EditValue = 0.0 Then
            BtnChoose.Enabled = False
            LabelAttention.Text = "Price can't blank"
            LabelAttention.Visible = True
            MENote.Enabled = False
            TxtKurs.Enabled = False
        Else
            BtnChoose.Enabled = True
            LabelAttention.Visible = False
            MENote.Enabled = True
            TxtKurs.Enabled = True
        End If
    End Sub

    Sub checkExistInput()
        ketemu = False
        Try
            Dim id_sample_cek As String = GVSample.GetFocusedRowCellValue("id_sample").ToString
            Dim id_wh_drawer_cek As String = GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString
            Dim id_sample_price_cek As String = GVSample.GetFocusedRowCellValue("id_sample_price").ToString
            For i As Integer = 0 To (FormSampleAdjustmentOutSingle.GVDetail.RowCount - 1)
                'Try
                Dim id_sample_data As String = FormSampleAdjustmentOutSingle.GVDetail.GetRowCellValue(i, "id_sample")
                Dim id_wh_drawer_data As String = FormSampleAdjustmentOutSingle.GVDetail.GetRowCellValue(i, "id_wh_drawer")
                Dim id_sample_price_data As String = FormSampleAdjustmentOutSingle.GVDetail.GetRowCellValue(i, "id_sample_price")
                If id_sample_data <> "" Then
                    If action = "ins" Then
                        If id_sample_cek = id_sample_data And id_wh_drawer_cek = id_wh_drawer_data And id_sample_price_cek = id_sample_price_data Then
                            ketemu = True
                            Exit For
                        End If
                    ElseIf action = "upd" Then
                        If id_sample_cek = id_sample_data And id_wh_drawer_cek = id_wh_drawer_data And id_sample_price_cek = id_sample_price_data And i <> indeks_edit Then
                            ketemu = True
                            Exit For
                        End If
                    End If
                End If
                'Catch ex As Exception

                'End Try
            Next
        Catch ex As Exception
            chooseCondition()
        End Try
    End Sub

    Private Sub GVSample_BeforeLeaveRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GVSample.BeforeLeaveRow
        Try
            id_sample_old = GVSample.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
    End Sub


    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim qty_input As Decimal = SPQtyPL.EditValue
        viewCost()
        viewImg()
        checkExistInput()
        getQTYLimit()
        cantEdit()
        getCostCursored()
        SPQtyPL.EditValue = 1
        chooseCondition()
        Cursor = Cursors.Default
    End Sub

    Sub cantEdit()
      
    End Sub

    Sub getQTYLimit()
        SPQtyPL.EditValue = 0
        TxtRealCost.EditValue = 0.0
        SPQtyLimit.EditValue = GVSample.GetFocusedRowCellValue("qty_all_sample")
    End Sub

    Sub getRealCost()
        ' Try
        Dim po_price_dec As Decimal = TxtRealCost.EditValue
        Dim kurs, price As Decimal
        kurs = TxtKurs.EditValue
        'MsgBox(TxtKurs.EditValue)
        price = kurs * po_price_dec
        TxtRealCost.EditValue = price
        'Catch ex As Exception

        'End Try
    End Sub

    Sub getAmount()
        Dim qty As Decimal = Decimal.Parse(SPQtyPL.EditValue)
        Dim cost As Decimal = Decimal.Parse(TxtRealCost.EditValue)
        TxtAmount.EditValue = qty * cost
    End Sub

    Private Sub TxtRealCost_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRealCost.EditValueChanged
        getAmount()
    End Sub

    Private Sub BtnViewStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStock.Click
        Try
            viewStock()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SPQtyLimit_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtyLimit.EditValueChanged
        'SPQtyLimit.EditValue = 0
        'MENote.Text = ""
    End Sub

    Private Sub SPQtyPL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtyPL.EditValueChanged
        getAmount()
    End Sub

    Private Sub GVSample_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSample.ColumnFilterChanged
        chooseCondition()
    End Sub
End Class