Public Class FormMasterEmployeeCustom
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        If period = "" Then
            stopCustom("Date can't blank !")
        Else
            Close()
            FormMasterEmployee.SplashScreenManager1.ShowWaitForm()
            FormMasterEmployee.viewEmployee("AND emp.id_employee_status=''1'' AND emp.end_period<=DATE_ADD(" + period + ",INTERVAL 3 MONTH)")
            FormMasterEmployee.SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub FormMasterEmployeeCustom_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class