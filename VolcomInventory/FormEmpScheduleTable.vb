Public Class FormEmpScheduleTable
    Private Sub FormEmpScheduleTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormEmpScheduleTableSet.ShowDialog()
    End Sub

    Private Sub FormEmpScheduleTable_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class