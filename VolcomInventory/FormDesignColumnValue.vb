Public Class FormDesignColumnValue
    Public id_design_column_category As String = "-1"
    Public id_design_column_value As String = "-1"
    Public id_design_column As String = "-1"
    Public column_type_front As String = "-1"
    Public column_type_end As String = "-1"

    Private has_dependency As String = "-1"

    Private Sub FormDesignColumnValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TECategory.EditValue = execute_query("SELECT category FROM tb_design_column_category WHERE id_design_column_category = " + id_design_column_category, 0, True, "", "", "", "")

        TEType.EditValue = execute_query("
            SELECT CONCAT(column_front.display_name, ' ', column_end.display_name) AS `code`
            FROM (
	            SELECT display_name
	            FROM tb_m_code_detail
	            WHERE id_code_detail = '" + column_type_front + "'
            ) AS column_front, (
	            SELECT display_name
	            FROM tb_m_code_detail
	            WHERE id_code_detail = '" + column_type_end + "'
            ) AS column_end

            UNION

            SELECT 'ALL' AS `code`
        ", 0, True, "", "", "", "")

        TEColumnName.EditValue = execute_query("
            SELECT column_name
            FROM tb_design_column
            WHERE id_design_column = '" + id_design_column + "'
        ", 0, True, "", "", "", "")

        If Not id_design_column_value = "-1" Then
            Dim data As DataTable = execute_query("
                SELECT column_group, `value`
                FROM tb_design_column_value
                WHERE id_design_column_value = '" + id_design_column_value + "'
            ", -1, True, "", "", "", "")

            TEColumnGroup.EditValue = data.Rows(0)("column_group").ToString
            TEValue.EditValue = data.Rows(0)("value").ToString
        End If

        'controls
        has_dependency = execute_query("SELECT IFNULL(id_dependency, '-1') FROM tb_design_column WHERE id_design_column = " + id_design_column, 0, True, "", "", "", "")

        If has_dependency = "-1" Then
            TEColumnGroup.Width = 460
            SBBrowse.Visible = False
        Else
            TEColumnGroup.ReadOnly = True
        End If
    End Sub

    Private Sub FormDesignColumnValue_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormDesignColumn.form_load()

        'set focus
        For i = 0 To FormDesignColumn.GVDesignColumn.Columns.Count - 1
            If FormDesignColumn.GVDesignColumn.Columns(i).Tag.ToString.Split(";")(0) = id_design_column Then
                FormDesignColumn.GVDesignColumn.FocusedColumn = FormDesignColumn.GVDesignColumn.Columns(i)
            End If
        Next

        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If Not TEValue.Text = "" Then
            If id_design_column_value = "-1" Then
                'insert
                execute_non_query("
                INSERT INTO tb_design_column_value (id_design_column, column_type_front, column_type_end, column_group, `value`) VALUES (" + id_design_column + ", " + If(column_type_front = "", "NULL", column_type_front) + ", " + If(column_type_end = "", "NULL", column_type_end) + ", '" + addSlashes(TEColumnGroup.EditValue) + "', '" + addSlashes(TEValue.EditValue) + "')
            ", True, "", "", "", "")

                infoCustom("Saved.")

                Close()
            Else
                'update
                execute_non_query("
                    UPDATE tb_design_column_value SET id_design_column = " + id_design_column + ", column_type_front = " + If(column_type_front = "", "NULL", column_type_front) + ", column_type_end = " + If(column_type_end = "", "NULL", column_type_end) + ", column_group = '" + addSlashes(TEColumnGroup.EditValue) + "',  `value` = '" + addSlashes(TEValue.EditValue) + "' WHERE id_design_column_value = " + id_design_column_value + "
                ", True, "", "", "", "")

                infoCustom("Saved.")

                Close()
            End If
        Else
            errorCustom("Column value can't be blank.")
        End If
    End Sub

    Private Sub SBBrowse_Click(sender As Object, e As EventArgs) Handles SBBrowse.Click
        FormDesignColumnBrowse.id_design_column = has_dependency
        FormDesignColumnBrowse.column_type_front = column_type_front
        FormDesignColumnBrowse.column_type_end = column_type_end

        FormDesignColumnBrowse.ShowDialog()
    End Sub
End Class