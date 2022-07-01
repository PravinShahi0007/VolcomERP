Public Class FormOutboundListDet
    Public id_awb As String = ""
    Public is_cancel As Boolean = False

    Private Sub FormOutboundListDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_del_type(ByVal opt As String)
        Dim q As String = ""
        If opt = "marketplace" Then
            q = "SELECT id_del_type, del_type, is_no_weight,volume_divide_by FROM tb_lookup_del_type WHERE is_marketplace_only='1'"
        Else
            q = "SELECT id_del_type, del_type, is_no_weight,volume_divide_by FROM tb_lookup_del_type WHERE is_marketplace_only='2'"
        End If
        viewSearchLookupQuery(SLEDelType, q, "id_del_type", "del_type", "id_del_type")
        SLEDelType.EditValue = Nothing
    End Sub

    Private Sub FormOutboundListDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPanjang.EditValue = Nothing
        TELebar.EditValue = Nothing
        TETinggi.EditValue = Nothing
        TEActWeight.EditValue = Nothing
        '
        Dim q As String = "SELECT awb.id_awbill,SUM(awbd.qty) AS qty,dis.sub_district,IFNULL(c.comp_name,cg.description) AS comp_name,awb.ol_number,cg.is_marketplace
FROM `tb_wh_awbill` awb 
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awb.id_sub_district
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
LEFT JOIN tb_m_comp c ON c.id_comp=awb.id_store
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=awbd.id_pl_sales_order_del
INNER JOIN tb_m_comp_contact ccx ON ccx.id_comp_contact = pl.id_store_contact_to
INNER JOIN tb_m_comp cx ON cx.id_comp = ccx.id_comp
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=cx.`id_comp_group`
WHERE awb.id_awbill='" & id_awb & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            TEOutboundNumber.Text = dt.Rows(0)("ol_number").ToString
            TESubDistrict.Text = dt.Rows(0)("sub_district").ToString
            TEStore.Text = dt.Rows(0)("comp_name").ToString
            '
            view_do()
            '
            If dt.Rows(0)("is_marketplace").ToString = "1" Then
                view_del_type("marketplace")
                '
                TEPanjang.EditValue = 0
                TELebar.EditValue = 0
                TETinggi.EditValue = 0
                TEActWeight.EditValue = 0
                '
                TEPanjang.Enabled = False
                TELebar.Enabled = False
                TETinggi.Enabled = False
                TEActWeight.Enabled = False
            Else
                view_del_type("not_marketplace")
            End If
        End If
        '
        MENote.Focus()
        TEPanjang.Focus()
    End Sub

    Sub view_do()
        Dim query As String = "SELECT awbd.* ,cb.combine_number,cb.id_combine
