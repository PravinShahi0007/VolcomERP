Public Class FormViewFGWoff 
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


    Private Sub FormViewFGWoff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        GroupControlListItem.Enabled = True
        GroupControlDrawerDetail.Enabled = True
        GroupControlScannedItem.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
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
    End Sub

    'sub check_but
    Sub check_but()
       
    End Sub

    Sub check_but_drawer()
        
    End Sub

    Sub allow_status()
        MENote.Properties.ReadOnly = True
        GVItemList.OptionsCustomization.AllowGroup = True
        BtnAttachment.Enabled = True
        TxtNumber.Focus()
    End Sub

    Sub view_barcode_list()
        Dim id_det As String = "-1"
        Try
            id_det = GVItemList.GetFocusedRowCellValue("id_fg_woff_det").ToString
        Catch ex As Exception
        End Try
        Dim query As String = ""
        query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_woff_det_counting) AS code, "
        query += "(a.fg_woff_det_counting) AS counting_code, "
        query += "a.id_fg_woff_det_counting, ('2') AS is_fix, "
        query += "a.id_pl_prod_order_rec_det_unique, b.id_product "
        query += "FROM tb_fg_woff_det_counting a "
        query += "INNER JOIN tb_fg_woff_det b ON a.id_fg_woff_det = b.id_fg_woff_det "
        query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
        query += "WHERE b.id_fg_woff = '" + id_fg_woff + "' AND b.id_fg_woff_det='" + id_det + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
    End Sub

    Sub viewDetail()
        Dim id_param As String = ""
        Dim query_c As ClassFGWoff = New ClassFGWoff()
        Dim query As String = query_c.queryDetail(id_fg_woff)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub viewDetailDrawer()
        Dim id_det As String = "-1"
        Try
            id_det = GVItemList.GetFocusedRowCellValue("id_fg_woff_det").ToString
        Catch ex As Exception
        End Try

        Dim query_c As ClassFGWoff = New ClassFGWoff()
        Dim query As String = query_c.queryDetailDrw(id_fg_woff)
        Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
        dtd_temp.DefaultView.RowFilter = "id_fg_woff_det = " + id_det + " "
        Dim data As DataTable = dtd_temp.DefaultView.ToTable
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
      
    End Sub

    Sub codeAvailableIns(ByVal id_product_param As String)
   
    End Sub

    Sub codeAvailableDel(ByVal id_product_param As String)
       
    End Sub

    Sub insertDt(ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal)
       
    End Sub

  
    Private Sub FormViewFGWoff_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
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
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        viewDetailDrawer()
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

   

    Sub startScan()
       
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
        GVItemList.SetFocusedRowCellValue("fg_woff_det_qty", tot)

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
        FormReportMark.is_view = "1"
        FormReportMark.id_report = id_fg_woff
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "69"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = id_fg_woff
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemList.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        viewDetailDrawer()
        Cursor = Cursors.Default
    End Sub
End Class