Public Class FormInvMatDet
    Public id_inv As String = "-1"
    '
    Private Sub FormInvMatDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDueDate.EditValue = Now
        DERefDate.EditValue = Now
        DEDateCreated.EditValue = Now

        If id_inv = "-1" Then 'new
            BtnPrint.Visible = False
            BtnViewJournal.Visible = False
            BMark.Visible = False
            DEDueDate.Properties.ReadOnly = False
            DERefDate.Properties.ReadOnly = False
            '
            load_det()
            '
            If FormInvMat.XTCMatInv.SelectedTabPageIndex = 1 Then
                'invoice pl
                'vendor 
                SLEVendor.EditValue = FormInvMat.SLEVendorPayment.EditValue
                'detail
                Try
                    For i = 0 To FormInvMat.GVPL.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_prod_order") = FormInvMat.GVPL.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("id_report") = FormInvMat.GVPL.GetRowCellValue(i, "id_pl_mrs").ToString
                        newRow("report_mark_type") = "30"
                        newRow("report_number") = FormInvMat.GVPL.GetRowCellValue(i, "pl_mrs_number").ToString
                        newRow("info_design") = FormInvMat.GVPL.GetRowCellValue(i, "design_display_name").ToString
                        newRow("value") = FormInvMat.GVPL.GetRowCellValue(i, "amount")
                        newRow("inv_number") = ""
                        newRow("note") = ""
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf FormInvMat.XTCMatInv.SelectedTabPageIndex = 2 Then
                'invoice retur
                'vendor 
                SLEVendor.EditValue = FormInvMat.SLEVendorPayment.EditValue
                'detail
                Try
                    For i = 0 To FormInvMat.GVPL.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_prod_order") = FormInvMat.GVPL.GetRowCellValue(i, "id_prod_order").ToString
                        newRow("id_report") = FormInvMat.GVPL.GetRowCellValue(i, "id_mat_prod_ret_in").ToString
                        newRow("report_mark_type") = "32"
                        newRow("report_number") = FormInvMat.GVPL.GetRowCellValue(i, "mat_prod_ret_in_number").ToString
                        newRow("info_design") = FormInvMat.GVPL.GetRowCellValue(i, "design_display_name").ToString
                        newRow("value") = FormInvMat.GVPL.GetRowCellValue(i, "amount")
                        newRow("inv_number") = ""
                        newRow("note") = ""
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Else 'edit

        End If
    End Sub

    Sub calculate()

    End Sub

    Sub load_det()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,invd.`info_design`,invd.`id_report`,invd.`report_mark_type`,invd.`report_number`,invd.qty,invd.`value` 
FROM `tb_inv_mat_det` invd
INNER JOIN tb_prod_order po ON po.`id_prod_order`=invd.`id_prod_order`
WHERE invd.`id_inv_mat`='" & id_inv & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCList.DataSource = data
    End Sub

    Private Sub FormInvMatDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class