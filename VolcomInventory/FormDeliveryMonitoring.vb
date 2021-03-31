Public Class FormDeliveryMonitoring
    Private Sub FormDeliveryMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now
    End Sub

    Private Sub FormDeliveryMonitoring_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDeliveryMonitoring_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormDeliveryMonitoring_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_outbound()
        Dim query As String = "CALL view_outbound_delivery_monitoring('" + Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") + "');"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            data.Rows(i)("no") = i + 1
        Next

        GCOutbound.DataSource = data

        GVOutbound.BestFitColumns()
    End Sub

    Sub print_outbound()
        print_raw(GCOutbound, "Outbound Delivery Monitoring")
    End Sub

    Private Sub SBViewOutbound_Click(sender As Object, e As EventArgs) Handles SBViewOutbound.Click
        view_outbound()
    End Sub
End Class