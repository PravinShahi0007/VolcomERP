Public Class FormSNIppsBudget
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAWBOther_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAWBOther_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVList.RowCount < 1 Then
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

    Private Sub FormSNIppsBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pps()
    End Sub

    Sub load_pps()
        Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,sts.report_status
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name`,sts.report_status,cp.number AS cop_pps_number
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
INNER JOIN tb_design_cop_propose cp ON cp.id_design_cop_propose=pps.id_design_cop_propose
WHERE pps.is_need_confirm=1 AND pps.is_confirmed=2 AND pps.id_report_status=6"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCConfirm.DataSource = dt
        GVConfirm.BestFitColumns()
    End Sub

    Private Sub GCList_DoubleClick(sender As Object, e As EventArgs) Handles GCList.DoubleClick
        If GVList.RowCount > 0 Then
            FormSNIppsDet.id_pps = GVList.GetFocusedRowCellValue("id_sni_pps").ToString
            FormSNIppsDet.ShowDialog()
        End If
    End Sub

    Private Sub GVConfirm_DoubleClick(sender As Object, e As EventArgs) Handles GVConfirm.DoubleClick
        If GVConfirm.RowCount > 0 Then
            FormSNIppsDet.id_pps = GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString
            FormSNIppsDet.is_view = "1"
            FormSNIppsDet.ShowDialog()
        End If
    End Sub

    Private Sub RINoChanges_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RINoChanges.ButtonClick
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Choosing no changes, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                'update ecop SNI yang kena changes
                Dim q As String = "SELECT l.*,qty.qty,tot.total,ROUND(tot.total/qty.qty,2) AS cost
FROM `tb_sni_pps_list` l
INNER JOIN tb_sni_pps p ON p.id_sni_pps=l.id_sni_pps AND l.id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "'
INNER JOIN `tb_design_cop_propose_det` cd ON cd.id_design_cop_propose=p.id_design_cop_propose AND l.id_design=cd.id_design
INNER JOIN 
(
	SELECT id_sni_pps,SUM(qty) AS qty
	FROM tb_sni_pps_list
	WHERE id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "'
)qty ON qty.id_sni_pps=l.id_sni_pps
INNER JOIN
(
	SELECT id_sni_pps,SUM(budget_value*budget_qty) AS total
	FROM `tb_sni_pps_budget`
	WHERE id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "'
)tot ON tot.id_sni_pps=l.id_sni_pps
WHERE l.id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                For i = 0 To GVList.RowCount - 1
                    'notif ke MD
                    Dim qu As String = ""
                    qu = String.Format("UPDATE tb_m_design SET prod_order_cop_pd=prod_order_cop_pd+{1},prod_order_cop_pd_addcost='{1}' WHERE id_design='{0}'", dt.Rows(i)("id_design").ToString, decimalSQL(dt.Rows(i)("cost").ToString))
                    execute_non_query(qu, True, "", "", "", "")
                    '
                    qu = "UPDATE 
tb_m_design dsg
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.`id_prod_demand_design_line`
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
INNER JOIN tb_opt opt 
SET 
pdd.prod_demand_design_estimate_price = dsg.prod_order_cop_pd,
pdd.prod_demand_design_total_cost = dsg.prod_order_cop_pd,  
pdd.additional_cost = dsg.prod_order_cop_pd_addcost,
pdd.additional_price = IF(dsg.prod_order_cop_pd_addcost>0,opt.default_add_price,0)
WHERE pd.is_pd=2 AND dsg.id_design='" & dt.Rows(i)("id_design").ToString & "'"
                    execute_non_query(qu, True, "", "", "", "")

                    'send mail to md
                    Try
                        Dim nm As New ClassSendEmail
                        nm.par1 = dt.Rows(i)("id_design").ToString
                        nm.report_mark_type = "267"
                        nm.send_email()
                    Catch ex As Exception
                        execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'Failed send ECOP PD SNI pps id_design = " & dt.Rows(i)("id_design").ToString & "')", -1, True, "", "", "", "")
                    End Try
                Next
                '
                Dim qup As String = "UPDATE `tb_sni_pps` SET is_confirmed=1,is_revise=2 WHERE id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "'"
                execute_non_query(qup, True, "", "", "", "")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RIRevise_Click(sender As Object, e As EventArgs) Handles RIRevise.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Choosing this will cancel old propose, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            'update pps
            Dim qup As String = "UPDATE `tb_sni_pps` SET is_confirmed=1,is_revise=2,id_report_status=5 WHERE id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "'"
            execute_non_query(qup, True, "", "", "", "")
            'duplicate SNI
            qup = "INSERT INTO `tb_sni_pps`(`id_season`,`created_by`,`created_date`)
SELECT `id_season`," & id_user & ",NOW()
FROM tb_sni_pps
WHERE id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "'; SELECT LAST_INSERT_ID();"
            Dim id_new_pps As String = execute_query(qup, 0, True, "", "", "", "")
            'list design
            qup = "INSERT INTO `tb_sni_pps_list`(`id_sni_pps`,`id_design`,`id_prod_demand_product`,`qty`)
SELECT '" & id_new_pps & "' AS id_sni_pps,l.`id_design`,l.`id_prod_demand_product`,pqty.qty
FROM tb_sni_pps_list l
INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product=l.id_prod_demand_product
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=pdp.id_prod_demand_design
INNER JOIN 
(
	SELECT pdd.id_design,SUM(pdp.prod_demand_product_qty) AS qty 
	FROM tb_prod_demand_product pdp
	INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=pdp.id_prod_demand_design
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand=pdd.id_prod_demand AND pd.is_pd=2
	GROUP BY pdd.id_design
) pqty ON pqty.id_design=pdd.id_design
WHERE l.id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "';"
            execute_non_query(qup, True, "", "", "", "")

            'detail
            qup = "INSERT INTO tb_sni_pps_budget(id_sni_pps,budget_desc,budget_value,budget_qty)
SELECT '" & id_new_pps & "' AS id_sni_pps,budget_desc,budget_value,budget_qty
FROM `tb_sni_pps_budget`
WHERE id_sni_pps='" & GVConfirm.GetFocusedRowCellValue("id_sni_pps").ToString & "' AND ISNULL(id_design)"
            execute_non_query(qup, True, "", "", "", "")

            FormSNIppsDet.id_pps = id_new_pps
            FormSNIppsDet.ShowDialog()
        End If
    End Sub
End Class