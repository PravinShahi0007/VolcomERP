Public Class FormEmpDP
    Private Sub FormEmpDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_date()
    End Sub
    Sub load_date()
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub
End Class