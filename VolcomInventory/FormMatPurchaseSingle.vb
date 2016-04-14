Public Class FormMatPurchaseSingle
    Public id_mat_purc_det As String = "-1"
    Public id_mat_price As String = "-1"
    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"

    Private Sub FormSamplePurchaseSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        If TEQty.EditValue = 0 Then
            TEQty.EditValue = 0.0
        End If
        TEPriceTot.EditValue = 0.0
        TEDiscount.EditValue = 0.0

        TEKurs.Text = FormMatPurchaseDet.TEKurs.EditValue
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", get_setup_field("id_currency_default"))

        If id_mat_purc_det = "" Then
            id_mat_purc_det = "-1"
        End If

        view_mat()
    End Sub

    Sub view_mat()
        Try
            Dim query As String
            query = "CALL view_mat_comp(" & FormMatPurchaseDet.id_comp_to & ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMat.DataSource = data
            '
            If Not data.Rows.Count < 1 Then
                If id_mat_price <> "-1" Then
                    '
                    Dim id_mat_det As String
                    id_mat_det = get_id_mat_det2(id_mat_price)
                    GVMat.FocusedRowHandle = find_row(GVMat, "id_mat_det", id_mat_det)
                    '
                End If
                view_image()
                view_mat_price(GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_image()
        If System.IO.File.Exists(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg") Then
            PictureEdit1.LoadAsync(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg")
        Else
            PictureEdit1.LoadAsync(material_image_path & "default" & ".jpg")
        End If
    End Sub
    Sub view_mat_price(ByVal id_mat_detx As String)
        Dim query As String = "SELECT tb_lookup_currency.currency,tb_m_mat_det_price.id_mat_det_price,tb_m_mat_det_price.mat_det_price_name,tb_m_mat_det_price.mat_det_price,tb_m_mat_det_price.mat_det_price_date FROM tb_m_mat_det_price,tb_lookup_currency WHERE tb_m_mat_det_price.id_currency=tb_lookup_currency.id_currency AND tb_m_mat_det_price.id_mat_det='" & id_mat_detx & "' AND tb_m_mat_det_price.id_comp_contact='" & FormMatPurchaseDet.id_comp_to & "' ORDER BY tb_m_mat_det_price.id_mat_det_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPrice.DataSource = data

        If id_mat_purc_det <> "-1" Then
            If Not data.Rows.Count < 1 Then
                GroupControlDetail.Enabled = True
                PanelControlButton.Enabled = True
                '
                query = String.Format("SELECT * FROM tb_mat_purc_det WHERE id_mat_purc_det = '{0}'", id_mat_purc_det)
                data = execute_query(query, -1, True, "", "", "", "")

                GVMatPrice.FocusedRowHandle = find_row(GVMatPrice, "id_mat_det_price", data.Rows(0)("id_mat_det_price").ToString)

                TEKurs.Text = FormMatPurchaseDet.TEKurs.EditValue
                TEPrice.EditValue = data.Rows(0)("mat_purc_det_price")
                TEQty.Text = data.Rows(0)("mat_purc_det_qty").ToString()
                TEDiscount.Text = data.Rows(0)("mat_purc_det_discount").ToString()
                TENote.Text = data.Rows(0)("mat_purc_det_note").ToString()
                load_mat_price()
                '
            Else
                GroupControlDetail.Enabled = False
                PanelControlButton.Enabled = False
            End If
        Else
            If id_mat_price <> "-1" Then
                GVMatPrice.FocusedRowHandle = find_row(GVMatPrice, "id_mat_det_price", id_mat_price)
            End If
            If Not data.Rows.Count < 1 Then
                GroupControlDetail.Enabled = True
                PanelControlButton.Enabled = True
                load_mat_price()
            Else
                GroupControlDetail.Enabled = False
                PanelControlButton.Enabled = False
            End If
        End If
    End Sub
    Sub load_mat_price()
        TEVendCur.Text = GVMatPrice.GetFocusedRowCellDisplayText("currency").ToString
        TEVendPrice.EditValue = GVMatPrice.GetFocusedRowCellValue("mat_det_price")
        TEUOM.Text = GVMat.GetFocusedRowCellDisplayText("uom").ToString

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

    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMat.FocusedRowChanged
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
        view_mat_price(GVMat.GetFocusedRowCellDisplayText("id_mat_det").ToString)
    End Sub

    Private Sub GVSamplePrice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPrice.FocusedRowChanged
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
    End Sub

    Private Sub GVSamplePrice_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatPrice.RowClick
        load_mat_price()
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
        Dim id_price, kurs, price, qty, discount, error_text, note As String
        error_text = "-1"
        '
        id_price = "0"
        kurs = "0"
        price = "0"
        qty = "0"
        discount = "0"
        note = ""
        '
        Try
            id_price = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
            If id_price = "" Then
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
        Else
            'check dupe
            Dim already = False
            If FormMatPurchaseDet.GVListPurchase.RowCount > 0 Then
                For i As Integer = 0 To FormMatPurchaseDet.GVListPurchase.RowCount - 1
                    If FormMatPurchaseDet.GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString And Not GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString = id_mat_price Then
                        already = True
                    End If
                Next
            End If

            If already = True Then
                stopCustom("This material already on list.")
            Else
                If id_mat_price <> "-1" Then
                    'edit
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "id_mat_det_price", GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "name", GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "code", GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "size", GVMat.GetFocusedRowCellDisplayText("size").ToString)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "color", GVMat.GetFocusedRowCellDisplayText("color").ToString)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "price", TEPrice.EditValue)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "qty", TEQty.EditValue)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "discount", TEDiscount.EditValue)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "total", TEPriceTot.EditValue)
                    FormMatPurchaseDet.GVListPurchase.SetRowCellValue(FormMatPurchaseDet.GVListPurchase.FocusedRowHandle, "note", TENote.EditValue)
                    FormMatPurchaseDet.GVListPurchase.RefreshData()
                    FormMatPurchaseDet.GCListPurchase.Refresh()
                    FormMatPurchaseDet.calculate()
                    FormMatPurchaseDet.show_but()
                    Close()
                Else
                    'insert
                    Dim newRow As DataRow = (TryCast(FormMatPurchaseDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_mat_det_price") = GVMatPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
                    newRow("name") = GVMat.GetFocusedRowCellDisplayText("mat_det_name").ToString
                    newRow("code") = GVMat.GetFocusedRowCellDisplayText("mat_det_code").ToString
                    newRow("color") = GVMat.GetFocusedRowCellDisplayText("color").ToString
                    newRow("size") = GVMat.GetFocusedRowCellDisplayText("size").ToString
                    newRow("price") = TEPrice.EditValue
                    newRow("qty") = TEQty.EditValue
                    newRow("discount") = TEDiscount.EditValue
                    newRow("total") = TEPriceTot.EditValue
                    newRow("note") = TENote.Text

                    TryCast(FormMatPurchaseDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormMatPurchaseDet.GCListPurchase.RefreshDataSource()
                    FormMatPurchaseDet.calculate()
                    FormMatPurchaseDet.show_but()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub FormSamplePurchaseSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Try
            If System.IO.File.Exists(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_sample").ToString & ".jpg") Then
                Process.Start(material_image_path & GVMat.GetFocusedRowCellDisplayText("id_sample").ToString & ".jpg")
            Else
                Process.Start(material_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class