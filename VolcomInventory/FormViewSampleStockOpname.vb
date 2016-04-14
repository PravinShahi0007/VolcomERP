Public Class FormViewSampleStockOpname 
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_sample_so As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_from As String = "-1"
    Public dt As New DataTable
    Public id_fg_so_wh_det_list As New List(Of String)
    Public id_fg_so_wh_det_counting_list As New List(Of String)
    Dim id_comp_cat_wh As String = "-1"
    Public id_pl_category As String = "-1"
    Public pl_category As String = "-1"
    Dim id_lock As String = "-1"
    Dim is_scan As Boolean = False

    Private Sub FormViewSampleStockOpname_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")
        'call action
        actionLoad()
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_sample")
            dt.Columns.Add("code")
            dt.Columns.Add("sample_price")
        Catch ex As Exception
        End Try

        GroupControlItem.Enabled = True

        'query view based on edit id's
        Dim query As String = ""
        query += "SELECT so.sample_so_note, so.id_lock, so.id_sample_so, so.sample_so_number, so.id_report_status,stat.report_status, "
        query += "DATE_FORMAT(so.sample_so_date_created, '%Y-%m-%d') AS sample_so_date_created, "
        query += "DATE_FORMAT(so.sample_so_last_update, '%Y-%m-%d') AS sample_so_last_update, "
        query += "(comp_contact.id_comp_contact) AS id_comp_contact_from, (comp.id_comp) AS id_comp_from, "
        query += "(comp.comp_number) AS comp_number_from, (comp.comp_name) AS comp_name_from "
        query += "FROM tb_sample_so so "
        query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
        query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
        query += "WHERE so.id_sample_so = '" + id_sample_so + "' "

        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        id_report_status = data.Rows(0)("id_report_status").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        TxtSONumber.Text = data.Rows(0)("sample_so_number").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        DECreated.Text = view_date_from(data.Rows(0)("sample_so_date_created").ToString, 0)
        TxtLastUpdate.Text = view_date_from(data.Rows(0)("sample_so_last_update").ToString, 0)
        MENote.Text = data.Rows(0)("sample_so_note").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_lock = data.Rows(0)("id_lock").ToString

        ''detail2
        viewDetail()
        viewDetailCon()
        view_barcode_list()
    End Sub
    Sub viewDetail()
        Dim id_param As String = ""
        Dim query As String = "CALL view_sample_so_sum('" + id_sample_so + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub
    Sub viewDetailCon()
        Dim id_param As String = ""
        Dim query As String = "CALL view_sample_so_con('" + id_sample_so + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCCondition.DataSource = data
        GVCondition.ExpandAllGroups()
    End Sub
    Sub view_barcode_list()
        Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_sample_so_det, ('0') AS id_sample,('1') AS is_fix, CAST('0' AS DECIMAL(13,2)) AS sample_price, ('0') AS id_pl_category, ('') AS pl_category "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        deleteRowsBc()

        query = "SELECT ('') AS no, "
        query += "c.sample_code as code, ('2') AS is_fix, "
        query += "b.id_sample,b.sample_price,b.id_pl_category, e.pl_category,b.sample_so_det_qty "
        query += "FROM tb_sample_so a "
        query += "INNER JOIN tb_sample_so_det b ON a.id_sample_so = b.id_sample_so "
        query += "INNER JOIN tb_m_sample c ON c.id_sample = b.id_sample "
        query += "INNER JOIN tb_lookup_pl_category e ON e.id_pl_category = b.id_pl_category "
        query += "WHERE b.id_sample_so = '" + id_sample_so + "' "
        data = execute_query(query, -1, True, "", "", "", "")
        'GCBarcode.DataSource = data
        For i As Integer = 0 To data.Rows.Count - 1
            For j As Integer = 0 To data.Rows(i)("sample_so_det_qty") - 1
                GVBarcode.AddNewRow()
                GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample").ToString)
                GVBarcode.SetFocusedRowCellValue("id_pl_category", data.Rows(i)("id_pl_category").ToString)
                GVBarcode.SetFocusedRowCellValue("pl_category", data.Rows(i)("pl_category").ToString)
                GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code").ToString)
                GVBarcode.SetFocusedRowCellValue("sample_price", data.Rows(i)("sample_price").ToString)
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            Next
        Next
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub
    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVCondition_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVCondition.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub
    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        If Not is_scan Then
            viewImages(PictureEdit1, get_setup_field("pic_path_sample") & "\", id_samplex, False)
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSampleStockOpname.id_sample_so = id_sample_so
        Dim Report As New ReportSampleStockOpname()

        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportSampleStockOpname.dt = GCItemList.DataSource

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            ReportSampleStockOpname.dt = GCCondition.DataSource

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVCondition.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
        End If

        'Grid Detail
        ReportStyleGridview(Report.GridView1)

        Report.LSONumber.Text = TxtSONumber.Text
        Report.LWH.Text = TxtCodeCompFrom.Text & " - " & TxtNameCompFrom.Text
        Report.LDateCreated.Text = DECreated.Text
        Report.LDateLastUpdated.Text = TxtLastUpdate.Text

        Report.LabelNote.Text = MENote.Text

        '' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_so
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "64"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
End Class
