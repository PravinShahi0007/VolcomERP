Public Class FormPopUpPurchaseMatDet
    Public id_mat_purc As String
    Public id_pop_up As String
    Public action As String
    Private Sub FormPopUpPurchaseMatDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_mat_purc WHERE id_mat_purc = '" + id_mat_purc + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelSubTitle.Text = "Purchase Number NO :" + data.Rows(0)("mat_purc_number").ToString
        view_list_purchase(id_mat_purc)
    End Sub
    Sub view_list_purchase(ByVal id_mat_purc As String)
        Dim query = "CALL view_mat_purc_det('" & id_mat_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If id_pop_up = "1" Then
            Dim i As Integer = data.Rows.Count - 1
            While (i >= 0)
                If FormMatRetOutDet.id_mat_purc_det_list.Contains(data.Rows(i)("id_mat_purc_det").ToString) Then
                    data.Rows.RemoveAt(i)
                End If
                i = i - 1
            End While
        ElseIf id_pop_up = "2" Then
            Dim i As Integer = data.Rows.Count - 1
            While (i >= 0)
                If FormMatRetInDet.id_mat_purc_det_list.Contains(data.Rows(i)("id_mat_purc_det").ToString) Then
                    data.Rows.RemoveAt(i)
                End If
                i = i - 1
            End While
        End If
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BtnSave.Enabled = True
        Else
            BtnSave.Enabled = False
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If id_pop_up = "1" Then
            If action = "ins" Then
                FormMatRetOutDet.newRows()
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("id_mat_purc_ret_out_det", "0")
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("id_mat_det", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("id_mat_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellValue("uom").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("code", GVListPurchase.GetFocusedRowCellValue("code").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("mat_purc_ret_out_det_qty", "0")
                FormMatRetOutDet.GVRetDetail.CloseEditor()
                FormMatRetOutDet.id_mat_purc_det_list.Add(GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                FormMatRetOutDet.check_but()
                Close()
            ElseIf action = "upd" Then
                Dim id_mat_purc_det_old As String = FormMatRetOutDet.GVRetDetail.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString
                FormMatRetOutDet.id_mat_purc_det_list.Remove(id_mat_purc_det_old)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("id_mat_purc_ret_out_det", "0")
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("id_mat_det", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_det").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("id_mat_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellValue("uom").ToString)
                FormMatRetOutDet.GVRetDetail.SetFocusedRowCellValue("code", GVListPurchase.GetFocusedRowCellValue("code").ToString)
                FormMatRetOutDet.GVRetDetail.CloseEditor()
                FormMatRetOutDet.id_mat_purc_det_list.Add(GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                FormMatRetOutDet.check_but()
                Close()
            End If
        ElseIf id_pop_up = "2" Then
            If action = "ins" Then
                FormMatRetInDet.newRows()
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("id_mat_purc_ret_in_det", "0")
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("id_mat_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("color", GVListPurchase.GetFocusedRowCellValue("color").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellValue("uom").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("code", GVListPurchase.GetFocusedRowCellValue("code").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("mat_purc_ret_in_det_qty", "0")
                FormMatRetInDet.GVRetDetail.CloseEditor()
                FormMatRetInDet.id_mat_purc_det_list.Add(GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                FormMatRetInDet.check_but()
                FormMatRetInDet.GVRetDetail.RefreshData()
                Close()
            ElseIf action = "upd" Then
                Dim id_mat_purc_det_old As String = FormMatRetInDet.GVRetDetail.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString
                FormMatRetInDet.id_mat_purc_det_list.Remove(id_mat_purc_det_old)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("id_mat_purc_ret_in_det", "0")
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("id_mat_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("color", GVListPurchase.GetFocusedRowCellValue("color").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellValue("uom").ToString)
                FormMatRetInDet.GVRetDetail.SetFocusedRowCellValue("code", GVListPurchase.GetFocusedRowCellValue("code").ToString)
                FormMatRetInDet.GVRetDetail.CloseEditor()
                FormMatRetInDet.id_mat_purc_det_list.Add(GVListPurchase.GetFocusedRowCellDisplayText("id_mat_purc_det").ToString)
                FormMatRetInDet.check_but()
                FormMatRetInDet.GVRetDetail.RefreshData()
                Close()
            End If
        End If
    End Sub

    Private Sub FormPopUpPurchaseMatDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class