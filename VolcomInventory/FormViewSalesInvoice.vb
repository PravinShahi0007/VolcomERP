Public Class FormViewSalesInvoice 
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
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        query = "CALL view_sales_invoice('" + id_sales_invoice + "', '2') "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sales_invoice_det_list.Add(data.Rows(i)("id_sales_invoice_det").ToString)
        Next
        GCItemList.DataSource = data
    End Sub

    'sub check_but
    Sub check_but()
        'Dim id_sales_pos_detx As String = "0"
        'Try
        '    id_sales_pos_detx = GVItemList.GetFocusedRowCellValue("id_sales_pos_det").ToString
        'Catch ex As Exception

        'End Try

        ''MsgBox("main :" + id_productx)

        ''Constraint Status
        'If GVItemList.RowCount > 0 And id_sales_pos_detx <> "0" Then
        '    BtnEdit.Enabled = True
        '    BtnDel.Enabled = True
        'Else
        '    BtnEdit.Enabled = False
        '    BtnDel.Enabled = False
        'End If
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        DEDueDate.Properties.ReadOnly = True
        SPDiscount.Properties.ReadOnly = True
        SPVat.Properties.ReadOnly = True
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

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.id_report = id_sales_invoice
        FormReportMark.report_mark_type = "51"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Private Sub FormSalesInvoiceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class