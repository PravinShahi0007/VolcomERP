Public Class FormEmpAttnAssignDet
    Public id_emp_assign_sch As String = "-1"

    Private Sub FormEmpAttnAssignDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_emp_assign_sch = "-1" Then
            FormEmpScheduleTableSet.opt = "2"
            FormEmpScheduleTableSet.ShowDialog()
        End If
    End Sub

    Private Sub FormEmpAttnAssignDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub
End Class