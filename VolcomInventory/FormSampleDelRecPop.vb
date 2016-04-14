Public Class FormSampleDelRecPop 
    Public id_pop_up As String = "-1"

    Private Sub FormSampleDelRecPop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleDel()
    End Sub

    Sub viewSampleDel()
        Dim query_c As ClassSampleDel = New ClassSampleDel()
        Dim query As String = query_c.queryMain
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDel.DataSource = data
        GVSampleDel.ActiveFilterString = "[total_qty_delivered] > [total_qty_received] "
    End Sub

    Sub viewSampleDelDet()
        Dim id_sample_del As String = "-1"
        Try
            id_sample_del = GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
        Catch ex As Exception
        End Try

        Dim query_c As ClassSampleDel = New ClassSampleDel()
        Dim query As String = query_c.queryDetail(id_sample_del)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDelList.DataSource = data
    End Sub

    Private Sub GVSampleDel_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDel.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        viewSampleDelDet()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSampleDelRecPop_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            FormSampleDelRecDet.GVDrawer.ActiveFilter.Clear()
            FormSampleDelRecDet.TxtPLCategory.Text = GVSampleDel.GetFocusedRowCellValue("pl_category").ToString
            FormSampleDelRecDet.TxtSampleDelNumber.Text = GVSampleDel.GetFocusedRowCellValue("sample_del_number").ToString
            FormSampleDelRecDet.id_comp_contact_from = GVSampleDel.GetFocusedRowCellValue("id_comp_contact_from").ToString
            FormSampleDelRecDet.TxtCodeCompFrom.Text = GVSampleDel.GetFocusedRowCellValue("comp_number_from").ToString
            FormSampleDelRecDet.TxtNameCompFrom.Text = GVSampleDel.GetFocusedRowCellValue("comp_name_from").ToString
            FormSampleDelRecDet.id_comp_contact_to = GVSampleDel.GetFocusedRowCellValue("id_comp_contact_to").ToString
            FormSampleDelRecDet.TxtCodeCompTo.Text = GVSampleDel.GetFocusedRowCellValue("comp_number_to").ToString
            FormSampleDelRecDet.TxtNameCompTo.Text = GVSampleDel.GetFocusedRowCellValue("comp_name_to").ToString
            FormSampleDelRecDet.id_sample_del = GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
            FormSampleDelRecDet.viewSampleDelDet()
            FormSampleDelRecDet.viewDetailBC()
            FormSampleDelRecDet.viewDetailDrawer()
            FormSampleDelRecDet.GroupControlListItem.Enabled = True
            FormSampleDelRecDet.GroupControlDrawerDetail.Enabled = True
            FormSampleDelRecDet.GroupControlScannedItem.Enabled = True
            FormSampleDelRecDet.BtnInfoSrs.Enabled = True
            Dim id_sample_del_detx As String = "-1"
            Try
                id_sample_del_detx = FormSampleDelRecDet.GVItemList.GetFocusedRowCellValue("id_sample_del_det").ToString
            Catch ex As Exception
            End Try
            FormSampleDelRecDet.GVDrawer.ActiveFilterString = "[id_sample_del_det]='" + id_sample_del_detx + "'"
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSampleDelList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSampleDelList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class