Public Class FormSampleStorageIn 
    Dim sample_image_path As String = get_setup_field("pic_path_sample") & "\"
    Public id_sample As String
    Public id_sample_unique As String
    Public action As String
    Public id_storage_sample As String
    Dim id_comp As String
    Dim id_sample_price As String
    Public id_pl_sample_purc_det_unique As String
    Dim currency_po As String
    Dim po_price As String
    Dim id_sample_purc_det As String
    Public id_sample_purc_rec_det As String 'id_detail namanya aja yg tipu2
    Dim id_locator As String
    Dim id_rack As String
    Dim id_drawer As String
    Public id_report As String = "-1"
    Public report_mark_type As String = "-1"

    'fORM lOAD
    Private Sub FormSampleStorageIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub
    Sub actionLoad()
        Dim query As String
        Dim data As DataTable

        'Fill Lookup Edit
        viewComp()

        'Load information
        If action = "ins" Then
            Try
                query = "SELECT *, (d1.id_currency) AS id_currency_po, (d2.currency) AS currency_po, d.id_sample_purc_det, d.id_sample_price FROM tb_sample_purc_rec_det a "
                query += "INNER JOIN tb_sample_purc_det d ON a.id_sample_purc_det = d.id_sample_purc_det "
                query += "INNER JOIN tb_sample_purc d1 ON d.id_sample_purc = d1.id_sample_purc "
                query += "INNER JOIN tb_lookup_currency d2 ON d1.id_currency = d2.id_currency "
                query += "INNER JOIN tb_m_sample_price e ON e.id_sample_price = d.id_sample_price "
                query += "INNER JOIN tb_m_sample f ON e.id_sample = f.id_sample "
                query += "INNER JOIN tb_season_orign h ON h.id_season_orign = f.id_season_orign "
                query += "WHERE a.id_sample_purc_rec_det = '" + id_sample_purc_rec_det + "'  "
                data = execute_query(query, -1, True, "", "", "", "")
                id_sample = data.Rows(0)("id_sample").ToString
                id_sample_purc_det = data.Rows(0)("id_sample_purc_det").ToString
                LabelCode.Text = data.Rows(0)("sample_code").ToString
                'LabelFullCode.Text = data.Rows(0)("sample_unique").ToString
                LabelUSCode.Text = data.Rows(0)("sample_us_code").ToString
                LabelSampleName.Text = data.Rows(0)("sample_name").ToString
                LabelSeasonOrign.Text = data.Rows(0)("season_orign").ToString
                id_sample_price = data.Rows(0)("id_sample_price").ToString
                'id_sample_unique = data.Rows(0)("id_sample_unique").ToString
                po_price = data.Rows(0)("sample_purc_det_price").ToString
                LabelPONumber.Text = data.Rows(0)("sample_purc_number").ToString
                currency_po = data.Rows(0)("currency_po").ToString
                LabelCurrPO.Text = currency_po.ToString
                LabelPOPrice.Text = po_price.ToString
                TxtPrice.Text = po_price.ToString
                Dim jum As Decimal = data.Rows(0)("sample_purc_rec_det_qty") - data.Rows(0)("sample_purc_rec_det_qty_stored")
                SPQtyLimit.Text = jum.ToString

                viewPrice()

                'Load Image
                If System.IO.File.Exists(sample_image_path & id_sample & ".jpg") Then
                    PictureEdit1.LoadAsync(sample_image_path & id_sample & ".jpg")
                Else
                    PictureEdit1.LoadAsync(sample_image_path & "default" & ".jpg")
                End If
            Catch ex As Exception
                errorCustom(ex.ToString)
                Close()
            End Try
        ElseIf action = "upd" Then
            Try
                query = "SELECT SUM(IF(a.id_storage_category='2', CONCAT('-', a.qty_sample), a.qty_sample)) AS qty_all_sample, "
                query += "c.*, f.*, e2.*, e1.*, e.* FROM tb_storage_sample a "
                'query += "INNER JOIN tb_m_sample_price b ON a.id_sample_price = b.id_sample_price "
                query += "INNER JOIN tb_m_sample c ON a.id_sample = c.id_sample "
                'query += "INNER JOIN tb_m_sample_unique d ON c.id_sample = d.id_sample AND d.id_sample_unique = a.id_sample_unique "
                query += "INNER JOIN tb_m_wh_drawer e2 ON e2.id_wh_drawer = a.id_wh_drawer "
                query += "INNER JOIN tb_m_wh_rack e1 ON e1.id_wh_rack = e2.id_wh_rack "
                query += "INNER JOIN tb_m_wh_locator e ON e.id_wh_locator = e1.id_wh_locator "
                query += "INNER JOIN tb_season_orign f ON f.id_season_orign = c.id_season_orign "
                ' query += "INNER JOIN tb_sample_purc_rec_det g ON a.id_sample_purc_det = g.id_sample_purc_det "
                query += "WHERE a.id_sample = '" + id_sample + "' AND a.id_wh_drawer = '" + FormSampleStock.SLEDrawer.EditValue.ToString + "'"
                data = execute_query(query, -1, True, "", "", "", "")
                id_sample = data.Rows(0)("id_sample").ToString
                LabelCode.Text = data.Rows(0)("sample_code").ToString
                'LabelFullCode.Text = data.Rows(0)("sample_unique").ToString
                LabelUSCode.Text = data.Rows(0)("sample_us_code").ToString
                LabelSampleName.Text = data.Rows(0)("sample_name").ToString
                LabelSeasonOrign.Text = data.Rows(0)("season_orign").ToString
                'id_sample_price = data.Rows(0)("id_sample_price").ToString
                'id_sample_unique = data.Rows(0)("id_sample_unique").ToString
                SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
                SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
                SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
                SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
                'TxtPrice.Text = data.Rows(0)("sample_price").ToString
                LabelTitleCurrPo.Visible = False
                LabelTitlePOPrice.Visible = False
                LabelPOPrice.Visible = False
                LabelCurrPO.Visible = False
                LabelControlPO.Visible = False
                LabelPONumber.Visible = False
                TxtPrice.Enabled = False
                SPKurs.Enabled = False
                LabelControl15.Visible = False
                LabelControl18.Visible = False
                LabelControl5.Visible = False
                LabelControlStorage.Text = "Storage To"
                LabelControlLocator.Text = "Locator To"
                LabelControlRack.Text = "Rack To"
                LabelControlDrawer.Text = "Drawer To"
                SPQtyLimit.Text = data.Rows(0)("qty_all_sample").ToString
                LabelControlQty.Text = "Qty Moved"
            Catch ex As Exception
                errorCustom(ex.ToString)
                Close()
            End Try

            viewPrice()
            SLEPrice.EditValue = FormSampleStock.GVSample.GetFocusedRowCellValue("id_sample_price")
            SLEPrice.Enabled = False

            'Load Image
            If System.IO.File.Exists(sample_image_path & id_sample & ".jpg") Then
                PictureEdit1.LoadAsync(sample_image_path & id_sample & ".jpg")
            Else
                PictureEdit1.LoadAsync(sample_image_path & "default" & ".jpg")
            End If
            BCost.Enabled = False
            BRefresh.Enabled = False
        ElseIf action = "upd_del_rec" Then
            Try
                id_sample = FormSampleDelRecDet.GVItemList.GetFocusedRowCellValue("id_sample").ToString
                LabelCode.Text = FormSampleDelRecDet.GVItemList.GetFocusedRowCellValue("code").ToString
                LabelUSCode.Text = FormSampleDelRecDet.GVItemList.GetFocusedRowCellValue("sample_us_code").ToString
                LabelSampleName.Text = FormSampleDelRecDet.GVItemList.GetFocusedRowCellValue("name").ToString
                LabelSeasonOrign.Text = FormSampleDelRecDet.GVItemList.GetFocusedRowCellValue("season_orign").ToString
                id_sample_price = FormSampleDelRecDet.GVDrawer.GetFocusedRowCellValue("id_sample_price").ToString
                id_comp = FormSampleDelRecDet.id_comp_to
                LabelTitleCurrPo.Visible = False
                LabelTitlePOPrice.Visible = False
                LabelPOPrice.Visible = False
                LabelCurrPO.Visible = False
                LabelControlPO.Visible = False
                LabelPONumber.Visible = False
                TxtPrice.Enabled = False
                SPKurs.Enabled = False
                LabelControl15.Visible = False
                LabelControl18.Visible = False
                LabelControl5.Visible = False
                LabelControlStorage.Text = "Storage To"
                LabelControlLocator.Text = "Locator To"
                LabelControlRack.Text = "Rack To"
                LabelControlDrawer.Text = "Drawer To"
                LabelControlQty.Text = "Qty"
                Dim jum As Decimal = FormSampleDelRecDet.GVDrawer.GetFocusedRowCellValue("sample_del_rec_det_drawer_qty") - FormSampleDelRecDet.GVDrawer.GetFocusedRowCellValue("sample_del_rec_det_drawer_qty_stored")
                SPQtyLimit.EditValue = jum
            Catch ex As Exception
                errorCustom(ex.ToString)
                Close()
            End Try

            'wh
            SLEStorage.EditValue = id_comp
            SLEStorage.Enabled = False

            'Price
            viewPrice()
            SLEPrice.EditValue = id_sample_price
            SLEPrice.Enabled = False

            'Load Image
            If System.IO.File.Exists(sample_image_path & id_sample & ".jpg") Then
                PictureEdit1.LoadAsync(sample_image_path & id_sample & ".jpg")
            Else
                PictureEdit1.LoadAsync(sample_image_path & "default" & ".jpg")
            End If
            BCost.Enabled = False
            BRefresh.Enabled = False
        End If
    End Sub
    'view Price
    Sub viewPrice()
        Dim query As String = ""
        query += "SELECT ('0') AS id_sample_price, ('Please Select Price') AS sample_price, ('-') AS sample_price_name,('-') AS sample_price_date, ('-') AS comp_name, ('-') AS currency UNION ALL "
        query += "SELECT a.id_sample_price, a.sample_price, a.sample_price_name, a.sample_price_date, c.comp_name, c1.currency  FROM tb_m_sample_price a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact = b.id_comp_contact "
        query += "INNER JOIN tb_lookup_currency c1 ON c1.id_currency = a.id_currency "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp WHERE a.id_sample='" + id_sample + "' ORDER BY sample_price_date ASC "
        viewSearchLookupQuery(SLEPrice, query, "id_sample_price", "sample_price", "id_sample_price")
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
        Dim id_comp As String = ""
        Try
            id_comp = SLEStorage.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query = "SELECT * FROM tb_m_wh_locator a WHERE id_comp = '" + id_comp + "'"
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    'View Rack
    Sub viewRack()
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    'View Drawer
    Sub viewDrawer()
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    'Rekursif Comp-Locator
    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        viewLoactor()
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        viewRack()
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        viewDrawer()
    End Sub
    'View Image Picture
    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        Try
            If System.IO.File.Exists(sample_image_path & id_sample & ".jpg") Then
                Process.Start(sample_image_path & id_sample & ".jpg")
            Else
                Process.Start(sample_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Cancel Butrton
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Form Closed
    Private Sub FormSampleStorageIn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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
        EP_SLE_cant_blank(EPStoredSample, SLEDrawer)
    End Sub
    Sub validateMyForm()
        Try
            Dim qty_save As Decimal = Decimal.Parse(nominalWrite(SPQtySaved.Text))
            Dim qty_limit As Decimal = Decimal.Parse(nominalWrite(SPQtyLimit.Text))
            If qty_save > qty_limit Or qty_save = 0.0 Or qty_save = 0 Then
                EPStoredSample.SetError(SPQtySaved, "- Qty saved must be smaller than qty limit or equal to qty limit ! " + System.Environment.NewLine + "- Qty must higher than 0 ")
            Else
                EPStoredSample.SetError(SPQtySaved, String.Empty)
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Save
    Private Sub BtnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveNew.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPStoredSample, GroupControlLocator) Then
            errorInput()
        ElseIf SLEPrice.EditValue.ToString = "0" Then
            stopCustom("Please Select Price !")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save sample in this locator?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then

                Dim id_wh_locator As String = SLELocator.EditValue.ToString
                Dim id_wh_drawer As String = SLEDrawer.EditValue.ToString
                Dim id_dc As String = "1"
                Dim sample_price As String = TxtPrice.Text
                Dim query As String
                Dim sample_purc_rec_det_qty_stored As String = decimalSQL(SPQtySaved.EditValue.ToString)
                Dim storage_sample_notes As String = MEStored.Text
                Dim id_sample_price As String = SLEPrice.EditValue.ToString


                If action = "ins" Then
                    'Price
                    Dim sample_pricex As String = decimalSQL(SLEPrice.Properties.View.GetFocusedRowCellValue("sample_price").ToString)

                    Try
                        'insert to tble storage
                        query = "INSERT INTO tb_storage_sample(id_wh_drawer, id_storage_category, datetime_storage_sample, id_sample, qty_sample, storage_sample_notes, id_sample_price, sample_price, id_report, report_mark_type, id_stock_status) "
                        query += "VALUES ('" + id_wh_drawer + "', '" + id_dc + "',  NOW(), '" + id_sample + "', '" + sample_purc_rec_det_qty_stored + "', '" + storage_sample_notes + "', '" + id_sample_price + "', '" + sample_pricex + "', '" + id_report + "', '" + report_mark_type + "', '1') "
                        execute_non_query(query, True, "", "", "", "")

                        'Update store
                        query = "UPDATE tb_sample_purc_rec_det SET sample_purc_rec_det_qty_stored = sample_purc_rec_det_qty_stored + " + sample_purc_rec_det_qty_stored + " WHERE id_sample_purc_rec_det = '" + id_sample_purc_rec_det + "'"
                        execute_non_query(query, True, "", "", "", "")

                        FormSampleReceiveDet.view_list_rec()
                        Close()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                ElseIf action = "upd" Then
                    'Price
                    Dim sample_pricex As String = decimalSQL(FormSampleStock.GVSample.GetFocusedRowCellValue("sample_price").ToString)

                    Try
                        query = "INSERT INTO tb_storage_sample(id_wh_drawer, id_storage_category, datetime_storage_sample, id_sample, qty_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type) "
                        query += "VALUES ('" + FormSampleStock.SLEDrawer.EditValue.ToString + "', '2',  NOW(), '" + id_sample + "', '" + sample_purc_rec_det_qty_stored + "', '" + storage_sample_notes + "', '" + id_sample_price + "', '" + sample_pricex + "', '59') "
                        execute_non_query(query, True, "", "", "", "")

                        query = "INSERT INTO tb_storage_sample(id_wh_drawer, id_storage_category, datetime_storage_sample, id_sample, qty_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type) "
                        query += "VALUES ('" + id_wh_drawer + "', '1',  NOW(), '" + id_sample + "', '" + sample_purc_rec_det_qty_stored + "', '" + storage_sample_notes + "', '" + id_sample_price + "', '" + sample_pricex + "', '59') "
                        execute_non_query(query, True, "", "", "", "")

                        FormSampleStock.viewSampleStorage()
                        Close()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                ElseIf action = "upd_del_rec" Then
                    'Price
                    Dim sample_pricex As String = decimalSQL(FormSampleDelRecDet.GVDrawer.GetFocusedRowCellValue("sample_price").ToString)
                    Try
                        'insert to tble storage
                        query = "INSERT INTO tb_storage_sample(id_wh_drawer, id_storage_category, datetime_storage_sample, id_sample, qty_sample, storage_sample_notes, id_sample_price, sample_price, id_report, report_mark_type, id_stock_status) "
                        query += "VALUES ('" + id_wh_drawer + "', '" + id_dc + "',  NOW(), '" + id_sample + "', '" + sample_purc_rec_det_qty_stored + "', '" + storage_sample_notes + "', '" + id_sample_price + "', '" + sample_pricex + "', '" + id_report + "', '" + report_mark_type + "', '1') "
                        execute_non_query(query, True, "", "", "", "")

                        'Update store
                        query = "UPDATE tb_sample_del_rec_det_drawer SET sample_del_rec_det_drawer_qty_stored = sample_del_rec_det_drawer_qty_stored + " + sample_purc_rec_det_qty_stored + " WHERE id_sample_del_rec_det_drawer = '" + id_sample_purc_rec_det + "'"
                        execute_non_query(query, True, "", "", "", "")

                        FormSampleDelRecDet.actionLoad()
                        Close()
                    Catch ex As Exception
                        errorConnection()
                    End Try
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

    Private Sub BCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCost.Click
        FormMasterSampleDet.id_sample = id_sample
        FormMasterSampleDet.XTPGeneral.PageVisible = False
        FormMasterSampleDet.XTPNote.PageVisible = False
        FormMasterSampleDet.ShowDialog()
    End Sub

    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
        actionLoad()
    End Sub
End Class