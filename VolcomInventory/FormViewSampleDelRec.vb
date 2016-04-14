Public Class FormViewSampleDelRec 
    Public action As String = "-1"
    Public id_sample_del_rec As String = "-1"
    Public id_report_status As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_sample_del_rec_det_list As New List(Of String)
    Public id_sample_del_rec_det_drawer_list As New List(Of String)
    Public id_sample_del As String = "-1"
    Dim is_scan As Boolean = False
    Dim id_comp_cat_wh As String = "-1"


    Private Sub FormViewSampleDelRec_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormViewSampleDelRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        GroupControlListItem.Enabled = True
        GroupControlDrawerDetail.Enabled = True
        GroupControlScannedItem.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        XTPInboundScanNew.PageEnabled = True

        'query view based on edit id's
        Dim query_c As ClassSampleDelRec = New ClassSampleDelRec()
        Dim query As String = query_c.queryMain("AND rec.id_sample_del_rec=''" + id_sample_del_rec + "'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_sample_del = data.Rows(0)("id_sample_del").ToString
        id_sample_del_rec = data.Rows(0)("id_sample_del_rec").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
        TxtNumber.Text = data.Rows(0)("sample_del_rec_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sample_del_rec_datex").ToString, 0)
        MENote.Text = data.Rows(0)("sample_del_rec_note").ToString
        TxtPLCategory.Text = data.Rows(0)("pl_category").ToString
        TxtSampleDelNumber.Text = data.Rows(0)("sample_del_number").ToString

        ''detail2
        viewDetailBC()
        viewDetail()
        viewDetailDrawer()
        allow_status()
    End Sub

    Sub viewSampleDelDet()
        Dim query_c As ClassSampleDel = New ClassSampleDel()
        Dim query As String = query_c.queryDetail(id_sample_del)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim id_param As String = ""
        Dim query_c As ClassSampleDelRec = New ClassSampleDelRec()
        Dim query As String = query_c.queryDetail(id_sample_del_rec)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_del_rec_det_list.Add(data.Rows(i)("id_sample_del_rec_det").ToString)
            For j As Integer = 0 To data.Rows(i)("sample_del_rec_det_qty") - 1
                GVBarcode.AddNewRow()
                GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample"))
                GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code"))
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            Next
        Next
        GCItemList.DataSource = data
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    Sub viewDetailDrawer()
        Dim query As String = ""
        query += "SELECT rec_det.id_sample_del_det, drw.id_sample_del_rec_det_drawer, drw.id_sample_price, drw.sample_price, "
        query += "drw.sample_del_rec_det_drawer_qty, drw.sample_del_rec_det_drawer_qty_stored "
        query += "FROM tb_sample_del_rec_det_drawer drw "
        query += "INNER JOIN tb_sample_del_rec_det rec_det ON drw.id_sample_del_rec_det = rec_det.id_sample_del_rec_det "
        query += "WHERE rec_det.id_sample_del_rec = '" + id_sample_del_rec + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
    End Sub

    Sub viewDetailBC()
        Dim query As String = "SELECT ('0') AS id_sample, ('') AS code, ('') AS no, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.DeleteSelectedRows()
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        GVItemList.OptionsCustomization.AllowGroup = True

        'Btn Storage
        XTPInboundItemNew.PageEnabled = True
    End Sub

    '------------GRID ITEM LIST
    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim id_sample_del_detx As String = "-1"
        Dim id_samplex As String = "-1"
        Try
            id_sample_del_detx = GVItemList.GetFocusedRowCellValue("id_sample_del_det").ToString
        Catch ex As Exception
        End Try

        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        GVDrawer.ActiveFilterString = "[id_sample_del_det]='" + id_sample_del_detx + "'"
        GVBarcode.ActiveFilterString = "[id_sample]='" + id_samplex + "'"
    End Sub

    '------------BARCODE
    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
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

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        'CEK BARCODE
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim id_sample As String = ""


        'check available code
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Dim code As String = GVItemList.GetRowCellValue(i, "code").ToString
            id_sample = GVItemList.GetRowCellValue(i, "id_sample").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_sample", id_sample)
            countQty(id_sample)
            newRowsBc()
        End If
        Cursor = Cursors.Default
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

    Sub countQty(ByVal id_sample_param As String)
        Dim tot As Decimal = 0.0
        Dim jum_amount_ret As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_sample As String = GVBarcode.GetRowCellValue(i, "id_sample").ToString
            If id_sample = id_sample_param Then
                tot = tot + 1.0
            End If
        Next

        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sample", id_sample_param)
        GVItemList.SetFocusedRowCellValue("sample_del_rec_det_qty", tot)
        GVItemList.SetFocusedRowCellValue("sample_del_rec_det_amount_ret", tot * Decimal.Parse(GVItemList.GetFocusedRowCellValue("sample_ret_price").ToString))

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
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

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GVItemList.RowCount < 1 Then
            errorCustom("Please add product required !")
        Else
            startScan()
        End If
    End Sub

    Sub startScan()
       
    End Sub

    Sub stopScan()
        
    End Sub


    Sub allowDelete()
       
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "61"
        FormReportMark.id_report = id_sample_del_rec
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class