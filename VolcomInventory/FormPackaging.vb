Public Class FormPackaging
    Dim active_id_olshop As String = "-1"
    Dim d_json As New Newtonsoft.Json.Linq.JObject()

    Sub load_json()
        d_json = volcomErpApiGetJson(volcom_erp_api_host & "api/packaging")
    End Sub

    Private Sub FormPackaging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_json()
        load_online_shop()
    End Sub

    Sub load_online_shop()
        viewSearchLookupQueryO(SLEOnlineShop, volcomErpApiGetDT(d_json, 0), "id_comp_group", "description", "id_comp_group")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        active_id_olshop = SLEOnlineShop.EditValue.ToString
        LOlShop.Text = SLEOnlineShop.Text
        load_json()
        load_weight()
    End Sub

    Sub load_weight()
        GCClass.DataSource = volcomErpApiGetDT(d_json, 1).Select("[id_comp_group]='" & SLEOnlineShop.EditValue.ToString & "'")
    End Sub

    Private Sub BCreatePenawaran_Click(sender As Object, e As EventArgs) Handles BUpdateData.Click
        If GVClass.RowCount > 0 Then

        End If
    End Sub
End Class