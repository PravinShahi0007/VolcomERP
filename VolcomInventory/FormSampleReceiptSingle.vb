Public Class FormSampleReceiptSingle
    Public action As String
    Public id_receipt_sample As String
    Public id_comp_contact_from As String
    Public id_comp_contact_to As String
    Public id_pl_sample_purc As String
    Dim cond_new As Boolean = False
    Dim cond_del As Boolean = False
    Dim code_list As New List(Of String)
    Dim test_old As String
    Public id_report_status_rec As String

    'Form Load
    Private Sub FormSampleReceiptSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 2000
        viewReportStatus()
        actionLoad()
        'code_list.Add("a")
        'code_list.Add("b")
        'code_list.Add("c")
    End Sub
    'Action Load
    Sub actionLoad()
        If action = "ins" Then
            DEReceipt.Text = view_date(0)
            TxtReceiptNumber.Text = header_number("5")
            BtnPrint.Enabled = False
            BStored.Enabled = False
            GridColumnLocator.Visible = False
            BMark.Enabled = False
            id_report_status_rec = "1"
        ElseIf action = "upd" Then
            Try
                'Enabled/disable form
                BtnBrowse.Enabled = False
                BtnPrint.Enabled = True
                TxtReceiptNumber.Properties.ReadOnly = True

                'Fetch from db main
                Dim query As String = "SELECT a.id_pl_sample_purc, a2.id_sample_purc_rec,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_purc_date, a.pl_sample_purc_note, a.pl_sample_purc_number, g.sample_purc_rec_number,b.pl_category, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from,(f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to,(f.address_primary) AS comp_address_to, a.id_pl_category, a.id_report_status, g.sample_purc_rec_number, "
                query += "a.receipt_sample_date, a.receipt_sample_note, a.receipt_sample_number, a.id_report_status_rec, b.pl_category "
                query += "FROM tb_pl_sample_purc a "
                query += "INNER JOIN tb_pl_sample_purc_rec a2 ON a.id_pl_sample_purc = a2.id_pl_sample_purc "
                query += "INNER JOIN tb_lookup_pl_category b ON a.id_pl_category = b.id_pl_category  "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "INNER JOIN tb_sample_purc_rec g ON g.id_sample_purc_rec = a2.id_sample_purc_rec "
                query += "WHERE a.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtPLCategory.Text = data.Rows(0)("pl_category").ToString
                TxtReceiptNumber.Text = data.Rows(0)("receipt_sample_number").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
                'MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
                TxtPLNumber.Text = data.Rows(0)("pl_sample_purc_number").ToString
                Dim start_date_arr() As String = data.Rows(0)("receipt_sample_date").ToString.Split(" ")
                DEReceipt.Text = start_date_arr(0)
                'LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)
                MENote.Text = data.Rows(0)("receipt_sample_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status_rec").ToString)

                'Constraint Status
                id_report_status_rec = data.Rows(0)("id_report_status_rec").ToString
                If id_report_status_rec = "6" Or id_report_status_rec = "7" Then 'Completed
                    BAdd.Enabled = False
                    Bdel.Enabled = False
                    BStored.Enabled = False
                    BtnSave.Enabled = False
                    GridColumnLocator.Visible = True
                    DEReceipt.Properties.ReadOnly = True
                    MENote.Properties.ReadOnly = True
                    GVSummary.OptionsBehavior.Editable = False
                    GVDetail.OptionsBehavior.Editable = False
                    BMark.Enabled = False
                ElseIf id_report_status_rec = "3" Or id_report_status_rec = "4" Then ' Approved
                    BAdd.Enabled = False
                    Bdel.Enabled = False
                    BStored.Enabled = True
                    GridColumnLocator.Visible = True
                    MENote.Properties.ReadOnly = True
                    GVSummary.OptionsBehavior.Editable = False
                    GVDetail.OptionsBehavior.Editable = False
                ElseIf id_report_status_rec = "5" Then
                    BAdd.Enabled = False
                    Bdel.Enabled = False
                    BStored.Enabled = False
                    BtnSave.Enabled = False
                    GridColumnLocator.Visible = False
                    DEReceipt.Properties.ReadOnly = True
                    MENote.Properties.ReadOnly = True
                    GVSummary.OptionsBehavior.Editable = False
                    GVDetail.OptionsBehavior.Editable = False
                    BtnPrint.Enabled = False
                    BtnSave.Enabled = False
                Else
                    If check_edit_report_status(id_report_status_rec, "3", id_pl_sample_purc) Then
                        BtnPrint.Enabled = False
                        BStored.Enabled = False
                        GridColumnLocator.Visible = False
                        BAdd.Enabled = True
                        Bdel.Enabled = True
                        BStored.Enabled = False
                        BtnSave.Enabled = True
                        GridColumnLocator.Visible = False
                        DEReceipt.Properties.ReadOnly = True
                        MENote.Properties.ReadOnly = False
                        GVSummary.OptionsBehavior.Editable = True
                        GVDetail.OptionsBehavior.Editable = True
                        BMark.Enabled = True
                    Else
                        BAdd.Enabled = False
                        Bdel.Enabled = False
                        BStored.Enabled = False
                        BtnSave.Enabled = False
                        GridColumnLocator.Visible = True
                        DEReceipt.Properties.ReadOnly = True
                        MENote.Properties.ReadOnly = True
                        GVSummary.OptionsBehavior.Editable = False
                        GVDetail.OptionsBehavior.Editable = False
                        BMark.Enabled = True
                    End If
                End If

                'Fetch db detail
                viewDetailPL()
            Catch ex As Exception
                errorCustom(ex.ToString)
                'Close()
            End Try
        End If
    End Sub
    'Validating
    Private Sub TxtPLNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPLNumber.Validating
        EP_TE_cant_blank(EPReceipt, TxtPLNumber)
        EPReceipt.SetIconPadding(TxtPLNumber, 27)
    End Sub
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPReceipt, TxtNameCompFrom)
    End Sub
    Private Sub DEReceipt_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEReceipt.Validating
        EP_DE_cant_blank(EPReceipt, DEReceipt)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPReceipt, TxtNameCompTo)
    End Sub
    Private Sub TxtReceiptNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtReceiptNumber.Validating
        EP_TE_cant_blank(EPReceipt, TxtReceiptNumber)
    End Sub
    'Browse Popup
    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        FormPopUpPL.id_pop_up = "1"
        FormPopUpPL.ShowDialog()
    End Sub
    'View Report Status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    'View Detail PL
    Sub viewDetailPL()
        Try
            Dim query As String = "CALL view_pl_sample('" + id_pl_sample_purc + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If action = "upd" Then
                For i As Integer = 0 To (data.Rows.Count - 1)
                    data.Rows(i)("count_receipt_sample") = data.Rows(i)("count_receipt_sample_db")
                Next
            End If
            GCSummary.DataSource = data
            If action = "ins" Then
                viewDetailReceipt()
            Else
                'MsgBox(action)
                viewReceiptSample()
            End If
        Catch ex As Exception
            'no action  
        End Try
    End Sub
    'View Detail Receipt
    Sub viewDetailReceipt()
        Try
            Dim query As String = "SELECT ('1') AS no_row, ('') AS sample_code_unique, ('') AS note_receipt_sample_det, ('0') AS id_pl_sample_purc_det, ('0') AS id_pl_sample_purc_det_unique"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
            deleteRows()
            newRows()
        Catch ex As Exception
            'no action
        End Try
    End Sub
    Sub viewReceiptSample()
        Try
            Dim query As String = "SELECT *, CONCAT(d.sample_code, COALESCE(c.sample_unique_code, '')) AS sample_code_unique, IF(a.is_stored='1', 'Yes', 'No') AS is_stored_display FROM tb_pl_sample_purc_det_unique a "
            query += "INNER JOIN tb_pl_sample_purc_det b ON a.id_pl_sample_purc_det = b.id_pl_sample_purc_det "
            'query += "INNER JOIN tb_pl_sample_purc_rec b1 ON b.id_pl_sample_purc_rec = b1.id_pl_sample_purc_rec "
            query += "INNER JOIN tb_m_sample_unique c ON c.id_sample_unique = a.id_sample_unique "
            query += "INNER JOIN tb_m_sample d ON d.id_sample = c.id_sample "
            query += "WHERE b.id_pl_sample_purc = '" + id_pl_sample_purc + "' AND a.is_receipt = '1' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                code_list.Add(data.Rows(i)("id_pl_sample_purc_det_unique").ToString)
            Next
            GCDetail.DataSource = data
            hideBtnStored()
        Catch ex As Exception
            errorCustom(ex.ToString)
        End Try
    End Sub
    'Save Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPReceipt, GroupGeneralHeader) Then
            errorInput()
        Else
            Dim query As String = ""
            Dim receipt_sample_number As String = addSlashes(TxtReceiptNumber.Text)
            Dim receipt_sample_date_format As Date = CType(DEReceipt.Text, Date)
            Dim receipt_sample_date As String = receipt_sample_date_format.ToString("yyyy-mm-dd")
            Dim receipt_sample_note As String = addSlashes(MENote.Text)
            Dim id_report_status_rec As String = LEReportStatus.EditValue
            query = "UPDATE tb_pl_sample_purc SET receipt_sample_number = '" + receipt_sample_number + "', receipt_sample_date = '" + receipt_sample_date + "', receipt_sample_note = '" + receipt_sample_note + "', id_report_status_rec= '" + id_report_status_rec + "' WHERE id_pl_sample_purc = '" + id_pl_sample_purc + "' "
            execute_non_query(query, True, "", "", "", "")
            If action = "ins" Then
                increase_inc("5")
                insert_who_prepared("7", id_pl_sample_purc, id_user)
            End If

            'unique product
            query = "UPDATE tb_pl_sample_purc_det_unique a "
            query += "INNER JOIN tb_pl_sample_purc_det b ON a.id_pl_sample_purc_det = b.id_pl_sample_purc_det "
            'query += "INNER JOIN tb_pl_sample_purc_rec c ON b.id_pl_sample_purc_rec = c.id_pl_sample_purc_rec "
            query += "SET a.is_receipt = '2' WHERE b.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
            execute_non_query(query, True, "", "", "", "")
            'MsgBox(query)
            For i As Integer = 0 To (GVDetail.RowCount - 1)
                Try
                    Dim id_pl_sample_purc_det As String = GVDetail.GetRowCellValue(i, "id_pl_sample_purc_det").ToString
                    Dim id_pl_sample_purc_det_unique As String = GVDetail.GetRowCellValue(i, "id_pl_sample_purc_det_unique").ToString
                    If id_pl_sample_purc_det <> 0 Then
                        query = "UPDATE tb_pl_sample_purc_det_unique SET is_receipt = '1' WHERE id_pl_sample_purc_det_unique = '" + id_pl_sample_purc_det_unique + "'"
                        execute_non_query(query, True, "", "", "", "")
                    End If
                Catch ex As Exception

                End Try
            Next

            'update detail pl
            For j As Integer = 0 To (GVSummary.RowCount - 1)
                Try
                    Dim id_pl_sample_purc_det As String = GVSummary.GetRowCellValue(j, "id_pl_sample_purc_det").ToString
                    query = "UPDATE tb_pl_sample_purc_det SET id_pl_sample_purc_det = '" + id_pl_sample_purc_det + "'"
                    execute_non_query(query, True, "", "", "", "")
                Catch ex As Exception

                End Try
            Next


            FormSampleReceipt.viewPL()
            Close()
        End If
    End Sub
    'Cancel Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Closed Form
    Private Sub FormSampleReceiptSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Add Column Number
    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no_row" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVSummary_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    'Add Rows Detail
    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        If id_report_status_rec <> "3" Then
            newRows()
        End If
    End Sub
    'Delete Rows Detail
    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        If id_report_status_rec <> "3" Then
            If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", _
         MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
            deleteRows()
        End If
    End Sub
    'Focus Column Code
    Sub focusColumnCode()
        GVDetail.FocusedColumn = GVDetail.VisibleColumns(0)
        GVDetail.ShowEditor()
    End Sub
    'New Row
    Sub newRows()
        GVDetail.AddNewRow()
        GVDetail.SetFocusedRowCellValue("id_pl_sample_purc_det", "0")
        GVDetail.SetFocusedRowCellValue("id_pl_sample_purc_det_unique", "0")
        noEdit()
        focusColumnCode()
    End Sub
    'Delete Row
    Sub deleteRows()
        Try
            Dim code_old As String = GVDetail.GetFocusedRowCellDisplayText("id_pl_sample_purc_det_unique").ToString
            Dim id_pl_sample_purc_det_old As String = GVDetail.GetFocusedRowCellDisplayText("id_pl_sample_purc_det").ToString
            If id_pl_sample_purc_det_old <> "0" Then
                GVSummary.FocusedRowHandle = find_row(GVSummary, "id_pl_sample_purc_det", id_pl_sample_purc_det_old)
                Dim old_qty_rec As Decimal = Decimal.Parse(GVSummary.GetFocusedRowCellDisplayText("count_receipt_sample").ToString)
                Dim dec_qty_rec = old_qty_rec - 1
                If dec_qty_rec < 1 Then
                    dec_qty_rec = 0
                End If
                GVSummary.SetFocusedRowCellValue("count_receipt_sample", dec_qty_rec.ToString)
                code_list.Remove(code_old)
            End If
        Catch ex As Exception
            'no action
        End Try
        GVDetail.DeleteRow(GVDetail.FocusedRowHandle)
    End Sub
    'Check & counting
    Private Sub GVDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDetail.CellValueChanged
        Dim i As Integer = sender.FocusedRowHandle
        If e.Column.FieldName = "sample_code_unique" Then
            Dim test As String = sender.GetRowCellValue(i, "sample_code_unique").ToString
            'Dim digit_str_len As Integer = 2
            'Dim curr_str_len As Integer = test.Length
            'Dim compare_str_len As Integer = curr_str_len - digit_str_len
            'Dim code_check As String = test.Substring(0, compare_str_len)
            'Dim is_duplicate As Boolean = False
            Try
                Dim query As String = "SELECT b.id_pl_sample_purc_det, b.id_pl_sample_purc_det_unique, a.id_sample_unique, a.id_sample, CONCAT(a2.sample_code, COALESCE(a.sample_unique_code, '')) "
                query += "FROM tb_m_sample_unique a  "
                query += "INNER JOIN tb_m_sample a2 ON a2.id_sample = a.id_sample "
                query += "INNER JOIN tb_pl_sample_purc_det_unique b ON a.id_sample_unique = b.id_sample_unique "
                query += "INNER JOIN tb_pl_sample_purc_det c ON c.id_pl_sample_purc_det = b.id_pl_sample_purc_det "
                query += "INNER JOIN tb_pl_sample_purc d ON d.id_pl_sample_purc = c.id_pl_sample_purc "
                query += "WHERE CONCAT(a2.sample_code, COALESCE(a.sample_unique_code, ''))  = '" + test + "' AND d.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                Dim ix As Integer = data.Rows.Count - 1
                While (ix >= 0)
                    If code_list.Contains(data.Rows(ix)("id_pl_sample_purc_det_unique").ToString) Then
                        data.Rows.RemoveAt(ix)
                    End If
                    ix = ix - 1
                End While
                If data.Rows.Count > 0 Then 'Code Found
                    If code_list.Contains(data.Rows("0")("id_pl_sample_purc_det_unique").ToString) Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Code : " + test + ", already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        deleteRows()
                        'newRows()
                    Else
                        Dim id_pl_sample_purc_det As String = data.Rows("0")("id_pl_sample_purc_det").ToString
                        Dim id_pl_sample_purc_det_unique As String = data.Rows("0")("id_pl_sample_purc_det_unique").ToString
                        Dim id_pl_sample_purc_det_detail As String = GVDetail.GetFocusedRowCellDisplayText("id_pl_sample_purc_det").ToString
                        If id_pl_sample_purc_det_detail = "0" Then 'Baris Baru
                            GVSummary.FocusedRowHandle = find_row(GVSummary, "id_pl_sample_purc_det", id_pl_sample_purc_det)
                            Dim current_qty_rec As Decimal = Decimal.Parse(GVSummary.GetFocusedRowCellDisplayText("count_receipt_sample").ToString)
                            Dim current_name As String = GVSummary.GetFocusedRowCellDisplayText("name").ToString
                            Dim limit As Decimal = Decimal.Parse(GVSummary.GetFocusedRowCellDisplayText("qty_issue").ToString)
                            ' MsgBox(inc_qty_rec.ToString)
                            Dim inc_qty_rec = current_qty_rec + 1
                            If inc_qty_rec <= limit Then
                                code_list.Add(data.Rows("0")("id_pl_sample_purc_det_unique").ToString)
                                GVSummary.SetFocusedRowCellValue("count_receipt_sample", inc_qty_rec.ToString)
                                GVDetail.SetFocusedRowCellValue("id_pl_sample_purc_det", id_pl_sample_purc_det)
                                GVDetail.SetFocusedRowCellValue("id_pl_sample_purc_det_unique", id_pl_sample_purc_det_unique)
                                'newRows()
                                noEdit()
                            Else
                                DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + limit.ToString + " pcs !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                deleteRows()
                            End If
                        Else 'Baris lama/edit
                            '-----------------------------------
                            'SEMENTARA GAK DIPAKAI
                            '-----------------------------------
                            'decrement qty before edit
                            Dim id_pl_sample_purc_det_old As String = GVDetail.GetFocusedRowCellDisplayText("id_pl_sample_purc_det").ToString
                            GVSummary.FocusedRowHandle = find_row(GVSummary, "id_pl_sample_purc_det", id_pl_sample_purc_det_old)
                            Dim old_qty_rec As Decimal = Decimal.Parse(GVSummary.GetFocusedRowCellDisplayText("count_receipt_sample").ToString)
                            Dim dec_qty_rec = old_qty_rec - 1
                            code_list.Remove(test_old)
                            If dec_qty_rec < 1 Then
                                dec_qty_rec = 0
                            End If
                            GVSummary.SetFocusedRowCellValue("count_receipt_sample", dec_qty_rec.ToString)
                            'increment Qty
                            GVSummary.FocusedRowHandle = find_row(GVSummary, "id_pl_sample_purc_det", id_pl_sample_purc_det)
                            Dim current_qty_rec As Decimal = Decimal.Parse(GVSummary.GetFocusedRowCellDisplayText("count_receipt_sample").ToString)
                            Dim inc_qty_rec = current_qty_rec + 1
                            code_list.Add(data.Rows("0")("id_pl_sample_purc_det_unique").ToString)
                            GVSummary.SetFocusedRowCellValue("count_receipt_sample", inc_qty_rec.ToString)
                            GVDetail.SetFocusedRowCellValue("id_pl_sample_purc_det", id_pl_sample_purc_det)
                            'newRows()
                        End If
                    End If
                Else 'Code Not Found
                    DevExpress.XtraEditors.XtraMessageBox.Show("Product sample not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    deleteRows()
                    'newRows()
                End If
            Catch ex As Exception
                errorConnection()
            End Try
        End If
    End Sub
    'Editing editor event
    Private Sub GVDetail_CellValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDetail.CellValueChanging
        'Timer1.Enabled = False
        'Timer1.Enabled = True
    End Sub
    'Timer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        GVDetail.CloseEditor()
        Timer1.Enabled = False
    End Sub
    Sub checkDuplicate()
        For ix As Integer = 0 To GVDetail.RowCount - 1
            Try
                Dim sample_code_unique As String = GVDetail.GetRowCellValue(ix, "sample_code_unique").ToString
                MsgBox(sample_code_unique)
            Catch ex As Exception
                'no action
            End Try
        Next
    End Sub
    'Button Test
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        code_list.Remove("b")
    End Sub
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        'GVDetail.CloseEditor()
        If code_list.Contains("b") Then
            MsgBox("Ada B")
        Else
            MsgBox("Tidak ada B")
        End If
    End Sub
    'Shown Editor
    Private Sub GVDetail_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDetail.ShownEditor
        Try
            test_old = GVDetail.GetFocusedRowCellDisplayText("sample_code_unique").ToString
        Catch ex As Exception
            'no action
        End Try
    End Sub
    'Shortkey In GC DEtail
    Private Sub GCDetail_ProcessGridKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GCDetail.ProcessGridKey
        If e.KeyCode = Keys.Escape Then
            Dim grid As DevExpress.XtraGrid.GridControl = sender
            grid.FocusedView.CloseEditor()
            e.Handled = True
        ElseIf e.KeyCode = Keys.F5 Then
            If id_report_status_rec = "1" Or id_report_status_rec = "2" Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
                newRows()
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            If id_report_status_rec = "1" Or id_report_status_rec = "2" Then
                Dim grid As DevExpress.XtraGrid.GridControl = sender
                grid.FocusedView.CloseEditor()
                e.Handled = True
                If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", _
             MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
                deleteRows()
            End If
        End If
    End Sub
    'No Edit Code If was saved
    Sub noEdit()
        Try
            Dim id_pl_sample_purc_det As String = GVDetail.GetFocusedRowCellDisplayText("id_pl_sample_purc_det")
            If id_pl_sample_purc_det = "0" Then
                GridColumnSampleCodeUnique.OptionsColumn.AllowEdit = True
            Else
                GridColumnSampleCodeUnique.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            'no action
            MsgBox("Galgal")
        End Try
    End Sub
    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportSampleReceipt.id_pl_sample_purc = id_pl_sample_purc
        Dim Report As New ReportSampleReceipt()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub GVSummary_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSummary.RowCellStyle

    End Sub
    'Stored Sample
    Private Sub BStored_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStored.Click
        Try
            Dim id_pl_sample_purc_det_unique As String = GVDetail.GetFocusedRowCellDisplayText("id_pl_sample_purc_det_unique").ToString
            FormSampleStorageIn.action = "ins"
            FormSampleStorageIn.id_pl_sample_purc_det_unique = id_pl_sample_purc_det_unique
            FormSampleStorageIn.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
    'Hide Btn Stored Pre Row
    Sub hideBtnStored()
        Dim is_stored As String = GVDetail.GetFocusedRowCellDisplayText("is_stored_display").ToString
        'MsgBox(is_stored)
        If is_stored = "Checked" Then
            BStored.Enabled = False
        Else
            If id_report_status_rec = "3" Then
                BStored.Enabled = True
            Else
                BStored.Enabled = False
            End If
        End If
    End Sub

    Private Sub GVDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDetail.RowClick
        hideBtnStored()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_sample_purc
        FormReportMark.report_mark_type = "7"
        FormReportMark.ShowDialog()
    End Sub
End Class