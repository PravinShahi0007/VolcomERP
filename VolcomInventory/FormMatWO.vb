Public Class FormMatWO
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMatWO_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMatWO_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub check_menu()
        If GVMatWO.RowCount < 1 Then
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
    End Sub
    Sub no_focus_gv(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
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

    Private Sub GVMatWO_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatWO.FocusedRowChanged
        no_focus_gv(sender, e)
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
    Sub view_mat_purc()
        Dim query = "SELECT a.id_report_status,h.report_status,a.id_mat_wo, "
        query += "b.id_season,a.id_delivery,i.delivery, "
        query += "b.season, g.payment, "
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.mat_wo_number,a.id_ovh,j.overhead, "
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
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatWO.DataSource = data
        check_menu()
    End Sub
    Private Sub FormMatWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mat_purc()
    End Sub
End Class