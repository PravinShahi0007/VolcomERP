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
                    End If
                Next
            Next
        Else
            stopCustom("Please choose the employee.")
            FormEmpScheduleTableSet.ShowDialog()
        End If
    End Sub
End Class