Public Class FormLetterOfStatement
    Private Sub FormLetterOfStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormLetterOfStatement_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "0", "0")
    End Sub

    Private Sub FormLetterOfStatement_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormLetterOfStatement_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT p.popup, e.employee_name, s.number, s.date, s.id_letter_of_statement
            FROM tb_letter_of_statement AS s
            LEFT JOIN tb_letter_of_statement_popup AS p ON s.id_popup = p.id_letter_of_statement_popup
            LEFT JOIN tb_m_employee AS e ON s.id_employee = e.id_employee
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLetterOfStatement.DataSource = data

        GVLetterOfStatement.BestFitColumns()
    End Sub

    Sub form_print(ByVal id_letter_of_statement As String)

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        form_print(GVLetterOfStatement.GetFocusedRowCellValue("id_letter_of_statement").ToString)
    End Sub
End Class