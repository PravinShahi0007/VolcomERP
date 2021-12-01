Public Class FormPIBPPSDet
    Private Sub FormPIBPPSDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPIBPPSDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEPIB.EditValue = Now
        load_propose()
    End Sub

    Sub load_propose()
        Dim q As String = "SELECT f.number AS pre_cal_fgpo_number,f.id_pre_cal_fgpo,GROUP_CONCAT(CONCAT(po.prod_order_number,' - ',cd.class,' ',dsg.design_name,' ',cd.color) SEPARATOR '\n') AS list_fgpo,IFNULL(pr.pib_no,'') AS pib_no,IFNULL(pr.pib_date,DATE(NOW())) AS pib_date
FROM tb_pre_cal_fgpo_list fl
INNER JOIN tb_pre_cal_fgpo f ON f.id_pre_cal_fgpo=fl.id_pre_cal_fgpo
INNER JOIN tb_pib_review pr ON pr.id_pre_cal_fgpo=fl.id_pre_cal_fgpo AND fl.id_prod_order=pr.id_prod_order AND is_active=1
INNER JOIN tb_prod_order po ON po.id_prod_order=fl.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14,43)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
WHERE po.id_report_status=6
GROUP BY f.id_pre_cal_fgpo"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        GCSummary.DataSource = dt
        GVSummary.BestFitColumns()
    End Sub

    Private Sub BCreatePPS_Click(sender As Object, e As EventArgs) Handles BCreatePPS.Click
        If GVSummary.RowCount > 0 Then
            If TEPIBNumber.Text = "" Or DEPIB.EditValue = Nothing Then
                warningCustom("Please input value correctly")
            Else
                'check main pps
                Dim is_ok As Boolean = True
                For i = 0 To FormPIBPPS.BGVPIBPPS.RowCount - 1
                    If FormPIBPPS.BGVPIBPPS.GetRowCellValue(i, "id_pre_cal_fgpo").ToString = GVSummary.GetFocusedRowCellValue("id_pre_cal_fgpo").ToString Then
                        is_ok = False
                        Exit For
                    End If
                Next
                If Not is_ok Then
                    warningCustom("ISB already on list")
                Else
                    'save
                    Dim newRow As DataRow = (TryCast(FormPIBPPS.GCPIBPPps.DataSource, DataTable)).NewRow()
                    '
                    newRow("id_pre_cal_fgpo") = GVSummary.GetFocusedRowCellValue("id_pre_cal_fgpo").ToString
                    newRow("pre_cal_fgpo_number") = GVSummary.GetFocusedRowCellValue("pre_cal_fgpo_number").ToString
                    newRow("list_fgpo") = GVSummary.GetFocusedRowCellValue("list_fgpo").ToString

                    newRow("old_pib_no") = TEPIBNumberOld.EditValue
                    newRow("old_pib_date") = DEPIBOld.EditValue
                    '
                    newRow("pib_no") = TEPIBNumber.EditValue
                    newRow("pib_date") = DEPIB.EditValue

                    TryCast(FormPIBPPS.GCPIBPPps.DataSource, DataTable).Rows.Add(newRow)

                    Close()
                End If
            End If
        Else
            warningCustom("Please pick budget first")
        End If
    End Sub

    Private Sub GVSummary_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSummary.FocusedRowChanged
        view_det()
    End Sub

    Sub view_det()
        If GVSummary.RowCount > 0 Then
            TEPIBNumberOld.Text = GVSummary.GetFocusedRowCellValue("pib_no").ToString
            DEPIBOld.EditValue = GVSummary.GetFocusedRowCellValue("pib_date")
            '
            TEPIBNumber.Text = GVSummary.GetFocusedRowCellValue("pib_no").ToString
            DEPIB.EditValue = GVSummary.GetFocusedRowCellValue("pib_date")
        End If
    End Sub

    Private Sub GVSummary_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSummary.ColumnFilterChanged
        view_det()
    End Sub
End Class