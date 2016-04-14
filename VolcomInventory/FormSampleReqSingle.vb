Public Class FormSampleReqSingle 
    Public action As String
    Public id_sample_requisition As String = "-1"
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_comp_to As String
    Public id_comp_from As String
    Public id_sample_list, id_wh_drawer_list, id_sample_requisition_det_list As New List(Of String)
    Public id_report_status As String
    Public end_load As String = "-1"
    'Form
    Private Sub FormSampleReqSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        _view_division(LESampleDivision)
        actionLoad()
        end_load = "1"
    End Sub
    Private Sub FormSampleReqSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View Data
    Sub viewBlank()
        Dim query As String = "SELECT ('') AS code, ('0') AS id_sample_requisition_det, ('0') AS id_sample, ('') AS name, ('') AS size, ('') AS uom, ('0') AS sample_requisition_det_qty, ('') AS sample_requisition_det_note,('0') AS qty_all_sample, "
        query += "('0') AS id_comp, ('0') AS id_wh_locator, ('0') AS id_wh_rack, ('0') AS id_wh_drawer, "
        query += "('') AS comp_name, ('') AS wh_locator, ('') AS wh_rack, ('') AS wh_drawer "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    Sub actionLoad()
        If action = "ins" Then
            Dim id_super_admin As String = execute_query("SELECT id_role_super_admin FROM tb_opt", 0, True, "", "", "", "")


            'get from
            TxtCodeFrom.Text = get_user_identify(id_user, 2)
            TxtNameFrom.Text = get_user_identify(id_user, 1)
            TxtCodeDept.Text = get_departement_x(id_departement_user, 2)
            TxtNameDept.Text = get_departement_x(id_departement_user, 1)
            id_comp_from = get_company_from(id_user)
            id_comp_contact_from = get_company_x(id_comp_from, 6)
            TxtCodeCompFrom.Text = get_company_x(id_comp_from, 2)
            TxtNameCompFrom.Text = get_company_x(id_comp_from, 1)

            'fill auto
            viewDetail()
            isManipulation()
            Dim regDate As Date = Date.Now()
            Dim strDate As String = regDate.ToString("yyyy\-MM\-dd")
            DEReq.Text = view_date_from(strDate, 0)
            TxtReqNumber.Text = header_number("9")
            id_report_status = LEReportStatus.EditValue.ToString
            BtnAttachment.Enabled = False
            BtnPrint.Enabled = False
        ElseIf action = "upd" Then
            'BtnPopContactFrom.Enabled = False
            GroupControlReq.Enabled = True

            Dim query As String = ""
            query += "SELECT a.id_user, a.id_division, a.id_sample_requisition, a.sample_requisition_date, a.sample_requisition_duration, "
            query += "a.sample_requisition_note, a.sample_requisition_number, (c.comp_name) AS comp_from,  (c.id_comp) AS id_comp_from, (c.comp_number) AS comp_code_contact_from, (b.id_comp_contact) AS id_comp_contact_from, "
            'query += "(e.comp_name) AS comp_to, (e.id_comp) AS id_comp_to, (e.comp_number) AS comp_code_contact_to, (d.id_comp_contact) AS id_comp_contact_to, (e.address_primary) AS comp_address_contact_to, "
            query += " a.id_report_status, DATE_FORMAT(a.sample_requisition_date,'%Y-%m-%d') as sample_requisition_datex "
            query += "FROM tb_sample_requisition a INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact "
            query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
            'query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
            'query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
            query += "WHERE a.id_sample_requisition = '" + id_sample_requisition + "' "
            query += "ORDER BY a.id_sample_requisition DESC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtCodeFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 2)
            TxtNameFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
            TxtCodeDept.Text = get_user_identify(data.Rows(0)("id_user").ToString, 5)
            TxtNameDept.Text = get_user_identify(data.Rows(0)("id_user").ToString, 4)
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            'id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            'TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_to").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_from").ToString
            'TxtNameCompTo.Text = data.Rows(0)("comp_to").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            'id_comp_to = data.Rows(0)("id_comp_to").ToString
            'MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            Dim start_date_arr As String = view_date_from(data.Rows(0)("sample_requisition_datex").ToString, 0)
            DEReq.Text = start_date_arr.ToString
            TxtReqNumber.Text = data.Rows(0)("sample_requisition_number").ToString
            MENote.Text = data.Rows(0)("sample_requisition_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            SPDuration.Text = data.Rows(0)("sample_requisition_duration").ToString

            LESampleDivision.ItemIndex = LESampleDivision.Properties.GetDataSourceRowIndex("id_code_detail", data.Rows(0)("id_division").ToString)

            'Constraint Status
            If id_report_status = "3" Or id_report_status = "4" Or id_report_status = "6" Or id_report_status = "7" Then  'app
                ' GridColumnQtyAll.Visible = False
                BMark.Visible = True
                BtnPrint.Enabled = True
                GVRetDetail.OptionsBehavior.Editable = False
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
                MENote.Properties.ReadOnly = True
                BtnPopContactFrom.Enabled = False
                BtnPopContactTo.Enabled = False
                SPDuration.Properties.ReadOnly = True
                SimpleButton2.Enabled = False
                LESampleDivision.Enabled = False
                'DEReq.Properties.ReadOnly = True
                'DERetDueDate.Properties.ReadOnly = True
            ElseIf id_report_status = "5" Then 'cancel
                'GridColumnQtyAll.Visible = False
                BMark.Visible = False
                BtnPrint.Enabled = False
                GVRetDetail.OptionsBehavior.Editable = False
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
                MENote.Properties.ReadOnly = True
                BtnPopContactFrom.Enabled = False
                BtnPopContactTo.Enabled = False
                SPDuration.Properties.ReadOnly = True
                SimpleButton2.Enabled = False
                LESampleDivision.Enabled = False
                'DEReq.Properties.ReadOnly = True
            Else
                BMark.Visible = True
                BtnPrint.Enabled = False
                If check_edit_report_status(id_report_status, "11", id_sample_requisition) Then
                    'GridColumnQtyAll.Visible = True
                    GVRetDetail.OptionsBehavior.Editable = True
                    BtnAdd.Enabled = True
                    BtnEdit.Enabled = True
                    BtnDel.Enabled = True
                    MENote.Properties.ReadOnly = False
                    BtnPopContactFrom.Enabled = True
                    BtnPopContactTo.Enabled = True
                    SPDuration.Properties.ReadOnly = False
                    SimpleButton2.Enabled = True
                    BtnCancel.Text = "Cancel"
                    ' DEReq.Properties.ReadOnly = False
                    LESampleDivision.Enabled = True
                Else
                    'GridColumnQtyAll.Visible = False
                    'MsgBox("ndak boleh")
                    GVRetDetail.OptionsBehavior.Editable = False
                    BtnAdd.Enabled = False
                    BtnEdit.Enabled = False
                    BtnDel.Enabled = False
                    MENote.Properties.ReadOnly = True
                    BtnPopContactFrom.Enabled = False
                    BtnPopContactTo.Enabled = False
                    SPDuration.Properties.ReadOnly = True
                    SimpleButton2.Enabled = False
                    BtnCancel.Text = "Close"
                    ' DEReq.Properties.ReadOnly = True
                    LESampleDivision.Enabled = False
                End If
            End If
            'attachment
            If check_attach_report_status(id_report_status, "11", id_sample_requisition) Then
                BtnAttachment.Enabled = True
            Else
                BtnAttachment.Enabled = False
            End If
            viewDetail()
        End If
    End Sub
    Sub viewDetail()
        Dim query As String = "CALL view_sample_req_det('" + id_sample_requisition + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_list.Add(data.Rows(i)("id_sample").ToString)
            id_sample_requisition_det_list.Add(data.Rows(i)("id_sample_requisition_det").ToString)
        Next
        GCRetDetail.DataSource = data
    End Sub
    'Validating
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompFrom)
        EPRet.SetIconPadding(TxtNameCompFrom, 30)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        'EP_TE_cant_blank(EPRet, TxtNameCompTo)
        'EPRet.SetIconPadding(TxtNameCompTo, 30)
    End Sub
    Private Sub RepositoryItemSpinEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit1.EditValueChanged
        'aktifkan jika dipakai (ada pembatasan berdasarkan limit)
        'Try
        '    Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        '    Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
        '    Dim qty_limit As Decimal = Decimal.Parse(GVRetDetail.GetFocusedRowCellDisplayText("qty_all_sample").ToString)
        '    Dim current_name As String = GVRetDetail.GetFocusedRowCellDisplayText("name").ToString
        '    Dim uom As String = GVRetDetail.GetFocusedRowCellDisplayText("uom").ToString
        '    If qty_rec > qty_limit Then
        '        DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + qty_limit.ToString + " " + uom, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        GVRetDetail.SetFocusedRowCellValue("sample_requisition_det_qty", (qty_rec - 1).ToString)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub GVRetDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVRetDetail.CellValueChanged
        'If e.Column.FieldName = "sample_requisition_det_qty" Then
        '    Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        '    Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
        '    Dim qty_limit As Decimal = Decimal.Parse(GVRetDetail.GetFocusedRowCellDisplayText("qty_all_sample").ToString)
        '    Dim current_name As String = GVRetDetail.GetFocusedRowCellDisplayText("name").ToString
        '    If qty_rec > qty_limit Then
        '        DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + qty_limit.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        GVRetDetail.SetFocusedRowCellValue("sample_requisition_det_qty", "0")
        '    End If
        'End If
    End Sub
    'Button
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        'Cek isi qty
        Dim cond_qty As Boolean = True
        Dim cond_qty2 As Boolean = True
        Dim id_samplec As String = ""
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            id_samplec = ""
            Try
                id_samplec = GVRetDetail.GetRowCellValue(i, "id_sample").ToString
                Dim qty As Decimal = Decimal.Parse(GVRetDetail.GetRowCellValue(i, "sample_requisition_det_qty").ToString)
                If qty = 0 Then
                    cond_qty = False
                End If
            Catch ex As Exception

            End Try
            'tidak dipakai karena siapa tau bisa dipenuhi permintaannya setelah berjalan
            'Try
            '    Dim qty_rec As Decimal = Decimal.Parse(GVRetDetail.GetRowCellValue(i, "sample_requisition_det_qty").ToString)
            '    Dim qty_limit As Decimal = Decimal.Parse(GVRetDetail.GetRowCellValue(i, "qty_all_sample").ToString)
            '    'dim current_name as string = gvretdetail.getfocusedrowcelldisplaytext("name").tostring
            '    If qty_rec > qty_limit Then
            '        cond_qty2 = False
            '    End If
            'Catch ex As Exception

            'End Try
        Next
        If Not formIsValidInGroup(EPRet, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_qty Or GVRetDetail.RowCount = 0 Or Not cond_qty2 Then
            errorCustom("- Qty can't blank or zero value ! " + System.Environment.NewLine + "- Sample requisiton list can't blank !")
        Else
            Dim query As String
            Dim sample_requisition_number As String = addSlashes(TxtReqNumber.Text)
            'Dim sample_requisition_date_format As Date = DateTime.Parse(DEReq.Text)
            'Dim sample_requisition_date As String = sample_requisition_date_format.ToString("yyyy-MM-dd")
            Dim sample_requisition_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim sample_requisition_duration As String = SPDuration.Text.ToString
            Dim id_sample_requisition_det, id_division, sample_requisition_det_qty, sample_requisition_det_note, id_sample As String
            id_division = LESampleDivision.EditValue.ToString

            If action = "ins" Then
                Try
                    'Main tbale
                    query = "INSERT INTO tb_sample_requisition(sample_requisition_number, id_comp_contact_from, sample_requisition_date, sample_requisition_note, id_report_status, sample_requisition_duration, id_user,id_division) "
                    query += "VALUES('" + sample_requisition_number + "', '" + id_comp_contact_from + "',NOW(), '" + sample_requisition_note + "', '" + id_report_status + "', '" + sample_requisition_duration + "', '" + id_user + "','" + id_division + "'); SELECT LAST_INSERT_ID(); "

                    'Get Id 
                    id_sample_requisition = execute_query(query, 0, True, "", "", "", "")

                    'insert who prepared
                    increase_inc("9")
                    insert_who_prepared("11", id_sample_requisition, id_user)

                    'Detail return
                    For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Try
                            id_sample_requisition_det = GVRetDetail.GetRowCellValue(j, "id_sample_requisition_det").ToString
                            id_sample = GVRetDetail.GetRowCellValue(j, "id_sample").ToString
                            sample_requisition_det_qty = GVRetDetail.GetRowCellValue(j, "sample_requisition_det_qty").ToString
                            sample_requisition_det_note = GVRetDetail.GetRowCellValue(j, "sample_requisition_det_note").ToString
                            'id_comp = GVRetDetail.GetRowCellValue(j, "id_comp").ToString
                            'id_wh_drawer = GVRetDetail.GetRowCellValue(j, "id_wh_drawer").ToString
                            query = "INSERT tb_sample_requisition_det(id_sample_requisition, id_sample,sample_requisition_det_qty, sample_requisition_det_note) "
                            query += "VALUES('" + id_sample_requisition + "', '" + id_sample + "', '" + sample_requisition_det_qty + "', '" + sample_requisition_det_note + "') "
                            execute_non_query(query, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next
                    FormSampleReq.viewSampleReq()
                    FormSampleReq.GVReq.FocusedRowHandle = find_row(FormSampleReq.GVReq, "id_sample_requisition", id_sample_requisition)
                    action = "upd"
                    actionLoad()
                    infoCustom("Document #" + TxtReqNumber.Text.ToString + " was created successfully. ")
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                'edit main table
                query = "UPDATE tb_sample_requisition SET sample_requisition_number = '" + sample_requisition_number + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_report_status = '" + id_report_status + "', sample_requisition_note = '" + sample_requisition_note + "', sample_requisition_duration='" + sample_requisition_duration + "',id_division='" + id_division + "' WHERE id_sample_requisition = '" + id_sample_requisition + "' "
                execute_non_query(query, True, "", "", "", "")

                'edit detail table
                For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                    'Try
                    id_sample_requisition_det = GVRetDetail.GetRowCellValue(j, "id_sample_requisition_det").ToString
                    id_sample = GVRetDetail.GetRowCellValue(j, "id_sample").ToString
                    sample_requisition_det_qty = GVRetDetail.GetRowCellValue(j, "sample_requisition_det_qty").ToString
                    sample_requisition_det_note = GVRetDetail.GetRowCellValue(j, "sample_requisition_det_note").ToString
                    'id_comp = GVRetDetail.GetRowCellValue(j, "id_comp").ToString
                    'id_wh_drawer = GVRetDetail.GetRowCellValue(j, "id_wh_drawer").ToString
                    If id_sample_requisition_det = "0" Then
                        query = "INSERT tb_sample_requisition_det(id_sample_requisition, id_sample,sample_requisition_det_qty, sample_requisition_det_note) "
                        query += "VALUES('" + id_sample_requisition + "', '" + id_sample + "', '" + sample_requisition_det_qty + "', '" + sample_requisition_det_note + "') "
                        execute_non_query(query, True, "", "", "", "")
                    Else
                        query = "UPDATE tb_sample_requisition_det SET id_sample = '" + id_sample + "', sample_requisition_det_qty = '" + sample_requisition_det_qty + "', sample_requisition_det_note = '" + sample_requisition_det_note + "' WHERE id_sample_requisition_det = '" + id_sample_requisition_det + "'"
                        execute_non_query(query, True, "", "", "", "")
                        id_sample_requisition_det_list.Remove(id_sample_requisition_det)
                    End If
                    ' Catch ex As Exception

                    'End Try
                Next

                'delete sisa
                For k As Integer = 0 To (id_sample_requisition_det_list.Count - 1)
                    Try
                        query = "DELETE FROM tb_sample_requisition_det WHERE id_sample_requisition_det = '" + id_sample_requisition_det_list(k) + "' "
                        execute_non_query(query, True, "", "", "", "")
                    Catch ex As Exception

                    End Try
                Next

                'View
                FormSampleReq.viewSampleReq()
                FormSampleReq.GVReq.FocusedRowHandle = find_row(FormSampleReq.GVReq, "id_sample_requisition", id_sample_requisition)
                action = "upd"
                actionLoad()
                infoCustom("Document #" + TxtReqNumber.Text.ToString + " was edited successfully. ")
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnPopContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopContactTo.Click
        FormPopUpContact.id_pop_up = "11"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnPopContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopContactFrom.Click
        FormPopUpContact.id_pop_up = "12"
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnViewInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewInventory.Click
        FormMasterWH.Dispose()
        FormMasterWH.is_single = True
        FormMasterWH.XTPMasterWH.PageVisible = False
        FormMasterWH.Show()
    End Sub
    Private Sub BtnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfo.Click
        FormMasterWH.Dispose()
        FormMasterWH.is_single = True
        FormMasterWH.XTPMasterWH.PageVisible = False
        FormMasterWH.Show()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        '29 Jabuari 2016
        FormSampleReqList.id_pop_up = "1"
        FormSampleReqList.data_par = GCRetDetail.DataSource
        FormSampleReqList.ShowDialog()

        'old code
        'FormPopUpStorageSample.id_pop_up = "1"
        'FormPopUpStorageSample.action = "ins"
        'FormPopUpStorageSample.SLEWH.Enabled = False
        'FormPopUpStorageSample.SLELocator.Enabled = False
        'FormPopUpStorageSample.SLERack.Enabled = False
        'FormPopUpStorageSample.SLEDrawer.Enabled = False
        'FormPopUpStorageSample.BtnViewStock.Visible = False
        'FormPopUpStorageSample.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        'FormPopUpStorageSample.id_wh = id_comp_to
        'FormPopUpStorageSample.GridColumnQty.Visible = False
        FormPopUpStorageSample.id_sample_edit = GVRetDetail.GetFocusedRowCellDisplayText("id_sample").ToString
        'FormPopUpStorageSample.id_wh_drawer_edit = GVRetDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        FormPopUpStorageSample.id_pop_up = "1"
        FormPopUpStorageSample.action = "upd"
        FormPopUpStorageSample.SLEWH.Enabled = False
        FormPopUpStorageSample.SLELocator.Enabled = False
        FormPopUpStorageSample.SLERack.Enabled = False
        FormPopUpStorageSample.SLEDrawer.Enabled = False
        FormPopUpStorageSample.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", _
         MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_sample As String = GVRetDetail.GetFocusedRowCellDisplayText("id_sample").ToString
        deleteRows()
        CType(GCRetDetail.DataSource, DataTable).AcceptChanges()
        isManipulation()
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_requisition
        FormReportMark.report_mark_type = "11"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportSampleReq.id_sample_requisition = id_sample_requisition
        Dim Report As New ReportSampleReq()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
        GCRetDetail.RefreshDataSource()
        GVRetDetail.RefreshData()
    End Sub
    Sub isManipulation()
        Dim id_sample As String = ""
        Try
            id_sample = GVRetDetail.GetFocusedRowCellDisplayText("id_sample").ToString
        Catch ex As Exception
            id_sample = ""
        End Try
        If id_sample = "" Or GVRetDetail.RowCount = 0 Then
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            If check_edit_report_status(id_report_status, "11", id_sample_requisition) Or action = "ins" Then
                BtnEdit.Enabled = True
                BtnDel.Enabled = True
            End If
        End If
    End Sub

    Private Sub GVRetDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVRetDetail.RowClick
        isManipulation()
    End Sub

    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        isManipulation()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sample_requisition
        FormDocumentUpload.report_mark_type = "11"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub LESampleDivision_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles LESampleDivision.EditValueChanging
        If end_load = "1" Then
            Try
                If Not LESampleDivision.EditValue = Nothing Then
                    Dim confirm As DialogResult
                    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Changing division will reset the list, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        For i As Integer = 0 To GVRetDetail.RowCount - 1
                            GVRetDetail.DeleteRow(i)
                        Next
                    Else
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class