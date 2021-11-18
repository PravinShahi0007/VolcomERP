Public Class FormFGAdj 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    'Form
    Private Sub FormFGAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DEInFrom.EditValue = Now
        DEInTo.EditValue = Now
        DEOutFrom.EditValue = Now
        DEOutTo.EditValue = Now
    End Sub
    Private Sub FormFGAdj_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Private Sub FormFGAdj_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'View Data
    Sub viewAdjIn()
        Dim date_from As String = Date.Parse(DEInFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_to As String = Date.Parse(DEInTo.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_in_fg_date, '%d %M %Y') AS adj_in_fg_datex, SUM(adj_in_fg_det_qty) AS `total_qty`, 
        GROUP_CONCAT(DISTINCT comp.comp_number) AS `account` "
        query += "FROM tb_adj_in_fg a 
        INNER JOIN tb_adj_in_fg_det ad ON ad.id_adj_in_fg = a.id_adj_in_fg 
        INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = ad.id_wh_drawer
        INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack
        INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator
        INNER JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "WHERE a.adj_in_fg_date BETWEEN '" + date_from + "' AND '" + date_to + "'"
        query += "GROUP BY a.id_adj_in_fg "
        query += "ORDER BY a.id_adj_in_fg DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjIn.DataSource = data
        check_menu()
    End Sub
    Sub viewAdjOut()
        Dim date_from As String = Date.Parse(DEInFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_to As String = Date.Parse(DEInTo.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_out_fg_date, '%d %M %Y') AS adj_out_fg_datex,
        SUM(adj_out_fg_det_qty) AS `total_qty`, 
        GROUP_CONCAT(DISTINCT comp.comp_number) AS `account` "
        query += "FROM tb_adj_out_fg a 
        INNER JOIN tb_adj_out_fg_det ad ON ad.id_adj_out_fg = a.id_adj_out_fg 
        INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = ad.id_wh_drawer
        INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack
        INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator
        INNER JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "WHERE a.adj_out_fg_date BETWEEN '" + date_from + "' AND '" + date_to + "'"
        query += "GROUP BY a.id_adj_out_fg  "
        query += "ORDER BY a.id_adj_out_fg DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjOut.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If XTCAdj.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVAdjIn.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        ElseIf XTCAdj.SelectedTabPageIndex = 1 Then
            ''based on PO
            If GVAdjOut.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        End If
    End Sub

    Private Sub XTCReturn_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAdj.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub BtnSummaryOut_Click(sender As Object, e As EventArgs) Handles BtnSummaryOut.Click
        Cursor = Cursors.WaitCursor
        FormFGAdjReport.is_out = True
        FormFGAdjReport.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSummaryIn_Click(sender As Object, e As EventArgs) Handles BtnSummaryIn.Click
        Cursor = Cursors.WaitCursor
        FormFGAdjReport.is_out = False
        FormFGAdjReport.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SBInView_Click(sender As Object, e As EventArgs) Handles SBInView.Click
        viewAdjIn()
    End Sub

    Private Sub SBOutView_Click(sender As Object, e As EventArgs) Handles SBOutView.Click
        viewAdjOut()
    End Sub

    Sub view_in_bap()
        Dim query As String = "
            SELECT b.id_st_store_bap, b.number, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, DATE_FORMAT(b.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, b.id_report_status, r.report_status
            FROM tb_st_store_bap AS b
            LEFT JOIN tb_m_comp AS c ON b.id_comp = c.id_comp
            LEFT JOIN tb_m_user AS u ON b.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON b.id_report_status = r.id_report_status
            LEFT JOIN (
                SELECT d.id_st_store_bap, COUNT(*) AS total
                FROM tb_st_store_bap_ver AS v
                LEFT JOIN tb_st_store_bap_det AS d ON v.id_st_store_bap_det = d.id_st_store_bap_det
                WHERE v.report_mark_type = 0 AND v.qty < 0
                GROUP BY d.id_st_store_bap
            ) AS t ON b.id_st_store_bap = t.id_st_store_bap
            WHERE b.id_report_status = 6 AND b.id_st_store_bap NOT IN (SELECT IFNULL(id_st_store_bap, 0) FROM tb_adj_in_fg WHERE id_report_status <> 5) AND IFNULL(t.total, 0) > 0
            ORDER BY b.id_st_store_bap ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCInBAP.DataSource = data

        GVInBAP.BestFitColumns()
    End Sub

    Private Sub XTCAdjIn_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAdjIn.SelectedPageChanged
        view_in_bap()
    End Sub

    Private Sub SBCreateAdjIn_Click(sender As Object, e As EventArgs) Handles SBCreateAdjIn.Click
        FormFGAdjInDet.action = "ins"
        FormFGAdjInDet.id_st_store_bap = GVInBAP.GetFocusedRowCellValue("id_st_store_bap").ToString
        FormFGAdjInDet.ShowDialog()
    End Sub

    Sub view_out_bap()
        Dim query As String = "
            SELECT b.id_st_store_bap, b.number, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, DATE_FORMAT(b.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, b.id_report_status, r.report_status
            FROM tb_st_store_bap AS b
            LEFT JOIN tb_m_comp AS c ON b.id_comp = c.id_comp
            LEFT JOIN tb_m_user AS u ON b.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON b.id_report_status = r.id_report_status
            LEFT JOIN (
                SELECT d.id_st_store_bap, COUNT(*) AS total
                FROM tb_st_store_bap_ver AS v
                LEFT JOIN tb_st_store_bap_det AS d ON v.id_st_store_bap_det = d.id_st_store_bap_det
                WHERE v.report_mark_type = 0 AND v.qty > 0
                GROUP BY d.id_st_store_bap
            ) AS t ON b.id_st_store_bap = t.id_st_store_bap
            WHERE b.id_report_status = 6 AND b.id_st_store_bap NOT IN (SELECT IFNULL(id_st_store_bap, 0) FROM tb_adj_out_fg WHERE id_report_status <> 5) AND IFNULL(t.total, 0) > 0
            ORDER BY b.id_st_store_bap ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCOutBAP.DataSource = data

        GVOutBAP.BestFitColumns()
    End Sub

    Private Sub XTCAdjOut_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAdjOut.SelectedPageChanged
        view_out_bap()
    End Sub

    Private Sub SBCreateAdjOut_Click(sender As Object, e As EventArgs) Handles SBCreateAdjOut.Click
        FormFGAdjOutDet.action = "ins"
        FormFGAdjOutDet.id_st_store_bap = GVOutBAP.GetFocusedRowCellValue("id_st_store_bap").ToString
        FormFGAdjOutDet.ShowDialog()
    End Sub

    Private Sub GVAdjIn_DoubleClick(sender As Object, e As EventArgs) Handles GVAdjIn.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub GVAdjOut_DoubleClick(sender As Object, e As EventArgs) Handles GVAdjOut.DoubleClick
        FormMain.but_edit()
    End Sub
End Class