Public Class FormSampleDelDet 
    Public action As String = ""
    Public id_sample_del As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim dt As New DataTable
    Public id_report_status As String = "-1"
    Public id_sample_del_det_list As New List(Of String)
    Public id_sample_del_det_drawer_list As New List(Of String)
    Dim is_scan As Boolean = False
    Dim id_comp_cat_wh As String = "-1"

    Private Sub FormSampleDelDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        viewPLCat()
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            XTPOutboundScanNew.PageEnabled = False
            TxtNumber.Text = header_number("14")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlDrawerDetail.Enabled = True
            GroupControlScannedItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactFrom.Enabled = False
            XTPOutboundScanNew.PageEnabled = True

            'query view based on edit id's
            Dim query As String = ""
            query += "SELECT del.id_sample_del, del.sample_del_date, del.sample_del_number, "
            query += "del.id_report_status, del.id_comp_contact_to, del.id_comp_contact_from, "
            query += "(comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, (comp_from.id_comp) AS id_comp_from, "
            query += "(comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, (comp_to.id_comp) AS id_comp_to, "
            query += "stt.report_status, "
            query += "DATE_FORMAT(del.sample_del_date, '%Y-%m-%d') AS sample_del_datex, del.sample_del_note, "
            query += "del.id_pl_category "
            query += "FROM tb_sample_del del "
            query += "INNER JOIN tb_m_comp_contact cont_from ON cont_from.id_comp_contact = del.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp comp_from ON comp_from.id_comp = cont_from.id_comp "
            query += "INNER JOIN tb_m_comp_contact cont_to ON cont_to.id_comp_contact = del.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp comp_to ON comp_to.id_comp = cont_to.id_comp "
            query += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = del.id_report_status "
            query += "WHERE del.id_sample_del = '" + id_sample_del + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_sample_del = data.Rows(0)("id_sample_del").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
            TxtNumber.Text = data.Rows(0)("sample_del_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sample_del_datex").ToString, 0)
            MENote.Text = data.Rows(0)("sample_del_note").ToString
            LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)

            ''detail2
            viewDetailBC()
            viewDetail()
            viewDetailDrawer()
            check_but()
            allow_status()
        End If
    End Sub

    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub check_but()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_samplex <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            BtnAddDrawer.Enabled = True
            check_but2()
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            BtnAddDrawer.Enabled = False
            BtnEditDrawer.Enabled = False
            BtnDelDrawer.Enabled = False
        End If
    End Sub

    Sub check_but2()
        Dim id_drawerx As String = "0"
        Try
            id_drawerx = GVDrawer.GetFocusedRowCellValue("id_wh_drawer").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVDrawer.RowCount > 0 And id_drawerx <> "0" Then
            'MsgBox("1")
            BtnEditDrawer.Enabled = True
            BtnDelDrawer.Enabled = True
        Else
            'MsgBox("2")
            BtnEditDrawer.Enabled = False
            BtnDelDrawer.Enabled = False
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'action
            Dim query As String = "CALL view_sample_del('" + id_sample_del + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            Dim id_param As String = ""
            Dim query As String = "CALL view_sample_del('" + id_sample_del + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_del_det_list.Add(data.Rows(i)("id_sample_del_det").ToString)
                For j As Integer = 0 To data.Rows(i)("sample_del_det_qty") - 1
                    GVBarcode.AddNewRow()
                    GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample"))
                    GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code"))
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                Next
            Next
            GCItemList.DataSource = data
            GCBarcode.RefreshDataSource()
            GVBarcode.RefreshData()
        End If
    End Sub

    Sub viewDetailDrawer()
        Dim query As String = ""
        query += "SELECT a.id_sample_del_det_drawer, a.id_sample_del_det,a1.id_sample, a.id_wh_drawer, c.id_wh_rack, d.id_wh_locator, e.id_comp, b.id_wh_drawer, c.wh_rack, d.wh_locator, e.comp_name, "
        query += "(b.wh_drawer) AS drawer, (c.wh_rack) AS rack,  "
        query += "(d.wh_locator) AS locator, (e.comp_name) AS wh, a.id_sample_price, a.sample_price, a.id_sample_price, "
        query += "(a.sample_del_det_drawer_qty) AS qty_all_sample, (a.sample_del_det_drawer_qty) AS qty_all_sample_old,(a.sample_del_det_drawer_qty * a.sample_price) AS sample_amount_all  "
        query += "FROM tb_sample_del_det_drawer a   "
        query += "INNER JOIN tb_sample_del_det a1 ON a1.id_sample_del_det = a.id_sample_del_det "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer  "
        query += "INNER JOIN tb_m_wh_rack c ON c.id_wh_rack = b.id_wh_rack  "
        query += "INNER JOIN tb_m_wh_locator d ON d.id_wh_locator = c.id_wh_locator INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp WHERE a1.id_sample_del = '" + id_sample_del + "'  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_del_det_drawer_list.Add(data.Rows(i)("id_sample_del_det_drawer").ToString)
        Next
        GCDrawer.DataSource = data
    End Sub

    Sub viewDetailBC()
        Dim query As String = "SELECT ('0') AS id_sample, ('') AS code, ('') AS no, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.DeleteSelectedRows()
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "60", id_sample_del) Then
            GVItemList.OptionsBehavior.Editable = True
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            PanelControlNavDetail.Enabled = True
            PanelNavBarcode.Enabled = True
            MENote.Properties.ReadOnly = False
            LEPLCategory.Enabled = True
            BtnBrowseContactTo.Enabled = True
            GVItemList.OptionsCustomization.AllowGroup = False
            GridColumnQtyWH.Visible = True
            BtnSave.Enabled = True
        Else
            GVItemList.OptionsBehavior.Editable = False
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            PanelControlNavDetail.Enabled = False
            PanelNavBarcode.Enabled = False
            MENote.Properties.ReadOnly = True
            LEPLCategory.Enabled = False
            BtnBrowseContactTo.Enabled = False
            GVItemList.OptionsCustomization.AllowGroup = True
            GridColumnQtyWH.Visible = False
            BtnSave.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    'Validating
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        GVDrawer.ActiveFilter.Clear()

        'cek kesamaan from wh dengan scan
        Dim is_same_qty As Boolean = True
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim sample_del_det_qty_wh As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "sample_del_det_qty_wh"))
                Dim sample_del_det_qty As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "sample_del_det_qty"))
                If sample_del_det_qty_wh <> sample_del_det_qty Then
                    is_same_qty = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        'cek qty limit rack
        Dim available_stock As Boolean = True
        Dim warning_stock As String = ""
        For ix As Integer = 0 To GVDrawer.RowCount - 1
            Try
                Dim id_sample_del_det_drawer As String = GVDrawer.GetRowCellValue(ix, "id_sample_del_det_drawer").ToString
                If id_sample_del_det_drawer = "0" Then
                    Dim qty_all_sample As Decimal = GVDrawer.GetRowCellValue(ix, "qty_all_sample").ToString
                    Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(ix, "id_wh_drawer").ToString
                    Dim drawer As String = GVDrawer.GetRowCellValue(ix, "drawer").ToString
                    Dim id_wh_rack As String = GVDrawer.GetRowCellValue(ix, "id_wh_rack").ToString
                    Dim id_wh_locator As String = GVDrawer.GetRowCellValue(ix, "id_wh_locator").ToString
                    Dim id_comp As String = GVDrawer.GetRowCellValue(ix, "id_comp").ToString
                    Dim id_sample As String = GVDrawer.GetRowCellValue(ix, "id_sample").ToString
                    Dim query_cek_stok As String = "CALL view_stock_sample('" + id_comp + "','" + id_wh_locator + "','" + id_wh_rack + "','" + id_wh_drawer + "', '9999-12-01','2')"
                    Dim data_cek_temp As DataTable = execute_query(query_cek_stok, -1, True, "", "", "", "")
                    data_cek_temp.DefaultView.RowFilter = "id_sample = '" + id_sample + "' "
                    Dim data_cek_stok As DataTable = data_cek_temp.DefaultView.ToTable
                    If qty_all_sample > data_cek_stok.Rows(0)("qty_all_sample") Then
                        available_stock = False
                        warning_stock = "Out item in " + drawer + " cannot exceed " + data_cek_stok.Rows(0)("qty_all_sample") + ""
                        Exit For
                    End If
                End If
            Catch ex As Exception
            End Try
        Next

        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
            activeFilterDrawer()
        ElseIf GVItemList.RowCount = 0 Or GVDrawer.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            errorCustom("Transfer item, drawer detail, and scanned item data can't blank")
            activeFilterDrawer()
        ElseIf Not is_same_qty Then
            errorCustom("Qty from wh not equal to qty transfer, please check your input !")
            activeFilterDrawer()
        ElseIf Not available_stock Then
            errorCustom(warning_stock)
            activeFilterDrawer()
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process. Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim sample_del_number As String = TxtNumber.Text
                Dim sample_del_note As String = MENote.Text.ToString
                Dim id_pl_category As String = LEPLCategory.EditValue.ToString
                If action = "ins" Then
                    'query main table
                    Dim query_main As String = "INSERT tb_sample_del(sample_del_number, id_comp_contact_from, id_comp_contact_to, sample_del_date, sample_del_note, id_report_status, id_pl_category) "
                    query_main += "VALUES('" + sample_del_number + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', NOW(), '" + sample_del_note + "', '1', '" + id_pl_category + "'); SELECT LAST_INSERT_ID(); "

                    'Get Id & increment number doc
                    id_sample_del = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc("14")
                    

                    'insert who prepared
                    insert_who_prepared("60", id_sample_del, id_user)

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sample_del_det(id_sample_del, id_sample, sample_del_det_qty, sample_del_det_note, id_sample_ret_price, sample_ret_price) VALUES "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_sample As String = GVItemList.GetRowCellValue(j, "id_sample").ToString
                            Dim sample_del_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_del_det_qty").ToString)
                            Dim sample_del_det_note As String = GVItemList.GetRowCellValue(j, "sample_del_det_note").ToString
                            Dim id_sample_ret_price As String = GVItemList.GetRowCellValue(j, "id_sample_ret_price").ToString
                            Dim sample_ret_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_ret_price").ToString)

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sample_del + "', '" + id_sample + "', '" + sample_del_det_qty + "', '" + sample_del_det_note + "', '" + id_sample_ret_price + "', '" + sample_ret_price + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If GVItemList.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_sample_del_det, a.id_sample "
                    query_get_detail_id += "FROM tb_sample_del_det a "
                    query_get_detail_id += "WHERE a.id_sample_del = '" + id_sample_del + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'drawer
                    Dim jum_ins_s As Integer = 0
                    Dim query_drawer As String = ""
                    Dim query_drawer_stock As String = ""
                    If GVDrawer.RowCount > 0 Then
                        query_drawer = "INSERT INTO tb_sample_del_det_drawer(id_sample_del_det, id_wh_drawer, id_sample_price,sample_price, sample_del_det_drawer_qty) VALUES "
                        query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                    End If
                    For s As Integer = 0 To (GVDrawer.RowCount - 1)
                        Dim id_sample_drawer As String = GVDrawer.GetRowCellValue(s, "id_sample")
                        Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(s, "id_wh_drawer")
                        Dim id_sample_price As String = GVDrawer.GetRowCellValue(s, "id_sample_price")
                        Dim sample_price As String = decimalSQL(GVDrawer.GetRowCellValue(s, "sample_price").ToString)
                        Dim sample_del_det_drawer_qty As String = decimalSQL(GVDrawer.GetRowCellValue(s, "qty_all_sample").ToString)
                        Dim id_sample_del_det_drawer As String = ""
                        For s1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_sample_drawer = data_get_detail_id.Rows(s1)("id_sample").ToString Then
                                If jum_ins_s > 0 Then
                                    query_drawer += ", "
                                    query_drawer_stock += ", "
                                End If
                                query_drawer += "('" + data_get_detail_id.Rows(s1)("id_sample_del_det").ToString + "', '" + id_wh_drawer + "', '" + id_sample_price + "', '" + sample_price + "', '" + sample_del_det_drawer_qty + "') "
                                query_drawer_stock += "('" + id_wh_drawer + "', '2', '" + id_sample_drawer + "', '" + sample_del_det_drawer_qty + "', NOW(), 'PL Delivery No: " + sample_del_number + "', '" + id_sample_price + "','" + sample_price + "', '60', '" + id_sample_del + "', '2') "
                                jum_ins_s = jum_ins_s + 1
                                Exit For
                            End If
                        Next
                    Next
                    If GVDrawer.RowCount > 0 Then
                        execute_non_query(query_drawer, True, "", "", "", "")
                    End If


                    'insert stock
                    If jum_ins_s > 0 Then
                        execute_non_query(query_drawer_stock, True, "", "", "", "")
                    End If

                    FormSampleDel.viewSampleDel()
                    FormSampleDel.GVSampleDel.FocusedRowHandle = find_row(FormSampleDel.GVSampleDel, "id_sample_del", id_sample_del)
                    Close()
                ElseIf action = "upd" Then
                    'update main table
                    Dim query_main As String = "UPDATE tb_sample_del SET sample_del_number = '" + sample_del_number + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_comp_contact_to = '" + id_comp_contact_to + "', sample_del_note = '" + sample_del_note + "', id_pl_category='" + id_pl_category + "' WHERE id_sample_del = '" + id_sample_del + "' "
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sample_del_det(id_sample_del, id_sample, sample_del_det_qty, sample_del_det_note, id_sample_ret_price, sample_ret_price) "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_sample_del_det As String = GVItemList.GetRowCellValue(j, "id_sample_del_det").ToString
                            Dim id_sample As String = GVItemList.GetRowCellValue(j, "id_sample").ToString
                            Dim id_sample_ret_price As String = GVItemList.GetRowCellValue(j, "id_sample_ret_price").ToString
                            Dim sample_ret_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_ret_price").ToString)
                            Dim sample_del_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_del_det_qty").ToString)
                            Dim sample_del_det_note As String = GVItemList.GetRowCellValue(j, "sample_del_det_note").ToString

                            If id_sample_del_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "VALUES('" + id_sample_del + "', '" + id_sample + "', '" + sample_del_det_qty + "', '" + sample_del_det_note + "', '" + id_sample_ret_price + "', '" + sample_ret_price + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_detail_upd As String = "UPDATE tb_sample_del_det SET id_sample = '" + id_sample + "', sample_del_det_qty = '" + sample_del_det_qty + "', sample_del_det_note = '" + sample_del_det_note + "', id_sample_ret_price = '" + id_sample_ret_price + "', sample_ret_price = '" + sample_ret_price + "' WHERE id_sample_del_det = '" + id_sample_del_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_sample_del_det_list.Remove(id_sample_del_det)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If GVItemList.RowCount > 0 And jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    For j_del As Integer = 0 To (id_sample_del_det_list.Count - 1)
                        Try
                            Dim query_detail_del As String = "DELETE FROM tb_sample_del_det WHERE id_sample_del_det = '" + id_sample_del_det_list(j_del) + "'"
                            execute_non_query(query_detail_del, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_sample_del_det, a.id_sample "
                    query_get_detail_id += "FROM tb_sample_del_det a "
                    query_get_detail_id += "WHERE a.id_sample_del = '" + id_sample_del + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'update drawer
                    Dim jum_ins_s As Integer = 0
                    Dim query_drawer As String = ""
                    Dim query_drawer_stock As String = ""
                    If GVDrawer.RowCount > 0 Then
                        query_drawer = "INSERT INTO tb_sample_del_det_drawer(id_sample_del_det, id_wh_drawer, id_sample_price,sample_price, sample_del_det_drawer_qty) VALUES "
                        query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                    End If
                    For s As Integer = 0 To (GVDrawer.RowCount - 1)
                        Dim id_sample_del_det_drawer As String = GVDrawer.GetRowCellValue(s, "id_sample_del_det_drawer")
                        Dim id_sample_drawer As String = GVDrawer.GetRowCellValue(s, "id_sample")
                        Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(s, "id_wh_drawer")
                        Dim id_sample_price As String = GVDrawer.GetRowCellValue(s, "id_sample_price")
                        Dim sample_price As String = decimalSQL(GVDrawer.GetRowCellValue(s, "sample_price").ToString)
                        Dim sample_del_det_drawer_qty As String = decimalSQL(GVDrawer.GetRowCellValue(s, "qty_all_sample").ToString)
                        For s1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_sample_del_det_drawer = "0" Then
                                If id_sample_drawer = data_get_detail_id.Rows(s1)("id_sample").ToString Then
                                    If jum_ins_s > 0 Then
                                        query_drawer += ", "
                                        query_drawer_stock += ", "
                                    End If
                                    query_drawer += "('" + data_get_detail_id.Rows(s1)("id_sample_del_det").ToString + "', '" + id_wh_drawer + "', '" + id_sample_price + "','" + sample_price + "', '" + sample_del_det_drawer_qty + "') "
                                    query_drawer_stock += "('" + id_wh_drawer + "', '2', '" + id_sample_drawer + "', '" + sample_del_det_drawer_qty + "', NOW(), 'PL Sample Delivery No: " + sample_del_number + "', '" + id_sample_price + "','" + sample_price + "', '60', '" + id_sample_del + "', '2') "
                                    jum_ins_s = jum_ins_s + 1
                                    Exit For
                                End If
                            End If
                        Next
                    Next
                    If GVDrawer.RowCount > 0 And jum_ins_s > 0 Then
                        execute_non_query(query_drawer, True, "", "", "", "")
                    End If

                    'insert stock
                    If jum_ins_s > 0 Then
                        execute_non_query(query_drawer_stock, True, "", "", "", "")
                    End If

                    FormSampleDel.viewSampleDel()
                    FormSampleDel.GVSampleDel.FocusedRowHandle = find_row(FormSampleDel.GVSampleDel, "id_sample_del", id_sample_del)
                    Close()
                End If
                Cursor = Cursors.Default
            Else
                activeFilterDrawer()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSampleDelDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    '-------------CONTACT
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "50"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "51"
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub CheckEditRetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditRetail.CheckedChanged
        If CheckEditRetail.EditValue = True Then
            GridColumnRetail.Visible = True
            GridColumnRetail.VisibleIndex = 10
            GridColumnRetailAmount.Visible = True
            GridColumnRetailAmount.VisibleIndex = 11
            GridColumnRemark.VisibleIndex = 20
        Else
            GridColumnRetail.Visible = False
            GridColumnRetailAmount.Visible = False
        End If
    End Sub


    Private Sub CheckEditCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditCost.CheckedChanged
        If CheckEditCost.EditValue = True Then
            GridColumnCostAmount.Visible = True
            GridColumnCostAmount.VisibleIndex = 12
            GridColumnRemark.VisibleIndex = 20
        Else
            GridColumnCostAmount.Visible = False
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSampleDelSingle.id_wh = id_comp_from
        FormSampleDelSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim id_sample_del_det As String = "-1"
        Try
            id_sample_del_det = GVItemList.GetFocusedRowCellValue("id_sample_del_det").ToString
        Catch ex As Exception
        End Try
        Dim id_sample As String = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        If id_sample_del_det = "0" Then
            GVDrawer.ActiveFilter.Clear()
            GCDrawer.RefreshDataSource()
            GVDrawer.RefreshData()
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                deleteDetailBC(id_sample)
                deleteDetailDrawer(id_sample)
                allowScanPage()
                GCDrawer.RefreshDataSource()
                GVDrawer.RefreshData()
                GCBarcode.RefreshDataSource()
                GVBarcode.RefreshData()
                activeFilterDrawer()

                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                check_but()
                Cursor = Cursors.Default
            Else
                activeFilterDrawer()
            End If
        Else
            'cek uda ada product yg di scan ato blm
            errorCustom("This data already locked and can't delete.")
        End If
    End Sub

    Sub deleteDetailBC(ByVal id_sample_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_sample As String = ""
            Try
                id_sample = GVBarcode.GetRowCellValue(i, "id_sample").ToString()
            Catch ex As Exception

            End Try
            If id_sample = id_sample_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub deleteDetailDrawer(ByVal id_sample_param As String)
        'delete detail
        Dim i As Integer = GVDrawer.RowCount - 1
        While (i >= 0)
            Dim id_sample As String = ""
            Try
                id_sample = GVDrawer.GetRowCellValue(i, "id_sample").ToString()
            Catch ex As Exception
            End Try
            If id_sample = id_sample_param Then
                GVDrawer.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub countQtyFromWh(ByVal id_sample_param As String)
        Dim jum As Decimal = 0.0
        Dim jum_amount As Decimal = 0.0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                Dim id_sample_i As String = GVDrawer.GetRowCellValue(i, "id_sample").ToString
                If id_sample_i = id_sample_param Then
                    jum = jum + Decimal.Parse(GVDrawer.GetRowCellValue(i, "qty_all_sample"))
                    jum_amount = jum_amount + Decimal.Parse(GVDrawer.GetRowCellValue(i, "sample_amount_all"))
                End If
            Catch ex As Exception
            End Try
        Next
        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sample", id_sample_param)
        GVItemList.SetFocusedRowCellValue("sample_del_det_qty_wh", jum)
        GVItemList.SetFocusedRowCellValue("sample_del_det_amount", jum_amount)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        allowScanPage()
    End Sub

    Sub allowScanPage()
        'allow page scan
        Dim allow_scan = True
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim qty_wh_cek As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "sample_del_det_qty_wh"))
                If qty_wh_cek = 0.0 Then
                    allow_scan = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If Not allow_scan Or (GVItemList.RowCount <= 0) Then
            XTPOutboundScanNew.PageEnabled = False
        Else
            XTPOutboundScanNew.PageEnabled = True
        End If
    End Sub

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_sample_style As String = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            Dim id_sample_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_sample"))
            If id_sample_check = id_sample_style Then
                e.Appearance.BackColor = Color.Lavender
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAddDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_sample As String = "-1"
        Try
            id_sample = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        FormSampleDelDrawerSingle.id_comp = id_comp_from
        FormSampleDelDrawerSingle.id_pop_up = "-1"
        FormSampleDelDrawerSingle.id_sample_edit = id_sample
        FormSampleDelDrawerSingle.action_pop = "ins"
        FormSampleDelDrawerSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEditDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_sample As String = "-1"
        Dim id_sample_del_det_drawer As String = "-1"
        Dim id_wh_drawer As String = "-1"
        Dim qty_edit As Decimal = 0.0
        Try
            id_sample = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            id_sample_del_det_drawer = GVDrawer.GetFocusedRowCellValue("id_sample_del_det_drawer").ToString
            id_wh_drawer = GVDrawer.GetFocusedRowCellValue("id_wh_drawer").ToString
            qty_edit = GVDrawer.GetFocusedRowCellValue("sample_del_det_drawer_qty")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            FormSampleDelDrawerSingle.id_comp = id_comp_from
            FormSampleDelDrawerSingle.id_pop_up = "1"
            FormSampleDelDrawerSingle.indeks_edit = GVDrawer.FocusedRowHandle
            FormSampleDelDrawerSingle.id_sample_edit = id_sample
            FormSampleDelDrawerSingle.action_pop = "upd"
            FormSampleDelDrawerSingle.ShowDialog()
        ElseIf action = "upd" Then
            If id_sample_del_det_drawer = "0" Then
                FormSampleDelDrawerSingle.id_comp = id_comp_from
                FormSampleDelDrawerSingle.id_pop_up = "1"
                FormSampleDelDrawerSingle.indeks_edit = GVDrawer.FocusedRowHandle
                FormSampleDelDrawerSingle.id_sample_edit = id_sample
                FormSampleDelDrawerSingle.action_pop = "upd"
                FormSampleDelDrawerSingle.ShowDialog()
            Else
                errorCustom("This data already locked and can't edit.")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_sample_del_det_drawer As String = "-1"
        Try
            id_sample_del_det_drawer = GVDrawer.GetFocusedRowCellValue("id_sample_del_det_drawer").ToString
        Catch ex As Exception
        End Try

        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this drawer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_productx As String = GVDrawer.GetFocusedRowCellValue("id_sample").ToString
                GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
                GCDrawer.RefreshDataSource()
                GVDrawer.RefreshData()
                countQtyFromWh(id_productx)
            End If
        ElseIf action = "upd" Then
            If id_sample_del_det_drawer = "0" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this drawer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim id_samplex As String = GVDrawer.GetFocusedRowCellValue("id_sample").ToString
                    GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
                    GCDrawer.RefreshDataSource()
                    GVDrawer.RefreshData()
                    countQtyFromWh(id_samplex)
                End If
            Else
                'cek uda ada product yg di scan ato blm
                errorCustom("This data already locked and can't delete.")
            End If
        End If
        check_but2()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        activeFilterDrawer()
    End Sub

    Sub activeFilterDrawer()
        Dim id_samplex As String = "-1"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        GVDrawer.ActiveFilterString = "[id_sample]='" + id_samplex + "'"
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        'CEK BARCODE
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim id_sample As String = ""


        'check available code
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Dim code As String = GVItemList.GetRowCellValue(i, "code").ToString
            id_sample = GVItemList.GetRowCellValue(i, "id_sample").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_sample", id_sample)
            countQty(id_sample)
            newRowsBc()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub countQty(ByVal id_sample_param As String)
        Dim tot As Decimal = 0.0
        Dim jum_amount_ret As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_sample As String = GVBarcode.GetRowCellValue(i, "id_sample").ToString
            If id_sample = id_sample_param Then
                tot = tot + 1.0
            End If
        Next

        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sample", id_sample_param)
        GVItemList.SetFocusedRowCellValue("sample_del_det_qty", tot)
        GVItemList.SetFocusedRowCellValue("sample_del_det_amount_ret", tot * Decimal.Parse(GVItemList.GetFocusedRowCellValue("sample_ret_price").ToString))

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        If GVItemList.RowCount < 1 Then
            errorCustom("Please add product required !")
        Else
            startScan()
        End If
    End Sub

    Sub startScan()
        If GVItemList.RowCount > 0 Then
            is_scan = True
            MENote.Enabled = False
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BDelete.Enabled = False
            BtnCancel.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            ControlBox = False
            TxtNumber.Enabled = False
            newRowsBc()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Sub stopScan()
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next
        GVItemList.FocusedRowHandle = 0
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()

        is_scan = False
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        TxtNumber.Enabled = True
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        stopScan()
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim id_samplex As String = "-1"

        Try
            id_samplex = GVBarcode.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_sample As String = GVBarcode.GetFocusedRowCellValue("id_sample").ToString
            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

            deleteRowsBc()
            If id_sample <> "" Or id_sample <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_sample)
            End If

            allowDelete()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "60"
        FormReportMark.id_report = id_sample_del
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSampleDel.id_sample_del = id_sample_del
        ReportSampleDel.dt = GCItemList.DataSource
        Dim Report As New ReportSampleDel()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GridView1)

        Report.LabelFrom.Text = TxtNameCompFrom.Text
        Report.LabelTo.Text = TxtNameCompTo.Text
        Report.LabelNo.Text = TxtNumber.Text
        Report.LabelDate.Text = DEForm.Text
        Report.LabelPLCategory.Text = LEPLCategory.Properties.GetDisplayText(LEPLCategory.EditValue).ToString



        '' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub
End Class