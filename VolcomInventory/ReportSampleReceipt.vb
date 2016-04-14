Public Class ReportSampleReceipt
    Public pl_sample_purc_number As String
    Public receipt_sample_number As String
    Public receipt_sample_date As String
    Public source As String
    Public comp_from As String
    Public Shared id_pl_sample_purc As String
    Public receipt_sample_note As String
    Dim cond_matched As Boolean = True
    'View Detail PL
    Sub viewDetailPL()
        Try
            Dim query As String = "CALL view_pl_sample('" + id_pl_sample_purc + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSummary.DataSource = data
            For i As Integer = 0 To (data.Rows.Count - 1)
                If data.Rows(i)("count_receipt_sample_db").ToString <> data.Rows(i)("qty_issue").ToString Then
                    cond_matched = False
                End If
                data.Rows(i)("count_receipt_sample") = data.Rows(i)("count_receipt_sample_db")
            Next
        Catch ex As Exception
            'no action  
        End Try
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        viewDetailPL()
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = "SELECT a.id_pl_sample_purc, a2.id_sample_purc_rec,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_purc_date, a.pl_sample_purc_note, a.pl_sample_purc_number, g.sample_purc_rec_number,b.pl_category, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from,(f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to,(f.address_primary) AS comp_address_to, a.id_pl_category, a.id_report_status, g.sample_purc_rec_number, "
        query += "a.receipt_sample_date, a.receipt_sample_note, a.receipt_sample_number, a.id_report_status_rec "
        query += "FROM tb_pl_sample_purc a "
        query += "INNER JOIN tb_pl_sample_purc_rec a2 ON a.id_pl_sample_purc = a2.id_pl_sample_purc "
        query += "INNER JOIN tb_lookup_pl_category b ON a.id_pl_category = b.id_pl_category  "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_sample_purc_rec g ON g.id_sample_purc_rec = a2.id_sample_purc_rec "
        query += "WHERE a.id_pl_sample_purc = '" + id_pl_sample_purc + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelNo.Text = data.Rows(0)("receipt_sample_number").ToString
        LabelFrom.Text = data.Rows(0)("comp_code_from").ToString
        'MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
        LabelPL.Text = data.Rows(0)("pl_sample_purc_number").ToString
        Dim start_date_arr() As String = data.Rows(0)("receipt_sample_date").ToString.Split(" ")
        LabelDate.Text = start_date_arr(0)
        'LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)
        LabelNote.Text = data.Rows(0)("receipt_sample_note").ToString
        LabelSource.Text = data.Rows(0)("pl_category").ToString
        If cond_matched Then
            LabelStatus.Text = "Matched"
        Else
            LabelStatus.Text = "Not Matched"
        End If
    End Sub

    Private Sub ReportSampleReceipt_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("7", id_pl_sample_purc, "2", "1", XrTable1)
    End Sub
End Class