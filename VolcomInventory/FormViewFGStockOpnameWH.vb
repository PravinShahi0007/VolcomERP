Public Class FormViewFGStockOpnameWH 
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_so_wh As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_fg_so_wh_det_list As New List(Of String)
    Public id_fg_so_wh_det_counting_list As New List(Of String)
    Dim id_comp_cat_wh As String = "-1"
    Public id_pl_category As String = "-1"
    Public pl_category As String = "-1"
    Dim id_lock As String = "-1"
    Dim is_scan As Boolean = False
    Public is_view As String = "-1"

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub FormViewStockOpnameWH_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        Dispose()
    End Sub

    Sub actionLoad()
        GroupControlItem.Enabled = True
        'query view based on edit id's
        Dim query As String = ""
        query += "SELECT so.id_wh_drawer,drawer.wh_drawer,drawer.wh_drawer_code,so.id_sales_pos_ref,sal_pos.sales_pos_number,so.fg_so_wh_note, so.id_lock, so.id_fg_so_wh, so.fg_so_wh_number, so.id_report_status,stat.report_status, "
        query += "DATE_FORMAT(so.fg_so_wh_date_created, '%Y-%m-%d') AS fg_so_wh_date_created, "
        query += "DATE_FORMAT(so.fg_so_wh_last_update, '%Y-%m-%d') AS fg_so_wh_last_update, "
        query += "(comp_contact.id_comp_contact) AS id_comp_contact_from, (comp.id_comp) AS id_comp_from, "
        query += "(comp.comp_number) AS comp_number_from, (comp.comp_name) AS comp_name_from "
        query += "FROM tb_fg_so_wh so "
        query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
        query += "LEFT JOIN tb_sales_pos sal_pos ON sal_pos.id_sales_pos = so.id_sales_pos_ref "
        query += "LEFT JOIN tb_m_wh_drawer drawer ON drawer.id_wh_drawer=so.id_wh_drawer "
        query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
        query += "WHERE so.id_fg_so_wh = '" + id_fg_so_wh + "' "
        query += "ORDER BY so.id_fg_so_wh DESC "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        TxtSONumber.Text = data.Rows(0)("fg_so_wh_number").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        DEForm.Text = view_date_from(data.Rows(0)("fg_so_wh_date_created").ToString, 0)
        TxtLastUpdate.Text = view_date_from(data.Rows(0)("fg_so_wh_last_update").ToString, 0)
        TEDrawerCode.Text = data.Rows(0)("wh_drawer_code").ToString
        TEDrawerName.Text = data.Rows(0)("wh_drawer").ToString
        MENote.Text = data.Rows(0)("fg_so_wh_note").ToString
        'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_comp_from = data.Rows(0)("id_comp_from").ToString
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
        'view_barcode_list()
        check_but()
        allow_status()
    End Sub

    Sub viewDetail()
        Dim id_param As String = ""
        Dim query As String = "CALL view_fg_so_wh_sum('" + id_fg_so_wh + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.BestFitColumns()
    End Sub


    Sub view_barcode_list(ByVal id_fg_so_wh_det_param As String)
        Dim query As String = ""
        query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.fg_so_wh_det_counting) AS code, (c.product_full_code) AS product_code, "
        query += "(a.fg_so_wh_det_counting) AS counting_code, "
        query += "a.id_fg_so_wh_det_counting, ('2') AS is_fix, "
        query += "a.id_pl_prod_order_rec_det_unique, b.id_product, "
        query += "d.bom_unit_price, "
        query += "a.id_pl_category, e.pl_category "
        query += "FROM tb_fg_so_wh_det_counting a "
        query += "INNER JOIN tb_fg_so_wh_det b ON a.id_fg_so_wh_det = b.id_fg_so_wh_det "
        query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
        query += "INNER JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = a.id_pl_prod_order_rec_det_unique "
        query += "INNER JOIN tb_lookup_pl_category e ON e.id_pl_category = a.id_pl_category "
        query += "WHERE b.id_fg_so_wh = '" + id_fg_so_wh + "' AND b.id_fg_so_wh_det ='" + id_fg_so_wh_det_param + "' "
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
        'If GVBarcode.RowCount <= 0 Then
        '    BDelete.Enabled = False
        'Else
        '    BDelete.Enabled = True
        'End If
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
        Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
        GVItemList.SetFocusedRowCellValue("amount", tot * price)
        GVItemList.SetFocusedRowCellValue("qty", tot)
    End Sub


    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        noEdit()
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


    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormViewFGStockOpnameWH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        'call action
        actionLoad()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormViewFGStockOpnameWH_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_so_wh
        FormReportMark.report_mark_type = "56"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Dim id_designx As String = "0"
        Try
            id_designx = GVItemList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_designx, True)
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        'ReportFGStockOpnameWH.id_fg_so_wh = id_fg_so_wh
        'Dim Report As New ReportFGStockOpnameWH()
        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()

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

        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)

    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim id_productx As String = "0"
        Dim id_samplex As String = "0"
        Dim id_designx As String = "0"
        Dim id_design_pricex As String = "0"
        Dim price As Decimal = 0.0
        Dim id_fg_so_wh_detx As String = "0"
        Try
            id_designx = GVItemList.GetFocusedRowCellValue("id_design").ToString
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            price = Decimal.Parse(GVItemList.GetFocusedRowCellValue("bom_unit_price").ToString)
            id_fg_so_wh_detx = GVItemList.GetFocusedRowCellValue("id_fg_so_wh_det").ToString
        Catch ex As Exception
        End Try
        If Not is_scan Then
            pre_viewImages("2", PictureEdit1, id_designx, False)
        End If
        check_but()
        view_barcode_list(id_fg_so_wh_detx)
    End Sub

    Private Sub BGenerateInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGenerateInv.Click
        Cursor = Cursors.WaitCursor
        FormPopUpInvoiceMissing.id_popup = "1"
        FormPopUpInvoiceMissing.ShowDialog()
        Cursor = Cursors.Default
        '
    End Sub
End Class