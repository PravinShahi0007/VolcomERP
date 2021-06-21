Public Class ReportPengirimanProduk
    Public id_odm_print As String = "-1"
    Public id_grup_toko As String = "-1"

    Private Sub ReportPengirimanProduk_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim q As String = "SELECT IF(pl.`is_combine`=1,plc.`combine_number`,pl.`pl_sales_order_del_number`) AS do_number,CONCAT(c.`comp_number`,' - ',c.`comp_display_name`) AS store
,p.`product_full_code`,dsg.`design_display_name`,cd.`code_detail_name` AS size,cls.class
,pld.`pl_sales_order_del_det_qty` AS qty,odmph.`created_date` AS pickup_date,pl.`pl_sales_order_del_date` AS pl_date
,sos.`so_status`,IF(pl.`is_combine`=1,plc.combine_note,pl.`pl_sales_order_del_note`) AS pl_sales_order_del_note,odmph.`number`,del.`awbill_no`
FROM tb_odm_print_det odmp
INNER JOIN tb_odm_print odmph ON odmph.id_odm_print=odmp.id_odm_print 
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmp.id_odm_sc AND odmp.id_odm_print='" & id_odm_print & "'
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
INNER JOIN tb_m_comp_group cg ON c.id_comp_group=cg.id_comp_group AND cg.`id_comp_group`='" & id_grup_toko & "'
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
ORDER BY do_number"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        Dim row_baru As DevExpress.XtraReports.UI.XRTableRow = XRDetail
        Dim tot_qty As Decimal = 0.00
        Dim gran_tot_qty As Decimal = 0.00
        For i = 0 To dt.Rows.Count - 1
            insert_row(row_baru, dt, i)
            'add per SDO
            tot_qty += dt.Rows(i)("qty")
            gran_tot_qty += dt.Rows(i)("qty")
            If i = dt.Rows.Count - 1 Then
                'last row
                insert_footer(row_baru, tot_qty, "Total " & dt.Rows(i)("do_number").ToString)
                insert_footer(row_baru, gran_tot_qty, "Grand Total")
            Else
                If Not dt.Rows(i)("do_number").ToString = dt.Rows(i + 1)("do_number").ToString Then
                    insert_footer(row_baru, tot_qty, "Total " & dt.Rows(i)("do_number").ToString)
                    tot_qty = 0
                End If
            End If
        Next
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size, FontStyle.Regular)

        If Not row_i = 0 Then
            row = XTDetail.InsertRowBelow(row)
        End If

        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style

        'Store Name
        Dim store As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        store.Text = dt.Rows(row_i)("store").ToString
        store.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        store.Font = font_row_style

        'do_number
        Dim do_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        do_number.Text = dt.Rows(row_i)("do_number").ToString
        do_number.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        do_number.Font = font_row_style

        'pl_date
        Dim pl_date As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        pl_date.Text = Date.Parse(dt.Rows(row_i)("pl_date").ToString).ToString("dd MMMM yyyy")
        pl_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        pl_date.Font = font_row_style

        'barcode
        Dim product_full_code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        product_full_code.Text = dt.Rows(row_i)("product_full_code").ToString
        product_full_code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        product_full_code.Font = font_row_style

        'size
        Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        size.Text = dt.Rows(row_i)("size").ToString
        size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        size.Font = font_row_style

        'class
        Dim product_class As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        product_class.Text = dt.Rows(row_i)("class").ToString
        product_class.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        product_class.Font = font_row_style

        'product_desc
        Dim product_desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        product_desc.Text = dt.Rows(row_i)("design_display_name").ToString
        product_desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        product_desc.Font = font_row_style

        'qty
        Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        qty.Text = Decimal.Parse(dt.Rows(row_i)("qty").ToString).ToString("N0")
        qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty.Font = font_row_style

        'remark
        Dim remark As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        remark.Text = dt.Rows(row_i)("so_status").ToString
        remark.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        remark.Font = font_row_style

        'note
        Dim note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
        note.Text = dt.Rows(row_i)("pl_sales_order_del_note").ToString
        note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        note.Font = font_row_style

        'awbill_no
        Dim awbill_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
        awbill_no.Text = dt.Rows(row_i)("awbill_no").ToString
        awbill_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        awbill_no.Font = font_row_style

        'odm
        Dim odm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)
        odm.Text = dt.Rows(row_i)("number").ToString
        odm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        odm.Font = font_row_style
    End Sub

    Sub insert_footer(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal total As Decimal, ByVal do_no As String)
        Dim font_row_style As New Font(XTDetail.Font.FontFamily, XTDetail.Font.Size, FontStyle.Bold)

        row = XTDetail.InsertRowBelow(row)

        row.Borders = DevExpress.XtraPrinting.BorderSide.All
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style

        'Store Name
        Dim store As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        store.Text = ""
        store.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        store.Font = font_row_style

        'do_no
        Dim do_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        do_number.Text = do_no
        do_number.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        do_number.Font = font_row_style

        'pl_date
        Dim pl_date As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        pl_date.Text = ""
        pl_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        pl_date.Font = font_row_style

        'barcode
        Dim product_full_code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        product_full_code.Text = ""
        product_full_code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        product_full_code.Font = font_row_style

        'size
        Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        size.Text = ""
        size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        size.Font = font_row_style

        'class
        Dim product_class As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        product_class.Text = ""
        product_class.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        product_class.Font = font_row_style

        'product_desc
        Dim product_desc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        product_desc.Text = ""
        product_desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        product_desc.Font = font_row_style

        'qty
        Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        qty.Text = Decimal.Parse(total.ToString).ToString("N0")
        qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty.Font = font_row_style

        'remark
        Dim remark As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        remark.Text = ""
        remark.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        remark.Font = font_row_style

        'note
        Dim note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
        note.Text = ""
        note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        note.Font = font_row_style

        'awbill_no
        Dim awbill_no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
        awbill_no.Text = ""
        awbill_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        awbill_no.Font = font_row_style

        'odm
        Dim odm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(11)
        odm.Text = ""
        odm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        odm.Font = font_row_style
    End Sub
End Class