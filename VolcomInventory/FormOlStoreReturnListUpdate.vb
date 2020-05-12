Public Class FormOlStoreReturnListUpdate
    Private Sub FormOlStoreReturnListUpdate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_status()
        Dim q As String = "SELECT id_ol_store_ret_stt,ol_store_ret_stt
FROM `tb_lookup_ol_store_ret_stt`
WHERE is_only_cs='1'"
        viewSearchLookupQuery(SLEStatus, q, "id_ol_store_ret_stt", "ol_store_ret_stt", "id_ol_store_ret_stt")
    End Sub

    Private Sub FormOlStoreReturnListUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_status()
    End Sub

    Private Sub BSetStatus_Click(sender As Object, e As EventArgs) Handles BSetStatus.Click
        FormMain.SplashScreenManager1.ShowWaitForm()
        Dim q As String = ""
        For i As Integer = 0 To FormOlStoreReturnList.GVList.RowCount - 1
            Dim order_number As String = FormOlStoreReturnList.GVList.GetRowCellValue(i, "sales_order_ol_shop_number").ToString
            If SLEStatus.EditValue.ToString <> "2" Then
                q += "UPDATE tb_ol_store_ret_list SET id_ol_store_ret_stt='" & SLEStatus.EditValue.ToString & "',update_by='" & id_user & "',update_date=NOW() WHERE `id_ol_store_ret_list`='" & FormOlStoreReturnList.GVList.GetRowCellValue(i, "id_ol_store_ret_list").ToString & "';"
            Else
                'on process refund
                FormMain.SplashScreenManager1.SetWaitFormDescription("Checking invoice : " + order_number)
                Dim id_ol_store_ret_list As String = FormOlStoreReturnList.GVList.GetRowCellValue(i, "id_ol_store_ret_list").ToString
                Dim qcek As String = "SELECT * FROM tb_ol_store_ret_list l
                INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
                INNER JOIN tb_sales_pos_det id ON id.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
                INNER JOIN tb_sales_pos i ON i.id_sales_pos = id.id_sales_pos
                WHERE l.id_ol_store_ret_list=" + id_ol_store_ret_list + " AND i.id_report_status!=5 "
                Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
                Dim id_stt As String = ""
                If dcek.Rows.Count > 0 Then
                    id_stt = "6"
                Else
                    id_stt = "7"
                End If
                q += "UPDATE tb_ol_store_ret_list SET id_ol_store_ret_stt='" & id_stt & "',update_by='" & id_user & "',update_date=NOW() WHERE `id_ol_store_ret_list`='" & id_ol_store_ret_list & "';"
            End If
        Next
        FormMain.SplashScreenManager1.SetWaitFormDescription("Updating status")
        execute_non_query(q, True, "", "", "", "")
        FormOlStoreReturnList.view_list()
        FormMain.SplashScreenManager1.CloseWaitForm()
        infoCustom("Update status completed")
        Close()
    End Sub
End Class