Public Class FormDesignColumnMapping
    Public column_type_front As String = ""
    Public column_type_end As String = ""

    Private loaded As Boolean = False

    Private Sub FormDesignColumnMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupQuery(SLUEStore, "SELECT id_design_column_type, column_type FROM tb_design_column_type", "id_design_column_type", "column_type", "id_design_column_type")

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

        load_form()

        loaded = True
    End Sub

    Sub load_form()
        'col
        Dim cols As DataTable = execute_query("
            SELECT alias_name AS column_name FROM tb_design_column_additional
            UNION ALL
            SELECT column_name FROM tb_design_column
        ", -1, True, "", "", "", "")

        GCCol.DataSource = cols

        GVCol.BestFitColumns()

        'column
        GVColumn.Columns.Clear()

        Dim column As DataTable = execute_query("
            SELECT cl.id_design_column_list, cl.column_list, cm.column_mapping
            FROM tb_design_column_list AS cl
            LEFT JOIN (
	            SELECT cm.id_design_column_list, cm.column_mapping
	            FROM tb_design_column_mapping AS cm
	            LEFT JOIN tb_design_column_list AS cl ON cm.id_design_column_list = cl.id_design_column_list
	            WHERE cl.id_design_column_type = " + SLUEStore.EditValue.ToString + " AND cm.column_type_front = " + column_type_front + " AND cm.column_type_end = " + column_type_end + "
            ) AS cm ON cl.id_design_column_list = cm.id_design_column_list
            WHERE cl.id_design_column_type = " + SLUEStore.EditValue.ToString + "
        ", -1, True, "", "", "", "")

        Dim data As DataTable = New DataTable

        For i = 0 To column.Rows.Count - 1
            Dim id_design_column_list As String = column.Rows(i)("id_design_column_list").ToString
            Dim column_list As String = column.Rows(i)("column_list").ToString

            data.Columns.Add(column_list.Replace(" ", ""), GetType(String))

            Dim col As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

            col.Caption = column_list
            col.FieldName = column_list.Replace(" ", "")
            col.Tag = id_design_column_list
            col.MinWidth = 200
            col.ColumnEdit = RepositoryItemMemoEdit
            col.Visible = True

            GVColumn.Columns.Add(col)
        Next

        Dim row As DataRow = data.NewRow

        For i = 0 To column.Rows.Count - 1
            Dim column_name As String = column.Rows(i)("column_list").ToString

            row(column_name.Replace(" ", "")) = column.Rows(i)("column_mapping").ToString
        Next

        data.Rows.Add(row)

        GCColumn.DataSource = data

        GVColumn.BestFitColumns()
    End Sub

    Private Sub FormDesignColumnMapping_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Function generate_query(id_store As String, type_front As String, type_end As String, in_design As String) As String
        'select
        Dim q_select As String = ""

        Dim data_column As DataTable = execute_query("
            SELECT cl.column_list, cm.column_mapping
            FROM tb_design_column_list AS cl
            LEFT JOIN (
	            SELECT cm.id_design_column_list, cm.column_mapping
	            FROM tb_design_column_mapping AS cm
	            LEFT JOIN tb_design_column_list AS cl ON cm.id_design_column_list = cl.id_design_column_list
	            WHERE cl.id_design_column_type = " + id_store + " AND cm.column_type_front = " + type_front + " AND cm.column_type_end = " + type_end + "
            ) AS cm ON cl.id_design_column_list = cm.id_design_column_list
            WHERE cl.id_design_column_type = " + id_store + "
        ", -1, True, "", "", "", "")

        For i = 0 To data_column.Rows.Count - 1
            Dim q_concat As String = "CONCAT("

            'split value by line
            Dim value As String = data_column.Rows(i)("column_mapping").ToString

            value = value.Replace(vbCr, "")

            Dim s_line() As String = value.Split(vbLf)

            For j = 0 To s_line.Count - 1
                'get `column`
                Dim matched As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(s_line(j), "\`(.*?)\`")

                'replace `column` with [n]
                For k = 0 To matched.Count - 1
                    s_line(j) = s_line(j).Replace(matched(k).Value, "[" + k.ToString + "]")
                Next

                'split by space
                Dim s_space() As String = s_line(j).Split(" ")

                'replace [n] column
                For k = 0 To s_space.Count - 1
                    For l = 0 To matched.Count - 1
                        If s_space(k) = "[" + l.ToString + "]" Then
                            s_space(k) = matched(l).Value
                        End If
                    Next
                Next

                'build concat
                For k = 0 To s_space.Count - 1
                    If s_space(k).Contains("`") Then
                        q_concat += "IFNULL(" + s_space(k) + ", ''), "
                    Else
                        q_concat += "'" + s_space(k) + "', "
                    End If

                    If k < (s_space.Count - 1) Then
                        q_concat += "' ', "
                    End If
                Next

                If j < (s_line.Count - 1) Then
                    q_concat += "'\n', "
                End If
            Next

            q_concat = q_concat.Substring(0, q_concat.Length - 2) + ") AS `" + data_column.Rows(i)("column_list").ToString + "`"

            q_select += q_concat + ", "
        Next

        'column dynamic
        Dim q_column As String = ""

        Dim columns As DataTable = execute_query("SELECT * FROM tb_design_column", -1, True, "", "", "", "")

        For i = 0 To columns.Rows.Count - 1
            q_column += "MAX(CASE WHEN col.id_design_column = " + columns.Rows(i)("id_design_column").ToString + " THEN i.value END) AS `" + columns.Rows(i)("column_name").ToString + "`, "
        Next

        'column additional
        Dim a_column As String = execute_query("SELECT GROUP_CONCAT(CONCAT(column_name, ' AS `', alias_name, '`')) AS `column` FROM tb_design_column_additional", 0, True, "", "", "", "")

        'query
        Dim query As String = "
            SELECT " + q_select.Substring(0, q_select.Length - 2) + "
            FROM (
	            SELECT " + a_column + ",
	            " + q_column.Substring(0, q_column.Length - 2) + "
	            FROM tb_m_product AS p
	            INNER JOIN tb_m_product_code AS pc ON pc.id_product = p.id_product
	            INNER JOIN tb_m_code_detail AS cd ON cd.id_code_detail = pc.id_code_detail
	            INNER JOIN tb_m_design AS d ON d.id_design = p.id_design
	            LEFT JOIN tb_m_design_information AS i ON i.id_design = d.id_design
	            LEFT JOIN tb_design_column AS col ON col.id_design_column = i.id_design_column
	            WHERE d.id_design IN (" + in_design + ")
	            GROUP BY p.id_product
            ) tb
        "

        Return query
    End Function

    Private Sub GVCol_DoubleClick(sender As Object, e As EventArgs) Handles GVCol.DoubleClick
        Dim value As String = GVColumn.GetFocusedRowCellValue(GVColumn.FocusedColumn) + "`" + GVCol.GetFocusedRowCellValue("column_name").ToString + "`"

        GVColumn.SetFocusedRowCellValue(GVColumn.FocusedColumn, value)
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SLUEStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEStore.EditValueChanged
        load_form()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        If Not TEAdd.Text = "" Then
            'column
            Dim col As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

            col.Caption = TEAdd.EditValue.ToString
            col.FieldName = TEAdd.EditValue.ToString.Replace(" ", "")
            col.Tag = "0"
            col.MinWidth = 200
            col.ColumnEdit = RepositoryItemMemoEdit
            col.Visible = True

            GVColumn.Columns.Add(col)

            'datasource
            Dim data As DataTable = GCColumn.DataSource

            data.Columns.Add(TEAdd.EditValue.ToString.Replace(" ", ""), GetType(String))

            GCColumn.DataSource = data

            GVColumn.BestFitColumns()

            TEAdd.EditValue = ""
        Else
            stopCustom("Please add column name.")
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim in_design_column_list As String = ""

        For i = 0 To GVColumn.Columns.Count - 1
            Dim id_design_column_list As String = GVColumn.Columns(i).Tag.ToString

            If id_design_column_list = "0" Then
                'add column list
                id_design_column_list = execute_query("INSERT INTO tb_design_column_list (id_design_column_type, column_list) VALUES (" + SLUEStore.EditValue.ToString + ", '" + addSlashes(GVColumn.Columns(i).Caption) + "'); SELECT LAST_INSERT_ID();", 0, True, "", "", "", "")
            End If

            execute_non_query("DELETE FROM tb_design_column_mapping WHERE id_design_column_list = " + id_design_column_list + " AND column_type_front = " + column_type_front + " AND column_type_end = " + column_type_end, True, "", "", "", "")

            execute_non_query("INSERT INTO tb_design_column_mapping (id_design_column_list, column_type_front, column_type_end, column_mapping) VALUES (" + id_design_column_list + ", " + column_type_front + ", " + column_type_end + ", '" + addSlashes(GVColumn.GetRowCellValue(0, GVColumn.Columns(i))) + "')", True, "", "", "", "")

            in_design_column_list += id_design_column_list + ", "
        Next

        If Not in_design_column_list = "" Then
            execute_non_query("DELETE FROM tb_design_column_list WHERE id_design_column_list NOT IN (" + in_design_column_list.Substring(0, in_design_column_list.Length - 2) + ") AND id_design_column_type = " + SLUEStore.EditValue.ToString, True, "", "", "", "")
        End If

        infoCustom("Saved.")
    End Sub

    Private Sub SBDelete_Click(sender As Object, e As EventArgs) Handles SBDelete.Click
        'datasource
        Dim data As DataTable = GCColumn.DataSource

        data.Columns.Remove(GVColumn.FocusedColumn.FieldName)

        GVColumn.Columns.Remove(GVColumn.FocusedColumn)

        GCColumn.DataSource = data
    End Sub

    Private Sub SLUEStore_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SLUEStore.EditValueChanging
        If loaded Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to move, or save first ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class