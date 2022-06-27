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

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor

        'cek closing
        Dim y As String = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy")
        Dim m As String = DateTime.Parse(DEUntil.EditValue.ToString).ToString("MM")
        checkClosingSOHSalPeriod(m, y)

        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        'cek date
        Dim date_until_selected As String = "0000-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'season
        Dim where_string As String = ""
        If Not CCBESeason.EditValue.ToString = "" Then
            where_string += "AND d.id_season IN(" + CCBESeason.EditValue.ToString + ") "
        End If

        Dim query As String = "CALL view_compare_sal_thru('" + date_until_selected + "', '" + where_string + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub
End Class