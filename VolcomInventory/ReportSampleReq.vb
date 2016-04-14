Imports DevExpress.XtraReports.UI

Public Class ReportSampleReq
    Public Shared id_sample_requisition As String

    Private Sub ReportSampleReq_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = ""
        query += "SELECT a.id_user, a.id_sample_requisition, a.sample_requisition_date, a.sample_requisition_duration, "
        query += "a.sample_requisition_note, a.sample_requisition_number, (c.comp_name) AS comp_from,  (c.id_comp) AS id_comp_from, (c.comp_number) AS comp_code_contact_from, (b.id_comp_contact) AS id_comp_contact_from, "
        'query += "(e.comp_name) AS comp_to, (e.id_comp) AS id_comp_to, (e.comp_number) AS comp_code_contact_to, (d.id_comp_contact) AS id_comp_contact_to, (e.address_primary) AS comp_address_contact_to, "
        query += " a.id_report_status, DATE_FORMAT(a.sample_requisition_date,'%Y-%m-%d') as sample_requisition_datex,cod_det.code_detail_name as division  "
        query += "FROM tb_sample_requisition a INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact "
        query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=a.id_division "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        'query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        'query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
        query += "WHERE a.id_sample_requisition = '" + id_sample_requisition + "' "
        query += "ORDER BY a.id_sample_requisition DESC "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LDivision.Text = data.Rows(0)("division").ToString
        LabelFrom.Text = data.Rows(0)("comp_from").ToString
        LabelFromUser.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
        'TxtNameFrom.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
        'TxtCodeDept.Text = get_user_identify(data.Rows(0)("id_user").ToString, 5)
        LabelFromDepartement.Text = get_user_identify(data.Rows(0)("id_user").ToString, 4)
        'LabelTo.Text = data.Rows(0)("comp_to").ToString
        'LabelAddress.Text = data.Rows(0)("comp_address_contact_to").ToString
        'Dim start_date_arr() As String = data.Rows(0)("sample_requisition_date").ToString.Split(" ")
        LabelDate.Text = view_date_from(data.Rows(0)("sample_requisition_datex").ToString, 0)
        LabelNo.Text = data.Rows(0)("sample_requisition_number").ToString
        LabelNote.Text = data.Rows(0)("sample_requisition_note").ToString
        LabelDurationDate.Text = data.Rows(0)("sample_requisition_duration").ToString
        viewDetail()
        load_mark_horz("11", id_sample_requisition, "2", "1", XrTable1)
    End Sub
    Sub viewDetail()
        Dim query As String = "CALL view_sample_req_det('" + id_sample_requisition + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
        'GVRetDetail.Columns("name").GroupIndex = 0
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class