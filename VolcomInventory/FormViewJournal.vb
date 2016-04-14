Public Class FormViewJournal
    Public id_trans As String = "-1"

    Private Sub FormViewJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT a.id_user,a.acc_trans_number,DATE_FORMAT(a.date_created,'%Y-%m-%d') as date_created,a.acc_trans_note,id_report_status FROM tb_a_acc_trans a WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)
        TENumber.Text = data.Rows(0)("acc_trans_number").ToString
        Dim strDate As String = data.Rows(0)("date_created").ToString
        TEDate.Text = view_date_from(strDate, 0)
        MENote.Text = data.Rows(0)("acc_trans_note").ToString
        view_det()
    End Sub
    Sub view_det()
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note,a.report_mark_type,a.id_report FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
    End Sub
    Private Sub GVJournalDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVJournalDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_trans
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "36"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub FormViewJournal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SMViewTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewTransaction.Click
        If Not GVJournalDet.GetFocusedRowCellValue("report_mark_type").ToString = "" And Not GVJournalDet.GetFocusedRowCellValue("id_report").ToString = "" Then
            Dim show_popup As ClassShowPopUp = New ClassShowPopUp()
            show_popup.id_report = GVJournalDet.GetFocusedRowCellValue("id_report").ToString
            show_popup.report_mark_type = GVJournalDet.GetFocusedRowCellValue("report_mark_type").ToString
            show_popup.is_payment = "1"
            show_popup.show()
        End If
    End Sub

    Private Sub GVJournalDet_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVJournalDet.PopupMenuShowing
        If GVJournalDet.RowCount > 0 Then
            If GVJournalDet.IsGroupRow(GVJournalDet.FocusedRowHandle) Or GVJournalDet.GetFocusedRowCellValue("id_report").ToString = "" Or GVJournalDet.GetFocusedRowCellValue("report_mark_type").ToString = "" Then
                SMViewTransaction.Enabled = False
            Else
                SMViewTransaction.Enabled = True
            End If
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                BalanceMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub
End Class