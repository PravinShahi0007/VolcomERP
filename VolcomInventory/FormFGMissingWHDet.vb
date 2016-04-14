Public Class FormFGMissingWHDet
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

        If action = "ins" Then
            If id_pop_up = "1" Then
                TxtFGMissingNumber.Text = header_number_sales("24")
            End If

            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
        ElseIf action = "upd" Then
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
            viewStockStore()
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

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewStockStore()
        dt_stock_store.Clear()
        Dim end_period As String = "9999-12-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim query As String = ""
        dt_stock_store = execute_query(query, -1, True, "", "", "", "")
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
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception

        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_productx <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "77", id_fg_missing) Then
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True

            'UPDATED 09 October 2014
            DEDueDate.Properties.ReadOnly = False
            SPDiscount.Properties.ReadOnly = False
            SPVat.Properties.ReadOnly = False
            DEStart.Properties.ReadOnly = False
            DEEnd.Properties.ReadOnly = False
        Else
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False

            'UPDATED 09 October 2014
            DEDueDate.Properties.ReadOnly = True
            SPDiscount.Properties.ReadOnly = True
            SPVat.Properties.ReadOnly = True
            DEStart.Properties.ReadOnly = True
            DEEnd.Properties.ReadOnly = True
        End If

        If check_attach_report_status(id_report_status, "77", id_fg_missing) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtFGMissingNumber.Focus()
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

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        'FormPopUpContact.id_cat = id_comp_cat_store
        FormPopUpContact.id_pop_up = "46"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGMissingDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        'FormFGMissingSingle.action_pop = "ins"
        'FormFGMissingSingle.id_product = "0"
        'FormFGMissingSingle.id_comp = id_store_from
        'FormFGMissingSingle.id_fg_missing = id_fg_missing
        'FormFGMissingSingle.ShowDialog()

        FormFGAdjOutSingle.id_pop_up = "2"
        FormFGAdjOutSingle.action = "ins"
        FormFGAdjOutSingle.SLEWH.Enabled = True
        FormFGAdjOutSingle.SLELocator.Enabled = True
        FormFGAdjOutSingle.SLERack.Enabled = True
        FormFGAdjOutSingle.SLEDrawer.Enabled = True
        FormFGAdjOutSingle.allow_all_locator = True
        FormFGAdjOutSingle.allow_all_rack = True
        FormFGAdjOutSingle.allow_all_drawer = True
        FormFGAdjOutSingle.allow_all_wh = True
        FormFGAdjOutSingle.GroupControlInput.Visible = True
        If action = "ins" Then
            FormFGAdjOutSingle.id_adj_out_fg = "0"
        Else
            FormFGAdjOutSingle.id_adj_out_fg = "-1"
        End If
        FormFGAdjOutSingle.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        check_but()
        Dim id_samplex As String = "0"

        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        'images
        'pre_viewImages("2", PictureEdit1, GVItemList.GetFocusedRowCellValue("id_design").ToString, False)
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        FormFGMissingSingle.action_pop = "upd"
        FormFGMissingSingle.id_product = "0"
        Try
            FormFGMissingSingle.id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        FormFGMissingSingle.id_comp = id_store_from
        FormFGMissingSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormFGMissingSingle.id_product_edit = GVItemList.GetFocusedRowCellValue("id_product").ToString
        FormFGMissingSingle.product_code = GVItemList.GetFocusedRowCellValue("code").ToString
        FormFGMissingSingle.id_design_price_edit = GVItemList.GetFocusedRowCellValue("id_design_price")
        FormFGMissingSingle.qty_edit = GVItemList.GetFocusedRowCellValue("sales_pos_det_qty")
        FormFGMissingSingle.id_fg_missing = id_fg_missing
        FormFGMissingSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            check_but()
            getDiscount()
            getNetto()
            getVat()
            getTaxBase()
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_missing
        FormReportMark.report_mark_type = "77"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportFGMissingInvoice.id_fg_missing = id_fg_missing
        ReportFGMissingInvoice.dt = GCItemList.DataSource
        Dim Report As New ReportFGMissingInvoice()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GridView1)

        'Parse val
        Report.LabelNumber.Text = TxtFGMissingNumber.Text
        Report.LabelStore.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
        Report.LabelStoreAddress.Text = MEAdrressCompFrom.Text
        Report.LPODate.Text = DEForm.Text
        Report.LabelDueDate.Text = DEDueDate.Text
        Report.LabelPeriod.Text = DEStart.Text + "-" + DEEnd.Text
        Report.LabelQty.Text = GVItemList.Columns("sales_pos_det_qty").SummaryItem.SummaryValue.ToString
        Report.LabelGross.Text = GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString
        Report.LabelDiscount.Text = SPDiscount.Text.ToString
        Report.LabelNetto.Text = TxtNetto.Text.ToString
        Report.LabelVAT.Text = SPVat.Text.ToString
        Report.LabelTaxBase.Text = TxtTaxBase.Text
        Report.LabelCompName.Text = own_comp_name
        Report.LabelAddress.Text = own_comp_address
        Report.LabelNPWP.Text = own_comp_npwp
        Report.GridView1.OptionsPrint.PrintFooter = False

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()

        'Make sure valid data
        makeSafeGV(GVItemList)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()

        'cek periode
        Dim start_period_cek As String = "0000-01-01"
        Dim end_period_cek As String = "9999-12-01"
        Try
            start_period_cek = DEStart.EditValue.ToString
            end_period_cek = DEEnd.EditValue.ToString
        Catch ex As Exception
        End Try

        'check stock
        Dim valid_stock As Boolean = True
        Dim err_str As String = ""
        viewStockStore()
        Dim dt_check As DataTable = Nothing
        Dim dt_res As DataTable = Nothing
        For k As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            dt_check = Nothing
            dt_res = Nothing
            dt_check = dt_stock_store
            dt_check.DefaultView.RowFilter = "id_product = " + GVItemList.GetRowCellValue(k, "id_product").ToString + ""
            dt_res = dt_check.DefaultView.ToTable
            If GVItemList.GetRowCellValue(k, "sales_pos_det_qty") > dt_res.Rows("0")("jum_product") Then
                valid_stock = False
                err_str = dt_res.Rows("0")("code").ToString + "/" + dt_res.Rows("0")("name").ToString + "/Size " + dt_res.Rows("0")("size").ToString + ", cannto exceed " + dt_res.Rows("0")("jum_product").ToString
                Exit For
            End If
        Next
        Try
            dt_check.Dispose()
            dt_res.Dispose()
        Catch ex As Exception
        End Try

        If Not formIsValidInPanel(EPForm, PanelControlHeaderLeft) Or Not formIsValidInPanel(EPForm, PanelControlHeaderMiddle) Then
            errorInput()
        ElseIf GVItemList.RowCount <= 0 Then
            errorCustom("Item list can't blank ")
        ElseIf start_period_cek = "0000-01-01" Or end_period_cek = "9999-12-01" Then
            errorCustom("Please fill missing period")
        ElseIf Not valid_stock Then
            stopCustom(err_str.ToString)
        Else
            Dim fg_missing_number As String = TxtFGMissingNumber.Text
            Dim fg_missing_note As String = MENote.Text
            Dim id_report_status As String = LEReportStatus.EditValue

            'UPDATED 09  October 2014
            Dim fg_missing_due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim fg_missing_start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim fg_missing_end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim fg_missing_discount As String = decimalSQL(SPDiscount.EditValue.ToString)
            Dim fg_missing_vat As String = decimalSQL(SPVat.EditValue.ToString)
            Dim fg_missing_total As String = decimalSQL(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main table
                        Dim query As String = "INSERT INTO tb_sales_pos(id_store_contact_from, sales_pos_number, sales_pos_date, sales_pos_note, id_report_status, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_vat, sales_pos_total, id_memo_type, id_so_type) "
                        query += "VALUES('" + id_store_contact_from + "', '" + fg_missing_number + "', NOW(), '" + fg_missing_note + "', '" + id_report_status + "', '" + fg_missing_due_date + "', '" + fg_missing_start_period + "', '" + fg_missing_end_period + "', '" + fg_missing_discount + "', '" + fg_missing_vat + "', '" + fg_missing_total + "', '3', '1'); SELECT LAST_INSERT_ID(); "
                        id_fg_missing = execute_query(query, 0, True, "", "", "", "")

                        increase_inc_sales("24")

                        'insert who prepared
                        insert_who_prepared("77", id_fg_missing, id_user)

                        'Detail 
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, id_design_price_retail, design_price_retail, sales_pos_det_qty) VALUES "
                        End If
                        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                            Try
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim fg_missing_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                                'Dim fg_missing_det_note As String = GVItemList.GetRowCellValue(i, "fg_missing_det_note").ToString

                                If jum_ins_i > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_fg_missing + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + id_design_price + "', '" + design_price + "', '" + fg_missing_det_qty + "') "
                                jum_ins_i = jum_ins_i + 1
                            Catch ex As Exception
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        FormFGMissing.viewFGMissing()
                        FormFGMissing.GVFGMissing.FocusedRowHandle = find_row(FormFGMissing.GVFGMissing, "id_sales_pos", id_fg_missing)
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
                        Dim query As String = "UPDATE tb_sales_pos SET id_store_contact_from ='" + id_store_contact_from + "', sales_pos_number = '" + fg_missing_number + "', sales_pos_note='" + fg_missing_note + "', sales_pos_due_date='" + fg_missing_due_date + "', sales_pos_start_period = '" + fg_missing_start_period + "', sales_pos_end_period='" + fg_missing_end_period + "', sales_pos_discount='" + fg_missing_discount + "', sales_pos_vat='" + fg_missing_vat + "', sales_pos_total='" + fg_missing_total + "' WHERE id_sales_pos ='" + id_fg_missing + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, id_design_price_retail, design_price_retail, sales_pos_det_qty) VALUES "
                        End If
                        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                            Try
                                Dim id_fg_missing_det As String = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim fg_missing_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                                'Dim fg_missing_det_note As String = GVItemList.GetRowCellValue(i, "fg_missing_det_note").ToString

                                If id_fg_missing_det = "0" Then
                                    If jum_ins_i > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_fg_missing + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + id_design_price + "', '" + design_price + "', '" + fg_missing_det_qty + "') "
                                    jum_ins_i = jum_ins_i + 1
                                Else
                                    Dim query_edit As String = "UPDATE tb_sales_pos_det SET id_product = '" + id_product + "', id_design_price='" + id_design_price + "', design_price = '" + design_price + "', id_design_price_retail='" + id_design_price + "', design_price_retail='" + design_price + "', sales_pos_det_qty = '" + fg_missing_det_qty + "' WHERE id_sales_pos_det = '" + id_fg_missing_det + "' "
                                    execute_non_query(query_edit, True, "", "", "", "")
                                    id_fg_missing_det_list.Remove(id_fg_missing_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_fg_missing_det_list.Count - 1)
                            Try
                                Dim querydel As String = "DELETE FROM tb_sales_pos_det WHERE id_sales_pos_det = '" + id_fg_missing_det_list(k) + "' "
                                execute_non_query(querydel, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        FormFGMissing.viewFGMissing()
                        FormFGMissing.GVFGMissing.FocusedRowHandle = find_row(FormFGMissing.GVFGMissing, "id_sales_pos", id_fg_missing)
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

    'Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    pre_viewImages("2", PictureEdit1, GVItemList.GetFocusedRowCellValue("id_design").ToString, True)
    'End Sub

    'Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
    '    ReportFGMissing.id_fg_missing = id_fg_missing
    '    Dim Report As New ReportFGMissing()
    '    ' Show the report's preview. 
    '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
    '    Tool.ShowPreview()
    'End Sub

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

    Private Sub DEDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEDueDate.Validating
        EP_DE_cant_blank(EPForm, DEDueDate)
    End Sub

    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        Try
            DEEnd.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_fg_missing
        FormDocumentUpload.report_mark_type = "77"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImport.Click
        Cursor = Cursors.WaitCursor
        Dim start_period As String = "1945-01-01"
        Try
            start_period = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim end_period As String = "9999-12-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        If start_period = "1945-01-01" Or end_period = "9999-12-01" Then
            stopCustom("Please fill start & end period !")
        Else
            viewStockStore()
            FormImportExcel.id_pop_up = "7"
            FormImportExcel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub
End Class