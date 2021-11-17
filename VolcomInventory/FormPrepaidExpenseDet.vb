Public Class FormPrepaidExpenseDet
    Public id As String = "-1"
    Public id_coa_tag As String = "1"
    Public is_view As String = "-1"

    Dim id_report_status As String = "-1"
    Public id_comp As String = "-1"

    Dim created_date As String = ""

    Public id_polis_reg As String = "-1"

    Dim id_reff As String = "0"
    Dim report_mark_type As String = "0"

    Private Sub FormPrepaidExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_currency()
        Dim q As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupRepositoryQuery(RISLECurrency, q, 0, "currency", "id_currency")
    End Sub

    Private Sub FormPrepaidExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateReff.EditValue = Now()
        load_unit()
        '
        viewReportStatus()
        viewCCRepo()
        viewCOAPPH()
        viewCOARepo()
        load_currency()
        '
        view_repo_cat()
        view_repo_type()
        '
        actionLoad()
        '
        GridColumnPPH.UnboundExpression = "Iif([id_acc_pph] = " & get_opt_acc_field("id_acc_skbp") & ", 0, floor([pph_percent] / 100 * [amount]))"
        '
        If Not id_polis_reg = "-1" Then

            TEInvNo.Text = addSlashes(FormPrepaidExpensePolis.TEInvNumber.Text)
            id_comp = FormPrepaidExpensePolis.id_comp
            TxtCompNumber.Text = get_company_x(FormPrepaidExpensePolis.id_comp, "2")
            TxtCompName.Text = get_company_x(FormPrepaidExpensePolis.id_comp, "1")

            '
            id_reff = id_polis_reg
            report_mark_type = "309"
            '

            Dim qg As String = "SELECT c.id_acc_dp AS id_acc,c.id_comp,ppsd.id_comp AS id_store,ppsd.v_start_date,TIMESTAMPDIFF(MONTH, regd.real_start_date, regd.real_end_date) AS month_dif,regd.id_polis_reg_det,reg.`number`,regd.polis_number,regd.premi AS val
FROM `tb_polis_reg_det` regd
INNER JOIN tb_polis_pps_det ppsd ON ppsd.id_polis_pps_det=regd.id_polis_pps_det
INNER JOIN tb_polis_reg reg ON reg.`id_polis_reg`=regd.id_polis_reg
INNER JOIN tb_m_comp c ON c.id_comp=regd.vendor_dipilih
WHERE reg.id_polis_reg='" & id_polis_reg & "' AND regd.vendor_dipilih='" & FormPrepaidExpensePolis.id_comp & "' AND regd.polis_number='" & addSlashes(FormPrepaidExpensePolis.TEInvNumber.Text) & "' "
            Dim dtg As DataTable = execute_query(qg, -1, True, "", "", "", "")

            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If

            FormMain.SplashScreenManager1.SetWaitFormDescription("Generating from polis register..")

            For i = 0 To dtg.Rows.Count - 1
                FormMain.SplashScreenManager1.SetWaitFormDescription("Processing prepaid expense " & i + 1 & " of " & (dtg.Rows.Count) & "  ")

                'insert 1 by 1
                GVData.AddNewRow()
                GVData.FocusedRowHandle = GVData.RowCount - 1

                GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc", dtg.Rows(i)("id_acc").ToString)

                'If dth.Rows(0)("id_type").ToString = "2" Then
                '    '2246 acc WH id_acc
                '    GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc", "2246")
                'Else

                'End If

                GVData.SetRowCellValue(GVData.RowCount - 1, "id_expense_type", "1")
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_b_expense", "65")
                GVData.SetRowCellValue(GVData.RowCount - 1, "cc", dtg.Rows(i)("id_store").ToString)
                '2638
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc_biaya", "2638")
                GVData.SetRowCellValue(GVData.RowCount - 1, "start_date", DECreated.EditValue)
                GVData.SetRowCellValue(GVData.RowCount - 1, "qty_month", dtg.Rows(i)("month_dif"))
                GVData.SetRowCellValue(GVData.RowCount - 1, "description", FormPrepaidExpensePolis.TEDesc.Text)
                GVData.SetRowCellValue(GVData.RowCount - 1, "amount", dtg.Rows(i)("val"))
                GVData.SetRowCellValue(GVData.RowCount - 1, "tax_percent", FormPrepaidExpensePolis.TEPPN3PLInv.EditValue)
                '
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc_pph", FormPrepaidExpensePolis.SLEPPH3PLInv.EditValue.ToString)
                GVData.SetRowCellValue(GVData.RowCount - 1, "pph_percent", FormPrepaidExpensePolis.TEPPH3PLInv.EditValue)
                '
                GVData.SetRowCellValue(GVData.RowCount - 1, "amount_before", dtg.Rows(i)("val"))
                GVData.SetRowCellValue(GVData.RowCount - 1, "kurs", 1)
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_currency", 1)

                'GVData.SetRowCellValue(GVData.RowCount - 1, "is_lock", "yes")
                '
            Next
            FormMain.SplashScreenManager1.CloseWaitForm()
            GVData.BestFitColumns()
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "95"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        TxtSubTotal.EditValue = 0.00
        TxtVAT.EditValue = 0.00
        TxtTotal.EditValue = 0.00
        If id = "-1" Then
            Dim err_coa As String = ""

            'cek coa persediaan dan hutang
            Dim cond_coa As Boolean = True
            Dim qcoa As String = "SELECT * 
            FROM tb_opt_purchasing o
            INNER JOIN tb_a_acc k ON k.id_acc = o.acc_coa_vat_in 
            WHERE !ISNULL(k.id_acc) "
            Dim dcoa As DataTable = execute_query(qcoa, -1, True, "", "", "", "")
            If dcoa.Rows.Count <= 0 Then
                err_coa += "- COA : Vat In " + System.Environment.NewLine
                cond_coa = False
            End If

            If Not cond_coa Then
                warningCustom("Please contact Accounting Department to setup these COA : " + System.Environment.NewLine + err_coa)
                Close()
            End If

            'date
            DEDueDate.EditValue = getTimeDB()

            TEInvNo.Enabled = True

            'purc order detail
            GVData.OptionsCustomization.AllowSort = False
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            '
            DEDateReff.Properties.MinValue = execute_query("SELECT DATE_ADD(MAX(date_until),INTERVAL 1 DAY) FROM `tb_closing_log` WHERE id_coa_tag='" & SLEUnit.EditValue.ToString & "'", 0, True, "", "", "", "")
            '
            viewDetail()
        Else
            GVData.OptionsCustomization.AllowSort = True

            Dim query As String = "SELECT p.id_comp,p.id_coa_tag,c.comp_number,c.comp_name,p.due_date,p.date_reff,p.inv_number,p.id_report_status,p.number,p.created_date
