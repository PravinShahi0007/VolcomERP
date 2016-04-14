Public Class FormSalesCreditNoteDet 
    Public action As String = "-1"

    Public id_memo_type_ref As String = "-1"

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

    Private Sub FormSalesCreditNoteDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub FormSalesCreditNoteDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtDiscount.EditValue = 0.0
            TxtNetto.EditValue = 0.0
            TxtVatTot.EditValue = 0.0
            TxtTaxBase.EditValue = 0.0

            'TxtVirtualPosNumber.Text = header_number_sales("17")
            action_load_number()

            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            DEStart.DateTime = Now
            DEEnd.DateTime = Now
            DEDueDate.DateTime = Now
        ElseIf action = "upd" Then
            GroupControlList.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactFrom.Enabled = False

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

            id_memo_type_ref = data.Rows(0)("ref_id_memo_type").ToString
            TEMemoType.Text = data.Rows(0)("ref_memo_type").ToString

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
        End If
    End Sub
    Sub action_load_number()
        'If id_memo_type = "1" Then 'credit note sales pos
        '    TxtVirtualPosNumber.Text = header_number_sales("17")
        'ElseIf id_memo_type = "3" Then 'credit note missing
        '    TxtVirtualPosNumber.Text = header_number_sales("18")
        'ElseIf id_memo_type = "5" Then 'credit note promo
        '    TxtVirtualPosNumber.Text = header_number_sales("23")
        'Else
        '    TxtVirtualPosNumber.Text = ""
        'End If
        TxtVirtualPosNumber.Text = header_number_sales("17")
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
        If check_edit_report_status(id_report_status, "66", id_sales_pos) Then
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            DEDueDate.Properties.ReadOnly = False
            DEStart.Properties.ReadOnly = False
            DEEnd.Properties.ReadOnly = False
        Else
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            DEDueDate.Properties.ReadOnly = True
            DEStart.Properties.ReadOnly = True
            DEEnd.Properties.ReadOnly = True
        End If

        If check_attach_report_status(id_report_status, "66", id_sales_pos) Then
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
        Dim vat_total As Double = 0
        If id_memo_type_ref = "5" Then
            vat_total = (vat / 100) * netto
        Else
            vat_total = (vat / (100 + vat)) * netto
        End If

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
        Dim tax_base_total As Double = 0

        If id_memo_type_ref = "5" Then
            tax_base_total = ((100 + vat) / 100) * netto
        Else
            tax_base_total = (100 / (100 + vat)) * netto
        End If

        TxtTaxBase.EditValue = tax_base_total
    End Sub

    Private Sub TxtInvoice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtInvoice.Validating
        EP_TE_cant_blank(EPForm, TxtInvoice)
        EPForm.SetIconPadding(TxtInvoice, 30)
    End Sub

    Private Sub DEDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEDueDate.Validating
        EP_DE_cant_blank(EPForm, DEDueDate)
    End Sub

    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        Cursor = Cursors.WaitCursor
        FormSalesCreditNotePopInv.id_pop_up = "1"
        FormSalesCreditNotePopInv.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
        ValidateChildren()

        'cek periode
        Dim start_period_cek As String = "0001-01-01"
        Dim end_period_cek As String = "9999-12-01"
        Try
            start_period_cek = DEStart.EditValue.ToString
            end_period_cek = DEEnd.EditValue.ToString
        Catch ex As Exception
        End Try

        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopMiddle) Then
            errorInput()
        ElseIf GVItemList.RowCount <= 0 Then
            errorCustom("Item list can't blank ")
        ElseIf start_period_cek = "0000-01-01" Or end_period_cek = "9999-12-01" Then
            errorCustom("Please fill period")
        Else
            Dim sales_pos_number As String = TxtVirtualPosNumber.Text
            Dim sales_pos_note As String = MENote.Text
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim sales_pos_due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_discount As String = decimalSQL(SPDiscount.EditValue.ToString)
            Dim sales_pos_vat As String = decimalSQL(SPVat.EditValue.ToString)
            total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString) * -1


            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main tbale
                        Dim query As String = "INSERT INTO tb_sales_pos(id_sales_pos_ref, id_store_contact_from, sales_pos_number, sales_pos_date, sales_pos_note, id_report_status, id_so_type, sales_pos_total, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_vat, id_memo_type) "
                        query += "VALUES('" + id_sales_pos_ref + "','" + id_store_contact_from + "', '" + sales_pos_number + "', NOW(), '" + sales_pos_note + "', '" + id_report_status + "', '" + id_so_type + "', '" + decimalSQL(total_amount.ToString) + "', '" + sales_pos_due_date + "', '" + sales_pos_start_period + "', '" + sales_pos_end_period + "', '" + sales_pos_discount + "', '" + sales_pos_vat + "', '2'); SELECT LAST_INSERT_ID(); "
                        id_sales_pos = execute_query(query, 0, True, "", "", "", "")

                        'If id_memo_type = "1" Then
                        '    increase_inc_sales("17")
                        'ElseIf id_memo_type = "3" Then
                        '    increase_inc_sales("18")
                        'ElseIf id_memo_type = "5" Then
                        '    increase_inc_sales("23")
                        'End If

                        increase_inc_sales("17")

                        'insert who prepared
                        insert_who_prepared("66", id_sales_pos, id_user)

                        'Detail 
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos_det_ref, id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail) VALUES "
                        End If
                        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                            Dim id_sales_pos_det_ref As String = GVItemList.GetRowCellValue(i, "id_sales_pos_det_ref").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                            Dim sales_pos_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString) * -1
                            Dim id_design_price_retail As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                            Dim design_price_retail As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)

                            If jum_ins_i > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sales_pos_det_ref + "','" + id_sales_pos + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_pos_det_qty + "', '" + id_design_price_retail + "', '" + design_price_retail + "') "
                            jum_ins_i = jum_ins_i + 1
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        FormSalesCreditNote.viewSalesPOS()
                        FormSalesCreditNote.GVSalesPOS.FocusedRowHandle = find_row(FormSalesCreditNote.GVSalesPOS, "id_sales_pos", id_sales_pos)
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
                        Dim query As String = "UPDATE tb_sales_pos SET id_store_contact_from ='" + id_store_contact_from + "', sales_pos_number = '" + sales_pos_number + "', sales_pos_note='" + sales_pos_note + "', id_so_type = '" + id_so_type + "', sales_pos_total = '" + decimalSQL(total_amount.ToString) + "', sales_pos_due_date='" + sales_pos_due_date + "', sales_pos_start_period='" + sales_pos_start_period + "', sales_pos_end_period = '" + sales_pos_end_period + "', sales_pos_discount='" + sales_pos_discount + "', sales_pos_vat='" + sales_pos_vat + "' WHERE id_sales_pos ='" + id_sales_pos + "' "
                        execute_non_query(query, True, "", "", "", "")

                        FormSalesCreditNote.viewSalesPOS()
                        FormSalesCreditNote.GVSalesPOS.FocusedRowHandle = find_row(FormSalesCreditNote.GVSalesPOS, "id_sales_pos", id_sales_pos)
                        Close()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSalesCreditNote.id_sales_pos = id_sales_pos
        ReportSalesCreditNote.dt = GCItemList.DataSource
        Dim Report As New ReportSalesCreditNote()

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
        Report.LabelStore.Text = TxtNameCompFrom.Text
        Report.LabelNumber.Text = TxtVirtualPosNumber.Text
        Report.LPODate.Text = DEForm.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelStoreAddress.Text = MEAdrressCompFrom.Text
        Report.LabelInvoice.Text = TxtInvoice.Text
        Report.LabelType.Text = TxtSalesType.Text
        Report.LabelPeriod.Text = DEStart.Text + " - " + DEEnd.Text
        Report.LabelInvoicePeriod.Text = TxtInvStart.Text + " - " + TxtInvEnd.Text
        Report.LabelDueDate.Text = DEDueDate.Text
        Report.LabelSay.Text = METotSay.Text
        Report.LabelQty.Text = GVItemList.Columns("sales_pos_det_qty").SummaryItem.SummaryValue.ToString
        Report.LabelGross.Text = GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString
        Report.LabelDiscount.Text = SPDiscount.Text
        Report.LabelNetto.Text = TxtNetto.Text
        Report.LabelVAT.Text = TxtVatTot.Text
        Report.LabelTaxBase.Text = TxtTaxBase.Text
        Report.LabelCompName.Text = own_comp_name
        Report.LabelAddress.Text = own_comp_address
        Report.LabelNPWP.Text = own_comp_npwp
        Report.LTypeCN.Text = TEMemoType.Text
        Report.GridView1.OptionsPrint.PrintFooter = False

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sales_pos
        FormReportMark.report_mark_type = "66"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSalesCreditNoteSingle.id_sales_pos_ref = id_sales_pos_ref
        FormSalesCreditNoteSingle.action_pop = "ins"
        FormSalesCreditNoteSingle.id_pop_up = "1"
        FormSalesCreditNoteSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click

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
            check_but()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_pos
        FormDocumentUpload.report_mark_type = "66"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        Dim dt_str As Date = DEStart.EditValue
        DEEnd.Properties.MinValue = dt_str
    End Sub
End Class