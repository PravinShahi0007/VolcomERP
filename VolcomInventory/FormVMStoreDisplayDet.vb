Public Class FormVMStoreDisplayDet
    Public id_store As String = "-1"

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print(GCData, "Display Item List")
    End Sub

    Private Sub FormVMStoreDisplayDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class