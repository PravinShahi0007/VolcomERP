Public Class FormSalthruCompare
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormSalthruCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/salthru-compare")
        DEUntil.EditValue = volcomErpApiGetDT(dt_json, 0).Rows(0)("current_date")
        viewSeason()
    End Sub

    Private Sub FormSalthruCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewSeason()
        Dim data As DataTable = volcomErpApiGetDT(dt_json, 1)

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("season").ToString
            c.Value = data.Rows(i)("id_season").ToString

            CCBESeason.Properties.Items.Add(c)
        Next
    End Sub

    Sub viewData()

    End Sub
End Class