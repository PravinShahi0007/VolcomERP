Public Class FormEmpScheduleTable
    Private Sub FormEmpScheduleTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormEmpScheduleTableSet.ShowDialog()
    End Sub

    Private Sub FormEmpScheduleTable_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSetSchedule_Click(sender As Object, e As EventArgs) Handles BSetSchedule.Click
        If GVSchedule.RowCount > 0 Then
            For i As Integer = 0 To GVSchedule.RowCount - 1
                For j As Integer = 0 To GVSchedule.Columns.Count - 1
                    If Not (GVSchedule.Columns(j).FieldName = "id_employee" Or GVSchedule.Columns(j).FieldName = "employee_code" Or GVSchedule.Columns(j).FieldName = "employee_name") Then
                        Dim date_string As String = GVSchedule.Columns(j).FieldName.ToString
                        MsgBox(get_schedule(GVSchedule.GetRowCellValue(i, GVSchedule.Columns(j).FieldName.ToString).ToString))
                    End If
                Next
            Next
        Else
            stopCustom("Please choose the employee.")
            FormEmpScheduleTableSet.ShowDialog()
        End If
    End Sub
    Function get_schedule(ByVal shift_code As String)
        Dim id_schedule = ""
        If Not shift_code = "" Then
            Dim query As String = "SELECT id_schedule FROM tb_emp_schedule WHERE shift_code='" & shift_code & "' LIMIT 1"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_schedule = data.Rows(0)("id_schedule").ToString
        End If
        Return id_schedule
    End Function

End Class