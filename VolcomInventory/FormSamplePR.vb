Public Class FormSamplePR
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"

    Private Sub FormSamplePR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_sample_pr()
        view_sample_purc()
        view_sample_rec()
    End Sub

    Private Sub FormSamplePR_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSamplePR_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_sample_pr()
        Dim query As String = "SELECT z.id_report_status,h.report_status,z.pr_sample_purc_note,z.id_pr_sample_purc,z.pr_sample_purc_number,z.pr_sample_purc_date,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,a.delivery_order_date,a.delivery_order_number,b.sample_purc_number,a.sample_purc_rec_date, d.comp_name AS comp_to, "
        query += "DATE_ADD(b.sample_purc_date,INTERVAL (b.sample_purc_top+b.sample_purc_lead_time) DAY) AS sample_purc_top "
        query += "FROM tb_pr_sample_purc z "
        query += "LEFT JOIN tb_sample_purc_rec a ON z.id_sample_purc_rec = a.id_sample_purc_rec "
        query += "INNER JOIN tb_sample_purc b ON z.id_sample_purc=b.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePR.DataSource = data
        check_menu()
    End Sub

    Private Sub GVSamplePR_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePR.FocusedRowChanged
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

    Sub view_sample_purc()
        Dim query = "SELECT a.id_sample_purc, "
        query += "a.id_season_orign, "
        query += "b.season_orign, g.payment,"
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.sample_purc_number,"
        query += "(SELECT COUNT(tb_pr_sample_purc.id_pr_sample_purc) FROM tb_pr_sample_purc WHERE tb_pr_sample_purc.id_sample_purc = a.id_sample_purc) AS qty_payment, "
        query += "a.sample_purc_date, "
        query += "DATE_ADD(a.sample_purc_date,INTERVAL a.sample_purc_lead_time DAY) AS sample_purc_lead_time, "
        query += "DATE_ADD(a.sample_purc_date,INTERVAL (a.sample_purc_top+a.sample_purc_lead_time) DAY) AS sample_purc_top "
        query += "FROM tb_sample_purc a INNER JOIN tb_season_orign b ON a.id_season_orign = b.id_season_orign "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "WHERE a.id_report_status = '3' OR a.id_report_status = '4' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePurchaseNeed.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSamplePurchaseNeed.FocusedRowHandle = 0
            view_list_purchase(GVSamplePurchaseNeed.GetFocusedRowCellValue("id_sample_purc").ToString)
        End If
    End Sub

    Sub view_list_purchase(ByVal id_sample_purc As String)
        Dim query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Sub check_menu()
        If XTCTabPR.SelectedTabPageIndex = 0 Then
            'based on payment
            If GVSamplePR.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        ElseIf XTCTabPR.SelectedTabPageIndex = 1 Then
            'based on PO
            If GVSamplePurchaseNeed.RowCount < 1 Then
                'hide all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        ElseIf XTCTabPR.SelectedTabPageIndex = 2 Then
            'based on PO
            If GVMatReceive.RowCount < 1 Then
                'hide all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        End If
    End Sub

    Private Sub XTCTabPR_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabPR.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVSamplePurchaseNeed_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePurchaseNeed.FocusedRowChanged
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

    Private Sub GVSamplePurchaseNeed_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSamplePurchaseNeed.RowClick
        view_list_purchase(GVSamplePurchaseNeed.GetFocusedRowCellValue("id_sample_purc").ToString)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSamplePurchaseNeed_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSamplePurchaseNeed.DoubleClick
        If GVSamplePurchaseNeed.RowCount > 0 Then
            GVSamplePR.ApplyFindFilter(GVSamplePurchaseNeed.GetFocusedRowCellValue("sample_purc_number").ToString)
            XTCTabPR.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub
    '===================== end sample purchase =======================
    '===================== begin sample receive ======================
    Sub view_sample_rec()
        Dim query As String = "SELECT d.id_sample_purc,a.id_sample_purc_rec, a.sample_purc_rec_number, a.delivery_order_number,  a.delivery_order_date, a.sample_purc_rec_date, "
        query += "(SELECT COUNT(tb_pr_sample_purc.id_pr_sample_purc) FROM tb_pr_sample_purc WHERE tb_pr_sample_purc.id_sample_purc_rec = a.id_sample_purc_rec) AS pr_created, "
        query += "a.sample_purc_rec_note, c.comp_name, c.comp_number,e.season_orign, a.id_comp_contact_to  "
        query += "FROM tb_sample_purc_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER join tb_sample_purc d on a.id_sample_purc = d.id_sample_purc "
        query += "INNER JOIN tb_season_orign e ON e.id_season_orign = d.id_season_orign "
        query += "WHERE a.id_report_status = '3' OR a.id_report_status = '4' "
        query += "ORDER BY a.id_sample_purc_rec "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatReceive.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            'show all
            GVMatReceive.FocusedRowHandle = 0
            view_list_rec(GVMatReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
        End If
    End Sub
    'List All Detail Sample Received
    Sub view_list_rec(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_purc_rec_sample_det('" & id_sample_purc_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListReceive.DataSource = data
    End Sub
    '============================= end sample receive =====================

    Private Sub GVSampleReceive_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatReceive.FocusedRowChanged
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

    Private Sub GVSampleReceive_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatReceive.RowClick
        view_list_rec(GVMatReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
    End Sub

    Private Sub GVSampleReceive_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatReceive.DoubleClick
        If GVMatReceive.RowCount > 0 Then
            GVSamplePR.ApplyFindFilter(GVMatReceive.GetFocusedRowCellValue("sample_purc_rec_number").ToString)
            XTCTabPR.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub

    Private Sub GVListReceive_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListReceive.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class