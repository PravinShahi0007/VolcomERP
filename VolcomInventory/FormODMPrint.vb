Public Class FormODMPrint
    Public Shared id_print As String = ""
    Dim is_block_del_store As String = get_setup_field("is_block_del_store")

    Private Sub FormODMPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q As String = "SELECT c.comp_name,p.number FROM tb_odm_print p 
INNER JOIN tb_m_comp c ON c.id_comp=p.id_3pl
WHERE p.id_odm_print='" & id_print & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            L3PL.Text = dt.Rows(0)("comp_name").ToString
            TENumber.Text = dt.Rows(0)("number").ToString
        End If
        '
        load_odm_det()
    End Sub

    Sub load_odm_det()
        Dim q As String = "SELECT *
FROM (
    SELECT 0 AS NO,dis.sub_district,sts.id_report_status,a.ol_number,sts.report_status AS is_check, mdet.id_wh_awb_det, md.number, md.id_del_manifest,pdel.`id_pl_sales_order_del`,
    c.id_comp_group, md.awbill_no, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, CONCAT((ROUND(IF(pdelc.combine_number IS NULL, adet.qty, z.qty), 0)), ' ') AS qty, IFNULL(so.shipping_city,ct.city) AS city
    ,a.weight, a.width, a.length, a.height, a.weight_calc AS volume, md.c_weight, c.is_active
    FROM tb_del_manifest_det AS mdet
    INNER JOIN tb_del_manifest md ON md.`id_del_manifest`=mdet.`id_del_manifest`
    INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=md.id_sub_district
    INNER JOIN tb_odm_sc_det scd ON scd.`id_del_manifest`=md.`id_del_manifest` 
    INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` AND sc.`id_report_status`!=5
    INNER JOIN tb_odm_print_det odpd ON odpd.id_odm_sc=sc.id_odm_sc
    LEFT JOIN tb_wh_awbill_det AS adet ON mdet.id_wh_awb_det = adet.id_wh_awb_det
    LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
    LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
    LEFT JOIN tb_sales_order so ON so.`id_sales_order`=pdel.`id_sales_order`
    LEFT JOIN tb_m_comp_contact AS cc ON pdel.id_store_contact_to = cc.id_comp_contact
    LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
    LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
    LEFT JOIN tb_lookup_report_status sts ON sts.id_report_status=pdel.id_report_status
    LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
    LEFT JOIN (
	    SELECT z3.combine_number, SUM(pl_sales_order_del_det_qty) AS qty
	    FROM tb_pl_sales_order_del_det AS z1
	    LEFT JOIN tb_pl_sales_order_del AS z2 ON z1.id_pl_sales_order_del = z2.id_pl_sales_order_del
	    LEFT JOIN tb_pl_sales_order_del_combine AS z3 ON z2.id_combine = z3.id_combine
	    GROUP BY z2.id_combine
    ) AS z ON pdelc.combine_number = z.combine_number
    WHERE odpd.`id_odm_print`='" & id_print & "'
) AS tb
ORDER BY tb.awbill_no ASC,tb.ol_number ASC,tb.combine_number ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCListHistory.DataSource = dt
        GVListHistory.BestFitColumns()
    End Sub

    Private Sub GVList_RowCountChanged(sender As Object, e As EventArgs) Handles GVListHistory.RowCountChanged
        'manipulate numbering, merge qty & total qty
        Dim last_collie As String = ""
        Dim last_combine As String = ""

        Dim total_qty As Integer = 0

        Dim qty_manipulated As String = ""

        Dim no As Integer = 1

        For i = 0 To GVListHistory.RowCount - 1
            If GVListHistory.IsValidRowHandle(i) Then
                If i = 0 Then
                    last_collie = GVListHistory.GetRowCellValue(i, "id_awbill").ToString
                    last_combine = GVListHistory.GetRowCellValue(i, "combine_number").ToString

                    total_qty = total_qty + Integer.Parse(GVListHistory.GetRowCellValue(i, "qty").ToString.Replace(" ", ""))
                End If

                'numbering & merge qty
                If Not last_collie = GVListHistory.GetRowCellValue(i, "id_awbill").ToString Then
                    qty_manipulated = qty_manipulated + " "

                    no = no + 1
                End If

                'total qty
                If Not last_combine = GVListHistory.GetRowCellValue(i, "combine_number").ToString Then
                    total_qty = total_qty + Integer.Parse(GVListHistory.GetRowCellValue(i, "qty").ToString.Replace(" ", ""))
                End If

                GVListHistory.SetRowCellValue(i, "qty", GVListHistory.GetRowCellValue(i, "qty").ToString.Replace(" ", "") + qty_manipulated)

                last_collie = GVListHistory.GetRowCellValue(i, "id_awbill").ToString
                last_combine = GVListHistory.GetRowCellValue(i, "combine_number").ToString
            End If
        Next

        'set total qty
        GridColumnQty.SummaryItem.DisplayFormat = total_qty.ToString
    End Sub

    Private Sub GVList_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVListHistory.CellMerge
        If e.Column.FieldName = "qty" Or e.Column.FieldName = "combine_number" Or e.Column.FieldName = "city" Or e.Column.FieldName = "sub_district" Or e.Column.FieldName = "comp_number" Or e.Column.FieldName = "comp_name" Then
            If GVListHistory.GetRowCellValue(e.RowHandle1, "combine_number").ToString = GVListHistory.GetRowCellValue(e.RowHandle2, "combine_number").ToString Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
        Else
            If GVListHistory.GetRowCellValue(e.RowHandle1, "id_awbill").ToString = GVListHistory.GetRowCellValue(e.RowHandle2, "id_awbill").ToString Then
                e.Merge = True
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print()
    End Sub

    Sub print()


        'hold delivery
        Dim err_hold As String = ""
        For i As Integer = 0 To GVListHistory.RowCount - 1 - GetGroupRowCount(GVListHistory)
            If Not GVListHistory.IsGroupRow(i) Then
                Dim del As New ClassSalesDelOrder()
                If is_block_del_store = "1" And del.checkUnpaidInvoice(GVListHistory.GetRowCellValue(i, "id_comp_group").ToString) Then
                    err_hold += GVListHistory.GetRowCellValue(i, "combine_number").ToString + " (" + GVListHistory.GetRowCellValue(i, "comp_number").ToString + " - " + GVListHistory.GetRowCellValue(i, "comp_name").ToString + ")" + System.Environment.NewLine
                End If
            End If
        Next

        'store not active
        Dim err_not_active As String = ""
        For i As Integer = 0 To GVListHistory.RowCount - 1 - GetGroupRowCount(GVListHistory)
            If Not GVListHistory.IsGroupRow(i) Then
                If GVListHistory.GetRowCellValue(i, "is_active").ToString = "2" Then
                    err_not_active += GVListHistory.GetRowCellValue(i, "combine_number").ToString + " (" + GVListHistory.GetRowCellValue(i, "comp_number").ToString + " - " + GVListHistory.GetRowCellValue(i, "comp_name").ToString + ")" + System.Environment.NewLine
                End If
            End If
        Next

        If err_hold <> "" Then
            warningCustom("Hold delivery : " + System.Environment.NewLine + err_hold)
        ElseIf err_not_active <> "" Then
            warningCustom("Store not active : " + System.Environment.NewLine + err_not_active)
        Else
            Cursor = Cursors.WaitCursor

            send_insurance()
            send_stock()
            '
            Dim report As ReportODMScan = New ReportODMScan()

            report.dt = GCListHistory.DataSource
            report.XrLabelNumber.Text = TENumber.Text
            report.XrLabel3PL.Text = L3PL.Text

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
            tool.ShowPreview()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub send_insurance()
        Dim qc As String = "SELECT p.id_3pl,p.number,asr.`report_mark_type`,c.`comp_name`
FROM tb_odm_print p 
INNER JOIN tb_asuransi_3pl asr ON asr.`id_comp`=p.`id_3pl`
INNER JOIN tb_m_comp c ON c.`id_comp`=p.`id_3pl`
WHERE p.id_odm_print='" & id_print & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count > 0 Then
            'If dtc.Rows(0)("id_3pl").ToString = "1215" Then

            'End If
            Dim q As String = "SELECT del.awbill_no,SUM(pld.`pl_sales_order_del_det_qty` * pld.design_price) AS total_harga,dt.is_send_isurance
FROM tb_odm_print_det odmp
INNER JOIN tb_odm_print odmph ON odmph.id_odm_print=odmp.id_odm_print AND odmph.id_3pl='" & dtc.Rows(0)("id_3pl").ToString & "' -- vendor
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmp.id_odm_sc AND odmp.id_odm_print='" & id_print & "'
INNER JOIN tb_odm_sc_det odmd ON odmd.id_odm_sc=odm.id_odm_sc
INNER JOIN `tb_del_manifest_det` deld ON deld.id_del_manifest=odmd.id_del_manifest
INNER JOIN `tb_del_manifest` del ON deld.id_del_manifest=del.id_del_manifest
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_wh_awb_det=deld.id_wh_awb_det
INNER JOIN tb_lookup_del_type dt ON dt.id_del_type=del.id_del_type
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
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

            If dt.Rows.Count > 0 Then
                'check log
                Dim qc2 As String = "SELECT * FROM tb_odm_print_log WHERE report_mark_type='" & dtc.Rows(0)("report_mark_type").ToString & "' AND id_odm_print='" & id_print & "'"
                Dim dtc2 As DataTable = execute_query(qc2, -1, True, "", "", "", "")
                If Not dtc2.Rows.Count > 0 Then
                    Try
                        'hanya kirim jika belum pernah ngirim
                        Dim mail As ClassSendEmail = New ClassSendEmail()
                        mail.id_report = id_print
                        mail.par1 = dtc.Rows(0)("number").ToString
                        mail.par2 = dtc.Rows(0)("comp_name").ToString
                        mail.par3 = dtc.Rows(0)("id_3pl").ToString

                        If dt.Rows(0)("is_send_isurance").ToString = "1" Then

                        End If

                        mail.report_mark_type = dtc.Rows(0)("report_mark_type").ToString
                        mail.is_odm_asuransi = True
                        mail.send_email()
                        'log
                        execute_non_query("INSERT INTO tb_odm_print_log(id_odm_print,report_mark_type,id_comp,date_log) VALUES('" & id_print & "','" & dtc.Rows(0)("report_mark_type").ToString & "','" & dtc.Rows(0)("id_3pl").ToString & "',NOW())", True, "", "", "", "")
                    Catch ex As Exception
                        stopCustom("ERROR SENDING EMAIL INSURANCE, PLEASE CONTACT ADMINISTRATOR")
                        execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'ERROR SEND EMAIL INSURANCE')", -1, True, "", "", "", "")
                    End Try
                End If
            End If
        End If
    End Sub

    Sub send_stock()
        Dim q As String = "SELECT cg.id_comp_group,cg.description,cg.is_send_per_comp
FROM tb_odm_print_det odmp
INNER JOIN tb_odm_print odmph ON odmph.id_odm_print=odmp.id_odm_print 
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmp.id_odm_sc AND odmp.id_odm_print='" & id_print & "'
INNER JOIN tb_odm_sc_det odmd ON odmd.id_odm_sc=odm.id_odm_sc
INNER JOIN `tb_del_manifest_det` deld ON deld.id_del_manifest=odmd.id_del_manifest
INNER JOIN `tb_del_manifest` del ON deld.id_del_manifest=del.id_del_manifest
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_wh_awb_det=deld.id_wh_awb_det
INNER JOIN `tb_pl_sales_order_del_det` pld ON pld.`id_pl_sales_order_del`=awbd.id_pl_sales_order_del
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=pld.`id_pl_sales_order_del`
LEFT JOIN `tb_pl_sales_order_del_combine` plc ON plc.`id_combine`=pl.`id_combine`
INNER JOIN tb_sales_order so ON so.`id_sales_order`=pl.`id_sales_order`
INNER JOIN `tb_lookup_so_status` sos ON sos.`id_so_status`=so.`id_so_status`
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp AND c.`id_commerce_type`=1 
INNER JOIN tb_m_comp_group cg ON c.id_comp_group=cg.id_comp_group 
INNER JOIN tb_m_product p ON p.`id_product`=pld.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
LEFT JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
LEFT JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`
LEFT JOIN (
	SELECT dc.id_design,cd.id_code_detail AS `id_class`, cd.display_name AS `class`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=30
	INNER JOIN tb_m_design d ON d.id_design = dc.id_design
	GROUP BY dc.id_design
) cls ON cls.id_design = dsg.id_design
GROUP BY cg.`id_comp_group`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                'check log
                Dim qc2 As String = "SELECT * FROM tb_odm_print_log WHERE report_mark_type=314 AND id_odm_print='" & id_print & "' AND id_comp_group='" & dt.Rows(i)("id_comp_group").ToString & "'"
                Dim dtc2 As DataTable = execute_query(qc2, -1, True, "", "", "", "")
                '
                If Not dtc2.Rows.Count > 0 Then
                    If dt.Rows(i)("is_send_per_comp").ToString = "1" Then
                        Dim qs As String = "SELECT c.id_comp,c.`comp_name`,cg.is_send_per_comp
FROM tb_odm_print_det odmp
INNER JOIN tb_odm_print odmph ON odmph.id_odm_print=odmp.id_odm_print 
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmp.id_odm_sc AND odmp.id_odm_print='" & id_print & "'
INNER JOIN tb_odm_sc_det odmd ON odmd.id_odm_sc=odm.id_odm_sc
INNER JOIN `tb_del_manifest_det` deld ON deld.id_del_manifest=odmd.id_del_manifest
INNER JOIN `tb_del_manifest` del ON deld.id_del_manifest=del.id_del_manifest
INNER JOIN tb_wh_awbill_det awbd ON awbd.id_wh_awb_det=deld.id_wh_awb_det
INNER JOIN `tb_pl_sales_order_del_det` pld ON pld.`id_pl_sales_order_del`=awbd.id_pl_sales_order_del
INNER JOIN tb_pl_sales_order_del pl ON pl.id_pl_sales_order_del=pld.`id_pl_sales_order_del`
LEFT JOIN `tb_pl_sales_order_del_combine` plc ON plc.`id_combine`=pl.`id_combine`
INNER JOIN tb_sales_order so ON so.`id_sales_order`=pl.`id_sales_order`
INNER JOIN `tb_lookup_so_status` sos ON sos.`id_so_status`=so.`id_so_status`
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp AND c.`id_commerce_type`=1 AND c.`id_comp_group`='" & dt.Rows(i)("id_comp_group").ToString & "'
INNER JOIN tb_m_comp_group cg ON c.id_comp_group=cg.id_comp_group 
INNER JOIN tb_m_product p ON p.`id_product`=pld.`id_product`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=p.`id_design`
LEFT JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
LEFT JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail`
LEFT JOIN (
	SELECT dc.id_design,cd.id_code_detail AS `id_class`, cd.display_name AS `class`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=30
	INNER JOIN tb_m_design d ON d.id_design = dc.id_design
	GROUP BY dc.id_design
) cls ON cls.id_design = dsg.id_design
GROUP BY c.`id_comp`"
                        Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")
                        If dts.Rows.Count > 0 Then
                            For k = 0 To dts.Rows.Count - 1
                                Dim qc3 As String = "SELECT * FROM tb_mail_to_group WHERE report_mark_type=320 AND id_comp_group='" & dt.Rows(i)("id_comp_group").ToString & "' AND id_comp='" & dts.Rows(k)("id_comp").ToString & "' AND is_to=1"
                                Dim dtc3 As DataTable = execute_query(qc3, -1, True, "", "", "", "")

                                If dtc3.Rows.Count > 0 Then
                                    Try
                                        Dim mail As ClassSendEmail = New ClassSendEmail()
                                        mail.id_report = id_print
                                        mail.id_reff = dts.Rows(k)("id_comp").ToString
                                        mail.par1 = TENumber.Text
                                        mail.par2 = dts.Rows(k)("comp_name").ToString
                                        mail.report_mark_type = "320"
                                        mail.send_email()
                                        'log
                                        execute_non_query("INSERT INTO tb_odm_print_log(id_odm_print,report_mark_type,id_comp,id_comp_group,date_log) VALUES('" & id_print & "','320','" & dts.Rows(k)("id_comp").ToString & "','" & dt.Rows(i)("id_comp_group").ToString & "',NOW())", True, "", "", "", "")
                                    Catch ex As Exception
                                        stopCustom("ERROR SENDING EMAIL STOCK TO " & dts.Rows(k)("comp_name").ToString & ", PLEASE CONTACT ADMINISTRATOR")
                                        execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'ERROR SEND EMAIL STOK DEL TO STORE id_comp = " & dts.Rows(k)("id_comp").ToString & "')", -1, True, "", "", "", "")
                                    End Try
                                End If
                            Next
                        End If
                    Else
                        Dim qc3 As String = "SELECT * FROM tb_mail_to_group WHERE report_mark_type=314 AND id_comp_group='" & dt.Rows(i)("id_comp_group").ToString & "' AND is_to=1"
                        Dim dtc3 As DataTable = execute_query(qc3, -1, True, "", "", "", "")

                        If dtc3.Rows.Count > 0 Then
                            Try
                                Dim mail As ClassSendEmail = New ClassSendEmail()
                                mail.id_report = id_print
                                mail.id_reff = dt.Rows(i)("id_comp_group").ToString
                                mail.par1 = TENumber.Text
                                mail.par2 = dt.Rows(i)("description").ToString
                                mail.report_mark_type = "314"
                                mail.send_email()
                                'log
                                execute_non_query("INSERT INTO tb_odm_print_log(id_odm_print,report_mark_type,id_comp_group,date_log) VALUES('" & id_print & "','314','" & dt.Rows(i)("id_comp_group").ToString & "',NOW())", True, "", "", "", "")
                            Catch ex As Exception
                                stopCustom("ERROR SENDING EMAIL STOCK TO " & dt.Rows(i)("description").ToString & ", PLEASE CONTACT ADMINISTRATOR")
                                execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'ERROR SEND EMAIL STOK DEL TO STORE id_comp_group = " & dt.Rows(i)("id_comp_group").ToString & "')", -1, True, "", "", "", "")
                            End Try
                        End If
                    End If
                End If
            Next
        End If
    End Sub
End Class