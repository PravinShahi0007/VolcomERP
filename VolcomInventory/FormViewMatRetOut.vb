Public Class FormViewMatRetOut
    Public action As String
    Public id_mat_purc_ret_out As String
    Public id_mat_purc As String
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_mat_purc_det_list, id_mat_purc_ret_out_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String
    Private Sub FormViewMatRetOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        Try
            Dim query As String = "SELECT a.id_report_status, a.id_mat_purc, a.id_mat_purc_ret_out, a.mat_purc_ret_out_date, "
            query += "a.mat_purc_ret_out_due_date, a.mat_purc_ret_out_note, a.mat_purc_ret_out_number,  "
            query += "b.mat_purc_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
            query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to "
            query += "FROM tb_mat_purc_ret_out a "
            query += "INNER JOIN tb_mat_purc b ON a.id_mat_purc = b.id_mat_purc "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "WHERE a.id_mat_purc_ret_out='" + id_mat_purc_ret_out + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtOrderNumber.Text = data.Rows(0)("mat_purc_number").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_from").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            Dim start_date_arr() As String = data.Rows(0)("mat_purc_ret_out_date").ToString.Split(" ")
            DERet.Text = start_date_arr(0).ToString
            Dim start_due_date_arr() As String = data.Rows(0)("mat_purc_ret_out_due_date").ToString.Split(" ")
            DERetDueDate.Text = start_due_date_arr(0).ToString
            TxtRetOutNumber.Text = data.Rows(0)("mat_purc_ret_out_number").ToString
            MENote.Text = data.Rows(0)("mat_purc_ret_out_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_mat_purc = data.Rows(0)("id_mat_purc").ToString
        Catch ex As Exception
            errorConnection()
        End Try
        viewDetailReturn()
    End Sub
    Sub viewDetailReturn()
        Dim query As String = "CALL view_return_out_mat('" + id_mat_purc_ret_out + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_mat_purc_ret_out
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "18"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_mat_purc_ret_out
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "18"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class