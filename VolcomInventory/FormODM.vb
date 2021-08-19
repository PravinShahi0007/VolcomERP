Public Class FormODM
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_able_download_asuransi_3pl As Boolean = False
    Dim is_block_del_store As String = get_setup_field("is_block_del_store")

    Private Sub BView_Click(sender As Object, e As EventArgs)
        'view()
    End Sub

    Sub view()
        Dim q As String = "SELECT *
FROM (
    SELECT 0 AS NO,a.ol_number,md.id_comp AS id_3pl,sts.report_status,'' AS is_check, mdet.id_wh_awb_det, md.number, md.id_del_manifest,pdel.`id_pl_sales_order_del`,
    c.id_comp_group, a.awbill_no, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, IFNULL(so.shipping_city,ct.city) AS city
    ,a.weight, a.width, a.length, a.height, a.weight_calc AS volume, md.c_weight, c.is_active
    FROM tb_del_manifest_det AS mdet
    INNER JOIN tb_del_manifest md ON md.`id_del_manifest`=mdet.`id_del_manifest` 
    AND ISNULL(md.`id_report_status`)
    LEFT JOIN (
        SELECT odmd.id_odm_sc,odmd.id_del_manifest
        FROM tb_odm_sc_det odmd
        INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmd.id_odm_sc AND odm.id_report_status!=5 
    ) odm ON odm.id_del_manifest=md.id_del_manifest
    LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
    LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
    LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
    LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
    LEFT JOIN tb_lookup_report_status sts ON sts.id_report_status=pdel.id_report_status
    LEFT JOIN tb_sales_order so ON so.`id_sales_order`=pdel.`id_sales_order`
    LEFT JOIN tb_m_comp_contact AS cc ON pdel.id_store_contact_to = cc.id_comp_contact
    LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
    LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
    LEFT JOIN (
	    SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	    FROM tb_pl_sales_order_del_det AS z1
	    LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	    LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	    GROUP BY z2.id_combine
    ) AS z ON pdelc.combine_number = z.combine_number
    WHERE md.awbill_no='" & addSlashes(TEAWB.Text) & "' AND md.id_comp='" & SLUE3PL.EditValue.ToString & "' 
    AND ISNULL(odm.id_odm_sc)
) AS tb
ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
        '
        If Not GVList.RowCount > 0 Then
            warningCustom("AWB not found or already checked.")
            TEAWB.Text = ""
        Else
            TEAWB.Enabled = False
            SLUE3PL.Properties.ReadOnly = True
            'BView.Visible = False
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
        DEFrom.EditValue = Now
        DETo.EditValue = Now

        view_3pl()
    End Sub

    Sub view_3pl()
        Dim query As String = "(SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLE3PLPrint, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub GVList_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVList.CellMerge
        If e.Column.FieldName = "qty" Or e.Column.FieldName = "combine_number" Or e.Column.FieldName = "city" Or e.Column.FieldName = "comp_number" Or e.Column.FieldName = "comp_name" Then
            If GVList.GetRowCellValue(e.RowHandle1, "combine_number").ToString = GVList.GetRowCellValue(e.RowHandle2, "combine_number").ToString Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
        Else
            If GVList.GetRowCellValue(e.RowHandle1, "id_awbill").ToString = GVList.GetRowCellValue(e.RowHandle2, "id_awbill").ToString Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
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
        reset()
    End Sub

    Sub reset()
        SLUE3PL.Properties.ReadOnly = False
        'BView.Visible = True
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

        'hold delivery
        Dim err_hold As String = ""
        For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
            If Not GVList.IsGroupRow(i) Then
                Dim del As New ClassSalesDelOrder()
                If is_block_del_store = "1" And del.checkUnpaidInvoice(GVList.GetRowCellValue(i, "id_comp_group").ToString) Then
                    err_hold += GVList.GetRowCellValue(i, "combine_number").ToString + " (" + GVList.GetRowCellValue(i, "comp_number").ToString + " - " + GVList.GetRowCellValue(i, "comp_name").ToString + ")" + System.Environment.NewLine
                End If
            End If
        Next

        'store not active
        Dim err_not_active As String = ""
        For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
            If Not GVList.IsGroupRow(i) Then
                If GVList.GetRowCellValue(i, "is_active").ToString = "2" Then
                    err_not_active += GVList.GetRowCellValue(i, "combine_number").ToString + " (" + GVList.GetRowCellValue(i, "comp_number").ToString + " - " + GVList.GetRowCellValue(i, "comp_name").ToString + ")" + System.Environment.NewLine
                End If
            End If
        Next

        '
        If not_ok Then
            warningCustom("Some Outbound not scanned.")
        ElseIf err_hold <> "" Then
            warningCustom("Hold delivery : " + System.Environment.NewLine + err_hold)
        ElseIf err_not_active <> "" Then
            warningCustom("Store not active : " + System.Environment.NewLine + err_not_active)
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

                before_id_del_manifest = ""
                For i As Integer = 0 To GVList.RowCount - 1 - GetGroupRowCount(GVList)
                    If Not GVList.GetRowCellValue(i, "id_del_manifest").ToString = before_id_del_manifest Then
                        before_id_del_manifest = GVList.GetRowCellValue(i, "id_del_manifest").ToString

                        q = "UPDATE tb_del_manifest SET updated_date=NOW(),updated_by='" & id_user & "',id_report_status='6' WHERE id_del_manifest='" & GVList.GetRowCellValue(i, "id_del_manifest").ToString & "'"
                        execute_non_query(q, True, "", "", "", "")

                        'update outbound label
                        q = "UPDATE `tb_del_manifest_det` dd
