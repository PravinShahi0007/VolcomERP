Public Class FormFGTrfNew 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public id_sales_order_gen As String = "-1"

    Private Sub FormFGTrfNew_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGTrfNew_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormFGTrfNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")


        viewSalesOrder()

        'set notif load
        TimerMonitor.Interval = Integer.Parse(get_setup_field("load_notif"))
    End Sub

    Sub viewFGTrf()
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query_c As ClassFGTrf = New ClassFGTrf()
        Dim query As String = query_c.queryMain("AND (trf.fg_trf_date>=''" + date_from_selected + "'' AND trf.fg_trf_date<=''" + date_until_selected + "'') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGTrf.DataSource = data
        check_menu()
    End Sub

    Sub viewSalesOrder()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT a.id_sales_order, a.id_store_contact_to, d.id_commerce_type,d.id_comp AS `id_store`, d.is_use_unique_code, 
        d.id_store_type, d.comp_number AS `store_number`, d.comp_name AS `store`, d.address_primary as `store_address`, 
        CONCAT(d.comp_number,' - ',d.comp_name) AS store_name_to,a.id_report_status, f.report_status, 
        a.id_warehouse_contact_to, CONCAT(wh.comp_number,' - ',wh.comp_name) AS warehouse_name_to, 
        (wh.comp_number) AS warehouse_number_to,  (wh.comp_name) AS `warehouse`, wh.id_drawer_def AS `id_wh_drawer`, drw.wh_drawer_code, drw.wh_drawer, a.sales_order_note, 
        a.sales_order_date, a.sales_order_note, a.sales_order_number, a.sales_order_ol_shop_number, a.sales_order_ol_shop_date, (a.sales_order_date) AS sales_order_date, 
        ps.id_prepare_status, ps.prepare_status, ('No') AS `is_select`, cat.id_so_status, cat.so_status, ot.order_type, del_cat.id_so_cat, del_cat.so_cat, 
        IFNULL(so_item.tot_so,0.00) AS `total_order`,IFNULL(otstrf.outstanding,0) AS `outstanding`, CAST((IFNULL(trf_item.tot_trf, 0.00)/IFNULL(so_item.tot_so,0.00)*100) AS DECIMAL(5,2)) AS so_completness,  
        IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`,a.id_so_type, IFNULL(crt.created, 0) AS created_process, gen.id_sales_order_gen, IFNULL(gen.sales_order_gen_reff, '-') AS `sales_order_gen_reff`, a.final_comment, a.final_date, lp.printed_date, IFNULL(lp.printed_by,'-') AS `printed_by`, IFNULL(a.id_ol_store_oos,0) AS `id_ol_store_oos` 
        FROM tb_sales_order a 
        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
        INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
        INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to 
        INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp 
        INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status 
        INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status 
        INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = a.id_so_status 
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = cat.id_order_type 
        LEFT JOIN ( 
	        SELECT so_det.id_sales_order, SUM(so_det.sales_order_det_qty) AS tot_so  
	        FROM tb_sales_order_det so_det 
	        INNER JOIN tb_sales_order so ON so.id_sales_order = so_det.id_sales_order
	        WHERE so.id_so_status=5 AND so.id_report_status='6' AND so.id_prepare_status='1' AND so.is_transfer_data=2  
	        GROUP BY so_det.id_sales_order 
        ) so_item ON so_item.id_sales_order = a.id_sales_order 
        LEFT JOIN ( 
	        SELECT trf.id_sales_order, SUM(trf_det.fg_trf_det_qty) AS tot_trf 
	        FROM tb_fg_trf_det trf_det 
	        INNER JOIN tb_fg_trf trf ON trf.id_fg_trf = trf_det.id_fg_trf 
	        INNER JOIN tb_sales_order so ON so.id_sales_order = trf.id_sales_order
	        WHERE trf.id_report_status='6' AND trf_det.fg_trf_det_qty>0 AND so.id_prepare_status='1' AND so.is_transfer_data=2 
	        GROUP BY trf.id_sales_order  
        ) trf_item ON trf_item.id_sales_order = a.id_sales_order 
        LEFT JOIN tb_fg_so_reff an On an.id_fg_so_reff = a.id_fg_so_reff 
        LEFT JOIN tb_lookup_pd_alloc alloc On alloc.id_pd_alloc = d.id_pd_alloc 
        LEFT JOIN tb_lookup_so_cat del_cat On del_cat.id_so_cat = alloc.id_so_cat 
        Left Join( 
            Select id_sales_order, COUNT(*) As created FROM tb_fg_trf GROUP BY id_sales_order 
        ) crt On crt.id_sales_order = a.id_sales_order 
        Left JOIN tb_sales_order_gen gen ON gen.id_sales_order_gen = a.id_sales_order_gen 
        LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def 
        LEFT JOIN (
	        SELECT trf.id_sales_order,COUNT(*) AS `outstanding` FROM tb_fg_trf trf
	        WHERE trf.id_report_status!=5 AND trf.id_report_status!=6
	        GROUP BY trf.id_sales_order
        ) otstrf ON otstrf.id_sales_order = a.id_sales_order 
        LEFT JOIN (
           SELECT a.id_sales_order, a.log_date AS `printed_date`, e.employee_name AS `printed_by` 
           FROM (
              SELECT * FROM tb_sales_order_log_print lp
              ORDER BY lp.log_date ASC
           ) a 
           INNER JOIN tb_m_user u ON u.id_user = a.id_user
           INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
           GROUP BY a.id_sales_order
        ) lp ON lp.id_sales_order = a.id_sales_order 
        WHERE a.id_sales_order>0 AND a.id_so_status=5 AND a.id_report_status='6' AND a.id_prepare_status='1' AND a.is_transfer_data=2  
        ORDER BY a.id_sales_order ASC "
        ' Dim query_c As ClassSalesOrder = New ClassSalesOrder()
                'query_c.queryMain("AND a.id_so_status=5 AND a.id_report_status='6' AND a.id_prepare_status='1' AND a.is_transfer_data=2 ", "1")
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        GVSalesOrder.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub check_menu()
        If XTCTrf.SelectedTabPageIndex = 0 Then
            If GVFGTrf.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                noManipulating()
            End If
        ElseIf XTCTrf.SelectedTabPageIndex = 1 Then
            If GVSalesOrder.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCTrf.SelectedTabPageIndex = 2 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub noManipulating()
        If XTCTrf.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = GVFGTrf.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCTrf.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = GVSalesOrder.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVFGTrf_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGTrf.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVFGTrf_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGTrf.DoubleClick
        If GVFGTrf.RowCount > 0 And GVFGTrf.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormFGTrfNewDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        If XTCTrf.SelectedTabPageIndex = 0 Then
            FormFGTrfNewDet.id_pre = "2"
            FormMain.but_edit()
        Else
            If GVSalesOrder.FocusedRowHandle >= 0 And GVSalesOrder.RowCount > 0 Then
                Dim id As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormViewSalesOrder.id_sales_order = id
                FormViewSalesOrder.is_print = "1"
                FormViewSalesOrder.ShowDialog()
                viewSalesOrder()
                GVSalesOrder.FocusedRowHandle = find_row(GVSalesOrder, "id_sales_order", id)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGTrf_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVFGTrf.PopupMenuShowing
        If GVFGTrf.RowCount > 0 And GVFGTrf.FocusedRowHandle >= 0 Then
            Dim id_stt As String = GVFGTrf.GetFocusedRowCellValue("id_report_status").ToString
            If id_stt <> "3" And id_stt <> "4" And id_stt <> "6" Then
                SMPrint.Visible = False
            Else
                SMPrint.Visible = True
            End If

            If id_stt <> "1" And id_stt <> "2" And id_stt <> "3" And id_stt <> "4" And id_stt <> "6" Then
                SMPrePrint.Visible = False
            Else
                SMPrePrint.Visible = True
            End If
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub CheckEditRefresh_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditRefresh.CheckedChanged
        Dim cek As String = CheckEditRefresh.EditValue.ToString
        If cek Then
            TimerMonitor.Enabled = True
        Else
            TimerMonitor.Enabled = False
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewFGTrf()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCTrf_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTrf.SelectedPageChanged
        check_menu()
        If XTCTrf.SelectedTabPageIndex = 0 Then
            SMPrePrint.Visible = True
        ElseIf XTCTrf.SelectedTabPageIndex = 1 Then
            SMPrePrint.Visible = False
            GVSalesOrder.ShowFindPanel()
            GVSalesOrder.ShowFindPanel()
        ElseIf XTCTrf.SelectedTabPageIndex = 2 Then
            TxtNoParam.Focus()
        End If
    End Sub

    Private Sub GVFGTrf_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVFGTrf.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVSalesOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesOrder.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub TxtNoParam_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoParam.ButtonClick
        Cursor = Cursors.WaitCursor
        FormSalesOrderRef.id_pop_up = "2"
        FormSalesOrderRef.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewRef()
        Cursor = Cursors.WaitCursor
        Dim val As String = addSlashes(TxtNoParam.Text.ToString)
        If val = "" Then
            errorCustom("Data not found !")
        Else
            If id_sales_order_gen = "-1" Then
                Dim query As String = "SELECT id_sales_order_gen FROM tb_sales_order_gen WHERE sales_order_gen_reff='" + val + "' AND id_so_status=5 LIMIT 1 "
                id_sales_order_gen = "-1"
                Try
                    id_sales_order_gen = execute_query(query, 0, True, "", "", "", "")
                Catch ex As Exception
                End Try
            End If

            If id_sales_order_gen = "-1" Then
                errorCustom("Data not found !")
                GCNewPrepare.DataSource = Nothing
            Else
                Dim rf As New ClassSalesOrder()
                rf.viewReff(id_sales_order_gen, "-1", GCNewPrepare, GVNewPrepare)
                id_sales_order_gen = "-1"
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewNewPrepare_Click(sender As Object, e As EventArgs) Handles BtnViewNewPrepare.Click
        viewRef()
    End Sub


    Private Sub TxtNoParam_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNoParam.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewRef()
        End If
    End Sub
End Class