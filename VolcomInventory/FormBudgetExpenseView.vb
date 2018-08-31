Public Class FormBudgetExpenseView
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_view As String = "-1"

    Private Sub FormBudgetExpenseView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewCat()
        viewYear()
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Sub viewYear()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim j As Integer = 0
        Dim dym As DataTable = execute_query("SELECT YEAR(DATE_ADD(NOW(),INTERVAL 10 YEAR)) AS `ym`", -1, True, "", "", "", "")
        For i As Integer = 2018 To dym.Rows(0)("ym")
            If j > 0 Then
                query += "UNION ALL "
            End If
            query += "SELECT " + i.ToString + " AS `year` "
            j += 1
        Next
        viewLookupQuery(LEYear, query, 0, "year", "year")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cond_cat As String = ""
        If LECat.EditValue.ToString <> "0" Then
            cond_cat = "AND c.id_item_cat = '" + LECat.EditValue.ToString + "' "
        End If
        Dim query As String = "SELECT c.id_item_coa,coa.acc_name AS `exp_acc`, coa.acc_description AS `exp_description`, cat.item_cat, et.expense_type,
        IFNULL(SUM(case when MONTH(em.month) = '1' THEN em.value_expense END),0) AS `1_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '2' THEN em.value_expense END),0) AS `2_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '3' THEN em.value_expense END),0) AS `3_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '4' THEN em.value_expense END),0) AS `4_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '5' THEN em.value_expense END),0) AS `5_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '6' THEN em.value_expense END),0) AS `6_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '7' THEN em.value_expense END),0) AS `7_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '8' THEN em.value_expense END),0) AS `8_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '9' THEN em.value_expense END),0) AS `9_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '10' THEN em.value_expense END),0) AS `10_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '11' THEN em.value_expense END),0) AS `11_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '12' THEN em.value_expense END),0) AS `12_budget`,
        0 AS `1_actual`,
        0 AS `2_actual`,
        0 AS `3_actual`,
        0 AS `4_actual`,
        0 AS `5_actual`,
        0 AS `6_actual`,
        0 AS `7_actual`,
        0 AS `8_actual`,
        0 AS `9_actual`,
        0 AS `10_actual`,
        0 AS `11_actual`,
        0 AS `12_actual`
        FROM tb_b_expense_month em
        LEFT JOIN tb_b_expense e ON e.id_b_expense = em.id_b_expense
        LEFT JOIN tb_item_coa c ON c.id_item_coa = e.id_item_coa
        LEFT JOIN tb_item_cat cat ON cat.id_item_cat = c.id_item_cat
        LEFT JOIN tb_lookup_expense_type et ON et.id_expense_type = cat.id_expense_type
        LEFT JOIN tb_a_acc coa ON coa.id_acc = c.id_coa_out
        WHERE c.id_departement='" + LEDeptSum.EditValue.ToString + "' AND e.year='" + LEYear.Text.ToString + "' 
        " + cond_cat + "
        GROUP BY e.id_item_coa "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub check_menu()
        If GVData.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVData.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormBudgetExpenseView_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormBudgetExpenseView_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Dim dtb_hist As DataTable = Nothing
    Private Sub CEBudgetHistory_CheckedChanged(sender As Object, e As EventArgs) Handles CEBudgetHistory.CheckedChanged
        dtb_hist = Nothing
        GCBudgetHist.DataSource = Nothing
        If CEBudgetHistory.EditValue = True Then
            GroupControlBudgetRevision.Visible = True
            Dim query As String = "SELECT c.id_item_coa, m.month, CONCAT(MONTH(m.month),'_','budget') AS `col_name`, COUNT(m.month) AS `jum` 
            FROM tb_b_expense_month_log ml
            INNER JOIN tb_b_expense_month m ON m.id_b_expense_month = ml.id_b_expense_month
            INNER JOIN tb_b_expense e ON e.id_b_expense = m.id_b_expense
            INNER JOIN tb_item_coa c ON c.id_item_coa = e.id_item_coa
            WHERE e.year='" + LEYear.EditValue.ToString + "' AND c.id_departement='" + LEDeptSum.EditValue.ToString + "' AND ml.report_mark_type=138 
            GROUP BY c.id_item_coa,m.month
            HAVING jum>0 "
            dtb_hist = execute_query(query, -1, True, "", "", "", "")
            viewBudgetHistory()
        Else
            GroupControlBudgetRevision.Visible = False
        End If
        AddHandler GVData.RowCellStyle, AddressOf custom_cell
        GCData.Focus()
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEBudgetHistory.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If e.Column.FieldName.ToString.Contains("_budget") Then
                Dim data_filter_cek As DataRow() = dtb_hist.Select("[id_item_coa]='" + currview.GetRowCellValue(e.RowHandle, "id_item_coa").ToString + "' AND [col_name]='" + e.Column.FieldName.ToString + "'")
                If data_filter_cek.Length > 0 Then
                    If e.Column.FieldName.ToString = data_filter_cek(0)("col_name").ToString Then
                        e.Appearance.BackColor = Color.Yellow
                    Else
                        e.Appearance.BackColor = Color.Empty
                    End If
                Else
                    e.Appearance.BackColor = Color.Empty
                End If
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Public Sub custom_cell_default(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If e.Column.FieldName.ToString.Contains("_budget") Then
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub GVData_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVData.FocusedColumnChanged
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 And CEBudgetHistory.EditValue = True Then
            viewBudgetHistory()
        End If
    End Sub

    Sub viewBudgetHistory()
        Cursor = Cursors.WaitCursor
        If GVData.FocusedColumn.FieldName.ToString.Contains("_budget") Then
            Dim col_foc As String() = GVData.FocusedColumn.FieldName.ToString.Split("_")
            Dim col As String = col_foc(0)
            Dim month As String = LEYear.Text + "-" + col + "-" + "01"
            Dim id_item_coa As String = GVData.GetFocusedRowCellValue("id_item_coa").ToString
            Dim query As String = "SELECT IF(ml.report_mark_type=136,p.number, r.number) AS `trans_number`,
            ml.log_date AS `trans_date`, ml.value_old AS `trans_before_value`, ml.value_new AS `trans_after_value`, ml.id_report, ml.report_mark_type
            FROM tb_b_expense_month_log ml
            INNER JOIN  tb_b_expense_month m ON m.id_b_expense_month = ml.id_b_expense_month
            INNER JOIN tb_b_expense e ON e.id_b_expense = m.id_b_expense
            INNER JOIN tb_item_coa c ON c.id_item_coa = e.id_item_coa
            LEFT JOIN tb_b_expense_propose p ON p.id_b_expense_propose = ml.id_report AND ml.report_mark_type=136
            LEFT JOIN tb_b_expense_revision r ON r.id_b_expense_revision = ml.id_report AND ml.report_mark_type=138
            WHERE e.year='" + LEYear.EditValue.ToString + "' AND c.id_departement='" + LEDeptSum.EditValue.ToString + "' AND e.id_item_coa='" + id_item_coa + "' AND m.month='" + month + "'
            ORDER BY ml.id_b_expense_month_log ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBudgetHist.DataSource = data
            GVBudgetHist.BestFitColumns()
        Else
            GCBudgetHist.DataSource = Nothing
            GVBudgetHist.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 And CEBudgetHistory.EditValue = True Then
            viewBudgetHistory()
        End If
    End Sub

    Private Sub GVBudgetHist_DoubleClick(sender As Object, e As EventArgs) Handles GVBudgetHist.DoubleClick
        If GVBudgetHist.RowCount > 0 And GVBudgetHist.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_report As String = GVBudgetHist.GetFocusedRowCellValue("id_report").ToString
            Dim rmt As String = GVBudgetHist.GetFocusedRowCellValue("report_mark_type").ToString
            Dim p As New ClassShowPopUp()
            p.id_report = id_report
            p.report_mark_type = rmt
            p.show()
            Cursor = Cursors.Default
        End If
    End Sub
End Class