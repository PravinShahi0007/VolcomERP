Public Class FormFGStockOpnameStoreDet 
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_so_store As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_store_from As String = "-1"
    Public dt As New DataTable
    Public id_fg_so_store_det_list As New List(Of String)
    Public id_fg_so_store_det_counting_list As New List(Of String)
    Dim id_comp_cat_store As String = "-1"
    Public id_pl_category As String = "-1"
    Public pl_category As String = "-1"
    Dim id_lock As String = "-1"

    Private Sub FormFGStockOpnameStoreDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        'call action
        actionLoad()
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGStockOpnameStoreDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_pl_prod_order_rec_det_unique")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("bom_unit_price")
            dt.Columns.Add("id_design_price")
            dt.Columns.Add("design_price")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            TxtSONumber.Text = header_number_sales("9")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnLock.Enabled = False
            DEForm.Text = view_date(0)
        ElseIf action = "upd" Then
            GroupControlItem.Enabled = True
            BtnBrowseStoreFrom.Enabled = False

            'query view based on edit id's
            Dim query As String = ""
            query += "SELECT so.fg_so_store_note, so.id_lock, so.id_fg_so_store, so.fg_so_store_number, so.id_report_status,stat.report_status, "
            query += "DATE_FORMAT(so.fg_so_store_date_created, '%Y-%m-%d') AS fg_so_store_date_created, "
            query += "DATE_FORMAT(so.fg_so_store_last_update, '%Y-%m-%d') AS fg_so_store_last_update, "
            query += "(comp_contact.id_comp_contact) AS id_store_contact_from, (comp.id_comp) AS id_store_from, "
            query += "(comp.comp_number) AS store_number_from, (comp.comp_name) AS store_name_from "
            query += "FROM tb_fg_so_store so "
            'query += "INNER JOIN tb_fg_so_store_det so_det ON so.id_fg_so_store = so_det.id_fg_so_store "
            query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_store_contact_from "
            query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
            query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
            query += "WHERE so.id_fg_so_store = '" + id_fg_so_store + "' "
            query += "ORDER BY so.id_fg_so_store DESC "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
            TxtSONumber.Text = data.Rows(0)("fg_so_store_number").ToString
            TxtNameStoreFrom.Text = data.Rows(0)("store_name_from").ToString
            TxtCodeStoreFrom.Text = data.Rows(0)("store_number_from").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_so_store_date_created").ToString, 0)
            TxtLastUpdate.Text = view_date_from(data.Rows(0)("fg_so_store_last_update").ToString, 0)
            MENote.Text = data.Rows(0)("fg_so_store_note").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_store_from = data.Rows(0)("id_store_from").ToString
            id_lock = data.Rows(0)("id_lock").ToString

            ''detail2
            viewDetail()
            view_barcode_list()
            'check_but()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'action
            Dim query As String = ""
            Dim datax As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = datax
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_fg_so_store('" + id_fg_so_store + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_so_store_det_list.Add(data.Rows(i)("id_fg_so_store_det").ToString)
                'codeAvailableIns(data.Rows(i)("id_product").ToString, id_store, data.Rows(i)("id_design_price").ToString)
            Next
            GCItemList.DataSource = data
            codeAvailableIns("0", id_store_from, "0")
        End If
    End Sub


    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_fg_so_store_det, ('0') AS id_pl_prod_order_rec_det_unique, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_fg_so_store_det_counting, CAST('0' AS DECIMAL(13,2)) AS bom_unit_price, CAST('0' AS DECIMAL(13,2)) AS design_price, ('0') AS id_design_price, ('0') AS id_pl_category, ('') AS pl_category "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_so_store_det_counting) AS code, (c.product_full_code) AS product_code, "
            query += "(a.fg_so_store_det_counting) AS counting_code, "
            query += "a.id_fg_so_store_det_counting, ('2') AS is_fix, "
            query += "a.id_pl_prod_order_rec_det_unique, b.id_product, "
            query += "dsg.design_cop as `bom_unit_price`, b.id_design_price, b.design_price, "
            query += "a.id_pl_category, e.pl_category, dsg.is_old_design "
            query += "FROM tb_fg_so_store_det_counting a "
            query += "INNER JOIN tb_fg_so_store_det b ON a.id_fg_so_store_det = b.id_fg_so_store_det "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
            query += "INNER JOIN tb_m_design dsg ON dsg.id_design = c.id_design "
            query += "LEFT JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = a.id_pl_prod_order_rec_det_unique "
            query += "INNER JOIN tb_lookup_pl_category e ON e.id_pl_category = a.id_pl_category "
            query += "WHERE b.id_fg_so_store = '" + id_fg_so_store + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_so_store_det_counting_list.Add(data.Rows(i)("id_fg_so_store_det_counting").ToString)
                insertDt(data.Rows(i)("id_product").ToString, data.Rows(i)("id_pl_prod_order_rec_det_unique").ToString, data.Rows(i)("product_code").ToString, data.Rows(i)("counting_code").ToString, data.Rows(i)("code").ToString, Decimal.Parse(data.Rows(i)("bom_unit_price").ToString), data.Rows(i)("id_design_price").ToString, Decimal.Parse(data.Rows(i)("design_price").ToString), data.Rows(i)("is_old_design").ToString)
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    Sub codeAvailableIns(ByVal id_product_param As String, ByVal id_store_param As String, ByVal id_design_price_param As String)
        dt.Clear()
        Dim query As String = ""
        query = "CALL view_stock_fg_unique_ret('" + id_product_param + "','" + id_store_param + "', '" + id_design_price_param + "','0')"
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        For k As Integer = 0 To (datax.Rows.Count - 1)
            insertDt(datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_pl_prod_order_rec_det_unique").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, Decimal.Parse(datax.Rows(k)("bom_unit_price").ToString), datax.Rows(k)("id_design_price").ToString, Decimal.Parse(datax.Rows(k)("design_price").ToString), "2")
        Next

        'not unique
        Dim id_prd As String = ""
        For d As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            If d > 0 Then
                id_prd += ";"
            End If
            id_prd += GVItemList.GetRowCellValue(d, "id_product").ToString
        Next
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query_not As String = query_c.queryOldDesignCode(id_prd)
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

    Sub insertDt(ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal, ByVal id_design_price_param As String, ByVal design_price_param As Decimal, ByVal is_old_design_param As String)
        Dim R As DataRow = dt.NewRow
        R("id_product") = id_product_param
        R("id_pl_prod_order_rec_det_unique") = id_pl_prod_order_rec_det_unique_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        R("id_design_price") = id_design_price_param
        R("design_price") = design_price_param
        R("is_old_design") = is_old_design_param
        dt.Rows.Add(R)
    End Sub

    'Sub codeAvailableDel(ByVal id_product_param As String)
    '    Dim i As Integer = dt.Rows.Count - 1
    '    While (i >= 0)
    '        If dt.Rows(i)("id_product").ToString = id_product_param Then
    '            dt.Rows.RemoveAt(i)
    '        End If
    '        i = i - 1
    '    End While
    'End Sub

    Sub allow_status()
        If id_lock = "1" Then
            GVItemList.OptionsBehavior.Editable = True
            'PanelControlNav.Enabled = True
            'PanelControlNavDetail.Enabled = True
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
            'PanelControlNavDetail.Enabled = False
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
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
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

    Sub countQty(ByVal id_product_param As String, ByVal id_design_price_param As String, ByVal design_price_param As Decimal)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = GVBarcode.GetRowCellValue(i, "id_product").ToString
            Dim id_design_price As String = GVBarcode.GetRowCellValue(i, "id_design_price").ToString
            Dim design_price As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(i, "design_price").ToString)
            If id_product = id_product_param And id_design_price = id_design_price_param And design_price = design_price_param Then
                tot = tot + 1.0
            End If
        Next

        Dim indeks As Integer = 0
        For j As Integer = 0 To GVItemList.RowCount - 1
            Try
                Dim id_productx As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                Dim id_design_pricex As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                Dim design_pricex As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(j, "design_price").ToString)
                If id_productx = id_product_param And id_design_pricex = id_design_price_param And design_pricex = design_price_param Then
                    indeks = j
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next



        GVItemList.FocusedRowHandle = indeks
        Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
        GVItemList.SetFocusedRowCellValue("amount", tot * price)
        GVItemList.SetFocusedRowCellValue("qty", tot)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_so_store
        FormReportMark.report_mark_type = "53"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        FormFGStockOpnameStoreSingle.ShowDialog()
        'startScan()
    End Sub

    Sub startScan()
        If GVItemList.RowCount > 0 Then
            'is_scan = True
            MENote.Enabled = False
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BDelete.Enabled = False
            BtnCancel.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            ControlBox = False
            BRefresh.Enabled = False
            TxtSONumber.Enabled = False
            newRowsBc()
            'allowDelete()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        'is_scan = False
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        BRefresh.Enabled = True
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
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim id_fg_so_store_det_counting As String = "-1"
        Try
            id_fg_so_store_det_counting = GVBarcode.GetFocusedRowCellValue("id_fg_so_store_det_counting").ToString
        Catch ex As Exception
        End Try

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
            Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
            Dim id_design_price As String = GVBarcode.GetFocusedRowCellValue("id_design_price").ToString
            Dim design_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("design_price").ToString)
            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

            deleteRowsBc()
            If id_product <> "" Or id_product <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_product, id_design_price, design_price)
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
        Dim code_item_found As Boolean = False
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_product As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim id_design_price As String = ""
        Dim design_price As Decimal = 0.0
        Dim is_old As String = "0"

        'check available code
        Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_check + "' ")
        If dt_filter.Length > 0 Then
            counting_code = dt_filter(0)("product_counting_code").ToString
            id_pl_prod_order_rec_det_unique = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
            id_product = dt_filter(0)("id_product").ToString
            bom_unit_price = Decimal.Parse(dt_filter(0)("bom_unit_price").ToString)
            id_design_price = dt_filter(0)("id_design_price").ToString
            design_price = Decimal.Parse(dt_filter(0)("design_price").ToString)
            is_old = dt_filter(0)("is_old_design").ToString
            code_found = True
        End If

        'check in item list
        For g As Integer = 0 To GVItemList.RowCount - 1
            Dim id_design_price_item As String = GVItemList.GetRowCellValue(g, "id_design_price").ToString
            Dim id_product_item As String = GVItemList.GetRowCellValue(g, "id_product").ToString
            Dim design_price_item As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(g, "design_price").ToString)
            Try
                If id_product = id_product_item And id_design_price = id_design_price_item And design_price = design_price_item Then
                    code_item_found = True
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If is_old = "1" Then 'no unique
            If Not code_found Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data not found!")
            ElseIf Not code_item_found Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data not found!")
            Else
                GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                GVBarcode.SetFocusedRowCellValue("id_fg_so_store_det_counting", "0")
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
                GVBarcode.SetFocusedRowCellValue("id_product", id_product)
                GVBarcode.SetFocusedRowCellValue("bom_unit_price", bom_unit_price)
                GVBarcode.SetFocusedRowCellValue("id_design_price", id_design_price)
                GVBarcode.SetFocusedRowCellValue("design_price", design_price)
                GVBarcode.SetFocusedRowCellValue("id_pl_category", id_pl_category)
                GVBarcode.SetFocusedRowCellValue("pl_category", pl_category)
                countQty(id_product, id_design_price, design_price)
                newRowsBc()
            End If
        ElseIf is_old = "2" Then ' unique
            'check duplicate code
            If GVBarcode.RowCount <= 0 Then
                code_duplicate = False
            Else
                For i As Integer = 0 To (GVBarcode.RowCount - 1)
                    Dim code As String = ""
                    If Not IsDBNull(GVBarcode.GetRowCellValue(i, "code")) Then
                        code = GVBarcode.GetRowCellValue(i, "code".ToString)
                    End If

                    Dim is_fix As String = "1"
                    If Not IsDBNull(GVBarcode.GetRowCellValue(i, "is_fix")) Then
                        is_fix = GVBarcode.GetRowCellValue(i, "is_fix").ToString
                    End If

                    If code = code_check And is_fix = "2" Then
                        code_duplicate = True
                        Exit For
                    End If
                Next
            End If

            If Not code_found Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data not found or duplicate!")
            ElseIf code_duplicate Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data duplicate !")
            ElseIf Not code_item_found Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data not found or duplicate!")
            Else
                GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                GVBarcode.SetFocusedRowCellValue("id_fg_so_store_det_counting", "0")
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                'GVBarcode.SetFocusedRowCellValue("id_pl_sales_order_del_det", id_pl_sales_order_del_det)
                GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
                GVBarcode.SetFocusedRowCellValue("id_product", id_product)
                GVBarcode.SetFocusedRowCellValue("bom_unit_price", bom_unit_price)
                GVBarcode.SetFocusedRowCellValue("id_design_price", id_design_price)
                GVBarcode.SetFocusedRowCellValue("design_price", design_price)
                GVBarcode.SetFocusedRowCellValue("id_pl_category", id_pl_category)
                GVBarcode.SetFocusedRowCellValue("pl_category", pl_category)
                countQty(id_product, id_design_price, design_price)
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

    Private Sub BtnBrowseStoreFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseStoreFrom.Click
        FormPopUpContact.id_cat = id_comp_cat_store
        FormPopUpContact.id_pop_up = "44"
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
        pre_viewImages("2", PictureEdit1, id_designx, False)
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Dim id_designx As String = "0"
        Try
            id_designx = GVItemList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_designx, True)
    End Sub

    Private Sub FormFGStockOpnameStoreDet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
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
                Dim fg_so_store_number As String = TxtSONumber.Text
                Dim fg_so_store_note As String = MENote.Text

                If action = "ins" Then
                    'query main table
                    Dim query_main As String = ""
                    query_main = "INSERT INTO tb_fg_so_store(id_store_contact_from, fg_so_store_number, fg_so_store_date_created, fg_so_store_last_update, fg_so_store_note, id_report_status) "
                    query_main += "VALUES ('" + id_store_contact_from + "', '" + fg_so_store_number + "', NOW(), NOW(), '" + fg_so_store_note + "', '1'); SELECT LAST_INSERT_ID(); "
                    id_fg_so_store = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc_sales("9")

                   
                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_so_store_det(id_fg_so_store, id_product, id_design_price, design_price, fg_so_store_det_qty, fg_so_store_det_note) VALUES "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim fg_so_store_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "qty").ToString)
                            Dim fg_so_store_det_note As String = GVItemList.GetRowCellValue(j, "note").ToString

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_fg_so_store + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + fg_so_store_det_qty + "', '" + fg_so_store_det_note + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                            'MsgBox(ex.ToString)
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_fg_so_store_det, a.id_product, a.id_design_price, a.design_price "
                    query_get_detail_id += "FROM tb_fg_so_store_det a "
                    query_get_detail_id += "WHERE a.id_fg_so_store = '" + id_fg_so_store + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")


                    'counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_fg_so_store_det_counting(id_fg_so_store_det, id_pl_prod_order_rec_det_unique, fg_so_store_det_counting, id_pl_category) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product").ToString
                        Dim id_design_price_counting As String = GVBarcode.GetRowCellValue(p, "id_design_price").ToString
                        Dim design_price_counting As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(p, "design_price").ToString)
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        Dim fg_so_store_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        Dim id_pl_category_counting As String = GVBarcode.GetRowCellValue(p, "id_pl_category").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString And id_design_price_counting = data_get_detail_id.Rows(p1)("id_design_price").ToString And design_price_counting = Decimal.Parse(data_get_detail_id.Rows(p1)("design_price").ToString) Then
                                If jum_ins_p > 0 Then
                                    query_counting += ", "
                                End If
                                query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_so_store_det").ToString + "', '" + id_pl_prod_order_rec_det_unique + "', '" + fg_so_store_det_counting + "', '" + id_pl_category_counting + "') "
                                jum_ins_p = jum_ins_p + 1
                                Exit For
                            End If
                        Next
                    Next
                    If jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If


                    FormFGStockOpnameStore.viewSoStore()
                    FormFGStockOpnameStore.GVSOStore.FocusedRowHandle = find_row(FormFGStockOpnameStore.GVSOStore, "id_fg_so_store", id_fg_so_store)
                    Close()
                ElseIf action = "upd" Then
                    'update main table
                    Dim query_main As String = "UPDATE tb_fg_so_store SET id_store_contact_from = '" + id_store_contact_from + "', fg_so_store_number= '" + fg_so_store_number + "', fg_so_store_note = '" + fg_so_store_note + "', fg_so_store_last_update = NOW() WHERE id_fg_so_store = '" + id_fg_so_store + "' "
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_so_store_det(id_fg_so_store, id_product, id_design_price, design_price, fg_so_store_det_qty, fg_so_store_det_note) VALUES "
                    End If
                    For j As Integer = 0 To (GVItemList.RowCount - 1)
                        Try
                            Dim id_fg_so_store_det As String = GVItemList.GetRowCellValue(j, "id_fg_so_store_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim fg_so_store_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "qty").ToString)
                            Dim fg_so_store_det_note As String = GVItemList.GetRowCellValue(j, "note").ToString

                            If id_fg_so_store_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_fg_so_store + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + fg_so_store_det_qty + "', '" + fg_so_store_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_detail_upd As String = "UPDATE tb_fg_so_store_det SET id_product = '" + id_product + "', id_design_price = '" + id_design_price + "', design_price='" + design_price + "', fg_so_store_det_qty = '" + fg_so_store_det_qty + "', fg_so_store_det_note = '" + fg_so_store_det_note + "' WHERE id_fg_so_store_det = '" + id_fg_so_store_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_fg_so_store_det_list.Remove(id_fg_so_store_det)
                            End If
                        Catch ex As Exception
                            'MsgBox(ex.ToString)
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    For j_del As Integer = 0 To (id_fg_so_store_det_list.Count - 1)
                        Try
                            Dim query_detail_del As String = "DELETE FROM tb_fg_so_store_det WHERE id_fg_so_store_det = '" + id_fg_so_store_det_list(j_del) + "'"
                            execute_non_query(query_detail_del, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_fg_so_store_det, a.id_product, a.id_design_price, a.design_price "
                    query_get_detail_id += "FROM tb_fg_so_store_det a "
                    query_get_detail_id += "WHERE a.id_fg_so_store = '" + id_fg_so_store + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")


                    'update counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_fg_so_store_det_counting(id_fg_so_store_det, id_pl_prod_order_rec_det_unique, fg_so_store_det_counting, id_pl_category) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_fg_so_store_det_counting As String = GVBarcode.GetRowCellValue(p, "id_fg_so_store_det_counting").ToString
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product").ToString
                        Dim id_design_price_counting As String = GVBarcode.GetRowCellValue(p, "id_design_price").ToString
                        Dim design_price_counting As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(p, "design_price").ToString)
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        Dim fg_so_store_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        Dim id_pl_category_counting As String = GVBarcode.GetRowCellValue(p, "id_pl_category").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_fg_so_store_det_counting = "0" Then
                                If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString And id_design_price_counting = data_get_detail_id.Rows(p1)("id_design_price").ToString And design_price_counting = Decimal.Parse(data_get_detail_id.Rows(p1)("design_price").ToString) Then
                                    If jum_ins_p > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_so_store_det").ToString + "', '" + id_pl_prod_order_rec_det_unique + "', '" + fg_so_store_det_counting + "', '" + id_pl_category_counting + "') "
                                    jum_ins_p = jum_ins_p + 1
                                    Exit For
                                End If
                            Else
                                'Dim query_upd_counting As String = "UPDATE tb_fg_so_store_det_counting SET id_pl_prod_order_rec_det_unique = '" + id_pl_prod_order_rec_det_unique + "', fg_so_store_det_counting = '" + fg_so_store_det_counting + "' WHERE id_fg_so_store_det_counting = '" + id_fg_so_store_det_counting + "'"
                                'execute_non_query(query_upd_counting, True, "", "", "", "")
                                id_fg_so_store_det_counting_list.Remove(id_fg_so_store_det_counting)
                            End If
                        Next
                    Next
                    If jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    For p_del As Integer = 0 To (id_fg_so_store_det_counting_list.Count - 1)
                        Try
                            Dim query_counting_del As String = "DELETE FROM tb_fg_so_store_det_counting WHERE id_fg_so_store_det_counting = '" + id_fg_so_store_det_counting_list(p_del) + "'"
                            execute_non_query(query_counting_del, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next


                    FormFGStockOpnameStore.viewSoStore()
                    FormFGStockOpnameStore.GVSOStore.FocusedRowHandle = find_row(FormFGStockOpnameStore.GVSOStore, "id_fg_so_store", id_fg_so_store)
                    Close()
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtNameStoreFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameStoreFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameStoreFrom)
        EPForm.SetIconPadding(TxtNameStoreFrom, 30)
    End Sub

    Private Sub BtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLock.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("User can't edit this data after locking process, are you sure to continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim query As String = "CALL generate_sum_fg_so_store('" + id_fg_so_store + "', '" + id_store_from + "')"
                execute_non_query(query, True, "", "", "", "")

                'insert who prepared
                insert_who_prepared("53", id_fg_so_store, id_user)

                FormFGStockOpnameStore.viewSoStore()
                Close()
            Catch ex As Exception
                errorConnection()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportFGStockOpnameStore.id_fg_so_store = id_fg_so_store
        Dim Report As New ReportFGStockOpnameStore()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub
End Class