Public Class ReportSampleReturn
    Public Shared id_sample_return As String
    Private Sub ReportSampleReturn_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "SELECT g.pl_sample_del_number, a.id_sample_return, a.id_comp_contact_from , a.id_comp_contact_to,a.sample_return_date, DATE_FORMAT(a.sample_return_date,'%Y-%m-%d') as sample_return_datex,a.sample_return_note, a.sample_return_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_t, a.id_report_status,cod_det.code_detail_name as division "
        query += "FROM tb_sample_return a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp  "
        query += "INNER JOIN tb_pl_sample_del g ON g.id_pl_sample_del = a.id_pl_sample_del "
        query += "INNER JOIN tb_sample_requisition h ON h.id_sample_requisition = g.id_sample_requisition "
        query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=h.id_division "
        query += "WHERE a.id_sample_return = '" + id_sample_return + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'tampung ke form
        LDivision.Text = data.Rows(0)("division").ToString
        LabelNo.Text = data.Rows(0)("sample_return_number").ToString
        LabelFrom.Text = data.Rows(0)("comp_name_from").ToString
        LabelTo.Text = data.Rows(0)("comp_name_to").ToString
        LabelDate.Text = view_date_from(data.Rows(0)("sample_return_datex").ToString, 0)
        LabelNote.Text = data.Rows(0)("sample_return_note").ToString
        LabelSRSNumber.Text = data.Rows(0)("pl_sample_del_number").ToString

        'detail 
        viewDetailReturn()

        'mark
        load_mark_horz("14", id_sample_return, "2", "1", XrTable1)
    End Sub
    Sub viewDetailReturn()
        Dim query As String = ""
        query += "CALL view_sample_return('" + id_sample_return + "')"
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