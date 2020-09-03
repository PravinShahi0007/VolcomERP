Public Class FormMasterDesignLookUp
    Public id_design_column As String = "-1"
    Public column_type_front As String = "-1"
    Public column_type_end As String = "-1"

    Private has_dependency As String = "-1"
    Private value_dependency As String = "-1"

    Private Sub FormMasterDesignLookUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get dependecy
        has_dependency = execute_query("SELECT IFNULL(id_dependency, '-1') FROM tb_design_column WHERE id_design_column = " + id_design_column, 0, True, "", "", "", "")

        If has_dependency <> "-1" Then
            For i = 0 To FormMasterDesignSingle.GVAdditional.RowCount - 1
                If FormMasterDesignSingle.GVAdditional.IsValidRowHandle(i) Then
                    If FormMasterDesignSingle.GVAdditional.GetRowCellValue(i, "id_design_column").ToString = has_dependency Then
                        value_dependency = FormMasterDesignSingle.GVAdditional.GetRowCellValue(i, "value").ToString
                    End If
                End If
            Next
        End If

        Dim data As DataTable = execute_query("
            SELECT '' AS column_group, '' AS `value`

            UNION ALL

            SELECT column_group, `value`
            FROM tb_design_column_value
            WHERE id_design_column = " + id_design_column + " AND ((column_type_front = " + column_type_front + " AND column_type_end = " + column_type_end + ") OR (column_type_front IS NULL AND column_type_end IS NULL)) " + If(has_dependency = "-1", "", "AND column_group = '" + value_dependency + "'") + "
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

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        If Not MEValue.Text = "" Then
            FormMasterDesignSingle.GVAdditional.SetFocusedRowCellValue("value", MEValue.EditValue.ToString)

            Close()
        Else
            stopCustom("Please insert new value.")
        End If
    End Sub
End Class