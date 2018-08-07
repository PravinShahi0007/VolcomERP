Public Class FormBudgetExpenseRevisionNew
    Private Sub FormBudgetExpenseRevisionNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewAnnual()
        SLEYear.Focus()
    End Sub

    Sub viewAnnual()
        Dim b As New ClassBudgetExpensePropose()
        Dim query As String = b.queryMain("AND p.id_departement='" + id_departement_user + "' AND p.id_report_status=6 ", "2")
        viewSearchLookupQuery(SLEYear, query, "id_b_expense_propose", "year", "id_b_expense_propose")
    End Sub


    Private Sub FormBudgetExpenseRevisionNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Private Sub SLEYear_EditValueChanged(sender As Object, e As EventArgs) Handles SLEYear.EditValueChanged
        Try
            TxtDept.Text = SLEYear.Properties.View.GetFocusedRowCellValue("departement").ToString
            TxtNumber.Text = SLEYear.Properties.View.GetFocusedRowCellValue("number").ToString
        Catch ex As Exception
            TxtDept.Text = ""
            TxtNumber.Text = ""
        End Try
    End Sub
End Class