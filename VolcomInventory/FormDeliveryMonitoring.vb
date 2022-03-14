Public Class FormDeliveryMonitoring
    Private Sub FormDeliveryMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = getTimeDB()
        DETo.EditValue = getTimeDB()

        view_type()
        view3pl()
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

        'filter 3pl
        If Not SLUE3PL.EditValue.ToString = "0" Then
            Dim dv As DataView = New DataView(data)

            dv.RowFilter = "cargo = '" + SLUE3PL.Text.ToString + "'"

            data = dv.ToTable
        End If

        'filter offline online
        If Not SLEOnlineOffline.EditValue.ToString = "3" Then
            Dim dv As DataView = New DataView(data)

            dv.RowFilter = "id_commerce_type = '" + SLEOnlineOffline.EditValue.ToString + "'"

            data = dv.ToTable
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

        Dim q2 As String = "
            SELECT 3 AS id_type, 'Offline + Online' `type` UNION ALL
            SELECT 1 AS id_type, 'Offline' `type` UNION ALL
            SELECT 2 AS id_type, 'Online' `type`
        "

        viewSearchLookupQuery(SLEOnlineOffline, q2, "id_type", "type", "id_type")
    End Sub

    Sub view3pl()
        Dim query As String = "
            SELECT 0 AS id_3pl, 'All' AS 3pl
            UNION ALL
            SELECT id_comp AS id_3pl, comp_name AS 3pl
            FROM tb_m_comp
            WHERE id_comp_cat = 7
        "

        viewSearchLookupQuery(SLUE3PL, query, "id_3pl", "3pl", "id_3pl")
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormAWBInv.ShowDialog()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_verification()
    End Sub

    Sub load_verification()
        Dim q As String = "SELECT inv.id_awb_inv_sum,sts.report_status,c.comp_name,inv.created_date,inv.inv_number,emp.employee_name,SUM(invd.amount_cargo) AS a_tot,SUM(invd.amount_wh) AS c_tot
FROM `tb_awb_inv_sum_det` invd
INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invd.id_awb_inv_sum
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=inv.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=inv.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
GROUP BY inv.id_awb_inv_sum"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCInvoice.DataSource = dt
        GVInvoice.BestFitColumns()
    End Sub

    Private Sub GVInvoice_DoubleClick(sender As Object, e As EventArgs) Handles GVInvoice.DoubleClick
        If GVInvoice.RowCount > 0 Then
            FormAWBInv.id_verification = GVInvoice.GetFocusedRowCellValue("id_awb_inv_sum").ToString
            FormAWBInv.ShowDialog()
        End If
    End Sub
End Class