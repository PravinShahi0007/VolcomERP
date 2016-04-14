Public Class FormMatWOSingle
    Public id_mat_wo_det As String = "-1"
    Public id_mat_det As String = "-1"
    Public id_mat_det_result As String = "-1"
    Public id_mat_det_price As String = "-1"
    Public id_mat_det_price_result As String = "-1"
    Public id_comp As String = "-1"
    Public id_ovh As String = "-1"
    Public id_ovh_price As String = "-1"
    Public id_pop_up As String = "-1"

    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"

    Private Sub FormMatWOSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim def_decimal As Decimal = 0.0
        TEQty.EditValue = def_decimal
        TEQtyMat.EditValue = def_decimal
        TEDiscount.EditValue = def_decimal

        view_currency(LECurrency)

        TEKurs.EditValue = FormMatWODet.TEKurs.EditValue
        LECurrency.EditValue = Nothing
        'LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormMatPurchaseDet.LECurrency.EditValue.ToString)
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", get_setup_field("id_currency_default"))

        If id_pop_up = "1" Then
            'result
            If id_mat_wo_det = "" Then
                id_mat_wo_det = "-1"
            End If
            view_mat_result()
            XTPMatBefore.PageVisible = False
            XTPMatAfter.PageVisible = True
            GroupControlDetail.Visible = True
            GroupControlOVH.Visible = True
            GroupControlDetMat.Visible = False
        ElseIf id_pop_up = "2" Then
            'material
            view_mat()
            XTPMatBefore.PageVisible = True
            XTPMatAfter.PageVisible = False
            GroupControlDetail.Visible = False
            GroupControlOVH.Visible = False
            GroupControlDetMat.Visible = True
        End If
    End Sub

    Sub view_mat()
        Try
            Dim query As String
            query = "CALL view_mat()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
            If data.Rows.Count > 0 Then
                If Not id_mat_det = "-1" Then
                    GVMat.FocusedRowHandle = find_row(GVMat, "id_mat_det", id_mat_det)
                    view_mat_price(GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                Else
                    view_mat_price(GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                End If
                view_image()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_mat_result()
        Try
            Dim query As String
            query = "CALL view_mat()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatResult.DataSource = data
            '
            If Not data.Rows.Count < 1 Then
                If id_mat_det_result <> "-1" Then
                    '
                    GVMatResult.FocusedRowHandle = find_row(GVMatResult, "id_mat_det", id_mat_det_result)
                    '
                End If
                view_image_result()
                view_mat_result_price(GVMatResult.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                view_ovh_price()
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_mat_price(ByVal id_mat_detx As String)
        Dim query As String = "CALL view_mat_det_price_cost(" & id_mat_detx & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPrice.DataSource = data
        If data.Rows.Count > 0 Then
            If Not id_mat_det_price = "-1" Then
                GVMatPrice.FocusedRowHandle = find_row(GVMatPrice, "id_mat_det_price", id_mat_det_price)
                TEQtyMat.EditValue = FormMatWODet.GVMaterial.GetFocusedRowCellValue("qty")
                TENoteMat.Text = FormMatWODet.GVMaterial.GetFocusedRowCellValue("note").ToString
            End If

            TEUOMMat.Text = GVMat.GetFocusedRowCellDisplayText("uom").ToString
            BSave.Enabled = True
        Else
            TEUOMMat.Text = ""
            BSave.Enabled = False
        End If
    End Sub
    Sub view_mat_result_price(ByVal id_mat_detx As String)
        Dim query As String = "CALL view_mat_det_price_cost(" & id_mat_detx & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatResultPrice.DataSource = data
        If data.Rows.Count > 0 Then
            If Not id_mat_det_price_result = "-1" Then
                GVMatResultPrice.FocusedRowHandle = find_row(GVMatResultPrice, "id_mat_det_price", id_mat_det_price_result)
            End If
        End If
        check_but_result()
    End Sub
    Sub view_image()
        If System.IO.File.Exists(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg") Then
            PEMat.LoadAsync(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg")
        Else
            PEMat.LoadAsync(material_image_path & "default" & ".jpg")
        End If
    End Sub
    Sub view_image_result()
        If System.IO.File.Exists(material_image_path & GVMatResult.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg") Then
            PEMatResult.LoadAsync(material_image_path & GVMatResult.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg")
        Else
            PEMatResult.LoadAsync(material_image_path & "default" & ".jpg")
        End If
    End Sub
    Sub view_ovh_price()
        Dim query As String = "SELECT a.id_ovh_price,a.ovh_price_name,a.ovh_price,a.id_currency,a.ovh_price_date,d.currency,a.id_currency "
        query += "FROM tb_m_ovh_price a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact=b.id_comp_contact "
        query += "INNER JOIN tb_m_ovh c ON a.id_ovh=c.id_ovh "
        query += "INNER JOIN tb_lookup_currency d ON a.id_currency=d.id_currency "
        query += "WHERE c.id_ovh='" & id_ovh & "' AND b.id_comp='" & id_comp & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOverhead.DataSource = data

        If Not data.Rows.Count < 1 Then
            GroupControlDetail.Enabled = True
            PanelControlButton.Enabled = True
            If id_ovh_price <> "-1" Then
                GroupControlDetail.Enabled = True
                PanelControlButton.Enabled = True
                '
                GVOverhead.FocusedRowHandle = find_row(GVOverhead, "id_ovh_price", id_ovh_price)
                '
                TEKurs.EditValue = FormMatWODet.TEKurs.EditValue
                TEPrice.EditValue = FormMatWODet.GVListPurchase.GetFocusedRowCellValue("price")
                TEQty.EditValue = FormMatWODet.GVListPurchase.GetFocusedRowCellValue("qty")
                TEDiscount.EditValue = FormMatWODet.GVListPurchase.GetFocusedRowCellValue("discount")
                TENote.Text = FormMatWODet.GVListPurchase.GetFocusedRowCellValue("note").ToString
                load_ovh_price()
            Else
                load_ovh_price()
            End If
        Else
            GroupControlDetail.Enabled = False
            PanelControlButton.Enabled = False
        End If
    End Sub
    Sub load_ovh_price()
        TEVendCur.Text = GVOverhead.GetFocusedRowCellDisplayText("currency").ToString
        TEVendPrice.EditValue = Decimal.Parse(GVOverhead.GetFocusedRowCellDisplayText("ovh_price").ToString)
        TEUOM.Text = GVMatResult.GetFocusedRowCellDisplayText("uom").ToString

        calculate()
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub GVMat_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMat.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        view_image()
        view_mat_price(GVMat.GetFocusedRowCellValue("id_mat_det").ToString)
        check_but_mat()
    End Sub
    Private Sub GVSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMat.RowClick
        view_image()
    End Sub
    Private Sub GVMatResult_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatResult.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        If GVMatResult.RowCount > 0 Then
            view_mat_result_price(GVMatResult.GetFocusedRowCellValue("id_mat_det").ToString)
            view_image_result()
        End If
    End Sub
    Private Sub GVSamplePrice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVOverhead.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        check_but_result()
    End Sub

    Private Sub GVOVHPrice_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVOverhead.RowClick
        load_ovh_price()
    End Sub

    Private Sub TEKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEKurs.EditValueChanged
        calculate()
    End Sub

    Private Sub TEQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEQty.EditValueChanged
        calculate()
    End Sub

    Private Sub TEDiscount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDiscount.EditValueChanged
        calculate()
    End Sub
    Sub calculate()
        Try
            Dim price_tot As Decimal

            'If TEVendPrice.EditValue = 0 Or TEKurs.EditValue = 0 Then
            '    TEPrice.EditValue = 0
            'Else
            '    price_kurs = TEVendPrice.EditValue * TEKurs.EditValue
            '    TEPrice.EditValue = price_kurs
            'End If
            'If TEPrice.EditValue = 0 Or TEQty.EditValue = 0 Then
            '    TEPriceTot.EditValue = 0
            'Else
            '    price_tot = (TEPrice.EditValue - TEDiscount.EditValue) * TEQty.EditValue
            '    TEPriceTot.EditValue = price_tot
            'End If
            TEPrice.EditValue = TEVendPrice.EditValue
            If TEVendPrice.EditValue = 0 Or TEQty.EditValue = 0 Then
                TEPriceTot.EditValue = 0
            Else
                price_tot = (TEVendPrice.EditValue - TEDiscount.EditValue) * TEQty.EditValue
                TEPriceTot.EditValue = price_tot
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim id_price, kurs, price, qty, discount, error_text, note, id_mat As String
        error_text = "-1"
        '
        id_price = "0"
        id_mat = "0"
        kurs = "0"
        price = "0"
        qty = "0"
        discount = "0"
        note = ""
        '
        If id_pop_up = "1" Then 'result
            Try
                id_price = GVOverhead.GetFocusedRowCellDisplayText("id_ovh_price").ToString
                id_mat = GVMatResult.GetFocusedRowCellDisplayText("id_mat_det").ToString
                If id_price = "" Or id_mat = "" Then
                    error_text = "1"
                End If
                kurs = TEKurs.EditValue
                price = TEPrice.EditValue
                qty = TEQty.EditValue
                discount = TEDiscount.EditValue
                note = TENote.Text
            Catch ex As Exception
                error_text = "1"
            End Try

            If error_text <> "-1" Then
                'ada error
                errorInput()
            ElseIf TEQty.EditValue = 0 Then
                stopCustom("Please input qty material.")
            Else
                'check dupe
                Dim already = False
                If FormMatWODet.GVListPurchase.RowCount > 0 Then
                    For i As Integer = 0 To FormMatWODet.GVListPurchase.RowCount - 1
                        If (FormMatWODet.GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString = id_mat And Not id_mat_det = id_mat) And (FormMatWODet.GVListPurchase.GetRowCellValue(i, "id_ovh_price").ToString = id_price And Not id_ovh_price = id_price) Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("This material already on list.")
                Else
                    If id_ovh_price <> "-1" Then
                        'edit
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "id_ovh_price", GVOverhead.GetFocusedRowCellDisplayText("id_ovh_price").ToString)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "id_mat_det", GVMatResult.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "uom", GVMatResult.GetFocusedRowCellDisplayText("uom").ToString)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "name", GVMatResult.GetFocusedRowCellDisplayText("mat_det_name").ToString)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "code", GVMatResult.GetFocusedRowCellDisplayText("mat_det_code").ToString)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "price", TEPrice.EditValue)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "qty", TEQty.EditValue)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "discount", TEDiscount.EditValue)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "total", TEPriceTot.EditValue)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "note", TENote.EditValue)
                        FormMatWODet.GVListPurchase.SetRowCellValue(FormMatWODet.GVListPurchase.FocusedRowHandle, "id_mat_det_price", GVMatResultPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                        FormMatWODet.GCListPurchase.RefreshDataSource()
                        FormMatWODet.calculate()
                        FormMatWODet.show_but()
                        Close()
                    Else
                        'insert
                        Dim newRow As DataRow = (TryCast(FormMatWODet.GCListPurchase.DataSource, DataTable)).NewRow()
                        newRow("id_ovh_price") = GVOverhead.GetFocusedRowCellDisplayText("id_ovh_price").ToString
                        newRow("id_mat_det") = GVMatResult.GetFocusedRowCellDisplayText("id_mat_det").ToString
                        newRow("uom") = GVMatResult.GetFocusedRowCellDisplayText("uom").ToString
                        newRow("name") = GVMatResult.GetFocusedRowCellDisplayText("mat_det_name").ToString
                        newRow("code") = GVMatResult.GetFocusedRowCellDisplayText("mat_det_code").ToString
                        newRow("id_mat_det_price") = GVMatResultPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
                        newRow("price") = TEPrice.EditValue
                        newRow("qty") = TEQty.EditValue
                        newRow("discount") = TEDiscount.EditValue
                        newRow("total") = TEPriceTot.EditValue
                        newRow("note") = TENote.Text

                        TryCast(FormMatWODet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                        FormMatWODet.GCListPurchase.RefreshDataSource()
                        FormMatWODet.calculate()
                        FormMatWODet.show_but()
                        Close()
                    End If
                End If
            End If
        ElseIf id_pop_up = "2" Then 'material
            Try
                id_mat = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
                If id_mat = "" Then
                    error_text = "1"
                End If
                note = TENote.Text
            Catch ex As Exception
                error_text = "1"
            End Try

            If error_text <> "-1" Then
                'ada error
                errorInput()
            ElseIf TEQtyMat.EditValue = 0 Then
                stopCustom("Please input qty material.")
            Else
                'check dupe
                Dim already = False
                If FormMatWODet.GVMaterial.RowCount > 0 Then
                    For i As Integer = 0 To FormMatWODet.GVMaterial.RowCount - 1
                        If (FormMatWODet.GVMaterial.GetRowCellValue(i, "id_mat_det").ToString = id_mat And Not id_mat_det = id_mat) Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("This material already on list.")
                Else
                    If id_mat_det_price <> "-1" Then
                        'edit
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "id_mat_det", GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "name", GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString)
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "code", GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString)
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "uom", GVMat.GetFocusedRowCellDisplayText("uom").ToString)
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "price", GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price"))
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "qty", TEQtyMat.EditValue)
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "total", TEQtyMat.EditValue * GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price"))
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "note", TENoteMat.EditValue)
                        FormMatWODet.GVMaterial.SetRowCellValue(FormMatWODet.GVMaterial.FocusedRowHandle, "id_mat_det_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                        FormMatWODet.GCMaterial.RefreshDataSource()
                        FormMatWODet.show_but_mat()
                        Close()
                    Else
                        'insert
                        Dim newRow As DataRow = (TryCast(FormMatWODet.GCMaterial.DataSource, DataTable)).NewRow()
                        'newRow("id_ovh_price") = GVOverhead.GetFocusedRowCellDisplayText("id_ovh_price").ToString
                        newRow("id_mat_det") = GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
                        newRow("name") = GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString
                        newRow("code") = GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString
                        newRow("uom") = GVMat.GetFocusedRowCellDisplayText("uom").ToString
                        newRow("id_mat_det_price") = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString

                        newRow("price") = GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price")
                        newRow("qty") = TEQtyMat.EditValue
                        newRow("total") = TEQtyMat.EditValue * GVMatPrice.GetFocusedRowCellDisplayText("mat_det_price")
                        newRow("note") = TENoteMat.Text
                        TryCast(FormMatWODet.GCMaterial.DataSource, DataTable).Rows.Add(newRow)
                        FormMatWODet.GCMaterial.RefreshDataSource()
                        FormMatWODet.show_but_mat()
                        Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FormSamplePurchaseSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Try
            If System.IO.File.Exists(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg") Then
                Process.Start(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg")
            Else
                Process.Start(material_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BViewResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewResult.Click
        Try
            If System.IO.File.Exists(material_image_path & GVMatResult.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg") Then
                Process.Start(material_image_path & GVMatResult.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg")
            Else
                Process.Start(material_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub TEPrice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEPrice.EditValueChanged
        calculate()
    End Sub
    Sub check_but_result()
        If Not GVMatResultPrice.RowCount > 0 Or Not GVOverhead.RowCount > 0 Then
            BSave.Enabled = False
        Else
            BSave.Enabled = True
        End If
    End Sub
    Sub check_but_mat()
        If Not GVMatPrice.RowCount > 0 Then
            BSave.Enabled = False
        Else
            BSave.Enabled = True
        End If
    End Sub

    Private Sub BSetDefault_Click(sender As Object, e As EventArgs) Handles BSetDefault.Click
        If GVMatResult.RowCount > 0 Then
            Dim id_mat_det As String = GVMatResult.GetFocusedRowCellValue("id_mat_det").ToString
            FormMasterRawMaterialDetSingle.action = "upd"
            FormMasterRawMaterialDetSingle.id_mat_det = id_mat_det
            FormMasterRawMaterialDetSingle.ShowDialog()
        Else
            stopCustom("No material selected.")
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BRefreshPrice.Click
        If GVMatResult.RowCount > 0 Then
            view_mat_result_price(GVMatResult.GetFocusedRowCellValue("id_mat_det").ToString)
        Else
            view_mat_result_price("-1")
        End If
    End Sub

    Private Sub GVMatResult_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVMatResult.ColumnFilterChanged
        If GVMatResult.RowCount > 0 Then
            view_mat_result_price(GVMatResult.GetFocusedRowCellValue("id_mat_det").ToString)
        Else
            view_mat_result_price("-1")
        End If
    End Sub
End Class