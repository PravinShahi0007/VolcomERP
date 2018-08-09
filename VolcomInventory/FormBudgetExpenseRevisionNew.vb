Public Class FormBudgetExpenseRevisionNew
    Private Sub FormBudgetExpenseRevisionNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewAnnual()
        SLEYear.Focus()
    End Sub

    Sub viewAnnual()
        Dim query As String = "SELECT b.year 
        FROM tb_b_expense b
        INNER JOIN tb_item_coa c ON c.id_item_coa = b.id_item_coa
        WHERE c.id_departement='" + id_departement_user + "'
        GROUP BY b.year "
        viewSearchLookupQuery(SLEYear, query, "year", "year", "year")
    End Sub


    Private Sub FormBudgetExpenseRevisionNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        If SLEYear.EditValue = Nothing Or MEReason.Text = "" Then
            stopCustom("All fields are required.")
        Else
            'check outstanding
            Dim cond_exist = False
            Dim qex As String = "SELECT * FROM tb_b_expense_revision WHERE year='" + SLEYear.Text.ToString + "' AND id_departement='" + id_departement_user + "' AND (id_report_status=1 OR id_report_status=3) "
            Dim dex As DataTable = execute_query(qex, -1, True, "", "", "", "")
            If dex.Rows.Count > 0 Then
                cond_exist = True
            End If

            If cond_exist Then
                stopCustom("Can't revision of the budget, because there is a revision that is being processed.")
            Else
                Dim year As String = SLEYear.Text.ToString
                Dim query As String = "INSERT INTO tb_b_expense_revision(id_departement, year, created_date, id_created_user, value_expense_total, note, id_report_status) 
                VALUES('" + id_departement_user + "', '" + year + "', NOW(), '" + id_user + "',0,'" + addSlashes(MEReason.Text) + "',1); SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")

                'update number
                Dim qn As String = "CALL gen_number(" + id + ",138)"
                execute_non_query(qn, True, "", "", "", "")

                'refresh
                FormBudgetExpenseRevision.viewData()
                FormBudgetExpenseRevision.GVData.FocusedRowHandle = find_row(FormBudgetExpenseRevision.GVData, "id_b_expense_revision", id)
                FormBudgetExpenseRevisionDet.id = id
                FormBudgetExpenseRevisionDet.ShowDialog()
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEYear_EditValueChanged(sender As Object, e As EventArgs) Handles SLEYear.EditValueChanged

    End Sub
End Class