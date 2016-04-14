Public Class FormSamplePLSingle 
    Public action As String
    Public id_pl_sample_purc As String
    Public id_comp_contact_from As String
    Public id_comp_contact_to As String
    Public id_sample_purc_rec As String
    Public id_sample_purc As String
    Dim code_list As New List(Of String)
    Public id_sample_purc_rec_list As New List(Of String) 'List Detail PO
    Public id_receiving_list As New List(Of String) 'List Receiving
    Dim id_pl_sample_purc_det_list As New List(Of String)
    Dim id_pl_sample_purc_det_unique_list As New List(Of String)
    Dim test_old As String
    Public id_report_status As String
    Dim id_pl_sample_purc_rec As String
    Dim found_rec As Boolean = False

    'Form Load
    Private Sub FormSamplePLSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkFormAccessSingle(Name) 'check access
        viewPLCat() 'get PL Category
        viewReportStatus() 'get report status
        actionLoad()
    End Sub
    'Action Load
    Sub actionLoad()
        TxtPLNumber.Properties.ReadOnly = True
        DEPL.Properties.ReadOnly = True
        If action = "ins" Then
            TxtPLNumber.Text = header_number("3")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEPL.Text = view_date(0)
            id_report_status = "1"
        ElseIf action = "upd" Then
            Try
                'Enabled/disable form
                GConListPL.Enabled = True
                GCReceiving.Enabled = True
                SimpleButton1.Enabled = False
                GroupControlDetailSingle.Enabled = True

                'Fetch from db main
                Dim query As String = "SELECT a.id_pl_sample_purc, a.id_sample_purc,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_purc_date, a.pl_sample_purc_note, a.pl_sample_purc_number, g.sample_purc_number,b.pl_category, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from,(f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to,(f.address_primary) AS comp_address_to, a.id_pl_category, a.id_report_status, g.sample_purc_number "
                query += "FROM tb_pl_sample_purc a "
                query += "INNER JOIN tb_lookup_pl_category b ON a.id_pl_category = b.id_pl_category  "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "INNER JOIN tb_sample_purc g ON g.id_sample_purc = a.id_sample_purc "
                query += "WHERE a.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                'tampung ke form
                TxtOrderNumber.Text = data.Rows(0)("sample_purc_number").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
                MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
                TxtPLNumber.Text = data.Rows(0)("pl_sample_purc_number").ToString
                Dim start_date_arr() As String = data.Rows(0)("pl_sample_purc_date").ToString.Split(" ")
                DEPL.Text = start_date_arr(0)
                LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)
                MENote.Text = data.Rows(0)("pl_sample_purc_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                id_report_status = data.Rows(0)("id_report_status").ToString
                If id_report_status = "3" Or id_report_status = "4" Or id_report_status = "6" Then
                    GCReceiving.Enabled = False
                    BtnPrint.Enabled = True
                    BtnPopTo.Enabled = False
                    LEPLCategory.Properties.ReadOnly = True
                    BtnDelPL.Enabled = False
                    GVListPurchase.OptionsBehavior.Editable = False
                    BAdd.Enabled = False
                    Bdel.Enabled = False
                    GVDetail.OptionsBehavior.Editable = False
                    MENote.Properties.ReadOnly = True
                    LEReportStatus.Properties.ReadOnly = True
                ElseIf id_report_status = "5" Then
                    GCReceiving.Enabled = False
                    BMark.Enabled = False
                    BtnSave.Enabled = False
                    BtnPrint.Enabled = False
                    BtnPopTo.Enabled = False
                    LEPLCategory.Properties.ReadOnly = True
                    BtnDelPL.Enabled = False
                    GVListPurchase.OptionsBehavior.Editable = False
                    BAdd.Enabled = False
                    Bdel.Enabled = False
                    GVDetail.OptionsBehavior.Editable = False
                    MENote.Properties.ReadOnly = True
                    LEReportStatus.Properties.ReadOnly = False
                Else
                    If check_edit_report_status(id_report_status, "3", id_pl_sample_purc) Then
                        GCReceiving.Enabled = True
                        BtnPrint.Enabled = False
                        BtnPopTo.Enabled = True
                        LEPLCategory.Properties.ReadOnly = False
                        BtnDelPL.Enabled = True
                        GVListPurchase.OptionsBehavior.Editable = True
                        BAdd.Enabled = True
                        Bdel.Enabled = True
                        GVDetail.OptionsBehavior.Editable = True
                        MENote.Properties.ReadOnly = False
                        LEReportStatus.Properties.ReadOnly = False
                    Else
                        GCReceiving.Enabled = False
                        BtnPrint.Enabled = True
                        BtnPopTo.Enabled = False
                        LEPLCategory.Properties.ReadOnly = True
                        BtnDelPL.Enabled = False
                        GVListPurchase.OptionsBehavior.Editable = False
                        BAdd.Enabled = False
                        Bdel.Enabled = False
                        GVDetail.OptionsBehavior.Editable = False
                        MENote.Properties.ReadOnly = True
                        LEReportStatus.Properties.ReadOnly = True
                    End If
                End If
                'Fetch db detail
                viewReceivingUpd()
                viewPLSample()
            Catch ex As Exception
                'errorConnection()
                'Close()
            End Try
        End If
    End Sub
    'Form Closed
    Private Sub FormSamplePLSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        checkFormAccess("FormSamplePL")
    End Sub
    'View Receiving 
    Sub viewReceiving()
        Dim query As String = "SELECT *, ('No') AS choose_receiving FROM tb_sample_purc_rec WHERE id_sample_purc = '" + id_sample_purc + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReceiving.DataSource = data
    End Sub
    'View Receiving (UPDATE)
    Sub viewReceivingUpd()
        Dim query As String = "SELECT a.sample_purc_rec_number, a.id_sample_purc_rec, b.id_pl_sample_purc_rec, IF(!ISNULL(b.id_pl_sample_purc_rec), 'Yes', 'No') AS choose_receiving FROM tb_sample_purc_rec a "
        query += "LEFT JOIN tb_pl_sample_purc_rec b ON a.id_sample_purc_rec = b.id_sample_purc_rec AND b.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
        query += "WHERE a.id_sample_purc = '" + id_sample_purc + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            If Not IsDBNull(data.Rows(0)("id_pl_sample_purc_rec")) Then
                id_receiving_list.Add(data.Rows(i)("id_sample_purc_rec").ToString)
            End If
        Next
        GCReceiving.DataSource = data
    End Sub
    'View PL Sample
    Sub viewPLSample()
        'Try
        Dim query As String = "CALL view_pl_sample('" + id_pl_sample_purc + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_purc_rec_list.Add(data.Rows(i)("id_sample_purc_det").ToString)
            'If Not id_receiving_list.Contains(data.Rows(i)("id_sample_purc_rec").ToString) Then
            '    id_receiving_list.Add(data.Rows(i)("id_sample_purc_rec").ToString)
            'End If
            id_pl_sample_purc_det_list.Add(data.Rows(i)("id_pl_sample_purc_det").ToString)
        Next
        GCListPurchase.DataSource = data
        viewPLUnique()
        ' Catch ex As Exception
        'errorConnection()
        'End Try
    End Sub
    'View PL Unique
    Sub viewPLUnique()
        ' Try
        Dim query As String = "SELECT (CONCAT(d.sample_code, COALESCE(c.sample_unique_code, ''))) AS sample_unique_code, a.id_pl_sample_purc_det, b.id_sample_purc_det, a.id_pl_sample_purc_det_unique, a.id_sample_unique FROM tb_pl_sample_purc_det_unique a "
        query += "INNER JOIN tb_pl_sample_purc_det b ON a.id_pl_sample_purc_det = b.id_pl_sample_purc_det "
        query += "INNER JOIN tb_pl_sample_purc b1 ON b1.id_pl_sample_purc = b.id_pl_sample_purc "
        query += "INNER JOIN tb_m_sample_unique c ON a.id_sample_unique = c.id_sample_unique "
        query += "INNER JOIN tb_m_sample d ON d.id_sample = c.id_sample "
        query += "WHERE b1.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            code_list.Add(data.Rows(i)("id_sample_unique").ToString)
            id_pl_sample_purc_det_unique_list.Add(data.Rows(i)("id_pl_sample_purc_det_unique").ToString)
        Next
        GCDetail.DataSource = data
        '  Catch ex As Exception
        ' errorConnection()
        'End Try
    End Sub
    'View PL Detail
    Sub viewPLDetail()
        Try
            Dim query As String = "SELECT ('1') AS no_row, ('') AS sample_unique_code, ('') AS note_receipt_sample_det, ('0') AS id_sample_purc_det,  ('0') AS id_sample_unique, ('0') AS id_pl_sample_purc_det_unique"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
            GVDetail.DeleteRow(GVDetail.FocusedRowHandle)
            newRows()
        Catch ex As Exception
            'no action
        End Try
    End Sub
    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub
    'View Report Status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    'View List Receive (INSERT ONLY)
    Sub viewListRec()
        'Dim query = "CALL view_purc_rec_sample_det_limit('" & id_sample_purc_rec & "')"
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'For i As Integer = 0 To (data.Rows.Count - 1)
        '    id_sample_purc_rec_list.Add(data.Rows(i)("id_sample_purc_rec_det").ToString)
        'Next
        'Dim query As String = "SELECT ('0') as no, ('') AS code, ('') AS uom,('') AS name, ('') AS size, ('') AS sample_purc_rec_det_qty, ('') AS qty_issue, ('') AS pl_sample_purc_det_note, ('') AS id_sample_purc_det, ('') AS id_pl_sample_purc_det, ('') AS id_sample_purc_rec, ('0') AS id_pl_sample_purc_rec "
        Dim query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_purc_rec_list.Add(data.Rows(i)("id_sample_purc_det").ToString)
        Next
        GCListPurchase.DataSource = data
        GroupControlDetailSingle.Enabled = True
        'GVListPurchase.DeleteRow(GVListPurchase.FocusedRowHandle)
        viewPLDetail()
    End Sub
    'Popup Contact From
    Private Sub BtnPopFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "4"
        FormPopUpContact.id_comp_contact = id_comp_contact_from
        FormPopUpContact.ShowDialog()
    End Sub
    'Popup Contact To
    Private Sub BtnPopTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPopTo.Click
        FormPopUpContact.id_comp_contact = id_comp_contact_to
        FormPopUpContact.id_pop_up = "5"
        FormPopUpContact.ShowDialog()
    End Sub
    'PopUp Receveing
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        FormPopUpPurchase.id_purc = id_sample_purc
        FormPopUpPurchase.id_pop_up = "5"
        FormPopUpPurchase.ShowDialog()
    End Sub
    Private Sub BtnDelPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelPL.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", _
          MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_recx As String = GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString
        Dim id_rec_detail As String = GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
        Dim id_rec_detail_unique As String = ""
        Dim i As Integer = GVDetail.RowCount - 1
        While i >= 0
            Try
                id_rec_detail_unique = GVDetail.GetRowCellValue(i, "id_sample_purc_rec_det").ToString
                If id_rec_detail = id_rec_detail_unique Then
                    GVDetail.DeleteRow(i)
                End If
            Catch ex As Exception

            End Try
            i = i - 1
        End While
        MsgBox(id_rec_detail)
        id_sample_purc_rec_list.Remove(id_rec_detail)
        GVListPurchase.DeleteRow(GVListPurchase.FocusedRowHandle)
    End Sub
    'Cancel Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        Dim cek_input_qty As Boolean = False
        Dim cek_pl_sample_purc_det_qty As String

        For i As Integer = 0 To GVReceiving.RowCount - 1
            Try
                cek_pl_sample_purc_det_qty = GVReceiving.GetRowCellValue(i, "choose_receiving").ToString
                ' MsgBox(cek_pl_sample_purc_det_qty)
                'Or cek_pl_sample_purc_det_qty = "0" 
                If cek_pl_sample_purc_det_qty = "No" Then
                    cek_input_qty = False
                Else
                    cek_input_qty = True
                    Exit For
                End If
            Catch ex As Exception
                'no action
                MsgBox(ex.ToString)
            End Try
        Next
        'MsgBox(cek_input_qty.ToString)
        If Not formIsValidInPanel(ErrorProviderPL, GroupGeneralHeader) Or Not cek_input_qty Then
            errorInput()
        Else
            'MsgBox("berhasil")
            'main
            Dim query As String = ""
            Dim query2 As String = ""
            Dim pl_sample_purc_number As String = addSlashes(TxtPLNumber.Text)
            Dim id_pl_category As String = LEPLCategory.EditValue
            Dim pl_sample_purc_date_format As Date = CType(DEPL.Text, Date)
            Dim pl_sample_purc_date As String = pl_sample_purc_date_format.ToString("yyyy-MM-dd")
            Dim pl_sample_purc_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            'detail
            Dim id_sample_purc_rec_det As String
            Dim pl_sample_purc_det_qty As String
            Dim pl_sample_purc_det_note As String
            Dim succes As Boolean = False
            If action = "ins" Then
                'Try
                'Main table
                query = "INSERT INTO tb_pl_sample_purc(id_sample_purc, pl_sample_purc_number, id_pl_category, id_comp_contact_from, id_comp_contact_to, pl_sample_purc_date, pl_sample_purc_note, id_report_status) "
                query += "VALUES('" + id_sample_purc + "', '" + pl_sample_purc_number + "', '" + id_pl_category + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', '" + pl_sample_purc_date + "', '" + pl_sample_purc_note + "', '" + id_report_status + "')"
                execute_non_query(query, True, "", "", "", "")


                'get id main
                query = "SELECT LAST_INSERT_ID()"
                id_pl_sample_purc = execute_query(query, 0, True, "", "", "", "")
                increase_inc("3")

                'preapred default
                insert_who_prepared("3", id_pl_sample_purc, id_user)


                'detail table
                For i As Integer = 0 To GVListPurchase.RowCount - 1
                    'Try
                    id_sample_purc_rec = GVListPurchase.GetRowCellValue(i, "id_sample_purc_rec").ToString
                    id_sample_purc_rec_det = GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString
                    pl_sample_purc_det_qty = GVListPurchase.GetRowCellValue(i, "qty_issue").ToString
                    pl_sample_purc_det_note = GVListPurchase.GetRowCellValue(i, "pl_sample_purc_det_note").ToString

                    'If pl_sample_purc_det_qty <> "0" And pl_sample_purc_det_qty <> "0.00" And pl_sample_purc_det_qty <> "" And pl_sample_purc_det_qty <> " " Then
                    'INSERT TB PL SAMPLE RECEIVING
                    'query2 = "SELECT id_pl_sample_purc_rec FROM tb_pl_sample_purc_rec WHERE id_pl_sample_purc = '" + id_pl_sample_purc + "' AND id_sample_purc_rec = '" + id_sample_purc_rec + "' "
                    'Dim data2 As DataTable = execute_query(query2, -1, True, "", "", "", "")
                    'If data2.Rows.Count > 0 Then
                    '    id_pl_sample_purc_rec = execute_query(query2, 0, True, "", "", "", "")
                    'Else
                    '    Dim query_new_pl_rec As String = "INSERT INTO tb_pl_sample_purc_rec(id_pl_sample_purc, id_sample_purc_rec) VALUES ('" + id_pl_sample_purc + "', '" + id_sample_purc_rec + "')"
                    '    execute_non_query(query_new_pl_rec, True, "", "", "", "")
                    '    id_pl_sample_purc_rec = execute_query("SELECT LAST_INSERT_ID()", 0, True, "", "", "", "")
                    'End If

                    'INSERT TB PL SAMPLE DETAIL
                    query = "INSERT tb_pl_sample_purc_det(id_pl_sample_purc, id_sample_purc_det, pl_sample_purc_det_qty, pl_sample_purc_det_note) "
                    query += "VALUES('" + id_pl_sample_purc + "', '" + id_sample_purc_rec_det + "', '" + pl_sample_purc_det_qty + "', '" + pl_sample_purc_det_note + "') "
                    execute_non_query(query, True, "", "", "", "")


                    'INSERT TB PL SAMPLE UNIQUE
                    Dim id_pl_sample_purc_det As String = execute_query("SELECT LAST_INSERT_ID()", 0, True, "", "", "", "")
                    For j As Integer = 0 To (GVDetail.RowCount - 1)
                        Try
                            Dim id_sample_purc_rec_detail As String = GVDetail.GetRowCellValue(j, "id_sample_purc_det").ToString
                            If id_sample_purc_rec_det = id_sample_purc_rec_detail Then
                                If id_sample_purc_rec_detail <> 0 Then
                                    Dim id_sample_unique As String = GVDetail.GetRowCellValue(j, "id_sample_unique").ToString
                                    query = "INSERT INTO tb_pl_sample_purc_det_unique(id_pl_sample_purc_det, id_sample_unique) VALUES('" + id_pl_sample_purc_det + "', '" + id_sample_unique + "') "
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                    'End If
                    succes = True
                    'Catch ex As Exception
                    '    MsgBox("Error Success")
                    '    succes = False
                    'End Try
                Next

                'INSERT TB RECEIVE
                For k As Integer = 0 To (GVReceiving.RowCount - 1)
                    Try
                        Dim id_sample_receiving_pl As String = GVReceiving.GetRowCellValue(k, "id_sample_purc_rec").ToString
                        Dim choose_rec As String = GVReceiving.GetRowCellValue(k, "choose_receiving").ToString
                        Dim query_rec_pl As String = ""
                        If choose_rec = "Yes" Then
                            query_rec_pl = "INSERT tb_pl_sample_purc_rec(id_pl_sample_purc, id_sample_purc_rec) VALUES ('" + id_pl_sample_purc + "', '" + id_sample_receiving_pl + "')"
                            execute_non_query(query_rec_pl, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                        errorCustom(ex.ToString)
                    End Try
                Next

                If succes Then
                    FormSamplePL.viewPL()
                    Close()
                Else
                    errorConnection()
                End If
                'Catch ex As Exception
                '    errorCustom(ex.ToString)
                'End Try
            ElseIf action = "upd" Then
                ' Try
                'update main table
                query = "UPDATE tb_pl_sample_purc SET pl_sample_purc_number = '" + pl_sample_purc_number + "', id_pl_category = '" + id_pl_category + "', id_comp_contact_to = '" + id_comp_contact_to + "', pl_sample_purc_date = '" + pl_sample_purc_date + "', pl_sample_purc_note = '" + pl_sample_purc_note + "', id_report_status = '" + id_report_status + "' WHERE id_pl_sample_purc = '" + id_pl_sample_purc + "'"
                execute_non_query(query, True, "", "", "", "")

                'update detail table
                For i As Integer = 0 To (GVListPurchase.RowCount - 1)
                    Try
                        id_sample_purc_rec = GVListPurchase.GetRowCellValue(i, "id_sample_purc_rec").ToString
                        Dim id_pl_sample_purc_det As String = GVListPurchase.GetRowCellValue(i, "id_pl_sample_purc_det").ToString
                        id_sample_purc_rec_det = GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString
                        pl_sample_purc_det_qty = GVListPurchase.GetRowCellValue(i, "qty_issue").ToString
                        pl_sample_purc_det_note = GVListPurchase.GetRowCellValue(i, "pl_sample_purc_det_note").ToString

                        ' If pl_sample_purc_det_qty <> "0" And pl_sample_purc_det_qty <> "0.00" And pl_sample_purc_det_qty <> "" And pl_sample_purc_det_qty <> " " Then
                        If id_pl_sample_purc_det_list.Contains(id_pl_sample_purc_det) Then
                            query = "UPDATE tb_pl_sample_purc_det SET id_sample_purc_det = '" + id_sample_purc_rec_det + "', pl_sample_purc_det_qty = '" + pl_sample_purc_det_qty + "', pl_sample_purc_det_note = '" + pl_sample_purc_det_note + "' WHERE id_pl_sample_purc_det = '" + id_pl_sample_purc_det + "'"
                            execute_non_query(query, True, "", "", "", "")
                            id_pl_sample_purc_det_list.Remove(id_pl_sample_purc_det)
                        Else
                            'query2 = "SELECT id_pl_sample_purc_rec FROM tb_pl_sample_purc_rec WHERE id_pl_sample_purc = '" + id_pl_sample_purc + "' AND id_sample_purc_rec = '" + id_sample_purc_rec + "' "
                            'Dim data2 As DataTable = execute_query(query2, -1, True, "", "", "", "")
                            'If data2.Rows.Count > 0 Then
                            '    id_pl_sample_purc_rec = execute_query(query2, 0, True, "", "", "", "")
                            'Else
                            '    Dim query_new_pl_rec As String = "INSERT INTO tb_pl_sample_purc_rec(id_pl_sample_purc, id_sample_purc_rec) VALUES ('" + id_pl_sample_purc + "', '" + id_sample_purc_rec + "')"
                            '    execute_non_query(query_new_pl_rec, True, "", "", "", "")
                            '    id_pl_sample_purc_rec = execute_query("SELECT LAST_INSERT_ID()", 0, True, "", "", "", "")
                            'End If
                            query = "INSERT tb_pl_sample_purc_det(id_pl_sample_purc, id_sample_purc_det, pl_sample_purc_det_qty, pl_sample_purc_det_note) "
                            query += "VALUES('" + id_pl_sample_purc_rec + "', '" + id_sample_purc_rec_det + "', '" + pl_sample_purc_det_qty + "', '" + pl_sample_purc_det_note + "') "
                            execute_non_query(query, True, "", "", "", "")
                        End If
                        'End If
                    Catch ex As Exception

                    End Try
                Next

                'update unique table
                For j As Integer = 0 To (GVDetail.RowCount - 1)
                    Try
                        Dim id_sample_purc_rec_detail As String = GVDetail.GetRowCellValue(j, "id_sample_purc_det").ToString
                        Dim id_sample_receiving As String = execute_query("SELECT id_sample_purc_rec FROM tb_sample_purc_rec_det WHERE id_sample_purc_rec_det = '" + id_sample_purc_rec_detail + "'", 0, True, "", "", "", "")
                        If id_sample_purc_rec_detail <> 0 Then
                            Dim id_pl_sample_purc_det_unique As String = GVDetail.GetRowCellValue(j, "id_pl_sample_purc_det_unique").ToString
                            If id_pl_sample_purc_det_unique_list.Contains(id_pl_sample_purc_det_unique) Then
                                id_pl_sample_purc_det_unique_list.Remove(id_pl_sample_purc_det_unique)
                            Else
                                'id_pl_sample_purc_rec = execute_query("SELECT id_pl_sample_purc_rec FROM tb_pl_sample_purc_rec WHERE id_pl_sample_purc = '" + id_pl_sample_purc + "' AND id_sample_purc_rec = '" + id_sample_receiving + "'", 0, True, "", "", "", "")
                                Dim id_sample_unique As String = GVDetail.GetRowCellValue(j, "id_sample_unique").ToString
                                Dim id_pl_sample_purc_det As String = execute_query("SELECT id_pl_sample_purc_det FROM tb_pl_sample_purc_det WHERE id_sample_purc_det = '" + id_sample_purc_rec_detail + "' AND  id_pl_sample_purc = '" + id_pl_sample_purc + "'", 0, True, "", "", "", "")
                                query = "INSERT INTO tb_pl_sample_purc_det_unique(id_pl_sample_purc_det, id_sample_unique) VALUES('" + id_pl_sample_purc_det + "', '" + id_sample_unique + "') "
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                Next

                'UPDATE TB RECEIVE
                'sementara pake delete
                execute_non_query("DELETE FROM tb_pl_sample_purc_rec WHERE id_pl_sample_purc = '" + id_pl_sample_purc + "'", True, "", "", "", "")
                For k As Integer = 0 To (GVReceiving.RowCount - 1)
                    Try
                        Dim id_sample_receiving_pl As String = GVReceiving.GetRowCellValue(k, "id_sample_purc_rec").ToString
                        Dim choose_rec As String = GVReceiving.GetRowCellValue(k, "choose_receiving").ToString
                        Dim query_rec_pl As String = ""
                        If choose_rec = "Yes" Then
                            query_rec_pl = "INSERT tb_pl_sample_purc_rec(id_pl_sample_purc, id_sample_purc_rec) VALUES ('" + id_pl_sample_purc + "', '" + id_sample_receiving_pl + "')"
                            execute_non_query(query_rec_pl, True, "", "", "", "")
                        End If
                        'If choose_rec = "Yes" Then
                        '    If id_receiving_list.Contains(id_sample_receiving_pl) Then
                        '        id_receiving_list.Remove(id_sample_receiving_pl)
                        '    Else
                        '        query_rec_pl = "INSERT tb_pl_sample_purc_rec(id_pl_sample_purc, id_sample_purc_rec) VALUES ('" + id_pl_sample_purc + "', '" + id_sample_receiving_pl + "')"
                        '        execute_non_query(query_rec_pl, True, "", "", "", "")
                        '    End If
                        'End If
                    Catch ex As Exception
                        errorCustom(ex.ToString)
                    End Try
                Next

                'delete sisa data di list
                For a As Integer = 0 To (id_pl_sample_purc_det_list.Count - 1)
                    Try
                        Dim pl_detail As String = id_pl_sample_purc_det_list(a)

                        'Delete table PL Receiving
                        'Dim query_receiving_pl_old As String = "SELECT id_pl_sample_purc_rec FROM tb_pl_sample_purc_det WHERE id_pl_sample_purc_det = '" + pl_detail + "'"
                        'Dim id_pl_sample_purc_receiving_pl_old As String = execute_query(query_receiving_pl_old, 0, True, "", "", "", "")

                        'Delete Table PL Detail
                        query = "DELETE FROM tb_pl_sample_purc_det WHERE id_pl_sample_purc_det = '" + pl_detail + "'"
                        execute_non_query(query, True, "", "", "", "")

                        'Cek kondisi 
                        'query_receiving_pl_old = "SELECT * FROM tb_pl_sample_purc_det WHERE id_pl_sample_purc_rec = '" + id_pl_sample_purc_receiving_pl_old + "' "
                        'Dim data_receiving_pl_old As DataTable = execute_query(query_receiving_pl_old, -1, True, "", "", "", "")
                        'If data_receiving_pl_old.Rows.Count < 1 Then
                        'execute_non_query("DELETE FROM tb_pl_sample_purc_rec WHERE id_pl_sample_purc_rec = '" + id_pl_sample_purc_receiving_pl_old + "'", True, "", "", "", "")
                        'End If
                    Catch ex As Exception

                    End Try
                Next
                For b As Integer = 0 To (id_pl_sample_purc_det_unique_list.Count - 1)
                    Try
                        'MsgBox(id_pl_sample_purc_det_unique_list(b))
                        query = "DELETE FROM tb_pl_sample_purc_det_unique WHERE id_pl_sample_purc_det_unique = '" + id_pl_sample_purc_det_unique_list(b) + "'"
                        execute_non_query(query, True, "", "", "", "")
                    Catch ex As Exception
                    End Try
                Next

                'For c As Integer = 0 To (id_receiving_list.Count - 1)
                '    '  Try
                '    'MsgBox(id_pl_sample_purc_det_unique_list(b))
                '    Dim id_rec_pl_old As String = execute_query("SELECT id_pl_sample_purc_rec FROM tb_pl_sample_purc_rec  WHERE id_pl_sample_purc = '" + id_pl_sample_purc + "' AND id_sample_purc_rec = '" + id_receiving_list(c) + "'", 0, True, "", "", "", "")
                '    query = "DELETE FROM tb_pl_sample_purc_rec WHERE id_pl_sample_purc_rec = '" + id_rec_pl_old + "'"
                '    execute_non_query(query, True, "", "", "", "")
                '    'Catch ex As Exception
                '    'errorCustom(ex.ToString)
                '    'End Try
                'Next

                FormSamplePL.viewPL()
                Close()
                ' Catch ex As Exception
                'errorCustom(ex.ToString)
                'End Try
            End If
        End If
    End Sub
    'Validating
    Private Sub DEPL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEPL.Validating
        EP_DE_cant_blank(ErrorProviderPL, DEPL)
    End Sub
    Private Sub TxtOrderNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOrderNumber.Validating
        EP_TE_cant_blank(ErrorProviderPL, TxtOrderNumber)
        ErrorProviderPL.SetIconPadding(TxtOrderNumber, 28)
    End Sub
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(ErrorProviderPL, TxtNameCompFrom)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(ErrorProviderPL, TxtNameCompTo)
        ErrorProviderPL.SetIconPadding(TxtNameCompTo, 28)
    End Sub
    'Print
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportPLSample.id_pl_sample_purc = id_pl_sample_purc
        Dim Report As New ReportPLSample()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
    'Focus Column Code
    Sub focusColumnCode()
        GVDetail.FocusedColumn = GVDetail.VisibleColumns(0)
        GVDetail.ShowEditor()
    End Sub
    'New Row
    Sub newRows()
        GVDetail.AddNewRow()
        GVDetail.SetFocusedRowCellValue("id_sample_purc_det", "0")
        GVDetail.SetFocusedRowCellValue("id_sample_unique", "0")
        GVDetail.SetFocusedRowCellValue("id_pl_sample_purc_det_unique", "0")
        noEdit()
        focusColumnCode()
    End Sub
    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        newRows()
    End Sub
    'Delete Row
    Sub deleteRows()
        Try
            Dim code_old As String = GVDetail.GetFocusedRowCellDisplayText("id_sample_unique").ToString
            Dim id_sample_purc_rec_det_old As String = GVDetail.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
            If id_sample_purc_rec_det_old <> "0" Then
                GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_sample_purc_det", id_sample_purc_rec_det_old)
                Dim old_qty_rec As Decimal = Decimal.Parse(GVListPurchase.GetFocusedRowCellDisplayText("qty_issue").ToString)
                Dim dec_qty_rec = old_qty_rec - 1
                If dec_qty_rec < 1 Then
                    dec_qty_rec = 0
                End If
                GVListPurchase.SetFocusedRowCellValue("qty_issue", dec_qty_rec.ToString)
                code_list.Remove(code_old)
            End If
        Catch ex As Exception
            'no action
        End Try
        GVDetail.DeleteRow(GVDetail.FocusedRowHandle)
    End Sub
    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", _
         MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        deleteRows()
    End Sub
    Sub noEdit()
        Try
            Dim id_sample_purc_rec_det As String = GVDetail.GetFocusedRowCellDisplayText("id_sample_purc_det")
            'MsgBox(id_sample_purc_rec_det)
            If id_sample_purc_rec_det = "0" Then
                GridColumnSampleCodeUnique.OptionsColumn.AllowEdit = True
            Else
                GridColumnSampleCodeUnique.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_sample_purc_rec_det)
        Catch ex As Exception
            'no action
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_sample_purc
        FormReportMark.report_mark_type = "3"
        FormReportMark.ShowDialog()
    End Sub
    'Pop Up Receiving
    Private Sub BtnAddPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddPL.Click
        FormPopUpReceive.id_pop_up = "1"
        FormPopUpReceive.id_purc = id_sample_purc
        FormPopUpReceive.action = "ins"
        FormPopUpReceive.ShowDialog()
    End Sub
    Private Sub BtnEditPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditPL.Click
        FormPopUpReceive.id_pop_up = "1"
        FormPopUpReceive.id_purc = id_sample_purc
        FormPopUpReceive.action = "upd"
        FormPopUpReceive.ShowDialog()
    End Sub
    Function findReceiving(ByVal value_check As String)
        found_rec = False
        For i As Integer = 0 To (GVDetail.RowCount - 1)
            Try
                Dim id_rec As String = GVDetail.GetRowCellValue(i, "id_sample_purc_rec ")
                If id_rec = value_check Then
                    found_rec = True
                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next
        If found_rec Then
            Return True
        Else
            Return False
        End If
    End Function
    'Gridcontrol PL EVENT
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    'Gridcontrol Detail EVENT
    'Press Key On Grid Control Detail
    Private Sub GCDetail_ProcessGridKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GCDetail.ProcessGridKey
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
    Private Sub GVDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDetail.CellValueChanged
        Dim i As Integer = sender.FocusedRowHandle
        If e.Column.FieldName = "sample_unique_code" Then
            Dim test As String = sender.GetRowCellValue(i, "sample_unique_code").ToString
            'Try
            Dim query As String = "SELECT e.sample_purc_number, e.id_sample_purc, f.id_sample_purc_det, modif_tbl.id_pl_sample_purc_det_unique, modif_tbl.id_sample_unique,  modif_tbl.id_sample, modif_tbl.sample_code_counting  FROM tb_sample_purc e "
            query += "INNER JOIN tb_sample_purc_det f ON e.id_sample_purc = f.id_sample_purc "
            query += "INNER JOIN tb_m_sample_price g ON g.id_sample_price = f.id_sample_price "
            query += "INNER JOIN "
            query += "(SELECT b.id_pl_sample_purc_det_unique, a.id_sample_unique, a.id_sample, CONCAT(a2.sample_code, COALESCE(a.sample_unique_code, '')) AS sample_code_counting "
            query += "FROM tb_m_sample_unique a "
            query += "LEFT JOIN tb_m_sample a2 ON a2.id_sample = a.id_sample "
            query += "LEFT JOIN tb_pl_sample_purc_det_unique b ON a.id_sample_unique = b.id_sample_unique "
            query += "LEFT JOIN tb_pl_sample_purc_det c ON c.id_pl_sample_purc_det = b.id_pl_sample_purc_det "
            query += "LEFT JOIN tb_pl_sample_purc d ON d.id_pl_sample_purc = c.id_pl_sample_purc "
            query += "WHERE CONCAT(a2.sample_code, COALESCE(a.sample_unique_code, ''))  = '" + test + "' AND (ISNULL(b.id_pl_sample_purc_det_unique)) OR d.id_report_status ='5') "
            query += "modif_tbl ON g.id_sample = modif_tbl.id_sample "
            query += "WHERE e.id_sample_purc = '" + id_sample_purc + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim ix As Integer = data.Rows.Count - 1
            While (ix >= 0)
                If code_list.Contains(data.Rows(ix)("id_sample_unique").ToString) Then
                    data.Rows.RemoveAt(ix)
                End If
                ix = ix - 1
            End While
            If data.Rows.Count > 0 Then 'Code Found
                If id_sample_purc_rec_list.Contains(data.Rows("0")("id_sample_purc_det").ToString) Then
                    If code_list.Contains(data.Rows("0")("id_sample_unique").ToString) Then
                        DevExpress.XtraEditors.XtraMessageBox.Show("Code : " + test + ", already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        deleteRows()
                        'newRows()
                    Else
                        If Not IsDBNull(data.Rows(0)("id_pl_sample_purc_det_unique")) Then
                            'gk kepake karena aku pakein yg null saja 
                            DevExpress.XtraEditors.XtraMessageBox.Show("Code : " + test + ", already exist in Packing List Number : " + data.Rows("0")("pl_sample_purc_number").ToString + " !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            deleteRows()
                        Else
                            Dim id_sample_purc_rec_det As String = data.Rows("0")("id_sample_purc_det").ToString
                            'MsgBox(id_sample_purc_rec_det)
                            Dim id_sample_unique As String = data.Rows("0")("id_sample_unique").ToString
                            Dim id_sample_purc_rec_det_detail As String = GVDetail.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
                            'Dim status_editing As String = GVDetail.GetFocusedRowCellDisplayText("status_editing").ToString

                            If id_sample_purc_rec_det_detail = "0" Then 'Baris Baru
                                If GVListPurchase.RowCount < 1 Then
                                    errorCustom("Packing List data still empty !")
                                    deleteRows()
                                Else
                                    GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_sample_purc_det", id_sample_purc_rec_det)
                                    Dim current_qty_rec As Decimal = Decimal.Parse(GVListPurchase.GetFocusedRowCellDisplayText("qty_issue").ToString)
                                    Dim current_name As String = GVListPurchase.GetFocusedRowCellDisplayText("name").ToString
                                    Dim limit As Decimal = Decimal.Parse(GVListPurchase.GetFocusedRowCellDisplayText("sample_purc_rec_det_qty").ToString)
                                    Dim inc_qty_rec = current_qty_rec + 1
                                    code_list.Add(data.Rows("0")("id_sample_unique").ToString)
                                    GVListPurchase.SetFocusedRowCellValue("qty_issue", inc_qty_rec.ToString)
                                    GVDetail.SetFocusedRowCellValue("id_sample_purc_det", id_sample_purc_rec_det)
                                    GVDetail.SetFocusedRowCellValue("id_sample_unique", id_sample_unique)
                                    noEdit()
                                End If
                                '------------OLD CODE---------------------------
                                'If inc_qty_rec <= limit Then
                                '    code_list.Add(data.Rows("0")("id_sample_unique").ToString)
                                '    GVListPurchase.SetFocusedRowCellValue("qty_issue", inc_qty_rec.ToString)
                                '    GVDetail.SetFocusedRowCellValue("id_sample_purc_rec_det", id_sample_purc_rec_det)
                                '    GVDetail.SetFocusedRowCellValue("id_sample_unique", id_sample_unique)
                                '    noEdit()
                                'Else
                                '    DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + limit.ToString + " pcs !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                '    deleteRows()
                                'End If
                                '------------END OF OLD CODE---------------------------
                                'newRows()
                            Else 'Baris lama/edit
                                'decrement qty before edit
                                '-----------------------------------
                                'SEMENTARA GAK DIPAKAI (VELUM AKU EDIT JADI PURCHASE DET)
                                '-----------------------------------
                                Dim id_sample_purc_rec_det_old As String = GVDetail.GetFocusedRowCellDisplayText("id_sample_purc_rec_det").ToString
                                GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_sample_purc_rec_det", id_sample_purc_rec_det_old)
                                Dim old_qty_rec As Decimal = Decimal.Parse(GVListPurchase.GetFocusedRowCellDisplayText("qty_issue").ToString)
                                Dim dec_qty_rec = old_qty_rec - 1
                                code_list.Remove(test_old)
                                If dec_qty_rec < 1 Then
                                    dec_qty_rec = 0
                                End If
                                GVListPurchase.SetFocusedRowCellValue("qty_issue", dec_qty_rec.ToString)
                                'increment Qty
                                GVListPurchase.FocusedRowHandle = find_row(GVListPurchase, "id_sample_purc_rec_det", id_sample_purc_rec_det)
                                Dim current_qty_rec As Decimal = Decimal.Parse(GVListPurchase.GetFocusedRowCellDisplayText("qty_issue").ToString)
                                Dim current_name As String = GVListPurchase.GetFocusedRowCellDisplayText("name").ToString
                                Dim limit As Decimal = Decimal.Parse(GVListPurchase.GetFocusedRowCellDisplayText("sample_purc_rec_det_qty").ToString)
                                Dim inc_qty_rec = current_qty_rec + 1
                                code_list.Add(data.Rows("0")("id_sample_unique").ToString)
                                GVListPurchase.SetFocusedRowCellValue("qty_issue", inc_qty_rec.ToString)
                                GVDetail.SetFocusedRowCellValue("id_sample_purc_rec_det", id_sample_purc_rec_det)
                                GVDetail.SetFocusedRowCellValue("id_sample_unique", id_sample_unique)
                                '------------OLD CODE---------------------------
                                'If inc_qty_rec <= limit Then
                                '    code_list.Add(data.Rows("0")("id_sample_unique").ToString)
                                '    GVListPurchase.SetFocusedRowCellValue("qty_issue", inc_qty_rec.ToString)
                                '    GVDetail.SetFocusedRowCellValue("id_sample_purc_rec_det", id_sample_purc_rec_det)
                                '    GVDetail.SetFocusedRowCellValue("id_sample_unique", id_sample_unique)
                                'Else
                                '    DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + limit.ToString + " pcs !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                '    'deleteRows()
                                'End If
                                'newRows()
                                '------------END OF OLD CODE---------------------------
                            End If
                        End If
                    End If
                Else 'Code Not Found
                    DevExpress.XtraEditors.XtraMessageBox.Show("Product sample not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    deleteRows()
                    'newRows()
                End If
            Else 'Code Not Found
                DevExpress.XtraEditors.XtraMessageBox.Show("Product sample not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                deleteRows()
                'newRows()
            End If
            'Catch ex As Exception
            'errorCustom(ex.ToString)
            'End Try
        End If
    End Sub
    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        noEdit()
    End Sub
    Private Sub GVDetail_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDetail.ShownEditor
        Try
            test_old = GVDetail.GetFocusedRowCellDisplayText("id_sample_unique").ToString
            'Dim id_sample_purc_rec_det As String = GVDetail.GetFocusedRowCellDisplayText("id_sample_purc_rec_det")
            'MsgBox(id_sample_purc_rec_det)
            'If id_sample_purc_rec_det = "0" Then
            '    GridColumnSampleCodeUnique.OptionsColumn.AllowEdit = True
            'Else
            '    GridColumnSampleCodeUnique.OptionsColumn.AllowEdit = False
            'End If
            ''MsgBox(id_sample_purc_rec_det)
        Catch ex As Exception
            'no action
            'MsgBox("Galgal")
        End Try
    End Sub

    Private Sub GroupGeneralHeader_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupGeneralHeader.Paint

    End Sub
End Class