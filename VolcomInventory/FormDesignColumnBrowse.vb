Public Class FormDesignColumnBrowse
    Public id_design_column As String = "-1"
    Public column_type_front As String = "-1"
    Public column_type_end As String = "-1"

    Private Sub FormDesignColumnBrowse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCBrowse.DataSource = execute_query("
            (SELECT '' AS `value`)
            UNION ALL
            (SELECT `value`
            FROM tb_design_column_value
            WHERE id_design_column = " + id_design_column + " AND column_type_front " + If(column_type_front = "", "IS NULL", "= " + column_type_front) + " AND column_type_end " + If(column_type_end = "", "IS NULL", "= " + column_type_end) + ")
        ", -1, True, "", "", "", "")
    End Sub

    Private Sub FormDesignColumnBrowse_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVBrowse_DoubleClick(sender As Object, e As EventArgs) Handles GVBrowse.DoubleClick
        FormDesignColumnValue.TEColumnGroup.EditValue = GVBrowse.GetFocusedRowCellValue("value").ToString

        Close()
    End Sub
End Class