Public Class FormViewSampleReturnPL
    Public action As String = ""
    Public id_sample_pl As String = "-1"
    Public id_report_status As String = "-1"
    Public id_sample_pl_det_list As New List(Of String)
    Public id_comp_contact_to As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_wh_locator As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_drawer As String = "-1"

    Private Sub FormViewSampleReturnPL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        BMark.Enabled = True

        'query view based on edit id's
        Dim query_c As ClassSampleReturnPL = New ClassSampleReturnPL()
        Dim query As String = query_c.queryMain("AND ret.id_sample_pl_ret='" + id_sample_pl + "' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_sample_pl = data.Rows(0)("id_sample_pl_ret").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtNumber.Text = data.Rows(0)("sample_pl_ret_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sample_pl_datex").ToString, 0)
        MENote.Text = data.Rows(0)("sample_pl_ret_note").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_to_code").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_to_name").ToString
        id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
        id_wh_rack = data.Rows(0)("id_wh_rack").ToString
        id_wh_locator = data.Rows(0)("id_wh_locator").ToString
        TxtCodeDrawer.Text = data.Rows(0)("wh_drawer_code").ToString
        TxtNameDrawer.Text = data.Rows(0)("wh_drawer").ToString

        'detail2
        viewDetail()
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sample_pl_ret('" + id_sample_pl + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "89"
        FormReportMark.id_report = id_sample_pl
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormViewSampleReturnPL_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class