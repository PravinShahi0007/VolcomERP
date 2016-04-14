Public Class FormSampleReturnPickSingle
    Dim sample_image_path As String = get_setup_field("pic_path_sample") & "\"
    Public id_sample_return_det As String
    Public id_comp_from, id_wh, action As String
    Public id_locator As String = "-1"
    Public id_rack As String = "-1"
    Public id_drawer As String = "-1"
    Public id_sample_edit As String
    Dim id_sample_old As String
    Public id_wh_rack_edit, id_wh_locator_edit, id_wh_drawer_edit, sample_return_det_qty, sample_return_det_note As String
    Public id_pl_sample_del As String
    Dim ketemu As Boolean = False
    Public indeks_edit As Integer
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_sample_return As String

    'Form
    Private Sub FormSampleReturnPickSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewWHStock()
        viewStock()
        viewPLDel()
        If action = "upd" Then
            'MsgBox(id_sample_edit + " " + id_wh_drawer_edit)
            SLELocator.EditValue = id_wh_locator_edit
            SLERack.EditValue = id_wh_rack_edit
            SLEDrawer.EditValue = id_wh_drawer_edit
            SPQtyPL.Text = sample_return_det_qty.ToString
            MENote.Text = sample_return_det_note.ToString
        End If
    End Sub
    Private Sub FormSampleReturnPickSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View
    Sub viewStock()
        'UPDATED 17 Nov 14
        If action = "ins" Then
            Dim query As String = "CALL view_pl_sample_del_limit('" + id_pl_sample_del + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim i As Integer = data.Rows.Count - 1
            GCSample.DataSource = data
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_pl_sample_del_limit('" + id_pl_sample_del + "')"
            Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
            dtd_temp.DefaultView.RowFilter = "id_sample = '" + id_sample_edit + "' "
            Dim data As DataTable = dtd_temp.DefaultView.ToTable
            GCSample.DataSource = data
        End If
        viewDrawer()
        viewImg()
        chooseCondition()
        checkExistInput()
        If action = "ins" Then
            checkExistInput()
        End If
    End Sub
    Sub viewDrawer()
        GVSampleDrawer.ActiveFilter.Clear()
        Dim id_sample As String = "-1"
        Try
            id_sample = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT j.id_wh_drawer, f.sample_code, f.sample_name, g.uom, n.comp_name, n.id_comp, m.wh_locator, m.id_wh_locator, l.wh_rack, l.id_wh_rack, k.wh_drawer , "
        query += "CAST(SUM(IF(j.id_storage_category='2', CONCAT('-', j.qty_sample), j.qty_sample)) AS DECIMAL(13,2)) AS qty_all_sample "
        query += "FROM tb_m_sample f "
        query += "INNER JOIN tb_m_uom g ON g.id_uom = f.id_uom "
        query += "INNER JOIN tb_storage_sample j ON j.id_sample = f.id_sample "
        query += "INNER JOIN tb_m_wh_drawer k ON j.id_wh_drawer = k.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack l ON l.id_wh_rack = k.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator m ON m.id_wh_locator =  l.id_wh_locator "
        query += "INNER JOIN tb_m_comp n ON n.id_comp = m.id_comp "
        query += "WHERE j.id_wh_drawer  LIKE '%%' "
        query += "AND l.id_wh_rack  LIKE '%%' "
        query += "AND m.id_wh_locator  LIKE '%%' "
        query += "AND n.id_comp  LIKE '%%' "
        query += "AND j.id_sample = '" + id_sample + "' "
        query += "GROUP BY j.id_sample, j.id_wh_drawer "
        query += "ORDER BY j.id_wh_drawer ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDrawer.DataSource = data
        'viewPLDel()
        GVSampleDrawer.ActiveFilterString = "[qty_all_sample]>0"
    End Sub
    Sub viewPLDel()
        Dim id_wh_drawer As String = GVSampleDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim id_sample As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim query As String = "SELECT i.sample_requisition_number, a.id_pl_sample_del, "
        query += "a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status, "
        query += "(a2.pl_sample_del_det_qty) AS total_qty "
        query += "FROM tb_pl_sample_del a "
        query += "INNER JOIN tb_pl_sample_del_det a2 ON a.id_pl_sample_del = a2.id_pl_sample_del "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_sample_requisition i ON a.id_sample_requisition = i.id_sample_requisition "
        query += "INNER JOIN tb_sample_requisition_det j ON j.id_sample_requisition_det = a2.id_sample_requisition_det "
        query += "WHERE j.id_sample = '" + id_sample + "' AND a2.id_wh_drawer = '" + id_wh_drawer + "' "
        'query += "GROUP BY a.id_pl_sample_del "
        query += "ORDER BY a.id_pl_sample_del ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCSamplePLDel.DataSource = data
    End Sub
    Sub viewImg()
        Try
            Dim id_sample As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
            If System.IO.File.Exists(sample_image_path & id_sample & ".jpg") Then
                PictureEdit1.LoadAsync(sample_image_path & id_sample & ".jpg")
            Else
                PictureEdit1.LoadAsync(sample_image_path & "default" & ".jpg")
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
        If id_wh <> "-1" Then
            query += "AND a.id_comp = '" + id_wh + "' "
        End If
        query += "ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub
    Sub viewWHLocatorSLE()
        Dim id_comp As String = SLEWH.EditValue.ToString
        Dim query As String = ""
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Sub viewWHRack()
        Dim id_locator As String = SLELocator.EditValue.ToString
        Dim query As String = ""
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Sub viewWHDrawer()
        Dim id_rack As String = SLERack.EditValue.ToString
        Dim query As String = ""
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    'Button Actoion
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyPL.EditValue.ToString)
        'get id_pl_sample_del_det

        ketemu = False
        Dim id_sample_cek As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        'Dim id_wh_drawer_cek As String = SLEDrawer.EditValue.ToString
        For i As Integer = 0 To (FormSampleReturnSingle.GVRetDetail.RowCount - 1)
            Try
                Dim id_sample_data As String = FormSampleReturnSingle.GVRetDetail.GetRowCellValue(i, "id_sample")
                ' Dim id_wh_drawer_data As String = FormSampleReturnSingle.GVRetDetail.GetRowCellValue(i, "id_wh_drawer")
                If id_sample_data <> "" Then
                    If action = "ins" Then
                        If id_sample_cek = id_sample_data Then
                            ketemu = True
                            Exit For
                        End If
                    ElseIf action = "upd" Then
                        If id_sample_cek = id_sample_data And i <> indeks_edit Then
                            ketemu = True
                            Exit For
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        Next

        If ketemu Then
            stopCustom("This sample already exist in Return List !")
        Else
            If action = "ins" Then
                'Edit di Induk insert save langsung ke db
                If id_sample_return_det <> "0" Then
                    FormSampleReturnSingle.GVDump.FocusedRowHandle = find_row(FormSampleReturnSingle.GVDump, "id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                    Dim qty_curr As Decimal = Decimal.Parse(FormSampleReturnSingle.GVDump.GetFocusedRowCellDisplayText("qty_real_sample").ToString)
                    Dim qty_pl As Decimal = Decimal.Parse(SPQtyPL.Text.ToString)
                    'qty_pl = qty_pl + qty_curr
                    isAllowPL(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString, GVSample.GetFocusedRowCellDisplayText("name").ToString, id_pl_sample_del, qty_pl.ToString)

                    If cond_check Then
                        Dim query_ins_return_det As String = "INSERT tb_sample_return_det(id_sample_return, sample_return_det_note, sample_return_det_qty, id_wh_drawer, id_sample) "
                        query_ins_return_det += "VALUES('" + FormSampleReturnSingle.id_sample_return + "','" + MENote.Text + "', '" + SPQtyPL.Text + "', '" + SLEDrawer.EditValue.ToString + "', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "') "
                        execute_non_query(query_ins_return_det, True, "", "", "", "")
                        Dim id_sample_return_det_new As String = execute_query("SELECT LAST_INSERT_ID()", 0, True, "", "", "", "")

                        Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                        query_upd_storage += "VALUES('" + SLEDrawer.EditValue.ToString + "', '1', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + SPQtyPL.Text + "', NOW(), 'Data Edited, Return Sample No. : " + FormSampleReturnSingle.TxtRetNumber.Text + "')"
                        execute_non_query(query_upd_storage, True, "", "", "", "")

                        FormSampleReturnSingle.newRows()
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_return_det", id_sample_return_det_new)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("size").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_return_det_qty", qty_input_grid.ToString("n2"))
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_return_det_note", MENote.Text)
                        'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                        'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                        'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                        'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                        'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                        'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                        'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                        'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_price", GVSample.GetFocusedRowCellValue("id_sample_price").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_price", GVSample.GetFocusedRowCellValue("sample_price").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("pl_sample_del_det_limit_qty", GVSample.GetFocusedRowCellValue("pl_sample_del_det_limit_qty").ToString)


                        FormSampleReturnSingle.GVRetDetail.CloseEditor()
                        FormSampleReturnSingle.GCRetDetail.RefreshDataSource()
                        FormSampleReturnSingle.GVRetDetail.RefreshData()
                        FormSampleReturnSingle.getAmountReq(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString, False)
                        Close()
                    Else
                        errorCustom("Sample : '" + sample_check + "' cannot exceed " + allow_sum.ToString("N2") + ", please check in Info PL ! ")
                        'FormInfoPLSampleDel.id_sample_return = "-1"
                        'FormSampleReturnSingle.infoPL()
                    End If
                Else
                    FormSampleReturnSingle.newRows()
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_return_det", "0")
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("size").ToString)
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_return_det_qty", qty_input_grid.ToString("n2"))
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_return_det_note", MENote.Text)
                    'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                    'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                    'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                    'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                    'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                    'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                    'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                    'FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_price", GVSample.GetFocusedRowCellValue("id_sample_price").ToString)
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_price", GVSample.GetFocusedRowCellValue("sample_price").ToString)
                    FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("pl_sample_del_det_limit_qty", GVSample.GetFocusedRowCellValue("pl_sample_del_det_limit_qty").ToString)

                    FormSampleReturnSingle.GVRetDetail.CloseEditor()
                    FormSampleReturnSingle.GCRetDetail.RefreshDataSource()
                    FormSampleReturnSingle.GVRetDetail.RefreshData()
                    FormSampleReturnSingle.getAmountReq(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString, False)
                    Close()
                End If
            ElseIf action = "upd" Then
                'MsgBox(ketemu.ToString)
                If Not ketemu Then
                    'Edit di Induk update save langsung ke db
                    If id_sample_return_det <> "0" Then
                        'MsgBox("Jangan")
                        FormSampleReturnSingle.GVDump.FocusedRowHandle = find_row(FormSampleReturnSingle.GVDump, "id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        Dim qty_curr As Decimal = Decimal.Parse(FormSampleReturnSingle.GVDump.GetFocusedRowCellDisplayText("qty_real_sample").ToString) - Decimal.Parse(sample_return_det_qty.ToString)
                        Dim qty_pl As Decimal = Decimal.Parse(SPQtyPL.Text)
                        'qty_pl = qty_pl + qty_curr
                        'MsgBox(qty_curr.ToString)
                        'MsgBox(qty_pl.ToString)
                        isAllowPL(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString, GVSample.GetFocusedRowCellDisplayText("name").ToString, id_pl_sample_del, qty_pl.ToString)

                        If cond_check Then
                            Dim query_upd_return_det As String = "UPDATE tb_sample_return_det SET id_sample_return = '" + FormSampleReturnSingle.id_sample_return + "',sample_return_det_note = '" + MENote.Text + "', sample_return_det_qty = '" + SPQtyPL.Text + "', id_wh_drawer = '" + SLEDrawer.EditValue.ToString + "' WHERE id_sample_return_det = '" + id_sample_return_det + "' "
                            execute_non_query(query_upd_return_det, True, "", "", "", "")
                            Dim query_upd_storage1 As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                            query_upd_storage1 += "VALUES('" + id_wh_drawer_edit.ToString + "', '2', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + sample_return_det_qty + "', NOW(), 'Data Edited, Return Sample No. : " + FormSampleReturnSingle.TxtRetNumber.Text + "')"
                            execute_non_query(query_upd_storage1, True, "", "", "", "")
                            Dim query_upd_storage2 As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                            query_upd_storage2 += "VALUES('" + SLEDrawer.EditValue.ToString + "', '1', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + SPQtyPL.Text + "', NOW(), 'Data Edited, Return Sample No. : " + FormSampleReturnSingle.TxtRetNumber.Text + "')"
                            execute_non_query(query_upd_storage2, True, "", "", "", "")

                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_return_det", id_sample_return_det)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("size").ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_return_det_qty", qty_input_grid.ToString("n2"))
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_return_det_note", MENote.Text)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                            FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                            FormSampleReturnSingle.GVRetDetail.CloseEditor()
                            FormSampleReturnSingle.GCRetDetail.RefreshDataSource()
                            FormSampleReturnSingle.GVRetDetail.RefreshData()
                            FormSampleReturnSingle.getAmountReq(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString, False)
                            Close()
                        Else
                            errorCustom("Sample : '" + sample_check + "' cannot exceed " + allow_sum.ToString("N2") + ", please check in Info PL ! ")
                            'FormInfoPLSampleDel.id_sample_return = id_sample_return_det
                            'FormSampleReturnSingle.infoPL()
                        End If
                    Else
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_return_det", "0")
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("size").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_return_det_qty", qty_input_grid.ToString("n2"))
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("sample_return_det_note", MENote.Text)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_drawer", SLEDrawer.EditValue.ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_rack", SLERack.EditValue.ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_locator", SLELocator.EditValue.ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("id_comp", SLEWH.EditValue.ToString)
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_drawer", SLEDrawer.Properties.GetDisplayText(SLEDrawer.EditValue))
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_rack", SLERack.Properties.GetDisplayText(SLERack.EditValue))
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("wh_locator", SLELocator.Properties.GetDisplayText(SLELocator.EditValue))
                        FormSampleReturnSingle.GVRetDetail.SetFocusedRowCellValue("comp_name", SLEWH.Properties.GetDisplayText(SLEWH.EditValue))
                        FormSampleReturnSingle.GVRetDetail.CloseEditor()
                        FormSampleReturnSingle.GCRetDetail.RefreshDataSource()
                        FormSampleReturnSingle.GVRetDetail.RefreshData()
                        FormSampleReturnSingle.getAmountReq(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString, False)
                        Close()
                    End If
                Else
                    errorCustom("This sample already exist in Return List !")
                End If
            End If
            FormSampleReturnSingle.GVRetDetail.OptionsBehavior.AutoExpandAllGroups = True
        End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

    End Sub
    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Try
            Dim id_sample As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
            If System.IO.File.Exists(sample_image_path & id_sample & ".jpg") Then
                Process.Start(sample_image_path & id_sample & ".jpg")
            Else
                Process.Start(sample_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub

    'GridView
    Private Sub GVSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSample.RowClick
        'If action = "ins" Then
        '    Dim qty_input As String = SPQtyPL.Text
        '    If qty_input = "0" Then
        '        viewDrawer()
        '        viewImg()
        '        chooseCondition()
        '        checkExistInput()
        '    Else
        '        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("All input will be reset if you change this data, are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '        If confirm = Windows.Forms.DialogResult.Yes Then
        '            viewDrawer()
        '            viewImg()
        '            chooseCondition()
        '            checkExistInput()
        '            SPQtyPL.Text = "0"
        '            MENote.Text = ""
        '        Else
        '            GVSample.FocusedRowHandle = find_row(GVSample, "id_sample", id_sample_old)
        '        End If
        '    End If
        'ElseIf action = "upd" Then
        '    viewDrawer()
        '    viewImg()
        '    chooseCondition()
        '    'checkExistInput()
        'End If
    End Sub
    Private Sub GVSampleDrawer_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSampleDrawer.RowClick
        viewPLDel()
    End Sub

    'SLE EVENT
    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        Try
            ' MsgBox("Load Locator")
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
        Catch ex As Exception

        End Try
    End Sub

    'Aneka Function
    Sub chooseCondition()
        'Dim id_sample As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        'If SLEDrawer.EditValue Is Nothing Or id_sample = "" Then
        '    'MsgBox("Kosong")
        '    BtnChoose.Enabled = False
        '    LabelAttention.Text = "Drawer is not available this time"
        '    LabelAttention.Visible = True
        '    SPQtyPL.Enabled = False
        '    MENote.Enabled = False
        'Else
        '    'MsgBox("Isi")
        '    BtnChoose.Enabled = True
        '    LabelAttention.Visible = False
        '    SPQtyPL.Enabled = True
        '    MENote.Enabled = True
        'End If
    End Sub

    Sub checkExistInput()
        'ketemu = False
        'Dim id_sample_cek As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        'Try
        '    Dim id_wh_drawer_cek As String = SLEDrawer.EditValue.ToString
        '    For i As Integer = 0 To (FormSampleReturnSingle.GVRetDetail.RowCount - 1)
        '        Try
        '            Dim id_sample_data As String = FormSampleReturnSingle.GVRetDetail.GetRowCellValue(i, "id_sample")
        '            Dim id_wh_drawer_data As String = FormSampleReturnSingle.GVRetDetail.GetRowCellValue(i, "id_wh_drawer")
        '            If id_sample_data <> "" Then
        '                If action = "ins" Then
        '                    If id_sample_cek = id_sample_data And id_wh_drawer_cek = id_wh_drawer_data Then
        '                        ketemu = True
        '                        Exit For
        '                    End If
        '                ElseIf action = "upd" Then
        '                    If id_sample_cek = id_sample_data And id_wh_drawer_cek = id_wh_drawer_data And i <> indeks_edit Then
        '                        ketemu = True
        '                        Exit For
        '                    End If
        '                End If
        '            End If
        '        Catch ex As Exception

        '        End Try
        '    Next
        '    If action = "ins" Then
        '        If ketemu Then
        '            BtnChoose.Enabled = False
        '            LabelAttention.Text = "This sample already exist in Return List !"
        '            LabelAttention.Visible = True
        '        Else
        '            BtnChoose.Enabled = True
        '            LabelAttention.Visible = False
        '        End If
        '    End If
        'Catch ex As Exception
        '    chooseCondition()
        'End Try
    End Sub

    Private Sub GVSample_BeforeLeaveRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GVSample.BeforeLeaveRow
        'id_sample_old = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
    End Sub

    Sub isAllowPL(ByVal id_sample As String, ByVal sample_name As String, ByVal id_pl_sample_del_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        Dim query_check As String = "SELECT "
        If action = "upd" Then
            'MsgBox("Update")
            query_check += "(SUM(a.pl_sample_del_det_qty) - COALESCE((SELECT SUM(tb_sample_return_det.sample_return_det_qty) FROM tb_sample_return_det INNER JOIN tb_sample_return ON tb_sample_return_det.id_sample_return = tb_sample_return.id_sample_return WHERE tb_sample_return.id_report_status!='5' AND tb_sample_return_det.id_sample = '" + id_sample + "' AND tb_sample_return.id_pl_sample_del='" + id_pl_sample_del_cek + "' AND tb_sample_return_det.id_sample_return_det!='" + id_sample_return_det + "'),0)) AS not_yet_returned "
        ElseIf action = "ins" Then
            'MsgBox("Insert")
            query_check += "(SUM(a.pl_sample_del_det_qty) - COALESCE((SELECT SUM(tb_sample_return_det.sample_return_det_qty) FROM tb_sample_return_det INNER JOIN tb_sample_return ON tb_sample_return_det.id_sample_return = tb_sample_return.id_sample_return WHERE tb_sample_return.id_report_status!='5' AND tb_sample_return_det.id_sample = '" + id_sample + "' AND tb_sample_return.id_pl_sample_del='" + id_pl_sample_del_cek + "'),0)) AS not_yet_returned "
        End If
        query_check += "FROM tb_pl_sample_del_det a "
        query_check += "INNER JOIN tb_sample_requisition_det a1 ON a1.id_sample_requisition_det = a.id_sample_requisition_det "
        query_check += "WHERE a.id_pl_sample_del = '" + id_pl_sample_del + "' AND a1.id_sample = '" + id_sample + "' "
        query_check += "GROUP BY a1.id_sample"
        allow_sum = Decimal.Parse(execute_query(query_check, 0, True, "", "", "", ""))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

   
    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        'checkExistInput()
        Cursor = Cursors.WaitCursor
        viewDrawer()
        Cursor = Cursors.Default
    End Sub
End Class