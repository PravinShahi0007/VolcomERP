﻿Public Class FormMaterialRequisition
    Private Sub FormMaterialRequisition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
        view_mrs()
        show_but_mrs()
    End Sub

    Private Sub FormMaterialRequisition_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    '================ view MRS ====================
    Sub view_mrs()
        Dim query = "SELECT a.id_prod_order_mrs,a.prod_order_mrs_number,a.id_report_status,h.report_status,a.id_prod_order_wo,b.prod_order_wo_number, "
        query += "d.comp_name AS comp_name_req_from,c.id_comp_contact AS id_comp_name_req_from, "
        query += "f.comp_name AS comp_name_req_to,e.id_comp_contact AS id_comp_name_req_to, "
        query += "a.prod_order_mrs_date, "
        query += "p.id_prod_order, p.prod_order_number, ds.design_code, CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',ds.design_name,' ',cd.color) AS  design_display_name, emp.employee_name AS created_by "
        query += "FROM tb_prod_order_mrs a "
        query += "LEFT JOIN tb_prod_order p ON p.id_prod_order = a.id_prod_order "
        query += "LEFT JOIN tb_prod_demand_design pd ON p.id_prod_demand_design = pd.id_prod_demand_design "
        query += "LEFT JOIN tb_m_design ds ON pd.id_design = ds.id_design "
        query += "LEFT JOIN tb_season s ON s.id_season=ds.id_season
LEFT JOIN tb_range r ON r.id_range=s.id_range
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = ds.id_design
"
        query += "LEFT JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_req_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_req_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "LEFT JOIN tb_m_user AS usr ON a.created_by = usr.id_user "
        query += "LEFT JOIN tb_m_employee AS emp ON usr.id_employee = emp.id_employee "
        query += "WHERE a.id_prod_order IS NOT NULL AND DATE(a.prod_order_mrs_date)>=DATE('" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(a.prod_order_mrs_date)<=DATE('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "') "
        query += "ORDER BY a.id_prod_order_mrs DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMRS.DataSource = data
        GVMRS.BestFitColumns()
        show_but_mrs()
    End Sub

    Sub show_but_mrs()
        If GVMRS.RowCount > 0 Then
            button_main("1", "1", "1")
        Else
            button_main("1", "0", "0")
        End If
    End Sub

    Private Sub FormMaterialRequisition_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "1")
    End Sub

    Private Sub FormMaterialRequisition_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVMRS_DoubleClick(sender As Object, e As EventArgs) Handles GVMRS.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        view_mrs()
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        Try
            DEStart.Properties.MaxValue = DEUntil.EditValue
        Catch ex As Exception
        End Try
    End Sub
End Class