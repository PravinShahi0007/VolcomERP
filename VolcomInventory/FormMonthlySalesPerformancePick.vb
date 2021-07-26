Public Class FormMonthlySalesPerformancePick
    Private Sub FormMonthlySalesPerformancePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim where As String = ""

        If Not FormMonthlySalesPerformance.CCBESeason.EditValue.ToString = "" Then
            where += " AND d.id_season IN (" + FormMonthlySalesPerformance.CCBESeason.EditValue.ToString + ")"
        End If

        If Not FormMonthlySalesPerformance.CCBEDivision.EditValue.ToString = "" Then
            where += " AND v.id_code_detail IN (" + FormMonthlySalesPerformance.CCBEDivision.EditValue.ToString + ")"
        End If

        If Not FormMonthlySalesPerformance.CCBECategory.EditValue.ToString = "" Then
            where += " AND c.id_code_detail IN (" + FormMonthlySalesPerformance.CCBECategory.EditValue.ToString + ")"
        End If

        If Not FormMonthlySalesPerformance.CCBEClass.EditValue.ToString = "" Then
            where += " AND l.id_code_detail IN (" + FormMonthlySalesPerformance.CCBEClass.EditValue.ToString + ")"
        End If

        Dim query As String = "
            SELECT 'no' AS is_checked, d.id_design, d.design_code, d.design_display_name
            FROM tb_m_design AS d
            LEFT JOIN (
	            SELECT c.id_design, c.id_code_detail
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 32
            ) AS v ON d.id_design = v.id_design
            LEFT JOIN (
	            SELECT c.id_design, c.id_code_detail
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 4
            ) AS c ON d.id_design = c.id_design
            LEFT JOIN (
	            SELECT c.id_design, c.id_code_detail
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 30
            ) AS l ON d.id_design = l.id_design
            WHERE d.id_lookup_status_order <> 2 " + where + " AND d.design_code <> ''
        "

        GCProduct.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVProduct.BestFitColumns()
    End Sub

    Private Sub FormMonthlySalesPerformancePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBSelect.Click
        GVProduct.ActiveFilterString = "is_checked = 'yes'"

        Dim list_product As String = ""
        Dim id_list_product As String = ""

        For i = 0 To GVProduct.RowCount - 1
            list_product += GVProduct.GetRowCellValue(i, "design_code").ToString + ","
            id_list_product += GVProduct.GetRowCellValue(i, "id_design").ToString + ","
        Next

        If Not list_product = "" Then
            list_product = list_product.Substring(0, list_product.Length - 1)
            id_list_product = id_list_product.Substring(0, id_list_product.Length - 1)
        End If

        FormMonthlySalesPerformance.TEProductCode.EditValue = list_product
        FormMonthlySalesPerformance.TxtIdProduct.EditValue = id_list_product

        Close()
    End Sub
End Class