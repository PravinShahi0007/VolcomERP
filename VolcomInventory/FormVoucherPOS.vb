Public Class FormVoucherPOS
    Private Sub FormVoucherPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewVoucher()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT v.id_pos_voucher, v.voucher_number, v.voucher_value, v.voucher_name, v.voucher_address, 
        v.period_start, v.period_end, v.id_outlet, sc.outlet_name 
        FROM tb_pos_voucher v
        LEFT JOIN tb_store_conn sc ON sc.id_outlet = v.id_outlet "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormVoucherPOS_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormVoucherPOS_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class