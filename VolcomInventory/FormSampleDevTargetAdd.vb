Public Class FormSampleDevTargetAdd
    Private Sub FormSampleDevTargetAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
        '
        Dim date_string As String = ""
        DELabDip.EditValue = Now()
        DEStrikeOff1.EditValue = Now()
        DEProtoSample1.EditValue = Now()
        DEStrikeOff2.EditValue = Now()
        DEProtoSample2.EditValue = Now()
        DECopyProtoSample2.EditValue = Now()
    End Sub

    Sub viewDesign()
        Dim query As String = ""
        query += "SELECT dsg.id_design,dsg.design_display_name
,dsg.design_code
,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS  design_display_name
FROM tb_m_design dsg
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
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`,
	MAX(CASE WHEN cd.id_code=5 THEN cd.id_code_detail END) AS `src`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34, 5)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
LEFT JOIN
(
	SELECT id_design
	FROM tb_prod_order_rec r
	INNER JOIN tb_prod_order po ON po.id_prod_order=r.id_prod_order AND r.id_report_status!=5
	INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
	GROUP BY id_design
)rec ON rec.id_design=dsg.id_design
WHERE dsg.is_approved=1 AND dsg.is_old_design=2 AND dsg.id_lookup_status_order!=2 AND cd.src=205 AND ISNULL(rec.id_design)
ORDER BY dsg.id_design DESC"
        viewSearchLookupQuery(SLEDesignStockStore, query, "id_design", "design_display_name", "id_design")
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        'check on list
        Dim is_ok As Boolean = True
        For i As Integer = 0 To FormSampleDevTargetPps.GVPps.RowCount - 1
            If SLEDesignStockStore.EditValue.ToString = FormSampleDevTargetPps.GVPps.GetRowCellValue(i, "id_design").ToString Then
                is_ok = False
                warningCustom("Design already listed")
            End If
        Next
        If is_ok Then
            Dim newRow As DataRow = (TryCast(FormSampleDevTargetPps.GCPps.DataSource, DataTable)).NewRow()
            newRow("id_design") = SLEDesignStockStore.EditValue.ToString
            newRow("design_display_name") = SLEDesignStockStore.Text
            newRow("labdip") = DELabDip.EditValue
            newRow("strike_off_1") = DEStrikeOff1.EditValue
            newRow("proto_sample_1") = DEProtoSample1.EditValue
            newRow("strike_off_2") = DEStrikeOff2.EditValue
            newRow("proto_sample_2") = DEProtoSample2.EditValue
            newRow("copy_proto_sample_2") = DECopyProtoSample2.EditValue
            TryCast(FormSampleDevTargetPps.GCPps.DataSource, DataTable).Rows.Add(newRow)
        End If
    End Sub

    Private Sub DELabDip_EditValueChanged(sender As Object, e As EventArgs) Handles DELabDip.EditValueChanged
        DEStrikeOff1.Properties.MinValue = DELabDip.EditValue
        DEProtoSample1.Properties.MinValue = DELabDip.EditValue
        DEStrikeOff2.Properties.MinValue = DELabDip.EditValue
        DEProtoSample2.Properties.MinValue = DELabDip.EditValue
        DECopyProtoSample2.Properties.MinValue = DELabDip.EditValue
    End Sub

    Private Sub DEStrikeOff1_EditValueChanged(sender As Object, e As EventArgs) Handles DEStrikeOff1.EditValueChanged
        DEProtoSample1.Properties.MinValue = DELabDip.EditValue
        DEStrikeOff2.Properties.MinValue = DELabDip.EditValue
        DEProtoSample2.Properties.MinValue = DELabDip.EditValue
        DECopyProtoSample2.Properties.MinValue = DELabDip.EditValue
    End Sub

    Private Sub DEProtoSample1_EditValueChanged(sender As Object, e As EventArgs) Handles DEProtoSample1.EditValueChanged
        DEStrikeOff2.Properties.MinValue = DELabDip.EditValue
        DEProtoSample2.Properties.MinValue = DELabDip.EditValue
        DECopyProtoSample2.Properties.MinValue = DELabDip.EditValue
    End Sub

    Private Sub DEStrikeOff2_EditValueChanged(sender As Object, e As EventArgs) Handles DEStrikeOff2.EditValueChanged
        DEProtoSample2.Properties.MinValue = DELabDip.EditValue
        DECopyProtoSample2.Properties.MinValue = DELabDip.EditValue
    End Sub

    Private Sub DEProtoSample2_EditValueChanged(sender As Object, e As EventArgs) Handles DEProtoSample2.EditValueChanged
        DECopyProtoSample2.Properties.MinValue = DELabDip.EditValue
    End Sub

    Private Sub FormSampleDevTargetAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class