﻿Imports Microsoft.Office.Interop

Public Class FormFGRepairReturnRecDet
    Public id_fg_repair_return_rec As String = "-1"
    Public id_fg_repair_return_select As String = "-1"
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_repair_return_rec_det_list As New List(Of String)
    Public id_pre As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_wh_locator_from As String = "-1"
    Public id_wh_rack_from As String = "-1"
    Public id_wh_drawer_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_wh_locator_to As String = "-1"
    Public id_wh_rack_to As String = "-1"
    Public id_wh_drawer_to As String = "-1"
    Public id_wh_drawer_dest As String = "-1"
    Public dt As New DataTable
    Dim is_delete_scan As Boolean = False
    Public id_type As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_repair As String = get_setup_field("bof_xls_repair_return_rec")
    Public id_wh_type As String = "-1"

    Dim is_use_unique_code_wh As String = get_setup_field("is_use_unique_code_all")

    'scan
    Private cforKeyDown As Char = vbNullChar
    Private _lastKeystroke As DateTime = DateTime.Now
    Public speed_barcode_read As Integer = get_setup_field("speed_barcode_read")
    Public speed_barcode_read_timer As Integer = get_setup_field("speed_barcode_read_timer")
    Public is_view As String = "-1"

    Private Sub FormFGRepairRecDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            viewRepair()
            viewDetail()
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)
            TxtCodeCompFrom.Focus()
        ElseIf action = "upd" Then
            XTPSummary.PageVisible = True
            XtraTabControl1.SelectedTabPageIndex = 1
            GVScan.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = False
            DDBPrint.Enabled = True

            'query view based on edit id's
            Dim query_c As ClassFGRepairReturnRec = New ClassFGRepairReturnRec()
            Dim query As String = query_c.queryMain("AND rec.id_fg_repair_return_rec='" + id_fg_repair_return_rec + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_repair_return_rec = data.Rows(0)("id_fg_repair_return_rec").ToString
            id_fg_repair_return_select = data.Rows(0)("id_fg_repair_return").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNumber.Text = data.Rows(0)("fg_repair_return_rec_number").ToString
            TxtNumberRepair.Text = data.Rows(0)("fg_repair_return_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_repair_return_rec_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_repair_return_rec_note").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            id_wh_drawer_dest = data.Rows(0)("id_wh_drawer_dest").ToString
            TxtCodeWH.Text = data.Rows(0)("wh_number").ToString
            TxtNameWH.Text = data.Rows(0)("wh_name").ToString
            is_use_unique_code_wh = data.Rows(0)("is_use_unique_code").ToString

            setDefaultDrawerFrom()
            setDefaultDrawerTo()

            'detail2
            viewDetail()
            viewDetailSum()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If
        End If
    End Sub

    Sub viewRepair()
        Dim query_c As ClassFGRepairReturn = New ClassFGRepairReturn()
        Dim query As String = query_c.queryMain("AND r.id_fg_repair_return='" + id_fg_repair_return_select + "' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_fg_repair_return_select = data.Rows(0)("id_fg_repair_return").ToString
        TxtNumberRepair.Text = data.Rows(0)("fg_repair_return_number").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        setDefaultDrawerFrom()
        setDefaultDrawerTo()
        codeAvailableIns()
    End Sub

    Sub codeAvailableIns()
        SplashScreenManager1.ShowWaitForm()
        dt.Clear()
        Dim query As String = "CALL view_fg_repair_return('" + id_fg_repair_return_select + "') "
        dt = execute_query(query, -1, True, "", "", "", "")
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Sub setDefaultDrawerFrom()
        'get drw def
        Dim data As DataTable = queryDefaultDrawer(id_comp_from)
        If data.Rows.Count > 0 Then
            id_wh_locator_from = data.Rows(0)("id_wh_locator").ToString
            id_wh_rack_from = data.Rows(0)("id_wh_rack").ToString
            id_wh_drawer_from = data.Rows(0)("id_wh_drawer").ToString
        Else
            stopCustom("There is no drawer default for this company")
            id_comp_from = "-1"
            id_wh_locator_from = "-1"
            id_wh_rack_from = "-1"
            id_wh_drawer_from = "-1"
        End If
    End Sub

    Sub setDefaultDrawerTo()
        'get drw def
        Dim data As DataTable = queryDefaultDrawer(id_comp_to)
        If data.Rows.Count > 0 Then
            id_wh_locator_to = data.Rows(0)("id_wh_locator").ToString
            id_wh_rack_to = data.Rows(0)("id_wh_rack").ToString
            id_wh_drawer_to = data.Rows(0)("id_wh_drawer").ToString
        Else
            stopCustom("There is no drawer default for this company")
            id_comp_to = "-1"
            id_wh_locator_to = "-1"
            id_wh_rack_to = "-1"
            id_wh_drawer_to = "-1"
        End If
    End Sub

    Function queryDefaultDrawer(ByVal id_comp As String) As DataTable
        Dim query As String = ""
        query += "SELECT wh.id_comp, wh.comp_number, loc.id_wh_locator, loc.wh_locator_code, rck.id_wh_rack, rck.wh_rack_code, drw.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer "
        query += "FROM tb_m_comp wh "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "WHERE wh.id_comp='" + id_comp + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub viewDetail()
        Dim query As String = "CALL view_fg_repair_return_rec('" + id_fg_repair_return_rec + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScan.DataSource = data
    End Sub

    Sub viewDetailSum()
        Dim query As String = "CALL view_fg_repair_return_sum('" + id_fg_repair_return_select + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScanSum.DataSource = data
        GridColumnStatus.Visible = False
        GridColumnQtyAvail.Visible = False
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "94", id_fg_repair_return_rec) Then
            MENote.Enabled = False
            BtnSave.Enabled = False
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
        End If
        BtnBrowseWH.Enabled = False
        PanelNavBarcode.Enabled = False
        TxtCodeCompFrom.Enabled = False
        TxtCodeCompTo.Enabled = False
        GridColumnQty.OptionsColumn.AllowEdit = False
        GVScan.OptionsCustomization.AllowGroup = True
        BtnSummary.Visible = False
        PanelControlSummary.Visible = False

        'ATTACH
        If check_attach_report_status(id_report_status, "94", id_fg_repair_return_rec) Then
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
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If

        If is_view = "1" Then
            BMark.Enabled = True
        Else
            BMark.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGRepairReturnRecDet.id_pre = "1"
        Else
            ReportFGRepairReturnRec.id_pre = "1"
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGRepairReturnRecDet.id_pre = "-1"
        Else
            ReportFGRepairReturnRec.id_pre = "-1"
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            GridColumnStatus.Visible = False
            ReportFGRepairReturnRecDet.id_fg_repair_return_rec = id_fg_repair_return_rec
            ReportFGRepairReturnRecDet.id_type = id_type
            ReportFGRepairReturnRecDet.dt = GCScan.DataSource
            Dim Report As New ReportFGRepairReturnRecDet()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVScan.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVScan.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVScan)

            'Parse val
            Report.LabelRepair.Text = TxtNumberRepair.Text.ToString
            Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
            Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
            Report.LRecNumber.Text = TxtNumber.Text
            Report.LRecDate.Text = DEForm.Text
            Report.LabelNote.Text = MENote.Text
            If id_type = "1" Then
                Report.XrPanel2.Visible = False
            End If

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        Else
            GridColumnStatus.Visible = False
            ReportFGRepairReturnRec.id_fg_repair_return_rec = id_fg_repair_return_rec
            ReportFGRepairReturnRec.id_type = id_type
            ReportFGRepairReturnRec.dt = GCScanSum.DataSource
            Dim Report As New ReportFGRepairReturnRec()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVScanSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVScanSum.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVScanSum)

            'Parse val
            Report.LabelRepair.Text = TxtNumberRepair.Text.ToString
            Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
            Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
            Report.LRecNumber.Text = TxtNumber.Text
            Report.LRecDate.Text = DEForm.Text
            Report.LabelNote.Text = MENote.Text
            If id_type = "1" Then
                Report.XrPanel2.Visible = False
            End If

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGRepairRecDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "94"
        FormDocumentUpload.id_report = id_fg_repair_return_rec
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "94"
        FormReportMark.id_report = id_fg_repair_return_rec
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Function checkStock() As Boolean
        Dim cond_stc As Boolean

        If action = "ins" And GVScan.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'insert to temporary
            XTPSummary.PageVisible = True
            XtraTabControl1.SelectedTabPageIndex = 1

            Dim data_temp As DataTable = GCScan.DataSource
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySql.Data.MySqlClient.MySqlConnection(connection_string)
            connection.Open()
            Dim command As MySql.Data.MySqlClient.MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_fg_repair_return_rec_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_fg_repair_return_rec_temp AS ( SELECT * FROM ("
            For d As Integer = 0 To data_temp.Rows.Count - 1
                Dim id_fg_repair_return_det As String = data_temp.Rows(d)("id_fg_repair_return_det").ToString
                Dim id_product As String = data_temp.Rows(d)("id_product").ToString
                Dim id_pl_prod_order_rec_det_unique As String = data_temp.Rows(d)("id_pl_prod_order_rec_det_unique").ToString
                Dim code As String = data_temp.Rows(d)("product_code").ToString
                Dim name As String = addSlashes(data_temp.Rows(d)("name").ToString)
                Dim size As String = data_temp.Rows(d)("size").ToString
                If d > 0 Then
                    qry += "UNION ALL "
                End If
                qry += "SELECT '" + id_fg_repair_return_det + "' AS `id_fg_repair_return_det`,'" + id_product + "' AS `id_product`, '" + id_pl_prod_order_rec_det_unique + "' AS `id_pl_prod_order_rec_det_unique`, '" + code + "' AS `code`, '" + name + "' AS `name`, '" + size + "' AS `size`  "
            Next
            qry += ") a ); ALTER TABLE tb_fg_repair_return_rec_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data_view As New DataTable
            Dim qry_view As String = "SELECT a.id_product, a.code, a.name, a.size, COUNT(a.id_product) AS `qty_scan` 
                                FROM tb_fg_repair_return_rec_temp a 
                                GROUP BY a.id_product"
            Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(qry_view, connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data_view)
            adapter.Dispose()

            'connection.Close()
            'connection.Dispose()

            'get data stock
            Dim query_stock As String = "call view_fg_repair_return_sum('" + id_fg_repair_return_select + "')"
            Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")
            Dim tb1 = data_stock.AsEnumerable()
            Dim tb2 = data_view.AsEnumerable()
            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("id_product").ToString Equals table_tmp("id_product").ToString
                        Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                        {
                            .code = table1.Field(Of String)("code").ToString,
                            .name = table1.Field(Of String)("name").ToString,
                            .size = table1.Field(Of String)("size").ToString,
                            .qty = table1("qty"),
                            .available_qty = If(y1 Is Nothing, 0, y1("qty_scan")),
                            .design_price_retail = table1("design_price_retail"),
                            .id_product = table1("id_product").ToString,
                            .design_first_rec_wh_year = table1("design_first_rec_wh_year").ToString,
                            .status = If(table1("qty") = If(y1 Is Nothing, 0, y1("qty_scan")), "OK", "Scanned qty is not equal with demand qty.")
                        }
            GCScanSum.DataSource = Nothing
            GCScanSum.DataSource = query.ToList()
            GCScanSum.RefreshDataSource()


            'find not ok
            GVScanSum.ActiveFilterString = "[status]<>'OK'"
            If GVScanSum.RowCount > 0 Then
                cond_stc = False
            Else
                cond_stc = True
            End If
            GVScanSum.ActiveFilterString = ""
            Cursor = Cursors.Default
        End If
        Return cond_stc
    End Function

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVScan)
        Dim cond_stc As Boolean = True
        cond_stc = checkStock()

        If id_wh_drawer_from = "-1" Or id_wh_drawer_to = "-1" Then
            stopCustom("Account can't blank!")
        ElseIf GVScan.RowCount <= 0 Then
            stopCustom("Data can't blank!")
        ElseIf Not cond_stc Then
            stopCustom("Scanned qty is not equal with demand qty, please see error in column status!")
        ElseIf id_wh_drawer_dest = "-1" Then
            stopCustom("Please select WH destination")
        Else
            Dim fg_repair_return_rec_note As String = addSlashes(MENote.Text.ToString)
            If action = "ins" Then 'insert
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    BtnSave.Enabled = False
                    'main query
                    Dim query As String = "INSERT INTO tb_fg_repair_return_rec(id_fg_repair_return,id_wh_drawer_from, id_wh_drawer_to, id_wh_drawer_dest, fg_repair_return_rec_number, fg_repair_return_rec_date, fg_repair_return_rec_note, id_report_status, is_use_unique_code) 
                                           VALUES('" + id_fg_repair_return_select + "','" + id_wh_drawer_from + "', '" + id_wh_drawer_to + "','" + id_wh_drawer_dest + "','" + header_number_sales("30") + "', NOW(), '" + fg_repair_return_rec_note + "', '1', '" + is_use_unique_code_wh + "'); SELECT LAST_INSERT_ID(); "
                    id_fg_repair_return_rec = execute_query(query, 0, True, "", "", "", "")
                    increase_inc_sales("30")

                    'insert who prepared
                    submit_who_prepared("94", id_fg_repair_return_rec, id_user)

                    'Detail 
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVScan.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_repair_return_rec_det(id_fg_repair_return_rec, id_fg_repair_return_det, id_product, id_pl_prod_order_rec_det_unique, fg_repair_return_rec_det_counting) VALUES "
                    End If
                    For j As Integer = 0 To ((GVScan.RowCount - 1) - GetGroupRowCount(GVScan))
                        Dim id_product = GVScan.GetRowCellValue(j, "id_product").ToString
                        Dim id_fg_repair_return_det = GVScan.GetRowCellValue(j, "id_fg_repair_return_det").ToString
                        Dim id_pl_prod_order_rec_det_unique = GVScan.GetRowCellValue(j, "id_pl_prod_order_rec_det_unique").ToString
                        If id_pl_prod_order_rec_det_unique = "0" Then
                            id_pl_prod_order_rec_det_unique = "NULL"
                        End If
                        Dim fg_repair_return_rec_det_counting As String = GVScan.GetRowCellValue(j, "fg_repair_return_rec_det_counting").ToString

                        If jum_ins_j > 0 Then
                            query_detail += ", "
                        End If
                        query_detail += "('" + id_fg_repair_return_rec + "','" + id_fg_repair_return_det + "', '" + id_product + "', " + id_pl_prod_order_rec_det_unique + ", '" + fg_repair_return_rec_det_counting + "') "
                        jum_ins_j = jum_ins_j + 1
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'reserved unique code
                    'If is_use_unique_code_wh = "1" Then
                    '    Dim quniq As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_fg_repair_return_rec_det`,`id_type`,`unique_code`,
                    '    `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
                    '    SELECT c.id_comp, t.`id_wh_drawer_from`, td.id_product, td.id_pl_prod_order_rec_det_unique, td.id_fg_repair_return_rec_det, '11', 
                    '    CONCAT(p.product_full_code,td.fg_repair_return_rec_det_counting), sod.id_design_price, sod.design_price, -1, 1, NOW() 
                    '    FROM tb_fg_repair_return_rec_det td
                    '    INNER JOIN tb_fg_repair_return_rec t ON t.id_fg_repair_return_rec = td.id_fg_repair_return_rec
                    '    INNER JOIN tb_m_wh_drawer drw_frm ON drw_frm.id_wh_drawer = t.id_wh_drawer_from  
                    '    INNER JOIN tb_m_wh_rack rack_frm ON rack_frm.id_wh_rack = drw_frm.id_wh_rack  
                    '    INNER JOIN tb_m_wh_locator loc_frm ON loc_frm.id_wh_locator = rack_frm.id_wh_locator  
                    '    INNER JOIN tb_m_comp c ON c.id_comp = loc_frm.id_comp  
                    '    INNER JOIN tb_m_product p ON p.id_product = td.id_product
                    '    INNER JOIN tb_m_design d ON d.id_design = p.id_design
                    '    LEFT JOIN( 
                    '        SELECT * FROM ( 
                    '     SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                    '     price.id_design_price_type, price_type.design_price_type,
                    '     cat.id_design_cat, cat.design_cat
                    '     FROM tb_m_design_price price 
                    '     INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type 
                    '     INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                    '     WHERE price.is_active_wh ='1' AND price.design_price_start_date <= NOW() 
                    '     ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
                    '        ) a 
                    '        GROUP BY a.id_design 
                    '    ) sod ON sod.id_design = d.id_design 
                    '    WHERE t.id_fg_repair_return_rec=" & id_fg_repair_return_rec & " AND d.is_old_design=2 AND t.is_use_unique_code=1 "
                    '    execute_non_query(quniq, True, "", "", "", "")
                    'End If


                    'refresh data
                    FormFGRepairReturnRec.viewData()
                    FormFGRepairReturnRec.viewRepairList()
                    FormFGRepairReturnRec.GVRepairRec.FocusedRowHandle = find_row(FormFGRepairReturnRec.GVRepairRec, "id_fg_repair_return_rec", id_fg_repair_return_rec)
                    action = "upd"
                    actionLoad()

                    'bof
                    exportToBOF(False)


                    infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                    Cursor = Cursors.Default
                End If
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "UPDATE tb_fg_repair_return_rec SET fg_repair_return_rec_note='" + fg_repair_return_rec_note + "' WHERE id_fg_repair_return_rec='" + id_fg_repair_return_rec + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'refresh data
                    FormFGRepairReturnRec.viewData()
                    FormFGRepairReturnRec.viewRepairList()
                    FormFGRepairReturnRec.GVRepairRec.FocusedRowHandle = find_row(FormFGRepairRec.GVRepairRec, "id_fg_repair_return_rec", id_fg_repair_return_rec)
                    action = "upd"
                    actionLoad()
                    infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        disableControl()
        is_delete_scan = False
        TxtScannedCode.Visible = True
        LblScannedCode.Visible = True
        TxtScannedCode.Focus()
    End Sub

    Sub disableControl()
        GVScan.OptionsCustomization.AllowSort = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        GroupGeneralHeader.Enabled = False
        GroupControl3.Enabled = False
        PanelControl3.Enabled = False
        XTPSummary.PageVisible = False
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        TxtScannedCode.Text = ""
        GVScan.OptionsCustomization.AllowSort = True
        TxtScannedCode.Visible = False
        LblScannedCode.Visible = False
        BStop.Enabled = False
        BScan.Enabled = True
        BDelete.Enabled = True
        GroupGeneralHeader.Enabled = True
        GroupControl3.Enabled = True
        PanelControl3.Enabled = True
        BScan.Focus()
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        disableControl()
        is_delete_scan = True
        TxtScannedCode.Visible = True
        LblScannedCode.Visible = True
        TxtScannedCode.Focus()
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        cforKeyDown = ChrW(e.KeyCode)
    End Sub

    Private Sub checkAvailable(ByVal code_par As String)
        GVScan.ActiveFilterString = ""
        Dim dt_filter As DataRow() = dt.Select("[code]='" + code_par + "' ")
        If dt_filter.Length > 0 Then
            If dt_filter(0)("is_old_design").ToString = "2" Then
                GVScan.ActiveFilterString = "[code]='" + code_par + "'"
                If GVScan.RowCount > 0 Then
                    GVScan.ActiveFilterString = ""
                    stopCustomDialog("Duplicate code")
                    Exit Sub
                Else
                    GVScan.ActiveFilterString = ""
                End If
            End If

            'jika akun normal/sale
            Dim id_design_cat As String = dt_filter(0)("id_design_cat").ToString
            Dim prc As Decimal = dt_filter(0)("design_price")
            If id_wh_type = "1" Or id_wh_type = "2" Then
                If (id_wh_type <> id_design_cat) And prc > 0 Then
                    If id_wh_type = "1" Then
                        stopCustomDialog(TxtCodeWH.Text + " is only for normal product. ")
                    Else
                        stopCustomDialog(TxtCodeWH.Text + " is only for sale product. ")
                    End If
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            Dim newRow As DataRow = (TryCast(GCScan.DataSource, DataTable)).NewRow()
            newRow("id_fg_repair_return_rec_det") = "0"
            newRow("id_fg_repair_return_det") = dt_filter(0)("id_fg_repair_return_det").ToString
            newRow("id_fg_repair_return_rec") = 0
            newRow("id_product") = dt_filter(0)("id_product").ToString
            newRow("code") = dt_filter(0)("code").ToString
            newRow("product_code") = dt_filter(0)("product_code").ToString
            newRow("name") = dt_filter(0)("name").ToString
            newRow("size") = dt_filter(0)("size").ToString
            newRow("id_pl_prod_order_rec_det_unique") = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
            newRow("fg_repair_return_rec_det_counting") = dt_filter(0)("fg_repair_return_det_counting").ToString
            TryCast(GCScan.DataSource, DataTable).Rows.Add(newRow)
            GCScan.RefreshDataSource()
            GVScan.RefreshData()
            GVScan.FocusedRowHandle = GVScan.RowCount - 1
        Else
            stopCustomDialog("Code not found!")
        End If
    End Sub

    Private Sub GVScan_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScan.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.Name = "GridColumnNoSum" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'kolom ori - creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVScanSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)


            'hide column
            For c As Integer = 0 To GVScanSum.Columns.Count - 1
                GVScanSum.Columns(c).Visible = False
            Next
            GridColumnCodeSum.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            'GVItemList.OptionsPrint.PrintFooter = False
            'GVItemList.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\bof_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls_repair + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVScanSum, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GVScanSum.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        'If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        'End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To 4
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtNumber.Text.ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtCodeCompFrom.Text.ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtCodeCompTo.Text.ToString
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Private Sub BtnBrowseWH_Click(sender As Object, e As EventArgs) Handles BtnBrowseWH.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "87"
        FormPopUpContact.is_must_active = "1"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGRepairReturnRecDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            FormMenuAuth.type = "10"
            FormMenuAuth.ShowDialog()
        End If
    End Sub

    Private Sub BtnSummary_Click(sender As Object, e As EventArgs) Handles BtnSummary.Click
        Dim cond_stc As Boolean = checkStock()
        If Not cond_stc Then
            stopCustom("Some item can't exceed qty limit, please see error in column status!")
        End If
    End Sub

    Private Sub BtnBackToScan_Click(sender As Object, e As EventArgs) Handles BtnBackToScan.Click
        If action = "ins" Then
            XtraTabControl1.SelectedTabPageIndex = 0
        End If
    End Sub

    Private Sub BtnPrintPrev_Click(sender As Object, e As EventArgs) Handles BtnPrintPrev.Click
        If action = "ins" Then
            print(GCScanSum, "Preview Scan")
        End If
    End Sub

    Private Sub TxtScannedCode_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyUp
        If Len(TxtScannedCode.EditValue.ToString) > 1 Then
            If cforKeyDown <> ChrW(e.KeyCode) OrElse cforKeyDown = vbNullChar Then
                cforKeyDown = vbNullChar
                TxtScannedCode.EditValue = ""
                Return
            End If

            Dim elapsed As TimeSpan = DateTime.Now - _lastKeystroke

            If elapsed.TotalMilliseconds > speed_barcode_read Then TxtScannedCode.EditValue = ""

            If e.KeyCode = Keys.Enter And TxtScannedCode.Text.Length > 0 Then
                Cursor = Cursors.WaitCursor
                If Not is_delete_scan Then 'scan
                    makeSafeGV(GVScan)
                    checkAvailable(TxtScannedCode.Text)
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else 'delete scan
                    GVScan.ActiveFilterString = "[code]='" + TxtScannedCode.Text + "'"
                    If GVScan.RowCount <= 0 Then
                        stopCustomDialog("Code not found.")
                        GVScan.ActiveFilterString = ""
                        TxtScannedCode.Text = ""
                        TxtScannedCode.Focus()
                    Else
                        If action = "ins" Then
                            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                            If confirm = Windows.Forms.DialogResult.Yes Then
                                Dim id_pl_prod_order_rec_det_unique As String = GVScan.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                                GVScan.DeleteRow(GVScan.FocusedRowHandle)
                                GVScan.ActiveFilterString = ""
                                GCScan.RefreshDataSource()
                                GVScan.RefreshData()
                            Else
                                GVScan.ActiveFilterString = ""
                            End If
                            TxtScannedCode.Text = ""
                            TxtScannedCode.Focus()
                        End If
                    End If
                End If
                Cursor = Cursors.Default
            End If
        End If

        _lastKeystroke = DateTime.Now
    End Sub
End Class