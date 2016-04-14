Public Class FormSampleReqList
    Public id_pop_up As String = "-1"
    Public data_par As DataTable

    Private Sub FormSampleReqList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCode.Focus()
        Dim query As String = ""
        If id_pop_up = "1" Then
            query = "CALL view_stock_sample('0','0','0','0', '9999-12-01','3')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'MsgBox(data_par.Rows.Count.ToString)
            If data_par.Rows.Count = 0 Then
                GCList.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_sample") Equals _t2("id_sample") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCList.DataSource = except
            End If
        End If
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim code_par As String = TxtCode.Text.ToString
            Dim query_par As String = "SELECT b.sample_code, (a.design_display_name) as name  FROM tb_m_design a INNER JOIN tb_m_sample b ON b.id_sample = a.id_sample WHERE a.design_code='" + code_par + "' "
            Dim data As DataTable = execute_query(query_par, -1, True, "", "", "", "")
            If data.Rows.Count = 0 Then
                stopCustom("Style not found !")
            Else
                GVList.ActiveFilterString = "[code]='" + data.Rows(0)("sample_code").ToString + "' "
                TxtDesign.Text = data.Rows(0)("name").ToString
                e.SuppressKeyPress = True
                SelectNextControl(ActiveControl, True, True, True, True)
            End If
            Cursor = Cursors.Default
        End If
    End Sub


    Private Sub GVList_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVList.FocusedRowChanged

    End Sub

    Private Sub FormSampleReqList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate

    End Sub

    Private Sub GVList_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVList.FocusedColumnChanged
        Try
            If e.FocusedColumn.ToString = GVList.Columns("code").ToString Then
                GVList.FocusedColumn = GridColumnReq
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function IsLastVisibleRow(view As DevExpress.XtraGrid.Views.Grid.GridView, rowHandle As Integer) As Boolean
        Dim viewInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = TryCast(view.GetViewInfo(), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo)
        If viewInfo Is Nothing OrElse viewInfo.RowsInfo Is Nothing OrElse viewInfo.RowsInfo.Count = 0 Then
            Return False
        End If
        Return viewInfo.RowsInfo(viewInfo.RowsInfo.Count - 1).RowHandle = rowHandle
    End Function

    Private Sub FormSampleReqList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        makeSafeGV(GVList)
        GVList.ActiveFilterString = "[is_select] = 'Yes'"
        If GVList.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to select these items?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                For i As Integer = 0 To ((GVList.RowCount - 1) - GetGroupRowCount(GVList))
                    FormSampleReqSingle.newRows()
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_requisition_det", "0")
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_sample", GVList.GetRowCellValue(i, "id_sample").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("name", GVList.GetRowCellValue(i, "name").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("size", GVList.GetRowCellValue(i, "size").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVList.GetRowCellValue(i, "uom").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("qty_all_sample", GVList.GetRowCellValue(i, "qty_all_sample").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("code", GVList.GetRowCellValue(i, "code").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("sample_requisition_det_qty", GVList.GetRowCellValue(i, "qty_select"))
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_comp", GVList.GetRowCellValue(i, "id_comp").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_locator", GVList.GetRowCellValue(i, "id_wh_locator").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_rack", GVList.GetRowCellValue(i, "id_wh_rack").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_drawer", GVList.GetRowCellValue(i, "id_wh_drawer").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("comp_name", GVList.GetRowCellValue(i, "comp_name").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_locator", GVList.GetRowCellValue(i, "wh_locator").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_rack", GVList.GetRowCellValue(i, "wh_rack").ToString)
                    FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_drawer", GVList.GetRowCellValue(i, "wh_drawer").ToString)
                    FormSampleReqSingle.GVRetDetail.CloseEditor()
                    FormSampleReqSingle.GCRetDetail.RefreshDataSource()
                    FormSampleReqSingle.GVRetDetail.RefreshData()
                    Close()
                Next
                Cursor = Cursors.Default
            Else
                GVList.ActiveFilterString = ""
            End If
        Else
            stopCustom("There is no selected item.")
            GVList.ActiveFilterString = ""
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        Dim val As String = CheckEdit1.EditValue.ToString
        For i As Integer = 0 To ((GVList.RowCount - 1) - GetGroupRowCount(GVList))
            If val = "True" Then
                GVList.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVList.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub

    Private Sub RepositoryItemTextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit1.EditValueChanged
        Dim qty_limit As Integer = GVList.GetFocusedRowCellValue("qty_all_sample")
        Dim TE As DevExpress.XtraEditors.TextEdit = CType(sender, DevExpress.XtraEditors.TextEdit)
        Dim qty_select As Integer = TE.EditValue
        If qty_select > qty_limit Then
            stopCustom("Request qty can't exceed " + qty_limit.ToString)
            If qty_limit <= 0 Then
                GVList.SetFocusedRowCellValue("qty_select", 0)
            Else
                GVList.SetFocusedRowCellValue("qty_select", 1)
            End If
        End If
    End Sub
End Class