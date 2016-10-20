Public Class FormEmpLeaveDet
    Public id_emp_leave As String = "-1"
    Public id_employee As String = "-1"
    Private Sub FormEmpLeaveDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        check_but()
    End Sub

    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "1"
        FormPopUpEmployee.ShowDialog()
    End Sub

    Sub check_but()
        If GVLeaveDet.RowCount > 0 Then
            BEditLeave.Visible = True
            BDelLeave.Visible = True
        Else
            BEditLeave.Visible = True
            BDelLeave.Visible = True
        End If
    End Sub
End Class