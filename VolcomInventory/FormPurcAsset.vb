Public Class FormPurcAsset
    Private Sub FormPurcAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPending()
    End Sub

    Sub viewPending()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        Dim query As String = a.queryMain("AND a.id_report_status=1 AND ISNULL(a.is_active) ", "1", False)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPending.DataSource = data
        GVPending.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewActive()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        Dim query As String = a.queryMain("AND a.id_report_status=6 AND a.is_active=1 ", "1", True)
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
            viewDetail(GVPending.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "-1")
        End If
    End Sub

    Sub viewDetail(ByVal id As String, ByVal is_view As String)
        Cursor = Cursors.WaitCursor
        FormPurcAssetDet.is_view = is_view
        FormPurcAssetDet.action = "upd"
        FormPurcAssetDet.id = id
        FormPurcAssetDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCAsset_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAsset.SelectedPageChanged
        If XTCAsset.SelectedTabPageIndex = 0 Then
            viewPending()
        ElseIf XTCAsset.SelectedTabPageIndex = 1 Then
            viewActive()
        ElseIf XTCAsset.SelectedTabPageIndex = 2 Then
        ElseIf XTCAsset.SelectedTabPageIndex = 3 Then
            viewDep()
        End If
    End Sub

    Private Sub GVActive_DoubleClick(sender As Object, e As EventArgs) Handles GVActive.DoubleClick
        If GVActive.RowCount > 0 And GVActive.FocusedRowHandle >= 0 Then
            viewDetail(GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "1")
        End If
    End Sub

    Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles BtnApply.Click
        If GVDep.RowCount > 0 And GVDep.FocusedRowHandle >= 0 Then
            getQueryDepPerRow(GVDep.FocusedRowHandle)
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
        Dim query_first_month As String = ""

        'first month
        Dim id_purc_rec_asset As String = GVDep.GetRowCellValue(rh, "id_purc_rec_asset").ToString
        Dim acq_date As String = Date.Parse(GVDep.GetRowCellValue(rh, "acq_date").ToString).ToString("yyyy-MM-dd")
        Dim expired_date As String = Date.Parse(GVDep.GetRowCellValue(rh, "expired_date").ToString).ToString("yyyy-MM-dd")
        Dim last_dep_date As String = ""
        Try
            last_dep_date = Date.Parse(GVDep.GetRowCellValue(rh, "last_dep_date").ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        If GVDep.GetRowCellValue(rh, "dep_first_month") > 0 Then
            query_first_month += "INSERT INTO tb_purc_rec_asset_dep (id_purc_rec_asset, period, amount) 
            SELECT '" + id_purc_rec_asset + "',LAST_DAY('" + acq_date + "') AS `period`, '" + decimalSQL(GVDep.GetRowCellValue(rh, "dep_first_month").ToString) + "' AS `dep_value`; SELECT LAST_INSERT_ID(); "
        End If
        If query_first_month <> "" Then
            'insert journal
            Dim id_first_month As String = execute_query(query_first_month, 0, True, "", "", "", "")

            'main journal
            Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, acc_trans_note, id_report_status) 
                VALUES ('" + header_number_acc("1") + "','','0','" + id_user + "', NOW(), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
            Dim id_acc_trans As String = execute_query(qjm, 0, True, "", "", "", "")
            increase_inc_acc("1")

            'det journal
            Dim qjd As String = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number)
            SELECT '" + id_acc_trans + "', a.id_acc_dep, dep.amount, 0, CONCAT('DEPRECIATION - ',DATE_FORMAT(dep.period,'%M %Y')), 161, dep.id_purc_rec_asset_dep, ''
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


        ''full day
        'Dim query_full_day As String = ""
        'If GVDep.GetRowCellValue(rh, "full_day") > 0 Then
        '    For i As Integer = 1 To GVDep.GetRowCellValue(rh, "full_day")
        '        query_full_day = "Select "
        '        If GVDep.GetRowCellValue(rh, "dep_first_month") > 0 Then
        '            query_full_day += "LAST_DAY(DATE_ADD('" + acq_date + "', INTERVAL " + i.ToString + " MONTH)) AS `period`, "
        '        Else
        '            query_full_day += "LAST_DAY(DATE_ADD('" + last_dep_date + "', INTERVAL " + i.ToString + " MONTH)) AS `period`, "
        '        End If
        '        query_full_day += decimalSQL(GVDep.GetRowCellValue(rh, "dep_full_day").ToString) + " AS `dep_value` "
        '    Next
        'End If

        ''last_ month
        'If GVDep.GetRowCellValue(rh, "dep_last_month") > 0 Then
        '    If query <> "" Then
        '        query += "UNION ALL "
        '    End If
        '    query += "SELECT LAST_DAY('" + expired_date + "') AS `period`, " + decimalSQL(GVDep.GetRowCellValue(rh, "dep_last_month").ToString) + " AS `dep_value` "
        'End If
    End Sub
End Class