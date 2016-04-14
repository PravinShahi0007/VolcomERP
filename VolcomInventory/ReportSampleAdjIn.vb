Public Class ReportSampleAdjIn
    Public Shared id_adj_in_sample As String
    Dim currency As String
    Private Sub ReportSampleAdjIn_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'Fetch from db main
        Dim query As String = "SELECT *, DATE_FORMAT(a.adj_in_sample_date, '%Y-%m-%d') AS adj_in_sample_datex FROM tb_adj_in_sample a "
        query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "WHERE a.id_adj_in_sample = '" + id_adj_in_sample + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        ''tampung ke form
        LabelNo.Text = data.Rows(0)("adj_in_sample_number").ToString
        LabelDate.Text = view_date_from(data.Rows(0)("adj_in_sample_datex").ToString, 0)
        LabelNote.Text = data.Rows(0)("adj_in_sample_note").ToString
        currency = data.Rows(0)("currency").ToString

        'Detail
        viewDetailReturn()

        'Mark
        load_mark_horz("20", id_adj_in_sample, "2", "1", XrTable1)
    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        query += "CALL view_sample_adj_in('" + id_adj_in_sample + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.DisplayFormat = currency + " {0:n2} "
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class