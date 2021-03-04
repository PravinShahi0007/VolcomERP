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

    Sub load_list(ByVal id As String)
        Dim q As String = "SELECT awb.id_awbill,SUM(awbd.qty) As qty,dis.sub_district,c.comp_name,awb.ol_number
FROM `tb_wh_awbill` awb 
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awb.id_sub_district
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
INNER JOIN tb_m_comp c ON c.id_comp=awb.id_store
WHERE awb.id_report_status!=5 AND awb.id_report_status!=6 AND awb.is_old_ways!=1 AND awb.step=1"
        If Not id = "" Then
            q += " AND awb.ol_number='" & id & "' "
        End If
        q += " GROUP BY awb.id_awbill"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        GCOutbound.DataSource = dt
        GVOutbound.BestFitColumns()

        If Not id = "" And Not dt.Rows.Count > 0 Then
            warningCustom("Outbound number not found")
            TEOutboundNumber.Text = ""
        End If

        If dt.Rows.Count > 0 Then
            If Not id = "" Then
                'popup detail
                FormOutboundListDet.id_awb = dt.Rows(0)("id_awbill").ToString
                FormOutboundListDet.ShowDialog()
            End If
        End If
        TEOutboundNumber.Text = ""
    End Sub

    Private Sub FormOutboundList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TEOutboundNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles TEOutboundNumber.KeyUp
        If Not TEOutboundNumber.Text = "" Then
            If e.KeyCode = Keys.Enter Then
                load_list(addSlashes(TEOutboundNumber.Text))
            End If
        End If
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_list("")
    End Sub

    Private Sub ViewDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDocumentToolStripMenuItem.Click
        If XTCOutbound.SelectedTabPageIndex = 0 Then
            If GVOutbound.RowCount > 0 Then
                Dim report As ReportOutboundLabel = New ReportOutboundLabel
                '
                Dim q As String = "(SELECT c.`comp_number`,c.`comp_name` ,pl.`pl_sales_order_del_number` AS number,SUM(pld.`pl_sales_order_del_det_qty`) AS qty
FROM tb_wh_awbill_det awbd
INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=awbd.`id_pl_sales_order_del`
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.`id_store_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.id_comp
INNER JOIN tb_pl_sales_order_del_det pld ON pld.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
WHERE id_awbill='" & GVOutbound.GetFocusedRowCellValue("id_awbill").ToString & "'
GROUP BY pld.`id_pl_sales_order_del`
ORDER BY pl.id_pl_sales_order_del ASC)
UNION ALL
(SELECT '' AS `comp_number`,pl.shipping_name AS `comp_name` ,pl.`number` AS number,COUNT(pld.`id_ol_store_ret_list`) AS qty
FROM tb_wh_awbill_det awbd
INNER JOIN tb_ol_store_cust_ret pl ON pl.`id_ol_store_cust_ret`=awbd.`id_ol_store_cust_ret`
INNER JOIN tb_ol_store_cust_ret_det pld ON pld.`id_ol_store_cust_ret`=pl.`id_ol_store_cust_ret`
WHERE id_awbill='" & GVOutbound.GetFocusedRowCellValue("id_awbill").ToString & "'
GROUP BY pld.`id_ol_store_cust_ret`
ORDER BY pl.id_ol_store_cust_ret ASC)"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                '
                report.id_awbill = GVOutbound.GetFocusedRowCellValue("id_awbill").ToString
                report.dt = dt

                Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
                tool.ShowPreview()
            End If
        End If
    End Sub
End Class