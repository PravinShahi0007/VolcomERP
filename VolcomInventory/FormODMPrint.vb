Public Class FormODMPrint
    Public id_print As String = ""

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
    ,a.weight, a.width, a.length, a.height, a.weight_calc AS volume, md.c_weight
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
        Dim report As ReportODMScan = New ReportODMScan

        report.dt = GCListHistory.DataSource
        report.XrLabelNumber.Text = TENumber.Text
        report.XrLabel3PL.Text = L3PL.Text

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
        tool.ShowPreview()
    End Sub
End Class