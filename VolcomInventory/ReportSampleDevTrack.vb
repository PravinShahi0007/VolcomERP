Public Class ReportSampleDevTrack
    Public id_comp As String = "-1"
    Private Sub ReportSampleDevTrack_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'table
        Dim qv As String = "(SELECT t.id_design AS id_design,'Lab dip' AS tahapan,CONCAT(dsg.design_code,' - ',IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,'' AS confirm,'' AS reason,'' AS new_dates,'" & id_comp & "' AS id_comp
FROM `tb_sample_dev_tracking` t
INNER JOIN tb_m_design dsg ON dsg.id_design=t.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
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
) cd ON cd.id_design = dsg.id_design
WHERE ISNULL(t.labdip_act) AND DATE(IF(ISNULL(t.labdip_upd),t.labdip,t.labdip_upd))=DATE_ADD(DATE(NOW()),INTERVAL 7 DAY) AND t.id_comp='" & id_comp & "')
UNION ALL
(SELECT t.id_design AS id_design,'Strike Off 1' AS tahapan,CONCAT(dsg.design_code,' - ',IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,'' AS confirm,'' AS reason,'' AS new_dates,'" & id_comp & "' AS id_comp
FROM `tb_sample_dev_tracking` t
INNER JOIN tb_m_design dsg ON dsg.id_design=t.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
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
) cd ON cd.id_design = dsg.id_design WHERE ISNULL(t.strike_off_1_act) AND DATE(IF(ISNULL(t.strike_off_1_upd),t.strike_off_1,t.strike_off_1_upd))=DATE_ADD(DATE(NOW()),INTERVAL 7 DAY) AND t.id_comp='" & id_comp & "')
UNION ALL
(SELECT t.id_design AS id_design,'Proto Sample 1' AS tahapan,CONCAT(dsg.design_code,' - ',IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,'' AS confirm,'' AS reason,'' AS new_dates,'" & id_comp & "' AS id_comp
FROM `tb_sample_dev_tracking` t
INNER JOIN tb_m_design dsg ON dsg.id_design=t.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
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
) cd ON cd.id_design = dsg.id_design WHERE ISNULL(t.proto_sample_1_act) AND DATE(IF(ISNULL(t.proto_sample_1_upd),t.proto_sample_1,t.proto_sample_1_upd))=DATE_ADD(DATE(NOW()),INTERVAL 7 DAY) AND t.id_comp='" & id_comp & "')
UNION ALL
(SELECT t.id_design AS id_design,'Lab dip' AS typ,CONCAT(dsg.design_code,' - ',IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,'' AS confirm,'' AS reason,'' AS new_dates,'" & id_comp & "' AS id_comp
FROM `tb_sample_dev_tracking` t
INNER JOIN tb_m_design dsg ON dsg.id_design=t.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
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
) cd ON cd.id_design = dsg.id_design WHERE ISNULL(t.strike_off_2_act) AND DATE(IF(ISNULL(t.strike_off_2_upd),t.strike_off_2,t.strike_off_2_upd))=DATE_ADD(DATE(NOW()),INTERVAL 7 DAY) AND t.id_comp='" & id_comp & "')
UNION ALL
(SELECT t.id_design AS id_design,'Strike Off 2' AS tahapan,CONCAT(dsg.design_code,' - ',IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,'' AS confirm,'' AS reason,'' AS new_dates,'" & id_comp & "' AS id_comp
FROM `tb_sample_dev_tracking` t
INNER JOIN tb_m_design dsg ON dsg.id_design=t.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
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
) cd ON cd.id_design = dsg.id_design WHERE ISNULL(t.proto_sample_2_act) AND DATE(IF(ISNULL(t.proto_sample_2_upd),t.proto_sample_2,t.proto_sample_2_upd))=DATE_ADD(DATE(NOW()),INTERVAL 7 DAY) AND t.id_comp='" & id_comp & "')
UNION ALL
(SELECT t.id_design AS id_design,'Copy Proto Sample 2' AS tahapan,CONCAT(dsg.design_code,' - ',IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,'' AS confirm,'' AS reason,'' AS new_dates,'" & id_comp & "' AS id_comp
FROM `tb_sample_dev_tracking` t
INNER JOIN tb_m_design dsg ON dsg.id_design=t.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
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
) cd ON cd.id_design = dsg.id_design WHERE ISNULL(t.copy_proto_sample_2_act) AND DATE(IF(ISNULL(t.copy_proto_sample_2_upd),t.copy_proto_sample_2,t.copy_proto_sample_2_upd))=DATE_ADD(DATE(NOW()),INTERVAL 7 DAY) AND t.id_comp='" & id_comp & "')"
        Dim dtv As DataTable = execute_query(qv, -1, True, "", "", "", "")

        Dim row_baru_kolektif As DevExpress.XtraReports.UI.XRTableRow = XRRow
        For i = 0 To dtv.Rows.Count - 1
            insert_row(row_baru_kolektif, dtv, i)
        Next
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XRRow.Font.FontFamily, XRRow.Font.Size, FontStyle.Regular)

        row = XT1.InsertRowBelow(row)
        row.Borders = DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top
        row.BorderWidth = 1
        row.HeightF = 15
        row.Font = font_row_style
        row.BackColor = Color.Transparent

        'id_design
        Dim id_design As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        id_design.ForeColor = Color.Transparent
        id_design.Text = dt.Rows(row_i)("id_design").ToString
        id_design.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        id_design.Font = font_row_style

        'tahapan
        Dim tahapan As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        tahapan.Text = dt.Rows(row_i)("tahapan").ToString
        tahapan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        tahapan.Font = font_row_style

        'design display name
        Dim penawaran As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        penawaran.Text = dt.Rows(row_i)("design_display_name").ToString
        penawaran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        penawaran.Font = font_row_style

        'confirm
        Dim confirm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        confirm.Text = ""
        confirm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        confirm.Font = font_row_style

        'not_confirm
        Dim not_confirm As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        not_confirm.Text = ""
        not_confirm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        not_confirm.Font = font_row_style

        'new dates
        Dim new_dates As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        new_dates.Text = ""
        new_dates.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        new_dates.Font = font_row_style

        'id_design
        Dim vendor As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        vendor.ForeColor = Color.Transparent
        vendor.Text = dt.Rows(row_i)("id_comp").ToString
        vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        vendor.Font = font_row_style
    End Sub
End Class