Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportAccountingJournalAdj
    Public Shared id_trans_adj As String = "-1"
    Sub view_trans()
        Dim query As String = "SELECT a.id_acc_trans_adj_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_adj_det_note as note FROM tb_a_acc_trans_adj_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc WHERE a.id_acc_trans_adj='" & id_trans_adj & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
    End Sub

    Private Sub GVJournalDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVJournalDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        view_trans()
    End Sub

    Private Sub ReportAccountingJournal_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("40", id_trans_adj, "2", "1", XrTable1)
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = "SELECT a.id_user,b.acc_trans_number,a.acc_trans_adj_number,b.acc_trans_number,DATE_FORMAT(a.date_created,'%Y-%m-%d') as date_created,a.acc_trans_adj_note,a.id_report_status FROM tb_a_acc_trans_adj a INNER JOIN tb_a_acc_trans b ON a.id_acc_trans=b.id_acc_trans WHERE a.id_acc_trans_adj='" & id_trans_adj & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LNumber.Text = data.Rows(0)("acc_trans_adj_number").ToString
        LRef.Text = data.Rows(0)("acc_trans_number").ToString
        LUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
        Dim strDate As String = data.Rows(0)("date_created").ToString
        LDate.Text = view_date_from(strDate, 0)
        LNote.Text = data.Rows(0)("acc_trans_adj_note").ToString
    End Sub
End Class