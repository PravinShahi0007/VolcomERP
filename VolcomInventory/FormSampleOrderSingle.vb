Public Class FormSampleOrderSingle 
    Dim sample_image_path As String = get_setup_field("pic_path_sample") & "\"
    Public action_pop As String
    Dim price As Decimal = 0.0
    Dim qty As Decimal = 0.0
    Public indeks_edit As Integer = 0
    Public id_sample_edit As Integer
    Public sample_code As String
    Public qty_edit As Decimal
    Public remark_edit As String
    Public id_sample_ret_price_edit As Integer

    Private Sub FormSampleOrderSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSampleOrderSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSample()
        If action_pop = "upd" Then
            GVProduct.FocusedRowHandle = find_row(GVProduct, "id_sample", id_sample_edit)
            SLEPrice.EditValue = id_sample_ret_price_edit
            SPQty.EditValue = qty_edit
            MENote.Text = remark_edit
            GVProduct.ApplyFindFilter("")
            GVProduct.ActiveFilterString = "[code] = '" + toDoubleQuote(sample_code.ToString) + "' "
            GVProduct.FocusedRowHandle = find_row(GVProduct, "id_sample", id_sample_edit.ToString)
        End If
    End Sub

    'VIEW
    Sub viewSample()
        Dim query As String = "CALL view_stock_sample('0', '0','0','0', '9999-12-01', '1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount > 0 Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    Sub viewRetailPrice(ByVal id_sample_param As String)
        Dim query As String = "SELECT a.sample_ret_price, c.design_price_type, a.sample_ret_price_date, a.sample_ret_price_start_date, a.sample_ret_price_name, a.id_currency, b.currency,a.id_sample, "
        query += "a.id_sample_ret_price, IF(a.is_print='1', 'Yes', 'No') AS is_print "
        query += "FROM tb_m_sample_ret_price a "
        query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency  "
        query += "INNER JOIN tb_lookup_design_price_type c ON c.id_design_price_type = a.id_design_price_type "
        query += "WHERE a.id_sample = '" + id_sample_param + "' "
        query += "ORDER BY a.sample_ret_price_start_date DESC "
        viewSearchLookupQuery(SLEPrice, query, "id_sample_ret_price", "sample_ret_price", "id_sample_ret_price")
    End Sub

    Sub viewWH(ByVal id_sample_param As String)
        Dim query As String = ""
        query += "SELECT (e.comp_name) AS wh, a.id_sample, "
        query += "SUM(IF(a.id_storage_category='2', CONCAT('-', a.qty_sample), a.qty_sample)) AS qty_all_sample, "
        query += "SUM(IF(a.id_stock_status='1', (IF(a.id_storage_category='2', CONCAT('-', a.qty_sample), a.qty_sample)),'0')) AS qty_normal, "
        query += "SUM(IF(a.id_stock_status='2', (IF(a.id_storage_category='1', CONCAT('-', a.qty_sample), a.qty_sample)),'0')) AS qty_reserved, "
        query += "f.id_departement, f.departement "
        query += "FROM tb_storage_sample a "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack c ON c.id_wh_rack = b.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator d ON d.id_wh_locator = c.id_wh_locator "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_departement f on f.id_departement = e.id_departement "
        query += "WHERE a.id_sample ='" + id_sample_param + "' "
        query += "GROUP BY e.id_comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCWH.DataSource = data
    End Sub

    Sub getAmount()
        price = 0.0
        qty = 0.0

        'get price
        Try
            price = Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString)
        Catch ex As Exception

        End Try

        'get qty
        Try
            qty = Decimal.Parse(SPQty.EditValue.ToString)
        Catch ex As Exception

        End Try

        Dim amount As Decimal = price * qty
        TxtAmount.EditValue = amount
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_samplex As String = "0"
        Dim id_sample_ret_pricex As String = "0"
        Try
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, False)
        viewRetailPrice(id_samplex)

        'get id_price 
        Try
            id_sample_ret_pricex = SLEPrice.EditValue.ToString
        Catch ex As Exception

        End Try

        'show wh detail
        viewWH(id_samplex)

        'active/non choose
        If id_samplex = "0" Or id_sample_ret_pricex = "0" Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, True)
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Dim qty_input As Decimal = Decimal.Parse(SPQty.EditValue.ToString)
        If qty_input > 0 Then
            If action_pop = "ins" Then
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSampleOrderDet.GVItemList.RowCount - 1)
                    Dim id_sample_cek As String = 0
                    Try
                        id_sample_cek = FormSampleOrderDet.GVItemList.GetRowCellValue(i, "id_sample").ToString
                    Catch ex As Exception
                    End Try
                    If id_sample_cek = GVProduct.GetFocusedRowCellValue("id_sample").ToString Then
                        is_duplicate = True
                        Exit For
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This sample already exist in Item List !")
                Else
                    Dim newRow As DataRow = (TryCast(FormSampleOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_sample_order_det") = "0"
                    newRow("name") = GVProduct.GetFocusedRowCellValue("name").ToString
                    newRow("code") = GVProduct.GetFocusedRowCellValue("code").ToString
                    newRow("size") = GVProduct.GetFocusedRowCellValue("size").ToString
                    newRow("sample_order_det_qty") = SPQty.EditValue
                    newRow("id_sample_ret_price") = SLEPrice.EditValue.ToString
                    newRow("sample_ret_price") = Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString)
                    newRow("sample_order_det_amount") = Decimal.Parse(TxtAmount.EditValue.ToString)
                    newRow("sample_order_det_note") = MENote.Text.ToString
                    newRow("id_sample") = GVProduct.GetFocusedRowCellValue("id_sample").ToString
                    TryCast(FormSampleOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSampleOrderDet.GCItemList.RefreshDataSource()
                    FormSampleOrderDet.GVItemList.RefreshData()
                    FormSampleOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSampleOrderDet.GVItemList.FocusedRowHandle = find_row(FormSampleOrderDet.GVItemList, "id_sample", GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                    FormSampleOrderDet.check_but()
                    Close()
                End If
            ElseIf action_pop = "upd" Then
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSampleOrderDet.GVItemList.RowCount - 1)
                    Dim id_sample_cek As String = 0
                    Try
                        id_sample_cek = FormSampleOrderDet.GVItemList.GetRowCellValue(i, "id_sample").ToString
                    Catch ex As Exception

                    End Try
                    If id_sample_cek = GVProduct.GetFocusedRowCellValue("id_sample").ToString And i <> indeks_edit Then
                        is_duplicate = True
                        Exit For
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This sample already exist in Item List !")
                Else
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("name", GVProduct.GetFocusedRowCellValue("name").ToString)
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("code", GVProduct.GetFocusedRowCellValue("code").ToString)
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("size", GVProduct.GetFocusedRowCellValue("size").ToString)
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("sample_order_det_qty", SPQty.EditValue)
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("id_sample_ret_price", SLEPrice.EditValue.ToString)
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("sample_ret_price", Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString))
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("sample_order_det_amount", Decimal.Parse(TxtAmount.EditValue.ToString))
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("sample_order_det_note", MENote.Text.ToString)
                    FormSampleOrderDet.GVItemList.SetFocusedRowCellValue("id_sample", GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                    FormSampleOrderDet.GCItemList.RefreshDataSource()
                    FormSampleOrderDet.GVItemList.RefreshData()
                    FormSampleOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSampleOrderDet.check_but()
                    Close()
                End If
            End If
        Else
            errorCustom("Qty not allowed zero value ! ")
        End If
    End Sub

    Private Sub SLEPrice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEPrice.EditValueChanged
        If SLEPrice.EditValue = Nothing Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
        getAmount()
    End Sub
    Private Sub SPQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQty.EditValueChanged
        getAmount()
    End Sub

End Class