INNER JOIN tb_del_manifest d ON d.id_del_manifest=dd.`id_del_manifest` AND d.`id_report_status`=6
INNER JOIN tb_wh_awbill_det awbd ON awbd.`id_wh_awb_det`=dd.`id_wh_awb_det` 
INNER JOIN tb_wh_awbill awb ON awb.`id_awbill`=awbd.`id_awbill` 
SET awb.`id_report_status`=6
WHERE dd.`id_del_manifest`='" & GVList.GetRowCellValue(i, "id_del_manifest").ToString & "'"
                        execute_non_query(q, True, "", "", "", "")

                    End If
                Next

                FormMain.SplashScreenManager1.CloseWaitForm()
                infoCustom("Completed")
                reset()
                load_waiting_list()

                'SLEScanList.EditValue = id_odm_sc
                'load_odm_det()

                'print()
            Catch ex As Exception
                'log scan security
                Dim qlog As String = "INSERT INTO tb_log_scan_security(reff,log_date,log_by,log) VALUES('" & addSlashes(TEAWB.Text) & "',NOW(),'" & id_user & "','" & addSlashes(ex.ToString) & "')"
                execute_non_query(qlog, True, "", "", "", "")
                warningCustom(ex.ToString)
                FormMain.SplashScreenManager1.CloseWaitForm()
            End Try
        End If
    End Sub

    Private Sub TEAWB_KeyUp(sender As Object, e As KeyEventArgs) Handles TEAWB.KeyUp
        If e.KeyCode = Keys.Enter Then
            view()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormODMPrintPick.ShowDialog()
    End Sub

    Private Sub GVListODM_DoubleClick(sender As Object, e As EventArgs) Handles GVListODM.DoubleClick
        If GVListODM.RowCount > 0 Then
            FormODMPrint.id_print = GVListODM.GetFocusedRowCellValue("id_odm_print").ToString
            FormODMPrint.ShowDialog()
        End If
    End Sub

    Sub load_print_list()
        Dim q As String = "SELECT od.id_odm_print,od.`number`,emp.employee_name,od.`created_date`,c.comp_name
