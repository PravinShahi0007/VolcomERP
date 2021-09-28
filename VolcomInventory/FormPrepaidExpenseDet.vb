Public Class FormPrepaidExpenseDet
    Public id As String = "-1"
    Public id_coa_tag As String = "1"
    Public is_view As String = "-1"

    Dim id_report_status As String = "-1"
    Public id_comp As String = "-1"

    Dim created_date As String = ""

    Private Sub FormPrepaidExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPrepaidExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateReff.EditValue = Now()
        load_unit()
        '
        viewReportStatus()
        viewCCRepo()
        viewCOAPPH()
        viewCOARepo()
        '
        view_repo_cat()
        view_repo_type()
        '
        actionLoad()
        '
        GridColumnPPH.UnboundExpression = "Iif([id_acc_pph] = " & get_opt_acc_field("id_acc_skbp") & ", 0, floor([pph_percent] / 100 * [amount]))"

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

            Dim query As String = ""
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_coa_tag = data.Rows(0)("id_coa_tag").ToString
            SLEUnit.EditValue = id_coa_tag

            Dim is_pay_later As String = data.Rows(0)("is_pay_later").ToString
            If is_pay_later = "1" Then
                id_comp = data.Rows(0)("id_comp").ToString
                TxtCompNumber.Text = data.Rows(0)("comp_number").ToString
                TxtCompName.Text = data.Rows(0)("comp_name").ToString
                DEDueDate.EditValue = data.Rows(0)("due_date")
                DEDateReff.EditValue = data.Rows(0)("date_reff")
            End If

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

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim q_year As String = ""
        Dim query As String = "SELECT 'no' AS is_lock,ed.start_date,ed.qty_month,ed.amount,ed.id_prepaid_expense_det,ed.cc,c.comp_number AS cc_desc, ed.id_prepaid_expense,ed.id_expense_type,ed.id_b_expense,bex.item_cat_main,typ.expense_type,
        ed.id_acc,pphacc.acc_description AS coa_desc_pph,a.id_acc_cat, a.acc_description AS `coa_desc`, ed.description,a.acc_name,ed.id_acc_pph,ed.pph_percent,ed.pph, "

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
        INNER JOIN tb_lookup_expense_type typ ON typ.id_expense_type=ed.id_expense_type
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
        GVData.SetRowCellValue(GVData.RowCount - 1, "qty_month", "1")
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "amount", 0)
        GVData.SetRowCellValue(GVData.RowCount - 1, "tax_percent", 0)
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "pph_percent", 0)
        '
        GVData.BestFitColumns()
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

        'cek empty
        Dim cond_empty As Boolean = False
        GVData.ActiveFilterString = "[amount] Is Null OR [amount]=0 OR IsNullOrEmpty([id_acc]) OR ([pph_percent]>0 AND IsNullOrEmpty([id_acc_pph]))"
        If GVData.RowCount > 0 Then
            cond_empty = True
        End If
        makeSafeGV(GVData)

        If cond_empty Then
            warningCustom("Please complete all detail data")
        ElseIf GVData.RowCount <= 0 Then
            warningCustom("Please input detail expense")
        ElseIf TEInvNo.Text = "" Then
            warningCustom("Please input invoice number")
        ElseIf MENote.Text = "" Then
            warningCustom("Please put some note")
        ElseIf DEDateReff.Text = "" Then
            warningCustom("Please put refference date")
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


                        Dim qm As String = "INSERT INTO tb_prepaid_expense(id_comp,inv_number, created_date, due_date, created_by, id_report_status, note, sub_total, vat_total, total, is_open, date_reff, id_coa_tag) VALUES 
                (" + id_comp + ",'" + inv_no + "', NOW()," + due_date + ", '" + id_user + "', 1, '" + note + "','" + sub_total + "', '" + vat_total + "', '" + total + "', '" + is_open + "', '" + date_reff + "','" & SLEUnit.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                        id = execute_query(qm, 0, True, "", "", "", "")
                        execute_non_query("CALL gen_number(" + id + ",349); ", True, "", "", "", "")

                        'query det
                        Dim qd As String = "INSERT INTO tb_prepaid_expense_det(id_prepaid_expense, id_acc,cc, description, tax_percent, tax_value, amount, id_expense_type, id_b_expense, id_acc_pph, pph_percent, pph, start_date,qty_month,end_date) VALUES "
                        For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_acc As String = GVData.GetRowCellValue(d, "id_acc").ToString
                            Dim cc As String = GVData.GetRowCellValue(d, "cc").ToString
                            Dim description As String = addSlashes(GVData.GetRowCellValue(d, "description").ToString)
                            Dim tax_percent As String = decimalSQL(GVData.GetRowCellValue(d, "tax_percent").ToString)
                            Dim tax_value As String = decimalSQL(GVData.GetRowCellValue(d, "tax_value").ToString)
                            Dim amount As String = decimalSQL(GVData.GetRowCellValue(d, "amount").ToString)
                            Dim id_expense_type As String = GVData.GetRowCellValue(d, "id_expense_type").ToString
                            Dim id_b_expense As String = GVData.GetRowCellValue(d, "id_b_expense").ToString
                            '
                            Dim start_period As String = GVData.GetRowCellValue(d, "start_date").ToString
                            Dim qty_month As String = decimalSQL(GVData.GetRowCellValue(d, "qty_month").ToString)
                            Dim end_period As String = GVData.GetRowCellValue(d, "end_date").ToString
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
                            qd += "('" + id + "','" + id_acc + "','" + cc + "', '" + description + "', '" + tax_percent + "', '" + tax_value + "', '" + amount + "', '" + id_expense_type + "', '" + id_b_expense + "'," + id_acc_pph + ",'" + pph_percent + "','" + pph + "','" & start_period & "','" & qty_month & "','" & end_period & "') "
                        Next
                        '
                        If GVData.RowCount > 0 Then
                            execute_non_query(qd, True, "", "", "", "")
                        End If

                        'submit
                        submit_who_prepared("349", id, id_user)

                        'refresh
                        actionLoad()
                        FormItemExpense.viewData()
                        FormItemExpense.GVData.FocusedRowHandle = find_row(FormItemExpense.GVData, "id_item_expense", id)
                        infoCustom("Prepaid Expense : " + TxtNumber.Text.ToString + " was created successfully. Waiting for approval")
                    ElseIf Not id = "-1" Then
                        'no more edit for u
                    End If
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub
End Class