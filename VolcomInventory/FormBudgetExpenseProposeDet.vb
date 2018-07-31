Public Class FormBudgetExpenseProposeDet
    Public id As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "-1"
    Public id_departement As String = "-1"

    Private Sub FormBudgetExpenseProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewDept()
        actionLoad()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim query_c As New ClassBudgetExpensePropose()
            Dim query As String = query_c.queryMain("AND p.id_b_expense_propose=" + id + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            TxtYear.Text = data.Rows(0)("year").ToString
            TxtTotal.EditValue = data.Rows(0)("value_expense_total")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LEDeptSum.ItemIndex = LEDeptSum.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            id_departement = data.Rows(0)("id_departement").ToString
            allow_status()
        Else
            TxtTotal.EditValue = 0.00
            LEDeptSum.ItemIndex = LEDeptSum.Properties.GetDataSourceRowIndex("id_departement", id_departement_user)
            XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
            ActiveControl = TxtYear
        End If
    End Sub

    Sub viewDetailYearly()
        'total budgwt
        Dim query_c As New ClassBudgetExpensePropose()
        Dim query As String = "SELECT p.value_expense_total FROM tb_b_expense_propose p WHERE p.id_b_expense_propose=6"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtTotalYearly.EditValue = data.Rows(0)("value_expense_total")

        'data mapping per dept
        Dim qd As String = "SELECT ic.id_item_coa, ic.id_item_cat, cat.item_cat, ic.id_departement, d.departement,
        ic.id_coa_out,  coa.acc_name AS `exp_acc`, coa.acc_description AS `exp_description`, IFNULL(py.value_expense,0) AS `val`
        FROM tb_item_coa ic 
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = ic.id_item_cat
        INNER JOIN tb_m_departement d ON d.id_departement = ic.id_departement
        INNER JOIN tb_a_acc coa ON coa.id_acc = ic.id_coa_out
        LEFT JOIN tb_b_expense_propose_year py ON py.id_item_coa = ic.id_item_coa AND py.id_b_expense_propose=" + id + "
        WHERE ic.id_departement=" + id_departement + " AND ic.is_active=1 "
        Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
        GCYearlyCat.DataSource = dd
        GVYearlyCat.BestFitColumns()

        'get total cat
        getTotalYearlyCat()
    End Sub

    Sub getTotalYearlyCat()
        Dim query As String = "SELECT IFNULL(SUM(bd.value_expense),0) AS `total` FROM tb_b_expense_propose_year bd WHERE bd.id_b_expense_propose=" + id + ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtTotYearlyCat.EditValue = data.Rows(0)("total")
        TxtTotYearlyDiffCat.EditValue = TxtTotalYearly.EditValue - TxtTotYearlyCat.EditValue
    End Sub

    Sub viewDetailMonthly()
        'Dim query As String = ""
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCData.DataSource = data
        'GVData.BestFitColumns()
    End Sub


    Sub allow_status()
        XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then 'belum confirm
            BtnImportXLSYearlyCat.Visible = True
            BtnExportXLSYearlyCat.Visible = True
            BtnDividedYearlyCat.Visible = True
            BtnImportXLSMonthly.Visible = True
            BtnMark.Visible = False
            GVData.OptionsBehavior.Editable = True
            GCYearlyCat.ContextMenuStrip = CMSYearlyCat
        Else
            BtnImportXLSYearlyCat.Visible = False
            BtnExportXLSYearlyCat.Visible = False
            BtnDividedYearlyCat.Visible = False
            BtnImportXLSMonthly.Visible = False
            BtnMark.Visible = True
            GVData.OptionsBehavior.Editable = False
            GCYearlyCat.ContextMenuStrip = Nothing
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Visible = True
        Else
            BtnPrint.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            GVData.OptionsBehavior.Editable = False
        ElseIf id_report_status = "5" Then
            BtnImportXLSYearlyCat.Visible = False
            BtnExportXLSYearlyCat.Visible = False
            BtnDividedYearlyCat.Visible = False
            BtnImportXLSMonthly.Visible = False
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            GVData.OptionsBehavior.Editable = False
            GCYearlyCat.ContextMenuStrip = Nothing
        End If

        If is_view = "1" Then
            XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True
        End If
    End Sub

    Private Sub FormBudgetExpenseProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If XTCBudget.SelectedTabPageIndex = 0 Then
            'cek budget
            Dim cond As Boolean = True
            Dim query_c As New ClassBudgetExpensePropose()
            Dim check_upd As String = ""
            If action = "upd" Then
                check_upd = "AND p.id_b_expense_propose!=" + id + " "
            End If
            Dim queryc As String = query_c.queryMain("AND p.year='" + TxtYear.Text + "' AND p.id_departement='" + LEDeptSum.EditValue.ToString + "' AND p.id_report_status!=5 " + check_upd, "2")
            Dim data As DataTable = execute_query(queryc, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                cond = False
            End If

            If Not cond Then
                stopCustom("Expense budget : " + TxtYear.Text + " already created")
                Exit Sub
            ElseIf TxtTotal.EditValue <= 0 Then
                stopCustom("Please input total budget")
                TxtTotal.Focus()
                Exit Sub
            Else
                Cursor = Cursors.WaitCursor
                Dim id_departement As String = LEDeptSum.EditValue.ToString
                Dim number As String = ""
                Dim year As String = TxtYear.Text
                Dim value_expense_total As String = decimalSQL(TxtTotal.EditValue.ToString)
                Dim note As String = addSlashes(MENote.Text)

                If action = "ins" Then
                    Dim query As String = "INSERT INTO tb_b_expense_propose(id_departement, number, created_date, id_created_user, year, value_expense_total, note, id_report_status) 
                    VALUES('" + id_departement + "', '',NOW(),'" + id_user + "', '" + year + "', '" + value_expense_total + "', '" + note + "',1); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")

                    'update number
                    Dim qn As String = "CALL gen_number(" + id + ",136)"
                    execute_non_query(qn, True, "", "", "", "")

                    FormBudgetExpensePropose.viewData()
                    FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id)
                    action = "upd"
                    actionLoad()
                ElseIf action = "upd" Then
                    Dim query As String = "UPDATE tb_b_expense_propose SET year='" + year + "', value_expense_total='" + value_expense_total + "', note='" + note + "'
                    WHERE id_b_expense_propose='" + id + "' "
                    execute_non_query(query, True, "", "", "", "")
                    FormBudgetExpensePropose.viewData()
                    FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id)
                    action = "upd"
                    actionLoad()
                End If
                Cursor = Cursors.Default
            End If
        End If
        XTCBudget.SelectedTabPageIndex = XTCBudget.SelectedTabPageIndex + 1
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        XTCBudget.SelectedTabPageIndex = XTCBudget.SelectedTabPageIndex - 1
    End Sub

    Private Sub XTCBudget_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBudget.SelectedPageChanged
        If XTCBudget.SelectedTabPageIndex = 0 Then 'total budget
            BtnPrev.Visible = False
            BtnNext.Visible = True
            BtnConfirm.Visible = False
            TxtYear.Focus()
        ElseIf XTCBudget.SelectedTabPageIndex = 1 Then 'yearly budget
            BtnPrev.Visible = True
            BtnNext.Visible = True
            BtnConfirm.Visible = False

            'data
            viewDetailYearly()
        ElseIf XTCBudget.SelectedTabPageIndex = 2 Then 'monthly budget
            BtnPrev.Visible = True
            BtnNext.Visible = False
            If is_confirm = "2" And id_report_status! = 5 Then
                BtnConfirm.Visible = True
            Else
                BtnConfirm.Visible = False
            End If
        End If
    End Sub

    Private Sub TxtYear_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtTotal.Focus()
        End If
    End Sub

    Private Sub TxtTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnNext.Focus()
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "136"
        FormReportMark.id_report = id
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this budget ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'status
            Dim query As String = "UPDATE tb_b_expense_propose SET id_report_status=5 WHERE id_b_expense_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 136, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            'refresg
            FormBudgetExpensePropose.viewData()
            FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "136"
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click

    End Sub


    Private Sub GVYearly_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVYearlyCat.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim old_val As Decimal = GVYearlyCat.ActiveEditor.OldEditValue
        Dim row_foc As String = e.RowHandle.ToString
        Dim year As String = TxtYear.Text
        Dim id_item_coa As String = GVYearlyCat.GetRowCellValue(row_foc, "id_item_coa").ToString
        Dim value_expense As String = decimalSQL(e.Value.ToString)
        If ((TxtTotYearlyCat.EditValue - old_val) + e.Value) <= TxtTotalYearly.EditValue Then
            Dim query As String = "DELETE FROM tb_b_expense_propose_year 
            WHERE id_b_expense_propose = " + id + " And year = '" + year + "' And id_item_coa = " + id_item_coa + ";
            INSERT INTO tb_b_expense_propose_year(id_b_expense_propose, year, id_item_coa, value_expense)
            VALUES('" + id + "','" + year + "', '" + id_item_coa + "','" + value_expense + "'); "
            execute_non_query(query, True, "", "", "", "")
            GVYearlyCat.RefreshData()
            GVYearlyCat.BestFitColumns()
            getTotalYearlyCat()
        Else
            stopCustom("Total budget higher than yearly budget.")
            GVYearlyCat.SetRowCellValue(row_foc, "val", old_val)
            GVYearlyCat.RefreshData()
            GVYearlyCat.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FillReToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillReToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        GVYearlyCat.FocusedColumn = GVYearlyCat.Columns("val")
        GVYearlyCat.ShowEditor()
        GVYearlyCat.SetFocusedRowCellValue("val", TxtTotYearlyDiffCat.EditValue)
        Cursor = Cursors.Default
    End Sub

    Private Sub AddWithRemainingQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddWithRemainingQtyToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        GVYearlyCat.FocusedColumn = GVYearlyCat.Columns("val")
        GVYearlyCat.ShowEditor()
        GVYearlyCat.SetFocusedRowCellValue("val", TxtTotYearlyDiffCat.EditValue + GVYearlyCat.ActiveEditor.OldEditValue)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiffYearly_Click(sender As Object, e As EventArgs) Handles BtnDividedYearlyCat.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to divide equally value for all budget categories?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim val As Decimal = TxtTotalYearly.EditValue / GVYearlyCat.RowCount
            Dim query As String = "DELETE FROM tb_b_expense_propose_year WHERE id_b_expense_propose=6;
            INSERT INTO tb_b_expense_propose_year(id_b_expense_propose, year, id_item_coa, value_expense) VALUES "
            For i As Integer = 0 To ((GVYearlyCat.RowCount - 1) - GetGroupRowCount(GVYearlyCat))
                If i > 0 Then
                    query += ", "
                End If
                query += "('" + id + "', '" + TxtYear.Text + "', '" + GVYearlyCat.GetRowCellValue(i, "id_item_coa").ToString + "','" + decimalSQL(val.ToString) + "') "
            Next
            If GVYearlyCat.RowCount > 0 Then
                execute_non_query(query, True, "", "", "", "")
                viewDetailYearly()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportXLSYearlyCat_Click(sender As Object, e As EventArgs) Handles BtnExportXLSYearlyCat.Click
        Cursor = Cursors.WaitCursor
        GVYearlyCat.OptionsPrint.PrintFooter = False

        'export excel
        Dim printableComponentLink1 As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
        Dim path_root As String = Application.StartupPath & "\download\"
        'create directory if not exist
        If Not IO.Directory.Exists(path_root) Then
            System.IO.Directory.CreateDirectory(path_root)
        End If
        Dim fileName As String = "bex_" + TxtYear.Text + "_" + id + ".xlsx"
        Dim exp As String = IO.Path.Combine(path_root, fileName)
        printableComponentLink1.Component = GCYearlyCat
        printableComponentLink1.CreateDocument()
        printableComponentLink1.ExportToXlsx(exp)
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to open file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Process.Start(exp)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportXLSYearlyCat_Click(sender As Object, e As EventArgs) Handles BtnImportXLSYearlyCat.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "38"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub


End Class