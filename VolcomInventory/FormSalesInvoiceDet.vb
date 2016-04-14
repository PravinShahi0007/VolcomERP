Public Class FormSalesInvoiceDet 
    Public action As String = ""
    Public id_sales_invoice As String = "0"
    Public id_store_contact_to As String = "-1"
    Public id_store_to As String = "-1"
    Public id_report_status As String
    Public id_sales_invoice_det_list As New List(Of String)
    Dim currency As String = "-1"
    Dim id_currency As String = "-1"
    Dim start_period As String = "-1"
    Dim end_period As String = "-1"
    Public id_so_type As String

    Private Sub FormSalesInvoiceDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get currency default
        Dim query_currency As String = "SELECT b.id_currency, b.currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        Dim data_cur As DataTable = execute_query(query_currency, -1, True, "", "", "", "")
        id_currency = data_cur.Rows(0)("id_currency").ToString
        currency = data_cur.Rows(0)("currency").ToString
        TxtCurrency.Text = currency

        viewReportStatus()
        viewSoType()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtDiscount.EditValue = 0.0
            TxtNetto.EditValue = 0.0
            TxtVatTot.EditValue = 0.0
            TxtTaxBase.EditValue = 0.0

            TxtSalesInvoiceNumber.Text = header_number_sales("8")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            Me.LETypeSO.ItemIndex = Me.LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", id_so_type)
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
            query += "SELECT a.sales_invoice_discount, a.sales_invoice_vat,a.id_so_type, a.id_report_status,a.id_sales_invoice, a.sales_invoice_discount, "
            query += "a.sales_invoice_discount, a.sales_invoice_end_period, a.sales_invoice_note, a.sales_invoice_number, a.sales_invoice_start_period, "
            query += "a.sales_invoice_total, a.sales_invoice_vat, b.so_type, c.report_status, "
            query += "CONCAT_WS(' - ', DATE_FORMAT(a.sales_invoice_start_period, '%d %M %Y') ,DATE_FORMAT(a.sales_invoice_end_period, '%d %M %Y')) AS sales_invoice_period, "
            query += "(e.comp_name) AS store_name_to, (e.id_comp) AS id_store, (e.address_primary) AS store_address_to, (e.comp_number) AS store_number_to, a.id_store_contact_to, "
            query += "DATE_FORMAT(a.sales_invoice_date, '%d %M %Y') AS sales_invoice_date, "
            query += "DATE_FORMAT(a.sales_invoice_due_date, '%d %M %Y') AS sales_invoice_due_date, "
            query += "DATE_FORMAT(a.sales_invoice_date, '%Y-%m-%d') AS sales_invoice_datex "
            query += "FROM tb_sales_invoice a "
            query += "INNER JOIN tb_lookup_so_type b ON b.id_so_type = a.id_so_type "
            query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
            query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_store_contact_to "
            query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
            query += "WHERE a.id_sales_invoice = '" + id_sales_invoice + "' "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sales_invoice_datex").ToString, 0)
            TxtSalesInvoiceNumber.Text = data.Rows(0)("sales_invoice_number").ToString
            MENote.Text = data.Rows(0)("sales_invoice_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            DEDueDate.EditValue = data.Rows(0)("sales_invoice_due_date")
            DEStart.EditValue = data.Rows(0)("sales_invoice_start_period")
            DEEnd.EditValue = data.Rows(0)("sales_invoice_end_period")
            SPDiscount.EditValue = data.Rows(0)("sales_invoice_discount")
            SPVat.EditValue = data.Rows(0)("sales_invoice_vat")

            start_period = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            id_so_type = LETypeSO.EditValue.ToString

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
            query = "CALL view_sales_pos_available('" + id_store_contact_to + "','" + start_period + "', '" + end_period + "', '" + LETypeSO.EditValue.ToString + "', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            query = "CALL view_sales_invoice('" + id_sales_invoice + "', '1') "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_invoice_det_list.Add(data.Rows(i)("id_sales_invoice_det").ToString)
            Next
            GCItemList.DataSource = data
        End If
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_sales_pos_detx As String = "0"
        Try
            id_sales_pos_detx = GVItemList.GetFocusedRowCellValue("id_sales_pos_det").ToString
        Catch ex As Exception

        End Try

        'MsgBox("main :" + id_productx)

        'Constraint Status
        If GVItemList.RowCount > 0 And id_sales_pos_detx <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "51", id_sales_invoice) Then
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
        TxtSalesInvoiceNumber.Focus()
    End Sub

    Sub getNetto()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("sales_invoice_det_amount").SummaryItem.SummaryValue.ToString)
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
            gross_total = Double.Parse(GVItemList.Columns("sales_invoice_det_amount").SummaryItem.SummaryValue.ToString)
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
        FormSalesInvoiceSingle.action_pop = "upd"
        FormSalesInvoiceSingle.id_store_contact_to_param = id_store_contact_to
        FormSalesInvoiceSingle.start_period_param = start_period
        FormSalesInvoiceSingle.end_period_param = end_period
        FormSalesInvoiceSingle.id_so_type_param = id_so_type
        FormSalesInvoiceSingle.id_sales_invoice_param = id_sales_invoice
        FormSalesInvoiceSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormSalesInvoiceSingle.id_sales_pos_det_edit = GVItemList.GetFocusedRowCellValue("id_sales_pos_det").ToString
        FormSalesInvoiceSingle.ShowDialog()
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
        FormSalesInvoiceSingle.action_pop = "ins"
        FormSalesInvoiceSingle.id_sales_invoice_param = id_sales_invoice
        FormSalesInvoiceSingle.id_store_contact_to_param = id_store_contact_to
        FormSalesInvoiceSingle.start_period_param = start_period
        FormSalesInvoiceSingle.end_period_param = end_period
        FormSalesInvoiceSingle.id_so_type_param = id_so_type
        FormSalesInvoiceSingle.ShowDialog()
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
            Dim sales_invoice_number As String = TxtSalesInvoiceNumber.Text
            Dim sales_invoice_note As String = MENote.Text
            Dim sales_invoice_due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_invoice_start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_invoice_end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim sales_invoice_discount As String = decimalSQL(SPDiscount.EditValue.ToString)
            Dim sales_invoice_vat As String = decimalSQL(SPVat.EditValue.ToString)
            Dim sales_invoice_total As String = decimalSQL(GVItemList.Columns("sales_invoice_det_amount").SummaryItem.SummaryValue.ToString)


            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main tbale
                        Dim query As String = "INSERT INTO tb_sales_invoice(id_store_contact_to, sales_invoice_number, sales_invoice_date, sales_invoice_due_date, sales_invoice_start_period, sales_invoice_end_period, sales_invoice_discount, sales_invoice_vat, sales_invoice_total, sales_invoice_note, id_so_type, id_report_status) "
                        query += "VALUES('" + id_store_contact_to + "', '" + sales_invoice_number + "', NOW(), '" + sales_invoice_due_date + "', '" + sales_invoice_start_period + "', '" + sales_invoice_end_period + "',  '" + sales_invoice_discount + "', '" + sales_invoice_vat + "', '" + sales_invoice_total + "', '" + sales_invoice_note + "', '" + id_so_type + "', '" + id_report_status + "') "
                        execute_non_query(query, True, "", "", "", "")

                        'Get Id 
                        query = "SELECT LAST_INSERT_ID() "
                        id_sales_invoice = execute_query(query, 0, True, "", "", "", "")

                        increase_inc_sales("8")

                        'insert who prepared
                        insert_who_prepared("51", id_sales_invoice, id_user)

                        'Detail 
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_invoice_det(id_sales_invoice, id_sales_pos_det, id_product, id_design_price, design_price, sales_invoice_det_qty) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)
                                Dim sales_invoice_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_invoice_det_qty").ToString)
                                Dim id_sales_pos_det As String = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString

                                If jum_ins_i > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sales_invoice + "', '" + id_sales_pos_det + "','" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_invoice_det_qty + "') "
                                jum_ins_i = jum_ins_i + 1
                            Catch ex As Exception
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        FormSalesInvoice.viewSalesInvoice()
                        FormSalesInvoice.GVSalesInvoice.FocusedRowHandle = find_row(FormSalesInvoice.GVSalesInvoice, "id_sales_invoice", id_sales_invoice)
                        Close()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim query As String = "UPDATE tb_sales_invoice SET sales_invoice_due_date = '" + sales_invoice_due_date + "', sales_invoice_discount = '" + sales_invoice_discount + "', sales_invoice_vat = '" + sales_invoice_vat + "', sales_invoice_total = '" + sales_invoice_total + "', sales_invoice_note = '" + sales_invoice_note + "' WHERE id_sales_invoice = '" + id_sales_invoice + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_invoice_det(id_sales_invoice, id_sales_pos_det, id_product, id_design_price, design_price, sales_invoice_det_qty) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_sales_invoice_det As String = GVItemList.GetRowCellValue(i, "id_sales_invoice_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)
                                Dim sales_invoice_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_invoice_det_qty").ToString)
                                Dim id_sales_pos_det As String = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString

                                If id_sales_invoice_det = "0" Then
                                    If jum_ins_i > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_sales_invoice + "', '" + id_sales_pos_det + "','" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_invoice_det_qty + "') "
                                    jum_ins_i = jum_ins_i + 1
                                Else
                                    Dim query_edit As String = "UPDATE tb_sales_invoice_det SET id_sales_pos_det = '" + id_sales_pos_det + "', id_product = '" + id_product + "', id_design_price = '" + id_design_price + "', design_price = '" + design_price + "', sales_invoice_det_qty = '" + sales_invoice_det_qty + "' WHERE id_sales_invoice_det = '" + id_sales_invoice_det + "' "
                                    execute_non_query(query_edit, True, "", "", "", "")
                                    id_sales_invoice_det_list.Remove(id_sales_invoice_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_sales_invoice_det_list.Count - 1)
                            Try
                                Dim querydel As String = "DELETE FROM tb_sales_invoice_det WHERE id_sales_invoice_det = '" + id_sales_invoice_det_list(k) + "' "
                                execute_non_query(querydel, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        FormSalesInvoice.viewSalesInvoice()
                        FormSalesInvoice.GVSalesInvoice.FocusedRowHandle = find_row(FormSalesInvoice.GVSalesInvoice, "id_sales_invoice", id_sales_invoice)
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
        FormReportMark.id_report = id_sales_invoice
        FormReportMark.report_mark_type = "51"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'ReportSalesInvoice.id_sales_invoice = id_sales_invoice
        'Dim Report As New ReportSalesInvoice()
        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesInvoiceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


End Class