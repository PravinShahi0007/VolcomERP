Public Class FormOutboundList
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormOutboundList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormOutboundList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
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

    Private Sub FormOutboundList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Dim is_load As Boolean = False

    Sub load_list(ByVal id As String, ByVal opt As String)
        Dim q As String = "SELECT awb.id_awbill,SUM(awbd.qty) AS qty,dis.sub_district,IFNULL(c.comp_number,cg.comp_group) AS comp_number,IFNULL(c.comp_name,cg.description) AS comp_name,awb.ol_number
,GROUP_CONCAT(DISTINCT pl.`pl_sales_order_del_number`) AS sdo_number,GROUP_CONCAT(DISTINCT cb.`combine_number`) AS combine_number,GROUP_CONCAT(DISTINCT so.sales_order_ol_shop_number) AS online_order_number
FROM `tb_wh_awbill` awb 
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awb.id_sub_district
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
LEFT JOIN tb_m_comp c ON c.id_comp=awb.id_store
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=awbd.id_pl_sales_order_del
LEFT JOIN `tb_pl_sales_order_del_combine` cb ON cb.id_combine=pl.id_combine
INNER JOIN tb_sales_order so ON so.id_sales_order=pl.id_sales_order
INNER JOIN tb_m_comp_contact ccx ON ccx.id_comp_contact = pl.id_store_contact_to
INNER JOIN tb_m_comp cx ON cx.id_comp = ccx.id_comp
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=cx.`id_comp_group`
WHERE awb.is_old_ways!=1 AND awb.id_report_status!=5 AND awb.id_report_status!=6 "

        If opt = "cancel" Then
            q += " AND awb.step!=1 "
        Else
            q += " AND awb.step=1 "
        End If

        If Not id = "" Then
            q += " AND awb.ol_number='" & id & "' "
        End If

        q += " GROUP BY awb.id_awbill"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        GCOutbound.DataSource = dt
        GVOutbound.BestFitColumns()

        If Not id = "" And Not dt.Rows.Count > 0 Then
            If opt = "cancel" Then
                warningCustom("Outbound number tidak dapat di cancel")
            Else
                warningCustom("Outbound number not found")
            End If

            TEOutboundNumber.Text = ""
        End If

        If dt.Rows.Count > 0 Then
            If Not id = "" Then
                'popup detail
                If opt = "cancel" Then
                    FormOutboundListDet.BApprove.Visible = False
                    FormOutboundListDet.PCType.Visible = False
                Else
                    FormOutboundListDet.BApprove.Visible = True
                End If
                FormOutboundListDet.id_awb = dt.Rows(0)("id_awbill").ToString
                FormOutboundListDet.ShowDialog()
            End If
        End If
        TEOutboundNumber.Text = ""
    End Sub

    Private Sub FormOutboundList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DETo.EditValue = Now
    End Sub

    Private Sub TEOutboundNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles TEOutboundNumber.KeyUp
        If Not TEOutboundNumber.Text = "" Then
            If e.KeyCode = Keys.Enter Then
                load_list(addSlashes(TEOutboundNumber.Text), "")
            End If
        End If
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_list("", "")
    End Sub

    Private Sub ViewDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDocumentToolStripMenuItem.Click
        If XTCOutbound.SelectedTabPageIndex = 0 Then
            If GVOutbound.RowCount > 0 Then
                print_ol(GVOutbound.GetFocusedRowCellValue("id_awbill").ToString)
            End If
        ElseIf XTCOutbound.SelectedTabPageIndex = 1 Then
            If GVHistory.RowCount > 0 Then
                print_ol(GVHistory.GetFocusedRowCellValue("id_awbill").ToString)
            End If
        End If
    End Sub

    Sub print_ol(ByVal id_awbill As String)
        Dim report As ReportOutboundLabel = New ReportOutboundLabel
        '
        Dim q As String = "(SELECT c.`comp_number`,c.`comp_name` ,IFNULL(cb.combine_number,pl.`pl_sales_order_del_number`) AS number,SUM(pld.`pl_sales_order_del_det_qty`) AS qty