,p.note,p.id_report_status,p.sub_total,p.vat_total,p.total
FROM tb_prepaid_expense p
INNER JOIN tb_m_comp c ON c.`id_comp`=p.`id_comp`
WHERE p.id_prepaid_expense='" & id & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_coa_tag = data.Rows(0)("id_coa_tag").ToString
            SLEUnit.EditValue = id_coa_tag

            id_comp = data.Rows(0)("id_comp").ToString
            TxtCompNumber.Text = data.Rows(0)("comp_number").ToString
            TxtCompName.Text = data.Rows(0)("comp_name").ToString
            DEDueDate.EditValue = data.Rows(0)("due_date")
            DEDateReff.EditValue = data.Rows(0)("date_reff")

            TEInvNo.Text = data.Rows(0)("inv_number").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtSubTotal.EditValue = data.Rows(0)("sub_total")
            TxtVAT.EditValue = data.Rows(0)("vat_total")
            TxtTotal.EditValue = data.Rows(0)("total")

            viewDetail()
            calculate()
            allow_status()
        End If
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True 'pindah permintaan bu mariati
        BtnBrowse.Enabled = True
        '
        If check_edit_report_status(id_report_status, "349", id) And Not is_view = "1" Then
            'msh bisa edit
            GridColumnAccountDescription.Visible = False
            GridColumnaccount.VisibleIndex = 1
            '
            GridColumnPPHDesc.Visible = False
            GridColumnPPHCOA.VisibleIndex = 12
            '
            GridColumnBudgetTypeDesc.Visible = False
            GridColumnBudgetType.VisibleIndex = 2
            '
            GCCCDesc.Visible = False
            GCCC.VisibleIndex = 2
            '
            GridColumnBudgetDesc.Visible = False
            GridColumnBudget.VisibleIndex = 3
        Else
            'tidak bisa edit
            GVData.OptionsBehavior.Editable = False
            '
            SLEUnit.Enabled = False
            DEDateReff.Enabled = False
            '
            BtnBrowse.Enabled = False
            DEDueDate.Enabled = False
            BtnSave.Visible = False
            MENote.Enabled = False
            GCData.ContextMenuStrip = Nothing
            PanelControlNav.Visible = False
            '
            GridColumnaccount.Visible = False
            GridColumnAccountDescription.VisibleIndex = 1
            '
            GridColumnPPHCOA.Visible = False
            GridColumnPPHDesc.VisibleIndex = 12
            '
            GridColumnBudgetType.Visible = False
            GridColumnBudgetTypeDesc.VisibleIndex = 2
            '
            GCCC.Visible = False
            GCCCDesc.VisibleIndex = 2
            '
            GridColumnBudget.Visible = False
            GridColumnBudgetDesc.VisibleIndex = 3
        End If
        '
        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Sub calculate()
        Cursor = Cursors.WaitCursor

        Dim sub_total As Decimal = 0.00
        Try
            sub_total = GVData.Columns("amount").SummaryItem.SummaryValue
        Catch ex As Exception
            sub_total = 0.00
        End Try
        TxtSubTotal.EditValue = sub_total

        Dim vat As Decimal = 0.00
        Try
            vat = GVData.Columns("tax_value").SummaryItem.SummaryValue
        Catch ex As Exception
            vat = 0.00
        End Try
        TxtVAT.EditValue = vat

        Dim pph As Decimal = 0.00
        Try
            pph = GVData.Columns("pph_value").SummaryItem.SummaryValue
        Catch ex As Exception
            pph = 0.00
        End Try
        TEPPH.EditValue = pph

        TxtTotal.EditValue = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim rh As Integer = e.RowHandle

        If e.Column.FieldName = "id_currency" Or e.Column.FieldName = "kurs" Or e.Column.FieldName = "amount_before" Then
            'calculate amount in RP
            'For i = 0 To GVData.RowCount - 1
            '    Try
            '        GVData.SetRowCellValue(i, "amount", If(GVData.GetRowCellValue(i, "id_currency").ToString = "1", GVData.GetRowCellValue(i, "amount_before"), GVData.GetRowCellValue(i, "amount_before") * GVData.GetRowCellValue(i, "kurs")))
            '    Catch ex As Exception
            '        Console.WriteLine(ex.ToString)
            '    End Try
            'Next

            Try
                GVData.SetRowCellValue(e.RowHandle, "amount", If(GVData.GetRowCellValue(e.RowHandle, "id_currency").ToString = "1", GVData.GetRowCellValue(e.RowHandle, "amount_before"), GVData.GetRowCellValue(e.RowHandle, "amount_before") * GVData.GetRowCellValue(e.RowHandle, "kurs")))
            Catch ex As Exception
                'Console.WriteLine(ex.ToString)
            End Try

        End If

        If e.Column.FieldName = "amount" Or e.Column.FieldName = "tax_percent" Or e.Column.FieldName = "pph_percent" Then
            GCData.RefreshDataSource()
            GVData.RefreshData()
            calculate()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim q_year As String = ""
        Dim query As String = "SELECT 'no' AS is_lock,ed.id_currency,cur.currency,ed.amount_before,ed.kurs,ed.id_acc_biaya,ed.start_date,ed.qty_month,ed.amount,ed.id_prepaid_expense_det,ed.cc,c.comp_number AS cc_desc, ed.id_prepaid_expense,ed.id_expense_type,ed.id_b_expense,bex.item_cat_main,typ.expense_type,
        ed.id_acc,pphacc.acc_description AS coa_desc_pph,a.id_acc_cat, a.acc_description AS `coa_desc`,ab.acc_description AS `coa_biaya_desc`, ed.description,a.acc_name,ed.id_acc_pph,ed.pph_percent,ed.pph, "

        If id = "-1" Then
            query += "0.00 AS tax_percent,0.00 AS `amount` "
        Else
            query += "ed.tax_percent,ed.amount "
        End If

        If id = "-1" Then
            q_year = " WHERE bo.`year`=YEAR(NOW()) AND bo.is_active='1' "
        End If

        query += "FROM tb_prepaid_expense_det ed
        INNER JOIN tb_prepaid_expense e ON e.id_prepaid_expense=ed.id_prepaid_expense
        LEFT JOIN tb_a_acc pphacc ON pphacc.id_acc = ed.id_acc_pph
        INNER JOIN tb_a_acc a ON a.id_acc = ed.id_acc
        INNER JOIN tb_a_acc ab ON ab.id_acc = ed.id_acc_biaya
        INNER JOIN tb_lookup_expense_type typ ON typ.id_expense_type=ed.id_expense_type
        INNER JOIN tb_lookup_currency cur ON cur.id_currency=ed.id_currency
        LEFT JOIN tb_m_comp c ON ed.cc=c.id_comp
        INNER JOIN 
        (
	        SELECT bo.`year`,bo.`id_b_expense_opex` AS id_b_expense,icm.`id_item_cat_main`,icm.`item_cat_main`,icm.`id_expense_type`
	        FROM tb_b_expense_opex bo
	        INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
	        " & q_year & "
	        UNION ALL
	        SELECT bo.`year`,bo.`id_b_expense` AS id_b_expense,icm.`id_item_cat_main`,CONCAT('[',dep.departement,']',icm.`item_cat_main`) AS item_cat_main,icm.`id_expense_type`
	        FROM tb_b_expense bo
	        INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
	        INNER JOIN tb_m_departement dep ON dep.id_departement=bo.id_departement
	        " & q_year & "
        ) bex ON bex.id_b_expense=ed.id_b_expense AND ed.id_expense_type=bex.id_expense_type AND bex.year=YEAR(e.date_reff)
        WHERE ed.id_prepaid_expense=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data

        GridColumnNo.MaxWidth = 0
        GridColumnCurrView.MaxWidth = 0
        GridColumnAmount.MaxWidth = 0
        GridColumnTaxPercent.MaxWidth = 0
        GridColumnTaxValue.MaxWidth = 0
        GridColumnPPHPercent.MaxWidth = 0
        GridColumnPPH.MaxWidth = 0

        GVData.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Sub viewCOARepo()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        If id_coa_tag = "1" Then
            query += " AND id_coa_type='1' "
        Else
            query += " AND id_coa_type='2' "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepositoryItemSearchLookUpEdit1.DataSource = Nothing
        RepositoryItemSearchLookUpEdit1.DataSource = data
        RepositoryItemSearchLookUpEdit1.DisplayMember = "acc_description"
        RepositoryItemSearchLookUpEdit1.ValueMember = "id_acc"
    End Sub

    Sub view_repo_cat()
        Dim q As String = "SELECT bo.`id_b_expense_opex` AS id_b_expense,icm.`id_item_cat_main`,icm.`item_cat_main`,icm.`id_expense_type`
