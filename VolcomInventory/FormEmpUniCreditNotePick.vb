Public Class FormEmpUniCreditNotePick
    Private Sub FormEmpUniCreditNotePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormEmpUniCreditNotePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_form()
        Cursor = Cursors.WaitCursor

        'prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"

        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassEmpUniExpense = New ClassEmpUniExpense()

        Dim query As String = query_c.queryMain("AND (e.emp_uni_ex_date >= '" + date_from_selected + "' AND e.emp_uni_ex_date <= '" + date_until_selected + "') ", "2")

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        view_form()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        FormEmpUniCreditNoteDet.load_ref(GVData.GetFocusedRowCellValue("id_emp_uni_ex").ToString)

        Close()
    End Sub
End Class