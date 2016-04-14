Public Class FormViewFGMissingWH 
    Public action As String
    Public id_fg_missing As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_store_from As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_missing_det_list As New List(Of String)
    Dim id_comp_cat_store As String = "-1"
    Dim currency As String = "-1"
    Dim id_currency As String = "-1"
    Dim own_comp_name As String = "-1"
    Dim own_comp_address As String = "-1"
    Dim own_comp_npwp As String = "-1"

    'update 8 September 2015
    Public id_pop_up As String = "-1"

    'update 15 januari 2015
    Public dt_stock_store As New DataTable
    Dim last_end_period_select As String = "9999-12-01"
    Dim end_load As Boolean = False
    Private Sub FormFGMissingDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        'get currency default
        Dim query_currency As String = "SELECT b.id_currency, b.currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        Dim data_cur As DataTable = execute_query(query_currency, -1, True, "", "", "", "")
        id_currency = data_cur.Rows(0)("id_currency").ToString
        currency = data_cur.Rows(0)("currency").ToString
        TxtCurrency.Text = currency

        'default own company
        Dim query_own As String = "SELECT id_own_company FROM tb_opt"
        Dim id_comp As String = execute_query(query_own, 0, True, "", "", "", "")
        own_comp_name = get_company_x(id_comp, "1")
        own_comp_address = get_company_x(id_comp, "3") + " - " + get_company_contact_x(get_company_x(id_comp, "6"), "2")
        own_comp_npwp = get_company_x(id_comp, "5")

        DEStart.DateTime = Now
        DEEnd.DateTime = Now
        DEDueDate.DateTime = Now

        viewReportStatus()
        actionLoad()
    End Sub
    Sub actionLoad()
        'UPDATED 09 Oktober 2014
        TxtDiscount.EditValue = 0.0
        TxtNetto.EditValue = 0.0
        TxtVatTot.EditValue = 0.0
        TxtTaxBase.EditValue = 0.0
        GroupControlList.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True

        ''query view based on edit id's
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMain("AND a.id_sales_pos=''" + id_fg_missing + "'' ", "1")

        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("store_name_from_single").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("store_number_from_single").ToString
        MEAdrressCompFrom.Text = data.Rows(0)("store_address_from").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sales_pos_datex").ToString, 0)
        TxtFGMissingNumber.Text = data.Rows(0)("sales_pos_number").ToString
        MENote.Text = data.Rows(0)("sales_pos_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_store_from = data.Rows(0)("id_store_from").ToString

        'UPDATED 11 December 2014
        DEDueDate.EditValue = data.Rows(0)("sales_pos_due_date")
        DEStart.EditValue = data.Rows(0)("sales_pos_start_period")
        DEEnd.EditValue = data.Rows(0)("sales_pos_end_period")
        SPDiscount.EditValue = data.Rows(0)("sales_pos_discount")
        SPVat.EditValue = data.Rows(0)("sales_pos_vat")

        'detail2
        viewDetail()
        viewStockStore()
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
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

    Sub viewStockStore()

    End Sub

    Sub viewDetail()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryDetail(id_fg_missing)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_fg_missing_det_list.Add(data.Rows(i)("id_sales_pos_det").ToString)
        Next
        GCItemList.DataSource = data
    End Sub
    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub getNetto()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
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
    Private Sub FormFGMissingDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_missing
        FormReportMark.report_mark_type = "77"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class