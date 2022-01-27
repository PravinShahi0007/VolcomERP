Public Class FormDeviden
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormDeviden_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_deviden()
        Dim q As String = "SELECT d.*,emp.employee_name,sts.report_status 
FROM tb_deviden d
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=d.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=d.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
ORDER BY id_deviden DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCData.DataSource = dt
        GVData.BestFitColumns()
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
                bedit_active = "1"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub Brefresh_Click(sender As Object, e As EventArgs) Handles Brefresh.Click
        If XTCDevidenReport.SelectedTabPageIndex = 0 Then
            Dim q As String = "SELECT d.profit_year,ds.id_comp,c.`comp_number`,ds.`pph_account`,IF(ds.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,ds.`pph_percent`,ds.`deviden_percent`,ds.deviden_amount,ds.pph_amount
,IFNULL(pn.paid_amount,0) AS paid_amount
FROM `tb_deviden_share` ds
INNER JOIN tb_deviden d ON d.id_deviden=ds.id_deviden AND d.id_report_status!=5
INNER JOIN tb_m_comp c ON c.`id_comp`=ds.`id_comp`
LEFT JOIN tb_a_acc acc ON ds.`pph_account`=acc.`id_acc`
LEFT JOIN
(
	SELECT d.`id_deviden`,c.`id_comp`,pn.`id_pn`,pn.`number`,c.`comp_name`,pn.`date_created`,pn.`date_payment`,sts.`report_status`,SUM(pnd.`value`) AS paid_amount,d.`profit_year`
	FROM tb_pn_det pnd
	INNER JOIN tb_pn pn ON pn.`id_pn`=pnd.`id_pn` AND pnd.`report_mark_type`='384'
	INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pn.`id_comp_contact`
	INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=pn.`id_report_status`
	INNER JOIN tb_deviden_share ds ON ds.`id_deviden`=pnd.id_report AND ds.`id_comp`=c.`id_comp`
	INNER JOIN tb_deviden d ON d.`id_deviden`=ds.`id_deviden`
	GROUP BY d.`id_deviden`,c.`id_comp`
)pn ON pn.id_deviden=ds.`id_deviden` AND pn.`id_comp`=ds.`id_comp`
UNION ALL
SELECT tb.profit_year,0 AS id_comp,'' AS comp_number,'' AS `pph_account`,'' AS pph_desc,'TOTAL' AS `comp_name`,0 AS `pph_percent`,0 AS deviden_percent,SUM(tb.deviden_amount) AS deviden_amount,SUM(tb.pph_amount) AS pph_amount
,IFNULL(pn.paid_amount,0) AS paid_amount
FROM
(
	SELECT d.id_deviden,d.profit_year,ds.id_comp,c.`comp_number`,ds.`pph_account`,IF(ds.pph_account=0,'No PPH',CONCAT(acc.acc_name ,' - ',acc.`acc_description`)) AS pph_desc,c.`comp_name`,ds.`pph_percent`,ds.`deviden_percent`,ds.deviden_amount,ds.pph_amount
	FROM `tb_deviden_share` ds
	INNER JOIN tb_deviden d ON d.id_deviden=ds.id_deviden AND d.id_report_status!=5
	INNER JOIN tb_m_comp c ON c.`id_comp`=ds.`id_comp`
	LEFT JOIN tb_a_acc acc ON ds.`pph_account`=acc.`id_acc`
) tb
LEFT JOIN
(
	SELECT pn.`id_pn`,pn.`number`,c.`comp_name`,pn.`date_created`,pn.`date_payment`,sts.`report_status`,SUM(pnd.`value`) AS paid_amount,d.`profit_year`
	FROM tb_pn_det pnd
	INNER JOIN tb_pn pn ON pn.`id_pn`=pnd.`id_pn` AND pnd.`report_mark_type`='384'
	INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pn.`id_comp_contact`
	INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=pn.`id_report_status`
	INNER JOIN tb_deviden_share ds ON ds.`id_deviden`=pnd.id_report AND ds.`id_comp`=c.`id_comp`
	INNER JOIN tb_deviden d ON d.`id_deviden`=ds.`id_deviden`
	GROUP BY d.`profit_year`
)pn ON pn.profit_year=tb.`profit_year` 
GROUP BY tb.profit_year
ORDER BY id_comp DESC,profit_year ASC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCHistory.DataSource = dt
            GVHistory.BestFitColumns()
            GVHistory.ExpandAllGroups()
        Else
            show_list_bbk("0", "0", "2")
        End If
    End Sub

    Private Sub GVHistory_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVHistory.ColumnFilterChanged
        If GVHistory.RowCount > 0 And GVHistory.FocusedRowHandle >= 0 Then
            show_list_bbk(GVHistory.GetFocusedRowCellValue("profit_year").ToString, GVHistory.GetFocusedRowCellValue("id_comp").ToString, "1")
        End If
    End Sub

    Sub show_list_bbk(ByVal profit_year As String, ByVal id_comp As String, ByVal opt As String)
        Dim qw_comp As String = ""

        If Not id_comp = "0" Then
            qw_comp = " AND c.id_comp='" & id_comp & "'"
        End If

        Dim qw_year As String = ""

        If Not profit_year = "0" Then
            qw_year = " AND d.profit_year='" & profit_year & "'"
        End If

        Dim q As String = "SELECT pn.`id_pn`,pn.`number`,c.`comp_name`,pn.`date_created`,pn.`date_payment`,sts.`report_status`,pnd.`value` AS paid_amount,d.`profit_year`
FROM tb_pn_det pnd
INNER JOIN tb_pn pn ON pn.`id_pn`=pnd.`id_pn` AND pnd.`report_mark_type`='384'
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pn.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` " & qw_comp & "
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=pn.`id_report_status`
INNER JOIN tb_deviden_share ds ON ds.`id_deviden`=pnd.id_report AND ds.`id_comp`=c.`id_comp`
INNER JOIN tb_deviden d ON d.`id_deviden`=ds.`id_deviden` " & qw_year
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If opt = "1" Then
            GCBBKList.DataSource = dt
        Else
            GCBBK.DataSource = dt
        End If
    End Sub

    Private Sub GVHistory_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVHistory.FocusedRowChanged
        If GVHistory.RowCount > 0 And GVHistory.FocusedRowHandle >= 0 Then
            show_list_bbk(GVHistory.GetFocusedRowCellValue("profit_year").ToString, GVHistory.GetFocusedRowCellValue("id_comp").ToString, "1")
        End If
    End Sub
End Class