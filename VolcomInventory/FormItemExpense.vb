Public Class FormItemExpense
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormItemExpense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEBBKFrom.EditValue = Now
        DEBBKTo.EditValue = Now
        DEContract.EditValue = Now
        '
        load_unit()
        viewData()
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim exp As New ClassItemExpense()
        Dim cond As String = "-1"

        cond = " AND DATE(e.created_date)>='" & Date.Parse(DEBBKFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(e.created_date)<='" & Date.Parse(DEBBKTo.EditValue.ToString).ToString("yyyy-MM-dd") & "'"

        If Not SLEUnit.EditValue.ToString = "0" Then
            cond += "  AND e.id_coa_tag='" & SLEUnit.EditValue.ToString & "' "
        End If

        Dim query As String = exp.queryMain(cond, "2", False)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemExpense_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemExpense_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormItemExpense_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCExpense.SelectedTabPageIndex = 0 Then
            If GVData.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            indeks = GVData.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnBankWithdrawal_Click(sender As Object, e As EventArgs) Handles BtnBankWithdrawal.Click
        Cursor = Cursors.WaitCursor
        'if already open
        Try
            FormBankWithdrawal.Close()
            FormBankWithdrawal.Dispose()
        Catch ex As Exception
        End Try

        Try
            FormBankWithdrawal.MdiParent = FormMain
            FormBankWithdrawal.Show()
            FormBankWithdrawal.WindowState = FormWindowState.Maximized
            FormBankWithdrawal.Focus()
            FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 2
        Catch ex As Exception
            errorCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub DEBBKFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEBBKFrom.EditValueChanged
        DEBBKTo.Properties.MinValue = DEBBKFrom.EditValue
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        viewData()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_verification()
    End Sub

    Sub load_verification()
        Dim q As String = "SELECT inv.id_awb_inv_sum,sts.report_status,c.comp_name,inv.created_date,inv.inv_number,emp.employee_name
,SUM(invd.amount_final) AS final_tot
,IF(inv.id_type=1,'Outbound',IF(inv.id_type=2,'Inbound','Return Online Store')) AS `type`
FROM `tb_awb_inv_sum_det` invd
INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invd.id_awb_inv_sum
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=inv.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=inv.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
LEFT JOIN tb_item_expense `exp` ON exp.id_comp=inv.id_comp AND exp.inv_number=inv.inv_number AND exp.id_report_status!=5
WHERE inv.id_report_status=6 AND ISNULL(exp.id_item_expense)
GROUP BY inv.id_awb_inv_sum
UNION ALL
SELECT inv.id_awb_inv_sum,sts.report_status,c.comp_name,inv.created_date,inv.inv_number,emp.employee_name
,SUM(invd.amount_final) AS final_tot
,IF(inv.id_type=3,'Office','-') AS `type`
FROM `tb_awb_inv_sum_other` invd
INNER JOIN tb_awb_inv_sum inv ON inv.id_awb_inv_sum=invd.id_awb_inv_sum
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=inv.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=inv.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
LEFT JOIN tb_item_expense `exp` ON exp.id_comp=inv.id_comp AND exp.inv_number=inv.inv_number AND exp.id_report_status!=5
WHERE inv.id_report_status=6 AND ISNULL(exp.id_item_expense)
GROUP BY inv.id_awb_inv_sum"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCInvoice.DataSource = dt
        GVInvoice.BestFitColumns()
    End Sub

    Private Sub GVInvoice_DoubleClick(sender As Object, e As EventArgs) Handles GVInvoice.DoubleClick
        FormItemExpensePop.id_awb_inv_sum = GVInvoice.GetFocusedRowCellValue("id_awb_inv_sum").ToString
        FormItemExpensePop.TEVendor.Text = GVInvoice.GetFocusedRowCellValue("comp_name").ToString
        FormItemExpensePop.TEInvNumber.Text = GVInvoice.GetFocusedRowCellValue("inv_number").ToString
        FormItemExpensePop.TEDesc3PLInv.Text = GVInvoice.GetFocusedRowCellValue("type").ToString
        FormItemExpensePop.ShowDialog()
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click

    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVListSNI.DoubleClick
        If GVListSNI.RowCount > 0 Then
            FormItemExpenseSNI.id_pps = GVListSNI.GetFocusedRowCellValue("id_sni_pps").ToString
            FormItemExpenseSNI.TEBudgetNumber.Text = GVListSNI.GetFocusedRowCellValue("number").ToString
            FormItemExpenseSNI.ShowDialog()
        End If
    End Sub

    Private Sub BrefreshSNI_Click(sender As Object, e As EventArgs) Handles BrefreshSNI.Click
        Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,s.season
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_season s ON s.id_season=pps.id_season
LEFT JOIN tb_sni_realisasi sr ON sr.id_sni_pps=pps.id_sni_pps AND sr.id_report_status !=5
WHERE pps.id_report_status=6 AND ISNULL(sr.id_sni_realisasi) "
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListSNI.DataSource = dt
        GVListSNI.BestFitColumns()
    End Sub

    Private Sub XTCExpense_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCExpense.SelectedPageChanged

    End Sub

    Private Sub DuplicateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 And GVData.GetFocusedRowCellValue("id_report_status").ToString = "5" Then
            Cursor = Cursors.WaitCursor
            FormItemExpenseDet.is_duplicate = True
            FormMain.but_edit()
            Cursor = Cursors.Default
        Else
            warningCustom("Only cancelled document")
        End If
    End Sub

    Private Sub GVContractList_DoubleClick(sender As Object, e As EventArgs) Handles GVContractList.DoubleClick
        'check
        If GVContractList.RowCount > 0 Then
            Dim q As String = "SELECT ed.*,DATE_FORMAT(e.`date_reff`,'%m%Y') FROM tb_item_expense_det ed
INNER JOIN tb_item_expense e ON e.`id_item_expense`=ed.`id_item_expense` AND e.`id_report_status`!=5 
WHERE ed.`id_report`='" & GVContractList.GetFocusedRowCellValue("id_kontrak_rider").ToString & "' AND report_mark_type='398' AND DATE_FORMAT(e.`date_reff`,'%m%Y')=DATE_FORMAT('" & Date.Parse(GVContractList.GetFocusedRowCellValue("periode").ToString).ToString("yyyy-MM-dd") & "','%m%Y')"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count = 0 Then
                FormItemExpenseRider.TEVendor.Text = GVContractList.GetFocusedRowCellValue("comp_name").ToString
                FormItemExpenseRider.id_kontrak_rider = GVContractList.GetFocusedRowCellValue("id_kontrak_rider").ToString
                FormItemExpenseRider.ShowDialog()
            Else
                warningCustom("This endorsee payment already created")
            End If
        End If

    End Sub

    Private Sub BViewEndorsee_Click(sender As Object, e As EventArgs) Handles BViewEndorsee.Click
        load_contract()
    End Sub

    Sub load_contract()
        Dim q As String = "SELECT 'no' AS is_check,'" & Date.Parse(DEContract.EditValue.ToString).ToString("yyyy-MM-dd") & "' AS periode,ppsd.id_kontrak_rider,c.`comp_name`,ppsd.kontrak_from,ppsd.kontrak_until,ppsd.id_comp,ppsd.id_kontrak_type
,CONCAT(IFNULL(DATE_FORMAT(ppsd.kontrak_from,'%d %b %Y'),''),' - ',IFNULL(DATE_FORMAT(ppsd.kontrak_until,'%d %b %Y'),'')) AS contract
,IF(ISNULL(ppsd.`kontrak_from`),0,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from,ppsd.kontrak_until)*ppsd.`monthly_pay`) AS total
,TIMESTAMPDIFF(MONTH,ppsd.kontrak_from,ppsd.kontrak_until) AS qty_month
,IFNULL(ppsd.`monthly_pay`,0) AS monthly_pay
,e.number
FROM `tb_kontrak_rider` ppsd
INNER JOIN tb_m_comp c ON c.`id_comp`=ppsd.`id_comp` AND ppsd.is_active=1
LEFT JOIN 
(
    SELECT k.`id_comp`,e.id_item_expense,e.`number` FROM tb_item_expense_det ed
    INNER JOIN tb_item_expense e ON e.`id_item_expense`=ed.`id_item_expense` AND e.`id_report_status`!=5 
    INNER JOIN tb_kontrak_rider k ON k.id_kontrak_rider=ed.id_report AND ed.report_mark_type='398'
    WHERE DATE_FORMAT(e.`date_reff`,'%m%Y')=DATE_FORMAT('" & Date.Parse(DEContract.EditValue.ToString).ToString("yyyy-MM-dd") & "','%m%Y')
    GROUP BY k.id_comp
)e ON e.id_comp=ppsd.id_comp
WHERE ppsd.kontrak_from<='" & Date.Parse(DEContract.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE_SUB(ppsd.kontrak_until, INTERVAL 1 DAY)>='" & Date.Parse(DEContract.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCContractList.DataSource = dt
        GVContractList.BestFitColumns()
    End Sub
End Class