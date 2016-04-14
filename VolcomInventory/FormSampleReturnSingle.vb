Public Class FormSampleReturnSingle 
    Public id_sample_return As String = "-1"
    Public id_comp_contact_from As String
    Public id_comp_contact_to As String
    Public action As String
    Public id_report_status As String
    Public id_comp_to As String
    Public id_pl_sample_del As String = "-1"
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    'Public code_list, code_list_drawer As New List(Of String)

    'Form
    Private Sub FormSampleReturnSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        viewComp()
        actionLoad()
    End Sub
    Private Sub FormSampleReturnSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'Validating
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompFrom)
        EPRet.SetIconPadding(TxtNameCompFrom, 30)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'EP_TE_cant_blank(EPRet, TxtNameCompTo)
        'EPRet.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    'PopUp
    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "16"
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "17"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub

    'View Data
    Sub viewDump()
        Dim query As String = "CALL view_pl_sample_del('" + id_pl_sample_del + "', '2')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDump.DataSource = data
        For i As Integer = 0 To (data.Rows.Count - 1)
            If action = "upd" Then
                getAmountReq(data.Rows(i)("id_sample").ToString, False)
            End If
        Next
    End Sub

    'View Company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "WHERE a.id_departement = '" + id_departement_user + "' "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub

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

    Sub actionLoad()
        If action = "ins" Then
            PanelControl1.Visible = True
            id_comp_contact_to = get_company_x(id_comp_to, 6)
            'TxtCodeCompTo.Text = get_company_x(id_comp_to, 2)
            'TxtNameCompTo.Text = get_company_x(id_comp_to, 1)

            'new based on Info Return
            If id_pl_sample_del <> "-1" Then
                viewDetailReturn()
                GroupControlRet.Enabled = True

                viewDetailBC()
                allowDelete()
                GroupControlScannedItem.Enabled = True
            End If

            BtnBrowseContactTo.Focus()
            Dim regDate As Date = Date.Now()
            Dim strDate As String = regDate.ToString("dd\/MM\/yyyy")
            DERet.Text = strDate
            TxtRetNumber.Text = header_number("11")
            id_report_status = LEReportStatus.EditValue.ToString
            BMark.Enabled = False
            BtnPrint.Enabled = False
        ElseIf action = "upd" Then
            PanelControl1.Visible = False
            PanelNavBarcode.Visible = False
            GVRetDetail.OptionsBehavior.AutoExpandAllGroups = True
            'BtnBrowseContactFrom.Enabled = False
            BtnInfoPL.Enabled = True
            BtnPopPLDel.Enabled = False
            BtnCancel.Text = "Close"
            GridColumnQtyRemaining.Visible = False

            'Fetch from db main
            Dim query As String = "SELECT a.id_wh_drawer,rck.id_wh_rack, loc.id_wh_locator, a.id_pl_sample_del, g.pl_sample_del_number, h.id_user, a.id_sample_return, a.id_comp_contact_from , a.id_comp_contact_to,a.sample_return_date, DATE_FORMAT(a.sample_return_date,'%Y-%m-%d') as sample_return_datex,a.sample_return_note, a.sample_return_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_t, a.id_report_status,cod_det.code_detail_name as division "
            query += "FROM tb_sample_return a "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp  "
            query += "INNER JOIN tb_pl_sample_del g ON a.id_pl_sample_del = g.id_pl_sample_del "
            query += "INNER JOIN tb_sample_requisition h ON h.id_sample_requisition = g.id_sample_requisition "
            query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=h.id_division "
            query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
            query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
            query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += "WHERE a.id_sample_return = '" + id_sample_return + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'tampung ke form
            TEDivision.Text = data.Rows(0)("division").ToString
            id_pl_sample_del = data.Rows(0)("id_pl_sample_del").ToString
            TxtPLSampleDelNumber.Text = data.Rows(0)("pl_sample_del_number").ToString
            TxtCodeUserFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 2)
            TxtNameUserFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
            TxtCodeDeptFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 5)
            TxtNameDeptFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 4)
            TxtRetNumber.Text = data.Rows(0)("sample_return_number").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            'id_comp_from = data.Rows(0)("id_comp_from").ToString
            'TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
            'TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString

            'MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
            'Dim start_date_arr() As String = data.Rows(0)("sample_return_date").ToString.Split(" ")
            'Dim tgl_format As Date = start_date_arr(0)
            DERet.Text = view_date_from(data.Rows(0)("sample_return_datex").ToString, 0)
            MENote.Text = data.Rows(0)("sample_return_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            'Group Control
            GroupControlRet.Enabled = True
            GroupControlScannedItem.Enabled = True

            'based on sttatus
            id_report_status = data.Rows(0)("id_report_status").ToString

            'comp
            SLEStorage.EditValue = data.Rows(0)("id_comp_to").ToString
            SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
            SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
            SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
            

            'Fetch db detail
            viewDetailBC()
            viewDetailReturn()
            allow_status()
            allowDelete()
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "14", id_sample_return) Then
            'MsgBox("Masih Boleh")
            BMark.Enabled = True
            BtnSave.Enabled = True
            BtnBrowseContactTo.Enabled = True
            GVRetDetail.OptionsBehavior.Editable = True
            MENote.Properties.ReadOnly = False
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            SLEStorage.Enabled = True
            SLELocator.Enabled = True
            SLERack.Enabled = True
            SLEDrawer.Enabled = True
            PanelNavBarcode.Enabled = True
            'GridColumnQtyRemaining.Visible = True
        Else
            BMark.Enabled = True
            BtnSave.Enabled = False
            BtnBrowseContactTo.Enabled = False
            GVRetDetail.OptionsBehavior.Editable = False
            MENote.Properties.ReadOnly = True
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            SLEStorage.Enabled = False
            SLELocator.Enabled = False
            SLERack.Enabled = False
            SLEDrawer.Enabled = False
            PanelNavBarcode.Enabled = False
            'GridColumnQtyRemaining.Visible = False
        End If


        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub
    Sub viewDetailReturn()
        'UPDATED 17 NOVEMBER 2014
        Dim query As String = ""
        If action = "ins" Then
            query = "CALL view_pl_sample_del_limit('" + id_pl_sample_del + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetDetail.DataSource = data
        Else
            query += "CALL view_sample_return('" + id_sample_return + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetDetail.DataSource = data
            If data.Rows.Count > 0 Then
                For i As Integer = 0 To data.Rows.Count - 1
                    For j As Integer = 0 To data.Rows(i)("sample_return_det_qty") - 1
                        GVBarcode.AddNewRow()
                        GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample"))
                        GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code"))
                        GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                    Next
                Next
                GCRetDetail.DataSource = data
                GCBarcode.RefreshDataSource()
                GVBarcode.RefreshData()
            End If
        End If
        viewDump()
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
        cantEdit()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
        cantEdit()
    End Sub

    'Button Action
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'UPDATED 17 NOVEMBER 2014
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        Dim cond_qty As Boolean = True
        makeSafeGV(GVRetDetail)

        'check drawer
        Dim id_wh_drawer_cek As String = "-1"
        Try
            id_wh_drawer_cek = SLEDrawer.EditValue.ToString
        Catch ex As Exception
        End Try

        For i As Integer = 0 To (GVDump.RowCount - 1)
            Try
                Dim qty As String = GVDump.GetRowCellValue(i, "qty_real_sample").ToString
                Dim id_sample_checkya As String = GVDump.GetRowCellValue(i, "id_sample").ToString
                Dim sample_checkya As String = GVDump.GetRowCellValue(i, "name").ToString
                isAllowPL(id_sample_checkya, sample_checkya, id_pl_sample_del, qty)
                If Not cond_check Then
                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next
        If Not formIsValidInGroup(EPRet, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_qty Or GVRetDetail.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            stopCustom("Error : " + System.Environment.NewLine + "- Data can't blank. " + System.Environment.NewLine + "- Qty can't blank or zero value !")
        ElseIf Not cond_check Then
            stopCustom("Sample : '" + sample_check + "' cannot exceed " + allow_sum.ToString("N2") + ", please check in Info PL ! ")
            FormInfoPLSampleDel.id_sample_return = "-1"
            infoPL()
        ElseIf id_wh_drawer_cek = "-1" Then
            stopCustom("Drawer not valid, please select other drawer.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'Main var
                Dim query As String = ""
                Dim query2 As String = ""
                Dim sample_return_number As String = addSlashes(TxtRetNumber.Text)
                'Dim sample_return_date_format As Date = CType(DERet.Text, Date)
                'Dim sample_return_date As String = sample_return_date_format.ToString("yyyy-MM-dd")
                Dim sample_return_note As String = addSlashes(MENote.Text)
                Dim id_report_status As String = LEReportStatus.EditValue

                'detail var
                Dim sample_return_det_note As String
                Dim id_sample_return_det As String = ""
                Dim sample_return_det_qty As String
                Dim id_sample As String
                Dim id_sample_price As String
                Dim sample_price As String
                Dim succes As Boolean = False

                'drawer & storage
                Dim id_wh_drawer As String = SLEDrawer.EditValue.ToString
                Dim id_storage As String = SLEStorage.EditValue.ToString
                id_comp_contact_to = get_company_x(id_storage, "6")

                If action = "ins" Then
                    'Main table
                    query = "INSERT INTO tb_sample_return(id_pl_sample_del, sample_return_number, id_comp_contact_from, id_comp_contact_to, sample_return_date, sample_return_note, id_report_status, id_wh_drawer) "
                    query += "VALUES('" + id_pl_sample_del + "', '" + sample_return_number + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', NOW(), '" + sample_return_note + "', '" + id_report_status + "', '" + id_wh_drawer + "');SELECT LAST_INSERT_ID(); "
                    id_sample_return = execute_query(query, 0, True, "", "", "", "")

                    increase_inc("11")

                    'preapred default
                    insert_who_prepared("14", id_sample_return, id_user)


                    'detail table
                    Dim jum_ins_i As Integer = 0
                    Dim query_detail As String = ""
                    If GVRetDetail.RowCount > 0 Then
                        query_detail = "INSERT tb_sample_return_det(id_sample_return, sample_return_det_note, sample_return_det_qty, id_wh_drawer, id_sample,id_sample_price ,sample_price) VALUES "
                    End If
                    For i As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Try
                            sample_return_det_note = GVRetDetail.GetRowCellValue(i, "sample_return_det_note").ToString
                            sample_return_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(i, "sample_return_det_qty").ToString)
                            id_sample = GVRetDetail.GetRowCellValue(i, "id_sample").ToString
                            id_sample_price = GVRetDetail.GetRowCellValue(i, "id_sample_price").ToString
                            sample_price = decimalSQL(GVRetDetail.GetRowCellValue(i, "sample_price").ToString)

                            'INSERT TB PL SAMPLE DETAIL
                            If jum_ins_i > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sample_return + "','" + sample_return_det_note + "', '" + sample_return_det_qty + "', '" + id_wh_drawer + "', '" + id_sample + "', '" + id_sample_price + "', '" + sample_price + "') "
                            jum_ins_i = jum_ins_i + 1
                            succes = True
                        Catch ex As Exception
                        End Try
                    Next

                    If GVRetDetail.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    FormSampleReturn.viewSampleReturn()
                    FormSampleReturn.viewPl()
                    FormSampleReturn.GVRetSample.FocusedRowHandle = find_row(FormSampleReturn.GVRetSample, "id_sample_return", id_sample_return)
                    Close()
                ElseIf action = "upd" Then
                    Try
                        'update main table
                        query = "UPDATE tb_sample_return SET sample_return_number = '" + sample_return_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', sample_return_note = '" + sample_return_note + "', id_report_status = '" + id_report_status + "', id_wh_drawer='" + id_wh_drawer + "' WHERE id_sample_return = '" + id_sample_return + "'"
                        execute_non_query(query, True, "", "", "", "")

                        'update detail
                        For i As Integer = 0 To (GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail)
                            Try
                                id_sample_return_det = GVRetDetail.GetRowCellValue(i, "id_sample_return_det").ToString
                                sample_return_det_note = GVRetDetail.GetRowCellValue(i, "sample_return_det_note").ToString
                                sample_return_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(i, "sample_return_det_qty").ToString)

                                'Edit TB PL SAMPLE DETAIL
                                Dim query_upd As String = "UPDATE tb_sample_return_det SET sample_return_det_qty='" + sample_return_det_qty + "', sample_return_det_note='" + sample_return_det_note + "', id_wh_drawer = '" + id_wh_drawer + "' WHERE id_sample_return_det='" + id_sample_return_det + "' "
                                execute_non_query(query_upd, True, "", "", "", "")
                            Catch ex As Exception
                            End Try
                        Next

                        FormSampleReturn.viewSampleReturn()
                        FormSampleReturn.viewPl()
                        FormSampleReturn.GVRetSample.FocusedRowHandle = find_row(FormSampleReturn.GVRetSample, "id_sample_return", id_sample_return)
                        Close()

                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportSampleReturn.id_sample_return = id_sample_return
        Dim Report As New ReportSampleReturn()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_return
        FormReportMark.report_mark_type = "14"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSampleReturnPickSingle.id_wh = SLEStorage.EditValue.ToString
        FormSampleReturnPickSingle.id_pl_sample_del = id_pl_sample_del
        FormSampleReturnPickSingle.action = "ins"
        FormSampleReturnPickSingle.SLEWH.Enabled = False
        If action = "ins" Then
            FormSampleReturnPickSingle.id_sample_return_det = "0"
        Else
            FormSampleReturnPickSingle.id_sample_return_det = "-1"
        End If
        FormSampleReturnPickSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        Dim id_wh_locator_curr As String = GVRetDetail.GetFocusedRowCellDisplayText("id_wh_locator").ToString
        Dim id_wh_rack_curr As String = GVRetDetail.GetFocusedRowCellDisplayText("id_wh_rack").ToString
        Dim id_wh_drawer_curr As String = GVRetDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim id_sample_edit As String = GVRetDetail.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim qty As String = GVRetDetail.GetFocusedRowCellDisplayText("sample_return_det_qty").ToString
        Dim remark As String = GVRetDetail.GetFocusedRowCellDisplayText("sample_return_det_note").ToString
        Dim id_sample_return_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_sample_return_det").ToString
        FormSampleReturnPickSingle.indeks_edit = GVRetDetail.FocusedRowHandle
        FormSampleReturnPickSingle.id_sample_edit = id_sample_edit
        FormSampleReturnPickSingle.id_sample_return = id_sample_return
        FormSampleReturnPickSingle.sample_return_det_qty = qty
        FormSampleReturnPickSingle.sample_return_det_note = remark
        FormSampleReturnPickSingle.id_wh_locator_edit = id_wh_locator_curr
        FormSampleReturnPickSingle.id_wh_rack_edit = id_wh_rack_curr
        FormSampleReturnPickSingle.id_wh_drawer_edit = id_wh_drawer_curr
        FormSampleReturnPickSingle.id_wh = id_comp_to
        FormSampleReturnPickSingle.id_pl_sample_del = id_pl_sample_del
        FormSampleReturnPickSingle.action = "upd"
        FormSampleReturnPickSingle.SLEWH.Enabled = False
        FormSampleReturnPickSingle.id_sample_return_det = id_sample_return_det
        FormSampleReturnPickSingle.BtnChoose.Text = "Update"
        FormSampleReturnPickSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        'UPDATED 20 October 2014
        Dim confirm As String = ""
        confirm = "Are you sure to delete this data?"
        If (MessageBox.Show(confirm, "Delete Confirmation", _
         MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_sample As String = GVRetDetail.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim id_sample_return_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_sample_return_det").ToString
        Dim id_wh_drawer As String = GVRetDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim sample_return_det_qty As String = GVRetDetail.GetFocusedRowCellDisplayText("sample_return_det_qty").ToString
        deleteRows()
        deleteDetailBC(id_sample)
        getAmountReq(id_sample, False)
        allowDelete()
        'If id_sample_return_det <> "0" Then
        '    Dim query_del As String = "DELETE FROM tb_sample_return_det WHERE id_sample_return_det = '" + id_sample_return_det + "'"
        '    execute_non_query(query_del, True, "", "", "", "")
        '    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
        '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_sample + "', '" + sample_return_det_qty + "', NOW(), 'Sample IN was cancelled, Return Sample No. : " + TxtRetNumber.Text + "')"
        '    execute_non_query(query_upd_storage, True, "", "", "", "")
        'End If
    End Sub

    Private Sub BtnPopPLDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopPLDel.Click
        Cursor = Cursors.WaitCursor
        FormPopUpSamplePLDel.id_pop_up = "1"
        FormPopUpSamplePLDel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub isAllowPL(ByVal id_sample As String, ByVal sample_name As String, ByVal id_pl_sample_del_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        Dim query_check As String = "SELECT "
        If action = "upd" Then
            'MsgBox("Update")
            query_check += "(SUM(a.pl_sample_del_det_qty) - COALESCE((SELECT SUM(tb_sample_return_det.sample_return_det_qty) FROM tb_sample_return_det INNER JOIN tb_sample_return ON tb_sample_return_det.id_sample_return = tb_sample_return.id_sample_return WHERE tb_sample_return.id_report_status!='5' AND tb_sample_return_det.id_sample = '" + id_sample + "' AND tb_sample_return.id_pl_sample_del='" + id_pl_sample_del_cek + "' AND tb_sample_return.id_sample_return!='" + id_sample_return + "'),0)) AS not_yet_returned "
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

    Sub infoPL()
        Cursor = Cursors.WaitCursor
        FormInfoPLSampleDel.id_pl_sample_del = id_pl_sample_del
        FormInfoPLSampleDel.LabelSubTitle.Text = "PL Sample Delivery No : " + TxtPLSampleDelNumber.Text + ""
        FormInfoPLSampleDel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub getAmountReq(ByVal id_sample As String, ByVal is_sum_req As Boolean)
        Dim qty_sum As Decimal = 0
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            Try
                'MsgBox(id_sample_requisition_det)
                Dim qty As Decimal = Decimal.Parse(GVRetDetail.GetRowCellValue(i, "sample_return_det_qty").ToString)
                Dim id_sample_data As String = GVRetDetail.GetRowCellValue(i, "id_sample").ToString
                If id_sample_data = id_sample Then
                    qty_sum = qty + qty_sum
                End If
            Catch ex As Exception

            End Try
        Next
        GVDump.FocusedRowHandle = find_row(GVDump, "id_sample", id_sample)
        If Not is_sum_req Then
            'MsgBox(qty_sum.ToString("N2"))
            GVDump.SetFocusedRowCellValue("qty_real_sample", qty_sum.ToString("N2"))
        Else
            ''MsgBox(qty_sum.ToString("N2"))
            'Dim qty_requisition As Decimal = Decimal.Parse(GVDump.GetFocusedRowCellDisplayText("sample_requisition_det_qty").ToString)
            'Dim tot As Decimal = qty_requisition + qty_sum
            'GVDetail.SetFocusedRowCellValue("qty_real_sample", qty_sum.ToString("N2"))
            'GVDetail.SetFocusedRowCellValue("sample_requisition_det_qty", tot.ToString("N2"))
        End If
    End Sub

    Private Sub BtnInfoPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoPL.Click
        If action = "ins" Then
            FormInfoPLSampleDel.id_sample_return = "-1"
        ElseIf action = "upd" Then
            FormInfoPLSampleDel.id_sample_return = "-1"
            'If check_edit_report_status(id_report_status, "14", id_sample_return) Then
            '    FormInfoPLSampleDel.id_sample_return = id_sample_return
            'Else
            '    FormInfoPLSampleDel.id_sample_return = "-1"
            'End If
        End If
        infoPL()
    End Sub

    Sub cantEdit()
        Dim id_sample_curr As String = ""
        Try
            id_sample_curr = GVRetDetail.GetFocusedRowCellDisplayText("id_sample").ToString()
        Catch ex As Exception

        End Try
        If GVRetDetail.RowCount < 1 Or id_sample_curr = "" Then
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            If check_edit_report_status(id_report_status, "14", id_sample_return) Or action = "ins" Then
                BtnEdit.Enabled = True
                BtnDel.Enabled = True
            End If
        End If
    End Sub

    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        cantEdit()
    End Sub

    Private Sub GVRetDetail_RowCountChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetDetail.RowCountChanged

    End Sub

    Private Sub GVRetDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVRetDetail.RowClick
        cantEdit()
    End Sub

    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
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

    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub

    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
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
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            Dim code As String = GVRetDetail.GetRowCellValue(i, "code").ToString
            id_sample = GVRetDetail.GetRowCellValue(i, "id_sample").ToString
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
            If GVRetDetail.GetRowCellValue(index_atas, "sample_return_det_qty") >= GVRetDetail.GetRowCellValue(index_atas, "pl_sample_del_det_limit_qty") Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Qty Returned more than Remaining Qty.")
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

        GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_sample", id_sample_param)
        GVRetDetail.SetFocusedRowCellValue("sample_return_det_qty", tot)

        GCRetDetail.RefreshDataSource()
        GVRetDetail.RefreshData()
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
        If GVRetDetail.RowCount < 1 Then
            errorCustom("Please choose Return List.")
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
        If GVRetDetail.RowCount > 0 Then
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BtnPopPLDel.Enabled = False
            BDelete.Enabled = False
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            BtnCancel.Enabled = False
            BtnInfoPL.Enabled = False
            newRowsBc()
        Else
            errorCustom("Please choose Return List.")
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
        GVRetDetail.FocusedRowHandle = 0
        GCRetDetail.RefreshDataSource()
        GVRetDetail.RefreshData()

        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BDelete.Enabled = True
        BtnAdd.Enabled = True
        BtnEdit.Enabled = True
        BtnDel.Enabled = True
        BtnCancel.Enabled = True
        BtnInfoPL.Enabled = True
        allowDelete()
        BtnPopPLDel.Enabled = False
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
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

    Private Sub SLEStorage_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLEStorage.Validating
        EP_SLE_cant_blank(EPRet, SLEStorage)
    End Sub
End Class