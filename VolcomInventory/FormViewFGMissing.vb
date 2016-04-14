Public Class FormViewFGMissing 
    Public action As String
    Public id_fg_missing As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_store_from As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_missing_det_list As New List(Of String)
    Dim id_comp_cat_store As String = "-1"
    Dim currency As String = "-1"
    Dim id_currency As String = "-1"

    Private Sub FormFGMissingDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        'get currency default
        Dim query_currency As String = "SELECT b.id_currency, b.currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        Dim data_cur As DataTable = execute_query(query_currency, -1, True, "", "", "", "")
        id_currency = data_cur.Rows(0)("id_currency").ToString
        currency = data_cur.Rows(0)("currency").ToString
        TxtCurrency.Text = currency

        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        GroupControlList.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        BtnBrowseContactFrom.Enabled = False

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
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
        check_but()
        allow_status()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
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

    'sub check_but
    Sub check_but()
       
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True

        'UPDATED 09 October 2014
        DEDueDate.Properties.ReadOnly = True
        SPDiscount.Properties.ReadOnly = True
        SPVat.Properties.ReadOnly = True
        DEStart.Properties.ReadOnly = True
        DEEnd.Properties.ReadOnly = True
        BtnAttachment.Enabled = True
        TxtFGMissingNumber.Focus()
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

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_cat = id_comp_cat_store
        FormPopUpContact.id_pop_up = "46"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub FormFGMissingDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
        Dim id_samplex As String = "0"

        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        'images
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.id_report = id_fg_missing
        FormReportMark.report_mark_type = "54"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
  
    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Dim id_designx As String = "0"
        Try
            id_designx = GVItemList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_designx, True)
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


    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        Try
            DEEnd.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = id_fg_missing
        FormDocumentUpload.report_mark_type = "54"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class