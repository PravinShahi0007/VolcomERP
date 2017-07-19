Public Class FormEmpUniOrderNew
    Private Sub FormEmpUniOrderNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_emp_uni_budget(" + FormEmpUniPeriodDet.id_emp_uni_period + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GCDetail.Focus()
        GVDetail.Focus()
    End Sub

    Sub chooseEmp()
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            infoCustom("OK")
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        chooseEmp()
    End Sub

    Private Sub FormEmpUniOrderNew_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            chooseEmp()
        End If
    End Sub
End Class