FROM tb_b_expense_opex bo
INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
WHERE bo.`year`=YEAR('" & Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND bo.is_active='1'
UNION ALL
SELECT bo.`id_b_expense` AS id_b_expense,icm.`id_item_cat_main`,CONCAT('[',dep.departement,']',icm.`item_cat_main`) AS item_cat_main,icm.`id_expense_type`
FROM tb_b_expense bo
INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
INNER JOIN tb_m_departement dep ON dep.id_departement=bo.id_departement
WHERE bo.`year`=YEAR('" & Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND bo.is_active='1'"
        viewSearchLookupRepositoryQuery(RISLECatExpense, q, 0, "item_cat_main", "id_b_expense")
    End Sub

    Sub viewCOAPPH()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a 
INNER JOIN `tb_lookup_tax_report` tr ON tr.id_tax_report=a.id_tax_report AND tr.id_type=1
WHERE a.id_status=1 AND a.id_is_det=2 "
        If id_coa_tag = "1" Then
            query += " AND a.id_coa_type='1' "
        Else
            query += " AND a.id_coa_type='2' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RISLECOAPPH.DataSource = Nothing
        RISLECOAPPH.DataSource = data
        RISLECOAPPH.DisplayMember = "acc_description"
        RISLECOAPPH.ValueMember = "id_acc"
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_repo_type()
        Dim q As String = "SELECT id_expense_type,expense_type FROM tb_lookup_expense_type"
        viewSearchLookupRepositoryQuery(RISLEType, q, 0, "expense_type", "id_expense_type")
    End Sub

    Sub viewCCRepo()
        Dim q As String = "SELECT id_comp,comp_number,comp_name FROM tb_m_comp"
        viewSearchLookupRepositoryQuery(RISLECC, q, 0, "comp_number", "id_comp")
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        'query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        GVData.AddNewRow()
        GVData.FocusedRowHandle = GVData.RowCount - 1
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "id_expense_type", "1")
        GVData.SetRowCellValue(GVData.RowCount - 1, "cc", "1")
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "start_date", DECreated.EditValue)
        GVData.SetRowCellValue(GVData.RowCount - 1, "qty_month", "2")
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "amount_before", 0)
        GVData.SetRowCellValue(GVData.RowCount - 1, "kurs", 1)
        GVData.SetRowCellValue(GVData.RowCount - 1, "id_currency", 1)

        GVData.SetRowCellValue(GVData.RowCount - 1, "tax_percent", 0)
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "pph_percent", 0)
        '
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTPDraftJournal_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTPDraftJournal.SelectedPageChanged
        If XTPDraftJournal.SelectedTabPageIndex = 1 Then
            GVData.RefreshData()
            load_blank_draft()
            viewDraftJournal()
        ElseIf XTPDraftJournal.SelectedTabPageIndex = 2 Then
            GVData.RefreshData()
            load_blank_draft_bulanan()
            viewDraftJournalBulanan()
        End If
    End Sub

    Sub load_blank_draft()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`,'' AS id_acc, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub load_blank_draft_bulanan()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`,'' AS id_acc, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournalBulanan()
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 Then
            makeSafeGV(GVData)
            Dim jum_row As Integer = 0

            'For i As Integer = 0 To GVData.RowCount - 1
            '    'biaya
            '    Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            '    newRowh("no") = jum_row
            '    newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
            '    newRowh("acc_description") = dh.Rows(0)("acc_name").ToString & " - " & dh.Rows(0)("acc_description").ToString
            '    newRowh("cc") = "000"
            '    newRowh("report_number") = ""
            '    newRowh("note") = MENote.Text
            '    newRowh("debit") = 0
            '    newRowh("credit") = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
            '    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
            '    GCDraft.RefreshDataSource()
            '    GVDraft.RefreshData()

            '    'hutang
            '    Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            '    newRowh("no") = jum_row
            '    newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
            '    newRowh("acc_description") = dh.Rows(0)("acc_name").ToString & " - " & dh.Rows(0)("acc_description").ToString
            '    newRowh("cc") = "000"
            '    newRowh("report_number") = ""
            '    newRowh("note") = MENote.Text
            '    newRowh("debit") = 0
            '    newRowh("credit") = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
            '    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
            '    GCDraft.RefreshDataSource()
            '    GVDraft.RefreshData()
            'Next

            'header
            jum_row += 1
                Dim qh As String = "SELECT acc.acc_name,acc.acc_description
