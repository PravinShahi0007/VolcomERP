Public Class FormSamplePLDelSingle 
    Public action As String
    Public id_pl_sample_del As String
    Public id_comp_contact_from, id_comp_from As String
    Public id_comp_contact_to, id_comp_to As String
    Public code_list, code_list_drawer, id_sample_list As New List(Of String)
    Dim id_pl_sample_del_det_list As New List(Of String)
    Dim test_old As String
    Public id_report_status As String
    Public id_sample_requisition As String = "-1"
    Public id_sample_requisition_det_style As String
    Dim qty_process As Decimal
    Dim based_on_srs As Boolean = False
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    'Form Load
    Private Sub FormSamplePLDelSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        actionLoad()
    End Sub
    Sub actionLoad()
        If action = "ins" Then
            PanelNavDetailDrawer.Visible = True

            id_comp_contact_from = get_company_x(id_comp_from, 6)
            TxtCodeCompFrom.Text = get_company_x(id_comp_from, 2)
            TxtNameCompFrom.Text = get_company_x(id_comp_from, 1)
            If id_sample_requisition <> "-1" Then
                id_comp_contact_to = get_company_x(id_comp_to, 6)
                TxtCodeCompTo.Text = get_company_x(id_comp_to, 2)
                TxtNameCompTo.Text = get_company_x(id_comp_to, 1)
                viewFillEmptyData()
                viewDetailBC()
                GroupControlScannedItem.Enabled = True
                GroupControlDrawer.Enabled = True
                GroupControlDetailSingle.Enabled = True
                based_on_srs = True
                BtnInfoSrs.Enabled = True
            End If
            TxtPLNumber.Text = header_number("8")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEPL.Text = view_date(0)
            id_report_status = "2"
        ElseIf action = "upd" Then
            PanelNavDetailDrawer.Visible = False

            BtnCancel.Text = "Close"
            BtnInfoSrs.Enabled = True
            'Fetch from db main
            Dim query As String = "SELECT a.pl_sample_del_duration ,a.id_sample_requisition, a.id_pl_sample_del ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_t, a.id_report_status, "
            query += "DATE_FORMAT(a.pl_sample_del_date,'%Y-%m-%d') as pl_sample_del_datex,cod_det.code_detail_name as division "
            query += "FROM tb_pl_sample_del a "
            query += "INNER JOIN tb_sample_requisition samp_req ON samp_req.id_sample_requisition=a.id_sample_requisition "
            query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=samp_req.id_division "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "WHERE a.id_pl_sample_del = '" + id_pl_sample_del + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'tampung ke form

            TEDivision.Text = data.Rows(0)("division").ToString

            BtnPopSRS.Enabled = False
            BtnPopSource.Enabled = False
            SPDuration.Text = data.Rows(0)("pl_sample_del_duration").ToString
            TxtSRSNumber.Text = data.Rows(0)("pl_sample_del_number").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            'MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
            TxtPLNumber.Text = data.Rows(0)("pl_sample_del_number").ToString
            DEPL.Text = view_date_from(data.Rows(0)("pl_sample_del_datex").ToString(), 0)
            MENote.Text = data.Rows(0)("pl_sample_del_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_sample_requisition = data.Rows(0)("id_sample_requisition").ToString

            'Group Control
            GroupControlDetailSingle.Enabled = True
            GroupControlDrawer.Enabled = True

            'based on sttatus
            id_report_status = data.Rows(0)("id_report_status").ToString
            If id_report_status = "3" Or id_report_status = "4" Or id_report_status = "6" Then
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
                BtnSave.Enabled = False
                BtnPrint.Enabled = True
                BtnPopTo.Enabled = False
                BtnPopFrom.Enabled = False
                BAdd.Enabled = False
                Bdel.Enabled = False
                'GVDetail.OptionsBehavior.Editable = False
                MENote.Properties.ReadOnly = True
                SPDuration.Properties.ReadOnly = True
                PanelNavBarcode.Enabled = False
            ElseIf id_report_status = "5" Then
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
                BtnSave.Enabled = False
                BtnPrint.Enabled = False
                BtnPopTo.Enabled = False
                BtnPopFrom.Enabled = False
                BAdd.Enabled = False
                Bdel.Enabled = False
                'GVDetail.OptionsBehavior.Editable = False
                MENote.Properties.ReadOnly = True
                GridColumnQtyReq.Visible = False
                'GridColumnQty.Visible = False
                GroupControlDetailSingle.Enabled = False
                GroupControlDrawer.Enabled = False
                SPDuration.Properties.ReadOnly = True
                PanelNavBarcode.Enabled = False
            Else
                If check_edit_report_status(id_report_status, "10", id_pl_sample_del) Then
                    'MsgBox("Masih Boleh")
                    BtnAdd.Enabled = True
                    BtnEdit.Enabled = True
                    BtnDel.Enabled = True
                    BtnPrint.Enabled = False
                    BtnPopTo.Enabled = True
                    BtnPopFrom.Enabled = True
                    BAdd.Enabled = True
                    Bdel.Enabled = True
                    'GVDetail.OptionsBehavior.Editable = True
                    MENote.Properties.ReadOnly = False
                    SPDuration.Properties.ReadOnly = False
                    PanelNavBarcode.Enabled = True
                Else
                    'MsgBox("Nggak Boleh")
                    BtnAdd.Enabled = False
                    BtnEdit.Enabled = False
                    BtnDel.Enabled = False
                    BtnPrint.Enabled = False
                    BtnPopTo.Enabled = False
                    BAdd.Enabled = False
                    Bdel.Enabled = False
                    'GVDetail.OptionsBehavior.Editable = False
                    MENote.Properties.ReadOnly = True
                    SPDuration.Properties.ReadOnly = True
                    PanelNavBarcode.Enabled = False
                End If
            End If
            'Fetch db detail
            viewFillEmptyData()
            viewDetailBC()
        End If
    End Sub
    'View Report Status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetailBC()
        Dim query As String = "SELECT ('0') AS id_sample, ('') AS code, ('') AS no, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.DeleteSelectedRows()
    End Sub

    Sub viewFillEmptyData()
        'Dim query As String = "SELECT ('0') AS id_pl_sample_del_det, ('0') AS id_pl_sample_del,('') AS code_full, ('') AS name, ('') AS size, ('') AS uom, ('0') AS id_storage_sample, ('0') AS id_sample_unique, ('') AS pl_sample_del_det_note "
        Dim query As String = "CALL view_sample_req_det_limit('" + id_sample_requisition + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        If action = "ins" Then
            viewFillEmptyDrawer()
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_list.Add(data.Rows(i)("id_sample").ToString)
                If action = "upd" Then
                    getAmountReq(data.Rows(i)("id_sample_requisition_det").ToString, False)
                End If
            Next
        ElseIf action = "upd" Then
            viewPLSample()
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_list.Add(data.Rows(i)("id_sample").ToString)
                If action = "upd" Then
                    getAmountReq(data.Rows(i)("id_sample_requisition_det").ToString, False)
                    Dim qty_pl As Decimal = 0.0
                    Try
                        qty_pl = GVDetail.GetFocusedRowCellValue("qty_real_sample_wh")
                    Catch ex As Exception
                    End Try
                    GVDetail.SetFocusedRowCellValue("qty_real_sample", qty_pl)
                End If
            Next
            GVDetail.FocusedRowHandle = 0
        End If
    End Sub
    Sub viewFillEmptyDrawer()
        Dim query As String = "SELECT ('0') AS id_pl_sample_del_det, ('0') AS id_sample,('') AS code, ('') AS name, ('0') AS id_wh_drawer, ('') AS wh_locator, ('') AS wh_rack,  ('') AS wh_drawer, ('0') AS pl_sample_del_det_qty, ('') AS pl_sample_del_det_note, ('0') AS qty_all_sample, ('0') AS id_sample_requisition_det, ('') AS uom, ('0') AS id_wh_locator, ('0') AS id_wh_rack, ('0') as id_sample_price, ('0') as sample_price "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
        deleteRows()
    End Sub
    'View PL Sample
    Sub viewPLSample()
        Dim query As String = "CALL view_pl_sample_del('" + id_pl_sample_del + "', '1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            code_list.Add(data.Rows(i)("id_sample").ToString)
            code_list_drawer.Add(data.Rows(i)("id_wh_drawer").ToString)
            id_pl_sample_del_det_list.Add(data.Rows(i)("id_pl_sample_del_det").ToString)
        Next
        GCDrawer.DataSource = data
    End Sub
    'Gridcontrol Detail EVENT
    'Press Key On Grid Control Detail
    Private Sub GCDetail_ProcessGridKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If id_report_status = "1" Or id_report_status = "2" Then
            If e.KeyCode = Keys.Escape Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
            ElseIf e.KeyCode = Keys.F5 Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
                newRows()
            ElseIf e.KeyCode = Keys.F6 Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
                If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", _
             MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
                deleteRows()
            End If
        End If
    End Sub
    'Code Editing & check
    Private Sub GVDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        'Dim i As Integer = sender.FocusedRowHandle
        'If e.Column.FieldName = "code_full" Then
        '    Dim test As String = sender.GetRowCellValue(i, "code_full").ToString
        '    'Try
        '    Dim query As String = "CALL view_pl_sample_del_criteria('" + test + "')"
        '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '    Dim ix As Integer = data.Rows.Count - 1
        '    While (ix >= 0)
        '        If code_list.Contains(data.Rows(ix)("id_sample_unique").ToString) Then
        '            data.Rows.RemoveAt(ix)
        '        End If
        '        ix = ix - 1
        '    End While
        '    If data.Rows.Count > 0 Then 'Code Found
        '        If code_list.Contains(data.Rows("0")("id_sample_unique").ToString) Then
        '            DevExpress.XtraEditors.XtraMessageBox.Show("Code : " + test + ", already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            deleteRows()
        '            'newRows()
        '        Else
        '            Dim id_sample_unique As String = data.Rows("0")("id_sample_unique").ToString
        '            Dim id_pl_sample_del_det As String = "0"
        '            Dim id_storage_sample As String = data.Rows("0")("id_storage_sample").ToString
        '            Dim namex As String = data.Rows("0")("name").ToString
        '            Dim uom As String = data.Rows("0")("uom").ToString
        '            Dim id_pl_sample_del As String = "0"
        '            Dim size As String = data.Rows("0")("size").ToString

        '            If id_pl_sample_del_det = "0" Then 'Baris Baru
        '                code_list.Add(data.Rows("0")("id_sample_unique").ToString)
        '                GVDetail.SetFocusedRowCellValue("id_pl_sample_del_det", id_pl_sample_del_det)
        '                GVDetail.SetFocusedRowCellValue("id_sample_unique", id_sample_unique)
        '                GVDetail.SetFocusedRowCellValue("id_storage_sample", id_storage_sample)
        '                GVDetail.SetFocusedRowCellValue("name", namex)
        '                GVDetail.SetFocusedRowCellValue("uom", uom)
        '                GVDetail.SetFocusedRowCellValue("id_pl_sample_del", id_pl_sample_del)
        '                GVDetail.SetFocusedRowCellValue("size", size)
        '                'noEdit()
        '            End If
        '        End If
        '    Else 'Code Not Found
        '        DevExpress.XtraEditors.XtraMessageBox.Show("Product sample not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        deleteRows()
        '        'newRows()
        '    End If
        '    'Catch ex As Exception
        '    'errorCustom(ex.ToString)
        '    'End Try
        'End If
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVDrawer.FocusedColumn = GVDrawer.VisibleColumns(0)
        GVDrawer.ShowEditor()
    End Sub
    Sub newRows()
        GVDrawer.AddNewRow()
        cantEdit()
    End Sub
    Sub deleteRows()
        GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
        cantEdit()
    End Sub
    Sub cantEdit()
        If GVDrawer.RowCount < 1 Then
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        End If
    End Sub

    'Company
    Private Sub BtnPopFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopFrom.Click
        FormPopUpContact.id_comp_contact = id_comp_contact_from
        FormPopUpContact.id_pop_up = "9"
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnPopTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopTo.Click
        FormPopUpContact.id_comp_contact = id_comp_contact_to
        FormPopUpContact.id_pop_up = "10"
        FormPopUpContact.ShowDialog()
    End Sub
    'Validating
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(ErrorProviderPL, TxtNameCompFrom)
        ErrorProviderPL.SetIconPadding(TxtNameCompFrom, 30)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(ErrorProviderPL, TxtNameCompTo)
        ErrorProviderPL.SetIconPadding(TxtNameCompTo, 5)
    End Sub
    'Navigation Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()

        'spy gk error
        makeSafeGV(GVDetail)
        makeSafeGV(GVDrawer)

        Dim cond_equal As Boolean = True
        Dim cond_limit As Boolean = True
        If action = "ins" Then
            'cek dengan requisition di DB
            For i As Integer = 0 To GVDetail.RowCount - 1
                Dim id_sample_requisition_det_cekya As String = GVDetail.GetRowCellValue(i, "id_sample_requisition_det").ToString
                Dim qty_plya As String = GVDetail.GetRowCellValue(i, "qty_real_sample").ToString
                Dim sample_checkya As String = GVDetail.GetRowCellValue(i, "name").ToString
                isAllowRequisition(sample_checkya, id_sample_requisition_det_cekya, qty_plya)
                If Not cond_check Then
                    Exit For
                End If
            Next

            'equal pl and wh
            For i As Integer = 0 To GVDetail.RowCount - 1
                Dim qty_wh As Decimal = Decimal.Parse(GVDetail.GetRowCellValue(i, "qty_real_sample_wh").ToString)
                Dim qty_pl As Decimal = Decimal.Parse(GVDetail.GetRowCellValue(i, "qty_real_sample").ToString)
                Dim qty_req As Decimal = Decimal.Parse(GVDetail.GetRowCellValue(i, "sample_requisition_det_qty").ToString)
                If qty_wh <> qty_pl Then
                    cond_equal = False
                    Exit For
                ElseIf qty_pl > qty_req Then
                    cond_equal = False
                    Exit For
                ElseIf qty_wh > qty_req Then
                    cond_equal = False
                    Exit For
                End If
            Next

        End If


        If Not formIsValidInGroup(ErrorProviderPL, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVDrawer.RowCount = 0 Or GVBarcode.RowCount = 0 And action = "ins" Then
            stopCustom("Drawer List and Scanned Item can't blank!")
        ElseIf Not cond_equal Then
            stopCustom("Qty input not valid. Make sure: " + System.Environment.NewLine + "- Qty WH equal to Qty PL. " + System.Environment.NewLine + "- Qty WH/Qty PL must be smaller than Remaining Qty or equal to Remaining Qty ")
        ElseIf Not cond_check Then
            stopCustom("Sample : '" + sample_check + "' cannot exceed " + allow_sum.ToString("N2") + ", please check in Info SRS ! ")
            infoSrs()
        Else
            'Main var
            Dim query As String = ""
            Dim query2 As String = ""
            Dim pl_sample_del_number As String = addSlashes(TxtPLNumber.Text)
            Dim pl_sample_del_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim pl_sample_del_duration As String = SPDuration.Text

            'detail var
            Dim pl_sample_del_det_note As String
            Dim id_pl_sample_del_det As String = ""
            Dim id_sample_requisition_det As String
            Dim pl_sample_del_det_qty As String
            Dim id_sample As String
            Dim id_sample_price As String
            Dim sample_price As Decimal
            Dim id_wh_drawer As String
            Dim succes As Boolean = False

            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process. Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                If action = "ins" Then
                    'Main table
                    query = "INSERT INTO tb_pl_sample_del(id_sample_requisition, pl_sample_del_number, id_comp_contact_from, id_comp_contact_to, pl_sample_del_date, pl_sample_del_note, id_report_status, pl_sample_del_duration) "
                    query += "VALUES('" + id_sample_requisition + "','" + pl_sample_del_number + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', NOW(), '" + pl_sample_del_note + "', '" + id_report_status + "', '" + pl_sample_del_duration + "'); SELECT LAST_INSERT_ID(); "
                    'get id main
                    id_pl_sample_del = execute_query(query, 0, True, "", "", "", "")

                    'preapred default
                    increase_inc("8")
                    insert_who_prepared("10", id_pl_sample_del, id_user)

                    'detail table
                    For i As Integer = 0 To (GVDrawer.RowCount - 1) - GetGroupRowCount(GVDrawer)
                        Try
                            pl_sample_del_det_note = GVDrawer.GetRowCellValue(i, "pl_sample_del_det_note").ToString
                            id_sample_requisition_det = GVDrawer.GetRowCellValue(i, "id_sample_requisition_det").ToString
                            pl_sample_del_det_qty = decimalSQL(GVDrawer.GetRowCellValue(i, "pl_sample_del_det_qty").ToString)
                            id_wh_drawer = GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                            id_sample = GVDrawer.GetRowCellValue(i, "id_sample").ToString

                            id_sample_price = GVDrawer.GetRowCellValue(i, "id_sample_price").ToString
                            sample_price = GVDrawer.GetRowCellValue(i, "sample_price")

                            'INSERT TB PL SAMPLE DETAIL
                            query = "INSERT tb_pl_sample_del_det(id_pl_sample_del,pl_sample_del_det_note, id_sample_requisition_det, pl_sample_del_det_qty, id_wh_drawer,id_sample_price,sample_price) "
                            query += "VALUES('" + id_pl_sample_del + "','" + pl_sample_del_det_note + "', '" + id_sample_requisition_det + "', '" + pl_sample_del_det_qty + "', '" + id_wh_drawer + "','" + id_sample_price + "', '" + decimalSQL(sample_price.ToString) + "') "
                            execute_non_query(query, True, "", "", "", "")

                            'INSERT TB PL STORAGE
                            Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                            query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'PL : " + pl_sample_del_number + "','" + id_pl_sample_del + "','10','2','" + id_sample_price + "', '" + decimalSQL(sample_price.ToString) + "')"
                            execute_non_query(query_upd_storage, True, "", "", "", "")

                            succes = True
                        Catch ex As Exception
                        End Try
                    Next

                    FormSamplePLDel.XTCPL.SelectedTabPageIndex = 0
                    FormSamplePLDel.viewPL()
                    FormSamplePLDel.viewSampleReq()
                    FormSamplePLDel.GVPL.FocusedRowHandle = find_row(FormSamplePLDel.GVPL, "id_pl_sample_del", id_pl_sample_del)
                    Close()
                ElseIf action = "upd" Then
                    'update main table
                    query = "UPDATE tb_pl_sample_del SET pl_sample_del_number = '" + pl_sample_del_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', pl_sample_del_note = '" + pl_sample_del_note + "', id_report_status = '" + id_report_status + "', pl_sample_del_duration = '" + pl_sample_del_duration + "' WHERE id_pl_sample_del = '" + id_pl_sample_del + "'"
                    execute_non_query(query, True, "", "", "", "")
                    FormSamplePLDel.XTCPL.SelectedTabPageIndex = 0
                    FormSamplePLDel.viewPL()
                    FormSamplePLDel.viewSampleReq()
                    FormSamplePLDel.GVPL.FocusedRowHandle = find_row(FormSamplePLDel.GVPL, "id_pl_sample_del", id_pl_sample_del)
                    Close()
                End If
                Cursor = Cursors.Default
            End If

        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub FormSamplePLDelSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_sample_del
        FormReportMark.report_mark_type = "10"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPopSRS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopSRS.Click
        FormPopUpSampleReq.id_pop_up = "1"
        FormPopUpSampleReq.ShowDialog()
    End Sub
    'Add Sample based on drawer
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormPopUpStorageSample.id_wh = id_comp_from
        FormPopUpStorageSample.id_pop_up = "2"
        FormPopUpStorageSample.action = "ins"
        FormPopUpStorageSample.SLEWH.Enabled = False
        FormPopUpStorageSample.SLELocator.Enabled = True
        FormPopUpStorageSample.SLERack.Enabled = True
        FormPopUpStorageSample.SLEDrawer.Enabled = True
        FormPopUpStorageSample.allow_all_locator = True
        FormPopUpStorageSample.allow_all_rack = True
        FormPopUpStorageSample.allow_all_drawer = True
        FormPopUpStorageSample.allow_all_wh = False
        'FormPopUpStorageSample.GridColumnQtyPL.Visible = True
        FormPopUpStorageSample.GroupControlInput.Visible = True
        'FormPopUpStorageSample.BtnChoose.Text = "Save"
        If action = "ins" Then
            FormPopUpStorageSample.id_pl_sample_del_det = "0"
        Else
            FormPopUpStorageSample.id_pl_sample_del_det = "-1"
        End If
        FormPopUpStorageSample.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As String = ""
        If action = "ins" Then
            confirm = "Are you sure to delete this data?"
        ElseIf action = "upd" Then
            confirm = "This data will be removed from database, are you sure to delete this data?"
        End If
        If (MessageBox.Show(confirm, "Delete Confirmation", _
         MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_sample As String = GVDrawer.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim id_sample_requisition_det As String = GVDrawer.GetFocusedRowCellDisplayText("id_sample_requisition_det").ToString
        Dim id_pl_sample_del_det As String = GVDrawer.GetFocusedRowCellDisplayText("id_pl_sample_del_det").ToString
        Dim id_wh_drawer As String = GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim pl_sample_del_det_qty As String = GVDrawer.GetFocusedRowCellDisplayText("pl_sample_del_det_qty").ToString
        code_list.Remove(id_sample)
        code_list_drawer.Remove(id_wh_drawer)
        deleteRows()
        If id_pl_sample_del_det <> "0" Then
            Dim query_del As String = "DELETE FROM tb_pl_sample_del_det WHERE id_pl_sample_del_det = '" + id_pl_sample_del_det + "'"
            execute_non_query(query_del, True, "", "", "", "")
            Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
            query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Out sample was cancelled, PL : " + TxtPLNumber.Text + "')"
            execute_non_query(query_upd_storage, True, "", "", "", "")
        End If
        getAmountReq(id_sample_requisition_det, False)
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Dim id_wh_locator_curr As String = GVDrawer.GetFocusedRowCellDisplayText("id_wh_locator").ToString
        Dim id_wh_rack_curr As String = GVDrawer.GetFocusedRowCellDisplayText("id_wh_rack").ToString
        Dim id_wh_drawer_curr As String = GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim id_sample_edit As String = GVDrawer.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim qty As String = GVDrawer.GetFocusedRowCellDisplayText("pl_sample_del_det_qty").ToString
        Dim remark As String = GVDrawer.GetFocusedRowCellDisplayText("pl_sample_del_det_note").ToString
        Dim id_pl_sample_del_det As String = GVDrawer.GetFocusedRowCellDisplayText("id_pl_sample_del_det").ToString
        FormPopUpStorageSample.id_sample_edit = id_sample_edit
        FormPopUpStorageSample.pl_sample_del_det_qty = qty
        FormPopUpStorageSample.pl_sample_del_det_note = remark
        FormPopUpStorageSample.id_wh_locator_edit = id_wh_locator_curr
        FormPopUpStorageSample.id_wh_rack_edit = id_wh_rack_curr
        FormPopUpStorageSample.id_wh_drawer_edit = id_wh_drawer_curr
        FormPopUpStorageSample.id_wh = id_comp_from
        FormPopUpStorageSample.id_pop_up = "2"
        FormPopUpStorageSample.action = "upd"
        FormPopUpStorageSample.SLEWH.Enabled = False
        FormPopUpStorageSample.SLELocator.Enabled = False
        FormPopUpStorageSample.SLERack.Enabled = False
        FormPopUpStorageSample.SLEDrawer.Enabled = False
        FormPopUpStorageSample.BtnViewStock.Visible = False
        FormPopUpStorageSample.allow_all_locator = False
        FormPopUpStorageSample.allow_all_rack = False
        FormPopUpStorageSample.allow_all_drawer = False
        FormPopUpStorageSample.allow_all_wh = False
        'FormPopUpStorageSample.GridColumnQtyPL.Visible = True
        FormPopUpStorageSample.GroupControlInput.Visible = True
        FormPopUpStorageSample.id_pl_sample_del_det = id_pl_sample_del_det
        FormPopUpStorageSample.BtnChoose.Text = "Update"
        FormPopUpStorageSample.ShowDialog()
    End Sub
    'Color Cell
    Public Sub test_aw(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("A")
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        id_sample_requisition_det_style = GVDetail.GetFocusedRowCellValue("id_sample_requisition_det").ToString
        Dim id_sample_requisition_det_check As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("id_sample_requisition_det"))
        If id_sample_requisition_det_check = id_sample_requisition_det_style Then
            e.Appearance.BackColor = Color.SpringGreen
            e.Appearance.BackColor2 = Color.White
        End If
    End Sub

    Public Sub test_aw_wht(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("A")
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White
    End Sub

    Private Sub RepositoryItemSpinEdit2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
            Dim qty_limit As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("qty_all_sample").ToString)
            Dim current_name As String = GVDrawer.GetFocusedRowCellDisplayText("name").ToString
            Dim current_uom As String = GVDrawer.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_limit Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + qty_limit.ToString + " " + current_uom + " ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_qty", "0")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub getAmountReq(ByVal id_sample_requisition_det As String, ByVal is_sum_req As Boolean)
        Dim qty_sum As Decimal = 0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                'MsgBox(id_sample_requisition_det)
                Dim qty As Decimal = Decimal.Parse(GVDrawer.GetRowCellValue(i, "pl_sample_del_det_qty").ToString)
                Dim id_sample_requisition_det_data As String = GVDrawer.GetRowCellValue(i, "id_sample_requisition_det").ToString
                If id_sample_requisition_det_data = id_sample_requisition_det Then
                    qty_sum = qty + qty_sum
                End If
            Catch ex As Exception

            End Try
        Next
        GVDetail.FocusedRowHandle = find_row(GVDetail, "id_sample_requisition_det", id_sample_requisition_det)
        If Not is_sum_req Then
            'MsgBox(qty_sum.ToString("N2"))
            GVDetail.SetFocusedRowCellValue("qty_real_sample_wh", qty_sum)
        Else
            'MsgBox(qty_sum.ToString("N2"))
            Dim qty_requisition As Decimal = Decimal.Parse(GVDetail.GetFocusedRowCellDisplayText("sample_requisition_det_qty").ToString)
            Dim tot As Decimal = qty_requisition + qty_sum
            GVDetail.SetFocusedRowCellValue("qty_real_sample", qty_sum)
            GVDetail.SetFocusedRowCellValue("sample_requisition_det_qty", tot)
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        
        'MsgBox(qty_process.ToString)
        'Dim id_sample_requisition_det_data As String = GVDrawer.GetRowCellValue(0, "name").ToString
        'MsgBox(id_sample_requisition_det_data)
        'getAmountReq("1")
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportSamplePLDel.id_pl_sample_del = id_pl_sample_del
        Dim Report As New ReportSamplePLDel()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub RepositoryItemSpinEdit2_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit2.EditValueChanged
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
            Dim qty_requisition As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("sample_requisition_det_qty").ToString)
            Dim qty_available As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("qty_all_sample").ToString)
            Dim current_name As String = GVDrawer.GetFocusedRowCellDisplayText("name").ToString
            Dim uom As String = GVDrawer.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_requisition Or qty_rec > qty_available Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Error : " + vbNewLine + "- Qty cannot exceed qty requisition " + vbNewLine + "- Qty cannot exceed qty available ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_qty", "0")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SPDuration_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPDuration.EditValueChanged
        DEPLReturn.Text = view_date(Integer.Parse(SPDuration.EditValue))
    End Sub

    Private Sub GVDrawer_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)
        cantEdit()
    End Sub

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub

    Private Sub GVDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDetail.RowClick
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub

    Private Sub BtnPopSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopSource.Click
        FormPopUpContact.id_pop_up = "9"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoSrs()
    End Sub

    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_sample_requisition_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        Dim query_check As String = "SELECT (a.sample_requisition_det_qty - IFNULL(SUM(IF(pl.id_report_status='5',0,b.pl_sample_del_det_qty)), 0) ) AS allow_sum "
        query_check += "FROM tb_sample_requisition_det a "
        query_check += "LEFT JOIN tb_pl_sample_del_det b ON a.id_sample_requisition_det = b.id_sample_requisition_det "
        query_check += "LEFT JOIN tb_pl_sample_del pl ON pl.id_pl_sample_del = b.id_pl_sample_del "
        If action = "upd" Then
            query_check += "AND b.id_pl_sample_del !='" + id_pl_sample_del + "' "
        End If
        query_check += "WHERE a.id_sample_requisition_det = '" + id_sample_requisition_det_cek + "'  "
        query_check += "GROUP BY a.id_sample_requisition "
        allow_sum = Decimal.Parse(execute_query(query_check, 0, True, "", "", "", ""))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoSrs()
        Cursor = Cursors.WaitCursor
        FormInfoSRS.id_sample_requisition = id_sample_requisition
        FormInfoSRS.LabelSubTitle.Text = "SRS No : " + TxtSRSNumber.Text + ""
        FormInfoSRS.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintDrawer.Click
        Cursor = Cursors.WaitCursor
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw_wht
        ReportStyleGridview(GVDrawer)
        print(GCDrawer, "Item List Based on Drawer")
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDrawer_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDrawer.FocusedRowChanged
        noManipulating()
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = 0
        Try
            indeks = GVDrawer.FocusedRowHandle
        Catch ex As Exception
        End Try
        If indeks < 0 Then
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        End If
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
        Dim index_atas As Integer = 0

        'check available code
        For i As Integer = 0 To (GVDetail.RowCount - 1)
            Dim code As String = GVDetail.GetRowCellValue(i, "code").ToString
            id_sample = GVDetail.GetRowCellValue(i, "id_sample").ToString
            If code = code_check Then
                'cek qty
                index_atas = i
                code_found = True
                Exit For
            End If
        Next

        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        Else
            If GVDetail.GetRowCellValue(index_atas, "qty_real_sample") >= GVDetail.GetRowCellValue(index_atas, "sample_requisition_det_qty") Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Qty PL more than Remaining Qty.")
            ElseIf GVDetail.GetRowCellValue(index_atas, "qty_real_sample") >= GVDetail.GetRowCellValue(index_atas, "qty_real_sample_wh") Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Qty PL more than Qty from WH.")
            Else
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                GVBarcode.SetFocusedRowCellValue("id_sample", id_sample)
                countQty(id_sample)
                newRowsBc()
            End If
        End If
        Cursor = Cursors.Default
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

        GVDetail.FocusedRowHandle = find_row(GVDetail, "id_sample", id_sample_param)
        GVDetail.SetFocusedRowCellValue("qty_real_sample", tot)

        GCDetail.RefreshDataSource()
        GVDetail.RefreshData()
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
        If GVDetail.RowCount < 1 Then
            errorCustom("Please choose Sample Borrow Requisition.")
        Else
            startScan()
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        stopScan()
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

    Sub startScan()
        If GVDetail.RowCount > 0 Then
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BtnPopSRS.Enabled = False
            BDelete.Enabled = False
            newRowsBc()
        Else
            errorCustom("Please choose Sample Requisition.")
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
        GVDetail.FocusedRowHandle = 0
        GCDetail.RefreshDataSource()
        GVDetail.RefreshData()

        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BDelete.Enabled = True
        allowDelete()
        BtnPopSRS.Enabled = False
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub
End Class