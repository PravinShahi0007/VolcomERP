Public Class FormMatStockOpnameResultDet
    Public id_mat_so As String = "-1"
    Public id_comp_contact As String = "-1"
    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"
    Public id_report_status As String = "1"
    Dim datax As DataTable
    Private Sub FormMatStockOpnameResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        actionLoad()
    End Sub
    Sub actionLoad()

        Dim query As String = "SELECT a.id_mat_so,a.id_comp_contact,a.mat_so_number,a.id_report_status,DATE_FORMAT(a.mat_so_date_created,'%Y-%m-%d') AS mat_so_date_created,DATE_FORMAT(a.mat_so_last_update,'%Y-%m-%d') AS mat_so_last_update,b.report_status,a.id_lock FROM tb_mat_so a INNER JOIN tb_lookup_report_status b ON b.id_report_status=a.id_report_status WHERE a.id_mat_so='" & id_mat_so & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TESoNumber.Text = data.Rows(0)("mat_so_number").ToString
        TEDate.Text = view_date_from(data.Rows(0)("mat_so_date_created").ToString, 0)
        TELastUpd.Text = view_date_from(data.Rows(0)("mat_so_last_update").ToString, 0)

        id_report_status = data.Rows(0)("id_report_status").ToString

        id_comp_contact = data.Rows(0)("id_comp_contact").ToString
        TESourceName.Text = get_company_x(get_id_company(id_comp_contact), "1")
        TESourceCode.Text = get_company_x(get_id_company(id_comp_contact), "2")
        MESourceAddress.Text = get_company_x(get_id_company(id_comp_contact), "3")

        id_report_status = data.Rows(0)("id_report_status").ToString

        GCMatSO.Enabled = True

        allow_status()
        view_inventory_mat()
    End Sub
    Sub allow_status()
        If check_print_report_status(id_report_status) Then
            BPrint.Visible = True
            BPrintList.Visible = True
        Else
            BPrint.Visible = False
            BPrintList.Visible = False
        End If
    End Sub
    Private Sub BRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        view_inventory_mat()
    End Sub
    Sub view_inventory_mat()
        Try
            Dim queryx As String = "SELECT m_so_d.id_mat_so_det,m_so_d.mat_so_det_qty,m_so_d.mat_so_det_note,m_so_d.id_mat_det,m_so_d.id_pl_category,l_pl_cat.pl_category FROM tb_mat_so_det m_so_d INNER JOIN tb_lookup_pl_category l_pl_cat ON m_so_d.id_pl_category=l_pl_cat.id_pl_category WHERE m_so_d.id_mat_so='" & id_mat_so & "'"
            datax = execute_query(queryx, -1, True, "", "", "", "")
            GCMatSO.DataSource = datax
            '
            Dim query As String
            '
            query = "CALL view_stock_mat_so_result('" & id_mat_so & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatList.DataSource = data
            If data.Rows.Count > 0 Then
                view_so(GVMatList.GetFocusedRowCellValue("id_mat_det").ToString)
            End If
            '
            query = "CALL view_mat_so_result_list('" & id_mat_so & "')"
            data = execute_query(query, -1, True, "", "", "", "")
            GCList.DataSource = data
            '
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_image()
        If System.IO.File.Exists(material_image_path & GVMatList.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg") Then
            PictureEdit1.LoadAsync(material_image_path & GVMatList.GetFocusedRowCellDisplayText("id_mat_det").ToString & ".jpg")
        Else
            PictureEdit1.LoadAsync(material_image_path & "default" & ".jpg")
        End If
    End Sub
    Sub view_so(ByVal id_mat_det)
        Dim data_filter As DataRow() = datax.Select("[id_mat_det] ='" & id_mat_det & "'")
        Dim x As DataTable
        x = datax.Copy
        x.Clear()
        For Each datarowx As DataRow In data_filter
            x.ImportRow(datarowx)
        Next

        GCMatSO.DataSource = x.DefaultView
    End Sub
    Private Sub GVMatList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatList.FocusedRowChanged
        If GVMatList.RowCount > 0 Then
            view_image()
            If Not id_mat_so = "-1" Then 'new
                view_so(GVMatList.GetFocusedRowCellValue("id_mat_det").ToString)
            End If
        End If
    End Sub
    Private Sub GVMatList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVMatSO_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatSO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mat_so
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "52"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportMatStockOpnameSum.id_mat_so = id_mat_so
        Dim Report As New ReportMatStockOpnameSum()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BPrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrintList.Click
        print(GCList, "Detail Stock Opname")
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewAll.Click
        FormMatStockOpnameResultPrice.id_mat_so = id_mat_so
        FormMatStockOpnameResultPrice.ShowDialog()
    End Sub
End Class