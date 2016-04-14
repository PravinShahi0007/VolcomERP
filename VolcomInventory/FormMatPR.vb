Public Class FormMatPR 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"

    Private Sub FormSamplePR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_pr()
        view_mat_purc()
        view_mat_rec()
    End Sub

    Private Sub FormSamplePR_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSamplePR_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_mat_pr()
        Dim query As String = "SELECT b.id_delivery, g.id_season,g0.delivery, z.id_report_status,h.report_status,z.pr_mat_purc_note,z.id_pr_mat_purc,z.pr_mat_purc_number,z.pr_mat_purc_date,g.season,a.id_mat_purc_rec,a.mat_purc_rec_number,DATE_FORMAT(a.delivery_order_date,'%d %M %Y') AS delivery_order_date,a.delivery_order_number,b.mat_purc_number,a.mat_purc_rec_date, d.comp_name AS comp_to, "
        query += "pr_mat_purc_due_date "
        query += "FROM tb_pr_mat_purc z "
        query += "LEFT JOIN tb_mat_purc_rec a ON z.id_mat_purc_rec = a.id_mat_purc_rec "
        query += "INNER JOIN tb_mat_purc b ON z.id_mat_purc=b.id_mat_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_delivery g0 ON g0.id_delivery = b.id_delivery "
        query += "INNER JOIN tb_season g ON g0.id_season = g.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
        query += "ORDER BY g.date_season_start DESC "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPR.DataSource = data
        check_menu()
    End Sub

    Private Sub GVSamplePR_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPR.FocusedRowChanged
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

    Sub view_mat_purc()
        Dim query = "SELECT a.id_mat_purc, "
        query += "b0.id_season, b0.delivery, "
        query += "b.season, g.payment,"
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.mat_purc_number,"
        query += "(SELECT COUNT(tb_pr_mat_purc.id_pr_mat_purc) FROM tb_pr_mat_purc WHERE tb_pr_mat_purc.id_mat_purc = a.id_mat_purc) AS qty_payment, "
        query += "DATE_FORMAT(a.mat_purc_date,'%d %M %Y') AS mat_purc_date, "
        query += "DATE_FORMAT(DATE_ADD(a.mat_purc_date,INTERVAL a.mat_purc_lead_time DAY),'%d %M %Y') AS mat_purc_lead_time, "
        query += "DATE_FORMAT(DATE_ADD(a.mat_purc_date,INTERVAL (a.mat_purc_top+a.mat_purc_lead_time) DAY),'%d %M %Y') AS mat_purc_top "
        query += "FROM tb_mat_purc a "
        query += "INNER JOIN tb_season_delivery b0 ON a.id_delivery = b0.id_delivery "
        query += "INNER JOIN tb_season b ON b0.id_season = b.id_season "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "WHERE a.id_report_status >= '3' AND a.id_report_status!='5' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPurchaseNeed.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVMatPurchaseNeed.FocusedRowHandle = 0
            view_list_purchase(GVMatPurchaseNeed.GetFocusedRowCellValue("id_mat_purc").ToString)
        End If
    End Sub

    Sub view_list_purchase(ByVal id_mat_purc As String)
        Dim query = "CALL view_mat_purc_det('" & id_mat_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Sub check_menu()
        If XTCTabPR.SelectedTabPageIndex = 0 Then
            'based on payment
            If GVMatPR.RowCount < 1 Then
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
            If GVMatPurchaseNeed.RowCount < 1 Then
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

    Private Sub GVSamplePurchaseNeed_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPurchaseNeed.FocusedRowChanged
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

    Private Sub GVMatPurchaseNeed_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatPurchaseNeed.RowClick
        view_list_purchase(GVMatPurchaseNeed.GetFocusedRowCellValue("id_mat_purc").ToString)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSamplePurchaseNeed_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatPurchaseNeed.DoubleClick
        If GVMatPurchaseNeed.RowCount > 0 Then
            GVMatPR.ApplyFindFilter(GVMatPurchaseNeed.GetFocusedRowCellValue("mat_purc_number").ToString)
            XTCTabPR.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub
    '===================== end sample purchase =======================
    '===================== begin sample receive ======================
    Sub view_mat_rec()
        Dim query As String = "SELECT d.id_delivery, e.id_season, e0.delivery, d.id_mat_purc,a.id_mat_purc_rec, a.mat_purc_rec_number, a.delivery_order_number,  a.delivery_order_date, a.mat_purc_rec_date, "
        query += "(SELECT COUNT(tb_pr_mat_purc.id_pr_mat_purc) FROM tb_pr_mat_purc WHERE tb_pr_mat_purc.id_mat_purc_rec = a.id_mat_purc_rec) AS pr_created, "
        query += "a.mat_purc_rec_note, c.comp_name, c.comp_number,e.season, a.id_comp_contact_to  "
        query += "FROM tb_mat_purc_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER join tb_mat_purc d on a.id_mat_purc = d.id_mat_purc "
        query += "INNER JOIN tb_season_delivery e0 ON e0.id_delivery = d.id_delivery "
        query += "INNER JOIN tb_season e ON e.id_season = e0.id_season "
        query += "WHERE a.id_report_status >= '3' AND a.id_report_status != '5' "
        query += "ORDER BY a.id_mat_purc_rec "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatReceive.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            'show all
            GVMatReceive.FocusedRowHandle = 0
            view_list_rec(GVMatReceive.GetFocusedRowCellValue("id_mat_purc_rec").ToString)
        End If
    End Sub
    'List All Detail Sample Received
    Sub view_list_rec(ByVal id_mat_purc_rec As String)
        Dim query = "CALL view_purc_rec_mat_det('" & id_mat_purc_rec & "')"
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
        view_list_rec(GVMatReceive.GetFocusedRowCellValue("id_mat_purc_rec").ToString)
    End Sub

    Private Sub GVSampleReceive_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatReceive.DoubleClick
        If GVMatReceive.RowCount > 0 Then
            GVMatPR.ApplyFindFilter(GVMatReceive.GetFocusedRowCellValue("mat_purc_rec_number").ToString)
            XTCTabPR.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub

    Private Sub GVListReceive_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListReceive.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVMatPR_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatPR.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPR.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPR.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPR.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPR.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPR.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPR.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub

    Private Sub GVMatPurchaseNeed_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatPurchaseNeed.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchaseNeed.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchaseNeed.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchaseNeed.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchaseNeed.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchaseNeed.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchaseNeed.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub

    Private Sub GVMatReceive_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatReceive.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatReceive.IsGroupRow(rowhandle) Then
                rowhandle = GVMatReceive.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatReceive.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatReceive.IsGroupRow(rowhandle) Then
                rowhandle = GVMatReceive.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatReceive.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub

    Private Sub GVMatPR_DoubleClick(sender As Object, e As EventArgs) Handles GVMatPR.DoubleClick
        If GVMatPR.FocusedRowHandle >= 0 And GVMatPR.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class