Public Class ReportSamplePLDel
    Public Shared id_pl_sample_del As String
    Private Sub ReportSamplePLDel_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "SELECT a.pl_sample_del_duration, a.id_sample_requisition, a.id_pl_sample_del ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_t, a.id_report_status, "
        query += "DATE_FORMAT(a.pl_sample_del_date,'%Y-%m-%d') as pl_sample_del_datex,cod_det.code_detail_name as division "
        query += "FROM tb_pl_sample_del a "
        query += "INNER JOIN tb_sample_requisition samp_req ON samp_req.id_sample_requisition=a.id_sample_requisition "
        query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=samp_req.id_division "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "WHERE a.id_pl_sample_del = '" + id_pl_sample_del + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'tampung ke form
        LDivision.Text = data.Rows(0)("division").ToString
        LabelNo.Text = data.Rows(0)("pl_sample_del_number").ToString
        'TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
        LabelFrom.Text = data.Rows(0)("comp_name_from").ToString
        'id_comp_from = data.Rows(0)("id_comp_from").ToString
        'TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
        LabelTo.Text = data.Rows(0)("comp_name_to").ToString
        'id_comp_to = data.Rows(0)("id_comp_to").ToString
        'MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
        LabelSRSNumber.Text = data.Rows(0)("pl_sample_del_number").ToString
        Dim start_date_arr As String = view_date_from(data.Rows(0)("pl_sample_del_datex").ToString, 0)
        LabelDate.Text = start_date_arr
        LabelReturn.Text = view_date_from(data.Rows(0)("pl_sample_del_datex").ToString, data.Rows(0)("pl_sample_del_duration").ToString)
        LabelNote.Text = data.Rows(0)("pl_sample_del_note").ToString
        LabelDuration.Text = data.Rows(0)("pl_sample_del_duration").ToString
        'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        'id_sample_requisition = data.Rows(0)("id_sample_requisition").ToString

        'Fetch db detail
        viewPLSample()

        'mark
        load_mark_horz("10", id_pl_sample_del, "2", "1", XrTable1)
    End Sub
    Sub viewPLSample()
        Dim query As String = "CALL view_pl_sample_del('" + id_pl_sample_del + "', '1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
        'GVDrawer.Columns("name").GroupIndex = 0
    End Sub

    Private Sub GVDrawer_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDrawer.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class