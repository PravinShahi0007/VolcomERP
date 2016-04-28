Public Class FormSampleRetInSingle 

    Public action As String
    Public id_sample_purc_ret_in As String
    Public id_sample_purc As String
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_sample_purc_det_list, id_sample_purc_ret_in_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String

    'Load Form
    Private Sub FormSampleRetOutSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        actionLoad()
    End Sub
    Sub actionLoad()
        If action = "ins" Then
            TxtRetOutNumber.Text = header_number("7")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DERet.Text = view_date(0)
        ElseIf action = "upd" Then
            'Enable/Disable
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True

            'View data
            Try
                Dim query As String = "SELECT a.id_report_status, a.id_sample_purc, a.id_sample_purc_ret_in, a.sample_purc_ret_in_date, "
                query += "a.sample_purc_ret_in_note, a.sample_purc_ret_in_number,  "
                query += "b.sample_purc_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
                query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to "
                query += "FROM tb_sample_purc_ret_in a "
                query += "INNER JOIN tb_sample_purc b ON a.id_sample_purc = b.id_sample_purc "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "WHERE a.id_sample_purc_ret_in='" + id_sample_purc_ret_in + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtOrderNumber.Text = data.Rows(0)("sample_purc_number").ToString
                id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
                id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
                MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
                Dim start_date_arr() As String = data.Rows(0)("sample_purc_ret_in_date").ToString.Split(" ")
                DERet.Text = start_date_arr(0).ToString
                'Dim start_due_date_arr() As String = data.Rows(0)("sample_purc_ret_in_due_date").ToString.Split(" ")
                ' DERetDueDate.Text = start_due_date_arr(0).ToString
                TxtRetOutNumber.Text = data.Rows(0)("sample_purc_ret_in_number").ToString
                MENote.Text = data.Rows(0)("sample_purc_ret_in_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                id_report_status = data.Rows(0)("id_report_status").ToString
                id_sample_purc = data.Rows(0)("id_sample_purc").ToString

                'Constraint Status
                If id_report_status = "3" Or id_report_status = "4" Or id_report_status = "6" Or id_report_status = "7" Then  'app
                    BtnPrint.Enabled = True
                    BtnBrowseContactFrom.Enabled = False
                    GVRetDetail.OptionsBehavior.Editable = False
                    BtnAdd.Enabled = False
                    BtnEdit.Enabled = False
                    BtnDel.Enabled = False
                    MENote.Properties.ReadOnly = True
                    DERet.Properties.ReadOnly = True
                    'DERetDueDate.Properties.ReadOnly = True
                ElseIf id_report_status = "5" Then 'cancel
                    BtnPrint.Enabled = False
                    BtnPrint.Enabled = True
                    BtnBrowseContactFrom.Enabled = False
                    GVRetDetail.OptionsBehavior.Editable = False
                    BtnAdd.Enabled = False
                    BtnEdit.Enabled = False
                    BtnDel.Enabled = False
                    MENote.Properties.ReadOnly = True
                    DERet.Properties.ReadOnly = True
                    'DERetDueDate.Properties.ReadOnly = True
                Else
                    BtnPrint.Enabled = False
                    BtnBrowseContactFrom.Enabled = True
                    GVRetDetail.OptionsBehavior.Editable = True
                    BtnAdd.Enabled = True
                    BtnEdit.Enabled = True
                    BtnDel.Enabled = True
                    MENote.Properties.ReadOnly = False
                    DERet.Properties.ReadOnly = False
                    'DERetDueDate.Properties.ReadOnly = True
                End If
            Catch ex As Exception
                errorConnection()
            End Try
            viewDetailReturn()
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
            Dim query As String = "SELECT ('0') AS id_sample_purc_ret_in_det, "
            query += "('0') AS id_sample_purc_det, "
            query += "('0') AS no, "
            query += "('0') AS name, "
            query += "('0') AS size, "
            query += "('0') AS uom, "
            query += "('0') AS sample_purc_ret_in_det_qty, "
            query += "('0') AS sample_purc_ret_in_det_note "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetDetail.DataSource = data
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_return_in_sample('" + id_sample_purc_ret_in + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sample_purc_det_list.Add(data.Rows(i)("id_sample_purc_det").ToString)
                'MsgBox(data.Rows(i)("id_sample_purc_det").ToString)
                id_sample_purc_ret_in_det_list.Add(data.Rows(i)("id_sample_purc_ret_in_det").ToString)
            Next
            GCRetDetail.DataSource = data
        End If
    End Sub
    'Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        'Cek isi qty
        Dim cond_qty As Boolean = True
        Dim qty As String
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            qty = GVRetDetail.GetRowCellValue(i, "sample_purc_ret_in_det_qty").ToString
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
            Dim sample_purc_ret_in_number As String = addSlashes(TxtRetOutNumber.Text)
            Dim sample_purc_ret_in_date_format As Date = CType(DERet.Text, Date)
            Dim sample_purc_ret_in_date As String = sample_purc_ret_in_date_format.ToString("yyyy-MM-dd")
            'Dim sample_purc_ret_in_due_date_format As Date = CType(DERetDueDate.Text, Date)
            'Dim sample_purc_ret_in_due_date As String = sample_purc_ret_in_due_date_format.ToString("yyyy-MM-dd")
            Dim sample_purc_ret_in_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_sample_purc_det, sample_purc_ret_in_det_qty, sample_purc_ret_in_det_note As String
            Dim id_sample_purc_ret_in_det As String
            If action = "ins" Then
                Try
                    'Main tbale
                    query = "INSERT INTO tb_sample_purc_ret_in(id_sample_purc, sample_purc_ret_in_number, id_comp_contact_to, id_comp_contact_from, sample_purc_ret_in_date, sample_purc_ret_in_note, id_report_status) "
                    query += "VALUES('" + id_sample_purc + "', '" + sample_purc_ret_in_number + "', '" + id_comp_contact_to + "', '" + id_comp_contact_from + "', '" + sample_purc_ret_in_date + "', '" + sample_purc_ret_in_note + "', '" + id_report_status + "');SELECT LAST_INSERT_ID(); "
                    id_sample_purc_ret_in = execute_query(query, 0, True, "", "", "", "")

                    increase_inc("7")



                    'insert who prepared
                    insert_who_prepared("6", id_sample_purc_ret_in, id_user)

                    'Detail return
                    For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Try
                            id_sample_purc_det = GVRetDetail.GetRowCellValue(j, "id_sample_purc_det").ToString
                            sample_purc_ret_in_det_qty = GVRetDetail.GetRowCellValue(j, "sample_purc_ret_in_det_qty").ToString
                            sample_purc_ret_in_det_note = GVRetDetail.GetRowCellValue(j, "sample_purc_ret_in_det_note").ToString
                            query = "INSERT tb_sample_purc_ret_in_det(id_sample_purc_ret_in, id_sample_purc_det, sample_purc_ret_in_det_qty, sample_purc_ret_in_det_note) "
                            query += "VALUES('" + id_sample_purc_ret_in + "', '" + id_sample_purc_det + "', '" + sample_purc_ret_in_det_qty + "', '" + sample_purc_ret_in_det_note + "') "
                            execute_non_query(query, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next
                    FormSampleRet.viewRetIn()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    'edit main table
                    query = "UPDATE tb_sample_purc_ret_in SET id_sample_purc = '" + id_sample_purc + "', sample_purc_ret_in_number = '" + sample_purc_ret_in_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', sample_purc_ret_in_date = '" + sample_purc_ret_in_date + "', id_report_status = '" + id_report_status + "', sample_purc_ret_in_note = '" + sample_purc_ret_in_note + "' WHERE id_sample_purc_ret_in = '" + id_sample_purc_ret_in + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'edit detail table
                    For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                        Try
                            id_sample_purc_ret_in_det = GVRetDetail.GetRowCellValue(j, "id_sample_purc_ret_in_det").ToString
                            id_sample_purc_det = GVRetDetail.GetRowCellValue(j, "id_sample_purc_det").ToString
                            sample_purc_ret_in_det_qty = GVRetDetail.GetRowCellValue(j, "sample_purc_ret_in_det_qty").ToString
                            sample_purc_ret_in_det_note = GVRetDetail.GetRowCellValue(j, "sample_purc_ret_in_det_note").ToString
                            If id_sample_purc_ret_in_det = "0" Then
                                query = "INSERT tb_sample_purc_ret_in_det(id_sample_purc_ret_in, id_sample_purc_det, sample_purc_ret_in_det_qty, sample_purc_ret_in_det_note) "
                                query += "VALUES('" + id_sample_purc_ret_in + "', '" + id_sample_purc_det + "', '" + sample_purc_ret_in_det_qty + "', '" + sample_purc_ret_in_det_note + "') "
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                query = "UPDATE tb_sample_purc_ret_in_det SET id_sample_purc_det = '" + id_sample_purc_det + "', sample_purc_ret_in_det_qty = '" + sample_purc_ret_in_det_qty + "', sample_purc_ret_in_det_note = '" + sample_purc_ret_in_det_note + "' WHERE id_sample_purc_ret_in_det = '" + id_sample_purc_ret_in_det + "'"
                                execute_non_query(query, True, "", "", "", "")
                                id_sample_purc_ret_in_det_list.Remove(id_sample_purc_ret_in_det)
                            End If
                        Catch ex As Exception

                        End Try
                    Next

                    'delete sisa
                    For k As Integer = 0 To (id_sample_purc_ret_in_det_list.Count - 1)
                        Try
                            query = "DELETE FROM tb_sample_purc_ret_in_det WHERE id_sample_purc_ret_in_det = '" + id_sample_purc_ret_in_det_list(k) + "' "
                            execute_non_query(query, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next

                    'View
                    FormSampleRet.viewRetIn()
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
    Private Sub FormSampleRetOutSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub BtnBrowsePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowsePO.Click
        FormPopUpPurchase.id_pop_up = "4"
        FormPopUpPurchase.ShowDialog()
    End Sub
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "8"
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpPurchaseDetail.id_pop_up = "2"
        FormPopUpPurchaseDetail.action = "ins"
        FormPopUpPurchaseDetail.id_sample_purc = id_sample_purc
        FormPopUpPurchaseDetail.ShowDialog()
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", _
         MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_sample_purc_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
        id_sample_purc_det_list.Remove(id_sample_purc_det)
        deleteRows()
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormPopUpPurchaseDetail.id_pop_up = "2"
        FormPopUpPurchaseDetail.action = "upd"
        FormPopUpPurchaseDetail.id_sample_purc = id_sample_purc
        FormPopUpPurchaseDetail.ShowDialog()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportSampleReturnIn.id_sample_purc_ret_in = id_sample_purc_ret_in
        Dim Report As New ReportSampleReturnIn()
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
    Private Sub DERet_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DERet.Validating
        EP_DE_cant_blank(EPRet, DERet)
    End Sub
    'Private Sub DERetDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DERetDueDate.Validating
    '    'EP_DE_cant_blank(EPRet, DERetDueDate)
    'End Sub
    Private Sub DERet_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DERet.EditValueChanged
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
        FormReportMark.id_report = id_sample_purc_ret_in
        FormReportMark.report_mark_type = "6"
        FormReportMark.ShowDialog()
    End Sub
End Class