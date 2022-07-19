﻿Public Class FormPurcAsset
    Public is_view As String = "2"

    Private Sub FormPurcAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DEUntil.EditValue = Now

        load_unit()
        load_dep()

        If is_view = "1" Then
            'XTPPending.PageVisible = False
            XTPSold.PageVisible = False
            XTPNewDepreciation.PageVisible = False
            XTCAsset.SelectedTabPageIndex = 1
            viewActive()
        Else
            'XTPPending.PageVisible = True
            XTPNewDepreciation.PageVisible = True
            XTPSold.PageVisible = True
            viewPending()
        End If
    End Sub

    Sub load_dep()
        Dim q As String = "SELECT 'ALL' AS id_departement,'ALL' AS departement
UNION ALL
SELECT id_departement,departement
FROM tb_m_departement
WHERE id_coa_tag='" & SLEUnit.EditValue.ToString & "'"
        viewSearchLookupQuery(SLEDep, q, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Sub viewPending()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        Dim query As String = a.queryMain("AND a.id_report_status=1 AND ISNULL(a.is_active) AND a.is_value_added=2 ", "1", False)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPending.DataSource = data
        GVPending.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewActive()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        Dim qw As String = ""
        If Not SLEUnit.EditValue.ToString = "0" Then
            qw += " AND a.id_coa_tag='" & SLEUnit.EditValue.ToString & "' "
        End If
        If Not SLEDep.EditValue.ToString = "ALL" Then
            qw += " AND d.id_departement='" & SLEDep.EditValue.ToString & "' "
        End If
        Dim query As String = a.queryMain(qw & "AND a.id_report_status=6 AND a.is_active=1 AND a.is_value_added=2 AND DATE(a.acq_date)>=DATE('" & Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(a.acq_date)<=DATE('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "') ", "1", True)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCActive.DataSource = data
        GVActive.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDep()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_asset_dep()"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDep.DataSource = data
        GVDep.BestFitColumns()
        If GVDep.RowCount > 0 Then
            BtnApplyAll.Visible = True
        Else
            BtnApplyAll.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcAsset_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPurcAsset_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcAsset_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opened
        If XTCAsset.SelectedTabPageIndex = 0 Then
            RecordToolStripMenuItem.Visible = True
        Else
            RecordToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub RecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordToolStripMenuItem.Click

    End Sub

    Private Sub GVPending_DoubleClick(sender As Object, e As EventArgs) Handles GVPending.DoubleClick
        If GVPending.RowCount > 0 And GVPending.FocusedRowHandle >= 0 Then
            viewDetail(GVPending.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "-1", False, False, False, False)
        End If
    End Sub

    Sub viewDetail(ByVal id As String, ByVal is_view As String, ByVal find_accum As Boolean, ByVal view_current As Boolean, ByVal move_location As Boolean, ByVal input_description As Boolean)
        Cursor = Cursors.WaitCursor
        FormPurcAssetDet.is_view = is_view
        FormPurcAssetDet.action = "upd"
        FormPurcAssetDet.id = id
        FormPurcAssetDet.find_accum = find_accum
        FormPurcAssetDet.view_current = view_current
        FormPurcAssetDet.move_location = move_location
        FormPurcAssetDet.input_description = input_description
        FormPurcAssetDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCAsset_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAsset.SelectedPageChanged
        If XTCAsset.SelectedTabPageIndex = 0 Then
            viewPending()
        ElseIf XTCAsset.SelectedTabPageIndex = 1 Then
            'viewActive()
        ElseIf XTCAsset.SelectedTabPageIndex = 2 Then
        ElseIf XTCAsset.SelectedTabPageIndex = 3 Then
            viewDep()
        End If
    End Sub

    Private Sub GVActive_DoubleClick(sender As Object, e As EventArgs) Handles GVActive.DoubleClick
        If GVActive.RowCount > 0 And GVActive.FocusedRowHandle >= 0 Then
            viewDetail(GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "1", True, False, False, False)
        End If
    End Sub

    Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles BtnApply.Click
        If GVDep.RowCount > 0 And GVDep.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this action ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                getQueryDepPerRow(GVDep.FocusedRowHandle)
                viewDep()
            End If
        End If
    End Sub

    Private Sub BtnDetail_Click(sender As Object, e As EventArgs) Handles BtnDetail.Click
        If GVDep.RowCount > 0 And GVDep.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormPurcAssetDepDetail.id_asset = GVDep.GetFocusedRowCellValue("id_purc_rec_asset").ToString.ToUpper
            FormPurcAssetDepDetail.LabelAssetName.Text = GVDep.GetFocusedRowCellValue("asset_name").ToString.ToUpper
            FormPurcAssetDepDetail.LabelLinkAssetNumber.Text = GVDep.GetFocusedRowCellValue("asset_number").ToString.ToUpper
            FormPurcAssetDepDetail.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub getQueryDepPerRow(ByVal rh As Integer)
        Cursor = Cursors.WaitCursor
        Dim id_purc_rec_asset As String = GVDep.GetRowCellValue(rh, "id_purc_rec_asset").ToString
        Dim acq_date As String = Date.Parse(GVDep.GetRowCellValue(rh, "acq_date").ToString).ToString("yyyy-MM-dd")
        Dim expired_date As String = Date.Parse(GVDep.GetRowCellValue(rh, "expired_date").ToString).ToString("yyyy-MM-dd")
        Dim last_dep_date As String = ""
        Try
            last_dep_date = Date.Parse(GVDep.GetRowCellValue(rh, "last_dep_date").ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        ' >>> FIRST MONTH
        If GVDep.GetRowCellValue(rh, "dep_first_month") > 0 Then
            ' insert tb depresiasi
            Dim query_first_month As String = "INSERT INTO tb_purc_rec_asset_dep (id_purc_rec_asset, period, amount) 
            SELECT '" + id_purc_rec_asset + "',LAST_DAY('" + acq_date + "') AS `period`, '" + decimalSQL(GVDep.GetRowCellValue(rh, "dep_first_month").ToString) + "' AS `dep_value`; SELECT LAST_INSERT_ID(); "

            'insert journal & update number
            Dim id_first_month As String = execute_query(query_first_month, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number(" + id_first_month + ", 161); ", True, "", "", "", "")
            Dim number_first_month As String = execute_query("SELECT number FROM tb_purc_rec_asset_dep WHERE id_purc_rec_asset_dep=" + id_first_month + "", 0, True, "", "", "", "")

            'main journal
            Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status) 
                VALUES ('','" + number_first_month + "','0','" + id_user + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
            Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

            'det journal
            Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number)
            SELECT '" + id_acc_trans + "', a.id_acc_dep, dep.amount, 0, CONCAT('DEPRECIATION - ',DATE_FORMAT(dep.period,'%M %Y')), 161, dep.id_purc_rec_asset_dep, dep.number
            FROM tb_purc_rec_asset_dep dep
            INNER JOIN tb_purc_rec_asset a ON a.id_purc_rec_asset = dep.id_purc_rec_asset
            WHERE dep.id_purc_rec_asset_dep='" + id_first_month + "'
            UNION ALL
            SELECT '" + id_acc_trans + "', a.id_acc_dep_accum, 0,dep.amount, CONCAT('ACCUM. DEPRECIATION - ',DATE_FORMAT(dep.period,'%M %Y')), 161, dep.id_purc_rec_asset_dep, ''
            FROM tb_purc_rec_asset_dep dep
            INNER JOIN tb_purc_rec_asset a ON a.id_purc_rec_asset = dep.id_purc_rec_asset
            WHERE dep.id_purc_rec_asset_dep='" + id_first_month + "' "
            execute_non_query(qjd, True, "", "", "", "")
        End If


        ' >>> full day
        If GVDep.GetRowCellValue(rh, "full_day") > 0 Then
            For i As Integer = 1 To GVDep.GetRowCellValue(rh, "full_day")
                'insert tiap period di tabel depresiasi
                Dim query_full_day As String = "INSERT INTO tb_purc_rec_asset_dep(id_purc_rec_asset, period, amount) "
                query_full_day += "SELECT '" + id_purc_rec_asset + "', "
                If GVDep.GetRowCellValue(rh, "dep_first_month") > 0 Then
                    query_full_day += "LAST_DAY(DATE_ADD('" + acq_date + "', INTERVAL " + i.ToString + " MONTH)) AS `period`, "
                Else
                    query_full_day += "LAST_DAY(DATE_ADD('" + last_dep_date + "', INTERVAL " + i.ToString + " MONTH)) AS `period`, "
                End If
                query_full_day += decimalSQL(GVDep.GetRowCellValue(rh, "dep_full_day").ToString) + " AS `dep_value`; SELECT LAST_INSERT_ID(); "

                'get id & number
                Dim id_full_day As String = execute_query(query_full_day, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_full_day + ", 161); ", True, "", "", "", "")
                Dim number_full_day As String = execute_query("SELECT number FROM tb_purc_rec_asset_dep WHERE id_purc_rec_asset_dep=" + id_full_day + "", 0, True, "", "", "", "")

                'main journal
                Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status) 
                VALUES ('','" + number_full_day + "','0','" + id_user + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                'det journal
                Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number)
                SELECT '" + id_acc_trans + "', a.id_acc_dep, dep.amount, 0, CONCAT('DEPRECIATION - ',DATE_FORMAT(dep.period,'%M %Y')), 161, dep.id_purc_rec_asset_dep, dep.number
                FROM tb_purc_rec_asset_dep dep
                INNER JOIN tb_purc_rec_asset a ON a.id_purc_rec_asset = dep.id_purc_rec_asset
                WHERE dep.id_purc_rec_asset_dep='" + id_full_day + "'
                UNION ALL
                SELECT '" + id_acc_trans + "', a.id_acc_dep_accum, 0,dep.amount, CONCAT('ACCUM. DEPRECIATION - ',DATE_FORMAT(dep.period,'%M %Y')), 161, dep.id_purc_rec_asset_dep, ''
                FROM tb_purc_rec_asset_dep dep
                INNER JOIN tb_purc_rec_asset a ON a.id_purc_rec_asset = dep.id_purc_rec_asset
                WHERE dep.id_purc_rec_asset_dep='" + id_full_day + "' "
                execute_non_query(qjd, True, "", "", "", "")
            Next
        End If

        ' >>> last_ month
        If GVDep.GetRowCellValue(rh, "dep_last_month") > 0 Then
            'inset di tabel depresiasi
            Dim query_last_month As String = "INSERT INTO tb_purc_rec_asset_dep(id_purc_rec_asset, period, amount) "
            query_last_month += "SELECT '" + id_purc_rec_asset + "',LAST_DAY('" + expired_date + "') AS `period`, " + decimalSQL(GVDep.GetRowCellValue(rh, "dep_last_month").ToString) + " AS `dep_value`; SELECT LAST_INSERT_ID(); "

            'get id & number
            Dim id_last_month As String = execute_query(query_last_month, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number(" + id_last_month + ", 161); ", True, "", "", "", "")
            Dim number_last_month As String = execute_query("SELECT number FROM tb_purc_rec_asset_dep WHERE id_purc_rec_asset_dep=" + id_last_month + "", 0, True, "", "", "", "")

            'main journal
            Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status) 
            VALUES ('','" + number_last_month + "','0','" + id_user + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
            Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

            'det journal
            Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number)
            SELECT '" + id_acc_trans + "', a.id_acc_dep, dep.amount, 0, CONCAT('DEPRECIATION - ',DATE_FORMAT(dep.period,'%M %Y')), 161, dep.id_purc_rec_asset_dep, dep.number
            FROM tb_purc_rec_asset_dep dep
            INNER JOIN tb_purc_rec_asset a ON a.id_purc_rec_asset = dep.id_purc_rec_asset
            WHERE dep.id_purc_rec_asset_dep='" + id_last_month + "'
            UNION ALL
            SELECT '" + id_acc_trans + "', a.id_acc_dep_accum, 0,dep.amount, CONCAT('ACCUM. DEPRECIATION - ',DATE_FORMAT(dep.period,'%M %Y')), 161, dep.id_purc_rec_asset_dep, ''
            FROM tb_purc_rec_asset_dep dep
            INNER JOIN tb_purc_rec_asset a ON a.id_purc_rec_asset = dep.id_purc_rec_asset
            WHERE dep.id_purc_rec_asset_dep='" + id_last_month + "' "
            execute_non_query(qjd, True, "", "", "", "")
        End If

        '>>> LAST UPDATE
        Dim query_upd As String = "UPDATE tb_purc_rec_asset SET last_dep_date=LAST_DAY(NOW()) WHERE id_purc_rec_asset='" + id_purc_rec_asset + "' "
        execute_non_query(query_upd, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles BtnHistory.Click
        Cursor = Cursors.WaitCursor
        FormPurcAssetDepHistory.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnApplyAll_Click(sender As Object, e As EventArgs) Handles BtnApplyAll.Click
        makeSafeGV(GVDep)
        If GVDep.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this action ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                FormMain.SplashScreenManager1.ShowWaitForm()
                For i As Integer = 0 To ((GVDep.RowCount - 1) - GetGroupRowCount(GVDep))
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing " + (i + 1).ToString + " of " + GVDep.RowCount.ToString)
                    getQueryDepPerRow(i)
                Next
                viewDep()
                FormMain.SplashScreenManager1.CloseWaitForm()
            End If
        End If
    End Sub

    Private Sub ValueaddedAssetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValueaddedAssetToolStripMenuItem.Click
        If GVActive.RowCount > 0 And GVActive.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormPurcAssetValueAddedList.id_parent = GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString
            FormPurcAssetValueAddedList.LabelAssetName.Text = GVActive.GetFocusedRowCellValue("asset_name").ToString
            FormPurcAssetValueAddedList.LabelLinkAssetNumber.Text = GVActive.GetFocusedRowCellValue("asset_number").ToString
            FormPurcAssetValueAddedList.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub InputEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputEmployeeToolStripMenuItem.Click
        If GVActive.RowCount > 0 And GVActive.FocusedRowHandle >= 0 Then
            viewDetail(GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "1", True, True, False, False)
        End If
    End Sub

    Private Sub MoveLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveLocationToolStripMenuItem.Click
        If GVActive.RowCount > 0 And GVActive.FocusedRowHandle >= 0 Then
            viewDetail(GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "1", True, True, True, False)
        End If
    End Sub

    Private Sub GVActive_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVActive.PopupMenuShowing
        Dim dt_current As DataTable = execute_query("SELECT id_departement_current, asset_note FROM tb_purc_rec_asset WHERE id_purc_rec_asset = " + GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString, -1, True, "", "", "", "")
        Dim dt_history As String = execute_query("SELECT COUNT(id_purc_rec_asset) FROM tb_purc_rec_asset_history WHERE id_purc_rec_asset = " + GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString, 0, True, "", "", "", "")

        If dt_current.Rows(0)("id_departement_current").ToString = "" Then
            InputEmployeeToolStripMenuItem.Visible = True
            MoveLocationToolStripMenuItem.Visible = False
        Else
            InputEmployeeToolStripMenuItem.Visible = False
            MoveLocationToolStripMenuItem.Visible = True
        End If

        If dt_current.Rows(0)("asset_note").ToString = "" Then
            InputDescriptionToolStripMenuItem.Visible = True
        Else
            InputDescriptionToolStripMenuItem.Visible = False
        End If

        If dt_history = "0" Then
            ViewMoveHistoryToolStripMenuItem.Visible = False
        Else
            ViewMoveHistoryToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub ViewMoveHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewMoveHistoryToolStripMenuItem.Click
        FormPurcAssetHistory.id_purc_rec_asset = GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString

        FormPurcAssetHistory.ShowDialog()
    End Sub

    Private Sub InputDescriptionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputDescriptionToolStripMenuItem.Click
        If GVActive.RowCount > 0 And GVActive.FocusedRowHandle >= 0 Then
            viewDetail(GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "-1", False, False, False, True)
        End If
    End Sub

    Private Sub BAddDepreciation_Click(sender As Object, e As EventArgs) Handles BAddDepreciation.Click
        'check ada yang blm completed
        Dim qc As String = "SELECT * FROM tb_asset_dep_pps WHERE id_report_status!=6 AND id_report_status!=5"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            warningCustom("There is pending document need to complete first")
        Else
            Dim a As New ClassPurcAsset()
            Dim query As String = a.queryMain("AND a.id_report_status=1 AND ISNULL(a.is_active) AND a.is_value_added=2 ", "1", False)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                warningCustom("There is pending asset.")
            Else
                FormPurcAssetDep.ShowDialog()
            End If
        End If
    End Sub

    Private Sub BRefreshDepreciation_Click(sender As Object, e As EventArgs) Handles BRefreshDepreciation.Click
        load_dep_pps()
    End Sub

    Sub load_dep_pps()
        Dim q As String = "SELECT ct.tag_description,SUM(ppsd.dep_value) AS dep_value_tot,pps.*,emp.employee_name,sts.report_status 
FROM tb_asset_dep_pps_det ppsd
INNER JOIN `tb_asset_dep_pps` pps ON pps.id_asset_dep_pps=ppsd.id_asset_dep_pps
INNER JOIN tb_coa_tag ct ON ct.id_coa_tag=pps.id_coa_tag
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON pps.id_report_status=sts.id_report_status
GROUP by ppsd.id_asset_dep_pps
ORDER BY ppsd.id_asset_dep_pps DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDepPPS.DataSource = dt
        GVDepPPS.BestFitColumns()
    End Sub

    Private Sub GVDepPPS_DoubleClick(sender As Object, e As EventArgs) Handles GVDepPPS.DoubleClick
        If GVDepPPS.RowCount > 0 Then
            FormPurcAssetDep.id_dep = GVDepPPS.GetFocusedRowCellValue("id_asset_dep_pps").ToString
            FormPurcAssetDep.ShowDialog()
        End If
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        viewActive()
    End Sub

    Private Sub BRefreshDisp_Click(sender As Object, e As EventArgs) Handles BRefreshDisp.Click
        load_disp()
    End Sub

    Sub load_disp()
        Dim q As String = "SELECT disp.number,disp.`id_purc_rec_asset_disp`,disp.`note`,disp.`created_date`,emp.employee_name,tag.`tag_description`,sts.`report_status`,IF(disp.`is_sell`=1,'Penjualan Fixed Asset','Penghapusan Fixed Asset') AS typ,disp.`is_sell`
FROM tb_purc_rec_asset_disp disp
INNER JOIN tb_m_user usr ON usr.id_user=disp.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=disp.`id_report_status`
INNER JOIN tb_coa_tag tag ON tag.`id_coa_tag`=disp.`id_coa_tag`
ORDER BY id_purc_rec_asset_disp DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDisp.DataSource = dt
        GVDisp.BestFitColumns()
    End Sub

    Private Sub BNewDisp_Click(sender As Object, e As EventArgs) Handles BNewDisp.Click
        FormPurcAssetDisp.is_sell = False
        FormPurcAssetDisp.ShowDialog()
    End Sub

    Private Sub BNewJual_Click(sender As Object, e As EventArgs) Handles BNewJual.Click
        FormPurcAssetDisp.is_sell = True
        FormPurcAssetDisp.ShowDialog()
    End Sub

    Private Sub GVDisp_DoubleClick(sender As Object, e As EventArgs) Handles GVDisp.DoubleClick
        If GVDisp.RowCount > 0 Then
            FormPurcAssetDisp.id_trans = GVDisp.GetFocusedRowCellValue("id_purc_rec_asset_disp").ToString()
            FormPurcAssetDisp.ShowDialog()
        End If
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        DEUntil.Properties.MinValue = DEFrom.EditValue
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        DEFrom.Properties.MaxValue = DEUntil.EditValue
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        load_dep()
    End Sub
End Class