Public Class FormPopUpReceive 
    Public id_pop_up As String = "-1"
    Public id_rec As String = "-1"
    Public id_purc As String = "-1"
    Public action As String
    '1 : sample PL Receiving
    '2 : PR SAMPLE

    Private Sub FormPopUpReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample_rec()
        If id_rec <> "-1" Then
            GVSampleReceive.FocusedRowHandle = find_row(GVSampleReceive, "id_sample_purc_rec", id_rec)
        End If
        'If id_pop_up = "1" Then
        '    view_sample_rec()
        '    If id_rec <> "-1" Then
        '        GVSampleReceive.FocusedRowHandle = find_row(GVSampleReceive, "id_sample_purc_rec", id_rec)
        '    End If
        'ElseIf id_pop_up = "2" Then
        '    view_sample_rec()
        '    If id_rec <> "-1" Then
        '        GVSampleReceive.FocusedRowHandle = find_row(GVSampleReceive, "id_sample_purc_rec", id_rec)
        '    End If
        'End If
    End Sub
    'List Sample All Received
    Sub view_sample_rec()
        Dim query As String = "SELECT d.id_sample_purc,a.id_sample_purc_rec, a.sample_purc_rec_number, a.delivery_order_number,  a.delivery_order_date, a.sample_purc_rec_date, "
        query += "a.sample_purc_rec_note, c.comp_name, c.comp_number,e.season_orign, a.id_comp_contact_to  "
        query += "FROM tb_sample_purc_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER join tb_sample_purc d on a.id_sample_purc = d.id_sample_purc "
        query += "INNER JOIN tb_season_orign e ON e.id_season_orign = d.id_season_orign "

        If id_purc <> "-1" Then
            query += "WHERE a.id_sample_purc='" & id_purc & "' "
        End If

        query += "ORDER BY a.id_sample_purc_rec "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleReceive.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            BtnSave.Enabled = True
            If id_pop_up = "1" Then
                view_list_rec_limit(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
            Else
                view_list_rec(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
            End If
        Else
            BtnSave.Enabled = False
        End If
    End Sub
    'List All Detail Sample Received
    Sub view_list_rec(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_purc_rec_sample_det('" & id_sample_purc_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BtnSave.Enabled = True
        Else
            BtnSave.Enabled = False
        End If
    End Sub
    'List Custom Detail Sample Received
    Sub view_list_rec_limit(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_purc_rec_sample_det('" & id_sample_purc_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        Dim i As Integer = data.Rows.Count - 1
        While (i >= 0)
            If FormSamplePLSingle.id_sample_purc_rec_list.Contains(data.Rows(i)("id_sample_purc_det").ToString) Then
                data.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
        If data.Rows.Count > 0 Then
            BtnSave.Enabled = True
        Else
            BtnSave.Enabled = False
        End If
    End Sub
    'Sample Received
    Private Sub GVSampleReceive_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSampleReceive.RowClick
        If id_pop_up = "1" Then
            view_list_rec_limit(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
        Else
            view_list_rec(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
        End If
    End Sub
    ' Row Focus
    Private Sub GVSampleReceive_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleReceive.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub
    'Form Closed
    Private Sub FormPopUpPurchase_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Cancel
    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If id_pop_up = "1" Then
            'FormSamplePLSingle.id_sample_purc_rec = GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString
            'FormSamplePLSingle.TxtOrderNumber.Text = GVSampleReceive.GetFocusedRowCellValue("sample_purc_rec_number").ToString
            'FormSamplePLSingle.TxtCodeCompFrom.Text = GVSampleReceive.GetFocusedRowCellValue("comp_number").ToString
            'FormSamplePLSingle.TxtNameCompFrom.Text = GVSampleReceive.GetFocusedRowCellValue("comp_name").ToString
            'FormSamplePLSingle.GConListPL.Enabled = True
            'FormSamplePLSingle.id_comp_contact_from = GVSampleReceive.GetFocusedRowCellValue("id_comp_contact_to").ToString
            'FormSamplePLSingle.viewListRec()
            If action = "ins" Then
                FormSamplePLSingle.GVListPurchase.AddNewRow()
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("id_sample_purc_rec", GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("no", "0")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("id_pl_sample_purc_det", "0")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("qty_issue", "0")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("pl_sample_purc_det_note", "")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("id_pl_sample_purc_rec", "0")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("id_sample_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_rec_det").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("sample_purc_rec_det_qty", GVListPurchase.GetFocusedRowCellDisplayText("sample_purc_rec_det_qty").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("code", GVListPurchase.GetFocusedRowCellDisplayText("code").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellDisplayText("uom").ToString)
                FormSamplePLSingle.GVListPurchase.CloseEditor()
                FormSamplePLSingle.GVListPurchase.FocusedRowHandle = 0
                FormSamplePLSingle.id_sample_purc_rec_list.Add(GVListPurchase.GetFocusedRowCellValue("id_sample_purc_det").ToString)
                'If Not FormSamplePLSingle.id_receiving_list.Contains(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString) Then
                '    FormSamplePLSingle.id_receiving_list.Add(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
                'End If
            ElseIf action = "upd" Then
                Dim id_sample_purc_rec_det_old As String = FormSamplePLSingle.GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_det").ToString
                FormSamplePLSingle.id_sample_purc_rec_list.Remove(id_sample_purc_rec_det_old)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("id_sample_purc_rec", GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("no", "0")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("id_pl_sample_purc_det", "0")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("qty_issue", "0")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("pl_sample_purc_det_note", " ")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("id_pl_sample_purc_rec", "0")
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("id_sample_purc_det", GVListPurchase.GetFocusedRowCellDisplayText("id_sample_purc_rec_det").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("sample_purc_rec_det_qty", GVListPurchase.GetFocusedRowCellDisplayText("sample_purc_rec_det_qty").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("name", GVListPurchase.GetFocusedRowCellDisplayText("name").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("code", GVListPurchase.GetFocusedRowCellDisplayText("code").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("size", GVListPurchase.GetFocusedRowCellValue("size").ToString)
                FormSamplePLSingle.GVListPurchase.SetFocusedRowCellValue("uom", GVListPurchase.GetFocusedRowCellDisplayText("uom").ToString)
                FormSamplePLSingle.GVListPurchase.CloseEditor()
                FormSamplePLSingle.id_sample_purc_rec_list.Add(GVListPurchase.GetFocusedRowCellValue("id_sample_purc_det").ToString)
                'If Not FormSamplePLSingle.findReceiving(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString) Then
                '    FormSamplePLSingle.id_receiving_list.Remove(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
                'End If
            End If
            Dispose()
        ElseIf id_pop_up = "2" Then
            FormSamplePRDet.id_rec = GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString
            FormSamplePRDet.TERecNumber.Text = GVSampleReceive.GetFocusedRowCellValue("sample_purc_rec_number").ToString
            FormSamplePRDet.id_purc = GVSampleReceive.GetFocusedRowCellValue("id_sample_purc").ToString
            FormSamplePRDet.TEPONumber.Text = GVSampleReceive.GetFocusedRowCellValue("sample_purc_rec_number").ToString
            FormSamplePRDet.TEDONumber.Text = GVSampleReceive.GetFocusedRowCellValue("delivery_order_number").ToString
            FormSamplePRDet.TECompTo.Text = GVSampleReceive.GetFocusedRowCellValue("comp_name").ToString

            FormSamplePRDet.view_po()
            FormSamplePRDet.view_list_rec()
            FormSamplePRDet.GConListPurchase.Enabled = True
            Close()
        End If
    End Sub
    'Custom Number View
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVSampleReceive_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSampleReceive.DoubleClick
        If id_pop_up = "1" Then
            Try
                Dim id_sample_purc_rec = GVSampleReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString
                FormInfoPLSample.id_receiving = id_sample_purc_rec
                FormInfoPLSample.id_info = "1"
                FormInfoPLSample.number_receiving = GVSampleReceive.GetFocusedRowCellDisplayText("sample_purc_rec_number").ToString
                FormInfoPLSample.Show()
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class