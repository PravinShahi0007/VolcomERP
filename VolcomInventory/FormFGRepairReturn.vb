Public Class FormFGRepairReturn
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_from_vendor As Boolean = False

    Private Sub FormFGRepairReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        If is_from_vendor = True Then
            Text = "Receive Repair from Vendor"
            XTPRepairList.PageVisible = True
            viewRepairList()
        Else
            XTPRepairList.PageVisible = False
        End If
    End Sub

    Sub viewRepairList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT a.id_fg_repair, rep.fg_repair_number, rep.fg_repair_date, 
        CONCAT(v.comp_number, ' - ',v.comp_name) AS `vendor`
        FROM (	
          SELECT rd.id_product, rd.id_fg_repair, COUNT(rd.id_fg_repair_det) AS `qty_repair`, IFNULL(ret.qty,0) AS `qty_return`
          FROM tb_fg_repair_det rd
          INNER JOIN tb_fg_repair r ON r.id_fg_repair = rd.id_fg_repair
          LEFT JOIN (
             SELECT retd.id_product, ret.id_fg_repair, COUNT(retd.id_product) AS `qty` 
             FROM tb_fg_repair_return ret
             INNER JOIN tb_fg_repair_return_det retd ON retd.id_fg_repair_return = ret.id_fg_repair_return
             WHERE ret.id_report_status!=5 AND ret.is_from_vendor=1
             GROUP BY retd.id_product, ret.id_fg_repair
          ) ret ON ret.id_product = rd.id_product AND ret.id_fg_repair = r.id_fg_repair
          WHERE r.id_report_status=6 AND r.is_to_vendor=1 AND r.fg_repair_date>='2021-01-29'
          GROUP BY rd.id_product, rd.id_fg_repair
          HAVING qty_repair<>qty_return
        ) a 
        INNER JOIN tb_fg_repair rep ON rep.id_fg_repair = a.id_fg_repair
        INNER JOIN tb_m_comp v ON v.id_drawer_def = rep.id_wh_drawer_to
        GROUP BY rep.id_fg_repair "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepairList.DataSource = data
        GVRepairList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGRepairReturn_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGRepairReturn_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVRepairReturn.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = 0
        Try
            indeks = GVRepairReturn.FocusedRowHandle
        Catch ex As Exception
        End Try
        If indeks < 0 Then
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        Else
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVRepairReturn_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRepairReturn.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVRepairReturn_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRepairReturn.FocusedRowChanged
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

        Dim is_vendor As String = ""
        If is_from_vendor = True Then
            is_vendor = "1"
        Else
            is_vendor = "2"
        End If

        Dim query_c As New ClassFGRepairReturn()
        'Dim query As String = query_c.queryMain("AND r.is_from_vendor=" + is_vendor + " AND (r.fg_repair_return_date>='" + date_from_selected + "' AND r.fg_repair_return_date<='" + date_until_selected + "') ", "2")
        Dim query As String = "Select r.id_fg_repair_return, "
        query += "r.id_wh_drawer_from, comp_frm.id_comp As `id_comp_from`, comp_frm.comp_number As `comp_number_from`, comp_frm.comp_name As `comp_name_from`, CONCAT(comp_frm.comp_number,' - ', comp_frm.comp_name) AS `comp_from`, "
        query += "r.id_wh_drawer_to, comp_to.id_comp As `id_comp_to`, comp_to.comp_number As `comp_number_to`, comp_to.comp_name As `comp_name_to`, CONCAT(comp_to.comp_number,' - ', comp_to.comp_name) AS `comp_to`, "
        query += "r.fg_repair_return_number, r.fg_repair_return_date, DATE_FORMAT(r.fg_repair_return_date, '%Y-%m-%d') AS fg_repair_return_datex, "
        query += "r.fg_repair_return_note, r.id_report_status, stt.report_status, r.is_from_vendor,r.is_use_unique_code, rep.id_fg_repair, rep.fg_repair_number, COUNT(r.id_fg_repair_return) AS `total_qty` "
        query += "From tb_fg_repair_return r 
        INNER JOIN tb_fg_repair_return_det rd ON rd.id_fg_repair_return = r.id_fg_repair_return "
        query += "INNER Join tb_m_wh_drawer drw_frm On drw_frm.id_wh_drawer = r.id_wh_drawer_from  "
        query += "INNER Join tb_m_comp comp_frm On comp_frm.id_drawer_def = drw_frm.id_wh_drawer  "
        query += "INNER Join tb_m_wh_drawer drw_to On drw_to.id_wh_drawer = r.id_wh_drawer_to "
        query += "INNER Join tb_m_comp comp_to On comp_to.id_drawer_def = drw_to.id_wh_drawer "
        query += "INNER Join tb_lookup_report_status stt On stt.id_report_status = r.id_report_status "
        query += "LEFT JOIN tb_fg_repair rep ON rep.id_fg_repair = r.id_fg_repair "
        query += "WHERE r.id_fg_repair_return>0 "
        query += "AND r.is_from_vendor=" + is_vendor + " AND (r.fg_repair_return_date>='" + date_from_selected + "' AND r.fg_repair_return_date<='" + date_until_selected + "') 
        GROUP BY r.id_fg_repair_return "
        query += "ORDER BY r.id_fg_repair_return DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepairReturn.DataSource = data
        check_menu()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormFGRepairReturnDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        FormFGRepairReturnDet.id_pre = "2"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRepairReturn_DoubleClick(sender As Object, e As EventArgs) Handles GVRepairReturn.DoubleClick
        If GVRepairReturn.RowCount > 0 And GVRepairReturn.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub XTCData_Click(sender As Object, e As EventArgs) Handles XTCData.Click

    End Sub
End Class