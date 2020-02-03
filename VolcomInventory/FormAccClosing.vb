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
        Dim query As String = "SELECT trx.id_acc_trans,trxd.id_report,trxd.report_number,trxd.report_mark_type,emp.`employee_name`,trx.`date_created`,trx.`date_reference`,bt.`bill_type`,trx.`acc_trans_number`,SUM(trxd.`debit`) AS debit,SUM(trxd.credit) AS credit,IF(SUM(trxd.`debit`)!=SUM(trxd.credit),'Not Balance',IF(SUM(trxd.`debit`)<=0,'Value zero','Ok')) AS sts 
FROM tb_a_acc_trans_det trxd
INNER JOIN tb_a_acc_trans trx ON trxd.`id_acc_trans`=trx.`id_acc_trans`
INNER JOIN `tb_lookup_bill_type` bt ON bt.`id_bill_type`=trx.`id_bill_type`
INNER JOIN tb_m_user usr ON usr.`id_user`=trx.`id_user`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE trx.`is_close`='2' AND trx.`date_reference`<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'
GROUP BY trxd.`id_acc_trans`
HAVING NOT sts='Ok'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCClosing.DataSource = data
        GVClosing.BestFitColumns()

        If data.Rows.Count > 0 Then
            PCCloseAndGenerate.Visible = False
        Else
            PCCloseAndGenerate.Visible = True
        End If
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVClosing.RowCount > 0 Then
            Dim p As ClassShowPopUp = New ClassShowPopUp()
            p.id_report = GVClosing.GetFocusedRowCellValue("id_acc_trans").ToString
            p.report_mark_type = "36"
            p.show()
        End If
    End Sub

    Private Sub ViewReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewReportToolStripMenuItem.Click
        If GVClosing.RowCount > 0 Then
            Dim p As ClassShowPopUp = New ClassShowPopUp()
            p.id_report = GVClosing.GetFocusedRowCellValue("id_report").ToString
            p.report_mark_type = GVClosing.GetFocusedRowCellValue("report_mark_type").ToString
            p.show()
        End If
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        'log start
        Dim query As String = "INSERT INTO `tb_closing_log`(date_until,date_closing,note) VALUES('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "',NOW(),'Closing Start')"
        execute_non_query(query, True, "", "", "", "")

        'pindah saldo profit and loss ke laba tahun berjalan, jika akhir tahun pindah ke laba ditahan



        'closing
        query = "UPDATE tb_a_acc_trans trx SET trx.is_close='1' WHERE trx.`is_close`='2' AND trx.`date_reference`<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & ""
        execute_non_query(query, True, "", "", "", "")
        'log end
        query = "INSERT INTO `tb_closing_log`(date_until,date_closing,note) VALUES('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "',NOW(),'Closing End')"
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class