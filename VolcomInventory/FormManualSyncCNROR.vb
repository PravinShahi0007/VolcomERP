Public Class FormManualSyncCNROR
    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim comp_not_in As String = execute_query("SELECT GROUP_CONCAT(DISTINCT o.id_store) FROM tb_m_comp_volcom_ol o", 0, True, "", "", "", "")
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2
        WHERE c.id_comp NOT IN (" + comp_not_in + ")
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormManualSyncCNROR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewData()
    End Sub

    Private Sub FormManualSyncCNROR_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT a.id_ol_store_return_order, a.id_comp_group, cg.comp_group, a.created_date, a.order_number, so.customer_name,
        a.ol_store_id, a.item_id, p.product_full_code AS `code`, p.product_name AS `name`, cd.display_name AS `size`, a.qty, 
        a.id_sales_order, a.id_sales_order_det, a.id_sales_pos_det, a.id_sales_pos, a.id_cn, 
        a.id_ror, ro.sales_return_order_number, a.is_process, IF(a.is_process=1,'Yes', 'No') AS `is_process_view`, a.process_date,
        a.is_manual_sync, a.manual_sync_by, emp.employee_name AS `manual_sync_by_name`
        FROM tb_ol_store_return_order a
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = a.id_comp_group
        INNER JOIN tb_sales_order so ON so.id_sales_order = a.id_sales_order 
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det =  a.id_sales_order_det
        INNER JOIN tb_m_product p ON p.id_product = sod.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = a.id_ror
        INNER JOIN tb_m_user us ON us.id_user = a.manual_sync_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = us.id_employee
        WHERE a.is_manual_sync=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSync_Click(sender As Object, e As EventArgs) Handles BtnSync.Click
        Dim is_need_sync As String = execute_query("CALL view_ol_store_status_check_sync();", 0, True, "", "", "", "")
        If is_need_sync = "1" Then
            Dim id_zalora_grp As String = get_setup_field("zalora_comp_group")
            Dim id_bli_grp As String = get_setup_field("blibli_comp_group")
            If TxtOrderNumber.Text <> "" Then
                Dim order_no As String = addSlashes(TxtOrderNumber.Text.Trim)
                Dim id_grp As String = SLECompGroup.EditValue.ToString
                Dim query As String = "SELECT so.id_sales_order, so.id_sales_order_ol_shop AS `id_order`, so.sales_order_ol_shop_number AS `order_no`, sod.id_sales_order_det, sod.ol_store_id,sod.item_id, 
                sp.id_sales_pos, spd.id_sales_pos_det 
                FROM tb_sales_order so
                INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
                INNER JOIN tb_sales_pos_det spd ON spd.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
                INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos AND sp.id_report_status=6
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                WHERE so.id_report_status=6 AND so.sales_order_ol_shop_number='" + order_no + "' AND c.id_comp_group='" + id_grp + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                        FormMain.SplashScreenManager1.ShowWaitForm()
                    End If
                    Dim sch_cek As DateTime = getTimeDB()
                    Dim sch_input As String = DateTime.Parse(sch_cek).ToString("yyyy-MM-dd HH:mm:ss")
                    Dim cmos As New ClassMOS()
                    cmos.insertLog(sch_input, "start")
                    Dim found As Boolean = False
                    Dim already_exist As Boolean = False

                    'get status
                    If id_grp = id_zalora_grp Then
                        'zalora get status
                        Cursor = Cursors.WaitCursor
                        Dim zalora_sleep_req_time As Integer = get_setup_field("zalora_sleep_req_time")
                        For z As Integer = 0 To data.Rows.Count - 1
                            FormMain.SplashScreenManager1.SetWaitFormDescription("Get status " + (z + 1).ToString + " of " + data.Rows.Count.ToString)
                            Try
                                Dim za As New ClassZaloraApi()
                                Dim dt As DataTable = za.get_status_update(data.Rows(z)("id_order").ToString, data.Rows(z)("item_id").ToString)
                                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                                    Dim id_sales_order_det As String = data.Rows(z)("id_sales_order_det").ToString
                                    Dim status As String = dt.Rows(0)("order_status").ToString
                                    Dim status_date As String = dt.Rows(0)("order_status_date").ToString
                                    cmos.insertStatusOrder(id_sales_order_det, status, status_date)

                                    'for auto cn/ror
                                    If data.Rows(z)("id_sales_pos").ToString <> "" And (dt.Rows(0)("order_status").ToString = "canceled" Or dt.Rows(0)("order_status").ToString = "failed" Or dt.Rows(0)("order_status").ToString = "returned") Then
                                        'cek database
                                        Dim dt_cek As DataTable = execute_query("SELECT * FROM tb_ol_store_return_order WHERE id_sales_order_det='" + data.Rows(z)("id_sales_order_det").ToString + "' ", -1, True, "", "", "", "")
                                        If dt_cek.Rows.Count <= 0 Then
                                            Dim qiz As String = "INSERT INTO tb_ol_store_return_order(id_comp_group, created_date, order_number, ol_store_id, item_id, qty, id_sales_order, id_sales_order_det, id_sales_pos_det, id_sales_pos, is_manual_sync, manual_sync_by)
                                            VALUES('" + id_grp + "', NOW(), '" + data.Rows(z)("order_no").ToString + "', '" + data.Rows(z)("ol_store_id").ToString + "', '" + data.Rows(z)("item_id").ToString + "','1','" + data.Rows(z)("id_sales_order").ToString + "', '" + data.Rows(z)("id_sales_order_det").ToString + "', '" + data.Rows(z)("id_sales_pos_det").ToString + "', '" + data.Rows(z)("id_sales_pos").ToString + "',1,'" + id_user + "'); "
                                            execute_non_query(qiz, True, "", "", "", "")
                                            found = True
                                        Else
                                            already_exist = True
                                        End If
                                    End If
                                End If
                                If (z + 1) Mod 30 = 0 Then
                                    Threading.Thread.Sleep(zalora_sleep_req_time)
                                End If
                            Catch ex As Exception
                                cmos.insertLog(sch_input, "err_stt_zal;item:" + data.Rows(z)("item_id").ToString + ";" + ex.ToString + "")
                            End Try
                        Next
                        Cursor = Cursors.Default
                    ElseIf id_grp = id_bli_grp Then
                        'blibli get status
                        Cursor = Cursors.WaitCursor
                        For b As Integer = 0 To data.Rows.Count - 1
                            Try
                                Dim bli As New ClassBliBliApi()
                                Dim dt As DataTable = bli.get_status(data.Rows(b)("order_no").ToString, data.Rows(b)("ol_store_id").ToString)
                                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                                    Dim id_sales_order_det As String = data.Rows(b)("id_sales_order_det").ToString
                                    Dim status As String = dt.Rows(0)("order_status").ToString
                                    Dim status_date As String = DateTime.Parse(dt.Rows(0)("order_status_date").ToString).ToString("yyyy-MM-dd HH:mm")
                                    cmos.insertStatusOrder(id_sales_order_det, status, status_date)

                                    'for auto cn/ror
                                    If data.Rows(b)("id_sales_pos").ToString <> "" And (dt.Rows(0)("order_status").ToString = "cancelled" Or dt.Rows(0)("order_status").ToString = "failed") Then
                                        Dim dt_cek As DataTable = execute_query("SELECT * FROM tb_ol_store_return_order WHERE id_sales_order_det='" + data.Rows(b)("id_sales_order_det").ToString + "' ", -1, True, "", "", "", "")
                                        If dt_cek.Rows.Count <= 0 Then
                                            Dim qib As String = "INSERT INTO tb_ol_store_return_order(id_comp_group, created_date, order_number, ol_store_id, item_id, qty, id_sales_order, id_sales_order_det, id_sales_pos_det, id_sales_pos, is_manual_sync, manual_sync_by)
                                            VALUES('" + id_grp + "', NOW(), '" + data.Rows(b)("order_no").ToString + "', '" + data.Rows(b)("ol_store_id").ToString + "', '" + data.Rows(b)("item_id").ToString + "','1','" + data.Rows(b)("id_sales_order").ToString + "', '" + data.Rows(b)("id_sales_order_det").ToString + "', '" + data.Rows(b)("id_sales_pos_det").ToString + "', '" + data.Rows(b)("id_sales_pos").ToString + "',1,'" + id_user + "'); "
                                            execute_non_query(qib, True, "", "", "", "")
                                            found = True
                                        Else
                                            already_exist = True
                                        End If
                                    End If

                                    'ror
                                    If Not found Then
                                        bli.get_ror_list_spesific(data.Rows(b)("ol_store_id").ToString)
                                        Dim dt_cek As DataTable = execute_query("SELECT * FROM tb_ol_store_return_order WHERE id_sales_order_det='" + data.Rows(b)("id_sales_order_det").ToString + "' ", -1, True, "", "", "", "")
                                        If dt_cek.Rows.Count <= 0 Then
                                            bli.set_to_returned_spesific(data.Rows(b)("ol_store_id").ToString, 1)
                                            found = True
                                        Else
                                            already_exist = True
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                cmos.insertLog(sch_input, "err_stt_bli;ol_id:" + data.Rows(b)("ol_store_id").ToString + ";" + ex.ToString + "")
                            End Try
                        Next
                        Cursor = Cursors.Default
                    End If

                    'auto cn ror
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Checking auto CN & ROR")
                    If found Then
                        Try
                            Dim qcr As String = "SELECT olr.id_sales_order, olr.id_sales_pos, olr.order_number
                                                    FROM tb_ol_store_return_order olr
                                                    WHERE olr.is_process=2 AND olr.is_manual_sync=1 AND olr.manual_sync_by='" + id_user + "' AND olr.order_number='" + order_no + "' AND olr.id_comp_group='" + id_grp + "' AND !ISNULL(olr.id_sales_order) AND !ISNULL(olr.id_sales_pos)
                                                    GROUP BY olr.id_sales_order, olr.id_sales_pos
                                                    ORDER BY olr.created_date ASC "
                            Dim dcr As DataTable = execute_query(qcr, -1, True, "", "", "", "")
                            For c As Integer = 0 To dcr.Rows.Count - 1
                                FormMain.SplashScreenManager1.SetWaitFormDescription((c + 1).ToString + " of " + dcr.Rows.Count.ToString)
                                cmos.insertLog(sch_input, "auto_cn_ror_" + dcr.Rows(c)("order_number").ToString)
                                execute_non_query_long("CALL create_ol_store_cn_ror(" + dcr.Rows(c)("id_sales_order").ToString + ", " + dcr.Rows(c)("id_sales_pos").ToString + "); ", True, "", "", "", "")
                            Next
                        Catch ex As Exception
                            cmos.insertLog(sch_input, "err_cn_ror;" + ex.ToString)
                        End Try
                    Else
                        If already_exist Then
                            stopCustom("Already exist on manual sync list")
                        Else
                            stopCustom("Returned/failed status not found")
                        End If
                    End If
                    TxtOrderNumber.Text = ""
                    FormMain.SplashScreenManager1.CloseWaitForm()
                    cmos.insertLog(sch_input, "end")
                    viewData()
                Else
                    stopCustom("Order not found")
                End If
            End If
        Else
            stopCustom("Sync already on process")
        End If
    End Sub
End Class