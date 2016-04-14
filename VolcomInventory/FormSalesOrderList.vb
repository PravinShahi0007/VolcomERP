Public Class FormSalesOrderList
    Dim data_band_break_plan As New DataTable

    Private Sub FormSalesOrderList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'load listt
        viewSalesOrder()

        'set notif load
        TimerMonitor.Interval = Integer.Parse(get_setup_field("load_notif"))

        Dim query_c As ClassDesign = New ClassDesign()
        data_band_break_plan = query_c.getBreakTotalLineList("4")
    End Sub

    Private Sub FormSalesOrderList_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesOrderList_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Function viewSalesOrderQuery(ByVal cond_par As String)
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = ""
        If cond_par <> "-1" Then
            query = query_c.queryMain("AND a.id_report_status='6' " + cond_par, "1")
        Else
            query = query_c.queryMain("AND a.id_report_status='6' ", "1")
        End If
        Return query
    End Function

    Sub viewSalesOrder()
        Dim query As String = viewSalesOrderQuery("AND a.id_prepare_status='1' ")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
    End Sub
    Sub viewNewPrepare(ByVal no_par As String)
        'prepare
        GCNewPrepare.DataSource = Nothing
        GCNewPrepare.RepositoryItems.Clear()
        GCNewPrepare.RefreshDataSource()
        GVNewPrepare.ApplyFindFilter("")
        GVNewPrepare.ColumnPanelRowHeight = 40
        GVNewPrepare.Columns.Clear()
        GVNewPrepare.GroupSummary.Clear()
        GVNewPrepare.Bands.Clear()
        GVNewPrepare.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GVNewPrepare.OptionsBehavior.AutoExpandAllGroups = True

        ' Make the group footers always visible.
        GVNewPrepare.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        'create band
        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVNewPrepare.Bands.AddBand("DESCRIPTION")
        band_desc.AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_break As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVNewPrepare.Bands.AddBand("BREAKDOWN SIZE")
        band_break.AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVNewPrepare.Bands.AddBand("")
        band_total.AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)

        'declare band for merge coluumn
        Dim band_arr() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
        Dim band_alloc_break() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

        'declare arr to store break sizw column initial
        Dim break_alloc_initial As New List(Of String)

        'query
        Dim query As String = "CALL view_sales_order_new_prod('" + no_par + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")


        'rep
        Dim riTE As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        riTE.NullText = "-"
        GCNewPrepare.RepositoryItems.Add(riTE)


        'properties column
        GVNewPrepare.BeginUpdate()

        'setup band size total
        band_break.Columns.Add(GVNewPrepare.Columns.AddVisible("brk_1", ""))
        band_break.Columns.Add(GVNewPrepare.Columns.AddVisible("brk_2", ""))
        band_break.Columns.Add(GVNewPrepare.Columns.AddVisible("brk_3", ""))
        band_break.Columns.Add(GVNewPrepare.Columns.AddVisible("brk_4", ""))
        GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns("brk_1"), 0, 0)
        GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns("brk_2"), 1, 0)
        GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns("brk_3"), 2, 0)
        GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns("brk_4"), 3, 0)

        'var bantu utk band dinamis
        Dim i_break As Integer = 0


        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "QTY" Then
                band_total.Columns.Add(GVNewPrepare.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                'properties
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)

                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString)
                GVNewPrepare.GroupSummary.Add(item)
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf Not data.Columns(i).ColumnName.ToString.Contains("_qty") Then
                band_desc.Columns.Add(GVNewPrepare.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            Else
                i_break += 1
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 4
                band_break.Columns.Add(GVNewPrepare.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

                'size position
                Dim data_filter As DataRow() = data_band_break_plan.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString), data_filter(0)("code_row_index").ToString, data_filter(0)("code_col_index").ToString)

                'properties
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)

                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString)
                GVNewPrepare.GroupSummary.Add(item)

                'repo
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).ColumnEdit = riTE
            End If
        Next

        'dispose column
        GVNewPrepare.Columns("brk_1").Dispose()
        GVNewPrepare.Columns("brk_2").Dispose()
        GVNewPrepare.Columns("brk_3").Dispose()
        GVNewPrepare.Columns("brk_4").Dispose()

        'set datasource
        GVNewPrepare.EndUpdate()
        GCNewPrepare.DataSource = data

        'hide column
        GVNewPrepare.Columns("id_design").Visible = False
        GVNewPrepare.Columns("DESIGN").Visible = False

        'order BAND
        GVNewPrepare.Bands.MoveTo(1, band_desc)
        GVNewPrepare.Bands.MoveTo(2, band_break)
        GVNewPrepare.Bands.MoveTo(3, band_total)

        'group
        GVNewPrepare.Columns("DESIGN").GroupIndex = 0
        GVNewPrepare.Columns("DESIGN").FieldNameSortGroup = "id_design"
        GVNewPrepare.GroupFormat = "{1}{2}"

        ' 'hide PBC & Show GRID
        GCNewPrepare.RefreshDataSource()
        GVNewPrepare.RefreshData()

        'clear band array
        band_arr = Nothing
        band_alloc_break = Nothing
        break_alloc_initial.Clear()

        'best Fit
        GVNewPrepare.BestFitColumns()
    End Sub

    Private Sub BtnViewNewPrepare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewNewPrepare.Click
        Cursor = Cursors.WaitCursor
        Dim val As String = addSlashes(TxtNoParam.Text.ToString)
        If val = "" Then
            errorCustom("Data not found !")
        Else
            Dim query As String = "SELECT id_sales_order_gen FROM tb_sales_order_gen WHERE sales_order_gen_reff='" + val + "' LIMIT 1 "
            Dim id As String = ""
            Try
                id = execute_query(query, 0, True, "", "", "", "")
            Catch ex As Exception
            End Try
            If id = "" Then
                errorCustom("Data not found !")
            Else
                Dim rf As New ClassSalesOrder()
                rf.viewReff(id, "-1", GCNewPrepare, GVNewPrepare)
            End If
        End If
        'viewNewPrepare(TxtNoParam.Text)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesOrder_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesOrder.PopupMenuShowing
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            SMCreate.Visible = True
            UpdatePackingStatusToolStripMenuItem.Visible = False
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub BtnPrepareOrderHist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrepareOrderHist.Click
        Cursor = Cursors.WaitCursor
        Dim start_date As String = "-1"
        Try
            start_date = DateTime.Parse(DateEditFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim end_date As String = "-1"
        Try
            end_date = DateTime.Parse(DateEditUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        If start_date = "-1" Or end_date = "-1" Then
            stopCustom("Date can't blank.")
        Else
            Dim query As String = viewSalesOrderQuery("AND a.sales_order_date>='" + start_date + "' AND a.sales_order_date<='" + end_date + "' AND a.id_prepare_status='2' ")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSalesOrderHist.DataSource = data
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewDetailOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewDetailOrderToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTCPrepareList.SelectedTabPageIndex = 0 Then
           viewDetailOrder(GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString)
        ElseIf XTCPrepareList.SelectedTabPageIndex = 1 Then
            viewDetailOrder(GVSalesOrderHist.GetFocusedRowCellValue("id_sales_order").ToString)
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailOrder(ByVal id_sales_order_par As String)
        Cursor = Cursors.WaitCursor
        Dim sh As ClassShowPopUp = New ClassShowPopUp()
        sh.report_mark_type = "39"
        sh.id_report = id_sales_order_par
        sh.show()
        FormViewSalesOrder.BMark.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditRefresh.CheckedChanged
        Dim cek As String = CheckEditRefresh.EditValue.ToString
        If cek Then
            TimerMonitor.Enabled = True
        Else
            TimerMonitor.Enabled = False
        End If
    End Sub

    Private Sub TimerMonitor_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMonitor.Tick
        Cursor = Cursors.WaitCursor
        viewSalesOrder()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
       
    End Sub

    Private Sub GVSalesOrder_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesOrder.DoubleClick
        If GVSalesOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            viewDetailOrder(GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVSalesOrderHist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesOrderHist.DoubleClick
        If GVSalesOrderHist.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            viewDetailOrder(GVSalesOrderHist.GetFocusedRowCellValue("id_sales_order").ToString)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SMCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMCreate.Click
        Dim id_sales_order_par As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
        Dim type_process As String = "-1"
        Try
            type_process = GVSalesOrder.GetFocusedRowCellValue("id_so_status").ToString
        Catch ex As Exception
        End Try

        If type_process = "5" Then
            'trf
            Cursor = Cursors.WaitCursor
            Try
                'open menu
                FormFGTrfNew.MdiParent = FormMain
                FormFGTrfNew.Show()
                FormFGTrfNew.WindowState = FormWindowState.Maximized
                FormFGTrfNew.Focus()

                'go to form
                FormFGTrfNew.GVFGTrf.ApplyFindFilter("")
                FormFGTrfNewDet.id_sales_order = id_sales_order_par
                FormFGTrfNewDet.action = "ins"
                FormFGTrfNewDet.ShowDialog()
            Catch ex As Exception
                'errorProcess()
            End Try
            Cursor = Cursors.Default
        Else
            'delivery order
            Cursor = Cursors.WaitCursor
            Try
                'open menu
                FormSalesDelOrder.MdiParent = FormMain
                FormSalesDelOrder.Show()
                FormSalesDelOrder.WindowState = FormWindowState.Maximized
                FormSalesDelOrder.Focus()

                'go to form
                FormSalesDelOrder.GVSalesDelOrder.ApplyFindFilter("")
                FormSalesDelOrderDet.id_sales_order = id_sales_order_par
                FormSalesDelOrderDet.action = "ins"
                FormSalesDelOrderDet.ShowDialog()
            Catch ex As Exception
                'errorProcess()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SMView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMView.Click
        Dim id_sales_order_par As String = "-1"
        Dim order_number_par As String = "-1"
        Dim id_so_status As String = "-1"
        If XTCPrepareList.SelectedTabPageIndex = 0 Then
            id_sales_order_par = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString()
            order_number_par = GVSalesOrder.GetFocusedRowCellValue("sales_order_number").ToString()
            id_so_status = GVSalesOrder.GetFocusedRowCellValue("id_so_status").ToString
        ElseIf XTCPrepareList.SelectedTabPageIndex = 1 Then
            id_sales_order_par = GVSalesOrderHist.GetFocusedRowCellValue("id_sales_order").ToString()
            order_number_par = GVSalesOrderHist.GetFocusedRowCellValue("sales_order_number").ToString()
            id_so_status = GVSalesOrderHist.GetFocusedRowCellValue("id_so_status").ToString
        End If

        If id_so_status = "5" Then 'trf
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
        Else 'del
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
        End If
    End Sub

    Private Sub UpdatePackingStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdatePackingStatusToolStripMenuItem.Click
        Dim id_prepare As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
        Dim id_cur_stt As String = GVSalesOrder.GetFocusedRowCellValue("id_prepare_status").ToString
        FormSalesOrderPacking.id_trans = id_prepare
        FormSalesOrderPacking.id_cur_status = id_cur_stt
        FormSalesOrderPacking.ShowDialog()
    End Sub

    Private Sub GVSalesOrderHist_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesOrderHist.PopupMenuShowing
        If GVSalesOrderHist.RowCount > 0 And GVSalesOrderHist.FocusedRowHandle >= 0 Then
            SMCreate.Visible = False
            UpdatePackingStatusToolStripMenuItem.Visible = False
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub GVNewPrepare_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVNewPrepare.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class