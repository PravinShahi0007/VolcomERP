Public Class ReportSampleTargetTemplate
    Public id_pps As String = "-1"

    Private Sub ReportSampleTargetTemplate_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'table
        Dim qv As String = "SELECT ppsd.*,CONCAT(dsg.design_code,' - ',IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name 
FROM `tb_sample_dev_pps_det` ppsd
INNER JOIN tb_m_design dsg ON dsg.id_design=ppsd.id_design
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
WHERE ppsd.id_sample_dev_pps='" & id_pps & "'"
        Dim dtv As DataTable = execute_query(qv, -1, True, "", "", "", "")

        Dim row_baru_kolektif As DevExpress.XtraReports.UI.XRTableRow = XRRow
        For i = 0 To dtv.Rows.Count - 1
            insert_row(row_baru_kolektif, dtv, i)
        Next
    End Sub

    Sub insert_row(ByRef row As DevExpress.XtraReports.UI.XRTableRow, ByVal dt As DataTable, ByVal row_i As Integer)
        Dim font_row_style As New Font(XRRow.Font.FontFamily, XRRow.Font.Size - 2, FontStyle.Regular)

        row = XT1.InsertRowBelow(row)
        row.Borders = DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top
        row.BorderWidth = 1
        row.HeightF = 10
        row.Font = font_row_style
        row.BackColor = Color.Transparent

        'id_design
        Dim id_design As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        id_design.ForeColor = Color.Transparent
        id_design.Text = dt.Rows(row_i)("id_design").ToString
        id_design.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        id_design.Font = font_row_style

        'design display name
        Dim penawaran As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
        penawaran.Text = dt.Rows(row_i)("design_display_name").ToString
        penawaran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        penawaran.Font = font_row_style

        'labdip
        Dim labdip As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
        labdip.Text = If(dt.Rows(row_i)("labdip").ToString = "", "", Date.Parse(dt.Rows(row_i)("labdip").ToString).ToString("dd-MM-yyyy"))
        labdip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        labdip.Font = font_row_style

        'strike off 1
        Dim strike_off_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
        strike_off_1.Text = If(dt.Rows(row_i)("strike_off_1").ToString = "", "", Date.Parse(dt.Rows(row_i)("strike_off_1").ToString).ToString("dd-MM-yyyy"))
        strike_off_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        strike_off_1.Font = font_row_style

        'proto sample 1
        Dim proto_sample_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
        proto_sample_1.Text = If(dt.Rows(row_i)("proto_sample_1").ToString = "", "", Date.Parse(dt.Rows(row_i)("proto_sample_1").ToString).ToString("dd-MM-yyyy"))
        proto_sample_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        proto_sample_1.Font = font_row_style

        'strike off 2
        Dim strike_off_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
        strike_off_2.Text = If(dt.Rows(row_i)("strike_off_2").ToString = "", "", Date.Parse(dt.Rows(row_i)("strike_off_2").ToString).ToString("dd-MM-yyyy"))
        strike_off_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        strike_off_2.Font = font_row_style

        'proto sample 2
        Dim proto_sample_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
        proto_sample_2.Text = If(dt.Rows(row_i)("proto_sample_2").ToString = "", "", Date.Parse(dt.Rows(row_i)("proto_sample_2").ToString).ToString("dd-MM-yyyy"))
        proto_sample_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        proto_sample_2.Font = font_row_style

        'copy proto sample 2
        Dim copy_proto_sample_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
        copy_proto_sample_2.Text = If(dt.Rows(row_i)("copy_proto_sample_2").ToString = "", "", Date.Parse(dt.Rows(row_i)("copy_proto_sample_2").ToString).ToString("dd-MM-yyyy"))
        copy_proto_sample_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        copy_proto_sample_2.Font = font_row_style
    End Sub
End Class