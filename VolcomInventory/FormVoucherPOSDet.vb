Public Class FormVoucherPOSDet
    Public id As String = "-1"
    Public action As String = "-1"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormVoucherPOSDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtVoucherNumber.Focus()
        If action = "ins" Then
            Dim tgl As DateTime = getTimeDB()
            DEStart.EditValue = tgl
            DEEnd.EditValue = tgl
        Else

        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub
End Class