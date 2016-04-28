Public Class FormMatRetOutDet
    Public action As String
    Public id_mat_purc_ret_out As String
    Public id_mat_purc As String
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_mat_purc_det_list, id_mat_purc_ret_out_det_list, id_mat_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String

    Private Sub FormMatRetOutDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        actionLoad()
    End Sub

    Private Sub FormMatRetOutDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtRetOutNumber.Text = header_number_mat("5")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DERet.Text = view_date(0)
            viewDetailReturn()
        ElseIf action = "upd" Then
            'Enable/Disable
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True

            'View data
            Try
                Dim query As String = "SELECT a.id_report_status, a.id_mat_purc, a.id_mat_purc_ret_out, a.mat_purc_ret_out_date, "
                query += "a.mat_purc_ret_out_due_date, a.mat_purc_ret_out_note, a.mat_purc_ret_out_number,  "
                query += "b.mat_purc_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
                query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to "
                query += "FROM tb_mat_purc_ret_out a "
                query += "INNER JOIN tb_mat_purc b ON a.id_mat_purc = b.id_mat_purc "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "WHERE a.id_mat_purc_ret_out='" + id_mat_purc_ret_out + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtOrderNumber.Text = data.Rows(0)("mat_purc_number").ToString
                id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
                id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
                MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
                Dim start_date_arr() As String = data.Rows(0)("mat_purc_ret_out_date").ToString.Split(" ")
                DERet.Text = start_date_arr(0).ToString
                Dim start_due_date_arr() As String = data.Rows(0)("mat_purc_ret_out_due_date").ToString.Split(" ")
                DERetDueDate.Text = start_due_date_arr(0).ToString
                TxtRetOutNumber.Text = data.Rows(0)("mat_purc_ret_out_number").ToString
                MENote.Text = data.Rows(0)("mat_purc_ret_out_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                id_report_status = data.Rows(0)("id_report_status").ToString
                id_mat_purc = data.Rows(0)("id_mat_purc").ToString
            Catch ex As Exception
                errorConnection()
            End Try
            viewDetailReturn()
            check_but()
            allow_status()
        End If
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status, "18", id_mat_purc_ret_out) Then
            BtnBrowseContactFrom.Enabled = True
            GVRetDetail.OptionsBehavior.Editable = True
            BtnAdd.Enabled = True
            'BtnEdit.Enabled = True
            BtnDel.Enabled = True
            MENote.Properties.ReadOnly = False
            DERetDueDate.Enabled = True
            BtnSave.Enabled = True
        Else
            BtnBrowseContactFrom.Enabled = False
            GVRetDetail.OptionsBehavior.Editable = False
            BtnAdd.Enabled = False
            'BtnEdit.Enabled = False
            BtnDel.Enabled = False
            MENote.Properties.ReadOnly = True
            DERet.Properties.ReadOnly = True
            DERetDueDate.Enabled = False
            BtnSave.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub
    'sub check_but
    Sub check_but()
        'Constraint Status
        If GVRetDetail.RowCount > 0 Then
            'BtnEdit.Visible = True
            BtnDel.Visible = True
        Else
            'BtnEdit.Visible = False
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
        If action = "ins" Then
            Dim query As String = "CALL view_return_out_mat('" + id_mat_purc_ret_out + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetDetail.DataSource = data
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_return_out_mat('" + id_mat_purc_ret_out + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_mat_purc_det_list.Add(data.Rows(i)("id_mat_purc_det").ToString)
                id_mat_det_list.Add(data.Rows(i)("id_mat_det").ToString)
                id_mat_purc_ret_out_det_list.Add(data.Rows(i)("id_mat_purc_ret_out_det").ToString)
            Next
            GCRetDetail.DataSource = data
        End If
        check_but()
    End Sub
    'Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        'Cek isi qty
        Dim cond_qty As Boolean = True
        Dim qty As String
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            qty = GVRetDetail.GetRowCellValue(i, "mat_purc_ret_out_det_qty").ToString
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
            Dim mat_purc_ret_out_number As String = addSlashes(TxtRetOutNumber.Text)
            Dim mat_purc_ret_out_due_date_format As Date = CType(DERetDueDate.Text, Date)
            Dim mat_purc_ret_out_due_date As String = mat_purc_ret_out_due_date_format.ToString("yyyy-MM-dd")
            Dim mat_purc_ret_out_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_sample_purc_det, sample_purc_ret_out_det_qty, sample_purc_ret_out_det_note As String
            Dim id_sample_purc_ret_out_det As String
            If action = "ins" Then
                Try
                    'Main tbale
                    query = "INSERT INTO tb_mat_purc_ret_out(id_mat_purc, mat_purc_ret_out_number, id_comp_contact_to, id_comp_contact_from, mat_purc_ret_out_date, mat_purc_ret_out_due_date, mat_purc_ret_out_note, id_report_status) "
                    query += "VALUES('" + id_mat_purc + "', '" + mat_purc_ret_out_number + "', '" + id_comp_contact_to + "', '" + id_comp_contact_from + "', NOW(), '" + mat_purc_ret_out_due_date + "', '" + mat_purc_ret_out_note + "', '" + id_report_status + "');SELECT LAST_INSERT_ID(); "
                    id_mat_purc_ret_out = execute_query(query, 0, True, "", "", "", "")

                    increase_inc_mat("5")
                    'insert who prepared
                    insert_who_prepared("18", id_mat_purc_ret_out, id_user)

                    'Detail return
                    For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Try
                            id_sample_purc_det = GVRetDetail.GetRowCellValue(j, "id_mat_purc_det").ToString
                            sample_purc_ret_out_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "mat_purc_ret_out_det_qty").ToString)
                            sample_purc_ret_out_det_note = GVRetDetail.GetRowCellValue(j, "mat_purc_ret_out_det_note").ToString
                            query = "INSERT tb_mat_purc_ret_out_det(id_mat_purc_ret_out, id_mat_purc_det, mat_purc_ret_out_det_qty, mat_purc_ret_out_det_note,id_wh_drawer,price) "
                            query += "VALUES('" + id_mat_purc_ret_out + "', '" + id_sample_purc_det + "', '" + sample_purc_ret_out_det_qty + "', '" + sample_purc_ret_out_det_note + "','" + GVRetDetail.GetRowCellValue(j, "id_wh_drawer").ToString + "','" + decimalSQL(GVRetDetail.GetRowCellValue(j, "price").ToString) + "') "
                            execute_non_query(query, True, "", "", "", "")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Next
                    FormMatRet.viewRetOut()
                    FormMatRet.GVRetOut.FocusedRowHandle = find_row(FormMatRet.GVRetOut, "id_mat_purc_ret_out", id_mat_purc_ret_out)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    'edit main table
                    query = "UPDATE tb_mat_purc_ret_out SET id_mat_purc = '" + id_mat_purc + "', mat_purc_ret_out_number = '" + mat_purc_ret_out_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', mat_purc_ret_out_date = NOW(), mat_purc_ret_out_due_date = '" + mat_purc_ret_out_due_date + "', mat_purc_ret_out_due_date = '" + mat_purc_ret_out_due_date + "', id_report_status = '" + id_report_status + "', mat_purc_ret_out_note = '" + mat_purc_ret_out_note + "' WHERE id_mat_purc_ret_out = '" + id_mat_purc_ret_out + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'edit detail table
                    For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Try
                            id_sample_purc_ret_out_det = GVRetDetail.GetRowCellValue(j, "id_mat_purc_ret_out_det").ToString
                            id_sample_purc_det = GVRetDetail.GetRowCellValue(j, "id_mat_purc_det").ToString
                            sample_purc_ret_out_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "mat_purc_ret_out_det_qty").ToString)
                            sample_purc_ret_out_det_note = GVRetDetail.GetRowCellValue(j, "mat_purc_ret_out_det_note").ToString
                            If id_sample_purc_ret_out_det = "0" Then
                                query = "INSERT tb_mat_purc_ret_out_det(id_mat_purc_ret_out, id_mat_purc_det, mat_purc_ret_out_det_qty, mat_purc_ret_out_det_note,price) "
                                query += "VALUES('" + id_mat_purc_ret_out + "', '" + id_sample_purc_det + "', '" + sample_purc_ret_out_det_qty + "', '" + sample_purc_ret_out_det_note + "','" + decimalSQL(GVRetDetail.GetRowCellValue(j, "price").ToString) + "') "
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                query = "UPDATE tb_mat_purc_ret_out_det SET id_mat_purc_det = '" + id_sample_purc_det + "', mat_purc_ret_out_det_qty = '" + sample_purc_ret_out_det_qty + "', mat_purc_ret_out_det_note = '" + sample_purc_ret_out_det_note + "',price='" + decimalSQL(GVRetDetail.GetRowCellValue(j, "price").ToString) + "' WHERE id_mat_purc_ret_out_det = '" + id_sample_purc_ret_out_det + "'"
                                execute_non_query(query, True, "", "", "", "")
                                id_mat_purc_ret_out_det_list.Remove(id_sample_purc_ret_out_det)
                            End If
                        Catch ex As Exception
                            ex.ToString()
                        End Try
                    Next

                    'delete sisa
                    For k As Integer = 0 To (id_mat_purc_ret_out_det_list.Count - 1)
                        Try
                            query = "DELETE FROM tb_mat_purc_ret_out_det WHERE id_mat_purc_ret_out_det = '" + id_mat_purc_ret_out_det_list(k) + "' "
                            execute_non_query(query, True, "", "", "", "")
                        Catch ex As Exception
                            ex.ToString()
                        End Try
                    Next

                    'View
                    FormMatRet.viewRetOut()
                    FormMatRet.GVRetOut.FocusedRowHandle = find_row(FormMatRet.GVRetOut, "id_mat_purc_ret_out", id_mat_purc_ret_out)
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
        FormPopUpPurchaseMat.id_pop_up = "2"
        FormPopUpPurchaseMat.ShowDialog()
    End Sub
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "21"
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpPurchaseMatDet.id_pop_up = "1"
        FormPopUpPurchaseMatDet.action = "ins"
        FormPopUpPurchaseMatDet.id_mat_purc = id_mat_purc
        FormPopUpPurchaseMatDet.ShowDialog()
        'FormPopUpStorageMat.id_pop_up = "3"
        'FormPopUpStorageMat.ShowDialog()
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_mat_purc_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString
        id_mat_purc_det_list.Remove(id_mat_purc_det)
        deleteRows()
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'FormPopUpPurchaseMatDet.id_pop_up = "1"
        'FormPopUpPurchaseMatDet.action = "upd"
        'FormPopUpPurchaseMatDet.id_mat_purc = id_mat_purc
        'FormPopUpPurchaseMatDet.ShowDialog()
        'with stock
        'FormPopUpStorageMat.id_pop_up = "1"
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportMatRetOut.id_mat_purc_ret_out = id_mat_purc_ret_out
        Dim Report As New ReportMatRetOut()
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
        EPRet.SetIconPadding(TxtNameCompFrom, 28)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompTo)
    End Sub
    Private Sub DERet_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        EP_DE_cant_blank(EPRet, DERet)
    End Sub
    Private Sub DERetDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DERetDueDate.Validating
        EP_DE_cant_blank(EPRet, DERetDueDate)
    End Sub
    Private Sub DERet_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim dt_str As String = DERet.Text
            date_start = Date.Parse(DERet.Text)
            DERetDueDate.Properties.MinValue = date_start
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
        FormReportMark.id_report = id_mat_purc_ret_out
        FormReportMark.report_mark_type = "18"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemButtonEdit1.Click
        If GVRetDetail.RowCount > 0 Then
            FormPopUpStorageMat.id_pop_up = "3"
            FormPopUpStorageMat.id_mat_ada = GVRetDetail.GetFocusedRowCellValue("id_mat_det").ToString
            FormPopUpStorageMat.ShowDialog()
        End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mat_purc_ret_out
        FormDocumentUpload.report_mark_type = "18"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class