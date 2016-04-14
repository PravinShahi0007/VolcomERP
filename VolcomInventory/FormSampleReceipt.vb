Public Class FormSampleReceipt 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    'Load Form
    Private Sub FormSampleReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPL()
    End Sub
    'Activated Form
    Private Sub FormSampleReceipt_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    'Deadctivated Form
    Private Sub FormSampleReceipt_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'View Packing List
    'Sub viewReceipt()
    '    Dim query As String = "SELECT a.id_receipt_sample, b.id_pl_sample_purc, a.id_comp_contact_from , a.id_comp_contact_to,a.receipt_sample_date, a.receipt_sample_note, a.receipt_sample_number, g.report_status, "
    '    query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to "
    '    query += "FROM tb_receipt_sample a "
    '    query += "INNER JOIN tb_pl_sample_purc b ON a.id_pl_sample_purc = b.id_pl_sample_purc "
    '    query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
    '    query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
    '    query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
    '    query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
    '    query += "INNER JOIN tb_lookup_report_status g ON a.id_report_status = g.id_report_status "
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '    GCReceipt.DataSource = data
    '    If data.Rows.Count > 0 Then 'ada data
    '        bnew_active = 1
    '        bedit_active = 1
    '        bdel_active = 1
    '    Else
    '        bnew_active = "1"
    '        bedit_active = "0"
    '        bdel_active = "0"
    '    End If
    '    checkFormAccess(Name)
    '    button_main(bnew_active, bedit_active, bdel_active)
    'End Sub
    Sub viewPL()
        Dim query As String = "SELECT a.id_pl_sample_purc, a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_purc_date, a.pl_sample_purc_note, a.pl_sample_purc_number, b.pl_category, "
        query += "a.receipt_sample_date, a.receipt_sample_note, a.receipt_sample_number, g.report_status, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.season "
        query += "FROM tb_pl_sample_purc a "
        ' query += "INNER JOIN tb_pl_sample_purc_rec a2 ON a.id_pl_sample_purc = a2.id_pl_sample_purc "
        query += "INNER JOIN tb_sample_purc a3 ON a.id_sample_purc = a3.id_sample_purc "
        query += "INNER JOIN tb_lookup_pl_category b ON a.id_pl_category = b.id_pl_category "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_season h ON h.id_season = a3.id_season "
        query += "INNER JOIN tb_lookup_report_status g ON a.id_report_status_rec = g.id_report_status WHERE receipt_sample_number != '-' "
        query += "ORDER BY a.id_pl_sample_purc DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReceipt.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            bnew_active = 1
            bedit_active = 1
            bdel_active = 1
        Else
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVReceipt_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVReceipt.FocusedRowChanged
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
End Class