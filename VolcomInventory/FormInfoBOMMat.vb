Public Class FormInfoBOMMat 
    Public id_pd_design As String = "-1"

    Private Sub FormInfoBOMMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RCIsCOP.ValueChecked = Convert.ToSByte(1)
        RCIsCOP.ValueUnchecked = Convert.ToSByte(2)

        view_bom_mat()
    End Sub
    Sub view_bom_mat()
        Try
            Dim query As String
            query = "CALL view_mat_design('" & id_pd_design & "')"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub FormInfoBOMMat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAddMat_Click(sender As Object, e As EventArgs) Handles BAddMat.Click
        'check if exist
        Dim already = False
        If FormProductionMRS.GVMat.RowCount > 0 Then
            For i As Integer = 0 To FormProductionMRS.GVMat.RowCount - 1
                If FormProductionMRS.GVMat.GetRowCellValue(i, "id_mat_det_price").ToString = GVBomDetMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString Then
                    already = True
                End If
            Next
        End If

        If already = True Then
            stopCustom("Material already in list")
        Else
            Dim newRow As DataRow = (TryCast(FormProductionMRS.GCMat.DataSource, DataTable)).NewRow()
            newRow("id_mat_det") = GVBomDetMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
            newRow("id_mat_det_price") = GVBomDetMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
            newRow("size") = GVBomDetMat.GetFocusedRowCellDisplayText("size").ToString
            newRow("mat_det_price") = GVBomDetMat.GetFocusedRowCellDisplayText("price")
            newRow("name") = GVBomDetMat.GetFocusedRowCellDisplayText("mat_det_name").ToString
            newRow("code") = GVBomDetMat.GetFocusedRowCellDisplayText("mat_det_code").ToString
            newRow("color") = GVBomDetMat.GetFocusedRowCellDisplayText("color").ToString
            newRow("qty_all_mat") = GVBomDetMat.GetFocusedRowCellDisplayText("qty_all_mat").ToString
            newRow("qty_left") = GVBomDetMat.GetFocusedRowCellDisplayText("qty_left").ToString
            newRow("qty") = GVBomDetMat.GetFocusedRowCellDisplayText("qty").ToString

            TryCast(FormProductionMRS.GCMat.DataSource, DataTable).Rows.Add(newRow)
            FormProductionMRS.GCMat.RefreshDataSource()
            FormProductionMRS.check_but()
            FormProductionMRS.GVMat.FocusedRowHandle = 0
            Close()
        End If
    End Sub
End Class