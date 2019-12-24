Public Class FormAccountingLedger
    Private Sub FormAccountingLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now

        DETo.Properties.MinValue = Now

        viewSearchLookupQuery(SLUEFrom, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc ORDER BY acc_name ASC", "acc_name", "acc_name_description", "acc_name")

        view_acc_to()
    End Sub

    Private Sub FormAccountingLedger_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAccountingLedger_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormAccountingLedger_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_form()
        Dim acc_range As DataTable = execute_query("SELECT acc_name FROM tb_a_acc WHERE CAST(acc_name AS UNSIGNED) >= " + SLUEFrom.EditValue.ToString + " AND CAST(acc_name AS UNSIGNED) <= " + SLUETo.EditValue.ToString, -1, True, "", "", "", "")

        Dim acc_name As String = ""

        For i = 0 To acc_range.Rows.Count - 1
            acc_name += "acc.acc_name LIKE \'" + acc_range.Rows(i)("acc_name").ToString + "%\' OR "
        Next

        acc_name = "(" + acc_name.Substring(0, acc_name.Length - 4) + ")"

        Dim query As String = "CALL view_acc_ledger('" + Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + acc_name + "')"

        GCAccountingLedger.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVAccountingLedger.BestFitColumns()
    End Sub

    Sub print_form()

    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        view_form()
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DETo.Properties.MinValue = DEFrom.EditValue
    End Sub

    Sub view_acc_to()
        viewSearchLookupQuery(SLUETo, "SELECT acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) AS acc_name_description FROM tb_a_acc WHERE CAST(acc_name AS UNSIGNED) >= " + SLUEFrom.EditValue.ToString + " AND CHAR_LENGTH(acc_name) = " + SLUEFrom.EditValue.ToString.Length.ToString + " ORDER BY acc_name ASC", "acc_name", "acc_name_description", "acc_name")
    End Sub

    Private Sub SLUEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEFrom.EditValueChanged
        view_acc_to()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()

        showpopup.report_mark_type = GVAccountingLedger.GetFocusedRowCellValue("report_mark_type").ToString
        showpopup.id_report = GVAccountingLedger.GetFocusedRowCellValue("id_report").ToString
        showpopup.show()

        Cursor = Cursors.Default
    End Sub

    Private Sub ViewReffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewReffToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()

        showpopup.report_mark_type = GVAccountingLedger.GetFocusedRowCellValue("report_mark_type_ref").ToString
        showpopup.id_report = GVAccountingLedger.GetFocusedRowCellValue("id_report_ref").ToString
        showpopup.show()

        Cursor = Cursors.Default
    End Sub
End Class