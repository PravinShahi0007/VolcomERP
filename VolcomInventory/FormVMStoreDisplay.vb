Public Class FormVMStoreDisplay
    Private Sub FormVMStoreDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewStore()
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT  'No' AS `is_select`,c.id_comp,c.is_active, c.comp_number, c.comp_name, c.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`, c.address_primary,
        aa.`area`, cty.id_city, cty.city, sta.id_state, sta.state, rep.id_employee, rep.employee_name, ls.log_date, ls.reason, st.store_type
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN tb_m_area aa ON aa.id_area = c.id_area
        LEFT JOIN tb_m_city cty ON cty.id_city = c.id_city
        LEFT JOIN tb_m_state sta ON sta.id_state = cty.id_state
        LEFT JOIN tb_m_employee rep ON rep.id_employee = c.id_employee_rep
        LEFT JOIN (
	        SELECT ls.id_comp, ls.`log_date`, ls.reason
	        FROM tb_log_store_activation ls
	        INNER JOIN (
		        SELECT ls.id_comp, MAX(ls.log_date) AS `log_date` 
		        FROM tb_log_store_activation ls
		        GROUP BY ls.id_comp
	        ) lm ON lm.id_comp = ls.id_comp AND lm.log_date = ls.log_date
	        GROUP BY ls.id_comp
        ) ls ON ls.id_comp = c.id_comp
        LEFT JOIN tb_lookup_store_type st ON st.id_store_type = c.id_store_type
        WHERE 1=1 AND c.is_active IN(1,2) "
        query += "ORDER BY cg.description, c.comp_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormVMStoreDisplay_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormVMStoreDisplay_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormMain.hide_rb()
    End Sub

    Sub print_list()
        Cursor = Cursors.WaitCursor
        print(GCData, "VM Store Display")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        Cursor = Cursors.WaitCursor
        FormVMStoreDisplayDet.id_store = GVData.GetFocusedRowCellValue("id_comp").ToString
        FormVMStoreDisplayDet.TxtStoreCode.Text = GVData.GetFocusedRowCellValue("comp_number").ToString
        FormVMStoreDisplayDet.TxtStoreName.Text = GVData.GetFocusedRowCellValue("comp_name").ToString
        FormVMStoreDisplayDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class