Public Class FormEmpDP
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_propose As String = "-1"

    Private Sub FormEmpDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_date()
    End Sub
    Sub load_dp()
        Dim query As String = "SELET * FROM tb_emp_dp"
    End Sub
    Sub load_date()
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub FormEmpDP_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpDP_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class