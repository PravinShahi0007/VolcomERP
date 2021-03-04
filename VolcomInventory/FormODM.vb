Public Class FormODM
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        'view()
    End Sub

    Sub view()
        Dim q As String = "SELECT *
FROM (
    SELECT 0 AS NO,a.ol_number,md.id_comp AS id_3pl,'' AS is_check, mdet.id_wh_awb_det, md.number, md.id_del_manifest,pdel.`id_pl_sales_order_del`,
    c.id_comp_group, a.awbill_no, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, ct.city
    ,a.weight, a.width, a.length, a.height, a.weight_calc AS volume, md.c_weight
    FROM tb_del_manifest_det AS mdet
    INNER JOIN tb_del_manifest md ON md.`id_del_manifest`=mdet.`id_del_manifest` AND ISNULL(md.`id_report_status`) 
    LEFT JOIN (
        SELECT odmd.id_odm_sc,odmd.id_del_manifest
        FROM tb_odm_sc_det odmd
        INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmd.id_odm_sc AND odm.id_report_status!=5 
    ) odm ON odm.id_del_manifest=md.id_del_manifest
    LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
    LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
    LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
    LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
    LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
    LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
    LEFT JOIN (
	    SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	    FROM tb_pl_sales_order_del_det AS z1
	    LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	    LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	    GROUP BY z2.id_combine
    ) AS z ON pdelc.combine_number = z.combine_number
    WHERE md.awbill_no='" & addSlashes(TEAWB.Text) & "' AND md.id_comp='" & SLUE3PL.EditValue.ToString & "' AND ISNULL(odm.id_odm_sc)
) AS tb
ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        '
        If Not GVList.RowCount > 0 Then
            warningCustom("AWB not found.")
            TEAWB.Text = ""
        Else
            TEAWB.Enabled = False
            SLUE3PL.Properties.ReadOnly = True
            BView.Visible = False
            BComplete.Visible = True
            TEScan.Focus()
        End If
    End Sub

    Private Sub FormODM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormODM_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormODM_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormODM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_3pl()
    End Sub

    Sub view_3pl()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub GVList_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVList.CellMerge
        If GVList.GetRowCellValue(e.RowHandle1, "id_awbill").ToString = GVList.GetRowCellValue(e.RowHandle2, "id_awbill").ToString Then
            e.Merge = True
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub

    Private Sub TEScan_KeyUp(sender As Object, e As KeyEventArgs) Handles TEScan.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim is_found As Boolean = False
            For i As Integer = 0 To GVList.RowCount - 1
                Try
                    If GVList.GetRowCellValue(i, "ol_number").ToString = addSlashes(TEScan.Text) Then
                        GVList.SetRowCellValue(i, "is_check", "OK")

                        GVList.FocusedRowHandle = i
                        is_found = True
                    End If
                Catch ex As Exception

                End Try
            Next

            If Not is_found Then
                FormError.LabelContent.Text = "Outbound Label Number Not Found"
                FormError.ShowDialog()
            End If

            TEScan.Text = ""
            TEScan.Focus()

            GVList.RefreshData()
        End If
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        SLUE3PL.Properties.ReadOnly = False
        BView.Visible = True
        TEScan.Text = ""
        BComplete.Visible = False
        '
        TEAWB.Text = ""
        TEAWB.Enabled = True
        '
        empty_gv()
    End Sub

    Sub empty_gv()
        For i = GVList.RowCount - 1 To 0 Step -1
            GVList.DeleteRow(i)
        Next
    End Sub

    Private Sub GVList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVList.RowCellStyle
        If e.Column.FieldName = "ol_number" Then
            e.Appearance.BackColor = If(GVList.GetRowCellValue(e.RowHandle, "is_check").ToString = "OK", Color.LightGreen, Color.LightSalmon)
        End If
    End Sub

    Private Sub BComplete_Click(sender As Object, e As EventArgs) Handles BComplete.Click
        Dim not_ok As Boolean = False
        For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)

            If Not GVList.IsGroupRow(i) Then
                If Not GVList.GetRowCellValue(i, "is_check").ToString = "OK" Then
                    not_ok = True
                    Exit For
                End If
            End If
        Next
        '
        If not_ok Then
            warningCustom("Some Outbound not scanned.")
        Else
            'complete
            Try
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If

                FormMain.SplashScreenManager1.SetWaitFormDescription("Creating report header..")
                Dim q As String = "INSERT INTO `tb_odm_sc`(id_3pl,awbill_no,created_by,created_date,id_report_status)
VALUES('" & SLUE3PL.EditValue.ToString & "','" & addSlashes(TEAWB.Text) & "','" & id_user & "',NOW(),'1'); SELECT LAST_INSERT_ID(); "
                Dim id_odm_sc As String = execute_query(q, 0, True, "", "", "", "")

                q = "CALL gen_number('" & id_odm_sc & "','258')"
                execute_non_query(q, True, "", "", "", "")

                Dim before_id_del_manifest As String = ""
                q = "INSERT INTO tb_odm_sc_det(id_odm_sc,id_del_manifest) VALUES"

                For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
                    If Not GVList.GetRowCellValue(i, "id_del_manifest").ToString = before_id_del_manifest Then
                        before_id_del_manifest = GVList.GetRowCellValue(i, "id_del_manifest").ToString

                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_odm_sc & "','" & GVList.GetRowCellValue(i, "id_del_manifest").ToString & "')"
                    End If
                Next
                execute_non_query(q, True, "", "", "", "")

                For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing Order " & i + 1 & " of " & (GVList.RowCount - 1 - GetGroupRowCount(GVList)).ToString)
                    Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                    stt.changeStatus(GVList.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "6")
                Next

                FormMain.SplashScreenManager1.CloseWaitForm()
                XTCManifestScan.SelectedTabPageIndex = 1
                load_odm_sc()
                SLEScanList.EditValue = id_odm_sc
                load_odm_det()

                print()
            Catch ex As Exception
                warningCustom(ex.ToString)
                FormMain.SplashScreenManager1.CloseWaitForm()
            End Try
        End If
    End Sub

    Private Sub XTCManifestScan_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCManifestScan.SelectedPageChanged
        If XTCManifestScan.SelectedTabPageIndex = 1 Then
            load_odm_sc()
        End If
    End Sub

    Sub load_odm_sc()
        Dim q As String = "SELECT sc.id_odm_sc,sc.number,c.comp_name,sc.created_date,emp.employee_name FROM tb_odm_sc sc
