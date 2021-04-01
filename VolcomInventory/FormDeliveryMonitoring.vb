Public Class FormDeliveryMonitoring
    Private Sub FormDeliveryMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now

        view_type()
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
        Dim data As DataTable = New DataTable
        Dim data_new As DataTable = New DataTable
        Dim data_old As DataTable = New DataTable

        If SLUEType.EditValue.ToString = "1" Or SLUEType.EditValue.ToString = "3" Then
            'new
            Dim query_new As String = "CALL view_outbound_delivery_monitoring('" + Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") + "');"

            data_new = execute_query(query_new, -1, True, "", "", "", "")

            If data.Columns.Count = 0 Then
                data = data_new.Clone()
            End If

            data.Merge(data_new)
        End If

        If SLUEType.EditValue.ToString = "2" Or SLUEType.EditValue.ToString = "3" Then
            'old
            Dim query_old As String = "CALL view_outbound_delivery_monitoring_old('" + Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") + "');"

            data_old = execute_query(query_old, -1, True, "", "", "", "")

            If data.Columns.Count = 0 Then
                data = data_old.Clone()
            End If

            data.Merge(data_old)
        End If

        'numbering
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
        Cursor = Cursors.WaitCursor
        view_outbound()
        Cursor = Cursors.Default
    End Sub

    Private Sub BAWBRec_Click(sender As Object, e As EventArgs) Handles BAWBRec.Click
        FormImportExcel.id_pop_up = "35"
        FormImportExcel.ShowDialog()
    End Sub

    Sub view_type()
        Dim query As String = "
            SELECT 1 AS id_type, 'New' `type` UNION ALL
            SELECT 2 AS id_type, 'Old' `type` UNION ALL
            SELECT 3 AS id_type, 'All' `type`
        "

        viewSearchLookupQuery(SLUEType, query, "id_type", "type", "id_type")
    End Sub
End Class