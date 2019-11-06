Public Class FormDebitNoteDet
    Public id_dn As String = "-1"

    Private Sub FormDebitNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_det()
        Dim query As String = ""
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDebitNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub
End Class