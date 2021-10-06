Public Class FormPrepaidExpense
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormPrepaidExpense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEBBKFrom.EditValue = Now
        DEBBKTo.EditValue = Now
        '
        load_unit()
        viewData()
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        'query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cond As String = "-1"

        cond = " AND DATE(e.created_date)>='" & Date.Parse(DEBBKFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(e.created_date)<='" & Date.Parse(DEBBKTo.EditValue.ToString).ToString("yyyy-MM-dd") & "'"

        If Not SLEUnit.EditValue.ToString = "0" Then
            cond += "  AND e.id_coa_tag='" & SLEUnit.EditValue.ToString & "' "
        End If

        Dim query As String = "SELECT e.id_coa_tag,ct.tag_description,e.inv_number,e.id_prepaid_expense,349 AS report_mark_type
, IFNULL(e.id_comp,0) AS `id_comp`, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, e.`number`
, e.created_date,e.date_reff, e.due_date, e.created_by, emp.employee_name AS `created_by_name`, e.id_report_status, stt.report_status
, IF(e.id_report_status!=6, '-', IF(e.is_open=2, 'Paid', IF(DATE(NOW())>e.due_date,'Overdue', 'Open'))) AS `paid_status`, e.note, e.is_open,
e.sub_total, e.vat_total,e.total, IFNULL(er.total,0) AS `total_paid`, (e.total-IFNULL(er.total,0)) AS `balance`, 'No' AS `is_select`, DATEDIFF(e.`due_date`,NOW()) AS due_days
,cf.id_comp AS `id_comp_default`, cf.comp_number AS `comp_number_default`,SUM(ed.amount) AS amount
, IFNULL(edp.total,0) AS `total_dp`
, IFNULL(payment_pending.jml,0) AS `total_pending`
, acc.id_acc,acc.acc_name,acc.acc_description 
FROM tb_prepaid_expense e
INNER JOIN tb_coa_tag ct ON ct.id_coa_tag=e.id_coa_tag
INNER JOIN tb_m_comp cf ON cf.id_comp=1
INNER JOIN tb_m_user u ON u.id_user = e.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = e.id_report_status
INNER JOIN tb_prepaid_expense_det ed ON ed.id_prepaid_expense=e.id_prepaid_expense
LEFT JOIN (
	SELECT pd.id_report, SUM(pd.`value`) AS total 
	FROM tb_pn p
	INNER JOIN tb_pn_det pd ON pd.id_pn = p.id_pn  AND p.is_tolakan=2
	WHERE p.report_mark_type=349 AND p.id_report_status!=5
	GROUP BY pd.id_report
) er ON er.id_report = e.id_prepaid_expense 
LEFT JOIN (
	SELECT pd.id_report, SUM(pd.`value`) AS total 
	FROM tb_pn p
	INNER JOIN tb_pn_det pd ON pd.id_pn = p.id_pn
	WHERE p.report_mark_type=349 AND p.id_report_status!=5 
	GROUP BY pd.id_report
) edp ON edp.id_report = e.id_prepaid_expense 
LEFT JOIN (
	SELECT COUNT(pyd.id_report) AS jml,pyd.id_report FROM `tb_pn_det` pyd
	INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=6 AND py.id_report_status!=5 AND py.report_mark_type='349'
	GROUP BY pyd.id_report
) payment_pending ON payment_pending.id_report = e.id_prepaid_expense 
LEFT JOIN tb_m_comp c ON c.id_comp = e.id_comp 
LEFT JOIN tb_a_acc acc ON acc.id_acc=IF(e.id_coa_tag=1,c.id_acc_ap,c.id_acc_cabang_ap) 
WHERE e.id_prepaid_expense>0 AND e.id_report_status!=5 " & cond & "
GROUP BY ed.id_prepaid_expense ORDER BY e.id_prepaid_expense DESC "

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
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        viewData()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 Then
            FormPrepaidExpenseDet.id = GVData.GetFocusedRowCellValue("id_prepaid_expense").ToString
            FormPrepaidExpenseDet.ShowDialog()
        End If
    End Sub
End Class