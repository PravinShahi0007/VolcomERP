Public Class FormFGTransList
    Public page_active As String = ""

    Private Sub FormFGTransList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
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
        DEFromSal.EditValue = data_dt.Rows(0)("dt")
        DEUntilSal.EditValue = data_dt.Rows(0)("dt")
        DEFromSO.EditValue = data_dt.Rows(0)("dt")
        DEUntilSO.EditValue = data_dt.Rows(0)("dt")
        DEFromRepair.EditValue = data_dt.Rows(0)("dt")
        DEUntilRepair.EditValue = data_dt.Rows(0)("dt")
        DEFromRepairRec.EditValue = data_dt.Rows(0)("dt")
        DEUntilRepairRec.EditValue = data_dt.Rows(0)("dt")

        'lookup
        viewPeriodType()
        viewStatus()
        viewComp()

        SLStatus1.EditValue = "6"
        SLStatus2.EditValue = "6"
        SLStatus3.EditValue = "6"
        SLStatus4.EditValue = "6"
        SLStatus5.EditValue = "6"
        SLStatus6.EditValue = "6"
        SLStatus7.EditValue = "6"
        SLStatus8.EditValue = "6"
        SLStatus9.EditValue = "6"
        SLStatus10.EditValue = "6"
        SLEReportStatusRepair.EditValue = "6"
        SLEReportStatusRepairRec.EditValue = "6"

        'set size
        setCaptionSize(GVPLMain)
        setCaptionSize(GVSalesDelOrderMain)
        setCaptionSize(GVSOMain)
        setCaptionSize(GVSalesMain)
        setCaptionSize(GVSalesReturnMain)
        setCaptionSize(GVFGTrfMain)

        ActiveControl = DEFromRec
        page_active = "rec"
    End Sub

    Sub viewComp()
        Dim query As String = "
            SELECT c.id_comp, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`
            FROM tb_m_comp c 
            WHERE c.id_comp_cat IN (5,6)
            ORDER BY c.comp_number ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("comp").ToString
            c.Value = data.Rows(i)("id_comp").ToString

            CCBEStore.Properties.Items.Add(c)
        Next
    End Sub


    Sub viewPeriodType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '1' AS `id_period_type`,'Sales Date' AS `period_type`
        UNION
        SELECT '2' AS `id_period_type`,'Entry Date' AS `period_type` "
        viewSearchLookupQuery(SLEPeriodType, query, "id_period_type", "period_type", "id_period_type")
        Cursor = Cursors.Default
    End Sub

    Sub viewStatus()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT id_report_status, report_status FROM tb_lookup_report_status
        UNION
        SELECT 0 AS id_report_status, 'All Status' AS report_status"
        viewSearchLookupQuery(SLStatus1, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus2, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus3, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus4, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus5, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus6, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus7, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus8, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus9, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLStatus10, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEReportStatusRepair, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEReportStatusRepairRec, query, "id_report_status", "report_status", "id_report_status")
        Cursor = Cursors.Default
    End Sub

    Sub viewRec()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = If(SLStatus1.EditValue.ToString = "0", "", "AND a0.id_report_status = " + SLStatus1.EditValue.ToString)

        Dim query_c As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
        Dim data As DataTable = query_c.transactionList("AND (a0.pl_prod_order_rec_date>='" + date_from_selected + "' AND a0.pl_prod_order_rec_date<='" + date_until_selected + "') " + w_status, "1", True)
        GCPL.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewRecMainCode()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = If(SLStatus1.EditValue.ToString = "0", "", "AND a0.id_report_status = " + SLStatus1.EditValue.ToString)

        Dim query_c As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
        Dim data As DataTable = query_c.transactionList("AND (a0.pl_prod_order_rec_date>='" + date_from_selected + "' AND a0.pl_prod_order_rec_date<='" + date_until_selected + "') " + w_status, "1", False)
        GCPLMain.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub setCaptionSize(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        gv.Columns("qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("qty0").Caption = "0" + System.Environment.NewLine + "SM"
    End Sub

    Sub viewDO()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = If(SLStatus2.EditValue.ToString = "0", "", "AND a.id_report_status = " + SLStatus2.EditValue.ToString)

        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim data As DataTable = query_c.transactionList("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') " + w_status, "1", True)
        GCSalesDelOrder.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewDOMain()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = If(SLStatus2.EditValue.ToString = "0", "", "AND a.id_report_status = " + SLStatus2.EditValue.ToString)

        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim data As DataTable = query_c.transactionList("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') " + w_status, "1", False)
        GCSalesDelOrderMain.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewDO_Click(sender As Object, e As EventArgs) Handles BtnViewDO.Click
        If XTCDel.SelectedTabPageIndex = 0 Then
            viewDO()
        Else
            viewDOMain()
        End If
    End Sub

    Sub viewReturn()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = If(SLStatus3.EditValue.ToString = "0", "", "AND a.id_report_status = " + SLStatus3.EditValue.ToString)

        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim data As DataTable = query_c.transactionList("AND (a.id_ret_type!=2) AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') " + w_status, "1", True)
        GCSalesReturn.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewReturnMain()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = If(SLStatus3.EditValue.ToString = "0", "", "AND a.id_report_status = " + SLStatus3.EditValue.ToString)

        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim data As DataTable = query_c.transactionList("AND (a.id_ret_type!=2) AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') " + w_status, "1", False)
        GCSalesReturnMain.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewReturn_Click(sender As Object, e As EventArgs) Handles BtnViewReturn.Click
        If XTCReturn.SelectedTabPageIndex = 0 Then
            viewReturn()
        Else
            viewReturnMain
        End If
    End Sub

    Sub viewNonStock()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = If(SLStatus4.EditValue.ToString = "0", "", "AND a.id_report_status = " + SLStatus4.EditValue.ToString)

        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim data As DataTable = query_c.transactionListNSI("AND a.id_ret_type=2 AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') " + w_status, "1")
        GCNonStock.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewNonStock_Click(sender As Object, e As EventArgs) Handles BtnViewNonStock.Click
        viewNonStock()
    End Sub

    Private Sub BtnViewRec_Click(sender As Object, e As EventArgs) Handles BtnViewRec.Click
        If XTCRec.SelectedTabPageIndex = 0 Then
            viewRec()
        Else
            viewRecMainCode()
        End If
    End Sub

    Sub viewTrf()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = "AND 1=1 "
        w_status += If(SLStatus6.EditValue.ToString = "0", "", "AND trf.id_report_status = " + SLStatus6.EditValue.ToString) + " "
        If CCBEStore.EditValue.ToString <> "" Then
            w_status += "AND comp_to.id_comp IN (" + CCBEStore.EditValue.ToString + ") "
        End If

        Dim query_c As ClassFGTrf = New ClassFGTrf()
        Dim data As DataTable = query_c.transactionList("AND (trf.fg_trf_date>='" + date_from_selected + "' AND trf.fg_trf_date<='" + date_until_selected + "') " + w_status, "1", True)
        GCFGTrf.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewTrfMain()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = "AND 1=1 "
        w_status += If(SLStatus6.EditValue.ToString = "0", "", "AND trf.id_report_status = " + SLStatus6.EditValue.ToString) + " "
        If CCBEStore.EditValue.ToString <> "" Then
            w_status += "AND comp_to.id_comp IN (" + CCBEStore.EditValue.ToString + ") "
        End If

        Dim query_c As ClassFGTrf = New ClassFGTrf()
        Dim data As DataTable = query_c.transactionList("AND (trf.fg_trf_date>='" + date_from_selected + "' AND trf.fg_trf_date<='" + date_until_selected + "') " + w_status, "1", False)
        GCFGTrfMain.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewTrf_Click(sender As Object, e As EventArgs) Handles BtnViewTrf.Click
        If XTCTrf.SelectedTabPageIndex = 0 Then
            viewTrf()
        Else
            viewTrfMain()
        End If
    End Sub

    Sub viewRQC()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim w_status As String = If(SLStatus5.EditValue.ToString = "0", "", "AND a.id_report_status = " + SLStatus5.EditValue.ToString)

        Dim query_c As ClassSalesReturnQC = New ClassSalesReturnQC()
        Dim data As DataTable = query_c.transactionList("AND (a.sales_return_qc_date>='" + date_from_selected + "' AND a.sales_return_qc_date<='" + date_until_selected + "') " + w_status, "1")
        GCSalesReturnQC.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewReturnQC_Click(sender As Object, e As EventArgs) Handles BtnViewReturnQC.Click
        viewRQC()
    End Sub

    Private Sub FormFGTransList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGTransList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGTransList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCSvcLevel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSvcLevel.SelectedPageChanged
        Dim tab_index As Integer = XTCSvcLevel.SelectedTabPageIndex
        If tab_index = 0 Then
            page_active = "rec"
            ActiveControl = DEFromRec
        ElseIf tab_index = 1 Then
            page_active = "del"
            ActiveControl = DEFromDO
        ElseIf tab_index = 2 Then
            page_active = "ret"
            ActiveControl = DEFromReturn
        ElseIf tab_index = 3 Then
            page_active = "nsr"
            ActiveControl = DEFromNonStock
        ElseIf tab_index = 4 Then
            page_active = "ret_trf"
            ActiveControl = DEFromReturnQC
        ElseIf tab_index = 5 Then
            page_active = "trf"
            ActiveControl = DEFromTrf
        ElseIf tab_index = 6 Then
            page_active = "sal"
            ActiveControl = DEFromSal
        ElseIf tab_index = 7 Then
            page_active = "order"
            ActiveControl = DEFromSO
        ElseIf tab_index = 10 Then
            page_active = "repair"
            ActiveControl = DEFromRepair
        ElseIf tab_index = 11 Then
            page_active = "repair_rec"
            ActiveControl = DEFromRepairRec
        End If
    End Sub

    Private Sub DEFromRec_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromRec.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilRec.Focus()
        End If
    End Sub

    Private Sub DEUntilRec_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilRec.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewRec.Focus()
        End If
    End Sub

    Private Sub DEFromDO_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromDO.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilDO.Focus()
        End If
    End Sub

    Private Sub DEUntilDO_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilDO.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewDO.Focus()
        End If
    End Sub

    Private Sub DEFromReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromReturn.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilReturn.Focus()
        End If
    End Sub

    Private Sub DEUntilReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilReturn.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewReturn.Focus()
        End If
    End Sub

    Private Sub DEFromNonStock_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromNonStock.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilNonStock.Focus()
        End If
    End Sub

    Private Sub DEUntilNonStock_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilNonStock.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewNonStock.Focus()
        End If
    End Sub

    Private Sub DEFromReturnQC_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromReturnQC.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilReturnQC.Focus()
        End If
    End Sub

    Private Sub DEUntilReturnQC_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilReturnQC.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewReturnQC.Focus()
        End If
    End Sub

    Private Sub DEFromTrf_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromTrf.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilTrf.Focus()
        End If
    End Sub

    Private Sub DEUntilTrf_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilTrf.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewTrf.Focus()
        End If
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If XTCDel.SelectedTabPageIndex = 0 Then
            If GVSalesDelOrder.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim dt_from As String = DEFromDO.Text.Replace(" ", "")
                Dim dt_until As String = DEUntilDO.Text.Replace(" ", "")
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                'path = path + "del_" + dt_from + "_" + dt_until + ".xlsx"
                path = path + "tl_del.xlsx"
                exportToXLS(path, "del", GCSalesDelOrder)
                Cursor = Cursors.Default
            End If
        Else
            If GVSalesDelOrderMain.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'column option creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVSalesDelOrderMain.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                For i As Integer = 0 To GVSalesDelOrderMain.Columns.Count - 1
                    If GVSalesDelOrderMain.Columns(i).FieldName.Contains("qty") And GVSalesDelOrderMain.Columns(i).FieldName <> "pl_sales_order_del_det_qty" Then
                        GVSalesDelOrderMain.Columns(i).Caption = GVSalesDelOrderMain.Columns(i).FieldName.ToString
                    End If
                Next

                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                'path = path + "del_" + dt_from + "_" + dt_until + ".xlsx"
                path = path + "tl_del_by_code.xlsx"
                exportToXLS(path, "del", GCSalesDelOrderMain)

                'restore column opt
                GVSalesDelOrderMain.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLSRec_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRec.Click
        If XTCRec.SelectedTabPageIndex = 0 Then
            If GVPL.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim dt_from As String = DEFromRec.Text.Replace(" ", "")
                Dim dt_until As String = DEUntilRec.Text.Replace(" ", "")
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_rec.xlsx"
                exportToXLS(path, "rec", GCPL)
                Cursor = Cursors.Default
            End If
        Else
            If GVPLMain.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'column option creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVPLMain.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                For i As Integer = 0 To GVPLMain.Columns.Count - 1
                    If GVPLMain.Columns(i).FieldName.Contains("qty") And GVPLMain.Columns(i).FieldName <> "qty" Then
                        GVPLMain.Columns(i).Caption = GVPLMain.Columns(i).FieldName.ToString
                    End If
                Next

                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_rec_main_code.xlsx"
                exportToXLS(path, "rec", GCPLMain)

                'restore column opt
                GVPLMain.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnExportToXLSRet_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRet.Click
        If XTCReturn.SelectedTabPageIndex = 0 Then
            If GVSalesReturn.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim dt_from As String = DEFromReturn.Text.Replace(" ", "")
                Dim dt_until As String = DEUntilReturn.Text.Replace(" ", "")
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_ret.xlsx"
                exportToXLS(path, "ret", GCSalesReturn)
                Cursor = Cursors.Default
            End If
        Else
            If GVSalesReturnMain.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'column option creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVSalesReturnMain.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                For i As Integer = 0 To GVSalesReturnMain.Columns.Count - 1
                    If GVSalesReturnMain.Columns(i).FieldName.Contains("qty") And GVSalesReturnMain.Columns(i).FieldName <> "qty" Then
                        GVSalesReturnMain.Columns(i).Caption = GVSalesReturnMain.Columns(i).FieldName.ToString
                    End If
                Next

                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_ret_main.xlsx"
                exportToXLS(path, "ret", GCSalesReturnMain)

                'restore column opt
                GVSalesReturnMain.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnExportToXLSNonStock_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSNonStock.Click
        If GVNonStock.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_ns.xlsx"
            exportToXLS(path, "ns", GCNonStock)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLSRetTrf_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRetTrf.Click
        If GVSalesReturnQC.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_ret_trf.xlsx"
            exportToXLS(path, "ret_trf", GCSalesReturnQC)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLSTrf_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSTrf.Click
        If XTCTrf.SelectedTabPageIndex = 0 Then
            If GVFGTrf.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_trf.xlsx"
                exportToXLS(path, "trf", GCFGTrf)
                Cursor = Cursors.Default
            End If
        Else
            If GVFGTrfMain.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'column option creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVFGTrfMain.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                For i As Integer = 0 To GVFGTrfMain.Columns.Count - 1
                    If GVFGTrfMain.Columns(i).FieldName.Contains("qty") And GVFGTrfMain.Columns(i).FieldName <> "qty" Then
                        GVFGTrfMain.Columns(i).Caption = GVFGTrfMain.Columns(i).FieldName.ToString
                    End If
                Next

                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_trf_main.xlsx"
                exportToXLS(path, "trf", GCFGTrfMain)

                'restore column opt
                GVFGTrfMain.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnViewSal_Click(sender As Object, e As EventArgs) Handles BtnViewSal.Click
        If XTCSales.SelectedTabPageIndex = 0 Then
            viewSal()
        Else
            viewSalMain()
        End If
    End Sub

    Sub viewSal()
        Cursor = Cursors.WaitCursor
        'class
        Dim id_code_class As String = get_setup_field("id_code_fg_class")
        'period type
        Dim col_date As String = ""
        Dim col_date_uni As String = ""
        If SLEPeriodType.EditValue.ToString = "1" Then
            col_date = "sp.sales_pos_end_period"
            col_date_uni = "sp.period_from "
        Else
            col_date = "sp.sales_pos_date"
            col_date_uni = "sp.emp_uni_ex_date"
        End If
        'filter gwp (invoice nol/pendapatan lain dari missing)
        Dim cond_promo As String = "AND sp.report_mark_type!=116 "
        If CEPromo.EditValue = True Then
            cond_promo += ""
        Else
            cond_promo += "AND sp.sales_pos_total>0 "
        End If
        'date paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSal.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilSal.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim w_status As String = If(SLStatus7.EditValue.ToString = "0", "", " AND sp.id_report_status = " + SLStatus7.EditValue.ToString)

        Dim query As String = "SELECT spd.id_sales_pos_det, spd.id_sales_pos, sp.sales_pos_number, rmt.report_mark_type_name, 
        c.comp_number, c.comp_name, cg.comp_group, cg.description AS `comp_group_name`, lct.commerce_type,
        sp.sales_pos_date, sp.sales_pos_due_date,
        sp.sales_pos_start_period, sp.sales_pos_end_period,
        prod.id_product, prod.id_design, prod.`code`, prod.`code_main`,
        prod.`name`, prod.`size`, prod.`class`, prod.season, spd.sales_pos_det_qty, spd.design_price_retail, (spd.sales_pos_det_qty * spd.design_price_retail) AS `amount`,
        stt.report_status, IFNULL(prod.unit_cost,0) AS `unit_cost`
        FROM tb_sales_pos_det spd
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_commerce_type lct ON lct.id_commerce_type = c.id_commerce_type
        LEFT JOIN (
	        SELECT prod.id_product, prod.id_design, prod.product_full_code AS `code`, dsg.design_code AS `code_main`,
	        prod.product_display_name AS `name`, sz.code_detail_name AS `size`, cls.display_name AS `class`, dsg.design_cop AS `unit_cost`, ss.season
	        FROM tb_m_product prod
	        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
	        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = prod_code.id_code_detail
	        INNER JOIN tb_m_design_code dsg_code ON dsg_code.id_design = dsg.id_design
	        INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dsg_code.id_code_detail AND cls.id_code=" + id_code_class + "
            INNER JOIN tb_season ss ON ss.id_season = dsg.id_season
	        WHERE dsg.id_lookup_status_order!=2
        ) prod ON prod.id_product = spd.id_product
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = sp.id_report_status
        WHERE 1=1 AND (" + col_date + ">='" + date_from_selected + "' AND " + col_date + "<='" + date_until_selected + "') " + cond_promo + w_status
        If CEIncludePrmUni.EditValue = True Then
            query += " UNION ALL SELECT spd.id_emp_uni_ex_det AS id_sales_pos_det, spd.id_emp_uni_ex AS id_sales_pos, sp.emp_uni_ex_number AS sales_pos_number, rmt.report_mark_type_name, 
            c.comp_number, c.comp_name, cg.comp_group, cg.description AS `comp_group_name`, lct.commerce_type,
            sp.emp_uni_ex_date AS sales_pos_date, sp.emp_uni_ex_date AS sales_pos_due_date,
            sp.period_from AS sales_pos_start_period, sp.period_until AS sales_pos_end_period,
            prod.id_product, prod.id_design, prod.`code`, prod.`code_main`,
            prod.`name`, prod.`size`, prod.`class`, prod.season, spd.qty AS sales_pos_det_qty, (spd.design_cop + ((sp.vat_trans/100)*spd.design_cop)) AS design_price_retail, (spd.qty * (SELECT design_price_retail)) AS `amount`,
            stt.report_status, IFNULL(prod.unit_cost,0) AS `unit_cost`
            FROM tb_emp_uni_ex_det spd
            INNER JOIN tb_emp_uni_ex sp ON sp.id_emp_uni_ex = spd.id_emp_uni_ex
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= sp.id_comp_contact
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_commerce_type lct ON lct.id_commerce_type = c.id_commerce_type
            LEFT JOIN (
              SELECT prod.id_product, prod.id_design, prod.product_full_code AS `code`, dsg.design_code AS `code_main`,
              prod.product_display_name AS `name`, sz.code_detail_name AS `size`, cls.display_name AS `class`, dsg.design_cop AS `unit_cost`, ss.season
              FROM tb_m_product prod
              INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
              INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
              INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = prod_code.id_code_detail
              INNER JOIN tb_m_design_code dsg_code ON dsg_code.id_design = dsg.id_design
              INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dsg_code.id_code_detail AND cls.id_code=" + id_code_class + "
               INNER JOIN tb_season ss ON ss.id_season = dsg.id_season
              WHERE dsg.id_lookup_status_order!=2
            ) prod ON prod.id_product = spd.id_product
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = sp.id_report_status
            JOIN tb_opt o
            WHERE sp.period_until>=o.sales_uni_start_period  AND (" + col_date_uni + ">='" + date_from_selected + "' AND " + col_date_uni + "<='" + date_until_selected + "') " + w_status
        End If
        query += " ORDER BY id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewSalMain()
        Cursor = Cursors.WaitCursor
        'class
        Dim id_code_class As String = get_setup_field("id_code_fg_class")
        'period type
        Dim col_date As String = ""
        Dim col_date_uni As String = ""
        If SLEPeriodType.EditValue.ToString = "1" Then
            col_date = "sp.sales_pos_end_period"
            col_date_uni = "sp.period_until"
        Else
            col_date = "sp.sales_pos_date"
            col_date_uni = "sp.emp_uni_ex_date"
        End If
        'filter promo
        Dim cond_promo As String = "AND sp.report_mark_type!=116 "
        If CEPromo.EditValue = True Then
            cond_promo += ""
        Else
            cond_promo += "AND sp.sales_pos_total>0 "
        End If
        'date paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSal.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilSal.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim w_status As String = If(SLStatus7.EditValue.ToString = "0", "", " AND sp.id_report_status = " + SLStatus7.EditValue.ToString)

        Dim query As String = "SELECT spd.id_sales_pos_det, spd.id_sales_pos, sp.sales_pos_number, rmt.report_mark_type_name, 
        c.comp_number, c.comp_name, cg.comp_group, cg.description AS `comp_group_name`,lct.commerce_type,
        sp.sales_pos_date, sp.sales_pos_due_date,
        sp.sales_pos_start_period, sp.sales_pos_end_period,
        prod.id_product, prod.id_design, prod.`code`,
        prod.`name`, SUBSTRING(prod.product_full_code, 10, 1) AS `sizetype`, prod.`class`,  prod.season,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='1' THEN spd.sales_pos_det_qty END),0) AS `qty1`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='2' THEN spd.sales_pos_det_qty END),0) AS `qty2`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='3' THEN spd.sales_pos_det_qty END),0) AS `qty3`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='4' THEN spd.sales_pos_det_qty END),0) AS `qty4`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='5' THEN spd.sales_pos_det_qty END),0) AS `qty5`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='6' THEN spd.sales_pos_det_qty END),0) AS `qty6`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='7' THEN spd.sales_pos_det_qty END),0) AS `qty7`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='8' THEN spd.sales_pos_det_qty END),0) AS `qty8`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='9' THEN spd.sales_pos_det_qty END),0) AS `qty9`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='0' THEN spd.sales_pos_det_qty END),0) AS `qty0`,
        SUM(spd.sales_pos_det_qty) AS `sales_pos_det_qty`, spd.design_price_retail, 
        SUM(spd.sales_pos_det_qty * spd.design_price_retail) AS `amount`,
        stt.report_status, IFNULL(prod.unit_cost,0) AS `unit_cost`
        FROM tb_sales_pos_det spd
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_commerce_type lct ON lct.id_commerce_type = c.id_commerce_type
        LEFT JOIN (
	        SELECT prod.id_product, prod.id_design, prod.product_full_code, dsg.design_code AS `code`, ss.season,
	        prod.product_display_name AS `name`, sz.code_detail_name AS `size`, cls.display_name AS `class`, sz.code AS `code_size`, dsg.design_cop AS `unit_cost`
	        FROM tb_m_product prod
	        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
	        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = prod_code.id_code_detail
	        INNER JOIN tb_m_design_code dsg_code ON dsg_code.id_design = dsg.id_design
	        INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dsg_code.id_code_detail AND cls.id_code=" + id_code_class + "
            INNER JOIN tb_season ss ON ss.id_season = dsg.id_season
	        WHERE dsg.id_lookup_status_order!=2
        ) prod ON prod.id_product = spd.id_product
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = sp.id_report_status
        WHERE 1=1 AND (" + col_date + ">='" + date_from_selected + "' AND " + col_date + "<='" + date_until_selected + "') " + cond_promo + w_status
        query += " GROUP BY sp.id_sales_pos, prod.id_design, SUBSTRING(prod.product_full_code, 10, 1) "
        If CEIncludePrmUni.EditValue = True Then
            query += " UNION ALL SELECT spd.id_emp_uni_ex_det AS id_sales_pos_det, spd.id_emp_uni_ex AS id_sales_pos, sp.emp_uni_ex_number AS sales_pos_number, rmt.report_mark_type_name, 
            c.comp_number, c.comp_name, cg.comp_group, cg.description AS `comp_group_name`, lct.commerce_type,
            sp.emp_uni_ex_date AS sales_pos_date, sp.emp_uni_ex_date AS sales_pos_due_date,
            sp.period_from AS sales_pos_start_period, sp.period_until AS sales_pos_end_period,
            prod.id_product, prod.id_design, prod.`code`,
            prod.`name`, SUBSTRING(prod.product_full_code, 10, 1) AS `sizetype`, prod.`class`, prod.season, 
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='1' THEN spd.qty END),0) AS `qty1`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='2' THEN spd.qty END),0) AS `qty2`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='3' THEN spd.qty END),0) AS `qty3`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='4' THEN spd.qty END),0) AS `qty4`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='5' THEN spd.qty END),0) AS `qty5`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='6' THEN spd.qty END),0) AS `qty6`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='7' THEN spd.qty END),0) AS `qty7`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='8' THEN spd.qty END),0) AS `qty8`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='9' THEN spd.qty END),0) AS `qty9`,
            IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='0' THEN spd.qty END),0) AS `qty0`,
            SUM(spd.qty) AS `sales_pos_det_qty`,(spd.design_cop + ((sp.vat_trans/100)*spd.design_cop)) AS design_price_retail, 
            SUM(spd.qty * (SELECT design_price_retail)) AS `amount`,
            stt.report_status, IFNULL(prod.unit_cost,0) AS `unit_cost`
            FROM tb_emp_uni_ex_det spd
            INNER JOIN tb_emp_uni_ex sp ON sp.id_emp_uni_ex = spd.id_emp_uni_ex
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= sp.id_comp_contact
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_commerce_type lct ON lct.id_commerce_type = c.id_commerce_type
            LEFT JOIN (
              SELECT prod.id_product, prod.id_design, prod.product_full_code, dsg.design_code AS `code`,
              prod.product_display_name AS `name`, sz.code_detail_name AS `size`, cls.display_name AS `class`, sz.code AS `code_size`, dsg.design_cop AS `unit_cost`, ss.season
              FROM tb_m_product prod
              INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
              INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
              INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = prod_code.id_code_detail
              INNER JOIN tb_m_design_code dsg_code ON dsg_code.id_design = dsg.id_design
              INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dsg_code.id_code_detail AND cls.id_code=" + id_code_class + "
               INNER JOIN tb_season ss ON ss.id_season = dsg.id_season
              WHERE dsg.id_lookup_status_order!=2
            ) prod ON prod.id_product = spd.id_product
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = sp.id_report_status
            JOIN tb_opt o
            WHERE sp.period_until>=o.sales_uni_start_period  AND (" + col_date_uni + ">='" + date_from_selected + "' AND " + col_date_uni + "<='" + date_until_selected + "') " + w_status
            query += " GROUP BY sp.id_emp_uni_ex, prod.id_design, SUBSTRING(prod.product_full_code, 10, 1) "
        End If
        query += " ORDER BY id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesMain.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLSSal_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSSal.Click
        If XTCSales.SelectedTabPageIndex = 0 Then
            If GVSales.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_sal.xlsx"
                exportToXLS(path, "sal", GCSales)
                Cursor = Cursors.Default
            End If
        Else
            If GVSalesMain.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'column option creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVSalesMain.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                For i As Integer = 0 To GVSalesMain.Columns.Count - 1
                    If GVSalesMain.Columns(i).FieldName.Contains("qty") And GVSalesMain.Columns(i).FieldName <> "sales_pos_det_qty" Then
                        GVSalesMain.Columns(i).Caption = GVSalesMain.Columns(i).FieldName.ToString
                    End If
                Next

                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_sal_main.xlsx"
                exportToXLS(path, "sal", GCSalesMain)

                'restore column opt
                GVSalesMain.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnViewSO_Click(sender As Object, e As EventArgs) Handles BtnViewSO.Click
        If XTCSO.SelectedTabPageIndex = 0 Then
            viewPrepareOrder()
        Else
            viewPrepareOrderMain()
        End If
    End Sub

    Sub viewPrepareOrder()
        Cursor = Cursors.WaitCursor
        'date paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilSO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim w_status As String = If(SLStatus8.EditValue.ToString = "0", "", "AND so.id_report_status = " + SLStatus8.EditValue.ToString)

        Dim query As String = "SELECT so.id_sales_order, so.sales_order_number, ot.order_type, so.id_so_status, cat.so_status, gen.sales_order_gen_reff, so.sales_order_date,
        rs.id_report_status, rs.report_status,
        wh.comp_number AS `wh_account`, wh.comp_name AS `wh`, 
        store.comp_number AS `store_account`, store.comp_name AS `store`, cg.comp_group, cg.description AS `comp_group_name`,
        so_det.id_product,prod.product_full_code, prod.design_code, (prod.`class`) AS `class_display`, prod.design_display_name, (prod.size) AS `size`, prod.color, prod.sht,
        so_det.sales_order_det_qty, so_det.design_price, (so_det.sales_order_det_qty * so_det.design_price) AS `amount`, 
        so.id_prepare_status, stt.prepare_status,so.final_comment
        FROM tb_sales_order_det so_det 
        INNER JOIN tb_sales_order so ON so.id_sales_order = so_det.id_sales_order
        INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = so.id_so_status
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = cat.id_order_type
        INNER JOIN tb_lookup_prepare_status stt ON stt.id_prepare_status = so.id_prepare_status
        LEFT JOIN tb_sales_order_gen gen ON gen.id_sales_order_gen = so.id_sales_order_gen
        INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = so.id_warehouse_contact_to 
        INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp 
        INNER JOIN tb_m_comp_contact store_cont ON store_cont.id_comp_contact = so.id_store_contact_to 
        INNER JOIN tb_m_comp store ON store.id_comp = store_cont.id_comp 
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = store.id_comp_group
        LEFT JOIN (
            SELECT  a.id_product,f.product_full_code, f.product_ean_code,f.product_name, f.product_display_name,e.id_season,e.season,d.id_design, d.design_code, d.id_sample,d.design_name, e.id_range, d.design_display_name,
            (del.delivery_date) AS `design_del_date`, (del.est_wh_date) AS `design_wh_date`, b.code_detail_name AS `size`, d2.display_name AS `class`, cd.color, cd.sht
            FROM tb_m_product f  
            INNER JOIN tb_m_product_code a ON a.id_product = f.id_product 
            INNER JOIN tb_m_code_detail b ON a.id_code_detail = b.id_code_detail 
            INNER JOIN tb_m_design d ON f.id_design = d.id_design 
            LEFT JOIN (
		        SELECT dc.id_design, 
		        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
		        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
		        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
		        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
		        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
		        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
		        FROM tb_m_design_code dc
		        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
		        AND cd.id_code IN (32,30,14, 43)
		        GROUP BY dc.id_design
	        ) cd ON cd.id_design = d.id_design
            INNER JOIN tb_m_design_code d1 ON d.id_design = d1.id_design 
            INNER JOIN tb_m_code_detail d2 ON d1.id_code_detail = d2.id_code_detail AND d2.id_code=30
            INNER JOIN tb_season e ON d.id_season=e.id_season
            INNER JOIN tb_season_delivery del ON d.id_delivery = del.id_delivery
            GROUP BY f.id_product
        ) prod ON prod.id_product = so_det.id_product
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = so.id_report_status
        WHERE 1=1 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') " + w_status + "
        ORDER BY so.id_sales_order ASC , prod.`class` ASC, product_full_code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSO.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewPrepareOrderMain()
        Cursor = Cursors.WaitCursor
        'date paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilSO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim w_status As String = If(SLStatus8.EditValue.ToString = "0", "", "AND so.id_report_status = " + SLStatus8.EditValue.ToString)

        Dim query As String = "SELECT so.id_sales_order, so.sales_order_number, ot.order_type, so.id_so_status, cat.so_status, gen.sales_order_gen_reff, so.sales_order_date,
        rs.id_report_status, rs.report_status,
        wh.comp_number AS `wh_account`, wh.comp_name AS `wh`, 
        store.comp_number AS `store_account`, store.comp_name AS `store`, cg.comp_group, cg.description AS `comp_group_name`,
        so_det.id_product,prod.product_full_code, prod.design_code, (prod.`class`) AS `class_display`, prod.design_display_name, (prod.size) AS `size`, prod.color, prod.sht,
        SUBSTRING(prod.product_full_code, 10, 1) AS `sizetype`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='1' THEN so_det.sales_order_det_qty END),0) AS `qty1`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='2' THEN so_det.sales_order_det_qty END),0) AS `qty2`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='3' THEN so_det.sales_order_det_qty END),0) AS `qty3`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='4' THEN so_det.sales_order_det_qty END),0) AS `qty4`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='5' THEN so_det.sales_order_det_qty END),0) AS `qty5`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='6' THEN so_det.sales_order_det_qty END),0) AS `qty6`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='7' THEN so_det.sales_order_det_qty END),0) AS `qty7`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='8' THEN so_det.sales_order_det_qty END),0) AS `qty8`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='9' THEN so_det.sales_order_det_qty END),0) AS `qty9`,
        IFNULL(SUM(CASE WHEN SUBSTRING(prod.code_size,2,1)='0' THEN so_det.sales_order_det_qty END),0) AS `qty0`,
        SUM(so_det.sales_order_det_qty) AS `sales_order_det_qty`, 
        so_det.design_price, SUM(so_det.sales_order_det_qty * so_det.design_price) AS `amount`, 
        so.id_prepare_status, stt.prepare_status,so.final_comment
        FROM tb_sales_order_det so_det 
        INNER JOIN tb_sales_order so ON so.id_sales_order = so_det.id_sales_order
        INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = so.id_so_status
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = cat.id_order_type
        INNER JOIN tb_lookup_prepare_status stt ON stt.id_prepare_status = so.id_prepare_status
        LEFT JOIN tb_sales_order_gen gen ON gen.id_sales_order_gen = so.id_sales_order_gen
        INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = so.id_warehouse_contact_to 
        INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp 
        INNER JOIN tb_m_comp_contact store_cont ON store_cont.id_comp_contact = so.id_store_contact_to 
        INNER JOIN tb_m_comp store ON store.id_comp = store_cont.id_comp 
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = store.id_comp_group
        LEFT JOIN (
            SELECT  a.id_product,f.product_full_code, f.product_ean_code,f.product_name, f.product_display_name,e.id_season,e.season,d.id_design, d.design_code, d.id_sample,d.design_name, e.id_range, d.design_display_name,
            (del.delivery_date) AS `design_del_date`, (del.est_wh_date) AS `design_wh_date`, b.code_detail_name AS `size`, b.code AS `code_size`,
            d2.display_name AS `class`, cd.color , cd.sht
            FROM tb_m_product f  
            INNER JOIN tb_m_product_code a ON a.id_product = f.id_product 
            INNER JOIN tb_m_code_detail b ON a.id_code_detail = b.id_code_detail 
            INNER JOIN tb_m_design d ON f.id_design = d.id_design 
            LEFT JOIN (
		        SELECT dc.id_design, 
		        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
		        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
		        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
		        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
		        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
		        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
		        FROM tb_m_design_code dc
		        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
		        AND cd.id_code IN (32,30,14, 43)
		        GROUP BY dc.id_design
	        ) cd ON cd.id_design = d.id_design
            INNER JOIN tb_m_design_code d1 ON d.id_design = d1.id_design 
            INNER JOIN tb_m_code_detail d2 ON d1.id_code_detail = d2.id_code_detail AND d2.id_code=30
            INNER JOIN tb_season e ON d.id_season=e.id_season
            INNER JOIN tb_season_delivery del ON d.id_delivery = del.id_delivery
            GROUP BY f.id_product
        ) prod ON prod.id_product = so_det.id_product
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = so.id_report_status
        WHERE 1=1 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') " + w_status + "
        GROUP BY so.id_sales_order, prod.id_design, SUBSTRING(prod.product_full_code, 10, 1)
        ORDER BY so.id_sales_order ASC , prod.`class` ASC, product_full_code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOMain.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLSSO_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSSO.Click
        If XTCSO.SelectedTabPageIndex = 0 Then
            If GVSO.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_order.xlsx"
                exportToXLS(path, "order", GCSO)
                Cursor = Cursors.Default
            End If
        Else
            If GVSOMain.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'column option creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVSOMain.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                For i As Integer = 0 To GVSOMain.Columns.Count - 1
                    If GVSOMain.Columns(i).FieldName.Contains("qty") And GVSOMain.Columns(i).FieldName <> "sales_order_det_qty" Then
                        GVSOMain.Columns(i).Caption = GVSOMain.Columns(i).FieldName.ToString
                    End If
                Next

                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "tl_order_main.xlsx"
                exportToXLS(path, "order", GCSOMain)

                'restore column opt
                GVSOMain.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Cursor = Cursors.Default
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub SBViewAdjIn_Click(sender As Object, e As EventArgs) Handles SBViewAdjIn.Click
        Cursor = Cursors.WaitCursor

        'date paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"

        Try
            date_from_selected = DateTime.Parse(DEFromAdjIn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilAdjIn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim where_status As String = If(SLStatus9.EditValue.ToString = "0", "", "AND fg.id_report_status = " + SLStatus9.EditValue.ToString)

        Dim query As String = "
            SELECT *
            FROM tb_adj_in_fg_det AS fg_det
            LEFT JOIN tb_adj_in_fg AS fg ON fg_det.id_adj_in_fg = fg.id_adj_in_fg
            LEFT JOIN (
                SELECT a.id_product, f.product_full_code, f.product_ean_code, f.product_name, f.product_display_name, e.id_season,e.season,d.id_design, d.design_code, d.id_sample, d.design_name, e.id_range, d.design_display_name,
                del.delivery_date AS design_del_date, del.est_wh_date AS design_wh_date, b.code_detail_name AS `size`, d2.display_name AS `class`
                FROM tb_m_product f  
                INNER JOIN tb_m_product_code a ON a.id_product = f.id_product 
                INNER JOIN tb_m_code_detail b ON a.id_code_detail = b.id_code_detail 
                INNER JOIN tb_m_design d ON f.id_design = d.id_design 
                INNER JOIN tb_m_design_code d1 ON d.id_design = d1.id_design 
                INNER JOIN tb_m_code_detail d2 ON d1.id_code_detail = d2.id_code_detail AND d2.id_code=30
                INNER JOIN tb_season e ON d.id_season=e.id_season
                INNER JOIN tb_season_delivery del ON d.id_delivery = del.id_delivery
                GROUP BY f.id_product
            ) prod ON prod.id_product = fg_det.id_product
            LEFT JOIN tb_m_wh_drawer AS wd ON fg_det.id_wh_drawer = wd.id_wh_drawer
            LEFT JOIN tb_m_wh_rack AS wr ON wd.id_wh_rack = wr.id_wh_rack
            LEFT JOIN tb_m_wh_locator AS wl ON wr.id_wh_locator = wl.id_wh_locator
            LEFT JOIN tb_m_comp AS comp ON wl.id_comp = comp.id_comp
            LEFT JOIN tb_lookup_report_status AS rmt ON fg.id_report_status = rmt.id_report_status
            WHERE fg.adj_in_fg_date BETWEEN '" + date_from_selected + "' AND '" + date_until_selected + "' " + where_status + "
        "

        GCAdjIn.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVAdjIn.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBViewAdjOut_Click(sender As Object, e As EventArgs) Handles SBViewAdjOut.Click
        Cursor = Cursors.WaitCursor

        'date paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"

        Try
            date_from_selected = DateTime.Parse(DEFromAdjOut.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilAdjOut.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim where_status As String = If(SLStatus10.EditValue.ToString = "0", "", "AND fg.id_report_status = " + SLStatus10.EditValue.ToString)

        Dim query As String = "
            SELECT *
            FROM tb_adj_out_fg_det AS fg_det
            LEFT JOIN tb_adj_out_fg AS fg ON fg_det.id_adj_out_fg = fg.id_adj_out_fg
            LEFT JOIN (
                SELECT a.id_product, f.product_full_code, f.product_ean_code, f.product_name, f.product_display_name, e.id_season,e.season,d.id_design, d.design_code, d.id_sample, d.design_name, e.id_range, d.design_display_name,
                del.delivery_date AS design_del_date, del.est_wh_date AS design_wh_date, b.code_detail_name AS `size`, d2.display_name AS `class`
                FROM tb_m_product f  
                INNER JOIN tb_m_product_code a ON a.id_product = f.id_product 
                INNER JOIN tb_m_code_detail b ON a.id_code_detail = b.id_code_detail 
                INNER JOIN tb_m_design d ON f.id_design = d.id_design 
                INNER JOIN tb_m_design_code d1 ON d.id_design = d1.id_design 
                INNER JOIN tb_m_code_detail d2 ON d1.id_code_detail = d2.id_code_detail AND d2.id_code=30
                INNER JOIN tb_season e ON d.id_season=e.id_season
                INNER JOIN tb_season_delivery del ON d.id_delivery = del.id_delivery
                GROUP BY f.id_product
            ) prod ON prod.id_product = fg_det.id_product
            LEFT JOIN tb_m_wh_drawer AS wd ON fg_det.id_wh_drawer = wd.id_wh_drawer
            LEFT JOIN tb_m_wh_rack AS wr ON wd.id_wh_rack = wr.id_wh_rack
            LEFT JOIN tb_m_wh_locator AS wl ON wr.id_wh_locator = wl.id_wh_locator
            LEFT JOIN tb_m_comp AS comp ON wl.id_comp = comp.id_comp
            LEFT JOIN tb_lookup_report_status AS rmt ON fg.id_report_status = rmt.id_report_status
            WHERE fg.adj_out_fg_date BETWEEN '" + date_from_selected + "' AND '" + date_until_selected + "' " + where_status + "
        "

        GCAdjOut1.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVAdjOut1.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGTransList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            FormMenuAuth.type = "6"
            FormMenuAuth.ShowDialog()
        End If
    End Sub

    Private Sub SBExcelAdjIn_Click(sender As Object, e As EventArgs) Handles SBExcelAdjIn.Click
        If GVAdjIn.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_adj_in.xlsx"
            exportToXLS(path, "adj_in", GCAdjIn)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SBExcelAdjOut_Click(sender As Object, e As EventArgs) Handles SBExcelAdjOut.Click
        If GVAdjOut1.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_adj_out.xlsx"
            exportToXLS(path, "adj_out", GCAdjOut1)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnXLSRepair_Click(sender As Object, e As EventArgs) Handles BtnXLSRepair.Click
        If GVRepair.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_repair.xlsx"
            exportToXLS(path, "repair", GCRepair)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnRepair_Click(sender As Object, e As EventArgs) Handles BtnRepair.Click
        viewRepair
    End Sub

    Sub viewRepair()
        Cursor = Cursors.WaitCursor

        'date paramater
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

        Dim where_status As String = If(SLEReportStatusRepair.EditValue.ToString = "0", "", "AND r.id_report_status = " + SLEReportStatusRepair.EditValue.ToString + " ")


        Dim query As String = "SELECT r.id_fg_repair, r.fg_repair_number, r.fg_repair_date, 
        cf.comp_number AS `comp_number_from`, cf.comp_name AS `comp_name_from`,
        ct.comp_number AS `comp_number_to`, ct.comp_name AS `comp_name_to`,
        p.id_product, p.product_full_code AS `code`, cd.class,p.product_display_name AS `name`, cd.color, cd.sht, sz.code_detail_name AS `size`, YEAR(d.design_first_rec_wh) AS `rec_wh`,
        COUNT(rd.id_product) AS `qty`,r.fg_repair_note, stt.report_status, IF(r.is_to_vendor=1,'Repair to Vendor', 'Repair to QC') AS `repair_type`
        FROM tb_fg_repair r
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        INNER JOIN tb_fg_repair_det rd ON rd.id_fg_repair = r.id_fg_repair
        INNER JOIN tb_m_comp cf ON cf.id_drawer_def = r.id_wh_drawer_from
        INNER JOIN tb_m_comp ct ON ct.id_drawer_def = r.id_wh_drawer_to
        INNER JOIN tb_m_product p ON p.id_product = rd.id_product
        INNER JOIN tb_m_design d ON d.id_design = p.id_design   
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
        LEFT JOIN (
	        SELECT dc.id_design, 
	        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43)
	        GROUP BY dc.id_design
        ) cd ON cd.id_design = d.id_design
        WHERE (r.fg_repair_date>='" + date_from_selected + "' AND r.fg_repair_date<='" + date_until_selected + "') " + where_status
        query += "GROUP BY rd.id_fg_repair, rd.id_product 
        ORDER BY id_fg_repair ASC, class ASC, name ASC, code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepair.DataSource = Data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnRepairRec_Click(sender As Object, e As EventArgs) Handles BtnRepairRec.Click
        viewRepairRec()
    End Sub

    Sub viewRepairRec()
        Cursor = Cursors.WaitCursor
        'date paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"

        Try
            date_from_selected = DateTime.Parse(DEFromRepairRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilRepairRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim where_status As String = If(SLEReportStatusRepairRec.EditValue.ToString = "0", "", "AND rr.id_report_status = " + SLEReportStatusRepairRec.EditValue.ToString + " ")

        Dim query As String = "SELECT rr.id_fg_repair_rec,rr.fg_repair_rec_number, r.fg_repair_number, rr.fg_repair_rec_date,
        cf.comp_number AS `comp_number_from`, cf.comp_name AS `comp_name_from`,
        ct.comp_number AS `comp_number_to`, ct.comp_name AS `comp_name_to`,
        p.product_full_code, cd.class, d.design_display_name AS `name`, cd.color, cd.sht, 
        COUNT(rrd.id_fg_repair_rec_det) AS `qty`, rr.fg_repair_rec_note, stt.report_status
        FROM tb_fg_repair_rec rr
        INNER JOIN tb_fg_repair r ON r.id_fg_repair = rr.id_fg_repair
        INNER JOIN tb_m_comp cf ON cf.id_drawer_def = rr.id_wh_drawer_from
        INNER JOIN tb_m_comp ct ON ct.id_drawer_def = rr.id_wh_drawer_to
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = rr.id_report_status
        INNER JOIN tb_fg_repair_rec_det rrd ON rrd.id_fg_repair_rec = rr.id_fg_repair_rec
        INNER JOIN tb_m_product p ON p.id_product = rrd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        LEFT JOIN (
          SELECT dc.id_design, 
          MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
          MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
          MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
          MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
          MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
          MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
          MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
          MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
          MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
          FROM tb_m_design_code dc
          INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
          AND cd.id_code IN (32,30,14, 43)
          GROUP BY dc.id_design
        ) cd ON cd.id_design = d.id_design
        WHERE rr.id_fg_repair_rec>0 AND (rr.fg_repair_rec_date>='" + date_from_selected + "' AND rr.fg_repair_rec_date<='" + date_until_selected + "')
        " + where_status + "
        GROUP BY rrd.id_fg_repair_rec, rrd.id_product
        ORDER BY rrd.id_fg_repair_rec ASC, `class` ASC, `name` ASC, `product_full_code` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepairRec.DataSource = data
        'GVRepairRec.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXLSRepairRec_Click(sender As Object, e As EventArgs) Handles BtnXLSRepairRec.Click
        If GVRepairRec.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_repair_rec.xlsx"
            exportToXLS(path, "repair_rec", GCRepairRec)
            Cursor = Cursors.Default
        End If
    End Sub
End Class