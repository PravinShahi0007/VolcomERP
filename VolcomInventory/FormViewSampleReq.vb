Public Class FormViewSampleReq 
    Public action As String
    Public id_sample_requisition As String
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_comp_to As String
    Public id_comp_from As String
    Public id_sample_list, id_wh_drawer_list, id_sample_requisition_det_list As New List(Of String)
    Public id_report_status As String

    'Form
    Private Sub FormViewSampleReq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        actionLoad()
    End Sub
    Private Sub FormViewSampleReq_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View Data
    Sub viewBlank()
        Dim query As String = "SELECT ('') AS code, ('0') AS id_sample_requisition_det, ('0') AS id_sample, ('') AS name, ('') AS size, ('') AS uom, ('0') AS sample_requisition_det_qty, ('') AS sample_requisition_det_note,('0') AS qty_all_sample, "
        query += "('0') AS id_comp, ('0') AS id_wh_locator, ('0') AS id_wh_rack, ('0') AS id_wh_drawer, "
        query += "('') AS comp_name, ('') AS wh_locator, ('') AS wh_rack, ('') AS wh_drawer "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    Sub actionLoad()
        'BtnPopContactFrom.Enabled = False
        GroupControlReq.Enabled = True

        Dim query As String = ""
        query += "SELECT a.id_user, a.id_sample_requisition, a.sample_requisition_date, a.sample_requisition_duration, "
        query += "a.sample_requisition_note, a.sample_requisition_number, (c.comp_name) AS comp_from,  (c.id_comp) AS id_comp_from, (c.comp_number) AS comp_code_contact_from, (b.id_comp_contact) AS id_comp_contact_from, "
        'query += "(e.comp_name) AS comp_to, (e.id_comp) AS id_comp_to, (e.comp_number) AS comp_code_contact_to, (d.id_comp_contact) AS id_comp_contact_to, (e.address_primary) AS comp_address_contact_to, "
        query += " a.id_report_status, DATE_FORMAT(a.sample_requisition_date,'%Y-%m-%d') as sample_requisition_datex,cod_det.code_detail_name as division "
        query += "FROM tb_sample_requisition a INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact "
        query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=a.id_division "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        'query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        'query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
        query += "WHERE a.id_sample_requisition = '" + id_sample_requisition + "' "
        query += "ORDER BY a.id_sample_requisition DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEDivision.Text = data.Rows(0)("division").ToString

        TxtCodeFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 2)
        TxtNameFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
        TxtCodeDept.Text = get_user_identify(data.Rows(0)("id_user").ToString, 5)
        TxtNameDept.Text = get_user_identify(data.Rows(0)("id_user").ToString, 4)
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        'id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
        'TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_to").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_from").ToString
        'TxtNameCompTo.Text = data.Rows(0)("comp_to").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        'id_comp_to = data.Rows(0)("id_comp_to").ToString
        'MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
        Dim start_date_arr As String = view_date_from(data.Rows(0)("sample_requisition_datex").ToString, 0)
        DEReq.Text = start_date_arr.ToString
        TxtReqNumber.Text = data.Rows(0)("sample_requisition_number").ToString
        MENote.Text = data.Rows(0)("sample_requisition_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        SPDuration.Text = data.Rows(0)("sample_requisition_duration").ToString

        'Constraint Status
        If id_report_status = "5" Then 'cancel
            BMark.Visible = False
            GVRetDetail.OptionsBehavior.Editable = False
            MENote.Properties.ReadOnly = True
            SPDuration.Properties.ReadOnly = True
        Else
            BMark.Visible = True
            GVRetDetail.OptionsBehavior.Editable = False
            MENote.Properties.ReadOnly = True
            BtnPopContactFrom.Enabled = False
            SPDuration.Properties.ReadOnly = True

        End If
        viewDetail()
    End Sub
    Sub viewDetail()
        Dim query As String = "CALL view_sample_req_det('" + id_sample_requisition + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_requisition
        FormReportMark.report_mark_type = "11"
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
   
    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
    End Sub
    Sub isManipulation()
       
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sample_requisition
        FormDocumentUpload.report_mark_type = "11"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRetDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVRetDetail.RowClick
        isManipulation()
    End Sub

    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        isManipulation()
    End Sub
End Class