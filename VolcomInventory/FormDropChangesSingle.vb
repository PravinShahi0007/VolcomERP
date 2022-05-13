Public Class FormDropChangesSingle
    Public id_season As String = "-1"
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormDropChangesSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/dropchanges-product/" + id_season + "")
        viewStt()
        viewSeasonMove()
    End Sub

    Sub viewStt()
        viewSearchLookupQueryO(SLEStatus, volcomErpApiGetDT(dt_json, 0), "id_lookup_status_order", "lookup_status_order", "id_lookup_status_order")
        SLEStatus.EditValue = Nothing
    End Sub

    Sub viewSeasonMove()
        viewSearchLookupQueryO(SLESeasonMove, volcomErpApiGetDT(dt_json, 1), "id_delivery", "season_del", "id_delivery")
        SLESeasonMove.EditValue = Nothing
    End Sub
End Class