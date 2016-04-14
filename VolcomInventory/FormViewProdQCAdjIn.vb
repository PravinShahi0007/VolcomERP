Public Class FormViewProdQCAdjIn
    Public id_adj_in As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_report_status As String = "-1"

    Private Sub FormViewProdQCAdjIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()

        Dim query As String = "SELECT tb_prod_order_qc_adj_in.id_prod_order,tb_prod_order.prod_order_number,prod_order_qc_adj_in_number,prod_order_qc_adj_in_date,prod_order_qc_adj_in_note,tb_prod_order_qc_adj_in.id_report_status FROM tb_prod_order_qc_adj_in INNER JOIN tb_prod_order ON tb_prod_order.id_prod_order=tb_prod_order_qc_adj_in.id_prod_order WHERE id_prod_order_qc_adj_in='" + id_adj_in + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TxtAdjNumber.Text = data.Rows(0)("prod_order_qc_adj_in_number").ToString
        TxtAdjDate.EditValue = data.Rows(0)("prod_order_qc_adj_in_date")
        MENote.Text = data.Rows(0)("prod_order_qc_adj_in_note").ToString
        TEProdOrderNumber.Text = data.Rows(0)("prod_order_number").ToString

        id_prod_order = data.Rows(0)("id_prod_order").ToString

        LEReportStatus.EditValue = data.Rows(0)("id_report_status").ToString

        viewDetailReturn()
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString), "1")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_adj_in
        FormReportMark.report_mark_type = "72"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_adj_in
        FormDocumentUpload.report_mark_type = "72"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        query += "CALL view_qc_adj_in('" + id_adj_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
    End Sub

    Sub calculate()
        For i As Integer = 0 To GVDetail.RowCount - 1
            GVDetail.SetRowCellValue(i, "amount", (GVDetail.GetRowCellValue(i, "cost") * GVDetail.GetRowCellValue(i, "qty")))
        Next
        GVDetail.RefreshData()
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString), "1")
    End Sub

    Private Sub GVDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDetail.CellValueChanged
        If e.Column.FieldName.ToString = "qty" Then
            calculate()
        End If
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class