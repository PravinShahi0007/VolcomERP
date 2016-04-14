Public Class FormViewFGMissingCreditNoteStore 
    Public action As String = "-1"
    Public id_sales_pos As String = "-1"
    Public id_report_status As String = "-1"
    Public currency As String = "-1"
    Public id_sales_pos_det_list As New List(Of String)
    Public id_sales_pos_ref As String = "-1"
    Public id_so_type As String = "-1"
    Public id_store_contact_from As String = "-1"
    Dim total_amount As Decimal = 0.0
    Dim own_comp_name As String = ""
    Dim own_comp_address As String = ""
    Dim own_comp_npwp As String = ""

    Private Sub FormViewFGMissingCreditNoteStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get currency default
        Dim query_currency As String = "SELECT b.id_currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        currency = execute_query(query_currency, 0, True, "", "", "", "")

        'default own company
        Dim query_own As String = "SELECT id_own_company FROM tb_opt"
        Dim id_comp As String = execute_query(query_own, 0, True, "", "", "", "")
        own_comp_name = get_company_x(id_comp, "1")
        own_comp_address = get_company_x(id_comp, "3") + " - " + get_company_contact_x(get_company_x(id_comp, "6"), "2")
        own_comp_npwp = get_company_x(id_comp, "5")

        'view data
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormViewFGMissingCreditNoteStore_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        GroupControlList.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True

        'query view based on edit id's
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMain("AND a.id_sales_pos=''" + id_sales_pos + "'' ", "1")
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_sales_pos_ref = data.Rows(0)("id_sales_pos_ref").ToString
        id_so_type = data.Rows(0)("id_so_type").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
        TxtInvoice.Text = data.Rows(0)("sales_pos_ref_number").ToString
        TxtNameCompFrom.Text = data.Rows(0)("store_name_from").ToString
        MEAdrressCompFrom.Text = data.Rows(0)("store_address_from").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sales_pos_datex").ToString, 0)
        TxtVirtualPosNumber.Text = data.Rows(0)("sales_pos_number").ToString
        MENote.Text = data.Rows(0)("sales_pos_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtSalesType.Text = data.Rows(0)("so_type").ToString
        TxtInvStart.Text = data.Rows(0)("sales_pos_ref_start_periodx").ToString
        TxtInvEnd.Text = data.Rows(0)("sales_pos_ref_end_periodx").ToString

        DEDueDate.EditValue = data.Rows(0)("sales_pos_due_date")
        DEStart.EditValue = data.Rows(0)("sales_pos_start_period")
        DEEnd.EditValue = data.Rows(0)("sales_pos_end_period")
        SPDiscount.EditValue = data.Rows(0)("sales_pos_discount")
        SPVat.EditValue = data.Rows(0)("sales_pos_vat")


        'detail2
        viewDetail()
        check_but()
        allow_status()
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryDetail(id_sales_pos)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_pos_det_list.Add(data.Rows(i)("id_sales_pos_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Sub check_but()
       
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        DEDueDate.Properties.ReadOnly = True
        DEStart.Properties.ReadOnly = True
        DEEnd.Properties.ReadOnly = True
        BtnAttachment.Enabled = True
        TxtVirtualPosNumber.Focus()
    End Sub

    Sub getNetto()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        Dim netto As Double = gross_total - Decimal.Parse(TxtDiscount.EditValue.ToString)
        TxtNetto.EditValue = netto
        METotSay.Text = ConvertCurrencyToEnglish(netto, currency)
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
            gross_total = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
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

    

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sales_pos
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "67"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    
    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_pos
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "67"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        Dim dt_str As Date = DEStart.EditValue
        DEEnd.Properties.MinValue = dt_str
    End Sub
End Class