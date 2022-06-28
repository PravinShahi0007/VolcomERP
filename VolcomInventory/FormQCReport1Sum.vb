Public Class FormQCReport1Sum
    Dim imagedir As String = get_opt_prod_field("pic_path_qc_report1") & "\"
    Public id As String = "-1"
    Public is_view As String = "-1"
    '
    Dim id_po As String = "-1"
    Private Sub FormQCReport1Sum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub view_metode_type()
        Dim q As String = "SELECT `id_metode_qc`,`metode_qc` FROM `tb_metode_qc`"
        viewSearchLookupQuery(SLEMetode, q, "id_metode_qc", "metode_qc", "id_metode_qc")
    End Sub

    Sub load_head()
        view_fgpo()
        view_metode_type()

        If id = "-1" Then
            BGenerate.Visible = True
            XTCImage.Enabled = False
        Else
            SLEFGPO.ReadOnly = True
            SLEMetode.ReadOnly = True
            Dim q As String = "SELECT * FROM tb_qc_report1_sum WHERE id_qc_report1_sum='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                DECreated.EditValue = dt.Rows(0)("created_date")
                SLEFGPO.EditValue = dt.Rows(0)("id_prod_order").ToString
                id_po = dt.Rows(0)("id_prod_order").ToString
                SLEMetode.EditValue = dt.Rows(0)("id_metode_qc").ToString
                '
                TENumber.Text = dt.Rows(0)("number").ToString
                '
                If dt.Rows(0)("id_report_status").ToString = "6" Or dt.Rows(0)("id_report_status").ToString = "5" Or is_view = "1" Then
                    XTPInputImage.PageVisible = False
                    ContextMenuStrip1.Visible = False
                End If
                '
                If dt.Rows(0)("is_submit").ToString = "1" Then
                    BMark.Text = "Mark"
                    '
                    XTPInputImage.PageVisible = False
                    ContextMenuStrip1.Visible = False
                Else
                    BMark.Text = "Submit"
                End If
            End If
            BGenerate.Visible = False
            XTCImage.Enabled = True
            '
            load_rec()
            load_det()
            load_img()
        End If
    End Sub

    Sub load_det()
        Dim q As String = "SELECT po.prod_order_number,qrs.created_date,qrs.number
,pod.qty AS qty_po
,SUM(qrd.qc_report1_det_qty) AS qty_qc_report1
,SUM(IF(qr.`id_pl_category`=1,qrd.qc_report1_det_qty,0)) AS qty_normal
,SUM(IF(qr.`id_pl_category`=2,qrd.`qc_report1_det_qty`,0)) AS qty_reject_minor
,SUM(IF(qr.`id_pl_category`=3,qrd.`qc_report1_det_qty`,0)) AS qty_reject_major
,SUM(IF(qr.`id_pl_category`!=1,qrd.`qc_report1_det_qty`,0)) AS qty_reject
,recd.qty AS qty_rec 
,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',d.design_name,' ',cd.color) AS  design_display_name
,s.season,d.design_code
FROM `tb_qc_report1_det` qrd
INNER JOIN tb_qc_report1 qr ON qr.`id_qc_report1`=qrd.`id_qc_report1` AND qr.`id_report_status`=6
INNER JOIN tb_prod_order po ON po.id_prod_order=qr.id_prod_order
INNER JOIN tb_qc_report1_sum qrs ON qrs.id_prod_order=po.id_prod_order AND qr.created_date<=qrs.created_date AND qrs.id_qc_report1_sum='" & id & "' AND qrs.id_metode_qc=qr.id_metode_qc
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design d ON d.id_design=pdd.id_design
INNER JOIN tb_season s ON s.id_season=d.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
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
INNER JOIN (
	SELECT r.id_prod_order , SUM(rd.`prod_order_rec_det_qty`) AS qty
	FROM tb_prod_order_rec_det rd 
	INNER JOIN tb_prod_order_rec r ON r.`id_prod_order_rec`=rd.`id_prod_order_rec` AND r.`id_report_status`=6
    INNER JOIN tb_qc_report1_sum s ON s.id_prod_order=r.id_prod_order AND s.id_qc_report1_sum='" & id & "'
	GROUP BY r.`id_prod_order`
) recd ON recd.id_prod_order=po.`id_prod_order`
INNER JOIN (
	SELECT pod.id_prod_order,SUM(pod.prod_order_qty) AS qty
	FROM tb_prod_order_det pod
    INNER JOIN tb_qc_report1_sum s ON s.id_prod_order=pod.id_prod_order AND s.id_qc_report1_sum='" & id & "'
	GROUP BY pod.`id_prod_order`
) pod ON pod.id_prod_order=qr.`id_prod_order`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            TESeason.Text = dt.Rows(0)("season").ToString
            TEDesignCode.Text = dt.Rows(0)("design_code").ToString
            TEDesign.Text = dt.Rows(0)("design_display_name").ToString
        End If
        GCProd.DataSource = dt
        GVProd.BestFitColumns()
    End Sub

    Sub load_rec()
        Dim q As String = "SELECT rec.`prod_order_rec_number`,rec.`prod_order_rec_date`,rec.`complete_date`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,pl.`pl_category`