FROM tb_m_comp c 
INNER JOIN tb_a_acc acc ON acc.id_acc=" & If(id_coa_tag = "1", "c.id_acc_ap", "c.id_acc_cabang_ap") & "
WHERE c.id_comp='" + id_comp + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            If dh.Rows.Count > 0 Then
                'total
                If TxtSubTotal.EditValue > 0 Then
                    Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowh("no") = jum_row
                    newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
                    newRowh("acc_description") = dh.Rows(0)("acc_name").ToString & " - " & dh.Rows(0)("acc_description").ToString
                    newRowh("cc") = "000"
                    newRowh("report_number") = ""
                    newRowh("note") = MENote.Text
                    newRowh("debit") = 0
                    newRowh("credit") = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                End If

                'detil
                For i As Integer = 0 To GVData.RowCount - 1
                    'Dim found As Boolean = False
                    'Dim row_found As Integer = 0
                    'For j As Integer = 0 To GVDraft.RowCount - 1
                    '    row_found = j
                    'Next

                    'If found Then
                    '    GVDraft.SetRowCellValue(row_found, "debit", GVDraft.GetRowCellValue(row_found, "debit") + Math.Abs(GVData.GetRowCellValue(i, "valuex")))
                    'Else
                    '    jum_row += 1
                    '    Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    '    newRow("no") = jum_row
                    '    newRow("id_acc") = GVData.GetRowCellValue(i, "id_acc").ToString
                    '    newRow("acc_description") = GVData.GetRowCellDisplayText(i, "id_acc").ToString
                    '    newRow("cc") = "000"
                    '    newRow("report_number") = GVData.GetRowCellValue(i, "report_number").ToString
                    '    newRow("note") = GVData.GetRowCellValue(i, "info_design").ToString
                    '    If GVData.GetRowCellValue(i, "valuex") < 0 Then
                    '        newRow("debit") = 0
                    '        newRow("credit") = Math.Abs(GVData.GetRowCellValue(i, "valuex"))
                    '    Else
                    '        newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "valuex"))
                    '        newRow("credit") = 0
                    '    End If
                    '    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                    '    GCDraft.RefreshDataSource()
                    '    GVDraft.RefreshData()
                    'End If
                    jum_row += 1
                    Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRow("no") = jum_row
                    newRow("id_acc") = GVData.GetRowCellValue(i, "id_acc").ToString

                    If id = "-1" Then
                        Try
                            newRow("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc").ToString, "1")
                            newRow("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc").ToString, "2")
                            newRow("cc") = GVData.GetRowCellValue(i, "cc_desc").ToString
                        Catch ex As Exception
                        End Try
                    Else
                        newRow("acc_name") = GVData.GetRowCellValue(i, "acc_name").ToString
                        newRow("acc_description") = GVData.GetRowCellValue(i, "coa_desc").ToString
                        newRow("cc") = GVData.GetRowCellDisplayText(i, "cc").ToString
                    End If

                    newRow("report_number") = ""
                    newRow("note") = GVData.GetRowCellValue(i, "description").ToString
                    If GVData.GetRowCellValue(i, "amount") < 0 Then
                        newRow("debit") = 0
                        newRow("credit") = Math.Abs(GVData.GetRowCellValue(i, "amount"))
                    Else
                        newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "amount"))
                        newRow("credit") = 0
                    End If
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                    'pph
                    If GVData.GetRowCellValue(i, "id_acc_pph").ToString = get_opt_acc_field("id_acc_skbp") And GVData.GetRowCellValue(i, "pph_percent") > 0 Then
                        'SKBP
                        'debit
                        jum_row += 1
                        Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = (GVData.GetRowCellValue(i, "pph_percent") / 100) * GVData.GetRowCellValue(i, "amount")
                        newRowvat("credit") = 0
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)

                        'credit
                        jum_row += 1
                        newRowvat = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = 0
                        newRowvat("credit") = (GVData.GetRowCellValue(i, "pph_percent") / 100) * GVData.GetRowCellValue(i, "amount")
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    ElseIf GVData.GetRowCellValue(i, "pph_percent") > 0 Then
                        jum_row += 1
                        Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = 0
                        newRowvat("credit") = GVData.GetRowCellValue(i, "pph_value")
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    End If
                Next
                'vat
                If TxtVAT.EditValue > 0 Then
                    jum_row += 1
                    Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowvat("no") = jum_row
                    If id_coa_tag = "1" Then
                        newRowvat("acc_name") = get_acc(get_opt_purchasing_field("acc_coa_vat_in"), "1")
                        newRowvat("acc_description") = get_acc(get_opt_purchasing_field("acc_coa_vat_in"), "2")
                    Else
                        newRowvat("acc_name") = get_acc(get_opt_purchasing_field("acc_coa_vat_in_cabang"), "1")
                        newRowvat("acc_description") = get_acc(get_opt_purchasing_field("acc_coa_vat_in_cabang"), "2")
                    End If
                    newRowvat("cc") = "000"
                    newRowvat("report_number") = ""
                    newRowvat("note") = MENote.Text
                    newRowvat("debit") = TxtVAT.EditValue
                    newRowvat("credit") = 0
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    jum_row += 1
                End If
                '
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()

                GVDraft.BestFitColumns()
            Else
                MsgBox("DP/AP account is not set")
                XTPDraftJournal.SelectedTabPageIndex = 0
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 Then
            makeSafeGV(GVData)
            Dim jum_row As Integer = 0

            'header
            jum_row += 1
            Dim qh As String = "SELECT acc.acc_name,acc.acc_description