FROM
`tb_odm_print` od
INNER JOIN tb_m_user usr ON usr.`id_user`=od.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp c ON od.id_3pl=c.id_comp
WHERE od.id_3pl='" & SLE3PLPrint.EditValue.ToString & "'
ORDER BY od.id_odm_print DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListODM.DataSource = dt
        GVListODM.BestFitColumns()
    End Sub

    Private Sub BViewPrintList_Click(sender As Object, e As EventArgs) Handles BViewPrintList.Click
        load_print_list()
    End Sub

    Private Sub BViewHistoryList_Click(sender As Object, e As EventArgs) Handles BViewHistoryList.Click
        load_hist()
    End Sub

    Sub load_hist()
        Dim query As String = "
            SELECT odm.scan_manifest,odm.print_manifest,m.id_del_manifest, c.comp_name,m.awbill_no, m.number, DATE_FORMAT(m.created_date, '%d %M %Y %H:%i:%s') AS created_date, DATE_FORMAT(m.updated_date, '%d %M %Y %H:%i:%s') AS updated_date, ea.employee_name AS created_by, eb.employee_name AS updated_by, IFNULL(l.report_status, 'Waiting checked by security') AS report_status
            FROM tb_del_manifest AS m
            LEFT JOIN tb_m_comp AS c ON m.id_comp = c.id_comp
            LEFT JOIN tb_m_user AS ua ON m.created_by = ua.id_user
            LEFT JOIN tb_m_employee AS ea ON ua.id_employee = ea.id_employee
            LEFT JOIN tb_m_user AS ub ON m.updated_by = ub.id_user
            LEFT JOIN tb_m_employee AS eb ON ub.id_employee = eb.id_employee
            LEFT JOIN tb_lookup_report_status AS l ON m.id_report_status = l.id_report_status
            INNER JOIN
            (
                SELECT scd.`id_del_manifest`,sc.`number` AS scan_manifest,sc.created_date,p.`number` AS print_manifest
                FROM tb_odm_sc_det scd 
                INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` 
                LEFT JOIN tb_odm_print_det pd ON pd.`id_odm_sc`=sc.`id_odm_sc`
                LEFT JOIN tb_odm_print p ON p.`id_odm_print`=pd.`id_odm_print`
            )odm ON odm.id_del_manifest=m.id_del_manifest
            WHERE DATE(odm.created_date)>='" & Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(odm.created_date)<='" & Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") & "'
            ORDER BY m.id_del_manifest DESC
        "

        GCHistoryList.DataSource = execute_query(query, -1, True, "", "", "", "")
        GVHistoryList.BestFitColumns()
    End Sub

    Private Sub SLUE3PL_EditValueChanged(sender As Object, e As EventArgs) Handles SLUE3PL.EditValueChanged
        TEAWB.Focus()
    End Sub

    Private Sub BRefreshWaiting_Click(sender As Object, e As EventArgs) Handles BRefreshWaiting.Click
        load_waiting_list()
    End Sub

    Sub load_waiting_list()
        Dim query As String = "
            SELECT odm.scan_manifest,odm.print_manifest,m.id_del_manifest, c.comp_name,m.awbill_no, m.number, DATE_FORMAT(m.created_date, '%d %M %Y %H:%i:%s') AS created_date, DATE_FORMAT(m.updated_date, '%d %M %Y %H:%i:%s') AS updated_date, ea.employee_name AS created_by, eb.employee_name AS updated_by, IFNULL(l.report_status, 'Waiting checked by security') AS report_status
            FROM tb_del_manifest AS m
            LEFT JOIN tb_m_comp AS c ON m.id_comp = c.id_comp
            LEFT JOIN tb_m_user AS ua ON m.created_by = ua.id_user
            LEFT JOIN tb_m_employee AS ea ON ua.id_employee = ea.id_employee
            LEFT JOIN tb_m_user AS ub ON m.updated_by = ub.id_user
            LEFT JOIN tb_m_employee AS eb ON ub.id_employee = eb.id_employee
            LEFT JOIN tb_lookup_report_status AS l ON m.id_report_status = l.id_report_status
            LEFT JOIN
            (
                SELECT scd.`id_del_manifest`,sc.`number` AS scan_manifest,p.`number` AS print_manifest
                FROM tb_odm_sc_det scd 
                INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` 
                LEFT JOIN tb_odm_print_det pd ON pd.`id_odm_sc`=sc.`id_odm_sc`
                LEFT JOIN tb_odm_print p ON p.`id_odm_print`=pd.`id_odm_print`
                GROUP BY scd.`id_del_manifest`
            )odm ON odm.id_del_manifest=m.id_del_manifest
            WHERE ISNULL(l.report_status)
            ORDER BY m.id_del_manifest DESC
        "

        GCWaitingToScan.DataSource = execute_query(query, -1, True, "", "", "", "")
        GVWaitingToScan.BestFitColumns()
    End Sub

    Private Sub GetDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetDataToolStripMenuItem.Click
        'check
        Dim qc As String = "SELECT del.awbill_no,SUM(pld.`pl_sales_order_del_det_qty` * pld.design_price) AS total_harga
FROM tb_odm_print_det odmp
INNER JOIN tb_odm_print odmph ON odmph.id_odm_print=odmp.id_odm_print AND odmph.id_3pl='1215' -- JNE
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmp.id_odm_sc AND odmp.id_odm_print='" & GVListODM.GetFocusedRowCellValue("id_odm_print").ToString & "'
INNER JOIN tb_odm_sc_det odmd ON odmd.id_odm_sc=odm.id_odm_sc
INNER JOIN `tb_del_manifest_det` deld ON deld.id_del_manifest=odmd.id_del_manifest
INNER JOIN `tb_del_manifest` del ON deld.id_del_manifest=del.id_del_manifest
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_wh_awb_det=deld.id_wh_awb_det
INNER JOIN `tb_pl_sales_order_del_det` pld ON pld.`id_pl_sales_order_del`=awbd.id_pl_sales_order_del
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=pld.`id_pl_sales_order_del`
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_m_comp_group cg ON c.id_comp_group=cg.id_comp_group AND cg.is_marketplace=2
INNER JOIN tb_m_product p ON p.`id_product`=pld.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
LEFT JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
LEFT JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`
GROUP BY del.awbill_no"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

        If GVListODM.RowCount > 0 And dtc.Rows.Count > 0 Then
            'pakai login dept head 
            is_able_download_asuransi_3pl = False

            FormMenuAuth.type = "19"
            FormMenuAuth.ShowDialog()

            If is_able_download_asuransi_3pl Then
                Dim Report As New Report3PLInsurance()
                Report.id_odm_print = GVListODM.GetFocusedRowCellValue("id_odm_print").ToString
                Report.LManifestNo.Text = GVListODM.GetFocusedRowCellValue("number").ToString

                Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                tool.ShowPreview()
            End If
        Else
            warningCustom("Data untuk pertanggungan asuransi tidak ditemukan")
        End If
    End Sub
End Class