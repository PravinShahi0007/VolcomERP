Public Class FormProductPerformProductPick
    Private Sub FormProductPerformProductPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim where As String = ""

        If Not FormProductPerform.CCBESeason.EditValue.ToString = "" Then
            where += " AND d.id_season IN (" + FormProductPerform.CCBESeason.EditValue.ToString + ")"
        End If

        If Not FormProductPerform.CCBEDivision.EditValue.ToString = "" Then
            where += " AND v.id_code_detail IN (" + FormProductPerform.CCBEDivision.EditValue.ToString + ")"
        End If

        If Not FormProductPerform.CCBECategory.EditValue.ToString = "" Then
            where += " AND c.id_code_detail IN (" + FormProductPerform.CCBECategory.EditValue.ToString + ")"
        End If

        If Not FormProductPerform.CCBEClass.EditValue.ToString = "" Then
            where += " AND l.id_code_detail IN (" + FormProductPerform.CCBEClass.EditValue.ToString + ")"
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

    Private Sub FormProductPerformProductPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBSelect.Click
        GVProduct.ActiveFilterString = "is_checked = 'yes'"

        Dim list_product As String = ""
        Dim list_product_id As String = ""
        For i = 0 To GVProduct.RowCount - 1
            If i > 0 Then
                list_product += ","
                list_product_id += ","
            End If
            list_product += GVProduct.GetRowCellValue(i, "design_code").ToString
            list_product_id += GVProduct.GetRowCellValue(i, "id_design").ToString
        Next

        FormProductPerform.TEProductCode.EditValue = list_product
        FormProductPerform.TxtIdProduct.Text = list_product_id
        Close()
    End Sub
End Class