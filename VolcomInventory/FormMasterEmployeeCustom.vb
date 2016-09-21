Public Class FormMasterEmployeeCustom
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        If period = "" Then
            stopCustom("Date can't blank !")
        Else
            Close()
            FormMasterEmployee.SplashScreenManager1.ShowWaitForm()
            FormMasterEmployee.viewEmployee("AND emp.id_employee_active=''1'' AND emp.id_employee_status=''1'' AND emp.end_period<=DATE_ADD(''" + period + "'',INTERVAL 3 MONTH)")
            FormMasterEmployee.SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub FormMasterEmployeeCustom_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterEmployeeCustom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEStart.EditValue = data_dt.Rows(0)("dt")
    End Sub
End Class