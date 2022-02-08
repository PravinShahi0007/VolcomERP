Public Class FormPIBPPS
    Public id As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormPIBPPS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPIBPPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        '
        If id = "-1" Then 'new

        Else 'edit
            Dim q As String = "SELECT pps.number,emp.employee_name,pps.created_date,pps.note,pps.id_report_status
FROM tb_pib_pps pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE pps.id_pib_pps='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TENumber.Text = dt.Rows(0)("number").ToString
                DECreated.EditValue = dt.Rows(0)("created_date")
                MENote.Text = dt.Rows(0)("note").ToString
                TEProposedBy.Text = dt.Rows(0)("employee_name").ToString
                '
                If dt.Rows(0)("id_report_status").ToString = "6" Or dt.Rows(0)("id_report_status").ToString = "5" Then
                    BtnSave.Visible = False
                    is_view = "1"
                End If
                '
            End If
            BtnAttachment.Visible = True
            BtnPrint.Visible = True
            BtnMark.Visible = True
        End If

        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT f.number AS pre_cal_fgpo_number,f.id_pre_cal_fgpo,GROUP_CONCAT(CONCAT(po.prod_order_number,' - ',cd.class,' ',dsg.design_name,' ',cd.color) SEPARATOR '\n') AS list_fgpo
,ppsd.old_pib_no,ppsd.old_pib_date,ppsd.pib_no,ppsd.pib_date,ppsd.old_vp_due_date,ppsd.vp_due_date
FROM tb_pre_cal_fgpo_list fl
INNER JOIN tb_pre_cal_fgpo f ON f.id_pre_cal_fgpo=fl.id_pre_cal_fgpo
INNER JOIN `tb_pib_pps_det` ppsd ON ppsd.id_pre_cal_fgpo=f.id_pre_cal_fgpo AND ppsd.id_pib_pps='" & id & "'
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
        GCPIBPPps.DataSource = dt
        GVPIBPps.BestFitColumns()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        del()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        FormPIBPPSDet.ShowDialog()
    End Sub

    Sub del()
        If GVPIBPps.RowCount > 0 Then
            GVPIBPps.DeleteSelectedRows()
            GCPIBPPps.RefreshDataSource()
            GVPIBPps.RefreshData()
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "359"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = "359"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Not BGVPIBPPS.RowCount > 0 Then
            warningCustom("Please pick isb first")
        Else
            If id = "-1" Then 'new
                Dim q As String = "INSERT INTO `tb_pib_pps`(created_by,created_date,`note`) VALUES('" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "'); SELECT LAST_INSERT_ID(); "
                id = execute_query(q, 0, True, "", "", "", "")
                '
                q = "CALL gen_number('" & id & "','359')"
                execute_non_query(q, True, "", "", "", "")
                '
                q = "INSERT INTO `tb_pib_pps_det`(`id_pib_pps`,`id_pre_cal_fgpo`,`old_pib_no`,`old_pib_date`,`old_vp_due_date`,`pib_no`,`pib_date`,`vp_due_date`) VALUES"
                For i = 0 To BGVPIBPPS.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & BGVPIBPPS.GetRowCellValue(i, "id_pre_cal_fgpo").ToString & "','" & addSlashes(BGVPIBPPS.GetRowCellValue(i, "old_pib_no").ToString) & "','" & Date.Parse(BGVPIBPPS.GetRowCellValue(i, "old_pib_date").ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(BGVPIBPPS.GetRowCellValue(i, "old_vp_due_date").ToString).ToString("yyyy-MM-dd") & "','" & addSlashes(BGVPIBPPS.GetRowCellValue(i, "pib_no").ToString) & "','" & Date.Parse(BGVPIBPPS.GetRowCellValue(i, "pib_date").ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(BGVPIBPPS.GetRowCellValue(i, "vp_due_date").ToString).ToString("yyyy-MM-dd") & "')"
                Next
                execute_non_query(q, True, "", "", "", "")

                'mark
                submit_who_prepared("359", id, id_user)

                infoCustom("PIB detail proposed")

                Close()
            Else 'edit
                execute_non_query("UPDATE tb_pib_pps SET `note`='" & addSlashes(MENote.Text) & "' WHERE id_pib_pps='" & id & "'", True, "", "", "", "")
                '
                Dim q As String = ""
                '
                execute_non_query("DELETE FROM tb_pib_pps_det WHERE id_pib_pps='" & id & "'", True, "", "", "", "")
                '
                q = "INSERT INTO `tb_pib_pps_det`(`id_pib_pps`,`id_pre_cal_fgpo`,`old_pib_no`,`old_pib_date`,`old_vp_due_date`,`pib_no`,`pib_date`,`vp_due_date`) VALUES"
                For i = 0 To BGVPIBPPS.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id & "','" & BGVPIBPPS.GetRowCellValue(i, "id_pre_cal_fgpo").ToString & "','" & addSlashes(BGVPIBPPS.GetRowCellValue(i, "old_pib_no").ToString) & "','" & Date.Parse(BGVPIBPPS.GetRowCellValue(i, "old_pib_date").ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(BGVPIBPPS.GetRowCellValue(i, "old_vp_due_date").ToString).ToString("yyyy-MM-dd") & "','" & addSlashes(BGVPIBPPS.GetRowCellValue(i, "pib_no").ToString) & "','" & Date.Parse(BGVPIBPPS.GetRowCellValue(i, "pib_date").ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(BGVPIBPPS.GetRowCellValue(i, "vp_due_date").ToString).ToString("yyyy-MM-dd") & "')"
                Next
                execute_non_query(q, True, "", "", "", "")

                infoCustom("PIB detail updated")

                Close()
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim q As String = "SELECT pps.number,emp.employee_name,DATE_FORMAT(pps.created_date,'%d %M %Y') AS created_date,pps.note
FROM tb_pib_pps pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE pps.id_pib_pps='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            ReportPIBPPS.id = id
            ReportPIBPPS.dt = GCPIBPPps.DataSource
            Dim Report As New ReportPIBPPS()
            Report.DataSource = dt

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
    End Sub
End Class