FROM tb_wh_awbill_det awbd
INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=awbd.`id_pl_sales_order_del`
LEFT JOIN `tb_pl_sales_order_del_combine` cb ON cb.id_combine=pl.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.`id_store_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.id_comp
INNER JOIN tb_pl_sales_order_del_det pld ON pld.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
WHERE id_awbill='" & id_awbill & "'
GROUP BY IFNULL(cb.id_combine,pld.`id_pl_sales_order_del`)
ORDER BY pl.id_pl_sales_order_del ASC)
UNION ALL
(SELECT '' AS `comp_number`,pl.shipping_name AS `comp_name` ,pl.`number` AS number,COUNT(pld.`id_ol_store_ret_list`) AS qty
FROM tb_wh_awbill_det awbd
INNER JOIN tb_ol_store_cust_ret pl ON pl.`id_ol_store_cust_ret`=awbd.`id_ol_store_cust_ret`
INNER JOIN tb_ol_store_cust_ret_det pld ON pld.`id_ol_store_cust_ret`=pl.`id_ol_store_cust_ret`
WHERE id_awbill='" & id_awbill & "'
GROUP BY pld.`id_ol_store_cust_ret`
ORDER BY pl.id_ol_store_cust_ret ASC)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        Dim olnumber As String = ""
        Dim qs As String = "SELECT ol_number FROM tb_wh_awbill WHERE id_awbill='" & id_awbill & "'"
        olnumber = execute_query(qs, 0, True, "", "", "", "")
        '
        report.id_awbill = id_awbill
        report.ol_number = olnumber
        report.dt = dt

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
        tool.ShowPreview()
    End Sub

    Private Sub BRefreshHistory_Click(sender As Object, e As EventArgs) Handles BRefreshHistory.Click
        load_history()
    End Sub

    Private Sub CancelOutboundLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelOutboundLabelToolStripMenuItem.Click
        If XTCOutbound.SelectedTabPageIndex = 1 Then
            If GVHistory.RowCount > 0 Then
                load_list(addSlashes(GVHistory.GetFocusedRowCellValue("ol_number").ToString), "cancel")
            End If
        ElseIf XTCOutbound.SelectedTabPageIndex = 0 Then
            warningCustom("Please select not approve")
        End If
    End Sub

    Sub load_history()
        Dim q As String = "SELECT awb.id_awbill,SUM(awbd.qty) AS qty,dis.sub_district,IFNULL(c.comp_number,cg.comp_group) AS comp_number,IFNULL(c.comp_name,cg.description) AS comp_name,awb.ol_number
,GROUP_CONCAT(DISTINCT pl.`pl_sales_order_del_number`) AS sdo_number,GROUP_CONCAT(DISTINCT so.sales_order_ol_shop_number) AS online_order_number
,sts.report_status
,d.number AS draft_manifest
,odmsc.number AS scan_manifest
,odmp.number AS print_manifest
,d.awbill_no
,GROUP_CONCAT(DISTINCT cb.`combine_number`) AS combine_number
FROM `tb_wh_awbill` awb 
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awb.id_sub_district
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
LEFT JOIN tb_m_comp c ON c.id_comp=awb.id_store
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=awbd.id_pl_sales_order_del
LEFT JOIN `tb_pl_sales_order_del_combine` cb ON cb.id_combine=pl.id_combine
INNER JOIN tb_sales_order so ON so.id_sales_order=pl.id_sales_order
INNER JOIN tb_m_comp_contact ccx ON ccx.id_comp_contact = pl.id_store_contact_to
INNER JOIN tb_m_comp cx ON cx.id_comp = ccx.id_comp
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=cx.`id_comp_group`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=awb.id_report_status
LEFT JOIN tb_del_manifest_det dd ON awbd.`id_wh_awb_det`=dd.`id_wh_awb_det` 
LEFT JOIN tb_del_manifest d ON d.id_del_manifest=dd.`id_del_manifest` AND d.id_del_manifest!=5
LEFT JOIN tb_odm_sc_det odmscd ON odmscd.id_del_manifest=d.id_del_manifest
LEFT JOIN tb_odm_sc odmsc ON odmsc.id_odm_sc=odmscd.id_odm_sc
LEFT JOIN tb_odm_print_det odmpd ON odmpd.id_odm_sc=odmscd.id_odm_sc
LEFT JOIN tb_odm_print odmp ON odmp.id_odm_print=odmpd.id_odm_print
WHERE awb.is_old_ways!=1 AND awb.step!=1 AND awb.id_report_status!=5 AND DATE(awb.awbill_date)>=DATE('" & Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND DATE(awb.awbill_date)<=DATE('" & Date.Parse(DETo.EditValue.ToString).ToString("yyyy-MM-dd") & "')
GROUP BY awb.id_awbill "

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        GCHistory.DataSource = dt
        GVHistory.BestFitColumns()
    End Sub

    Private Sub BOutboundLabel_Click(sender As Object, e As EventArgs) Handles BOutboundLabel.Click
        FormOutboundLabel.ShowDialog()
    End Sub

    Private Sub CancelOutboundLabelToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CancelOutboundLabelToolStripMenuItem1.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to drop outbound label ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_awbill As String = ""
            If XTCOutbound.SelectedTabPageIndex = 0 Then
                id_awbill = GVOutbound.GetFocusedRowCellValue("id_awbill").ToString
            ElseIf XTCOutbound.SelectedTabPageIndex = 1 Then
                id_awbill = GVHistory.GetFocusedRowCellValue("id_awbill").ToString
            End If

            Dim qc As String = "SELECT *
FROM tb_wh_awbill awb
INNER JOIN tb_wh_awbill_det awbd ON awbd.`id_awbill`=awb.`id_awbill`
INNER JOIN tb_del_manifest_det dd ON dd.`id_wh_awb_det`=awbd.`id_wh_awb_det`
INNER JOIN tb_del_manifest d ON d.`id_del_manifest`=dd.`id_del_manifest` AND d.`id_report_status`!=5
WHERE awb.id_awbill='" & id_awbill & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                warningCustom("Already created draft manifest.")
            Else
                'cancel
                Dim qu As String = "UPDATE tb_wh_awbill SET id_report_status=5 WHERE id_awbill='" & id_awbill & "'"
                execute_non_query(qu, True, "", "", "", "")
                qu = "DELETE FROM tb_wh_awbill_det WHERE id_awbill='" & id_awbill & "'"
                execute_non_query(qu, True, "", "", "", "")

                warningCustom("Outbound cancelled.")

                If XTCOutbound.SelectedTabPageIndex = 0 Then
                    load_list("", "")
                ElseIf XTCOutbound.SelectedTabPageIndex = 1 Then
                    load_history()
                End If
            End If
        End If
    End Sub
End Class