Public Class FormPopUpPurchaseDetail 
    Public id_sample_purc As String
    Public id_pop_up As String
    Public action As String
    Private Sub FormPopUpPurchaseDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_pop_up = "1" Then
            Dim query As String = "SELECT * FROM tb_sample_purc WHERE id_sample_purc = '" + id_sample_purc + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LabelSubTitle.Text = "Purchase Sample :" + data.Rows(0)("sample_purc_number").ToString
            view_list_purchase(id_sample_purc)
        ElseIf id_pop_up = "2" Then
            Dim query As String = "SELECT * FROM tb_sample_purc WHERE id_sample_purc = '" + id_sample_purc + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LabelSubTitle.Text = "Purchase Sample :" + data.Rows(0)("sample_purc_number").ToString
            view_list_purchase(id_sample_purc)
        End If
    End Sub
    Sub view_list_purchase(ByVal id_sample_purc As String)
        Dim query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If id_pop_up = "1" Then
            Dim i As Integer = data.Rows.Count - 1
            While (i >= 0)
                If FormSampleRetOutSingle.id_sample_purc_det_list.Contains(data.Rows(i)("id_sample_purc_det").ToString) Then
                    data.Rows.RemoveAt(i)
                End If
                i = i - 1
            End While
        ElseIf id_pop_up = "2" Then
            Dim i As Integer = data.Rows.Count - 1
            While (i >= 0)
                If FormSampleRetInSingle.id_sample_purc_det_list.Contains(data.Rows(i)("id_sample_purc_det").ToString) Then
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
                FormSampleRetOutSingle.newRows()
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_purc_ret_out_det", "0")
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellValue("uom").ToString)
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("sample_purc_ret_out_det_qty", "0")
                FormSampleRetOutSingle.GVRetDetail.CloseEditor()
                FormSampleRetOutSingle.id_sample_purc_det_list.Add(GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                Close()
            ElseIf action = "upd" Then
                Dim id_sample_purc_det_old As String = FormSampleRetOutSingle.GVRetDetail.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
                FormSampleRetOutSingle.id_sample_purc_det_list.Remove(id_sample_purc_det_old)
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_purc_ret_out_det", "0")
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormSampleRetOutSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellValue("uom").ToString)
                FormSampleRetOutSingle.GVRetDetail.CloseEditor()
                FormSampleRetOutSingle.id_sample_purc_det_list.Add(GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                Close()
            End If
        ElseIf id_pop_up = "2" Then
            If action = "ins" Then
                FormSampleRetInSingle.newRows()
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_purc_ret_in_det", "0")
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellValue("uom").ToString)
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("sample_purc_ret_in_det_qty", "0")
                FormSampleRetInSingle.GVRetDetail.CloseEditor()
                FormSampleRetInSingle.id_sample_purc_det_list.Add(GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                Close()
            ElseIf action = "upd" Then
                Dim id_sample_purc_det_old As String = FormSampleRetInSingle.GVRetDetail.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
                FormSampleRetInSingle.id_sample_purc_det_list.Remove(id_sample_purc_det_old)
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_purc_ret_in_det", "0")
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormSampleRetInSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellValue("uom").ToString)
                FormSampleRetInSingle.GVRetDetail.CloseEditor()
                FormSampleRetInSingle.id_sample_purc_det_list.Add(GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString)
                Close()
            End If

        End If
    End Sub

    Private Sub FormPopUpPurchaseDetail_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class