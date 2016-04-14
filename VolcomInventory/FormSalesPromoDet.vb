Public Class FormSalesPromoDet
    Public action As String
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

    Public id_wh_locator As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_drawer As String = "-1"

    Private Sub FormSalesPOSDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get currency default
        Dim query_currency As String = "SELECT b.id_currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        currency = execute_query(query_currency, 0, True, "", "", "", "")

        'get default store category for pick company
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        'view data
        viewReportStatus()
        viewSoType()
        actionLoad()
        end_load = True
    End Sub

    Sub actionLoad()
        TxtNetto.EditValue = 0.0
        TxtVatTot.EditValue = 0.0
        TxtTaxBase.EditValue = 0.0

        If action = "ins" Then
            TxtVirtualPosNumber.Text = header_number_sales("22")
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            GCItemList.DataSource = Nothing
            '
            DEStart.DateTime = Now()
            DEEnd.DateTime = Now()
            DEDueDate.DateTime = Now()

        ElseIf action = "upd" Then
            GroupControlList.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactFrom.Enabled = False

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
            SPVat.EditValue = data.Rows(0)("sales_pos_vat")
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
            check_but()
            allow_status()
            getNetto()
            getVat()
            getTaxBase()
        End If
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
        If action = "ins" Then
            'action
        ElseIf action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_pos_det_list.Add(data.Rows(i)("id_sales_pos_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Sub viewStockStore()
        dt_stock_store.Clear()
        Dim end_period As String = "9999-12-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '" + end_period + "') "
        dt_stock_store = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'Make sure valid data
        makeSafeGV(GVItemList)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        getNetto()
        getVat()
        getTaxBase()

        'cek periode
        Dim start_period_cek As String = "0000-01-01"
        Dim end_period_cek As String = "9999-12-01"
        Dim due_date_cek As String = "-1"
        Try
            start_period_cek = DEStart.EditValue.ToString
        Catch ex As Exception
        End Try
        Try
            end_period_cek = DEEnd.EditValue.ToString
        Catch ex As Exception
        End Try
        Try
            due_date_cek = DEDueDate.EditValue.ToString
        Catch ex As Exception
        End Try

        'check stock
        Dim valid_stock As Boolean = True
        Dim err_str As String = ""
        If action = "ins" Then
            viewStockStore()
            Dim dt_check As DataTable = Nothing
            Dim dt_res As DataTable = Nothing
            For k As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                dt_check = Nothing
                dt_res = Nothing
                dt_check = dt_stock_store
                dt_check.DefaultView.RowFilter = "id_product = " + GVItemList.GetRowCellValue(k, "id_product").ToString + ""
                dt_res = dt_check.DefaultView.ToTable
                If GVItemList.GetRowCellValue(k, "sales_pos_det_qty") > dt_res.Rows("0")("qty_all_product") Then
                    valid_stock = False
                    err_str = dt_res.Rows("0")("code").ToString + "/" + dt_res.Rows("0")("name").ToString + "/Size " + dt_res.Rows("0")("size").ToString + ", cannto exceed " + dt_res.Rows("0")("qty_all_product").ToString
                    Exit For
                End If
            Next
            Try
                dt_check.Dispose()
                dt_res.Dispose()
            Catch ex As Exception
            End Try
        End If


        ValidateChildren()
        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopMiddle) Then
            errorInput()
        ElseIf GVItemList.RowCount <= 0 Then
            stopCustom("Item list can't blank ")
        ElseIf start_period_cek = "0000-01-01" Or end_period_cek = "9999-12-01" Or due_date_cek = "-1" Then
            stopCustom("Please fill period and due date!")
        ElseIf Not valid_stock Then
            stopCustom(err_str.ToString)
        Else
            Dim sales_pos_number As String = TxtVirtualPosNumber.Text
            Dim sales_pos_note As String = MENote.Text
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_so_type As String = LETypeSO.EditValue
            Dim sales_pos_due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_vat As String = decimalSQL(SPVat.EditValue.ToString)
            total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)


            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main tbale
                        Dim query As String = "INSERT INTO tb_sales_pos(id_store_contact_from, sales_pos_number, sales_pos_date, sales_pos_note, id_report_status, id_so_type, sales_pos_total, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_vat,id_memo_type) "
                        query += "VALUES('" + id_store_contact_from + "', '" + sales_pos_number + "', NOW(), '" + sales_pos_note + "', '" + id_report_status + "', '" + id_so_type + "', '" + decimalSQL(total_amount.ToString) + "', '" + sales_pos_due_date + "', '" + sales_pos_start_period + "', '" + sales_pos_end_period + "', '0', '" + sales_pos_vat + "','5'); SELECT LAST_INSERT_ID(); "
                        id_sales_pos = execute_query(query, 0, True, "", "", "", "")

                        increase_inc_sales("22")

                        'insert who prepared
                        insert_who_prepared("76", id_sales_pos, id_user)

                        'Detail 
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim sales_pos_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                                'Dim sales_pos_det_note As String = GVItemList.GetRowCellValue(i, "sales_return_order_det_note").ToString
                                Dim id_design_price_retail As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                                Dim design_price_retail As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)

                                If jum_ins_i > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sales_pos + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_pos_det_qty + "', '" + id_design_price_retail + "', '" + design_price_retail + "') "
                                jum_ins_i = jum_ins_i + 1
                            Catch ex As Exception

                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'reserved stock
                        Dim rsv_stock As ClassSalesInv = New ClassSalesInv()
                        rsv_stock.reservedStock(id_sales_pos, "76")

                        FormSalesPromo.viewSalesPOS()
                        FormSalesPromo.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPromo.GVSalesPOS, "id_sales_pos", id_sales_pos)
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
                        Dim query As String = "UPDATE tb_sales_pos SET id_store_contact_from ='" + id_store_contact_from + "', sales_pos_number = '" + sales_pos_number + "', sales_pos_note='" + sales_pos_note + "', id_so_type = '" + id_so_type + "', sales_pos_total = '" + decimalSQL(total_amount.ToString) + "', sales_pos_due_date='" + sales_pos_due_date + "', sales_pos_start_period='" + sales_pos_start_period + "', sales_pos_end_period = '" + sales_pos_end_period + "', sales_pos_discount='0', sales_pos_vat='" + sales_pos_vat + "' WHERE id_sales_pos ='" + id_sales_pos + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_sales_pos_det As String = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim sales_pos_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                                'Dim sales_pos_det_note As String = GVItemList.GetRowCellValue(i, "sales_pos_det_note").ToString
                                Dim id_design_price_retail As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                                Dim design_price_retail As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)

                                If id_sales_pos_det = "0" Then
                                    If jum_ins_i > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_sales_pos + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_pos_det_qty + "', '" + id_design_price_retail + "', '" + design_price_retail + "') "
                                    jum_ins_i = jum_ins_i + 1
                                Else
                                    Dim query_edit As String = "UPDATE tb_sales_pos_det SET id_product = '" + id_product + "', id_design_price='" + id_design_price + "', design_price = '" + design_price + "', sales_pos_det_qty = '" + sales_pos_det_qty + "', id_design_price_retail = '" + id_design_price_retail + "', design_price_retail = '" + design_price_retail + "'  WHERE id_sales_pos_det = '" + id_sales_pos_det + "' "
                                    execute_non_query(query_edit, True, "", "", "", "")
                                    id_sales_pos_det_list.Remove(id_sales_pos_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_sales_pos_det_list.Count - 1)
                            Try
                                Dim querydel As String = "DELETE FROM tb_sales_pos_det WHERE id_sales_pos_det = '" + id_sales_pos_det_list(k) + "' "
                                execute_non_query(querydel, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        FormSalesPromo.viewSalesPOS()
                        FormSalesPromo.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPromo.GVSalesPOS, "id_sales_pos", id_sales_pos)
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

    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception

        End Try

        'MsgBox("main :" + id_productx)

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
        If check_edit_report_status(id_report_status, "76", id_sales_pos) Then
            'BtnBrowseContactFrom.Enabled = True
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = False
            LETypeSO.Enabled = True
            BtnSave.Enabled = True

            'update 8 oktocer 2014
            DEDueDate.Properties.ReadOnly = False
            SPVat.Properties.ReadOnly = False
            DEStart.Properties.ReadOnly = True
            DEEnd.Properties.ReadOnly = True
        Else
            'BtnBrowseContactFrom.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            LETypeSO.Enabled = False
            BtnSave.Enabled = False

            'update 8 oktocer 2014
            DEDueDate.Properties.ReadOnly = True
            SPVat.Properties.ReadOnly = True
            DEStart.Properties.ReadOnly = True
            DEEnd.Properties.ReadOnly = True
        End If


        If check_attach_report_status(id_report_status, "76", id_sales_pos) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtVirtualPosNumber.Focus()
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

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "61"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesPOSDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormSalesPromoSingle.action_pop = "ins"
        FormSalesPromoSingle.id_product = "0"
        FormSalesPromoSingle.id_comp = id_comp
        FormSalesPromoSingle.id_wh_locator = id_wh_locator
        FormSalesPromoSingle.id_wh_rack = id_wh_rack
        FormSalesPromoSingle.id_wh_drawer = id_wh_drawer
        Dim end_period As String = "9999-01-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        FormSalesPromoSingle.date_param = end_period
        FormSalesPromoSingle.id_sales_pos = id_sales_pos
        FormSalesPromoSingle.ShowDialog()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormSalesPromoSingle.action_pop = "upd"
        FormSalesPromoSingle.id_product = "0"
        Try
            FormSalesPromoSingle.id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        FormSalesPromoSingle.id_comp = id_comp
        FormSalesPromoSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormSalesPromoSingle.id_product_edit = GVItemList.GetFocusedRowCellValue("id_product").ToString
        FormSalesPromoSingle.product_code = GVItemList.GetFocusedRowCellValue("code").ToString
        FormSalesPromoSingle.id_design_price_edit = GVItemList.GetFocusedRowCellValue("id_design_price")
        FormSalesPromoSingle.qty_edit = GVItemList.GetFocusedRowCellValue("sales_pos_det_qty")
        FormSalesPromoSingle.id_sales_pos = id_sales_pos
        FormSalesPromoSingle.ShowDialog()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            getNetto()
            getVat()
            getTaxBase()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                MsgBox(id_product)
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sales_pos
        FormReportMark.report_mark_type = "76"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSalesPromo.id_sales_pos = id_sales_pos
        Dim Report As New ReportSalesPromo()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Sub sayCurr()
        total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, currency)
    End Sub

    Private Sub DEDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEDueDate.Validating
        EP_DE_cant_blank(EPForm, DEDueDate)
    End Sub

    Private Sub SPDiscount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        getNetto()
        getVat()
        getTaxBase()
    End Sub

    Private Sub SPVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPVat.EditValueChanged
        getVat()
        getTaxBase()
    End Sub

    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        DEEnd.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_pos
        FormDocumentUpload.report_mark_type = "76"
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
            FormImportExcel.id_pop_up = "18"
            FormImportExcel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DEEnd_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DEEnd.EditValueChanging
        'If end_load Then
        '    Cursor = Cursors.WaitCursor
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Changing end period will reset the list, are you sure to continue??", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        viewDetail()
        '    Else
        '        e.Cancel = True
        '    End If
        '    Cursor = Cursors.Default
        'End If
    End Sub
End Class