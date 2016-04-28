Public Class FormFGMissingInvoiceDet 
    Public action As String = ""
    Public id_fg_missing_invoice As String = "0"
    Public id_store_contact_to As String = "-1"
    Public id_store_to As String = "-1"
    Public id_report_status As String
    Public id_fg_missing_invoice_det_list As New List(Of String)
    Dim currency As String = "-1"
    Dim id_currency As String = "-1"
    Dim start_period As String = "-1"
    Dim end_period As String = "-1"

    Private Sub FormFGMissingInvoiceDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get currency default
        Dim query_currency As String = "SELECT b.id_currency, b.currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        Dim data_cur As DataTable = execute_query(query_currency, -1, True, "", "", "", "")
        id_currency = data_cur.Rows(0)("id_currency").ToString
        currency = data_cur.Rows(0)("currency").ToString
        TxtCurrency.Text = currency

        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub


    Sub actionLoad()
        If action = "ins" Then
            TxtDiscount.EditValue = 0.0
            TxtNetto.EditValue = 0.0
            TxtVatTot.EditValue = 0.0
            TxtTaxBase.EditValue = 0.0

            TxtNumber.Text = header_number_sales("11")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            start_period = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")

            viewDetail()
            check_but()
            getDiscount()
            getNetto()
            getVat()
            getTaxBase()
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True

            ''query view based on edit id's
            Dim query As String = ""
            query += "SELECT a.fg_missing_invoice_discount, a.fg_missing_invoice_vat, a.id_report_status,a.id_fg_missing_invoice, a.fg_missing_invoice_discount, "
            query += "a.fg_missing_invoice_end_period, a.fg_missing_invoice_note, a.fg_missing_invoice_number, a.fg_missing_invoice_start_period, "
            query += "a.fg_missing_invoice_total, a.fg_missing_invoice_vat, c.report_status, "
            query += "CONCAT_WS(' - ', DATE_FORMAT(a.fg_missing_invoice_start_period, '%d %M %Y') ,DATE_FORMAT(a.fg_missing_invoice_end_period, '%d %M %Y')) AS fg_missing_invoice_period, "
            query += "(e.comp_name) AS store_name_to, (e.id_comp) AS id_store_to, (e.address_primary) AS store_address_to, (e.comp_number) AS store_number_to, a.id_store_contact_to, "
            query += "DATE_FORMAT(a.fg_missing_invoice_date, '%d %M %Y') AS fg_missing_invoice_date, "
            query += "DATE_FORMAT(a.fg_missing_invoice_due_date, '%d %M %Y') AS fg_missing_invoice_due_date, "
            query += "DATE_FORMAT(a.fg_missing_invoice_date, '%Y-%m-%d') AS fg_missing_invoice_datex "
            query += "FROM tb_fg_missing_invoice a "
            query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_store_contact_to "
            query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
            query += "WHERE a.id_fg_missing_invoice = '" + id_fg_missing_invoice + "' "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            id_store_to = data.Rows(0)("id_store_to").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_missing_invoice_datex").ToString, 0)
            TxtNumber.Text = data.Rows(0)("fg_missing_invoice_number").ToString
            MENote.Text = data.Rows(0)("fg_missing_invoice_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            DEDueDate.EditValue = data.Rows(0)("fg_missing_invoice_due_date")
            DEStart.EditValue = data.Rows(0)("fg_missing_invoice_start_period")
            DEEnd.EditValue = data.Rows(0)("fg_missing_invoice_end_period")
            SPDiscount.EditValue = data.Rows(0)("fg_missing_invoice_discount")
            SPVat.EditValue = data.Rows(0)("fg_missing_invoice_vat")

            start_period = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")

            'detail2
            viewDetail()
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            getDiscount()
            getNetto()
            getVat()
            getTaxBase()
            check_but()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        If action = "ins" Then
            'action
            query = "CALL view_fg_missing_available('" + id_store_contact_to + "','" + start_period + "', '" + end_period + "', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            query = "CALL view_fg_missing_invoice('" + id_fg_missing_invoice + "', '1') "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_missing_invoice_det_list.Add(data.Rows(i)("id_fg_missing_invoice_det").ToString)
            Next
            GCItemList.DataSource = data
        End If
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_fg_missing_detx As String = "0"
        Try
            id_fg_missing_detx = GVItemList.GetFocusedRowCellValue("id_fg_missing_det").ToString
        Catch ex As Exception

        End Try

        'MsgBox("main :" + id_productx)

        'Constraint Status
        If GVItemList.RowCount > 0 And id_fg_missing_detx <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "55", id_fg_missing_invoice) Then
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            DEDueDate.Properties.ReadOnly = False
            SPDiscount.Properties.ReadOnly = False
            SPVat.Properties.ReadOnly = False
        Else
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            DEDueDate.Properties.ReadOnly = True
            SPDiscount.Properties.ReadOnly = True
            SPVat.Properties.ReadOnly = True
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Sub getNetto()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("fg_missing_invoice_det_amount").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        Dim netto As Double = gross_total - Decimal.Parse(TxtDiscount.EditValue.ToString)
        TxtNetto.EditValue = netto
        MESay.Text = ConvertCurrencyToEnglish(netto, id_currency)
    End Sub

    Sub getVat()
        Dim netto As Double = Double.Parse(TxtNetto.EditValue.ToString)
        Dim vat As Double = Double.Parse(SPVat.EditValue.ToString)
        Dim vat_total As Double = (vat / (100 + vat)) * netto
        TxtVatTot.EditValue = vat_total
    End Sub

    Sub getDiscount()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("fg_missing_invoice_det_amount").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        Dim discount As Double = (Decimal.Parse(SPDiscount.EditValue.ToString) / 100) * gross_total
        TxtDiscount.EditValue = discount
    End Sub

    Sub getTaxBase()
        Dim netto As Double = Double.Parse(TxtNetto.EditValue.ToString)
        Dim vat As Double = Double.Parse(SPVat.EditValue.ToString)
        Dim tax_base_total As Double = (100 / (100 + vat)) * netto
        TxtTaxBase.EditValue = tax_base_total
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged

    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            getDiscount()
            getNetto()
            getVat()
            getTaxBase()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormFGMissingInvoiceSingle.action_pop = "upd"
        FormFGMissingInvoiceSingle.id_store_contact_to_param = id_store_contact_to
        FormFGMissingInvoiceSingle.start_period_param = start_period
        FormFGMissingInvoiceSingle.end_period_param = end_period
        FormFGMissingInvoiceSingle.id_fg_missing_invoice_param = id_fg_missing_invoice
        FormFGMissingInvoiceSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormFGMissingInvoiceSingle.id_fg_missing_det_edit = GVItemList.GetFocusedRowCellValue("id_fg_missing_det").ToString
        FormFGMissingInvoiceSingle.ShowDialog()
    End Sub

    Private Sub SPDiscount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPDiscount.EditValueChanged
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
    End Sub

    Private Sub SPVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPVat.EditValueChanged
        getVat()
        getTaxBase()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormFGMissingInvoiceSingle.action_pop = "ins"
        FormFGMissingInvoiceSingle.id_fg_missing_invoice_param = id_fg_missing_invoice
        FormFGMissingInvoiceSingle.id_store_contact_to_param = id_store_contact_to
        FormFGMissingInvoiceSingle.start_period_param = start_period
        FormFGMissingInvoiceSingle.end_period_param = end_period
        FormFGMissingInvoiceSingle.ShowDialog()
    End Sub

    Private Sub DEDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEDueDate.Validating
        EP_DE_cant_blank(EPForm, DEDueDate)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVItemList.RowCount <= 0 Then
            errorCustom("Item list can't blank")
        Else
            Dim fg_missing_invoice_number As String = TxtNumber.Text
            Dim fg_missing_invoice_note As String = MENote.Text
            Dim fg_missing_invoice_due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim fg_missing_invoice_start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim fg_missing_invoice_end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim fg_missing_invoice_discount As String = decimalSQL(SPDiscount.EditValue.ToString)
            Dim fg_missing_invoice_vat As String = decimalSQL(SPVat.EditValue.ToString)
            Dim fg_missing_invoice_total As String = decimalSQL(GVItemList.Columns("fg_missing_invoice_det_amount").SummaryItem.SummaryValue.ToString)


            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main tbale
                        Dim query As String = "INSERT INTO tb_fg_missing_invoice(id_store_contact_to, fg_missing_invoice_number, fg_missing_invoice_date, fg_missing_invoice_due_date, fg_missing_invoice_start_period, fg_missing_invoice_end_period, fg_missing_invoice_discount, fg_missing_invoice_vat, fg_missing_invoice_total, fg_missing_invoice_note, id_report_status) "
                        query += "VALUES('" + id_store_contact_to + "', '" + fg_missing_invoice_number + "', NOW(), '" + fg_missing_invoice_due_date + "', '" + fg_missing_invoice_start_period + "', '" + fg_missing_invoice_end_period + "',  '" + fg_missing_invoice_discount + "', '" + fg_missing_invoice_vat + "', '" + fg_missing_invoice_total + "', '" + fg_missing_invoice_note + "', '" + id_report_status + "');SELECT LAST_INSERT_ID(); "

                        id_fg_missing_invoice = execute_query(query, 0, True, "", "", "", "")

                        increase_inc_sales("11")

                        'insert who prepared
                        insert_who_prepared("55", id_fg_missing_invoice, id_user)

                        'Detail 
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_fg_missing_invoice_det(id_fg_missing_invoice, id_fg_missing_det, id_product, id_design_price, design_price, fg_missing_invoice_det_qty) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim fg_missing_invoice_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "fg_missing_invoice_det_qty").ToString)
                                Dim id_fg_missing_det As String = GVItemList.GetRowCellValue(i, "id_fg_missing_det").ToString

                                If jum_ins_i > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_fg_missing_invoice + "', '" + id_fg_missing_det + "','" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + fg_missing_invoice_det_qty + "') "
                                jum_ins_i = jum_ins_i + 1
                            Catch ex As Exception
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        FormFGMissingInvoice.viewFGMissingInvoice()
                        FormFGMissingInvoice.GVFGMissingInvoice.FocusedRowHandle = find_row(FormFGMissingInvoice.GVFGMissingInvoice, "id_fg_missing_invoice", id_fg_missing_invoice)
                        Close()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim query As String = "UPDATE tb_fg_missing_invoice SET fg_missing_invoice_due_date = '" + fg_missing_invoice_due_date + "', fg_missing_invoice_discount = '" + fg_missing_invoice_discount + "', fg_missing_invoice_vat = '" + fg_missing_invoice_vat + "', fg_missing_invoice_total = '" + fg_missing_invoice_total + "', fg_missing_invoice_note = '" + fg_missing_invoice_note + "' WHERE id_fg_missing_invoice = '" + id_fg_missing_invoice + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_fg_missing_invoice_det(id_fg_missing_invoice, id_fg_missing_det, id_product, id_design_price, design_price, fg_missing_invoice_det_qty) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_fg_missing_invoice_det As String = GVItemList.GetRowCellValue(i, "id_fg_missing_invoice_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim fg_missing_invoice_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "fg_missing_invoice_det_qty").ToString)
                                Dim id_fg_missing_det As String = GVItemList.GetRowCellValue(i, "id_fg_missing_det").ToString

                                If id_fg_missing_invoice_det = "0" Then
                                    If jum_ins_i > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_fg_missing_invoice + "', '" + id_fg_missing_det + "','" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + fg_missing_invoice_det_qty + "') "
                                    jum_ins_i = jum_ins_i + 1
                                Else
                                    Dim query_edit As String = "UPDATE tb_fg_missing_invoice_det SET id_fg_missing_det = '" + id_fg_missing_det + "', id_product = '" + id_product + "', id_design_price = '" + id_design_price + "', design_price = '" + design_price + "', fg_missing_invoice_det_qty = '" + fg_missing_invoice_det_qty + "' WHERE id_fg_missing_invoice_det = '" + id_fg_missing_invoice_det + "' "
                                    execute_non_query(query_edit, True, "", "", "", "")
                                    id_fg_missing_invoice_det_list.Remove(id_fg_missing_invoice_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_fg_missing_invoice_det_list.Count - 1)
                            Try
                                Dim querydel As String = "DELETE FROM tb_fg_missing_invoice_det WHERE id_fg_missing_invoice_det = '" + id_fg_missing_invoice_det_list(k) + "' "
                                execute_non_query(querydel, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        FormFGMissingInvoice.viewFGMissingInvoice()
                        FormFGMissingInvoice.GVFGMissingInvoice.FocusedRowHandle = find_row(FormFGMissingInvoice.GVFGMissingInvoice, "id_fg_missing_invoice", id_fg_missing_invoice)
                        Close()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_missing_invoice
        FormReportMark.report_mark_type = "55"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'ReportFGMissingInvoice.id_fg_missing_invoice = id_fg_missing_invoice
        'Dim Report As New ReportFGMissingInvoice()
        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGMissingInvoiceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        
    End Sub

End Class