Public Class FormBuktiPickupPick
    Public id_comp As String = "0"

    Private Sub FormBuktiPickupPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Date.Parse(Now)
        DEUntil.EditValue = Date.Parse(Now)
    End Sub

    Private Sub FormBuktiPickupPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DEUntil.Properties.MinValue = DEFrom.EditValue
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Dim date_from As String = Date.Parse(DEFrom.EditValue.ToString)
        Dim date_to As String = Date.Parse(DEUntil.EditValue.ToString)

        Dim query As String = ""
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class