FROM tb_wh_awbill_det awbd
LEFT JOIN tb_pl_sales_order_del pld ON pld.id_pl_sales_order_del=awbd.id_pl_sales_order_del
LEFT JOIN `tb_pl_sales_order_del_combine` cb ON cb.id_combine=pld.id_combine
WHERE id_awbill='" + id_awb + "'
ORDER BY cb.combine_number"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDO.DataSource = data
        GVDO.BestFitColumns()

        'manipulate merge qty & total qty
        Dim last_combine As String = ""
        Dim total_qty As Integer = 0

        For i = 0 To data.Rows.Count - 1
            If i = 0 Then
                last_combine = data.Rows(i)("combine_number").ToString

                total_qty = total_qty + Integer.Parse(data.Rows(i)("qty").ToString.Replace(" ", ""))
            End If

            'total qty
            If Not last_combine = data.Rows(i)("combine_number").ToString And Not data.Rows(i)("combine_number").ToString = "" Then
                total_qty = total_qty + Integer.Parse(data.Rows(i)("qty").ToString.Replace(" ", ""))
            End If

            last_combine = data.Rows(i)("combine_number").ToString
        Next

        'set total qty
        GridColumnQty.SummaryItem.DisplayFormat = total_qty.ToString
    End Sub

    'Sub calculate()
    '    Dim dim_weight As Decimal = 0.0
    '    Dim divide_by As Decimal = 1
    '    '
    '    Dim panjang As Decimal = 0.0
    '    Dim lebar As Decimal = 0.0
    '    Dim tinggi As Decimal = 0.0
    '    '
    '    Try
    '        divide_by = SearchLookUpEdit1View.GetFocusedRowCellValue("volume_divide_by")
    '    Catch ex As Exception

    '    End Try

    '    Try
    '        panjang = TEPanjang.EditValue
    '        lebar = TELebar.EditValue
    '        tinggi = TETinggi.EditValue
    '    Catch ex As Exception

    '    End Try

    '    Try
    '        dim_weight = (panjang * lebar * tinggi) / divide_by
    '        TEDimWeight.EditValue = dim_weight
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub TEPanjang_EditValueChanged(sender As Object, e As EventArgs) Handles TEPanjang.EditValueChanged
    '    calculate()
    'End Sub

    'Private Sub TELebar_EditValueChanged(sender As Object, e As EventArgs) Handles TELebar.EditValueChanged
    '    calculate()
    'End Sub

    'Private Sub TETinggi_EditValueChanged(sender As Object, e As EventArgs) Handles TETinggi.EditValueChanged
    '    calculate()
    'End Sub

    'Private Sub SLEDelType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDelType.EditValueChanged
    '    Try
    '        If SearchLookUpEdit1View.GetFocusedRowCellValue("is_no_weight").ToString = "1" Then
    '            PCWeight.Visible = False
    '        Else
    '            PCWeight.Visible = True
    '        End If
    '        calculate()
    '    Catch ex As Exception
    '        Console.WriteLine(ex.ToString)
    '    End Try
    'End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click
        'Approve DO
        'If SLEDelType.EditValue = Nothing Then
        '    warningCustom("Please select delivery type !")
        'If TEActWeight.EditValue <= 0 And PCWeight.Visible = True Then
        '    warningCustom("Please input weight")
        'Else

        If TEActWeight.Text = "blank" Or TEPanjang.Text = "blank" Or TELebar.Text = "blank" Or TETinggi.Text = "blank" Then
            warningCustom("Please input weight and dimension")
        Else
            'If SearchLookUpEdit1View.GetFocusedRowCellValue("is_no_weight").ToString = "2" And (TEActWeight.EditValue + TEDimWeight.EditValue <= 0) Then
            '    warningCustom("Please put some weight")
            'Else

            'End If

            Dim q As String = "UPDATE tb_wh_awbill SET weight='" & decimalSQL(TEActWeight.EditValue.ToString) & "',`length`='" & decimalSQL(TEPanjang.EditValue.ToString) & "',width='" & decimalSQL(TELebar.EditValue.ToString) & "',height='" & decimalSQL(TETinggi.EditValue.ToString) & "',id_report_status=3,step=2,approve_outbound_by='" & id_user & "',approve_outbound_date=NOW()  WHERE id_awbill='" & id_awb & "'"
            execute_non_query(q, True, "", "", "", "")

            For i = 0 To GVDO.RowCount - 1
                If Not GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString = "" And Not GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString = "NULL" Then
                    Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                    stt.changeStatus(GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "3")

                    If FormViewSalesDelOrder.id_commerce_type = "2" Then
                        stt.sendEmailConfirmation(GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString)
                    End If

                    'Reset approval
                    'normal
                    q = String.Format("UPDATE tb_report_mark SET report_mark_start_datetime=NULL,report_mark_lead_time=NULL WHERE id_report='{0}' AND report_mark_type='43'", GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString)
                    execute_non_query(q, True, "", "", "", "")

                    'combine
                    If Not GVDO.GetRowCellValue(i, "id_combine").ToString = "" Then
                        q = String.Format("UPDATE tb_report_mark SET report_mark_start_datetime=NULL,report_mark_lead_time=NULL WHERE id_report='{0}' AND report_mark_type='103'", GVDO.GetRowCellValue(i, "id_combine").ToString)
                        execute_non_query(q, True, "", "", "", "")
                    End If
                ElseIf Not GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString = "" And Not GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString = "NULL" Then
                    Dim query As String = String.Format("UPDATE tb_ol_store_cust_ret SET id_report_status='{0}' WHERE id_ol_store_cust_ret ='{1}'", "3", GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString)
                    execute_non_query(query, True, "", "", "", "")
                End If
            Next

            FormOutboundList.load_list("", "")
            Close()
        End If
    End Sub

    Private Sub BNotApprove_Click(sender As Object, e As EventArgs) Handles BNotApprove.Click
        'pakai login dept head + cancel semua DO
        FormMenuAuth.type = "15"
        FormMenuAuth.ShowDialog()

        If is_cancel Then
            'cancel
            'check first
            Dim qc As String = "SELECT awb.id_awbill,SUM(awbd.qty) AS qty,dis.sub_district,IFNULL(c.comp_name,cg.description) AS comp_name,awb.ol_number
,GROUP_CONCAT(DISTINCT pl.`pl_sales_order_del_number`) AS sdo_number,GROUP_CONCAT(DISTINCT so.sales_order_ol_shop_number) AS online_order_number
,sts.report_status
,d.number AS draft_manifest
,odmsc.number AS scan_manifest
,odmp.number AS print_manifest
FROM `tb_wh_awbill` awb 
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=awb.id_sub_district
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_awbill=awb.id_awbill
LEFT JOIN tb_m_comp c ON c.id_comp=awb.id_store
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=awbd.id_pl_sales_order_del
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
WHERE awb.is_old_ways!=1 AND awb.step!=1 AND awb.id_report_status!=5 AND awb.id_awbill='" & id_awb & "' AND ISNULL(d.id_del_manifest)
GROUP BY awb.id_awbill"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                For i = 0 To GVDO.RowCount - 1
                    If Not GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString = "" And Not GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString = "NULL" Then
                        Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
                        stt.changeStatus(GVDO.GetRowCellValue(i, "id_pl_sales_order_del").ToString, "5")

                    ElseIf Not GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString = "" And Not GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString = "NULL" Then
                        Dim query As String = String.Format("UPDATE tb_ol_store_cust_ret SET id_report_status='{0}' WHERE id_ol_store_cust_ret ='{1}'", "5", GVDO.GetRowCellValue(i, "id_ol_store_cust_ret").ToString)
                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next
                Dim q As String = "UPDATE tb_wh_awbill SET id_report_status=5  WHERE id_awbill='" & id_awb & "'"
                execute_non_query(q, True, "", "", "", "")
                FormOutboundList.load_list("", "")
                Close()
            Else
                warningCustom("Already created manifest, please cancel it first")
            End If
        End If
    End Sub

    Private Sub BPrintLabel_Click(sender As Object, e As EventArgs) Handles BPrintLabel.Click
        print_ol(id_awb)
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

    Private Sub GVDO_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVDO.CellMerge
        If e.Column.FieldName = "qty" Or e.Column.FieldName = "combine_number" Then
            If GVDO.GetRowCellValue(e.RowHandle1, "combine_number").ToString = GVDO.GetRowCellValue(e.RowHandle2, "combine_number").ToString And Not GVDO.GetRowCellValue(e.RowHandle1, "combine_number").ToString = "" Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub
End Class