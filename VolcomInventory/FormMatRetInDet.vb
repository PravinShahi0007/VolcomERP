Public Class FormMatRetInDet
    Public action As String
    Public id_mat_purc_ret_in As String
    Public id_mat_purc As String
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_mat_purc_det_list, id_mat_purc_ret_in_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String
    Private Sub FormMatRetInDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        viewComp()
        actionLoad()
    End Sub
    Sub actionLoad()
        If action = "ins" Then
            TxtRetOutNumber.Text = header_number_mat("6")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BAttach.Enabled = False
            DERet.Text = view_date(0)
        ElseIf action = "upd" Then
            'Enable/Disable
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True

            'View data
            Try
                Dim query As String = "SELECT a.id_report_status, a.id_mat_purc, a.id_mat_purc_ret_in, a.mat_purc_ret_in_date, "
                query += "a.mat_purc_ret_in_note, a.mat_purc_ret_in_number,  "
                query += "b.mat_purc_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
                query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to "
                query += ",drw.id_wh_drawer,rck.id_wh_rack,loc.id_wh_locator,comp.id_comp "
                query += "FROM tb_mat_purc_ret_in a "
                query += "INNER JOIN tb_mat_purc b ON a.id_mat_purc = b.id_mat_purc "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
                query += "LEFT JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
                query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
                query += "LEFT JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
                query += "WHERE a.id_mat_purc_ret_in='" + id_mat_purc_ret_in + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Try
                    SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
                    SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
                    SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
                    SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
                Catch ex As Exception
                End Try

                TxtOrderNumber.Text = data.Rows(0)("mat_purc_number").ToString
                id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
                id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
                MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
                Dim start_date_arr() As String = data.Rows(0)("mat_purc_ret_in_date").ToString.Split(" ")
                DERet.Text = start_date_arr(0).ToString
                TxtRetOutNumber.Text = data.Rows(0)("mat_purc_ret_in_number").ToString
                MENote.Text = data.Rows(0)("mat_purc_ret_in_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                id_report_status = data.Rows(0)("id_report_status").ToString
                id_mat_purc = data.Rows(0)("id_mat_purc").ToString

                'Constraint Status
            Catch ex As Exception
                errorConnection()
            End Try
            viewDetailReturn()
            check_but()
            allow_status()
        End If
    End Sub
    'view company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
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
    Sub allow_status()
        If check_edit_report_status(id_report_status, "19", id_mat_purc_ret_in) Then
            BtnBrowseContactFrom.Enabled = True
            GVRetDetail.OptionsBehavior.Editable = True
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            '
            SLEDrawer.Enabled = True
            SLERack.Enabled = True
            SLELocator.Enabled = True
            SLEStorage.Enabled = True
        Else
            BtnBrowseContactFrom.Enabled = False
            GVRetDetail.OptionsBehavior.Editable = False
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            MENote.Properties.ReadOnly = True
            DERet.Properties.ReadOnly = True
            BtnSave.Enabled = False
            '
            SLEDrawer.Enabled = False
            SLERack.Enabled = False
            SLELocator.Enabled = False
            SLEStorage.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub
    Sub check_but()
        If GVRetDetail.RowCount > 0 Then
            BtnEdit.Visible = True
            BtnDel.Visible = True
        Else
            BtnEdit.Visible = False
            BtnDel.Visible = False
        End If
    End Sub
    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    Sub viewDetailReturn()
        Dim query As String = "CALL view_return_in_mat('" + id_mat_purc_ret_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_mat_purc_det_list.Add(data.Rows(i)("id_mat_purc_det").ToString)
            id_mat_purc_ret_in_det_list.Add(data.Rows(i)("id_mat_purc_ret_in_det").ToString)
        Next
        GCRetDetail.DataSource = data
    End Sub
    'Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        'Cek isi qty
        Dim cond_qty As Boolean = True
        Dim qty As String
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            qty = GVRetDetail.GetRowCellValue(i, "mat_purc_ret_in_det_qty").ToString
            If qty = "" Or qty = "0" Or qty Is Nothing Then
                cond_qty = False
            End If
        Next
        If Not formIsValidInGroup(EPRet, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_qty Or GVRetDetail.RowCount = 0 Then
            errorCustom("Qty can't blank or zero value !")
        Else
            Dim query As String
            Dim mat_purc_ret_in_number As String = addSlashes(TxtRetOutNumber.Text)
            Dim mat_purc_ret_in_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_wh_drawer As String = SLEDrawer.EditValue.ToString
            Dim id_mat_purc_det, mat_purc_ret_in_det_qty, mat_purc_ret_in_det_note As String
            Dim id_mat_purc_ret_in_det As String
            If action = "ins" Then
                Try
                    'Main tbale
                    query = "INSERT INTO tb_mat_purc_ret_in(id_mat_purc, mat_purc_ret_in_number, id_comp_contact_to, id_comp_contact_from, mat_purc_ret_in_date, mat_purc_ret_in_note, id_report_status,id_wh_drawer) "
                    query += "VALUES('" + id_mat_purc + "', '" + mat_purc_ret_in_number + "', '" + id_comp_contact_to + "', '" + id_comp_contact_from + "', NOW(), '" + mat_purc_ret_in_note + "', '" + id_report_status + "','" + id_wh_drawer + "'); SELECT LAST_INSERT_ID() "
                    id_mat_purc_ret_in = execute_query(query, 0, True, "", "", "", "")
                    increase_inc_mat("6")

                    'insert who prepared
                    insert_who_prepared("19", id_mat_purc_ret_in, id_user)

                    'Detail return
                    For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Try
                            id_mat_purc_det = GVRetDetail.GetRowCellValue(j, "id_mat_purc_det").ToString
                            mat_purc_ret_in_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "mat_purc_ret_in_det_qty").ToString)
                            mat_purc_ret_in_det_note = GVRetDetail.GetRowCellValue(j, "mat_purc_ret_in_det_note").ToString
                            query = "INSERT tb_mat_purc_ret_in_det(id_mat_purc_ret_in, id_mat_purc_det, mat_purc_ret_in_det_qty, mat_purc_ret_in_det_note) "
                            query += "VALUES('" + id_mat_purc_ret_in + "', '" + id_mat_purc_det + "', '" + mat_purc_ret_in_det_qty + "', '" + mat_purc_ret_in_det_note + "') "
                            execute_non_query(query, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next
                    FormMatRet.viewRetIn()
                    FormMatRet.GVRetIn.FocusedRowHandle = find_row(FormMatRet.GVRetIn, "id_mat_purc_ret_in", id_mat_purc_ret_in)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    'edit main table
                    query = "UPDATE tb_mat_purc_ret_in SET id_mat_purc = '" + id_mat_purc + "', mat_purc_ret_in_number = '" + mat_purc_ret_in_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_report_status = '" + id_report_status + "', mat_purc_ret_in_note = '" + mat_purc_ret_in_note + "',id_wh_drawer='" + id_wh_drawer + "' WHERE id_mat_purc_ret_in = '" + id_mat_purc_ret_in + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'edit detail table
                    For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Try
                            id_mat_purc_ret_in_det = GVRetDetail.GetRowCellValue(j, "id_mat_purc_ret_in_det").ToString
                            id_mat_purc_det = GVRetDetail.GetRowCellValue(j, "id_mat_purc_det").ToString
                            mat_purc_ret_in_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "mat_purc_ret_in_det_qty").ToString)
                            mat_purc_ret_in_det_note = GVRetDetail.GetRowCellValue(j, "mat_purc_ret_in_det_note").ToString
                            If id_mat_purc_ret_in_det = "0" Then
                                query = "INSERT tb_mat_purc_ret_in_det(id_mat_purc_ret_in, id_mat_purc_det, mat_purc_ret_in_det_qty, mat_purc_ret_in_det_note) "
                                query += "VALUES('" + id_mat_purc_ret_in + "', '" + id_mat_purc_det + "', '" + mat_purc_ret_in_det_qty + "', '" + mat_purc_ret_in_det_note + "') "
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                query = "UPDATE tb_mat_purc_ret_in_det SET id_mat_purc_det = '" + id_mat_purc_det + "', mat_purc_ret_in_det_qty = '" + mat_purc_ret_in_det_qty + "', mat_purc_ret_in_det_note = '" + mat_purc_ret_in_det_note + "' WHERE id_mat_purc_ret_in_det = '" + id_mat_purc_ret_in_det + "'"
                                execute_non_query(query, True, "", "", "", "")
                                id_mat_purc_ret_in_det_list.Remove(id_mat_purc_ret_in_det)
                            End If
                        Catch ex As Exception

                        End Try
                    Next

                    'delete sisa
                    For k As Integer = 0 To (id_mat_purc_ret_in_det_list.Count - 1)
                        Try
                            query = "DELETE FROM tb_mat_purc_ret_in_det WHERE id_mat_purc_ret_in_det = '" + id_mat_purc_ret_in_det_list(k) + "' "
                            execute_non_query(query, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next
                    'View
                    FormMatRet.viewRetIn()
                    FormMatRet.GVRetIn.FocusedRowHandle = find_row(FormMatRet.GVRetIn, "id_mat_purc_ret_in", id_mat_purc_ret_in)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub BtnBrowsePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowsePO.Click
        FormPopUpPurchaseMat.id_pop_up = "4"
        FormPopUpPurchaseMat.ShowDialog()
    End Sub
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "23"
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpPurchaseMatDet.id_pop_up = "2"
        FormPopUpPurchaseMatDet.action = "ins"
        FormPopUpPurchaseMatDet.id_mat_purc = id_mat_purc
        FormPopUpPurchaseMatDet.ShowDialog()
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_mat_purc_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString
        id_mat_purc_det_list.Remove(id_mat_purc_det)
        deleteRows()
        check_but()
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormPopUpPurchaseMatDet.id_pop_up = "2"
        FormPopUpPurchaseMatDet.action = "upd"
        FormPopUpPurchaseMatDet.id_mat_purc = id_mat_purc
        FormPopUpPurchaseMatDet.ShowDialog()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportMatRetIn.id_mat_purc_ret_in = id_mat_purc_ret_in
        Dim Report As New ReportMatRetIn()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
    'Validating
    Private Sub TxtOrderNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOrderNumber.Validating
        EP_TE_cant_blank(EPRet, TxtOrderNumber)
        EPRet.SetIconPadding(TxtOrderNumber, 28)
    End Sub
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompFrom)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompTo)
        EPRet.SetIconPadding(TxtNameCompTo, 28)
    End Sub
    Private Sub DERet_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        EP_DE_cant_blank(EPRet, DERet)
    End Sub
    Private Sub DERet_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim dt_str As String = DERet.Text
            date_start = Date.Parse(DERet.Text)
            'DERetDueDate.Properties.MinValue = date_start
        Catch ex As Exception

        End Try
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
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mat_purc_ret_in
        FormReportMark.report_mark_type = "19"
        FormReportMark.ShowDialog()
    End Sub
    Private Sub FormMatRetInDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mat_purc_ret_in
        FormDocumentUpload.report_mark_type = "19"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class