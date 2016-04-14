Public Class FormMatRecWO
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"

    Private Sub FormMatRecWO_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub view_mat_rec_purc()
        Dim query = "SELECT a.id_report_status,h.report_status,g.season,a.id_mat_wo_rec,a.mat_wo_rec_number,DATE_FORMAT(a.delivery_order_date,'%d %M %Y') AS delivery_order_date,a.delivery_order_number,b.mat_wo_number,DATE_FORMAT(a.mat_wo_rec_date,'%d %M %Y') AS mat_wo_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += "FROM tb_mat_wo_rec a INNER JOIN tb_mat_wo b ON a.id_mat_wo=b.id_mat_wo "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_delivery i ON b.id_delivery=i.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=i.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=a.id_report_status "
        query += "ORDER BY g.date_season_start DESC, a.id_mat_wo_rec DESC "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatRecPurc.DataSource = data
        check_menu()
    End Sub

    Private Sub FormMatRecWO_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMatRecWO_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMatRecWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_rec_purc()
        view_mat_wo()
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
            If GVMatWO.RowCount < 1 Then
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

    Sub view_mat_wo()
        Dim query = "SELECT a.id_report_status,h.report_status,a.id_mat_wo,NOW() as date_now, "
        query += "b.id_season,a.id_delivery,i.delivery, "
        query += "b.season, g.payment, "
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.mat_wo_number,a.id_ovh,j.overhead, "
        query += "(SELECT COUNT(tb_mat_wo_rec.id_mat_wo_rec) FROM tb_mat_wo_rec WHERE tb_mat_wo_rec.id_mat_wo = a.id_mat_wo) AS qty_receive, "
        query += "DATE_FORMAT(a.mat_wo_date,'%d %M %Y') AS mat_wo_date, "
        query += "DATE_FORMAT(DATE_ADD(a.mat_wo_date,INTERVAL a.mat_wo_lead_time DAY),'%d %M %Y') AS mat_wo_lead_time, "
        query += "DATE_FORMAT(DATE_ADD(a.mat_wo_date,INTERVAL (a.mat_wo_top+a.mat_wo_lead_time) DAY),'%d %M %Y') AS mat_wo_top "
        query += "FROM tb_mat_wo a INNER JOIN tb_season_delivery i ON a.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season b ON i.id_season = b.id_season "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON a.id_ovh = j.id_ovh "
        query += "WHERE a.id_report_status = '3' OR a.id_report_status = '4' OR a.id_report_status = '6'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatWO.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            view_list_wo(GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString)
        End If
    End Sub
    Private Sub XTCTabReceive_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabReceive.SelectedPageChanged
        check_menu()
    End Sub

    Sub view_list_wo(ByVal id_mat_wo As String)
        Dim query = "CALL view_mat_wo_det('" & id_mat_wo & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Private Sub GVMatWO_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVMatWO.RowCellStyle
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

    Private Sub GVMatWO_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatWO.DoubleClick
        If GVMatWO.RowCount > 0 Then
            GVMatRecPurc.ApplyFindFilter(GVMatWO.GetFocusedRowCellValue("mat_wo_number").ToString)
            XTCTabReceive.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVMatWO_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatWO.RowClick
        view_list_wo(GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString)
    End Sub

    Private Sub GVMatWO_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatWO.FocusedRowChanged
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

    Private Sub GVMatWO_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatWO.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatWO.IsGroupRow(rowhandle) Then
                rowhandle = GVMatWO.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatWO.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatWO.IsGroupRow(rowhandle) Then
                rowhandle = GVMatWO.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatWO.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
        If e.Column.FieldName = "id_wo_type" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatWO.IsGroupRow(rowhandle) Then
                rowhandle = GVMatWO.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatWO.GetRowCellDisplayText(rowhandle, "wo_type")
            End If
        End If
    End Sub
End Class