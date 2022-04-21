Public Class FormSampleDevActual
    Private Sub FormSampleDevActual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_tahapan()
        load_view()
        '
        load_pick()
    End Sub

    Sub load_pick()
        If GVTracker.RowCount > 0 Then
            If SLETahapan.EditValue.ToString = "Lab dip" Then
                If GVTracker.GetFocusedRowCellValue("labdip_upd").ToString = "" And GVTracker.GetFocusedRowCellValue("labdip").ToString = "" Then
                    DEActual.Properties.ReadOnly = True
                    BAdd.Enabled = False
                Else
                    If GVTracker.GetFocusedRowCellValue("labdip_upd").ToString = "" Then
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("labdip")
                    Else
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("labdip_upd")
                    End If
                    '
                    If GVTracker.GetFocusedRowCellValue("labdip_act").ToString = "" Then
                        DEActual.EditValue = GVTracker.GetFocusedRowCellValue("labdip_act")
                    End If
                    DEActual.Properties.ReadOnly = False
                    BAdd.Enabled = True
                End If
            ElseIf SLETahapan.EditValue.ToString = "Strike Off 1" Then
                If GVTracker.GetFocusedRowCellValue("strike_off_1_upd").ToString = "" And GVTracker.GetFocusedRowCellValue("strike_off_1").ToString = "" Then
                    DEActual.Properties.ReadOnly = True
                    BAdd.Enabled = False
                Else
                    If GVTracker.GetFocusedRowCellValue("strike_off_1_upd").ToString = "" Then
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("strike_off_1")
                    Else
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("strike_off_1_upd")
                    End If
                    '
                    If GVTracker.GetFocusedRowCellValue("strike_off_1_act").ToString = "" Then
                        DEActual.EditValue = GVTracker.GetFocusedRowCellValue("strike_off_1_act")
                    End If
                    DEActual.Properties.ReadOnly = False
                    BAdd.Enabled = True
                End If
            ElseIf SLETahapan.EditValue.ToString = "Proto Sample 1" Then
                If GVTracker.GetFocusedRowCellValue("proto_sample_1_upd").ToString = "" And GVTracker.GetFocusedRowCellValue("proto_sample_1").ToString = "" Then
                    DEActual.Properties.ReadOnly = True
                    BAdd.Enabled = False
                Else
                    If GVTracker.GetFocusedRowCellValue("proto_sample_1_upd").ToString = "" Then
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("proto_sample_1")
                    Else
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("proto_sample_1_upd")
                    End If
                    '
                    If GVTracker.GetFocusedRowCellValue("proto_sample_1_act").ToString = "" Then
                        DEActual.EditValue = GVTracker.GetFocusedRowCellValue("proto_sample_1_act")
                    End If
                    DEActual.Properties.ReadOnly = False
                    BAdd.Enabled = True
                End If
            ElseIf SLETahapan.EditValue.ToString = "Strike Off 2" Then
                If GVTracker.GetFocusedRowCellValue("strike_off_2_upd").ToString = "" And GVTracker.GetFocusedRowCellValue("strike_off_2").ToString = "" Then
                    DEActual.Properties.ReadOnly = True
                    BAdd.Enabled = False
                Else
                    If GVTracker.GetFocusedRowCellValue("strike_off_2_upd").ToString = "" Then
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("strike_off_2")
                    Else
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("strike_off_2_upd")
                    End If
                    '
                    If GVTracker.GetFocusedRowCellValue("strike_off_2_act").ToString = "" Then
                        DEActual.EditValue = GVTracker.GetFocusedRowCellValue("strike_off_2_act")
                    End If
                    DEActual.Properties.ReadOnly = False
                    BAdd.Enabled = True
                End If
            ElseIf SLETahapan.EditValue.ToString = "Proto Sample 2" Then
                If GVTracker.GetFocusedRowCellValue("proto_sample_2_upd").ToString = "" And GVTracker.GetFocusedRowCellValue("proto_sample_2").ToString = "" Then
                    DEActual.Properties.ReadOnly = True
                    BAdd.Enabled = False
                Else
                    If GVTracker.GetFocusedRowCellValue("proto_sample_2_upd").ToString = "" Then
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("proto_sample_2")
                    Else
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("proto_sample_2_upd")
                    End If
                    '
                    If GVTracker.GetFocusedRowCellValue("proto_sample_2_act").ToString = "" Then
                        DEActual.EditValue = GVTracker.GetFocusedRowCellValue("proto_sample_2_act")
                    End If
                    DEActual.Properties.ReadOnly = False
                    BAdd.Enabled = True
                End If
            ElseIf SLETahapan.EditValue.ToString = "Copy Proto Sample 2" Then
                If GVTracker.GetFocusedRowCellValue("copy_proto_sample_2_upd").ToString = "" And GVTracker.GetFocusedRowCellValue("copy_proto_sample_2").ToString = "" Then
                    DEActual.Properties.ReadOnly = True
                    BAdd.Enabled = False
                Else
                    If GVTracker.GetFocusedRowCellValue("copy_proto_sample_2_upd").ToString = "" Then
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("copy_proto_sample_2")
                    Else
                        DEUpd.EditValue = GVTracker.GetFocusedRowCellValue("copy_proto_sample_2_upd")
                    End If
                    '
                    If GVTracker.GetFocusedRowCellValue("copy_proto_sample_2_act").ToString = "" Then
                        DEActual.EditValue = GVTracker.GetFocusedRowCellValue("copy_proto_sample_2_act")
                    End If
                    DEActual.Properties.ReadOnly = False
                    BAdd.Enabled = True
                End If
            End If
        End If
    End Sub

    Sub load_tahapan()
        Dim q As String = "SELECT 'Lab dip' AS tahapan