FROM tb_m_comp c 
INNER JOIN tb_a_acc acc ON acc.id_acc=" & If(id_coa_tag = "1", "c.id_acc_ap", "c.id_acc_cabang_ap") & "
WHERE c.id_comp='" + id_comp + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            If dh.Rows.Count > 0 Then
                'total
                If TxtSubTotal.EditValue > 0 Then
                    Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowh("no") = jum_row
                    newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
                    newRowh("acc_description") = dh.Rows(0)("acc_name").ToString & " - " & dh.Rows(0)("acc_description").ToString
                    newRowh("cc") = "000"
                    newRowh("report_number") = ""
                    newRowh("note") = MENote.Text
                    newRowh("debit") = 0
                    newRowh("credit") = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                End If

                'detil
                For i As Integer = 0 To GVData.RowCount - 1
                    'Dim found As Boolean = False
                    'Dim row_found As Integer = 0
                    'For j As Integer = 0 To GVDraft.RowCount - 1
                    '    row_found = j
                    'Next

                    'If found Then
                    '    GVDraft.SetRowCellValue(row_found, "debit", GVDraft.GetRowCellValue(row_found, "debit") + Math.Abs(GVData.GetRowCellValue(i, "valuex")))
                    'Else
                    '    jum_row += 1
                    '    Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    '    newRow("no") = jum_row
                    '    newRow("id_acc") = GVData.GetRowCellValue(i, "id_acc").ToString
                    '    newRow("acc_description") = GVData.GetRowCellDisplayText(i, "id_acc").ToString
                    '    newRow("cc") = "000"
                    '    newRow("report_number") = GVData.GetRowCellValue(i, "report_number").ToString
                    '    newRow("note") = GVData.GetRowCellValue(i, "info_design").ToString
                    '    If GVData.GetRowCellValue(i, "valuex") < 0 Then
                    '        newRow("debit") = 0
                    '        newRow("credit") = Math.Abs(GVData.GetRowCellValue(i, "valuex"))
                    '    Else
                    '        newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "valuex"))
                    '        newRow("credit") = 0
                    '    End If
                    '    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                    '    GCDraft.RefreshDataSource()
                    '    GVDraft.RefreshData()
                    'End If
                    jum_row += 1
                    Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRow("no") = jum_row
                    newRow("id_acc") = GVData.GetRowCellValue(i, "id_acc").ToString

                    If id = "-1" Then
                        Try
                            newRow("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc").ToString, "1")
                            newRow("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc").ToString, "2")
                            newRow("cc") = GVData.GetRowCellValue(i, "cc_desc").ToString
                        Catch ex As Exception
                        End Try
                    Else
                        newRow("acc_name") = GVData.GetRowCellValue(i, "acc_name").ToString
                        newRow("acc_description") = GVData.GetRowCellValue(i, "coa_desc").ToString
                        newRow("cc") = GVData.GetRowCellDisplayText(i, "cc").ToString
                    End If

                    newRow("report_number") = ""
                    newRow("note") = GVData.GetRowCellValue(i, "description").ToString
                    If GVData.GetRowCellValue(i, "amount") < 0 Then
                        newRow("debit") = 0
                        newRow("credit") = Math.Abs(GVData.GetRowCellValue(i, "amount"))
                    Else
                        newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "amount"))
                        newRow("credit") = 0
                    End If
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                    'pph
                    If GVData.GetRowCellValue(i, "id_acc_pph").ToString = get_opt_acc_field("id_acc_skbp") And GVData.GetRowCellValue(i, "pph_percent") > 0 Then
                        'SKBP
                        'debit
                        jum_row += 1
                        Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = (GVData.GetRowCellValue(i, "pph_percent") / 100) * GVData.GetRowCellValue(i, "amount")
                        newRowvat("credit") = 0
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)

                        'credit
                        jum_row += 1
                        newRowvat = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = 0
                        newRowvat("credit") = (GVData.GetRowCellValue(i, "pph_percent") / 100) * GVData.GetRowCellValue(i, "amount")
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    ElseIf GVData.GetRowCellValue(i, "pph_percent") > 0 Then
                        jum_row += 1
                        Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = 0
                        newRowvat("credit") = GVData.GetRowCellValue(i, "pph_value")
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    End If
                Next
                'vat
                If TxtVAT.EditValue > 0 Then
                    jum_row += 1
                    Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowvat("no") = jum_row
                    If id_coa_tag = "1" Then
                        newRowvat("acc_name") = get_acc(get_opt_purchasing_field("acc_coa_vat_in"), "1")
                        newRowvat("acc_description") = get_acc(get_opt_purchasing_field("acc_coa_vat_in"), "2")
                    Else
                        newRowvat("acc_name") = get_acc(get_opt_purchasing_field("acc_coa_vat_in_cabang"), "1")
                        newRowvat("acc_description") = get_acc(get_opt_purchasing_field("acc_coa_vat_in_cabang"), "2")
                    End If
                    newRowvat("cc") = "000"
                    newRowvat("report_number") = ""
                    newRowvat("note") = MENote.Text
                    newRowvat("debit") = TxtVAT.EditValue
                    newRowvat("credit") = 0
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    jum_row += 1
                End If
                '
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()

                GVDraft.BestFitColumns()
            Else
                MsgBox("DP/AP account is not set")
                XTPDraftJournal.SelectedTabPageIndex = 0
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        del()
    End Sub

    Sub del()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            If GVData.GetFocusedRowCellValue("is_lock").ToString = "yes" Then
                stopCustom("Data locked")
            Else
                GVData.DeleteSelectedRows()
                GCData.RefreshDataSource()
                GVData.RefreshData()
                calculate()
            End If
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVData.RefreshData()
        makeSafeGV(GVData)
        calculate()

        Dim multiple_curr As Boolean = False

        'cek multiple currency
        For i As Integer = 0 To GVData.RowCount - 1
            If Not GVData.GetRowCellValue(i, "id_currency").ToString = GVData.GetRowCellValue(0, "id_currency").ToString Or Not Decimal.Parse(GVData.GetRowCellValue(i, "kurs").ToString) = Decimal.Parse(GVData.GetRowCellValue(0, "kurs").ToString) Then
                multiple_curr = True
                Exit For
            End If
        Next

        'cek empty
        Dim cond_empty As Boolean = False
        GVData.ActiveFilterString = "[amount] Is Null OR [amount]=0 OR IsNullOrEmpty([id_acc]) OR IsNullOrEmpty([id_acc_biaya]) OR ([pph_percent]>0 AND IsNullOrEmpty([id_acc_pph]))"
        If GVData.RowCount > 0 Then
            cond_empty = True
        End If
        makeSafeGV(GVData)

        'cek month installment
        Dim cond_installment As Boolean = False
        GVData.ActiveFilterString = "[qty_month]=1 OR [qty_month]<0 OR IsNullOrEmpty([qty_month])"
        If GVData.RowCount > 0 Then
            cond_installment = True
        End If
        makeSafeGV(GVData)

        If cond_empty Then
            warningCustom("Please complete all detail data")
        ElseIf GVData.RowCount <= 0 Then
            warningCustom("Please input detail expense")
        ElseIf TEInvNo.Text = "" Then
            warningCustom("Please input invoice number")
        ElseIf cond_installment Then
            warningCustom("Please input month installment with minimum 2 month")
        ElseIf MENote.Text = "" Then
            warningCustom("Please put some note")
        ElseIf DEDateReff.Text = "" Then
            warningCustom("Please put refference date")
        ElseIf multiple_curr Then
            warningCustom("Please use only same currency with same kurs")
        Else
            GVData.ActiveFilterString = ""
            'check invoice duplicate
            Dim inv_no As String = addSlashes(TEInvNo.Text)
            Dim qc As String = "SELECT * FROM tb_prepaid_expense WHERE id_comp='" & id_comp & "' AND inv_number='" & inv_no & "' AND id_prepaid_expense !='" & id & "' AND id_report_status!=5"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

            If dtc.Rows.Count > 0 Then
                warningCustom("Invoice number duplicate")
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'query main
                    If id = "-1" Then
                        Dim note As String = addSlashes(MENote.Text)
                        Dim due_date As String = ""
                        Dim date_reff As String = ""
                        Dim sub_total As String = decimalSQL(TxtSubTotal.EditValue.ToString)
                        Dim vat_total As String = decimalSQL(TxtVAT.EditValue.ToString)
                        Dim total As String = decimalSQL(TxtTotal.EditValue.ToString)
                        Dim is_open As String = ""

                        due_date = "'" + Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
                        date_reff = "" + Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") + ""
                        is_open = "1"

                        Dim qm As String = "INSERT INTO tb_prepaid_expense(id_comp,inv_number, created_date, due_date, created_by, id_report_status, note, sub_total, vat_total, total, is_open, date_reff, id_coa_tag, id_reff,report_mark_type) VALUES 
                (" + id_comp + ",'" + inv_no + "', NOW()," + due_date + ", '" + id_user + "', 1, '" + note + "','" + sub_total + "', '" + vat_total + "', '" + total + "', '" + is_open + "', '" + date_reff + "','" & SLEUnit.EditValue.ToString & "','" & id_reff & "','" & report_mark_type & "'); SELECT LAST_INSERT_ID(); "
                        id = execute_query(qm, 0, True, "", "", "", "")
                        execute_non_query("CALL gen_number(" + id + ",349); ", True, "", "", "", "")

                        'query det
                        Dim qd As String = "INSERT INTO tb_prepaid_expense_det(id_prepaid_expense, id_acc, id_acc_biaya,cc, description, tax_percent, tax_value,id_currency,amount_before,kurs, amount, id_expense_type, id_b_expense, id_acc_pph, pph_percent, pph, start_date,qty_month,end_date) VALUES "
                        For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_acc As String = GVData.GetRowCellValue(d, "id_acc").ToString
                            Dim id_acc_biaya As String = GVData.GetRowCellValue(d, "id_acc_biaya").ToString
                            Dim cc As String = GVData.GetRowCellValue(d, "cc").ToString
                            Dim description As String = addSlashes(GVData.GetRowCellValue(d, "description").ToString)
                            Dim tax_percent As String = decimalSQL(GVData.GetRowCellValue(d, "tax_percent").ToString)
                            Dim tax_value As String = decimalSQL(GVData.GetRowCellValue(d, "tax_value").ToString)
                            Dim amount As String = decimalSQL(GVData.GetRowCellValue(d, "amount").ToString)
                            Dim id_expense_type As String = GVData.GetRowCellValue(d, "id_expense_type").ToString
                            Dim id_b_expense As String = GVData.GetRowCellValue(d, "id_b_expense").ToString
                            '
                            Dim start_period As String = Date.Parse(GVData.GetRowCellValue(d, "start_date").ToString).ToString("yyyy-MM-dd")
                            Dim qty_month As String = decimalSQL(GVData.GetRowCellValue(d, "qty_month").ToString)
                            Dim end_period As String = Date.Parse(GVData.GetRowCellValue(d, "end_date").ToString).ToString("yyyy-MM-dd")
                            '
                            Dim id_currency As String = GVData.GetRowCellValue(d, "id_currency").ToString
                            Dim kurs As String = decimalSQL(GVData.GetRowCellValue(d, "kurs").ToString)
                            Dim amount_before As String = decimalSQL(GVData.GetRowCellValue(d, "amount_before").ToString)
                            '
                            Dim id_acc_pph As String = "NULL"
                            Dim pph_percent As String = "0"
                            Dim pph As String = "0"
                            '
                            If GVData.GetRowCellValue(d, "pph_percent") > 0 Then
                                id_acc_pph = "'" & GVData.GetRowCellValue(d, "id_acc_pph").ToString & "'"
                                pph_percent = decimalSQL(GVData.GetRowCellValue(d, "pph_percent").ToString)
                                pph = decimalSQL(GVData.GetRowCellValue(d, "pph_value").ToString)
                            End If
                            '
                            If d > 0 Then
                                qd += ", "
                            End If
                            qd += "('" + id + "','" + id_acc + "','" + id_acc_biaya + "','" + cc + "', '" + description + "', '" + tax_percent + "', '" + tax_value + "', '" + id_currency + "', '" + amount_before + "', '" + kurs + "', '" + amount + "', '" + id_expense_type + "', '" + id_b_expense + "'," + id_acc_pph + ",'" + pph_percent + "','" + pph + "','" & start_period & "','" & qty_month & "','" & end_period & "') "
                        Next
                        '
                        If GVData.RowCount > 0 Then
                            execute_non_query(qd, True, "", "", "", "")
                        End If

                        'submit
                        submit_who_prepared("349", id, id_user)

                        'refresh
                        actionLoad()
                        FormPrepaidExpense.viewData()
                        FormPrepaidExpense.GVData.FocusedRowHandle = find_row(FormPrepaidExpense.GVData, "id_prepaid_expense", id)
                        infoCustom("Prepaid Expense : " + TxtNumber.Text.ToString + " was created successfully. Waiting for approval")
                    ElseIf Not id = "-1" Then
                        Dim note As String = addSlashes(MENote.Text)
                        Dim due_date As String = ""
                        Dim date_reff As String = ""
                        Dim sub_total As String = decimalSQL(TxtSubTotal.EditValue.ToString)
                        Dim vat_total As String = decimalSQL(TxtVAT.EditValue.ToString)
                        Dim total As String = decimalSQL(TxtTotal.EditValue.ToString)
                        Dim is_open As String = ""

                        due_date = "'" + Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
                        date_reff = "" + Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") + ""
                        is_open = "1"

                        Dim qm As String = "UPDATE tb_prepaid_expense SET id_comp=" + id_comp + ",inv_number='" + inv_no + "', created_date=NOW(), due_date=" + due_date + ", created_by='" + id_user + "', note='" + note + "', sub_total='" + sub_total + "', vat_total='" + vat_total + "', total='" + total + "', is_open='" + is_open + "', date_reff='" + date_reff + "',id_coa_tag='" & SLEUnit.EditValue.ToString & "' WHERE id_prepaid_expense='" & id & "' ; "
                        execute_non_query(qm, True, "", "", "", "")

                        'query det
                        Dim qd As String = ""
                        'delete first
                        qd = "DELETE FROM tb_prepaid_expense_det WHERE id_prepaid_expense='" & id & "'"
                        execute_non_query(qd, True, "", "", "", "")
                        'input details
                        qd = "INSERT INTO tb_prepaid_expense_det(id_prepaid_expense, id_acc, id_acc_biaya,cc, description, tax_percent, tax_value,id_currency,amount_before,kurs, amount, id_expense_type, id_b_expense, id_acc_pph, pph_percent, pph, start_date,qty_month,end_date) VALUES "
                        For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_acc As String = GVData.GetRowCellValue(d, "id_acc").ToString
                            Dim id_acc_biaya As String = GVData.GetRowCellValue(d, "id_acc_biaya").ToString
                            Dim cc As String = GVData.GetRowCellValue(d, "cc").ToString
                            Dim description As String = addSlashes(GVData.GetRowCellValue(d, "description").ToString)
                            Dim tax_percent As String = decimalSQL(GVData.GetRowCellValue(d, "tax_percent").ToString)
                            Dim tax_value As String = decimalSQL(GVData.GetRowCellValue(d, "tax_value").ToString)
                            Dim amount As String = decimalSQL(GVData.GetRowCellValue(d, "amount").ToString)
                            Dim id_expense_type As String = GVData.GetRowCellValue(d, "id_expense_type").ToString
                            Dim id_b_expense As String = GVData.GetRowCellValue(d, "id_b_expense").ToString
                            '
                            Dim start_period As String = Date.Parse(GVData.GetRowCellValue(d, "start_date").ToString).ToString("yyyy-MM-dd")
                            Dim qty_month As String = decimalSQL(GVData.GetRowCellValue(d, "qty_month").ToString)
                            Dim end_period As String = Date.Parse(GVData.GetRowCellValue(d, "end_date").ToString).ToString("yyyy-MM-dd")
                            '
                            Dim id_currency As String = GVData.GetRowCellValue(d, "id_currency").ToString
                            Dim kurs As String = decimalSQL(GVData.GetRowCellValue(d, "kurs").ToString)
                            Dim amount_before As String = decimalSQL(GVData.GetRowCellValue(d, "amount_before").ToString)
                            '
                            Dim id_acc_pph As String = "NULL"
                            Dim pph_percent As String = "0"
                            Dim pph As String = "0"
                            '
                            If GVData.GetRowCellValue(d, "pph_percent") > 0 Then
                                id_acc_pph = "'" & GVData.GetRowCellValue(d, "id_acc_pph").ToString & "'"
                                pph_percent = decimalSQL(GVData.GetRowCellValue(d, "pph_percent").ToString)
                                pph = decimalSQL(GVData.GetRowCellValue(d, "pph_value").ToString)
                            End If
                            '
                            If d > 0 Then
                                qd += ", "
                            End If
                            qd += "('" + id + "','" + id_acc + "','" + id_acc_biaya + "','" + cc + "', '" + description + "', '" + tax_percent + "', '" + tax_value + "', '" + id_currency + "', '" + amount_before + "', '" + kurs + "', '" + amount + "', '" + id_expense_type + "', '" + id_b_expense + "'," + id_acc_pph + ",'" + pph_percent + "','" + pph + "','" & start_period & "','" & qty_month & "','" & end_period & "') "
                        Next
                        '
                        If GVData.RowCount > 0 Then
                            execute_non_query(qd, True, "", "", "", "")
                        End If

                        'refresh
                        actionLoad()
                        FormPrepaidExpense.viewData()
                        FormPrepaidExpense.GVData.FocusedRowHandle = find_row(FormPrepaidExpense.GVData, "id_prepaid_expense", id)
                        infoCustom("Prepaid Expense : " + TxtNumber.Text.ToString + " was updated successfully. Waiting for approval")
                    End If
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=349 AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "349"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "349", id) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_prepaid_expense SET id_report_status=5 WHERE id_item_expense='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", "349", id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormPrepaidExpense.viewData()
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        'If id_report_status = "6" Then

        If id_report_status = "6" Then
            ReportPrepaidExpense.is_pre = False
        Else
            ReportPrepaidExpense.is_pre = True
        End If

        ReportPrepaidExpense.id = id
        ReportPrepaidExpense.dt = GCData.DataSource
        Dim Report As New ReportPrepaidExpense()
        '
        GridColumnaccount.Visible = False
        GridColumnAccountDescription.VisibleIndex = -1
        '
        GridColumnCurr.Visible = False
        GridColumnCurrView.VisibleIndex = 5
        '
        GridColumnEndPeriod.Visible = False
        GridColumnCOABiaya.Visible = False
        GridColumnCoaBiayaCol.Visible = False
        '
        GridColumnBudgetType.Visible = False
        GridColumnBudgetTypeDesc.VisibleIndex = -1
        '
        GCCC.Visible = False
        GCCCDesc.VisibleIndex = -1
        '
        GridColumnBudget.Visible = False
        GridColumnBudgetDesc.VisibleIndex = 2
        '
        GridColumnPPHCOA.Visible = False
        'GridColumnPPHDesc.VisibleIndex = 12
        GridColumnPPHPercent.VisibleIndex = 13
        GridColumnPPH.VisibleIndex = 14
        '
        GVData.BestFitColumns()
        '
        GridColumnBudgetDesc.MinWidth = 100
        GridColumnNo.MaxWidth = 30
        GridColumnCurrView.MaxWidth = 30
        GridColumnBeforeKurs.MaxWidth = 70
        GridColumnKurs.MaxWidth = 50
        GridColumnAmount.MaxWidth = 80
        GridColumnTaxPercent.MaxWidth = 30
        GridColumnTaxValue.MaxWidth = 70
        GridColumnPPHPercent.MaxWidth = 30
        GridColumnPPH.MaxWidth = 70

        'creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        'Grid Detail
        ReportStyleGridview(Report.GVData)
        Report.GVData.OptionsPrint.AllowMultilineHeaders = True
        ''============== END OF first table
        'GridColumnCurrView.VisibleIndex = -1
        'GridColumnBudgetDesc.VisibleIndex = -1
        'GridColumnBefKurs.VisibleIndex = -1
        'GridColumnKurs.VisibleIndex = -1
        'GridColumnAmount.VisibleIndex = -1
        'GridColumnTaxPercent.VisibleIndex = -1
        'GridColumnTaxValue.VisibleIndex = -1
        'GridColumnPPHDesc.VisibleIndex = 2
        'GridColumnPPHPercent.VisibleIndex = 3
        'GridColumnPPH.VisibleIndex = 4

        'GVData.BestFitColumns()

        ''creating and saving the view's layout to a new memory stream 
        'Dim str2 As System.IO.Stream
        'str2 = New System.IO.MemoryStream()
        'GVData.SaveLayoutToStream(str2, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str2.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVPPH.RestoreLayoutFromStream(str2, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str2.Seek(0, System.IO.SeekOrigin.Begin)
        ''Grid Detail
        'ReportStyleGridview(Report.GVPPH)

        ''============== END OF second table

        GridColumnAccountDescription.VisibleIndex = 1
        GCCCDesc.VisibleIndex = 2
        GridColumnBudgetTypeDesc.VisibleIndex = 3
        GridColumnBudgetDesc.VisibleIndex = 4
        GridColumnDescription.VisibleIndex = 5
        GridColumnCurrView.VisibleIndex = 6
        GridColumnBeforeKurs.VisibleIndex = 7
        GridColumnKurs.VisibleIndex = 8
        GridColumnAmount.VisibleIndex = 9
        GridColumnTaxPercent.VisibleIndex = 10
        GridColumnTaxValue.VisibleIndex = 11
        'GridColumnPPHDesc.VisibleIndex = 12
        GridColumnPPHPercent.VisibleIndex = 13
        GridColumnPPH.VisibleIndex = 14

        GridColumnNo.MaxWidth = 0
        GridColumnCurrView.MaxWidth = 0
        GridColumnBeforeKurs.MaxWidth = 0
        GridColumnKurs.MaxWidth = 0
        GridColumnAmount.MaxWidth = 0
        GridColumnTaxPercent.MaxWidth = 0
        GridColumnTaxValue.MaxWidth = 0
        GridColumnPPHPercent.MaxWidth = 0
        GridColumnPPH.MaxWidth = 0

        GVData.BestFitColumns()

        'Parse val
        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToString
        Report.LNote.Text = MENote.Text.ToString
        Report.LUnit.Text = SLEUnit.Text

        Report.LabelBeneficiary.Text = TxtCompName.Text
        Report.LabelDUelDate.Text = DEDueDate.Text

        Report.LInvNo.Text = TEInvNo.Text
        Report.LabelTotalPayment.Text = TxtTotal.Text
        Report.LSay.Text = ConvertCurrencyToIndonesian(Decimal.Parse(TxtTotal.EditValue.ToString))

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        'Else
        '    print_raw_no_export(GCData)
        'End If
        '
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "349"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        actionLoad()
        Cursor = Cursors.Default
    End Sub

    Private Sub GrossUpPPHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrossUpPPHToolStripMenuItem.Click
        If GVData.RowCount > 0 Then
            Try
                Dim dpp As Decimal = Decimal.Parse(GVData.GetFocusedRowCellValue("amount").ToString)
                Dim pph As Decimal = Decimal.Parse(GVData.GetFocusedRowCellValue("pph_percent").ToString)
                '
                Dim kurs As Decimal = Decimal.Parse(GVData.GetFocusedRowCellValue("kurs").ToString)
                '
                Dim grossup_val As Decimal = 0.00
                grossup_val = Math.Floor((100 / (100 - pph)) * dpp)
                'grossup_val = dpp - (1 - (pph / 100))
                GVData.SetFocusedRowCellValue("amount_before", grossup_val / kurs)
                GVData.SetFocusedRowCellValue("amount", grossup_val)
                calculate()
            Catch ex As Exception
                warningCustom("Please check your input")
            End Try
        End If
    End Sub
End Class