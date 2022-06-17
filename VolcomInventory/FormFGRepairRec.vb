Public Class FormFGRepairRec
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGRepairRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        'list
        viewRepairList()
    End Sub

    Private Sub FormFGRepairRec_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If XTCRepairRec.SelectedTabPageIndex = 0 Then
            If GVRepairRec.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        Else
            If GVRepairRec.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        If XTCRepairRec.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = 0
            Try
                indeks = GVRepairRec.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            Dim indeks As Integer = 0
            Try
                indeks = GVRepairList.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVRepairRec_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRepairRec.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVRepairRec_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRepairRec.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVRepairList_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRepairList.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVRepairList_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRepairList.FocusedRowChanged
        noManipulating()
    End Sub

    Sub viewData()
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query_c As New ClassFGRepairRec()
        'Dim query As String = query_c.queryMain("AND (rec.fg_repair_rec_date>='" + date_from_selected + "' AND rec.fg_repair_rec_date<='" + date_until_selected + "') ", "2")
        Dim query As String = "Select rec.id_fg_repair_rec, r.id_fg_repair, "
        query += "rec.id_wh_drawer_from, comp_frm.id_comp As `id_comp_from`, comp_frm.comp_number As `comp_number_from`, comp_frm.comp_name As `comp_name_from`, CONCAT(comp_frm.comp_number,' - ', comp_frm.comp_name) AS `comp_from`, "
        query += "rec.id_wh_drawer_to, comp_to.id_comp As `id_comp_to`, comp_to.comp_number As `comp_number_to`, comp_to.comp_name As `comp_name_to`, CONCAT(comp_to.comp_number,' - ', comp_to.comp_name) AS `comp_to`, "
        query += "rec.fg_repair_rec_number, r.fg_repair_number, rec.fg_repair_rec_date, DATE_FORMAT(rec.fg_repair_rec_date, '%Y-%m-%d') AS fg_repair_rec_datex, "
        query += "rec.fg_repair_rec_note, rec.id_report_status, stt.report_status, rec.is_use_unique_code, IFNULL(COUNT(id_fg_repair_rec_det),0) AS `total_qty` "
        query += "From tb_fg_repair_rec rec 
        INNER JOIN tb_fg_repair_rec_det recd ON recd.id_fg_repair_rec = rec.id_fg_repair_rec "
        query += "INNER JOIN tb_fg_repair r ON r.id_fg_repair = rec.id_fg_repair "
        query += "INNER Join tb_m_wh_drawer drw_frm On drw_frm.id_wh_drawer = rec.id_wh_drawer_from  "
        query += "INNER Join tb_m_comp comp_frm On comp_frm.id_drawer_def = drw_frm.id_wh_drawer  "
        query += "INNER Join tb_m_wh_drawer drw_to On drw_to.id_wh_drawer = rec.id_wh_drawer_to "
        query += "INNER Join tb_m_comp comp_to On comp_to.id_drawer_def = drw_to.id_wh_drawer "
        query += "INNER Join tb_lookup_report_status stt On stt.id_report_status = rec.id_report_status "
        query += "WHERE rec.id_fg_repair_rec>0 "
        query += "AND (rec.fg_repair_rec_date>='" + date_from_selected + "' AND rec.fg_repair_rec_date<='" + date_until_selected + "') 
        GROUP BY rec.id_fg_repair_rec "
        query += "ORDER BY rec.id_fg_repair_rec DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepairRec.DataSource = data
        check_menu()
    End Sub

    Sub viewRepairList()
        Dim query_c As New ClassFGRepairRec()
        Dim query As String = query_c.queryRepairList("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepairList.DataSource = data
        check_menu()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGRepairRec_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCRepairRec_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRepairRec.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormFGRepairRecDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        FormFGRepairRecDet.id_pre = "2"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRepairRec_DoubleClick(sender As Object, e As EventArgs) Handles GVRepairRec.DoubleClick
        If GVRepairRec.FocusedRowHandle >= 0 And GVRepairRec.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class