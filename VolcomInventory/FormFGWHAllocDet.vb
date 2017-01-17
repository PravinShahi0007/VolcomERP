Public Class FormFGWHAllocDet
    Public id_fg_wh_alloc As String = "-1"
    Public action As String = "-1"
    Public id_wh_drawer_from As String = "-1"
    Public id_wh_rack_from As String = "-1"
    Public id_wh_locator_from As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_report_status As String = "-1"
    Public id_pre As String = "-1"
    Dim is_submit As String = "2"


    Private Sub FormFGWHAllocDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSeason()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    'view season
    Sub viewSeason()
        ' Dim query As String = "SELECT * FROM tb_season a "
        'query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        'query += "WHERE b.is_md='1' "
        'query += "ORDER BY b.range DESC"
        'viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            GroupControlItemList.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            BtnSave.Text = "Create New"
        ElseIf action = "upd" Then
            GroupControlItemList.Enabled = True
            DDBPrint.Enabled = True
            BtnAttachment.Enabled = True
            BtnSave.Text = "Save Changes"
            BtnBrowseFrom.Enabled = False
            TxtCodeCompFrom.Enabled = False

            'query view based on edit id's
            Dim query_c As ClassFGWHAlloc = New ClassFGWHAlloc()
            Dim query As String = query_c.queryMain("AND allc.id_fg_wh_alloc='" + id_fg_wh_alloc + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_wh_alloc = data.Rows(0)("id_fg_wh_alloc").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNumber.Text = data.Rows(0)("fg_wh_alloc_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_wh_alloc_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_wh_alloc_note").ToString
            id_comp_from = data.Rows(0)("id_comp").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
            id_wh_drawer_from = data.Rows(0)("id_wh_drawer").ToString
            id_wh_rack_from = data.Rows(0)("id_wh_rack").ToString
            id_wh_locator_from = data.Rows(0)("id_wh_locator").ToString
            is_submit = data.Rows(0)("is_submit").ToString

            If is_submit = "1" Then
                BMark.Enabled = True
            Else
                BMark.Enabled = False
            End If

            'detail2
            viewDetail()
            check_but()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                Printing()
                Close()
            End If
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_fg_wh_alloc(" + id_fg_wh_alloc + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data

        If is_submit = "1" Then
            GridColumnCompTo.GroupIndex = 0
            XTPSummary.PageVisible = False
            XTPDetailAlloc.PageVisible = True
            Dim ac As New ClassFGWHAlloc()
            Dim qs As String = ac.queryAllocReport(id_fg_wh_alloc)
            Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
            GCSum2.DataSource = ds
            GVSum2.Columns("1").Caption = "1" + System.Environment.NewLine + "XXS"
            GVSum2.Columns("2").Caption = "2" + System.Environment.NewLine + "XS"
            GVSum2.Columns("3").Caption = "3" + System.Environment.NewLine + "S"
            GVSum2.Columns("4").Caption = "4" + System.Environment.NewLine + "M"
            GVSum2.Columns("5").Caption = "5" + System.Environment.NewLine + "ML"
            GVSum2.Columns("6").Caption = "6" + System.Environment.NewLine + "L"
            GVSum2.Columns("7").Caption = "7" + System.Environment.NewLine + "XL"
            GVSum2.Columns("8").Caption = "8" + System.Environment.NewLine + "XXL"
            GVSum2.Columns("9").Caption = "9" + System.Environment.NewLine + "ALL"
            GVSum2.Columns("0").Caption = "0" + System.Environment.NewLine + "SM"
            GVSum2.GroupFormat = "{1}{2}"
            GVSum2.RefreshData()
        Else
            Dim query_sum As String = "CALL view_fg_wh_alloc_sum(" + id_fg_wh_alloc + ")"
            Dim data_sum As DataTable = execute_query(query_sum, -1, True, "", "", "", "")
            GCSummary.DataSource = data_sum
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = " Select * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_productx <> "0" Then
            BtnDelete.Enabled = True
        Else
            BtnDelete.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "87", id_fg_wh_alloc) And is_submit = "2" Then
            MENote.Enabled = True
            BtnSave.Enabled = True
            PanelNavBarcode.Enabled = True
            BtnBrowseFrom.Enabled = False
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
            PanelNavBarcode.Enabled = False
            BtnBrowseFrom.Enabled = False
        End If
        SLESeason.Enabled = False


        'ATTACH
        If check_attach_report_status(id_report_status, "87", id_fg_wh_alloc) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrinting.Enabled = True
        Else
            BtnPrinting.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "And comp.id_comp_cat = '" + get_setup_field("id_comp_cat_wh") + "' "
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, "-1")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                TxtNameCompFrom.Text = ""
                id_comp_from = "-1"
                id_wh_drawer_from = "-1"
                TxtCodeCompFrom.Text = ""
                TxtCodeCompFrom.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_from = data.Rows(0)("id_comp").ToString
                id_wh_drawer_from = data.Rows(0)("id_wh_drawer").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                viewDetail()
                BtnSave.Focus()
                Cursor = Cursors.Default
            End If
        End If
    End Sub


    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGWHAllocDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_wh_drawer_from = "-1" Then
            stopCustom("Drawer is not found, please check account from!")
        Else
            Dim fg_wh_alloc_note As String = MENote.Text.ToString
            If action = "ins" Then
                Cursor = Cursors.WaitCursor
                'query main
                Dim query As String = "INSERT INTO tb_fg_wh_alloc(id_wh_drawer_from, fg_wh_alloc_number, fg_wh_alloc_note, fg_wh_alloc_date, id_report_status) "
                query += "VALUES ('" + id_wh_drawer_from + "', '" + header_number_sales("26") + "', '" + MENote.Text + "', NOW(), '1'); SELECT LAST_INSERT_ID(); "
                id_fg_wh_alloc = execute_query(query, 0, True, "", "", "", "")

                increase_inc_sales("26")

                action = "upd"
                actionLoad()
                FormFGWHAlloc.viewFGWHAlloc()
                FormFGWHAlloc.GVFGWHAlloc.FocusedRowHandle = find_row(FormFGWHAlloc.GVFGWHAlloc, "id_fg_wh_alloc", id_fg_wh_alloc)
                infoCustom("Document #" + TxtNumber.Text + " was created succesfully.")
                Cursor = Cursors.Default
            ElseIf action = "upd" Then
                'change tab
                XtraTabControl1.SelectedTabPageIndex = 1

                'reserved stock
                Dim cond_stc As Boolean = True
                If is_submit = "2" Then
                    Dim dt_cek As DataTable = execute_query("CALL view_stock_fg('" + id_comp_from + "', '" + id_wh_locator_from + "', '" + id_wh_rack_from + "', '" + id_wh_drawer_from + "', '0', '1','9999-12-01') ", -1, True, "", "", "", "")
                    For c As Integer = 0 To ((GVSummary.RowCount - 1) - GetGroupRowCount(GVSummary))
                        Dim qty_cek As Integer = GVSummary.GetRowCellValue(c, "fg_wh_alloc_det_qty")
                        Dim id_product_cek As String = GVSummary.GetRowCellValue(c, "id_product").ToString
                        Dim dt_filter_cek As DataRow() = dt_cek.Select("[id_product]='" + id_product_cek + "' ")
                        Dim qty_limit As Integer = 0
                        If dt_filter_cek.Length > 0 Then
                            qty_limit = dt_filter_cek(0)("qty_all_product")
                        Else
                            qty_limit = 0
                        End If
                        If qty_cek > qty_limit Then
                            GVSummary.SetRowCellValue(c, "note", "Can't exceed " + qty_limit.ToString + "")
                            cond_stc = False
                        Else
                            GVSummary.SetRowCellValue(c, "note", "OK")
                        End If
                    Next
                End If
                GCSummary.RefreshDataSource()
                GVSummary.RefreshData()

                Dim cond_gv As Boolean = True
                If GVSummary.RowCount <= 0 Then
                    cond_gv = False
                End If

                If Not cond_stc Then
                    stopCustom("Some item can't exceed qty limit, please see error in column note!")
                ElseIf Not cond_gv
                    stopCustom("Item list can't blank !")

                    'change tab
                    XtraTabControl1.SelectedTabPageIndex = 0
                Else
                    Dim confirmx As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process. Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirmx = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        'query reserved stock
                        Dim rsv As ClassFGWHAlloc = New ClassFGWHAlloc()
                        rsv.reservedStock(id_fg_wh_alloc)

                        'query main
                        Dim query As String = "UPDATE tb_fg_wh_alloc SET fg_wh_alloc_note='" + fg_wh_alloc_note + "', is_submit='1' WHERE id_fg_wh_alloc='" + id_fg_wh_alloc + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'submit mark
                        submit_who_prepared("87", id_fg_wh_alloc, id_user)

                        action = "upd"
                        actionLoad()
                        FormFGWHAlloc.viewFGWHAlloc()
                        FormFGWHAlloc.GVFGWHAlloc.FocusedRowHandle = find_row(FormFGWHAlloc.GVFGWHAlloc, "id_fg_wh_alloc", id_fg_wh_alloc)

                        'change tab
                        XtraTabControl1.SelectedTabPageIndex = 0

                        infoCustom("Document #" + TxtNumber.Text + " was edited succesfully.")
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "87"
        FormReportMark.id_report = id_fg_wh_alloc
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "87"
        FormDocumentUpload.id_report = id_fg_wh_alloc
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_cat = get_setup_field("id_comp_cat_wh")
        FormPopUpContact.id_pop_up = "66"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "20"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_KeyDown(sender As Object, e As KeyEventArgs) Handles SLESeason.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGWHAlloc.id_fg_wh_alloc = id_fg_wh_alloc
            ReportFGWHAlloc.dt = GCItemList.DataSource
            Dim Report As New ReportFGWHAlloc()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVItemList)

            'Parse val
            Report.LabelNumber.Text = TxtNumber.Text
            Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
            Report.LabelCreated.Text = DEForm.Text
            Report.LabelNote.Text = MENote.Text

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            ReportFGWHAllocRpt.id_fg_wh_alloc = id_fg_wh_alloc
            ReportFGWHAllocRpt.dt = GCSum2.DataSource
            Dim Report As New ReportFGWHAllocRpt()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVSum2.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVSum2.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVSum2)

            'Parse val
            Report.LabelNumber.Text = TxtNumber.Text
            Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
            Report.LabelCreated.Text = DEForm.Text
            Report.LabelNote.Text = MENote.Text

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGWHAlloc.id_pre = "1"
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            ReportFGWHAllocRpt.id_pre = "1"
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGWHAlloc.id_pre = "-1"
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            ReportFGWHAllocRpt.id_pre = "-1"
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrinting.ItemClick
        Cursor = Cursors.WaitCursor
        printing()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        Cursor = Cursors.WaitCursor
        prePrinting()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportExcelNew_Click(sender As Object, e As EventArgs) Handles BtnImportExcelNew.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "24"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class