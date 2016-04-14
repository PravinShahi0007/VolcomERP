Public Class FormMatStorageIn
    Dim mat_image_path As String = get_setup_field("pic_path_mat") & "\"
    Public id_mat_det As String
    Public action As String
    Public id_storage_sample As String
    Dim id_comp As String
    Dim id_mat_det_price As String
    Public id_pl_sample_purc_det_unique As String
    Dim currency_po As String
    Dim po_price As String
    'purc
    Dim id_mat_purc_det As String
    Public id_mat_purc_rec_det As String
    'wo
    Dim id_mat_wo_det As String = "-1"
    Public id_mat_wo_rec_det As String = "-1"
    'ret in purc
    Public id_mat_purc_ret_in_det As String = "-1"
    'ret in prod
    Public id_mat_prod_ret_in_det As String = "-1"
    '
    Public report_mark_type As String = "-1"
    Public id_report As String = "-1"
    Dim id_locator As String
    Dim id_rack As String
    Dim id_drawer As String
    Public id_pop_up As String = "-1"

    Private Sub FormMatStorageIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = ""
        Dim data As DataTable

        'Fill Lookup Edit
        viewComp()

        'Load information
        If action = "ins" Then
            If id_pop_up = "1" Then 'rec mat purc
                Try
                    query = "SELECT IFNULL(a.mat_purc_rec_det_qty,0) as mat_purc_rec_det_qty,IFNULL(a.mat_purc_rec_det_qty_stored,0) as mat_purc_rec_det_qty_stored,e.id_mat_det,f.mat_det_code,f.mat_det_name,d.mat_purc_det_price,d.id_mat_det_price,d1.mat_purc_number, (d1.id_currency) AS id_currency_po, (d2.currency) AS currency_po, d.id_mat_purc_det, d.id_mat_det_price FROM tb_mat_purc_rec_det a "
                    query += "INNER JOIN tb_mat_purc_det d ON a.id_mat_purc_det = d.id_mat_purc_det "
                    query += "INNER JOIN tb_mat_purc d1 ON d.id_mat_purc = d1.id_mat_purc "
                    query += "INNER JOIN tb_lookup_currency d2 ON d1.id_currency = d2.id_currency "
                    query += "INNER JOIN tb_m_mat_det_price e ON e.id_mat_det_price = d.id_mat_det_price "
                    query += "INNER JOIN tb_m_mat_det f ON e.id_mat_det = f.id_mat_det "
                    query += "WHERE a.id_mat_purc_rec_det = '" + id_mat_purc_rec_det + "'  "
                    data = execute_query(query, -1, True, "", "", "", "")
                    id_mat_det = data.Rows(0)("id_mat_det").ToString
                    id_mat_purc_det = data.Rows(0)("id_mat_purc_det").ToString
                    LabelCode.Text = data.Rows(0)("mat_det_code").ToString
                    LabelSampleName.Text = data.Rows(0)("mat_det_name").ToString
                    id_mat_det_price = data.Rows(0)("id_mat_det_price").ToString
                    po_price = data.Rows(0)("mat_purc_det_price").ToString
                    LabelPONumber.Text = data.Rows(0)("mat_purc_number").ToString
                    currency_po = data.Rows(0)("currency_po").ToString
                    LabelCurrPO.Text = currency_po.ToString
                    LabelPOPrice.Text = Decimal.Parse(po_price).ToString("N2")
                    TxtPrice.Text = po_price.ToString
                    Dim jum As Decimal = data.Rows(0)("mat_purc_rec_det_qty") - data.Rows(0)("mat_purc_rec_det_qty_stored")
                    SPQtyLimit.EditValue = jum
                Catch ex As Exception
                    errorCustom(ex.ToString)
                    Close()
                End Try
            ElseIf id_pop_up = "2" Then 'rec mat wo
                Try
                    query = "SELECT IFNULL(a.mat_wo_rec_det_qty,0) as mat_wo_rec_det_qty,IFNULL(a.mat_wo_rec_det_qty_stored,0) as mat_wo_rec_det_qty_stored,e.id_mat_det,f.mat_det_code,f.mat_det_name,d.mat_wo_det_price,d.id_mat_det_price,d1.mat_wo_number, (d1.id_currency) AS id_currency_po, (d2.currency) AS currency_po, d.id_mat_wo_det, d.id_mat_det_price FROM tb_mat_wo_rec_det a "
                    query += "INNER JOIN tb_mat_wo_det d ON a.id_mat_wo_det = d.id_mat_wo_det "
                    query += "INNER JOIN tb_mat_wo d1 ON d.id_mat_wo = d1.id_mat_wo "
                    query += "INNER JOIN tb_lookup_currency d2 ON d1.id_currency = d2.id_currency "
                    query += "LEFT JOIN tb_m_mat_det_price e ON e.id_mat_det_price = d.id_mat_det_price_result "
                    query += "LEFT JOIN tb_m_mat_det f ON e.id_mat_det = f.id_mat_det "
                    query += "WHERE a.id_mat_wo_rec_det = '" + id_mat_wo_rec_det + "'  "
                    data = execute_query(query, -1, True, "", "", "", "")
                    id_mat_det = data.Rows(0)("id_mat_det").ToString
                    id_mat_wo_det = data.Rows(0)("id_mat_wo_det").ToString
                    LabelCode.Text = data.Rows(0)("mat_det_code").ToString
                    LabelSampleName.Text = data.Rows(0)("mat_det_name").ToString
                    id_mat_det_price = data.Rows(0)("id_mat_det_price").ToString
                    po_price = data.Rows(0)("mat_wo_det_price").ToString
                    LabelPONumber.Text = data.Rows(0)("mat_wo_number").ToString
                    currency_po = data.Rows(0)("currency_po").ToString
                    LabelCurrPO.Text = currency_po.ToString
                    LabelPOPrice.Text = Decimal.Parse(po_price).ToString("N2")
                    TxtPrice.Text = po_price.ToString
                    Dim jum As Decimal = data.Rows(0)("mat_wo_rec_det_qty") - data.Rows(0)("mat_wo_rec_det_qty_stored")
                    SPQtyLimit.EditValue = jum
                Catch ex As Exception
                    errorCustom(ex.ToString)
                    Close()
                End Try
            ElseIf id_pop_up = "3" Then 'ret in mat purc
                Try
                    query = "SELECT IFNULL(a.mat_purc_ret_in_det_qty,0) as mat_purc_ret_in_det_qty,IFNULL(a.mat_purc_ret_in_det_qty_stored,0) as mat_purc_ret_in_det_qty_stored,e.id_mat_det,f.mat_det_code,f.mat_det_name,d.mat_purc_det_price,d.id_mat_det_price,d1.mat_purc_number, (d1.id_currency) AS id_currency_po, (d2.currency) AS currency_po, d.id_mat_purc_det, d.id_mat_det_price FROM tb_mat_purc_ret_in_det a "
                    query += "INNER JOIN tb_mat_purc_det d ON a.id_mat_purc_det = d.id_mat_purc_det "
                    query += "INNER JOIN tb_mat_purc d1 ON d.id_mat_purc = d1.id_mat_purc "
                    query += "INNER JOIN tb_lookup_currency d2 ON d1.id_currency = d2.id_currency "
                    query += "INNER JOIN tb_m_mat_det_price e ON e.id_mat_det_price = d.id_mat_det_price "
                    query += "INNER JOIN tb_m_mat_det f ON e.id_mat_det = f.id_mat_det "
                    query += "WHERE a.id_mat_purc_ret_in_det = '" + id_mat_purc_ret_in_det + "'  "
                    data = execute_query(query, -1, True, "", "", "", "")
                    id_mat_det = data.Rows(0)("id_mat_det").ToString
                    id_mat_purc_det = data.Rows(0)("id_mat_purc_det").ToString
                    LabelCode.Text = data.Rows(0)("mat_det_code").ToString
                    LabelSampleName.Text = data.Rows(0)("mat_det_name").ToString
                    id_mat_det_price = data.Rows(0)("id_mat_det_price").ToString
                    po_price = data.Rows(0)("mat_purc_det_price").ToString
                    LabelPONumber.Text = data.Rows(0)("mat_purc_number").ToString
                    currency_po = data.Rows(0)("currency_po").ToString
                    LabelCurrPO.Text = currency_po.ToString
                    LabelPOPrice.Text = Decimal.Parse(po_price).ToString("N2")
                    TxtPrice.Text = po_price.ToString
                    Dim jum As Decimal = data.Rows(0)("mat_purc_ret_in_det_qty") - data.Rows(0)("mat_purc_ret_in_det_qty_stored")
                    SPQtyLimit.EditValue = jum
                Catch ex As Exception
                    errorCustom(ex.ToString)
                    Close()
                End Try
            ElseIf id_pop_up = "4" Then 'ret in mat prod
                Try
                    query = "SELECT IFNULL(a.mat_prod_ret_in_det_qty,0) as mat_prod_ret_in_det_qty,IFNULL(a.mat_prod_ret_in_det_qty_stored,0) as mat_prod_ret_in_det_qty_stored,e.id_mat_det,f.mat_det_code,f.mat_det_name,d.pl_mrs_det_price,d.id_mat_det_price,d1.pl_mrs_number, (d1.id_currency) AS id_currency_po, (d2.currency) AS currency_po, d.id_pl_mrs_det, d.id_mat_det_price FROM tb_mat_prod_ret_in_det a "
                    query += "INNER JOIN tb_pl_mrs_det d ON a.id_pl_mrs_det = d.id_pl_mrs_det "
                    query += "INNER JOIN tb_pl_mrs d1 ON d.id_pl_mrs = d1.id_pl_mrs "
                    query += "INNER JOIN tb_lookup_currency d2 ON d1.id_currency = d2.id_currency "
                    query += "INNER JOIN tb_m_mat_det_price e ON e.id_mat_det_price = d.id_mat_det_price "
                    query += "INNER JOIN tb_m_mat_det f ON e.id_mat_det = f.id_mat_det "
                    query += "WHERE a.id_mat_prod_ret_in_det = '" + id_mat_prod_ret_in_det + "'  "
                    data = execute_query(query, -1, True, "", "", "", "")
                    id_mat_det = data.Rows(0)("id_mat_det").ToString
                    LabelCode.Text = data.Rows(0)("mat_det_code").ToString
                    LabelSampleName.Text = data.Rows(0)("mat_det_name").ToString
                    id_mat_det_price = data.Rows(0)("id_mat_det_price").ToString
                    po_price = data.Rows(0)("pl_mrs_det_price").ToString
                    'LabelPONumber.Text = data.Rows(0)("mat_purc_number").ToString
                    currency_po = data.Rows(0)("currency_po").ToString
                    LabelCurrPO.Text = currency_po.ToString
                    LabelPOPrice.Text = Decimal.Parse(po_price).ToString("N2")
                    TxtPrice.Text = po_price.ToString
                    Dim jum As Decimal = data.Rows(0)("mat_prod_ret_in_det_qty") - data.Rows(0)("mat_prod_ret_in_det_qty_stored")
                    SPQtyLimit.EditValue = jum
                Catch ex As Exception
                    errorCustom(ex.ToString)
                    Close()
                End Try
            End If
        Else
            Try
                SPQtySaved.EditValue = 0.0
                query += "CALL view_stock_mat_det('" + FormMasterWH.SLEWHStockMat.EditValue.ToString + "','" + FormMasterWH.SLELocatorStockMat.EditValue.ToString + "','" + FormMasterWH.SLERackStockMat.EditValue.ToString + "', '" + FormMasterWH.SLEDrawerStockMat.EditValue.ToString + "', '1','" + id_mat_det + "')"
                data = execute_query(query, -1, True, "", "", "", "")
                id_mat_det = data.Rows(0)("id_mat_det").ToString
                LabelCode.Text = data.Rows(0)("code").ToString
                LabelSampleName.Text = data.Rows(0)("name").ToString
                SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
                SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
                SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
                SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
                LabelTitleCurrPo.Visible = False
                LabelTitlePOPrice.Visible = False
                LabelTitlePO.Visible = False
                LabelPONumber.Visible = False
                LabelPOPrice.Visible = False
                LabelCurrPO.Visible = False
                TxtPrice.Enabled = False
                SPKurs.Enabled = False
                LabelControl15.Visible = False
                LabelControl18.Visible = False
                LabelControl5.Visible = False
                SPQtyLimit.EditValue = data.Rows(0)("qty_all_mat")
                LabelControlQty.Text = "Qty Moved"
                LabelCat.Text = data.Rows(0)("mat_cat").ToString
                LabelColor.Text = data.Rows(0)("color").ToString
                LabelSize.Text = data.Rows(0)("size").ToString
                LabelLot.Text = data.Rows(0)("lot").ToString
            Catch ex As Exception
                errorCustom(ex.ToString)
                Close()
            End Try
        End If

        viewPrice()

        'Load Image
        If System.IO.File.Exists(mat_image_path & id_mat_det & ".jpg") Then
            PictureEdit1.LoadAsync(mat_image_path & id_mat_det & ".jpg")
        Else
            PictureEdit1.LoadAsync(mat_image_path & "default" & ".jpg")
        End If

    End Sub

    'View Locator
    Sub viewPrice()
        Try
            Dim query As String = "SELECT a.id_mat_det_price,a.mat_det_price_name,a.mat_det_price,b.currency FROM tb_m_mat_det_price a LEFT JOIN tb_lookup_currency b ON a.id_currency=b.id_currency WHERE a.id_mat_det = '" + id_mat_det + "'"
            viewSearchLookupQuery(SLEPrice, query, "id_mat_det_price", "mat_det_price", "id_mat_det_price")

            TEPrice.EditValue = SPQtySaved.EditValue * SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue)
        Catch ex As Exception
        End Try
    End Sub

    'View Company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub

    'View Locator
    Sub viewLoactor()
        Dim query As String = "SELECT * FROM tb_m_wh_locator a WHERE id_comp = '" + id_comp + "'"
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub

    'View Rack
    Sub viewRack()
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    'View Drawer
    Sub viewDrawer()
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    'Rekursif Comp-Locator
    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        Try
            id_comp = SLEStorage.EditValue.ToString
            viewLoactor()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        Try
            id_locator = SLELocator.EditValue.ToString
            viewRack()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Try
            id_rack = SLERack.EditValue.ToString
            viewDrawer()
        Catch ex As Exception

        End Try
    End Sub
    'View Image Picture
    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        Try
            If System.IO.File.Exists(mat_image_path & id_mat_det & ".jpg") Then
                Process.Start(mat_image_path & id_mat_det & ".jpg")
            Else
                Process.Start(mat_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Cancel Butrton
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormMatStorageIn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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
        EP_SLE_cant_blank(EPStoredMat, SLEDrawer)
    End Sub
    Sub validateMyForm()
        ' Try
        Dim qty_save As Decimal = Decimal.Parse(SPQtySaved.EditValue)
        Dim qty_limit As Decimal = Decimal.Parse(SPQtyLimit.EditValue)
        If qty_save > qty_limit Or qty_save = 0.0 Or qty_save = 0 Then
            EPStoredMat.SetError(SPQtySaved, "- Qty saved must be smaller than qty limit or equal to qty limit ! " + System.Environment.NewLine + "- Qty must higher than 0 ")
            price_write()
        Else
            EPStoredMat.SetError(SPQtySaved, String.Empty)
            price_write()
        End If
        If SLEPrice.EditValue = Nothing Then
            EPStoredMat.SetError(SLEPrice, "Please assign the price for this material. ")
        Else
            EPStoredMat.SetError(SLEPrice, String.Empty)
        End If
        'Catch ex As Exception
        ' End Try
    End Sub
    'Save
    Private Sub BtnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveNew.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPStoredMat, GroupControlLocator) Then
            errorInput()
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save sample in this locator?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_wh_locator As String = SLELocator.EditValue.ToString
                Dim id_wh_drawer As String = SLEDrawer.EditValue.ToString
                Dim id_dc As String = "1"
                Dim query As String
                Dim qty_stored As String = decimalSQL(SPQtySaved.EditValue.ToString)
                Dim storage_sample_notes As String = MEStored.Text
                If action = "ins" Then
                    Try
                        'insert to tble storage
                        query = "INSERT INTO tb_storage_mat(id_wh_drawer, id_storage_category, storage_mat_datetime, id_mat_det, id_mat_det_price, price,report_mark_type,id_report, storage_mat_qty, storage_mat_notes) "
                        query += "VALUES ('" + id_wh_drawer + "', '" + id_dc + "',  NOW(), '" + id_mat_det + "','" + id_mat_det_price + "','" + decimalSQL(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString) + "','" + report_mark_type + "','" + id_report + "', '" + qty_stored + "', '" + storage_sample_notes + "') "
                        execute_non_query(query, True, "", "", "", "")

                        If id_pop_up = "1" Then 'rec mat purc
                            'Update store
                            query = "UPDATE tb_mat_purc_rec_det SET mat_purc_rec_det_qty_stored = mat_purc_rec_det_qty_stored + " + qty_stored + " WHERE id_mat_purc_rec_det = '" + id_mat_purc_rec_det + "'"
                            execute_non_query(query, True, "", "", "", "")
                            FormMatRecPurcDet.view_list_rec()
                        ElseIf id_pop_up = "2" Then 'rec mat wo
                            'Update store
                            query = "UPDATE tb_mat_wo_rec_det SET mat_wo_rec_det_qty_stored = mat_wo_rec_det_qty_stored + " + qty_stored + " WHERE id_mat_wo_rec_det = '" + id_mat_wo_rec_det + "'"
                            execute_non_query(query, True, "", "", "", "")
                            FormMatRecWODet.view_list_rec()
                        ElseIf id_pop_up = "3" Then 'ret in mat purc
                            'Update store
                            query = "UPDATE tb_mat_purc_ret_in_det SET mat_purc_ret_in_det_qty_stored = mat_purc_ret_in_det_qty_stored + " + qty_stored + " WHERE id_mat_purc_ret_in_det = '" + id_mat_purc_ret_in_det + "'"
                            execute_non_query(query, True, "", "", "", "")
                            FormMatRetInDet.viewDetailReturn()
                        ElseIf id_pop_up = "4" Then 'ret in mat prod
                            'Update store
                            query = "UPDATE tb_mat_prod_ret_in_det SET mat_prod_ret_in_det_qty_stored = mat_prod_ret_in_det_qty_stored + " + qty_stored + " WHERE id_mat_prod_ret_in_det = '" + id_mat_prod_ret_in_det + "'"
                            execute_non_query(query, True, "", "", "", "")
                            FormMatRetInProd.viewDetailReturn()
                        End If

                        Close()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                ElseIf action = "upd" Then
                    query = "INSERT INTO tb_storage_mat(id_wh_drawer, id_storage_category, storage_mat_datetime, id_mat_det, id_mat_det_price, price,report_mark_type,id_report, storage_mat_qty, storage_mat_notes) "
                    query += "VALUES ('" + FormMasterWH.SLEDrawerStockMat.EditValue.ToString + "', '2',  NOW(), '" + id_mat_det + "','" + id_mat_det_price + "','" + decimalSQL(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString) + "','" + report_mark_type + "','" + id_report + "', '" + qty_stored + "', '" + storage_sample_notes + "') "
                    execute_non_query(query, True, "", "", "", "")

                    query = "INSERT INTO tb_storage_mat(id_wh_drawer, id_storage_category, storage_mat_datetime, id_mat_det, id_mat_det_price, price,report_mark_type,id_report, storage_mat_qty, storage_mat_notes) "
                    query += "VALUES ('" + id_wh_drawer + "', '1',  NOW(), '" + id_mat_det + "','" + id_mat_det_price + "','" + decimalSQL(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString) + "','" + report_mark_type + "','" + id_report + "', '" + qty_stored + "', '" + storage_sample_notes + "') "
                    execute_non_query(query, True, "", "", "", "")

                    FormMasterWH.viewMatStorage()
                    Dispose()
                End If
            End If
        End If
    End Sub

    Private Sub SPQtySaved_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtySaved.EditValueChanged
        validateMyForm()
    End Sub

    Private Sub SPQtySaved_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SPQtySaved.Validating
        validateMyForm()
    End Sub

    Private Sub SLEPrice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEPrice.EditValueChanged
        id_mat_det_price = SLEPrice.EditValue
        price_write()
    End Sub

    Sub price_write()
        ' Try
        If SPQtySaved.EditValue = 0 Or SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue) = 0 Then
            TEPrice.EditValue = 0
        Else
            TEPrice.EditValue = SPQtySaved.EditValue * SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue)
        End If
        'Catch ex As Exception
        ' End Try
    End Sub

    Private Sub SLEPrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLEPrice.Validating
        validateMyForm()
    End Sub
End Class