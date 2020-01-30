Public Class FormAccClosing
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormReportAccClosing_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormReportAccClosing_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEUntil.EditValue = New DateTime(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month))
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        Try
            DEUntil.EditValue = New DateTime(DEUntil.EditValue.Year, DEUntil.EditValue.Month, Date.DaysInMonth(DEUntil.EditValue.Year, DEUntil.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Dim query As String = "SELECT trx.id_acc_trans,trx.`acc_trans_number`,SUM(trxd.`debit`) AS debit,SUM(trxd.credit) AS credit,IF(SUM(trxd.`debit`)!=SUM(trxd.credit),'Not Balance',IF(SUM(trxd.`debit`)<=0,'Value zero','Ok')) AS sts FROM tb_a_acc_trans_det trxd
INNER JOIN tb_a_acc_trans trx ON trxd.`id_acc_trans`=trx.`id_acc_trans`
WHERE trx.`is_close`='2' AND trx.`date_reference`<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'
GROUP BY trxd.`id_acc_trans`
HAVING NOT sts='Ok'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            GCClosing.DataSource = data
            GVClosing.BestFitColumns()
        End If
    End Sub
End Class