Public Class FormPurcReqItemUnableFulfill
    Public id_popup As String = "-1"
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPurcReqItemUnableFulfill_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BUnable_Click(sender As Object, e As EventArgs) Handles BUnable.Click
        Cursor = Cursors.WaitCursor
        If MEReason.Text = "" Then
            warningCustom("Please fill the reason first")
        Else
            If id_popup = "1" Then 'cant fulfill request
                For i As Integer = 0 To FormPurcOrder.GVPurcReq.RowCount - 1
                    If FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_po_created") > 0 Then
                        'already created PO
                        FormPurcOrder.GVPurcReq.SetRowCellValue(i, "status_val", "Already created PO")
                    Else
                        Dim query_upd As String = "UPDATE tb_purc_req_det SET is_unable_fulfill=1,unable_fulfill_reason='" & addSlashes(MEReason.Text) & "' WHERE id_purc_req_det='" & FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_purc_req_det").ToString & "'"
                        execute_non_query(query_upd, True, "", "", "", "")
                        FormPurcOrder.GVPurcReq.SetRowCellValue(i, "status_val", "Status updated --> Unable to fulfill")
                    End If
                Next
                infoCustom("Status updated")
                FormPurcOrder.load_req()
                Close()
                'ElseIf id_popup = "2" Then 'PO cant receive anymore move to close rec form
                '    For i As Integer = 0 To FormPurcOrder.GVPurcReq.RowCount - 1
                '        'close the PO
                '        Dim query_upd As String = "UPDATE tb_purc_order SET is_close_rec=1,close_rec_season='" & addSlashes(MEReason.Text) & "' WHERE id_purc_rec='" & FormPurcOrder.GVPO.GetRowCellValue(i, "id_purc_order").ToString & "'"
                '        execute_non_query(query_upd, True, "", "", "", "")
                '    Next
                '    infoCustom("Status updated")
                '    FormPurcOrder.load_po()
                '    Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class