Public Class FormBulanImport
    Private Sub FormBulanImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearStart.EditValue = Now()
        DEYearUntil.EditValue = Now()
        DEYearInput.EditValue = Now()
        '
    End Sub

    Private Sub BViewInput_Click(sender As Object, e As EventArgs) Handles BViewInput.Click
        view_input()
    End Sub

    Sub view_input()
        Dim q As String = "SELECT id_month,month_ind,bi.`bulan`,IF(ISNULL(bi.`bulan`),'no','yes') AS rencana_import
FROM `tb_lookup_month` lm
LEFT JOIN tb_bulan_import bi ON bi.`bulan`=lm.`id_month` AND bi.`year`='" & Date.Parse(DEYearInput.EditValue.ToString).ToString("yyyy") & "'
ORDER BY lm.`id_month` ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPlan.DataSource = dt
    End Sub

    Private Sub BUpdateDuty_Click(sender As Object, e As EventArgs) Handles BUpdateDuty.Click
        If GVPlan.RowCount > 0 Then
            Dim q As String = "DELETE FROM tb_bulan_import WHERE `year`='" & Date.Parse(DEYearInput.EditValue.ToString).ToString("yyyy") & "'"
            execute_non_query(q, True, "", "", "", "")
            '
            GVPlan.ActiveFilterString = "[rencana_import]='yes'"
            If GVPlan.RowCount > 0 Then
                q = "INSERT INTO tb_bulan_import(year,bulan) VALUES"
                For i = 0 To GVPlan.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & Date.Parse(DEYearInput.EditValue.ToString).ToString("yyyy") & "','" & GVPlan.GetRowCellValue(i, "id_month").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
            End If
            GVPlan.ActiveFilterString = ""
        End If
    End Sub

    Sub del_all()
        For i = GVPlan.RowCount - 1 To 0 Step -1
            GVPlan.DeleteRow(i)
        Next
    End Sub

    Private Sub DEYearInput_EditValueChanged(sender As Object, e As EventArgs) Handles DEYearInput.EditValueChanged
        del_all()
    End Sub

    Private Sub DEYearStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEYearStart.EditValueChanged
        DEYearUntil.Properties.MinValue = DEYearStart.EditValue
    End Sub

    Private Sub DEYearUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEYearUntil.EditValueChanged
        DEYearStart.Properties.MaxValue = DEYearUntil.EditValue
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        view_summary()
    End Sub

    Sub view_summary()
        Dim q As String = "SELECT bi.`year`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[1]')>0,'yes','no') AS `jan`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[2]')>0,'yes','no') AS `feb`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[3]')>0,'yes','no') AS `mar`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[4]')>0,'yes','no') AS `apr`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[5]')>0,'yes','no') AS `may`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[6]')>0,'yes','no') AS `jun`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[7]')>0,'yes','no') AS `jul`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[8]')>0,'yes','no') AS `aug`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[9]')>0,'yes','no') AS `sep`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[10]')>0,'yes','no') AS `oct`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[11]')>0,'yes','no') AS `nov`
,IF(INSTR(GROUP_CONCAT('[',bi.`bulan`,']'),'[12]')>0,'yes','no') AS `dec`
,COUNT(bi.bulan) AS jml_bln
FROM `tb_bulan_import` bi
WHERE bi.`year`>='" & Date.Parse(DEYearStart.EditValue.ToString).ToString("yyyy") & "' AND bi.`year`<='" & Date.Parse(DEYearUntil.EditValue.ToString).ToString("yyyy") & "'
GROUP BY bi.`year`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCSummary.DataSource = dt
    End Sub
End Class