Public Class FormBiayaSewa
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormReportAccClosing_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormReportAccClosing_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub load_biaya_sewa()
        Dim qw As String = ""

        If Not SLEUnit.EditValue.ToString = "0" Then
            qw = " AND bs.is_unit='" & SLEUnit.EditValue.ToString & "'"
        End If

        Dim q As String = "SELECT bs.*,ROUND(bs.`total_uang_muka`/bs.`total_bulan`,2) AS biaya_bulanan,CONCAT(acc2.`acc_name`,' - ',acc2.acc_description) AS acc_uang_muka,CONCAT(acc.`acc_name`,' - ',acc.acc_description) AS acc_biaya,emp.`employee_name` 
FROM tb_biaya_sewa bs
INNER JOIN tb_m_user usr ON usr.`id_user`=bs.`insert_by`
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.`id_employee`
INNER JOIN tb_a_acc acc ON acc.`id_acc`=bs.`coa_biaya`
INNER JOIN tb_a_acc acc2 ON acc2.`id_acc`=bs.`coa_uang_muka`
WHERE bs.is_active=2 " & qw & " ORDER BY id_biaya_sewa DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub FormBiayaSewa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If XTCBiayaSewa.SelectedTabPageIndex = 1 Then
            FormBiayaSewaBulanan.ShowDialog()
        End If
    End Sub

    Private Sub FormBiayaSewa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_unit()
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT 0 AS id_coa_tag,'ALL' AS tag_code,'ALL' AS tag_description 
UNION ALL
SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        'query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        If XTCBiayaSewa.SelectedTabPageIndex = 0 Then
            load_biaya_sewa()
        ElseIf XTCBiayaSewa.SelectedTabPageIndex = 1 Then
            load_biaya_bulanan_pps()
        End If
    End Sub

    Sub load_biaya_bulanan_pps()
        Dim q As String = "SELECT ct.tag_description,SUM(ppsd.alokasi_biaya_per_bulan) AS dep_value_tot,pps.*,emp.employee_name,sts.report_status 
FROM `tb_biaya_sewa_bulanan_det` ppsd
INNER JOIN `tb_biaya_sewa_bulanan` pps ON pps.id_biaya_sewa_bulanan=ppsd.id_biaya_sewa_bulanan
INNER JOIN tb_coa_tag ct ON ct.id_coa_tag=pps.id_coa_tag
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON pps.id_report_status=sts.id_report_status
GROUP BY ppsd.id_biaya_sewa_bulanan
ORDER BY ppsd.id_biaya_sewa_bulanan DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCMonthlyPPS.DataSource = dt
        GVMonthlyPPS.BestFitColumns()
    End Sub

    Private Sub GVMonthlyPPS_DoubleClick(sender As Object, e As EventArgs) Handles GVMonthlyPPS.DoubleClick
        If GVMonthlyPPS.RowCount > 0 Then
            FormBiayaSewaBulanan.id_biaya_bulanan = GVMonthlyPPS.GetFocusedRowCellValue("id_biaya_sewa_bulanan").ToString
            FormBiayaSewaBulanan.ShowDialog()
        End If
    End Sub
End Class