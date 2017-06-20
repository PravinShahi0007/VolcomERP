Public Class FormWHDelEmptyDet
    Public action As String
    Public id_wh_del_empty As String = "-1"
    Public id_report_status As String
    Public dt As New DataTable
    Public id_pre As String = "-1"
    Public id_wh_drawer As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_do_emp")
    Public is_view As String = "-1"
    Public is_fix As String = "2"

    Private Sub FormWHDelEmptyDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim del As New ClassDelEmpty()
        Dim query As String = del.queryMain("AND del.id_wh_del_empty=" + id_wh_del_empty + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
        DETrans.EditValue = data.Rows(0)("wh_del_empty_date")
        TxtSalesDelOrderNumber.Text = data.Rows(0)("wh_del_empty_number").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_report_status)
        is_fix = data.Rows(0)("is_fix").ToString

        view_detail()
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Sub view_detail()

    End Sub

    Sub allow_status()
        If is_fix = "1" Then
            BtnSave.Enabled = False
            PanelNavBarcode.Enabled = False
        Else
            BtnSave.Enabled = True
            PanelNavBarcode.Enabled = True
        End If

    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_wh_del_empty
        FormReportMark.report_mark_type = "111"
        FormReportMark.form_origin = Name
        FormReportMark.is_disabled_set_stt = "1"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_wh_del_empty
        FormDocumentUpload.report_mark_type = "111"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class