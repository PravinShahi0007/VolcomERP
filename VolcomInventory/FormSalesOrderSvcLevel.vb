Public Class FormSalesOrderSvcLevel
    Dim last_view_order As DateTime
    Dim expired_close_too As Integer = 0

    Public is_md As String = "-1"

    Sub viewSalesOrder()
        CheckSelAll.Checked = False

        'Prepare paramater
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

        Dim cond_status As String = ""
        If SLEPackingStatus.EditValue.ToString = "0" Then
            cond_status = "AND a.id_prepare_status>0 "
        Else
            cond_status = "AND a.id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "' "
        End If

        'oos
        If LETypeRestockTOO.EditValue.ToString = "1" Then
            cond_status += "AND ISNULL(a.id_ol_store_oos) "
        ElseIf LETypeRestockTOO.EditValue.ToString = "2" Then
            cond_status += "AND !ISNULL(a.id_ol_store_oos) "
        End If

        'prepare query
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = query_c.queryMain("AND a.id_report_status='6' AND (a.sales_order_date>='" + date_from_selected + "' AND a.sales_order_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data

        If is_md = "1" Then
            Dim dataView As DataView = New DataView(data)
            dataView.RowFilter = "so_completness = 0 AND outstanding = 0"
            GCSalesOrder.DataSource = dataView
        End If

        GVSalesOrder.BestFitColumns()
        last_view_order = Now
    End Sub

    Sub viewReturnOrder()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRet.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilRet.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEPackingStatusRet.EditValue.ToString = "0" Then
            cond_status = "AND a.id_prepare_status>0 "
        Else
            cond_status = "AND a.id_prepare_status='" + SLEPackingStatusRet.EditValue.ToString + "' "
        End If

        'return query
        Dim where_id_comp As String = ""

        If Not SLUEStore.EditValue.ToString = "0" Then
            where_id_comp = " AND d.id_comp = " + SLUEStore.EditValue.ToString + " "
        End If

        Dim query_c As ClassReturn = New ClassReturn()
        Dim query As String = query_c.queryMain("AND a.id_report_status='6' AND (a.sales_return_order_date>='" + date_from_selected + "' AND a.sales_return_order_date<='" + date_until_selected + "') AND dg.is_auto_cn_ror = 2 " + cond_status + where_id_comp, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        GVSalesReturnOrder.BestFitColumns()
    End Sub

    Sub viewRecProduct()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusRec.EditValue.ToString = "0" Then
            cond_status = "AND (a0.id_report_status=1 OR a0.id_report_status=3 OR a0.id_report_status=5 OR a0.id_report_status=6) "
        Else
            cond_status = "AND a0.id_report_status='" + SLEStatusRec.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
        Dim query As String = query_c.queryMain("AND (a0.pl_prod_order_rec_date>='" + date_from_selected + "' AND a0.pl_prod_order_rec_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPL.DataSource = data
    End Sub

    Sub viewDO()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusDO.EditValue.ToString = "0" Then
            cond_status = "AND (a.id_report_status=1 OR a.id_report_status=3 OR a.id_report_status=5 OR a.id_report_status=6) "
        Else
            cond_status = "AND a.id_report_status='" + SLEStatusDO.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim query As String = query_c.queryMain("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
    End Sub

    Sub viewReturn()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusReturn.EditValue.ToString = "0" Then
            cond_status = "AND (a.id_report_status=1 OR a.id_report_status=3 OR a.id_report_status=5 OR a.id_report_status=6) "
        Else
            cond_status = "AND a.id_report_status='" + SLEStatusReturn.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim query As String = query_c.queryMain("AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturn.DataSource = data
    End Sub

    Sub viewReturnQC()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturnQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilReturnQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusReturnQC.EditValue.ToString = "0" Then
            cond_status = "AND (a.id_report_status=1 OR a.id_report_status=3 OR a.id_report_status=5 OR a.id_report_status=6) "
        Else
            cond_status = "AND a.id_report_status='" + SLEStatusReturnQC.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassSalesReturnQC = New ClassSalesReturnQC()
        Dim query As String = query_c.queryMain("AND (a.sales_return_qc_date>='" + date_from_selected + "' AND a.sales_return_qc_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnQC.DataSource = data
    End Sub

    Sub viewTrf()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusTrf.EditValue.ToString = "0" Then
            cond_status = "AND (trf.id_report_status=1 OR trf.id_report_status=3 OR trf.id_report_status=5 OR trf.id_report_status=6) "
        Else
            cond_status = "AND trf.id_report_status=" + SLEStatusTrf.EditValue.ToString + " "
        End If

        'type restock
        Dim id_type_restock As String = LETypeRestock.EditValue.ToString
        If id_type_restock = "1" Then
            cond_status += "AND ISNULL(so.id_ol_store_oos)"
        ElseIf id_type_restock = "2" Then
            cond_status += "AND !ISNULL(so.id_ol_store_oos)"
        End If

        'prepare query
        Dim query_c As ClassFGTrf = New ClassFGTrf()
        Dim query As String = query_c.queryMain("AND (trf.fg_trf_date>=''" + date_from_selected + "'' AND trf.fg_trf_date<=''" + date_until_selected + "'') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGTrf.DataSource = data
    End Sub

    Sub viewNonStock()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromNonStock.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilNonStock.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusNonStock.EditValue.ToString = "0" Then
            cond_status = "AND (del.id_report_status=1 OR del.id_report_status=3 OR del.id_report_status=5 OR del.id_report_status=6) "
        Else
            cond_status = "AND del.id_report_status=" + SLEStatusNonStock.EditValue.ToString + " "
        End If

        'prepare query
        Dim query_c As ClassDelEmpty = New ClassDelEmpty()
        Dim query As String = query_c.queryMain("AND (del.wh_del_empty_date>='" + date_from_selected + "' AND wh_del_empty_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNonStock.DataSource = data
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        GVSalesOrder.ActiveFilterString = ""
        viewSalesOrder()
        noEdit(6)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewRet_Click(sender As Object, e As EventArgs) Handles BtnViewRet.Click
        Cursor = Cursors.WaitCursor
        viewReturnOrder()
        'noEdit(8)
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesOrderSvcLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCSvcLevel.TabPages
            XTCSvcLevel.SelectedTabPage = t
        Next t
        XTCSvcLevel.SelectedTabPage = XTCSvcLevel.TabPages(0)
        viewPackingStatus()
        viewReportStatus()
        view_store()
        view_type_restock()

        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromRet.EditValue = data_dt.Rows(0)("dt")
        DEUntilRet.EditValue = data_dt.Rows(0)("dt")
        DEFromRec.EditValue = data_dt.Rows(0)("dt")
        DEUntilRec.EditValue = data_dt.Rows(0)("dt")
        DEFromDO.EditValue = data_dt.Rows(0)("dt")
        DEUntilDO.EditValue = data_dt.Rows(0)("dt")
        DEFromReturn.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturn.EditValue = data_dt.Rows(0)("dt")
        DEFromReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEFromTrf.EditValue = data_dt.Rows(0)("dt")
        DEUntilTrf.EditValue = data_dt.Rows(0)("dt")
        DEFromNonStock.EditValue = data_dt.Rows(0)("dt")
        DEUntilNonStock.EditValue = data_dt.Rows(0)("dt")
        DEManifestStart.EditValue = data_dt.Rows(0)("dt")
        DEManifestUntil.EditValue = data_dt.Rows(0)("dt")
        DEStartInputAWBM.EditValue = data_dt.Rows(0)("dt")
        DEUntilInputAWBM.EditValue = data_dt.Rows(0)("dt")
        DEFromRepair.EditValue = data_dt.Rows(0)("dt")
        DEUntilRepair.EditValue = data_dt.Rows(0)("dt")

        'load expire
        Dim qex As String = "SELECT expired_close_too FROM tb_opt"
        Dim dex As DataTable = execute_query(qex, -1, True, "", "", "", "")
        expired_close_too = dex.Rows(0)("expired_close_too")

        load_surat_jalan()

        If get_opt_sales_field("is_active_new_ws_del") = "2" Then
            XTPCompleteManifest.PageVisible = False
            XTPAWBManifest.PageVisible = False
        End If

        'not used
        XTPAWBManifest.PageVisible = False

        If is_md = "1" Then
            XTPClosingSuratJalan.PageVisible = False
            XTPNonStockInv.PageVisible = False
            XTPTrf.PageVisible = False
            XTPReturnQC.PageVisible = False
            XTPReturn.PageVisible = False
            XTPDelOrder.PageVisible = False
            XTPRec.PageVisible = False
            XTPReturnOrder.PageVisible = False
            XTPCompleteManifest.PageVisible = False

            Text = "Cancel Prepare Order"
        End If
    End Sub

    Sub view_type_restock()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 1 AS `id_type`, 'Reguler' AS `type`
        UNION ALL
        SELECT 2 AS `id_type`, 'Restock Online Order' AS `type` "
        viewLookupQuery(LETypeRestock, query, 0, "type", "id_type")
        viewLookupQuery(LETypeRestockTOO, query, 0, "type", "id_type")
        Cursor = Cursors.Default
    End Sub

    Sub viewPackingStatus()
        Dim query As String = "SELECT 0 AS id_prepare_status, 'All Status' AS prepare_status UNION ALL "
        query += "SELECT id_prepare_status,prepare_status FROM tb_lookup_prepare_status a "
        viewSearchLookupQuery(SLEPackingStatus, query, "id_prepare_status", "prepare_status", "id_prepare_status")
        viewSearchLookupQuery(SLEPackingStatusRet, query, "id_prepare_status", "prepare_status", "id_prepare_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT ('0') AS id_report_status, ('All Status') AS report_status UNION ALL "
        query += "SELECT id_report_status, report_status FROM tb_lookup_report_status WHERE id_report_status=1 OR id_report_status=3 OR id_report_status=5 OR id_report_status=6 ORDER BY id_report_status ASC "
        viewSearchLookupQuery(SLEStatusRec, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusDO, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusReturn, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusReturnQC, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusTrf, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusNonStock, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub SMView_Click(sender As Object, e As EventArgs) Handles SMView.Click
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then 'prepare order
            Dim id_sales_order_par As String = "-1"
            Dim order_number_par As String = "-1"
            Dim id_so_cat As String = "-1"
            id_sales_order_par = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString()
            order_number_par = GVSalesOrder.GetFocusedRowCellValue("sales_order_number").ToString()
            id_so_cat = GVSalesOrder.GetFocusedRowCellValue("id_so_cat").ToString

            If id_so_cat = "1" Then
                'delivery order
                Cursor = Cursors.WaitCursor
                Try
                    'open menu
                    FormSalesDelOrder.MdiParent = FormMain
                    FormSalesDelOrder.Show()
                    FormSalesDelOrder.WindowState = FormWindowState.Maximized
                    FormSalesDelOrder.Focus()

                    'search
                    FormSalesDelOrder.GVSalesDelOrder.ShowFindPanel()
                    FormSalesDelOrder.GVSalesDelOrder.ApplyFindFilter(order_number_par)
                Catch ex As Exception
                    errorProcess()
                End Try
                Cursor = Cursors.Default
            ElseIf id_so_cat = "2" Then
                'trf
                Cursor = Cursors.WaitCursor
                Try
                    'open menu
                    FormFGTrfNew.MdiParent = FormMain
                    FormFGTrfNew.Show()
                    FormFGTrfNew.WindowState = FormWindowState.Maximized
                    FormFGTrfNew.Focus()

                    'search
                    FormFGTrfNew.GVFGTrf.ShowFindPanel()
                    FormFGTrfNew.GVFGTrf.ApplyFindFilter(order_number_par)
                Catch ex As Exception
                    errorProcess()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then 'return order
            Dim id_sales_return_order_par As String = "-1"
            Dim order_number_par As String = "-1"
            id_sales_return_order_par = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString()
            order_number_par = GVSalesReturnOrder.GetFocusedRowCellValue("sales_return_order_number").ToString()
            Cursor = Cursors.WaitCursor
            Try
                'open menu
                FormSalesReturn.MdiParent = FormMain
                FormSalesReturn.Show()
                FormSalesReturn.WindowState = FormWindowState.Maximized
                FormSalesReturn.Focus()

                'search
                FormSalesReturn.GVSalesReturn.ShowFindPanel()
                FormSalesReturn.GVSalesReturn.ApplyFindFilter(order_number_par)
            Catch ex As Exception
                errorProcess()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ViewDetailOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailOrderToolStripMenuItem.Click
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then
            Cursor = Cursors.WaitCursor
            Dim sh As ClassShowPopUp = New ClassShowPopUp()
            sh.report_mark_type = "39"
            sh.id_report = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            sh.show()
            FormViewSalesOrder.BMark.Visible = False
            Cursor = Cursors.Default
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then
            Cursor = Cursors.WaitCursor
            Dim id_so As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_order").ToString
            If id_so = "0" Then
                FormViewSalesReturnOrder.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                FormViewSalesReturnOrder.is_detail_soh = "1"
                FormViewSalesReturnOrder.ShowDialog()
            Else
                FormSalesReturnOrderOLDet.is_view = "1"
                FormSalesReturnOrderOLDet.action = "upd"
                FormSalesReturnOrderOLDet.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString()
                FormSalesReturnOrderOLDet.is_detail_soh = "1"
                FormSalesReturnOrderOLDet.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub UpdatePackingStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePackingStatusToolStripMenuItem.Click
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then 'prepare
            Dim id_prepare As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            Dim id_cur_stt As String = GVSalesOrder.GetFocusedRowCellValue("id_prepare_status").ToString
            If id_cur_stt = "1" Then
                'FormSalesOrderPacking.id_trans = id_prepare
                'FormSalesOrderPacking.id_cur_status = id_cur_stt
                'FormSalesOrderPacking.id_pop_up = "1"
                'FormSalesOrderPacking.ShowDialog()
            Else
                stopCustom("Data already locked.")
            End If
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then 'return
            Dim id_prepare As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
            Dim id_cur_stt As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_prepare_status").ToString
            If id_cur_stt = "1" Then
                'FormSalesOrderPacking.id_trans = id_prepare
                'FormSalesOrderPacking.id_cur_status = id_cur_stt
                'FormSalesOrderPacking.id_pop_up = "2"
                'FormSalesOrderPacking.ShowDialog()
            Else
                stopCustom("Data already locked.")
            End If
        End If
    End Sub

    Private Sub GVSalesOrder_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesOrder.PopupMenuShowing
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            UpdatePackingStatusToolStripMenuItem.Visible = True
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub FormSalesOrderSvcLevel_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesOrderSvcLevel_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVSalesReturnOrder_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesReturnOrder.PopupMenuShowing
        If GVSalesReturnOrder.RowCount > 0 And GVSalesReturnOrder.FocusedRowHandle >= 0 Then
            UpdatePackingStatusToolStripMenuItem.Visible = True
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub XTCSvcLevel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSvcLevel.SelectedPageChanged
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then 'prepare
            SMView.Text = "View Detail Delivery/Transfer"
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then 'return
            SMView.Text = "View Detail Return"
        End If
    End Sub

    Private Sub BtnViewRec_Click(sender As Object, e As EventArgs) Handles BtnViewRec.Click
        Cursor = Cursors.WaitCursor
        GVPL.ActiveFilterString = ""
        viewRecProduct()
        noEdit(1)
        Cursor = Cursors.Default
    End Sub

    Sub noEdit(ByVal type As String)
        If type = "1" Then 'REC PRODUCT
            If GVPL.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVPL.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVPL.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVPL.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "2" Then 'DEL ORDER
            If GVSalesDelOrder.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesDelOrder.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVSalesDelOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVSalesDelOrder.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "3" Then 'RETURN
            If GVSalesReturn.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesReturn.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVSalesReturn.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVSalesReturn.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "4" Then 'RETURN QC
            If GVSalesReturnQC.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesReturnQC.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVSalesReturnQC.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVSalesReturnQC.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "5" Then 'TRF
            If GVFGTrf.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVFGTrf.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVFGTrf.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVFGTrf.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "6" Then
            If GVSalesOrder.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesOrder.GetFocusedRowCellValue("id_prepare_status").ToString
                Dim ots As Integer = GVSalesOrder.GetFocusedRowCellValue("outstanding")
                If alloc_cek = "2" Then
                    GVSalesOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    If ots = 0 Then
                        GVSalesOrder.Columns("is_select").OptionsColumn.AllowEdit = True
                    Else
                        GVSalesOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                    End If
                End If
            End If
        ElseIf type = "7" Then ' non stock inv
            If GVNonStock.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVNonStock.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVNonStock.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVNonStock.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "8" Then 'return order
            If GVSalesReturnOrder.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_prepare_status").ToString
                Dim ots As Integer = GVSalesReturnOrder.GetFocusedRowCellValue("outstanding")
                If alloc_cek = "2" Then
                    GVSalesReturnOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    If ots = 0 Then
                        GVSalesReturnOrder.Columns("is_select").OptionsColumn.AllowEdit = True
                    Else
                        GVSalesReturnOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GVPL_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPL.FocusedRowChanged
        noEdit(1)
    End Sub

    Private Sub BtnUpdateRec_Click(sender As Object, e As EventArgs) Handles BtnUpdateRec.Click
        Cursor = Cursors.WaitCursor
        GVPL.ActiveFilterString = ""
        GVPL.ActiveFilterString = "[is_select]='Yes' "
        If GVPL.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVPL.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "1"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPL_DoubleClick(sender As Object, e As EventArgs) Handles GVPL.DoubleClick
        If GVPL.FocusedRowHandle >= 0 And GVPL.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewProductionPLToWHRec.action = "upd"
            FormViewProductionPLToWHRec.id_pl_prod_order_rec = GVPL.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
            FormViewProductionPLToWHRec.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewDO_Click(sender As Object, e As EventArgs) Handles BtnViewDO.Click
        Cursor = Cursors.WaitCursor
        GVSalesDelOrder.ActiveFilterString = ""
        viewDO()
        noEdit(2)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesDelOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesDelOrder.FocusedRowChanged
        noEdit(2)
    End Sub

    Private Sub BtnUpdateDO_Click(sender As Object, e As EventArgs) Handles BtnUpdateDO.Click
        Cursor = Cursors.WaitCursor
        GVSalesDelOrder.ActiveFilterString = ""
        GVSalesDelOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesDelOrder.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVSalesDelOrder.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "2"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesDelOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesDelOrder.DoubleClick
        viewDetailPreDel()
    End Sub

    Sub viewDetailPreDel()
        If GVSalesDelOrder.FocusedRowHandle >= 0 And GVSalesDelOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewSalesDelOrder.action = "upd"
            FormViewSalesDelOrder.id_pl_sales_order_del = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            FormViewSalesDelOrder.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewReturn_Click(sender As Object, e As EventArgs) Handles BtnViewReturn.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturn.ActiveFilterString = ""
        viewReturn()
        noEdit(3)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturn_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturn.FocusedRowChanged
        noEdit(3)
    End Sub

    Private Sub BtnUpdateReturn_Click(sender As Object, e As EventArgs) Handles BtnUpdateReturn.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturn.ActiveFilterString = ""
        GVSalesReturn.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesReturn.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVSalesReturn.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "3"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturn_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturn.DoubleClick
        If GVSalesReturn.FocusedRowHandle >= 0 And GVSalesReturn.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewSalesReturn.action = "upd"
            FormViewSalesReturn.id_sales_return = GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
            FormViewSalesReturn.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewReturnQC_Click(sender As Object, e As EventArgs) Handles BtnViewReturnQC.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturnQC.ActiveFilterString = ""
        viewReturnQC()
        noEdit(4)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnQC_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturnQC.FocusedRowChanged
        noEdit(4)
    End Sub

    Private Sub BtnUpdateReturnQC_Click(sender As Object, e As EventArgs) Handles BtnUpdateReturnQC.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturnQC.ActiveFilterString = ""
        GVSalesReturnQC.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesReturnQC.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVSalesReturnQC.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "4"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnQC_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturnQC.DoubleClick
        If GVSalesReturnQC.FocusedRowHandle >= 0 And GVSalesReturnQC.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewSalesReturnQC.action = "upd"
            FormViewSalesReturnQC.id_sales_return_qc = GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
            FormViewSalesReturnQC.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewTrf_Click(sender As Object, e As EventArgs) Handles BtnViewTrf.Click
        Cursor = Cursors.WaitCursor
        GVFGTrf.ActiveFilterString = ""
        viewTrf()
        noEdit(5)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGTrf_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGTrf.FocusedRowChanged
        noEdit(5)
    End Sub

    Private Sub BtnUpdateTrf_Click(sender As Object, e As EventArgs) Handles BtnUpdateTrf.Click
        Cursor = Cursors.WaitCursor
        GVFGTrf.ActiveFilterString = ""
        GVFGTrf.ActiveFilterString = "[is_select]='Yes' "
        If GVFGTrf.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVFGTrf.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "5"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGTrf_DoubleClick(sender As Object, e As EventArgs) Handles GVFGTrf.DoubleClick
        If GVFGTrf.FocusedRowHandle >= 0 And GVFGTrf.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewFGTrf.action = "upd"
            FormViewFGTrf.id_fg_trf = GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
            FormViewFGTrf.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        noEdit(6)
    End Sub

    Private Sub GVSalesOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesOrder.ColumnFilterChanged
        noEdit(6)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor

        'cek expired view
        Dim result As TimeSpan = Now() - last_view_order
        'MsgBox(result.TotalSeconds.ToString)
        If result.TotalSeconds > expired_close_too Then
            stopCustom("Order List is expired, please click 'View' again")
            GCSalesOrder.DataSource = Nothing
            Cursor = Cursors.Default
            Exit Sub
        End If

        GVSalesOrder.ActiveFilterString = ""
        GVSalesOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesOrder.RowCount = 0 Then
            stopCustom("Please select order first.")
            GVSalesOrder.ActiveFilterString = ""
        Else
            Dim order_under_100 As String = ""
            Dim order_ix As Integer = 0
            For c As Integer = 0 To GVSalesOrder.RowCount - 1
                Dim so_number As String = GVSalesOrder.GetRowCellValue(c, "sales_order_number").ToString
                Dim lvl As Decimal = GVSalesOrder.GetRowCellValue(c, "so_completness")
                If lvl < 100 Then
                    If order_ix > 0 Then
                        order_under_100 += ","
                    End If
                    order_under_100 += so_number
                    order_ix += 1
                End If
            Next
            If order_ix > 0 Then
                FormError.LabelContent.Text = "Be careful ! Service level under 100% : " + System.Environment.NewLine + order_under_100
                FormError.ShowDialog()
            End If
            FormSalesOrderPacking.id_pop_up = "4"
            FormSalesOrderPacking.ShowDialog()
        End If
        GVSalesOrder.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSelAll.CheckedChanged
        If GVSalesOrder.RowCount > 0 Then
            Dim cek As String = CheckSelAll.EditValue.ToString
            For i As Integer = ((GVSalesOrder.RowCount - 1) - GetGroupRowCount(GVSalesOrder)) To 0 Step -1
                Dim id_prepare_status As String = GVSalesOrder.GetRowCellValue(i, "id_prepare_status").ToString
                Dim ots As Integer = GVSalesOrder.GetRowCellValue(i, "outstanding")
                If cek And id_prepare_status = "1" And ots = 0 Then
                    GVSalesOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub PrintPrepareOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPrepareOrderToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then
            If GVSalesOrder.FocusedRowHandle >= 0 And GVSalesOrder.RowCount > 0 Then
                FormViewSalesOrder.id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormViewSalesOrder.is_print = "1"
                FormViewSalesOrder.ShowDialog()
            End If
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then
            If GVSalesReturnOrder.FocusedRowHandle >= 0 And GVSalesReturnOrder.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim id_so As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_order").ToString
                If id_so = "0" Then
                    FormViewSalesReturnOrder.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                    FormViewSalesReturnOrder.is_detail_soh = "1"
                    FormViewSalesReturnOrder.is_print = "1"
                    FormViewSalesReturnOrder.ShowDialog()
                Else
                    FormSalesReturnOrderOLDet.is_view = "1"
                    FormSalesReturnOrderOLDet.action = "upd"
                    FormSalesReturnOrderOLDet.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString()
                    FormSalesReturnOrderOLDet.is_detail_soh = "1"
                    FormSalesReturnOrderOLDet.is_print = "1"
                    FormSalesReturnOrderOLDet.ShowDialog()
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        viewDetailPreDel()
    End Sub

    Private Sub PrintUniqueCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintUniqueCodeToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVSalesDelOrder.FocusedRowHandle >= 0 And GVSalesDelOrder.RowCount > 0 Then
            FormUniqueDel.id_del = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            FormUniqueDel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewNonStock_Click(sender As Object, e As EventArgs) Handles BtnViewNonStock.Click
        Cursor = Cursors.WaitCursor
        GVNonStock.ActiveFilterString = ""
        viewNonStock()
        noEdit(7)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVNonStock_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVNonStock.FocusedRowChanged
        noEdit(7)
    End Sub

    Private Sub BtnUpdateStatusNonStock_Click(sender As Object, e As EventArgs) Handles BtnUpdateStatusNonStock.Click
        Cursor = Cursors.WaitCursor
        GVNonStock.ActiveFilterString = ""
        GVNonStock.ActiveFilterString = "[is_select]='Yes' "
        If GVNonStock.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVNonStock.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "6"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVNonStock_DoubleClick(sender As Object, e As EventArgs) Handles GVNonStock.DoubleClick
        If GVNonStock.FocusedRowHandle >= 0 And GVNonStock.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormWHDelEmptyDet.action = "upd"
            FormWHDelEmptyDet.id_wh_del_empty = GVNonStock.GetFocusedRowCellValue("id_wh_del_empty").ToString
            FormWHDelEmptyDet.is_view = "1"
            FormWHDelEmptyDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVSalesReturnOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesReturnOrder.ColumnFilterChanged
        'noEdit(8)
    End Sub

    Private Sub GVSalesReturnOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturnOrder.FocusedRowChanged
        'noEdit(8)
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If GVSalesReturnOrder.RowCount > 0 Then
            Dim cek As String = CheckEdit1.EditValue.ToString
            For i As Integer = ((GVSalesReturnOrder.RowCount - 1) - GetGroupRowCount(GVSalesReturnOrder)) To 0 Step -1
                Dim id_prepare_status As String = GVSalesReturnOrder.GetRowCellValue(i, "id_prepare_status").ToString
                Dim ots As Integer = GVSalesReturnOrder.GetRowCellValue(i, "outstanding")
                If cek And id_prepare_status = "1" And ots = 0 Then
                    GVSalesReturnOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesReturnOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturnOrder.ActiveFilterString = ""
        GVSalesReturnOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesReturnOrder.RowCount = 0 Then
            stopCustom("Please select order first.")
            GVSalesReturnOrder.ActiveFilterString = ""
        Else
            'check
            Dim is_valid As Boolean = True

            For i = 0 To GVSalesReturnOrder.RowCount - 1
                Dim alloc_cek As String = GVSalesReturnOrder.GetRowCellValue(i, "id_prepare_status").ToString
                Dim ots As Integer = GVSalesReturnOrder.GetRowCellValue(i, "outstanding").ToString
                If alloc_cek = "2" Then
                    is_valid = False
                Else
                    If Not ots = 0 Then
                        is_valid = False
                    End If
                End If
            Next

            If is_valid Then
                FormSalesOrderPacking.id_pop_up = "5"
                FormSalesOrderPacking.ShowDialog()
            Else
                stopCustom("Some order can't close.")
            End If
        End If
        GVSalesReturnOrder.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewCombinedDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewCombinedDeliveryToolStripMenuItem.Click
        Dim id_combine As String = ""
        Try
            id_combine = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
        Catch ex As Exception
        End Try
        If id_combine = "0" Then
            id_combine = ""
        End If
        If id_combine <> "" Then
            Cursor = Cursors.WaitCursor
            FormSalesDelOrderSlip.is_view = "1"
            FormSalesDelOrderSlip.action = "upd"
            FormSalesDelOrderSlip.id_pl_sales_order_del_slip = id_combine
            FormSalesDelOrderSlip.ShowDialog()
            Cursor = Cursors.Default
        Else
            stopCustom("Combined delivery not found")
        End If
    End Sub

    Private Sub LogPrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogPrintToolStripMenuItem.Click
        If GVSalesOrder.FocusedRowHandle >= 0 And GVSalesOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim id As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormSalesOrderLogPrint.id = id
            FormSalesOrderLogPrint.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CancellCombinedDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancellCombinedDeliveryToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            Dim id_combine As String = ""
            Try
                id_combine = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
            Catch ex As Exception
            End Try
            If id_combine = "0" Then
                id_combine = ""
            End If
            If id_combine <> "" Then
                If statusCombineDel(id_combine) Then
                    Cursor = Cursors.WaitCursor
                    FormSalesDelOrderCancellCombine.id_combine = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
                    FormSalesDelOrderCancellCombine.LabelCombineNumber.Text = GVSalesDelOrder.GetFocusedRowCellValue("combine_number").ToString
                    FormSalesDelOrderCancellCombine.LabelStore.Text = GVSalesDelOrder.GetFocusedRowCellValue("store").ToString
                    FormSalesDelOrderCancellCombine.id_comp_contact_from = GVSalesDelOrder.GetFocusedRowCellValue("id_comp_contact_from").ToString
                    FormSalesDelOrderCancellCombine.id_store_contact_to = GVSalesDelOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
                    FormSalesDelOrderCancellCombine.ShowDialog()
                    Cursor = Cursors.Default
                Else
                    warningCustom("Combined delivery already process")
                End If
            Else
                warningCustom("Combined delivery not found")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Public Function statusCombineDel(ByVal id As String) As Boolean
        Dim query As String = "SELECT id_report_status FROM tb_pl_sales_order_del_combine WHERE id_combine='" + id + "' "
        Dim id_stt As String = execute_query(query, 0, True, "", "", "", "")
        If id_stt <> "1" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub PrintUniqueCodeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintUniqueCodeToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If GVPL.FocusedRowHandle >= 0 And GVPL.RowCount > 0 Then
            FormUniqueRevProduct.id_pl_prod_order_rec = GVPL.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
            FormUniqueRevProduct.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If GVSalesReturn.FocusedRowHandle >= 0 And GVSalesReturn.RowCount > 0 Then
            FormUniqueSalesReturn.id_sales_return = GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
            FormUniqueSalesReturn.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturn_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesReturn.PopupMenuShowing
        If GVSalesReturn.GetFocusedRowCellValue("id_ret_type").ToString = "2" Then
            ToolStripMenuItem1.Visible = False
        Else
            ToolStripMenuItem1.Visible = True
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Cursor = Cursors.WaitCursor
        If GVSalesReturnQC.FocusedRowHandle >= 0 And GVSalesReturnQC.RowCount > 0 Then
            FormUniqueSalesReturnQC.id_sales_return_qc = GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
            FormUniqueSalesReturnQC.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Cursor = Cursors.WaitCursor
        If GVFGTrf.FocusedRowHandle >= 0 And GVFGTrf.RowCount > 0 Then
            FormUniqueFGTrf.id_fg_trf = GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
            FormUniqueFGTrf.fg_trf_number = GVFGTrf.GetFocusedRowCellValue("fg_trf_number").ToString
            FormUniqueFGTrf.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CancelCombineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelCombineToolStripMenuItem.Click
        If GVSalesReturn.FocusedRowHandle >= 0 And GVSalesReturn.RowCount > 0 Then
            Dim combine_number As String = GVSalesReturn.GetFocusedRowCellValue("combine_number").ToString
            Dim id_store_contact_from As String = GVSalesReturn.GetFocusedRowCellValue("id_store_contact_from").ToString
            Dim id_comp_contact_to As String = GVSalesReturn.GetFocusedRowCellValue("id_comp_contact_to").ToString
            Dim sales_return_store_number As String = GVSalesReturn.GetFocusedRowCellValue("sales_return_store_number").ToString

            If combine_number <> "" Then
                'cek combine status
                Dim id_rs As String = execute_query("SELECT MAX(id_report_status) AS `id_report_status` FROM tb_sales_return WHERE combine_number='" + combine_number + "' ", 0, True, "", "", "", "")
                If id_rs <> "1" Then
                    stopCustom("Can't cancel this combine because already approved ")
                    Exit Sub
                End If


                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell combine number : " + combine_number + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim query As String = "/*update keterangan rm*/
                    UPDATE tb_report_mark rm 
                    INNER JOIN tb_sales_return r ON r.id_sales_return = rm.id_report
                    SET rm.info_design = ''
                    WHERE (rm.report_mark_type=46 OR rm.report_mark_type=113 OR rm.report_mark_type=120) AND r.combine_number='" + combine_number + "';
                    /*update combine number*/
                    UPDATE tb_sales_return SET combine_number='' WHERE combine_number='" + combine_number + "'; 
                    /*insert log cancell*/
                    INSERT INTO tb_sales_return_cancel_combine_hist(combine_number, id_store_contact_from, id_comp_contact_to, sales_return_store_number, cancelled_date, cancelled_by) 
                    VALUES('" + combine_number + "', '" + id_store_contact_from + "', '" + id_comp_contact_to + "', '" + sales_return_store_number + "', NOW(), " + id_user + "); "
                    execute_non_query(query, True, "", "", "", "")
                    GCSalesReturn.DataSource = Nothing
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Combine number not found")
            End If
        End If
    End Sub

    Private Sub ViewPreDel_Opened(sender As Object, e As EventArgs) Handles ViewPreDel.Opened
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            If GVSalesDelOrder.GetFocusedRowCellValue("is_use_unique_code").ToString = "1" And GVSalesDelOrder.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                SendEmailConfirmationToolStripMenuItem.Visible = True
            Else
                SendEmailConfirmationToolStripMenuItem.Visible = False
            End If
        End If
    End Sub

    Private Sub SendEmailConfirmationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendEmailConfirmationToolStripMenuItem.Click
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            Dim report_number As String = ""
            Dim id_report As String = ""
            Dim rmt As String = ""
            If GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString = "0" Then
                report_number = GVSalesDelOrder.GetFocusedRowCellValue("pl_sales_order_del_number").ToString
                id_report = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
                rmt = "43"
            Else
                report_number = GVSalesDelOrder.GetFocusedRowCellValue("combine_number").ToString
                id_report = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
                rmt = "103"
            End If
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to send delivery confirmation for this delivery : " + report_number + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim d As New ClassSalesDelOrder()
                d.sendDeliveryConfirmationOfflineStore(id_report, rmt)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub LinkManifest_Click(sender As Object, e As EventArgs) Handles LinkManifest.Click
        If GVSalesDelOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_manifest As String = "-1"
            Try
                id_manifest = GVSalesDelOrder.GetFocusedRowCellValue("id_del_manifest").ToString
            Catch ex As Exception
                id_manifest = "-1"
            End Try
            If id_manifest = "" Then
                id_manifest = "-1"
            End If
            If id_manifest <> "-1" Then
                FormDelManifestDet.id_del_manifest = id_manifest
                FormDelManifestDet.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub load_surat_jalan()
        Try
            FormTrackingReturn.Dispose()
        Catch ex As Exception
        End Try

        FormTrackingReturn.TopLevel = False

        XTPClosingSuratJalan.Controls.Clear()
        XTPClosingSuratJalan.Controls.Add(FormTrackingReturn)

        FormTrackingReturn.for_update = True

        FormTrackingReturn.Show()

        FormTrackingReturn.FormBorderStyle = FormBorderStyle.None
        FormTrackingReturn.Dock = DockStyle.Fill
    End Sub

    Private Sub FormSalesOrderSvcLevel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        FormTrackingReturn.Close()
    End Sub

    Private Sub SBInputTanggalPickup_Click(sender As Object, e As EventArgs) Handles SBInputTanggalPickup.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturnOrder.ActiveFilterString = ""
        GVSalesReturnOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesReturnOrder.RowCount = 0 Then
            stopCustom("Please select order first.")
            GVSalesReturnOrder.ActiveFilterString = ""
        Else
            'check
            Dim is_valid As Boolean = True

            For i = 0 To GVSalesReturnOrder.RowCount - 1
                Dim pickup_date As String = GVSalesReturnOrder.GetRowCellValue(i, "pickup_date").ToString
                Dim pickup_date_updated_by As String = GVSalesReturnOrder.GetRowCellValue(i, "pickup_date_updated_by").ToString
                Dim pickup_date_updated_at As String = GVSalesReturnOrder.GetRowCellValue(i, "pickup_date_updated_at").ToString

                If Not pickup_date = "-" Or Not pickup_date_updated_by = "-" Or Not pickup_date_updated_at = "-" Then
                    is_valid = False
                End If
            Next

            If is_valid Then
                FormSalesReturnInputTanggalPickup.ShowDialog()
            Else
                stopCustom("Some order can't input store pick up date.")
            End If
        End If
        GVSalesReturnOrder.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub SBViewAllPickupDate_Click(sender As Object, e As EventArgs) Handles SBViewAllPickupDate.Click
        Cursor = Cursors.WaitCursor
        viewReturnOrderPickupDate()
        'noEdit(8)
        Cursor = Cursors.Default
    End Sub

    Sub viewReturnOrderPickupDate()
        'return query
        Dim query_c As ClassReturn = New ClassReturn()
        Dim query As String = query_c.queryMain("AND a.id_report_status='6' AND mail.id_report IS NOT NULL AND a.pickup_date IS NULL ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        GVSalesReturnOrder.BestFitColumns()
    End Sub

    Sub view_store()
        Dim query As String = "
            (SELECT 0 AS id_comp, 'ALL' AS comp_name)
            UNION ALL
            (SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS comp_name
            FROM tb_m_comp
            WHERE id_comp_cat = 6)
        "

        viewSearchLookupQuery(SLUEStore, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SLUEStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEStore.EditValueChanged
        GCSalesReturnOrder.DataSource = Nothing
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If Not SLUEStore.EditValue.ToString = "0" Then
            GVSalesReturnOrder.ActiveFilterString = "[is_select]='Yes' "

            If GVSalesReturnOrder.RowCount > 0 Then
                Dim already_pickup_date As Boolean = True
                Dim empty_3pl As Boolean = True

                For i = 0 To GVSalesReturnOrder.RowCount - 1
                    If GVSalesReturnOrder.GetRowCellValue(i, "pickup_date").ToString = "-" Then
                        already_pickup_date = False
                    End If

                    If GVSalesReturnOrder.GetRowCellValue(i, "id_3pl_status").ToString = "2" Or GVSalesReturnOrder.GetRowCellValue(i, "id_3pl_status").ToString = "3" Then
                        empty_3pl = False
                    End If
                Next

                If already_pickup_date Then
                    If empty_3pl Then
                        FormSalesReturnOrderMailDet.id_mail_3pl = "-1"
                        'FormSalesReturnOrderMailDet.id_store = SLUEStore.EditValue.ToString
                        FormSalesReturnOrderMailDet.ShowDialog()
                    Else
                        stopCustom("Some order already have 3pl or still waiting.")
                    End If
                Else
                    stopCustom("Some order have empty pick up date.")
                End If
            Else
                stopCustom("Please select order.")
            End If

            GVSalesReturnOrder.ActiveFilterString = ""
        Else
            stopCustom("Please select specific store.")
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        FormSalesReturnOrderMail.ShowDialog()
    End Sub

    Private Sub CancelSDOToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim qc As String = "SELECT * FROM tb_wh_awbill_det awbd
INNER JOIN tb_wh_awbill awb ON awb.id_awbill=awbd.`id_awbill` AND awb.`id_report_status`!=5
WHERE awbd.`id_pl_sales_order_del`='" & GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString & "'"
        Dim dt As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then

        End If
    End Sub

    Sub load_manifest()
        Dim query As String = "
SELECT 'yes' AS is_check,c.is_active,awb.ol_number,cg.id_comp_group,sp.sales_pos_total,rec.value,IF(sp.sales_pos_total>0,IF(IFNULL(rec.value,0)=0,0,1),0) AS paid, c.comp_name,CONCAT(c.comp_number,' - ',c.comp_name) AS store,
pl.pl_sales_order_del_number AS do_number,sp.`sales_pos_number` AS inv_number,GROUP_CONCAT(DISTINCT rec.number SEPARATOR ', ') AS bbm_number
,DATE(pl.pl_sales_order_del_date) as created_date,pl.id_pl_sales_order_del
FROM tb_pl_sales_order_del pl 
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.`id_store_contact_to` AND pl.id_report_status=3
INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
LEFT JOIN 
(
	SELECT sp.id_sales_pos,sp.report_mark_type,sp.sales_pos_number,sp.id_pl_sales_order_del,sp.`sales_pos_total`
	FROM tb_sales_pos sp
	INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from` AND sp.`id_report_status`=6 
	INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
	INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
)sp ON sp.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
LEFT JOIN
(
	SELECT r.`number`,r.`id_rec_payment`,rd.`id_report`,rd.`report_mark_type`,pl.`id_sales_order`,rd.`value`
	FROM tb_rec_payment_det rd 
	INNER JOIN tb_rec_payment r ON r.`id_rec_payment`=rd.`id_rec_payment` AND r.`id_report_status`=6
	INNER JOIN tb_sales_pos sp ON sp.`id_sales_pos`=rd.`id_report` AND rd.`report_mark_type`=sp.`report_mark_type`
	INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=sp.`id_pl_sales_order_del` AND pl.id_report_status=6
	INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from`
	INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
	INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
)rec ON rec.`id_report`=sp.`id_sales_pos` AND sp.`report_mark_type`=rec.report_mark_type
INNER JOIN tb_wh_awbill_det awbd ON awbd.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill`
LEFT JOIN (
	SELECT md.`id_wh_awb_det`,m.`id_del_manifest`,m.`awbill_no` 
	FROM tb_del_manifest_det md 
	INNER JOIN tb_del_manifest m ON m.`id_del_manifest`=md.`id_del_manifest`
	WHERE m.`id_report_status`!=5
)m ON m.id_wh_awb_det=awbd.`id_wh_awb_det`
WHERE DATE(pl.pl_sales_order_del_date)>=DATE('" & Date.Parse(DEManifestStart.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(pl.pl_sales_order_del_date)<=DATE('" & Date.Parse(DEManifestUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "') 
AND ISNULL(m.id_del_manifest) 
GROUP BY pl.`id_pl_sales_order_del`"
        'query = "
        '    SELECT odm.scan_manifest,odm.print_manifest,CONCAT(store.comp_number,' - ',store.comp_name) AS store,m.id_del_manifest, c.comp_name,m.awbill_no, m.number, DATE_FORMAT(m.created_date, '%d %M %Y %H:%i:%s') AS created_date, DATE_FORMAT(m.updated_date, '%d %M %Y %H:%i:%s') AS updated_date, ea.employee_name AS created_by, eb.employee_name AS updated_by, IFNULL(l.report_status, 'Waiting checked by security') AS report_status
        '    FROM tb_del_manifest AS m
        '    INNER JOIN tb_m_comp AS c ON m.id_comp = c.id_comp
        '    LEFT JOIN tb_m_user AS ua ON m.created_by = ua.id_user
        '    LEFT JOIN tb_m_employee AS ea ON ua.id_employee = ea.id_employee
        '    LEFT JOIN tb_m_user AS ub ON m.updated_by = ub.id_user
        '    LEFT JOIN tb_m_employee AS eb ON ub.id_employee = eb.id_employee
        '    INNER JOIN tb_lookup_report_status AS l ON m.id_report_status = l.id_report_status
        '    INNER JOIN tb_m_comp store ON store.id_comp=m.id_store_offline
        '    LEFT JOIN
        '    (
        '        SELECT scd.`id_del_manifest`,sc.`number` AS scan_manifest,p.`number` AS print_manifest
        '        FROM tb_odm_sc_det scd 
        '        INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` 
        '        LEFT JOIN tb_odm_print_det pd ON pd.`id_odm_sc`=sc.`id_odm_sc`
        '        LEFT JOIN tb_odm_print p ON p.`id_odm_print`=pd.`id_odm_print`
        '        GROUP BY scd.`id_del_manifest`
        '    )odm ON odm.id_del_manifest=m.id_del_manifest
        '    WHERE m.id_del_type='6' AND m.is_need_finalize='1' AND DATE(m.created_date)>=DATE('" & Date.Parse(DEManifestStart.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(m.created_date)<=DATE('" & Date.Parse(DEManifestUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "')
        '    ORDER BY m.id_del_manifest DESC
        '"

        GCList.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVList.BestFitColumns()
    End Sub

    Private Sub BViewManifest_Click(sender As Object, e As EventArgs) Handles BViewManifest.Click
        load_manifest()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormDelManifestDet.id_del_manifest = GVList.GetFocusedRowCellValue("id_del_manifest").ToString
        FormDelManifestDet.is_complete_wholesale = True
        FormDelManifestDet.ShowDialog()
    End Sub

    Private Sub BViewInputAWBM_Click(sender As Object, e As EventArgs) Handles BViewInputAWBM.Click
        Dim query As String = ""
        '        query = "
        '            SELECT m.`id_del_manifest`, c.comp_name,m.awbill_no, m.number,CONCAT(store.comp_number,' - ',store.comp_name) AS store,m.`number`,GROUP_CONCAT(DISTINCT pl.pl_sales_order_del_number) AS do_number,GROUP_CONCAT(DISTINCT sp.`sales_pos_number`) AS inv_number,GROUP_CONCAT(DISTINCT r.number) AS bbm_number
        'FROM `tb_rec_payment_det` rd
        'INNER JOIN tb_rec_payment r ON r.`id_rec_payment`=rd.`id_rec_payment` AND r.`id_report_status`=6 
        'INNER JOIN tb_sales_pos sp ON sp.`id_sales_pos`=rd.id_report AND rd.report_mark_type=sp.`report_mark_type` AND sp.`id_report_status`=6
        'INNER JOIN tb_wh_awbill_det awbd ON awbd.`id_pl_sales_order_del`=sp.`id_pl_sales_order_del`
        'INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=awbd.`id_pl_sales_order_del`
        'INNER JOIN tb_del_manifest_det md ON md.`id_wh_awb_det`=awbd.`id_wh_awb_det`
        'INNER JOIN tb_del_manifest m ON m.id_del_manifest=md.`id_del_manifest`
        'INNER JOIN tb_m_comp AS c ON m.id_comp = c.id_comp
        'INNER JOIN tb_m_comp store ON store.id_comp=m.id_store_offline
        'LEFT JOIN
        '(
        '	SELECT scd.`id_del_manifest`,sc.`number` AS scan_manifest,p.`number` AS print_manifest
        '	FROM tb_odm_sc_det scd 
        '	INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` 
        '	LEFT JOIN tb_odm_print_det pd ON pd.`id_odm_sc`=sc.`id_odm_sc`
        '	LEFT JOIN tb_odm_print p ON p.`id_odm_print`=pd.`id_odm_print`
        '	GROUP BY scd.`id_del_manifest`
        ')odm ON odm.id_del_manifest=m.id_del_manifest
        'WHERE m.`id_del_type`=6 AND DATE(m.created_date)>=DATE('" & Date.Parse(DEStartInputAWBM.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(m.created_date)<=DATE('" & Date.Parse(DEUntilInputAWBM.EditValue.ToString).ToString("yyyy-MM-dd") & "')
        'AND ISNULL(odm.scan_manifest) AND m.is_need_finalize='1' AND m.`is_finalize_complete`=1
        'GROUP BY md.`id_del_manifest`
        'ORDER BY m.id_del_manifest DESC"

        query = "SELECT tb.`id_del_manifest`, tb.comp_name,tb.awbill_no, tb.number,tb.store,GROUP_CONCAT(DISTINCT tb.do_number SEPARATOR ', ') AS do_number,GROUP_CONCAT(DISTINCT tb.`inv_number` SEPARATOR ', ') AS inv_number,GROUP_CONCAT(DISTINCT tb.bbm_number SEPARATOR ', ') AS bbm_number,IF(SUM(tb.not_paid)>0,'Pending','Paid') AS sts
FROM
(
	SELECT sp.sales_pos_total,rec.value,IF(sp.sales_pos_total>0,IF(IFNULL(rec.value,0)=0,1,0),0) AS not_paid,m.`id_del_manifest`, c.comp_name,m.awbill_no,CONCAT(store.comp_number,' - ',store.comp_name) AS store,m.`number`,pl.pl_sales_order_del_number AS do_number,sp.`sales_pos_number` AS inv_number,GROUP_CONCAT(DISTINCT rec.number SEPARATOR ', ') AS bbm_number
	FROM tb_del_manifest_det md 
	INNER JOIN tb_del_manifest m ON m.id_del_manifest=md.`id_del_manifest` AND m.`id_del_type`=6 AND m.is_need_finalize='1' AND m.`is_finalize_complete`=1
	INNER JOIN tb_m_comp store ON store.id_comp=m.id_store_offline
	INNER JOIN tb_wh_awbill_det awbd ON  md.`id_wh_awb_det`=awbd.`id_wh_awb_det`
	INNER JOIN tb_pl_sales_order_del pl ON awbd.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del` AND pl.id_report_status=6
	INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.`id_store_contact_to`
	INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
	INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	LEFT JOIN 
	(
		SELECT sp.id_sales_pos,sp.report_mark_type,sp.sales_pos_number,sp.id_pl_sales_order_del,sp.`sales_pos_total`
		FROM tb_sales_pos sp
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from` AND sp.`id_report_status`=6 
		INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
		INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	)sp ON sp.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
	LEFT JOIN
	(
		SELECT r.`number`,r.`id_rec_payment`,rd.`id_report`,rd.`report_mark_type`,pl.`id_sales_order`,rd.`value`
		FROM tb_rec_payment_det rd 
		INNER JOIN tb_rec_payment r ON r.`id_rec_payment`=rd.`id_rec_payment` AND r.`id_report_status`=6
		INNER JOIN tb_sales_pos sp ON sp.`id_sales_pos`=rd.`id_report` AND rd.`report_mark_type`=sp.`report_mark_type`
		INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=sp.`id_pl_sales_order_del` AND pl.id_report_status=6
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from`
		INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
		INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	)rec ON rec.`id_report`=sp.`id_sales_pos` AND sp.`report_mark_type`=rec.report_mark_type
	LEFT JOIN
	(
		SELECT scd.`id_del_manifest`,sc.`number` AS scan_manifest,p.`number` AS print_manifest
		FROM tb_odm_sc_det scd 
		INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` 
		LEFT JOIN tb_odm_print_det pd ON pd.`id_odm_sc`=sc.`id_odm_sc`
		LEFT JOIN tb_odm_print p ON p.`id_odm_print`=pd.`id_odm_print`
		GROUP BY scd.`id_del_manifest`
	)odm ON odm.id_del_manifest=m.id_del_manifest
	WHERE DATE(m.created_date)>=DATE('" & Date.Parse(DEStartInputAWBM.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(m.created_date)<=DATE('" & Date.Parse(DEUntilInputAWBM.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND ISNULL(odm.scan_manifest) 
	GROUP BY pl.`id_pl_sales_order_del`
)tb
GROUP BY tb.id_del_manifest
HAVING sts='Paid'"

        GCInputAWBManifest.DataSource = execute_query(query, -1, True, "", "", "", "")
        GVInputAWBManifest.BestFitColumns()
        BCompleteWholesale.Visible = True
    End Sub

    Private Sub BCompleteWholesale_Click(sender As Object, e As EventArgs) Handles BCompleteWholesale.Click
        If GVInputAWBManifest.RowCount > 0 Then
            FormAWBManifest.TEDraftNo.Text = GVInputAWBManifest.GetFocusedRowCellValue("number").ToString
            FormAWBManifest.TE3PLNo.Text = GVInputAWBManifest.GetFocusedRowCellValue("comp_name").ToString
            FormAWBManifest.TEStore.Text = GVInputAWBManifest.GetFocusedRowCellValue("store").ToString
            FormAWBManifest.TEAwb.Text = GVInputAWBManifest.GetFocusedRowCellValue("awbill_no").ToString
            FormAWBManifest.id_del_manifest = GVInputAWBManifest.GetFocusedRowCellValue("id_del_manifest").ToString
            FormAWBManifest.ShowDialog()
        End If
    End Sub

    Private Sub BShowPendingPaymentAWB_Click(sender As Object, e As EventArgs) Handles BShowPendingPaymentAWB.Click
        Dim q As String = "SELECT sp.sales_pos_total,rec.value,IF(sp.sales_pos_total>0,IF(IFNULL(rec.value,0)=0,1,0),0) AS not_paid,m.`id_del_manifest`, c.comp_name,m.awbill_no,CONCAT(store.comp_number,' - ',store.comp_name) AS store,m.`number`,pl.pl_sales_order_del_number AS do_number,sp.`sales_pos_number` AS inv_number,GROUP_CONCAT(DISTINCT rec.number SEPARATOR ', ') AS bbm_number
	FROM tb_del_manifest_det md 
	INNER JOIN tb_del_manifest m ON m.id_del_manifest=md.`id_del_manifest` AND m.`id_del_type`=6 AND m.is_need_finalize='1' AND m.`is_finalize_complete`=1
	INNER JOIN tb_m_comp store ON store.id_comp=m.id_store_offline
	INNER JOIN tb_wh_awbill_det awbd ON  md.`id_wh_awb_det`=awbd.`id_wh_awb_det`
	INNER JOIN tb_pl_sales_order_del pl ON awbd.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del` AND pl.id_report_status=6
	INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.`id_store_contact_to`
	INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
	INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	LEFT JOIN 
	(
		SELECT sp.id_sales_pos,sp.report_mark_type,sp.sales_pos_number,sp.id_pl_sales_order_del,sp.`sales_pos_total`
		FROM tb_sales_pos sp
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from` AND sp.`id_report_status`=6 
		INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
		INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	)sp ON sp.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
	LEFT JOIN
	(
		SELECT r.`number`,r.`id_rec_payment`,rd.`id_report`,rd.`report_mark_type`,pl.`id_sales_order`,rd.`value`
		FROM tb_rec_payment_det rd 
		INNER JOIN tb_rec_payment r ON r.`id_rec_payment`=rd.`id_rec_payment` AND r.`id_report_status`=6
		INNER JOIN tb_sales_pos sp ON sp.`id_sales_pos`=rd.`id_report` AND rd.`report_mark_type`=sp.`report_mark_type`
		INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=sp.`id_pl_sales_order_del` AND pl.id_report_status=6
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from`
		INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
		INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	)rec ON rec.`id_report`=sp.`id_sales_pos` AND sp.`report_mark_type`=rec.report_mark_type
	LEFT JOIN
	(
		SELECT scd.`id_del_manifest`,sc.`number` AS scan_manifest,p.`number` AS print_manifest
		FROM tb_odm_sc_det scd 
		INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` 
		LEFT JOIN tb_odm_print_det pd ON pd.`id_odm_sc`=sc.`id_odm_sc`
		LEFT JOIN tb_odm_print p ON p.`id_odm_print`=pd.`id_odm_print`
		GROUP BY scd.`id_del_manifest`
	)odm ON odm.id_del_manifest=m.id_del_manifest
	WHERE DATE(m.created_date)>=DATE('" & Date.Parse(DEStartInputAWBM.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(m.created_date)<=DATE('" & Date.Parse(DEUntilInputAWBM.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND ISNULL(odm.scan_manifest) 
	GROUP BY pl.`id_pl_sales_order_del`
	HAVING not_paid=1"
        GCInputAWBManifest.DataSource = execute_query(q, -1, True, "", "", "", "")
        GVInputAWBManifest.BestFitColumns()
        BCompleteWholesale.Visible = False
    End Sub

    Private Sub BHistoryAWBM_Click(sender As Object, e As EventArgs) Handles BHistoryAWBM.Click
        Dim q As String = "SELECT c.is_active,sp.sales_pos_total,rec.value,IF(sp.sales_pos_total>0,IF(IFNULL(rec.value,0)=0,1,0),0) AS not_paid,m.`id_del_manifest`, c.comp_name,m.awbill_no,CONCAT(store.comp_number,' - ',store.comp_name) AS store,m.`number`,pl.pl_sales_order_del_number AS do_number,sp.`sales_pos_number` AS inv_number,GROUP_CONCAT(DISTINCT rec.number SEPARATOR ', ') AS bbm_number
	FROM tb_del_manifest_det md 
	INNER JOIN tb_del_manifest m ON m.id_del_manifest=md.`id_del_manifest` AND m.`id_del_type`=6 
	INNER JOIN tb_m_comp store ON store.id_comp=m.id_store_offline
	INNER JOIN tb_wh_awbill_det awbd ON  md.`id_wh_awb_det`=awbd.`id_wh_awb_det`
	INNER JOIN tb_pl_sales_order_del pl ON awbd.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del` AND pl.id_report_status=6
	INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.`id_store_contact_to`
	INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
	INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	LEFT JOIN 
	(
		SELECT sp.id_sales_pos,sp.report_mark_type,sp.sales_pos_number,sp.id_pl_sales_order_del,sp.`sales_pos_total`
		FROM tb_sales_pos sp
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from` AND sp.`id_report_status`=6 
		INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
		INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	)sp ON sp.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
	LEFT JOIN
	(
		SELECT r.`number`,r.`id_rec_payment`,rd.`id_report`,rd.`report_mark_type`,pl.`id_sales_order`,rd.`value`
		FROM tb_rec_payment_det rd 
		INNER JOIN tb_rec_payment r ON r.`id_rec_payment`=rd.`id_rec_payment` AND r.`id_report_status`=6
		INNER JOIN tb_sales_pos sp ON sp.`id_sales_pos`=rd.`id_report` AND rd.`report_mark_type`=sp.`report_mark_type`
		INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=sp.`id_pl_sales_order_del` AND pl.id_report_status=6
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from`
		INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
		INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	)rec ON rec.`id_report`=sp.`id_sales_pos` AND sp.`report_mark_type`=rec.report_mark_type
	LEFT JOIN
	(
		SELECT scd.`id_del_manifest`,sc.`number` AS scan_manifest,p.`number` AS print_manifest
		FROM tb_odm_sc_det scd 
		INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` 
		LEFT JOIN tb_odm_print_det pd ON pd.`id_odm_sc`=sc.`id_odm_sc`
		LEFT JOIN tb_odm_print p ON p.`id_odm_print`=pd.`id_odm_print`
		GROUP BY scd.`id_del_manifest`
	)odm ON odm.id_del_manifest=m.id_del_manifest
	WHERE DATE(m.created_date)>=DATE('" & Date.Parse(DEStartInputAWBM.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(m.created_date)<=DATE('" & Date.Parse(DEUntilInputAWBM.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND NOT ISNULL(odm.scan_manifest) 
	GROUP BY pl.`id_pl_sales_order_del`"
        GCInputAWBManifest.DataSource = execute_query(q, -1, True, "", "", "", "")
        GVInputAWBManifest.BestFitColumns()
        BCompleteWholesale.Visible = False
    End Sub

    Dim is_block_del_store As String = get_setup_field("is_block_del_store")

    Private Sub BCompleteWholesaleSDO_Click(sender As Object, e As EventArgs) Handles BCompleteWholesaleSDO.Click
        GVList.ActiveFilterString = "[is_check]='yes'"
        If GVList.RowCount > 0 Then
            'hold delivery
            Dim err_hold As String = ""
            For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
                If Not GVList.IsGroupRow(i) Then
                    Dim del As New ClassSalesDelOrder()
                    If is_block_del_store = "1" And del.checkUnpaidInvoice(GVList.GetRowCellValue(i, "id_comp_group").ToString) Then
                        err_hold += GVList.GetRowCellValue(i, "do_number").ToString + " (" + GVList.GetRowCellValue(i, "store").ToString + ")" + System.Environment.NewLine
                    End If
                End If
            Next

            'store not active
            Dim err_not_active As String = ""
            For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
                If Not GVList.IsGroupRow(i) Then
                    If GVList.GetRowCellValue(i, "is_active").ToString = "2" Then
                        err_not_active += GVList.GetRowCellValue(i, "do_number").ToString + " (" + GVList.GetRowCellValue(i, "store").ToString + ")" + System.Environment.NewLine
                    End If
                End If
            Next

            If err_hold <> "" Then
                warningCustom("Hold delivery : " + System.Environment.NewLine + err_hold)
            ElseIf err_not_active <> "" Then
                warningCustom("Store not active : " + System.Environment.NewLine + err_not_active)
            Else
                'complete
                Try
                    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                        FormMain.SplashScreenManager1.ShowWaitForm()
                    End If

                    For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
                        FormMain.SplashScreenManager1.SetWaitFormDescription("Processing Order " & i + 1 & " of " & (GVList.RowCount - 1 - GetGroupRowCount(GVList)).ToString)
                        Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                        'infoCustom("change status " & GVList.GetRowCellValue(i, "id_pl_sales_order_del").ToString)
                        stt.is_finalize = "1"
                        stt.changeStatus(GVList.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "6")
                        Dim mail As ClassSendEmail = New ClassSendEmail()
                        mail.id_report = GVList.GetRowCellValue(i, "id_pl_sales_order_del").ToString
                        mail.report_mark_type = "391"
                        mail.send_email()
                    Next

                    FormMain.SplashScreenManager1.CloseWaitForm()
                    Close()
                Catch ex As Exception
                    'log scan security
                    warningCustom(ex.ToString)
                    FormMain.SplashScreenManager1.CloseWaitForm()
                End Try
            End If
        End If
        GVList.ActiveFilterString = ""
    End Sub

    Private Sub BtnRepair_Click(sender As Object, e As EventArgs) Handles BtnRepair.Click
        Cursor = Cursors.WaitCursor
        viewRepair()
        Cursor = Cursors.Default
    End Sub

    Sub viewRepair()
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRepair.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilRepair.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query_c As New ClassFGRepair()
        Dim query As String = query_c.queryMain("AND comp_frm.id_departement=6 AND (r.fg_repair_date>='" + date_from_selected + "' AND r.fg_repair_date<='" + date_until_selected + "') ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepair.DataSource = data
    End Sub

    Private Sub GVRepair_DoubleClick(sender As Object, e As EventArgs) Handles GVRepair.DoubleClick
        If GVRepair.RowCount > 0 And GVRepair.FocusedRowHandle >= 0 Then
            'Repair
            FormFGRepairDet.action = "upd"
            FormFGRepairDet.id_fg_repair = GVRepair.GetFocusedRowCellValue("id_fg_repair").ToString
            FormFGRepairDet.ShowDialog()
        End If
    End Sub
End Class