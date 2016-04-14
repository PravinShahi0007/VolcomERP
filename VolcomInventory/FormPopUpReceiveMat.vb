Public Class FormPopUpReceiveMat 
    Public id_pop_up As String = "-1"
    Public id_rec As String = "-1"
    Public id_purc As String = "-1"
    Public action As String
    '1 : PR Mat

    Private Sub FormPopUpReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_rec()
        If id_rec <> "-1" Then
            GVMatReceive.FocusedRowHandle = find_row(GVMatReceive, "id_mat_purc_rec", id_rec)
        End If
    End Sub
    'List Sample All Received
    Sub view_mat_rec()
        Dim query As String = "SELECT d.id_delivery, e.id_season, d.id_mat_purc,a.id_mat_purc_rec, d.mat_purc_number,a.mat_purc_rec_number, a.delivery_order_number,  a.delivery_order_date, a.mat_purc_rec_date, "
        query += "a.mat_purc_rec_note, c.comp_name, c.comp_number,e.season, e0.delivery,a.id_comp_contact_to  "
        query += "FROM tb_mat_purc_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER join tb_mat_purc d on a.id_mat_purc = d.id_mat_purc "
        query += "INNER JOIN tb_season_delivery e0 ON d.id_delivery = e0.id_delivery "
        query += "INNER JOIN tb_season e ON e.id_season = e0.id_season "
        query += "WHERE a.id_report_status >= '3' AND a.id_report_status != '5' "

        If id_purc <> "-1" Then
            query += "AND a.id_mat_purc='" & id_purc & "' "
        End If

        query += "ORDER BY a.id_mat_purc_rec "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatReceive.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            BtnSave.Enabled = True
            If id_pop_up = "1" Then
                view_list_rec_limit(GVMatReceive.GetFocusedRowCellValue("id_mat_purc_rec").ToString)
            Else
                view_list_rec(GVMatReceive.GetFocusedRowCellValue("id_mat_purc_rec").ToString)
            End If
        Else
            BtnSave.Enabled = False
        End If
    End Sub
    'List All Detail Sample Received
    Sub view_list_rec(ByVal id_mat_purc_rec As String)
        Dim query = "CALL view_purc_rec_mat_det('" & id_mat_purc_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BtnSave.Enabled = True
        Else
            BtnSave.Enabled = False
        End If
    End Sub
    'List Custom Detail Sample Received
    Sub view_list_rec_limit(ByVal id_mat_purc_rec As String)
        'Dim query = "CALL view_purc_rec_mat_det('" & id_mat_purc_rec & "')"
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCListPurchase.DataSource = data
        'Dim i As Integer = data.Rows.Count - 1
        'While (i >= 0)
        '    If FormSamplePLSingle.id_mat_purc_rec_list.Contains(data.Rows(i)("id_mat_purc_det").ToString) Then
        '        data.Rows.RemoveAt(i)
        '    End If
        '    i = i - 1
        'End While
        'If data.Rows.Count > 0 Then
        '    BtnSave.Enabled = True
        'Else
        '    BtnSave.Enabled = False
        'End If
    End Sub
    ' Row Focus
    Private Sub GVMatReceive_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatReceive.FocusedRowChanged
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
        view_list_rec(GVMatReceive.GetFocusedRowCellValue("id_mat_purc_rec").ToString)
    End Sub
    'Form Closed
    Private Sub FormPopUpPurchase_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Custom Number View
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If id_pop_up = "1" Then
            FormMatPRDet.id_rec = GVMatReceive.GetFocusedRowCellValue("id_mat_purc_rec").ToString
            FormMatPRDet.TERecNumber.Text = GVMatReceive.GetFocusedRowCellValue("mat_purc_rec_number").ToString
            FormMatPRDet.id_purc = GVMatReceive.GetFocusedRowCellValue("id_mat_purc").ToString
            FormMatPRDet.TEWONumber.Text = GVMatReceive.GetFocusedRowCellValue("mat_purc_rec_number").ToString
            FormMatPRDet.TEDONumber.Text = GVMatReceive.GetFocusedRowCellValue("delivery_order_number").ToString
            FormMatPRDet.TECompTo.Text = GVMatReceive.GetFocusedRowCellValue("comp_name").ToString

            FormMatPRDet.view_po()
            FormMatPRDet.view_list_rec()
            FormMatPRDet.GConListPurchase.Enabled = True
            FormMatPRDet.calculate()
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub GVMatReceive_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVMatReceive.ColumnFilterChanged
        view_list_rec(GVMatReceive.GetFocusedRowCellValue("id_mat_purc_rec").ToString)
    End Sub
End Class