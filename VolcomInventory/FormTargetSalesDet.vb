Public Class FormTargetSalesDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "414"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormTargetSalesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormTargetSalesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class