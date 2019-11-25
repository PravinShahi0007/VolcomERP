Public Class FormPopUpJournal
    Public id_acc_trans As String = "-1"

    Private Sub FormPopUpJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_billing_type(LEBillingView)
        load_rmt()

    End Sub

    Private Sub FormPopUpJournal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub load_rmt()
        Dim query As String = "SELECT 'ALL' AS report_mark_type,'ALL' AS report_mark_type_name
UNION
SELECT report_mark_type,report_mark_type_name FROM tb_lookup_report_mark_type"
        viewSearchLookupQuery(SLEReportMarkType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Sub load_billing_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT 'ALL' AS id_bill_type,'ALL' AS bill_type
UNION
SELECT id_bill_type,bill_type FROM tb_lookup_bill_type WHERE is_active='1'"
        viewLookupQuery(lookup, query, 0, "bill_type", "id_bill_type")
    End Sub

    Sub view_jurnal()
        Dim q_where As String = ""
        '
        If Not TEReportNumber.Text = "" Then
            q_where = " AND det.report_number='" & TEReportNumber.Text & "'"
        End If
        '
        If Not LEBillingView.EditValue.ToString = "ALL" Then
            q_where = " AND t.id_bill_type='" & LEBillingView.EditValue.ToString & "'"
        End If
        '
        If Not SLEReportMarkType.EditValue.ToString = "ALL" Then
            q_where = " AND det.report_mark_type='" & SLEReportMarkType.EditValue.ToString & "'"
        End If
        '
        Dim query As String = ""
        query = "SELECT t.id_report_status,f.report_status,t.id_acc_trans,t.acc_trans_number,t.acc_trans_note,i.employee_name,  DATE_FORMAT(t.date_created, '%d %M %Y') AS date_created 
                ,det.id_report,det.report_mark_type,det.report_number
                ,bt.`bill_type`
                FROM tb_a_acc_trans t 
                INNER JOIN tb_m_user h ON t.id_user = h.id_user 
                INNER JOIN tb_m_employee i ON h.id_employee = i.id_employee 
                INNER JOIN tb_lookup_report_status f ON t.id_report_status = f.id_report_status 
                INNER JOIN tb_lookup_bill_type bt ON bt.`id_bill_type`=t.`id_bill_type`
                INNER JOIN 
                (
	                SELECT id_acc_trans,id_report,report_mark_type,report_number FROM tb_a_acc_trans_det
	                GROUP BY id_acc_trans
                ) det ON det.id_acc_trans=t.`id_acc_trans`
                WHERE 1=1 " & q_where & "
                ORDER BY t.id_acc_trans DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAccTrans.DataSource = data
        If data.Rows.Count > 0 Then
            view_det(GVAccTrans.GetFocusedRowCellValue("id_acc_trans").ToString)
        End If
    End Sub

    Sub view_det(ByVal id_acc_transx As String)
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note,a.report_number,a.report_number_ref FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc WHERE a.id_acc_trans='" & id_acc_transx & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
        If Not data.Rows.Count > 0 Then
            BtnSave.Enabled = False
        Else
            BtnSave.Enabled = True
        End If
    End Sub
    Private Sub GVJournalDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVJournalDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVAccTrans_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVAccTrans.FocusedRowChanged
        If GVAccTrans.RowCount > 0 Then
            view_det(GVAccTrans.GetFocusedRowCellValue("id_acc_trans").ToString)
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        FormAccountingJournalAdjDet.id_trans = GVAccTrans.GetFocusedRowCellValue("id_acc_trans").ToString
        FormAccountingJournalAdjDet.TEJournalNumber.Text = GVAccTrans.GetFocusedRowCellValue("acc_trans_number").ToString
        FormAccountingJournalAdjDet.view_reverse()
        FormAccountingJournalAdjDet.id_report = GVAccTrans.GetFocusedRowCellValue("id_report").ToString
        FormAccountingJournalAdjDet.report_mark_type = GVAccTrans.GetFocusedRowCellValue("report_mark_type").ToString
        FormAccountingJournalAdjDet.report_number = GVAccTrans.GetFocusedRowCellValue("report_number").ToString
        Close()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        view_jurnal()
    End Sub
End Class