Public Class FormAccountingJournal
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Private Sub FormAccountingJournal_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccountingJournal_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAccountingJournal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub
    Sub check_but()
        If XTCJurnal.SelectedTabPageIndex = 0 Then
            If GVAccTrans.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0" 'you will never delete journal, use adjustment.
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
        End If
        
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccountingJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_billing_type(LEBilling)
        check_but()
    End Sub

    Sub view_det(ByVal start_date As String, ByVal end_date As String)
        Dim query As String = "SELECT c.id_acc_trans,c.acc_trans_number,c.date_created,a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc INNER JOIN tb_a_acc_trans c ON c.id_acc_trans=a.id_acc_trans "
        query += " WHERE (DATE(c.date_created) <= '" & end_date & "') AND (DATE(c.date_created) >= '" & start_date & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
        GVJournalDet.ExpandAllGroups()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Dim fromdate As String = ""
        Dim enddate As String = ""

        If DEFrom.Text = "" Then
            DEFrom.DateTime = Now
            fromdate = Now.ToString("yyy-MM-dd")
        Else
            fromdate = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        If DETo.Text = "" Then
            DETo.DateTime = Now
            enddate = Now.ToString("yyy-MM-dd")
        Else
            enddate = DateTime.Parse(DETo.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        view_det(fromdate, enddate)
    End Sub

    Private Sub XTCJurnal_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCJurnal.SelectedPageChanged
        check_but()
    End Sub

    Sub view_entry(ByVal id_type As String, ByVal fromdate As String, ByVal enddate As String)
        Dim query As String = ""
        query = "SELECT t.id_acc, acc.acc_description,bill.bill_type,bill.id_bill_type,t.id_report_status,f.report_status,t.id_acc_trans,t.acc_trans_number,t.acc_trans_note,i.employee_name,  DATE_FORMAT(t.date_created, '%d %M %Y') AS date_created FROM tb_a_acc_trans t "
        query += "INNER JOIN tb_m_user h ON t.id_user = h.id_user "
        query += "INNER JOIN tb_m_employee i ON h.id_employee = i.id_employee "
        query += "INNER JOIN tb_lookup_report_status f ON t.id_report_status = f.id_report_status "
        query += "INNER JOIN tb_lookup_bill_type bill ON bill.id_bill_type=t.id_bill_type "
        query += "INNER JOIN tb_a_acc acc ON acc.id_acc = t.id_acc "
        query += "WHERE t.id_bill_type LIKE '" + id_type + "' AND (DATE(t.date_created) <= '" & enddate & "') AND (DATE(t.date_created) >= '" & fromdate & "')"
        query += "ORDER BY t.id_acc_trans DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAccTrans.DataSource = data
        check_but()
    End Sub

    Private Sub BViewJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewJournal.Click
        Dim fromdate As String = ""
        Dim enddate As String = ""

        If DEFromViewJournal.Text = "" Then
            DEFromViewJournal.DateTime = Now
            fromdate = Now.ToString("yyy-MM-dd")
        Else
            fromdate = DateTime.Parse(DEFromViewJournal.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        If DEToViewJournal.Text = "" Then
            DEToViewJournal.DateTime = Now
            enddate = Now.ToString("yyy-MM-dd")
        Else
            enddate = DateTime.Parse(DEToViewJournal.EditValue.ToString).ToString("yyy-MM-dd")
        End If

        view_entry(LEBilling.EditValue.ToString, fromdate, enddate)
    End Sub
End Class