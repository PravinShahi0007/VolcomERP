Public Class FormSalthruCompare
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormSalthruCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/salthru-compare")
    End Sub

    Private Sub FormSalthruCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewData()
        DEUntil.EditValue = volcomErpApiGetDT(dt_json, 0).Rows(0)("current_date")
    End Sub
End Class