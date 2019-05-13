Public Class FormSalesOrderReportDet
    Public id_so As String = "-1"
    Public so_number As String = "-1"

    Private Sub FormSalesOrderReportDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormSalesOrderReportDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class