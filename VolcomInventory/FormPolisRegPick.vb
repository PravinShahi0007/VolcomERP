Public Class FormPolisRegPick
    Private Sub BRefreshPenawaran_Click(sender As Object, e As EventArgs) Handles BRefreshPenawaran.Click
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            load_pps()
        Else
            load_pps_kolektif()
            load_kolektif()
        End If
    End Sub

    Sub load_pps()
        Dim q As String = "SELECT pps.id_polis_pps,pps.number,sts.report_status,emp.employee_name,pps.created_by,IF(pps.id_report_status=6 OR pps.id_report_status=5,'',IF(pps.step=1,'Waiting nilai stock',IF(pps.step=2,'Waiting nilai lainnya',IF(pps.step=3,'Waiting penawaran vendor','Waiting approval')))) as step_desc
FROM tb_polis_pps pps
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
LEFT JOIN tb_polis_reg reg ON reg.id_polis_pps=pps.id_polis_pps AND reg.id_report_status!=5
WHERE pps.id_report_status=6 AND ISNULL(reg.id_polis_reg) AND pps.id_pps_type='2'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPolisPPS.DataSource = dt
        GVPolisPPS.BestFitColumns()
    End Sub

    Sub load_pps_kolektif()
        Dim q As String = "SELECT pps.id_polis_pps,pps.number,sts.report_status,emp.employee_name,pps.created_by,IF(pps.id_report_status=6 OR pps.id_report_status=5,'',IF(pps.step=1,'Waiting nilai stock',IF(pps.step=2,'Waiting nilai lainnya',IF(pps.step=3,'Waiting penawaran vendor','Waiting approval')))) as step_desc
FROM tb_polis_pps pps
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
LEFT JOIN tb_polis_reg reg ON reg.id_polis_pps=pps.id_polis_pps AND reg.id_report_status!=5
WHERE pps.id_report_status=6 AND ISNULL(reg.id_polis_reg) AND pps.id_pps_type='1'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPolisPPS.DataSource = dt
        GVPolisPPS.BestFitColumns()
    End Sub

    Private Sub FormPolisRegPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            'mandiri
            If GVPolisPPS.RowCount > 0 Then
                FormPolisReg.id_polis_pps = GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString
                '
                Dim id_reg As String = ""
                Dim q As String = "INSERT INTO tb_polis_reg(id_polis_pps,created_date,created_by,id_report_status) VALUES(" & GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString & ",NOW(),'" & id_user & "',1); SELECT LAST_INSERT_ID(); "
                id_reg = execute_query(q, 0, True, "", "", "", "")
                '
                q = "CALL gen_number('" & id_reg & "','309')"
                execute_non_query(q, True, "", "", "", "")

                'mandiri perlu vendor dan nomor polis
                'add details
                q = "INSERT INTO `tb_polis_reg_det`(`id_polis_reg`,`id_polis_pps_det`,`rekomendasi_vendor`,`rekomendasi_premi`,`vendor_dipilih`,`premi`,`polis_number`,`id_desc_premi`)
SELECT '" & id_reg & "' AS id_polis_reg,ppsd.id_polis_pps_det,ppsd.`polis_vendor` AS rekomendasi_vendor,ppsd.`premi` AS rekomendasi_premi,ppsd.`polis_vendor` AS vendor_dipilih,ppsd.`premi` AS premi,'' AS polis_number,pps.`id_desc_premi`
FROM `tb_polis_pps_det` ppsd
INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps`
WHERE ppsd.id_polis_pps='" & GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString & "'"
                '
                FormPolisReg.id_reg = id_reg
                '
                Close()
            End If
        Else
            'kolektif
            If GVPolisPPS.RowCount > 0 Then
                FormPolisReg.id_polis_pps = GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString
                '
                Dim id_reg As String = ""
                Dim q As String = "INSERT INTO tb_polis_reg(id_polis_pps,created_date,created_by,id_report_status) VALUES(" & GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString & ",NOW(),'" & id_user & "',1); SELECT LAST_INSERT_ID(); "
                id_reg = execute_query(q, 0, True, "", "", "", "")
                '
                q = "CALL gen_number('" & id_reg & "','309')"
                execute_non_query(q, True, "", "", "", "")
                '
                'kolektif perlu premi
                'add details
                q = "INSERT INTO `tb_polis_reg_det`(`id_polis_reg`,`id_polis_pps_det`,`rekomendasi_vendor`,`rekomendasi_premi`,`vendor_dipilih`,`premi`,`polis_number`,`id_desc_premi`)
SELECT '" & id_reg & "' AS id_polis_reg,ppsd.id_polis_pps_det,(SELECT id_vendor FROM  `tb_polis_pps_kolektif` WHERE is_recommended=1 AND id_polis_pps='" & GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString & "' LIMIT 1) AS rekomendasi_vendor,0 AS rekomendasi_premi,'" & SLEPenawaran.EditValue.ToString & "' AS vendor_dipilih,0 AS premi,'" & addSlashes(TENomorPolis.Text) & "' AS polis_number,pps.`id_desc_premi`
FROM `tb_polis_pps_det` ppsd
INNER JOIN tb_polis_pps pps ON pps.`id_polis_pps`=ppsd.`id_polis_pps`
WHERE ppsd.id_polis_pps='" & GVPolisPPS.GetFocusedRowCellValue("id_polis_pps").ToString & "'"
                '

                FormPolisReg.id_reg = id_reg
                '
                Close()
            End If
        End If
    End Sub

    Private Sub FormPolisRegPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pps()
    End Sub

    Private Sub GVPPSKolektif_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPPSKolektif.FocusedRowChanged
        load_kolektif()
    End Sub

    Private Sub GVPPSKolektif_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVPPSKolektif.ColumnFilterChanged
        load_kolektif()
    End Sub

    Sub load_kolektif()
        If GVPPSKolektif.RowCount > 0 Then
            Dim q As String = "-1"
            q = "SELECT c.id_comp,c.comp_number,c.comp_name 
FROM tb_polis_pps_vendor ppsv
INNER JOIN tb_m_comp c ON c.id_comp=ppsv.id_vendor
WHERE ppsv.id_polis_pps='" & GVPPSKolektif.GetFocusedRowCellValue("id_polis_pps").ToString & "'
GROUP BY ppsv.id_vendor"
            viewSearchLookupQuery(SLEPenawaran, q, "id_comp", "comp_name", "id_comp")
        End If
    End Sub
End Class