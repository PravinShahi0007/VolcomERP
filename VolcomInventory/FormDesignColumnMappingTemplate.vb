Public Class FormDesignColumnMappingTemplate
    Public id_design_column_type As String = "0"

    Private Sub FormDesignColumnMappingTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TETemplate.EditValue = execute_query("SELECT IFNULL((SELECT column_type FROM tb_design_column_type WHERE id_design_column_type = " + id_design_column_type + "), '') AS column_type", 0, True, "", "", "", "")

        Dim data As DataTable = execute_query("
            SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, IF(IFNULL(w.id_comp, '') = '', '0', '1') AS is_select
            FROM tb_m_comp AS c
            LEFT JOIN (
	            SELECT id_comp
	            FROM tb_design_column_type_wh
                WHERE id_design_column_type = " + id_design_column_type + "
            ) AS w ON c.id_comp = w.id_comp
            WHERE c.id_comp_cat = 5
            ORDER BY c.comp_number ASC
        ", -1, True, "", "", "", "")

        GCWH.DataSource = data

        GVWH.BestFitColumns()
    End Sub

    Private Sub FormDesignColumnMappingTemplate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If id_design_column_type = "0" Then
            'insert
            id_design_column_type = execute_query("INSERT INTO tb_design_column_type (column_type) VALUES ('" + addSlashes(TETemplate.EditValue.ToString) + "'); SELECT LAST_INSERT_ID();", 0, True, "", "", "", "")
        Else
            'update
            execute_non_query("UPDATE tb_design_column_type SET column_type = '" + addSlashes(TETemplate.EditValue.ToString) + "' WHERE id_design_column_type = " + id_design_column_type, True, "", "", "", "")
        End If

        'insert detail
        execute_non_query("DELETE FROM tb_design_column_type_wh WHERE id_design_column_type = " + id_design_column_type, True, "", "", "", "")

        GVWH.FindFilterText = ""

        GVWH.ActiveFilterString = "[is_select] = 1"

        For i = 0 To GVWH.RowCount - 1
            execute_non_query("INSERT INTO tb_design_column_type_wh (id_design_column_type, id_comp) VALUES (" + id_design_column_type + ", " + GVWH.GetRowCellValue(i, "id_comp").ToString + "); SELECT LAST_INSERT_ID();", True, "", "", "", "")
        Next

        FormDesignColumnMapping.view_template()

        FormDesignColumnMapping.SLUEStore.EditValue = id_design_column_type

        infoCustom("Saved.")

        Close()
    End Sub
End Class