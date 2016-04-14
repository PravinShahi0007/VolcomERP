Public Class FormFGWoffDet 
    Public action As String = "-1"
    Public id_fg_woff As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_report_status As String = "-1"
    Dim dt As New DataTable
    Public id_fg_woff_det_list As New List(Of String)
    Public id_fg_woff_det_counting_list As New List(Of String)
    Public id_fg_woff_det_drawer_list As New List(Of String)
    Dim id_comp_cat_wh As String = "-1"
    Dim is_scan As Boolean = False


    Private Sub FormFGWoffDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        id_comp_cat_wh = get_setup_field("id_comp_cat_wh")
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
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
        Catch ex As Exception
        End Try

        If action = "ins" Then
            XTPOutboundScanNew.PageEnabled = False
            TxtNumber.Text = header_number_sales("20")
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
            check_but_drawer()
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlDrawerDetail.Enabled = True
            GroupControlScannedItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactFrom.Enabled = False
            XTPOutboundScanNew.PageEnabled = True

            Dim query_c As ClassFGWoff = New ClassFGWoff()
            Dim query As String = query_c.queryMain("AND tb_fg_woff.id_fg_woff=''" + id_fg_woff + "'' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_woff = data.Rows(0)("id_fg_woff").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            id_comp_from = data.Rows(0)("id_comp_from").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
            TxtNumber.Text = data.Rows(0)("fg_woff_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_woff_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_woff_note").ToString

            'detail2
            viewDetail()
            view_barcode_list()
            viewDetailDrawer()
            check_but()
            check_but_drawer()
            allow_status()
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
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            BtnAddDrawer.Enabled = True
            BtnEditDrawer.Enabled = True
            BtnDelDrawer.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            BtnAddDrawer.Enabled = False
            BtnEditDrawer.Enabled = False
            BtnDelDrawer.Enabled = False
        End If
    End Sub

    Sub check_but_drawer()
        Dim id_wh_drawer_ As String = "0"
        Try
            id_wh_drawer_ = GVDrawer.GetFocusedRowCellValue("id_wh_drawer").ToString
        Catch ex As Exception
        End Try

        If GVDrawer.RowCount > 0 And id_wh_drawer_ <> "0" Then
            BtnEditDrawer.Enabled = True
            BtnDelDrawer.Enabled = True
        Else
            BtnEditDrawer.Enabled = False
            BtnDelDrawer.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "69", id_fg_woff) Then
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            PanelControlNavDetail.Enabled = True
            PanelNavBarcode.Enabled = True
            MENote.Properties.ReadOnly = False
            GVItemList.OptionsCustomization.AllowGroup = False
            BtnSave.Enabled = True
        Else
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            PanelControlNavDetail.Enabled = False
            PanelNavBarcode.Enabled = False
            MENote.Properties.ReadOnly = True
            GVItemList.OptionsCustomization.AllowGroup = True
            BtnSave.Enabled = False
        End If

        'ATTACH
        If check_attach_report_status(id_report_status, "69", id_fg_woff) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_fg_woff_det, ('0') AS id_pl_prod_order_rec_det_unique, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_fg_woff_det_counting "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_woff_det_counting) AS code, "
            query += "(a.fg_woff_det_counting) AS counting_code, "
            query += "a.id_fg_woff_det_counting, ('2') AS is_fix, "
            query += "a.id_pl_prod_order_rec_det_unique, b.id_product "
            query += "FROM tb_fg_woff_det_counting a "
            query += "INNER JOIN tb_fg_woff_det b ON a.id_fg_woff_det = b.id_fg_woff_det "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
            query += "WHERE b.id_fg_woff = '" + id_fg_woff + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_woff_det_counting_list.Add(data.Rows(i)("id_fg_woff_det_counting").ToString)
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'action
            Dim query_c As ClassFGWoff = New ClassFGWoff()
            Dim query As String = query_c.queryDetail(id_fg_woff)
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            Dim id_param As String = ""
            Dim query_c As ClassFGWoff = New ClassFGWoff()
            Dim query As String = query_c.queryDetail(id_fg_woff)
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_fg_woff_det_list.Add(data.Rows(i)("id_fg_woff_det").ToString)
                id_param = id_param + data.Rows(i)("id_product").ToString
                If i < (data.Rows.Count - 1) Then
                    id_param = id_param + ";"
                End If
            Next
            GCItemList.DataSource = data
            Me.codeAvailableIns(id_param)
        End If
    End Sub

    Sub viewDetailDrawer()
        Dim query_c As ClassFGWoff = New ClassFGWoff()
        Dim query As String = query_c.queryDetailDrw(id_fg_woff)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_fg_woff_det_drawer_list.Add(data.Rows(i)("id_fg_woff_det_drawer").ToString)
        Next
        GCDrawer.DataSource = data
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

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub codeAvailableIns(ByVal id_product_param As String)
        dt.Clear()
        Dim query As String = ""
        query = "CALL view_stock_fg_unique_del('" + id_product_param + "')"
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        For k As Integer = 0 To (datax.Rows.Count - 1)
            insertDt(datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_pl_prod_order_rec_det_unique").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, Decimal.Parse(datax.Rows(k)("bom_unit_price").ToString))
        Next
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

    Sub insertDt(ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal)
        Dim R As DataRow = dt.NewRow
        R("id_product") = id_product_param
        R("id_pl_prod_order_rec_det_unique") = id_pl_prod_order_rec_det_unique_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        dt.Rows.Add(R)
    End Sub

    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "57"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub FormFGWoffDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGStockOpnameWHSingle.id_pop_up = "2"
        FormFGStockOpnameWHSingle.id_wh = id_comp_from
        FormFGStockOpnameWHSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim id_fg_woff_det As String = "-1"
        Try
            id_fg_woff_det = GVItemList.GetFocusedRowCellValue("id_fg_woff_det").ToString
        Catch ex As Exception
        End Try
        Dim id_product As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
        If id_fg_woff_det = "0" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                codeAvailableDel(id_product)
                deleteDetailBC(id_product)
                deleteDetailDrawer(id_product)
                check_but()
                Cursor = Cursors.Default
            End If
        Else
            'cek uda ada product yg di scan ato blm
            errorCustom("This data already locked and can't delete.")
        End If
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

    Sub deleteDetailDrawer(ByVal id_product_param As String)
        'delete detail
        Dim i As Integer = GVDrawer.RowCount - 1
        While (i >= 0)
            Dim id_product As String = ""
            Try
                id_product = GVDrawer.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVDrawer.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub


    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
            Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
            If id_product_check = id_product_style Then
                e.Appearance.BackColor = Color.Lavender
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub my_color_cell_wht(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Try
            check_but()
            AddHandler GVDrawer.RowCellStyle, AddressOf my_color_cell
            GCDrawer.RefreshDataSource()
            GVDrawer.RefreshData()
        Catch ex As Exception
            check_but()
            AddHandler GVDrawer.RowCellStyle, AddressOf my_color_cell_wht
            GCDrawer.RefreshDataSource()
            GVDrawer.RefreshData()
        End Try
    End Sub

    Private Sub BtnPrintDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrintDrawer.Click
        Cursor = Cursors.WaitCursor
        AddHandler GVDrawer.RowCellStyle, AddressOf my_color_cell_wht
        ReportStyleGridview(GVDrawer)
        print(GCDrawer, "Item List Based on Drawer")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_product As String = "-1"
        Try
            id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        FormSalesDelOrderSingle.id_comp = id_comp_from
        FormSalesDelOrderSingle.id_pop_up = "2"
        FormSalesDelOrderSingle.id_product = "0"
        FormSalesDelOrderSingle.action_pop = "ins"
        FormSalesDelOrderSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub countQtyFromWh(ByVal id_product_param As String)
        Dim jum As Decimal = 0.0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                Dim id_product_i As String = GVDrawer.GetRowCellValue(i, "id_product").ToString
                If id_product_i = id_product_param Then
                    jum = jum + Decimal.Parse(GVDrawer.GetRowCellValue(i, "qty_all_product"))
                End If
            Catch ex As Exception

            End Try
        Next
        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        GVItemList.SetFocusedRowCellValue("qty_from_wh", jum)
        allowScanPage()

    End Sub

    Sub allowScanPage()
        'allow page scan
        Dim allow_scan = True
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim qty_wh_cek As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "qty_from_wh"))
                If qty_wh_cek = 0.0 Then
                    allow_scan = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
        'MsgBox(allow_scan)
        If Not allow_scan Or (GVItemList.RowCount <= 0) Then
            XTPOutboundScanNew.PageEnabled = False
        Else
            XTPOutboundScanNew.PageEnabled = True
        End If
    End Sub

    Private Sub BtnDelDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_fg_woff_det_drawer As String = "-1"
        Try
            id_fg_woff_det_drawer = GVDrawer.GetFocusedRowCellValue("id_fg_woff_det_drawer").ToString
        Catch ex As Exception
        End Try

        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this drawer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_productx As String = GVDrawer.GetFocusedRowCellValue("id_product").ToString
                GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
                GCDrawer.RefreshDataSource()
                GVDrawer.RefreshData()
                countQtyFromWh(id_productx)
                check_but_drawer()
            End If
        ElseIf action = "upd" Then
            If id_fg_woff_det_drawer = "0" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this drawer?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim id_productx As String = GVDrawer.GetFocusedRowCellValue("id_product").ToString
                    GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
                    GCDrawer.RefreshDataSource()
                    GVDrawer.RefreshData()
                    countQtyFromWh(id_productx)
                    check_but_drawer()
                End If
            Else
                'cek uda ada product yg di scan ato blm
                errorCustom("This data already locked and can't delete.")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        If GVItemList.RowCount < 1 Then
            errorCustom("Please add product required !")
        Else
            startScan()
        End If
    End Sub

    Sub startScan()
        If GVItemList.RowCount > 0 Then
            is_scan = True
            MENote.Enabled = False
            BtnSave.Enabled = False
            BScan.Enabled = False
            BStop.Enabled = True
            BDelete.Enabled = False
            BtnCancel.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            ControlBox = False
            TxtNumber.Enabled = False
            BtnBrowseContactFrom.Enabled = False
            newRowsBc()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
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

        is_scan = False
        MENote.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVItemList.OptionsBehavior.Editable = True
        ControlBox = True
        TxtNumber.Enabled = True
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim id_fg_woff_det_counting As String = "-1"
        Try
            id_fg_woff_det_counting = GVItemList.GetFocusedRowCellValue("id_fg_woff_det_counting").ToString
        Catch ex As Exception
        End Try

        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                deleteRowsBc()
                If id_product <> "" Or id_product <> Nothing Then
                    GVBarcode.ApplyFindFilter("")
                    countQty(id_product)
                End If

                allowDelete()
                Cursor = Cursors.Default
            End If
        ElseIf action = "upd" Then
            If id_fg_woff_det_counting = "0" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                    Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                    Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                    Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                    deleteRowsBc()
                    If id_product <> "" Or id_product <> Nothing Then
                        GVBarcode.ApplyFindFilter("")
                        countQty(id_product)
                    End If

                    allowDelete()
                    Cursor = Cursors.Default
                End If
            Else
                'cek uda ada product yg di scan ato blm
                errorCustom("This data already locked and can't delete.")
            End If
        End If
    End Sub

    Sub countQty(ByVal id_product_param As String)
        Dim tot As Decimal = 0.0

        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = GVBarcode.GetRowCellValue(i, "id_product").ToString
            If id_product = id_product_param Then
                tot = tot + 1.0
            End If
        Next


        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)
        Dim amount As Decimal = GVItemList.GetFocusedRowCellValue("design_cop") * tot
        GVItemList.SetFocusedRowCellValue("fg_woff_det_qty", tot)
        GVItemList.SetFocusedRowCellValue("design_cop_amount", amount)

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVDrawer_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDrawer.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
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

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
        End Try
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

        'check available code
        For i As Integer = 0 To (dt.Rows.Count - 1)
            Dim code As String = dt.Rows(i)("product_full_code").ToString
            counting_code = dt.Rows(i)("product_counting_code").ToString
            id_pl_prod_order_rec_det_unique = dt.Rows(i)("id_pl_prod_order_rec_det_unique").ToString
            id_product = dt.Rows(i)("id_product").ToString
            bom_unit_price = Decimal.Parse(dt.Rows(i)("bom_unit_price").ToString)
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

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

        'check in item list
        For g As Integer = 0 To GVItemList.RowCount - 1
            Dim id_product_item As String = GVItemList.GetRowCellValue(g, "id_product").ToString
            Try
                If id_product = id_product_item Then
                    code_item_found = True
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

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
            GVBarcode.SetFocusedRowCellValue("id_fg_woff_det_counting", "0")
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
            GVBarcode.SetFocusedRowCellValue("id_product", id_product)
            GVBarcode.SetFocusedRowCellValue("bom_unit_price", bom_unit_price)
            countQty(id_product)
            newRowsBc()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "69"
        FormReportMark.id_report = id_fg_woff
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "69"
        FormDocumentUpload.id_report = id_fg_woff
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        makeSafeGV(GVBarcode)
        makeSafeGV(GVItemList)
        makeSafeGV(GVDrawer)

        Cursor = Cursors.WaitCursor
        ValidateChildren()

        'cek kesamaan from wh dengan scan
        Dim is_same_qty As Boolean = True
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Try
                Dim qty_from_wh As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "qty_from_wh"))
                Dim fg_woff_det_qty As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "fg_woff_det_qty"))
                If qty_from_wh <> fg_woff_det_qty Then
                    is_same_qty = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        'cek qty limit rack
        Dim available_stock As Boolean = True
        Dim warning_stock As String = ""
        For ix As Integer = 0 To ((GVDrawer.RowCount - 1) - GetGroupRowCount(GVDrawer))
            Try
                Dim id_fg_woff_det_drawer As String = GVDrawer.GetRowCellValue(ix, "id_fg_woff_det_drawer").ToString
                If id_fg_woff_det_drawer = "0" Then
                    Dim qty_all_product As Decimal = GVDrawer.GetRowCellValue(ix, "qty_all_product").ToString
                    Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(ix, "id_wh_drawer").ToString
                    Dim drawer As String = GVDrawer.GetRowCellValue(ix, "drawer").ToString
                    Dim id_wh_rack As String = GVDrawer.GetRowCellValue(ix, "id_wh_rack").ToString
                    Dim id_wh_locator As String = GVDrawer.GetRowCellValue(ix, "id_wh_locator").ToString
                    Dim id_comp As String = GVDrawer.GetRowCellValue(ix, "id_comp").ToString
                    Dim id_product As String = GVDrawer.GetRowCellValue(ix, "id_product").ToString
                    Dim query_cek_stok As String = "CALL view_stock_fg('" + id_comp + "','" + id_wh_locator + "','" + id_wh_rack + "','" + id_wh_drawer + "', '" + id_product + "','4', '9999-01-01')"
                    Dim data_cek_stok As DataTable = execute_query(query_cek_stok, -1, True, "", "", "", "")
                    If qty_all_product > data_cek_stok.Rows(0)("qty_all_product") Then
                        available_stock = False
                        warning_stock = "Out item in " + drawer + " cannot exceed " + data_cek_stok.Rows(0)("qty_all_product") + ""
                        Exit For
                    End If
                End If
            Catch ex As Exception
            End Try
        Next

        If Not formIsValidInGroup(EPForm, GroupGeneralHeader) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Or GVDrawer.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            errorCustom("Write Off item, drawer detail, and scanned item data can't blank")
        ElseIf Not is_same_qty Then
            errorCustom("Qty from wh not equal to qty transfer, please check your input !")
        ElseIf Not available_stock Then
            errorCustom(warning_stock)
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process. Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim fg_woff_number As String = TxtNumber.Text
                Dim fg_woff_note As String = MENote.Text.ToString
                If action = "ins" Then
                    'query main table
                    Dim query_main As String = "INSERT tb_fg_woff(fg_woff_number, id_comp_contact_from, fg_woff_date, fg_woff_note, id_report_status) "
                    query_main += "VALUES('" + fg_woff_number + "', '" + id_comp_contact_from + "', NOW(), '" + fg_woff_note + "', '1'); SELECT LAST_INSERT_ID(); "
                    id_fg_woff = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc_sales("20")

                    'insert who prepared
                    insert_who_prepared("69", id_fg_woff, id_user)

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_woff_det(id_fg_woff, id_product, fg_woff_det_qty, fg_woff_det_note) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim fg_woff_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "fg_woff_det_qty").ToString)
                            Dim fg_woff_det_note As String = GVItemList.GetRowCellValue(j, "fg_woff_det_note").ToString

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_fg_woff + "', '" + id_product + "', '" + fg_woff_det_qty + "', '" + fg_woff_det_note + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If GVItemList.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_fg_woff_det, a.id_product "
                    query_get_detail_id += "FROM tb_fg_woff_det a "
                    query_get_detail_id += "WHERE a.id_fg_woff = '" + id_fg_woff + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'drawer
                    Dim jum_ins_s As Integer = 0
                    Dim query_drawer As String = ""
                    Dim query_drawer_stock As String = ""
                    If GVDrawer.RowCount > 0 Then
                        query_drawer = "INSERT INTO tb_fg_woff_det_drawer(id_fg_woff_det, id_wh_drawer, bom_unit_price, fg_woff_det_drawer_qty) VALUES "
                        query_drawer_stock = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, report_mark_type, id_report, id_stock_status) VALUES "
                    End If
                    For s As Integer = 0 To ((GVDrawer.RowCount - 1) - GetGroupRowCount(GVDrawer))
                        Dim id_product_drawer As String = GVDrawer.GetRowCellValue(s, "id_product")
                        Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(s, "id_wh_drawer")
                        Dim bom_unit_price As String = decimalSQL(GVDrawer.GetRowCellValue(s, "bom_unit_price").ToString)
                        Dim fg_woff_det_drawer_qty As String = decimalSQL(GVDrawer.GetRowCellValue(s, "qty_all_product").ToString)
                        Dim id_fg_woff_det_drawer As String = ""
                        For s1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_product_drawer = data_get_detail_id.Rows(s1)("id_product").ToString Then
                                If jum_ins_s > 0 Then
                                    query_drawer += ", "
                                    query_drawer_stock += ", "
                                End If
                                query_drawer += "('" + data_get_detail_id.Rows(s1)("id_fg_woff_det").ToString + "', '" + id_wh_drawer + "', '" + bom_unit_price + "', '" + fg_woff_det_drawer_qty + "') "
                                query_drawer_stock += "('" + id_wh_drawer + "', '2', '" + id_product_drawer + "', '" + fg_woff_det_drawer_qty + "', NOW(), 'Write Off No: " + fg_woff_number + "', '" + bom_unit_price + "', '69', '" + id_fg_woff + "', '2') "
                                jum_ins_s = jum_ins_s + 1
                                Exit For
                            End If
                        Next
                    Next
                    If GVDrawer.RowCount > 0 Then
                        execute_non_query(query_drawer, True, "", "", "", "")
                    End If

                    'counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_fg_woff_det_counting(id_fg_woff_det, id_pl_prod_order_rec_det_unique, fg_woff_det_counting) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        Dim fg_woff_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                If jum_ins_p > 0 Then
                                    query_counting += ", "
                                End If
                                query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_woff_det").ToString + "', '" + id_pl_prod_order_rec_det_unique + "', '" + fg_woff_det_counting + "') "
                                jum_ins_p = jum_ins_p + 1
                                Exit For
                            End If
                        Next
                    Next
                    If GVBarcode.RowCount > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    'insert stock
                    If jum_ins_s > 0 Then
                        execute_non_query(query_drawer_stock, True, "", "", "", "")
                    End If

                    FormFGWoff.viewFGWoff()
                    FormFGWoff.GVFGWoff.FocusedRowHandle = find_row(FormFGWoff.GVFGWoff, "id_fg_woff", id_fg_woff)
                    Close()
                ElseIf action = "upd" Then
                    'update main table
                    Dim query_main As String = "UPDATE tb_fg_woff SET fg_woff_number = '" + fg_woff_number + "', id_comp_contact_from = '" + id_comp_contact_from + "', fg_woff_note = '" + fg_woff_note + "' WHERE id_fg_woff = '" + id_fg_woff + "' "
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_fg_woff_det(id_fg_woff, id_product, fg_woff_det_qty, fg_woff_det_note) "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_fg_woff_det As String = GVItemList.GetRowCellValue(j, "id_fg_woff_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim fg_woff_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "fg_woff_det_qty").ToString)
                            Dim fg_woff_det_note As String = GVItemList.GetRowCellValue(j, "fg_woff_det_note").ToString

                            If id_fg_woff_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "VALUES('" + id_fg_woff + "', '" + id_product + "', '" + fg_woff_det_qty + "', '" + fg_woff_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_detail_upd As String = "UPDATE tb_fg_woff_det SET id_product = '" + id_product + "', fg_woff_det_qty = '" + fg_woff_det_qty + "', fg_woff_det_note = '" + fg_woff_det_note + "' WHERE id_fg_woff_det = '" + id_fg_woff_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_fg_woff_det_list.Remove(id_fg_woff_det)
                            End If
                        Catch ex As Exception
                            'MsgBox(ex.ToString)
                        End Try
                    Next
                    If GVItemList.RowCount > 0 And jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    For j_del As Integer = 0 To (id_fg_woff_det_list.Count - 1)
                        Try
                            Dim query_detail_del As String = "DELETE FROM tb_fg_woff_det WHERE id_fg_woff_det = '" + id_fg_woff_det_list(j_del) + "'"
                            execute_non_query(query_detail_del, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_fg_woff_det, a.id_product "
                    query_get_detail_id += "FROM tb_fg_woff_det a "
                    query_get_detail_id += "WHERE a.id_fg_woff = '" + id_fg_woff + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'update drawer
                    Dim jum_ins_s As Integer = 0
                    Dim query_drawer As String = ""
                    Dim query_drawer_stock As String = ""
                    If GVDrawer.RowCount > 0 Then
                        query_drawer = "INSERT INTO tb_fg_woff_det_drawer(id_fg_woff_det, id_wh_drawer, bom_unit_price, fg_woff_det_drawer_qty) VALUES "
                        query_drawer_stock = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, report_mark_type, id_report, id_stock_status) VALUES "
                    End If
                    For s As Integer = 0 To ((GVDrawer.RowCount - 1) - GetGroupRowCount(GVDrawer))
                        Dim id_fg_woff_det_drawer As String = GVDrawer.GetRowCellValue(s, "id_fg_woff_det_drawer")
                        Dim id_product_drawer As String = GVDrawer.GetRowCellValue(s, "id_product")
                        Dim id_wh_drawer As String = GVDrawer.GetRowCellValue(s, "id_wh_drawer")
                        Dim bom_unit_price As String = decimalSQL(GVDrawer.GetRowCellValue(s, "bom_unit_price").ToString)
                        Dim fg_woff_det_drawer_qty As String = decimalSQL(GVDrawer.GetRowCellValue(s, "qty_all_product").ToString)
                        For s1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_fg_woff_det_drawer = "0" Then
                                If id_product_drawer = data_get_detail_id.Rows(s1)("id_product").ToString Then
                                    If jum_ins_s > 0 Then
                                        query_drawer += ", "
                                        query_drawer_stock += ", "
                                    End If
                                    query_drawer += "('" + data_get_detail_id.Rows(s1)("id_fg_woff_det").ToString + "', '" + id_wh_drawer + "', '" + bom_unit_price + "', '" + fg_woff_det_drawer_qty + "') "
                                    query_drawer_stock += "('" + id_wh_drawer + "', '2', '" + id_product_drawer + "', '" + fg_woff_det_drawer_qty + "', NOW(), 'Finished Goods Write Off No: " + fg_woff_number + "', '" + bom_unit_price + "', '69', '" + id_fg_woff + "', '2') "
                                    jum_ins_s = jum_ins_s + 1
                                    Exit For
                                End If
                            End If
                        Next
                    Next
                    If GVDrawer.RowCount > 0 And jum_ins_s > 0 Then
                        execute_non_query(query_drawer, True, "", "", "", "")
                    End If

                    'update counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_fg_woff_det_counting(id_fg_woff_det, id_pl_prod_order_rec_det_unique, fg_woff_det_counting) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_fg_woff_det_counting As String = GVBarcode.GetRowCellValue(p, "id_fg_woff_det_counting").ToString
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        Dim fg_woff_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_fg_woff_det_counting = "0" Then
                                If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                    If jum_ins_p > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail_id.Rows(p1)("id_fg_woff_det").ToString + "', '" + id_pl_prod_order_rec_det_unique + "', '" + fg_woff_det_counting + "') "
                                    jum_ins_p = jum_ins_p + 1
                                    Exit For
                                End If
                            End If
                        Next
                    Next
                    If GVBarcode.RowCount > 0 And jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    'insert stock
                    If jum_ins_s > 0 Then
                        execute_non_query(query_drawer_stock, True, "", "", "", "")
                    End If

                    FormFGWoff.viewFGWoff()
                    FormFGWoff.GVFGWoff.FocusedRowHandle = find_row(FormFGWoff.GVFGWoff, "id_fg_woff", id_fg_woff)
                    Close()
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEditDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditDrawer.Click
        Cursor = Cursors.WaitCursor
        Dim id_product As String = "-1"
        Dim id_fg_woff_det_drawer As String = "-1"
        Dim id_wh_drawer As String = "-1"
        Dim qty_edit As Decimal = 0.0
        Try
            id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
            id_fg_woff_det_drawer = GVDrawer.GetFocusedRowCellValue("id_fg_woff_det_drawer").ToString
            id_wh_drawer = GVDrawer.GetFocusedRowCellValue("id_wh_drawer").ToString
            qty_edit = GVDrawer.GetFocusedRowCellValue("fg_woff_det_drawer_qty")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            FormSalesDelOrderSingle.id_comp = id_comp_from
            FormSalesDelOrderSingle.id_pop_up = "2"
            FormSalesDelOrderSingle.indeks_edit = GVDrawer.FocusedRowHandle
            FormSalesDelOrderSingle.id_product = "0"
            FormSalesDelOrderSingle.action_pop = "upd"
            FormSalesDelOrderSingle.ShowDialog()
        ElseIf action = "upd" Then
            If id_fg_woff_det_drawer = "0" Then
                FormSalesDelOrderSingle.id_comp = id_comp_from
                FormSalesDelOrderSingle.id_pop_up = "2"
                FormSalesDelOrderSingle.indeks_edit = GVDrawer.FocusedRowHandle
                FormSalesDelOrderSingle.id_product = "0"
                FormSalesDelOrderSingle.action_pop = "upd"
                FormSalesDelOrderSingle.ShowDialog()
            Else
                errorCustom("This data already locked and can't edit.")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportFGWoff.id_fg_woff = id_fg_woff
        ReportFGWoff.dt = GCItemList.DataSource
        Dim Report As New ReportFGWoff()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GridView1)

        'Parse val
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LRecNumber.Text = TxtNumber.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LabelNote.Text = MENote.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub
End Class