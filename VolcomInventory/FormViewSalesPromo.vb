Public Class FormViewSalesPromo 
    Public id_sales_pos As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_report_status As String
    Public id_sales_pos_det_list As New List(Of String)
    Public id_comp As String = "-1"
    Public dt_stock_store As New DataTable

    Dim total_amount As Decimal = 0.0
    Dim currency As String = "-1"
    Dim id_comp_cat_store As String = "-1"
    Dim now_date As String = "-1"
    Dim last_end_period_select As String = "9999-12-01"
    Dim end_load As Boolean = False

    Private Sub FormViewSalesPromo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get currency default
        Dim query_currency As String = "SELECT b.id_currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        currency = execute_query(query_currency, 0, True, "", "", "", "")

        'get default store category for pick company
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        'view data
        viewReportStatus()
        viewSoType()

        GroupControlList.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True

        'query view based on edit id's
        Dim query As String = ""
        query += "SELECT a.id_so_type, a.id_report_status, a.id_sales_pos, a.sales_pos_date, a.sales_pos_note, "
        query += "a.sales_pos_number, (c.comp_name) AS store_name_from, "
        query += "a.id_store_contact_from, (c.comp_number) AS store_number_from, (c.address_primary) AS store_address_from,d.report_status, DATE_FORMAT(a.sales_pos_date,'%Y-%m-%d') AS sales_pos_datex, c.id_comp, "
        query += "a.sales_pos_due_date, a.sales_pos_start_period, a.sales_pos_end_period, a.sales_pos_discount, a.sales_pos_vat "
        query += "FROM tb_sales_pos a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
        query += "WHERE a.id_sales_pos = '" + id_sales_pos + "' "
        query += "ORDER BY a.id_sales_pos ASC "

        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("store_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("store_number_from").ToString
        MEAdrressCompFrom.Text = data.Rows(0)("store_address_from").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sales_pos_datex").ToString, 0)
        TxtVirtualPosNumber.Text = data.Rows(0)("sales_pos_number").ToString
        MENote.Text = data.Rows(0)("sales_pos_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
        id_comp = data.Rows(0)("id_comp").ToString

        ''updated 8 october 2014
        DEDueDate.EditValue = data.Rows(0)("sales_pos_due_date")
        DEStart.EditValue = data.Rows(0)("sales_pos_start_period")
        DEEnd.EditValue = data.Rows(0)("sales_pos_end_period")

        ''detail2
        viewDetail()
        viewStockStore()
        getNetto()
        getVat()
        getTaxBase()
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

    Sub viewDetail()
        Dim query As String = "CALL view_sales_pos('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
 
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sales_pos_det_list.Add(data.Rows(i)("id_sales_pos_det").ToString)
        Next
        GCItemList.DataSource = data
    End Sub

    Sub viewStockStore()

    End Sub

    Sub getNetto()
        Dim gross_total As Double = 0.0
        Try
            TxtNetto.EditValue = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        METotSay.Text = ConvertCurrencyToEnglish(TxtNetto.EditValue, currency)
    End Sub

    Sub getVat()
        Dim netto As Double = Double.Parse(TxtNetto.EditValue.ToString)
        Dim vat As Double = Double.Parse(SPVat.EditValue.ToString)
        Dim vat_total As Double = (vat / 100) * netto
        TxtVatTot.EditValue = vat_total
    End Sub

    Sub getTaxBase()
        Dim netto As Double = Double.Parse(TxtNetto.EditValue.ToString)
        Dim vat As Double = Double.Parse(SPVat.EditValue.ToString)
        Dim tax_base_total As Double = ((100 + vat) / 100) * netto
        TxtTaxBase.EditValue = tax_base_total
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
        FormDocumentUpload.report_mark_type = "76"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sales_pos
        FormReportMark.report_mark_type = "76"
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
End Class