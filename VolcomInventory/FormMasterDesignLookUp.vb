Public Class FormMasterDesignLookUp
    Public id_design_column As String = "-1"
    Public column_type_front As String = "-1"
    Public column_type_end As String = "-1"

    Private Sub FormMasterDesignLookUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data As DataTable = execute_query("
            SELECT '' AS column_group, '' AS `value`

            UNION ALL

            SELECT column_group, `value`
            FROM tb_design_column_value
            WHERE id_design_column = " + id_design_column + " AND ((column_type_front = " + column_type_front + " AND column_type_end = " + column_type_end + ") OR (column_type_front IS NULL AND column_type_end IS NULL))
        ", -1, True, "", "", "", "")

        GCBrowse.DataSource = data

        GVBrowse.BestFitColumns()
    End Sub

    Private Sub GVBrowse_DoubleClick(sender As Object, e As EventArgs) Handles GVBrowse.DoubleClick
        FormMasterDesignSingle.GVAdditional.SetFocusedRowCellValue("value", GVBrowse.GetFocusedRowCellValue("value").ToString)

        Close()
    End Sub

    Private Sub FormMasterDesignLookUp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class