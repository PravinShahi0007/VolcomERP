Public Class FormEmpInitialize
    Private Sub FormEmpInitialize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewEmployee()
    End Sub

    Sub viewEmployee()
        Dim query As String = "CALL view_employee('-1', 2)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
    End Sub

    Private Sub FormEmpInitialize_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormEmpInitialize_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub




    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        If GVEmployee.RowCount > 0 And GVEmployee.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If GVEmployee.RowCount > 0 Then
            Dim cek As String = CheckEdit1.EditValue.ToString
            For i As Integer = 0 To ((GVEmployee.RowCount - 1) - GetGroupRowCount(GVEmployee))
                If cek Then
                    GVEmployee.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVEmployee.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub
End Class