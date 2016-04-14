Public Class ReportSalesInvoice
    Public Shared id_sales_pos As String = "-1"
    Dim currency As String = "-1"
    Dim id_currency As String = "-1"
    Dim discount_all As Decimal = 0.0
    Dim vat_all As Decimal = 0.0
    Dim gross_total_all As Decimal = 0.0
    Dim netto_all As Decimal = 0.0

    Dim discount_allx As Decimal = 0.0
    Dim vat_allx As Decimal = 0.0
    Dim gross_total_allx As Decimal = 0.0
    Dim netto_allx As Decimal = 0.0

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        'get currency default
        Dim query_currency As String = "SELECT b.id_currency, b.currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        Dim data_cur As DataTable = execute_query(query_currency, -1, True, "", "", "", "")
        id_currency = data_cur.Rows(0)("id_currency").ToString
        currency = data_cur.Rows(0)("currency").ToString

        Dim query As String = ""
        query += "SELECT a.id_so_type, a.id_report_status, a.id_sales_pos, a.sales_pos_date, a.sales_pos_note, "
        query += "a.sales_pos_number, (c.comp_name) AS store_name_from,c.npwp, "
        query += "a.id_store_contact_from, (c.comp_number) AS store_number_from, (c.address_primary) AS store_address_from,d.report_status, DATE_FORMAT(a.sales_pos_date,'%Y-%m-%d') AS sales_pos_datex, DATE_FORMAT(a.sales_pos_due_date,'%Y-%m-%d') AS sales_pos_due_datex, DATE_FORMAT(a.sales_pos_start_period,'%Y-%m-%d') AS sales_pos_start_periodx, DATE_FORMAT(a.sales_pos_end_period,'%Y-%m-%d') AS sales_pos_end_periodx, c.id_comp, "
        query += "a.sales_pos_due_date, a.sales_pos_discount, a.sales_pos_vat, e.so_type, a.sales_pos_total "
        query += "FROM tb_sales_pos a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_so_type e ON e.id_so_type = a.id_so_type "
        query += "WHERE a.id_sales_pos = '" + id_sales_pos + "' "
        query += "ORDER BY a.id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        LabelNumber.Text = data.Rows(0)("sales_pos_number").ToString
        LabelStore.Text = data.Rows(0)("store_number_from").ToString + " " + data.Rows(0)("store_name_from").ToString
        LabelStoreAddress.Text = data.Rows(0)("store_address_from").ToString
        LPODate.Text = view_date_from(data.Rows(0)("sales_pos_datex").ToString, 0)
        LabelNote.Text = data.Rows(0)("sales_pos_note").ToString
        LabelType.Text = data.Rows(0)("so_type").ToString
        LNPWP.Text = data.Rows(0)("npwp").ToString
        LabelDueDate.Text = view_date_from(data.Rows(0)("sales_pos_due_datex").ToString, 0)
        LabelPeriod.Text = view_date_from(data.Rows(0)("sales_pos_start_periodx").ToString, 0) + " - " + view_date_from(data.Rows(0)("sales_pos_end_periodx").ToString, 0)
        discount_all = data.Rows(0)("sales_pos_discount")
        vat_all = data.Rows(0)("sales_pos_vat")
        gross_total_all = data.Rows(0)("sales_pos_total")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_pos('" + id_sales_pos + "') "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCSalesInvoice.DataSource = data
        GVSalesInvoice.RefreshData()
    End Sub

    Private Sub GVSalesInvoice_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesInvoice.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        viewDetail()

    End Sub


    Private Sub ReportSalesInvoice_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("48", id_sales_pos, "2", "1", XrTable1)
    End Sub

    Sub getNetto()
        Dim gross_total As Double = 0.0
        'Try
        'gross_total = Double.Parse(GVSalesInvoice.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        'Catch ex As Exception
        'End Try
        gross_total = gross_total_all
        Dim netto As Double = gross_total - Decimal.Parse(discount_allx)
        netto_allx = netto
        CLabelNetto.Text = currency
        LabelNetto.Text = netto.ToString("n2")
        CLabelGross.Text = currency
        LabelGross.Text = gross_total.ToString("n2")
        netto_all = netto
        LabelSay.Text = ConvertCurrencyToEnglish(netto, id_currency)
    End Sub

    Sub getVat()
        Dim netto As Double = Double.Parse(netto_allx.ToString)
        Dim vat As Double = Double.Parse(vat_all.ToString)
        Dim vat_total As Double = (vat / (100 + vat)) * netto
        LabelVatHeader.Text = "VAT " + vat_all.ToString("f2") + "%"
        CLabelVAT.Text = currency
        LabelVAT.Text = vat_total.ToString("n2")
    End Sub

    Sub getDiscount()
        Dim gross_total As Double = 0.0
        'Try
        'gross_total = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        'Catch ex As Exception
        'End Try
        gross_total = gross_total_all

        Dim discount As Double = (Decimal.Parse(discount_all.ToString) / 100) * gross_total
        discount_allx = discount
        CLabelDiscount.Text = currency
        LabelDiscount.Text = discount.ToString("n2")
        LabelHeaderDiscount.Text = "Discount " + discount_all.ToString("f2") + "%"
    End Sub

    Sub getTaxBase()
        Dim netto As Double = Double.Parse(netto_allx.ToString)
        Dim vat As Double = Double.Parse(vat_all.ToString)
        Dim tax_base_total As Double = (100 / (100 + vat)) * netto
        CLabelTaxBase.Text = currency
        LabelTaxBase.Text = tax_base_total.ToString("n2")
    End Sub

    Sub calculate()
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

        LabelQty.Text = GVSalesInvoice.Columns("sales_pos_det_qty").SummaryText.ToString

        'default own company
        Dim query_own As String = "SELECT id_own_company FROM tb_opt"
        Dim id_comp As String = execute_query(query_own, 0, True, "", "", "", "")
        LabelCompName.Text = get_company_x(id_comp, "1")
        LabelAddress.Text = get_company_x(id_comp, "3") + " - " + get_company_contact_x(get_company_x(id_comp, "6"), "2")
        LabelNPWP.Text = get_company_x(id_comp, "5")

        'gross
        calculate()
    End Sub
End Class