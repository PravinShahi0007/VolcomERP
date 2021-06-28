Public Class FormSNIppsDet
    Public id_pps As String = "-1"

    Private Sub FormSNIppsDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        If id_pps = "-1" Then
            'new
            load_pending_kids()
            TENumber.Text = "[auto_generate]"
            TEProposedBy.Text = get_emp(id_employee_user, "1")
            '
            XTPListDesign.PageVisible = True
            XTPProposedList.PageVisible = False
            XTPBudgetPropose.PageVisible = False
        Else
            'edit
            Dim q As String = "SELECT pps.`id_sni_pps`,pps.`number`,pps.`created_date`,emp.`employee_name` 
FROM tb_sni_pps pps
INNER JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pps.`id_sni_pps`='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                TEProposedBy.Text = dt.Rows(0)("employee_name").ToString
                DEProposeDate.EditValue = dt.Rows(0)("created_date")
                '
                load_proposed()
            End If
            XTPListDesign.PageVisible = False
            XTPProposedList.PageVisible = True
            XTPBudgetPropose.PageVisible = True
        End If
    End Sub

    Sub load_pending_kids()
        Dim q As String = "SELECT 'no' AS is_check,dsg.`id_design`,dsg.`design_code`,dsg.`design_display_name`,(dsg.`prod_order_cop_pd`-dsg.`prod_order_cop_pd_addcost`) AS ecop,del.`delivery`,ssn.`season`
FROM tb_m_design dsg
INNER JOIN tb_m_design_code cd ON cd.`id_code_detail`=14696 AND cd.`id_design`=dsg.`id_design`
INNER JOIN tb_season_delivery del ON del.id_delivery=dsg.`id_delivery`
INNER JOIN tb_season ssn ON ssn.id_season=del.id_season
WHERE dsg.`id_design` NOT IN (
	SELECT id_design 
	FROM tb_prod_demand_design pdd 
	INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
	WHERE pd.`id_report_status`=6 AND pd.`is_void_pd`!=1 AND pd.`is_pd`=1
	GROUP BY pdd.`id_design`
)
AND dsg.`is_approved`=1 AND dsg.`is_old_design`=2 AND dsg.`id_lookup_status_order`!=2"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        '
        If GVList.RowCount > 0 Then
            BPropose.Visible = True
        End If
    End Sub

    Sub load_budget()
        Dim q As String = "SELECT id_sni_pps_budget,`id_sni_pps`,`id_design`,`budget_desc`,`budget_value`,`budget_qty`
FROM `tb_sni_pps_budget`
WHERE `id_sni_pps`=''"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
    End Sub

    Sub load_proposed()
        Dim q As String = "SELECT 'no' AS is_check,dsg.`id_design`,dsg.`design_code`,dsg.`design_display_name`,(dsg.`prod_order_cop_pd`-dsg.`prod_order_cop_pd_addcost`) AS ecop,del.`delivery`,ssn.`season`
FROM tb_sni_pps_list `ppsl`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=ppsl.`id_design`
INNER JOIN tb_m_design_code cd ON cd.`id_code_detail`=14696 AND cd.`id_design`=dsg.`id_design`
INNER JOIN tb_season_delivery del ON del.id_delivery=dsg.`id_delivery`
INNER JOIN tb_season ssn ON ssn.id_season=del.id_season
AND dsg.`is_approved`=1 AND dsg.`is_old_design`=2 AND dsg.`id_lookup_status_order`!=2
WHERE ppsl.id_sni_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCProposed.DataSource = dt
        GVProposed.BestFitColumns()
    End Sub

    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        GVList.ActiveFilterString = "[is_check]='yes'"
        If GVList.RowCount = 0 Then
            warningCustom("No design selected")
        Else
            Dim q As String = "INSERT INTO tb_sni_pps(created_by,created_date) VALUES('" & id_user & "',NOW()); SELECT LAST_INSERT_ID(); "
            id_pps = execute_query(q, 0, True, "", "", "", "")
            q = "INSERT INTO tb_sni_pps_list(id_sni_pps,id_design) VALUES"
            For i As Integer = 0 To GVList.RowCount - 1
                If Not i = 0 Then
                    q += ","
                End If
                q += "('" & id_pps & "','" & GVList.GetRowCellValue(i, "id_design").ToString & "')"
            Next
            execute_non_query(q, True, "", "", "", "")
            '
            load_head()
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim q As String = ""

    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub
End Class