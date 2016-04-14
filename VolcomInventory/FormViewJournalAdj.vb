Public Class FormViewJournalAdj 
    Public id_trans_adj As String = "-1"
    Public id_trans As String = "-1"
    Public id_report_status_g As String = "1"

    Private Sub FormViewJournalAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT b.acc_trans_number,a.id_acc_trans,a.acc_trans_adj_number,DATE_FORMAT(a.date_created,'%Y-%m-%d') as date_created,a.id_user,a.acc_trans_adj_note,a.id_report_status FROM tb_a_acc_trans_adj a INNER JOIN tb_a_acc_trans b ON a.id_acc_trans=b.id_acc_trans WHERE a.id_acc_trans_adj='" & id_trans_adj & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_report_status_g = data.Rows(0)("id_report_status").ToString

        TEJournalNumber.Text = data.Rows(0)("acc_trans_number").ToString
        id_trans = data.Rows(0)("id_acc_trans").ToString

        TEUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)

        TENumber.Text = data.Rows(0)("acc_trans_adj_number").ToString
        Dim strDate As String = data.Rows(0)("date_created").ToString
        TEDate.Text = view_date_from(strDate, 0)
        MENote.Text = data.Rows(0)("acc_trans_adj_note").ToString
        view_det()
    End Sub
    Sub view_det()
        Dim query As String = "SELECT a.id_acc_trans_adj_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_adj_det_note as note FROM tb_a_acc_trans_adj_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc WHERE a.id_acc_trans_adj='" & id_trans_adj & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
    End Sub
    Private Sub GVJournalDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVJournalDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.is_view = "1"
        FormReportMark.id_report = id_trans_adj
        FormReportMark.report_mark_type = "40"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub FormViewJournal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class