FROM tb_prod_order_rec_det recd
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` 
INNER JOIN tb_qc_report1_sum s ON s.id_prod_order=rec.id_prod_order AND s.id_qc_report1_sum='" & id & "' AND rec.complete_date<=s.created_date
INNER JOIN tb_lookup_pl_category pl ON pl.`id_pl_category`=rec.`id_pl_category`
WHERE rec.id_report_status=6 
GROUP BY rec.id_prod_order_rec"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCRec.DataSource = dt
        GVRec.BestFitColumns()
    End Sub

    Sub view_fgpo()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,dsg.`design_display_name`,dsg.`design_code`,CONCAT(po.`prod_order_number`,' - ',dsg.`design_display_name`) AS view_po
FROM tb_prod_order_rec_det recd 
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.id_prod_order AND wo.is_main_vendor=1
INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=wo.id_ovh_price
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_m_city ct ON ct.`id_city`=c.`id_city`
INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
INNER JOIN tb_m_country co ON co.`id_country`=reg.`id_country`
LEFT JOIN
(
    SELECT kod.* FROM 
    tb_prod_order_ko_det kod
    INNER JOIN(
        SELECT id_prod_order,MAX(id_prod_order_ko_det) AS id_prod_order_ko_det
        FROM tb_prod_order_ko_det kod
        INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order)
        GROUP BY id_prod_order
    )ko ON ko.id_prod_order_ko_det=kod.id_prod_order_ko_det
)ko ON ko.id_prod_order=po.id_prod_order
LEFT JOIN
(
    SELECT id_prod_order
    FROM `tb_prod_order_attach`
    WHERE id_report_status=6
    GROUP BY id_prod_order
)att ON att.id_prod_order=po.id_prod_order
WHERE po.`id_report_status`='6' AND IF(co.id_country=5,NOT ISNULL(ko.id_prod_order_ko),IF(po.prod_order_date>='2021-12-31',NOT ISNULL(att.id_prod_order),TRUE))
GROUP BY po.`id_prod_order`"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "view_po", "id_prod_order")
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BGenerate.Click
        Dim q As String = "INSERT INTO tb_qc_report1_sum(`id_prod_order`,`id_metode_qc`,`created_date`,`created_by`,`id_report_status`) VALUES('" & SLEFGPO.EditValue.ToString & "','" & SLEMetode.EditValue.ToString & "',NOW(),'" & id_user & "','1'); SELECT LAST_INSERT_ID();"
        id = execute_query(q, 0, True, "", "", "", "")
        '
        execute_non_query("CALL gen_number('" & id & "','388')", True, "", "", "", "")
        'submit_who_prepared("388", id, id_user)
        '
        load_head()
    End Sub

    Sub load_img()
        Dim q As String = "SELECT img.id_qc_report1_img,img.note 
FROM tb_qc_report1_img img
INNER JOIN tb_qc_report1_sum qrs ON qrs.`id_qc_report1_sum`=img.`id_qc_report1_sum`
WHERE qrs.`id_prod_order`='" & id_po & "' AND qrs.id_metode_qc='" & SLEMetode.EditValue.ToString & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCImage.DataSource = dt
    End Sub

    Private Sub BUploadImg_Click(sender As Object, e As EventArgs) Handles BUploadImg.Click
        If Not PictureEdit1.EditValue Is Nothing And Not MemoEdit1.Text = "" Then
            Dim q As String = "INSERT INTO tb_qc_report1_img(id_qc_report1_sum,note) VALUES('" & id & "','" & addSlashes(MemoEdit1.Text) & "'); SELECT LAST_INSERT_ID()"
            Dim id_img As String = execute_query(q, 0, True, "", "", "", "")
            save_image_ori(PictureEdit1, imagedir, id_img & ".jpg")
            '
            PictureEdit1.EditValue = Nothing
            MemoEdit1.Text = ""
            '
            load_img()
            XTCImage.SelectedTabPageIndex = 0
        Else
            warningCustom("Please upload image and fill note")
        End If
    End Sub

    Private Sub BRefreshImg_Click(sender As Object, e As EventArgs) Handles BRefreshImg.Click
        load_img()
    End Sub

    Private Sub GVImage_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVImage.CustomUnboundColumnData
        If e.Column.FieldName = "img" Then
            Dim images As Hashtable = New Hashtable()

            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_qc_report1_img"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try
                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(imagedir, fileName, False)

                    img = Image.FromFile(filePath)

                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch
                End Try

                images.Add(fileName, resizeImg)
            End If

            e.Value = images(fileName)
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor

        If BMark.Text = "Mark" Then
            FormReportMark.report_mark_type = "388"
            FormReportMark.id_report = id
            FormReportMark.is_view = is_view
            FormReportMark.form_origin = Name
            FormReportMark.ShowDialog()
        Else
            'submit
            submit_who_prepared("388", id, id_user)
            execute_non_query("UPDATE tb_qc_report1_sum SET is_submit=1 WHERE id_qc_report1_sum='" & id & "'", True, "", "", "", "")
            '
            infoCustom("Summary submitted")
            load_head()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim Report As New ReportQCReport1Sum()

        Report.id = id

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormQCReport1Sum_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GVImage.RowCount > 0 Then
            execute_non_query("DELETE FROM tb_qc_report1_img WHERE id_qc_report1_img='" & GVImage.GetFocusedRowCellValue("id_qc_report1_img").ToString & "'", True, "", "", "", "")
            load_img()
        End If
    End Sub
End Class