UNION ALL
SELECT 'Strike Off 1' AS tahapan
UNION ALL
SELECT 'Proto Sample 1' AS tahapan
UNION ALL
SELECT 'Strike Off 2' AS tahapan
UNION ALL
SELECT 'Proto Sample 2' AS tahapan
UNION ALL
SELECT 'Copy Proto Sample 2' AS tahapan"
        viewSearchLookupQuery(SLETahapan, q, "tahapan", "tahapan", "tahapan")
    End Sub

    Sub load_view()
        Dim q As String = "SELECT DATE(NOW()) AS cur_date,'no' AS is_check,t.*,CONCAT(c.comp_number,' - ',c.comp_name) AS vendor,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS  design_display_name
FROM `tb_sample_dev_tracking` t
INNER JOIN tb_m_design dsg ON dsg.id_design=t.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season AND t.id_comp='" & FormSampleDevTargetPps.SLEVendor.EditValue.ToString & "'
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
INNER JOIN tb_m_comp c ON c.id_comp=t.id_comp"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCTracker.DataSource = dt
        GVTracker.BestFitColumns()
    End Sub

    Private Sub GVTracker_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVTracker.FocusedRowChanged
        load_pick()
    End Sub

    Private Sub SLETahapan_EditValueChanged(sender As Object, e As EventArgs) Handles SLETahapan.EditValueChanged
        load_pick()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        'check first
        If GVTracker.RowCount > 0 Then
            Dim is_ok As Boolean = True

            For i As Integer = 0 To FormSampleDevTargetPps.GVActual.RowCount - 1
                If GVTracker.GetFocusedRowCellValue("id_design").ToString = FormSampleDevTargetPps.GVActual.GetRowCellValue(i, "id_design").ToString And SLETahapan.EditValue.ToString = FormSampleDevTargetPps.GVActual.GetRowCellValue(i, "tahapan").ToString Then
                    is_ok = False
                    warningCustom("Design already listed")
                End If
            Next
            If is_ok Then
                Dim newRow As DataRow = (TryCast(FormSampleDevTargetPps.GCActual.DataSource, DataTable)).NewRow()
                newRow("id_design") = GVTracker.GetFocusedRowCellValue("id_design").ToString
                newRow("design_display_name") = GVTracker.GetFocusedRowCellValue("design_display_name").ToString
                newRow("tahapan") = SLETahapan.EditValue.ToString
                newRow("reason") = ""
                newRow("current_date") = DEUpd.EditValue
                newRow("new_date") = DEActual.EditValue
                TryCast(FormSampleDevTargetPps.GCActual.DataSource, DataTable).Rows.Add(newRow)
            End If
        End If
    End Sub
End Class