INNER JOIN tb_m_comp c ON c.id_comp=sc.id_3pl
INNER JOIN tb_m_user usr ON usr.id_user=sc.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE sc.id_report_status!=5"
        viewSearchLookupQuery(SLEScanList, q, "id_odm_sc", "number", "id_odm_sc")
        SLEScanList.EditValue = Nothing
    End Sub

    Sub load_odm_det()
        Dim q As String = "SELECT *
FROM (
    SELECT 0 AS NO,sts.id_report_status,sts.report_status AS is_check, mdet.id_wh_awb_det, md.number, md.id_del_manifest,pdel.`id_pl_sales_order_del`,
    c.id_comp_group, md.awbill_no, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, ct.city
    ,a.weight, a.width, a.length, a.height, a.weight_calc AS volume, md.c_weight
    FROM tb_del_manifest_det AS mdet
    INNER JOIN tb_del_manifest md ON md.`id_del_manifest`=mdet.`id_del_manifest` AND ISNULL(md.`id_report_status`)
    INNER JOIN tb_odm_sc_det scd ON scd.`id_del_manifest`=md.`id_del_manifest` 
    INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` AND sc.`id_report_status`!=5
    LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
    LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
    LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
    LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
    LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
    LEFT JOIN tb_lookup_report_status sts ON sts.id_report_status=pdel.id_report_status
    LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
    LEFT JOIN (
	    SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	    FROM tb_pl_sales_order_del_det AS z1
	    LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	    LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	    GROUP BY z2.id_combine
    ) AS z ON pdelc.combine_number = z.combine_number
    WHERE sc.`id_odm_sc`='" & SLEScanList.EditValue.ToString & "'
) AS tb
ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListHistory.DataSource = dt
        GVListHistory.BestFitColumns()
        load_button()
    End Sub

    'complete or print
    Sub load_button()
        Dim q As String = "SELECT *
FROM (
    SELECT 0 AS NO,sts.id_report_status,sts.report_status AS is_check, mdet.id_wh_awb_det, md.number, md.id_del_manifest,pdel.`id_pl_sales_order_del`,
    c.id_comp_group, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, ct.city
    ,a.weight, a.width, a.length, a.height, a.weight_calc AS volume, md.c_weight, md.awbill_no
    FROM tb_del_manifest_det AS mdet
    INNER JOIN tb_del_manifest md ON md.`id_del_manifest`=mdet.`id_del_manifest` AND ISNULL(md.`id_report_status`)
    INNER JOIN tb_odm_sc_det scd ON scd.`id_del_manifest`=md.`id_del_manifest` 
    INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` AND sc.`id_report_status`!=5
    LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
    LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
    LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
    LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
    LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
    LEFT JOIN tb_lookup_report_status sts ON sts.id_report_status=pdel.id_report_status
    LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
    LEFT JOIN (
	    SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	    FROM tb_pl_sales_order_del_det AS z1
	    LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	    LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	    GROUP BY z2.id_combine
    ) AS z ON pdelc.combine_number = z.combine_number
    WHERE sc.`id_odm_sc`='" & SLEScanList.EditValue.ToString & "' AND pdel.id_report_status!=6
) AS tb
ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            BPrint.Visible = False
            BCompleteHistory.Visible = True
        Else
            BPrint.Visible = True
            BCompleteHistory.Visible = False
        End If
    End Sub

    Private Sub BViewHistory_Click(sender As Object, e As EventArgs) Handles BViewHistory.Click
        L3PL.Text = SLEScanList.Properties.View.GetFocusedRowCellValue("comp_name").ToString
        load_odm_det()
    End Sub

    Private Sub BCompleteHistory_Click(sender As Object, e As EventArgs) Handles BCompleteHistory.Click
        Try
            FormMain.SplashScreenManager1.ShowWaitForm()
            For i As Integer = 0 To GVListHistory.RowCount - 1 - GetGroupRowCount(GVListHistory)
                If GVListHistory.GetRowCellValue(i, "id_report_status").ToString = "3" Then
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing Order " & i + 1 & " of " & (GVListHistory.RowCount - 1 - GetGroupRowCount(GVListHistory)).ToString)
                    Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                    stt.changeStatus(GVListHistory.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "6")
                End If
            Next
            FormMain.SplashScreenManager1.CloseWaitForm()
            'recheck
            load_odm_det()
        Catch ex As Exception
            warningCustom(ex.ToString)
            FormMain.SplashScreenManager1.CloseWaitForm()
        End Try
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print()
    End Sub

    Sub print()
        Dim report As ReportODMScan = New ReportODMScan

        report.dt = GCListHistory.DataSource
        report.XrLabelNumber.Text = SLEScanList.Text
        report.XrLabel3PL.Text = L3PL.Text

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
        tool.ShowPreview()
    End Sub

    Private Sub TEAWB_KeyUp(sender As Object, e As KeyEventArgs) Handles TEAWB.KeyUp
        If e.KeyCode = Keys.Enter Then
            view()
        End If
    End Sub
End Class