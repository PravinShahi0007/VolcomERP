Public Class ReportQCReport1Sum
    Public id As String = "-1"

    Dim imagedir As String = get_opt_prod_field("pic_path_qc_report1") & "\"

    Private Sub ReportQCReport1Sum_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim q As String = "SELECT rec.`prod_order_rec_number`,rec.`prod_order_rec_date`,rec.`complete_date`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,pl.`pl_category`
FROM tb_prod_order_rec_det recd
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` 
INNER JOIN tb_qc_report1_sum s ON s.id_prod_order=rec.id_prod_order AND s.id_qc_report1_sum='" & id & "' AND rec.complete_date<=s.created_date
INNER JOIN tb_lookup_pl_category pl ON pl.`id_pl_category`=rec.`id_pl_category`
WHERE rec.id_report_status=6 
GROUP BY rec.id_prod_order_rec"
        Dim dt_rec As DataTable = execute_query(q, -1, True, "", "", "", "")

        Dim tot As Decimal = 0.0

        For i = 0 To dt_rec.Rows.Count - 1
            insert_row_bm(RowBM, dt_rec, i)
            tot += dt_rec.Rows(i)("qty_rec")
        Next

        insert_row_total(RowBM, tot)
        '
        Dim q2 As String = "SELECT d.id_design,vendor.comp_name AS vendor_name,po.id_prod_order,po.prod_order_number,DATE_FORMAT(qrs.created_date,'%d %M %Y') AS created_date,qrs.number
,FORMAT(podd.prod_order_qty,0,'id_ID') AS qty_po
,FORMAT(SUM(qrd.qc_report1_det_qty),0,'id_ID') AS qty_qc_report1
,FORMAT(SUM(IF(qr.`id_pl_category`=1,qrd.qc_report1_det_qty,0)),0,'id_ID') AS qty_normal
,FORMAT(SUM(IF(qr.`id_pl_category`=2,qrd.`qc_report1_det_qty`,0)),0,'id_ID') AS qty_reject_minor
,FORMAT(SUM(IF(qr.`id_pl_category`=3,qrd.`qc_report1_det_qty`,0)),0,'id_ID') AS qty_reject_major
,FORMAT(SUM(IF(qr.`id_pl_category`!=1,qrd.`qc_report1_det_qty`,0)),0,'id_ID') AS qty_reject
,FORMAT(recd.qty,0,'id_ID') AS qty_rec 
,CONCAT(d.design_code,' - ',IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',d.design_name,' ',cd.color) AS  design_display_name
,s.season,d.design_code
,prd.`product_full_code`
,pcd.`code_detail_name` AS size
FROM `tb_qc_report1_det` qrd
INNER JOIN tb_qc_report1 qr ON qr.`id_qc_report1`=qrd.`id_qc_report1` AND qr.`id_report_status`=6
INNER JOIN tb_prod_order po ON po.id_prod_order=qr.id_prod_order
INNER JOIN tb_qc_report1_sum qrs ON qrs.id_prod_order=po.id_prod_order AND qr.created_date<=qrs.created_date AND qrs.id_qc_report1_sum='" & id & "'
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design d ON d.id_design=pdd.id_design
INNER JOIN tb_season s ON s.id_season=d.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
INNER JOIN 
(
    SELECT wo.`id_prod_order`,c.`comp_name`
    FROM tb_prod_order_wo wo
    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
    WHERE wo.is_main_vendor=1 AND wo.`id_report_status`=6
    GROUP BY wo.id_prod_order
)vendor ON vendor.id_prod_order=po.id_prod_order
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = d.id_design
INNER JOIN tb_prod_order_det podd ON podd.id_prod_order_det=qrd.id_prod_order_det
INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product=podd.id_prod_demand_product
INNER JOIN tb_m_product prd ON prd.id_product=pdp.id_product
INNER JOIN tb_m_product_code pc ON pc.id_product=prd.id_product
INNER JOIN tb_m_code_detail pcd ON pcd.id_code_detail=pc.id_code_detail
INNER JOIN (
	SELECT rd.id_prod_order_det,SUM(rd.`prod_order_rec_det_qty`) AS qty
	FROM tb_prod_order_rec_det rd 
	INNER JOIN tb_prod_order_rec r ON r.`id_prod_order_rec`=rd.`id_prod_order_rec` AND r.`id_report_status`=6
	INNER JOIN tb_qc_report1_sum s ON s.id_prod_order=r.id_prod_order AND s.id_qc_report1_sum='" & id & "'
	GROUP BY rd.`id_prod_order_det`
) recd ON recd.id_prod_order_det=podd.`id_prod_order_det`
GROUP BY podd.`id_prod_order_det`"
        Dim dt As DataTable = execute_query(q2, -1, True, "", "", "", "")
        '
        If dt.Rows.Count > 0 Then
            Lnumber.Text = dt.Rows(0)("number").ToString
            LCreatedDate.Text = dt.Rows(0)("created_date").ToString
            LProdNumber.Text = dt.Rows(0)("prod_order_number").ToString
            LVendorName.Text = dt.Rows(0)("vendor_name").ToString
            LabelDesign.Text = dt.Rows(0)("design_display_name").ToString
            LSeason.Text = dt.Rows(0)("season").ToString
            '
            'get images
            Dim images As Hashtable = New Hashtable()
            Dim id_design As String = dt.Rows(0)("id_design").ToString
            Dim fileName As String = id_design & ".jpg".ToLower

            If (Not images.ContainsKey(fileName)) Then
                Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(product_image_path, fileName, False)
                XRPDesign.ImageUrl = filePath
            End If

            load_img(dt.Rows(0)("id_prod_order").ToString)

            Dim tot_po As Decimal = 0.0
            Dim tot_rec As Decimal = 0.0
            Dim tot_selisih As Decimal = 0.0
            Dim tot_normal As Decimal = 0.0
            Dim tot_minor As Decimal = 0.0
            Dim tot_major As Decimal = 0.0
            Dim tot_report As Decimal = 0.0

            'details
            For i = 0 To dt.Rows.Count - 1
                insert_row_det(ROWdet, dt, i)
                tot_po += dt.Rows(i)("qty_po")
                tot_rec += dt.Rows(i)("qty_rec")
                tot_selisih += dt.Rows(i)("qty_rec") - dt.Rows(i)("qty_po")
                tot_normal += dt.Rows(i)("qty_normal")
                tot_minor += dt.Rows(i)("qty_reject_minor")
                tot_major += dt.Rows(i)("qty_reject_major")
                tot_report += dt.Rows(i)("qty_qc_report1")
            Next

            insert_row_det_total(ROWdet, tot_po, tot_rec, tot_selisih, tot_normal, tot_minor, tot_major, tot_report)
        End If
    End Sub

    Sub load_img(ByVal id_po As String)
        Dim q As String = "SELECT img.id_qc_report1_img,img.note 
FROM tb_qc_report1_img img
INNER JOIN tb_qc_report1_sum qrs ON qrs.`id_qc_report1_sum`=img.`id_qc_report1_sum`
WHERE qrs.`id_prod_order`='" & id_po & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        'GCImage.DataSource = dt
        For i = 0 To dt.Rows.Count - 1
            insert_row_image(ROWImg, dt, i)
        Next
    End Sub

    Sub insert_row_det(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size - 2, FontStyle.Regular)

        row = XTDet.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style

        'code
        Dim rec As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        rec.Text = dt.Rows(row_i)("product_full_code").ToString
        rec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        rec.Font = font_row_style

        'size
        Dim cd_c As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        cd_c.Text = dt.Rows(row_i)("size").ToString
        cd_c.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        cd_c.Font = font_row_style

        'qty po
        Dim tot_qty As String = Decimal.Parse(dt.Rows(row_i)("qty_po").ToString).ToString("N0")

        Dim tot_qtyc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        tot_qtyc.Text = tot_qty
        tot_qtyc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_qtyc.Font = font_row_style

        'qty rec
        Dim qty_rec As String = Decimal.Parse(dt.Rows(row_i)("qty_rec").ToString).ToString("N0")

        Dim qty_recc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        qty_recc.Text = qty_rec
        qty_recc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_recc.Font = font_row_style

        'qty po - rec
        Dim qty_selisih As String = Decimal.Parse((dt.Rows(row_i)("qty_rec") - dt.Rows(row_i)("qty_po")).ToString).ToString("N0")

        Dim qty_selisihc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        qty_selisihc.Text = qty_selisih
        qty_selisihc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_selisihc.Font = font_row_style

        'qty normal
        Dim qty_normal As String = Decimal.Parse(dt.Rows(row_i)("qty_normal").ToString).ToString("N0")

        Dim qty_normalc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        qty_normalc.Text = qty_normal
        qty_normalc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_normalc.Font = font_row_style

        'qty minor
        Dim qty_minor As String = Decimal.Parse(dt.Rows(row_i)("qty_reject_minor").ToString).ToString("N0")

        Dim qty_minorc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        qty_minorc.Text = qty_minor
        qty_minorc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_minorc.Font = font_row_style

        'qty major
        Dim qty_major As String = Decimal.Parse(dt.Rows(row_i)("qty_reject_major").ToString).ToString("N0")

        Dim qty_majorc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        qty_majorc.Text = qty_major
        qty_majorc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_majorc.Font = font_row_style

        'qty total
        Dim qty_tot As String = Decimal.Parse(dt.Rows(row_i)("qty_qc_report1").ToString).ToString("N0")

        Dim qty_totc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        qty_totc.Text = qty_tot
        qty_totc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_totc.Font = font_row_style
    End Sub

    Sub insert_row_det_total(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal tot_po As Decimal, ByVal tot_rec As Decimal, ByVal tot_selisih As Decimal, ByVal tot_normal As Decimal, ByVal tot_minor As Decimal, ByVal tot_major As Decimal, ByVal tot_report As Decimal)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size - 2, FontStyle.Regular)

        row = XTDet.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style

        'code
        Dim rec As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        rec.Text = "Total"
        rec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        rec.Font = font_row_style

        'size
        Dim cd_c As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        cd_c.Text = ""
        cd_c.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        cd_c.Font = font_row_style

        'qty po
        Dim tot_qty As String = Decimal.Parse(tot_po).ToString("N0")

        Dim tot_qtyc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        tot_qtyc.Text = tot_qty
        tot_qtyc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_qtyc.Font = font_row_style

        'qty rec
        Dim qty_rec As String = Decimal.Parse(tot_rec).ToString("N0")

        Dim qty_recc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        qty_recc.Text = qty_rec
        qty_recc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_recc.Font = font_row_style

        'qty po - rec
        Dim qty_selisih As String = Decimal.Parse(tot_selisih).ToString("N0")

        Dim qty_selisihc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        qty_selisihc.Text = qty_selisih
        qty_selisihc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_selisihc.Font = font_row_style

        'qty normal
        Dim qty_normal As String = Decimal.Parse(tot_normal).ToString("N0")

        Dim qty_normalc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        qty_normalc.Text = qty_normal
        qty_normalc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_normalc.Font = font_row_style

        'qty minor
        Dim qty_minor As String = Decimal.Parse(tot_minor).ToString("N0")

        Dim qty_minorc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        qty_minorc.Text = qty_minor
        qty_minorc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_minorc.Font = font_row_style

        'qty major
        Dim qty_major As String = Decimal.Parse(tot_major).ToString("N0")

        Dim qty_majorc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        qty_majorc.Text = qty_major
        qty_majorc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_majorc.Font = font_row_style

        'qty total
        Dim qty_tot As String = Decimal.Parse(tot_report).ToString("N0")

        Dim qty_totc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
        qty_totc.Text = qty_tot
        qty_totc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        qty_totc.Font = font_row_style
    End Sub

    Sub insert_row_bm(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTBM.Font.FontFamily, XTBM.Font.Size - 2, FontStyle.Regular)

        row = XTBM.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style

        'rec#
        Dim rec As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        rec.Text = dt.Rows(row_i)("prod_order_rec_number").ToString
        rec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        rec.Font = font_row_style

        'created date
        Dim cd As String = Date.Parse(dt.Rows(row_i)("prod_order_rec_date").ToString).ToString("dd MMMM yyyy")

        Dim cd_c As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        cd_c.Text = cd
        cd_c.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        cd_c.Font = font_row_style

        'type
        Dim separator As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        separator.Text = dt.Rows(row_i)("pl_category").ToString
        separator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        separator.Font = font_row_style

        'qty
        Dim tot_qty As String = Decimal.Parse(dt.Rows(row_i)("qty_rec").ToString).ToString("N0")

        Dim tot_qtyc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        tot_qtyc.Text = tot_qty
        tot_qtyc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_qtyc.Font = font_row_style
    End Sub

    Sub insert_row_total(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal tot As Decimal)
        'total
        Dim font_row_style_tot As New Font(XTBM.Font.FontFamily, XTBM.Font.Size - 2, FontStyle.Regular)

        row = XTBM.InsertRowBelow(row)

        row.HeightF = 20
        row.Font = font_row_style_tot

        'rec#
        Dim rec_tot As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        rec_tot.Text = "Total"
        rec_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        rec_tot.Font = font_row_style_tot

        'created date
        Dim cd_c_tot As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        cd_c_tot.Text = ""
        cd_c_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        cd_c_tot.Font = font_row_style_tot

        'type
        Dim separator_tot As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        separator_tot.Text = ""
        separator_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        separator_tot.Font = font_row_style_tot

        'qty
        Dim tot_qty_tot As String = Decimal.Parse(tot.ToString).ToString("N0")

        Dim tot_qtyc_tot As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        tot_qtyc_tot.Text = tot_qty_tot
        tot_qtyc_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        tot_qtyc_tot.Font = font_row_style_tot
    End Sub

    Sub insert_row_image(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XTImage.Font.FontFamily, XTBM.Font.Size - 2, FontStyle.Regular)

        row = XTImage.InsertRowBelow(row)

        row.HeightF = 150
        row.Font = font_row_style

        'img#
        Dim img_box As DevExpress.XtraReports.UI.XRPictureBox = New DevExpress.XtraReports.UI.XRPictureBox
        Dim rec As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        rec.Controls.Add(img_box)

        img_box.LocationF = New PointF(0, 0)
        '
        img_box.WidthF = 100
        img_box.HeightF = 150
        img_box.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage

        'get images
        Dim images As Hashtable = New Hashtable()
        Dim id As String = dt.Rows(row_i)("id_qc_report1_img").ToString
        Dim fileName As String = id & ".jpg".ToLower

        If (Not images.ContainsKey(fileName)) Then
            Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(imagedir, fileName, False)
            img_box.ImageUrl = filePath
            img_box.Image = ResizeImage(img_box.Image)
        End If
        'note
        Dim cd_c As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        cd_c.Text = dt.Rows(row_i)("note").ToString
        cd_c.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        cd_c.Font = font_row_style
    End Sub

    Public Shared Function ResizeImage(ByVal InputImage As Image) As Image
        Return New Bitmap(InputImage, New Size(500, 750))
    End Function

    'Private Sub GVImage_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
    '    If e.Column.FieldName = "img" Then
    '        Dim images As Hashtable = New Hashtable()

    '        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '        Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_qc_report1_img"))

    '        Dim fileName As String = id & ".jpg".ToLower

    '        If (Not images.ContainsKey(fileName)) Then
    '            Dim img As Image = Nothing
    '            Dim resizeImg As Image = Nothing

    '            Try
    '                Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(imagedir, fileName, False)

    '                img = Image.FromFile(filePath)

    '                resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
    '            Catch
    '            End Try

    '            images.Add(fileName, resizeImg)
    '        End If

    '        e.Value = images(fileName)
    '    End If
    'End Sub
End Class