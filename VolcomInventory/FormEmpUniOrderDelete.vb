Public Class FormEmpUniOrderDelete
    Private Sub FormEmpUniOrderDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub choose()
        If TxtNo.Text <> "" Then
            FormEmpUniOrderDet.GVItemList.ActiveFilterString = "[no]='" + addSlashes(TxtNo.Text.ToString) + "'"
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormEmpUniOrderDelete_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        choose()
    End Sub
End Class