Public Class FormPopUpJournal 
    Public id_acc_trans As String = "-1"
    Private Sub FormPopUpJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_jurnal()
        If Not id_acc_trans = "-1" Then
            GVAccTrans.FocusedRowHandle = find_row(GVAccTrans, "id_acc_trans", id_acc_trans)
        End If
    End Sub

    Private Sub FormPopUpJournal_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Sub view_jurnal()
        Dim query As String = ""
        query = "SELECT t.id_report_status,f.report_status,t.id_acc_trans,t.acc_trans_number,t.acc_trans_note,i.employee_name,  DATE_FORMAT(t.date_created, '%d %M %Y') AS date_created FROM tb_a_acc_trans t "
        query += "INNER JOIN tb_m_user h ON t.id_user = h.id_user "
        query += "INNER JOIN tb_m_employee i ON h.id_employee = i.id_employee "
        query += "INNER JOIN tb_lookup_report_status f ON t.id_report_status = f.id_report_status "
        query += "ORDER BY t.id_acc_trans DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAccTrans.DataSource = data
        If data.Rows.Count > 0 Then
            view_det(GVAccTrans.GetFocusedRowCellValue("id_acc_trans").ToString)
        End If
    End Sub

    Sub view_det(ByVal id_acc_transx As String)
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc WHERE a.id_acc_trans='" & id_acc_transx & "'"
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
        Close()
    End Sub
End Class