Public Class FormAccountingTrs
    Public id_pop_up As String = "-1"
    Public id_acc As String = "-1"
    Public id_acc_child As String = "-1"

    Public fromdate As String = "0001-01-01"
    Public enddate As String = "9999-01-01"

    Dim data As DataTable

    Private Sub FormAccoutningTrs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_pop_up = "1" Then
            TEAcc.Text = FormAccounting.TreeList1.FocusedNode.GetValue("acc_name").ToString()
            TEDesc.Text = FormAccounting.TreeList1.FocusedNode.GetValue("acc_description").ToString()
            view_det(fromdate, enddate, "1")
        ElseIf id_pop_up = "2" Then
            TEAcc.Text = FormAccountingSummary.TreeList1.FocusedNode.GetValue("acc_name").ToString()
            TEDesc.Text = FormAccountingSummary.TreeList1.FocusedNode.GetValue("acc_description").ToString()
            view_det(fromdate, enddate, "1")
        End If
        WindowState = FormWindowState.Maximized
    End Sub
    Sub view_det(ByVal start_date As String, ByVal end_date As String, ByVal is_full As String)
        Dim query As String = "SELECT id_acc_trans,acc_trans_number,date_created,id_acc_trans_det,id_acc,acc_name,acc_description,debit,credit,note,id_report,entry,number_adj "
        query += "FROM "
        query += "(SELECT c.id_acc_trans,c.acc_trans_number,c.date_created,a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) AS debit,CAST(a.credit AS DECIMAL(13,2)) AS credit,a.acc_trans_det_note AS note "
        query += ",'Normal' AS 'entry',a.id_acc_trans AS id_report,'' AS number_adj "
        query += "FROM tb_a_acc_trans_det a "
        query += "INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc "
        query += "INNER JOIN tb_a_acc_trans c ON c.id_acc_trans=a.id_acc_trans "
        query += "UNION "
        query += "SELECT c.id_acc_trans,d.acc_trans_number,c.date_created,a.id_acc_trans_adj_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) AS debit,CAST(a.credit AS DECIMAL(13,2)) AS credit,a.acc_trans_adj_det_note AS note  "
        query += ",'Adjustment' AS 'entry',a.id_acc_trans_adj AS id_report,c.acc_trans_adj_number AS number_adj "
        query += "FROM tb_a_acc_trans_adj_det a  "
        query += "INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc  "
        query += "INNER JOIN tb_a_acc_trans_adj c ON c.id_acc_trans_adj=a.id_acc_trans_adj "
        query += "INNER JOIN tb_a_acc_trans d ON d.id_acc_trans=c.id_acc_trans "
        query += ") uni "
        query += "WHERE (id_acc_trans IN ( "
        query += "SELECT a.id_acc_trans FROM tb_a_acc_trans_det a "
        query += "INNER JOIN tb_a_acc_trans b ON a.id_acc_trans=b.id_acc_trans "
        query += "WHERE a.id_acc IN (" & id_acc_child & ") AND (DATE(date_created) <= '" & end_date & "') AND (DATE(date_created) >= '" & start_date & "') "
        query += "GROUP BY a.id_acc_trans ) "
        query += "OR id_acc_trans IN ( "
        query += "SELECT b.id_acc_trans FROM tb_a_acc_trans_adj_det a "
        query += "INNER JOIN tb_a_acc_trans_adj b ON a.id_acc_trans_adj=b.id_acc_trans_adj "
        query += "WHERE a.id_acc IN (" & id_acc_child & ") AND (DATE(date_created) <= '" & end_date & "') AND (DATE(date_created) >= '" & start_date & "') "
        query += "GROUP BY b.id_acc_trans )) "
        If is_full = "2" Then
            query += "AND id_acc IN (" & id_acc_child & ") "
        End If
        query += "ORDER BY uni.id_acc_trans,uni.date_created "
        data = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
        GVJournalDet.ExpandAllGroups()
    End Sub
    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        If DEFrom.Text = "" Then
            fromdate = "0001-01-01"
        Else
            fromdate = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyy-MM-dd")
        End If
        If DETo.Text = "" Then
            enddate = "9999-01-01"
        Else
            enddate = DateTime.Parse(DETo.EditValue.ToString).ToString("yyy-MM-dd")
        End If
        If CEShowAdj.Checked = True Then
            view_det(fromdate, enddate, "1")
        Else
            view_det(fromdate, enddate, "2")
        End If
    End Sub

    Private Sub CEShowAdj_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEShowAdj.CheckedChanged
        Dim id_acc_trans_focus As String = ""
        If GVJournalDet.IsGroupRow(GVJournalDet.FocusedRowHandle) Then
            id_acc_trans_focus = ""
        Else
            id_acc_trans_focus = GVJournalDet.GetFocusedRowCellValue("id_acc_trans").ToString
        End If
        '
        If CEShowAdj.Checked = True Then 'full
            view_det(fromdate, enddate, "1")
        Else 'only account related
            view_det(fromdate, enddate, "2")
        End If
        '
        If Not id_acc_trans_focus = "" Then
            GVJournalDet.FocusedRowHandle = find_row(GVJournalDet, "id_acc_trans", id_acc_trans_focus)
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        print(GCJournalDet, "COA Transaction - " & TEAcc.Text & " - " & TEDesc.Text)
    End Sub

    Private Sub FormAccoutningTrs_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SMViewTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewTransaction.Click
        If GVJournalDet.GetFocusedRowCellValue("entry").ToString = "Adjustment" Then
            'adjustment
            FormViewJournalAdj.id_trans_adj = GVJournalDet.GetFocusedRowCellValue("id_report").ToString
            FormViewJournalAdj.ShowDialog()
        Else
            'normal
            FormViewJournal.id_trans = GVJournalDet.GetFocusedRowCellValue("id_report").ToString
            FormViewJournal.ShowDialog()
        End If
    End Sub

    Private Sub GVJournalDet_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVJournalDet.PopupMenuShowing
        If GVJournalDet.RowCount > 0 Then
            If GVJournalDet.IsGroupRow(GVJournalDet.FocusedRowHandle) Then
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