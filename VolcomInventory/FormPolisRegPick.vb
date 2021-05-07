﻿Public Class FormPolisRegPick
    Private Sub BRefreshPenawaran_Click(sender As Object, e As EventArgs) Handles BRefreshPenawaran.Click
        load_pps()
    End Sub

    Sub load_pps()
        Dim q As String = "SELECT pps.id_polis_pps,pps.number,sts.report_status,emp.employee_name,pps.created_by,IF(pps.id_report_status=6 OR pps.id_report_status=5,'',IF(pps.step=1,'Waiting nilai stock',IF(pps.step=2,'Waiting nilai lainnya',IF(pps.step=3,'Waiting penawaran vendor','Waiting approval')))) as step_desc
FROM tb_polis_pps pps
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
LEFT JOIN tb_polis_reg reg ON reg.id_polis_pps=pps.id_polis_pps AND reg.id_report_status!=5
WHERE pps.id_report_status=6 AND ISNULL(reg.id_polis_reg)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPolisPPS.DataSource = dt
        GVPolisPPS.BestFitColumns()
    End Sub

    Private Sub FormPolisRegPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If GVPolisPPS.RowCount > 0 Then
            FormPolisReg.id_polis_pps = GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString
            '
            Dim id_reg As String = ""
            Dim q As String = "INSERT INTO tb_polis_reg(id_polis_pps,created_date,created_by,id_report_status) VALUES(" & GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString & ",NOW(),'" & id_user & "',1); SELECT LAST_INSERT_ID(); "
            id_reg = execute_query(q, -1, True, "", "", "", "")
            '
            Close()
        End If
    End Sub

    Private Sub FormPolisRegPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pps()
    End Sub
End Class