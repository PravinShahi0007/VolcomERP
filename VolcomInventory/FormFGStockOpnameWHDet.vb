Public Class FormFGStockOpnameWHDet 
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_so_wh As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_from As String = "-1"
    '
    Public dt As New DataTable
    Public dt_rec As New DataTable
    Public dt_avail As New DataTable
    '
    Public id_fg_so_wh_det_list As New List(Of String)
    Public id_fg_so_wh_det_counting_list As New List(Of String)
    Dim id_comp_cat_wh As String = "-1"
    Public id_pl_category As String = "-1"
    Public pl_category As String = "-1"
    Dim id_lock As String = "-1"
    Dim is_scan As Boolean = False
    ' update 15 september 2015
    Public id_drawer As String = "-1"

    Private Sub FormFGStockOpnameWHDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        'call action
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGStockOpnameWHDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub setDefaultDrawer()
        'get drw def
        Dim id_wh_par As String = get_company_contact_x(id_comp_contact_from, "3")
        Dim query As String = ""
        query += "SELECT wh.id_comp, wh.comp_number, loc.id_wh_locator, loc.wh_locator_code, rck.id_wh_rack, rck.wh_rack_code, drw.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer "
        query += "FROM tb_m_comp wh "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "WHERE wh.id_comp='" + id_wh_par + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TEDrawerCode.Text = data.Rows(0)("wh_drawer_code").ToString
            TEDrawerName.Text = data.Rows(0)("wh_drawer").ToString
            id_drawer = data.Rows(0)("id_wh_drawer").ToString
        End If
    End Sub

    Sub initialize_dt(ByVal dtx As DataTable)
        dtx.Columns.Add("id_product")
        dtx.Columns.Add("id_pl_prod_order_rec_det_unique")
        dtx.Columns.Add("product_code")
        dtx.Columns.Add("product_counting_code")
        dtx.Columns.Add("product_full_code")
        dtx.Columns.Add("bom_unit_price")
        dtx.Columns.Add("id_design_price")
        dtx.Columns.Add("design_price")
        dtx.Columns.Add("is_rec")
        dtx.Columns.Add("is_old_design")
    End Sub
    Sub actionLoad()
        Try
            'initialisation datatable jika blm ada
            initialize_dt(dt)
            initialize_dt(dt_avail)
            initialize_dt(dt_rec)
            '
        Catch ex As Exception
        End Try

        If action = "ins" Then
            TxtSONumber.Text = header_number_sales("12")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnLock.Enabled = False
            BDrawer.Enabled = True

            DEForm.Text = view_date(0)
            check_but()
        ElseIf action = "upd" Then
            GroupControlItem.Enabled = True
            BtnBrowseCompFrom.Enabled = False
            BDrawer.Enabled = False

            'query view based on edit id's
            Dim query As String = ""
            query += "SELECT so.id_wh_drawer,drawer.wh_drawer,drawer.wh_drawer_code,so.fg_so_wh_note, so.id_lock, so.id_fg_so_wh, so.fg_so_wh_number, so.id_report_status,stat.report_status, "
            query += "DATE_FORMAT(so.fg_so_wh_date_created, '%Y-%m-%d') AS fg_so_wh_date_created, "
            query += "DATE_FORMAT(so.fg_so_wh_last_update, '%Y-%m-%d') AS fg_so_wh_last_update, "
            query += "(comp_contact.id_comp_contact) AS id_comp_contact_from, (comp.id_comp) AS id_comp_from, "
            query += "(comp.comp_number) AS comp_number_from, (comp.comp_name) AS comp_name_from "
            query += "FROM tb_fg_so_wh so "
            'query += "INNER JOIN tb_fg_so_wh_det so_det ON so.id_fg_so_wh = so_det.id_fg_so_wh "
            query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_comp_contact_from "
            query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
            query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
            query += "LEFT JOIN tb_m_wh_drawer drawer ON drawer.id_wh_drawer=so.id_wh_drawer "
            query += "WHERE so.id_fg_so_wh = '" + id_fg_so_wh + "' "
            query += "ORDER BY so.id_fg_so_wh DESC "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            'update 15 September 2015
            id_drawer = data.Rows(0)("id_wh_drawer").ToString
            TEDrawerCode.Text = data.Rows(0)("wh_drawer_code").ToString
            TEDrawerName.Text = data.Rows(0)("wh_drawer").ToString

            id_report_status = data.Rows(0)("id_report_status").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtSONumber.Text = data.Rows(0)("fg_so_wh_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_so_wh_date_created").ToString, 0)
            TxtLastUpdate.Text = view_date_from(data.Rows(0)("fg_so_wh_last_update").ToString, 0)
            MENote.Text = data.Rows(0)("fg_so_wh_note").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            id_lock = data.Rows(0)("id_lock").ToString

            ''detail2
            viewDetail()
            view_barcode_list()
            check_but()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'action
            Dim query As String = "SELECT ('0') AS code, ('') AS name, ('') AS size, ('') AS color, CAST('0' AS DECIMAL(13,2)) AS qty, CAST('0' AS DECIMAL(13,2)) AS bom_unit_price,'0' as id_design_price,CAST('0' AS DECIMAL(13,2)) AS design_price, CAST('0' AS DECIMAL(13,2)) AS amount, ('') AS note, ('0') AS id_product, ('0') AS id_design,('0') AS id_sample , ('0') AS id_det "
            Dim datax As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = datax
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
        ElseIf action = "upd" Then
            Dim id_param As String = ""
            Dim query As String = "CALL view_fg_so_wh('" + id_fg_so_wh + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_so_wh_det_list.Add(data.Rows(i)("id_det").ToString)
                id_param = id_param + data.Rows(i)("id_product").ToString
                If i < (data.Rows.Count - 1) Then
                    id_param = id_param + ";"
                End If
            Next
            GCItemList.DataSource = data
            Me.codeAvailableIns(id_param)
            'codeAvailableIns("0", id_store_from, "0")
        End If
    End Sub


    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_fg_so_wh_det, ('0') AS id_pl_prod_order_rec_det_unique, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_fg_so_wh_det_counting, CAST('0' AS DECIMAL(13,2)) AS bom_unit_price, ('0') AS id_pl_category, ('') AS pl_category , ('') AS is_rec "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_so_wh_det_counting) AS code, (c.product_full_code) AS product_code, "
            query += "(a.fg_so_wh_det_counting) AS counting_code, "
            query += "a.id_fg_so_wh_det_counting, ('2') AS is_fix, "
            query += "a.id_pl_prod_order_rec_det_unique, b.id_product, "
            query += "d.bom_unit_price, "
            query += "a.id_pl_category, e.pl_category,a.is_rec "
            query += "FROM tb_fg_so_wh_det_counting a "
            query += "INNER JOIN tb_fg_so_wh_det b ON a.id_fg_so_wh_det = b.id_fg_so_wh_det "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
            query += "LEFT JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = a.id_pl_prod_order_rec_det_unique "
            query += "INNER JOIN tb_lookup_pl_category e ON e.id_pl_category = a.id_pl_category "
            query += "WHERE b.id_fg_so_wh = '" + id_fg_so_wh + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_so_wh_det_counting_list.Add(data.Rows(i)("id_fg_so_wh_det_counting").ToString)
                'insertDt(data.Rows(i)("id_product").ToString, data.Rows(i)("id_pl_prod_order_rec_det_unique").ToString, data.Rows(i)("product_code").ToString, data.Rows(i)("counting_code").ToString, data.Rows(i)("code").ToString, Decimal.Parse(data.Rows(i)("bom_unit_price").ToString))
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    '-------------------------------------------------------------------------------------
    'SAAT INI PARAMETER HANYA ID PROD KARENA PRODUCTION HANYA ADA 1 COST (19 Sept 2014)
    '-----------------------------------------------------------------------------------
    Sub codeAvailableIns(ByVal id_product_param As String)
        dt_rec.Clear()
        dt.Clear()
        Dim query As String = ""
        query = "CALL view_stock_fg_unique_del('" + id_product_param + "')"
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        For k As Integer = 0 To (datax.Rows.Count - 1)
            insertDt(dt, datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_pl_prod_order_rec_det_unique").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, datax.Rows(k)("bom_unit_price"), datax.Rows(k)("is_rec").ToString, datax.Rows(k)("is_old_design").ToString)
        Next

        ' Kode unique dari receiving
        Dim query_rec As String = ""
        query_rec = "CALL view_stock_fg_unique_rec('" + id_product_param + "')"
        Dim data_rec As DataTable = execute_query(query_rec, -1, True, "", "", "", "")
        For k As Integer = 0 To (data_rec.Rows.Count - 1)
            insertDt(dt_rec, data_rec.Rows(k)("id_product").ToString, data_rec.Rows(k)("id_pl_prod_order_rec_det_unique").ToString, data_rec.Rows(k)("product_code").ToString, data_rec.Rows(k)("product_counting_code").ToString, data_rec.Rows(k)("product_full_code").ToString, data_rec.Rows(k)("bom_unit_price"), data_rec.Rows(k)("is_rec").ToString, data_rec.Rows(k)("is_old_design").ToString)
        Next

        'find except then merge
        If dt.Rows.Count > 0 And dt_rec.Rows.Count > 0 Then
            Dim t1 = dt_rec.AsEnumerable()
            Dim t2 = dt.AsEnumerable()
            Dim except As DataTable = (From _t1 In t1
                                       Group Join _t2 In t2
                        On _t1("id_pl_prod_order_rec_det_unique") Equals _t2("id_pl_prod_order_rec_det_unique") Into Group
                                       From _t3 In Group.DefaultIfEmpty()
                                       Where _t3 Is Nothing
                                       Select _t1).CopyToDataTable
            dt.Merge(except)
        End If

        'not unique 
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query_not As String = query_c.queryOldDesignCode(id_product_param)
        Dim data_not As DataTable = execute_query(query_not, -1, True, "", "", "", "")

        'merge
        If data_not.Rows.Count > 0 Then
            If dt.Rows.Count = 0 Then
                dt = data_not
            Else
                dt.Merge(data_not, True, MissingSchemaAction.Ignore)
            End If
        End If
    End Sub

    Sub insertDt(ByVal dtx As DataTable, ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal, ByVal is_rec_param As String, ByVal is_old_design_param As String)
        Dim R As DataRow = dtx.NewRow
        R("id_product") = id_product_param
        R("id_pl_prod_order_rec_det_unique") = id_pl_prod_order_rec_det_unique_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        R("is_rec") = is_rec_param
        R("is_old_design") = is_old_design_param
        dtx.Rows.Add(R)
    End Sub

    Sub codeAvailableDel(ByVal id_product_param As String)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("id_product").ToString = id_product_param Then
                dt.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub allow_status()
        'BMark.Enabled = True
        If id_lock = "1" Then
            GVItemList.OptionsBehavior.Editable = True
            'PanelControlNav.Enabled = True
            PanelControlNavDetail.Enabled = True
            PanelNavBarcode.Enabled = True
            PanelNavBarcode.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            TxtSONumber.Properties.ReadOnly = True
            'BtnInfoSrs.Enabled = True
            BMark.Enabled = False
            BtnLock.Enabled = True
        Else
            GVItemList.OptionsBehavior.Editable = False
            'PanelControlNav.Enabled = False
            PanelControlNavDetail.Enabled = False
            PanelNavBarcode.Enabled = False
            PanelNavBarcode.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            TxtSONumber.Properties.ReadOnly = True
            'BtnInfoSrs.Enabled = False
            BMark.Enabled = True
            BtnLock.Enabled = False
        End If

        'Print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        TxtSONumber.Focus()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_pl_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_pl_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Sub countQty(ByVal id_product_param As String)
        GVBarcode.ActiveFilterString = "[id_product]='" + id_product_param + "' "
        Dim tot As Integer = GVBarcode.RowCount
        GVBarcode.ActiveFilterString = ""

        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        Dim cost As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("bom_unit_price").ToString)
        Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
        GVItemList.SetFocusedRowCellValue("amount", tot * price)
        GVItemList.SetFocusedRowCellValue("qty", tot)

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_so_wh
        FormReportMark.report_mark_type = "56"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        If GVItemList.RowCount < 1 Then
            errorCustom("Please add product required !")
        Else
            FormFGStockOpnameStoreSingle.id_pop_up = "1"
            FormFGStockOpnameStoreSingle.ShowDialog()
            'startScan()
        End If

    End Sub

    Sub startScan()
        If GVItemList.RowCount > 0 Then
            is_scan = True
            viewImagesBarcode(PictureEdit1, get_setup_field("pic_path_sample") & "\", False)
            BView.Enabled = False
            MENote.Enabled = False
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BDelete.Enabled = False
            BtnCancel.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            ControlBox = False
            BRefresh.Enabled = False
            If action = "upd" Then
                BtnLock.Enabled = False
            End If
            TxtSONumber.Enabled = False
            newRowsBc()
            'allowDelete()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        is_scan = False
        BView.Enabled = True
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        BRefresh.Enabled = True
        If action = "upd" Then
            BtnLock.Enabled = True
        End If
        TxtSONumber.Enabled = True
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next
        GVItemList.FocusedRowHandle = 0
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim id_fg_so_wh_det_counting As String = "-1"

        Try
            id_fg_so_wh_det_counting = GVBarcode.GetFocusedRowCellValue("id_fg_so_wh_det_counting").ToString
        Catch ex As Exception
        End Try

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
            'MsgBox(GVBarcode.RowCount.ToString)
            Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

            deleteRowsBc()
            If id_product <> "" Or id_product <> Nothing Then
                'MsgBox(id_product)
                GVBarcode.ApplyFindFilter("")
                countQty(id_product)
            End If

            allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        'Dim id_pl_sales_order_del_det As String = ""
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_product As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim id_design_price As String = ""
        Dim design_price As Decimal = 0.0
        Dim is_rec As String = "0"
        Dim is_old As String = "0"

        'check available code
        Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_check + "' ")
        If dt_filter.Length > 0 Then
            counting_code = dt_filter(0)("product_counting_code").ToString
            id_pl_prod_order_rec_det_unique = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
            id_product = dt_filter(0)("id_product").ToString
            bom_unit_price = Decimal.Parse(dt_filter(0)("bom_unit_price").ToString)
            is_rec = dt_filter(0)("is_rec").ToString
            is_old = dt_filter(0)("is_old_design").ToString
            code_found = True
        End If

        If is_old = "1" Then 'no unique
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_fg_so_wh_det_counting", "0")
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_category", id_pl_category)
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "pl_category", pl_category)
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_rec", is_rec)
            countQty(id_product)
            newRowsBc()
        ElseIf is_old = "2" Then 'unique code
            'check duplicate code
            GVBarcode.ActiveFilterString = "[code]='" + code_check + "' AND [is_fix]='2' "
            If GVBarcode.RowCount > 0 Then
                code_duplicate = True
            End If
            GVBarcode.ActiveFilterString = ""

            If Not code_found Then
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustom("Data not found!")
            ElseIf code_duplicate Then
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustom("Data duplicate !")
            Else
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_fg_so_wh_det_counting", "0")
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_category", id_pl_category)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "pl_category", pl_category)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_rec", is_rec)
                countQty(id_product)
                newRowsBc()
            End If
        Else 'not found
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
            GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
            stopCustom("Data not found !")
        End If
        Cursor = Cursors.Default
    End Sub

    Sub deleteDetailBC(ByVal id_product_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_product As String = ""
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Private Sub BtnBrowseStoreFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseCompFrom.Click
        'FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.id_pop_up = "47"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim id_productx As String = "0"
        Dim id_samplex As String = "0"
        Dim id_designx As String = "0"
        Dim id_design_pricex As String = "0"
        Dim price As Decimal = 0.0
        Try
            id_designx = GVItemList.GetFocusedRowCellValue("id_design").ToString
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            price = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
        Catch ex As Exception
        End Try
        If Not is_scan Then
            pre_viewImages("2", PictureEdit1, id_designx, False)
        End If
        check_but()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Dim id_designx As String = "0"
        Try
            id_designx = GVItemList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try
        pre_viewImages("2", PictureEdit1, id_designx, True)
    End Sub

    Private Sub FormFGStockOpnameWHDet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'MsgBox("Tutup")
        'GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        GVBarcode.ShowEditor()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()

        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            errorCustom("Scanned item can't blank")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim fg_so_wh_number As String = TxtSONumber.Text
                Dim fg_so_wh_note As String = MENote.Text

                If action = "ins" Then
                    'query main table
                    Dim query_main As String = ""
                    query_main = "INSERT INTO tb_fg_so_wh(id_comp_contact_from, fg_so_wh_number, fg_so_wh_date_created, fg_so_wh_last_update, fg_so_wh_note, id_report_status,id_wh_drawer) "
                    query_main += "VALUES ('" + id_comp_contact_from + "', '" + fg_so_wh_number + "', NOW(), NOW(), '" + fg_so_wh_note + "', '1','" + id_drawer + "'); SELECT LAST_INSERT_ID(); "
                    id_fg_so_wh = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc_sales("12")

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_so_wh_det(id_fg_so_wh, id_product, bom_unit_price, id_design_price, design_price, fg_so_wh_det_qty, fg_so_wh_det_note) VALUES "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim bom_unit_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "bom_unit_price").ToString)
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim id_design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "id_design_price").ToString)
                            Dim fg_so_wh_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "qty").ToString)
                            Dim fg_so_wh_det_note As String = GVItemList.GetRowCellValue(j, "note").ToString

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_fg_so_wh + "', '" + id_product + "', '" + bom_unit_price + "','" + id_design_price + "','" + design_price + "', '" + fg_so_wh_det_qty + "', '" + fg_so_wh_det_note + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                            'MsgBox(ex.ToString)
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_fg_so_wh_det, a.id_product, a.bom_unit_price "
                    query_get_detail_id += "FROM tb_fg_so_wh_det a "
                    query_get_detail_id += "WHERE a.id_fg_so_wh = '" + id_fg_so_wh + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_fg_so_wh_det_counting(id_fg_so_wh_det, id_pl_prod_order_rec_det_unique, fg_so_wh_det_counting, id_pl_category, is_rec) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product").ToString
                        Dim bom_unit_price_counting As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(p, "bom_unit_price").ToString)
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        Dim fg_so_wh_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        Dim id_pl_category_counting As String = GVBarcode.GetRowCellValue(p, "id_pl_category").ToString
                        Dim is_rec As String = GVBarcode.GetRowCellValue(p, "is_rec").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                'And bom_unit_price_counting = Decimal.Parse(data_get_detail_id.Rows(p1)("bom_unit_price").ToString) Then
                                If jum_ins_p > 0 Then
                                    query_counting += ", "
                                End If
                                query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_so_wh_det").ToString + "', '" + id_pl_prod_order_rec_det_unique + "', '" + fg_so_wh_det_counting + "', '" + id_pl_category_counting + "','" + is_rec + "') "
                                jum_ins_p = jum_ins_p + 1
                                Exit For
                            End If
                        Next
                    Next

                    If jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    FormFGStockOpnameWH.viewSOWH()
                    FormFGStockOpnameWH.GVSOWH.FocusedRowHandle = find_row(FormFGStockOpnameWH.GVSOWH, "id_fg_so_wh", id_fg_so_wh)
                    Close()
                ElseIf action = "upd" Then
                    'update main table
                    Dim query_main As String = "UPDATE tb_fg_so_wh SET id_comp_contact_from = '" + id_comp_contact_from + "', fg_so_wh_number= '" + fg_so_wh_number + "', fg_so_wh_note = '" + fg_so_wh_note + "', fg_so_wh_last_update = NOW(),id_wh_drawer='" + id_drawer + "' WHERE id_fg_so_wh = '" + id_fg_so_wh + "' "
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_so_wh_det(id_fg_so_wh, id_product, bom_unit_price,id_design_price, design_price, fg_so_wh_det_qty, fg_so_wh_det_note) VALUES "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_fg_so_wh_det As String = GVItemList.GetRowCellValue(j, "id_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim bom_unit_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "bom_unit_price").ToString)
                            Dim id_design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "id_design_price").ToString)
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim fg_so_wh_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "qty").ToString)
                            Dim fg_so_wh_det_note As String = GVItemList.GetRowCellValue(j, "note").ToString

                            If id_fg_so_wh_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_fg_so_wh + "', '" + id_product + "', '" + bom_unit_price + "','" + id_design_price + "','" + design_price + "', '" + fg_so_wh_det_qty + "', '" + fg_so_wh_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_detail_upd As String = "UPDATE tb_fg_so_wh_det SET id_product = '" + id_product + "',  bom_unit_price='" + bom_unit_price + "',id_design_price='" + id_design_price + "',design_price='" + design_price + "', fg_so_wh_det_qty = '" + fg_so_wh_det_qty + "', fg_so_wh_det_note = '" + fg_so_wh_det_note + "' WHERE id_fg_so_wh_det = '" + id_fg_so_wh_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_fg_so_wh_det_list.Remove(id_fg_so_wh_det)
                            End If
                        Catch ex As Exception
                            'MsgBox(ex.ToString)
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    For j_del As Integer = 0 To (id_fg_so_wh_det_list.Count - 1)
                        Try
                            Dim query_detail_del As String = "DELETE FROM tb_fg_so_wh_det WHERE id_fg_so_wh_det = '" + id_fg_so_wh_det_list(j_del) + "'"
                            execute_non_query(query_detail_del, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_fg_so_wh_det, a.id_product, a.bom_unit_price "
                    query_get_detail_id += "FROM tb_fg_so_wh_det a "
                    query_get_detail_id += "WHERE a.id_fg_so_wh = '" + id_fg_so_wh + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'update counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_fg_so_wh_det_counting(id_fg_so_wh_det, id_pl_prod_order_rec_det_unique, fg_so_wh_det_counting, id_pl_category, is_rec) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_fg_so_wh_det_counting As String = GVBarcode.GetRowCellValue(p, "id_fg_so_wh_det_counting").ToString
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product").ToString
                        Dim bom_unit_price_counting As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(p, "bom_unit_price").ToString)
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        Dim fg_so_wh_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        Dim id_pl_category_counting As String = GVBarcode.GetRowCellValue(p, "id_pl_category").ToString
                        Dim is_rec As String = GVBarcode.GetRowCellValue(p, "is_rec").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_fg_so_wh_det_counting = "0" Then
                                If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                    If jum_ins_p > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_so_wh_det").ToString + "', '" + id_pl_prod_order_rec_det_unique + "', '" + fg_so_wh_det_counting + "', '" + id_pl_category_counting + "','" + is_rec + "') "
                                    jum_ins_p = jum_ins_p + 1
                                    Exit For
                                End If
                            Else
                                'Dim query_upd_counting As String = "UPDATE tb_fg_so_wh_det_counting SET id_pl_prod_order_rec_det_unique = '" + id_pl_prod_order_rec_det_unique + "', fg_so_wh_det_counting = '" + fg_so_wh_det_counting + "' WHERE id_fg_so_wh_det_counting = '" + id_fg_so_wh_det_counting + "'"
                                'execute_non_query(query_upd_counting, True, "", "", "", "")
                                id_fg_so_wh_det_counting_list.Remove(id_fg_so_wh_det_counting)
                            End If
                        Next
                    Next
                    If jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    For p_del As Integer = 0 To (id_fg_so_wh_det_counting_list.Count - 1)
                        Try
                            Dim query_counting_del As String = "DELETE FROM tb_fg_so_wh_det_counting WHERE id_fg_so_wh_det_counting = '" + id_fg_so_wh_det_counting_list(p_del) + "'"
                            execute_non_query(query_counting_del, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next

                    FormFGStockOpnameWH.viewSOWH()
                    FormFGStockOpnameWH.GVSOWH.FocusedRowHandle = find_row(FormFGStockOpnameWH.GVSOWH, "id_fg_so_wh", id_fg_so_wh)
                    Close()
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtNameStoreFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Private Sub TEDrawer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDrawerName.Validating
        EP_TE_cant_blank(EPForm, TEDrawerName)
        EPForm.SetIconPadding(TEDrawerName, 30)
    End Sub

    Private Sub BtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLock.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("User can't edit this data after locking process, are you sure to continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor

            'get product
            Dim query_product As String = "("
            Dim query_product2 As String = "("
            For i As Integer = 0 To GVItemList.RowCount - 1
                Try
                    Dim id_productx As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                    query_product = query_product + "j.id_product LIKE ''" + id_productx + "'' "
                    query_product2 = query_product2 + "a.id_product LIKE ''" + id_productx + "'' "
                    If i < (GVItemList.RowCount - 1) Then
                        query_product = query_product + "OR "
                        query_product2 = query_product2 + "OR "
                    End If
                Catch ex As Exception
                End Try
            Next
            query_product = query_product + ")"
            query_product2 = query_product2 + ")"

            Try
                Dim query As String = "CALL generate_sum_fg_so_wh('" + id_fg_so_wh + "', '" + id_drawer + "', '" + id_comp_from + "', '" + query_product + "', '" + query_product2 + "')"
                execute_non_query(query, True, "", "", "", "")

                'insert who prepared
                insert_who_prepared("56", id_fg_so_wh, id_user)

                FormFGStockOpnameWH.viewSOWH()
                Close()
            Catch ex As Exception
                errorConnection()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        'MsgBox("test")
        Cursor = Cursors.WaitCursor

        ReportFGStockOpnameWH.dt = GCItemList.DataSource
        ReportFGStockOpnameWH.id_fg_so_wh = id_fg_so_wh
        Dim Report As New ReportFGStockOpnameWH()

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

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        'ReportFGStockOpnameWH.id_fg_so_wh = id_fg_so_wh
        'Dim Report As New ReportFGStockOpnameWH()
        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGStockOpnameWHSingle.id_wh = 0 'id_comp_from (all product)
        FormFGStockOpnameWHSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim id_product As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            codeAvailableDel(id_product)
            deleteDetailBC(id_product)
            check_but()
            Cursor = Cursors.Default
        End If
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_productx <> "0" Then
            BtnDel.Enabled = True
        Else
            BtnDel.Enabled = False
        End If
    End Sub

    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub BDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDrawer.Click
        If id_comp_from = "-1" Then
            stopCustom("Please choose warehouse first.")
        Else
            FormPopUpDrawer.id_pop_up = 5
            FormPopUpDrawer.id_comp = id_comp_from
            FormPopUpDrawer.ShowDialog()
        End If
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_store_detail()
        End If
    End Sub

    Sub load_store_detail()
        'get default store category for pick company
        Dim id_comp_cat_store As String = "-1"
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        Dim query As String = "select cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_so_type "
        query += " From tb_m_comp_contact cc "
        query += " inner join tb_m_comp c On c.id_comp=cc.id_comp"
        query += " where cc.is_default=1 and (c.id_comp_cat = '5' OR c.id_comp_cat = '6') AND c.comp_number='" + TxtCodeCompFrom.Text + "'"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        If data.Rows.Count <= 0 Then
            stopCustom("Store not found.")
            TxtCodeCompFrom.Focus()
        ElseIf data.Rows.Count > 1 Then
            FormPopUpContact.id_pop_up = "47"
            FormPopUpContact.id_cat = id_comp_cat_store
            FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + TxtCodeCompFrom.Text + "'"
            FormPopUpContact.ShowDialog()
        Else
            id_comp_contact_from = data.Rows(0)("id_comp_contact").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
            id_comp_from = data.Rows(0)("id_comp").ToString
            GroupControlItem.Enabled = True
            viewDetail()
            view_barcode_list()
            dt.Clear()
            setDefaultDrawer()
        End If
    End Sub
End Class