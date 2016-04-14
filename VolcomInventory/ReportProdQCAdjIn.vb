Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportProdQCAdjIn
    Public Shared id_adj_in As String = "-1"
    Sub viewDetailQCAdjIn()
        Dim query As String = ""
        query += "CALL view_qc_adj_in('" + id_adj_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
    End Sub
    Sub view_adj_in()
        Dim query As String = "SELECT tb_prod_order_qc_adj_in.id_prod_order,tb_prod_order.prod_order_number,prod_order_qc_adj_in_number,prod_order_qc_adj_in_date,prod_order_qc_adj_in_note,tb_prod_order_qc_adj_in.id_report_status FROM tb_prod_order_qc_adj_in INNER JOIN tb_prod_order ON tb_prod_order.id_prod_order=tb_prod_order_qc_adj_in.id_prod_order WHERE id_prod_order_qc_adj_in='" + id_adj_in + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim datex As Date = data.Rows(0)("prod_order_qc_adj_in_date")

        LNumber.Text = data.Rows(0)("prod_order_qc_adj_in_number").ToString
        LDate.Text = "DATE : " + datex.ToString("dd MMM yyyy")
        LNote.Text = data.Rows(0)("prod_order_qc_adj_in_note").ToString
        LPONumber.Text = data.Rows(0)("prod_order_number").ToString

        viewDetailQCAdjIn()
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub ReportSamplePR_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("72", id_adj_in, "2", "1", XrTable1)
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        view_adj_in()
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        If GVDetail.RowCount > 0 Then
            LTotQty.Text = Decimal.Parse(GVDetail.Columns("qty").SummaryItem.SummaryValue).ToString("N2")
            LTotCost.Text = Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString("N2")
            LSayCurr.Text = ConvertCurrencyToEnglish(Double.Parse(Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString), "1")
        Else
            LTotQty.Text = Decimal.Parse(0).ToString("N2")
            LTotCost.Text = Decimal.Parse(0).ToString("N2")
            LSayCurr.Text = ConvertCurrencyToEnglish(0, "1")
        End If
    End Sub
End Class