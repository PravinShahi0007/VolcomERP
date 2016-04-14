Public Class FormViewFGStockOpname 
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
    Public disc As Decimal = 0.0

    Private Sub FormViewFGStockOpnameStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        'call action
        actionLoad()
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormViewFGStockOpnameStore_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        GroupControlItem.Enabled = True

        'query view based on edit id's
        Dim query As String = ""
        query += "SELECT so.id_sales_pos_ref,s_pos.sales_pos_number,comp.comp_commission,so.fg_so_store_note, so.id_lock, so.id_fg_so_store, so.fg_so_store_number, so.id_report_status,stat.report_status, "
        query += "DATE_FORMAT(so.fg_so_store_date_created, '%Y-%m-%d') AS fg_so_store_date_created, "
        query += "DATE_FORMAT(so.fg_so_store_last_update, '%Y-%m-%d') AS fg_so_store_last_update, "
        query += "(comp_contact.id_comp_contact) AS id_store_contact_from, (comp.id_comp) AS id_store_from, "
        query += "(comp.comp_number) AS store_number_from, (comp.comp_name) AS store_name_from "
        query += "FROM tb_fg_so_store so "
        'query += "INNER JOIN tb_fg_so_store_det so_det ON so.id_fg_so_store = so_det.id_fg_so_store "
        query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_store_contact_from "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
        query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
        query += "LEFT JOIN tb_sales_pos s_pos ON s_pos.id_sales_pos=so.id_sales_pos_ref "
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
        disc = data.Rows(0)("comp_commission")
        TEInv.Text = data.Rows(0)("sales_pos_number").ToString
        'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_store_from = data.Rows(0)("id_store_from").ToString
        id_lock = data.Rows(0)("id_lock").ToString

        If data.Rows(0)("id_sales_pos_ref").ToString = "" Or data.Rows(0)("id_sales_pos_ref").ToString = "0" Then 'not generated yet
            BGenerateInv.Enabled = True
            LInv.Visible = False
            TEInv.Visible = False
        Else
            BGenerateInv.Enabled = False
            LInv.Visible = True
            TEInv.Visible = True
            TEInv.Text = data.Rows(0)("sales_pos_number").ToString
        End If

        ''detail2
        viewDetail()
        'check_but()
        allow_status()
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_fg_so_store_sum('" + id_fg_so_store + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub view_barcode_list(ByVal id_fg_so_store_det_param As String)
        Dim query As String = ""
        query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_so_store_det_counting) AS code, (c.product_full_code) AS product_code, "
        query += "(a.fg_so_store_det_counting) AS counting_code, "
        query += "a.id_fg_so_store_det_counting, ('2') AS is_fix, "
        query += "a.id_pl_prod_order_rec_det_unique, b.id_product, "
        query += "d.bom_unit_price, b.id_design_price, b.design_price, "
        query += "a.id_pl_category, e.pl_category "
        query += "FROM tb_fg_so_store_det_counting a "
        query += "INNER JOIN tb_fg_so_store_det b ON a.id_fg_so_store_det = b.id_fg_so_store_det "
        query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
        query += "INNER JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = a.id_pl_prod_order_rec_det_unique "
        query += "INNER JOIN tb_lookup_pl_category e ON e.id_pl_category = a.id_pl_category "
        query += "WHERE b.id_fg_so_store = '" + id_fg_so_store + "' AND b.id_fg_so_store_det = '" + id_fg_so_store_det_param + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
    End Sub

   
    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        TxtSONumber.Properties.ReadOnly = True
        BMark.Enabled = True

        'Print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If id_report_status = "6" Then
            BGenerateInv.Visible = True
        Else
            BGenerateInv.Visible = False
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
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_so_store
        FormReportMark.report_mark_type = "53"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
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

    Private Sub BtnBrowseStoreFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        Dim id_fg_so_store_detx As String = "0"
        Try
            id_designx = GVItemList.GetFocusedRowCellValue("id_design").ToString
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            id_fg_so_store_detx = GVItemList.GetFocusedRowCellValue("id_fg_so_store_det").ToString
            price = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
        Catch ex As Exception
        End Try
        pre_viewImages("2", PictureEdit1, id_designx, False)
        view_barcode_list(id_fg_so_store_detx)
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Dim id_designx As String = "0"
        Try
            id_designx = GVItemList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_designx, True)
    End Sub

    Private Sub FormViewFGStockOpnameStore_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'MsgBox("Tutup")
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        GVBarcode.ShowEditor()
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

    Private Sub BGenerateInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGenerateInv.Click
        Cursor = Cursors.WaitCursor
        FormPopUpInvoiceMissing.id_popup = "2"
        FormPopUpInvoiceMissing.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class