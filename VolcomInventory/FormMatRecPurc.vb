Public Class FormMatRecPurc
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"

    Private Sub FormMatRecPurc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_rec_purc()
        view_mat_purc()
    End Sub

    Sub view_mat_rec_purc()
        Dim query = "SELECT a.id_report_status,h.report_status,i.delivery,b.id_delivery,i.id_season,g.season,a.id_mat_purc_rec,a.mat_purc_rec_number,a.delivery_order_date,a.delivery_order_number,b.mat_purc_number,a.mat_purc_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += "FROM tb_mat_purc_rec a INNER JOIN tb_mat_purc b ON a.id_mat_purc=b.id_mat_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_delivery i ON b.id_delivery=i.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=i.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=a.id_report_status "
        query += "ORDER BY g.date_season_start DESC, a.id_mat_purc_rec DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatRecPurc.DataSource = data
        If data.Rows.Count > 0 Then
            GVMatRecPurc.FocusedRowHandle = 0
        End If
        check_menu()
    End Sub

    Private Sub FormMatRecPurc_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMatRecPurc_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMatRecPurc_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCTabReceive.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVMatRecPurc.RowCount < 1 Then
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
        ElseIf XTCTabReceive.SelectedTabPageIndex = 1 Then
            'based on PO
            If GVMatPurchase.RowCount < 1 Then
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
    Private Sub GVSamplePurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatRecPurc.FocusedRowChanged
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
        Dim query = "SELECT a.id_report_status,h.report_status,a.id_mat_purc,NOW() as date_now, "
        query += "b.id_season,a.id_delivery,i.delivery, "
        query += "b.season, g.payment,"
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.mat_purc_number,"
        query += "(SELECT COUNT(tb_mat_purc_rec.id_mat_purc_rec) FROM tb_mat_purc_rec WHERE tb_mat_purc_rec.id_mat_purc = a.id_mat_purc) AS qty_receive,"
        query += "a.mat_purc_date, "
        query += "DATE_ADD(a.mat_purc_date,INTERVAL a.mat_purc_lead_time DAY) AS mat_purc_lead_time, "
        query += "DATE_ADD(a.mat_purc_date,INTERVAL (a.mat_purc_top+a.mat_purc_lead_time) DAY) AS mat_purc_top "
        query += "FROM tb_mat_purc a INNER JOIN tb_season_delivery i ON a.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season b ON i.id_season = b.id_season "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "WHERE a.id_report_status = '3' OR a.id_report_status = '4' OR a.id_report_status = '6' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            GVMatPurchase.FocusedRowHandle = 0
            view_list_purchase(GVMatPurchase.GetFocusedRowCellValue("id_mat_purc"))
        End If
        check_menu()
    End Sub

    Sub view_list_purchase(ByVal id_mat_purc As String)
        Dim query = "CALL view_mat_purc_det('" & id_mat_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Private Sub XTCTabReceive_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabReceive.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVMatPurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPurchase.FocusedRowChanged
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

    Private Sub GVMatPurchase_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatPurchase.DoubleClick
        If GVMatPurchase.RowCount > 0 Then
            GVMatRecPurc.ApplyFindFilter(GVMatPurchase.GetFocusedRowCellValue("mat_purc_number").ToString)
            XTCTabReceive.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub

    Private Sub GVMatPurchase_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVMatPurchase.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_rec As Date

        If e.Column.FieldName = "qty_receive" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_rec = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("sample_purc_lead_time")))
            If date_now > date_rec And View.GetRowCellDisplayText(e.RowHandle, View.Columns("qty_receive")) <= 0 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
    End Sub

    Private Sub GVMatPurchase_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatPurchase.RowClick
        view_list_purchase(GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVMatPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchase.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchase.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchase.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchase.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchase.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchase.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub

    Private Sub GVMatRecPurc_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatRecPurc.DoubleClick
        FormMain.but_edit()
    End Sub
End Class